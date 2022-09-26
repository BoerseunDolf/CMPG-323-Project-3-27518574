using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using DeviceManagement_WebApp.Repositories;
namespace DeviceManagement_WebApp.Repositories
{
    public class ZoneRepository
    {
        private readonly ConnectedOfficeContext _context;

        public ZoneRepository(ConnectedOfficeContext context)
        {
            _context = context;
        }

        // GET: Zones
        public async Task<List<Zone>> GetZoneListAsync()
        {
            return await _context.Zone.ToListAsync();
        }

        // GET: Zones/Details/5
        public async Task<Zone> GetDetailAsync(Guid? id)
        {
            return await _context.Zone
                .FirstOrDefaultAsync(m => m.ZoneId == id);
        }

        public async void CreateZone(Zone zone)
        {
            zone.ZoneId = Guid.NewGuid();
            _context.Add(zone);
            await _context.SaveChangesAsync();
        }

        // GET: Zones/Edit/5
        public async Task<Zone> FindAsync(Guid? id)
        {
            return await _context.Zone.FindAsync(id);
        }

        // POST: Zones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async void EditAsync(Guid id,Zone zone)
        {
            try
            {
                _context.Update(zone);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

        }

        // GET: Zones/Delete/5
        public async void DeleteAsync(Guid? id)
        {
            var zone = await _context.Zone
                .FirstOrDefaultAsync(m => m.ZoneId == id);

            _context.Remove(zone);
            await _context.SaveChangesAsync();
        }

        // POST: Zones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async void DeleteConfirmedAsync(Guid id)
        {
            var zone = await _context.Zone.FindAsync(id);
            _context.Zone.Remove(zone);
            await _context.SaveChangesAsync();
        }

    }
}
