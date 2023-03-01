using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform[] ts;
    public GameObject person;
    public Text text;
    public float limit = 10f;
    public float speed = 1f;
    public GameObject enemy;
    private Rigidbody rigid;
 

    private void Start()
    {
        rigid = person.GetComponent<Rigidbody>();
        for (int i = 0; i < 10; i++)
        {
            int randx = UnityEngine.Random.Range(0, 10);
            int randy = UnityEngine.Random.Range(0, 10);

            Vector3 pos = new Vector3(UnityEngine.Random.Range(-50, 50), 0.5f, UnityEngine.Random.Range(-50, 50));
            Instantiate(enemy, pos, Quaternion.identity);


        }
 
    }
    
    private void Update()
    {
  
 
    }


}
