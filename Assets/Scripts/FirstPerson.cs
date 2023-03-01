using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FirstPerson : MonoBehaviour
{


    public int points;
    public Text score;
    public Text healthpoints;
    public int actualhealth;
    Rigidbody rigidb;
    private IEnumerator coroutine;
    public List<System.Func<float>> speedOverrides = new List<System.Func<float>>();

    private void Start()
    {
        actualhealth = 100;
        healthpoints.text = "HEALTH:" + actualhealth.ToString();
        coroutine = WaitAndPrint(2.0f);
    }


    //public void QuitGame()
    //{
    //    UnityEditor.EditorApplication.isPlaying = false;
    //}

    private IEnumerator WaitAndPrint(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            actualhealth = actualhealth - 5;
            healthpoints.text = actualhealth.ToString();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Anomaly"))
        {
            StartCoroutine(coroutine);
        }
        

    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (other.gameObject.CompareTag("Artifact"))
            {
                points++;
                other.gameObject.SetActive(false);
                score.text = points.ToString();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Anomaly"))
        {
            StopCoroutine(coroutine);
        }
    }

    void Awake()
    {
        rigidb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {

        //if (Input.GetKeyDown(KeyCode.Escape) || (actualhealth <= 0) || (points == 10) )
        //{
        //    QuitGame();
        //}



    }
}