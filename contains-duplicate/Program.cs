int[] nums = [1, 2, 3, 3];

bool hasDupes = false;

//Or do with a MAP/Dictionary then you can avoid a nested loop.

for (var i = 0; i < nums.Length; i++)
{
    for (var j = i + 1; j < nums.Length; j++)
    {
        if (nums[i] == nums[j])
        {
            hasDupes = true;
            break;
        }
    }
}

Console.WriteLine(hasDupes);
