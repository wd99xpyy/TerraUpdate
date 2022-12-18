using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using UnityEngine.UI;

public class AnimalOnWorld : MonoBehaviour
{
    public Animal thisAnimal;
    public Specise animalInSpecise;
    public int animalHealth;
    public int animalMaxHealth = 100;
    public int animalHungry;
    public int animalMaxHungry = 100;
    public int animalHappiness;
    public int animalMaxHappiness = 100;
    public int animalThirst;
    public int animalMaxThirst = 100;

    public bool animalN = false;
    public string animalName;
    public TextMeshProUGUI infoName;

    public float time = 0;

    public TextMeshProUGUI species;
    public TextMeshProUGUI sickness;

    public healthbar healthbar;
    public healthbar hungrybar;

    public TextMeshProUGUI infospecies;
    public healthbar infohealthbar;
    public healthbar infohungrybar;
    public healthbar infohappinessbar;
    public healthbar infothirstbar;

    public GameObject release;

    public GameObject feedTip;
    public TextMeshProUGUI feedTipInfo;

    // Start is called before the first frame update
    void Start()
    {
        animalHealth = Random.Range(30, 70);
        animalHungry = Random.Range(30, 70);
        animalHappiness = Random.Range(30, 70);
        animalThirst = Random.Range(30, 70);
        setAnimalInfo();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time>5)
        {
            time = 0;
            HangryAndThirst(1);
            //Debug.Log("hungry:" + animalHungry + " health:" + animalHealth + " happness: " + animalHappiness + " thirth: " + animalThirst);
            if (animalHappiness < 1 || animalHungry < 1 || animalThirst < 1)
            {
                takeDamage(1);
            }
        }

        if(animalHealth <= 0)
        {
            StartCoroutine(theTip());
            

        }

/*        if (animalHappiness > 100)
        {
            animalHappiness = 99;
        }
        if(animalThirst > 100)
        {
            animalThirst = 99;
        }
        if (animalHungry > 100)
        {
            animalHungry= 100;
        }
        if (animalHealth > 100)
        {
            animalHealth = 100;
        }*/
    }

    IEnumerator theTip()
    {
        if (animalName!="")
        {
            feedTipInfo.text = animalName + " is dead";
            feedTip.SetActive(true);
        }
        yield return new WaitForSeconds(2);
        feedTip.SetActive(false);
        feedTipInfo.text = "Please Select an animal to feed";
        Destroy(gameObject);
    }

    public void refreshBar()
    {
        hungrybar.SetHealth(animalHungry);
        healthbar.SetHealth(animalHealth);
        infohealthbar.SetHealth(animalHealth);
        infohungrybar.SetHealth(animalHungry);
        infohappinessbar.SetHealth(animalHappiness);
        infothirstbar.SetHealth(animalThirst);
        if( animalHealth > 90 && animalHungry > 90 && animalHappiness > 90 && animalThirst > 90) {
            release.SetActive(true);
        }
    }

    void takeDamage(int damage)
    {
        if(animalHealth > 0)
        {
            animalHealth -= damage;
        }
        healthbar.SetHealth(animalHealth);
    }

    void HangryAndThirst(int damage)
    {
        if(animalHungry>0)
        {
            animalHungry -= damage;
        }
        if (animalThirst > 0)
        {
            animalThirst -= damage;
        }
        refreshBar();
    }


    void setAnimalInfo()
    {
        healthbar.SetMaxHealth(animalMaxHealth);
        healthbar.SetHealth(animalHealth);

        hungrybar.SetMaxHealth(animalMaxHungry);
        hungrybar.SetHealth(animalHungry);

        species.text = "Specise: " + thisAnimal.anmalSpecise;
    }

    public void selectSetup()
    {
        infoName.text = animalName;
        infospecies.text = thisAnimal.anmalSpecise;

        infohealthbar.SetMaxHealth(100);
        infohealthbar.SetHealth(animalHealth);

        infohungrybar.SetMaxHealth(100);
        infohungrybar.SetHealth(animalHungry);

        infohappinessbar.SetMaxHealth(100);
        infohappinessbar.SetHealth(animalHappiness);

        infothirstbar.SetMaxHealth(100);
        infothirstbar.SetHealth(animalThirst);
    }

    public bool checkFoodLike(item food)
    {
        for(int i = 0; i < thisAnimal.FoodLike.Length; i++)
        {
            if (thisAnimal.FoodLike[i] == food)
            {
                return true;
            }
        }
        return false;
    }

    public bool checkFoodDislike(item food)
    {
        for (int i = 0; i < thisAnimal.FoodDislike.Length; i++)
        {
            if (thisAnimal.FoodDislike[i] == food)
            {
                return true;
            }
        }
        return false;
    }
}
