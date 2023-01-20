using EntityFrameworkWPF.Models;
using EntityFrameworkWPF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkWPF.Service
{
    public class MyEventService : IMyEventService
    {
        private readonly IMyEventRepository _repository;

        public MyEventService(IMyEventRepository repository)
        {
            _repository = repository;
        }
        public int Count(MyEvent myEvent)
        {
            return _repository.Count(myEvent);
        }

        public void Create(MyEvent myEvent)
        {
            _repository.Create(myEvent);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<MyEvent> GetAll()
        {
            return _repository.GetAll();
        }

        public MyEvent GetById(int id)
        {
            return _repository.GetById(id);
        }

        public MyEvent GetByTitle(string title)
        {
            return _repository.GetByTitle(title);
        }

        public List<MyEvent> Search(string keyword)
        {
            return _repository.Search(keyword);
        }

        public void Update(MyEvent myEvent)
        {
            _repository.Update(myEvent);
        }
    }
}
