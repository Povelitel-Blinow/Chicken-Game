using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] float maxHP;
    private float currentHP;

    private void Awake() {
        currentHP = maxHP;
    }

    public void TakeDamage(float damageTaken){
        currentHP -= damageTaken;
    }

    void Update()
    {
        if (currentHP <= 0){
            Die();
        }
    }

    private void Die(){
        Destroy(gameObject);
    }
}
