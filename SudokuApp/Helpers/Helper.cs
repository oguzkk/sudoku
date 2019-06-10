using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuApp.Helpers
{
    public class Helper
    {
        public static List<int> PrepareFullNumberList(int length)
        {
            List<int> list = new List<int>();
            for (int i = 1; i <= length; i++)
            {
                list.Add(i);
            }
            return list;
        }

        public static void PrintSudoku(int[,] puzzle, int length)
        {
            int squareLength = (int)SquareLength(length);

            for (int i = 0; i < length; i++)
            {
                if (i % squareLength == 0)
                {
                    for (int index = 0; index < length; index++)
                    {
                        Console.Write("   =");
                        if (index % squareLength == squareLength - 1)
                        {
                            Console.Write(" ");
                        }
                    }
                }
                else
                {
                    for (int index = 0; index < length; index++)
                    {
                        Console.Write("   -");
                        if (index % squareLength == squareLength - 1)
                        {
                            Console.Write(" ");
                        }
                    }
                }
                Console.WriteLine();
                for (int j = 0; j < length; j++)
                {
                    if (j % squareLength == 0)
                    {
                        Console.Write("||");
                    }
                    else
                    {
                        Console.Write("|");
                    }
                    if (puzzle[i, j] != 0)
                    {
                        Console.Write(" " + puzzle[i, j] + " ");
                    }
                    else
                    {
                        Console.Write("   ");
                    }
                    if (j == length - 1)
                    {
                        Console.Write("||");
                    }
                }
                Console.WriteLine();
            }
            for (int index = 0; index < length; index++)
            {
                Console.Write("   =");
                if (index % squareLength == squareLength - 1)
                {
                    Console.Write(" ");
                }
            }

            Console.ReadLine();
        }

        public static double SquareLength(int commonLength)
        {
            return Math.Sqrt(commonLength);
        }

        public static List<int> CheckNumber(int number, ref List<int> numberList)
        {
            if (number != 0 && numberList.Contains(number) == false)
            {
                numberList.Add(number);
            }
            return numberList;
        }

        public static bool IsSolved(int[,] puzzle, int length)
        {
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (puzzle[i, j] == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static int[,] SolvePuzzle(int[,] puzzle, int commonLength)
        {
            int squareLength = (int)SquareLength(commonLength);
            bool anySquareSolved = false;
            while (IsSolved(puzzle, commonLength) == false)
            {
                anySquareSolved = false;
                for (int i = 0; i < commonLength; i++)
                {
                    for (int j = 0; j < commonLength; j++)
                    {
                        if (puzzle[i, j] == 0)
                        {
                            List<int> numberList = new List<int>();
                            int startingRow = i - (i % squareLength);
                            int startingCol = j - (j % squareLength);
                            for (int index = 0; index < commonLength; index++)
                            {
                                CheckNumber(puzzle[i, index], ref numberList);
                                CheckNumber(puzzle[index, j], ref numberList);
                                CheckNumber(puzzle[startingRow + ((index - index % squareLength) / squareLength), startingCol + (index % squareLength)], ref numberList);
                            }
                            if (numberList.Count == commonLength - 1)
                            {
                                List<int> allNumberList = PrepareFullNumberList(commonLength);
                                for (int index = 0; index < numberList.Count; index++)
                                {
                                    allNumberList.Remove(numberList[index]);
                                }
                                puzzle[i, j] = allNumberList[0];
                                anySquareSolved = true;
                            }
                        }
                    }
                }
                if (anySquareSolved == false)
                {
                    Console.WriteLine("Cant solve this sudoku.");
                    break;
                }
                else
                {
                    anySquareSolved = false;
                }
            }
            return puzzle;
        }
    }
}
