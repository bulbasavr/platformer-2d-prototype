using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float _speed = 2.0f;

    private void Update()
    {
        transform.Rotate(transform.rotation.x, transform.rotation.y, 360 * Time.deltaTime * _speed);
    }
}
