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

namespace TelekomNevaNetwork
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void repeat_Click(object sender, RoutedEventArgs e)
        {
            getCode cod = new getCode();
            cod.Show();
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            inputPassword.Clear();
            inputCode.Clear();
            inputNumber.Clear();
            inputPassword.IsEnabled = false;
        }
        /// <summary>
        /// кнопка авторизации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void inSign_Click(object sender, RoutedEventArgs e)
        {
            using(var db = new UserAuthEntities())
            {
                var log = db.users.AsNoTracking().FirstOrDefault(u => u.number == inputNumber.Text && u.password == inputPassword.Password);
                var pass = db.users.AsNoTracking().FirstOrDefault(u=> u.password == inputPassword.Password);

                if(log == null)
                {
                    MessageBox.Show("Пользователь не найден!");

                }
                else
                {
                    if(pass == null)
                    {
                        MessageBox.Show("Неверный пароль!");
                    }
                    else
                    {
                        string intCod = inputCode.Text.ToString();
                        string randcode = getCode.randNum.ToString();

                        inputCode.IsEnabled = true;

                        
                        if (intCod == randcode)
                        {
                            string rol = pass.numRol.ToString();

                            if(rol == "1")
                            {
                                MessageBox.Show("Ваша роль - Специалист ТП (выездной инженер)");
                            }
                            else if(rol == "2")
                            {
                                MessageBox.Show("Ваша роль - Директор по развитию"); 
                            }
                            else if (rol == "3")
                            {
                                MessageBox.Show("Ваша роль - Технический департамент");
                            }
                            else if (rol == "4")
                            {
                                MessageBox.Show("Ваша роль - Бухгалтер");
                            }
                            else if(rol == "5")
                            {
                                MessageBox.Show("Ваша роль - Менеджер по работе с клиентами");
                            }

                        }

                    }
                }

            }
        }

        /// <summary>
        /// обработка нажатия
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void inputNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                if(inputNumber.Text.Length > 0)
                {
                    inputPassword.IsEnabled = true;
                    inputPassword.Focus();
                }
                else
                {
                    MessageBox.Show("Введите номер!");
                }
            }
        }

        private void inputPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                if(inputPassword.Password.Length > 0)
                {
                    using (var db = new UserAuthEntities())
                    {
                        var log = db.users.AsNoTracking().FirstOrDefault(u => u.number == inputNumber.Text && u.password == inputPassword.Password);
                        var pass = db.users.AsNoTracking().FirstOrDefault(u => u.password == inputPassword.Password);
                        if(log == null)
                        {
                            MessageBox.Show("Пользователь не найден!");
                            inputPassword.Clear();
                            inputNumber.Clear();
                            inputPassword.IsEnabled = false;
                        }
                        else
                        {
                            if(pass == null)
                            {
                                MessageBox.Show("Неверный пароль");
                                inputPassword.Clear();
                            }
                            else
                            {
                                inputCode.IsEnabled = true;
                                getCode cod = new getCode();
                                cod.Show();
                            }
                            
                        }
                    }
                }    
                else
                {
                    MessageBox.Show("Введите пароль");
                }
            }
        }

        private void inputCode_KeyDown(object sender, KeyEventArgs e)
        {
            inSign.IsEnabled = true;
        }
    }
}
