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
    /// Логика взаимодействия для WorkerPage.xaml
    /// </summary>
    public partial class WorkerPage : Page
    {
        ZdorovyeEntities context;
        public WorkerPage()
        {
            InitializeComponent();
            context = new ZdorovyeEntities();
            workertable.ItemsSource = context.Worker.ToList();

            var positionList = context.ListPositions.ToList();
            positionList.Insert(0, new ListPositions() { title = "все", id = 0 });
            idPositionBox.ItemsSource = positionList;
        }
        public void RefreshData()
        {
            var list = context.Worker.ToList();
            if (idPositionBox.SelectedIndex > 0)
            {
                ListPositions pos = idPositionBox.SelectedItem as ListPositions;
                list = list.Where(x => x.ListPositions == pos).ToList();
            }


            if (string.IsNullOrWhiteSpace(fioBox.Text))
            {
                list = list.Where(x => x.fio.ToLower().Contains(fioBox.Text.ToLower())).ToList();
            }
            workertable.ItemsSource = list;
            if (string.IsNullOrWhiteSpace(fioBox.Text))
            {
            }
            workertable.ItemsSource = list;
        }
        private void fiochanged(object sender, TextChangedEventArgs e)
        {
            RefreshData();
        }

        private void positionchanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshData();
        }

        private void DeleteWorker(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = MessageBox.Show("Вы уверены, что хотите удалить сотрудника?", "Подтверждение", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                try
                {
                    Worker worker = workertable.SelectedItem as Worker;
                    context.Worker.Remove(worker);
                    context.SaveChanges();
                    NavigationService.Navigate(new WorkerPage());
                }
                catch
                {
                    MessageBox.Show("Ошибка!");
                }
            }


        }
        private void EditWorker(object sender, RoutedEventArgs e)
        {
            Worker worker = workertable.SelectedItem as Worker;
            NavigationService.Navigate(new AddWorker(context, worker));
        }
        private void AddWorker(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddWorker(context));
        }
    }
}
