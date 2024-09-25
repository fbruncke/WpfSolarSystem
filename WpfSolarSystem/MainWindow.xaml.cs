using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace WpfSolarSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            InitializeComponent();

            Console.WriteLine("WPF form constructor thread id: " + Thread.CurrentThread.ManagedThreadId);

            Planet p3 = new Planet(120, 120, 0.02, 200, 70, Brushes.Yellow);
            this.universeCanvas.Children.Add(p3.mEllipse);


            Planet p1 = new Planet(50, 50 , 0.05, 70,150, Brushes.Pink);
            this.universeCanvas.Children.Add(p1.mEllipse);

            Planet p2 = new Planet(20, 20, 0.05, 270, 100, Brushes.Green);
            this.universeCanvas.Children.Add(p2.mEllipse);


            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(20);
            timer.Tick += p1.Move;
            timer.Tick += p3.Move;
            timer.Start();

            DispatcherTimer timer2 = new DispatcherTimer();
            timer2.Interval = TimeSpan.FromMilliseconds(10);
            timer2.Tick += p2.Move;
            timer2.Start();

        }

        
    }
}
