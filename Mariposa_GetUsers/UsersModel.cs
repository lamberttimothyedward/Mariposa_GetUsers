using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendWelcomeEmail
{

    public class UsersRootobject
    {
        public UsersMeta meta { get; set; }
        public UsersLinked linked { get; set; }
        public User[] users { get; set; }
    }

    public class UsersMeta
    {
    }

    public class UsersLinked
    {
    }

    public class User
    {
        public string id { get; set; }
        public string uid { get; set; }
        public object hris_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string full_name { get; set; }
        public object sortable_name { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string email { get; set; }
        public string locale { get; set; }
        public string[] roles { get; set; }
        public string name { get; set; }
        public string avatar_url { get; set; }
        public DateTime? updated_at { get; set; }
        public object deleted_at { get; set; }
        public object unsubscribed { get; set; }
        public DateTime? welcomedAt { get; set; }
        public DateTime? loggedInAt { get; set; }
        public bool passwordIsSet { get; set; }
        public object hire_date { get; set; }
        public bool is_manager { get; set; }
        public object job_title { get; set; }
        public object bio { get; set; }
        public object department { get; set; }
        public object anonymized { get; set; }
        public UsersLinks links { get; set; }
        public Meta1 meta { get; set; }
    }

    public class UsersLinks
    {
    }

    public class Meta1
    {
        public bool can_masquerade { get; set; }
    }

}
