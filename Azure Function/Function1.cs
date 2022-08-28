using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Web.Http;
using Azure_Function.Model;
using System.Linq;
using System.Net.Http;
using Microsoft.EntityFrameworkCore;

namespace Azure_Function
{
    public class Function1
    {

        private readonly BookDatabaseContext _dbContext;

        public Function1(BookDatabaseContext bookDatabaseContext)
        {
            _dbContext = bookDatabaseContext ?? throw new ArgumentNullException(nameof(bookDatabaseContext));
        }

        [FunctionName("Function1")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {

            try
            {
                log.LogInformation("C# HTTP trigger function processed a request.");

                string responseMessage = "";

                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                dynamic data = JsonConvert.DeserializeObject(requestBody);


                //name = name ?? data?.name;
                if (requestBody != null)
                {
                    var payment = new Payment();
                    payment.BuyerName = data.BuyerName;
                    payment.PaymentDate = DateTime.Now;
                    payment.BuyerEmail = data.BuyerEmail;
                    payment.BookId = data.BookId;
                    _dbContext.Payments.Add(payment);
                    _dbContext.SaveChanges();

                    responseMessage = "Inserted Payment successfully";
                    return new OkObjectResult(responseMessage);
                }
                responseMessage = "Some Issue occurred";

                return new OkObjectResult(responseMessage);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
