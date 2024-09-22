using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PersistentManagerScript : MonoBehaviour
{
    public static PersistentManagerScript Instance { get; private set; }
    public float Time = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level_1_Scene")
        {
            Time += UnityEngine.Time.deltaTime;

        }
        else
        {
            Time = 0;
        }

    }

}
