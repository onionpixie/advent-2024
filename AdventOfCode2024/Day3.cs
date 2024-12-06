using System.Text.RegularExpressions;

namespace AdventOfCode {
    public class Day3 : IDay {
        private string[] Lines { get; set; }
        public Day3() {
            Lines = File.ReadAllLines("./Files/Day3.txt");
        }

        public string SolveA() {
            var sum = 0;
            foreach (var line in Lines)
            {
                var pattern = "m{1}u{1}l{1}\\({1}[1234567890]+\\,{1}[1234567890]+\\){1}";
                var regexExpression = new Regex(pattern);
                var matches = regexExpression.Matches(line);
                foreach(var match in matches) {
                    var numbersPattern = "[1234567890]+";
                    var numbersExpression = new Regex(numbersPattern);

                    var numbers = numbersExpression.Matches(match.ToString());
                    sum += int.Parse(numbers[0].ToString()) * int.Parse(numbers[1].ToString());
                }
            }
            
            return sum.ToString();
        }

        public string SolveB() {
            var sum = 0;
            foreach (var line in Lines)
            {
                var combinedPattern = "(do\\(\\)){1}.+?(don't\\(\\)){1}";
                var combinedExpression = new Regex(combinedPattern);
                var enabledSections = combinedExpression.Matches(line);

                var numbersPattern = "[1234567890]+";
                var numbersExpression = new Regex(numbersPattern);
                var pattern = "m{1}u{1}l{1}\\({1}[1234567890]+\\,{1}[1234567890]+\\){1}";
                var regexExpression = new Regex(pattern);
                
                if (enabledSections.Count == 0) throw new Exception();

                foreach (var section in enabledSections)
                {
                    var matches = regexExpression.Matches(section.ToString());
                    foreach(var match in matches) {
                        var numbers = numbersExpression.Matches(match.ToString());
                        sum += int.Parse(numbers[0].ToString()) * int.Parse(numbers[1].ToString());
                    }
                }
            }
            
            return sum.ToString();
        }
    }
}