using UnityEngine;
using UnityEngine.AI;

public class CubeMove : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;

    private float totalDistance;
    private bool isTriggered = false;
    private enum EnemyState { Moving, Jumping, SpeedBoost }
    private EnemyState currentState = EnemyState.Moving;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(target.position);
        totalDistance = Vector3.Distance(transform.position, target.position); //Tổng khoảng cách
    }

    void Update()
    {
        float remainingDistance = Vector3.Distance(transform.position, target.position); //khoảng cách còn lại

        if (!isTriggered && remainingDistance <= (2f / 3f) * totalDistance)
        {
            isTriggered = true;
            PerformRandomAction();
        }
    }

    void PerformRandomAction()
    {
        int randomAction = Random.Range(0, 2); // 0 for jump, 1 for speed boost
        if (randomAction == 0)
        {
            //Jump();
            SpeedBoost();
        }
        else
        {
            //SpeedBoost();
            Jump();
        }
    }

    void Jump()
    {
        currentState = EnemyState.Jumping;
        Debug.Log("Enemy is jumping!");
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);
        }
        Invoke("ResetState", 1f);
    }

    void SpeedBoost()
    {
        currentState = EnemyState.SpeedBoost;
        Debug.Log("Enemy speed boosted!");
        agent.speed *= 2;
        Invoke("ResetSpeed", 2f);
    }

    void ResetSpeed()
    {
        agent.speed /= 2;
        ResetState();
    }

    void ResetState()
    {
        currentState = EnemyState.Moving;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            Debug.Log("Game Over! Quái đã đến đích.");
            Destroy(gameObject);
            // Gọi màn hình Game Over
        }
    }
}
