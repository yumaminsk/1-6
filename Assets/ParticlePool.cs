using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePool : MonoBehaviour
{
    private int current_particlepool_element = 0; // индекс текущего элемента пула

    public GameObject prefab; //префаб для пула
    public int pool_count = 10; // количество объектов в пуле
    
    private GameObject[] pool_mass;
   

    void Start()
    {
        BulletScript.OnDeathEvent += ParticleEffect;
        pool_mass = new GameObject[pool_count];
        for(int i = 0; i < pool_count; i++)
        {
            pool_mass[i] = Instantiate(prefab, transform.position, transform.rotation);
            pool_mass[i].SetActive(false);
            pool_mass[i].transform.SetParent(transform);
            BulletScript Death = pool_mass[i].GetComponent<BulletScript>();
        }
    }

    void ParticleEffect(float BulletPosx, float BulletPosy, float BulletPosz)
    {
        pool_mass[current_particlepool_element].SetActive(true);
        var particle = pool_mass[current_particlepool_element].GetComponent<ParticleSystem>();
        particle.Play();
        pool_mass[current_particlepool_element].transform.position = new Vector3 (BulletPosx, BulletPosy, BulletPosz);
        current_particlepool_element++;
        print("Explosion");
        if(current_particlepool_element >= pool_count) current_particlepool_element = 0;
    }
   
}
