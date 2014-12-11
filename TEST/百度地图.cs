using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TEST
{
    public partial class 百度地图 : Form
    {
        public 百度地图()
        {
            InitializeComponent();

            webBrowser1.Navigate(System.Environment.CurrentDirectory + "\\Map.html");
        }
    }
}
