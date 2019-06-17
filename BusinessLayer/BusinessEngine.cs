using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
namespace BusinessLayer
{
    public class BusinessEngine
    {
        public List<PersonModel> GetAllPersonRecord()
        {
            DataEngine dbEngine = new DataEngine();
            return dbEngine.GetAllPersonRecord();
        }

        public PersonModel GetSinglePersonRecord(int Id)
        {
            DataEngine dbEngine = new DataEngine();
            return dbEngine.GetSinglePersonRecord(Id);
        }

        public void InsertPersonRecord(PersonModel model)
        {

            string[] d = model.BirthdateStr.Split('-');
            model.Birthdate = new DateTime(int.Parse(d[2]), int.Parse(d[0]), int.Parse(d[1]));

            DataEngine dbEngine = new DataEngine();
            dbEngine.InsertPersonRecord(model);
        }

        public void UpdatePersonRecord(PersonModel model)
        {

            string[] d = model.BirthdateStr.Split('-');
            model.Birthdate = new DateTime(int.Parse(d[2]), int.Parse(d[0]), int.Parse(d[1]));

            DataEngine dbEngine = new DataEngine();
            dbEngine.UpdatePersonRecord(model);
        }

        public void DeletePersonRecord(int Id)
        {

            DataEngine dbEngine = new DataEngine();
            dbEngine.DeletePersonRecord(Id);
        }
    }
}
