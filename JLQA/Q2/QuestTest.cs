using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
namespace JLQA.Q2
{
    public class QuestTest
    {
        private readonly Quest _quest;
        public QuestTest()
        {
            _quest = new Quest();
        }
        /// <summary>
        /// A完成但B未完成
        /// </summary>
        [Fact]
        public void AIsCompleted_BNot()
        {
            _quest._questA = true;
            _quest._questB = false;
            Assert.Equal("D", _quest.GetQuest());
        }
        /// <summary>
        /// B完成但A未完成
        /// </summary>
        [Fact]
        public void BIsCompleted_ANot()
        {
            _quest._questA = false;
            _quest._questB = true;
            Assert.Equal("D", _quest.GetQuest());
        }
        /// <summary>
        /// A和B都完成
        /// </summary>
        [Fact]
        public void AAndBCompleted()
        {
            _quest._questA = true;
            _quest._questB = true;
            Assert.Equal("C", _quest.GetQuest());
        }
        /// <summary>
        /// A和B都未完成
        /// </summary>
        [Fact]
            
        public void AAndBNotCompleted()
        {
            _quest._questA = false;
            _quest._questB = false;
            Assert.Equal("D", _quest.GetQuest());
        }
    }
}
