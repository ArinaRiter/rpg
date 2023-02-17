using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NPCstats : MonoBehaviour
{
    public EnStats enstats = new EnStats(10, 50, 2);
    public float curHP;
    public bool death;
    public Loot loot;
    public Slider slider;
    public NPCstats npc;
    public GameObject healthBarUI;
    public Vector3 maincam;

    void Start()
    {
        curHP = enstats.hitPoints;
        slider.value = CalculateHealth();
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

        slider.value = CalculateHealth();
        if (npc.curHP < 50)
        {
            healthBarUI.SetActive(true);
        }
        maincam = GameObject.FindWithTag("MainCamera").transform.position;
        transform.LookAt(maincam);
    }
    private void Death()
    {
        //Destroy(GameObject.FindWithTag("Enemy"));
        //Destroy(Gameobject.Find(name));
        if (curHP == 0)
        {
            Destroy(this.gameObject);
            loot.Drop();
        }
    }
    float CalculateHealth()
    {
        return npc.curHP / 50;
    }
}
