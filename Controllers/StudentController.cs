using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetspPetaPocoWebApi.Model;
using Newtonsoft.Json;
using PetaPoco;
using PetaPoco.Providers;

namespace PetaPocoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        // GET: api/Student

      /*[HttpGet]
       public string StudentDate()
        {
            string connectionString = "Server=127.0.0.1;Database=School;Uid=sa;Pwd=123456";

             var db = DatabaseConfiguration.Build()
                .UsingCommandTimeout(60)
                .WithAutoSelect().
                WithNamedParams()
                .UsingConnectionString(connectionString)
                .UsingProvider<SqlServerDatabaseProvider>().Create();
            
            Student student =  db.SingleOrDefault<Student>(35);
            student.Sex = student.Sex.Trim();
            string StudentJson = JsonConvert.SerializeObject(student);
            return StudentJson;
            
        }*/
    }
}
