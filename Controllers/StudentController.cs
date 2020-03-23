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
        private StudentController studentController;
        // GET: api/Student
        //查询
        //[HttpGet]
        public string Get()
        {
            List<Student> studentList = new List<Student>();
            studentController = new StudentController();

            //查询学生数据
            string StudentJson = studentController.GetStudent();

            Student student = new Student();
            student.Name = "王小明";
            student.Sex = "男";
            student.Age = 32;

            studentList.Add(student);
            string studentStr = JsonConvert.SerializeObject(studentList);
            //增加
            //studentController.Post(studentStr);
            //删除
            //studentController.Delete(87);
            //修改
            //studentController.Put(64, studentStr);
            return StudentJson;
        }
        //插入
        [HttpPost]
        public void Post([FromBody] string value)
        {
            if (value != null)
            {
                string connectionString = "Server=127.0.0.1;Database=School;Uid=sa;Pwd=123456";

                var db = DatabaseConfiguration.Build()
                   .UsingCommandTimeout(60)
                   .WithAutoSelect()
                   .WithNamedParams()
                   .UsingConnectionString(connectionString)
                   .UsingProvider<SqlServerDatabaseProvider>().Create();

                List<Student> stuList = JsonConvert.DeserializeObject<List<Student>>(value);
                //Student student = JsonConvert.DeserializeObject<Student>(value);

                foreach (var student in stuList)
                {
                    db.Insert(student);
                }

            }
            
        }
        //修改
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            string connectionString = "Server=127.0.0.1;Database=School;Uid=sa;Pwd=123456";
            var db = DatabaseConfiguration.Build()
                .UsingCommandTimeout(60)
                .WithAutoSelect()
                .WithNamedParams()
                .UsingConnectionString(connectionString)
                .UsingProvider<SqlServerDatabaseProvider>().Create();

                List<Student> stuList = JsonConvert.DeserializeObject<List<Student>>(value);
                foreach (var student in stuList)
                {
                    if (db.SingleOrDefault<Student>(id) != null)
                    {
                        db.Update(student,id);
                    
                    }
                    
                }
          

        }

        //删除
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            string connectionString = "Server=127.0.0.1;Database=School;Uid=sa;Pwd=123456";
            var db = DatabaseConfiguration.Build()
                .UsingCommandTimeout(60)
                .WithAutoSelect()
                .WithNamedParams()
                .UsingConnectionString(connectionString)
                .UsingProvider<SqlServerDatabaseProvider>().Create();

            if (db.SingleOrDefault<Student>(id) != null)
            {
                db.Delete<Student>(id);
            }

        }

        [HttpGet]
        //查询
        public string GetStudent()
        {
            string connectionString = "Server=127.0.0.1;Database=School;Uid=sa;Pwd=123456";

            var db = DatabaseConfiguration.Build()
                .UsingCommandTimeout(60)
                .WithAutoSelect()
                .WithNamedParams()
                .UsingConnectionString(connectionString)
                .UsingProvider<SqlServerDatabaseProvider>().Create();

            //Student student = db.SingleOrDefault<Student>(35);
            Sql sql = Sql.Builder.Select("*").From("Student");
            List<Student> studentList = db.Fetch<Student>(sql);
            foreach (var student in studentList)
            {
                student.Sex = student.Sex.Trim();
            }
            string StudentJson = JsonConvert.SerializeObject(studentList);
            return StudentJson;
        }


    }
}
