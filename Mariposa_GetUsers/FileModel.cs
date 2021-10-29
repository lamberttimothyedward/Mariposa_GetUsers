using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileHelpers;

namespace SendWelcomeEmail
{
    [DelimitedRecord(",")]
    public class FileUsers
    {
        public string user_id;
    }


    [DelimitedRecord(",")]
    public class UsersOutput
    {
        public string user_id;
        public string email;
        public string first_name;
        public string last_name;
        public string passwordIsSet;
        public string dayswelcomed;

    }
}
