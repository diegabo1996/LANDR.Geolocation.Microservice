using LANDR.Geolocation.Microservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LANDR.Geolocation.Microservice.Executor
{
    public interface IExecutor
    {
        public Task<IPData> Execute(string IP);
    }
}
