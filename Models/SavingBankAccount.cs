using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
     class SavingBankAccount : BankAccount
     {
          public SavingBankAccount()
               : base()
          {
          }

          public SavingBankAccount(string title, double openingBalance)
               : base(title, openingBalance, AccountType.Saving)
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
     }
}
