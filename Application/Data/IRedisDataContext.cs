using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace Application.Data
{
    public interface IRedisDataContext
    {
        IDatabase Redis { get; }
    }
}
