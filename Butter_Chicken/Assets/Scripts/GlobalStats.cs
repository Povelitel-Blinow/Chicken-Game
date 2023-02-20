using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalStats : MonoBehaviour
{
    public static GlobalStats _instance { get; private set; }

    public float wepaonDamage;
    public float bulletSize;
    public float bulletSpeed;
    public float explosionRadius;
    public float knockback;
    public float playerSpeed;


}
