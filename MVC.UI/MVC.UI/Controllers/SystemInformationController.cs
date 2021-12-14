using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using MVC.UI.Models;

using System.Net.Http.Headers;



using System.Net.Http;
using System.Web.Configuration;

namespace MVC.UI.Controllers
{
   


    public class SystemInformationController : Controller
    {
        // GET: SystemInformation         // GET: Home

        public HttpClient WebCilent = new HttpClient();
       

        public ActionResult Index()
        {
            IEnumerable<SystemInformation> emptList;
            string apiUrl = WebConfigurationManager.AppSettings["ApiUrl"];



            WebCilent.BaseAddress = new Uri(apiUrl);

            WebCilent.DefaultRequestHeaders.Clear();



            WebCilent.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = WebCilent.GetAsync("SystemInformation").Result;
           emptList = response.Content.ReadAsAsync<IEnumerable<SystemInformation>>().Result;
           
            return View(emptList);
        }
    }
}