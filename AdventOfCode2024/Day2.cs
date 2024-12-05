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
                var levels = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(c => int.Parse(c)).ToList();

                var isSafe = IsItSafe(levels.ToArray());
                

                if (isSafe)
                { 
                    safeCount++; 
                    continue;
                }

                for (int i = 1; i < levels.Count; i++)
                {
                    // try again without i
                    var alteredLevels = levels.RemoveAt(i);
                    isSafe = IsItSafe(alteredLevels.ToArray());
                    if (isSafe)
                    { 
                        safeCount++; 
                        break;
                    }
                }
            }

            return (Lines.Length - safeCount).ToString();
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