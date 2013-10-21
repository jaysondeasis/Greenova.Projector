using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Greenova.Projector.Service;
using Greenova.Projector.Service.Messaging;
using Greenova.Projector.Model;
using Greenova.Projector.Infrastructure.Factory;

namespace Greenova.Projector.WebApplication.Controllers
{
    public class ProjectsController : Controller
    {
        private ProjectorService _projectService;

        public ProjectsController()
        {
            _projectService = ServiceFactory.CreateProjectService();
        }               
        
        //
        // GET: /Projects/

        public ActionResult Index()
        {
            GetProjectRequest request = new GetProjectRequest();
            request.All = true;
            GetProjectResponse respose = _projectService.GetProject(request);

            if (respose.Success)
            {                
                return View(respose.ProjectAssignments);
            }

            return View("Error");
            
        }

        public ActionResult Create()
        {
            Project project = new Project();
            return View(project);
        }

        [HttpPost]
        public ActionResult Create(Project project)
        {
            if (ModelState.IsValid)
            {
                CreateProjectRequest request = new CreateProjectRequest();
                request.Project = project;

                CreateProjectResponse response = _projectService.CreateProject(request);
                if (response.Success)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(project);
        }

        public ActionResult Assignments(int projectId)
        {
            GetProjectRequest request = new GetProjectRequest();            
            request.Id = projectId;
            GetProjectResponse response = _projectService.GetProject(request);
            
            return View(response.AssignProject);
        }

        public PartialViewResult Assign(int projectId, int personId)
        {
            return PartialView();
        }

    }
}
