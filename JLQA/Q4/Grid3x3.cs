using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JLQA.Q4
{
    public class Grid3x3
    {
        private Dictionary<string, int> _score = new Dictionary<string, int>
        {
            //1分
            {"123",1 },{"456",1 },{"789",1 },{"147",1 },{"258",1 },{"369",1 },
            //3分
            {"123,456",3 },{"123,789",3 },{"456,789",3 },{"147,258",3 },{"147,369",3 },{"258,369",3 },
            //5分
            {"123,456,789",5 },{"147,258,369",5 },
        };
        public int Play(string line)
        {
            int lastCommaIndex;
            while (true)
            {
                if (_score.ContainsKey(line))
                {
                    return _score[line];
                }
                else
                {
                    lastCommaIndex = line.LastIndexOf(",");
                    if (lastCommaIndex >= 0)
                    {
                        line = line.Remove(lastCommaIndex);
                    }
                }
            }
        }
    }
}
