using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JLQA.Q3
{
    public class DoorGame
    {
        private decimal _initialScore = 1000;
        public decimal result;
        private int bouns = 0;
        public char option1 , option2;
        private bool endGame = false;
        public void Level_1()
        {
            while (true)
            {
                switch (option1)
                {
                    case 'a':
                        bouns += 500;
                        break;
                    case 'b':
                        _initialScore /= 2;
                        option1 = 'x';
                        continue;
                    case 'c':
                        endGame = true;
                        break;
                }
                break;
            }
            result = _initialScore + bouns;
        }
        public void Level_2()
        {
            while (true)
            {
                switch (option2)
                {
                    case 'a':
                        bouns += 500;
                        break;
                    case 'b':
                        _initialScore /= 2;
                        option2 = 'x';
                        continue;
                    case 'c':
                        break;
                }
                break;
            }
            result = _initialScore + bouns;
        }
    }
}
