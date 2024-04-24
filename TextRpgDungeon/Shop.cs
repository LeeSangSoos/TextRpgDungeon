//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace TextRpgDungeon
//{
//	class Shop
//	{
//		List<IItem> soldItems;
//		Warrior customer;
		
//		//기본 세팅
//		//기본 아이템 추가		
//		public Shop(Warrior _customer)
//		{
//			soldItems = new List<IItem>();
//			customer = _customer;
//		}

//		/*상점에 아이템 추가
//		 */
//		public void Add(IItem item)
//		{
//			soldItems.Add(item);
//		}

//		/*
//		 * 상점 아이템 확인창
//		 * 1을 누르면 selling상태가 활성화 되고 판매창 기능이 같이 켜짐
//		 */
//		public bool ShowItems()
//		{
//			bool exitShop = false;
//			bool selling = false;
//			while (!exitShop)
//			{
//				Console.WriteLine("---------------------------------------------");
//				Console.WriteLine("상점" +
//				"\n필요한 아이템을 얻을 수 있는 상점입니다.\n");
//				Console.WriteLine("[보유 골드]");
//				Console.WriteLine($"{customer.Gold} G");

//				Console.WriteLine("\n[판매 아이템 목록]");
//				for (int i = 0; i < soldItems.Count; i++)
//				{
//					if (selling)
//					{
//						Console.Write($"- {i + 1} ");
//					}
//					else
//					{
//						Console.Write($"- ");
//					}

//					soldItems[i].PrintData();
//					if (soldItems[i].Sold)
//					{

//					}
//					else
//					{
//						Console.WriteLine()
//					}
//				}
//				if (!selling)
//				{
//					Console.WriteLine("\n1. 아이템 구매");
//				}
//				Console.WriteLine("\n0. 나가기");
//				int input = Utils.GetInput(0, soldItems.Count);
//				switch (input)
//				{
//					case 0:// 뒤로로 나가기
//						if (selling)
//						{
//							selling= false;
//						}
//						else
//						{
//							exitShop = true;
//						}
//						break;
//					case 1:
//						selling = true;
//						break;
//					default:
//						EquipmentItem item = equipmentItems[input - 1];
//						if (item.equipped)//장착된 아이템 해제
//						{
//							if (item.equipType == EQUIPMENTYPE.BODY)
//							{
//								Body = null;
//								item.equipped = false;
//							}
//							else if (item.equipType == EQUIPMENTYPE.ONEHAND)
//							{
//								RightHand = null;
//								item.equipped = false;
//							}
//						}
//						else // 아이템 장착
//						{
//							if (item.equipType == EQUIPMENTYPE.BODY)
//							{
//								if (Body != null)
//								{
//									Body.equipped = false;
//									Body = null;
//								}
//								Body = item;
//								item.equipped = true;
//							}
//							else if (item.equipType == EQUIPMENTYPE.ONEHAND)
//							{
//								if (RightHand != null)
//								{
//									RightHand.equipped = false;
//									RightHand = null;
//								}
//								RightHand = item;
//								item.equipped = true;
//							}
//						}
//						break;
//				}
//			}
//			return false; //마을로 돌아가기
//		}
//	}
//}
