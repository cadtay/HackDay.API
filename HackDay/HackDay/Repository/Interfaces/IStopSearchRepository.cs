using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HackDay.Models;
using Microsoft.AspNetCore.Mvc;

namespace HackDay.Repository.Interfaces
{
    public interface IStopSearchRepository
    {
        Task<List<StopSearch>> GetStopSearches();
    }
}
