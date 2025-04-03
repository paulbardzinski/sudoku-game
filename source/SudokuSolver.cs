namespace GameSolver
{
    /// <summary>Provides the constructors and classes that are used in solving Sudoku puzzles.</summary>
    /// <remarks>This class inherits from the <see cref="Board" /> class.</remarks>
    /// <exception cref="GameInputInvalid">Thrown when the input is corrupted or invalid.</exception>
    public class Sudoku : Board
    {
        /// <summary>Enum for threading type.</summary>
        /// <remarks><c>SINGLE</c> = single threading, <c>MULTI</c> = multi threading</remarks>
        private enum _THREADING
        {
            SINGLE,
            MULTI
        };

        /// <summary>The threading type.</summary>
        private _THREADING _multi_threading;

        /// <summary>The max number of threads to use.</summary>
        private sbyte _max_threads = 1;

        /// <summary>Enum for difficulty type.</summary>
        public enum DIFFICULTY
        {
            GARDEN,
            TOASTER,
            HELL,
            OOTW
        }

        /// <summary>Public constructor.</summary>
        /// <param name="t_board">2 dimensional array of 32-bit integers.</param>
        /// <param name="t_multi_threading">Whether to use multi threading or not.</param>
        /// <param name="t_max_threads">Max number of threads to use, accepts <c>x > 1</c> thread count.</param>
        /// <exception cref="GameInputInvalid">Thrown when the input is corrupted or invalid.</exception>
        public Sudoku(int[,] t_board, bool t_multi_threading = false, sbyte t_max_threads = 1)
            : base(t_board)
        {
            // Change the board to the input board
            this.gameBoard = t_board;

            // decide whether to use single or multi threading based on user input
            this._multi_threading = t_multi_threading ? _THREADING.MULTI : _THREADING.SINGLE;

            if (t_multi_threading)
            {
                // if the number of threads is less than or equal to 1, return exception
                if (t_max_threads <= 1)
                {
                    throw new GameInputInvalid("The number of threads must be greater than 1!");
                }

                // if the number of threads is greater than the number of processors, set the number of threads to the number of processors
                if (t_max_threads > Environment.ProcessorCount)
                {
                    this._max_threads = (sbyte)Environment.ProcessorCount;
                }
                // Set the number of threads to the user input
                else
                {
                    this._max_threads = t_max_threads;
                }

                Console.WriteLine("Using multi-threading with " + this._max_threads + " threads.");
                return;
            }

            Console.WriteLine("Using single threading.");
        }

        // override the ChangeBoard method to check if the board size is 9x9
        /// <summary>Change the 9x9 board to the input.</summary>
        /// <param name="t_board">2 dimensional array of 32-bit integers.</param>
        /// <exception cref="GameInputInvalid">Thrown when the input is corrupted or invalid.</exception>
        override public void ChangeBoard(int[,]? t_board)
        {
            // if the board is null, return Game Input Invalid exception
            if (t_board == null)
            {
                throw new GameInputInvalid("The board cannot be null!");
            }
            // if the board is not 9x9, return Game Input Invalid exception
            else if (t_board.GetLength(0) != 9 || t_board.GetLength(1) != 9)
            {
                throw new GameInputInvalid("The board must be 9x9!");
            }

            // if the board is valid, change the board
            this.gameBoard = (int[,])t_board.Clone();
            this.originalBoard = (int[,])t_board.Clone();
        }

        /// <remarks><c>PrintSolution</c> method prints the board to the console.</remarks>
        /// <exception cref="GameInputInvalid">Thrown when the input is corrupted or invalid.</exception>
        override public void PrintSolution()
        {
            if (this.gameBoard == null)
            {
                throw new GameInputInvalid("The board cannot be null!");
            }

            for (int i = 0; i < this.gameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < this.gameBoard.GetLength(1); j++)
                {
                    Console.Write(this.gameBoard[i, j] + " ");
                    if (j == 2 || j == 5)
                    {
                        Console.Write("| ");
                    }
                }
                Console.WriteLine();
                if (i == 2 || i == 5)
                {
                    Console.WriteLine("------+-------+------");
                }
            }
        }

        /// <remarks><c>PrintBoard</c> method prints the board sent by the user to the console.</remarks>
        /// <exception cref="GameInputInvalid">Thrown when the input is corrupted or invalid.</exception>
        override public void PrintBoard()
        {
            // if the board is null, return Game Input Invalid exception
            if (this.originalBoard == null)
            {
                throw new GameInputInvalid("The board cannot be null!");
            }

            // print the original board
            for (int i = 0; i < this.originalBoard.GetLength(0); i++)
            {
                for (int j = 0; j < this.originalBoard.GetLength(1); j++)
                {
                    Console.Write(this.originalBoard[i, j] + " ");
                    if (j == 2 || j == 5)
                    {
                        Console.Write("| ");
                    }
                }
                Console.WriteLine();
                if (i == 2 || i == 5)
                {
                    Console.WriteLine("------+-------+------");
                }
            }
        }

        /// <returns>Coordinates of the longest cell and a list of probabilities with it.</returns>
        /// <param name="t_board">2 dimensional array of 32-bit integers.</param>
        private Tuple<int, int, int[]> _get_longest_cell_probabilities(int[,] t_board)
        {
            // create an array to store the longest cell probabilities
            int[] longestCellProbabilities = new int[] { };
            // create variables to store the x coordinate and y coordinate of the longest cell probabilities
            int xCoord = -1;
            int yCoord = -1;

            // loop through the board
            for (int xIterator = 0; xIterator < t_board.GetLength(0); xIterator++)
            {
                for (int yIterator = 0; yIterator < t_board.GetLength(1); yIterator++)
                {
                    // if the cell is not empty, continue
                    if (t_board[xIterator, yIterator] != 0)
                    {
                        continue;
                    }

                    // get the possibilities of the cell
                    int[] possibilities = _get_possibilities(t_board, xIterator, yIterator);

                    // if the length of the possibilities is greater than the length of the longest cell probabilities
                    if (possibilities.Length > longestCellProbabilities.Length)
                    {
                        // set the longest cell probabilities to the possibilities
                        longestCellProbabilities = possibilities;

                        // set the x coordinate and y coordinate of the longest cell probabilities
                        xCoord = xIterator;
                        yCoord = yIterator;
                    }
                }
            }

            // return the x coordinate, y coordinate, and longest cell probabilities
            return Tuple.Create(xCoord, yCoord, longestCellProbabilities);
        }

        /// <returns><c>true</c>, if the board is valid, <c>false</c> otherwise.</returns>
        /// <param name="t_board">2 dimensional array of 32-bit integers.</param>
        private bool _is_board_valid(int[,] t_board)
        {
            // check if the board is valid check for duplicates in rows and columns
            for (int xIterator = 0; xIterator < t_board.GetLength(0); xIterator++)
            {
                for (int yIterator = 0; yIterator < t_board.GetLength(1); yIterator++)
                {
                    // if the cell is empty, continue
                    if (t_board[xIterator, yIterator] == 0)
                    {
                        continue;
                    }

                    // check if is duplicate in the row
                    for (int k = 0; k < t_board.GetLength(1); k++)
                    {
                        if (
                            k != yIterator && t_board[xIterator, k] == t_board[xIterator, yIterator]
                        )
                        {
                            return false;
                        }
                    }

                    // check if the cell is a duplicate in the column
                    for (int k = 0; k < t_board.GetLength(0); k++)
                    {
                        if (
                            k != xIterator && t_board[k, yIterator] == t_board[xIterator, yIterator]
                        )
                        {
                            return false;
                        }
                    }

                    // check if the cell is a duplicate in the 3x3 box
                    int xBox = xIterator / 3;
                    int yBox = yIterator / 3;

                    for (int k = xBox * 3; k < xBox * 3 + 3; k++)
                    {
                        for (int l = yBox * 3; l < yBox * 3 + 3; l++)
                        {
                            if (
                                k != xIterator
                                && l != yIterator
                                && t_board[k, l] == t_board[xIterator, yIterator]
                            )
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            // if the board is valid, return true
            return true;
        }

        /// <returns>2 dimensional array of 32-bit integers as sudoku board.</returns>
        public int[,] GenerateSudoku(DIFFICULTY difficulty)
        {
            if (this.gameBoard == null)
            {
                throw new GameInputInvalid("The board cannot be null!");
            }

        StartGeneration:
            // create a new board
            int[,] board = new int[9, 9];

            // create a random number generator
            Random random = new Random();
            // store max number of generated numbers
            int maxOriginNumbers = 6;
            int generatedNumbers = 0;
            int maxIterations = 200;
            int currentIterations = 0;

            // set the first number
            board[0, 0] = random.Next(1, 10);

            // generate other random numbers
            while (generatedNumbers < maxOriginNumbers)
            {
                // start over if the generation takes too long / fails
                currentIterations++;
                if (currentIterations > maxIterations)
                {
                    goto StartGeneration;
                }

                // generate a random number and its coordinates
                int randomNumber = random.Next(1, 10);
                int xCoord = random.Next(1 * generatedNumbers, board.GetLength(0));
                int yCoord = random.Next(board.GetLength(1));

                if (!_can_be_placed(board, xCoord, yCoord, randomNumber))
                {
                    continue;
                }

                board[xCoord, yCoord] = randomNumber;
                generatedNumbers++;
            }

            // Select difficulty level
            if (difficulty == DIFFICULTY.TOASTER)
            {
                maxOriginNumbers = random.Next(28, 36);
            }
            else if (difficulty == DIFFICULTY.HELL)
            {
                maxOriginNumbers = random.Next(17, 28);
            }
            else if (difficulty == DIFFICULTY.OOTW)
            {
                maxOriginNumbers = random.Next(13, 17);
            }
            else
            {
                // default difficulty [GARDEN]
                maxOriginNumbers = random.Next(36, 47);
            }

            ChangeBoard(board);

            // check if can be solved
            if (!Solve())
            {
                goto StartGeneration;
            }

            // get the solved board
            board = this.gameBoard;
            generatedNumbers = 81;

            // go through the solved board and remove random elements from it
            while (maxOriginNumbers < generatedNumbers)
            {
                // get random coordinates
                int xCoord = random.Next(board.GetLength(0));
                int yCoord = random.Next(board.GetLength(1));

                // clear the board
                if (board[xCoord, yCoord] != 0)
                {
                    board[xCoord, yCoord] = 0;
                    generatedNumbers--;
                }
            }

            return board;
        }

        /// <summary>Used to solve puzzles, handles parallel multithreading if enabled.</summary>
        /// <returns><c>Boolean</c> value indicating if the puzzle was solved.</returns>
        /// <exception cref="GameInputInvalid">Thrown when the input is corrupted or invalid.</exception>
        public bool Solve()
        {
            if (this.gameBoard == null)
            {
                throw new GameInputInvalid("The board cannot be null!");
            }

            if (!_is_board_valid(this.gameBoard))
            {
                return false;
            }

            // if multithreading is disabled, use the single threaded solver, otherwise use the multi threaded solver
            if (this._multi_threading == _THREADING.SINGLE)
            {
                return _can_be_solved(this.gameBoard);
            }

            // Get the longest cell probabilities
            Tuple<int, int, int[]> emptyCell = _get_longest_cell_probabilities(this.gameBoard);
            int xCoord = emptyCell.Item1;
            int yCoord = emptyCell.Item2;

            // if there are no empty cells, return true
            // -1 because the ExtensionMethods.CoordinatesOf method returns -1 if the index is not found
            if (xCoord == -1)
            {
                return true;
            }

            // get the possibilities of the origin cell by calling the getPossibilities method
            int[] possibilities = emptyCell.Item3;

            // limit parallel threads to the maximum number of threads
            ParallelOptions parallelOptions = new ParallelOptions();
            parallelOptions.MaxDegreeOfParallelism = this._max_threads;

            // Set task scheduler to use the thread pool
            parallelOptions.TaskScheduler = TaskScheduler.Default;

            // Use parallel threads to solve the board faster
            Parallel.For(
                0,
                possibilities.Length,
                (iterator, state) =>
                {
                    // create a new sudoku board
                    int[,] newGameBoard = new int[9, 9];

                    // copy the current game board to the new game board
                    System.Buffer.BlockCopy(
                        this.gameBoard,
                        0,
                        newGameBoard,
                        0,
                        this.gameBoard.Length * sizeof(int)
                    );

                    // if the cell cannot be placed, return
                    if (!_can_be_placed(newGameBoard, xCoord, yCoord, possibilities[iterator]))
                    {
                        return;
                    }

                    // place the number in the cell
                    newGameBoard[xCoord, yCoord] = possibilities[iterator];

                    // if the board cannot be solved, return
                    if (!_can_be_solved(newGameBoard))
                    {
                        return;
                    }

                    // save the new game board to the current game board
                    System.Buffer.BlockCopy(
                        newGameBoard,
                        0,
                        this.gameBoard,
                        0,
                        newGameBoard.Length * sizeof(int)
                    );

                    // break the parallel loop
                    state.Break();
                }
            );

            // return true if the board is solved
            return this.gameBoard.Cast<int>().All(x => x != 0);
        }

        /// <returns>An array of all the possible numbers for a given cell.</returns>
        /// <param name="t_board">2 dimensional array of 32-bit integers.</param>
        /// <param name="t_xCoord">The X coordinate of the cell.</param>
        /// <param name="t_yCoord">The Y coordinate of the cell.</param>
        private int[] _get_possibilities(int[,] t_board, int t_xCoord = 0, int t_yCoord = 0)
        {
            // create an array of all the possible numbers
            int[] possibilities = new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Check the 3x3 square
            // Get the starting x and y coordinates of the square
            int xSquare = t_xCoord - (t_xCoord % 3);
            int ySquare = t_yCoord - (t_yCoord % 3);

            // Iterate through the square
            for (int xIterator = xSquare; xIterator < xSquare + 3; xIterator++)
            {
                for (int yIterator = ySquare; yIterator < ySquare + 3; yIterator++)
                {
                    // If the number is in the square, remove it from the possibilities array
                    if (t_board[xIterator, yIterator] != 0)
                    {
                        possibilities[t_board[xIterator, yIterator] - 1] = 0;
                    }
                }
            }

            // Check the row
            for (int iterator = 0; iterator < t_board.GetLength(1); iterator++)
            {
                // if the number is in the row, remove it from the possibilities array
                if (t_board[t_xCoord, iterator] != 0)
                {
                    possibilities[t_board[t_xCoord, iterator] - 1] = 0;
                }
            }

            // Check the column
            for (int iterator = 0; iterator < t_board.GetLength(0); iterator++)
            {
                // if the number is in the column, remove it from the possibilities array
                if (t_board[iterator, t_yCoord] != 0)
                {
                    possibilities[t_board[iterator, t_yCoord] - 1] = 0;
                }
            }

            // return the array of all the possibilities
            return possibilities.Where(x => x != 0).ToArray();
        }

        /// <returns>An array of all the possible numbers for each cell.</returns>
        /// <param name="t_board">2 dimensional array of 32-bit integers.</param>
        /// <exception cref="GameInputInvalid">Thrown when the input is corrupted or invalid.</exception>
        public int[,][] getAllPossibilities(int[,]? t_board)
        {
            // if the game board is null, throw an exception
            if (t_board == null)
            {
                throw new GameInputInvalid("The board cannot be null!");
            }

            // create a 2d array of all the possible numbers for each cell
            int[,][] allPossibilities = new int[9, 9][];

            // iterate through the game board
            for (int xIterator = 0; xIterator < t_board.GetLength(0); xIterator++)
            {
                for (int yIterator = 0; yIterator < t_board.GetLength(1); yIterator++)
                {
                    // get the possibilities for each cell
                    allPossibilities[xIterator, yIterator] = _get_possibilities(
                        t_board,
                        xIterator,
                        yIterator
                    );
                }
            }

            // return the array of all the possibilities
            return allPossibilities;
        }

        /// <returns><c>Boolean</c> value indicating if the number can be placed in the row.</returns>
        /// <param name="t_board">2 dimensional array of 32-bit integers.</param>
        /// <param name="t_xCoord">The X coordinate of the cell.</param>
        /// <param name="t_number">The number to be checked.</param>
        private bool _can_be_placed_in_row(int[,] t_board, int t_xCoord = 0, int t_number = 0)
        {
            // iterate through the row
            for (int iterator = 0; iterator < t_board.GetLength(1); iterator++)
            {
                // if the number is in the row, return false
                if (t_board[t_xCoord, iterator] == t_number)
                {
                    return false;
                }
            }

            // return true if the number can be placed in the row
            return true;
        }

        /// <returns><c>Boolean</c> value indicating if the number can be placed in the row.</returns>
        /// <param name="t_board">2 dimensional array of 32-bit integers.</param>
        /// <param name="t_yCoord">The Y coordinate of the cell</param>
        /// <param name="t_number">The number to be checked</param>
        private bool _can_be_placed_in_column(int[,] t_board, int t_yCoord = 0, int t_number = 0)
        {
            // iterate through the column
            for (int iterator = 0; iterator < t_board.GetLength(0); iterator++)
            {
                // if the number is in the column, return false
                if (t_board[iterator, t_yCoord] == t_number)
                {
                    return false;
                }
            }

            // return true if the number can be placed in the column
            return true;
        }

        /// <returns><c>Boolean</c> value indicating if the number can be placed in the square.</returns>
        /// <param name="t_board">2 dimensional array of 32-bit integers.</param>
        /// <param name="t_xCoord">The X coordinate of the cell.</param>
        /// <param name="t_yCoord">The Y coordinate of the cell.</param>
        /// <param name="t_number">The number to be checked.</param>
        private bool _can_be_placed_in_square(
            int[,] t_board,
            int t_xCoord = 0,
            int t_yCoord = 0,
            int t_number = 0
        )
        {
            // get the starting X and Y coordinate of the square
            int xSquare = t_xCoord - (t_xCoord % 3);
            int ySquare = t_yCoord - (t_yCoord % 3);

            // iterate through the square
            for (int xIterator = xSquare; xIterator < xSquare + 3; xIterator++)
            {
                for (int yIterator = ySquare; yIterator < ySquare + 3; yIterator++)
                {
                    // if the number is in the square, return false
                    if (t_board[xIterator, yIterator] == t_number)
                    {
                        return false;
                    }
                }
            }

            // return true if the number can be placed in the square
            return true;
        }

        /// <returns><c>Boolean</c> value indicating if the number can be placed in the cell.</returns>
        /// <param name="t_board">2 dimensional array of 32-bit integers.</param>
        /// <param name="t_xCoord">The X coordinate of the cell.</param>
        /// <param name="t_yCoord">The Y coordinate of the cell.</param>
        /// <param name="t_number">The number to be checked.</param>
        private bool _can_be_placed(int[,] t_board, int t_xCoord, int t_yCoord, int t_number)
        {
            // check if the number can be placed in the row, column and square
            return _can_be_placed_in_row(t_board, t_xCoord, t_number)
                && _can_be_placed_in_column(t_board, t_yCoord, t_number)
                && _can_be_placed_in_square(t_board, t_xCoord, t_yCoord, t_number);
        }

        /// <remarks>Creates an instance of the <see cref="Sudoku"/> class.</remarks>
        /// <returns><c>Boolean</c> value indicating if the number can be placed in the cell.</returns>
        /// <param name="t_board">2 dimensional array of 32-bit integers.</param>
        /// <param name="xCoord">The X coordinate of the cell.</param>
        /// <param name="yCoord">The Y coordinate of the cell.</param>
        /// <param name="number">The number to be checked.</param>
        public static bool canBePlaced(int[,] t_board, int t_xCoord, int t_yCoord, int t_number)
        {
            Sudoku instance = new Sudoku(t_board);
            return instance._can_be_placed(t_board, t_xCoord, t_yCoord, t_number);
        }

        /// <returns><c>Boolean</c> value indicating if the board can be solved with the current state.</returns>
        /// <param name="board">2 dimensional array of 32-bit integers.</param>
        private bool _can_be_solved(int[,] board)
        {
            // get the index of first empty cell from the current sudoku board
            Tuple<int, int> emptyCell = GameSolver.ExtensionMethods.CoordinatesOf(board, 0);
            int xCoord = emptyCell.Item1;
            int yCoord = emptyCell.Item2;

            // if there are no empty cells, return true
            // -1 because the ExtensionMethods.CoordinatesOf method returns -1 if the index is not found
            if (xCoord == -1)
            {
                return true;
            }

            // get the possibilities of the origin cell by cell index
            int[] originList = _get_possibilities(board, xCoord, yCoord);

            // iterate through the possibilities of the origin cell
            foreach (int originNumber in originList)
            {
                // if the number can be placed, place it to the temporary board
                if (_can_be_placed(board, xCoord, yCoord, originNumber))
                {
                    board[xCoord, yCoord] = originNumber;

                    if (_can_be_solved(board))
                    {
                        return true;
                    }

                    // if the sudoku is not solved, remove the number from the temporary board
                    board[xCoord, yCoord] = 0;
                }
            }

            // if the sudoku is not solved, return false
            return false;
        }
    }
}
