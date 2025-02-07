var solution = new Solution();
int[] nums = { 4, 5, 6, 7, 0, 1, 2 };
var target = 0;
var output = solution.Search(nums, target);
Console.WriteLine(output);

public class Solution
{
    /// <summary>
    /// Finds the index of the target in a rotated sorted array using binary search.
    /// </summary>
    /// <param name="nums">The rotated sorted input array</param>
    /// <param name="target">The target value to search for</param>
    /// <returns>The index of the target if found, otherwise -1</returns>
    public int Search(int[] nums, int target)
    {
        int leftIndex = 0;
        int rightIndex = nums.Length - 1;

        // Perform binary search
        while (leftIndex <= rightIndex)
        {
            // Calculate the middle index
            int middleIndex = leftIndex + (rightIndex - leftIndex) / 2;

            // Check if the middle element is the target
            if (nums[middleIndex] == target)
            {
                return middleIndex;
            }

            // Determine which side is properly sorted
            if (nums[leftIndex] <= nums[middleIndex])
            {
                // Left side is sorted
                if (nums[leftIndex] <= target && target < nums[middleIndex])
                {
                    rightIndex = middleIndex - 1;
                }
                else
                {
                    leftIndex = middleIndex + 1;
                }
            }
            else
            {
                // Right side is sorted
                if (nums[middleIndex] < target && target <= nums[rightIndex])
                {
                    leftIndex = middleIndex + 1;
                }
                else
                {
                    rightIndex = middleIndex - 1;
                }
            }
        }

        // Target not found
        return -1;
    }

  public int UnoptimizedSearch(int[] nums, int target) //this solution is an example of an less optimal algorithm with a time complexity of O(n). (my first attempt)
  {
      for (int i = 0; i < nums.Length; i++)
      {
          if (nums[i] == target)
          {
              return i;
          }
      }
      return -1;
  }
}
