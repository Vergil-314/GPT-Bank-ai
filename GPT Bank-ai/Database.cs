using System.Collections.Generic;
using System.Security.Principal;
public static class Database
{
    private static List<Account> accounts = new List<Account>();

    public static Account GetAccountByUsername(string username)
    {
        return accounts.Find(a => a.Username == username);
    }

    public static void AddAccount(Account account)
    {
        accounts.Add(account);
    }
}
