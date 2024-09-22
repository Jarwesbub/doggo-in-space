using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Health
using UnityEngine.SceneManagement;

public class FlyDog : MonoBehaviour
{
    public int health;
    public int maxHealth = 3;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public ParticleSystem explosionParticle1, explosionParticle2, flyParticle;

    public float velocity = 1;
    private Rigidbody2D rb;

    Animator animator;

    bool isTakingDamage = false;
    bool movementLock = false;
    bool isThrottling;


    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        SetHearts();


    }

    //This "myFunction" calculates how many seconds to wait -> yield return new WaitForSeconds(?);
    IEnumerator waitPlayerGetHP()
    {
        animator.Play("laika_hpgain");
        yield return new WaitForSeconds(1.5f);

        animator.Play("laika_idle2");

    }

    IEnumerator waitPlayerGetDamage()
    {
        isTakingDamage = true;
        health -= 1;
        SetHearts();

        animator.Play("laika_dmg");
        yield return new WaitForSeconds(0.1f);
        animator.Play("laika_dmg_rev");

        yield return new WaitForSeconds(0.3f);
        animator.Play("laika_idle2");
        isTakingDamage = false;
    }

    IEnumerator DeathToEndScreenFunction()
    {
        movementLock = true;

        animator.Play("laika_death");
        yield return new WaitForSeconds(0.7f);
        transform.Rotate(0, 0, 1 * velocity / 2);
        yield return new WaitForSeconds(1f);
        SoundManager.instance.PlayDeath();
        rb.velocity = Vector2.down * velocity * 8;
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("EndMenuScene");

    }


    void SetHearts()
    {

        if (health > maxHealth)
        {
            health = maxHealth;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

        }

    }


    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            if (!movementLock)
            {
                SoundManager.instance.PlayBooster();

                if (!isThrottling)
                {
                    isThrottling = true;
                }
                rb.velocity = Vector2.up * velocity;
            }
            else
            {
                flyParticle.loop = true;
                flyParticle.Play();
            }
        }
        else
        {
            isThrottling = false;
            SoundManager.instance.StopBooster();
            flyParticle.loop = true;
            flyParticle.Play();
        }

        if (health >= 3)
        {
            health = 3;
        }

        if (health <= 0)
        {
            StartCoroutine(DeathToEndScreenFunction());
        }

    }

    void OnBecameInvisible()
    {
        rb.velocity = Vector2.up * velocity;
        health -= 1;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Vector3 explosionPosition = other.transform.position;
        explosionPosition.z = -1;
        switch (other.gameObject.layer)
        {
            case 9: // Asteroid
            case 12: // Deadman
            case 13: // Satellite
                Destroy(other.gameObject);

                if (!isTakingDamage)
                {
                    StartCoroutine(waitPlayerGetDamage());

                    SoundManager.instance.PlaySound(SoundManager.instance.explosion);
                    SoundManager.instance.PlaySound(SoundManager.instance.whimper);

                    //Particles
                    explosionParticle1.transform.position = explosionPosition;
                    explosionParticle1.Play();
                    explosionParticle2.transform.position = explosionPosition;
                    explosionParticle2.Play();
                }
                break;

            case 10: // HP
                SoundManager.instance.PlayEat();

                Destroy(other.gameObject);
                if (!movementLock)
                {
                    health += 1;
                    SetHearts();
                    StartCoroutine(waitPlayerGetHP());
                }
                break;
            case 11:
                SoundManager.instance.PlayEat();

                Destroy(other.gameObject);

                if (!movementLock)
                {
                    health = maxHealth;
                    SetHearts();
                    StartCoroutine(waitPlayerGetHP());
                }
                break;

            case 14:
                rb.velocity = Vector2.up * velocity;

                if (!isTakingDamage)
                {

                    StartCoroutine(waitPlayerGetDamage());
                    SoundManager.instance.PlaySound(SoundManager.instance.impact);
                    SoundManager.instance.PlaySound(SoundManager.instance.whimper);
                }
                break;
            case 30: // Ceiling
                rb.velocity = Vector2.down * velocity;

                if (!isTakingDamage)
                {

                    StartCoroutine(waitPlayerGetDamage());
                    SoundManager.instance.PlaySound(SoundManager.instance.impact);
                    SoundManager.instance.PlaySound(SoundManager.instance.whimper);
                }
                break;
            case 31: // Planet
                if (!movementLock)
                {
                    rb.velocity = Vector2.up * velocity;
                }
                if (!isTakingDamage)
                {

                    StartCoroutine(waitPlayerGetDamage());

                }
                if (isTakingDamage && !movementLock)
                {
                    SoundManager.instance.PlaySound(SoundManager.instance.impact);
                    SoundManager.instance.PlaySound(SoundManager.instance.whimper);
                }
                break;
        }

    }

}

