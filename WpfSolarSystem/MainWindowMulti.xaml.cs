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
using System.Windows.Shapes;

namespace WpfSolarSystem
{
    /// <summary>
    /// Interaction logic for MainWindowMulti.xaml
    /// </summary>
    public partial class MainWindowMulti : Window
    {
        Timer t = null;
        Timer t1 = null;
        Timer t2 = null;

        public MainWindowMulti()
        {
            InitializeComponent();
            Planet p3 = new Planet(120, 120, 0.02, 200, 70, Brushes.Yellow);
            this.universeCanvas.Children.Add(p3.mEllipse);
            
            Planet p1 = new Planet(50, 50, 0.05, 70, 150, Brushes.Pink);
            this.universeCanvas.Children.Add(p1.mEllipse);

            Planet p2 = new Planet(20, 20, 0.05, 270, 100, Brushes.Green);
            this.universeCanvas.Children.Add(p2.mEllipse);

            t = new Timer(
            MovePlanet,
            p1,
            0,
            20);

            t1 = new Timer(
            MovePlanet,
            p3,
            0,
            20);

            t2 = new Timer(
            MovePlanet,
            p2,
            0,
            10);
        }

        /// <summary>
        /// Animates the planet movement by using timers (Threads)
        /// </summary>
        /// <param name="state"></param>
        public void MovePlanet(object state)
        {
            Planet planet = (Planet)state;
            planet.CalcMove();
            
            Dispatcher.Invoke(() => planet.Move());
        }

        /*
         * //anonymous action version
        public void movePlanet(object state)
        {
            Planet p1 = (Planet)state;
            planet.CalcMove();
            this.Dispatcher.Invoke((Action)delegate ()
            {                
                p1.Move();
            });
        }
        */
    }
}
