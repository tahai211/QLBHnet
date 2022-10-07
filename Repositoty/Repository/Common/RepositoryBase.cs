using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repository;

namespace EV.Repository.Infrastructure
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        internal IDatabaseSql _databaseSql;
        public RepositoryBase(IDatabaseSql databaseSql)
        {
            _databaseSql = databaseSql;
        }

    }
}
