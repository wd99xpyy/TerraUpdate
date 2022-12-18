using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class petGuide : MonoBehaviour
{
    public Animal animalS;
    public GameObject petList;
    public GameObject petInfo;

    public GameObject animalP;
    public TextMeshProUGUI animalSpecise;
    public GameObject[] foodLike;
    public GameObject[] foodDislike;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadPetInfo()
    {
        animalSpecise.text = animalS.anmalSpecise;
        animalP.GetComponent<Image>().sprite = animalS.animalImage;
        for(int i = 0; i < foodLike.Length; i++)
        {
            if(i<animalS.FoodLike.Length)
            {
                foodLike[i].GetComponent<Image>().sprite = animalS.FoodLike[i].itemImage;
            }
            if (i < animalS.FoodDislike.Length)
            {
                foodDislike[i].GetComponent<Image>().sprite = animalS.FoodDislike[i].itemImage;
            }
        }
    }
}
