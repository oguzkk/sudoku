using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuApp.Helpers
{
    public class Helper
    {

        public int Length { get; set; }

        public List<int> PrepareFullNumberList()
        {
            List<int> list = new List<int>();
            for (int i = 1; i <= Length; i++)
            {
                list.Add(i);
            }
            return list;
        }

        public void PrintSudoku(int[,] puzzle)
        {
            Console.WriteLine();
            int squareLength = (int)SquareLength();

            for (int i = 0; i < Length; i++)
            {
                if (i % squareLength == 0)
                {
                    for (int index = 0; index < Length; index++)
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
                    for (int index = 0; index < Length; index++)
                    {
                        Console.Write("   -");
                        if (index % squareLength == squareLength - 1)
                        {
                            Console.Write(" ");
                        }
                    }
                }
                Console.WriteLine();
                for (int j = 0; j < Length; j++)
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
                    if (j == Length - 1)
                    {
                        Console.Write("||");
                    }
                }
                Console.WriteLine();
            }
            for (int index = 0; index < Length; index++)
            {
                Console.Write("   =");
                if (index % squareLength == squareLength - 1)
                {
                    Console.Write(" ");
                }
            }
        }

        public double SquareLength()
        {
            return Math.Sqrt(Length);
        }

        public List<int> CheckNumber(int number, ref List<int> numberList)
        {
            if (number != 0 && numberList.Contains(number) == false)
            {
                numberList.Add(number);
            }
            return numberList;
        }

        public bool IsSolved(int[,] puzzle)
        {
            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Length; j++)
                {
                    if (puzzle[i, j] == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public int GetEmptyCellCount(int[,] puzzle)
        {
            int count = 0;
            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Length; j++)
                {
                    if (puzzle[i, j] == 0)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public int[,] SolvePuzzle(int[,] puzzle)
        {
            int squareLength = (int)SquareLength();
            bool anySquareSolved = false;
            while (IsSolved(puzzle) == false)
            {
                anySquareSolved = false;
                for (int i = 0; i < Length; i++)
                {
                    for (int j = 0; j < Length; j++)
                    {
                        if (puzzle[i, j] == 0)
                        {
                            List<int> numberList = new List<int>();
                            GetNotAllowedNumberList(puzzle, i, j, ref numberList);
                            List<int> allowedNumberList = GetAllowedNumberList(numberList);
                            if (allowedNumberList.Count == 1)
                            {
                                puzzle[i, j] = (numberList)[0];
                                anySquareSolved = true;
                            }
                            else
                            {
                                List<List<int>> neighborAllowedNumberList = GetNeighborCellsAllowedNumberList(puzzle, i, j);
                                for (int listIndex = 0; listIndex < neighborAllowedNumberList.Count; listIndex++)
                                {
                                    for (int numberListIndex = 0; numberListIndex < neighborAllowedNumberList[listIndex].Count; numberListIndex++)
                                    {
                                        allowedNumberList.Remove(neighborAllowedNumberList[listIndex][numberListIndex]);
                                    }
                                }
                                if (allowedNumberList.Count == 1)
                                {
                                    puzzle[i, j] = (allowedNumberList)[0];
                                    anySquareSolved = true;
                                }
                            }
                        }
                    }
                }
                if (anySquareSolved == false)
                {
                    break;
                }
                else
                {
                    anySquareSolved = false;
                }
            }
            return puzzle;
        }
        
        public List<int> GetAllowedNumberList(List<int> numberList)
        {
            List<int> allNumberList = PrepareFullNumberList();
            for (int index = 0; index < numberList.Count; index++)
            {
                allNumberList.Remove(numberList[index]);
            }
            return allNumberList;
        }

        public void GetNotAllowedNumberList(int[,] sudoku, int currentRow, int currentCol, ref List<int> numberList)
        {
            int squareLength = (int)SquareLength();
            int startingRow = currentRow - (currentRow % squareLength);
            int startingCol = currentCol - (currentCol % squareLength);
            for (int index = 0; index < Length; index++)
            {
                CheckNumber(sudoku[currentRow, index], ref numberList);
                CheckNumber(sudoku[index, currentCol], ref numberList);
                CheckNumber(sudoku[(startingRow + ((index - index % squareLength) / squareLength)), (startingCol + (index % squareLength))], ref numberList);
            }
        }

        public List<List<int>> GetNeighborCellsAllowedNumberList(int[,] sudoku, int currentRow, int currentCol)
        {
            List<List<int>> numberList = new List<List<int>>();
            int squareLength = (int)SquareLength();
            int startingRow = currentRow - (currentRow % squareLength);
            int startingCol = currentCol - (currentCol % squareLength);
            for (int index = 0; index < Length; index++)
            {
                if ((sudoku[startingRow + ((index - index % squareLength) / squareLength), startingCol + (index % squareLength)] == 0) 
                    && !(((startingRow + ((index - index % squareLength) / squareLength))==currentRow) && ((startingCol + (index % squareLength) == currentCol))))
                {
                    List<int> list = new List<int>();
                    GetNotAllowedNumberList(sudoku, (startingRow + ((index - index % squareLength) / squareLength)), (startingCol + (index % squareLength)), ref list);
                    numberList.Add(GetAllowedNumberList(list));
                }
            }
            return numberList;
        }
    }
}
