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
    /// Логика взаимодействия для Ad_Window.xaml
    /// </summary>
    public partial class Ad_Window : Window
    {
        public int choosed_adapter;
        public static PostsTableAdapter posts = new PostsTableAdapter();
        public static WorkersTableAdapter workers = new WorkersTableAdapter();
        public static ManufacturersTableAdapter manufacturers = new ManufacturersTableAdapter();
        public Ad_Window()
        {
            InitializeComponent();
        }
        public void Add_alement()
        {
            if (choosed_adapter == 0)
            {
                Tb1.Visibility = Visibility.Visible;               
                Tb1.KeyDown += new KeyEventHandler(edit_box_KeyDown);
            }
            else if (choosed_adapter == 1)
            {
                
                Tb1.Visibility = Visibility.Visible;
                Tb1.Text = "Name";
                Tb2.Visibility = Visibility.Visible;
                Tb2.Text = "Surname";
                Tb3.Visibility = Visibility.Visible;
                Tb3.Text = "Lastname";
                Tb4.Visibility = Visibility.Visible;
                Tb4.Text = "Login";
                Tb5.Visibility = Visibility.Visible;
                Tb5.Text = "Password";
                Tb5.KeyDown += new KeyEventHandler(edit_box_KeyDown);
                Cb1.Visibility = Visibility.Visible;
                Cb1.ItemsSource = posts.GetData();
                Cb1.DisplayMemberPath = "Post_name";
                Cb1.SelectedValuePath = "ID";
                
            }
            else if (choosed_adapter == 2)
            {                
                Tb1.Visibility = Visibility.Visible;
                Tb1.Text = "Manufactorier name";
                Tb1.KeyDown += new KeyEventHandler(edit_box_KeyDown);
            }

        }

        private void edit_box_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                try {
                    TextBox edit_box = (TextBox)sender;
                    string data = edit_box.Text;
                    if (choosed_adapter == 0)
                    {
                        posts.InsertQuery(data);
                        Save_btn.Text = "Сохранено!";
                    }
                    else if (choosed_adapter == 1)
                    {
                        workers.InsertQuery(Tb1.Text, Tb2.Text, Tb3.Text, Tb4.Text, Tb5.Text, Convert.ToInt32(Cb1.SelectedValue));
                        Save_btn.Text = "Сохранено!";
                    }
                    else if (choosed_adapter == 2)
                    {

                        manufacturers.InsertQuery(Tb1.Text);
                    }
                    Task.Delay(400);
                    Save_btn.Text = "Enter для Сохранения";
                }
                catch
                {
                    MessageBox.Show("Ошибка сохранения");
                }
                





            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }

}
