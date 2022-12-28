using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//check if fire is put out
//check timer
//display game over/pass
public class S1Manager : MonoBehaviour
{
    public GameObject _CDText;

    public GameObject _fire;
    public CountdownTimer currentTime;

    public GameObject _gameOverScreen;
    public GameObject _levelPassScreen;
    // Start is called before the first frame update



    void Start()
    {
        currentTime = _CDText.GetComponent<CountdownTimer>();
        _gameOverScreen.SetActive(false);
        _levelPassScreen.SetActive(false);
        GameObject.Find("PauseMenuCanvas").SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTime.currentTime == 0f && _fire.activeInHierarchy == true)
        {
            Debug.Log("Game Over!");
            
            _gameOverScreen.SetActive(true);
        }

        if(currentTime.currentTime != 0f && _fire.activeInHierarchy == false)
        {
            Debug.Log("Level Pass");
            Time.timeScale = 0f;
            _levelPassScreen.SetActive(true); //Display Game Pass Canvas
        }

        if(currentTime.currentTime == currentTime.startingTime)
        {
            Time.timeScale = 1f;
        }
    }
}
