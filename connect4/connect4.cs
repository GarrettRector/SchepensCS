using System;

namespace Connect4
{
    class Connect4
    {
        public static void print_board(string[,] board)
        {
            for (int k = 0; k < board.GetLength(0); k++)
            {
                for (int m = 0; m < board.GetLength(1); m++)
                {
                    Console.Write(board[k, m] + " ");
                }
                Console.WriteLine();
            }
        }

        public static bool check_win(string[,] board, int x, int y)
        {
            bool state = false;
            bool vertical = check_vertical(board, x);
            bool horizontal = check_horizontal(board, y);
            bool across = check_across(board, x, y);
            if (vertical)
            {
                state = vertical;
                Console.WriteLine("v");
            } else if (horizontal) {
                state = horizontal;
                Console.WriteLine("h");
            } else if (across) {
                Console.WriteLine("a");
                state = across;
            }

            return state;
        }

        public static bool check_across(string[,] board, int x, int y)
        {
            bool state = true;
            for (int z = 0; z < board.GetLength(1) - 1; z++)
            {
                if (board[z, z] != board[z + 1, z + 1])
                {
                    state = false;
                }
            }

            for (int z = board.GetLength(1) - 1; z < 0; z--)
            {
                if (board[z, z] != board[z - 1, z - 1])
                {
                    state = false;
                }
            }

            return state;
        }

        public static bool check_horizontal(string[,] board, int y)
        {
            bool state = true;
            for (int x = 0; x < board.GetLength(1) - 1; x++)
            {
                if (board[y, x] != board[y, x+1])
                {
                    state = false;
                }
            }
            return state;
        }

        public static bool check_vertical(string[,] board, int x)
        {
            bool state = true;
            for (int y = board.GetLength(1) - 2; y > 0; y--)
            {
                if (board[y, x] != (board[y+1, x]))
                {
                    state = false;
                }
            }
            return state;
        }

        static void Main(string[] args)
        {
            string[] players = new string[2] { "x", "o" };

            string[,] board = new string[4, 4] { { "-", "-", "-", "-" },
                                                    { "-", "-", "-", "-" },
                                                    { "-", "-", "-", "-" },
                                                    { "-", "-", "-", "-" }};

            bool won = false;

            int player = 0;

            while (!won)
            {
                print_board(board);
                player = (player + 1) % 2;
                Console.WriteLine("Column to place piece");

                int x = Int32.Parse(Console.ReadLine()) - 1;
                if (x <= board.GetLength(0))
                {
                    for (int y = board.GetLength(0) - 1; y >= 0; y--)
                    {
                        if (board[y, x] == "-")
                        {
                            board[y, x] = players[player];
                            won = check_win(board, x, y);
                            break;
                        }
                    }

                    Console.Clear();
                } else
                {
                    Console.Clear();
                    Console.WriteLine("Integer must be less than 5");
                }
            }
            Console.Clear();
            print_board(board);
            Console.WriteLine("Player " + player + " has won");
        }
    }
}
