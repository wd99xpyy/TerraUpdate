using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEditor;
using UnityEngine;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int currentLocation = 0;
    public string[] loactionName = {"The Base", "Hospital" };
    public TextMeshProUGUI locationNameonTopbar;
    public TextMeshProUGUI locationNameonMap;

    public GameObject currentL;
    public GameObject[] allLocation;

    public GameObject assignAnimalName;
    public TMP_InputField theinputfiled;
    public TextMeshProUGUI inputfiled;
    public TextMeshProUGUI placeholder;
    public string textinfiled;
    public GameObject animalAssignName;

    public GameObject background;
    public Sprite[] backgroundImage;
    public Camera theCamera;

    public GameObject myBag;
    public GameObject device;
    public GameObject map;
    public GameObject directory;
    public GameObject introMessage;
    public bool introMessageIsOpen;
    public bool deviceIsOpen;
    public bool myBagIsOpen;
    public bool mapIsOpen;
    public bool directoryIsOpen;

    public GameObject info;

    public GameObject select;

    public GameObject[] AnimalSetLocation;
    public int avaliableSet;

    public static GameObject currentSelectAnimal;

    // Start is called before the first frame update
    void Start()
    {
        theCamera = GameObject.Find("MainCamera").GetComponent<Camera>();

        StartCoroutine(showIntroMessage(3));

        avaliableSet = AnimalSetLocation.Length;
    }

    IEnumerator showIntroMessage(float duration)
    { 
        // waits here
        yield return new WaitForSeconds(duration);
        introMessage.SetActive(introMessageIsOpen);
    }

    // Update is called once per frame
    void Update()
    {
        /*        if (Input.GetKeyDown(KeyCode.B))
                {
                    OpenMyBag();
                }
                if (Input.GetKeyDown(KeyCode.M))
                {
                    OpenMap();
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    OpenDirectory();
                }
                if (Input.GetKeyDown(KeyCode.F))
                {
                    OpenDevice();
                }*/

        if (select.GetComponent<select>().currentlySelect != 2)
        {
            myBagIsOpen = false;
            myBag.SetActive(false);
        }
        else
        {
            myBagIsOpen = true;
            myBag.SetActive(true);
        }

        if(select.GetComponent<select>().currentlySelect == 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (hit.collider != null && hit.collider.gameObject.CompareTag("Animal"))
                {
                    if (hit.collider.gameObject.GetComponent<AnimalOnWorld>().animalN)
                    {
                        info.SetActive(true);
                        hit.collider.gameObject.GetComponent<AnimalOnWorld>().selectSetup();
                        currentSelectAnimal = hit.collider.gameObject;
                    }
                    else
                    {
                        assignAnimalName.SetActive(true);
                        animalAssignName = hit.collider.gameObject;
                    }
                }
            }
        }
        else
        {
            if(select.GetComponent<select>().currentlySelect != 2)
            {
                info.SetActive(false);
                currentSelectAnimal = null;
            }
            
        }
    }

    public void AssignName()
    {
        textinfiled = inputfiled.text;
        if (inputfiled.text.Length > 1)
        {
            animalAssignName.GetComponent<AnimalOnWorld>().animalN = true;
            animalAssignName.GetComponent<AnimalOnWorld>().animalName = inputfiled.text;
            assignAnimalName.SetActive(false);
            clearInput();
            setAnimalLocation();
        }
        else
        {
            placeholder.text = "Please enter the Name";
        }
    }

    public void clearInput()
    {
        theinputfiled.Select();
        theinputfiled.text = "";
    }

    public void setAnimalLocation()
    {
        GameObject locationA;
        if (avaliableSet > 0)
        {
            locationA = AnimalSetLocation[AnimalSetLocation.Length - avaliableSet];
            animalAssignName.transform.position= locationA.transform.position;
            avaliableSet--;
        }
    }
    public void updateLocationName()
    {
        locationNameonMap.text = loactionName[currentLocation];
        locationNameonTopbar.text = loactionName[currentLocation];
    }
     public void OpenIntroMessage()
    {
        introMessageIsOpen = !introMessageIsOpen;
        introMessage.SetActive(introMessageIsOpen);
    }
     public void OpenDevice()
    {
        deviceIsOpen = !deviceIsOpen;
        device.SetActive(deviceIsOpen);
    }
    public void OpenMyBag()
    {
        myBagIsOpen = !myBagIsOpen;
        myBag.SetActive(myBagIsOpen);
    }
    public void OpenMap()
    {
        mapIsOpen = !mapIsOpen;
        map.SetActive(mapIsOpen);
    }

    public void OpenDirectory()
    {
        directoryIsOpen = !directoryIsOpen;
        directory.SetActive(directoryIsOpen);
    }

    public void CloseName()
    {
        assignAnimalName.SetActive(false);
        clearInput();
    }
    public void LoadLocation(int locationNum)
    {
        background.GetComponent<SpriteRenderer>().sprite = backgroundImage[locationNum];
        currentLocation = locationNum;
        theCamera.transform.position = new Vector3(-20, -50 * locationNum, -10);
        updateLocationName();
        locatedLogo();
        OpenMap();
    }


    public void locatedLogo()
    {
        currentL.transform.position = allLocation[currentLocation].transform.position;
    }

    public void water()
    {
        if (currentSelectAnimal)
        {
            currentSelectAnimal.GetComponent<AnimalOnWorld>().animalThirst += 10;
            currentSelectAnimal.GetComponent<AnimalOnWorld>().refreshBar();
            //Debug.Log("water");
        }
    }

    public void Med()
    {
        if (currentSelectAnimal)
        {
            currentSelectAnimal.GetComponent<AnimalOnWorld>().animalHealth += 10;
            currentSelectAnimal.GetComponent<AnimalOnWorld>().refreshBar();
            //Debug.Log("water");
        }
    }
}
