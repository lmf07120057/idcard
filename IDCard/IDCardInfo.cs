using System;
using System.Collections.Generic;
using System.Text;

namespace IDCard
{
    /// <summary>
    /// 验证返回的身份证信息
    /// </summary>
    public class IDCardInfo
    {  
        /// <summary>
        /// 大区，如：华北地区,东北地区,华东地区,华中地区,华南地区, 西南地区,西北地区,特别地区
        /// </summary>
        public string Region { get; set; }
         
        /// <summary>
        /// 省名称
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// 区市县
        /// </summary>
        public string City { get; set; }
         
        /// <summary>
        /// 性别
        /// </summary>
        public string Gender { get;set;}

        /// <summary>
        /// 出生日期（年-月-日）
        /// </summary>
        public DateTime DayOfBirth { get;set;}

        /// <summary>
        /// 是否校验通过,默认否
        /// </summary>
        public bool IsVerifyPass { get;set;} = false;

    }
}
