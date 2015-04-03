using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Model.Person
{
    public class IdCardData
    {
        /// <summary>
        /// 初始化IdCard类
        /// </summary>
        /// <param name="idcard">15、18位身份证号</param>
        public IdCardData(string idcard)
        {
            this.IdCard = idcard;

        }

        public string IdCard { get; set; }

        public bool IsIdCard
        {
            get
            {
                return IsIdcard();
            }
        }

        /// <summary>
        /// 身份证号长度
        /// </summary>
        public int Length
        {
            get
            {
                if (this.IsIdCard)
                {
                    return this.IdCard.Length;
                }
                else
                {
                    throw new Exception("error Idcard!");
                }
            }
        }

        private bool IsIdcard()
        {

            if (this.IdCard.Length == 18)
            {
                return CheckIDCard18();
            }
            else if (this.IdCard.Length == 15)
            {
                return CheckIDCard15();
            }
            else
            {
                return false;
            }
        }
        private bool CheckIDCard18()
        {
            string Id = this.IdCard;
            long n = 0;
            if (long.TryParse(Id.Remove(17), out n) == false || n < Math.Pow(10, 16) || long.TryParse(Id.Replace('x', '0').Replace('X', '0'), out n) == false)
            {
                return false;//数字验证
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(Id.Remove(2)) == -1)
            {
                return false;//省份验证
            }
            string birth = Id.Substring(6, 8).Insert(6, "-").Insert(4, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证
            }
            string[] arrVarifyCode = ("1,0,x,9,8,7,6,5,4,3,2").Split(',');
            string[] Wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(',');
            char[] Ai = Id.Remove(17).ToCharArray();
            int sum = 0;
            for (int i = 0; i < 17; i++)
            {
                sum += int.Parse(Wi[i]) * int.Parse(Ai[i].ToString());
            }
            int y = -1;
            Math.DivRem(sum, 11, out y);
            if (arrVarifyCode[y] != Id.Substring(17, 1).ToLower())
            {
                return false;//校验码验证
            }
            return true;//符合GB11643-1999标准
        }


        private bool CheckIDCard15()
        {
            string Id = this.IdCard;
            long n = 0;
            if (long.TryParse(Id, out n) == false || n < Math.Pow(10, 14))
            {
                return false;//数字验证
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(Id.Remove(2)) == -1)
            {
                return false;//省份验证
            }
            string birth = Id.Substring(6, 6).Insert(4, "-").Insert(2, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证
            }
            return true;//符合15位身份证标准
        }

        public UInt32 GetAge()
        {
            return 0;
        }

        public DateTime GetBrithday()
        {
            string idCardBrithdayCode;
            if (this.IsIdCard)
            {
                if (this.Length == 15)
                {
                    idCardBrithdayCode = this.IdCard.Substring(6, 6);
                    Int32 year = Convert.ToInt32("19" + idCardBrithdayCode.Substring(0, 2));
                    Int32 month = Convert.ToInt32(idCardBrithdayCode.Substring(2, 2));
                    Int32 day = Convert.ToInt32(idCardBrithdayCode.Substring(4, 2));
                    return new DateTime(year, month, day);
                }
                else
                {
                    idCardBrithdayCode = this.IdCard.Substring(6, 8);
                    Int32 year = Convert.ToInt32(idCardBrithdayCode.Substring(0, 4));
                    Int32 month = Convert.ToInt32(idCardBrithdayCode.Substring(4, 2));
                    Int32 day = Convert.ToInt32(idCardBrithdayCode.Substring(6, 2));
                    return new DateTime(year, month, day);
                }
            }
            else
            {
                throw new Exception("error Idcard!");
            }
        }



    }
}
