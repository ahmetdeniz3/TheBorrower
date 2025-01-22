using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChooseMode : MonoBehaviour
{
    public static float ShootSpeed=10f;
    public static bool isChooseable;
    public static bool chooseMode;
    private CircleCollider2D circleCollider;
    public static float radiusCm = 3.5f;
    // Start is called before the first frame update
    void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        circleCollider.radius = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (chooseMode)
            {
                circleCollider.radius = 0;
                chooseMode = false;
                Debug.Log("choose mod kapandý");
            }
            else
            {
                    circleCollider.radius = radiusCm;
                    chooseMode = true;
                    Debug.Log("choose mod açýldý");
            }
        }
    }
   /* private void OnTriggerStay2(Collider2D collision)
    {
        if (collision.name == "MouseFollower"&&chooseMode==true)
        {
            Debug.Log("fare içeride");
            isChooseable = true;
        }
        else
        {
            isChooseable=false;
        }
    }
   */
}
