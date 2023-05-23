using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz4
{
    namespace TicTacToeSingle
    {
        class TicTacToeS
        {
            private char[,] board;
            private char player;

            public TicTacToeS()
            {
                board = new char[3, 3];
                player = 'X';
                Board();
            }

            private void Board()
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        board[i, j] = '-';
                    }
                }
            }

            public void Play()
            {
                Random r = new Random();
                int start = r.Next(2);

                if (start == 0)
                {
                    player = 'X';
                }
                else
                {
                    player = 'O';
                }

                while (true)
                {
                    Console.Clear();
                    ShowBoard();

                    if (player == 'X')
                    {
                        Console.WriteLine($"Player {player} ");
                        Console.Write("row: ");
                        int row = int.Parse(Console.ReadLine());
                        Console.Write("column: ");
                        int column = int.Parse(Console.ReadLine());

                        if (ValidMove(row, column))
                        {
                            Move(row, column);

                            if (Win())
                            {
                                Console.Clear();
                                ShowBoard();
                                Console.WriteLine($"Player {player} win!");
                                return;
                            }
                            else if (BoardFull())
                            {
                                Console.Clear();
                                ShowBoard();
                                Console.WriteLine("Draw!");
                                return;
                            }
                            else
                            {
                                SwitchPlayer();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error! ");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Computer ({player}) turn:");

                        int row, column;
                        do
                        {
                            row = r.Next(3);
                            column = r.Next(3);
                        } while (!ValidMove(row, column));

                        Move(row, column);

                        if (Win())
                        {
                            Console.Clear();
                            ShowBoard();
                            Console.WriteLine($"Computer ({player}) win!");
                            return;
                        }
                        else if (BoardFull())
                        {
                            Console.Clear();
                            ShowBoard();
                            Console.WriteLine("Draw!");
                            return;
                        }
                        else
                        {
                            SwitchPlayer();
                        }
                    }
                }
            }

            private bool ValidMove(int row, int column)
            {
                if (row < 0 || row > 2 || column < 0 || column > 2)
                {
                    return false;
                }
                else if (board[row, column] != '-')
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            private void Move(int row, int column)
            {
                board[row, column] = player;
            }

            private bool Win()
            {
                for (int i = 0; i < 3; i++)
                {
                    if (board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2] && board[i, 0] != '-')
                    {
                        return true;
                    }
                }
                for (int j = 0; j < 3; j++)
                {
                    if (board[0, j] == board[1, j] && board[1, j] == board[2, j] && board[0, j] != '-')
                    {
                        return true;
                    }
                }
                if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] && board[0, 0] != '-')
                {
                    return true;
                }

                if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0] && board[0, 2] != '-')
                {
                    return true;
                }

                return false;
            }

            private bool BoardFull()
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (board[i, j] == '-')
                        {
                            return false;
                        }
                    }
                }

                return true;
            }

            private void SwitchPlayer()
            {
                if (player == 'X')
                {
                    player = 'O';
                }
                else
                {
                    player = 'X';
                }
            }

            private void ShowBoard()
            {
                Console.WriteLine("  0 1 2");
                for (int i = 0; i < 3; i++)
                {
                    Console.Write($"{i} ");
                    for (int j = 0; j < 3; j++)
                    {
                        Console.Write($"{board[i, j]} ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}