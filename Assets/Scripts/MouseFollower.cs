using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollower : MonoBehaviour
{
    public GameObject mouseFollow;
    private Camera _camera;
    void Start()
    {
        _camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        mouseFollowing();
    }
    public void mouseFollowing()
    {
        mouseFollow.transform.position=_camera.ScreenToWorldPoint(Input.mousePosition);
    }
}
