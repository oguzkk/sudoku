using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuApp.Constants
{
    class CommonConstants
    {
        public static readonly int[,] exampleSudoku3x3 = new int[9, 9]{
                { 7   ,5   ,0   ,0   ,6   ,0   ,0   ,9   ,8}   ,
                { 8   ,0   ,0   ,0   ,2   ,0   ,0   ,7   ,0}   ,
                { 0   ,0   ,0   ,0   ,0   ,0   ,0   ,1   ,5}   ,
                { 0   ,0   ,0   ,9   ,0   ,0   ,0   ,8   ,3}   ,
                { 1   ,0   ,0   ,3   ,0   ,5   ,0   ,0   ,7}   ,
                { 4   ,3   ,0   ,0   ,0   ,7   ,0   ,0   ,0}   ,
                { 3   ,4   ,0   ,0   ,0   ,0   ,0   ,0   ,0}   ,
                { 0   ,7   ,0   ,0   ,5   ,0   ,0   ,0   ,6}   ,
                { 2   ,6   ,0   ,0   ,7   ,0   ,0   ,4   ,9}
             };

        public static readonly int[,] exampleSudoku2x2 = new int[4, 4]
     {
         {1 ,0 ,3, 0},
         {0 ,0 ,0, 2},
         {0 ,0 ,4, 0},
         {0 ,4 ,0, 0},
     };
    }
}
