namespace AdventOfCode {
    public class Day1 : IDay {
        private string[] Lines { get; set; }
        public Day1() {
            Lines = File.ReadAllLines("./Files/Day1.txt");
        }

        public string SolveA() {
            var firstList = new List<int>();
            var secondList = new List<int>();
            foreach (var line in Lines) {
                var values = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                firstList.Add(int.Parse(values[0]));
                secondList.Add(int.Parse(values[1]));
            }

            var orderedFirstList = firstList.Order().ToList();
            var orderedSecondList = secondList.Order().ToList();
            var distance = 0;
            for (int i = 0; i < firstList.Count; i++)
            {
                if (orderedFirstList[i] > orderedSecondList[i]) {
                    distance += orderedFirstList[i] - orderedSecondList[i];
                }
                else{
                    distance+= orderedSecondList[i] - orderedFirstList[i];
                }
            }   

            return distance.ToString();
        }

        public string SolveB() {
            var firstList = new List<int>();
            var secondList = new List<int>();
            foreach (var line in Lines) {
                var values = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                firstList.Add(int.Parse(values[0]));
                secondList.Add(int.Parse(values[1]));
            }

            var lookup = new Dictionary<int, int>();
            var answer = 0;
            for (int i = 0; i < firstList.Count; i++)
            {
                var value = firstList[i];
                if (!lookup.ContainsKey(value)) {
                    var countInOtherList = secondList.Count(c => c == value);
                    lookup.Add(value, value * countInOtherList);
                }

                answer += lookup[value];
            }   

            return answer.ToString();
        }
    }
}