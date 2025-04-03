using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;

// import the GameSolver namespace
using GameSolver;

namespace SudokuGameApp
{
    [Localizable(true)]
    public partial class SudokuApp : Form
    {
        /// <summary>
        /// Filters input to digits only.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void filterInput(object? sender, KeyPressEventArgs e)
        {
            // Check if the key is control and digit, if true return it
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }

            // otherwise return false
            e.Handled = false;
        }

        /// <summary>
        ///  Represents an input cell based on <see cref="RichTextBox" /> class.
        /// </summary>
        public class InputCell : RichTextBox
        {
            /// <summary>
            /// Initializes a new instance of <see cref="InputCell" /> class.
            /// </summary>
            public InputCell()
            {
                MaxLength = 1;
                TabIndex = 0;
                Multiline = false;
                DetectUrls = false;
                ScrollBars = RichTextBoxScrollBars.None;
                SelectionAlignment = HorizontalAlignment.Center;
                Font = new Font("NSimSun", 18, FontStyle.Bold);
            }

            /// <summary>
            /// Gets or sets an array of cell coordinates.
            /// </summary>
            /// <returns>32-bit integer of <c>X</c> and <c>Y</c> coordinates.</returns>
            public int[] Position
            {
                get => new int[2] {
                    (TabIndex-1) / 9,
                    (TabIndex-1) % 9
                };

                set => Position = value;
            }

            protected override void OnTextChanged(EventArgs e)
            {
                // skip inicialization
                if (TabIndex == 0)
                {
                    return;
                }

                // Check if event should do something or just skip
                if (this.Text.Length == 0)
                {
                    this.BackColor = Color.White;
                    return;
                }

                // convert the input to 32-bit integer if possible
                int number;
                if (!int.TryParse(this.Text, out number) || (number < 1 || number > 9))
                {
                    this.Text = string.Empty;
                    return;
                }

                // get the cell coordinates
                int xCoord = this.Position[0];
                int yCoord = this.Position[1];

                // get the sudoku grid and create empty 2 dimensional array
                TableLayoutPanel sudokuGrid = (TableLayoutPanel)this.Parent;
                int[,] data = new int[9, 9];

                // fill the table with all the inputs
                for (int xIterator = 0; xIterator < sudokuGrid.RowCount; xIterator++)
                {
                    for (int yIterator = 0; yIterator < sudokuGrid.ColumnCount; yIterator++)
                    {
                        // if the current coords are the same as input, skip
                        if (xIterator == xCoord && yIterator == yCoord)
                        {
                            continue;
                        }

                        // get the cell from the grid by coordinates
                        RichTextBox cell = (RichTextBox)sudokuGrid.GetControlFromPosition(yIterator, xIterator);

                        // if the cell is not empty, parse it to integer and add to the array
                        if (cell.Text != null && cell.Text.Length > 0)
                        {
                            data[xIterator, yIterator] = int.Parse(cell.Text);
                        }
                    }
                }

                if (!showCollisions)
                {
                    return;
                }

                // check if the number can be placed in the cell
                if (!Sudoku.canBePlaced(data, xCoord, yCoord, number))
                {
                    this.BackColor = Color.Red;
                }
                // if it can be placed, set the background to white
                else
                {
                    this.BackColor = Color.White;
                }

            }

        }

        ///// <summary>
        ///// Represents a cell of possibilities based on <see cref="RichTextBox" /> class.
        ///// </summary>
        //public class PossibilitiesCell : RichTextBox
        //{
        //    public PossibilitiesCell()
        //    {
        //        Multiline = true;
        //        DetectUrls = false;
        //        ScrollBars = RichTextBoxScrollBars.None;
        //        SelectionAlignment = HorizontalAlignment.Right;
        //        Font = new Font("Courier", 9, FontStyle.Bold);
        //        ReadOnly = true;
        //        Size = new Size(56, 24);
        //    }
        //}

        /// <summary>
        /// Initializes a new instance of <see cref="SudokuApp" /> class.
        /// </summary>
        public SudokuApp()
        {
            InitializeComponent();

            // set the input filter
            renderToTable(null);
        }

        // Define difficulty level for puzzle generation
        private Sudoku.DIFFICULTY generationDifficulty = Sudoku.DIFFICULTY.GARDEN;
        private bool useMultiThreading = false;
        /// <summary><c>true</c> if showing realtime collisions are on, <c>false</c> otherwise.</summary>
        public static bool showCollisions = true;

