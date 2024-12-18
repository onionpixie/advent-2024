using System.Runtime.CompilerServices;

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
            var found = false;
            var maxY = array.Length-1;
            var maxX = array[0].Length-1;
            

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] != '^') continue;

                    current = new Coordinates(j, i, Direction.Up);
                    found = true;
                    break;
                }

                if (found) break;
            }
            var start = current;
            var uniqueVisitedPoints = new List<Coordinates> { current };
            var allPoints = new List<Coordinates> { current };
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
                            allPoints.Add(nextSpace);
                            current = nextSpace;
                        }
                        else{
                            var nextSpace = new Coordinates(current.X, current.Y, Direction.Right);
                            allPoints.Add(nextSpace);
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
                            allPoints.Add(nextSpace);
                            current = nextSpace;
                        }
                        else{
                            var nextSpace = new Coordinates(current.X, current.Y, Direction.Left);
                            allPoints.Add(nextSpace);
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
                            allPoints.Add(nextSpace);
                            current = nextSpace;
                        }
                        else{
                            var nextSpace = new Coordinates(current.X, current.Y, Direction.Up);
                            allPoints.Add(nextSpace);
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
                            allPoints.Add(nextSpace);
                            current = nextSpace;
                        }
                        else{
                            var nextSpace = new Coordinates(current.X, current.Y, Direction.Down);
                            allPoints.Add(nextSpace);
                            current = nextSpace;
                        }
                    break;
                }
            }

            var loops = 0;
            for (int i = 0; i < uniqueVisitedPoints.Count; i++) {
                if (uniqueVisitedPoints[i].X == start.X && uniqueVisitedPoints[i].Y == start.Y) continue;

                exited = false;
                var looped = false;
                current = start;
                var haveIBeenHereBefore = new List<Coordinates>() { current };
                while (current.Y >= 0 && current.Y <= maxY && current.X >= 0 && current.X <= maxX && !exited && !looped) {
                    switch(current.Direction) {
                    case Direction.Up:
                       if (current.Y == 0){ 
                            exited = true; 
                            continue;
                        }
                        var nextSpace = new Coordinates(current.X, current.Y - 1, Direction.Up);
                        if (array[current.Y - 1][current.X] == '#' || (uniqueVisitedPoints[i].X != nextSpace.X && uniqueVisitedPoints[i].Y != nextSpace.Y)){
                            nextSpace.Direction = Direction.Right;
                            nextSpace.Y = current.Y;
                        }
                        if (haveIBeenHereBefore.Any(c => c.X == nextSpace.X && c.Y == nextSpace.Y && c.Direction == nextSpace.Direction)){
                            loops += 1;
                            looped = true;
                            continue;
                        }
                        current = nextSpace;
                    break;
                    case Direction.Down:
                        if (current.Y == maxY){ 
                            exited = true; 
                            continue;
                        }
                        nextSpace = new Coordinates(current.X, current.Y + 1, Direction.Down);
                        if (array[current.Y + 1][current.X] == '#' || (uniqueVisitedPoints[i].X != nextSpace.X && uniqueVisitedPoints[i].Y != nextSpace.Y)){
                            nextSpace.Direction = Direction.Left;
                            nextSpace.Y = current.Y;
                        }

                        if (haveIBeenHereBefore.Any(c => c.X == nextSpace.X && c.Y == nextSpace.Y && c.Direction == nextSpace.Direction)){
                            loops += 1;
                            looped = true;
                            continue;
                        }
                        current = nextSpace;
                    break;
                    case Direction.Left:
                        if (current.X == 0){ 
                            exited = true; 
                            continue;
                        }
                        nextSpace = new Coordinates(current.X - 1, current.Y, Direction.Left);
                        if (array[current.Y][current.X + 1] == '#' || (uniqueVisitedPoints[i].X != nextSpace.X && uniqueVisitedPoints[i].Y != nextSpace.Y)){
                            nextSpace.Direction = Direction.Up;
                            nextSpace.X = current.X;
                        }

                        if (haveIBeenHereBefore.Any(c => c.X == nextSpace.X && c.Y == nextSpace.Y && c.Direction == nextSpace.Direction)){
                                loops += 1;
                                looped = true;
                                continue;
                            }
                        current = nextSpace;
                    break;
                    case Direction.Right:
                        if (current.X == maxX){ 
                            exited = true; 
                            continue;
                        }
                        nextSpace = new Coordinates(current.X + 1, current.Y, Direction.Right);
                        if (array[current.Y][current.X + 1] == '#' || (uniqueVisitedPoints[i].X != nextSpace.X && uniqueVisitedPoints[i].Y != nextSpace.Y)){
                            nextSpace.Direction = Direction.Down;
                            nextSpace.X = current.X;
                        }

                        if (haveIBeenHereBefore.Any(c => c.X == nextSpace.X && c.Y == nextSpace.Y && c.Direction == nextSpace.Direction)){
                                loops += 1;
                                looped = true;
                                continue;
                            }
                            current = nextSpace;
                    break;
                }
            }
            }

           return loops.ToString();
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