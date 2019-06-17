using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationJtecson.DataLayer.DataAccess
{
    public class ConnectionStr
    {

        private string db = "";
        public ConnectionStr()
        {
            db = "Server=localhost;Database=jtecsondb;Uid=root;Pwd=password1;default command timeout=28800;CharSet=utf8;";
        }


        public string DBStr
        {
            get
            {
                return db;
            }

        }

    }
}
