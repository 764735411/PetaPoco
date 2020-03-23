using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PetaPoco;
using PetaPoco.Providers;
using PetaPocoWebApi.Service;
using PetspPetaPocoWebApi.Model;

namespace PetaPocoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private IRepository _repository = null;
        public StudentsController()
        {
            _repository = new Repository();
        }

        // GET: api/Students
        //查询
        [HttpGet]
        public string GetAll()
        {
           
            List<Student> studentList = _repository.QueryAll<Student>();
            foreach (var student in studentList)
            {
                student.Sex = student.Sex.Trim();
            }
            string StudentJson = JsonConvert.SerializeObject(studentList);
            return StudentJson;
        }

        // GET: api/Students/5
        [HttpGet("item/{id}", Name = "Get")]
        public string GetById(int id)
        {
            Student student = _repository.QueryById<Student>(id);
            if (student.Sex != null)
            {
                student.Sex = student.Sex.Trim();
            }
            string StudentJson = JsonConvert.SerializeObject(student);
            return StudentJson;
        }

        //添加
        // POST: api/Students
        [HttpPost("add")]
        public string Post([FromBody] Student student)
        {
            string message = "传入数据为空或数据错误";
            if (student!=null)
            {
                message = "添加成功";
                _repository.Add(student);
                return message;
            }
            else
            {
                return message;
            }
        }

        //修改
        // PUT: api/Students/5
        [HttpPut("update/{id}")]
        public string Put(int id, [FromBody] Student student)
        {
            string message = "修改失败";
            if (_repository.QueryById<Student>(id) != null)
            {
                _repository.Update<Student>(student);
                message = "修改成功";
            }

            return message;
        }

        //删除
        // DELETE: api/ApiWithActions/5
        [HttpDelete("delete/{id}")]
        public string Delete(int id)
        {
            string message;
            int a = _repository.DeleteById<Student>(id);
            if (a == 1)
            {
                message = "删除成功";
            }
            else
            {
                message = "删除失败";
            }
           return message;
        }
    }
}
