using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Slider healthbarSlider;
    private int currentHealth;
    private int maxHealth = 100;
    private Character character;
    private Quaternion startRotation;

    private void Awake()
    {
        character = GetComponent<Character>();
    }

    private void Start()
    {
        startRotation = transform.rotation;
        Reset();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHealthbarUI();
        if (currentHealth <= 0)
        {
            Reset();
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        UpdateHealthbarUI();
    }

    private void LateUpdate()
    {
        if (character != LevelManager.Current.Player)
        {
            healthbarSlider.transform.rotation = startRotation;
        }
    }

    private void UpdateHealthbarUI()
    {
        healthbarSlider.maxValue = maxHealth;
        healthbarSlider.minValue = 0;
        healthbarSlider.value = currentHealth;
    }

    private void Reset()
    {
        currentHealth = maxHealth;
        UpdateHealthbarUI();
    }
}