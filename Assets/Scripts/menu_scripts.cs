using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu_scripts : MonoBehaviour
{

    public void PlayButton()
    {
        SceneManager.LoadScene("level1");
    }

    public void OptionsButton()
    {
        SceneManager.LoadScene("options");
    }

    public void CreditsButton()
    {
        SceneManager.LoadScene("credits");
    }

    public void BackButton()
    {
        SceneManager.LoadScene("menu");
    }

}   
