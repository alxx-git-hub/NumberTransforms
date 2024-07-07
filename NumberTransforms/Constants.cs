namespace NumberTransforms;


public static class Constants
{
    private static readonly string fileName =
        System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;

    public static readonly string DirectoryApplicationName =
        System.IO.Path.GetDirectoryName(fileName);

    public static readonly List<int> InNumTask1 = new List<int>() { 
                         1,   2,   3,      4,   5,      6,      7,   8,   9,      10,     11,   12, 
                         13,   14,   15 };
    public static readonly List<string> OutNumTask1 = new List<string>() {
                        "1", "2", "fizz", "4", "buzz", "fizz", "7", "8", "fizz", "buzz", "11", "fizz",
                        "13", "14", "fizz-buzz"};

    public static readonly List<int> InNumTask2 = new List<int>() {
                         1,   2,   3,      4,      5,      6,      7,      8,      9,      10, 
                         11,   12,          13,   14,     15,          60, 
                         105,              420 };
    public static readonly List<string> OutNumTask2 = new List<string>() {
                        "1", "2", "fizz", "muzz", "buzz", "fizz", "guzz", "muzz", "fizz", "buzz", 
                        "11", "fizz-muzz", "13", "guzz", "fizz-buzz", "fizz-buzz-muzz", 
                        "fizz-buzz-guzz", "fizz-buzz-muzz-guzz"};

    public static readonly List<int> InNumTask3 = new List<int>() { 
                         1,   2,   3,     4,      5,     6,     7,      8,      9,     10,    11,   12,
                         13,   14,     15,        20,         60,
                         105,             420 };
    public static readonly List<string> OutNumTask3 = new List<string>() {
                        "1", "2", "dog", "muzz", "cat", "dog", "guzz", "muzz", "dog", "cat", "11", "fizz-muzz",
                        "13", "guzz", "good-boy", "muzz-cat", "good-boy-muzz",
                        "good-boy-guzz", "good-boy-muzz-guzz"};
}

