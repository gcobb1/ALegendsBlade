using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ControllerScript : MonoBehaviour
{
    public CharacterController controller;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    //public LayerMask InteractableLayers;
    //public InteractableShield interactableS;
    public EnemyScript Enemy;
    public PlayerScript Player;
    public Animator anim;
    public AudioSource Sword;
    public AudioSource Jump;
    public float x;
    public float z;
    public float speed = 3f;
    public float NewSpeed = 3f;
    public float RunSpeed = 10;
    public float gravity = -10f;
    public float jumpHeight = 6f;
    public GameObject player;
    public Transform groundCheck; 
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public StaminaBar StaminaBar;
    float MaxStamina = 125;
    float Stamina;
    float StaminaDec = .05f;
    public int Strength = 20;
    public bool jumped = false;
    public float timertoLand = 0f;
    public Text SpeedNumber;
    public Text StrengthNumber;




    Vector3 velocity;
    bool isGrounded;
    void Start()
    {
        Stamina = MaxStamina;
        StaminaBar.SetMaxStamina(Stamina);
        anim = GetComponent<Animator>();
        SpeedNumber.text = RunSpeed.ToString();
        StrengthNumber.text = Strength.ToString();




    }
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = RunSpeed;
        }
        else if (Input.GetKey(KeyCode.C))
        {
            speed = 1f;
        }
        else
        {
            speed = NewSpeed;
        }
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (timertoLand > -1)
        {
            timertoLand -= Time.deltaTime;
        }
        if (jumped == true)
        {
            
            if (isGrounded == true)
            {

                if (timertoLand <= 0f)
                {
                    anim.SetTrigger("IsGrounded");
                    jumped = false;
                }
                

            }
        }
        // {
        // Debug.Log("Grounded");
        //}
        //else
        //{
        //  Debug.Log("Not Grounded");
        // }
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        //else if()

        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        if(player.transform.position.y < -10)
        {
            Player.GameOver();
        }
        /*
        if (Input.GetAxis("Horizontal") != 0 && Input.GetAxis("Vertical") != 0)
        {
            anim.SetInteger("condition", 1);
        }
        else
        {
            anim.SetInteger("condition", 0);
        }
        */
        if (Input.GetMouseButtonDown(0))
        {
            if (Stamina > 10)
            {
                //transform.hasChanged = false;
                
                anim.SetTrigger("Attack");
                anim.SetInteger("condition", 0);


                Stamina = Stamina - 10;
                StaminaBar.SetStamina(Stamina);
                Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);
                foreach(Collider enemy in hitEnemies)
                {
                    enemy.GetComponent<EnemyScript>().TakeDamage(Strength);
                    enemy.GetComponent <EnemyScript>().CheckDeath();
                    Sword.Play();
                    //Enemy = enemy;

                }
            }
            
        }
      
        if (transform.hasChanged)
        {
            Stamina = Stamina - (StaminaDec * Time.deltaTime);
            StaminaBar.SetStamina(Stamina);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (x < 0)
                {
                    anim.SetInteger("condition", 14);   //LEFT
                    transform.hasChanged = false;
                    StaminaDec = 10f;
                }
                else if (x > 0)
                {
                    anim.SetInteger("condition", 15);   //Right
                    transform.hasChanged = false;
                    StaminaDec = 10f;
                }
                else if ((x == 0) && (z > 0))
                {
                    anim.SetInteger("condition", 2);   //walk
                    transform.hasChanged = false;
                    StaminaDec = 10f;
                }
                else if ((x == 0) && (z < 0))
                {
                    anim.SetInteger("condition", 13);   //Backwards
                    transform.hasChanged = false;
                    StaminaDec = 10f;
                }
                else
                {
                    anim.SetInteger("condition", 0);
                    transform.hasChanged = false;
                }

            }
            else if (Input.GetKey(KeyCode.C))
            {
                anim.SetInteger("condition", 4);
                transform.hasChanged = false;
                if (Stamina < MaxStamina) { 
                    StaminaDec = -30f;
                }
                else
                {
                    StaminaDec = 0f;
                }
            }
            else
            {
                if(x < 0)
                {
                    anim.SetInteger("condition", 10);   //LEFT
                    transform.hasChanged = false;
                    StaminaDec = .05f;
                }
                else if(x > 0)
                {
                    anim.SetInteger("condition", 11);   //Right
                    transform.hasChanged = false;
                    StaminaDec = .05f;
                }
                else if((x == 0) && (z > 0))
                {
                    anim.SetInteger("condition", 1);   //walk
                    transform.hasChanged = false;
                    StaminaDec = .05f;
                }
                else if ((x == 0) && (z < 0))
                {
                    anim.SetInteger("condition", 12);   //Backwards
                    transform.hasChanged = false;
                    StaminaDec = .05f;
                }
                else
                {
                    anim.SetInteger("condition", 0);
                    transform.hasChanged = false;
                }
            }
        }
        else
        {
            if (Stamina < MaxStamina)
            {
                Stamina = Stamina + (75f * Time.deltaTime);
                StaminaBar.SetStamina(Stamina);
            }
            if (Input.GetKeyDown(KeyCode.Y))
            {
                anim.SetInteger("condition", 3);
            }
            else
            {
                anim.SetInteger("condition", 0);
            }

        }

        Vector3 move = transform.right * x + transform.forward * z;
        if (Stamina > 0f) { 
            controller.Move(move * speed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            anim.SetTrigger("Jump");
            jumped = true;
            //anim.SetInteger("condition", 0);
            Jump.Play();
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            timertoLand = .2f;
            timertoLand -= Time.deltaTime;

            
        }

        velocity.y += 3 * gravity * Time.deltaTime;
        //if (Stamina > 0)
        //{
            controller.Move(velocity * Time.deltaTime);
        
        // }
    }
 
}
