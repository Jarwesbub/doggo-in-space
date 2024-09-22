using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameVar : MonoBehaviour
{

    public static float volume = 0.5f;
    public void SetVolume(float _volume)
    {
        volume = _volume;
    }

}
