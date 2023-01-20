using EntityFrameworkWPF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkWPF.Repositories
{
    public class MyEventRepository : IMyEventRepository
    {
        private readonly DataContext _context;

        public MyEventRepository(DataContext context)
        {
            _context = context;
        }

        public int Count(MyEvent myEvent)
        {
            return _context.MyEvents.Where(m => m.Id != 0).Count();
        }

        public void Create(MyEvent myEvent)
        {
            _context.MyEvents.Add(myEvent);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var myEventFound = _context.MyEvents.FirstOrDefault(e => e.Id == id);

            if (myEventFound is null)
            {
                throw (new Exception("MyEvent non trouvé"));
            }

            _context.MyEvents.Remove(myEventFound);
            _context.SaveChanges();
        }

        public List<MyEvent> GetAll()
        {
            return _context.MyEvents.AsNoTracking().ToList();
        }

        public MyEvent GetById(int id)
        {
            var myEventFound = _context.MyEvents.FirstOrDefault(e => e.Id == id);

            if(myEventFound == null)
            {
                throw (new Exception("MyEvent non trouvé"));
            }

            return myEventFound;
        }

        public MyEvent GetByTitle(string title)
        {
            var myEventFound = _context.MyEvents.FirstOrDefault(e => e.Title == title);

            if (myEventFound is null)
            {
                throw (new Exception("MyEvent non trouvé"));
            }

            return myEventFound;
        }

        public List<MyEvent> Search(string keyword)
        {
            return _context.MyEvents.AsNoTracking().Where(evt => evt.Title.Contains(keyword)
                || evt.Description.Contains(keyword)
                || evt.DateStart.ToString().Contains(keyword)
                || evt.DateEnd.ToString().Contains(keyword)).ToList();


        }

        public void Update(MyEvent myEvent)
        {
            int id = myEvent.Id;
            var myEventFound = _context.MyEvents.FirstOrDefault(e => e.Id == id);

            if (myEventFound is not null)
            {
                try
                {
                    //_context.MyEvents.Update(myEvent); ou celui d'en bas
                    _context.MyEvents.Attach(myEvent);
                    _context.Entry(myEvent).State = EntityState.Modified;
                    _context.SaveChanges();
                }
                catch (Exception e)
                {

                    throw new Exception(e.Message);
                }
            }

            
        }
    }
}
