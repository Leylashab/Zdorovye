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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        ZdorovyeEntities context;
        public MainWindow()
        {
            InitializeComponent();
            context = new ZdorovyeEntities();
        }

        private void EnterClick(object sender, RoutedEventArgs e)
        {
            try
            {
                int idWorker = Convert.ToInt32(login.Text);
                string pass = password.Text;

                Worker worker = context.Worker.ToList().Find(x => x.idWorker == idWorker);
                if (worker == null)
                {
                    MessageBox.Show("Работника с таким логином не существует!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if (worker.password.Equals(pass))

                    {
                        MessageBox.Show("Успешная авторизация", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                        password.Background = new SolidColorBrush(Color.FromRgb(0, 255, 0));
                    }
                    else
                    {                      
                        MessageBox.Show("Неверный пароль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        password.Background = new SolidColorBrush(Color.FromRgb(204, 0, 0));
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Неверный логин!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }


        private void password_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void login_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    } 
    }


