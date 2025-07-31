using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int enemyHealth = 100;
    private int enemySpeed = 1;

    NavMeshAgent enemyAgent;

    public RectTransform healthBarRect;

    private GameObject playerTargeted;

    public float distanceToTarget = 0.0f;

    public Slider healthBar;

    public GameObject manaPotion;
    public float manaPotionDropChange = 0.1f;

    public int enemyDamage = 10;

    private Animator enemyAnimator;

    private bool hasTarget = true;

    // Start is called before the first frame update
    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        enemyAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        UpdateTransform();

        if (hasTarget && playerTargeted is not null)
        {
            if (GameObject.FindGameObjectWithTag("Player") is not null)
            {
                ChasePlayer(playerTargeted.transform);
            }
        }
    }

    private void UpdateTransform()
    {
        AdjustRotation();
    }

    public void SetNewTarget( GameObject player)
    {
        playerTargeted = player;
    }

    void ChasePlayer( Transform player )
    {
        bool isStriking = enemyAnimator.GetBool("IsStriking");

        if (!isStriking)
        {
            enemyAgent.SetDestination(player.position);
            transform.LookAt(new Vector3(player.position.x, 0.0f, player.position.z));

            enemyAgent.speed = enemySpeed;
        }

        if ((player.position - transform.position).magnitude < distanceToTarget)
        {
            enemyAnimator.SetBool("IsStriking", true);
        }
    }

    void FinishStriking()
    {
        enemyAnimator.SetBool("IsStriking", false);
    }

    public void HitEnemy( int damage)
    {
        enemyHealth = enemyHealth - damage;

        healthBar.GetComponent<Slider>().value = enemyHealth / 100.0f;

        if (enemyHealth <= 0)
        {
            Debug.Log("Enemy defeated");
            KillEnemy();
        }
    }

    public void HitPlayer( GameObject player, int damage)
    {
        player.GetComponent<Player>().DamagePlayer(damage);
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Player":
                HitPlayer(other.gameObject, enemyDamage);
                break;
        }
    }

    private void AdjustRotation()
    {
        Vector3 cameraPosition = Camera.main.transform.position;

        cameraPosition = new Vector3(cameraPosition.x, 0, cameraPosition.z);

        healthBarRect.rotation = new Quaternion(0, cameraPosition.y, 
                                                0, 1.0f);
    }

    private void KillEnemy()
    {
        float rand = Random.value;

        if (rand < manaPotionDropChange)
        {
            Instantiate(manaPotion, gameObject.transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
