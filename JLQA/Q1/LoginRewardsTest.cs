using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
namespace JLQA.Q1
{
    public class LoginRewardsTest
    {
        private readonly LoginRewards _loginRewards;
        /// <summary>
        /// 初始化
        /// </summary>
        public LoginRewardsTest() {
            _loginRewards = new LoginRewards();
        }
        /// <summary>
        /// 沒有登入任何一天
        /// </summary>
        [Fact]
        public void NoLogin()
        {
            Assert.Empty(_loginRewards.GetLoggedInDays());
            Assert.Empty(_loginRewards.GetEarnedRewards());
        }
        /// <summary>
        /// 分別登入第1天 第2天 第3天
        /// </summary>
        /// <param name="day"></param>
        /// <param name="reward"></param>
        [Theory]
        [InlineData(1,"A")]
        [InlineData(2,"B")]
        [InlineData(3,"C")]
        public void LoginOneDay(int day , string reward) {
            _loginRewards.Login(day);
            Assert.Single(_loginRewards.GetLoggedInDays());
            Assert.Equal(reward, _loginRewards.GetEarnedRewards()[0]);
        }
        /// <summary>
        /// 登入某2天
        /// </summary>
        /// <param name="day1"></param>
        /// <param name="day2"></param>
        /// <param name="rewards"></param>
        [Theory]
        [InlineData(1, 2, "AB")]
        [InlineData(1, 3, "AC")]
        [InlineData(2, 3, "BC")]
        public void LoginTwoDays(int day1,int day2,string rewards)
        {
            _loginRewards.Login(day1);
            _loginRewards.Login(day2);
            Assert.Equal(2,_loginRewards.GetLoggedInDays().Count);
            Assert.Equal(rewards, _loginRewards.GetEarnedRewards()[0]+ _loginRewards.GetEarnedRewards()[1]);
        }
        /// <summary>
        /// 3天都登入
        /// </summary>
        [Fact]
        public void LoginThreeDays()
        {
            _loginRewards.Login(1);
            _loginRewards.Login(2);
            _loginRewards.Login(3);
            Assert.Equal(3,_loginRewards.GetLoggedInDays().Count);
            Assert.Equal("ABC", _loginRewards.GetEarnedRewards()[0]+ _loginRewards.GetEarnedRewards()[1]+ _loginRewards.GetEarnedRewards()[2]);
        }
        /// <summary>
        /// 重複登入
        /// </summary>
        /// <param name="day"></param>
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void RepeatLogin(int day)
        {
            _loginRewards.Login(day);
            _loginRewards.Login(day);
            Assert.Single(_loginRewards.GetLoggedInDays());
            //只能有1個獎勵
            Assert.Single(_loginRewards.GetEarnedRewards());
        }
        /// <summary>
        /// 邊界測試
        /// </summary>
        /// <param name="day"></param>
        [Theory]
        [InlineData(0)]
        [InlineData(4)]
        public void LoginOtherDay(int day) 
        {
            _loginRewards.Login(day);
            Assert.Empty(_loginRewards.GetLoggedInDays());
            Assert.Empty(_loginRewards.GetEarnedRewards());
        }
    }
}
