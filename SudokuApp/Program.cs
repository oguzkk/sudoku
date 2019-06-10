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
            Helper.PrintSudoku(CommonConstants.exampleSudoku3x3, 9);
            Helper.PrintSudoku(Helper.SolvePuzzle(CommonConstants.exampleSudoku3x3, 9), 9);
            Helper.PrintSudoku(CommonConstants.exampleSudoku2x2, 4);
            Helper.PrintSudoku(Helper.SolvePuzzle(CommonConstants.exampleSudoku2x2, 4), 4);
        }
    }
}
