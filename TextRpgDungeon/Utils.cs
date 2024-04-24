namespace TextRpgDungeon
{
	static class Utils
	{
		//�Է¹޴� �ż���
		//�ּ�, �ִ밪�� ����� ���Է� ��û
		public static int GetInput(int min, int limit)
		{
			Console.Write("���Ͻô� �ൿ�� �Է����ּ���.\n" +
						">>");
			int input = int.Parse(Console.ReadLine() ?? "-1");
			while (input < min || input > limit)
			{
				Console.Write(" �߸��� �Է��Դϴ�.\n" +
					"�ٽ� �Է����ּ��� >> ");
				input = int.Parse(Console.ReadLine() ?? "-1");
			}
			Console.Clear();
			
			return input;
		}

		static int IDFORITEM = 0;
		//������ ID ������
		public static int IdGenerator()
		{
			return IDFORITEM++;
		}
	}

	// ĳ���� ���� �������̽�
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

		//�������� ���� ���
		void TakeDamage(int damage);

		//ĳ���� �ɷ�ġ ���
		public bool PrintInfo();

		
	}

	enum CLASS
	{
		����,

	}
}