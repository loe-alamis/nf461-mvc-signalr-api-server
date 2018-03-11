using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace nf461webmvc.Hubs
{
    public class MyHub : Hub
    {
        private static IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<MyHub>();

        public void Hello()
        {
            Clients.All.hello();
        }

        public void Send(string name, string message)
        {
            Clients.All.addNewMessageToPage(name, message);
            this.Status();
        }

        public void Status()
        {
            int id = 9593;
            string status = "processing";
            Clients.All.checkStatus(id, status);
        }

        public static void SayHello()
        {
            hubContext.Clients.All.hello();
        }

        public static void SendHello()
        {
            hubContext.Clients.All.addNewMessageToPage("value1", "value2");
        }
    }
}