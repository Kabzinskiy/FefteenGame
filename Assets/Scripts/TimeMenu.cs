using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeMenu : MonoBehaviour
{
    public Text timer;
    float allTime = 0;
    int temp = 0, seconds = 0;
    int minutes = 0;
    public Button StartGame;
    // Start is called before the first frame update
    void Start()
    {
        stoppedTime();
        
    }

    public void OnClick() {
        allTime = 0;
        goTime();
    }
    // Update is called once per frame
    void Update()
    {
        allTime += Time.deltaTime;
        temp = (int)allTime;
        minutes = temp / 60;
        seconds = temp - minutes * 60;
        timer.text = minutes + ":" + seconds;
        
    }

    public void stoppedTime() {
        Time.timeScale = 0f;
    }

    public void goTime() {
        Time.timeScale = 1f;
    }
  
}
