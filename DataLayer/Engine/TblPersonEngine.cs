using DataLayer.Interface;
using Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationJtecson.DataLayer.DataAccess;

namespace DataLayer.Engine
{
    public class TblPersonEngine : AbstractSqlCommand, ITblPerson
    {

        public List<PersonModel> GetAllPerson()
        {
            string query = "select id,lastname,firstname,middlename,birthdate,gender from person";
            MySqlCommand command = sqlCommand(query);
            PersonModel model = null;
            List<PersonModel> lst = new List<PersonModel>();
            open();
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                model = new PersonModel();
                model.Id = int.Parse(reader["id"].ToString());
                model.Lastname = reader["lastname"].ToString();
                model.Firstname = reader["firstname"].ToString();
                model.Middlename = reader["middlename"].ToString();
                model.Birthdate = (DateTime)reader["birthdate"];
                model.BirthdateStr = DateTime.Parse(reader["birthdate"].ToString()).ToString("MMMM dd, yyyy");
                model.Gender = reader["gender"].ToString();
                lst.Add(model);
            }
            dispose();
            close();

            return lst;
        }

        public PersonModel GetSinglePerson(int id)
        {
            string query = "select lastname,firstname,middlename,birthdate,gender from person where id='" + id + "'";
            MySqlCommand command = sqlCommand(query);
            PersonModel model = null;
            open();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                model = new PersonModel();
                model.Id = id;
                model.Lastname = reader["lastname"].ToString();
                model.Firstname = reader["firstname"].ToString();
                model.Middlename = reader["middlename"].ToString();
                model.Birthdate = (DateTime)reader["birthdate"];
                model.BirthdateStr = DateTime.Parse(reader["birthdate"].ToString()).ToString("MM-dd-yyyy");
                model.Gender = reader["gender"].ToString();

            }
            dispose();
            close();

            return model;
        }

        public void InsertPerson(PersonModel data)
        {
            string query = "insert into person (lastname,firstname,middlename,gender,birthdate) values (?lastname,?firstname,?middlename,?gender,?birthdate)";
            MySqlCommand command = sqlCommand(query);
            open();
            command.Parameters.AddWithValue("?lastname", data.Lastname);
            command.Parameters.AddWithValue("?firstname", data.Firstname);
            command.Parameters.AddWithValue("?middlename", data.Middlename);
            command.Parameters.AddWithValue("?gender", data.Gender);
            command.Parameters.AddWithValue("?birthdate", data.Birthdate);
            command.ExecuteNonQuery();
            dispose();
            close();
        }

        public void UpdatePerson(PersonModel data)
        {
            string query = "update person set lastname=?lastname,firstname=?firstname,middlename=?middlename,gender=?gender,birthdate=?birthdate where id=" + data.Id + "";
            MySqlCommand command = sqlCommand(query);
            open();
            command.Parameters.AddWithValue("?lastname", data.Lastname);
            command.Parameters.AddWithValue("?firstname", data.Firstname);
            command.Parameters.AddWithValue("?middlename", data.Middlename);
            command.Parameters.AddWithValue("?gender", data.Gender);
            command.Parameters.AddWithValue("?birthdate", data.Birthdate);
            command.ExecuteNonQuery();
            dispose();
            close();
        }


        public void DeletePerson(int id)
        {
            string query = "delete from person where id=?id";
            MySqlCommand command = sqlCommand(query);
            open();
            command.Parameters.AddWithValue("?id", id);
            command.ExecuteNonQuery();
            dispose();
            close();
        }
    }
}
