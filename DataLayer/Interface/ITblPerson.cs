using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationJtecson.DataLayer.DataAccess;

namespace DataLayer.Interface
{
    public interface ITblPerson
    {

        List<PersonModel> GetAllPerson();
        void InsertPerson(PersonModel data);
        PersonModel GetSinglePerson(int id);
        void UpdatePerson(PersonModel data);
        void DeletePerson(int id);
    }
}
