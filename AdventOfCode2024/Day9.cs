using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode {
    public class Day9 : IDay {
        private string[] Input { get; set; }
        public Day9() {
            Input = File.ReadAllLines("./Files/Day9.txt");
        }

        public string SolveA() {
            var charArray = Input[0].ToCharArray();
            var diskMap = charArray.Select(s => (int)Char.GetNumericValue(s)).ToArray();
            var id = new List<IdNumber>();
            var count = 0;
            for (int i = 0; i < diskMap.Length; i++) {
                var newIdNumber = new IdNumber {
                    isEmpty = i % 2 == 1,
                    idNumber = count
                };

                if (i % 2 == 0) {
                    count++;
                }
            }

            var output = "";
            var numberOfTheEnd = id.Count - 1;
             for (int i = 0; i < id.Count; i++) {
                if (i == numberOfTheEnd) {
                    output += id[numberOfTheEnd];
                    break;
                }

                if (id[i] != '.') {
                    output += id[i];
                    continue;
                }

                while (idNumberArray[numberOfTheEnd] == '.') {
                    numberOfTheEnd -= 1;
                }

                output += idNumberArray[numberOfTheEnd];
                numberOfTheEnd--;
            }

            Int64 checkSum = 0;
            var outputArray = output.TrimEnd('.').ToCharArray();
            for (int i = 0; i < outputArray.Length; i++) {
                checkSum += (int)Char.GetNumericValue(outputArray[i]) * i;
            }

            return checkSum.ToString();
            //88957760693
        }

        public string SolveB() {
            
            
            return "";
        }

    }

    class IdNumber(){
        public bool isEmpty {get; set;}

        public int? idNumber {get; set;}
    }
}