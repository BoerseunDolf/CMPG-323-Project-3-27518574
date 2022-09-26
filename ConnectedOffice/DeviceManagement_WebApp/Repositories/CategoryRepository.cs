﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
namespace DeviceManagement_WebApp.Repositories
{
    public class CategoryRepository 
    {
        private readonly ConnectedOfficeContext _context;

        public CategoryRepository(ConnectedOfficeContext context)
        {
            _context = context;
        }

        // GET: Categories
        public async Task<List<Category>> GetCategoryListAsync()
        {
            return await _context.Category.ToListAsync();
        }

        // GET: Categories/Details/5
        public async Task<Category> GetDetailAsync(Guid? id)
        {
            return await _context.Category
                .FirstOrDefaultAsync(m => m.CategoryId == id);
        }

        public async void CreateCategory(Category category)
        {
            category.CategoryId = Guid.NewGuid();
            _context.Add(category);
            await _context.SaveChangesAsync();
        }

        // GET: Categories/Edit/5
        public async Task<Category> FindAsync(Guid? id)
        {
            return await _context.Category.FindAsync(id);
        }

        public async void EditAsync(Guid id, Category category)
        {
            try
            {
                _context.Update(category);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
               throw;
            }
        }

        // GET: Categories/Delete/5
        public async void DeleteAsync(Guid? id)
        {
            
            var category = await _context.Category
                .FirstOrDefaultAsync(m => m.CategoryId == id);

            _context.Remove(category);
            await _context.SaveChangesAsync();
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async void DeleteConfirmedAsync(Guid id)
        {
            var category = await _context.Category.FindAsync(id);
            _context.Category.Remove(category);
            await _context.SaveChangesAsync();
        }

    }
}
