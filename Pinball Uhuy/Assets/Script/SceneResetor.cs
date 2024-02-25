using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneResetor : MonoBehaviour
{

    public Collider bola;
    public GameObject Panel;

    private void OnTriggerEnter(Collider other)
    {
        if(other == bola)
        {
            Panel.SetActive(true);
        }
    }

    public void RestartLevel(string level)
    {
        SceneManager.LoadSceneAsync(level);
    }
}
