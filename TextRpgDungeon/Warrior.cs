﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TextRpgDungeon
{
	// 용사 클래스
	class Warrior : ICharacter
	{
		public string Name { get; set; }
		public float Health { get; set; }
		public float TotalHealth { get; set; }
		public float Attack { get; set; }
		public bool IsDead { get; set; }
		public int Level { get; set; }
		public CLASS Class { get; set; }
		public float Defence { get; set; }
		public int Gold { get; set; }
		public Inventory Inventory { get; set; }
		public int TotalExp { get; set; }
		public int Exp { get; set; }

		[JsonConstructor]
		public Warrior(string Name, float Health, float TotalHealth, float Attack, bool IsDead, int Level,
			CLASS Class, float Defence, int Gold, Inventory Inventory, int TotalExp, int Exp)
		{
			this.Name = Name;
			this.Health = Health;
			this.TotalHealth = TotalHealth;
			this.Attack = Attack;
			this.IsDead = IsDead;
			this.Level = Level;
			this.Class = Class;
			this.Defence = Defence;
			this.Gold = Gold;
			this.Inventory = Inventory;
			this.TotalExp = TotalExp;
			this.Exp = Exp;
		}

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
			TotalExp = 1;
			Exp = 0;
		}

		//데미지를 받아서 체력이 0이하가 되면 사망
		public void TakeDamage(float damage)
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

		public float TotalDefence()
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

		public float TotalAttack()
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
	
		public void LevelUp()
		{
			Level++;
			Attack += 0.5f;
			Defence += 1;
			TotalExp++;
			Exp = 0;
		}
	}
}
