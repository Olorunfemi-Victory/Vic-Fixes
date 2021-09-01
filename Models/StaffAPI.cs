using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STUDENTPORTAL.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Root
    {
        public int employeeId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string sex { get; set; }
        public string status { get; set; }
        public string dateOfBirth { get; set; }
        public string addressLine { get; set; }
        public string city { get; set; }
    }

    public class Result
    {
        public List<Root> roots { get; set; }
    }
}
