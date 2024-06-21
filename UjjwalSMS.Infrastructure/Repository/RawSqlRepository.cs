﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UjjwalSMS.Infrastructure.IRepository;
using UjjwalSMS.Infrastructure.Repository.CRUD;

namespace UjjwalSMS.Infrastructure.Repository
{
    public class RawSqlRepository : IRawSqlRepository
    {
        private readonly SMSDbContext _smsDbContext;

        public RawSqlRepository(SMSDbContext smsDbContext)
        {
            _smsDbContext = smsDbContext;
        }

        public IQueryable<TEntity> FromSql<TEntity>(string sql, params object[] parameters) where TEntity : class
        {
            var result = _smsDbContext.Set<TEntity>().FromSqlRaw(sql, parameters);
            return result;
        }
    }
}
