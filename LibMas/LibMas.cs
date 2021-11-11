using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LibMas
{
    public class ArrayWork
    {
        public static void MasZapoln(int m, int n, int diap1, int diap2, out int[,] matr)
        {
            matr = new int[n,m];
            Random rnd = new Random();
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                for (int j = 0; j < matr.GetLength(1); j++)
                {
                    matr[i,j] = rnd.Next(diap1, diap2);
                }
            }
        }
        public static void MasOchist(ref int[,] matr)
        {
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                for (int j = 0; j < matr.GetLength(1); j++)
                {
                    matr[i, j] = 0;
                }
            }
        }
        public static void MasSave(int[,] matr)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "Все файлы (*.*) | *.* | Текстовые файлы | *.txt";
            save.FilterIndex = 2;
            save.Title = "Сохранение таблицы";
            DialogResult dialogResult = save.ShowDialog();
            bool t = Convert.ToBoolean(dialogResult);
            if (t == true)
            {
                StreamWriter file = new StreamWriter(save.FileName);
                file.WriteLine(Convert.ToString(matr.GetLongLength(0)));
                file.WriteLine(Convert.ToString(matr.GetLongLength(1)));
                for (int i = 0; i < matr.GetLongLength(0); i++)
                {
                    for (int j = 0; j < matr.GetLongLength(1); j++)
                    {
                        file.WriteLine(matr[i, j]);
                    }

                }
                file.Close();
            }
        }
        public static void MasOpen(ref int[,] matr)
        {
            matr = new int[1, 1];
            OpenFileDialog open = new OpenFileDialog();
            open.DefaultExt = ".txt";
            open.Filter = "Все файлы (*.*) | *.* | Текстовые файлы | *.txt";
            open.FilterIndex = 2;
            open.Title = "Открыть таблицы";
            DialogResult dialogResult = open.ShowDialog();
            bool t = Convert.ToBoolean(dialogResult);
            if (t == true)
            {
                StreamReader file = new StreamReader(open.FileName);
                int x = Convert.ToInt32(file.ReadLine());
                int y = Convert.ToInt32(file.ReadLine());
                matr = new Int32[x, y];
                for (int i = 0; i < x; i++)
                {
                    for (int j = 0; j < y; j++)
                    {
                        matr[i, j] = Convert.ToInt32(file.ReadLine());
                    }
                }
                file.Close();
            }
        }
    }
}
