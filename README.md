# Register
Simple Register Simulator

Attached is a very simple register application. Its two functions are add/remove items and recalculate the subtotal. Your goal is to modify the transaction model so that it can handle discounts. The specific discount we are going to tackle deals with what we will call “Department Code” (DC) discount. 
If an item DC matches that of the discount, the discount percent should be applied to the item. 
I’ve provided you with a number of test cases that you can use to build out your model. You can simply swap out “SaleEvents1” for “SaleEvents2” and “Items1” for “Items2” and so forth, you can even write your own if you want to. 

Acceptance criteria

The subtotal should reflect the discounted amount
The total discount should reflect the amount discounted
If an item has a discount applied print the discounted amount (difference between the item price and the sale price)
All prices should be rounded to 2 decimal points.

Bonus

An item can have multiple discounts
To load and compile the solution download <a>Visual Studio Community Edition</a>. The Register project is where you should spend most of your time, specifically the Transaction class. I’ve included a test project that you can use to speed up the debugging of the code. Look into nUnit and possibly download the visual test runner. 

Good luck! Don’t hesitate to reach out with any questions.
