using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : Singleton<BulletManager>
{
public enum BulletType { bulletTP, pingpongTP, granateTP }
public BulletType BulletTP;
public GameObject prefab;
public GameObject[] pool_mass;
public GameObject[] pool_granate;
public GameObject[] pool_pingpong;
public GameObject[] pool_switch;
private Rigidbody B_rigidboyd;
private int i = 0;
private int pool_count = 10;
private int switchNum = 0;

    void Awake()
{
    CreatingBulletPool();
    CreatingGranatePool();
    CreatingpingpongPool();
        BulletTP = BulletType.bulletTP;
       
}
    private void Update()
    {
        switch (BulletTP)
        {
            case BulletType.bulletTP:
                pool_switch = pool_mass;
                break;
            case BulletType.pingpongTP:
                pool_switch = pool_pingpong;
                break;
            case BulletType.granateTP:
                pool_switch = pool_granate;
                break;

        }
    }
public void SwitchType()
    {
        int min = 0;
        int max = 2;
        switchNum++;
        if (switchNum >= 3) switchNum = 0;
        else
        {
            BulletTP = (BulletType)Mathf.Clamp(switchNum, min, max);
        }
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
private void CreatingGranatePool()
    {
        prefab = Resources.Load<GameObject>("Bullets/granate");
        pool_granate = new GameObject[pool_count];
        for (i = 0; i < pool_count; i++)
        {
            pool_granate[i] = Instantiate(prefab, transform.position, transform.rotation);
            pool_granate[i].SetActive(false);
            pool_granate[i].transform.SetParent(transform);
        }
    }
private void CreatingpingpongPool()
    {
        prefab = Resources.Load<GameObject>("Bullets/pingpong");
        pool_pingpong = new GameObject[pool_count];
        for (i = 0; i < pool_count; i++)
        {
            pool_pingpong[i] = Instantiate(prefab, transform.position, transform.rotation);
            pool_pingpong[i].SetActive(false);
            pool_pingpong[i].transform.SetParent(transform);
        }
    }
public GameObject GetBullet()
{
    for (i = 0; i < pool_switch.Length; i++)
    {
        if (!pool_switch[i].activeInHierarchy)
        {
            return pool_switch[i];
        }
    }
    return null;
}
    public GameObject Getpingpong()
    {
        for (i = 0; i < pool_pingpong.Length; i++)
        {
            if (!pool_pingpong[i].activeInHierarchy)
            {
                return pool_pingpong[i];
            }
        }
        return null;
    }
}
