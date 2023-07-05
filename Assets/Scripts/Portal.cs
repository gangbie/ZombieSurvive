using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private GameObject player;
    public LayerMask targetMask;
    public WeaponHolder weaponHolder;

    private Collider col;

    private void Awake()
    {
        col = GetComponent<Collider>();
        player = GameObject.FindGameObjectWithTag("Player");
        weaponHolder = player.GetComponentInChildren<WeaponHolder>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (GameManager.Instance.curStageNum == 1)
        {
            if (GameManager.data.GunInfo == "Default Gun")
                GameManager.data.curGunNum = 0;
            if (GameManager.data.GunInfo == "Famas Gun")
                GameManager.data.curGunNum = 1;
            GoToNextMap();
            Destroy(gameObject);
        }
        else
        {
            GameManager.UI.ShowPopUpUI<PopUpUI>("UI/GameClearUI");
        }
        
    }

    private void GoToNextMap()
    {
        GameManager.Scene.LoadScene("Map2");
    }
}
