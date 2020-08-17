using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HackDay.Modals;

namespace HackDay.Repository.Interfaces
{
    public interface IFloodRepository
    {
        Task<Flood> GetFloodAsync(FloodViewModel floodModel);
    }
}
