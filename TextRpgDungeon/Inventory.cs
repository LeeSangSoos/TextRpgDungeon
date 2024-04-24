﻿using System;
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
			bool manageEquipments = false; // 장착 관리 모드 on/off
			while (!exitInventory)
			{
				Console.WriteLine("---------------------------------------------");
				Console.WriteLine("인벤토리" +
				"\n보유 중인 아이템을 관리할 수 있습니다.\n");
				Console.WriteLine("[장착 아이템 목록]");
				for (int i = 0; i < equipmentItems.Count; i++)
				{
					Console.Write("- ");
					if (manageEquipments)
					{
						Console.Write($"- {i + 1} ");
					}
					equipmentItems[i].PrintData();
					Console.WriteLine();
				}

				if (!manageEquipments)
				{
					Console.WriteLine("\n[소모 아이템 목록]");
					foreach (UsableItem item in usableItems)
					{
						//추가 필요
					}
				}
				if (!manageEquipments)
				{
					Console.WriteLine("1. 장착 관리");
				}
				Console.WriteLine("0. 나가기");

				int input = 0;
				if (manageEquipments)
				{
					input = Utils.GetInput(0, equipmentItems.Count);
				}
				else
				{
					input = Utils.GetInput(0, 1);
				}
				switch (input)
				{
					case 0:
						if (manageEquipments)
						{
							manageEquipments = false;
						}
						else
						{
							exitInventory = true;
						}
						break;
					default:
						if (!manageEquipments && input == 1) // 장착 관리창이 아닐 때 장착관리창으로 이동
						{
							manageEquipments = true;
						}
						else //장착 관리 동작
						{
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
						}
						break;
				}
			}
			return false;//village로 돌아가기
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