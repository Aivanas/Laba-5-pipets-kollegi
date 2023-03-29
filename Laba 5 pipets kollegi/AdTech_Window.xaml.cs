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
    /// Логика взаимодействия для AdTech_Window.xaml
    /// </summary>
    public partial class AdTech_Window : Window
    {
        public int choosed_adapter;
        TractorsTableAdapter tractors = new TractorsTableAdapter();
        HarrowsTableAdapter harrows = new HarrowsTableAdapter();
        SprinklersTableAdapter sprinklers = new SprinklersTableAdapter();
        CultivatorsTableAdapter cultivators = new CultivatorsTableAdapter();
        Tractor_trailersTableAdapter trailers = new Tractor_trailersTableAdapter();
        ManufacturersTableAdapter manufacturers = new ManufacturersTableAdapter();
        public AdTech_Window()
        {
            InitializeComponent();
        }

        public void Ad_smthg()
        {
            if (choosed_adapter == 0)
            {
                Tb1.Visibility = Visibility.Visible;
                Tb1.Text = "Наименование трактора";
                Tb2.Visibility = Visibility.Visible;
                Tb2.Text = "Цена трактора";
                Tb3.Visibility = Visibility.Visible;
                Tb3.Text = "Мощность трактора";
                Tb4.Visibility = Visibility.Visible;
                Tb4.Text = "Объём двигателя";
                Cb1.Visibility = Visibility.Visible;
                Cb1.Text = "Производитель";
                Cb1.ItemsSource = manufacturers.GetData();
                Cb1.DisplayMemberPath = "Manf_name";
                Cb1.SelectedValuePath = "Manf_ID";

            }
            else if (choosed_adapter == 1 | choosed_adapter == 2)
            {

                Tb1.Visibility = Visibility.Visible;
                Tb1.Text = "Наименование";
                Tb2.Visibility = Visibility.Visible;
                Tb2.Text = "Цена";
                Tb3.Visibility = Visibility.Visible;
                Tb3.Text = "Требуемая мощность";
                Tb4.Visibility = Visibility.Visible;
                Tb4.Text = "Максимальная рабочая скорость";
                Tb6.Visibility = Visibility.Visible;
                Tb6.Text = "Ширина обработки";
                Tb5.Visibility = Visibility.Visible;                
                if (choosed_adapter == 1)
                {
                    Tb5.Text = "Глубина обработки";                   
                }
                else
                {
                    Tb5.Text = "Объём бака";
                }
                Cb1.Visibility = Visibility.Visible;
                Cb1.ItemsSource = manufacturers.GetData();
                Cb1.DisplayMemberPath = "Manf_name";
                Cb1.SelectedValuePath = "Manf_ID";

            }
            else if (choosed_adapter == 3)
            {

                Tb1.Visibility = Visibility.Visible;
                Tb1.Text = "Наименование";
                Tb2.Visibility = Visibility.Visible;
                Tb2.Text = "Цена";
                Tb3.Visibility = Visibility.Visible;
                Tb3.Text = "Транспортная скорость";
                Tb4.Visibility = Visibility.Visible;
                Tb4.Text = "Максимальная рабочая скорость";
                Tb5.Visibility = Visibility.Visible;
                Tb5.Text = "Необходимая рабочая мощность";
                Tb6.Visibility = Visibility.Visible;
                Tb6.Text = "Ширина захвата";
 
            }
            else if (choosed_adapter == 4)
            {

                Tb1.Visibility = Visibility.Visible;
                Tb1.Text = "Наименование";
                Tb2.Visibility = Visibility.Visible;
                Tb2.Text = "Цена";
                Tb3.Visibility = Visibility.Visible;
                Tb3.Text = "Транспортная скорость";
                Tb4.Visibility = Visibility.Visible;
                Tb4.Text = "Максимальная загрузка";
                Tb5.Visibility = Visibility.Visible;
                Tb5.Text = "Необходимая мощность";

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void MegaGrid_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Enter)
            {
                try {
                    if (choosed_adapter == 0)
                    {
                        tractors.InsertQuery(Tb1.Text, Convert.ToInt32(Tb2.Text), Convert.ToInt16(Tb3.Text), Convert.ToDouble(Tb4.Text), Convert.ToInt32(Cb1.SelectedValue));
                        Save_btn.Text = "Сохранено!";
                    }
                    else if (choosed_adapter == 1)
                    {
                        harrows.InsertQuery(Tb1.Text, Convert.ToInt32(Tb2.Text), Convert.ToInt16(Tb3.Text), Convert.ToInt16(Tb4.Text), Convert.ToInt16(Tb5.Text), Convert.ToInt16(Tb6.Text), Convert.ToInt16(Cb1.SelectedValue));
                        Save_btn.Text = "Сохранено!";
                    }
                    else if (choosed_adapter == 2)
                    {
                        sprinklers.InsertQuery(Tb1.Text, Convert.ToInt32(Tb2.Text), Convert.ToInt16(Tb5.Text), Convert.ToInt16(Tb3.Text), Convert.ToInt16(Tb4.Text), Convert.ToInt16(Tb6.Text), Convert.ToInt16(Cb1.SelectedValue));
                        Save_btn.Text = "Сохранено!";
                    }
                    else if (choosed_adapter == 3)
                    {
                        cultivators.InsertQuery(Tb1.Text, Convert.ToInt32(Tb2.Text), Convert.ToInt32(Tb3.Text), Convert.ToInt32(Tb4.Text), Convert.ToInt32(Tb5.Text), Convert.ToInt32(Tb6.Text));
                        Save_btn.Text = "Сохранено!";
                    }
                    else if (choosed_adapter == 4)
                    {
                        trailers.InsertQuery(Tb1.Text, Convert.ToInt32(Tb2.Text), Convert.ToInt32(Tb3.Text), Convert.ToInt32(Tb4.Text), Convert.ToInt32(Tb5.Text));
                        Save_btn.Text = "Сохранено!";
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка сохранения");
                }
                
            }
        }
    }
}
