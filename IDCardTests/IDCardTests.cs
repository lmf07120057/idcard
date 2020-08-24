using Microsoft.VisualStudio.TestTools.UnitTesting;
using IDCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDCardVerification;

namespace IDCard.Tests
{
    [TestClass()]
    public class IDCardTests
    { 

        [TestMethod()]
        public void VerifyTest()
        { 
            var idcard = "440304198511212612";
            var card = IDCard.Verify(idcard); 

            Assert.AreEqual("1985-11-21", card.DayOfBirth.ToString("yyyy-MM-dd"));
            Assert.AreEqual("男",card.Gender);
            Assert.AreEqual(true,card.IsVerifyPass);
            Assert.AreEqual("华南地区",card.Region);
            Assert.AreEqual("广东省",card.Province);
            Assert.AreEqual("福田区", card.City);

            var idcard2 = "440304198511212611";
            var card2 = IDCard.Verify(idcard2);
            Assert.AreEqual(false, card2.IsVerifyPass);

            var idcard3 = "440304851121261";
            var card3 = IDCard.Verify(idcard3);

            Assert.AreEqual("1985-11-21", card3.DayOfBirth.ToString("yyyy-MM-dd"));
            Assert.AreEqual("男", card3.Gender); 
            Assert.AreEqual("华南地区", card3.Region);
            Assert.AreEqual("广东省", card3.Province);
            Assert.AreEqual("福田区", card3.City);

        }
    }
}