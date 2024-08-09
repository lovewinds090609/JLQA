using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static System.Formats.Asn1.AsnWriter;
namespace JLQA.Q4
{
    public class Grid3x3Test
    {
        Grid3x3 _grid3X3;
        //於有效得分測試案例累積分數
        private static int totalScore = 0;
        public Grid3x3Test()
        {
            _grid3X3 = new Grid3x3 ();
        }
        /// <summary>
        /// 1分組合
        /// </summary>
        /// <param name="line"></param>
        /// <param name="exceptScore"></param>
        [Theory]
        [InlineData("123",1)]
        [InlineData("456",1)]
        [InlineData("789",1)]
        [InlineData("147",1)]
        [InlineData("258",1)]
        [InlineData("369",1)]
        public void OnePoint(string line , int exceptScore)
        {
            int score = _grid3X3.Play(line);
            Assert.Equal(exceptScore, score);
            totalScore += score;
        }
        /// <summary>
        /// 3分組合
        /// </summary>
        /// <param name="line"></param>
        /// <param name="exceptScore"></param>
        [Theory]
        [InlineData("123,456", 3)]
        [InlineData("123,789", 3)]
        [InlineData("456,789", 3)]
        [InlineData("147,258", 3)]
        [InlineData("147,369", 3)]
        [InlineData("258,369", 3)]
        public void TwoPoints(string line, int exceptScore)
        {
            int score = _grid3X3.Play(line);
            Assert.Equal(exceptScore, score);
            totalScore += score;
        }
        /// <summary>
        /// 5分組合
        /// </summary>
        /// <param name="line"></param>
        /// <param name="exceptScore"></param>
        [Theory]
        [InlineData("123,456,789", 5)]
        [InlineData("147,258,369", 5)]
        public void ThreePoints(string line, int exceptScore)
        {
            int score = _grid3X3.Play(line);
            Assert.Equal(exceptScore, score);
            totalScore += score;
        }
        /// <summary>
        /// 1分組合但是有重疊線
        /// </summary>
        /// <param name="line"></param>
        /// <param name="exceptScore"></param>
        [Theory]
        [InlineData("123,147", 1)]
        [InlineData("123,258", 1)]
        [InlineData("123,369", 1)]
        public void OnePointButRepeatLine(string line, int exceptScore)
        {
            int score = _grid3X3.Play(line);
            Assert.Equal(exceptScore, score);
        }
        /// <summary>
        /// 3分組合但是有重疊線
        /// </summary>
        /// <param name="line"></param>
        /// <param name="exceptScore"></param>
        [Theory]
        [InlineData("123,456,147", 3)]
        [InlineData("123,456,258", 3)]
        [InlineData("123,456,369", 3)]
        public void TwoPointButRepeatLine(string line, int exceptScore)
        {
            int score = _grid3X3.Play(line);
            Assert.Equal(exceptScore, score);
        }
        /// <summary>
        /// 5分組合但是有重疊線
        /// </summary>
        /// <param name="line"></param>
        /// <param name="exceptScore"></param>
        [Theory]
        [InlineData("123,456,789,147", 5)]
        [InlineData("123,456,789,258", 5)]
        [InlineData("123,456,789,369", 5)]
        [InlineData("123,456,789,147,258", 5)]
        [InlineData("123,456,789,147,369", 5)]
        [InlineData("123,456,789,258,369", 5)]
        public void ThreePointsButRepeatLine(string line, int exceptScore)
        {
            int score = _grid3X3.Play(line);
            Assert.Equal(exceptScore, score);
        }
        /// <summary>
        /// 計算有效得分 34為手動計算
        /// </summary>
        [Fact]
        public void TotalScore()
        {
            Assert.Equal(34, totalScore);
        }
    }
}
