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

            return "";
        }

        public string SolveB() {
            return "";
        }
    }
}