using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JLQA.Q1
{
    public class LoginRewards
    {
        private HashSet<int> _loggedInDays = new HashSet<int>();
        private Dictionary<int, string> _rewards = new Dictionary<int, string>
        {
            { 1,"A"},{2,"B"}, {3,"C"}
        };
        private List<string> _earnedRewards = new List<string>();

        public void Login(int day)
        {
            if (day < 1 || day > 3 || _loggedInDays.Contains(day)) return;
            _loggedInDays.Add(day);
            if (_rewards.ContainsKey(day))
            {
                _earnedRewards.Add(_rewards[day]);
            }
        }
        public HashSet<int> GetLoggedInDays()
        {
            return _loggedInDays;
        }
        public List<string> GetEarnedRewards()
        {
            return _earnedRewards;
        }
    }
}