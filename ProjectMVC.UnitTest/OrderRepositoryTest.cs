using Microsoft.EntityFrameworkCore;
using Moq;
using ProjectMVC.Database;
using ProjectMVC.Models;
using ProjectMVC.Repository;
using ProjectMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ProjectMVC.UnitTest
{
    public class OrderRepositoryTest
    {
        [Fact]
        public async void Get_Order_List_Return_Result()
        {
            //Setup
            var data = new List<OrderView>
            {
                new OrderView { CustomerName = "Mr Tran", ProductName = "Chair", CategoryName="Furniture", OrderDate = DateTime.Now, Amount = 100 },
                new OrderView { CustomerName = "Mr Van", ProductName = "Table", CategoryName="Furniture 2", OrderDate = DateTime.Now, Amount = 25 },
                new OrderView { CustomerName = "Mr Tung", ProductName = "Stove", CategoryName="Furniture 3", OrderDate = DateTime.Now, Amount = 55 },
            };

            var orderRepository = new Mock<IOrderRepository>();
            orderRepository.Setup(x => x.GetOrderWithPaging(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(data));

            //Action
            var mockOrderRepository = orderRepository.Object;
            List<OrderView> order_test = await mockOrderRepository.GetOrderWithPaging(0, 3);

            //Assert
            Assert.NotNull(order_test);
            Assert.True(order_test.Count == 3);
            Assert.True(order_test[0].CustomerName == "Mr Tran");
            Assert.True(order_test[1].CategoryName == "Furniture 2");
            Assert.True(order_test[2].Amount == 55);
        }

        [Fact]
        public async void Get_Order_List_With_Search_Return_Result()
        {
            //Setup
            var data = new List<OrderView>
            {
                new OrderView { CustomerName = "Mr Tran", ProductName = "Chair", CategoryName="Furniture", OrderDate = DateTime.Now, Amount = 100 },
                new OrderView { CustomerName = "Mr Van", ProductName = "Table", CategoryName="Furniture", OrderDate = DateTime.Now, Amount = 25 },
                new OrderView { CustomerName = "Mr Tung", ProductName = "Stove", CategoryName="Furniture", OrderDate = DateTime.Now, Amount = 55 },
            };

            var orderRepository = new Mock<IOrderRepository>();
            orderRepository.Setup(x => x.GetOrderWithSearchAndPaging(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(data));

            //Action
            var mockOrderRepository = orderRepository.Object;
            List<OrderView> order_test = await mockOrderRepository.GetOrderWithSearchAndPaging(0, 3, "Furniture");

            //Assert
            Assert.NotNull(order_test);
            Assert.True(order_test.Count == 3);
            Assert.True(order_test.All(o => o.CategoryName == "Furniture"));
        }
    }
}
