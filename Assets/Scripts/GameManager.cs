using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int CharacterQuantity = 1;

    public GameObject player;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
    void Update()
    {
        if (player.transform.position.y < -1)
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
    }
    
}
