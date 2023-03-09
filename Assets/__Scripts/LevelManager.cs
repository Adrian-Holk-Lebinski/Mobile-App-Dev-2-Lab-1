using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject gameController;

    public void LoadScene(){
        gameController.SetActive(true);
        SceneManager.LoadSceneAsync(1);
    }

}