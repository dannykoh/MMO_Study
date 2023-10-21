using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabTest : MonoBehaviour
{
    GameObject prefab;

    void Start()
    {
        prefab = Managers.Resource.Instantiate("Tank");

        Destroy(prefab, 3.0f);

        //prefab = Resources.Load<GameObject>("Prefabs/Tank");
        //GameObject tank = Instantiate(prefab);

        //Destroy(tank, 3.0f);
    }
}
