# Catering System Software - Overview

My software development bootcamp (Tech Elevator) tasked my classmate Merritt Weirick and myself with developing an application for a catering vendor.  

The goal was to design a console application that could be integrated with the customer’s bank accounts to allow customers to order catering products from their computers. This was assigned about a third of the way through our program and allowed us to apply all the object oriented programming, c# fundamentals, file I/O reading/writing, and unit test skills we'd been learning.

## Technologies Used

- C#/.NET

- .csv file

- .txt file


## Application Features

- Catering System tracks four different types of products (beverages, entrees, appetizers, and desserts). It initially stocks the inventory of all items along with their respective names and prices by reading the "cateringSystemInventorySource.csv" file (see Setup below). The csv lists the following properties: Type|Code|Name|Price.

- Displays a Main Menu and an Order Menu with clear instructions allowing users to easily interact.
        
- All item quantities are initially set to 10 items and automatically restock upon restarting the program.

- Via the Main Menu, user can Display Catering Items to see all available products along with their product code identifier, name, purchase price, and quantity. Here the user may also access the Order Menu or Quit the program.

- Via the Order Menu, user can Add Money to their account in whole dollar increments up to a maximum of $1000 and can see their current balance. 

- Via the Order Menu, user is also able to Select Products to purchase a given quantity of a product provided that enough inventory is available and user has sufficient funds. User can add to their balance and/or purchase items an indefinite number of times before selecting Complete Transaction.

- Via the Order Menu, user may Complete Transaction to print a report of all purchased items, their respective quantities and prices, and the total amount spent. Complete Transaction also returns user to the Main Menu and prints a list describing how their change will be refunded.

- As per the assignment's requirements, the user's change is returned using nickels, dimes, quarters, ones, fives, tens, and twenties (using the smallest amount of bills and coins possible). Their balance is simultaneously updated to $0.

- If and when user makes an error (tries to deposit more than $1000 into account, attempts a purchase without sufficient funds, attempts to purchase more than the quantity available for a given item, etc) a specific error message instructing the user is printed to the console.
  
- All transactions (adding money, purchasing items, receiving change) are written to a log, the "cateringLog.txt" file (see Setup below). These audit entries include the date, time, action taken, and new customer balance.

- Unit tests were written to demonstrate that the catering system works as expected. The process of writing these unit tests significantly helped our team's development of this application, as we were able to troubleshoot issues and better understand the way our code was behaving throughout the process, resulting in a much better designed final product.

## Setup

- In your C: drive, create a new directory called "Catering"

- Move both the "cateringSystemInventorySource.csv" and "cateringSystemLog.txt" files to your new "Catering" directory.

- That's it! Opening and running the program should allow you to interact via the console as intended.
