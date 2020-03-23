using Nest;
using PetaPoco;
using PetaPoco.Providers;
using PetspPetaPocoWebApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetaPocoWebApi.Service
{
   
    public class Repository : IRepository
    {
        //连接数据库
        private static string connectionString = "Server=127.0.0.1;Database=School;Uid=sa;Pwd=123456";
        IDatabase db = DatabaseConfiguration.Build()
            .UsingCommandTimeout(60)
            .WithAutoSelect()
            .WithNamedParams()
            .UsingConnectionString(connectionString)
            .UsingProvider<SqlServerDatabaseProvider>().Create();

        public void Add<T>(T t)
        {
            db.Insert(t);
        }

        public int DeleteById<T>(int id)
        {
            int a = 0;
            a = db.Delete<T>(id);
            return a;
        }
         
        public List<T> QueryAll<T>()
        {
            List<T> list = db.Fetch<T>();
            return list;
        }

        public T QueryById<T>(int id)
        {
           T t = db.SingleOrDefault<T>(id);
            return t;
        }

        public int Update<T>(T t)
        {
           int a = db.Update(t);
            return a;
        }
    }
}
