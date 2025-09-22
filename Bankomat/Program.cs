namespace Bankomat
{
    using System;

    class Person                                    
    {                                               
        public string Name { get; }                 // Read-only property som sparar personens namn (kan bara läsas utifrån).
        public string PersonalNumber { get; }       // Read-only property som sparar personnumret (kan bara läsas utifrån).

        public Person(string name, string personalnumber)      // Konstruktor: en metod som körs när vi skapar en ny Person.
        {                                                      
            Name = name;                                        
            PersonalNumber = personalnumber;                    
        }                                           

}
    class BankAccount                               // Definierar en klass som representerar ett bankkonto.
    {                                               
        private decimal balance;                    
        public decimal Balance { get { return balance; } } 

        public BankAccount(decimal initial)        // Konstruktor som skapar ett konto med ett startsaldo.
        {                                           
            if (initial < 0) initial = 0;          
            balance = initial;                     // Sätter det privata saldot till startsaldot.
        }                                           

        public bool Deposit(decimal amount)      
        {                                          
            if (amount <= 0) return false;         // Om beloppet är 0 eller negativt avbryt och returnera false.
            balance += amount;                     
            return true;                           // Returnera true för att visa att insättningen lyckades.
        }                                           

        public bool Withdraw(decimal amount)       
        {                                           
            if (amount <= 0) return false;         
            if (amount > balance) return false;    
            balance -= amount;                     
            return true;                           // Returnera true för att visa att uttaget lyckades.
        }                                           
    }                                               
.
            }                                         
        }                                             .
    }                                                 

}
    

