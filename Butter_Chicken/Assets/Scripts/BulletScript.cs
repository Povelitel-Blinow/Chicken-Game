using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // ## VARS ##

    // these values will come from a singleton to handle upgrades

    [SerializeField] private float size; 
    [SerializeField] private float explosionRadius;
    [SerializeField] private float knockback;
    [SerializeField] private float damage;
    private void Awake(){
        transform.localScale = new Vector3(size, size, size);  // for when bullet upgrades get implemented
    }

    private void OnTriggerEnter(Collider other) {

    
    GameObject hit = other.gameObject;
    Rigidbody enemyRB;

    // ## ON HIT DAMAGE + KNOCKBACK ##
    if (hit.CompareTag("Enemy")){
        // Take damage
        hit.GetComponent<EnemyScript>().TakeDamage(damage);

        // Knockback
        enemyRB = hit.GetComponent<Rigidbody>();
        Vector3 direction = gameObject.GetComponent<Rigidbody>().velocity.normalized;
        enemyRB.AddForce(direction*knockback, ForceMode.Impulse);
    }

    // ## EXPLOSIVE KNOCKBACK + DAMAGE ##
    Collider[] affectedObjects = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach(Collider collider in affectedObjects){
            hit = collider.gameObject;

            if(hit.CompareTag("Enemy") && other != collider){
             
                enemyRB = collider.GetComponent<Rigidbody>();
                
                if(enemyRB != null){

                    Vector3 direction;
                    float powerFalloff;
                    float distance;

                    // damage and knockback fall off with distance
                    distance = Vector3.Distance(transform.position,hit.transform.position);
                    powerFalloff = Mathf.Pow(((explosionRadius - distance) / explosionRadius), 2);

                    // Take Damage
                    hit.GetComponent<EnemyScript>().TakeDamage(powerFalloff * damage);
                    
                    // Knockback
                    direction = hit.transform.position - transform.position;
                    Debug.Log(direction);
                    enemyRB.AddForce(direction.normalized * powerFalloff * knockback, ForceMode.Impulse);
                }
                else{Debug.Log("rigidbody null");}
            }
        }

        Destroy(gameObject);
    }
}
