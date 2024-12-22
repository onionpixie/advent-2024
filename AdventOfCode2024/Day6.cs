using System.Diagnostics;

namespace AdventOfCode {
    public class Day6 : IDay {
        private string[] Lines { get; set; }
        public Day6() {
            Lines = File.ReadAllLines("./Files/Day6.txt");
        }

        public string SolveA() {
            char[][] array = new char[Lines.Length][];
            for (int i = 0; i < Lines.Length; i++)
            {
                array[i] = Lines[i].ToCharArray();
            }

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < Lines.Length; j++)
                {
                    array[i] = Lines[i].ToCharArray();
                }
            }

            var current = new Coordinates (0, 0);
            var found = false;
            var maxY = array.Length-1;
            var maxX = array[0].Length-1;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] != '^') continue;

                    current = new Coordinates(j, i);
                    found = true;
                    break;
                }

                if (found) break;
            }

            var currentDirection = Direction.Up;
            var visitedPoints = new List<Coordinates> { current };
            var exited = false;

            while (current.Y >= 0 && current.Y <= maxY && current.X >= 0 && current.X <= maxX && !exited) {
                switch(currentDirection) {
                    case Direction.Up:
                       if (current.Y == 0){ 
                            exited = true; 
                            continue;
                        }
                        if (array[current.Y - 1][current.X] != '#'){
                            var nextSpace = new Coordinates(current.X, current.Y - 1);
                            if (!visitedPoints.Any(c => c.X == nextSpace.X && c.Y == nextSpace.Y)) {
                                visitedPoints.Add(nextSpace);
                            }
                            current = nextSpace;
                        }
                        else{
                            currentDirection = Direction.Right;
                        }
                    break;
                    case Direction.Down:
                        
                         if (current.Y == maxY){ 
                            exited = true; 
                            continue;
                        }
                        if (array[current.Y + 1][current.X] != '#'){
                            var nextSpace = new Coordinates(current.X, current.Y + 1);
                            if (!visitedPoints.Any(c => c.X == nextSpace.X && c.Y == nextSpace.Y)) {
                                visitedPoints.Add(nextSpace);
                            }
                            current = nextSpace;
                        }
                        else{
                            currentDirection = Direction.Left;
                        }
                    break;
                    case Direction.Left:
                        if (current.X == 0){ 
                            exited = true; 
                            continue;
                        }
                        if (array[current.Y][current.X - 1] != '#'){
                            var nextSpace = new Coordinates(current.X - 1, current.Y);
                            if (!visitedPoints.Any(c => c.X == nextSpace.X && c.Y == nextSpace.Y)) {
                                visitedPoints.Add(nextSpace);
                            }
                            current = nextSpace;
                        }
                        else{
                            currentDirection = Direction.Up;
                        }
                    break;
                    case Direction.Right:
                        if (current.X == maxX){ 
                            exited = true; 
                            continue;
                        }
                        if (array[current.Y][current.X + 1] != '#'){
                            var nextSpace = new Coordinates(current.X + 1, current.Y);
                            if (!visitedPoints.Any(c => c.X == nextSpace.X && c.Y == nextSpace.Y)) {
                                visitedPoints.Add(nextSpace);
                            }
                            current = nextSpace;
                        }
                        else{
                            currentDirection = Direction.Down;
                        }
                    break;
                }
            }


            return visitedPoints.Count().ToString();
        }

        public string SolveB() {
            char[][] array = new char[Lines.Length][];
            for (int i = 0; i < Lines.Length; i++)
            {
                array[i] = Lines[i].ToCharArray();
            }

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < Lines.Length; j++)
                {
                    array[i] = Lines[i].ToCharArray();
                }
            }

            var current = new Coordinates (0, 0);
             var start = new Coordinates (0, 0);
            var found = false;
            var maxY = array.Length-1;
            var maxX = array[0].Length-1;
            

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] != '^') continue;

                    current = new Coordinates(j, i, Direction.Up);
                    start = new Coordinates(j, i, Direction.Up);
                    found = true;
                    break;
                }

                if (found) break;
            }

            var uniqueVisitedPoints = new List<Coordinates> { current };
            var exited = false;
            while (current.Y >= 0 && current.Y <= maxY && current.X >= 0 && current.X <= maxX && !exited) {
                switch(current.Direction) {
                    case Direction.Up:
                       if (current.Y == 0){ 
                            exited = true; 
                            continue;
                        }
                        if (array[current.Y - 1][current.X] != '#'){
                            var nextSpace = new Coordinates(current.X, current.Y - 1, Direction.Up);
                            if (!uniqueVisitedPoints.Any(c => c.X == nextSpace.X && c.Y == nextSpace.Y)) {
                                uniqueVisitedPoints.Add(nextSpace);
                            }
                            current = nextSpace;
                        }
                        else{
                            var nextSpace = new Coordinates(current.X, current.Y, Direction.Right);
                            current = nextSpace;
                        }
                    break;
                    case Direction.Down:
                        if (current.Y == maxY){ 
                            exited = true; 
                            continue;
                        }
                        if (array[current.Y + 1][current.X] != '#'){
                            var nextSpace = new Coordinates(current.X, current.Y + 1, Direction.Down);
                            if (!uniqueVisitedPoints.Any(c => c.X == nextSpace.X && c.Y == nextSpace.Y)) {
                                uniqueVisitedPoints.Add(nextSpace);
                            }
                            current = nextSpace;
                        }
                        else{
                            var nextSpace = new Coordinates(current.X, current.Y, Direction.Left);
                            current = nextSpace;
                        }
                    break;
                    case Direction.Left:
                        if (current.X == 0){ 
                            exited = true; 
                            continue;
                        }
                        if (array[current.Y][current.X - 1] != '#'){
                            var nextSpace = new Coordinates(current.X - 1, current.Y, Direction.Left);
                            if (!uniqueVisitedPoints.Any(c => c.X == nextSpace.X && c.Y == nextSpace.Y)) {
                                uniqueVisitedPoints.Add(nextSpace);
                            }
                            current = nextSpace;
                        }
                        else{
                            var nextSpace = new Coordinates(current.X, current.Y, Direction.Up);
                            current = nextSpace;
                        }
                    break;
                    case Direction.Right:
                        if (current.X == maxX){ 
                            exited = true; 
                            continue;
                        }
                        if (array[current.Y][current.X + 1] != '#'){
                            var nextSpace = new Coordinates(current.X + 1, current.Y, Direction.Right);
                            if (!uniqueVisitedPoints.Any(c => c.X == nextSpace.X && c.Y == nextSpace.Y)) {
                                uniqueVisitedPoints.Add(nextSpace);
                            }
                            current = nextSpace;
                        }
                        else{
                            var nextSpace = new Coordinates(current.X, current.Y, Direction.Down);
                            current = nextSpace;
                        }
                    break;
                }
            }

            var sw = new Stopwatch();
            sw.Start();
            var loops = 0;
            for (int i = 0; i < uniqueVisitedPoints.Count; i++) {
                if (uniqueVisitedPoints[i].X == start.X && uniqueVisitedPoints[i].Y == start.Y) continue;
                if (i % 25 == 0) 
                    Console.WriteLine($"Running {i}/{uniqueVisitedPoints.Count}. Time taken: {sw.ElapsedMilliseconds / 1000}s, ~{(uniqueVisitedPoints.Count - i) * (sw.ElapsedMilliseconds / i) * 0.001:N0}s to go");
                var finished = false;
                current = start;
                var haveIBeenHereBefore = new List<Coordinates>() { current };
                while (current.Y >= 0 && current.Y <= maxY && current.X >= 0 && current.X <= maxX && !finished)
                {
                    switch (current.Direction)
                    {
                        case Direction.Up:
                            if (current.Y == 0)
                            {
                                finished = true;
                                continue;
                            }

                            var nextSpace = new Coordinates(current.X, current.Y - 1, Direction.Up);
                            if (IsNextSpaceBlocked(array, uniqueVisitedPoints[i], nextSpace)) {
                                nextSpace.Direction = Direction.Right;
                                nextSpace.Y = current.Y;
                            }

                            if (CheckForLoop(haveIBeenHereBefore, nextSpace)){
                                loops += 1;
                                finished = true;
                                continue;
                            }

                            current = nextSpace;
                            haveIBeenHereBefore.Add(nextSpace);
                            break;
                        case Direction.Down:
                            if (current.Y == maxY)
                            {
                                finished = true;
                                continue;
                            }
                            nextSpace = new Coordinates(current.X, current.Y + 1, Direction.Down);
                            if (IsNextSpaceBlocked(array, uniqueVisitedPoints[i], nextSpace)) {
                                nextSpace.Direction = Direction.Left;
                                nextSpace.Y = current.Y;
                            }

                            if (CheckForLoop(haveIBeenHereBefore, nextSpace))
                            {
                                loops += 1;
                                finished = true;
                                continue;
                            }
                            current = nextSpace;
                            haveIBeenHereBefore.Add(nextSpace);
                            break;
                        case Direction.Left:
                            if (current.X == 0) {
                                finished = true;
                                continue;
                            }
                            nextSpace = new Coordinates(current.X - 1, current.Y, Direction.Left);
                            if (IsNextSpaceBlocked(array, uniqueVisitedPoints[i], nextSpace)) {
                                nextSpace.Direction = Direction.Up;
                                nextSpace.X = current.X;
                            }

                            if (CheckForLoop(haveIBeenHereBefore, nextSpace))
                            {
                                loops += 1;
                                finished = true;
                                continue;
                            }
                            current = nextSpace;
                            haveIBeenHereBefore.Add(nextSpace);
                            break;
                        case Direction.Right:
                            if (current.X == maxX) {
                                finished = true;
                                continue;
                            }

                            nextSpace = new Coordinates(current.X + 1, current.Y, Direction.Right);
                            if (IsNextSpaceBlocked(array, uniqueVisitedPoints[i], nextSpace)) {
                                nextSpace.Direction = Direction.Down;
                                nextSpace.X = current.X;
                            }

                            if (CheckForLoop(haveIBeenHereBefore, nextSpace)) {
                                loops += 1;
                                finished = true;
                                continue;
                            }

                            current = nextSpace;
                            haveIBeenHereBefore.Add(nextSpace);
                            break;
                    }
                }
            }

           return loops.ToString();
        }

        private static bool IsNextSpaceBlocked(char[][] array, Coordinates testingBlock, Coordinates nextSpace)
        {
            return array[nextSpace.Y][nextSpace.X] == '#' || (testingBlock.X == nextSpace.X && testingBlock.Y == nextSpace.Y);
        }

        private static bool CheckForLoop(List<Coordinates> haveIBeenHereBefore, Coordinates nextSpace)
        {
            return haveIBeenHereBefore.Any(c => c.X == nextSpace.X && c.Y == nextSpace.Y && c.Direction == nextSpace.Direction);
        }
    }

    public enum Direction{
        Up,
        Down,
        Left,
        Right
    }

    public class Coordinates{
        public int X  {get; set;}
        public int Y {get; set;}

        public Direction Direction{get; set;}

        public Coordinates(int x, int y) {
            X = x;
            Y = y;
        }

        public Coordinates(int x, int y, Direction direction){
            X = x;
            Y = y;
            Direction = direction;
        }
    }
}