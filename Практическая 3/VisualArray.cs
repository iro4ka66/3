using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Visual
{
    static class VisualArray
    {
        //Метод для одномерного массива
        public static DataTable ToDataTable<T>(this T[] arr)
        {
            var res = new DataTable();
            for (int i = 0; i < arr.Length; i++)
            {
                res.Columns.Add("Строка №" + (i + 1), typeof(T));
            }
            var row = res.NewRow();
            for (int i = 0; i < arr.Length; i++)
            {
                row[i] = arr[i];
            }
            res.Rows.Add(row);
            return res;
        }
        //Метод для двухмерного массива
        public static DataTable ToDataTable<T>(this T[,] matr)
        {
            var res = new DataTable();
            for (int i = 0; i < matr.GetLength(1); i++)
            {
                res.Columns.Add("Колонка №" + (i + 1), typeof(T));
            }
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                var row = res.NewRow();

                for (int j = 0; j < matr.GetLength(1); j++)
                {
                    row[j] = matr[i, j];
                }

                res.Rows.Add(row);
            }
            return res;
        }
    }
}