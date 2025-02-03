using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class Hand : MonoBehaviour
{
    public GameObject bullet;

    private void Awake()
    {
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Shoot()
    {
        GameObject ins = Instantiate(bullet, transform.position, Quaternion.identity);
    }
}