using System;
using UnityEngine;

public class CrystalCollectible : MonoBehaviour
{
    public static event Action OnCollected;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnCollected?.Invoke();
            Destroy(gameObject);
        }
    }
}
