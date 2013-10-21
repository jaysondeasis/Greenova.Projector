using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Greenova.Projector.Model.IRepositories;

namespace Greenova.Projector.Model.Services
{
    public class ProjectService
    {
        private IProjectRepository _projectRepository;        

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public Project GetProject(int id)
        {
            return _projectRepository.FindBy(id);
        }

        public IList<Model.Project> GetAllProjects()
        {
            List<Model.Project> projects = _projectRepository.FindAll().ToList();
            return projects;
        }

        public void AddProject(Project project)
        {
            _projectRepository.Save(project);
        }
               
    }
}
