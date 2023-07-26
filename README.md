## Description:

### Snail Sort
Given an n x n array, return the array elements arranged from outermost elements to the middle element, traveling clockwise.
```C#
array = [[1,2,3],
         [4,5,6],
         [7,8,9]]     

snail(array) #=> [1,2,3,6,9,8,7,4,5]
```
For better understanding, please follow the numbers of the next array consecutively:
```C#
array = [[1,2,3],
         [8,9,4],
         [7,6,5]]
         
snail(array) #=> [1,2,3,4,5,6,7,8,9]
```
This image will illustrate things more clearly:

![Snail examples](https://github.com/IvanovArtyom/Snail/blob/master/Snail%20examples.jpg)

**NOTE:** The idea is not sort the elements from the lowest value to the highest; the idea is to traverse the 2-d array in a clockwise snailshell pattern.

**NOTE 2:** The 0x0 (empty matrix) is represented as en empty array inside an array [[]].
### My solution
```C#
using System.Linq;
using System.Collections.Generic;

public class SnailSolution
{
    public static int[] Snail(int[][] array)
    {
        List<int> result = new();
        int leftBorder = 0, upperBound = 0, rightBorder = array[0].Length - 1, bottomLine = array.Length - 1;

        while (leftBorder <= rightBorder && upperBound <= bottomLine)
        {
            result.AddRange(array[upperBound++][leftBorder..(rightBorder + 1)]);

            for (int i = upperBound; i <= bottomLine; i++)
                result.Add(array[i][rightBorder]);

            rightBorder--;
            result.AddRange(array[bottomLine--][leftBorder..(rightBorder + 1)].Reverse());

            for (int i = bottomLine; i >= upperBound; i--)
                result.Add(array[i][leftBorder]);

            leftBorder++;
        }

        return result.ToArray();
    }
}
```
