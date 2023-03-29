using Laba_5_pipets_kollegi.FINAL_PROJECTDataSetTableAdapters;
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

namespace Laba_5_pipets_kollegi
{
    /// <summary>
    /// Логика взаимодействия для DelTechWindow.xaml
    /// </summary>
    public partial class DelTechWindow : Window
    {
        public int choosed_adapter;
        TractorsTableAdapter tractors = new TractorsTableAdapter();
        HarrowsTableAdapter harrows = new HarrowsTableAdapter();
        SprinklersTableAdapter sprinklers = new SprinklersTableAdapter();
        CultivatorsTableAdapter cultivators = new CultivatorsTableAdapter();
        Tractor_trailersTableAdapter trailers = new Tractor_trailersTableAdapter();

        public DelTechWindow()
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
                try
                {
                    switch (choosed_adapter)
                    {
                        case 0:
                            tractors.DeleteQuery(Convert.ToInt32(Choose_cmbx.SelectedValue));
                            Save_btn.Text = "Сохранено!";
                            break;
                        case 1:
                            harrows.DeleteQuery(Convert.ToInt32(Choose_cmbx.SelectedValue));
                            Save_btn.Text = "Сохранено!";
                            break;
                        case 2:
                            sprinklers.DeleteQuery(Convert.ToInt32(Choose_cmbx.SelectedValue));
                            Save_btn.Text = "Сохранено!";
                            break;
                        case 3:
                            cultivators.DeleteQuery(Convert.ToInt32(Choose_cmbx.SelectedValue));
                            Save_btn.Text = "Сохранено!";
                            break;
                        case 4:
                            trailers.DeleteQuery(Convert.ToInt32(Choose_cmbx.SelectedValue));
                            Save_btn.Text = "Сохранено!";
                            break;
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка! Вероятно вы ввели неверный тип данных");
                }


            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
