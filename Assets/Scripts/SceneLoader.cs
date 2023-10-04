using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public float sceneDelay = 2f;


    void start()
    {
    }
    public void load()
    {
        Invoke("SceneLoad", sceneDelay);
        
    }

    public void SceneLoad()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    
}
