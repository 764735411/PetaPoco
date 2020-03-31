using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetaPocoWebApi
{
    public class Page
    {
        private const int _maxPageSize = 20;
        public int PageNumber { get; set; } = 1;

        private int _pageSize = 10;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > _maxPageSize) ? _maxPageSize : value;
        }


    }
}
