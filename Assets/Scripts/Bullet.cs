using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 3;
    public bool enemy;
    public EnemyAI Enemy;


    private void Awake()
    {
        
        Destroy(gameObject, life);
    }
    private void Start()
    {
        gameObject.tag = "Enemy"; 
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == tag && enemy == false)
        {
            collision.gameObject.GetComponent<EnemyAI>().TakeDamage(10);
            Debug.Log("destroyed");
        }
        
            Destroy(gameObject);
            
     
       
    }
}
