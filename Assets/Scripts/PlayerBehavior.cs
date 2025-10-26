using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerBehavior : MonoBehaviour
{
    public GameObject detectionCylindar;

    private GameObject[] enemies = new GameObject[0];

    // Update is called once per frame
    void FixedUpdate()
    {
        Assert.AreEqual(detectionCylindar.transform.lossyScale.x, detectionCylindar.transform.lossyScale.z);
        Debug.Log("enemies.Length = " + enemies.Length);

        float detectionRadius = detectionCylindar.transform.lossyScale.x / 2.0f;

        float minDistance = detectionRadius;
        GameObject targettedEnemy = null;
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] == null)
            {
                ArrayUtility.RemoveAt<GameObject>(ref enemies, i);
            }
            else if (Vector3.Distance(enemies[i].transform.position,
                                      transform.position) <= detectionRadius)
            {
                float enemyDistance = Vector3.Distance(enemies[i].transform.position,
                                      transform.position);
                if (enemyDistance < minDistance)
                {
                    targettedEnemy = enemies[i];
                    minDistance = enemyDistance;
                }
            }
        }
        
        if(targettedEnemy != null)
        {
            Debug.Log("Targetted enemy is not null!");
            transform.LookAt(targettedEnemy.transform);
        }
    }

    public void AddEnemy(ref GameObject enemy)
    {
        enemies.Append<GameObject>(enemy);
    }
}
