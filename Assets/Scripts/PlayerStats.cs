using System.Collections;
using stats;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerStats : MonoBehaviour
{
    public Stats stats = new Stats(1,600,20,20,20);
    private static bool death;
    private int pointstat = 0;
    public float curHP;
    public float curMP;
    public float curEXP;
    private int showstat = 0;

    void Start()
    {
        death = false;
        Time.timeScale = 1;
        curHP = stats.HP;
        curMP = stats.MP;
    }
    void Update()
    {
        if (curHP > stats.HP)
        {
            curHP = stats.HP;
        }
        if (curHP <= 0)
        {
            curHP = 0;
            death = true;
            Time.timeScale = 0;
        }
        if (curMP < 0)
        {
            curMP = 0;
        }
        if (curMP > stats.MP)
        {
            curMP = stats.MP;
        }
        if (curEXP >= stats.EXP)
        {
            stats.lvlUP();
            curEXP -= stats.EXP;
            pointstat += 5;
        }
        if (showstat == 0) 
        {
            if (Input.GetKeyDown(KeyCode.P)) 
                showstat = 1; 
        }
        else if (showstat == 1) 
        {
            if (Input.GetKeyDown(KeyCode.P)) 
                showstat = 0; 
        }

        if (curEXP >= stats.EXP) 
        {
            stats.lvlUP(); 
            curEXP = 0; 
            pointstat += 5; 
        }
    }
    void OnGUI()
    {
        if (showstat == 1)
        {
            GUI.Box(new Rect(10, 70, 300, 300), "stats");
            GUI.Label(new Rect(10, 95, 300, 300), "LvL " + stats.lvl);
            GUI.Label(new Rect(10, 110, 300, 300), "HP " + stats.HP + "  CurHP " + curHP);
            GUI.Label(new Rect(10, 125, 300, 300), "MP " + stats.MP + "  CurMP " + curMP);
            GUI.Label(new Rect(10, 140, 300, 300), "EXP " + stats.EXP + "  CurEXP " + curEXP);
            GUI.Label(new Rect(10, 155, 300, 300), "STR " + stats.STR);
            GUI.Label(new Rect(10, 170, 300, 300), "vitality " + stats.vitality);
            GUI.Label(new Rect(10, 185, 300, 300), "energy " + stats.energy);

            if (pointstat > 0)
            {
                GUI.Label(new Rect(10, 250, 300, 20), "points" + pointstat.ToString());
                if (GUI.Button(new Rect(150, 155, 20, 20), "+"))
                {
                    if (pointstat > 0)
                    {
                        pointstat -= 1;
                        stats.STR += 1;
                        stats.newdmg();
                    }
                }
                if (GUI.Button(new Rect(150, 170, 20, 20), "+"))
                {
                    if (pointstat > 0)
                    {
                        pointstat -= 1;
                        stats.vitality += 1;
                        stats.newhp();
                    }
                }
                if (GUI.Button(new Rect(150, 185, 20, 20), "+"))
                {
                    if (pointstat > 0)
                    {
                        pointstat -= 1;
                        stats.energy += 1;
                        stats.newmp();
                    }
                }
            }
        }
        else
        {
            if (showstat == 0)
            {
                useGUILayout = false;
                if (death == true)
                {
                    if (GUI.Button(new Rect(Screen.width/2,Screen.height/2,100,50), "ещё раз"))
                        Application.LoadLevel(2);
                }
            }
        }
    }
}
