using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Animator EnemyAnimator;
    public NavMeshAgent Agent;
    Vector3 startPos;
    Collider enemyCollider;
    bool dashed;
    public ParticleSystem HitParticle;
    bool isDeath;

    AudioSource dashHit, catScream;
    // Start is called before the first frame update
    void Start()
    {
        dashHit = GameManager.Instance.AudioSources.GetChild(2).GetComponent<AudioSource>();
        catScream = GameManager.Instance.AudioSources.GetChild(3).GetComponent<AudioSource>();
        enemyCollider = GetComponent<Collider>();
        startPos = transform.position;
    }


    void FixedUpdate()
    {
        if (!dashed)
        {
            if (Vector3.Distance(transform.position, GameManager.Instance.Player.transform.position) < 40f) Agent.SetDestination(GameManager.Instance.Player.transform.position);
            else Agent.SetDestination(startPos);


            if (Agent.velocity.magnitude < 0.1f) EnemyAnimator.SetBool("IsWalk", false);
            else EnemyAnimator.SetBool("IsWalk", true);
        }
        else if (!isDeath)
        {
            isDeath = true;
            HitParticle.Play();
            EnemyAnimator.SetBool("IsDeath", true);
            Destroy(Agent);
        }



    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
            if (!GameManager.Instance.IsDeath)
            {
                GameObject newSound = Instantiate(catScream.gameObject);
                newSound.GetComponent<AudioSource>().Play();
            }

            //catScream.Play();

            if (GameManager.Instance.IsDash)
            {
                Debug.Log("DASHED");

                dashHit.Play();

                enemyCollider.enabled = false;
                dashed = true;
            }
            else
            {
                dashHit.Play();

                GameManager.Instance.IsDeath = true;
                Agent.SetDestination(transform.position);
                GameManager.Instance.Death?.Invoke();

            }
        }
    }
}
