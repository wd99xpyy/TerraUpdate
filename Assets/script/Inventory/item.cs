using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/New Item")]
public class item : ScriptableObject
{
    public string itemName;
    public Sprite itemImage;
    public int itemHeld;
    public bool isFood;
    public bool isMed;
    [TextArea]
    public string itemInfo;

}
