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
        NPC = GameObject.FindGameObjectWithTag("NPC").transform;
        dist = Vector3.Distance(NPC.position, player.position);
    }

    void Update()
    {
        if ((Input.GetMouseButtonDown(0))&&(dist<attackDist))
        {
            //npc.curHP -= playerstats.curDamage;
            npc.curHP -= dmg;
        }
    }
}
