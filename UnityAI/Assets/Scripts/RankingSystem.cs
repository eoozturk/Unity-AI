using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingSystem : MonoBehaviour
{
    public int rank;
    public float distance;
    public GameObject target;

    void CalculateDistance()
    {
        distance = Vector3.Distance(transform.position, target.transform.position);
    }

    void Update()
    {
        CalculateDistance();    
    }
}
