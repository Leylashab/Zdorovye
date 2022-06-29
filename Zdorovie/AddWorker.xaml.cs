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
    /// Логика взаимодействия для AddWorker.xaml
    /// </summary>
    public partial class AddWorker : Page
    {
        ZdorovyeEntities context;
        public AddWorker(ZdorovyeEntities cont)
        {
            InitializeComponent();
            context = cont;
            flag = true;
        }
        bool flag;

        private void AddSave(object sender, RoutedEventArgs e)
        {


            if (flag == true)
            {
                Worker worker = new Worker()
                {
                    idWorker = Convert.ToInt32(idBox.Text),
                    fio = fioBox.Text,
                    idPosition = (posBox.SelectedItem as ListPositions).id,
                    password = passBox.Text,
                    idAppel = (appBox.SelectedItem as Appel).idAppel,
                    idReception = (recBox.SelectedItem as Reception).idReception,               
                };
                context.Worker.Add(worker);
                Context.SaveChanges();
                NavigationService.Navigate(new WorkerPage());
            }
            else
            {

                context.Worker.Find(worker.idWorker).fio = fioBox.Text;
                context.Worker.Find(worker.idWorker).idPosition = (posBox.SelectedItem as ListPositions).id;
                context.Worker.Find(worker.idWorker).password = passBox.Text;
                context.Worker.Find(worker.idWorker).idAppel = (appBox.SelectedItem as Appel).idAppel;
                context.Worker.Find(worker.idWorker).idReception = (recBox.SelectedItem as Reception).idReception;

                context.SaveChanges();
                NavigationService.Navigate(new WorkerPage());
            }
        }
        Worker worker;
        public AddWorker(ZdorovyeEntities cont, Worker workers)
        {
            InitializeComponent();
            context = cont;
            posBox.ItemsSource = context.ListPositions.ToList();
            appBox.ItemsSource = context.Appel.ToList();
            recBox.ItemsSource = context.Reception.ToList(); 
            timeBox.ItemsSource = context.TimeTable.ToList();

          

            worker = workers;
            idBox.Text = workers.idWorker.ToString();
            fioBox.Text = workers.fio;
            posBox.SelectedItem = workers.ListPositions;
            passBox.Text = workers.password;
            appBox.Text = workers.Appel.ToString();
            recBox.Text = workers.Reception.ToString();
            flag = false;
        }
    }
}
