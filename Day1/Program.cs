// See https://aka.ms/new-console-template for more information


var inputLines = File.ReadAllLines("../../../input.txt");
Console.WriteLine($"Hello {inputLines[0]}");
int sum = 0;
foreach(var line in inputLines) {
    var arr = line.ToArray();
    try
    {
        var first = arr.Where(c => Char.IsDigit(c)).First();
        var last = arr.Reverse().Where(c => Char.IsDigit(c)).First();
        Int32.TryParse($"{first}{last}", out int res);
        sum += res;
    }
    catch (InvalidOperationException e)
    {
        continue;
    }
}
Console.WriteLine($"Part 1 sum: {sum}");

var numStringToNumCharMapper = new Dictionary<string, char>()
{
    {"zero", '0'},
    {"one", '1'},
    {"two", '2'},
    {"three", '3'},
    {"four", '4'},
    {"five", '5'},
    {"six", '6'},
    {"seven", '7'},
    {"eight", '8'},
    {"nine", '9'},
};



int newSum = 0;
foreach(var line in inputLines) {
    try {
        var relevantWordsInString = numStringToNumCharMapper.Keys.ToArray().Where(e => line.Contains(e));
        
        Tuple<int, string> firstWord = new Tuple<int, string>(Int32.MaxValue, "none");
        Tuple<int, string> lastWord = new Tuple<int, string>(-1, "none");
        foreach (var word in relevantWordsInString) {
            int firstPos = line.IndexOf(word);
            int lastPos = line.LastIndexOf(word);
            if (firstPos != -1 && (firstPos < firstWord.Item1)) {
                firstWord = new Tuple<int, string>(firstPos, word);
            }
            if (lastPos > lastWord.Item1) {
                lastWord = new Tuple<int, string>(lastPos, word);
            }
        }

        bool foundWordInText = firstWord.Item1 != Int32.MaxValue;

        char actualFirstVal;
        char actualLastVal;
        if (foundWordInText)
        {
            var literalNumsBeforeFirstStringyNum = line.Substring(0, firstWord.Item1).Where(c => Char.IsDigit(c));
            var literalNumsAfterLastStringyNum = line.Substring(lastWord.Item1 + lastWord.Item2.Length).Where(c => Char.IsDigit(c));
            actualFirstVal = literalNumsBeforeFirstStringyNum.Count() != 0
                ? literalNumsBeforeFirstStringyNum.First()
                : numStringToNumCharMapper[firstWord.Item2];
            actualLastVal = literalNumsAfterLastStringyNum.Count() != 0
                ? literalNumsAfterLastStringyNum.Reverse().First()
                : numStringToNumCharMapper[lastWord.Item2];
        }
        else
        {
            actualFirstVal = line.Where(e => Char.IsDigit(e)).First();
            actualLastVal = line.Where(e => Char.IsDigit(e)).Reverse().First();
        }
        //Console.WriteLine(line);
        Int32.TryParse($"{actualFirstVal}{actualLastVal}", out int res);
        //Console.WriteLine($"Got res: {res}");
        newSum += res;
        Console.WriteLine($"{line} = {actualFirstVal}{actualLastVal}, new sum={newSum}");
    }
    catch (InvalidOperationException e)
    {
        continue;
    }
}
Console.WriteLine($"Part 2 sum: {newSum}");

/*
Covered cases:
only int
int x word
word x int
int x int
word x word

*/