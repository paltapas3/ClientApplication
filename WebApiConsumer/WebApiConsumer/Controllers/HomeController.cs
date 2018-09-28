using WebApiConsumer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Text;

namespace WebApiConsumer.Controllers
{
    public class HomeController : Controller
    {

        public async Task<ActionResult> Index()
        {
            List<User> data = new List<Models.User>();
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri("http://webapicoreservice-webapitest.193b.starter-ca-central-1.openshiftapps.com/");

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/UserAccounts");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var UserResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    data = JsonConvert.DeserializeObject<List<User>>(UserResponse);
                }
            }
            return View(data);
        }

        //public ActionResult Update(string id)
        //{
        //    HttpResponseMessage response = client.GetAsync("/User/GetById" + $"/{id}").Result;
        //    User data = response.Content.ReadAsAsync<User>().Result;
        //    return View(data);
        //}

        //[HttpPost]
        //public ActionResult Update(User obj)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        HttpResponseMessage response = client.
        //            PutAsJsonAsync<User>("/User/Put" +
        //            $"/{obj.UserID}", obj).Result;
        //        TempData["Message"] = "User modified successfully!";
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        return View(obj);
        //    }
        //}

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Insert(User obj)
        {
           // List<User> data = new List<Models.User>();
            User data = new Models.User();
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri("http://webapicoreservice-webapitest.193b.starter-ca-central-1.openshiftapps.com/");

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                //string output = JsonConvert.SerializeObject(obj);
                HttpResponseMessage Res = await client.PostAsJsonAsync<User>("api/UserAccounts", obj);

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var UserResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    data = JsonConvert.DeserializeObject<User>(UserResponse);
                }
            }
            return RedirectToAction("Index");
        }


        //public ActionResult Delete(string id)
        //{
        //    HttpResponseMessage response = client.
        //           DeleteAsync("/User/Delete" + $"/{id}").Result;
        //    TempData["Message"] = "User deleted successfully!";
        //    return RedirectToAction("Index");
        //}
    }

}
