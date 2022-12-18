using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class refreshItem : MonoBehaviour
{
    public GameObject[] AllitemOneMapOne;
    public GameObject[] AllitemOneMapTwo;
    public GameObject[] AllitemOneMapThree;

    public float time = 0;


    private void Update()
    {
        time += Time.deltaTime;
        if (time > 5)
        {
            time = 0;
            int a = checkActive(AllitemOneMapOne);
            int b = checkActive(AllitemOneMapTwo);
            int c = checkActive(AllitemOneMapThree);
            if(a != 999)
            {
                AllitemOneMapOne[a].SetActive(true);
            }
            if (b != 999)
            {
                AllitemOneMapTwo[b].SetActive(true);
            }
            if (c != 999)
            {
                AllitemOneMapThree[c].SetActive(true);
            }

        }
    }

    int checkActive(GameObject[] checklist)
    {
        List<int> unactiveItem = new List<int>();
        for (int i = 0; i < checklist.Length; i++)
        {
            if (!checklist[i].activeSelf)
            {
                unactiveItem.Add(i);
            }
        }
        if (unactiveItem.Count > 0)
        {
            int randomNum = unactiveItem.Count;
            randomNum = Random.Range(0, randomNum);
            Debug.Log(randomNum);
            return unactiveItem[randomNum];
        }
        else
        {
            return 999;
        }

    }
}
