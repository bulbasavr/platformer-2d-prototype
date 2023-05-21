using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int _pineapple = 0;

    [SerializeField] private Text _textPineapple;

    [SerializeField] private AudioSource _collectionSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pineapple"))
        {
            Destroy(collision.gameObject);
            _pineapple++;
            _textPineapple.text = $"Pineapple: {_pineapple}";
            _collectionSoundEffect.Play();
        }
    }
}
