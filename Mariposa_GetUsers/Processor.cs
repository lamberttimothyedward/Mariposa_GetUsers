using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Web;
using System.IO;

namespace SendWelcomeEmail
{
    public class Processor
    {
        public static async Task<Sub_Accounts> connectToDomain(string domainURL = "")
        {
            string url = "";
            var logger = NLog.LogManager.GetCurrentClassLogger();
            if (!string.IsNullOrEmpty(domainURL))
            {

                url = domainURL + ConfigurationManager.AppSettings["getDomainURL"];
                
            }
            else
            {
                logger.Info("No Subaccount URL was Supplied");
            }
            try
            {
                using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        //Strip String of any extra characters
                        string result = response.Content.ReadAsStringAsync()
                            .Result
                            .Replace("\\", "")
                            .Trim(new char[1] { '"' });

                        var des = (SubAccountRoot)Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(SubAccountRoot));

                        if (des.sub_accounts.Length == 0)
                        {
                            Console.WriteLine("This subaccount: " + domainURL.ToString() + " has no information");


                        }
                        else
                        {
                            if (des.sub_accounts.Length > 0) 
                            {
                                Console.WriteLine("This domain: " + domainURL.ToString() + " is cool...");

                                foreach (Sub_Accounts sa in des.sub_accounts)
                                {

                                    if (!string.IsNullOrEmpty(sa.id))
                                    {

                                        return sa;
                                    }
                                }
                                return null;
                            }
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return null;
            }

            return null;
        }

        public static async Task<User> createUser(string domainURL = "", string email = "")
        {
            string url = "https://mariposa-acc.bridgeapp.com/api/admin/users";
            string users = "{\"users\": [{\"uid\": \"" + email + "\", \"email\": \"" + email + "\"}]}";
            var content = new StringContent(users, Encoding.UTF8, "application/json");
            string result = "";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsync(url, content))
            {
                try
                {
                    result = response.Content.ReadAsStringAsync()
                    .Result
                    .Replace("\\", "")
                    .Replace("\"\"", "")
                    .Trim(new char[1] { '"' });

                    var des = (UsersRootobject)Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(UsersRootobject));

                    if (des.users.Length == 0)
                    {
                        Console.WriteLine("This subaccount: " + domainURL.ToString() + " has no information");

                        return null;
                    }
                    else
                    {
                        if (des.users.Length == 1)
                        {
                            return des.users[0];
                        }
                    }
                }
                catch(Exception ex)
                {
                    return null;
                }
            }

                return null;
        }

        public static async Task<bool> updateUser(string domainURL, SendWelcomeEmail.User usr)
        {

            string url = domainURL + "/api/author/users/" + usr.id.ToString();
            string user = "{\"user\": {\"first_name\": \"" + usr.first_name + "\", \"last_name\": \"" + usr.last_name + "\"}}";

            Encoding encoding = Encoding.Default;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "PATCH";
            request.ContentType = "application/json; charset=utf-8";
            request.Headers.Add("Authorization", "Basic " + ConfigurationManager.AppSettings["token"]);
            byte[] buffer = encoding.GetBytes(user);
            System.IO.Stream dataStream = request.GetRequestStream();
            dataStream.Write(buffer, 0, buffer.Length);
            dataStream.Close();
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                string result = "";
                using (System.IO.StreamReader reader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.Default))
                {
                    result = reader.ReadToEnd();
                }

                return true;
            }
            catch (Exception ex)
            {
                
                return false;
            }

        }

        public static async Task<User[]> getUsers(string domainURL = "", bool managers = false)
        {
            string url = "";
            var logger = NLog.LogManager.GetCurrentClassLogger();
            if(managers == true)
            {
                url = domainURL + ConfigurationManager.AppSettings["managerURL"];
            }
            else
            {
                url = domainURL + ConfigurationManager.AppSettings["userURL"];
            }

            var loop = true;
            string result = "";
 
                    using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            //Strip String of any extra characters
                            result = response.Content.ReadAsStringAsync()
                                .Result
                                .Replace("\\", "")
                                .Replace("\"\"", "")
                                .Trim(new char[1] { '"' });
                            //var ziggo = HttpUtility.JavaScriptStringEncode(JsonConvert.SerializeObject(result));
                            //var des = (UsersRootobject)Newtonsoft.Json.JsonConvert.DeserializeObject(ziggo, typeof(UsersRootobject));
                            // Do here.....
                            do
                            {
                                try
                                {
                                    var des = (UsersRootobject)Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(UsersRootobject));

                                    if (des.users.Length == 0)
                                    {
                                        Console.WriteLine("This subaccount: " + domainURL.ToString() + " has no information");

                                        return null;
                                    }
                                    else
                                    {
                                        if (des.users.Length > 0)
                                        {
                                            return des.users;
                                        }
                                    }
                                }
                                catch (JsonReaderException ex)
                                {
                                    var position = ex.LinePosition;
                                    var invalidChar = result.Substring(position - 2, 2);
                                    invalidChar = invalidChar.Replace("\"", "'");
                                    result = $"{result.Substring(0, position - 1)}{result.Substring(position)}";
                                    logger.Error(ex.Message);
                                }
                            } while (loop);

                        }
                    }


            return null;
        }

        public static async Task<User> getUser(string domainURL = "", string email = "")
        {
            string url = "";
            var logger = NLog.LogManager.GetCurrentClassLogger();
            string myEncodedString = HttpUtility.UrlEncode(email);

            url = domainURL + ConfigurationManager.AppSettings["individualUserURL"] + myEncodedString;


            try
            {
                using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        //Strip String of any extra characters
                        string result = response.Content.ReadAsStringAsync()
                            .Result
                            .Replace("\\", "")
                            .Trim(new char[1] { '"' });

                        var des = (UsersRootobject)Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(UsersRootobject));

                        if (des.users.Length == 0)
                        {
                            Console.WriteLine("This subaccount: " + domainURL.ToString() + " has no information");
                            SendWelcomeEmail.User usr = new SendWelcomeEmail.User();
                            return usr;
                        }
                        else
                        {
                            if (des.users.Length > 0)
                            {
                                return des.users[0];
                            }
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                SendWelcomeEmail.User usr1 = new SendWelcomeEmail.User();
                logger.Error(ex.Message);
                return usr1;
            }
            SendWelcomeEmail.User usr2 = new SendWelcomeEmail.User();
            return usr2;
        }

        public static async Task<Boolean> sendWelcomeEmail(int userID = 0, string domainURL = "", bool passwordReset = false)
        {
            string url = "";
            var logger = NLog.LogManager.GetCurrentClassLogger();
            if(passwordReset == false)
            {
                url = domainURL + ConfigurationManager.AppSettings["welcomeURL"] + userID.ToString() + "/welcome";
            }
            else
            {
                url = domainURL + ConfigurationManager.AppSettings["welcomeURL"] + userID.ToString() + "/password";
            }

             

            try
            {
                using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsync(url, null))
                {
                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return true;

                    }
                    else
                    {
                        return false;
                    }
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return false;
            }

        }
    }
}
