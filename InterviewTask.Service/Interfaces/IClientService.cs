using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterviewTask.Domain;

namespace InterviewTask.Service.Interfaces
{
    public interface IClientService
    {
        List<ClientModel> GetAll();
        int CreateClient(ClientModel clientModel);

        ClientModel UpdateClient(ClientModel clientModel);

        void DeleteClient(int id);

        ClientModel GetById(int id);
    }
}