        // define timer variables
        private bool isTimerEnabled = false;
        private int timeInMin = 0;
        private int timeInSec = 0;
        private int timeInCs = 0;

        /// <summary>
        /// Reads the input from the table and returns it as a 2 dimensional array.
        /// </summary>
        /// <returns>2 dimensional array of integers.</returns>
        public int[,] readFromTable()
        {
            // get the sudoku grid and create empty 2 dimensional array
            int rowCount = sudokuGrid.RowCount;
            int columnCount = sudokuGrid.ColumnCount;

            int[,] data = new int[rowCount, columnCount];

            // fill the table with all the inputs
            for (int xIterator = 0; xIterator < rowCount; xIterator++)
            {
                for (int yIterator = 0; yIterator < columnCount; yIterator++)
                {
                    // get the cell from the grid by coordinates
                    RichTextBox cell = (RichTextBox)sudokuGrid.GetControlFromPosition(yIterator, xIterator);

                    // if the cell is not empty, parse it to integer and add to the array
                    if (cell != null && cell.Text.Length > 0)
                    {
                        data[xIterator, yIterator] = Int32.Parse(cell.Text);
                    }
                }
            }

            // return the array
            return data;
        }

        /// <summary>
        /// Renders the input to the table.
        /// </summary>
        /// <param name="data">2 dimensional array of integers.</param>
        public void renderToTable(int[,]? data, bool ignoreForeColorsForGeneration = false)
        {
            // get the sudoku grid and create empty 2 dimensional array
            int rowCount = sudokuGrid.RowCount;
            int columnCount = sudokuGrid.ColumnCount;
            int gridIndex = -1;

            // if the data is null, clear the grid
            if (data == null)
            {
                sudokuGrid.Controls.Clear();
            }

            // Go through sudoku grid and append input cells
            for (int xIterator = 0; xIterator < rowCount; xIterator++)
            {
                for (int yIterator = 0; yIterator < columnCount; yIterator++)
                {
                    gridIndex++;

                    // if the data is null, initialize new cell
                    if (data == null || data.Length == 0)
                    {
                        // Initialize new cell
                        InputCell newCell = new InputCell();
                        newCell.TabIndex = gridIndex + 1;

                        // add the cell to the grid
                        sudokuGrid.Controls.Add(newCell, yIterator, xIterator);
                        continue;
                    }

                    // get the cell from the grid by coordinates
                    int cellValue = data[xIterator, yIterator];
                    if (sudokuGrid.Controls.Count < 1)
                    {
                        return;
                    }

                    Control origin = sudokuGrid.Controls[gridIndex];
                    int originValue;

                    // try parsing the origin value to integer and compare it to the cell value
                    if (ignoreForeColorsForGeneration || (int.TryParse(origin.Text, out originValue) && cellValue == originValue))
                    {
                        if (cellValue == 0)
                        {
                            origin.ForeColor = Color.Gray;
                        }
                        else origin.ForeColor = Color.Black;
                    }
                    else
                    {
                        origin.ForeColor = Color.Gray;
                    }

                    // set the cell color and value
                    origin.BackColor = Color.White;
                    origin.Text = cellValue != 0 ? cellValue.ToString() : string.Empty;
                }
            }

        }

