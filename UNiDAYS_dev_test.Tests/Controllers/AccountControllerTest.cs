﻿using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using UNiDAYS_dev_test.Models;
using UNiDAYS_dev_test.Controllers;
using UNiDAYS_dev_test.Services;
using Moq;

namespace UNiDAYS_dev_test.Tests.Controllers
{
    [TestClass]
    public class AccountControllerTest
    {
        private Mock<IAccountDbContext> _accountDbContext;
        private AccountController _controller;
        
        
        [TestInitialize]
        public void TestInitialize()
        {
            _accountDbContext = new Mock<IAccountDbContext>();
            _controller = new AccountController(_accountDbContext.Object);
            

        }

        [TestMethod]
        public void TestNewUserGet()
        {
            var result = _controller.NewUser() as ViewResult;
            Assert.AreEqual("NewUser", result.ViewName);
        }

        [TestMethod]
        public void TestNewUserPost()
        {
            var model = new NewUserViewModel();
            _accountDbContext.Setup(m => m.CreateNewUser("user@domain.com", "somepassword")).Returns("some success string");
            var result = _controller.NewUser(model) as RedirectToRouteResult;
            Assert.AreEqual("NewUser", result.RouteValues["action"]);
        }
    }
}
