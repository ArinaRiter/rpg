using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    private float rndm;
    public NPCstats npcstats;
    public AttackingEnemy ae;
    //public Transform closestEnemy;

    public Vector3 vectorEnemy;
    public GameObject enemy;
    //public GameObject drop;
    public GameObject loot;
    void Start()
    {
        rndm = Random.Range(1,101);
        //enemy = GameObject.FindWithTag("Enemy");
        vectorEnemy = enemy.transform.position;


    }

    void Update()
    {
        if (GameObject.FindWithTag("Enemy"))
        {
            //closestEnemy = ae.FindClosestEnemy().transform.position;
            vectorEnemy = ae.FindClosestEnemy().transform.position;
        }
    }
    public void Drop()
    {
        //Object.Instantiate(ScriptableObject.CreateInstance("Coins"), vectorEnemy, Quaternion.identity);
        Instantiate(loot, vectorEnemy, Quaternion.identity);
    }
}
