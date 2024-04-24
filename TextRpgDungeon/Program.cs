using System.Threading;

namespace TextRpgDungeon
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//주인공 생성
			Warrior warrior;
			Console.Write("게임을 시작합니다!\n주인공 이름을 입력하세요: ");
			string? warriorName = Console.ReadLine();
			warrior = new Warrior(warriorName ?? "기본용사", 100, 10, 1, CLASS.전사, 5, 1500);

			//게임 시작
			Game game = new Game(warrior);
			game.Run();
		}
	}

	// 게임 진행
	class Game
	{
		Warrior warrior;
		Shop shop;
		List<Dungeon> dungeon;
		public Game(Warrior _warrior)
		{
			warrior = _warrior;
			shop = new Shop(warrior);
			dungeon = new List<Dungeon>();
			dungeon.Add(new Dungeon(1));
			dungeon.Add(new Dungeon(2));
			dungeon.Add(new Dungeon(3));
		}

		public void Run()
		{
			Village();
		}

		// 마을 구간
		void Village()
		{
			bool exitVillage = false;
			while (!exitVillage)
			{
				Console.WriteLine("---------------------------------------------");
				Console.WriteLine("던전 마을에 오신것을 환영합니다!\n" +
				"이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");

				int input;
				Console.Write("1. 상태 보기\n" +
						"2. 인벤토리\n" +
						"3. 상점\n" +
						"4. 던전입장\n" +
						"5. 휴식하기");
				input = Utils.GetInput(1, 5);
				switch (input)
				{
					case 1:
						exitVillage = warrior.PrintInfo();
						break;
					case 2:
						exitVillage = warrior.Inventory.ManageItems();
						break;
					case 3:
						exitVillage = shop.ShowItems();
						break;
					case 4:
						exitVillage = ChooseDungeon();
						break;
					case 5:
						exitVillage = Rest();
						break;
				}
			}

			Console.WriteLine("우리의 영웅 {0}가 사망했습니다...", warrior.Name);
		}

		//던전 선택 화면
		bool ChooseDungeon()
		{
			bool exitDungeon = false;
			while (!exitDungeon)
			{
				Console.WriteLine("---------------------------------------------");
				Console.WriteLine("던전입장" +
				"\n이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");
				for (int i = 0; i < dungeon.Count; i++) // 던전 목록 출력
				{
					Console.Write($"{i + 1}. ");
					dungeon[i].PrintData();
				}
				Console.WriteLine("0. 나가기");

				int input = Utils.GetInput(0, dungeon.Count);
				switch (input)
				{
					case 0:
						exitDungeon = true;
						break;
					default:
						if (warrior.IsDead)//죽었으면 강제로 퇴장
						{
							exitDungeon = true;
						}
						else
						{
							dungeon[input - 1].DungeonClear(warrior);//던전 선택시 입장
						}
						break;
				}
			}
			if (warrior.IsDead) // 사망시 게임 끝
			{
				return true;
			}
			else
			{
				return false;//village로 돌아가기
			}
		}

		//휴식 하기 창
		bool Rest()
		{
			bool exitDungeon = false;
			while (!exitDungeon)
			{
				Console.WriteLine("---------------------------------------------");
				Console.WriteLine("휴식하기" +
				"\n500 G 를 내면 체력을 회복할 수 있습니다. (보유 골드 : {0} G)\n", warrior.Gold);
				Console.WriteLine("1. 휴식하기");
				Console.WriteLine("0. 나가기");

				int input = Utils.GetInput(0, 1);
				switch (input)
				{
					case 0:
						exitDungeon = true;
						break;
					default:
						if(warrior.Gold >= 500) // 휴식에 성공하면 500골드를 내고 체력 완전회복
						{
							Console.WriteLine("휴식을 완료했습니다.");
							warrior.Health = warrior.TotalHealth;
						}
						else // 500골드가 부족하면 휴식 실패
						{
							Console.WriteLine("Gold 가 부족합니다.");
						}
						
						break;
				}
			}
			return false;//village로 돌아가기
		}
	}
}





