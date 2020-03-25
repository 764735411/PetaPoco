using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetaPocoWebApi.Model;
using PetaPocoWebApi.Service;

namespace PetaPocoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IRepository _repository = null;
        public UserController()
        {
            _repository = new Repository();
        }

        // GET: api/User
        //查询
        [HttpGet]
        public IActionResult GetAll()
        {

            List<User> userList = _repository.QueryAll<User>();
            //string StudentJson = JsonConvert.SerializeObject(studentList);
            return new JsonResult(userList);
        }

        // GET: api/Students/5
        [HttpGet("item/{id}", Name = "Get")]
        public IActionResult GetById(int id)
        {
            User user = _repository.QueryById<User>(id);
            //string user = JsonConvert.SerializeObject(student);
            return new JsonResult(user);
        }

        //添加
        // POST: api/Students
        [HttpPost("add")]
        public IActionResult Post([FromBody] User user)
        {
            string message = "传入数据为空或数据错误";
            if (user != null)
            {
                _repository.Add(user);
                message = "添加成功";
            }
            return Content(message);

        }

        //修改
        // PUT: api/Students/5
        [HttpPut("update/{id}")]
        public IActionResult Put(int id, [FromBody] User user)
        {
            string message = "修改失败";
            if (_repository.QueryById<User>(id) != null)
            {
                _repository.Update<User>(user);
                message = "修改成功";
            }

            return Content(message);
        }

        //删除
        // DELETE: api/ApiWithActions/5
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            string message = "删除失败";
            int a = _repository.DeleteById<User>(id);
            if (a == 1)
            {
                message = "删除成功";
            }
            return Content(message);
        }
    }
}
