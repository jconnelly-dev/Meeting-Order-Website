using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Xml;

namespace PreCiseMeetingContentDelivery.Pages
{
    public class IndexModel : PageModel
    {
        #region Properties
        public List<string> MemberOrder { get; private set; } = [];
        public DateTime DayOfMeeting { get; private set; } = DateTime.MinValue;
        public DateTime LastBuildTime { get; private set; } = DateTime.MinValue;
        public string TimeZoneStandardName { get; private set; } = string.Empty;
        #endregion

        #region Private Members
        private const string MEETING_TIMEZONE = "US:Mountain";
        private static readonly string[] _names =
        [
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
        ];
        #endregion

        public void OnGet()
        {
            DateTime updateOrderOnUtc = DateTime.UtcNow;
            TimeZoneInfo meetingTimeZone = TimeZoneInfo.FindSystemTimeZoneById(id: MEETING_TIMEZONE);
            LastBuildTime = TimeZoneInfo.ConvertTimeFromUtc(LastAssemblyBuild.Date, meetingTimeZone);
            DayOfMeeting = TimeZoneInfo.ConvertTimeFromUtc(updateOrderOnUtc, meetingTimeZone);
            TimeZoneStandardName = DayOfMeeting.IsDaylightSavingTime()
                ? meetingTimeZone.DaylightName
                : meetingTimeZone.StandardName;

            // Creating separation from page content to aid in future testing.
            MemberOrder = Randomizer.RandomizeOrder(_names, DayOfMeeting);
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
