using System.Collections;
using UnityEngine;

public class PlayerAnimStuff : MonoBehaviour
{
    public PlayerCombat player;
    public int playerAttack;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CanAttack()
    {
        playerAttack = player.lightAttackCount;
        player.canAttack = true;
        
        player.currentAttack = playerAttack;
        player.Cant();
    }

    public void Sheethed()
    {
        player.lightAttackCount = 0;
        player.canAttack = true;
     
        player.anim.SetBool("Sheeth", false);
    }


}
