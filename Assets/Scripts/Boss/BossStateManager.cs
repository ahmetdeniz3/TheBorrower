using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStateManager : MonoBehaviour
{
    [HideInInspector]
    public GameObject thisObject;
    [HideInInspector]
    public float can;
    [HideInInspector]
    public float dmg;
    [HideInInspector]
    public float Damage;
    public BossBaseState currentState;
    public WaitState waitState = new WaitState();
    public MoveTheGoal goal=new MoveTheGoal();
    public CatchUp CatchUp = new CatchUp();
    public Attack Attack = new Attack();

    void Start()
    {
        thisObject = gameObject;
        //can = GetComponentInParent<HealthScript>().can;
        //Damage = Player.DamageDone;
        //dmg = Player.MainDamage;
        currentState = waitState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
        //   can = GetComponentInParent<HealthScript>().can;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentState.OnTriggerEnter2D(this, collision);
    }
    public void SwitchState(BossBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
    public void killIt(GameObject go)
    {
        Destroy(go);
    }
}
