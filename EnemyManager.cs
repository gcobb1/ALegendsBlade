using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Manages Enemy Spawn, OnKill Update, Destroy, and other
public class EnemyManager : MonoBehaviour
{
    public delegate void EventType();
    public static event EventType EventInstanceName;
    public static void RemoveEventListener(Action methodListener)
    {
        foreach (Delegate d in EventInstanceName.GetInvocationList())
            if (d.Method.Name == methodListener.Method.Name)
                EventInstanceName-= (EventType)d;
    }
    public Transform m_SpawnPoint;
    public GameObject m_EnemyPrefab;
    //public HealthBar HealthBarMan;
    public GameObject MainCh;
    // Start is called before the first frame update
    void Start()
    {
        SpawnNewEnemy();
    }
	//listen for enemy killed and then call spawn new
    public void OnEnable()
    {
        EnemyScript.OnEnemyKilled += SpawnNewEnemy;


    }
	//kill listener
    void OnDestroy()
    {
        EnemyScript.OnEnemyKilled -= SpawnNewEnemy;
    }
	//Creates instances for the enemyscript by object per enemy	
    public void SpawnNewEnemy()
    {
        GameObject obj = (GameObject)Instantiate(m_EnemyPrefab, m_SpawnPoint.transform.position, Quaternion.identity);
        obj.GetComponent<EnemyScript>().PlayerMain = GameObject.FindWithTag("Player");
        MainCh.GetComponent<ControllerScript>().Enemy = obj.GetComponent<EnemyScript>();
        obj.GetComponent<EnemyScript>().HealthBarObj = GameObject.FindWithTag("health");
        obj.GetComponent<EnemyScript>().HealthBarS = obj.GetComponent<EnemyScript>().HealthBarObj.GetComponent<HealthBar>();
        obj.GetComponent<EnemyScript>().ShieldBarObj = GameObject.FindWithTag("shield");
        obj.GetComponent<EnemyScript>().ShieldBarS = obj.GetComponent<EnemyScript>().ShieldBarObj.GetComponent<ShieldBar>();
        obj.GetComponent<EnemyScript>().PlayerS = obj.GetComponent<EnemyScript>().PlayerMain.GetComponent<PlayerScript>();
        obj.GetComponent<EnemyScript>().RoundManObj = GameObject.FindWithTag("Round");
        obj.GetComponent<EnemyScript>().RoundMan = obj.GetComponent<EnemyScript>().RoundManObj.GetComponent<RoundManager>();
        obj.GetComponent<EnemyScript>().AudioEn = GameObject.FindWithTag("EnemyAud");
        obj.GetComponent<EnemyScript>().EnemyAudioAttack = obj.GetComponent<EnemyScript>().AudioEn.GetComponent<AudioSource>();
        obj.GetComponent<EnemyScript>().AudioEn2 = GameObject.FindWithTag("EnemyAud2");
        obj.GetComponent<EnemyScript>().EnemyAudioDeath = obj.GetComponent<EnemyScript>().AudioEn2.GetComponent<AudioSource>();
    }
}

