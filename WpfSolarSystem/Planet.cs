using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;


namespace WpfSolarSystem
{
    public class Planet 
    {
        public Ellipse mEllipse { get; set; }
        public double Speed { get; set; }
        private int xpos = 0;
        private int ypos = 0;

        int newYpos = 0;
        int newXpos = 0;

        public Planet(int height, int width, double speed, int xpos, int ypos, SolidColorBrush colour)
        {
            mEllipse = new Ellipse() {
                Height = height,
                Width = width,
                Fill = colour,
            };
            this.Speed = speed;
            this.xpos = xpos;
            this.ypos = ypos;

        }

        double testAngle = 0;
        public void Move(Object sender, EventArgs e)
        {
            testAngle+=this.Speed;
 
            
            int newYpos = (int)(Math.Sin(testAngle) * 100 + this.ypos);
            int newXpos = (int)(Math.Cos(testAngle) * 100 + this.xpos);
            
            if (mEllipse.Parent != null)
            {                
                Canvas.SetTop(mEllipse, newYpos);
                Canvas.SetLeft(mEllipse, newXpos);
            }
            Console.WriteLine("PlanetMovement thread id: " + Thread.CurrentThread.ManagedThreadId);
        }

        public void CalcMove()
        {
            //MainWindowMulti mwm = (MainWindowMulti)MainWindowMultiInst;

            testAngle += this.Speed;
            //pos = pos + 15;
            //xpos = (int)Math.Cos(pos%360);
            //Console.WriteLine("pos: "+ pos % 360);
            //Console.WriteLine("xpos: " + (pos % 360) + " - " + (Math.Sin((pos % 360))));

            newYpos = (int)(Math.Sin(testAngle) * 100 + this.ypos);
            newXpos = (int)(Math.Cos(testAngle) * 100 + this.xpos);                      

            Console.WriteLine("PlanetMovement thread id: " + Thread.CurrentThread.ManagedThreadId);
        }

        internal void Move()
        {
            if (mEllipse.Parent != null)
            {
                //Action action = () => Console.WriteLine("called");

                //mwm.Dispatcher.Invoke(action);
                //mwm.Dispatcher.Invoke(action); 
                Canvas.SetTop(mEllipse, newYpos);
                Canvas.SetLeft(mEllipse, newXpos);

            }
        }
    }
}
