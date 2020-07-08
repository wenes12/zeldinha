using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public List<GameObject> heartList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLife();   
    }

    void UpdateLife()
    {
        switch(GameController.instance.lives)
        {
            case 8:
                DisableHearts();

                heartList[1].SetActive(true);
                heartList[3].SetActive(true);
                heartList[5].SetActive(true);
                heartList[7].SetActive(true);

                break;

            case 7:
                DisableHearts();

                heartList[1].SetActive(true);
                heartList[3].SetActive(true);
                heartList[5].SetActive(true);
                heartList[6].SetActive(true);

                break;

            case 6:
                DisableHearts();

                heartList[1].SetActive(true);
                heartList[3].SetActive(true);
                heartList[5].SetActive(true);
                

                break;

            case 5:
                DisableHearts();

                heartList[1].SetActive(true);
                heartList[3].SetActive(true);
                heartList[4].SetActive(true);


                break;

            case 4:
                DisableHearts();

                heartList[1].SetActive(true);
                heartList[3].SetActive(true);


                break;

            case 3:
                DisableHearts();

                heartList[1].SetActive(true);
                heartList[2].SetActive(true);


                break;

            case 2:
                DisableHearts();

                heartList[1].SetActive(true);


                break;

            case 1:
                DisableHearts();

                heartList[0].SetActive(true);


                break;

            case 0:
                DisableHearts();


                break;
        }
    }

    void DisableHearts()
    {
        foreach(GameObject g in heartList)
        {
            g.SetActive(false);
        }
    }
}
