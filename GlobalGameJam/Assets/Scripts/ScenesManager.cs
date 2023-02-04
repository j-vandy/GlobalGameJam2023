using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public enum Scene
    {
        MainMenu,
        Back2Roots,
        SweptAway,
        GotToRoots
    }

    public static ScenesManager instance;

    private void Awake()
    {
        instance= this;
    }

    public void LoadScene(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(Scene.MainMenu.ToString());
    }
    public void LoadBack2Roots()
    {
        SceneManager.LoadScene(Scene.Back2Roots.ToString());
    }

}
