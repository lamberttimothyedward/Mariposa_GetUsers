using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendWelcomeEmail
{
    public class SubAccountRoot
    {
        public Sub_Accounts[] sub_accounts { get; set; }
    }

    public class Sub_Accounts
    {
        public string id { get; set; }
        public DateTime created_at { get; set; }
        public string name { get; set; }
        public SubAccountHost host { get; set; }
        public SubAccountConfig config { get; set; }
    }

    public class SubAccountHost
    {
        public string subdomain { get; set; }
        public object vanity_domain { get; set; }
        public string vanity_domain_state { get; set; }
    }

    public class SubAccountConfig
    {
        public object support_email { get; set; }
        public object support_name { get; set; }
        public object support_phone { get; set; }
        public object customer_provided_support_help_articles_url { get; set; }
        public object customer_provided_support_chat_url { get; set; }
        public bool show_custom_support_info { get; set; }
        public bool limited_managers { get; set; }
        public object lynda_org_id { get; set; }
        public string locale { get; set; }
        public string time_zone { get; set; }
        public object password_minimum_length { get; set; }
        public bool password_requires_numbers { get; set; }
        public bool password_requires_symbols { get; set; }
        public bool password_requires_uppercase { get; set; }
        public bool notifications { get; set; }
        public bool chat_notifications { get; set; }
        public object from_label { get; set; }
        public object reply_to { get; set; }
    }
}
