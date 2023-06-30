using Microsoft.EntityFrameworkCore;
using MyBookShop.Data;
using MyBookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookShop.Repository
{
    public class LanguageRepository
    {
        private readonly BookStoreContext _bookStoreContext = null;
        public LanguageRepository(BookStoreContext bookStoreContext)
        {
            _bookStoreContext = bookStoreContext;
        }

        public async Task<List<LanguageModel>> GetLanguages()
        {
            return await _bookStoreContext.Languages.Select(x=>new LanguageModel() {
            Id=x.Id,
            Name=x.Name,
            Description=x.Description
            }).ToListAsync();
        }
    }
}
