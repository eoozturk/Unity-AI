using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Opponent : MonoBehaviour
{
    float speedBoost = 1.0f;
    Vector3 opponentStartPos;
    public GameObject target, sBoostController;
    public NavMeshAgent opponentAgent;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        opponentAgent = GetComponent<NavMeshAgent>();
        opponentStartPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        opponentAgent.SetDestination(target.transform.position);
        if (gameManager.isGameOver)
        {
            opponentAgent.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            transform.position = opponentStartPos;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpeedBoost"))
        {
            sBoostController.SetActive(true);
            opponentAgent.speed = opponentAgent.speed + speedBoost;
            StartCoroutine(SpeedBoostControl());
        }
    }

    private IEnumerator SpeedBoostControl()
    {
        yield return new WaitForSeconds(1.0f);
        sBoostController.SetActive(false);
        opponentAgent.speed = opponentAgent.speed - speedBoost;
    }
}
