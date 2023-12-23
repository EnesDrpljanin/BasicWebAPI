using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterviewTask.Data.Entities;

namespace InterviewTask.Domain.Mappers
{
    public static class CountryMapper
    {
        public static CountryModel ToModel(this Country entity)
        {
            return new CountryModel()
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public static Country ToEntity(this CountryModel model)
        {
            return new Country()
            {
                Id = model.Id,
                Name = model.Name
            };
        }
    }
}
