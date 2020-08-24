using Microsoft.VisualStudio.TestTools.UnitTesting;
using IDCardVerification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDCardVerification.Tests
{
    [TestClass()]
    public class RegionalTableTests
    {
        private readonly RegionalTable table;

        public RegionalTableTests()
        {
            table = RegionalTable.GetInstance();
        }

        [TestMethod()]
        public void GetRegionTest()
        {
            var region1 = table.GetRegion(11);
            var region2 = table.GetRegion(44);
            var region3 = table.GetRegion(35);
            Assert.AreEqual("华北地区", region1);
            Assert.AreEqual("华南地区", region2);
            Assert.AreEqual("华东地区", region3);

        }

        [TestMethod()]
        public void GetProvinceTest()
        {
            var province1 = table.GetProvince(11);
            var province2 = table.GetProvince(21);
            var province3 = table.GetProvince(31);
            var province4 = table.GetProvince(41);
            var province5 = table.GetProvince(44);
            var province6 = table.GetProvince(54);

            Assert.AreEqual("北京市", province1);
            Assert.AreEqual("辽宁省", province2);
            Assert.AreEqual("上海市", province3);
            Assert.AreEqual("河南省", province4);
            Assert.AreEqual("广东省", province5);
            Assert.AreEqual("西藏自治区", province6);

        }

        [TestMethod()]
        public void GetCityTest()
        {
            var city1 = table.GetCity(110102);
            var city2 = table.GetCity(130628);
            var city3 = table.GetCity(140900);
            var city4 = table.GetCity(150223);
            var city5 = table.GetCity(331021);
            var city6 = table.GetCity(360403);
            var city7 = table.GetCity(410203);
            var city8 = table.GetCity(421381);
            var city9 = table.GetCity(441825);
            var city10 = table.GetCity(620103);
             
            Assert.AreEqual("西城区", city1);
            Assert.AreEqual("高阳县", city2);
            Assert.AreEqual("忻州市", city3);
            Assert.AreEqual("达尔罕茂明安联合旗", city4);
            Assert.AreEqual("玉环县", city5);
            Assert.AreEqual("浔阳区", city6);
            Assert.AreEqual("顺河回族区", city7);
            Assert.AreEqual("广水市", city8);
            Assert.AreEqual("连山壮族瑶族自治县", city9);
            Assert.AreEqual("七里河区", city10);

        }
    }
}