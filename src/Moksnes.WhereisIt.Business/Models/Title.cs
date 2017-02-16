using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moksnes.WhereisIt.Business.Models
{
    public class Title
    {
    }


    public class Rootobject
    {
        public List<Title_Popular> title_popular { get; set; }
        public List<Title_Exact> title_exact { get; set; }
        public List<Title_Substring> title_substring { get; set; }
    }

    public class Title_Popular
    {
        public string id { get; set; }
        public string title { get; set; }
        public string name { get; set; }
        public string title_description { get; set; }
        public string episode_title { get; set; }
        public string description { get; set; }
    }

    public class Title_Exact
    {
        public string id { get; set; }
        public string title { get; set; }
        public string name { get; set; }
        public string title_description { get; set; }
        public string episode_title { get; set; }
        public string description { get; set; }
    }

    public class Title_Substring
    {
        public string id { get; set; }
        public string title { get; set; }
        public string name { get; set; }
        public string title_description { get; set; }
        public string episode_title { get; set; }
        public string description { get; set; }
    }

}
