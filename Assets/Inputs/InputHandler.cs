using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private Camera maincam;
    private void Awake()
    {
        maincam=Camera.main;
    }
    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        var rayhit = Physics2D.GetRayIntersection(maincam.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if (!rayhit.collider) return;
        Debug.Log(rayhit.collider.gameObject.name);
    }

}
