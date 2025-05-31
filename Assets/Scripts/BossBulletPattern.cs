using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletPattern : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    public float bulletSpeed = 5f;
    public int bulletCount = 36;

    private float fireTimer = 0f;
    private float modeTimer = 0f;
    private int currentPattern = 0;

    void Update()
    {
        fireTimer += Time.deltaTime;
        modeTimer += Time.deltaTime;

        if (modeTimer >= 10f)
        {
            currentPattern = (currentPattern + 1) % 3; // Solo 3 patrones
            modeTimer = 0f;
        }

        if (fireTimer >= fireRate)
        {
            switch (currentPattern)
            {
                case 0: FireSineWaveCircle(); break;
                case 1: FireStraightDown(); break;
                case 2: FireConeDown(); break;
            }
            fireTimer = 0f;
        }
    }

    void FireSineWaveCircle()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            float baseAngle = i * (360f / bulletCount);
            float waveOffset = Mathf.Abs(Mathf.Sin(5 * baseAngle * Mathf.Deg2Rad)) * 30f;
            float finalAngle = baseAngle + waveOffset;

            float rad = finalAngle * Mathf.Deg2Rad;
            Vector2 dir = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));
            FireBullet(dir);
        }
    }

    void FireStraightDown()
    {
        for (int i = 0; i < bulletCount / 6; i++)
        {
            Vector3 offset = new Vector3(i - bulletCount / 12f, 0, 0);
            FireBullet(Vector2.down, offset);
        }
    }

    void FireConeDown()
    {
        float angleStart = -60f;
        float angleEnd = -120f;

        for (int i = 0; i < bulletCount; i++)
        {
            float angle = Mathf.Lerp(angleStart, angleEnd, i / (float)(bulletCount - 1));
            float rad = angle * Mathf.Deg2Rad;
            Vector2 dir = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));
            FireBullet(dir);
        }
    }

    void FireBullet(Vector2 direction, Vector3 offset = default)
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position + offset, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = direction.normalized * bulletSpeed;
    }
}
