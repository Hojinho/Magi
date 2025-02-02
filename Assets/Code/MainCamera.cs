using System;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] private Transform target = null;

    private float _height = 10f;

    private void Awake()
    {
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        this.transform.position = new Vector3(target.position.x, target.transform.position.y + _height,
            target.transform.position.z);
    }

    void SetTarget(Transform target)
    {
        this.target = target;
    }

    void RemoveTarget()
    {
        this.target = null;
    }
}