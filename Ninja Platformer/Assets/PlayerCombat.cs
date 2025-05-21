using System.Collections;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator anim;
    public int lightAttackCount;
    public int currentAttack;
    public bool attacking;
    public bool canAttack;
    public GameObject FollowUp;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        attacking = false;
        canAttack = true;
        currentAttack = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(lightAttackCount > 0)
        {
            attacking = true;
        }
        else
        {
            attacking = false;
        }

        if(Input.GetMouseButtonDown(0) && lightAttackCount < 3 && canAttack == true )
        {
           canAttack = false;
            lightAttackCount += 1;

        }

        if(canAttack == true)
        {
            FollowUp.SetActive(true);
        }

        if (canAttack == false)
        {
            FollowUp.SetActive(false);
        }


        if (lightAttackCount == 0)
        {
            anim.SetInteger("LightAttackCount", 0);

        }
        if (lightAttackCount == 1 )
        {
            anim.SetInteger("LightAttackCount", 1);
            
        }
        if (lightAttackCount == 2)
        {
            anim.SetInteger("LightAttackCount", 2);
            
        }
        if (lightAttackCount == 3 )
        {
            anim.SetInteger("LightAttackCount", 3);
            
        }
    }

    public void Cant()
    {
        if (currentAttack == lightAttackCount)
        {
            StartCoroutine(CantAttack());
        }
    }

    public IEnumerator CantAttack()
    {

        
            yield return new WaitForSeconds(0.25f);
        if (currentAttack == lightAttackCount)
        {
            canAttack = false;
                anim.SetBool("Sheeth", true);

        }

    }
}
