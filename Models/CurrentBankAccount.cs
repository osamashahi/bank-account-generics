using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    class CurrentBankAccount: BankAccount
    {
          public CurrentBankAccount()
               :base()
          {
          }

          public CurrentBankAccount(string title, double openingBalance)
               :base(title, openingBalance, AccountType.Current)
          {
          }
          
          public override bool Withdraw(double amount)
          {
               if (!base.Withdraw(amount))
               {
                    return false;
               }
               CurrentBalance -= 10;
               return true;
          }

          public override bool Payin(double amount)
          {
               if (!base.Payin(amount))
               {
                    return false;
               }
               CurrentBalance -= 10;
               return true;
          }

          public override bool DeactivateAccount(string accountNumber)
          {
               if (string.IsNullOrEmpty(accountNumber))
               {
                    return false;
               }
               CurrentBalance -= 100;
               return true;
          }

          public override bool ActivateAccount(string accountNumber)
          {
               if (string.IsNullOrEmpty(accountNumber))
               {
                    return false;
               }
               CurrentBalance -= 500;
               return true;
          }
     }
}
