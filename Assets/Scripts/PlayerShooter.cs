using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public GameObject bulletPrefab;     // Prefab de la bala (tu papa frita)
    public Transform firePoint;         // Punto desde donde se dispara la bala
    public float bulletSpeed = 10f;
    public float fireRate = 0.2f;       // Tiempo entre disparos

    private float nextFireTime = 0f;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = firePoint.up * bulletSpeed;
    }
}

