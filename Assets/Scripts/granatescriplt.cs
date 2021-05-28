using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class granatescriplt : MonoBehaviour
{
    public GameObject particlegranate;
    private bool isparticle = false;
    private float radius = 5f;
    private float lifetime = 3f;
    void Start()
    {
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
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach(Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                float force = 80f;
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }
    }
}
