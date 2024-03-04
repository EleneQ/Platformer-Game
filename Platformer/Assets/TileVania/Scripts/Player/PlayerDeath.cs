using UnityEngine;
using System;
using System.Collections;

public class PlayerDeath : MonoBehaviour
{
    public event Action OnTakePlayerLife;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] PlayerMovement playerMovement;

    [SerializeField] Vector2 deathThrow = new Vector2(5f, 5f);
    [SerializeField] float deathDelay = 2f;
    bool isAlive = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hazards") && isAlive ||
            other.CompareTag("Enemy") && isAlive)
        {
            isAlive = false;
            playerMovement.enabled = false;

            rb.velocity = deathThrow;

            ProcessPlayerDeath();
        }
    }

    private void ProcessPlayerDeath()
    {
        if (PlayerStats.lives > 1)
        {
            StartCoroutine(TakeLife());
        }
        else
        {
            StartCoroutine(PlayerDied());
        }
    }

    private IEnumerator TakeLife()
    {
        PlayerStats.lives--;
        OnTakePlayerLife?.Invoke();

        yield return new WaitForSecondsRealtime(deathDelay);
        LevelManager.instance.ReplayLevel();
    }

    private IEnumerator PlayerDied()
    {
        yield return new WaitForSecondsRealtime(deathDelay);
        LevelManager.instance.LoadMainMenu();
    }
}
