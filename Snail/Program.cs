using System.Linq;
using System.Collections.Generic;

public class SnailSolution
{
    public static void Main()
    {
        int[][] array =
        {
            new []{1, 2, 3},
            new []{4, 5, 6},
            new []{7, 8, 9}
        };

        // Test
        var t = Snail(array);
        // ...should return [1,2,3,6,9,8,7,4,5]
    }

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