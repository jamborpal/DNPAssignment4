using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNPAssignment3.ContextClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Models;

namespace Assignment2.Data
{
    public class AdultDataService:IAdultService
    {
        private AdultContext adultContext;

        public AdultDataService(AdultContext adultContext)
        {
            this.adultContext = adultContext;
        }
        public async Task<IList<Adult>> GetAdultsAsync()
        {
            return await adultContext.Adults.ToListAsync();
        }

        public async Task<Adult> AddAdultAsync(Adult adult)
        {
            EntityEntry<Adult> newAdult = await adultContext.Adults.AddAsync(adult);
            await adultContext.SaveChangesAsync();
            return newAdult.Entity;
        }

        public async Task RemoveAdultAsync(int id)
        {
            Adult toDelete = await adultContext.Adults.FirstOrDefaultAsync(t => t.Id == id);
            if (toDelete != null)
            {
                adultContext.Adults.Remove(toDelete);
                await adultContext.SaveChangesAsync();
            }
        }

        public void EditAdult()
        {
            throw new System.NotImplementedException();
        }
    }
}