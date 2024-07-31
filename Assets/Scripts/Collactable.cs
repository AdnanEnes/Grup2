using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private static Collectable _instance;
    public float radius = 5f; // Sphere'in yarıçapı

    public GameObject[] fragments; 

    public bool gameStartable = false;

    public static Collectable Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Collectable>();
            }
            return _instance;
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckSphere();
        if(fragments.length == 0)
        {
            gameStartable = true;
        }
    }

    void CheckSphere()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.CompareTag("Player"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (gameObject.CompareTag("Password"))
                    {
                        Destroy(gameObject);
                    }
                }
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
