using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSpawn : MonoBehaviour
{
    public float waitTimeBD = 3f;

    void Start()
    {
        Destroy(gameObject, waitTimeBD);
    }
}
