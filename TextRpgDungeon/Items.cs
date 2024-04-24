using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TextRpgDungeon
{
	enum ITEMTYPE
	{
		HEALTH,
		ATTACK,
		DEFENCE,

	}

	enum EQUIPMENTYPE
	{
		BODY,
		ONEHAND
	}

	//아이템 범용 인터페이스
	interface IItem
	{
		string Name { get; set; }
		int ID { get;}
		int Price {  get; }
		public bool Sold { get; set; }
		public void Use(Warrior warrior);
		public void PrintData(bool isShop);
	}
	//class UsableItem : IItem
	//{
	//	public string Name { get; set; }
	//	public string type { get; private set; }
	//	public int amount { get; private set; }
	//	public int ID { get; private set; }
	//	public int Price { get; private set; }
	//	public bool Sold { get; set; }
	//	public UsableItem(string _name, string _type, int _amount)
	//	{
	//		Name = _name;
	//		type = _type;
	//		amount = _amount;
	//		ID = Utils.IdGenerator();
	//	}
	//	public void Use(Warrior warrior)
	//	{
	//		Console.WriteLine("{0} (이/가) 아이템 {1}을 썼습니다!", warrior.Name, Name);
	//		if (type == "attack")
	//		{
	//			warrior.Attack += amount;
	//		}
	//		else
	//		{
	//			warrior.Health += amount;
	//		}
	//	}
	//	public void PrintData() { 
			
	//	}
	//}

	[JsonSourceGenerationOptions(WriteIndented = true)]
	[JsonSerializable(typeof(EquipmentItem))]
	class EquipmentItem : IItem
	{
		public string Name { get; set; }
		public EQUIPMENTYPE equipType { get; set; }
		public int stat { get; set; }
		public bool equipped { get; set; }
		public string discription { get; set; }
		public ITEMTYPE itemType { get; set; }
		public int ID { get; private set; }
		public int Price {  get; private set; }
		public bool Sold { get; set; }

		[JsonConstructor]
		public EquipmentItem(string Name, EQUIPMENTYPE equipType, int stat,
			bool equipped, string discription, ITEMTYPE itemType, int ID, int Price, bool Sold)
		{
			this.Name = Name;
			this.equipType = equipType;
			this.stat = stat;
			this.equipped = equipped;
			this.discription = discription;
			this.itemType = itemType;
			this.ID = ID;
			this.Price = Price;
			this.Sold = Sold;
		}

		public EquipmentItem(string _name, EQUIPMENTYPE _equipType, ITEMTYPE _itemType,
			int _stat, string _discription, int _price)
		{
			Name = _name;
			equipType = _equipType;
			stat = _stat;
			equipped = false;
			discription = _discription;
			itemType = _itemType;
			ID = Utils.IdGenerator();
			Price = _price;
			Sold = false;
		}
		public void Use(Warrior warrior)
		{
			Console.WriteLine("{0} (이/가) 아이템 {1}을 장착 했습니다!", warrior.Name, Name);
		}

		public void PrintData(bool isShop)
		{
			if(equipped && isShop == false)
			{
				Console.Write($"[E]{Name}\t|");
			}
            else
            {
				Console.Write($"{Name}  \t|");
			}
			switch (itemType)
			{
				case ITEMTYPE.DEFENCE:
					Console.Write($"방어력 +{stat} | {discription}");
					break;
				case ITEMTYPE.ATTACK:
					Console.Write($"공격력 +{stat} | {discription}");
					break;
				case ITEMTYPE.HEALTH:
					Console.Write($"체력회복 +{stat} | {discription}");
					break;
			}
		}
	}



}
