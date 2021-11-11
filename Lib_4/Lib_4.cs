using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_4
{
    public class Lib_4
    {
        public static void RPM (int[,] matr, out int[] mas)
        {
            mas = new int[matr.GetLength(0)];
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                int sum=0 ;
                for (int j = 0; j < matr.GetLength(1); j++)
                {
                    sum += matr[i, j];
                }
                mas[i] = sum;
            }
        }
    }
}
