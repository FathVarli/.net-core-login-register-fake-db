using API.Entities;
using API.Helpers;
using API.Interfaces;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class DailyNewsService : IDailyNews
    {
        private DataContext _context;
        public DailyNewsService(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<DailyNews> GetAll()
        {
            return _context.News;
        }

        public DailyNews GetById(int id)
        {
            return _context.News.Find(id);
        }

        public DailyNews Create(DailyNews dNews)
        {
            

            _context.News.Add(dNews);
            _context.SaveChanges();

            return dNews;
        }

        public void Update(DailyNews newsParam)
        {
            var nNews = _context.News.Find(newsParam.dailyID);

            if (nNews == null)
                throw new AppException("İlgili içerik bulunamadı !");


            // update user properties
            nNews.mainSubject = newsParam.mainSubject;
            nNews.body = newsParam.body;
            nNews.contentImage = newsParam.contentImage;
          
            _context.News.Update(nNews);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var cont = _context.News.Find(id);
            if (cont != null)
            {
                _context.News.Remove(cont);
                _context.SaveChanges();
            }
        }

    }
}
