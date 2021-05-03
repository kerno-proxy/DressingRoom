using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneManagementScript : MonoBehaviour
{
    [SerializeField]
    GameObject menuPopUp;
    string sceneName = "";
    private void Awake()
    {
        menuPopUp = GameObject.Find("MenuPopUp");
        if (menuPopUp != null)
        {
            menuPopUp.SetActive(false);
        }

    }
    private void Update()
    {
        if (Input.GetKeyDown("f") && menuPopUp != null)
        {
            menuPopUp.SetActive(false);

        }
        if (Input.GetKeyDown("j") && menuPopUp != null)
            {
            menuPopUp.SetActive(true);
            }
    }
    public void StartGame()
    {
        SceneManager.LoadScene("MainCharacterScreen");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void GameMenu()
    {
        if (menuPopUp != null)
        {
            
            if (menuPopUp.activeInHierarchy == true)
            {
                menuPopUp.SetActive(false);
            }
            else
            {
                menuPopUp.SetActive(true);
            }
        } else { Debug.LogError("Missing reference to MenuPopUp"); }

    }

    public void ReturnToGame()
    {
       
        if (menuPopUp.activeInHierarchy == true)
        {
            menuPopUp.SetActive(false);

        }
    }
    public void MainMenuScreen()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void LoadMapScene()
    {
        SceneManager.LoadScene("WorldMap");
    }

    public void LoadBuildingScene()
    {

        if (sceneName != "")
        {
            SceneManager.LoadScene(sceneName);
            sceneName = "";
        }
        else { Debug.LogError("No scene to load at SceneManagementScript"); }
    }
    public void SetSceneNameToLoad(string sceneToLoad)
    {
        sceneName = sceneToLoad;
    }
}
