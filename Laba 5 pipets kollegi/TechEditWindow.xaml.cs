using Laba_5_pipets_kollegi.FINAL_PROJECTDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Laba_5_pipets_kollegi
{
    /// <summary>
    /// Логика взаимодействия для TechEditWindow.xaml
    /// </summary>
    public partial class TechEditWindow : Window
    {
        public int choosed_adapter;
        TractorsTableAdapter tractors = new TractorsTableAdapter();
        HarrowsTableAdapter harrows = new HarrowsTableAdapter();
        SprinklersTableAdapter sprinklers = new SprinklersTableAdapter();
        CultivatorsTableAdapter cultivators = new CultivatorsTableAdapter();
        Tractor_trailersTableAdapter trailers = new Tractor_trailersTableAdapter();
        ManufacturersTableAdapter manufacturers = new ManufacturersTableAdapter();
        public TechEditWindow()
        {
            InitializeComponent();
        }

        public void StartEdit()
        {
            if (choosed_adapter == 0)
            {
                Choose_cmbx.ItemsSource = tractors.GetData();
                Choose_cmbx.DisplayMemberPath = "Tractor_name";
                Choose_cmbx.SelectedValuePath = "Tractor_ID";
            }
            else if (choosed_adapter == 1)
            {
                Choose_cmbx.ItemsSource = harrows.GetData();
                Choose_cmbx.DisplayMemberPath = "Harrow_name";
                Choose_cmbx.SelectedValuePath = "Harrow_ID";

            }
            else if (choosed_adapter == 2)
            {
                Choose_cmbx.ItemsSource = sprinklers.GetData();
                Choose_cmbx.DisplayMemberPath = "Sprinkler_name";
                Choose_cmbx.SelectedValuePath = "Sprinkler_ID";
            }
            else if (choosed_adapter == 3)
            {
                Choose_cmbx.ItemsSource = cultivators.GetData();
                Choose_cmbx.DisplayMemberPath = "Cultivator_name";
                Choose_cmbx.SelectedValuePath = "Cultivator_ID";
            }
            else if (choosed_adapter == 4)
            {
                Choose_cmbx.ItemsSource = trailers.GetData();
                Choose_cmbx.DisplayMemberPath = "Trailer_name";
                Choose_cmbx.SelectedValuePath = "Trailer_ID";
            }
        }



        private void MegaGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                try {
                    switch (choosed_adapter)
                    {
                        case 0:
                            tractors.UpdateQuery(Convert.ToInt32(Choose_cmbx.SelectedValue), Tb1.Text, Convert.ToInt32(Tb2.Text), Convert.ToInt16(Tb3.Text), Convert.ToDouble(Tb4.Text), Convert.ToInt32(Cb1.SelectedValue));
                            Save_btn.Text = "Сохранено!";
                            break;
                        case 1:
                            harrows.UpdateQuery(Convert.ToInt32(Choose_cmbx.SelectedValue), Tb1.Text, Convert.ToInt32(Tb2.Text), Convert.ToInt16(Tb3.Text), Convert.ToInt16(Tb4.Text), Convert.ToInt16(Tb5.Text), Convert.ToInt16(Tb6.Text), Convert.ToInt32(Cb1.SelectedValue));
                            Save_btn.Text = "Сохранено!";
                            break;
                        case 2:
                            sprinklers.UpdateQuery(Convert.ToInt32(Choose_cmbx.SelectedValue), Tb1.Text, Convert.ToInt32(Tb2.Text), Convert.ToInt16(Tb3.Text), Convert.ToInt16(Tb4.Text), Convert.ToInt16(Tb5.Text), Convert.ToInt16(Tb6.Text), Convert.ToInt32(Cb1.SelectedValue));
                            Save_btn.Text = "Сохранено!";
                            break;
                        case 3:
                            cultivators.UpdateQuery(Tb1.Text, Convert.ToInt32(Tb2.Text), Convert.ToInt16(Tb3.Text), Convert.ToInt16(Tb4.Text), Convert.ToInt16(Tb5.Text), Convert.ToInt16(Tb6.Text), Convert.ToInt32(Choose_cmbx.SelectedValue));
                            Save_btn.Text = "Сохранено!";
                            break;
                        case 4:
                            trailers.UpdateQuery(Tb1.Text, Convert.ToInt32(Tb2.Text), Convert.ToInt16(Tb3.Text), Convert.ToInt16(Tb4.Text), Convert.ToInt32(Cb1.SelectedValue), Convert.ToInt32(Choose_cmbx.SelectedValue));
                            Save_btn.Text = "Сохранено!";
                            break;

                            Task.Delay(1000);
                            Save_btn.Text = "Enter для Сохранения";
                    }
                }
                catch 
                {
                    MessageBox.Show("Ошибка! Вероятно вы ввели неверный тип данных");
                }

                
            }
        }

        private void Choose_cmbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (choosed_adapter == 0)
            {
                Tb1.Visibility = Visibility.Visible;
                var item = (Choose_cmbx.SelectedItem as DataRowView).Row;
                Tb1.Text = item[1].ToString();
                Tb2.Visibility = Visibility.Visible;
                Tb2.Text = item[2].ToString();
                Tb3.Visibility = Visibility.Visible;
                Tb3.Text = item[3].ToString();
                Tb4.Visibility = Visibility.Visible;
                Tb4.Text = item[4].ToString();
                Cb1.Visibility = Visibility.Visible;
                Cb1.ItemsSource = manufacturers.GetData();
                Cb1.DisplayMemberPath = "Manf_name";
                Cb1.SelectedValuePath = "Manf_ID";
                
            }
            else if (choosed_adapter == 1 | choosed_adapter == 2)
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
                Tb6.Visibility = Visibility.Visible;
                Tb6.Text = item[6].ToString();
                Cb1.Visibility = Visibility.Visible;
                Cb1.ItemsSource = manufacturers.GetData();
                Cb1.DisplayMemberPath = "Manf_name";
                Cb1.SelectedValuePath = "Manf_ID";
                Cb1.SelectedValue = item[7];
            }
            else if (choosed_adapter == 3)
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
                Tb6.Visibility = Visibility.Visible;
                Tb6.Text = item[6].ToString();
            }
            else if(choosed_adapter == 4)
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
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
