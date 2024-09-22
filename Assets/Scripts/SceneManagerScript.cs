using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneManagerScript : MonoBehaviour
{
    public Text ValueTxt;

    private void Start()
    {
        ValueTxt.text = Mathf.Round(PersistentManagerScript.Instance.Time).ToString();

    }

    public void GoToFirstScene()
    {
        
        SceneManager.LoadScene("Level_1_Scene");
        PersistentManagerScript.Instance.Time++;

    }

    public void GoToSecondScene()
    {
        SceneManager.LoadScene("EndMenuScene");
        PersistentManagerScript.Instance.Time++;

    }


}
