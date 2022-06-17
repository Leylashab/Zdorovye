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

namespace Zdorovie
{
    /// <summary>
    /// Логика взаимодействия для PatientPage.xaml
    /// </summary>
    public partial class PatientPage : Page
    {
        ZdorovyeEntities context;
        private object pacienttable;
        public PatientPage()
        {
            InitializeComponent();
            context = new ZdorovyeEntities();
            Patienttable.ItemsSource = context.Patient.ToList();
       
        }
        public void RefreshData()
        {
            var list = context.Patient.ToList();

            if (string.IsNullOrWhiteSpace(fioBox.Text))
            {
                list = list.Where(x => x.fio.ToLower().Contains(fioBox.Text.ToLower())).ToList();
            }
            Patienttable.ItemsSource = list;

            if (string.IsNullOrWhiteSpace(omsBox.Text))
            {
                list = list.Where(x => x.oms.ToString().Contains(omsBox.Text.ToLower())).ToList();
            }
            Patienttable.ItemsSource = list;
        }

        private void ChangeFio(object sender, TextChangedEventArgs e)
        {
            RefreshData();
        }

        private void Changeoms(object sender, TextChangedEventArgs e)
        {
            RefreshData();
        }
        private void AddPatient(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddPatient(context));
        }
        private void EditPatient(object sender, RoutedEventArgs e)
        {
            Patient pacient = pacienttable.SelectedItems as Patient;
            NavigationService.Navigate(new AddPatient(context, pacient));
        }
        private void DeletePatient(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = MessageBox.Show("Вы уверены, что хотите удалить пациента?", "Подтверждение", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                try
                {
                    Patient pacient = pacienttable.SelectedItem as Patient;
                    context.Patient.Remove(pacient);
                    context.SaveChanges();
                    NavigationService.Navigate(new PatientPage());

                }


            }
        }
    }
}
