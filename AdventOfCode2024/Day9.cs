using System.Data;
using System.Text.Json;

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
                        IsEmpty = i % 2 == 1,
                        Number = i % 2 == 1 ? null: count
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

                if (!id[i].IsEmpty) {
                    id[i].Position = i;
                    output.Add(id[i]);
                    continue;
                }

                while (id[numberOfTheEnd].IsEmpty) {
                    numberOfTheEnd -= 1;
                }

                 if (output.Count > numberOfTheEnd) break;

                id[numberOfTheEnd].Position = i;
                output.Add(id[numberOfTheEnd]);
                numberOfTheEnd--;
            }

            Int64? total = output.Where(o => !o.IsEmpty).Sum(o => o.CheckSum);
            return total.ToString();
        }

        public string SolveB() {
            var charArray = Input[0].ToCharArray();
            var diskMap = charArray.Select(s => (int)Char.GetNumericValue(s)).ToArray();
            var files = new List<DiskFile>();
            var count = 0;
            for (int i = 0; i < diskMap.Length; i++) {
                var newIdNumber = new DiskFile {
                    IdNumber = i % 2 == 1 ? null: count,
                    Size = diskMap[i]
                };

                files.Add(newIdNumber);

                if (i % 2 == 0) {
                    count++;
                }
            }
            
            List<DiskFile> defragedFiles = new List<DiskFile>(files.Count);

            for (int i = 0; i < files.Count; i++) {
                if (i > files.Count) break;

                var numberOfTheEnd = files.Count - 1;

                if (files[i].IdNumber.HasValue){
                    defragedFiles.Add((DiskFile)files[i].Clone());
                    continue;
                }

                var spaceToFill = files[i].Size;
                var numberOfFileToMove = files.Count - 1;
                while (spaceToFill > 0) {
                    if (numberOfFileToMove < i) {
                        break;
                    }

                    if (files[numberOfFileToMove].IdNumber != null && files[numberOfFileToMove].Size <= spaceToFill) {
                        spaceToFill -= files[numberOfFileToMove].Size;
                        defragedFiles.Add((DiskFile)files[numberOfFileToMove].Clone());
                        files[numberOfFileToMove].IdNumber = null;
                        numberOfFileToMove = files.Count - 1;
                    }
                    else {
                        numberOfFileToMove -= 1;
                    }
                }

                if (spaceToFill > 0 ) {
                    defragedFiles.Add(new DiskFile{
                        IdNumber = files[i].IdNumber,
                        Size = spaceToFill,
                    });
                }


            }

            var position = 0;
            Int64 checkSum = 0;
            foreach (var file in defragedFiles)
            {
                for (int i = 0; i < file.Size; i++)
                {
                    if (file.IdNumber.HasValue) {
                        checkSum += position * file.IdNumber.Value;
                    }
                    position++;
                }
            }
            
            return checkSum.ToString();
        }

    }

    class IdNumber(){
        public bool IsEmpty {get; set;}

        public Int64? Number {get; set;}

        public int Position {get; set;}

        public Int64? CheckSum => Number.HasValue ? Number.Value * Position : null;
    }

    class DiskFile() : ICloneable {
        public Int64? IdNumber {get; set;}

        public int Size{get; set;}

        public bool IsMoved {get; set; }

        public object Clone()
        {
            // setup
            var json = JsonSerializer.Serialize(this);

            // get
            return JsonSerializer.Deserialize<DiskFile>(json);
        }
    }
}