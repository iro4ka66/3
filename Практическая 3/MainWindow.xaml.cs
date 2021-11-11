using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LibMas;
using Lib_4;
using Visual;

namespace Практическая_3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        int[,] matr;
        int[] mas;

        private void Fiil_Click(object sender, RoutedEventArgs e)
        {
            bool q = Int32.TryParse(rangeM.Text, out int M);
            bool w = Int32.TryParse(rangeN.Text, out int N);
            bool a = Int32.TryParse(rangefrom.Text, out int diap1);
            bool s = Int32.TryParse(rangeup.Text, out int diap2);
            if (q == true && w == true && a == true && s == true)
            {
                ArrayWork.MasZapoln(M, N, diap1, diap2, out matr);
                Data1.ItemsSource = VisualArray.ToDataTable(matr).DefaultView;
            }
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            Lib_4.Lib_4.RPM(matr, out mas);
            Data2.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            rangeM.Text = null;
            rangeN.Text = null;
            rangefrom.Text = null;
            rangeup.Text = null;
        }

        private void BothClear_Click(object sender, RoutedEventArgs e)
        {
            Data1.ItemsSource = null;
            Data2.ItemsSource = null;
            ArrayWork.MasOchist(ref matr);
        }

        private void IsxClear_Click(object sender, RoutedEventArgs e)
        {
            Data1.ItemsSource = null;
            ArrayWork.MasOchist(ref matr);
        }

        private void ObrClear_Click(object sender, RoutedEventArgs e)
        {
            Data2.ItemsSource = null;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            ArrayWork.MasSave(matr);
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            ArrayWork.MasOpen(ref matr);
            Data1.ItemsSource = VisualArray.ToDataTable(matr).DefaultView;
        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Выполнила студентка группы ИСП-31 Баева Ирина" +
                "\nДана матрица размера M × N. Для каждой строки матрицы найти сумму его элементов", "Информация");
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
