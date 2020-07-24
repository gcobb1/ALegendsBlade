using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{ 
    int xPosition = 0;
    Vector3 pos;
    float x;
    float y;
    float z;
    private NavMeshAgent enemyNav;
    public PlayerScript PlayerS;
    public HealthBar HealthBarS;
    public ShieldBar ShieldBarS;
    public GameObject HealthBarObj;
    public GameObject ShieldBarObj;
    public AudioSource EnemyAudioAttack;
    public AudioSource EnemyAudioDeath;
    public GameObject DeathGlow;
    public GameObject AudioEn;
    public GameObject AudioEn2;
    public float health;
    public float healthMax = 100;
    public GameObject EnemyS;
    public GameObject PlayerMain;
    public bool RoundFlag;
    public Animator anim;
    public float speed = 3f;
    public float gravity = -10f;
    public float jumpHeight = 7f;
    public float Distancer;
    Vector3 dirToPlayer;
    Vector3 newPos;
    int SplitDamage = 0;
    public int Damage = 0;
    private float _timerToAttack = 1f; //Random Timer.
    private float _time = 1f;
    private bool _canAttack = false;
    private float _timerToSpawn = 0f; //Random Timer.
    private bool _canSpawn = true;
    public delegate void EnemyKilled();
    public static event EnemyKilled OnEnemyKilled;
    public RoundManager RoundMan;
    public GameObject RoundManObj;


    void Start()
    {
        enemyNav = GetComponent<NavMeshAgent>();
        health = healthMax * PlayerS.Round;
        pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        y = transform.position.y;
        z = transform.position.z;
    
    }
    void Update()
    {
	//Check exact diistance collisiion with player
        Distancer = Vector3.Distance(transform.position, PlayerMain.transform.position);
        if (Distancer > 1.5f)
        {
            dirToPlayer = transform.position - PlayerMain.transform.position;
            newPos = transform.position - dirToPlayer;
            enemyNav.SetDestination(newPos);
        }
        else
        {
            enemyNav.ResetPath();
        }
	//Keep .5 second charge rate for enemy so that it does always immediately attack
	//Attack if withn distance
        if(Distancer < 2f)
        {
            if (_canAttack == true)
            {
                anim.SetTrigger("Attack");
                EnemyAudioAttack.Play();
                if (PlayerS.Shield <= 0)
                { 
                    PlayerS.DecreaseHealth(14);
                    HealthBarS.SetHealth(PlayerS.Health);
                    _timerToAttack = 2f;
                    if (PlayerS.Health <= 0)
                    {
                        PlayerS.GameOver();
                        //If player dies from enemy GameOver Occurs
                    }
                }
		//Proper Damage subtraction  by enemy
                else if ((14 >= PlayerS.Shield) && (PlayerS.Shield > 0))
                {
                    SplitDamage = 14 - PlayerS.Shield;
                    PlayerS.Shield = 0;
                    ShieldBarS.SetShield(0);
                    PlayerS.Health = PlayerS.Health - SplitDamage;
                    HealthBarS.SetHealth(PlayerS.Health);
                    _timerToAttack = 2f;
                }
                else
                {
                    PlayerS.DecreaseShield(14);
                    _timerToAttack = 2f;
                }
            }
            if (_timerToAttack > 0)
            {
                _canAttack = false;
                _timerToAttack -= _time * Time.deltaTime;
            }
            else
            {
                _canAttack = true;
                _timerToAttack = 2f;
            }

        }
    }
	//Enemy takes damage based on sword strength
    public void TakeDamage(int Strength)
    {
        health = health - Strength;
        PlayerS.IncreaseScore(10);
        PlayerS.ScoreText.text = PlayerS.Score.ToString();
    }
	//when health goes below a limit check for death and trigger events correlating
    public void CheckDeath()
    {
        if(health <= 0)
        {  
            anim.SetTrigger("Death");
            EnemyAudioDeath.Play();
            DeathGlow.SetActive(true);
            pos = new Vector3(xPosition, y, z);
            //_timerToAttack = 3.5f;
            Destroy(EnemyS, 3f); //Check this tomorrow
            if (_timerToSpawn > 0f)
            {
                _canSpawn = false;
                _timerToSpawn -= _time * Time.deltaTime;
            }
            else
            {
                _canSpawn = true;
                _timerToSpawn = 5f;
            }
            if (_canSpawn == true)
            {
                if (OnEnemyKilled != null)
                {

                    OnEnemyKilled();
                }
                RoundMan.KilledEnemy();
                RoundMan.CheckRound();
            }
        }
    }
}
