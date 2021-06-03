using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    private float lifetime = 4;
    void Start()
    {
        
    }

    
    void Update()
    {
        lifetime -= Time.deltaTime;

        if(lifetime <= 0) { Destroy(gameObject); }
    }
}
