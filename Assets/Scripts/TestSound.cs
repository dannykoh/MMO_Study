using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Managers.Sound.Play(Define.Sound.Effect, "UnityChan/univ0001");
        Managers.Sound.Play(Define.Sound.Effect, "UnityChan/univ0002");
    }
}
