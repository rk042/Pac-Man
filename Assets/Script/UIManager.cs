using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void btn_home()
    {        
        SceneManager.LoadScene(0);
    }

    public void btn_Play()
    {
        SceneManager.LoadScene(1);
    }
}
