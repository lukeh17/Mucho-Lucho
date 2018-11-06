using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using States;
using UnityEngine.UI;

public class AIScript : MonoBehaviour
{
    public StateMachine<AIScript> stateMachine { get; set; }

    public static AIScript AI;
    public GameObject AIFighter;
    public GameObject Player;

    public GameObject Pillar1;
    public GameObject Pillar2;

    public Animator anim;
    float timeToGo;
    private Vector3 velocity;
    public float speed;

    public int maxHealth;
    public Slider HealthBar;
    public Renderer[] AIRenderer;

    public int currentHealth;

    void Awake()
    {
        if(AI == null)
        {
            AI = this;
        }
    }

    public int CurrentHealth
    {
        get { return currentHealth; }
        set
        {
            currentHealth = value;
        }
    }

    private void Start()
    {
        Player = GameObject.Find("Player 1(Clone)");
        Pillar1 = GameObject.Find("Edge1");
        Pillar2 = GameObject.Find("Edge2");
        HealthBar = GameObject.Find("SliderAI").GetComponent<Slider>();
        stateMachine = new StateMachine<AIScript>(this);
        stateMachine.ChangeState(FirstState.Instance);
        timeToGo = Time.time + .5f;
        currentHealth = maxHealth;
        AIRenderer = GetComponentsInChildren<Renderer>();
    }

    public float distance = 100f;

    void Update()
    {
        stateMachine.Update();

        if (Player == null)
        {
            return;
        }

        
        
        distance = Vector2.Distance(Player.transform.position, AIFighter.transform.position);

            
        if (distance < 4)
        {
            //Change to second state, close range to player.
            FirstState.Instance.ChangeState = true;
        }

        //used to slow down the rate attacks are called
        if (Time.time >= timeToGo)
         {
        if (distance < 3)
            {
                Attack();
            }
            timeToGo = Time.time + .5f;
        }
    }

    float p = 0f;

    public Object ragdoll;

    public void ShowRagdoll()
    {
        Instantiate(ragdoll, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
        Destroy(this);
    }

    public void MoveForward()
    {
        
        float a = AIFighter.transform.position.x;

        if (PlayerController.player.currentHealth > 0)
        {
            p = Player.transform.position.x;
        }
            

        if (a < p)
        {
            //flipping character
            if (transform.localScale.x > 0)
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);

            iTween.MoveAdd(gameObject, iTween.Hash("x", 4, "speed", speed));
           // StartCoroutine(Jump());
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Death"))
                anim.Play("Move");
        }
        else
        { 
            //flipping character
            if (transform.localScale.x < 0)
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);

            iTween.MoveAdd(gameObject, iTween.Hash("x", -4, "speed", speed));
            //StartCoroutine(Jump());

            if(!anim.GetCurrentAnimatorStateInfo(0).IsName("Death"))
                anim.Play("Move");
        }

    }

    public void ShowDeath()
    {
        
        StartCoroutine(Disable());
        //play win animation
    }

    IEnumerator Disable()
    {
        FindObjectOfType<AudioManager>().Play("death");
        anim.Play("Death");
        yield return new WaitForSeconds(2f);
        //yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
        anim.enabled = false;
        Destroy(AIFighter);
        Destroy(this);
    }

    public void MoveAway()
    {
        float a = AIFighter.transform.position.x;
        float p = Player.transform.position.x;
        
        if (a < 9.2 && a > -9.2)
        {
            if (a < p)
            {

                if (transform.localScale.x > 0)
                    transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);

                iTween.MoveAdd(gameObject, iTween.Hash("x", -4, "speed", speed));
                //StartCoroutine(Jump());
                if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Death"))
                    anim.Play("Move");
            }
            else
            {

                if (transform.localScale.x < 0)
                    transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);

                iTween.MoveAdd(gameObject, iTween.Hash("x", 4, "speed", speed));
                //StartCoroutine(Jump());
                if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Death"))
                    anim.Play("Move");
            }
        }
        else
        {
            return;
        }
            
    }

    

    public void Flip()
    {
        if (Player == null)
            return;
        
        float a = AIFighter.transform.position.x;
        float p = Player.transform.position.x;
        
        

        if (a < p)
        {
            if (transform.localScale.x > 0)
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            if (transform.localScale.x < 0)
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
        
    }

    IEnumerator Jump()
    {
        FindObjectOfType<AudioManager>().Play("jump");
        iTween.MoveBy(gameObject, iTween.Hash("y", 3, "time", 1f, "easeType", iTween.EaseType.easeInOutSine));
        yield return new WaitForSecondsRealtime(.25f);
        iTween.MoveBy(gameObject, iTween.Hash("y", -3, "time", 1f, "easeType", iTween.EaseType.easeInOutSine));
    }


    public void Attack()
    {
            int r = Random.Range(0, 2);
            

            FindObjectOfType<AudioManager>().Play("Punch");
            if (r == 0 && !anim.GetCurrentAnimatorStateInfo(0).IsName("Death"))
            {
                anim.Play("IdleHandsUp");
                anim.Play("PunchLeft");
            }


            if (r == 1 && !anim.GetCurrentAnimatorStateInfo(0).IsName("Death"))
            {
                anim.Play("IdleHandsUp");
                anim.Play("PunchRight");
            }

    }

    public void Health()
    {
        HealthBar.value = currentHealth * 1.0f / maxHealth;
    }


    public void H()
    {
        //Could probably move this vv
        StartCoroutine(ChangeColor());

        /*float a = AIFighter.transform.position.x;
        float p = Player.transform.position.x;

        if (a < p)
        {
            iTween.MoveAdd(gameObject, iTween.Hash("x", -1, "speed", 1));
        }
        else
        {
            iTween.MoveAdd(gameObject, iTween.Hash("x", 1, "speed", 1));
        }*/
    }

    IEnumerator ChangeColor()
    {
        foreach (Renderer component in AIRenderer)
        {
            component.material.color = Color.red;
        }

        yield return new WaitForSeconds(.1f);

        foreach (Renderer component in AIRenderer)
        {
            component.material.color = Color.white;
        }

    }

    public void Win()
    {
        anim.SetLayerWeight(2, 1);
        anim.Play("Win");
    }

}
