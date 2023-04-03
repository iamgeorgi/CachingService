using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class SampleDataAccess
    {
        private readonly IMemoryCache _memoryCache;

        public SampleDataAccess(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        public List<EmployeeModel> GetEmployees() { 
            List<EmployeeModel> output = new List<EmployeeModel>();

            output.Add(new EmployeeModel() { FirstName = "Tim", LastName = "Corey"});
            output.Add(new EmployeeModel() { FirstName = "Sue", LastName = "Storm"});
            output.Add(new EmployeeModel() { FirstName = "Jane", LastName = "Jones"});

            // delay the output returning for 3 sec
            Thread.Sleep(3000);
            return output;
        }
        public async Task<List<EmployeeModel>> GetEmployeesAsync()
        {
            List<EmployeeModel> output = new List<EmployeeModel>();

            output.Add(new EmployeeModel() { FirstName = "Tim", LastName = "Corey" });
            output.Add(new EmployeeModel() { FirstName = "Sue", LastName = "Storm" });
            output.Add(new EmployeeModel() { FirstName = "Jane", LastName = "Jones" });

            // turn it into async call which is waiting
            await Task.Delay(3000);
            return output;
        }

        public async Task<List<EmployeeModel>> GetEmployeesCache()
        {
            List<EmployeeModel> output;

            output = _memoryCache.Get<List<EmployeeModel>>("employees");

            if (output == null)
            {
                output = new List<EmployeeModel>();
                output.Add(new EmployeeModel() { FirstName = "Tim", LastName = "Corey" });
                output.Add(new EmployeeModel() { FirstName = "Sue", LastName = "Storm" });
                output.Add(new EmployeeModel() { FirstName = "Jane", LastName = "Jones" });

                await Task.Delay(3000);

                // it will be stored in memory for 1 minute
                _memoryCache.Set("employees", output, TimeSpan.FromMinutes(1));
            }

            return output;
        }
    }
}
