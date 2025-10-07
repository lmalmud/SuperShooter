using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFSM : MonoBehaviour
{

    public enum EnemyState { GoToBase, AttackBase, ChasePlayer, AttackPlayer }
    public EnemyState currentState;
    public Transform baseTransform; // the player base that we are trying toattack
    public float baseAttackDistance; // damage radius to tower
    public float playerAttackDistance; // damage radius to player
    public Sight sightSensor; // the object that will be the eyes - could use GetComponent but in case we change vision
    public float attackBufferDistance; // multiplier for how far away we all there to be before switching states
    private NavMeshAgent agent; // what will do the AI walking
    public GameObject bulletPrefab;
    public float lastShootTime;
    public float fireRate;

    private void Awake()
    {
        // so that when new enemies spawn in, they will be able to find the base
        baseTransform = GameObject.Find("BaseDamagePoint").transform;
        agent = GetComponentInParent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState == EnemyState.GoToBase) { GoToBase(); }
        else if (currentState == EnemyState.AttackBase) { AttackBase(); }
        else if (currentState == EnemyState.ChasePlayer) { ChasePlayer(); }
        else { AttackPlayer(); }
    }

    void GoToBase()

    {
        agent.isStopped = false;
        agent.SetDestination(baseTransform.position);

        if (sightSensor.detectedObject != null) // if we are going towards the base, but see an object instead, chase it!
        {
            currentState = EnemyState.ChasePlayer;
        }

        float distanceToBase = Vector3.Distance(transform.position, baseTransform.position);

        if (distanceToBase < baseAttackDistance) // if we are in range, switch to attack mode
        {
            currentState = EnemyState.AttackBase;
        }
    }

    void AttackBase()
    {

        agent.isStopped = true;
        LookTo(baseTransform.position);
        Shoot();

    }

    void ChasePlayer()
    {
        agent.isStopped = false;

        if (sightSensor.detectedObject == null) // if the eneemy doesn't see anything anymore, then go back to base
        {
            currentState = EnemyState.GoToBase;
            return;
        }

        agent.SetDestination(sightSensor.detectedObject.transform.position);

        float distanceToPlayer = Vector3.Distance(transform.position, sightSensor.detectedObject.transform.position);

        if (distanceToPlayer <= playerAttackDistance) // if within range of attack for the player, start attacking
        {
            currentState = EnemyState.AttackPlayer;
        }
    }
    void AttackPlayer()
    {
        agent.isStopped = true;

        if (sightSensor.detectedObject == null) // if there is no longer something in range, go back to attacking the base
        {
            currentState = EnemyState.GoToBase;
            return;
        }

        LookTo(sightSensor.detectedObject.transform.position);
        Shoot();

        float distanceToPlayer = Vector3.Distance(baseTransform.position, sightSensor.detectedObject.transform.position);

        if (distanceToPlayer > playerAttackDistance * attackBufferDistance)
        {
            currentState = EnemyState.ChasePlayer;
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, playerAttackDistance);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(baseTransform.position, baseAttackDistance);
    }

    void Shoot()
    {
        var timeSinceLastShoot = Time.time - lastShootTime;
        print("shooting");
        if (timeSinceLastShoot > fireRate)
        {
            lastShootTime = Time.time;
            Instantiate(bulletPrefab, baseTransform.position, baseTransform.rotation);
        }
    }

    void LookTo(Vector3 targetPosition)
    {
        Vector3 directionToPosition = Vector3.Normalize(targetPosition - baseTransform.parent.position);
        directionToPosition.y = 0;
        baseTransform.parent.forward = directionToPosition;
    }
}
