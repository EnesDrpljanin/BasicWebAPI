using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterviewTask.Data.Entities;

namespace InterviewTask.Domain.Mappers
{
    public static class ClientMapper
    {
        public static ClientModel ToModel(this Client entity)
        {
            return new ClientModel()
            {
                Id = entity.Id,
                ClientName = entity.ClientName,
                ClientAddress = entity.ClientAddress,
            };
        }
        

        public static Client ToEntity(this ClientModel model)
        {
            return new Client()
            {
                Id = model.Id,
                ClientName = model.ClientName,
                ClientAddress = model.ClientAddress,
            };
        }
    }
}
