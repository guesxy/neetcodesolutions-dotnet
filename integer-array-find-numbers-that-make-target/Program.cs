int[] a = {3,4,5,6};
        
Console.WriteLine("*** Start ***");
        
int[] result = TwoSum(a, 7);

foreach (var res in result)
    Console.WriteLine(res);

static int[] TwoSum(int[] nums, int target) {
    var map = new Dictionary<int, int>();
    var results = new List<int>();

    for (var i = 0; i < nums.Length; i++)
    {
        if (!map.ContainsKey(nums[i]))
        {
            map.Add(nums[i], i);
        }
    }

    for (var j = 0; j < nums.Length; j++)
    {
        int complement = target - nums[j];
    
        if (map.ContainsKey(complement) && map[complement] != j && !results.Contains(j)) {
            results.Add(map[complement]);
            results.Add(j);
        }
    }
    
    int[] resultArray = results.ToArray();
    Array.Sort(resultArray);
    
    return resultArray;
}