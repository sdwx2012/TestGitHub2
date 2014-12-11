using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace TEST
{
    public class NoSqlItem
    {
        public ObjectId _id;
        private long _index;
        private string _nkey;
        private string _nvalue;
        private DateTime _ndate;

        public NoSqlItem(int nkey, int nvalue)
        {
            _index = (new Random()).Next(1, int.MaxValue);
            _nkey = nkey.ToString();
            _nvalue = nvalue.ToString();
            _ndate = DateTime.Now;
        }
        public NoSqlItem(int index, int nkey, int nvalue)
        {
            _index = index;
            _nkey = nkey.ToString();
            _nvalue = nvalue.ToString();
            _ndate = DateTime.Now;
        }
        public long Index
        {
            get { return _index; }
            set { _index = value; }
        }
        public string Nkey
        {
            get { return _nkey; }
            set { _nkey = value; }
        }

        public string Nvalue
        {
            get { return _nvalue; }
            set { _nvalue = value; }
        }

        public DateTime Ndate
        {
            get { return _ndate; }
            set { _ndate = value; }
        }

    }
}
