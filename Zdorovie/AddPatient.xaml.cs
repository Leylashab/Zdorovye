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
    /// Логика взаимодействия для AddPatient.xaml
    /// </summary>
 
    public partial class AddPatient : Page
    {
        ZdorovyeEntities Context;

        public AddPatient()
        {
            InitializeComponent();
            Context = context;
            flag = true;

        }
        bool flag;
        private void AddSave(object sender, RoutedEventArgs e)
        {
            if (flag == true)
            {
                Patient patient = new Patient()
                {

                    fio = fioBox.Text,
                    oms = Convert.ToDecimal(omsBox.Text),
                    seriesAndNumberPassword = serBox.Text,
                    phone = Convert.ToDecimal(phoneBox.Text)

                };
                context.Patient.Add(patient);
                context.SaveChanges();
                NavigationService.Navigate(new PatientPage());
            }
            else
            {

                context.Patient.Find(patient.oms).fio = fioBox.Text;
                context.Patient.Find(patient.oms).seriesAndNumberPassword = serBox.Text;
                context.Patient.Find(patient.oms).phone = Convert.ToDecimal(phoneBox.Text);



                context.SaveChanges();
                NavigationService.Navigate(new WorkerPage());
            }
        }
        Patient patient;
        public AddPatient(ZdorovyeEntities cont, Patient pat)
        {
            InitializeComponent();
            context = cont;

            patient = pat;

            fioBox.Text = pat.fio;
            omsBox.Text = pat.oms.ToString();
            serBox.Text = pat.seriesAndNumberPassword;
            phoneBox.Text = pat.phone.ToString();
            flag = false;
        }
    }
}
