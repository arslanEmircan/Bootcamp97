using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] int finishQuantity;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            if (gameManager.CharacterQuantity >= finishQuantity)
                SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
            else
                SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);

        }       
    }
}
