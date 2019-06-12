using SudokuApp.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuApp.Helpers
{
    public class Generator
    {
        public int Length { get; set; }

        public int[,] EmptySudoku()
        {
            return new int[Length, Length];
        }

        private Helper helper;
        private Random random = new Random();

        private void InitilazeHelper() {
            helper = new Helper();
            helper.Length = Length;
        }

        public int GetRandomNumber(List<int> numberList)
        {
            int randomNumber = random.Next(0, numberList.Count);
            return numberList[randomNumber];
        }

        public int[,] GeneratePuzzle(Enums.Level level)
        {
            InitilazeHelper();
            int[,] sudoku = EmptySudoku();

            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Length; j++)
                {
                    List<int> numberList = new List<int>();
                    helper.GetNotAllowedNumberList(sudoku,i,j, ref numberList);
                    List<int> allowedNumberList = helper.GetAllowedNumberList(numberList);
                    if (allowedNumberList.Count != 0)
                    {
                        sudoku[i, j] = GetRandomNumber(allowedNumberList);

                    }
                    else
                    {
                        helper.PrintSudoku(sudoku);
                        break;
                 }
                }
            }

            return sudoku;
        }
    }
}
