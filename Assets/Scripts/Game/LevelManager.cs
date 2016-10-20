using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour 
{

    public void LoadLeval(string name)
    {
        Debug.Log("Level load requested for: " + name);
        //Application.LoadLevel(name);       
        SceneManager.LoadScene(name);
    }

    public void QuitRequest()
    {
        Debug.Log("I Want To Quit!");

        //BAD PRACTICE ANYWAY for Mobil Apps
        Application.Quit(); //older code not supported any longer
    }

    public void LoadNextLevel()
    {
        //this replaces Application.LoadLevel(Application.loadedLevel + 1)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
