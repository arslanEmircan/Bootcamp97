using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject MyCharacter;
    [SerializeField] int Quantity = 1;
    [SerializeField] string islem = "";
    [SerializeField] GameManager GameManager;
    bool firstinit = false;
    float posZ = 0;
    float c=0;
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
        if (!firstinit)
        {
            posZ = MyCharacter.transform.position.z;          
            firstinit = true;
        }
        float b = 0.1f;

        Debug.Log("yeni pos " + posZ);
       
        
        switch (islem)
        {
            case "carpi":
                int total1 = GameManager.CharacterQuantity * Quantity;
                for (int i = 0; i < (total1) - GameManager.CharacterQuantity; i++)
                {
                    //Vector3 newVector = new Vector3(MyCharacter.transform.position.x + b, MyCharacter.transform.position.y, MyCharacter.transform.position.z - 1);
                    GameObject bees = ObjectPoolList.SharedInstance.GetPooledObject(); 
                     if (bees != null) {
                        posZ -= 1;
                        Vector3 newVector = new Vector3(MyCharacter.transform.position.x + b, 1.55f, posZ);
                        bees.transform.position = newVector;    
                        bees.SetActive(true);
                     }
                    b = -b;                
                }
                GameManager.CharacterQuantity = GameManager.CharacterQuantity * Quantity;
                break;
            case "topla":
                for (int i = 0; i < Quantity; i++)
                {
                    GameObject bees = ObjectPoolList.SharedInstance.GetPooledObject();
                    if (bees != null)
                    {
                        posZ -= 1;
                        Vector3 newVector = new Vector3(MyCharacter.transform.position.x + b, 1.55f, posZ);
                        bees.transform.position = newVector;
                        bees.SetActive(true);
                    }
                    b = -b;
                }
                GameManager.CharacterQuantity += Quantity;
                break;
            case "cikar":
                for (int i = 0; i < Quantity; i++)
                {
                    if (GameManager.CharacterQuantity -1 >= 1)
                    {
                        ObjectPoolList.SharedInstance.DeactivePooledObject();
                        Debug.Log("cikar");
                        GameManager.CharacterQuantity--;
                    }                   
                }
                //GameManager.CharacterQuantity -= Quantity;
                break;

            case "bol":
                if(GameManager.CharacterQuantity > Quantity)
                {
                    int lastValue = (int) Mathf.CeilToInt(GameManager.CharacterQuantity / Quantity);
                 
                    while (GameManager.CharacterQuantity!= lastValue+1)
                    {
                        Debug.Log("bol" + lastValue + " bu kadar kaldi" + GameManager.CharacterQuantity);

                        if (GameManager.CharacterQuantity - 1 >= 1)
                        {
                            ObjectPoolList.SharedInstance.DeactivePooledObject();
                            Debug.Log("ne kaldi " + GameManager.CharacterQuantity);
                            GameManager.CharacterQuantity--;
                        }
                    }
                }                
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
