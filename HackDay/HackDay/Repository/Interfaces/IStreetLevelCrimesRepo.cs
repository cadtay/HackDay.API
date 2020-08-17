using HackDay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackDay.Repository.Interfaces
{
    public interface IStreetLevelCrimesRepo
    {
        // Task<StreetLevelCrimes[]> GetAllStreetLevelCrimesByLocation();
        Task<StreetLevelCrimes[]> GetAllStreetLevelCrimesByLocationAndTime(string date);
        // Task<StreetLevelCrimes[]> GetAllStreetLevelCrimesByLocationAndCategory(string category);
        // Task<StreetLevelCrimes[]> GetAllStreetLevelCrimesByLocationAndCategoryAndTime(string category, string date);
        Task<StreetLevelCrimes> GetStreetLevelCrimeById(int id);

        // LOCATIO
    }
}
