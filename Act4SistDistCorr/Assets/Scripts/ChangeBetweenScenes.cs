using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeBetweenScenes : MonoBehaviour
{
    public void GoHome()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
