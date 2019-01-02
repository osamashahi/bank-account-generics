using System;
using System.Text.RegularExpressions;

namespace Models
{
    public class BankAccount
    {

          public BankAccount()
          {
               AccountNumber = Guid.NewGuid();
               CreatedDate = DateTime.UtcNow.AddHours(5);
               AccountStatus = AccountStatus.Active;
          }

          public BankAccount(string title, double openingBalance, AccountType accountType)
               :this()
          {
               AccountTitle = title;
               OpeningBalance = openingBalance;
               CurrentBalance = openingBalance;
               AccountType = accountType;
          }

          private string accountTitle;

          public string AccountTitle
          {
               get { return accountTitle; }
               set
               {
                    if (!Regex.IsMatch(value, @"^[a-zA-Z]+$"))
                    {
                         throw new Exception("Invalid account title.");
                    }
                    accountTitle = value;
               }
          }

          public Guid AccountNumber { get; private set; }

          public AccountType AccountType { get; protected set; }

          public AccountStatus AccountStatus { get; private set; }

          public DateTime CreatedDate { get; private set; }

          public double CurrentBalance { get; protected set; }

          private double openingBalance;

          public double OpeningBalance
          {
               get { return openingBalance; }
               set
               {
                    if (value < 1000)
                    {
                         throw new Exception("Opening balance cannot be less than Rs. 1000");
                    }
                    openingBalance = value;
               }
          }

          public virtual bool Withdraw(double amount)
          {
               if (CurrentBalance < amount)
               {
                    return false;
               }
               CurrentBalance -= amount;
               return true;
          }

          public virtual bool Payin(double amount)
          {
               if (amount <= 0)
               {
                    return false;
               }
               CurrentBalance += amount;
               return true;
          }
     }
}
