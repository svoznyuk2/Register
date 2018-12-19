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

		public void RecalculateSubtotal()
		{
			SubTotal = Items.Sum(x => x.Price);
		}

	}
}
