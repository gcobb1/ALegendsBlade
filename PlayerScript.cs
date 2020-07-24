using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    
    public LayerMask InteractableLayerS;
    public LayerMask InteractableLayerH;
    public LayerMask InteractableLayerSW;
    public LayerMask InteractableLayerSW2;
    public LayerMask InteractableLayerSW3;
    public LayerMask InteractableLayerSW4;
    public AudioSource Heals;
    public AudioSource DarknessAud;
    public AudioSource LightningAud;
    public AudioSource SunAud;
    public AudioSource LegendAud;
    public AudioSource EndGameAud;
    public AudioSource StartGameAud;
    public AudioSource ChangeRoundAud;
    public GameOver GameOv;
    public GameObject JacketShieldG;
    public GameObject JacketHealthG;
    public GameObject Sword;
    public GameObject SwordBackHand;
    public GameObject OnSword;
    public GameObject OnSwordBackHand;
    public GameObject BladeofLight;
    public GameObject BladeofLightning;
    public GameObject BladeofDarkness;
    public GameObject BladeofTheSun;
    public GameObject ALegendsBlade;
    public GameObject BladeofLightningBH;
    public GameObject BladeofDarknessBH;
    public GameObject BladeofTheSunBH;
    public GameObject ALegendsBladeBH;
    //public GameObject GameOverUI;
    public Animator animChar;
    public bool GameOverQ = false;
    public bool LegendQ = false;
    public int SwordIndex = 0;
    public int SwordIndexBackHand = 0;
    public HealthBar healthBar;
    public ShieldBar ShieldBar;
    public Text RoundText;
    public Text ScoreText;
    public Text ShieldIText;
    public Text HealthIText;
    public Text HelperScreen;
    public Text ControlsText;
    public int ShieldInc = 100;
    public int HealthInc = 100;
    public int MaxHealth = 100;
    public int Health;
    public int MaxShield = 100;
    public int Shield = 0;
    //public int Strength = 20;
    //int SplitDamage = 0;
    public int Damage = 0;
    public int Round;
    public int Kills;
    public int killCounterThreshold = 0;
    public int Score = 500;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public int ShieldsInv;
    public int HealthInv;
    public int WeaponInv;
    public int ColliderCounter = 0;
    //private float _timerToExitText = 5f; //Random Timer.
    public int Counter1 = 0;
    public int Counter2 = 0;
    public int Counter3 = 0;
    public int Counter4 = 0;
    public int Counter5 = 0;
    public int Counter6 = 0;
    public bool CanDisable = false;
    public float disableTimer = 0f;
    public bool isDead = false;
    // private bool _canText = false;


    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
       // Cursor.lockState = CursorLockMode.Locked;
        StartGameAud.Play();
        Round = 1;
        Kills = 0;
        Health = MaxHealth;
        healthBar.SetMaxHealth(Health);
        ShieldBar.SetMaxShield(MaxShield);
        //Shield -= 100;
        ShieldBar.SetShield(Shield);
        Damage = 20;
        OnSword = BladeofLight;
        BladeofLight.SetActive(true);
    //OnSword = Sword.Find("SwordStarter");
}

    // Update is called once per frame
    void Update()
    {
        if (CanDisable == true)
        {
            if(disableTimer > 0f)
            {
                disableTimer -= Time.deltaTime;
            }
            else if (disableTimer <= 0f)
            {
                JacketHealthG.SetActive(false);
                JacketShieldG.SetActive(false);
                CanDisable = false;

            }
        }
        if(disableTimer > 0)
        {

        }
        /*
        if (Input.GetKeyDown(KeyCode.U))
        {
            if (Shield <= 0)
            {
                Health = Health - Damage;
                healthBar.SetHealth(Health);
                if (Health <= 0)
                {
                    Destroy(player, 3f);
                    Debug.Log("Destroying GameObject in 3...2...1");
                }
            }
            else
            {
                if (Damage >= Shield)
                {
                    SplitDamage = Damage - Shield;
                    Shield = 0;
                    ShieldBar.SetShield(0);
                    Health = Health - SplitDamage;
                    healthBar.SetHealth(Health);
                    if (Health <= 0)
                    {
                        Destroy(player, 3f);
                        Debug.Log("Destroying GameObject in 3...2...1");
                    }
                }
                else
                {
                    Shield = Shield - Damage;
                    ShieldBar.SetShield(Shield);
                }
            }      
        }
        */
        if (Input.GetKeyDown(KeyCode.R))
        {
            JacketShieldG.SetActive(false);
            if (ShieldsInv > 0)
            {
                Heals.Play();
                JacketShieldG.SetActive(true);
                disableTimer = 1.5f;
                CanDisable = true;
                ShieldInc = MaxShield - Shield;
                IncreaseShield(ShieldInc);
                ShieldsInv--;
                ShieldIText.text = ShieldsInv.ToString();
            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            JacketHealthG.SetActive(false);
            if (HealthInv > 0)
            {
                Heals.Play();
                JacketHealthG.SetActive(true);
                disableTimer = 1.5f;
                CanDisable = true;
                
                HealthInc = MaxHealth - Health;
                IncreaseHealth(HealthInc);
                HealthInv--;
                HealthIText.text = HealthInv.ToString();
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Collider[] hitShield = Physics.OverlapSphere(attackPoint.position, attackRange, InteractableLayerS);
            if (hitShield.Length > 0) {
                Debug.Log("HitShield");
                hitShield[0].GetComponent<InteractableShield>().Interact();                
            }
            Collider[] hitHealth = Physics.OverlapSphere(attackPoint.position, attackRange, InteractableLayerH);           
            if (hitHealth.Length > 0)
            {
                Debug.Log("HitHealth");
                hitHealth[0].GetComponent<InteractableHealth>().Interact(); 
            }
            
            Collider[] hitLightSword = Physics.OverlapSphere(attackPoint.position, attackRange, InteractableLayerSW);
            if (hitLightSword.Length > 0)
            {
                Debug.Log("HitLightSword");
                hitLightSword[0].GetComponent<InteractableStrength1>().Interact();
            }
            Collider[] hitDarkSword = Physics.OverlapSphere(attackPoint.position, attackRange, InteractableLayerSW2);
            if (hitDarkSword.Length > 0)
            {
                Debug.Log("HitDarkSword");
                hitDarkSword[0].GetComponent<InteractableStrength2>().Interact();
            }
            Collider[] hitSunSword = Physics.OverlapSphere(attackPoint.position, attackRange, InteractableLayerSW3);
            if (hitSunSword.Length > 0)
            {
                Debug.Log("HitSunSword");
                hitSunSword[0].GetComponent<InteractableStrength3>().Interact();
            }
            Collider[] hitLegendsBlade = Physics.OverlapSphere(attackPoint.position, attackRange, InteractableLayerSW4);
            if (hitLegendsBlade.Length > 0)
            {
                Debug.Log("HitLegendsBlade");
                hitLegendsBlade[0].GetComponent<InteractableStrength4>().Interact();
            }


        }

    }
    public void IncreaseScore(int score)
    {
        Score = Score + score;
        ScoreText.text = Score.ToString();

    }
    public void DecreaseScore(int score)
    {
        Score = Score - score;
        ScoreText.text = Score.ToString();
    }
    public void DecreaseHealth(int health)
    {
        Health = Health - health;
        healthBar.SetHealth(Health);
    }
    public void IncreaseHealth(int health)
    {
        Health = Health + health;
        healthBar.SetHealth(Health);
    }
    public void DecreaseShield(int shield)
    {
        Shield = Shield - shield;
        ShieldBar.SetShield(Shield);

    }
    public void IncreaseShield(int shield)
    {
        Shield = Shield + shield;
        ShieldBar.SetShield(Shield);
    }
    IEnumerator GameOverRoutine()
    {

        animChar.SetTrigger("Death");
        EndGameAud.Play();
        yield return new WaitForSeconds(3);
        GameOverQ = true;
        GameOv.GameOverMan(Round, Kills, LegendQ, GameOverQ);
        //For next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void GameOver()
    {
        if (isDead == false)
        {
            StartCoroutine("GameOverRoutine");
            isDead = true;
        }
        else
        {
            return;
        }
    }
}
