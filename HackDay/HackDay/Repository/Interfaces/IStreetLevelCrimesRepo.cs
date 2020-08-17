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
        Task<StreetLevelCrimes[]> GetAllStreetLevelCrimesByLocationAndDate();
        // Task<StreetLevelCrimes[]> GetAllStreetLevelCrimesByLocationAndCategory(string category);
        Task<StreetLevelCrimes[]> GetAllStreetLevelCrimesByLocationAndCategoryAndTime();
        Task<StreetLevelCrimes> GetStreetLevelCrimeById(int id);
        Task<StreetLevelCrimeCategories[]> GetStreetLevelCrimeCategories();

    }
}
