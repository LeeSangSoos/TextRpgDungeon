using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpgDungeon
{
	class Dungeon
	{
		public int level {  get; private set; }
		public int recommandedDefence { get; private set; }
		public int clearReward { get; private set; }
		public string Name { get; private set; }

		//던전 초기화
		//난이도에 따라 이름이랑, 보상, 권장 방어력 설정
		public Dungeon(int _level) { 
			level = _level;
			switch (level)
			{
				case 1:
					clearReward = 1000;
					recommandedDefence = 5;
					Name = "쉬운";
					break;
				case 2:
					clearReward = 1700;
					recommandedDefence = 6;
					Name = "일반";
					break;
				case 3:
					clearReward = 2500;
					recommandedDefence = 10;
					Name = "어려운";
					break;
				default:
					break;
			}
		}

		//던전 설명문 출력
		public void PrintData()
		{
			Console.WriteLine("{0} 던전\t| 방어력 {1} 이상 권장", Name, recommandedDefence);
		}

		//던전 클리어 여부 확인
		public void DungeonClear(Warrior warrior)
		{
			int warriorDefence = warrior.TotalDefence();
			if (warriorDefence < recommandedDefence)
			{
				Random random = new Random();
				int over3 = random.Next(0, 10);
				if (over3 > 3)
				{
					ClearSuccess(warrior);
				}
				else
				{
					ClearFailed(warrior);
				}
			}
			else
			{
				ClearSuccess(warrior);
			}

			Console.WriteLine("\n0. 나가기");
			Utils.GetInput(0, 0);
		}

		//클리어 성공시 출력과 결과 계산
		public void ClearSuccess(Warrior warrior)
		{
			Console.WriteLine("던전 클리어\n축하합니다!!");
			Console.WriteLine("{0} 던전을 클리어 하였습니다.", Name);

			Console.WriteLine("\n[탐험 결과]");
			int warriorDefence = warrior.TotalDefence();
			int warriorAttack = warrior.TotalAttack();

			Random random = new Random();
			int reducedHealth = random.Next(20, 36) + (warriorDefence - recommandedDefence);
			Console.WriteLine($"체력 {warrior.Health} -> {warrior.Health - reducedHealth}");
			warrior.TakeDamage(reducedHealth);

			float rewardIncrease = (int)(random.Next(warriorAttack, warriorAttack*2 + 1)/ 100);
			Console.WriteLine($"Gold {warrior.Gold} -> {(int)(warrior.Gold + clearReward + clearReward* rewardIncrease)}");
			warrior.Gold = (int)(warrior.Gold + clearReward + clearReward * rewardIncrease);
		}

		//클리어 실패시 출력과 결과 계산
		public void ClearFailed(Warrior warrior)
		{
			Console.WriteLine("던전 클리어 실패\n실패했습니다...");
			Console.WriteLine("{0} 던전을 클리어에 실패했습니다.", Name);

			Console.WriteLine("\n[탐험 결과]");

			int reducedHealth = (int)(warrior.Health * 0.5);
			Console.WriteLine($"체력 {warrior.Health} -> {warrior.Health - reducedHealth}");
			warrior.TakeDamage(reducedHealth);
		}
	}
}
