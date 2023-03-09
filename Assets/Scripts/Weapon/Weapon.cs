using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponData data;
    [SerializeField] private GameObject bullet;

    [SerializeField] private Transform bulletStartPosition;
    private bool isCooldown = false;

    public void Attack()
    {
        if (!isCooldown)
        {
            Instantiate(bullet, bulletStartPosition.position, bulletStartPosition.rotation);
            StartCoroutine(TimerBeforeCanShoot());
        }
    }

    public void Unlock()
    {
        data.isUnlocked = true;
    }

    private IEnumerator TimerBeforeCanShoot()
    {
        isCooldown = true;
        yield return new WaitForSeconds(data.AttackCooldown);
        isCooldown = false;
    }
}