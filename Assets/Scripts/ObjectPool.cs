using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    //public Transform poolposition;
    //private int current_pool_element = 0; // индекс текущего элемента пула

    public GameObject prefab; //префаб для пула
    public int pool_count = 10; // количество объектов в пуле
    
    public GameObject[] pool_mass;
    private Rigidbody B_rigidboyd; 
   

    void Start()
    {
        prefab = Resources.Load<GameObject>("Bullets/Bullet");
        pool_mass = new GameObject[pool_count];
        for(int i = 0; i < pool_count; i++)
        {
            pool_mass[i] = Instantiate(prefab, transform.position, transform.rotation);
            pool_mass[i].SetActive(false);
            pool_mass[i].transform.SetParent(transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.R))
        {
            //tester.Instance.BulletTP;
            //print(tester.Instance.BulletTP.ToString());
        }
        if(Input.GetKeyDown(KeyCode.F))
        {
            tester.Instance.Test();
        }*/
    }
    void Fire()
    {
        
    }
}
