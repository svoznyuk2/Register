namespace Register.Models
{
	public class Item
	{
		public decimal Price { get; set; }
		public string DepartmentCode { get; set; }
		public string Description { get; set; }
		public int ItemId { get; set; }
		public decimal ExtendedPrice { get; set; }
		public bool HasDiscount { get; set; }
	}
}
