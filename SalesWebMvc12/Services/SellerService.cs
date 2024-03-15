using Microsoft.EntityFrameworkCore;
using SalesWebMvc12.Data;
using SalesWebMvc12.Models;
using SalesWebMvc12.Services.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMvc12.Services
{
    public class SellerService
    {
        private readonly SalesWebMvc12Context _context;

        public SellerService(SalesWebMvc12Context context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        public void Insert(Seller seller)
        {
            _context.Add(seller);
            _context.SaveChanges();
        }
        public void Remove(int id)
        {
            Seller seller = _context.Seller.Find(id);
            _context.Seller.Remove(seller);
            _context.SaveChanges();
        }

        public Seller FindById(int id)
        {
            return _context.Seller.Include(x => x.Department).FirstOrDefault(x => x.Id == id);
        }

        public void Update(Seller seller)
        {
            if (!_context.Seller.Any(x => seller.Id == x.Id))
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(seller);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }    
    }
}
