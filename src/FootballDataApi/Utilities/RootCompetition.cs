﻿using FootballDataApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballDataApi.Utilities
{
    public class RootCompetition : RootApi
    {
        public IEnumerable<Competition> Competitions { get; set; }
    }
}
