using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThoughtWorks.QRCode.Codec;

namespace TEST
{
    public partial class 二维码 : Form
    {
        public 二维码()
        {
            InitializeComponent();

            pictureBox1.Image = ToQRCode(textBox1.Text);
        }

        private Bitmap ToQRCode(string str)
        {
            try
            {
                QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
                qrCodeEncoder.QRCodeVersion = 7;
                qrCodeEncoder.QRCodeScale = int.Parse(comboBox1.Text);
                //生成图像
                return qrCodeEncoder.Encode(str, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.Message;
                return new Bitmap(1,1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = ToQRCode(textBox1.Text);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = ToQRCode(textBox1.Text);
        }
    }
}
