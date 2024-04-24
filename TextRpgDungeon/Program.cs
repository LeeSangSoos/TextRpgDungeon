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
		public Game(Warrior _warrior)
		{
			warrior = _warrior;
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
						"3. 상점\n\n");
				input = Utils.GetInput(1, 3);
				switch (input)
				{
					case 1:
						exitVillage = warrior.PrintInfo();
						break;
					case 2:
						exitVillage = warrior.Inventory.ManageItems();
						break;
					case 3:
						break;
				}
			}
		}

	}

	//던전 클래스
	class Dungeon
	{

	}
}





