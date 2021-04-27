using Domain.Entities;
using Xunit;

namespace WishList.Domain.Test
{
    public class TestDomain
    {
        // Criar uma Lista de Desejos com
        // Title Description Link PhotoUrl, worOrBought

        [Fact]
        public void WishList_AddItem()
        {
            var itemExpected = new
            {
                Title = "Testando Item",
                Description = "Teste unitario",
                Link = "https://translate.google.com/",
                PhotoUrl = "",
                WonOrBought = true,
            };

            var item = new Item(itemExpected.Title, itemExpected.Description, itemExpected.Link, itemExpected.PhotoUrl, itemExpected.WonOrBought);

            Assert.Equal(itemExpected.Title, item.Title);
            Assert.Equal(itemExpected.Description, item.Description);
            Assert.Equal(itemExpected.Link, item.Link);
            Assert.Equal(itemExpected.PhotoUrl, itemExpected.PhotoUrl);
            Assert.Equal(itemExpected.WonOrBought, item.WonOrBought);
        }



    }
}
