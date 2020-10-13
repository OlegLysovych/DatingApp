using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.Models;
using Moq;
using System.Linq;
using Xunit;
using DatingApp.API.Controllers;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using DatingApp.API.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Test
{
    public class UsersControllerTests
    {
        private static DataContext _context;
        private DatingRepository _repo;
        // private List<User> GetTestUsers()
        // {   
        //     var users = new List<User>();
        //     for (int i = 1; i <= 3; i++)
        //     {
        //         Task<User> task = Task.Run<User>(async () => await _repo.GetUser(i));
        //         users.Add(task.Result);   
        //     }
        //     // users.Add( AsyncContext.Run(repo.GetUser(1)));
            
        //     // users.Add(await repo.GetUser(3));            
        //     return users;
        // }
        [Fact]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DataContext>().UseSqlite("Data Source=C:/Users/PC/source/repos/DatingApp/DatingApp.API/DatingApp.db").Options;
            _context = new DataContext(options);
            _repo = new DatingRepository(_context);
            Seed.SeedUsers(_context);

        }
        
        [Fact]
        public void GetUser_GivenId_UserByGivenId()
        {
            //Arrange
            int testUserId = 1;
            var mockRepo = new Mock<IDatingRepository>();
            mockRepo.Setup(repo => repo.GetUser(testUserId)).Returns(_context.Users.FirstOrDefaultAsync(u => u.Id == testUserId));//_context.Users.FirstOrDefaultAsync(u => u.Id == testUserId)
            var mockMap = new Mock<IMapper>();
            mockMap.Setup(m => m.Map<UserForDetailedDto>(It.IsAny<User>())).Returns(new UserForDetailedDto());
            var controller = new UsersController(mockRepo.Object, mockMap.Object);
            //Act
                // var result = controller.GetUser(testUserId);
            Task<IActionResult> task = Task.Run<IActionResult>(async () => await controller.GetUser(testUserId));
            var result = task.Result as ObjectResult;
                // ActionResult<UserForDetailedDto> result = controller.GetUser(testUserId).Result;
            //Assert
            Assert.IsType<OkObjectResult>(task.Result);
            Assert.True(result.StatusCode == 200);
        }
        
    }
}