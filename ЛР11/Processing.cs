using System;
using System.Windows.Forms;

public class ProcessingArray
{
    public static double Main(double[] arr1, double[] arr2)
    {
        double y1 = 0, y2 = 0;

        for (int i = 0; i < arr1.Length; i += 2)
        {
            y1 += arr1[i] * arr2[i];
            y2 += arr1[i + 1] * arr2[i + 1];
        }

        if (y2 == 0)
            throw new Exception();

        return y1 / y2;
    }
}