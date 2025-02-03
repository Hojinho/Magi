using System;
using Unity.VisualScripting;
using UnityEngine;

[Flags]
internal enum MoveState
{
    None = (0x01 << 0),
    Left = (0x01 << 1),
    Right = (0x01 << 2),
    Up = (0x01 << 3),
    Down = (0x01 << 4),
    Forward = (0x01 << 5),
    Back = (0x01 << 6),
}

[Flags]
internal enum ActionState
{
    None = (0x01 << 0),
    Shoot = (0x01 << 1),
}

public class Body : MonoBehaviour
{
    private MoveState currentMoveState = MoveState.None;
    private ActionState currentActionState = ActionState.None;
    private Hand hand = null;
    
    private float speed = 5f;


    private void Awake()
    {
        hand = GetComponentInChildren<Hand>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        InputState();

        MoveToState();
    }

    private void ActionToState()
    {
        if (currentActionState == ActionState.None)
            return;

        if (InCludeActionState(ActionState.Shoot))
        {
            hand.Shoot();
        }
    }

    private void InputState()
    {
        //move
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentMoveState |= MoveState.Forward;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentMoveState |= MoveState.Back;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentMoveState |= MoveState.Left;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentMoveState |= MoveState.Right;
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            currentMoveState ^= MoveState.Forward;
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            currentMoveState ^= MoveState.Back;
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            currentMoveState ^= MoveState.Left;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            currentMoveState ^= MoveState.Right;
        }

        //action
        if (Input.GetKeyDown(KeyCode.Space))
        {
            hand.Shoot();
        }
    }

    private void MoveToState()
    {
        if (currentMoveState == MoveState.None)
            return;

        float step = speed * Time.deltaTime;

        if (InCludelMoveState(MoveState.Back))
        {
            transform.position += Vector3.back * step;
        }

        if (InCludelMoveState(MoveState.Forward))
        {
            transform.position += Vector3.forward * step;
        }

        if (InCludelMoveState(MoveState.Right))
        {
            transform.position += Vector3.right * step;
        }

        if (InCludelMoveState(MoveState.Left))
        {
            transform.position += Vector3.left * step;
        }
    }

    bool InCludelMoveState(MoveState targetState)
    {
        return (currentMoveState & targetState) == targetState;
    }

    bool InCludeActionState(ActionState targetState)
    {
        return (currentActionState & targetState) == targetState;
    }
}