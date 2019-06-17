using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationJtecson.DataLayer.DataAccess
{
    public abstract class AbstractConnectionStr<T> where T : new()
    {
        private Lazy<T> _ConnStr = null;

        public AbstractConnectionStr()
        {
            _ConnStr = new Lazy<T>(() => new T());
        }


        protected T ConnStr
        {
            get
            {
                return _ConnStr.Value;
            }
        }


        public abstract MySqlConnection sqlConnection { get; set; }
    }
}
