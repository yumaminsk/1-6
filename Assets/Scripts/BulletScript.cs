using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class BulletScript : MonoBehaviour
{
    public delegate void OnDeathDelegate(float BulletPosx, float BulletPosy, float BulletPosz);
    public static event OnDeathDelegate OnDeathEvent;
    private Rigidbody B_rigidboyd; 

    void Start()
    {

        B_rigidboyd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision other) 
    {
        float BulletPosx = transform.position.x;
        float BulletPosy = transform.position.y;
        float BulletPosz = transform.position.z;
        OnDeathEvent?.Invoke(BulletPosx, BulletPosy, BulletPosz);

        gameObject.SetActive(false);
    }
}
