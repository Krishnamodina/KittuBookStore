using System;

using Microsoft.AspNetCore.Mvc;


namespace KittuBookStore.Controllers
{
    public class HomeController:Controller
    {
        public ViewResult index()
        {
            return View();
        }
        public ViewResult AboutUs()
        { 
       
          return View();

        }
       public ViewResult Contact()
       {
            return View();
       }

    }
}