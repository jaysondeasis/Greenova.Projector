using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Greenova.Projector.Model;
using Greenova.Projector.Model.IRepositories;
using Greenova.Projector.Service;
using Greenova.Projector.Service.Messaging;
using Greenova.Projector.Infrastructure.Factory;

namespace Greenova.Projector.WebApplication.Controllers
{
    public class PersonsController : Controller
    {

        ProjectorService _projectorService;

        public PersonsController()
        {
            _projectorService = ServiceFactory.CreateProjectService();
        }
        public ActionResult Create()
        {
            Person person = new Person();
            return View(person);
        }

        [HttpPost]
        public ActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                CreatePersonRequest request = new CreatePersonRequest();
                request.Person = person;
                CreatePersonResponse response = _projectorService.CreatePerson(request);
                if (response.Success)
                {
                    return RedirectToAction("Index", "Projects");
                }
            }

            return View(person);
        }
    }
}
