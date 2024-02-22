using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Xml;

namespace PreCiseMeetingContentDelivery.Pages
{
    public class IndexModel : PageModel
    {
        private static readonly string[] _names = new string[]
        {
            "andrew becklund",
            "andrew devoe",
            "anthony brother",
            "bob lowe",
            "camilla hoke",
            "darin macfarland",
            "dave carter",
            "dave heil",
            "emily sullivan",
            "jacob hays",
            "jay florey",
            "jay wendt",
            "jesse li",
            "joey connelly",
            "kellynn harder",
            "logan warner",
            "michael schlag",
            "michael travis",
            "nick kelly",
            "rhett harman",
            "ryan hansel",
            "samuel tew",
            "scott surber",
            "zuva donduro"
        };

        public DateTime DayOfMeeting { get; private set; } = DateTime.MinValue;
        public DateTime LastBuildTime { get; private set; } = DateTime.MinValue;
        public List<string> MemberOrder { get; private set; } = new List<string>();

        public void OnGet()
        {
            TimeZoneInfo meetingTimeZone = TimeZoneInfo.FindSystemTimeZoneById(id: "Mountain Standard Time");
            DayOfMeeting = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, meetingTimeZone);
            LastBuildTime = TimeZoneInfo.ConvertTimeFromUtc(LastAssemblyBuild.Date, meetingTimeZone);
            MemberOrder = RandomizeOrder();
        }

        private List<string> RandomizeOrder()
        {
            List<string> order = new List<string>();

            int seed = DateTime.Now.Day;
            Random rand = new Random(seed);
            Dictionary<int, string> participants = new Dictionary<int, string>();
            do
            {
                int upNext = rand.Next(0, _names.Length);
                if (!participants.ContainsKey(upNext))
                {
                    participants.Add(upNext, _names[upNext]);
                    order.Add(_names[upNext]);
                }
            }
            while (participants.Count < _names.Length);

            return order;
        }

        //[ResponseCache(Duration = 1200)]
        //[HttpGet]
        //public IActionResult Rss()
        //{
        //    var feed = new SyndicationFeed("Title", "Description", new Uri("SiteUrl"), "RSSUrl", DateTime.Now);

        //    feed.Copyright = new TextSyndicationContent($"{DateTime.Now.Year} Mitchel Sellers");
        //    var items = new List<SyndicationItem>();
        //    var postings = _blogDataService.ListBlogForRss();
        //    foreach (var item in postings)
        //    {
        //        var postUrl = Url.Action("Article", "Blog", new { id = item.UrlSlug }, HttpContext.Request.Scheme);
        //        var title = item.Title;
        //        var description = item.Preview;
        //        items.Add(new SyndicationItem(title, description, new Uri(postUrl), item.UrlSlug, item.PostDate));
        //    }

        //    feed.Items = items;
        //    var settings = new XmlWriterSettings
        //    {
        //        Encoding = Encoding.UTF8,
        //        NewLineHandling = NewLineHandling.Entitize,
        //        NewLineOnAttributes = true,
        //        Indent = true
        //    };
        //    using (var stream = new MemoryStream())
        //    {
        //        using (var xmlWriter = XmlWriter.Create(stream, settings))
        //        {
        //            var rssFormatter = new Rss20FeedFormatter(feed, false);
        //            rssFormatter.WriteTo(xmlWriter);
        //            xmlWriter.Flush();
        //        }
        //        return File(stream.ToArray(), "application/rss+xml; charset=utf-8");
        //    }
        //}
    }
}
