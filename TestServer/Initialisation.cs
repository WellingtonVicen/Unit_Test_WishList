using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace WishList.Domain.Test
{
    public class Initialisation
    {

        public TestServer TestServer { get; }

        public Initialisation()
        {
            var webBuilder = new WebHostBuilder();
            webBuilder.UseStartup<StartupT>();

            TestServer = new TestServer(webBuilder);
        }
    }
}
