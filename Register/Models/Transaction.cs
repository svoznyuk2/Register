using System.Collections.Generic;
using System.Linq;

namespace Register.Models
{
	public class Transaction
	{
		private readonly List<Discount> _discounts;
		public List<Item> Items;
		public decimal TotalDiscount { get; set; }
		public decimal SubTotal { get; set; }

		public Transaction(List<Discount> discounts)
		{
			_discounts = discounts;
			Items = new List<Item>();
		}

		public void AddItem(Item item)
		{
			Items.Add(item);
		}

		public void RemoveItem(int itemId)
		{
			var item = Items.FirstOrDefault(i => i.ItemId == itemId);
			if (item == null)
				return;

			Items.Remove(item);
		}
 
       
        //add code to calculate and sum discount
        public void RecalculateSubtotal()
        {
            decimal savings;
            decimal PercentAsDecimal;
            foreach (var item in Items) //check each item for discounts
            {
                foreach (var discount in _discounts) //check each discount
                {
                    if (item.DepartmentCode.Equals(discount.DepartmentCode)) //look for department match between item and discount
                    {
                        PercentAsDecimal = decimal.Multiply(discount.PercentOff, 0.01m);
                        savings = System.Math.Round(decimal.Multiply(item.Price, PercentAsDecimal), 2); //calculate savings due to discount - round to 2 decimal places
                        TotalDiscount += savings; //sum the total savings
                        item.Price = item.Price - savings; //reset the Price to the discounted price
                    }
                }
            }

            SubTotal = Items.Sum(x => x.Price);
        }


    }
}