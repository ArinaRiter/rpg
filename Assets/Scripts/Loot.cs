using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    private float rndm;
    public NPCstats npcstats;
    public Vector3 vectorEnemy;
    public GameObject enemy;
    //public GameObject drop;
    public GameObject loot;
    void Start()
    {
        rndm = Random.Range(1,101);
        enemy = GameObject.FindWithTag("Enemy");
        vectorEnemy = enemy.transform.position;
    }

    //void Update()
    //{
    //    if (npcstats.death == true)
    //        Drop();
    //}
    public void Drop()
    {
        //Object.Instantiate(ScriptableObject.CreateInstance("Coins"), vectorEnemy, Quaternion.identity);
        Instantiate(loot, vectorEnemy, Quaternion.identity);
    }
}
