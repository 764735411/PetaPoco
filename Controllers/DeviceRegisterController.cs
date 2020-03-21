using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PetaPoco;
using PetaPoco.Providers;
using PetaPocoWebApi.Model;

namespace PetaPocoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceRegisterController : ControllerBase
    {
        // GET: api/DeviceRegister
        //[HttpGet]


        [HttpGet]
        public string GetDeviceRegist()
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
            Sql sql = Sql.Builder.Select("*").From("YYSG_SBS");
            List<DeviceRegister> deviceRegister = db.Fetch<DeviceRegister>(sql);
            //DeviceRegister deviceRegister = db.SingleOrDefault<DeviceRegister>(sql);
            string deviceRegisterJson = JsonConvert.SerializeObject(deviceRegister);
            return deviceRegisterJson;
        }

    }
}
