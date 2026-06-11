using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IV.MyClient.ClientServices
{
    public class StkTypeMain
    {
        public async Task Runasync()
        {
            var gitHubApi = RestService.For<StkTypeApi>("https://localhost:7157");
            var octocat = await gitHubApi.GetStockTypes();

            foreach (var stk in octocat)
            {
                Console.WriteLine(stk.StkTypeName + "-" + stk.StkTypeDesc + "-" + stk.StkTypeId);
            }

            try
            {
                var data = await gitHubApi.GetById(12);
                foreach (var stk in data)
                {
                    Console.WriteLine(stk.StkTypeName + "-" + stk.StkTypeDesc + "-" + stk.StkTypeId);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }     
    }
}
