using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ButtonUpdate
{
    public class Internet
    {
        public static bool IsConnectedToGoogle()
        {
            try
            {
                string myAddress = "www.google.com";
                IPAddress[] addresslist = Dns.GetHostAddresses(myAddress);

                if (addresslist[0].ToString().Length > 6)
                {
                    return true;
                }
                else
                    return false;

            }
            catch
            {
                return false;
            }

        }

        public bool CanDownloadFile()
        {
            try
            {
                WebClient Client = new WebClient();
                String Response;
                Response = Client.DownloadString("http://www.google.com");
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool IsConnected()
        {
            return IsConnectedToGoogle() && CanDownloadFile();
        }
    }
}
