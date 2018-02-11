using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Camera : MonoBehaviour {

    [SerializeField] private Transform target;

    public float rotSpeed = 1.5f;

    private Vector3 _offset;

    // Use this for initialization
    void Start()
    {
        _offset = target.position - transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = target.position - _offset;
        transform.LookAt(target);
    }
}
