//Input: strs = ["act","pots","tops","cat","stop","hat"]
//Output: [["hat"],["act", "cat"],["stop", "pots", "tops"]]

string[] strings = ["act", "pots", "tops", "cat", "stop", "hat"];
var results = GroupAnagrams(strings);

foreach (var r in results)
    Console.WriteLine(r);

static List<List<string>> GroupAnagrams(string[] strs)
{
    var anagramMap = new Dictionary<string, List<string>>();

    foreach (var str in strs)
    {
        var charArray = str.ToCharArray();
        Array.Sort(charArray);
        var sortedStr = new string(charArray);

        if (!anagramMap.ContainsKey(sortedStr))
        {
            anagramMap[sortedStr] = new List<string>();
        }
        anagramMap[sortedStr].Add(str);
    }

    return anagramMap.Values.ToList();
}