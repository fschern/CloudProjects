using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Collections;

namespace WebApplication1.Controllers
{
  [Route("api/[controller]")]
  public class ValuesController : Controller
  {
    // GET api/values
    [HttpGet]
    public IEnumerable<string> Get()
    {
      return new string[] { "value1", "value2" };
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
      string result = string.Empty;

      foreach (DictionaryEntry de in Environment.GetEnvironmentVariables())
        result += string.Format("  {0} = {1}", de.Key, de.Value) + "\n";


      //string result = (-1000).ToString();
      //string connectionString = "server=172.30.250.114;user id=userVCB;password=mMlxj4suB5Wgx1Jk;persistsecurityinfo=True;SslMode=None;port=3306;database=sampledb";

      //try
      //{
      //  using (MySqlConnection connection = new MySqlConnection(connectionString))
      //  {
      //    connection.Open();
      //    MySqlCommand cmd = new MySqlCommand("CREATE TABLE User (id int, name varchar(255));");

      //    cmd.Connection = connection;
      //    result = cmd.ExecuteNonQuery().ToString();
      //  }
      //}
      //catch (Exception ex)
      //{
      //  return ex.Message;
      //}

      return result;
    }

    // POST api/values
    [HttpPost]
    public void Post([FromBody]string value)
    {
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
