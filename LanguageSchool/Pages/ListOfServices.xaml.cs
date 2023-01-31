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

namespace LanguageSchool.Pages
{
    /// <summary>
    /// Логика взаимодействия для ListOfServices.xaml
    /// </summary>
    public partial class ListOfServices : Page
    {
        public ListOfServices()
        {
            InitializeComponent();
            lvService.ItemsSource = Model.tbe.Service.ToList();
        }

        private void tbOldPrice_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock text = (TextBlock)sender;
            if (text.Uid != null) { text.Visibility = Visibility.Visible; }
            else { text.Visibility = Visibility.Hidden; }
        }

        private void tbActualPrice_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void tbSale_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock textBlock = (TextBlock)sender;
            if (textBlock.Uid != null) { textBlock.Visibility = Visibility.Visible; }
            else { textBlock.Visibility = Visibility.Hidden; }
        }
        private void cmbFiltres_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filtres();
        }
        private void cmbSorted_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filtres();
        }
        private void tbNameDescription_SelectionChanged(object sender, RoutedEventArgs e)
        {
            Filtres();
        }
         
        void Filtres()
        {
            List<Service> services = Model.tbe.Service.ToList();
            try
            {


                if (cmbFiltres.SelectedIndex != 0)
                {

                    ComboBoxItem comboBoxItemFilres = (ComboBoxItem)cmbFiltres.SelectedItem;
                    if(comboBoxItemFilres != null)
                    switch (comboBoxItemFilres.Content)
                    {
                        case "По умолчанию":
                            {
                                services = services;
                                break;
                            }
                        case "от 0 до 5%":
                            {
                                services = services.Where(x => x.Discount >= 0 && x.Discount < 5).ToList();
                                break;

                            }
                         
                        case "от 5 до 15%":
                            {

                                services = services.Where(x => x.Discount >= 5 && x.Discount < 15).ToList();
                                break;
                            }
                       
                        case "от 15 до 30%":
                            {

                                services = services.Where(x => x.Discount >= 15 && x.Discount < 30).ToList();
                                break;
                            }
                            
                        case "от 30 до 70%":
                            {

                                services = services.Where(x => x.Discount >= 30 && x.Discount < 70).ToList();
                                break;
                            }
                          
                        case "от 70 до 100%":
                            {

                                services = services.Where(x => x.Discount >= 70 && x.Discount < 100).ToList();
                                break;
                            }
                           



                    }

                }
                else
                {
                    MessageBox.Show("Отсутствие подходящих записей", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                }



                if (cmbSorted != null)
                    if (cmbSorted.SelectedIndex != 0)
                    {
                        ComboBoxItem comboBoxItem = (ComboBoxItem)cmbSorted.SelectedItem;
                        if (comboBoxItem != null)
                        {
                            switch (comboBoxItem.Content)
                            {
                                case "По возрастанию":
                                    {
                                        services = services.OrderBy(x => x.ActualPrice).ToList();
                                        break;
                                    }
                                case "По убыванию":
                                    {
                                        services = services.OrderByDescending(x => x.ActualPrice).ToList();
                                        break;
                                    }
                                default:
                                    services = services;
                                    break;


                            }
                        }


                    }
               
                
                if(tbNameDescription.Text != "")
                {
                    if (tbNameDescription.Text != null)
                    {
                        services = services.Where(x => x.Title.ToLower().Contains(tbNameDescription.Text.ToLower()) || (x.Description.ToLower().Contains(tbNameDescription.Text.ToLower()))).ToList();

                    }


                }


                lvService.ItemsSource = services;
            }
            catch
            {
                MessageBox.Show("Что-то пошло явно не так");
            }

        }
      

    }
}
