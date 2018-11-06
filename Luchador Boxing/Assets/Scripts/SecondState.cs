using States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondState : State<AIScript>
{

    private static SecondState _instance;

    private SecondState()
    {
        if (_instance != null)
            return;

        _instance = this;
    }

    public static SecondState Instance
    {
        get
        {
            if (_instance == null)
            {
                new SecondState();
            }

            return _instance;
        }
    }

    public override void EnterState(AIScript _owner)
    {
        //Debug.Log("Entering Second State");
        AIScript.AI.Attack();
    }

    public float gameTimer;
    public int seconds = 0;
    
    public override void UpdateState(AIScript _owner)
    {
        //timer
        if (Time.time > gameTimer + 1)
        {
            gameTimer = Time.time;
            seconds++;

        }

        float distance = AIScript.AI.distance;

        if (distance > 5)
        {
            _owner.stateMachine.ChangeState(FirstState.Instance);
        }


        //choosing move after 3 seconds
        if (seconds == 2)
        {
            seconds = 0;
            Move(distance);
        }
        
    }

    public void Move(float distance)
    {

        if (distance > 3)
        {
            AIScript.AI.MoveForward();
        }

        if (distance < 3)
        {
            //Makes sure to flip the right direction. Checks every 2 seconds
            AIScript.AI.Flip();
        }

    }


    public override void ExitState(AIScript _owner)
    {
        //Debug.Log("Exiting Second State");
    }

}