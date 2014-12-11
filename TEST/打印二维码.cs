using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpreadsheetGear;
using ThoughtWorks.QRCode.Codec;

namespace TEST
{
    public partial class 打印二维码 : Form
    {
        public 打印二维码()
        {
            InitializeComponent();

            Set();
        }

        public void Set()
        {
            wbv.GetLock();
            wbv.ActiveWorksheet.Shapes.AddPicture("cofco.jpg", 10, 5, 110, 65);
            IRange range = wbv.ActiveWorksheet.Cells;
            range["C2"].Value = "罐位识别卡";
            range["C2"].Font.Size = 24;

            range["A5"].ColumnWidth = 12;
            range["A5"].Value = "罐号:";
            range["A6"].Value = "罐区:";
            range["A7"].Value = "容量:";
            range["A8"].Value = "生产日期:";
            range["A9"].Value = "使用年限:";

            range["B5"].ColumnWidth = 14;
            range["B5"].Value = "F18:";
            range["B6"].Value = "发酵区:";
            range["B7"].Value = "100吨:";
            range["B8"].Value = DateTime.Now.AddDays(-300).ToString("yyyy年MM月dd日");
            range["B9"].Value = "30年:";
            range.Font.Bold = true;
            range.HorizontalAlignment = HAlign.Left;
            MemoryStream ms = new MemoryStream();
            ToQRCode("罐号:F18\r\n罐区:发酵区\r\n容量:100吨").Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] bytes = ms.GetBuffer();
            wbv.ActiveWorksheet.Shapes.AddPicture(bytes, 220, 60, 80, 80);
            wbv.ReleaseLock();
        }

        private Bitmap ToQRCode(string str)
        {
            try
            {
                QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
                qrCodeEncoder.QRCodeVersion = 0;
                qrCodeEncoder.QRCodeScale = 3;
                //生成图像
                return qrCodeEncoder.Encode(str, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                return new Bitmap(1, 1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            wbv.GetLock();
            wbv.Print(true);
            wbv.ReleaseLock();
        }
    }
}
