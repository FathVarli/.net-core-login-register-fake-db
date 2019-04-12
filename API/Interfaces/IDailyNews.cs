using API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IDailyNews
    {
        IEnumerable<DailyNews> GetAll();
        DailyNews GetById(int id);
        DailyNews Create(DailyNews news);
        void Update(DailyNews user);
        void Delete(int id);
    }
}
