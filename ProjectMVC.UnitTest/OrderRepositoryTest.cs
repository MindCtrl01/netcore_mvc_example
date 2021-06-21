using Moq;
using System;
using Xunit;

namespace ProjectMVC.UnitTest
{
    public class OrderRepositoryTest
    {
        [Fact]
        public void Get_Order_List_Return_Result()
        {
            //Setup DbContext and DbSet mock  
            var dbContextMock = new Mock<ProductsDbContext>();
            var dbSetMock = new Mock<DbSet<Product>>();
            dbSetMock.Setup(s => s.FindAsync(It.IsAny<Guid>())).Returns(Task.FromResult(new Product()));
            dbContextMock.Setup(s => s.Set<Product>()).Returns(dbSetMock.Object);

            //Execute method of SUT (ProductsRepository)  
            var productRepository = new ProductsRepository(dbContextMock.Object);
            var product = productRepository.GetByIdAsync(Guid.NewGuid()).Result;

            //Assert  
            Assert.NotNull(product);
            Assert.IsAssignableFrom<Product>(product);
        }
    }
}
