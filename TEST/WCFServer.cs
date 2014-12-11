using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace TEST
{
    public partial class WCFServer : Form
    {
        public WCFServer()
        {
            InitializeComponent();

            host.AddServiceEndpoint(typeof(IHelloKityService), new NetTcpBinding(), "net.tcp://localhost:8000/");
        }

        private ServiceHost host = new ServiceHost(typeof(HelloKityService));
        private void button1_Click(object sender, EventArgs e)
        {
            host.Open();
            panel1.BackColor = Color.Green;
        }
    }

    //ServiceContract——服务契约，可以用以接口和类，用以接口需要自定义类实现，Namespace是这个服务的域名空间。  
    [ServiceContract(Namespace = "http://localhost")]
    public interface IHelloKityService
    {
        [OperationContract]
        string HelloKity(string message);

        [OperationContract]
        [WebInvoke(UriTemplate = "AddData", Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json)]
        string AddData(Stream stream);
    }

    public class HelloKityService : IHelloKityService
    {
        #region IHelloKityService Members
        public string HelloKity(string message)
        {
            return string.Format("Receivied message at{0}:{1}", DateTime.Now, message);
        }

        public string AddData(Stream stream)
        {
            StreamReader sr = new StreamReader(stream);
            string s = sr.ReadToEnd();
            sr.Dispose();
            NameValueCollection nvc = HttpUtility.ParseQueryString(s);

            string appKey = nvc["appKey"];
            string sign = nvc["sign"];
            string name = nvc["username"];

            return new JavaScriptSerializer().Serialize("AAAAA");
        }  
        #endregion
    }
}
