using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : BossBaseState
{
    public override void EnterState(BossStateManager state)
    {

    }
    public override void UpdateState(BossStateManager state)
    {

        if (state.can <= 0)
        {

        }
    }
    public override void OnTriggerEnter2D(BossStateManager state, Collider2D colliison)
    {
        if (colliison.CompareTag("Bullet"))
        {

        }
    }
}
