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
using System.Windows.Shapes;

using System.Windows.Threading;

namespace TelekomNevaNetwork
{
    /// <summary>
    /// Логика взаимодействия для getCode.xaml
    /// </summary>
    public partial class getCode : Window
    {
        public static int randNum { get; set; }
        public getCode()
        {
            InitializeComponent();

            var timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_tick);
            timer.Interval = new TimeSpan(0, 0, 10);
            timer.Start();


            Random random = new Random();
            randNum = random.Next(10000000, 99999999);
            getcod.Text = randNum.ToString();


        }

        private void timer_tick(object sender, EventArgs e)
        {
            randNum = 111111111;
            Close();
        }
    }
}
