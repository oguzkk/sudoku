using SudokuApp.Constants;
using SudokuApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Examples
            //Helper sudokuHelper2x2 = new Helper();
            //sudokuHelper2x2.Length = 4;
            //sudokuHelper2x2.PrintSudoku(CommonConstants.exampleSudoku2x2);
            //int[,] solvedPuzzle = sudokuHelper2x2.SolvePuzzle(CommonConstants.exampleSudoku2x2);
            //sudokuHelper2x2.PrintSudoku(solvedPuzzle);

            Helper sudokuHelper3x3 = new Helper();
            sudokuHelper3x3.Length = 9;
            //sudokuHelper3x3.PrintSudoku(CommonConstants.exampleSudoku3x3);
            //sudokuHelper3x3.PrintSudoku(sudokuHelper3x3.SolvePuzzle(CommonConstants.exampleSudoku3x3));
            sudokuHelper3x3.PrintSudoku(CommonConstants.hardSudoku3x3);
            sudokuHelper3x3.PrintSudoku(sudokuHelper3x3.SolvePuzzle(CommonConstants.hardSudoku3x3));
            sudokuHelper3x3.PrintSudoku(CommonConstants.hardSudoku3x3_2);
            sudokuHelper3x3.PrintSudoku(sudokuHelper3x3.SolvePuzzle(CommonConstants.hardSudoku3x3_2));
            //Generator generator = new Generator();
            //generator.Length = 9;
            //sudokuHelper3x3.PrintSudoku(generator.GeneratePuzzle(Enums.Level.Easy));
            Console.Read();

        }
    }
}
