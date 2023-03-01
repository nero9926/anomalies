using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;


public class Generation : MonoBehaviour
{
    public GameObject loot;
    private IEnumerator generate;
    private Rigidbody rigid;
    private bool collider—ount;
    SphereCollider myCollider;
    //private float waitTime;

    void Start()
    {
        myCollider = GetComponent<SphereCollider>();
        //waitTime = 10.0f;
    }

    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, myCollider.radius);
        //Debug.Log(hitColliders.Length);
        
        if (hitColliders.Length >= 2)
        {
            collider—ount = false;
            //StopCoroutine(WaitAndPrint(10.0f));

        }
        else
        {
            collider—ount = true;
            //StartCoroutine(WaitAndPrint(10.0f));
            //Invoke ("gener", UnityEngine.Random.Range(waitTime * 0.5f, waitTime * 1.5f));
            Invoke("Gener", 10f);
        }
    }

    void Gener()
    {
        if (collider—ount == true)
        {
            Vector3 spawn = new(UnityEngine.Random.Range(transform.position.x - myCollider.radius, transform.position.x + myCollider.radius), transform.position.y, UnityEngine.Random.Range(transform.position.z - myCollider.radius, transform.position.z + myCollider.radius));
            Instantiate(loot, spawn, Quaternion.identity);
        }
    }

    //private IEnumerator WaitAndPrint(float waitTime)
    //{
    //    //while(true)
    //    ////if (collidercount == true)
    //    //{
    //        yield return new WaitForSeconds(UnityEngine.Random.Range(waitTime * 0.5f, waitTime * 1.5f));
    //        //if (collidercount == true)
    //        //{

    //        //yield return new WaitForSeconds(waitTime);
    //        if (collidercount == true)
    //        {
    //            Vector3 spawn = new Vector3(UnityEngine.Random.Range(transform.position.x - myCollider.radius, transform.position.x + myCollider.radius), transform.position.y, UnityEngine.Random.Range(transform.position.z - myCollider.radius, transform.position.z + myCollider.radius));
    //            Instantiate(loot, spawn, Quaternion.identity);
    //        }
    //        //}

    //    //}

}
