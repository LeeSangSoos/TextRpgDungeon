namespace TextRpgDungeon
{
	static class Utils
	{
		//입력받는 매서드
		//최소, 최대값을 벗어나면 재입력 요청
		public static int GetInput(int min, int limit)
		{
			Console.Write("원하시는 행동을 입력해주세요.\n" +
						">>");
			int input = int.Parse(Console.ReadLine() ?? "-1");
			while (input < min || input > limit)
			{
				Console.Write(" 잘못된 입력입니다.\n" +
					"다시 입력해주세요 >> ");
				input = int.Parse(Console.ReadLine() ?? "-1");
			}
			Console.Clear();
			
			return input;
		}

		static int IDFORITEM = 0;
		//아이템 ID 생성기
		public static int IdGenerator()
		{
			return IDFORITEM++;
		}
	}

	// 캐릭터 생성 인터페이스
	interface ICharacter
	{
		string Name { get; set; }
		int Health { get; set; }
		int Attack { get; set; }
		bool IsDead { get; set; }
		public int Level { get; set; }
		public CLASS Class { get; set; }
		public int Defence { get; set; }
		public int Gold { get; set; }

		//데미지를 받을 경우
		void TakeDamage(int damage);

		//캐릭터 능력치 출력
		public bool PrintInfo();

		
	}

	enum CLASS
	{
		전사,

	}
}