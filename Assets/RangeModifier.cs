using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeModifier : MonoBehaviour
{
    public Transform[] enemyPos;
    public float distance;
    public float rangeRadius = 10f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (enemyPos.Length == 0) return;

        foreach (Transform enemy in enemyPos)
        {
            distance = Vector3.Distance(transform.position, enemy.position);
            if (distance <= rangeRadius)
            {
                transform.LookAt(enemy.position);
                break;
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangeRadius);
    }
}