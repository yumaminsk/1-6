using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : Singleton<BulletManager>
{
/*public enum BulletType { bullet = 0, pingpong = 1, granate = 2 }
public BulletType BulletTP;  хочу здесь сделать переключение пула*/
public GameObject prefab;
public GameObject bullet;
public GameObject[] pool_mass;
private Rigidbody B_rigidboyd;
private int i = 0;
private int pool_count = 10;

void Awake()
{
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
    for (i = 0; i < pool_mass.Length; i++)
    {
        if (!pool_mass[i].activeInHierarchy)
        {
            return pool_mass[i];
        }
    }
    return null;
}  
}
