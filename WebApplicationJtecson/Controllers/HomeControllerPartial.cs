using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using Model;
namespace WebApplicationJtecson.Controllers
{
    public partial class HomeController : Controller
    {
        [HttpPost]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "none")]
        public JsonResult GetAllUser()
        {
            BusinessEngine EngineDB = new BusinessEngine();
            var lst = EngineDB.GetAllPersonRecord();

            return Json(lst, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "none")]
        public JsonResult GetUser(int UserID)
        {
            BusinessEngine EngineDB = new BusinessEngine();
            PersonModel model = EngineDB.GetSinglePersonRecord(UserID);

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "none")]
        public JsonResult DeleteUser(int UserID)
        {
            BusinessEngine EngineDB = new BusinessEngine();
            EngineDB.DeletePersonRecord(UserID);

            return Json("", JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "none")]
        public JsonResult SaveForm(PersonModel model)
        {
            BusinessEngine EngineDB = new BusinessEngine();
            EngineDB.InsertPersonRecord(model);

            return Json("", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "none")]
        public JsonResult UpdateForm(PersonModel model)
        {
            BusinessEngine EngineDB = new BusinessEngine();
            EngineDB.UpdatePersonRecord(model);
            return Json("", JsonRequestBehavior.AllowGet);
        }

    }
}