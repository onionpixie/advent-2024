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
                for (int j = 0; j < diskMap[i]; j++){
                    var newIdNumber = new IdNumber {
                        isEmpty = i % 2 == 1,
                        idNumber = i % 2 == 1 ? null: count % 10
                    };

                    id.Add(newIdNumber);
                }

                if (i % 2 == 0) {
                    count++;
                }
            }

            var output = new List<IdNumber>();
            var numberOfTheEnd = id.Count - 1;
             for (int i = 0; i < id.Count; i++) {
                if (output.Count > numberOfTheEnd) break;

                if (!id[i].isEmpty) {
                    id[i].position = i;
                    output.Add(id[i]);
                    continue;
                }

                while (id[numberOfTheEnd].isEmpty) {
                    numberOfTheEnd -= 1;
                }

                id[numberOfTheEnd].position = i;
                output.Add(id[numberOfTheEnd]);
                numberOfTheEnd--;
            }

            Int64? total = output.Where(o => !o.isEmpty).Sum(o => o.checkSum);
            return total.ToString();
            //88957760693
            //24044850307019
            //20075802679
            //5535195185
            //5534897585
        }

        public string SolveB() {
            
            
            return "";
        }

    }

    class IdNumber(){
        public bool isEmpty {get; set;}

        public Int64? idNumber {get; set;}

        public int position {get; set;}

        public Int64? checkSum => idNumber.HasValue ? idNumber.Value * position : null;
    }
}