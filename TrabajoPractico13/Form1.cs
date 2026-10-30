using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using S7.Net;
using System.Globalization;  //Por el idioma de windows usa coma para float, y el float lleva punto, asi lo normaliza todo a uno

namespace TrabajoPractico13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    }
}
