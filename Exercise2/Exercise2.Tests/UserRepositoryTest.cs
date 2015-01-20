using System;
using System.Linq;
using Exercise2.Entities;
using Exercise2.Infrastructure;
using NHibernate;
using NHibernate.Linq;
using NUnit.Framework;
using Rhino.Mocks;

namespace Exercise2.Tests
{
    [TestFixture]
    public class UserRepositoryTests
    {
        private ISessionFactoryProvider _sessionFactoryProvider;
        private ISessionFactory _sessionFactory;
        private ISession _session;

        private UserRepository _target;

        [SetUp]
        public void Setup()
        {
            _sessionFactoryProvider = MockRepository.GenerateStub<ISessionFactoryProvider>();
            _session = MockRepository.GenerateStub<ISession>();
            _sessionFactory = MockRepository.GenerateStub<ISessionFactory>();

            _target = new UserRepository();

            _sessionFactory.Stub(s => s.OpenSession()).Return(_session);
            _sessionFactoryProvider.Stub(x => x.GetSessionFactory()).Return(_sessionFactory);
        }
        
        [Test]
        public void Insert_User_SaveInDB()
        {
            var user = new User { Name = "Galo", ImageUrl = new Uri("http://www.myimage.com"), UserType = UserType.VIP };
        
            _target.Insert(user);
            
            _session.AssertWasCalled(s => s.Save(user));
        }

        [Test]
        public void GetAll_WhenNoUsers_ReturnEmptyList()
        {
            NoUsers();

            var result = _target.GetAll();

            Assert.That(result, Is.Empty);
        }

        private void NoUsers()
        {
            _session
                .Stub(s => s.Query<User>())
                .Return(new User[0].AsQueryable());
        }

        //[Test]
        //public void GetAll__NoUsersFound_ReturnEmptyList()
        //{
        //    //Arrange
        //    var repository = new UserRepository(_sessionFactoryProvider);
        //    var users = new User[]
        //    {
        //        new User{Name = "a", ImageUrl = new Uri("http://www.image1.com"), UserType = UserType.Regular}, 
        //        new User{Name = "b", ImageUrl = new Uri("http://www.image2.com"), UserType = UserType.VIP}, 
        //        new User{Name = "c", ImageUrl = new Uri("http://www.image3.com"), UserType = UserType.Employee}, 
        //    };

        

        //    //Act
        //    repository.GetAll();

        //    //Assert
        //    _session.AssertWasCalled(s => s.Query<User>());
        //}
    }
}
