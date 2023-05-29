using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Infraestructure;
using Infraestructure.Models;
using Infraestructure.Utils;
using TaskWeb.Services;
namespace TaskWeb.Controllers
{
    public class TaskController : Controller
    {
        // GET: Task
        public ActionResult Index()
        {
            IEnumerable<TaskDB> lista = null;
            try
            {
                IServiceTaskD _ServiceAutor = new ServiceTaskD();
                lista = _ServiceAutor.GetTasks();
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos!" + ex.Message;
                return RedirectToAction("Default", "Error");
            }
            return View(lista);
        }
        public ActionResult 
    }
}