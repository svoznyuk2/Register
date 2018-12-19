using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Register.Models;

namespace TransactionDiscountTest
{
	[TestFixture]
	public class Tests
	{
		public class SaleData
		{
			private static readonly List<Discount> Discount1 = new List<Discount>()
			{
				new Discount()
				{
					DepartmentCode = "101010",
					PercentOff = 10m
				},
				new Discount()
				{
					DepartmentCode = "101112",
					PercentOff = 15m
				}
			};

			private static readonly List<Discount> Discount2 = new List<Discount>()
			{
				new Discount()
				{
					DepartmentCode = "101010",
					PercentOff = 10m
				}
			};

			private static readonly List<Discount> Discount3 = new List<Discount>()
			{
				new Discount()
				{
					DepartmentCode = "101030",
					PercentOff = 10m
				}
			};

			private static readonly List<Discount> Discount4 = new List<Discount>()
			{
				new Discount()
				{
					DepartmentCode = "202030",
					PercentOff = 50m
				}
			};

			private static readonly List<Item> Items1 = new List<Item>()
			{
				new Item {
					Price = 25m,
					DepartmentCode = "101010",
					Description = "Book1",
					ItemId = 1
				},
				new Item {
					Price = 10.99m,
					DepartmentCode = "101112",
					Description = "Book2",
					ItemId = 2
				},
				new Item {
					Price = 12.00m,
					DepartmentCode = "101112",
					Description = "Book3",
					ItemId = 3
				}
			};

			private static readonly List<Item> Items2 = new List<Item>()
			{
				new Item()
				{
					Price = 20m,
					DepartmentCode = "101010",
					Description = "Book4",
					ItemId = 4
				},
				new Item()
				{
					Price = 10,
					DepartmentCode = "202020",
					Description = "Book5",
					ItemId = 5
				}
			};

			private static readonly List<Item> Items3 = new List<Item>()
			{
				new Item()
				{
					Price = 20m,
					DepartmentCode = "101030",
					Description = "Book6",
					ItemId = 6
				},
				new Item()
				{
					Price = 10,
					DepartmentCode = "202030",
					Description = "Book7",
					ItemId = 7
				}
			};

			public static IEnumerable TestCases
			{
				get
				{
					yield return new TestCaseData(Discount1, Items1, 42.04m, 5.95m);
					yield return new TestCaseData(Discount2, Items1, 45.49m, 2.5m);
					yield return new TestCaseData(Discount3, Items1, 47.99m, 0m);
					yield return new TestCaseData(Discount4, Items1, 47.99m, 0m);
					yield return new TestCaseData(Discount1, Items2, 28m, 2m);
					yield return new TestCaseData(Discount2, Items2, 28m, 2m);
					yield return new TestCaseData(Discount3, Items2, 30m, 0m);
					yield return new TestCaseData(Discount4, Items2, 30m, 0m);
					yield return new TestCaseData(Discount1, Items3, 30m, 0m);
					yield return new TestCaseData(Discount2, Items3, 30m, 0m);
					yield return new TestCaseData(Discount3, Items3, 28m, 2m);
					yield return new TestCaseData(Discount4, Items3, 25m, 5m);

				}
			}
		}

		[Test, TestCaseSource(typeof(SaleData), nameof(SaleData.TestCases))]
		public void TestDiscount(List<Discount> discounts, List<Item> items, decimal subtotal, decimal totalDiscount)
		{
			var transaction = new Transaction(discounts);
			foreach (var item in items)
			{
				transaction.AddItem(item);
			}
			transaction.RecalculateSubtotal();
			Assert.That(transaction.SubTotal, Is.EqualTo(subtotal));
			Assert.That(transaction.TotalDiscount, Is.EqualTo(totalDiscount));
		}
	}
}