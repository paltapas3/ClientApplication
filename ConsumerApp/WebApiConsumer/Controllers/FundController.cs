using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApiConsumer.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using System.Text;

namespace WebApiConsumer.Controllers
{
    public class FundController : Controller
    {
        // GET: Fund
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FundTransfers()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> FundTransfers(Transaction trans)
        {
            Random generator = new Random();
            string transNumber = "DU" + generator.Next(0, 99999);
            trans.Tid = 1;
            trans.TransactionNumber = transNumber;
            trans.Date = DateTime.Today.ToString("MM/dd/yyyy");

            if (ModelState.IsValid)
            {
                await UpdateTransaction(trans);
                return RedirectToAction("success","Success");
            }
            return View(trans);
           
        }


        async Task UpdateTransaction(Transaction obj)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://fundtransferservice-myservice.193b.starter-ca-central-1.openshiftapps.com/");



                HttpResponseMessage response = await client.PostAsJsonAsync("api/Transactions", obj);

                if (response.IsSuccessStatusCode)
                {
                    Transaction u = await response.Content.ReadAsAsync<Transaction>();
                }
                else
                {
                    //
                }
            }
        }





    }
}