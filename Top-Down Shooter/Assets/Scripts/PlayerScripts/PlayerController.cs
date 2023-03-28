using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;

    public PlayerVisuals visuals;
    public PlayerStats stats;

    Vector2 movement;

    public AudioSource audioSource;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        visuals.animator.SetFloat("Horizontal", movement.x);
        visuals.animator.SetFloat("Vertical", movement.y);
        visuals.animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        Vector2 direction = movement.normalized;
        rb.MovePosition(rb.position + direction * stats.Speed.Value * Time.fixedDeltaTime);
    }

    // Player damage
    public void ApplyDamage(float damageAmount)
    {
        audioSource.PlayOneShot(audioSource.clip, 0.1f);

        var randomValue = Random.Range(0f, 100f);

        //determine if the hit connects due to dodge chance
        if (randomValue >= Mathf.Min(stats.DodgeChance.Value, stats.MaxDodgeChance))
        {
            //determine the actual damage taken
            if (stats.Armor.Value >= 0)
            {
                damageAmount *= 100 / (100 + stats.Armor.Value);
            }
            else
            {
                damageAmount *= 2 - 100 / (100 - stats.Armor.Value);
            }

            stats.health.Damage(damageAmount);
        }
    }

    // Player healing
    public void ApplyHeal(float healAmount)
    {
        stats.health.Heal(healAmount);
    }

    // Player death
    // TODO change death event
    public UnityEvent OnDie;
    public void Die()
    {
        // Destroy(gameObject);
        Debug.Log("Player died!");
        OnDie?.Invoke();
    }
}