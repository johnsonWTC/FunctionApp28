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
    public static class Function1
    {
        [FunctionName("AddBook")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<Book>(requestBody);
            string responseMessage = "";
            if (data is null)
            {
                responseMessage = "no Book was sent to add, please add avalid book";
                return new OkObjectResult(responseMessage);
            }
            Book book = new Book();
            book.BookAuthor = data.BookAuthor;
            book.BookName = data.BookName;
            BookContext bookContext = new BookContext();
            bookContext.Books.Add(book);
            bookContext.SaveChanges();
            responseMessage = $"Book written by {book.BookAuthor} has been added";

            return new OkObjectResult(responseMessage);
        }
    }
}
