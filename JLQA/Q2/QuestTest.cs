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
        [Fact]
        public void AIsCompleted_BNot()
        {
            _quest._questA = true;
            _quest._questB = false;
            Assert.Equal("D", _quest.GetQuest());
        }
        [Fact]
        public void BIsCompleted_ANot()
        {
            _quest._questA = false;
            _quest._questB = true;
            Assert.Equal("D", _quest.GetQuest());
        }
        [Fact]
        public void AAndBCompleted()
        {
            _quest._questA = true;
            _quest._questB = true;
            Assert.Equal("C", _quest.GetQuest());
        }
        [Fact]
            
        public void AAndBNotCompleted()
        {
            _quest._questA = false;
            _quest._questB = false;
            Assert.Equal("D", _quest.GetQuest());
        }
    }
}
