using ListContact.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ListContact.Repository
{
    public class TodoRepository
    {
        private string ConnectionString { get; set; }
        public TodoRepository(IConfiguration configuration) 
        {
            this.ConnectionString = configuration.GetConnectionString("TodoConnection");
        }

        public void Save(Todo todo) 
        {
            using (var connection = new SqlConnection(this.ConnectionString)) 
            {
                var sql = @"INSERT INTO TASK(Id,TaskName,Finished) VALUES (@P1, @P2, @P3)";
                if (connection.State != System.Data.ConnectionState.Open) 
                {
                    connection.Open();
                }
                SqlCommand sqlCommand = connection.CreateCommand();
                sqlCommand.CommandText = sql;
                //sqlCommand.CommandText = "INSERT INTO TASK(Id,TaskName,Finished) VALUES (@P1, @P2, @P3)";
                sqlCommand.Parameters.AddWithValue("P1",todo.Id);
                sqlCommand.Parameters.AddWithValue("P2",todo.Name);
                sqlCommand.Parameters.AddWithValue("P3",todo.Finished);

                sqlCommand.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void Update(Todo todo) 
        {
            using (var connection = new SqlConnection(this.ConnectionString)) 
            {
                var sql = @"UPDATE TASK SET TaskName = @P1, Finished = @P2 WHERE Id = @P3";

                if (connection.State != System.Data.ConnectionState.Open) { connection.Open(); }

                SqlCommand sqlCommand = connection.CreateCommand();
                sqlCommand.CommandText = sql;
                sqlCommand.Parameters.AddWithValue("P1",todo.Name);
                sqlCommand.Parameters.AddWithValue("P2",todo.Finished);
                sqlCommand.Parameters.AddWithValue("P3",todo.Id);
                sqlCommand.ExecuteNonQuery();

                connection.Close();
            }
        }

        public void Delete(Guid id) 
        {
            using (var connection = new SqlConnection(this.ConnectionString)) 
            {
                var sql = @"DELETE FROM TASK WHERE Id = @P1";

                if (connection.State != System.Data.ConnectionState.Open) { connection.Open(); };

                SqlCommand sqlCommand = connection.CreateCommand();
                sqlCommand.CommandText = sql;
                sqlCommand.Parameters.AddWithValue("P1",id);
                sqlCommand.ExecuteNonQuery();

                connection.Close();
            }
        }

        public List<Todo> GetAll() 
        {
            List<Todo> result = new List<Todo>();
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                var sql = @"SELECT ID, TaskName, Finished FROM TASK";
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand sqlCommand = connection.CreateCommand();
                sqlCommand.CommandText = sql;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read()) 
                {
                    Todo todo = new Todo()
                    {
                        Id = Guid.Parse(reader["Id"].ToString()),
                        Name = reader["TaskName"].ToString(),
                        Finished = Convert.ToBoolean(reader["Finished"])
                    };
                    result.Add(todo);
                }
                connection.Close();
                return result;
            }
        }

        public Todo GetById(Guid id) 
        {
            List<Todo> result = new List<Todo>();
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                var sql = @"SELECT Id, TaskName, Finished FROM TASK WHERE Id = @P1";
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand sqlCommand = connection.CreateCommand();
                sqlCommand.CommandText = sql;
                sqlCommand.Parameters.AddWithValue("P1", id);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read()) 
                {
                    Todo todo = new Todo()
                    {
                        Id = Guid.Parse(reader["Id"].ToString()),
                        Name = reader["TaskName"].ToString(),
                        Finished = Convert.ToBoolean(reader["Finished"])
                    };
                    result.Add(todo);
                }
                connection.Close();
            }
            return result.FirstOrDefault();
        }
    }
}
