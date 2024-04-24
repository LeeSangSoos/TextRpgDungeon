using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpgDungeon
{
	// 인벤토리 클래스
	class Inventory
	{
		// 장착템 목록
		List<EquipmentItem> equipmentItems { get; set; }

		// 소모품 목록
		List<UsableItem> usableItems { get; set; }

		// 장착한 아이템 목록
		public EquipmentItem? Body;
		public EquipmentItem? RightHand;

		//초기화
		public Inventory()
		{
			equipmentItems = new List<EquipmentItem>();
			usableItems = new List<UsableItem>();
		}

		//인벤토리 창
		//장착아이템, 소모템 목록을 표시하고 장착관리나, 나가기로 이어짐
		public bool ManageItems()
		{
			bool exitInventory = false;
			while (!exitInventory)
			{
				Console.WriteLine("---------------------------------------------");
				Console.WriteLine("인벤토리" +
				"\n보유 중인 아이템을 관리할 수 있습니다.\n");
				Console.WriteLine("[장착 아이템 목록]");
				foreach (EquipmentItem item in equipmentItems)
				{
					Console.Write("- ");
					item.PrintData();
				}

				Console.WriteLine("\n소모 아이템: ");
				foreach (UsableItem item in usableItems)
				{
					Console.Write(item.Name + ", ");
				}

				Console.WriteLine("1. 장착 관리\n" +
					"0. 나가기");
				int input = Utils.GetInput(0, 1);
				switch (input)
				{
					case 0:
						exitInventory = true;
						break;
					case 1:
						exitInventory = ManageEquipments();
						break;
				}
			}
			return false;//village로 돌아가기
		}

		/*
		 * 장착 아이템 관리창
		 * 아이템목록앞에 숫자가뜨고 숫자를 고르면 그 아이템 장착 또는 해제
		 */
		public bool ManageEquipments()
		{
			bool exitInventory = false;
			while (!exitInventory)
			{
				Console.WriteLine("---------------------------------------------");
				Console.WriteLine("인벤토리" +
				"\n보유 중인 아이템을 관리할 수 있습니다.\n");
				Console.WriteLine("[장착 아이템 목록]");
				for (int i = 0; i < equipmentItems.Count; i++)
				{
					Console.Write($"- {i + 1} ");
					equipmentItems[i].PrintData();
				}

				Console.WriteLine("\n0. 나가기");
				int input = Utils.GetInput(0, equipmentItems.Count);
				switch (input)
				{
					case 0:// 인벤토리로 나가기
						exitInventory = true;
						break;
					default:
						EquipmentItem item = equipmentItems[input - 1];
						if (item.equipped)//장착된 아이템 해제
						{
							if (item.equipType == EQUIPMENTYPE.BODY)
							{
								Body = null;
								item.equipped = false;
							}
							else if (item.equipType == EQUIPMENTYPE.ONEHAND)
							{
								RightHand = null;
								item.equipped = false;
							}
						}
						else // 아이템 장착
						{
							if (item.equipType == EQUIPMENTYPE.BODY)
							{
								if (Body != null)
								{
									Body.equipped = false;
									Body = null;
								}
								Body = item;
								item.equipped = true;
							}
							else if (item.equipType == EQUIPMENTYPE.ONEHAND)
							{
								if (RightHand != null)
								{
									RightHand.equipped = false;
									RightHand = null;
								}
								RightHand = item;
								item.equipped = true;
							}
						}
						break;
				}
			}
			return false; //인벤토리로 돌아가기
		}
	
		/*인벤토리에 아이템 추가
		 */
		public void Add(IItem item)
		{
			if(item is EquipmentItem)
			{
				EquipmentItem equipmentItem = (EquipmentItem)item;
				equipmentItems.Add(equipmentItem);
			}
			else if(item is UsableItem)
			{
				UsableItem usableItem = (UsableItem)item;
				usableItems.Add(usableItem);
			}
		}

		/*
		 * LINQ를 사용한 제거
		 */
		public void Remove(IItem item)
		{
			if (item is EquipmentItem)
			{
				EquipmentItem equipmentItem = (EquipmentItem)item;
				equipmentItems.RemoveAll(equipment => equipment.ID == equipmentItem.ID);
			}
			else if (item is UsableItem)
			{
				UsableItem usableItem = (UsableItem)item;
				usableItems.RemoveAll(usable => usable.ID == usableItem.ID);
			}
		}
	}
}
