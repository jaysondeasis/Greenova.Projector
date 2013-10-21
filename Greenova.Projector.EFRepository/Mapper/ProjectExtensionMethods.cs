using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Greenova.Projector.EFRepository.Mapper
{
    public static class ProjectExtensionMethods
    {
        public static Model.Project ConvertToModelProject(this EFRepository.Project project)
        {
            return new Model.Project
            {
                Id = project.id,
                Code = project.code,
                Name = project.name,
                Remarks = project.remarks,
                Budget = project.budget,
                AssignedPersons = project.Persons.ConvertToModelPersons().ToList()
            };
        }

        public static IEnumerable<Model.Project> ConvertToModelProjects(this IEnumerable<EFRepository.Project> projects)
        {
            IList<Model.Project> modelProjects = new List<Model.Project>();

            foreach (EFRepository.Project project in projects)
            {
                modelProjects.Add(project.ConvertToModelProject());
            }

            return modelProjects.AsEnumerable();
        }
    }
}
