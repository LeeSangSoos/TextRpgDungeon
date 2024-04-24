using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
		public void Use(Warrior warrior);
	}
	class UsableItem : IItem
	{
		public string Name { get; set; }
		string type;
		int amount;
		public int ID { get; private set; }

		public UsableItem(string _name, string _type, int _amount)
		{
			Name = _name;
			type = _type;
			amount = _amount;
			ID = Utils.IdGenerator();
		}
		public void Use(Warrior warrior)
		{
			Console.WriteLine("{0} (이/가) 아이템 {1}을 썼습니다!", warrior.Name, Name);
			if (type == "attack")
			{
				warrior.Attack += amount;
			}
			else
			{
				warrior.Health += amount;
			}
		}
	}

	class EquipmentItem : IItem
	{
		public string Name { get; set; }
		public EQUIPMENTYPE equipType;
		public int stat;
		public bool equipped;
		public string discription;
		public ITEMTYPE itemType;
		public int ID { get; private set; }
		public EquipmentItem(string _name, EQUIPMENTYPE _equipType, ITEMTYPE _itemType,
			int _stat, string _discription)
		{
			Name = _name;
			equipType = _equipType;
			stat = _stat;
			equipped = false;
			discription = _discription;
			itemType = _itemType;
			ID = Utils.IdGenerator();
		}
		public void Use(Warrior warrior)
		{
			Console.WriteLine("{0} (이/가) 아이템 {1}을 장착 했습니다!", warrior.Name, Name);
		}

		public void PrintData()
		{
			if(equipped)
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
			Console.WriteLine();
		}
	}



}
