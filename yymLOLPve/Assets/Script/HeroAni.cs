using System.Collections;
using System.Collections.Generic;
using UnityEngine;
enum EHeroAni
{
    Idle,
    Run,
    Attack,
    Max
}
public class HeroAni : MonoBehaviour
{
    Animator animator;int Ani = 0;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        PlayerMoveAni();
    }
    public void HeroAniSet( int EHeroAni)
    {
        Ani = EHeroAni;
    }
    void PlayerMoveAni()
    {
        if (false)
        {

        }
        else
        animator.SetInteger("HeroMove",Ani);
    }
}
