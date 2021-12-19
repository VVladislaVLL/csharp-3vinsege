using System;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SportsStore.Infrastructure;

namespace SportsStore.Models
{
    public class SessionCourseWorksList : CourseWorksList
    {
        public static CourseWorksList GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            SessionCourseWorksList courseWorksList = session?.GetJson<SessionCourseWorksList>("Cart") ?? new SessionCourseWorksList();
            courseWorksList.Session = session;
            return courseWorksList;
        }

        [JsonIgnore] 
        public ISession Session { get; set; }

        public override void AddItem(CourseWork courseWork, int quantity)
        {
            base.AddItem(courseWork, quantity);
            Session.SetJson("Cart", this);
        }

        public override void RemoveLine(CourseWork courseWork)
        {
            base.RemoveLine(courseWork);
            Session.SetJson("Cart", this);
        }

        public override void Clear()
        {
            base.Clear();
            Session.Remove("Cart");
        }
    }
}