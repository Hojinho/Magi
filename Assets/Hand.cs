using System;
using Unity.VisualScripting;
using UnityEngine;

public class Hand : MonoBehaviour
{
    private GameObject bullet = null;

    private void Awake()
    {
        bullet = Resources.Load<GameObject>("Prefabs/Bullet");
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
        Instantiate(bullet, transform.position, Quaternion.identity);
    }
}