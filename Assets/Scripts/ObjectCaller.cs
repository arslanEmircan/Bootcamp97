using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCaller : MonoBehaviour
{
    [SerializeField] private ObjectPool objectPool = null;
    public Transform generatorPoint;
    public Transform RampsPoint,BusPointer;
    public Transform player;
    Vector3 pos;
    Vector3 pos2,pos3;
    private void Start()
    {
        pos = new Vector3(-1.48f, 1.403f, 0);
        pos2 = new Vector3(1.48f, 1.403f, 0);
        pos3 = new Vector3(0.04553562f, 2.38f,440);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (player.position.z+5 > generatorPoint.position.z)
        {
            GameObject platform = objectPool.GetPooledObject(0, generatorPoint.transform.position);
            platform.transform.position = new Vector3(platform.transform.position.x, platform.transform.position.y, platform.transform.position.z + 250);
            generatorPoint.transform.position = platform.transform.position;
           
            GameObject ramp = objectPool.GetPooledObject(1, pos);
            ramp.transform.position = new Vector3(-1.48f, 1.403f, ramp.transform.position.z + 68);
            RampsPoint.transform.position = ramp.transform.position;

            GameObject ramp2 = objectPool.GetPooledObject(2, pos2);
            ramp2.transform.position = new Vector3(1.48f, 1.403f, ramp2.transform.position.z + 90);
            ramp2.transform.rotation = Quaternion.Euler(0, 180, 0);
            RampsPoint.transform.position = ramp2.transform.position;

     
        }

        if(BusPointer.position.z < player.position.z +75)
        {
            int rand = Random.Range(0,3);
            float[] arrayInt = {-2.4f, 0, 2.4f};
            GameObject bus = objectPool.GetPooledObject(3, pos3);
            bus.transform.position = new Vector3(arrayInt[rand], 2.25f, player.transform.position.z + 85);
            bus.transform.rotation = Quaternion.Euler(0, 180, 0);
            BusPointer.transform.position = bus.transform.position;
        }

       
    }

}
