using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedisSession.Extensions;
using RedisSession.ViewModel;
using System;

namespace RedisSession.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {           
            UserViewModel model = InsertOnCache();
            return View(model);
        }

        private UserViewModel InsertOnCache()
        {   
            UserViewModel cacheObject = SessionHelper.Get<UserViewModel>(HttpContext.Session, "mysessiondata");
            if (cacheObject == null)
            {
                UserViewModel vm = new UserViewModel
                {
                    Id = 1,
                    Username = "Mary",
                    Role = "Dev",
                    CreatedOn = DateTime.Now
                };
                SessionHelper.Set<UserViewModel>(HttpContext.Session, "mysessiondata", vm);
                cacheObject = SessionHelper.Get<UserViewModel>(HttpContext.Session, "mysessiondata");
            }            

            return cacheObject;
        }

    }
}
