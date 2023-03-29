using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Логика взаимодействия для AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {
        
        static PostsTableAdapter posts = new PostsTableAdapter();
        static WorkersTableAdapter workers = new WorkersTableAdapter();
        static ManufacturersTableAdapter manufacturers = new ManufacturersTableAdapter();
        int choosed = 0;
        Edit_Window edit = new Edit_Window();
        Ad_Window ad = new Ad_Window();
        Del_window deli = new Del_window();

        public AdminPanel()
        {           
            InitializeComponent();
            switch (choosed)
            {
                case 0:
                    MainDataGrid.ItemsSource = posts.GetData();
                    edit.choosed_adapter = 0;
                    break;
                case 1:
                    MainDataGrid.ItemsSource = workers.GetData();
                    edit.choosed_adapter = 1;
                    break;
                case 2:
                    MainDataGrid.ItemsSource = manufacturers.GetData();
                    edit.choosed_adapter = 2;
                    break;
            }
            


            
        }

        private void Edit_btn_Click(object sender, RoutedEventArgs e)
        {
            edit.Show();
            edit.StartEdit();
        }

        public void posts_btn_Click(object sender, RoutedEventArgs e)
        {
            edit.choosed_adapter = 0;
            ad.choosed_adapter = 0;
            MainDataGrid.ItemsSource = posts.GetData();
        }

        private void workers_btn_Click(object sender, RoutedEventArgs e)
        {
            edit.choosed_adapter = 1;
            ad.choosed_adapter = 1;
            MainDataGrid.ItemsSource = workers.GetData();
        }

        private void manf_btn_Click(object sender, RoutedEventArgs e)
        {
            edit.choosed_adapter = 2;
            ad.choosed_adapter = 2;
            MainDataGrid.ItemsSource = manufacturers.GetData();
        }

        private void Add_btn_Click(object sender, RoutedEventArgs e)
        {
            ad.Show();
            ad.Add_alement();
        }

        private void Rem_btn_Click(object sender, RoutedEventArgs e)
        {
            deli.StartEdit();
            deli.Show();

        }
    }
}
