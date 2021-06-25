
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneContoller : MonoBehaviour
{
   
    public void ReplayGame()
    {
        SceneManager.LoadScene(1);
    }
}