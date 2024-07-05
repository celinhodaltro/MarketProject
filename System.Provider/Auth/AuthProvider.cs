using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Entities;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace System.Provider.Auth
{
  public class AuthProvider 
  {
    private readonly ApplicationDbContext _context;

    public AuthProvider(ApplicationDbContext context)
    {
      _context = context;
    }

    public async Task<Account> GetAccountById(int id)
    {
      return await _context.Accounts.FindAsync(id);
    }


    public async Task<Account> GetAccountByLogin(string login)
    {
      return await _context.Accounts.FirstOrDefaultAsync(a => a.Login == login);
    }

    public async Task<Account> CreateAccount(Account account)
    {
      _context.Accounts.Add(account);
      await _context.SaveChangesAsync();
      return account;
    }

    public async Task<Account> UpdateAccount(Account account)
    {
      _context.Entry(account).State = EntityState.Modified;
      await _context.SaveChangesAsync();
      return account;
    }

    public async Task DeleteAccount(int id)
    {
      var account = await _context.Accounts.FindAsync(id);
      if (account != null)
      {
        _context.Accounts.Remove(account);
        await _context.SaveChangesAsync();
      }
    }
  }
}
