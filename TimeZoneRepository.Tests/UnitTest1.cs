using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeZoneRepository.Model;
using System.Linq;

namespace TimeZoneRepository.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Log엔티티연결설렉트확인()
        {
            var db = new Entities();
            var test = db.Log.Where(w => w.Log_Id == 1);
            Assert.AreNotEqual(null, test);
        }
        [TestMethod]
        public void UnitOfWork엔티티확인()
        {
            var uw = new UnitOfWork();
            var log1 = uw.LogRepository.GetById(1);
            Assert.AreNotEqual(null, log1);
        }
    }
}
