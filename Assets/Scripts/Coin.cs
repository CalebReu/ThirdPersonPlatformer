using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Transform coinPosition;
    [SerializeField] private int value;
    [SerializeField] private float rotationRate;
    [SerializeField] private float bobRate;
    [SerializeField] private float bobHeight;
    void Update()
    {
        coinPosition.Rotate(Vector3.forward, rotationRate * 360 * Time.deltaTime);
        coinPosition.position = new Vector3(transform.position.x, transform.position.y + bobHeight * Mathf.Sin(bobRate * Time.time), transform.position.z);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.AddScore(value);
            Destroy(gameObject);
        }
    }
}
