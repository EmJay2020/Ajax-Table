using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AjaxTable.Models
{
    public class People
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }
    }
    public class Db
    {
        private string _connection;
        public Db(string cs)
        {
            _connection = cs;
        }

        public List<People> GetPeople()
        {
            using (var connection = new SqlConnection(_connection))
            using(var cmd = connection.CreateCommand())
            {
                cmd.CommandText = "select * from Persons";
                connection.Open();
                var result = new List<People>();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new People
                    {
                        Id = (int)reader["Id"],
                        Firstname = (string)reader["firstname"],
                        Lastname = (string)reader["lastname"],
                        Age = (int)reader["age"]
                    }
                     );
                }
                return result;
            }

        }
        public void Add(People p)
        {
            using (var connection = new SqlConnection(_connection))
            using (var cmd = connection.CreateCommand())
            {
                cmd.CommandText = @"insert into Persons(Firstname, Lastname, Age)
                                    values(@firstname, @lastname, @age)";
                cmd.Parameters.AddWithValue("@firstname", p.Firstname);
                cmd.Parameters.AddWithValue("@lastname", p.Lastname);
                cmd.Parameters.AddWithValue("@age", p.Age);
                connection.Open();
                cmd.ExecuteNonQuery();

            }
        }
        public void Edit(People p)
        {
            using (var connection = new SqlConnection(_connection))
            using (var cmd = connection.CreateCommand())
            {
                cmd.CommandText = @"update persons 
                                    set Firstname=@firstname, lastname=@lastname, age=@age
where Id=@Id";
                cmd.Parameters.AddWithValue("@Id", p.Id);
                cmd.Parameters.AddWithValue("@firstname", p.Firstname);
                cmd.Parameters.AddWithValue("@lastname", p.Lastname);
                cmd.Parameters.AddWithValue("@age", p.Age);
                connection.Open();
                cmd.ExecuteNonQuery();

            }
        }
        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connection))
            using (var cmd = connection.CreateCommand())
            {
                cmd.CommandText = @"delete from persons where Id=@Id";
                cmd.Parameters.AddWithValue("Id", @id);
                connection.Open();
                cmd.ExecuteNonQuery();

            }
        }



    }

}
