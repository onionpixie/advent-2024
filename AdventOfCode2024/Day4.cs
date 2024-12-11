using System.Runtime.InteropServices.JavaScript;
using System.Text.RegularExpressions;

namespace AdventOfCode {
    public class Day4 : IDay {
        private string[] Lines { get; set; }
        public Day4() {
            Lines = File.ReadAllLines("./Files/Day4.txt");
        }

        public string SolveA() {
            var noOfInstances = 0;

            char[][] array = new char[Lines.Length][];
            for (int i = 0; i < Lines.Length; i++)
            {
                array[i] = Lines[i].ToCharArray();
            }

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < Lines.Length; j++)
                {
                    array[i] = Lines[i].ToCharArray();
                }
            }

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] != 'X') continue;

                    if (j > 2 && array[i][j-1] == 'M' && array[i][j-2] == 'A' && array[i][j-3] == 'S'){
                        noOfInstances += 1;
                    }

                    if (j + 3 < array[i].Length && array[i][j+1] == 'M' && array[i][j+2] == 'A' && array[i][j+3] == 'S'){
                        noOfInstances += 1;
                    }

                    if (i > 2 && array[i- 1][j] == 'M' && array[i-2][j] == 'A' && array[i-3][j] == 'S'){
                        noOfInstances += 1;
                    }

                    if (i + 3 < array[i].Length && array[i+1][j] == 'M' && array[i+2][j] == 'A' && array[i+3][j] == 'S'){
                        noOfInstances += 1;
                    }

                    if (j > 2 && i > 2 && array[i-1][j-1] == 'M' && array[i-2][j-2] == 'A' && array[i-3][j-3] == 'S'){
                        noOfInstances += 1;
                    }

                    if (j + 3 < array[i].Length && i + 3 < array[i].Length && array[i+1][j+1] == 'M' && array[i+2][j+2] == 'A' && array[i+3][j+3] == 'S'){
                        noOfInstances += 1;
                    }

                    if (j > 2 && i + 3 < array[i].Length && array[i+1][j-1] == 'M' && array[i+2][j-2] == 'A' && array[i+3][j-3] == 'S'){
                        noOfInstances += 1;
                    }

                    if (j + 3 < array[i].Length && i > 2 && array[i-1][j+1] == 'M' && array[i-2][j+2] == 'A' && array[i-3][j+3] == 'S'){
                        noOfInstances += 1;
                    }
                }
            }

            return noOfInstances.ToString();
        }

        public string SolveB() {
            var noOfInstances = 0;

            char[][] array = new char[Lines.Length][];
            for (int i = 0; i < Lines.Length; i++)
            {
                array[i] = Lines[i].ToCharArray();
            }

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < Lines.Length; j++)
                {
                    array[i] = Lines[i].ToCharArray();
                }
            }

            for (int i = 1; i < array.Length -1; i++)
            {
                for (int j = 1; j < array[i].Length -1; j++)
                {
                    if (array[i][j] != 'A') continue;

                    if (((array[i-1][j-1] == 'M' && array[i+1][j+1] == 'S') || (array[i-1][j-1] == 'S' && array[i+1][j+1] == 'M'))
                    && ((array[i-1][j+1] == 'M' && array[i+1][j-1] == 'S') || (array[i-1][j+1] == 'S' && array[i+1][j-1] == 'M'))) {
                        noOfInstances += 1;
                    }
                    
                    
                }
            }

            return noOfInstances.ToString();
        }
    }
}