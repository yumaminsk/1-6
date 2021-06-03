using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class granatescriplt : MonoBehaviour
{
    public GameObject particlegranate;
    private bool isparticle = false;
    private float radius = 5f;
    private float lifetime = 3f;
    public event Action OnCollisionEvent;
    void Start()
    {
        particlegranate = Resources.Load<GameObject>("Bullets/BigExplosion");
        lifetime = 3f;
    }
   
    void Update()
    {
        if (isparticle)
        {
            lifetime -= Time.deltaTime;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        OnCollisionEvent?.Invoke();
        Instantiate(particlegranate, transform.position, transform.rotation);
        TurnoffActivity();
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach(Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                float force = 1000f;
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }
    }
    void TurnoffActivity()
    {
        gameObject.SetActive(false);
    }
}
