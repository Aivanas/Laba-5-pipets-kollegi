using Laba_5_pipets_kollegi.FINAL_PROJECTDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Laba_5_pipets_kollegi
{
    /// <summary>
    /// Логика взаимодействия для Del_window.xaml
    /// </summary>
    public partial class Del_window : Window
    {
        public int choosed_adapter;
        public static PostsTableAdapter posts = new PostsTableAdapter();
        public static WorkersTableAdapter workers = new WorkersTableAdapter();
        public static ManufacturersTableAdapter manufacturers = new ManufacturersTableAdapter();
        public Del_window()
        {
            InitializeComponent();
        }

        public void StartEdit()
        {
            if (choosed_adapter == 0)
            {
                Choose_cmbx.ItemsSource = posts.GetData();
                Choose_cmbx.DisplayMemberPath = "Post_name";
                Choose_cmbx.SelectedValuePath = "ID";
            }
            else if (choosed_adapter == 1)
            {
                Choose_cmbx.ItemsSource = workers.GetData();
                Choose_cmbx.DisplayMemberPath = "Worker_name";
                Choose_cmbx.SelectedValuePath = "Worker_ID";

            }
            else if (choosed_adapter == 2)
            {
                Choose_cmbx.ItemsSource = manufacturers.GetData();
                Choose_cmbx.DisplayMemberPath = "Manf_name";
                Choose_cmbx.SelectedValuePath = "Manf_ID";
            }



        }

        private void MegaGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (choosed_adapter == 0)
                {
                    posts.DeleteQuery(Convert.ToInt32(Choose_cmbx.SelectedValue));
                    Save_btn.Text = "Сохранено!";
                }
                else if (choosed_adapter == 1)
                {
                    workers.DeleteQuery(Convert.ToInt32(Choose_cmbx.SelectedValue));
                    Save_btn.Text = "Сохранено!";

                }
                else if (choosed_adapter == 2)
                {
                    workers.DeleteQuery(Convert.ToInt32(Choose_cmbx.SelectedValue));
                    Save_btn.Text = "Сохранено!";
                }
            }
            
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
