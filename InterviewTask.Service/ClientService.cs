using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterviewTask.Data;
using InterviewTask.Data.Entities;
using InterviewTask.Domain;
using InterviewTask.Domain.Mappers;
using InterviewTask.Service.Exceptions;
using InterviewTask.Service.Interfaces;

namespace InterviewTask.Service
{
    public class ClientService : IClientService
    {
        private InterviewTaskDbContext _interviewTaskDbContext;

        public ClientService(InterviewTaskDbContext InterviewTaskDbContext)
        {
            _interviewTaskDbContext = InterviewTaskDbContext;
        }
        public List<ClientModel> GetAll()
        {
            var clients = _interviewTaskDbContext.Clients.ToList();
            var clientModels = clients.Select(x => x.ToModel()).ToList();

            return clientModels;
        }
        public int CreateClient(ClientModel clientModel)
        {
            var clientEntity = clientModel.ToEntity();
            _interviewTaskDbContext.Clients.Add(clientEntity);

            return _interviewTaskDbContext.SaveChanges();
        }

        public ClientModel UpdateClient(ClientModel clientModel)
        {
            var clientEntity = _interviewTaskDbContext.Clients.FirstOrDefault(x => x.Id == clientModel.Id);

            if (clientEntity != null)
            {
                clientEntity.ClientName = clientModel.ClientName;

                _interviewTaskDbContext.Update(clientEntity);
                _interviewTaskDbContext.SaveChanges();

                return clientEntity.ToModel();
            }
            else
            {
                throw new NotFoundException($"Client with {clientModel.Id} not found ");
            }
        }

        public void DeleteClient(int id)
        {
            var clientEntity = _interviewTaskDbContext.Clients.FirstOrDefault(x => x.Id == id);

            if (clientEntity != null)
            {
                _interviewTaskDbContext.Clients.Remove(clientEntity);
                _interviewTaskDbContext.SaveChanges();
            }
            else
            {
                throw new NotFoundException($"Client with {id} not found ");
            }
        }

        public ClientModel GetById(int id)
        {
            var clientEntity = _interviewTaskDbContext.Clients.FirstOrDefault(x => x.Id == id);

            return clientEntity.ToModel();

        }
    }
}