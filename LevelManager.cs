using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public float waitToRespawn;

    public int EnergyCollected;

    public string levelToLoad;

    public float timeInLevel;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        timeInLevel = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timeInLevel += Time.deltaTime;
    }

    public void RespawnPlayer()
    {
        StartCoroutine(RespawnCo());
    }

    private IEnumerator RespawnCo()
    {
        PlayerController.instance.gameObject.SetActive(false);
        AudioManager.instance.PlaySFX(8);

        yield return new WaitForSeconds(waitToRespawn - (1f/ UIController.instance.fadeSpeed));
        UIController.instance.FadetoBlack();

        yield return new WaitForSeconds((1f / UIController.instance.fadeSpeed)+ .2f);
        UIController.instance.FadeFromBlack();

        PlayerController.instance.gameObject.SetActive(true);

        PlayerController.instance.transform.position = CheckpointController.instance.spawnPoint;

        PlayerHealthController.instance.currentHealth = PlayerHealthController.instance.maxHealth;
        UIController.instance.UpdateHealthDisplay();
    }

    public void EndLevel()
    { 
    StartCoroutine(EndLevelCo());
    }

    public IEnumerator EndLevelCo()
    {
        AudioManager.instance.PlayLevelVictory();
        
        PlayerController.instance.stopInput = true;
        CameraController.instance.stopFollow = true;

        UIController.instance.levelCompleteText.SetActive(true);

        yield return new WaitForSeconds(1.5f);

        UIController.instance.FadetoBlack();

        yield return new WaitForSeconds((1f / UIController.instance.fadeSpeed) + 3f);

        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_unlocked", 1);
        PlayerPrefs.SetString("CurrentLevel", SceneManager.GetActiveScene().name);

        if (PlayerPrefs.HasKey(SceneManager.GetActiveScene().name + "_energy"))
        {
            if (EnergyCollected > PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + "_energy"))
            {
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_energy", EnergyCollected);
            }
        }
        else 
        { 

            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_energy", EnergyCollected);
        }
        if (PlayerPrefs.HasKey(SceneManager.GetActiveScene().name + "_time"))
        {
            if (timeInLevel < PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name + "_time"))
            {
                PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "_time", timeInLevel);
            }
        }
        else 
        {
            PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "_time", timeInLevel);
        }
        
        
        
        SceneManager.LoadScene(levelToLoad);
    }

    public void MathEndLevel()
    {
        StartCoroutine(MathEndLevelCo());
    }

    public IEnumerator MathEndLevelCo()
    {
        
        



        

        yield return new WaitForSeconds(1.5f);

        UIController.instance.FadetoBlack();

        yield return new WaitForSeconds((1f / UIController.instance.fadeSpeed) + 3f);

        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_unlocked", 1);
        PlayerPrefs.SetString("CurrentLevel", SceneManager.GetActiveScene().name);

        if (PlayerPrefs.HasKey(SceneManager.GetActiveScene().name + "_energy"))
        {
            if (EnergyCollected > PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + "_energy"))
            {
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_energy", EnergyCollected);
            }
        }
        else
        {

            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_energy", EnergyCollected);
        }
        if (PlayerPrefs.HasKey(SceneManager.GetActiveScene().name + "_time"))
        {
            if (timeInLevel < PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name + "_time"))
            {
                PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "_time", timeInLevel);
            }
        }
        else
        {
            PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "_time", timeInLevel);
        }



        SceneManager.LoadScene(levelToLoad);
    }


    public void MathRetryLevel()
    {
      
        StartCoroutine(MathRetryLevelCo());
    }

    public IEnumerator MathRetryLevelCo()
    {
        
        yield return new WaitForSeconds(0.5f);

        UIController.instance.FadetoBlack();

        yield return new WaitForSeconds((1f / UIController.instance.fadeSpeed) + 1f);


        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }

}
