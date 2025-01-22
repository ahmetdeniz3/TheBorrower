using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static float MainDamage;
    public static int Health = 3;
    public static float DamageDone = 1;
    public static int NumberOfBullets;
    public static float BullletSpeed = 10f;
    public static float speed = 80f;
    public static float currentspeed;



    public Camera Camera;
    public float delay = 1;
    public GameObject Enemy;
    private Rigidbody2D rb;
    public float startDelay = 1.0f;
    public Vector2 move;
    public float lastHorizontalVector;
    public float lastVerticalVector;
    [HideInInspector]
    public Vector2 lastMovedVector;


    public static float maxExp;
    public static int Exp;
    public static int level;
    public static bool LevelUp;
    void Start()
    {
        MainDamage = DamageDone;
        currentspeed = speed;
        LevelUp = false;
        level = 1;
        maxExp = 3;
        Exp = 0;
        rb = GetComponent<Rigidbody2D>();
        lastMovedVector = new Vector2(1, 0f);
        // Invoke("SpawnEnemy", startDelay);
    }

    void Update()
    {
        move = new Vector2(Input.GetAxis("Horizontal"),0);
        LastVector();
        //levelUp
        if (maxExp == Exp || maxExp < Exp)
        {
            level++;
            LevelUp = true;
            maxExp = maxExp * 1.2f;
            Exp = 0;
        }

    }
    private void FixedUpdate()
    {
        rb.velocity = move * speed * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //CollectingExp
        if (collision.CompareTag("Exp"))
        {
            Destroy(collision.gameObject);
            Exp++;
            Debug.Log("Exp:" + Exp + " Level:" + level + "MaxExp" + maxExp);
        }

    }
    private void LastVector()
    {
        if (move.x != 0)
        {
            lastHorizontalVector = move.x;
            if (lastHorizontalVector < 0)
            {
                lastHorizontalVector = -1;
            }
            else if (lastHorizontalVector > 0)
            {
                lastHorizontalVector = 1;
            }
            lastMovedVector = new Vector2(lastHorizontalVector, 0);
        }
        if (move.y != 0)
        {
            lastVerticalVector = move.y;
            if (lastVerticalVector < 0)
            {
                lastVerticalVector = -1;
            }
            else if (lastVerticalVector > 0)
            {
                lastVerticalVector = 1;
            }
            lastMovedVector = new Vector2(0, lastVerticalVector);
        }

        if (move.x != 0 && move.y != 0)
        {
            lastMovedVector = new Vector2(lastHorizontalVector, lastVerticalVector);
        }
    }


}
