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

namespace ToursApp
{
    /// <summary>
    /// Логика взаимодействия для HotelsPage.xaml
    /// </summary>
    public partial class HotelsPage : Page
    {
        public HotelsPage()
        {
            InitializeComponent();
            //DGRegistration.ItemsSource = PoliclinicaPractikaEntities.GetContext().Registration.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage((sender as Button).DataContext as Registration));
        } 

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var registrationForRemoving = DGRegistration.SelectedItems.Cast<Registration>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить слудующие {registrationForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    PoliclinicaPractikaEntities.GetContext().Registration.RemoveRange(registrationForRemoving);
                    PoliclinicaPractikaEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DGRegistration.ItemsSource = PoliclinicaPractikaEntities.GetContext().Registration.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility==Visibility.Visible)
            {
                PoliclinicaPractikaEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGRegistration.ItemsSource = PoliclinicaPractikaEntities.GetContext().Registration.ToList();
            }
        }
    }
}
