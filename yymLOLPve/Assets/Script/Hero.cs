using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Hero : MonoBehaviour
{ 
    private void Awake()
    {
        //    HeroDataSet();
        gameObject.AddComponent<HeroState>();

    }
    void Start()
    {
    }
   public void HeroDataSet()
    {
    }
    void Update()
    {
        
    }
}

