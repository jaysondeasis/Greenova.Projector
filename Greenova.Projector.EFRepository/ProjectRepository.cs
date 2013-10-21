using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Greenova.Projector.Model.IRepositories;
using Greenova.Projector.EFRepository.Mapper;

namespace Greenova.Projector.EFRepository
{
    public class ProjectRepository : IProjectRepository
    {

        private GreenovaEntities _entities;

        public Model.Project FindBy(int id)
        {
            Model.Project project;

            using (_entities = new GreenovaEntities())
            {
                project = _entities.Projects.Where(x => x.id == id)
                    .SingleOrDefault().ConvertToModelProject();
            }

            return project;
        }

        public IEnumerable<Model.Project> FindAll()
        {
            IEnumerable<Model.Project> projects;

            using (_entities = new GreenovaEntities())
            {
                projects = _entities.Projects.ConvertToModelProjects();                
            }

            return projects;
        }

        public void Save(Model.Project entity)
        {
            using (_entities = new GreenovaEntities())
            {
                if (entity.Id == 0)
                {
                    EFRepository.Project dbEntry = new EFRepository.Project
                    {                        
                        code = entity.Code,
                        name = entity.Name,
                        remarks = entity.Remarks,
                        budget = entity.Budget
                    };

                    _entities.Projects.AddObject(dbEntry);
                }
                else
                {
                    EFRepository.Project dbEntry = _entities.Projects.Where(x => x.id == entity.Id)
                        .SingleOrDefault();

                    if (dbEntry != null)
                    {
                        dbEntry.name = entity.Name;
                        dbEntry.code = entity.Code;
                        dbEntry.remarks = entity.Remarks;
                        dbEntry.budget = entity.Budget;
                    }
                }

                _entities.SaveChanges();
            }
        }
    }
}
