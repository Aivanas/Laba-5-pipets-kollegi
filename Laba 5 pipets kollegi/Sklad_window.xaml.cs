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
using System.Windows.Shapes;
using Laba_5_pipets_kollegi.FINAL_PROJECTDataSetTableAdapters;

namespace Laba_5_pipets_kollegi
{
    /// <summary>
    /// Логика взаимодействия для Sklad_window.xaml
    /// </summary>
    public partial class Sklad_window : Window
    {
        TractorsTableAdapter tractors = new TractorsTableAdapter();
        HarrowsTableAdapter harrows = new HarrowsTableAdapter();
        SprinklersTableAdapter sprinklers = new SprinklersTableAdapter();
        CultivatorsTableAdapter cultivators = new CultivatorsTableAdapter();
        Tractor_trailersTableAdapter trailers = new Tractor_trailersTableAdapter();
        AdTech_Window adTech = new AdTech_Window();
        TechEditWindow TechEditWindow = new TechEditWindow();
        DelTechWindow DelTechWindow = new DelTechWindow();
        public Sklad_window()
        {
            InitializeComponent();
        }

        private void Edit_btn_Click(object sender, RoutedEventArgs e)
        {
            TechEditWindow.Show();
            TechEditWindow.StartEdit();
        }

        private void Add_btn_Click(object sender, RoutedEventArgs e)
        {
            adTech.Show ();
            adTech.Ad_smthg();
        }

        private void Rem_btn_Click(object sender, RoutedEventArgs e)
        {
            DelTechWindow.Show ();
            DelTechWindow.StartEdit ();

        }

        private void tractors_btn_Click(object sender, RoutedEventArgs e)
        {
            MainDataGrid.ItemsSource = tractors.GetData();
            adTech.choosed_adapter = 0;
            TechEditWindow.choosed_adapter = 0;
            DelTechWindow.choosed_adapter = 0;
        }

        private void cultivators_btn_Click(object sender, RoutedEventArgs e)
        {

            MainDataGrid.ItemsSource = cultivators.GetData();
            adTech.choosed_adapter = 3;
            TechEditWindow.choosed_adapter = 3;
            DelTechWindow.choosed_adapter=3;
        }

        private void harrows_btn_Click(object sender, RoutedEventArgs e)
        {

            MainDataGrid.ItemsSource = harrows.GetData(); 
            adTech.choosed_adapter = 1;
            TechEditWindow.choosed_adapter = 1;
            DelTechWindow.choosed_adapter = 1;
        }

        private void sprinklers_btn_Click(object sender, RoutedEventArgs e)
        {

            MainDataGrid.ItemsSource = sprinklers.GetData();
            adTech.choosed_adapter = 2;
            TechEditWindow.choosed_adapter = 2;
            DelTechWindow.choosed_adapter = 2;
        }

        private void trailers_btn_Click(object sender, RoutedEventArgs e)
        {

            MainDataGrid.ItemsSource = trailers.GetData();
            adTech.choosed_adapter = 4;
            TechEditWindow.choosed_adapter = 4;
            DelTechWindow .choosed_adapter = 4;
        }
    }
}
