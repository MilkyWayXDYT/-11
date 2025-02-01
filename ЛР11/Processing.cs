using System;

public class ProcessingArray
{
    public static double Main(double[] arrA, double[] arrB)
    {
        double y1 = 0, y2 = 0;

        for (int i = 0;  i < arrA.Length; i+=2)
        {
            y1 += arrA[i] * arrB[i];
            y2 += arrA[i + 1] * arrB[i + 1];
        }

        return y1 / y2;
    }
}