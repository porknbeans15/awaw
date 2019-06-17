using DataLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Engine;
using Model;

namespace DataLayer
{
    public class DataEngine
    {

        public List<PersonModel> GetAllPersonRecord()
        {
            return TblPersonEngine.GetAllPerson();
        }

        public PersonModel GetSinglePersonRecord(int id)
        {
            return TblPersonEngine.GetSinglePerson(id);
        }

        public void DeletePersonRecord(int id)
        {
            TblPersonEngine.DeletePerson(id);
        }


        public void InsertPersonRecord(PersonModel data)
        {
            TblPersonEngine.InsertPerson(data);
        }

        public void UpdatePersonRecord(PersonModel data)
        {
            TblPersonEngine.UpdatePerson(data);
        }




        private ITblPerson TblPersonEngine
        {
            get
            {
                return new TblPersonEngine();
            }
        }
    }
}
