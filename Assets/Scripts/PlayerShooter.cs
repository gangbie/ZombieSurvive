using System.Collections;
using System.Collections.Generic;
using UnityEngine.Animations.Rigging;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] Gun gun;
    [SerializeField] float reloadTime;
    [SerializeField] Rig aimRig;
    [SerializeField] WeaponHolder weaponHolder;

    private PlayerHealth player;

    private Animator anim;
    private bool isReloading;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        gun = GetComponentInChildren<Gun>();
        //gameSceneFlow = GetComponent<GameSceneFlow>();
        player = gameObject.GetComponent<PlayerHealth>();
    }

    private void OnReload(InputValue value)
    {
        if (isReloading) return;
        if (gun.bulletRemain == 30) return;

        Reload();
    }

    IEnumerator ReloadingRoutine()
    {
        anim.SetTrigger("Reload");
        isReloading = true;
        aimRig.weight = 0f;
        yield return new WaitForSeconds(reloadTime);
        isReloading = false;
        aimRig.weight = 1f;

        gun.bulletUsed = 0;
        gun.bulletRemain = gun.bulletCapacity;
        GameManager.data.UpdateBullet(gun.bulletRemain);
    }

    public void Reload()
    {
        StartCoroutine(ReloadingRoutine());
    }

    public void Fire()
    {
        weaponHolder.Fire();
        anim.SetTrigger("Fire");
    }

    private void OnFire(InputValue value)
    {
        if (isReloading)
            return;

        if (player.deadCheckForShooter == true)
            return;

        Fire();
    }
}
