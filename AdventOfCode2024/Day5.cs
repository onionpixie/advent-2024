using System.Runtime.InteropServices.JavaScript;
using System.Text.RegularExpressions;

namespace AdventOfCode {
    public class Day5 : IDay {
        private string[] Lines { get; set; }
        public Day5() {
            Lines = File.ReadAllLines("./Files/Day5.txt");
        }

        public string SolveA() {
            var rules = new List<PageOrderRule>();
            var updates = new List<Updates>();

            foreach (var line in Lines)
            {
                if (line.Contains(',')){
                    updates.Add(line.Split(',').Select(x => int.Parse(x)));
                }
                else {
                    var pages = line.Split('|');
                    if (pages.Length != 2) continue;
                    rules.Add( new PageOrderRule{
                        FirstPage = int.Parse(pages[0]),
                        SecondPage = int.Parse(pages[1]),
                    });
                }   
            }


            return "";
        }

        public string SolveB() {
            
            return "";
        }
    }

    class PageOrderRule(){
        public int FirstPage {get; set;}

        public int SecondPage {get; set;}
    }

    class Updates(){
        public List<int> PageOrder {get;set;} = new List<int>();
    }
}