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
            //由於當i非常大時會因為有效數字的問題而直接顯示0 所以只驗證在有效數字內的次數
            for (int i = 0; i < 80; i++) {
                _game.option1 = 'b';
                _game.Level_1();
            }
            //result趨近於0但是不為0
            Assert.True(_game.result > 0);
            _game.option1 = 'a';
            _game.Level_1();
            //經過無數次選擇b 最後的結果趨近於a所帶來的獎勵
            Assert.True(_game.result > 500 && _game.result <501);
            //第二關再次選擇無數次b
            for (int i = 0; i < 80; i++)
            {
                _game.option2 = 'b';
                _game.Level_2();
            }
            //由於初始獎勵有效數字已經超出decimal的精確度了 趨近於0直接捨入變成0
            Assert.True(_game.result == 500);
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
