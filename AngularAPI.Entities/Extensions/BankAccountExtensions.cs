using AngularAPI.Entities.Models;

namespace AngularAPI.Entities.Extensions
{
    /// <summary>
    /// The static <see cref="BankAccountExtensions"/>, extension class helps to map <see cref="Map"/> 
    /// the same two <see cref="BankAccount"/> object entities to each other, for further processing.
    /// </summary>
    public static class BankAccountExtensions
    {
        public static void Map(this BankAccount dbBankAccount, BankAccount bankaccount)
        {
            dbBankAccount.ID = bankaccount.ID;
            dbBankAccount.CreatedDateTime = bankaccount.CreatedDateTime;
            dbBankAccount.ClientNumber = bankaccount.ClientNumber;
            dbBankAccount.AccountName = bankaccount.AccountName;
            dbBankAccount.AccountBalance = bankaccount.AccountBalance;
        }
    }
}
