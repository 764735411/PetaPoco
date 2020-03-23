using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetaPocoWebApi.Service
{
    public interface IRepository
    {
        //查询全部
        List<T> QueryAll<T>();
        //根据id查询
        public T QueryById<T>(int id);

        //根据id 删除
        public int DeleteById<T>(int id);

        //增加
        public void Add<T>(T t);

        //修改
        public int Update<T>(T t);



    }
}
