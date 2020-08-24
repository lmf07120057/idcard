/** 
 * 
 *  1．号码的结构
　　公民身份号码是特征组合码，由十七位数字本体码和一位校验码组成。排列顺序从左至右依次为：六位数字地址码，八位数字出生日期码，三位数字顺序码和一位数字校验码。
　　2．地址码
　　表示编码对象常住户口所在县（县级市、旗、区）的行政区划代码，按GB/T2260的规定执行。
　　3．出生日期码
　　表示编码对象出生的年、月、日，按GB/T7408的规定执行，年、月、日代码之间不用分隔符。
　　4．顺序码
　　表示在同一地址码所标识的区域范围内，对同年、同月、同日出生的人编定的顺序号，顺序码的奇数分配给男性，偶数分配给女性。
　　5．校验码
　　根据前面十七位数字码，按照ISO 7064:1983.MOD 11-2校验码计算出来的检验码。
    校验码生成规则：
    （1）先将身份证前面的17位数分别乘以不同的系数
    （2）把这个17位数字和系数相乘后所得的结果相加，得到一个总和数，再除以11得到余数，那么余数与校验码（身份证是的最后一位）相对应的关系如图所示，即如果余数为3，校验码为9

-------------------------------------------------------------------------------------------------------------------------
    
    15位身份证号与18位身份证号的区别： 
      15位身份证号码各位的含义:
      1-2位省、自治区、直辖市代码；
      3-4位地级市、盟、自治州代码；
      5-6位县、县级市、区代码；
      7-12位出生年月日,比如670401代表1967年4月1日,与18位的第一个区别；
      13-15位为顺序号，其中15位男为单数，女为双数；
      与18位身份证号的第二个区别：没有最后一位的验证码。 
 * 
 */

using IDCardVerification;
using System;
using System.Collections.Generic;
using System.Text;

namespace IDCard
{
    /// <summary>
    /// 
    /// </summary>
    public static class IDCard
    {
        private static RegionalTable table = RegionalTable.GetInstance();

        /// <summary>
        /// 身份证校验
        /// </summary>
        /// <param name="idcard">身份证号码</param>
        /// <returns></returns>
        public static IDCardInfo Verify(this string idcard)
        {
            var len = idcard.Trim().Length;
            if (len==18)
            {
                return idcard.VerifyIdcard18();
            }
            else if (len==15)
            {
                return idcard.VerifyIdcard15();
            }
              
            return new IDCardInfo();
        }


        /// <summary>
        /// 身份证校验18位卡
        /// </summary>
        /// <param name="idcard">身份证号码</param>
        /// <returns></returns>
        private static IDCardInfo VerifyIdcard18(this string idcard)
        { 
            var regionid = Convert.ToInt32(idcard.Substring(0, 2));
            var cityid = Convert.ToInt32(idcard.Substring(0,6)); 
            var region = table.GetRegion(regionid); 
            var province = table.GetProvince(regionid);
            var city = table.GetCity(cityid); 
            var dayofbirth = new DateTime(int.Parse(idcard.Substring(6,4)),int.Parse(idcard.Substring(10,2)),int.Parse(idcard.Substring(12,2)));
            var genderid = int.Parse(idcard.Substring(14, 3)); 
            var gender = genderid % 2 == 1 ? "男": "女"; 
            var code = GetValidateCode(idcard.Substring(0,17));
            var isVerifyPass = code == char.Parse(idcard.Substring(17,1));

            IDCardInfo card = new IDCardInfo()
            {
                City = city,
                Province = province,
                Region = region,
                DayOfBirth = dayofbirth,
                Gender = gender,
                IsVerifyPass = isVerifyPass
            };

            return card;
        }

        /// <summary>
        /// 身份证校验15位卡
        /// </summary>
        /// <param name="idcard"></param>
        /// <returns></returns>
        private static IDCardInfo VerifyIdcard15(this string idcard)
        {
            //440304851121261
            var regionid = Convert.ToInt32(idcard.Substring(0, 2));
            var cityid = Convert.ToInt32(idcard.Substring(0, 6));
            var region = table.GetRegion(regionid);
            var province = table.GetProvince(regionid);
            var city = table.GetCity(cityid);
            var dayofbirth = new DateTime(int.Parse( "19" + idcard.Substring(6, 2)), int.Parse(idcard.Substring(8, 2)), int.Parse(idcard.Substring(10, 2)));
            var genderid = int.Parse(idcard.Substring(12, 3));
            var gender = genderid % 2 == 1 ? "男" : "女";
             
            IDCardInfo card = new IDCardInfo()
            {
                City = city,
                Province = province,
                Region = region,
                DayOfBirth = dayofbirth,
                Gender = gender,
                IsVerifyPass = true //15位无校验码
            };

            return card;
        }

        /// <summary>
        /// 验证
        /// </summary>
        /// <param name="idcard17"></param>
        /// <returns></returns>
        private static char GetValidateCode(string idcard17)
        {
            int[] weight = { 7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2 };         //十七位数字本体码权重
            char[] validate = { '1', '0', 'X', '9', '8', '7', '6', '5', '4', '3', '2' };    //mod11,对应校验码字符值 
            int sum = 0;
            int mode = 0;
            for (int i = 0; i < idcard17.Length; i++)
            {
                sum = sum + int.Parse(idcard17.Substring(i, 1)) * weight[i];
            }
            mode = sum % 11;
            return validate[mode];
        }

    }
}
