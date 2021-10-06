using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Linq;

namespace FunctionApp28
{
    public static class GetBookName
    {
        [FunctionName("GetBookNameByID")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "{id}")] HttpRequest req, int id)
        {
            string responseMessage = "";
            BookContext bookContext = new BookContext();
            var bookname = bookContext.Books.Where(b => b.BookID == id).FirstOrDefault()?.BookName;
            if(bookname != null)
            {
            responseMessage = $"The book name for that ID is {bookname}";
            return new OkObjectResult(responseMessage);
            }
            responseMessage = $"Could not if a book with ID {id}";
            return new OkObjectResult(responseMessage);
        }
    }
}
