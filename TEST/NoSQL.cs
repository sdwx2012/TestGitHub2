using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace TEST
{
    public partial class NoSQL : Form
    {
        public NoSQL()
        {
            InitializeComponent();

            string connectionString = "mongodb://10.0.3.3";
            MongoServer server = MongoServer.Create(connectionString);
            //连接到 mongodb_c_demo 数据库
            MongoDatabase db = server.GetDatabase("MyData");
            //获取集合 fruit
            collection = db.GetCollection<NoSqlItem>("myTest");
        }

        private MongoCollection<NoSqlItem> collection;
        private void button2_Click(object sender, EventArgs e)
        {
            List<NoSqlItem> ls = collection.FindAll().Where(i => i.Index < 10000).ToList();
            dataGridView1.DataSource = ls;
            MessageBox.Show("left 10000 count.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (collection.FindAll().Count() > 100000000)
            {
                MessageBox.Show("count greater than 100000000");
                return;
            }
            List<NoSqlItem> ls = new List<NoSqlItem>();
            for (int i = 0; i < 500000000; i++)
            {
                ls.Add(new NoSqlItem(i, i * i % 1000 + (new Random()).Next(int.MinValue, 0), (new Random()).Next(0, int.MaxValue) - i * i % 1000));
                if (i % 10000 == 0)
                {
                    collection.InsertBatch(ls);
                    ls = new List<NoSqlItem>();
                    textBox1.Text = i.ToString();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "mongodb://localhost";
            MongoServer server = MongoServer.Create(connectionString);
            //连接到 mongodb_c_demo 数据库
            MongoDatabase db = server.GetDatabase("MyData");
            //获取集合 fruit
            MongoCollection collection2 = db.GetCollection("BB");

            var batch = new BsonDocument[] { 
                new BsonDocument("x",1),
                new BsonDocument("x",2),
                new BsonDocument("x",3)
            };

            collection2.InsertBatch(batch);

            Console.WriteLine("count:{0}", collection2.Count());
            collection2.FindAllAs<BsonDocument>();
            var result = collection2.FindOneAs<BsonDocument>(Query.EQ("x", 2));
            Console.WriteLine("the value of x field in result:{0}", result["x"].AsInt32);
            collection2.RemoveAll();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            collection.Insert(new NoSqlItem(3, 132));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            collection.RemoveAll();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = collection.FindAll().Count().ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Text = "1";
            }
            dataGridView1.DataSource = new List<NoSqlItem> { collection.FindOneAs<NoSqlItem>(Query.EQ("Index", int.Parse(textBox1.Text))) };
        }

        private void button8_Click(object sender, EventArgs e)
        {
            collection.CreateIndex("Index");
        }
    }
}
