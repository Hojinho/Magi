using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    float bulletSpeed = 10f;
    float maxDistance = 100f;
    float bulletLifeTime = 2f;
    float bulletDamage = 100f;
    float timer = 0f;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;

        timer += dt;
        Move(dt);

        if (timer > bulletLifeTime)
        {
            Destroy(gameObject);
        }
    }

    void Move(float dt)
    {
        transform.Translate(Vector2.right * (bulletSpeed * dt));
    }
}