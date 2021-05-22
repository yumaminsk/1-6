using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tester : Singleton<tester>
{
    public enum BulletType {bullet = 0, pingpong = 1, granate = 2 }
    public BulletType BulletTP;
    public ObjectPool prefab;
    public GameObject bullet;
    
    private Rigidbody B_rigidboyd;
    public int i = 0;
    public GameObject[] poolofBullets;

   void Start()
   {
        prefab = Resources.Load<ObjectPool>("Bullets/Objectpool");
        bullet = Resources.Load<GameObject>("Bullets/Bullet");
        poolofBullets = prefab.GetComponent<ObjectPool>().pool_mass;
        GameObject Pool—ontainer = new GameObject();
        Pool—ontainer.transform.position = new Vector3(100f, 100f, 100f);
    }
    public void Test()
   {
        switch (BulletTP)
        {
            case BulletType.pingpong:
                print("pingpong");
                break;
            case BulletType.granate:
                print("granate");
                break;
            default:
                
                break;
        }
   }  
}
