using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    [SerializeField] Vector3 rotate;

    void Update()
    {
        transform.Rotate(rotate);
    }
}
