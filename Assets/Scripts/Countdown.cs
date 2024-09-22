using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{
    public Spawner Spawner;

    public float timeStart = 0;
 
    public float timeLevel = 0;
    public Text textBox;
    string sceneName;



    void TimeTravel()
    {
        if (sceneName == "Level_1_Scene")
        {
            textBox.text = timeStart.ToString();
            timeStart += Time.deltaTime;
            textBox.text = Mathf.Round(timeStart).ToString();
        }

    }


    // Update is called once per frame
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

        TimeTravel();

        timeLevel += Time.deltaTime;

        if ((timeLevel >= 30) && (sceneName == "Level_1_Scene"))
        {
            Spawner.JunkLevelUp();
            timeLevel = 0;
        }


    }
}
