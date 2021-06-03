using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : Singleton<BulletManager>
{
    public enum BulletType { bulletTP, pingpongTP, granateTP }
    public BulletType BulletTP;
    public GameObject prefab;
    public List<GameObject> pool_mass = new List<GameObject>();

    public List<GameObject> pool_granate = new List<GameObject>();
    public List<GameObject> pool_pingpong = new List<GameObject>();
    public List<GameObject> pool_switch;
    private Rigidbody B_rigidboyd;
    private int i = 0;
    private int pool_count = 10;

    void Awake()
    {
        CreatingPool(Resources.Load<GameObject>("Bullets/Bullet"), pool_mass);
        CreatingPool(Resources.Load<GameObject>("Bullets/granate"), pool_granate);
        CreatingPool(Resources.Load<GameObject>("Bullets/pingpong"), pool_pingpong);

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
    
    private void CreatingPool(GameObject prefab, List<GameObject> pool)
    {
        //pool = new List<GameObject>();
        for (i = 0; i < pool_count; i++)
        {
            GameObject obj = Instantiate(prefab, transform.position, transform.rotation);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }
    private List<GameObject> GetPool(BulletType type )
    {
        switch (type)
        {
            case BulletType.bulletTP:
                return pool_mass;
            case BulletType.pingpongTP:
                return pool_pingpong;
            case BulletType.granateTP:
                return pool_granate;

            default:
                return pool_mass;
        }
    }


public GameObject GetBullet(int w)
{
        print(w);
        List<GameObject> pool1 = GetPool((BulletType)w); // было switchnum

        for (i = 0; i < pool1.Count; i++)
    {
        if (!pool1[i].activeInHierarchy)
        {
            return pool1[i];
        }
        if( i > 10) { i = 0; }
    }
    return null;
}
}
