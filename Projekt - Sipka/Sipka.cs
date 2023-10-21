using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt___Sipka
{
    public enum Smer
    {
        nahoru = 1,
        dolu = 2,
        doleva = 3,
        doprava = 4,
    }
    
    public partial class Sipka : UserControl
    {
        public event EventHandler Naraz;
        Graphics parentG;
        public Sipka()
        {
            InitializeComponent();            
            Random rand = new Random();
            smer = (Smer)rand.Next(1, 5);
            tloustka = rand.Next(1, 6);
            ForeColor = Color.FromArgb(rand.Next(0, 256), rand.Next(0, 256), rand.Next(0, 256));
        }
        private Smer smer;
        public Smer Smer { get => smer; set => smer = value; } 
        public int Tloustka { get => tloustka; set => tloustka = value; }
        private int tloustka;
        public Color Barva { get => ForeColor; set => ForeColor = value; }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            int centerh = Width / 2;
            int centerv = Height / 2;
            Pen p = new Pen(ForeColor, tloustka);
            if ((int)smer == 1 || (int)smer == 2)
            {
                g.DrawLine(p, new Point(centerh, ClientRectangle.Top), new Point(centerh, ClientRectangle.Bottom));
                g.DrawLine(p, new Point(centerh, (int)smer == 1 ? ClientRectangle.Top : ClientRectangle.Bottom), new Point(ClientRectangle.Left, (int)smer == 1 ? ClientRectangle.Width / 2 : ClientRectangle.Bottom - ClientRectangle.Width / 2));
                g.DrawLine(p, new Point(centerh, (int)smer == 1 ? ClientRectangle.Top : ClientRectangle.Bottom), new Point(ClientRectangle.Right, (int)smer == 1 ? ClientRectangle.Width / 2 : ClientRectangle.Bottom - ClientRectangle.Width / 2));
            }
            else
            {
                g.DrawLine(p, new Point(ClientRectangle.Left, centerv), new Point(ClientRectangle.Right, centerv));
                g.DrawLine(p, new Point((int)smer == 3 ? ClientRectangle.Left : ClientRectangle.Right, centerv), new Point((int)smer == 3 ? ClientRectangle.Height / 2 : ClientRectangle.Right - ClientRectangle.Height / 2, ClientRectangle.Top));
                g.DrawLine(p, new Point((int)smer == 3 ? ClientRectangle.Left : ClientRectangle.Right, centerv), new Point((int)smer == 3 ? ClientRectangle.Height / 2 : ClientRectangle.Right - ClientRectangle.Height / 2, ClientRectangle.Bottom));
            }
        }
        public void Pohyb()
        {
            Refresh();
            switch ((int)smer)
            {
                case 1:
                    Top -= 5;
                    break;
                case 2:
                    Top += 5;
                    break;
                case 3:
                    Left -= 5;
                    break;
                case 4:
                    Left += 5;
                    break;
            }
            if (Naraz != null && (Top <= 0 || Left <= 0 || Bottom >= Parent.ClientSize.Height || Right >= Parent.ClientSize.Width))
            {
                Naraz?.Invoke(this, new EventArgs());
                return;
            }
            
        }
    }
}

