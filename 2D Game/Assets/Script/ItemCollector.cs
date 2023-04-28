using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private AudioSource CollectionSoundEffect;

    private int Apple = 0;
    [SerializeField] private Text AppleText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            CollectionSoundEffect.Play();
            Destroy(collision.gameObject);
            Apple++;
            AppleText.text = "Apple : " + Apple;
        }
    }

}
