using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public Joystick joystick;
    public Animator anim;
    public int maxHealth;

    public GameObject AIPlayer;
    public Slider HealthBar;

    public int currentHealth;
    public Renderer[] PlayerRenderer;
    public Button punchButton;

    public int CurrentHealth
    {
        get { return currentHealth; }
        set
        {
            currentHealth = value;
        }
    }

    public bool Punched = false;
    public static PlayerController player;
    
    void Awake()
    {
        if (player == null)
        {
            player = this;
        }

    }

    void Start()
    {
        CustColorG.colorG.CustColor();
        punchButton = GameObject.Find("PunchButton").GetComponent<Button>();
        joystick = FindObjectOfType<Joystick>(); //Object.
        AIPlayer = GameObject.Find("AI(Clone)");
        anim = GetComponentInChildren<Animator>();
        currentHealth = maxHealth;
        PlayerRenderer = GetComponentsInChildren<Renderer>();
        HealthBar = GameObject.Find("SliderP").GetComponent<Slider>();
        punchButton.onClick.AddListener(Punch); //(UnityEngine.Events.UnityAction)this.punch
    }

    private bool facingRight = true;
    private Vector3 velocity;
    private float GRAVITY = -20;
    
    void Update()
    {
        if(gameObject == null)
        {
            return;
        }

        if (Controller.col.collisions.above || Controller.col.collisions.below)
        {
            velocity.y = 0;
        }

        Jump();
        //Block();

        Vector2 input = new Vector2(joystick.Horizontal, joystick.Vertical).normalized;

        velocity.x = input.x * moveSpeed;
        velocity.y += GRAVITY * Time.deltaTime;
        Controller.col.Move(velocity * Time.deltaTime);

        if (joystick.Horizontal != 0f && currentHealth > 0)
        {
                anim.Play("Move");
        }

        //change direction facing
        if (joystick.Horizontal > 0 && !facingRight)
        {
            Flip();
        }

        if (joystick.Horizontal < 0 && facingRight)
        {
            Flip();
        }

    }

    void Flip()
    {
        facingRight = !facingRight;

        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    public void ShowDeath()
    {
        StartCoroutine(Disable());
    }

    IEnumerator Disable()
    {
        FindObjectOfType<AudioManager>().Play("death");
        anim.Play("Death");
        yield return new WaitForSeconds(2f);
        anim.enabled = false;
        Destroy(gameObject);
        Destroy(this);
        
    }

    public float jumpVelo = 8;
    
    public void Jump()
    {
        if (Controller.col.collisions.below && joystick.Vertical >= .5f)
        {
            velocity.y = jumpVelo;

            //Play jump Sound 
            FindObjectOfType<AudioManager>().Play("jump");
        }  
    }

    public void Block()
    {
        if (Controller.col.collisions.below && joystick.Vertical <= -.5f)
        {
            //play block animation
        }
    }

    

    public void Punch()
    {
        StartCoroutine(P());
        var r = Random.Range(0,2);

        FindObjectOfType<AudioManager>().Play("Punch");

        if (r == 0 && !anim.GetCurrentAnimatorStateInfo(0).IsName("Death"))
        {
            anim.Play("IdleHandsUp");//might have to put below
            anim.SetLayerWeight(1, 1);
            anim.Play("PunchLeft");
        }
            

        if (r == 1 && !anim.GetCurrentAnimatorStateInfo(0).IsName("Death"))
        {
            anim.Play("IdleHandsUp");//Might have to put below
            anim.SetLayerWeight(1, 1);
            anim.Play("PunchRight");
        } 
    }

    IEnumerator P()
    {
        Punched = true;
        yield return new WaitForSeconds(.25f);
        Punched = false;
    }

    public void Health()
    {
        HealthBar.value = currentHealth * 1.0f / maxHealth;   
    }

    public Object Ragdoll;

    public void ShowRagdoll()
    {
        Instantiate(Ragdoll, gameObject.transform.position, gameObject.transform.rotation);
        
        Destroy(gameObject);
        Destroy(this);
    }
  
    public void H()
    {
        StartCoroutine(ChangeColor());

    
       /* float a = AIPlayer.transform.position.x;
        float p = transform.position.x;


        if (p < a)
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
        foreach (Renderer component in PlayerRenderer)
        {
            component.material.color = Color.red;
        }
        
        yield return new WaitForSeconds(.1f);

        foreach (Renderer component in PlayerRenderer)
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
