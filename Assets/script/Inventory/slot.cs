using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class slot : MonoBehaviour
{
    public item slotItem;
    public Image slotImage;
    public TextMeshProUGUI slotIndex;

    public GameObject objectUsing;
    public bool isUsing = false;

    public GameObject slotPrefab;


    public void Update()
    {

    }

    public void ItemOnClick()
    {
        GameObject animalselect = GameManager.currentSelectAnimal;
        if (animalselect)
        {
            if (slotItem.isFood)
            {
                Debug.Log(animalselect.GetComponent<AnimalOnWorld>().animalHungry);
                if (animalselect.GetComponent<AnimalOnWorld>().animalHungry <= 99)
                {
                    bool isFoodLike = animalselect.GetComponent<AnimalOnWorld>().checkFoodLike(slotItem);
                    bool isFoodDislike = animalselect.GetComponent<AnimalOnWorld>().checkFoodDislike(slotItem);
                    if (isFoodLike)
                    {
                        animalselect.GetComponent<AnimalOnWorld>().animalHungry += 15;
                        animalselect.GetComponent<AnimalOnWorld>().animalHappiness += 5;
                    }
                    else if (isFoodDislike)
                    {
                        animalselect.GetComponent<AnimalOnWorld>().animalHungry += 5;
                        if (animalselect.GetComponent<AnimalOnWorld>().animalHappiness > 0)
                        {
                            animalselect.GetComponent<AnimalOnWorld>().animalHappiness -= 10;
                        }
                    }
                    else
                    {
                        animalselect.GetComponent<AnimalOnWorld>().animalHungry += 10;
                    }
                    slotItem.itemHeld--;
                }
                else
                {
                    Debug.Log("can not eat more");
                }
            }
            else if(slotItem.isMed)
            {
                if (animalselect.GetComponent<AnimalOnWorld>().animalHealth<=99)
                {
                    animalselect.GetComponent<AnimalOnWorld>().animalHealth += 5;
                }
                
                if (animalselect.GetComponent<AnimalOnWorld>().animalHappiness > 0)
                {
                    animalselect.GetComponent<AnimalOnWorld>().animalHappiness -= 5;
                }
                slotItem.itemHeld--;
            }
            animalselect.GetComponent<AnimalOnWorld>().refreshBar();
            inventoryManager.RefreshItem();
        }
        //inventoryManager.UpdateItemInfo(slotItem.itemInfo);
    }


    /*    public void useItem()
        {
            if(slotItem.itemHeld > 0)
            {
                createdImage();
            }
        }*/
    /*    public void createdImage()
        {
            if (isUsing == false)
            {
                GameObject newObject = new GameObject();
                Image itemImage = newObject.AddComponent<Image>();
                itemImage.sprite = slotImage.sprite;
                newObject.GetComponent<RectTransform>().SetParent(slotPrefab.transform);
                newObject.SetActive(true);
                isUsing = true;
                objectUsing = newObject;
            }
        }
    */
    /*    public void followMouse(GameObject gameobject)
        {
            gameobject.transform.position = Input.mousePosition;
        }*/


}
