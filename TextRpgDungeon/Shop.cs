using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpgDungeon
{
	class Shop
	{
		List<IItem> soldItems;
		Warrior customer;

		//기본 세팅
		//기본 아이템 추가		
		public Shop(Warrior _customer)
		{
			soldItems = new List<IItem>();
			customer = _customer;
			Add(new EquipmentItem("갑옷1", EQUIPMENTYPE.BODY, ITEMTYPE.DEFENCE, 2, "아주 단단한 갑옷", 100));
			Add(new EquipmentItem("갑옷2", EQUIPMENTYPE.BODY, ITEMTYPE.DEFENCE, 3, "더욱 단단한 갑옷", 200));
			Add(new EquipmentItem("무기1", EQUIPMENTYPE.ONEHAND, ITEMTYPE.ATTACK, 1, "날카로운 칼", 100));
			Add(new EquipmentItem("무기2", EQUIPMENTYPE.ONEHAND, ITEMTYPE.ATTACK, 3, "더욱 날카로운 칼", 200));
			Add(new EquipmentItem("수련자 갑옷", EQUIPMENTYPE.BODY, ITEMTYPE.DEFENCE, 5, " 수련에 도움을 주는 갑옷입니다. ", 1000));
		}

		/*상점에 아이템 추가
		 */
		public void Add(IItem item)
		{
			soldItems.Add(item);
		}

		/*
		 * 상점 아이템 확인창
		 * 1을 누르면 selling상태가 활성화 되고 판매창 기능이 같이 켜짐
		 */
		public bool ShowItems()
		{
			bool exitShop = false;
			bool selling = false;
			while (!exitShop)
			{
				Console.WriteLine("---------------------------------------------");
				Console.WriteLine("상점" +
				"\n필요한 아이템을 얻을 수 있는 상점입니다.\n");
				Console.WriteLine("[보유 골드]");
				Console.WriteLine($"{customer.Gold} G");

				Console.WriteLine("\n[판매 아이템 목록]");
				for (int i = 0; i < soldItems.Count; i++)
				{
					if (selling)
					{
						Console.Write($"- {i + 1} ");
					}
					else
					{
						Console.Write($"- ");
					}

					soldItems[i].PrintData();
					if (soldItems[i].Sold)
					{
						Console.WriteLine("\t| 구매완료");
					}
					else
					{
						Console.WriteLine($"\t| {soldItems[i].Price} G");
					}
				}
				if (!selling)
				{
					Console.WriteLine("\n1. 아이템 구매");
				}
				Console.WriteLine("\n0. 나가기");
				int input = 0;
				if (selling)
				{
					input = Utils.GetInput(0, soldItems.Count);
				}
				else
				{
					input = Utils.GetInput(0, 1);
				}
				switch (input)
				{
					case 0:// 뒤로로 나가기
						if (selling)
						{
							selling = false;
						}
						else
						{
							exitShop = true;
						}
						break;
					default:
						if (!selling && input == 1) // 아이템 구매중이 아닐 때는 구매창으로 이동
						{
							selling = true;
						}
						else
						{
							IItem item = soldItems[input - 1];
							if (item.Sold)
							{
								Console.WriteLine("이미 구매한 아이템입니다");
							}
							else
							{
								if(customer.Gold >= item.Price)
								{
									Console.WriteLine("구매를 완료했습니다.");
									customer.Gold -= item.Price;
									customer.Inventory.Add(item);
									item.Sold = true;
								}
								else
								{
									Console.WriteLine("Gold 가 부족합니다.");
								}
							}
						}
						break;
				}
			}
			return false; //마을로 돌아가기
		}
	}
}
