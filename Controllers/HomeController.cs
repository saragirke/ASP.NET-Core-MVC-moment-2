using Microsoft.AspNetCore.Mvc;
using BooksMvc.Models; //Inkluderar models
using Newtonsoft.Json; //Inkluderar paketet Newtonsoft.Json

namespace BooksMvc.Controllers {
    public class HomeController : Controller {

        public IActionResult Index() {
            var JsonStr = System.IO.File.ReadAllText("books.json"); //System.IO för att läsa in fil lokalt
            var JsonObj= JsonConvert.DeserializeObject<List<BookModel>>(JsonStr); //Konverterar till lista av typen BookModel
            return View(JsonObj); //Hämtar böcker till startsidan, tas emot i index.cshtml
       
       
        }
        //anger hur sökvägen för about ska se ut
        [Route("/about")]
        public IActionResult About() {
                var date = DateTime.Now;
                var shortDate = date.ToShortDateString();
                string today = shortDate;

                ViewBag.Message = today;
                return View();
        }
        
        [Route("/books")]
        public IActionResult Books() {
            return View();
        }

        [HttpPost("/books")]
        //Tar emot en instans av modellen BookModel
         public IActionResult Books(BookModel model) {
            if(ModelState.IsValid) {
                //Formuläret är rätt ifyllt
                var JsonStr = System.IO.File.ReadAllText("books.json"); //System.IO för att läsa in fil lokalt
                var JsonObj= JsonConvert.DeserializeObject<List<BookModel>>(JsonStr); //KOnverterar till lista

                if(JsonObj != null) {
                    JsonObj.Add(model); //LÄgger till i listan
                    System.IO.File.WriteAllText("books.json", JsonConvert.SerializeObject(JsonObj, Formatting.Indented)); //Serialiseras från json till text
                    
                    return RedirectToAction("Index", "Home"); //Skickas till Index som finns i controllern Home
                     //ModelState.Clear();  Rensa formuläret när det blivit korrekt ifyllt
                }
            }
            return View();
        }

        
    }
}