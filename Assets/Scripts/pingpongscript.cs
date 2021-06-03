using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pingpongscript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(TurnOff());
        IEnumerator TurnOff()
        {
            yield return new WaitForSeconds(3);
            gameObject.SetActive(false);
        }
    }
}
