using API;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace WishList.Domain.Test
{

    public class UnitTest1 : IClassFixture<Initialisation>, IDisposable
    {

        protected TestServer _testServer;

        public UnitTest1(Initialisation initialisation)
        {
            _testServer = initialisation.TestServer;
           
        }

        [Fact]
        public async Task TestCreateItem()
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/v1/itens/create");

            request.Content = new StringContent(JsonConvert.SerializeObject(new Dictionary<string, string>
            {
                {"Title", "Teste Post" },
                {" Description", "Teste Post" },
                {" Link", "https://translate.google.com/" },
                {" PhotoUrl", "" },
                {" WonOrBought ", "true" },

            }), Encoding.Default, "application/json");

            var client = _testServer.CreateClient();

            client.DefaultRequestHeaders.Clear();

            client.DefaultRequestHeaders
                .Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.SendAsync(request);

            response = await _testServer.CreateRequest("/api/v1/users/get-item/1").SendAsync("GET");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        public void Dispose()
        {
            _testServer.Dispose();
        }
    }
}
