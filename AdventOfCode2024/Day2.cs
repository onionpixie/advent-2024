namespace AdventOfCode {
    public class Day2 : IDay {
        private string[] Lines { get; set; }
        public Day2() {
            Lines = File.ReadAllLines("./Files/Day2.txt");
        }

        public string SolveA() {
            var safeCount = 0;

            foreach (var line in Lines) {
                var levels = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(c => int.Parse(c)).ToArray();
                if (levels[0] == levels[1]) continue;

                var isUnsafe = false;
                var isAscending = levels[0] < levels[1];
                for (int i = 1; i < levels.Length; i++) {
                    if (Math.Abs(levels[i] - levels[i-1]) > 3) {
                        isUnsafe = true;
                        break;
                    }

                    if (isAscending && levels[i] <= levels[i-1]) {
                        isUnsafe = true;
                        break;
                    }
                    else if (!isAscending && levels[i] >= levels[i-1]) {
                        isUnsafe = true;
                        break;
                    }
                }

                if (!isUnsafe) safeCount++;
            }

            return safeCount.ToString();
        }

        public string SolveB() {
            var safeCount = 0;
            foreach (var line in Lines) {
                var levels = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(c => int.Parse(c)).ToArray();
                
                var isSafe = IsItSafe(levels);
                
                if (isSafe)
                { 
                    safeCount++; 
                    continue;
                }

                 for (int i = 0; i < levels.Length; i++)
                 {
                     // try again without i
                    
                    var result = RemoveOneItem(levels.ToList(), i);

                    isSafe = IsItSafe(result.ToArray());
                    if (isSafe)
                    { 
                        safeCount++; 
                        break;
                    }
                 }
            }

            return safeCount.ToString();
        }

        List<T> RemoveOneItem<T>(List<T> list, int index)
        {
            var listCount = list.Count;

            // Create an array to store the data.
            var result = new T[listCount - 1];

            // Copy element before the index.
            list.CopyTo(0, result, 0, index);

            // Copy element after the index.
            list.CopyTo(index + 1, result, index, listCount - 1 - index);

            return new List<T>(result);
        }

        private static bool IsItSafe(int[] levels)
        {
            var ascended = false;
            var descended = false;
            for (int i = 1; i < levels.Length; i++)
            {
                var numberToTest = levels[i];
                var comparisonNumber = levels[i - 1] ;
                if (numberToTest == comparisonNumber || Math.Abs(numberToTest - comparisonNumber) > 3) {
                        return false;
                }

                if (!ascended && !descended)
                {
                    if (numberToTest < comparisonNumber) {
                        descended = true;
                        continue;
                    }
                    else {
                        ascended = true;
                        continue;
                    }
                }

                if (ascended && numberToTest <= comparisonNumber) {
                        return false;
                }
                else if (descended && numberToTest >= comparisonNumber) {
                        return false;
                }
            }

            return true;
        }
    }
}