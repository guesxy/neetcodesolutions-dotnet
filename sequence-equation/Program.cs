var p = new List<int> { 5, 2, 1, 3, 4 }; //{ 2, 3, 1 };
var map = new Dictionary<int, int>();
var results = new List<int>();

for (var i = 0; i < p.Count(); i++)
{
    map.Add(p[i], i + 1);
}

for (var i = 0; i < p.Count(); i++)
{
    Console.WriteLine(map[map[i + 1]]); 
    //for 231 case, 1 -> map[1] = 3 -> map[map[1]] -> map[3] -> 2
    results.Add(map[map[i + 1]]);
}
