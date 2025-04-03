using System.Globalization;

namespace GameSolver
{
    /// <summary>The <see cref="GameSolver" /> class provides the constructors and classes that are used in various solver algorithms.</summary>
    public class GameSolver
    {
        public GameSolver()
        {
        }

        /// <summary><c>ExtensionMethods</c> class provides extension methods for the GameSolver class.</summary>
        public class ExtensionMethods
        {
            /// <summary>This method checks if a given value is present in a given 2D matrix.</summary>
            /// <param name="t_matrix">2 dimensional array of T values</param>
            /// <param name="t_value">Value to check</param>
            /// <returns>True if the value is present in the matrix, false otherwise.</returns>
            /// <exception cref="GameInputInvalid">Thrown when the game board is corrupted or invalid.</exception>
            public static Tuple<int, int> CoordinatesOf<T>(T[,]? t_matrix, T t_value)
            {
                if (t_matrix == null || t_matrix.Length == 0)
                {
                    throw new GameInputInvalid();
                }

                int width = t_matrix.GetLength(0); // width
                int height = t_matrix.GetLength(1); // height

                for (int xIterator = 0; xIterator < width; xIterator++)
                {
                    for (int yIterator = 0; yIterator < height; ++yIterator)
                    {
                        if (t_matrix[xIterator, yIterator].Equals(t_value))
                        {
                            return Tuple.Create(xIterator, yIterator);
                        }
                    }
                }

                return Tuple.Create(-1, -1);
            }

            /// <summary>
            /// Writes sudoku puzzle to the provided file.
            /// </summary>
            /// <param name="t_fileName">File name</param>
            /// <param name="t_board">Puzzle to write</param>
            public static void writeSudokuToFile(string t_fileName, int[,] t_board)
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(t_fileName))
                {
                    for (int i = 0; i < t_board.GetLength(0); i++)
                    {
                        for (int j = 0; j < t_board.GetLength(1); j++)
                        {
                            sw.Write(t_board[i, j] + " ");
                        }
                        sw.WriteLine();
                    }
                }
            }

            /// <summary>
            /// Reads a file that contains sudoku puzzle.
            /// </summary>
            /// <param name="t_fileName"></param>
            /// <returns>2 dimensional array of 32-bit integers.</returns>
            public static int[,] readSudokuFromFile(string t_fileName)
            {
                int[,] board = new int[9, 9];
                int xIterator = 0;
                int yIterator = 0;

                // Read the file and display it line by line.
                using (StreamReader sr = File.OpenText(t_fileName))
                {
                    string? line = "";

                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] lineArray = line.Split(' ');
                        foreach (string number in lineArray)
                        {
                            if (number.Length == 0)
                            {
                                continue;
                            }

                            board[xIterator, yIterator] = Convert.ToInt32(number);
                            yIterator++;
                        }
                        xIterator++;
                        yIterator = 0;
                    }
                }

                return board;
            }

        }   // end of ExtensionMethods class


    }   // end of GameSolver class

    /// <remarks><c>GameInputInvalid</c> exception is thrown when the game input is invalid.</remarks>
    public class GameInputInvalid : Exception
    {
        /// <remarks>Constructor of the <see cref="GameInputInvalid" /> exception.</remarks>
        public GameInputInvalid(string message = "Invalid input!") : base(message)
        {
        }
    }

    /// <remarks>The <c>Board</c> class is the basis for all other classes that use the board.</remarks>
    public class Board
    {
        /// <remarks>Stores the value of the solution.</remarks>
        public int[,]? gameBoard = null;
        /// <remarks>Input board sent by the user.</remarks>
        public int[,]? originalBoard = null;

        /// <remarks>Constructor of the board class.</remarks>
        /// <param name="t_board">2 dimensional array of 32-bit integers.</param>
        /// <exception cref="GameInputInvalid">Thrown when the input is corrupted or invalid.</exception>
        public Board(int[,]? t_board)
        {
            // if the board is null, return Game Input Invalid exception
            if (t_board == null)
            {
                throw new GameInputInvalid("The board cannot be null!");
            }

            // call the ChangeBoard method to change the board to the input
            ChangeBoard(t_board);
        }

        /// <remarks><c>PrintBoard</c> method prints the board sent by the user to the console.</remarks>
        /// <exception cref="GameInputInvalid">Thrown when the input is corrupted or invalid.</exception>
        public virtual void PrintBoard()
        {
            // if the board is null, return Game Input Invalid exception
            if (this.originalBoard == null)
            {
                throw new GameInputInvalid("The board cannot be null!");
            }

            // iterate through the board and print it
            for (int i = 0; i < this.originalBoard.GetLength(0); i++)
            {
                for (int j = 0; j < this.originalBoard.GetLength(1); j++)
                {
                    Console.Write(this.originalBoard[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        /// <remarks><c>PrintSolution</c> method prints the board to the console.</remarks>
        /// <exception cref="GameInputInvalid">Thrown when the input is corrupted or invalid.</exception>
        public virtual void PrintSolution()
        {
            // if the board is null, return Game Input Invalid exception
            if (this.gameBoard == null)
            {
                throw new GameInputInvalid("The board cannot be null!");
            }

            // iterate through the board and print it
            for (int i = 0; i < this.gameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < this.gameBoard.GetLength(1); j++)
                {
                    Console.Write(this.gameBoard[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        /// <summary>Change the board to the input.</summary>
        /// <param name="t_board">2 dimensional array of 32-bit integers.</param>
        /// <exception cref="GameInputInvalid">Thrown when the input is corrupted or invalid.</exception>
        public virtual void ChangeBoard(int[,]? t_board = null)
        {
            // if the board is null, return Game Input Invalid exception
            if (t_board == null)
            {
                throw new GameInputInvalid("The board cannot be null!");
            }

            // clone the board to the gameBoard and originalBoard
            this.gameBoard = (int[,])t_board.Clone();
            this.originalBoard = (int[,])t_board.Clone();
        }

        /// <summary>Get the board sent by the user.</summary>
        /// <returns>Read-only reference to 2 dimensional array of 32-bit integers.</returns>
        /// <exception cref="GameInputInvalid">Thrown when the input is corrupted or invalid.</exception>
        public ref readonly int[,]? GetBoard()
        {
            // if the board is null, return Game Input Invalid exception
            if (this.originalBoard == null)
            {
                throw new GameInputInvalid("The board cannot be null!");
            }

            // return the board
            return ref this.originalBoard;
        }

        /// <summary>Get the solution board solved by the algorithm.</summary>
        /// <returns>Read-only reference to 2 dimensional array of 32-bit integers.</returns>
        /// <exception cref="GameInputInvalid">Thrown when the input is corrupted or invalid.</exception>
        public ref readonly int[,]? GetSolution()
        {
            // if the board is null, return Game Input Invalid exception
            if (this.gameBoard == null)
            {
                throw new GameInputInvalid("The board cannot be null!");
            }

            // return the board
            return ref this.gameBoard;
        }
    }
}