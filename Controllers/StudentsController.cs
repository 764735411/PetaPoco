using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        public IActionResult GetAll()
        {
           
            List<Student> studentList = _repository.QueryAll<Student>();
           //string StudentJson = JsonConvert.SerializeObject(studentList);
            return new JsonResult(studentList);
        }

        // GET: api/Students/5
        [HttpGet("item/{id}", Name = "Get")]
        public IActionResult GetById(int id)
        {
            Student student = _repository.QueryById<Student>(id);
            //string StudentJson = JsonConvert.SerializeObject(student);
            return new JsonResult(student);
        }

        //添加
        // POST: api/Students
        [HttpPost("add")]
        public IActionResult Post([FromBody] Student student)
        {
            string message = "传入数据为空或数据错误";
            if (student!=null)
            {
                _repository.Add(student);
                message = "添加成功";
            }
                return Content(message);
   
        }

        //修改
        // PUT: api/Students/5
        [HttpPut("update/{id}")]
        public IActionResult Put(int id, [FromBody] Student student)
        {
            string message = "修改失败";
            if (_repository.QueryById<Student>(id) != null)
            {
                _repository.Update<Student>(student);
                message = "修改成功";
            }

            return Content(message);
        }

        //删除
        // DELETE: api/ApiWithActions/5
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
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
           return Content(message);
        }
    }
}
