using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject MyCharacter;
    [SerializeField] int Quantity = 1;
    [SerializeField] string islem = "";
    [SerializeField] GameManager GameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SpawnNews()
    {
        for (int i = 0; i < Quantity; i++)
        {
            Instantiate(MyCharacter, new Vector3(MyCharacter.transform.position.x + 4, MyCharacter.transform.position.y, MyCharacter.transform.position.z - 1), Quaternion.identity);
        }
        switch (islem)
        {
            case "carpi":
                int total1 = GameManager.CharacterQuantity * Quantity;
                for (int i = 0; i < (total1) - GameManager.CharacterQuantity; i++)
                {
                    Instantiate(MyCharacter, new Vector3(MyCharacter.transform.position.x + 4, MyCharacter.transform.position.y, MyCharacter.transform.position.z - 1), Quaternion.identity);
                }
                GameManager.CharacterQuantity = GameManager.CharacterQuantity * Quantity;
                break;
            case "topla":

                for (int i = 0; i < Quantity; i++)
                {
                    Instantiate(MyCharacter, new Vector3(MyCharacter.transform.position.x + 1, MyCharacter.transform.position.y, MyCharacter.transform.position.z - 1), Quaternion.identity);
                }
                GameManager.CharacterQuantity += Quantity;
                break;
            default:
                break;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Debug.Log("collectable");
            SpawnNews();

        }

    }
}
