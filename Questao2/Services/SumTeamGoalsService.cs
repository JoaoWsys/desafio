using Questao2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questao2.Services
{
    internal class SumTeamGoalsService
    {
        public int TotalGoals { get; set; } = 0;

        internal int TotalTeamGoalsHome(List<Match> matches)
        {
            foreach (Match match in matches)
            {
                if (int.TryParse(match.team1goals, out int matchGoals))
                {
                    TotalGoals += matchGoals;
                }
            }
            return TotalGoals;
        }

        internal int TotalTeamGoalsAway(List<Match> matches)
        {
            foreach (Match match in matches)
            {
                if (int.TryParse(match.team2goals, out int matchGoals))
                {
                    TotalGoals += matchGoals;
                }
            }
            return TotalGoals;
        }
    }
}
