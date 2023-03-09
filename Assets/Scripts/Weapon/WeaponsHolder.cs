using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class WeaponsHolder : MonoBehaviour
{
    [SerializeField] private Weapon[] weapons;
    public Weapon CurrentWeapon { get; private set; }
    [SerializeField] private PlayerInputHandler playerInput;
    [SerializeField] private Button weaponUI;
    private int currentWeaponNumber;

    private void Start()
    {
        Initialize();
        weaponUI.onClick.AddListener(NextWeapon);
        if (playerInput.IsPc) playerInput.playerControll.Player.Attack.performed += ButtonAttack;
    }

    private void Initialize()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].gameObject.SetActive(false);
        }

        weapons[0].gameObject.SetActive(true);
        CurrentWeapon = weapons[0];
        currentWeaponNumber = 0;
    }

    private void ButtonAttack(InputAction.CallbackContext context)
    {
        CurrentWeapon.Attack();
    }

    private void NextWeapon()
    {
        bool switched = false;
        CurrentWeapon.gameObject.SetActive(false);
        for (int i = currentWeaponNumber + 1; i < weapons.Length; i++)
        {
            if (weapons[i].data.isUnlocked)
            {
                currentWeaponNumber = i;
                CurrentWeapon = weapons[i];
                switched = true;
                break;
            }
        }

        if (switched == false)
        {
            currentWeaponNumber = 0;
            CurrentWeapon = weapons[0];
        }

        CurrentWeapon.gameObject.SetActive(true);
    }

    public void UnlockWeapon(int id)
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            if (weapons[i].data.WeaponID == id)
            {
                weapons[i].Unlock();
            }
        }
    }

    public void JoystickAttack()
    {
        CurrentWeapon.Attack();
    }
}