        /// <summary>
        /// Handles the click event of the rules button.
        /// </summary>
        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            // close the application
            this.Close();
        }

        /// <summary>
        /// Handles the click event of the solve button.
        /// </summary>
        private void threadingBox_CheckedChanged(object sender, EventArgs e)
        {
            if (threadingBox.Checked)
            {
                // enable the input
                maxThreadsToUseInput.ReadOnly = false;
                maxThreadsToUseInput.BackColor = SystemColors.Window;
            }
            else
            {
                // disable the input
                maxThreadsToUseInput.ReadOnly = true;
                maxThreadsToUseInput.BackColor = Color.RosyBrown;
            }

            useMultiThreading = threadingBox.Checked;
        }

        /// <summary>
        /// Handles the input filtering for the max threads to use.
        /// </summary>
        private void maxThreadsToUseInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allow only numbers and backspace
            filterInput(sender, e);
        }

        /// <summary>
        /// Handles solving the solve button click event.
        /// </summary>
        private void solveButton_Click(object sender, EventArgs e)
        {
            // get the user's input
            int[,] currentPuzzle = readFromTable();
            bool useThreading = threadingBox.Checked;

            // check if the user entered a valid number of threads
            if (!SByte.TryParse(maxThreadsToUseInput.Text, out sbyte numberOfThreads))
            {
                responseMessageBox.Text = _handle_solver_message_culture("Invalid number of threads!");
            };

            // create new sudoku solver and pass settings to it
            Sudoku gameSolver;

            // start the timer
            var watch = System.Diagnostics.Stopwatch.StartNew();
            bool isSolved;
            try
            {
                // create new sudoku solver and pass settings to it
                gameSolver = new Sudoku(currentPuzzle, useThreading, numberOfThreads);
                // solve it and wait for bool value
                isSolved = gameSolver.Solve();
            }
            // catch the errors and return them to the interface
            catch (GameInputInvalid exception)
            {
                isSolved = false;
                responseMessageBox.Text = _handle_solver_message_culture(exception.Message);
                return;
            }

            // stop the timer
            watch.Stop();

            string message = "";

            if (isSolved)
            {
                string currentCulture = Thread.CurrentThread.CurrentCulture.Name;
                switch (currentCulture)
                {
                    case "de-DE":
                        message = $"Löse das Sudoku-Rätsel in {watch.ElapsedMilliseconds}ms!";
                        break;
                    case "ja-JP":
                        message = $"数独を{watch.ElapsedMilliseconds}msで解いた!";
                        break;
                    default:
                        message = $"Solved the sudoku puzzle in {watch.ElapsedMilliseconds}ms!";
                        break;
                }


            }
            else message = _handle_solver_message_culture("This puzzle cannot be solved!");

            responseMessageBox.Text = message;

            // render the solved puzzle to the table
            renderToTable(gameSolver.gameBoard);
        }

        /// <summary>
        /// Handles the click event of the clear board button.
        /// </summary>
        private void clearBoardButton_Click(object sender, EventArgs e)
        {
            // clear the table
            renderToTable(null);
        }

        /// <summary>
        /// Handles the click event of the file save menu.
        /// </summary>
        private void fileSaveMenu_Click(object sender, EventArgs e)
        {
            // open file dialog
            SaveFileDialog fileDialog = new SaveFileDialog();
            // set the filters
            fileDialog.Filter = "sudoku files (*.sudoku)|*.sudoku";
            fileDialog.FilterIndex = 1;
            fileDialog.RestoreDirectory = true;

            // if the user selected a file, write the sudoku to it
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                // get the sudoku grid and create empty 2 dimensional array
                int[,] data = readFromTable();

                GameSolver.GameSolver.ExtensionMethods.writeSudokuToFile(fileDialog.FileName, data);
            }
        }

        private string _handle_solver_message_culture(string message)
        {
            var currentCulture = Thread.CurrentThread.CurrentCulture.Name;

            if (currentCulture == "de-DE")
            {
                switch (message)
                {
                    case "The number of threads must be greater than 1!":
                        message = "Die Anzahl der Threads muss größer als 1 sein!";
                        break;
                    case "The board cannot be null!":
                        message = "Der Vorstand kann nicht null sein!";
                        break;
                    case "The board must be 9x9!":
                        message = "Das Brett muss 9x9 sein!";
                        break;
                    case "This puzzle cannot be solved!":
                        message = "Dieses Rätsel ist unlösbar!";
                        break;
                    default:
                        message = "Ungültige Eingabe!";
                        break;
                }
            }
            else if (currentCulture == "ja-JP")
            {
                switch (message)
                {
                    case "The number of threads must be greater than 1!":
                        message = "スレッド数は1より大きくなければならない!";
                        break;
                    case "The board cannot be null!":
                        message = "ボードがNULLになることはありえない!";
                        break;
                    case "The board must be 9x9!":
                        message = "ボードは9x9でなければならない";
                        break;
                    case "This puzzle cannot be solved!":
                        message = "このパズルは解けません!";
                        break;
                    default:
                        message = "入力が無効です";
                        break;
                }
            }

            return message;
        }

        /// <summary>
        /// Handles the click event of the file load menu.
        /// </summary>
        private void fileLoadMenu_Click(object sender, EventArgs e)
        {
            // open file dialog
            OpenFileDialog fileDialog = new OpenFileDialog();
            // set the filters
            fileDialog.Filter = "sudoku files (*.sudoku)|*.sudoku";
            fileDialog.FilterIndex = 1;
            fileDialog.RestoreDirectory = true;

            // if the user selected a file, read the sudoku from it
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                // read the sudoku from the file and render it to the table
                int[,] data = GameSolver.GameSolver.ExtensionMethods.readSudokuFromFile(fileDialog.FileName);

                clearBoardButton_Click((object)sender, new EventArgs());

                renderToTable(data, true);
            }
        }

        /// <summary>
        /// Handles the click event of the check answers button.
        /// </summary>
        private void checkCollisions_Click(object sender, EventArgs e)
        {
            if (!showCollisions)
            {
                return;
            }

            int[,] board = readFromTable();
            renderToTable(board);
        }

        /// <summary>
        /// Handles new puzzle generation.
        /// </summary>
        private void generatePuzzle_Click(object sender, EventArgs e)
        {
            int[,] board = new int[9, 9];
            int[,] newPuzzle;

            try
            {
                Sudoku gameSolver = new Sudoku(board);
                newPuzzle = gameSolver.GenerateSudoku(this.generationDifficulty);
            }
            catch (GameInputInvalid exception)
            {
                responseMessageBox.Text = exception.Message;
                return;
            }

            // render the generated content
            renderToTable(null);
            renderToTable(newPuzzle, true);
        }

        /////////////////////////////////////////////////////////
        //                   TIMER HANDLERS                    // 
        /////////////////////////////////////////////////////////
        private void timer1_Tick(object sender, EventArgs e)
        {
            // if the timer is not enabled, return
            if (!isTimerEnabled)
            {
                return;
            }

            // increment the time
            timeInCs += 12;

            if (timeInCs >= 100)
            {
                timeInSec++;
                timeInCs = 0;
            }

            if (timeInSec >= 60)
            {
                timeInMin++;
                timeInSec = 0;
            }

            DisplayTime();
        }

        /// <summary>
        /// Resets the timer.
        /// </summary>
        /// <remarks>Calls the <see cref="DisplayTime"/> method.</remarks>
        private void ResetTime()
        {
            resetTimer.Enabled = false;

            timeInSec = 0;
            timeInMin = 0;
            timeInCs = 0;

            DisplayTime();
        }

        /// <summary>
        /// Displays the time.
        /// </summary>
        private void DisplayTime()
        {
            timerLabel.Text = String.Format("{0:00}", timeInMin) + ":";
            timerLabel.Text += String.Format("{0:00}", timeInSec) + ":";
            timerLabel.Text += String.Format("{0:00}", timeInCs);
        }

        private void timerButton_Click(object sender, EventArgs e)
        {
            resetTimer.Enabled = isTimerEnabled;
            isTimerEnabled = !isTimerEnabled;

            _handle_culture_timer_text();
        }

        private void _handle_culture_timer_text()
        {
            string currentCulture = Thread.CurrentThread.CurrentCulture.Name;

            if (currentCulture == "de-DE")
            {
                timerButton.Text = isTimerEnabled ? "Timer Stopp" : "Timer Starten";
            }
            else if (currentCulture == "ja-JP")
            {
                timerButton.Text = isTimerEnabled ? "ストップタイマー" : "スタートタイマー";
            }
            else
            {
                timerButton.Text = isTimerEnabled ? "Stop Timer" : "Start Timer";
            }
        }

        private void resetTimer_Click(object sender, EventArgs e)
        {
            if (isTimerEnabled)
            {
                return;
            }

            ResetTime();
        }

        /////////////////////////////////////////////////////////
        //                MENU ITEM HANDLERS                   // 
        /////////////////////////////////////////////////////////
        private void startTimerMenuItem_Click(object sender, EventArgs e)
        {
            resetTimer.Enabled = false;
            isTimerEnabled = true;

            _handle_culture_timer_text();
        }

        private void stopTimerMenuItem_Click(object sender, EventArgs e)
        {
            resetTimer.Enabled = true;
            isTimerEnabled = false;
            _handle_culture_timer_text();
        }

        private void offToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resetTimer.Visible = false;
            isTimerEnabled = false;
            timerButton.Visible = false;
            timerLabel.Visible = false;
            sudokuGrid.Location = new Point(376, 69);
            _handle_culture_timer_text();
        }

        private void showTimerOnMenuItem_Click(object sender, EventArgs e)
        {
            resetTimer.Visible = true;
            timerButton.Visible = true;
            timerLabel.Visible = true;
            sudokuGrid.Location = new Point(376, 51);
        }

        // Difficulty handlers
        private void likeAGardenDifficultyMenuItem_Click(object sender, EventArgs e)
        {
            this.generationDifficulty = Sudoku.DIFFICULTY.GARDEN;
        }

        private void toasterDifficultyMenuItem_Click(object sender, EventArgs e)
        {
            this.generationDifficulty = Sudoku.DIFFICULTY.TOASTER;
        }

        private void hellDifficultyMenuItem_Click(object sender, EventArgs e)
        {
            this.generationDifficulty = Sudoku.DIFFICULTY.HELL;
        }

        private void ootwDifficultyMenuItem_Click(object sender, EventArgs e)
        {
            this.generationDifficulty = Sudoku.DIFFICULTY.OOTW;
        }

        /// <summary>
        /// Redirects to the Author's GitHub page.
        /// </summary>
        private void gitHubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _open_browser_url("https://github.com/DaRealAdalbertBro/sudoku-game");
        }

        /// <summary>
        /// Redirects to the rules page.
        /// </summary>
        private void helpRulesMenu_Click(object sender, EventArgs e)
        {
            _open_browser_url("https://sudoku.com/how-to-play/sudoku-rules-for-complete-beginners/#:~:text=Sudoku%20is%20played%20on%20a,the%20row%2C%20column%20or%20square.");
        }

        // Collision handlers
        private void collisionsOn_Click(object sender, EventArgs e)
        {
            showCollisions = true;
            checkCollisions.Enabled = true;

            renderToTable(readFromTable());
        }

        private void collisionsOff_Click(object sender, EventArgs e)
        {
            showCollisions = false;
            checkCollisions.Enabled = false;

            renderToTable(readFromTable());
        }

        // Threading handlers
        private void threadingOn_Click(object sender, EventArgs e)
        {
            useMultiThreading = true;
            threadingBox.Checked = true;
        }

        private void threadingOff_Click(object sender, EventArgs e)
        {
            useMultiThreading = false;
            threadingBox.Checked = false;
        }

        /////////////////////////////////////////////////////////
        //                 OTHER GAMES MENU                    // 
        /////////////////////////////////////////////////////////
        private void battleshipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _open_browser_url("https://github.com/DaRealAdalbertBro/BattleShip-minigame");
        }

        private void queenProblemStripMenuItem1_Click(object sender, EventArgs e)
        {
            _open_browser_url("https://github.com/DaRealAdalbertBro/N-Queen-Problem");
        }

        private void snowflakeIDGeneratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _open_browser_url("https://github.com/DaRealAdalbertBro/Snowflake-ID-Generator");
        }

        private void pathCollisionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _open_browser_url("https://github.com/DaRealAdalbertBro/Path-collision");
        }

        private void dDungeonBuilderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _open_browser_url("https://github.com/DaRealAdalbertBro/2D-Dungeon-Builder");
        }

        private void sevenBridgesOfKonigsbergToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _open_browser_url("https://github.com/DaRealAdalbertBro/Seven-Bridges-of-Konigsberg");
        }

        /////////////////////////////////////////////////////////
        //                    UNCATEGORIZED                    // 
        /////////////////////////////////////////////////////////

        /// <summary>
        /// Creates new browser process and redirects to the provided URL.
        /// </summary>
        /// <param name="t_url">URL destination.</param>
        private void _open_browser_url(string t_url = "https://google.com/")
        {
            Process.Start(new ProcessStartInfo { FileName = t_url, UseShellExecute = true });
        }

        public void SetCulture(string cultureName = "en-US")
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(cultureName);
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(cultureName);

            this.Hide();
            SudokuApp newApp = new SudokuApp();
            Application.CurrentCulture= CultureInfo.GetCultureInfo(cultureName);
            newApp.FormClosed += (s, args) => this.Close();
            newApp.Show();
        }

        private void englishLanguageMenuItem_Click(object sender, EventArgs e)
        {
            SetCulture();
        }

        private void germanLanguageMenuItem_Click(object sender, EventArgs e)
        {
            SetCulture("de-DE");
        }

        private void japaneseLanguageMenuItem_Click(object sender, EventArgs e)
        {
            SetCulture("ja-JP");
        }

    }
}