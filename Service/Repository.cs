using Nest;
using PetaPoco;
using PetaPoco.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetaPocoWebApi.Service
{
   
    public class Repository : IRepository
    {
        //连接数据库
        private static string connectionString = "Server=127.0.0.1;Database=UserManege;Uid=sa;Pwd=123456";
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
            
            int result = db.Delete<T>(id);
         
            return result;
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

        public int Update<T>(T t,int id)
        {
           int updateResult = db.Update(t,id);
            return updateResult;
        }

        public Page<T> SelectBypage<T>(int page,int pageSize)
        {
           Page<T> p = db.Page<T>(page, pageSize);
            return p;
        }
    }
}
