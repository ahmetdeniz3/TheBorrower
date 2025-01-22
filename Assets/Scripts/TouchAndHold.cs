using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;

public class TouchAndHold : MonoBehaviour
{
    private Collider2D collider2;
    public static string ChoosenName;
    private bool fýrlat=false;
    private GameObject player;
    private Camera mcam;
    Vector3 mousepos;
    private Rigidbody2D rb;
    private bool choosenone = false;
    private float timer;
    private float killtime = 1;
    // Start is called before the first frame update
    void Start()
    {
        collider2 = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        mcam = Camera.main;
        player = GameObject.Find("Player");
    }

    void Update()
    {
        Debug.Log(ChoosenName);
        if (ChooseMode.chooseMode&&ChoosenName==gameObject.name&&!fýrlat)
        {
            mousepos = mcam.ScreenToWorldPoint(Input.mousePosition);
            gameObject.transform.position = new Vector3(mousepos.x,mousepos.y,0);
            gameObject.GetComponent<Collider2D>().isTrigger = true;
        }
        else
        {
            gameObject.GetComponent<Collider2D>().isTrigger = false;
        }
        if (fýrlat)
        {
            ChooseMode.chooseMode = false;
            transform.position += new Vector3( mousepos.x,mousepos.y,0) *ChooseMode.ShootSpeed* Time.deltaTime;
            Vector3 rotation = transform.position - mousepos;
            float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rot + 90);
            timer += Time.deltaTime;
            collider2.isTrigger = true;
            if (timer > killtime)
            {
                fýrlat = false;
                Destroy(gameObject);
                ChoosenName = null;
            }
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(gameObject.name==ChoosenName && collision.gameObject.name !="MouseFollower" && collision.gameObject.name!="Player"&&!ChooseMode.chooseMode)
        {
            Destroy(gameObject);
            ChoosenName=null;
        }

    }
    public void OnClickHandler(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        var rayhit = Physics2D.GetRayIntersection(mcam.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if (!rayhit.collider) return;
        if(ChooseMode.chooseMode) ChoosenName = rayhit.collider.gameObject.name;
        if ( ChoosenName == gameObject.name) Debug.Log(rayhit.collider.gameObject.name);
    }
    public void Shoot(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        if (gameObject.name == ChoosenName) fýrlat = true; else fýrlat = false;
    }
}
