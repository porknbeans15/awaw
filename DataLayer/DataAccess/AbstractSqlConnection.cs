using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationJtecson.DataLayer.DataAccess
{
    public abstract class AbstractSqlConnection : AbstractConnectionStr<ConnectionStr>
    {

        private MySqlConnection _sqlConn = null;
        public AbstractSqlConnection()
        {

        }



        public override MySqlConnection sqlConnection
        {
            get
            {

                if (_sqlConn == null)
                    _sqlConn = new MySqlConnection(ConnStr.DBStr);


                return _sqlConn;
            }

            set
            {
                _sqlConn = value;
            }
        }

        public abstract MySqlCommand sqlCommand(string query);

        public abstract void open();
        public abstract void close();
        public abstract void dispose();
    }
}
