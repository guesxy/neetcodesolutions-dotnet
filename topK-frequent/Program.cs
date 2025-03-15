// See https://aka.ms/new-console-template for more information
var ints = new int[] { 1, 2, 2, 3, 3, 3, 4, 4, 4, 4 };

var res = TopKFrequent(ints, 2);

foreach (var r in res)
    Console.Write(r);

static int[] TopKFrequent(int[] nums, int k)
{
    //Map actual values to occurences, incrementing as we go
    //Then output by comparing occurences
    var occurenceMap = new Dictionary<int, int>();
    var returns = new int[k];

    foreach (var num in nums)
    {
        if (!occurenceMap.ContainsKey(num))
            occurenceMap.Add(num, 0);

        occurenceMap[num]++;
    }

    var sortedValues = occurenceMap.OrderByDescending(x => x.Value).Select(p => p.Key);

    for (var i = 0; i < k; i++)
        returns[i] = sortedValues.ElementAt(i);

    return returns;
}
