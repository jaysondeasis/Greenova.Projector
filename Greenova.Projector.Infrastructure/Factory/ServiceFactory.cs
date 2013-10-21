using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Greenova.Projector.Service;
using Greenova.Projector.Model.IRepositories;
using Greenova.Projector.EFRepository;

namespace Greenova.Projector.Infrastructure.Factory
{
    public static class ServiceFactory
    {
        public static ProjectorService CreateProjectService()
        {
            IProjectRepository projectRepository;
            IPersonRepository personRepository;

            projectRepository = new ProjectRepository();
            personRepository = new PersonRepository();

            return new ProjectorService(projectRepository,personRepository);
        }
    }
}
