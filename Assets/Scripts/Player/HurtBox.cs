using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBox : MonoBehaviour
{
    public float changeDrop;
    public GameObject[] objectInstiated;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            if(changeDrop <= 0)
            {
                int n = Random.Range(0, objectInstiated.Length);

                Instantiate(objectInstiated[n], other.transform.position, objectInstiated[n].transform.rotation);
            }
            else
            {
                return;
            }

            EnemyController.instance.anim.SetTrigger("Death");
            PlayerController.instance.Bounce();
            EnemyController.instance.rb.bodyType = RigidbodyType2D.Dynamic;
            EnemyController.instance.rb.mass = 2;
        }
    }
}
