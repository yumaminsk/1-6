using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tester : Singleton<tester>
{
    public enum BulletType {bullet = 0, pingpong = 1, granate = 2 }
    public BulletType BulletTP;
    public GameObject prefab;
    public GameObject bullet;
    public GameObject[] pool_mass;
    private Rigidbody B_rigidboyd;
    public int i = 0;
    public GameObject[] poolofBullets;
    private int pool_count = 10;

    void Awake()
   {
        gameObject.name = "BulletManager";
        CreatingBulletPool();
    }
    private void CreatingBulletPool()
    {
        
        
        prefab = Resources.Load<GameObject>("Bullets/Bullet");
        pool_mass = new GameObject[pool_count];
        for (i = 0; i < pool_count; i++)
        {
            pool_mass[i] = Instantiate(prefab, transform.position, transform.rotation);
            pool_mass[i].SetActive(false);
            pool_mass[i].transform.SetParent(transform);
        }
    }
    public GameObject GetBullet()
   {
        for (i = 0; i < pool_count; i++)
        {
            if (!pool_mass[i].activeInHierarchy)
            {
                return pool_mass[i];
            }
            else
            {
                return pool_mass[i=0];
            }
        }
        return null;
   }  
}
