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
using Laba_5_pipets_kollegi.FINAL_PROJECTDataSetTableAdapters;

namespace Laba_5_pipets_kollegi
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WorkersTableAdapter workers = new WorkersTableAdapter();
        AdminPanel adminPanel = new AdminPanel();
        Sklad_window sklad = new Sklad_window();

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool is_login = false;
            var all_people = workers.GetData().Rows;
            for (int i = 0; i < all_people.Count; i++)
            {
                if (all_people[i][4].ToString() == Login_txt.Text &&
                    all_people[i][5].ToString() == Password_txt.Password)
                //if (true)
                {
                    is_login = true;
                    this.Close();                  
                    if (Convert.ToInt32(all_people[i][6].ToString()) == 1) 
                    {                                   
                        adminPanel.Show();
                    }
                    else if (Convert.ToInt32(all_people[i][6].ToString()) == 6)
                    {
                        sklad.Show();
                    }

                } 
            }
            if (!is_login)
            {
                MessageBox.Show("Неправильный логин или пароль!!!!!");
            }

        }

        private void Login_txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) 
            {
                Password_txt.Focus();
            }
            
        }

        private void Password_txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                this.Button_Click(sender, e);
            }
        }
    }
}
