Objective
Assess skills in OO analysis, system design and .Net programming. The task should be completed by agreed term and sent to Bondora.
The task – Online construction equipment rental
We want to create a self-service system for renting construction equipment.
This rental site has potential to become a multinational and multilingual platform with hundreds of thousands of users, so the system must be ready to accommodate growth and be scalable.
Use cases
A customer must be able to:
• See the list of equipment
• For individual machines, enter the number of days for how long he wishes to rent it, and click “Add to Cart”
• Get an invoice
Inventory
There are three types of equipment available:
• Heavy equipment
• Regular equipment
• Specialized equipment
Example:

Name
Type
Caterpillar bulldozer
Heavy
KamAZ truck
Regular
Komatsu crane
Heavy
Volvo steamroller
Regular
Bosch jackhammer
Specialized

Inventory can be static and stored in any convenient way (simple file is OK).
Price calculation
The price of rentals is based on equipment type and rental length.

There are three different fees:
• One-time rental fee – 100€
• Premium daily fee – 60€/day
• Regular daily fee – 40€/day

The price calculation for different types of equipment is:
• Heavy – rental price is one-time rental fee plus premium fee for each day rented.
• Regular – rental price is one-time rental fee plus premium fee for the first 2 days plus regular fee for the number of days over 2.
• Specialized – rental price is premium fee for the first 3 days plus regular fee times the number of days over 3.
Loyalty points
Customers get loyalty points when renting equipment. A heavy machine gives 2 points and other types give one point per rental (regardless of the time rented).
Invoice
Customers can ask for an invoice that must be generated as a text file.

The file must contain:
• Title
• Line items for every rental, displaying name and rental price
• Summary displaying total price and number of bonus points earned

Because of a legal requirement, the system must not store intermediate customer balances, only individual machine names. Prices and points must be calculated at the time of invoice generation.

Unit tests
Implement a set of unit tests that you think is reasonable for this application. Make sure they can be run inside Visual Studio.

Other considerations
Do not worry about user management for time being. Assuming a single user is fine for demonstration purposes.
Also, persistence is not mandatory. It is OK to keep the program state in memory only.
