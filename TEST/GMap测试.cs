using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace TEST
{
    public partial class GMap测试 : Form
    {
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(0);
        }
        public GMap测试()
        {
            InitializeComponent();
            try
            {
                System.Net.IPHostEntry e = System.Net.Dns.GetHostEntry("map.baidu.com");
            }
            catch
            {
                MainMap.Manager.Mode = AccessMode.CacheOnly;
                MessageBox.Show("No internet connection avaible, going to CacheOnly mode.", "GMap.NET Demo");
            }
            MainMap.MapProvider = new BaiduMapProvider(); //google china 地图
            MainMap.MinZoom = 2;  //最小缩放
            MainMap.MaxZoom = 17; //最大缩放
            MainMap.Zoom = 6;     //当前缩放
            MainMap.Position = new PointLatLng(20, 60); //地图中心位置：南京
            MainMap.OnMarkerClick += myMarkerClick;
            button3_Click(null, null);
        }

        private void myMarkerClick(GMapMarker gMapMarker, MouseEventArgs e)
        {
            MessageBox.Show(gMapMarker.ToolTipText);
        }
        GMapOverlay objects;
        private void button3_Click(object sender, EventArgs e)
        {
            objects = new GMapOverlay(MainMap, "W");
            GMapMarker marker = new GMapMarkerGoogleRed(new PointLatLng(20, 60))
            {
                ToolTipText = "这个点至少一万",
                ToolTipMode = MarkerTooltipMode.Always
            };
            this.objects.Markers.Add(marker);

            marker = new GMapMarkerGoogleRed(new PointLatLng(20, 67))
            {
                ToolTipText = "这个点至少二万",
                ToolTipMode = MarkerTooltipMode.Always
            };
            this.objects.Markers.Add(marker);

            MainMap.Overlays.Add(objects);
        }
    }
}