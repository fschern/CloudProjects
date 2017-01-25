using MySql.Data.MySqlClient;
using System;
using System.Data.Common;
using WebApplication1.Models;
using System.Collections.Generic;

namespace WebApplication1
{
  public class UserManager : IUserManager
  {
    public void AddUser(User user)
    {
      using (DbConnection connection = GetConnection())
      {
        DbCommand cmd = new MySqlCommand("INSERT INTO User VALUES(@id, @name);");

        cmd.Connection = connection;
        cmd.Parameters.Add(new MySqlParameter("id", user.ID));
        cmd.Parameters.Add(new MySqlParameter("name", user.Name));
        cmd.ExecuteNonQuery();
      }
    }

    public IEnumerable<User> GetAllUsers()
    {
      IList<User> users = new List<User>();

      using (DbConnection connection = GetConnection())
      {
        DbCommand cmd = new MySqlCommand("SELECT * FROM User;");

        cmd.Connection = connection;
        DbDataReader reader = cmd.ExecuteReader();

        while (reader.NextResult())
        {
          users.Add(new User() { ID = reader.GetInt32(0), Name = reader[1].ToString() });
        }
      }

      return users;
    }

    public User GetUser(int id)
    {
      using (DbConnection connection = GetConnection())
      {
        MySqlCommand cmd = new MySqlCommand("SELECT TOP 1 * FROM User WHERE id=@id;");

        cmd.Parameters.Add(new MySqlParameter("id", id));
        DbDataReader reader = cmd.ExecuteReader();

        if (reader.NextResult())
        {
          return new User() { ID = reader.GetInt32(1), Name = reader[1].ToString() };
        }
      }

      return null;
    }

    private void EnsureTableExists(DbConnection connection)
    {
      DbCommand cmd = new MySqlCommand("CREATE TABLE IF NOT EXISTS User (id int, name varchar(255));");

      cmd.Connection = connection;
      cmd.ExecuteNonQuery();
    }

    private DbConnection GetConnection()
    {
      MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();      
      builder.UserID = "userVCB";
      builder.Password = "mMlxj4suB5Wgx1Jk";
      builder.Database = "sampledb";
      builder.SslMode = MySqlSslMode.None;
      builder.PersistSecurityInfo = true;
      builder.Port = uint.Parse(Environment.GetEnvironmentVariable("MARIADB_SERVICE_PORT"));
      builder.Server = Environment.GetEnvironmentVariable("MARIADB_SERVICE_HOST");

      string connectionString = "server=172.30.250.114;user id=userVCB;password=mMlxj4suB5Wgx1Jk;persistsecurityinfo=True;SslMode=None;port=3306;database=sampledb";
      MySqlConnection connection = new MySqlConnection(connectionString);
      connection.Open();
      return connection;
    }
  }
}
