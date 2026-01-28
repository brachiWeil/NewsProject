using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.core.Model;

namespace Web.core.Services
{
    public interface INewsService
    {
         Task<List<NewsItem>> GetNewsAsync();
          Task<NewsItem> GetNewsById(int id);

    }
}
