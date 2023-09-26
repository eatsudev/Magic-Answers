using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject attackArea;

    private bool attacking = false;

    private float timeToAttack = 0.25f;
    private float timer = 0f;
    Animator myAnimation;

    [SerializeField] private AudioSource spellSoundEffect;

    //public GameManager gameManager;
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
        myAnimation = GetComponent<Animator>();
    }

    
    void Update()
    {
        if (attacking)
        {
            timer += Time.deltaTime;

            if(timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
                myAnimation.SetBool("PlyerAttack", false);
            }
        }
    }

    public void Attack()
    {
        attacking = true;
        attackArea.SetActive(attacking);

        myAnimation.SetBool("PlyerAttack", true);
        spellSoundEffect.Play();
    }

}
