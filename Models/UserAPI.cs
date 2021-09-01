using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STUDENTPORTAL.Models
{// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class UserId
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
    }

    public class UserResult
    {
        public List<Root> roots { get; set; }
    }

}
