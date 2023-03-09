using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float timeBeforeDestroy = 2f;
    private Rigidbody rb;
    private int speed = 10;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        rb.velocity = transform.forward * speed;
        StartCoroutine(DestroyTimer());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("EEEE");
        }
        else if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Health>().TakeDamage(20);
            StopCoroutine(DestroyTimer());
            Destroy(this.gameObject);
        }
    }

    private IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(timeBeforeDestroy);
        Destroy(this.gameObject);
    }
}