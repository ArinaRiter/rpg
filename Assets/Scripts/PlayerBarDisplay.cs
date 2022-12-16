using UnityEngine;
using System.Collections;

public class PlayerBarDisplay : MonoBehaviour
{
    public GUISkin mySkin;
    public PlayerStats Char;
    public bool Visible = true;

    private void Start()
    {
       
    }

    private void OnGUI()
    {
        if(Visible)
        {
            GUI.skin = mySkin;
            PlayerStats PlayerSt = (PlayerStats)Char.GetComponent("PlayerStats");
            float MaxHealth = PlayerSt.stats.HP;
            float CurHealth = PlayerSt.curHP;
            float MaxMana = PlayerSt.stats.MP;
            float CurMana = PlayerSt.curMP;
            float needExp = PlayerSt.stats.EXP;
            float curExp = PlayerSt.curEXP;

            float HealthBarLen = CurHealth/MaxHealth;
            float ManaBarLen = CurMana/MaxMana;
            float ExpBarLen = curExp/needExp;

            GUI.Box(new Rect(10, 15, 254*HealthBarLen, 15), " ", GUI.skin.GetStyle("HPbar"));
            GUI.Box(new Rect(10, 30, 254*ManaBarLen, 15), " ", GUI.skin.GetStyle("MPbar"));
            GUI.Box(new Rect(10, 55, 254*ExpBarLen, 15), " ", GUI.skin.GetStyle("EXPbar"));
            GUI.Box(new Rect(10, 10, 254, 64), " ", GUI.skin.GetStyle("PlayerBar"));

        }
        
    }
    private void Update()
    {
        
    }

}

