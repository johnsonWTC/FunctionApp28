using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FunctionApp28
{
    public static class GetBookName
    {
        [FunctionName("GetBookName")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "{name}")] HttpRequest req, string name)
        {
            string responseMessage = "";
            Book book = new Book();
      
            BookContext bookContext = new BookContext();
            bookContext.Books.Add(book);
            bookContext.SaveChanges();
            responseMessage = $"Book written by {book.BookAuthor} has been added";

            return new OkObjectResult(responseMessage);
        }
    }
}
