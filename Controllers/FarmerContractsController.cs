using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PetaPoco;
using PetaPoco.Providers;
using PetaPocoWebApi.Model.FarmerContracts;

namespace PetaPocoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmerContractsController : ControllerBase
    {
        // GET: api/FarmerContracts
        //[HttpGet]
        /*public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }*/

        // GET: api/FarmerContracts/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/FarmerContracts
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/FarmerContracts/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }

        // GET: api/FarmerContracts
        [HttpGet]
        public string Get()
        {
            string connectionString = "Server=127.0.0.1;Database=YC2020343403A;Uid=sa;Pwd=123456";

            //连接数据库
            var db = DatabaseConfiguration.Build()
               .UsingCommandTimeout(60)
               .WithAutoSelect().
               WithNamedParams()
               .UsingConnectionString(connectionString)
               .UsingProvider<SqlServerDatabaseProvider>().Create();
            //sql
            Sql sql = Sql.Builder.Select("*").From("YYSG_JSZ");
            List<FarmerContract> deviceRegister = db.Fetch<FarmerContract>(sql);
            //DeviceRegister deviceRegister = db.SingleOrDefault<DeviceRegister>(sql);
            string deviceRegisterJson = JsonConvert.SerializeObject(deviceRegister);
            return deviceRegisterJson;
        }
    }
}
