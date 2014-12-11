using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TEST
{
    public partial class 百度API : Form
    {
        public 百度API()
        {
            InitializeComponent();
        }

        private void GetAddress(string Lng, string Lat)
        {
            string PageUrl = "http://api.map.baidu.com/geocoder/v2/?ak=7d6576b9d3ce95d2a5bd56ecf0a42186&callback=renderReverse&location=" + Lng + "," + Lat + "&output=json&pois=0"; //需要获取源代码的网页
            WebClient wc = new WebClient(); // 创建WebClient实例提供向URI 标识的资源发送数据和从URI 标识的资源接收数据
            wc.Credentials = CredentialCache.DefaultCredentials; // 获取或设置用于对向 Internet 资源的请求进行身份验证的网络凭据。

            ///方法一：
            Encoding enc = Encoding.GetEncoding("utf-8"); // 如果是乱码就改成 utf-8 / GB2312
            Byte[] pageData = wc.DownloadData(PageUrl); // 从资源下载数据并返回字节数组。
            textBox3.Text = enc.GetString(pageData); // 输出字符串(HTML代码)，ContentHtml为Multiline模式的TextBox控件
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetAddress(textBox1.Text, textBox2.Text);
        }
    }
}
