using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JLQA.Q2
{
    public class Quest
    {
        public bool _questA {  get; set; }
        public bool _questB {  get; set; }
        public string GetQuest()
        {
            if (_questA && _questB)
            {
                return "C";
            }
            else
            {
                return "D";
            }
        }
    }
}
