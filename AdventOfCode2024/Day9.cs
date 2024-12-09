using System.Data;
using System.Text;
using System.Text.Json;
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
                        idNumber = i % 2 == 1 ? null: count
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

                 if (output.Count > numberOfTheEnd) break;

                id[numberOfTheEnd].position = i;
                output.Add(id[numberOfTheEnd]);
                numberOfTheEnd--;
            }

            Int64? total = output.Where(o => !o.isEmpty).Sum(o => o.checkSum);
            return total.ToString();
        }

        public string SolveB() {
            var charArray = Input[0].ToCharArray();
            var diskMap = charArray.Select(s => (int)Char.GetNumericValue(s)).ToArray();
            var files = new List<DiskFile>();
            var count = 0;
            for (int i = 0; i < diskMap.Length; i++) {
                var newIdNumber = new DiskFile {
                    idNumber = i % 2 == 1 ? null: count,
                    size = diskMap[i]
                };

                files.Add(newIdNumber);

                if (i % 2 == 0) {
                    count++;
                }
            }
            
            List<DiskFile> defragedFiles = new List<DiskFile>(files.Count);

            // files.ForEach((item) =>
            //     {
            //         defragedFiles.Add((ICloneable)item.Clone());
            //     });


            for (int i = 0; i < files.Count; i++) {
                if (i > files.Count) break;

                var numberOfTheEnd = files.Count - 1;

                if (files[i].idNumber.HasValue){
                    defragedFiles.Add((DiskFile)files[i].Clone());
                    continue;
                }

                var spaceToFill = files[i].size;
                var numberOfFileToMove = files.Count - 1;
                while (spaceToFill > 0) {
                    if (numberOfFileToMove < i) {
                        break;
                    }

                    if (files[numberOfFileToMove].idNumber != null && files[numberOfFileToMove].size <= spaceToFill) {
                        spaceToFill -= files[numberOfFileToMove].size;
                        defragedFiles.Add((DiskFile)files[numberOfFileToMove].Clone());
                        files[numberOfFileToMove].idNumber = null;
                        numberOfFileToMove = files.Count - 1;
                    }
                    else {
                        numberOfFileToMove -= 1;
                    }
                }

                if (spaceToFill > 0 ) {
                    defragedFiles.Add(new DiskFile{
                        idNumber = files[i].idNumber,
                        size = spaceToFill,
                    });
                }


            }

            var position = 0;
            Int64 checkSum = 0;
            foreach (var file in defragedFiles)
            {
                for (int i = 0; i < file.size; i++)
                {
                    if (file.idNumber.HasValue) {
                        checkSum += position * file.idNumber.Value;
                    }
                    position++;
                }
            }
            
            return checkSum.ToString();
        }

    }

    class IdNumber(){
        public bool isEmpty {get; set;}

        public Int64? idNumber {get; set;}

        public int position {get; set;}

        public Int64? checkSum => idNumber.HasValue ? idNumber.Value * position : null;
    }

    class DiskFile() : ICloneable {
         public Int64? idNumber {get; set;}

         public int size{get; set;}

         public bool isMoved {get; set; }

         public object Clone()
      {
         // setup
    var json = JsonSerializer.Serialize(this);

            // get
            return JsonSerializer.Deserialize<DiskFile>(json);
      }
         
    }
}