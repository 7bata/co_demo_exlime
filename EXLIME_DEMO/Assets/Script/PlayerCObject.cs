using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCObject : MonoBehaviour
{
    public GameObject ObjectPrefabs;
    public float SpawnTime = 0.2f;
    public float SwawnTimeCount;
    public List<GameObject> EggList;
    // Start is called before the first frame update
    void Start()
    {
        SwawnTimeCount = SpawnTime;
    }

    // Update is called once per frame
    void Update()
    {

        if (player.instance.isMoving)
        {
            SwawnTimeCount -= Time.deltaTime;
            if(SwawnTimeCount <= 0)
            {
                EggList.Add(InstantiateObject());
                if (EggList.Count >= player.instance.max_length)
                {
                    GameObject obj = EggList[0];
                    EggList.RemoveAt(0);
                    Destroy(obj);
                }
                SwawnTimeCount = SpawnTime;
                player.instance.slider.value -= 0.005f;
            }
        }
        else
        {
            SwawnTimeCount = SpawnTime;
        }
        if (player.instance.slider.value <= 0)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    //实例化对象
    GameObject InstantiateObject()
    {
        //实例化对象
        GameObject obj = Instantiate(ObjectPrefabs, transform.position, Quaternion.identity);  
        return obj;
    }
}
