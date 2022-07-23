using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void changeToMenu()
    {
        SceneManager.LoadSceneAsync("Menu");
    }
    public void changeToScanner1()
    {
        SceneManager.LoadSceneAsync("Scanner1");
    }
    public void changeToScanner2()
    {
        SceneManager.LoadSceneAsync("Scanner2");
    }
    public void changeToGenerator1()
    {
        SceneManager.LoadSceneAsync("Generator1");
    }
}
