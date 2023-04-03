using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class SampleDataAccess
    {
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
    }
}
