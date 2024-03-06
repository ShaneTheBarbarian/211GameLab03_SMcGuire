using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCount : MonoBehaviour
{
    TMPro.TMP_Text text;
    int count;
   
    private void Awake()
    {
        text = GetComponent<TMPro.TMP_Text>();
    }

    void OnEnable() => CrystalCollectible.OnCollected += OnCollectableCollected;
    void OnDisable() => CrystalCollectible.OnCollected -= OnCollectableCollected;


    private void OnCollectableCollected()
    {
        text.text = (++count).ToString();
    }
}
