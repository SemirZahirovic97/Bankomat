namespace Bankomat
{
    using System;

    class Person                                    
    {                                               
        public string Name { get; }                 // Read-only property som sparar personens namn (kan bara läsas utifrån).
        public string PersonalNumber { get; }       // Read-only property som sparar personnumret (kan bara läsas utifrån).

        public Person(string name, string personalnumber)      // Konstruktor: en metod som körs när vi skapar en ny Person.
        {                                                      
            Name = name;                                        // Sätter klassens Name till värdet som skickades in.
            PersonalNumber = personalnumber;                    // Sätter klassens PersonalNumber till värdet som skickades in.
        }                                           

}                                     .
            }                                         
        }                                             .
    }                                                 

}
    

