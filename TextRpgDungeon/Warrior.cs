using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpgDungeon
{
	// 용사 클래스
	class Warrior : ICharacter
	{
		public string Name { get; set; }
		public int Health { get; set; }
		public int TotalHealth { get; private set; }
		public int Attack { get; set; }
		public bool IsDead { get; set; }
		public int Level { get; set; }
		public CLASS Class { get; set; }
		public int Defence { get; set; }
		public int Gold { get; set; }
		public Inventory Inventory { get; set; }

		//용사의 정보 초기화
		public Warrior(string _name, int _health, int _attack,
			int _level, CLASS _class, int _defence, int _gold)
		{
			Name = _name;
			Health = _health;
			TotalHealth = _health;
			Attack = _attack;
			IsDead = false;
			Level = _level;
			Class = _class;
			Defence = _defence;
			Gold = _gold;
			Inventory = new Inventory();
		}

		//데미지를 받아서 체력이 0이하가 되면 사망
		public void TakeDamage(int damage)
		{
			Health -= damage;
			if (Health <= 0)
			{
				Health = 0;
				IsDead = true;
				Console.WriteLine("용사 {0}(이/가) 사망했습니다.", Name);
			}
		}

		//상태보기 화면
		public bool PrintInfo()
		{
			Console.WriteLine("---------------------------------------------");
			Console.WriteLine("상태 보기\n 캐릭터의 정보가 표시됩니다.\n");
			Console.WriteLine($"Lv. {Level}");
			Console.WriteLine($"{Name} ({Class})");

			Console.Write($"공격력 : {Attack}");
			//장착 템이 있으면 추가 정보 표시
			if(Inventory.RightHand != null)
			{
				Console.Write($"(+{Inventory.RightHand.stat})");
			}

			Console.Write($"\n방어력 : {Defence}");
			//장착 템이 있으면 추가 정보 표시
			if (Inventory.Body != null)
			{
				Console.Write($"(+{Inventory.Body.stat})");
			}

			Console.WriteLine($"\n체 력 : {Health}");
			Console.WriteLine($"Gold : {Gold} G");

			Console.WriteLine("\n0. 나가기");
			int input = Utils.GetInput(0, 0);
			switch (input)
			{
				case 0:
					return false;
			}
			return true;
		}

		public int TotalDefence()
		{
			if(Inventory.Body != null)
			{
				return Defence + Inventory.Body.stat;
			}
			else
			{
				return Defence;
			}
		}

		public int TotalAttack()
		{
			if (Inventory.RightHand != null)
			{
				return Attack + Inventory.RightHand.stat;
			}
			else
			{
				return Attack;
			}
		}
	}
}
