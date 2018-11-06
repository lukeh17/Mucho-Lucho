using States;
using UnityEngine;

public class FirstState : State<AIScript> {

    private static FirstState _instance;

    private FirstState()
    {
        if (_instance != null)
            return;

        _instance = this;
    }

    public static FirstState Instance
    {
        get
        {
            if (_instance == null)
            {
                new FirstState();
            }

            return _instance;
        }
    }

    public override void EnterState(AIScript _owner)
    {
        //Debug.Log("Entering Idle Move State");

    }

    public override void ExitState(AIScript _owner)
    {
        //Debug.Log("Exiting First State");
    }

    public float gameTimer;
    public int seconds = 0;
    public bool ChangeState = false;

    public override void UpdateState(AIScript _owner)
    {

        //timer
        if (Time.time > gameTimer + 1)
        {
            gameTimer = Time.time;
            seconds++;

        }

        //choosing move after 3 seconds
        if (seconds == 3)
        {
            seconds = 0;
            ChooseMove();
        }

        if (ChangeState == true)
        {
            _owner.stateMachine.ChangeState(SecondState.Instance);
            ChangeState = false;
        }

    }

    public void ChooseMove()
    {
        int i = Random.Range(0, 100);

        if (i > 20)
        {
            //Debug.Log("Move forward");
            AIScript.AI.MoveForward();
        }

        if (i < 20 && i > 5)
        {
           // Debug.Log("Move Away");
            AIScript.AI.MoveAway();
        }

        if (i < 5)
        {
            //Debug.Log("Idle");
            return;
        }

    }
	
}
