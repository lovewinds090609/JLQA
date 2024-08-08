using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
namespace JLQA.Q3
{
    public class DoorGameTest
    {
        DoorGame _game;
        public DoorGameTest()
        {
            _game = new DoorGame();
        }
        /// <summary>
        /// 第一關選a第二關選a
        /// </summary>
        [Fact]
        public void AAndA()
        {
            _game.option1 = 'a';
            _game.Level_1();
            Assert.Equal(1500,_game.result);
            _game.option2 = 'a';
            _game.Level_2();
            Assert.Equal(2000, _game.result);
        }
        /// <summary>
        /// 第一關選a第二關選b後重選a
        /// </summary>
        [Fact]
        public void AAndBAndA()
        {
            _game.option1 = 'a';
            _game.Level_1();
            Assert.Equal(1500, _game.result);
            _game.option2 = 'b';
            _game.Level_2();
            Assert.Equal(1000, _game.result);
            _game.option2 = 'a';
            _game.Level_2();
            Assert.Equal(1500, _game.result);
        }
        /// <summary>
        /// 第一關選a第二關選b後重選c
        /// </summary>
        [Fact]
        public void AAndBAndC()
        {
            _game.option1 = 'a';
            _game.Level_1();
            Assert.Equal(1500, _game.result);
            _game.option2 = 'b';
            _game.Level_2();
            Assert.Equal(1000, _game.result);
            _game.option2 = 'c';
            _game.Level_2();
            Assert.Equal(1000, _game.result);
        }
        /// <summary>
        /// 第一關選b後重選a 第二關選a
        /// </summary>
        [Fact]
        public void BAndAAndA()
        {
            _game.option1 = 'b';
            _game.Level_1();
            Assert.Equal(500, _game.result);
            _game.option1 = 'a';
            _game.Level_1();
            Assert.Equal(1000, _game.result);
            _game.option2 = 'a';
            _game.Level_2();
            Assert.Equal(1500, _game.result);
        }
        /// <summary>
        /// 第一關選b後重選a 第二關選c
        /// </summary>
        [Fact]
        public void BAndAAndC()
        {
            _game.option1 = 'b';
            _game.Level_1();
            Assert.Equal(500, _game.result);
            _game.option1 = 'a';
            _game.Level_1();
            Assert.Equal(1000, _game.result);
            _game.option2 = 'c';
            _game.Level_2();
            Assert.Equal(1000, _game.result);
        }
        /// <summary>
        /// 第一關選b第二關選c
        /// </summary>
        [Fact]
        public void BAndC()
        {
            _game.option1 = 'b';
            _game.Level_1();
            Assert.Equal(500, _game.result);
            _game.option2 = 'c';
            _game.Level_2();
            Assert.Equal(500, _game.result);
        }
        /// <summary>
        /// 驗證選擇b非常多次分數是否大於0
        /// </summary>
        [Fact]
        public void BPowerN()
        {
            for (int i = 0; i < 1000; i++) {
                _game.option1 = 'b';
                _game.Level_1();
            }
            Assert.True(_game.result > 0);
        }
        /// <summary>
        /// 第一關選c
        /// </summary>
        [Fact]
        public void C()
        {
            _game.option1 = 'c';
            _game.Level_1();
            Assert.Equal(1000, _game.result);
        }
    }
}
