using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndMenu : MonoBehaviour
{
    PersistentManagerScript persistentManagerScript;
    public Text textBox;

   void Start()
    {
        persistentManagerScript = GameObject.FindWithTag("PersistentManager").GetComponent<PersistentManagerScript>();
        float time = persistentManagerScript.Time;

        textBox.text = time.ToString();
        textBox.text = Mathf.Round(time).ToString();
    }

}
