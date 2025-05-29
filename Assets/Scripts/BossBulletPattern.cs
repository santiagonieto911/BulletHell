using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletPattern : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int bulletCount = 36; // Número de balas por ráfaga
    public float fireRate = 1f;  // Tiempo entre ráfagas
    public float bulletSpeed = 5f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= fireRate)
        {
            FireBulletWave();
            timer = 0f;
        }
    }

    void FireBulletWave()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            float baseAngle = i * (360f / bulletCount);
            float waveOffset = Mathf.Abs(Mathf.Sin(5 * baseAngle * Mathf.Deg2Rad)) * 30f; // patrón senoidal
            float finalAngle = baseAngle + waveOffset;

            float rad = finalAngle * Mathf.Deg2Rad;
            Vector2 direction = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));

            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        }
    }
}
