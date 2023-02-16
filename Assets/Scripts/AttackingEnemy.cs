using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingEnemy : MonoBehaviour
{
    float attackDist=10f;
    float dist;
    public Transform player;
    public Transform NPC;
    public NPCstats npc;
    public PlayerStats playerstats;
    public int dmg = 5;
    //public KeyCode attackKey = KeyCode.R;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player").transform;
    }

    public GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        //Debug.Log(closest);
        return closest;

        //NPC = closest.transform;
    }

    void Update()
    {
        //NPC = GameObject.FindGameObjectWithTag("Enemy").transform;
        //NPC = this.gameObject;
        if (GameObject.FindWithTag("Enemy"))
        {
            NPC = FindClosestEnemy().transform;
            dist = Vector3.Distance(NPC.position, player.position);



            if ((dist < attackDist) && (Input.GetMouseButtonDown(0)))
            {
                //npc.curHP -= playerstats.curDamage;
                npc.curHP -= dmg;
            }
            else if ((Input.GetMouseButtonDown(0)) && !(dist < attackDist))
            {
                Debug.Log("aaaaa");
            }
        }
        

        
    }

    
}
