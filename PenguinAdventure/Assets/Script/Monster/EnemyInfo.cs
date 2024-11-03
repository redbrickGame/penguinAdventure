using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour
{

    public float Damage = 10f;
    public float Blood = 50f;
    public float ExperienceCapacity = 10;

    public GameObject experienceObj;
    public float DamageGet()
    {
        return Damage;
    }
    public void DamageSet(float dam)
    {
        Blood = Blood - dam;
        if (Blood < 0)
        {
            Instantiate(experienceObj, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }

}
