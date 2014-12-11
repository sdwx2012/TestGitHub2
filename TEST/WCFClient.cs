using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TEST2
{
    public partial class WCFClient : Form
    {
        public WCFClient()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //IHelloKityService proxy = ChannelFactory<IHelloKityService>.CreateChannel(new NetTcpBinding(), new EndpointAddress("net.tcp://localhost:8000/"));
            //string s = proxy.HelloKity(textBox1.Text);
            //textBox2.Text = s;
            postSend("http://localhost:8000/", "xxx");
        }
        public static string postSend(string url, string param)
        {
            Encoding myEncode = Encoding.GetEncoding("UTF-8");
            byte[] postBytes = Encoding.UTF8.GetBytes(param);

            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
            req.ContentLength = postBytes.Length;

            try
            {
                using (Stream reqStream = req.GetRequestStream())
                {
                    reqStream.Write(postBytes, 0, postBytes.Length);
                }
                using (WebResponse res = req.GetResponse())
                {
                    using (StreamReader sr = new StreamReader(res.GetResponseStream(), myEncode))
                    {
                        string strResult = sr.ReadToEnd();
                        return strResult;
                    }
                }
            }
            catch (WebException ex)
            {
                return "无法连接到服务器\r\n错误信息：" + ex.Message;
            }
        }  
    }

    [ServiceContract(Namespace = "http://localhost")]
    public interface IHelloKityService
    {
        [OperationContract]
        string HelloKity(string message);

        [OperationContract]
        [WebInvoke(UriTemplate = "AddData", Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json)]
        string AddData(Stream stream);
    }
}
