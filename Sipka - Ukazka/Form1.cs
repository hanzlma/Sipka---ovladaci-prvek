using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Projekt___Sipka;
namespace Sipka___Ukazka
{
    public partial class Form1 : Form
    {
        Sipka sipka;
        public Form1()
        {
            InitializeComponent();
            sipka = new Sipka();
            sipka.Width = 100;
            sipka.Height = 100S;
        }
        
    }
}
