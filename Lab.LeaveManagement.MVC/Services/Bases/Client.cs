using System.Net.Http;

namespace Lab.LeaveManagement.MVC.Services.Bases
{
    public partial class Client : IClient
    {
        public HttpClient HttpClient
        {
            get { return HttpClient; }
        }
    }
}
