using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class inventoryManager : MonoBehaviour
{
    static inventoryManager instance;

    public Inventory FoobBag;
    public Inventory MedBag;

    public GameObject slotGridFood;
    public GameObject slotGridMed;

    public slot slotPrefab;
    //public TextMeshProUGUI itemInfo;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
        }
        instance = this;
    }

    private void OnEnable()
    {
        RefreshItem();
        //instance.itemInfo.text = "";
    }

    public static void UpdateItemInfo(string iteminfo)
    {
        //instance.itemInfo.text = iteminfo;
    }

    public static void CreateNewFood(item item)
    {
        slot newItem = Instantiate(instance.slotPrefab,instance.slotGridFood.transform.position,Quaternion.identity);
        newItem.gameObject.transform.SetParent(instance.slotGridFood.transform);
        newItem.slotItem = item;
        newItem.slotImage.sprite = item.itemImage;
        newItem.slotIndex.text = item.itemHeld.ToString();
    }
    public static void CreateNewMed(item item)
    {
        slot newItem = Instantiate(instance.slotPrefab, instance.slotGridMed.transform.position, Quaternion.identity);
        newItem.gameObject.transform.SetParent(instance.slotGridMed.transform);
        newItem.slotItem = item;
        newItem.slotImage.sprite = item.itemImage;
        newItem.slotIndex.text = item.itemHeld.ToString();
    }

    public static void RefreshItem()
    {
        for(int i = 0; i < instance.slotGridFood.transform.childCount; i++)
        {
            if(instance.slotGridFood.transform.childCount == 0)
            {
                break;
            }
            Destroy(instance.slotGridFood.transform.GetChild(i).gameObject);
        }

        for(int i = 0; i < instance.FoobBag.itemList.Count; i++)
        {
            if (instance.FoobBag.itemList[i].itemHeld > 0)
            {
                CreateNewFood(instance.FoobBag.itemList[i]);
            }
            else
            {
                instance.FoobBag.itemList[i].itemHeld = 0;
            }
        }

        for (int i = 0; i < instance.slotGridMed.transform.childCount; i++)
        {
            if (instance.slotGridMed.transform.childCount == 0)
            {
                break;
            }
            Destroy(instance.slotGridMed.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < instance.MedBag.itemList.Count; i++)
        {
            if (instance.MedBag.itemList[i].itemHeld > 0)
            {
                CreateNewMed(instance.MedBag.itemList[i]);
            }
            else
            {
                instance.MedBag.itemList[i].itemHeld = 0;
            }
        }
    }
}
