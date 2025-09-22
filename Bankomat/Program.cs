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
            int attempts = 0;                       // Variabel som räknar hur många PIN-försök som gjorts.
            Customer loggedInCustomer = null;


            while (attempts < 3 && loggedInCustomer == null) // Loop som körs tills användaren är inloggad eller har gjort 3 försök.
            {
                Console.Clear();                    // Rensar konsolfönstret
                Console.WriteLine("=== Välkommen till bankomaten ===");
                Console.WriteLine();
                Console.Write("Ange 4-siffrig PIN: ");
                string inputPin = Console.ReadLine();

                foreach (Customer c in customers)    // Startar en loop som går igenom varje kund i customers-arrayen.
                {
                    if (c.Authenticate(inputPin))   // Anropar Authenticate på varje kund för att se om PIN matchar.
                    {
                        loggedInCustomer = c;
                        break;
                    }
                }

                if (loggedInCustomer == null)
                {                                   // Början av if-sats för fel PIN.
                    attempts++;
                    if (attempts >= 3)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Fel PIN. För många misslyckade försök. Avslutar."); // Meddela att programmet avslutas.
                        return;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Fel PIN. Försök igen."); // Skriv ett felmeddelande.
                        Console.WriteLine("Tryck valfri tangent för att försöka igen...");
                        Console.ReadKey();
                    }
                }
            }


            Console.Clear();
            Console.WriteLine("Välkommen " + loggedInCustomer.Person.Name + "!"); // Välkomstmeddelande med kundens namn.
            Console.WriteLine("Tryck valfri tangent för att gå vidare till menyn...");
            Console.ReadKey();

            // --- Huvudmeny ---
            while (true)                             // Oändlig loop som visar menyn tills användaren väljer att avsluta.          
            {                                       
                Console.Clear();                    
                Console.WriteLine("=== Bankomatmeny ==="); 
                Console.WriteLine("Inloggad som: " + loggedInCustomer.Person.Name); // Visa namnet på den inloggade kunden.
                Console.WriteLine();                
                Console.WriteLine("1) Sätt in pengar"); 
                Console.WriteLine("2) Ta ut pengar");  
                Console.WriteLine("3) Visa saldo");    
                Console.WriteLine("4) Avsluta");       
                Console.Write("Välj (1-4): ");         
                string val = Console.ReadLine();       

                if (val == "1")                       
                {                                     
                    Console.WriteLine();              
                    Console.Write("Ange belopp att sätta in: ");
                    string s = Console.ReadLine();    
                    if (decimal.TryParse(s, out decimal amount)) // Försök konvertera texten till ett decimaltal.
                    {                                 
                        if (amount <= 0)              // Kontrollera att beloppet är större än 0.
                        {                             
                            Console.WriteLine("Belopp måste vara större än 0."); 
                        }                            
                        else                          
                        {                             
                            bool ok = loggedInCustomer.Account.Deposit(amount); 
                            if (ok)                    
                                Console.WriteLine("Insättning lyckades. Nytt saldo: " + loggedInCustomer.Account.Balance); // Visa bekräftelse och nytt saldo.
                            else                       
                                Console.WriteLine("Insättning misslyckades."); 
                        }                             
                    }                                 
                    else                              
                    {                                 
                        Console.WriteLine("Ogiltigt belopp. Skriv bara siffror."); 
                    }                                 

                    Console.WriteLine();              
                    Console.WriteLine("Tryck valfri tangent för att återgå till menyn..."); 
                    Console.ReadKey();                
                }                                     
                else if (val == "2")                  
                {                                     
                    Console.WriteLine();             
                    Console.Write("Ange belopp att ta ut: "); 
                    string s = Console.ReadLine();    
                    if (decimal.TryParse(s, out decimal amount)) 
                    {                                 
                        if (amount <= 0)              
                        {                             
                            Console.WriteLine("Belopp måste vara större än 0."); 
                        }                           
                        else if (amount > loggedInCustomer.Account.Balance) // Om beloppet är större än saldot:
                        {                             
                            Console.WriteLine("Du har inte tillräckligt saldo."); 
                        }                             
                        else                          
                        {                          
                            bool ok = loggedInCustomer.Account.Withdraw(amount); 
                            if (ok)                    // Om Withdraw returnerade true:
                                Console.WriteLine("Uttag lyckades. Nytt saldo: " + loggedInCustomer.Account.Balance); // Visa bekräftelse och nytt saldo.
                            else                       // Om Withdraw returnerade false
                                Console.WriteLine("Uttag misslyckades."); // Visa fel.
                        }                             
                    }                                 
                    else                              
                    {                                 
                        Console.WriteLine("Ogiltigt belopp. Skriv bara siffror."); 
                    }                                 

                    Console.WriteLine();              
                    Console.WriteLine("Tryck valfri tangent för att återgå till menyn..."); 
                    Console.ReadKey();                
                }                                     
                else if (val == "3")                  
                {                                     
                    Console.WriteLine();              
                    Console.WriteLine("Ditt saldo är: " + loggedInCustomer.Account.Balance); // Skriver ut det aktuella saldot.
                    Console.WriteLine();              
                    Console.WriteLine("Tryck valfri tangent för att återgå till menyn..."); 
                    Console.ReadKey();                
                }                                     
                else if (val == "4")                  
                {                                     
                    Console.Clear();                  
                    Console.WriteLine("Hejdå " + loggedInCustomer.Person.Name + "!"); // Skriv hejdå meddelande med kundens namn.
                    break;                            
                }                                     
                else                                  
                {                                     
                    Console.WriteLine();           
                    Console.WriteLine("Ogiltigt val, försök igen.");
                    Console.WriteLine("Tryck valfri tangent för att återgå till menyn..."); 
                    Console.ReadKey();
                }
            }
        }


            }                                         
        }                                             
                                                     


    

