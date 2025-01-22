using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BossBaseState
{
    public abstract void EnterState(BossStateManager state);
    public abstract void UpdateState(BossStateManager state);
    public abstract void OnTriggerEnter2D(BossStateManager state, Collider2D collision);
}
