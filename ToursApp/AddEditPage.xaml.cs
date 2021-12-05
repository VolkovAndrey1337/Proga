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
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private Registration _currentRegistration = new Registration();

        public AddEditPage(Registration selectedRegistration)
        {
            InitializeComponent();

            if (selectedRegistration != null)
                _currentRegistration = selectedRegistration;

            DataContext = _currentRegistration;
            ComboDiagnosis.ItemsSource = PoliclinicaPractikaEntities.GetContext().Diagnosis.ToList();
            ComboDoctor.ItemsSource = PoliclinicaPractikaEntities.GetContext().Doctor.ToList();
            ComboPatient.ItemsSource = PoliclinicaPractikaEntities.GetContext().Patient.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(Convert.ToString(_currentRegistration.Number_Coupons)))
                errors.AppendLine("Укажите номер талона"); 
            if (string.IsNullOrWhiteSpace(_currentRegistration.Date))
                errors.AppendLine("Укажите дату визита");
            if (string.IsNullOrWhiteSpace(_currentRegistration.Visit_purpose))
                errors.AppendLine("Укажите цель визита");
            if (string.IsNullOrWhiteSpace(Convert.ToString(_currentRegistration.Price)))
                errors.AppendLine("Укажите цену посещения");
            if (_currentRegistration.Diagnosis == null)
                errors.AppendLine("Выберите диагноз");
            if (_currentRegistration.Doctor == null)
                errors.AppendLine("Выберите диагноз");
            if (_currentRegistration.Patient == null)
                errors.AppendLine("Выберите диагноз");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;

            }

            if (_currentRegistration.Id == 0)
            {
                PoliclinicaPractikaEntities.GetContext().Registration.Add(_currentRegistration);
            }

            try
            {
                PoliclinicaPractikaEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
        }
    }
}
