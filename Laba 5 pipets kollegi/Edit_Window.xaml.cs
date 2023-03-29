using Laba_5_pipets_kollegi.FINAL_PROJECTDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    /// Логика взаимодействия для Edit_Window.xaml
    /// </summary>
    public partial class Edit_Window : Window
    {
        
        public int choosed_adapter;        
        public static PostsTableAdapter posts = new PostsTableAdapter();
        public static WorkersTableAdapter workers = new WorkersTableAdapter();
        public static ManufacturersTableAdapter manufacturers = new ManufacturersTableAdapter();
        
        public Edit_Window()
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
                Choose_cmbx.SelectedValuePath="Worker_ID";

            }
            else if (choosed_adapter == 2) 
            {
                Choose_cmbx.ItemsSource = manufacturers.GetData();
                Choose_cmbx.DisplayMemberPath = "Manf_name";
                Choose_cmbx.SelectedValuePath = "Manf_ID";
            }
            


        }

       

        public void Choose_cmbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (choosed_adapter == 0)
            {
                Tb1.Visibility = Visibility.Visible;
                var item = (Choose_cmbx.SelectedItem as DataRowView).Row;
                Tb1.Text = item[1].ToString();
                Tb1.KeyDown += new KeyEventHandler(edit_box_KeyDown);
            }
            else if (choosed_adapter == 1)
            {
                var item = (Choose_cmbx.SelectedItem as DataRowView).Row;
                Tb1.Visibility = Visibility.Visible;
                Tb1.Text = item[1].ToString();
                Tb2.Visibility = Visibility.Visible;
                Tb2.Text = item[2].ToString();
                Tb3.Visibility = Visibility.Visible;
                Tb3.Text = item[3].ToString();
                Tb4.Visibility = Visibility.Visible;
                Tb4.Text = item[4].ToString();
                Tb5.Visibility = Visibility.Visible;
                Tb5.Text = item[5].ToString();
                Tb5.KeyDown += new KeyEventHandler(edit_box_KeyDown);
                Cb1.Visibility = Visibility.Visible;
                
                Cb1.ItemsSource = posts.GetData();
                Cb1.DisplayMemberPath = "Post_name";
                Cb1.SelectedValuePath = "ID";    
                Cb1.SelectedValue = item[6].ToString();
            }
            else if (choosed_adapter == 2)
            {
                var item = (Choose_cmbx.SelectedItem as DataRowView).Row;
                Tb1.Visibility= Visibility.Visible;
                Tb1.Text = item[1].ToString();
                Tb1.KeyDown += new KeyEventHandler(edit_box_KeyDown);
            }
            
        }

        private void edit_box_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) 
            {
                try
                {

                    TextBox edit_box = (TextBox)sender;
                    string data = edit_box.Text;
                    if (choosed_adapter == 0)
                    {
                        posts.UpdateQuery(data, Convert.ToInt32(Choose_cmbx.SelectedValue));
                        Save_btn.Text = "Сохранено!";
                    }
                    else if (choosed_adapter == 1)
                    {
                        workers.UpdateQuery(Tb1.Text, Tb2.Text, Tb3.Text, Tb4.Text, Tb5.Text, Convert.ToInt32(Cb1.SelectedValue), Convert.ToInt32(Choose_cmbx.SelectedValue));
                        Save_btn.Text = "Сохранено!";
                    }
                    else if (choosed_adapter == 2)
                    {
                        manufacturers.UpdateQuery(1, Tb1.Text, Convert.ToInt32(Choose_cmbx.SelectedValue));
                        Save_btn.Text = "Сохранено!";
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка сохранения.");
                }
                





            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            this.Hide();
            
        }
        //public void edit_box_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.Key == Key.Enter)
        //    {
        //        posts.UpdateQuery(edit)
        //    }

        //}

        //private void Save_btn_Click(object sender, RoutedEventArgs e)
        //{
        //    if (choosed_adapter == 0) 
        //    { 
        //        posts.UpdateQuery()
        //    }
        //}






        //public void StartEdit()
        //{
        //    if (isWorkes)
        //    {
        //        ChooseName.ItemsSource = workers_adapter.GetData();
        //        ChooseName.DisplayMemberPath = "Name";
        //        ChooseName.SelectedValuePath = "id";
        //    }
        //    else
        //    {
        //        ChooseName.ItemsSource = goods_adapter.GetData();
        //        ChooseName.DisplayMemberPath = "Name";
        //        ChooseName.SelectedValuePath = "Id";
        //    }
        //}

        //private void ChooseName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    var item = (ChooseName.SelectedItem as DataRowView).Row;
        //    frst_txt.Text = item[1].ToString();
        //    scnd_txt.Text = item[2].ToString();
        //    Save_btn.IsEnabled = true;
        //    if (!isWorkes)
        //    {
        //        ChooseFK.ItemsSource = workers_adapter.GetData();
        //        ChooseFK.DisplayMemberPath = "Name";
        //        ChooseFK.SelectedValuePath = "id";
        //        ChooseFK.SelectedValue = Convert.ToInt32(item[3]);
        //        ChooseFK.Visibility = Visibility.Visible;
        //    }

        //    frst_txt.Visibility = Visibility.Visible;
        //    scnd_txt.Visibility = Visibility.Visible;
        //}

        //private void Save_btn_Click(object sender, RoutedEventArgs e)
        //{
        //    if (isWorkes)
        //    {
        //        workers_adapter.UpdateWorkersQuery(frst_txt.Text, Convert.ToInt32(scnd_txt.Text),
        //            Convert.ToInt32(ChooseName.SelectedValue));
        //        MessageBox.Show("Сохранено!");
        //    }
        //    else
        //    {
        //        goods_adapter.UpdateGoodsQuery(frst_txt.Text, Convert.ToInt32(scnd_txt.Text),
        //            Convert.ToInt32(ChooseFK.SelectedValue), Convert.ToInt32(ChooseName.SelectedValue));
        //        MessageBox.Show("Сохранено!");
        //    }
        //}

        //private void Exit_btn_Click(object sender, RoutedEventArgs e)
        //{
        //    this.Close();
        //}
    }
}
