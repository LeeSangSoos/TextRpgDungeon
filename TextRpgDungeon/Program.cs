namespace TextRpgDungeon
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//주인공 생성
			Warrior warrior;
			Console.Write("게임을 시작합니다!\n주인공 이름을 입력하세요: ");
			string warriorName = Console.ReadLine();
			warrior = new Warrior(warriorName, 100, 10);

			//게임 시작
			Game game = new Game(warrior);
			game.Run();
		}
	}

	static int GetInput(int limit)
	{
		Console.Write("원하시는 행동을 입력해주세요.\n" +
					">>");
		int input = int.Parse(Console.ReadLine());
		if(input )

		return input;
	}

	// 게임 진행
	class Game
	{
		Warrior warrior;
		public Game(Warrior _warrior)
		{
			warrior = _/warrior;
		}

		public void Run()
		{
			Village();
		}

		// 마을 구간
		void Village()
		{
			Console.WriteLine("던전 마을에 오신것을 환영합니다!\n" +
				"이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");

			int input;
			Console.Write("1. 상태 보기\n" +
					"2. 인벤토리\n" +
					"3. 상점\n\n");
			input = GetInput();
		}

	}

	//던전 클래스
	class Dungeon
	{

	}

	// 캐릭터 생성 인터페이스
	interface ICharacter
	{
		string Name { get; set; }
		int Health { get; set; }
		int Attack { get; set; }
		bool IsDead { get; set; }
		void TakeDamage(int damage);
	}

	//상점 클래스
	class Shop
	{

	}


	// 용사 클래스
	class Warrior : ICharacter
	{
		public string Name { get; set; }
		public int Health { get; set; }
		public int Attack { get; set; }
		public bool IsDead { get; set; }

		//용사의 정보 초기화
		public Warrior(string _name, int _health, int _attack)
		{
			Name = _name;
			Health = _health;
			Attack = _attack;
			IsDead = false;
		}

		//데미지를 받아서 체력이 0이하가 되면 사망
		public void TakeDamage(int damage)
		{
			Console.WriteLine("용사 {0}(이/가) 공격 {1}을 받았습니다.", Name, damage);
			Health -= damage;
			if (Health <= 0)
			{
				Health = 0;
				IsDead = true;
				Console.WriteLine("용사 {0}(이/가) 사망했습니다.", Name);
			}
		}
	}

}





