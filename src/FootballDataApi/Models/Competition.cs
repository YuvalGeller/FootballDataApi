using System;
using System.Collections.Generic;
using System.Text;

namespace FootballDataApi.Models
{
    public class Competition
    {
        public int Id { get; set; }
        public Area Area { get; set; }
        public string Name { get; set; }
        public object Code { get; set; }
        public string Plan { get; set; }
        public Season CurrentSeason { get; set; }
        public IEnumerable<Season> Seasons { get; set; }
        public int NumberOfAvailableSeasons { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
