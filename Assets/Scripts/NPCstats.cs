using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NPCstats : MonoBehaviour
{
    public EnStats enstats = new EnStats(10, 50, 2);
    public float curHP;
    public static bool death;

    void Start()
    {
        curHP = enstats.hitPoints;
    }
    void Update()
    {
        //if (curHP > enstats.hitPoints)
        //    curHP = enstats.hitPoints;
        if (curHP <= 0)
        {
            curHP = 0;
            death = true;
        }
        if (death == true)
            Death();
    }
    private void Death()
    {
        Destroy(GameObject.FindWithTag("NPC"));
    }
}
