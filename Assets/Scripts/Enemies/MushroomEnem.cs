using UnityEngine;

public class MushroomEnem : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Idamageble>()?.Die();
        }
    }
}
