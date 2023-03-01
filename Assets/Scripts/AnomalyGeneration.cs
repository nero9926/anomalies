using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Anomaly
{
    private string name;
    private string type;
    private Vector3 position;
    private bool isMovable;
    private float speedMovement;
    private int damageValue;
    private float criticalDamageChance;
    private int criticalDamageValue;
    private string damageType;
    private int damageRadius;
    private int artefactGenerationRadius;
    private List<string> artefacts;
    private int anomalyCapacity;
    private GameObject anomalyPrefab;
    //private Rigidbody anomalyRigid;


    public Anomaly(string name, string type, Vector3 position, bool movement, float SpeedMovement, int damageValue, float critDmgChance, int critDmg, string damageType,
                    int damageRadius, int generRadius, int anomalyCapacity, GameObject anomalyPrefab)
    {
        this.name = name;
        this.type = type;
        this.position = position;
        this.isMovable = movement;
        this.speedMovement = SpeedMovement;
        this.damageValue = damageValue;
        this.criticalDamageChance = critDmgChance;
        this.criticalDamageValue = critDmg;
        this.damageType = damageType;
        this.damageRadius = damageRadius;
        this.artefactGenerationRadius = generRadius;
        this.anomalyCapacity = anomalyCapacity;
        this.anomalyPrefab = anomalyPrefab;

    }

    public Vector3 getPosition()
    {
        return this.position;
    }

    public void updatePosition(Vector3 vector)
    {
        this.position = vector;
    }

    public void generateArtefacts()
    {
        
    }

    public string getName()
    {
        return this.name;
    }

    public string getType()
    {
        return this.type;
    }

    public GameObject getobj()
    {
        return this.anomalyPrefab;
    }

    public void attack(Player player)
    {
        player.UpdateHealth(-(this.damageValue));
    }
}

public class AnomalyGeneration : MonoBehaviour
{
    public GameObject person;
    public GameObject enemy;
    //private Rigidbody rigid;
    

    private void Start()
    {
        //rigid = person.GetComponent<Rigidbody>();
        Anomaly anomaly = new("ELECTRON", "Electric", new Vector3(0, 0, 0), false, 0, 10, 15, 30, "Electricity", 5, 5, 3, enemy);

        for (int i = 0; i < 10; i++)
        {
            Vector3 position = new Vector3(UnityEngine.Random.Range(-50, 50), -0.5f, UnityEngine.Random.Range(-50, 50));
            anomaly.updatePosition(position);
            Instantiate(anomaly.getobj(), anomaly.getPosition(), Quaternion.identity);
        }
    }
}
