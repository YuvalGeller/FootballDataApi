using FootballDataApi;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FootballRequestConsole
{
    public class Program
    {
        private static object lockWrite = new object();

        public static void Main(string[] args)
        {
            var httpClient = new HttpClient();

            var apiKey  = "0cccc1f57ccf41dfbeec13653210c1b0";
            if (!string.IsNullOrEmpty(apiKey))
                httpClient.DefaultRequestHeaders.Add("X-Auth-Token", apiKey);
            
            var competitionController = CompetitionProvider.Create()
                .With(httpClient)
                .Build();

            var matchController = MatchProvider.Create()
                .With(httpClient)
                .Build();

            //GetCompetitions(competitionController);
            //GetCompetitionsWithFilter(competitionController);
            //GetCompetitionById(competitionController, 2019);
            //GetAllMatchOfCompetition(matchController, 2021);
            GetAllMatch(matchController);
            //GetMatchById(matchController, 200033);

            Console.ReadKey();
        }

        private static async void GetMatchById(MatchProvider matchController, int idMatch)
        {
            var match = await matchController.GetMatchById(idMatch);

            lock (lockWrite)
            {
                Console.WriteLine("### Get match by ID ###");
                Console.WriteLine(JsonConvert.SerializeObject(match));
                Console.WriteLine();
            }
        }

        private static async void GetAllMatch(MatchProvider matchController)
        {
            var matches = await matchController.GetAllMatches();

            lock (lockWrite)
            {
                Console.WriteLine("### All available matches ###");
                Console.WriteLine(JsonConvert.SerializeObject(matches));
                Console.WriteLine();
            }
        }

        private static async void GetAllMatchOfCompetition(MatchProvider matchController, int id)
        {
            //var matches = await matchController.GetAllMatchOfCompetition(id, "dateFrom", "2022-03-01", "dateTo", "2022-03-22");
            //var matches = await matchController.GetAllMatchOfCompetition(id, "status", "FINISHED");
            //var matches = await matchController.GetAllMatchOfCompetition(id, "dateFrom", "2021-03-01", "dateTo", "2021-03-22", "season", "2021");
            var matches = await matchController.GetAllMatchOfCompetition(id);

            lock (lockWrite)
            {
                Console.WriteLine("### All matches of competition ###");
                Console.WriteLine(JsonConvert.SerializeObject(matches));
                Console.WriteLine();
            }
        }

        private static async void GetCompetitionById(CompetitionProvider competitionController, int id)
        {
            var competition = await competitionController.GetCompetition(id);

            lock (lockWrite)
            {
                Console.WriteLine("### One particular competition ###");
                Console.WriteLine(JsonConvert.SerializeObject(competition));
                Console.WriteLine(); 
            }
        }

        private static async void GetCompetitions(CompetitionProvider competitionController)
        {
            var competitions = await competitionController.GetAvailableCompetition();

            lock (lockWrite)
            {
                Console.WriteLine("### All available competitions ###");
                Console.WriteLine(JsonConvert.SerializeObject(competitions));
                Console.WriteLine(); 
            }
        }

        private static async void GetCompetitionsWithFilter(CompetitionProvider competitionController)
        {
            var competitions = await competitionController.GetAvailableCompetitionByArea(2114);

            lock (lockWrite)
            {
                Console.WriteLine("### Competition of the area X ###");
                Console.WriteLine(JsonConvert.SerializeObject(competitions));
                Console.WriteLine(); 
            }
        }
    }
}
