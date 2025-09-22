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
    class Customer                                  
    {                                               
        public Person Person { get; }               
        public BankAccount Account { get; }         
        public string Pin { get; }                  // Read-only property som sparar kundens PIN-kod.

        public Customer(Person person, BankAccount account, string pin) // Konstruktor som skapar en Customer.
        {                                           
            Person = person;                        
            Account = account;                      
            Pin = pin;                              // Sparar PIN-koden för kunden.
        }                                           

        public bool Authenticate(string pin)        // Metod som kontrollerar om en inmatad PIN matchar kundens PIN.
        {                                           
            return pin == Pin;                      // Jämför inmatad PIN med lagrad PIN och returnerar true/false.
        }                                           
    }                                               

    class Program                                   
    {                                               
        static void Main()                           
        {                                           
                                                    // Skapa några hårdkodade kunder med olika PIN-koder.
            Customer[] customers = new Customer[] { 
          new Customer(new Person("Anna Andersson", "19900101-1234"), new BankAccount(1000m), "1234"), // Skapar kund 1 med namn, personnummer, konto och PIN.
          new Customer(new Person("Erik Svensson", "19850505-5678"), new BankAccount(500m), "5678"),  // Skapar kund 2.
          new Customer(new Person("Lisa Karlsson", "19951212-0001"), new BankAccount(250m), "0001")   // Skapar kund 3.
      };                                      

.
            }                                         
        }                                             .
    }                                                 

}
    

