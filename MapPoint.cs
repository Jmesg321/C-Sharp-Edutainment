using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPoint : MonoBehaviour
{
    public MapPoint up, right, down, left;
    public bool isLevel,isLocked;
    public string levelToLoad, levelToCheck, levelName;

    public int energyCollected, totalEnergy;
    public float bestTime, targetTime;

    public GameObject energyBadge, timeBadge;


    
    
    // Start is called before the first frame update
    void Start()
    {
        if (isLevel && levelToLoad != null)
        {
            if (PlayerPrefs.HasKey(levelToLoad + "_energy"))
            {
                energyCollected = PlayerPrefs.GetInt(levelToLoad + "_energy");
            }

            if (PlayerPrefs.HasKey(levelToLoad + "_time"))
            {
                bestTime = PlayerPrefs.GetFloat(levelToLoad + "_time");
            }

            if (energyCollected >= totalEnergy)
            {
                energyBadge.SetActive(true);
            }

            if (bestTime <= targetTime && bestTime != 0)
            {
                timeBadge.SetActive(true);
            }
            
            
            isLocked = true;


            if (levelToCheck != null)
            {
                if (PlayerPrefs.HasKey(levelToCheck + "_unlocked"))
                {
                    if (PlayerPrefs.GetInt(levelToCheck + "_unlocked") == 1)
                    {
                        isLocked = false;

                    }
                   

                }
            }
            if (levelToLoad == levelToCheck)
            {
                isLocked = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
