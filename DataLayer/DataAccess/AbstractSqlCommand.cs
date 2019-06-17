using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WebApplicationJtecson.DataLayer.DataAccess
{
    public abstract class AbstractSqlCommand : AbstractSqlConnection
    {


        public override MySqlCommand sqlCommand(string query)
        {
            return new MySqlCommand(query, sqlConnection);

        }

     

        public override void open()
        {
            sqlConnection.Open();
        }

        public override void close()
        {
            sqlConnection.Close();

        }

        public override void dispose()
        {
            sqlConnection.Dispose();
        }


    }
}
