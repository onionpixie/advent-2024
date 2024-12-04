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
                var failureTolerated = false;
                // this wrong come back here
                var isAscending = levels[0] < levels[1];
                if (levels[0] == levels[1]) {
                    failureTolerated = true;
                    if (levels[1] == levels[2]) continue;
                    isAscending = levels[1] < levels[2];
                }
                
                var isUnsafe = false;
                for (int i = 1; i < levels.Length; i++) {
                    if (Math.Abs(levels[i] - levels[i-1]) > 3) {
                        if (failureTolerated) {
                            isUnsafe = true;
                            break;
                        }
                        else {
                            failureTolerated = true;
                        }
                    }

                    if (isAscending && levels[i] <= levels[i-1]) {
                        if (failureTolerated) {
                            isUnsafe = true;
                            break;
                        }
                        else {
                            failureTolerated = true;
                        }
                    }
                    else if (!isAscending && levels[i] >= levels[i-1]) {
                        if (failureTolerated) {
                            isUnsafe = true;
                            break;
                        }
                        else {
                            failureTolerated = true;
                        }
                    }
                }

                if (!isUnsafe) safeCount++;
            }

            return safeCount.ToString();
        }
    }
}