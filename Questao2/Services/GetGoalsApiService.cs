using Newtonsoft.Json;
using Questao2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Questao2.Services
{
    public class GetGoalsApiService
    {
        readonly HttpClient _client = new HttpClient();
        public GetGoalsApiService(HttpClient client)
        {
            _client = client;
        }

        internal int TotalTeamGoals(int year, string team)
        {
            var totalGoals = GetTeamGoals(year, team) + GetTeamGoals(year, team, false);
            return totalGoals;
        }

        private int GetTeamGoals(int year, string team, bool isHomeTeam = true)
        {
            List<Match> matches = new();
            var goals = 0;
            var serviceGoalsSum = new SumTeamGoalsService();


            var MatchFirstPage = isHomeTeam ? HackerrankApiSearchGoals(year, team).Result : HackerrankApiSearchGoals(year, team, 1, false).Result;
            if (MatchFirstPage != "" && MatchFirstPage != null)
            {
                var firstPage = JsonConvert.DeserializeObject<Header>(MatchFirstPage);
                if (firstPage != null)
                {
                    foreach (var match in firstPage.data)
                    {
                        matches.Add(match);
                    }
                    if (firstPage.total_pages > 1)
                    {
                        for (int i = 2; i <= firstPage.total_pages; i++)
                        {
                            var MatchCurrentPage = isHomeTeam ? HackerrankApiSearchGoals(year, team, i).Result : HackerrankApiSearchGoals(year, team, i, false).Result;
                            if (MatchCurrentPage != "" && MatchCurrentPage != null)
                            {
                                var currentPage = JsonConvert.DeserializeObject<Header>(MatchCurrentPage);
                                if (currentPage != null)
                                {
                                    foreach (var match in currentPage.data)
                                    {
                                        matches.Add(match);
                                    }
                                }
                            }
                        }
                    }
                    goals = isHomeTeam ? serviceGoalsSum.TotalTeamGoalsHome(matches) : serviceGoalsSum.TotalTeamGoalsAway(matches);
                }
            }
            return goals;
         }

        private async Task<string> HackerrankApiSearchGoals(int year, string team, int page = 1, bool isHomeTeam = true)
        {
             var jsonContent = "";
             if (isHomeTeam)
             {
                HttpResponseMessage response = await _client.GetAsync($"https://jsonmock.hackerrank.com/api/football_matches?year={year}&team1={team}&page={page}");
                if (response.IsSuccessStatusCode) jsonContent = await response.Content.ReadAsStringAsync();
                return jsonContent;
             }
             else
                {
                    HttpResponseMessage response = await _client.GetAsync($"https://jsonmock.hackerrank.com/api/football_matches?year={year}&team2={team}&page={page}");
                    if (response.IsSuccessStatusCode) jsonContent = await response.Content.ReadAsStringAsync();
                    return jsonContent;
                }
            }
        }
    }
