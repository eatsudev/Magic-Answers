using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 10;

    //private int MAX_HEALTH = 100;


    void Update()
    {
        //myAnimation.SetBool("EnemyDamage", false);
    }

    private IEnumerator VisualIndicator(Color color)
    {
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void Damage(int amount)
    {
        if(amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Damage");
        }

        this.health -= amount;
        StartCoroutine(VisualIndicator(Color.red));

        if(health <= 0)
        {
            Die();
        }
    }


    private void Die()
    {
        Debug.Log("Vulcanos dead");
        Destroy(gameObject);
    }
}
