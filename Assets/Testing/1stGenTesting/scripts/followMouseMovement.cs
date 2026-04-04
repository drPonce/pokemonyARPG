using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FollowMouse : MonoBehaviour
{
    private Camera mainCamera;

    [SerializeField] private float maxSpeed = 10f;
    [SerializeField] private Animator animatorRef;
    [SerializeField] private bool bolingueVibes = true;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        FollowMousePositionDelayed(maxSpeed);

    }

    private void FollowMousePosition()
    {
        transform.position = GetWorldPositionFromMouse();

       
    }

    private void FollowMousePositionDelayed(float maxSpeed)
    {
        transform.position = Vector3.MoveTowards(transform.position, GetWorldPositionFromMouse(),maxSpeed*Time.deltaTime);
        Vector3 golira = GetWorldPositionFromMouse();
        Vector2 directionFromCharToMouse = golira - transform.position;

        if (Mathf.Abs(directionFromCharToMouse.x) > Mathf.Abs(directionFromCharToMouse.y))
        {
            // Horizontal
            if (directionFromCharToMouse.x > 0)
                animatorRef.SetInteger("directionClockwise", 1); // Right
            else
                animatorRef.SetInteger("directionClockwise", 3); ; // Left
        }
        else
        {
            // Vertical
            if (directionFromCharToMouse.y > 0)
                animatorRef.SetInteger("directionClockwise", 0); // Up
            else
                animatorRef.SetInteger("directionClockwise", 2); // Down
        }
    }

    private Vector2 GetWorldPositionFromMouse()
    {
        return mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
    }
}