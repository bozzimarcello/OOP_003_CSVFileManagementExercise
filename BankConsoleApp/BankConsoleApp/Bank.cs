using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp
{
    public class Bank
    {
        // 
        // Collezione di conti correnti
        //
        private List<BankAccount> _accounts;

        //
        // Costruttore
        //
        public Bank()
        {
            // DA FARE: Inizializza la collezione di conti correnti
        }

        //
        // Metodi pubblici
        //
        
        public List<BankAccount> GetAccounts() 
        { 
            // DA FARE: Restituisci la collezione di conti correnti
        }

        public void AddAccount(BankAccount account)
        {
            // DA FARE: verificare che l'account non sia nullo
            // altrimenti solleva un'eccezione ArgumentNullException

            // DA FARE: Aggiungi un conto corrente alla collezione
        }

        public void RemoveAccount(BankAccount account)
        {
            // DA FARE: verificare che l'account non sia nullo
            // altrimenti solleva un'eccezione ArgumentNullException

            // DA FARE: verificare che l'account esista nella collezione
            // altrimenti solleva un'eccezione InvalidOperationException

            // DA FARE: Rimuovi un conto corrente dalla collezione
        }

        public double GetTotalBalance()
        {
            // DA FARE: Calcola il saldo totale di tutti i conti correnti
        }

    }
}

