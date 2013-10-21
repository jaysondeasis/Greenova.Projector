using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Greenova.Projector.Model.IRepositories;
using Greenova.Projector.Model.Services;
using Greenova.Projector.Service.Messaging;
using Greenova.Projector.Service.ViewModels;
using Greenova.Projector.Model;

namespace Greenova.Projector.Service
{
    public class ProjectorService
    {
        private IProjectRepository _projectRepository;
        private IPersonRepository _personRepository;
        
        public ProjectorService(IProjectRepository projectRepository,
            IPersonRepository personRepository)
        {
            _projectRepository = projectRepository;
            _personRepository = personRepository;
        }

        public GetProjectResponse GetProject(GetProjectRequest request)
        {
            GetProjectResponse response = new GetProjectResponse();

            try
            {                
                ProjectService service = new ProjectService(_projectRepository);

                if (request.All)
                {
                    ProjectAssignmentsViewModel viewModel = new ProjectAssignmentsViewModel();
                    viewModel.Projects = service.GetAllProjects().AsEnumerable();                    
                    response.ProjectAssignments = viewModel;                 
                }

                if (request.Id != 0)
                {
                    AssignProjectInputModel assignProject = new AssignProjectInputModel();                    
                    assignProject.Project = service.GetProject(request.Id);
                    assignProject.PersonsToAssign = GetPersonsToAssign(assignProject.Project);
                    response.AssignProject = assignProject;
                }

                response.Success = true;

            }

            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Something went wrong: " + ex.ToString();
            }
            
            return response;
        }

        public CreateProjectResponse CreateProject(CreateProjectRequest request)
        {
            CreateProjectResponse response = new CreateProjectResponse();
            try
            {
                ProjectService service = new ProjectService(_projectRepository);
                service.AddProject(request.Project);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = "Something went wrong: " + ex.ToString();
                response.Success = false;
            }

            return response;
        }

        public CreatePersonResponse CreatePerson(CreatePersonRequest request)
        {
            CreatePersonResponse response = new CreatePersonResponse();
            try
            {
                PersonService service = new PersonService(_personRepository);
                service.AddPerson(request.Person);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = "Something went wrong: " + ex.ToString();
                response.Success = false;
            }
            
            return response;
        }

        private IEnumerable<Person> GetPersonsToAssign(Project project)
        {            
            IList<Person> persons = new List<Person>();
            IEnumerable<Person> allPerson = _personRepository.FindAll();
            foreach (Person p in allPerson)
            {
                if(!project.AssignedPersons.ToDictionary(x => x.Id).ContainsKey(p.Id))
                {
                    persons.Add(p);
                }
            }
            return persons;
        }
    }
}
