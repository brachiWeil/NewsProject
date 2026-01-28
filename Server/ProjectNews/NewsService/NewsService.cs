using System.Xml.Linq;
using Web.core.Model;
using Web.core.Services;
using Microsoft.Extensions.Caching.Memory;



namespace Web.Service
{
    public class NewsService : INewsService
    {
        private readonly IMemoryCache _cache;
        private readonly HttpClient _client;

        public NewsService(IMemoryCache cache)
        {
            _cache = cache;
            _client = new HttpClient();
        }
        public async Task<List<NewsItem>> GetNewsAsync()
        {
            //בודקים האם המידע כבר נמצא ב cache 
            if (!_cache.TryGetValue("RSSNews", out List<NewsItem> news))
            {
                var url = "https://www.kore.co.il/feed";
                var res = await _client.GetStringAsync(url);
                XNamespace contentNs = "http://purl.org/rss/1.0/modules/content/";
                var doc = XDocument.Parse(res);
                news = doc.Descendants("item")
                    .Select(i => new NewsItem
                    {
                        Title = i.Element("title")?.Value,
                        Link = i.Element("link")?.Value,
                        Content = i.Element(contentNs + "encoded")?.Value
                    }).ToList();
                //שמירה ב cache לכ10 דקות
                _cache.Set("RSSNews", news, TimeSpan.FromMinutes(10));


            }
            return (news);
        }
        public async Task<NewsItem> GetNewsById(int id)
        {
            var allNews = await GetNewsAsync();

            if (id >= 0 && id < allNews.Count)
            {
                return allNews[id];
            }

            return null;
        }
    }
}
