using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private TextMeshProUGUI scoreText;
    private int score;

    private void Start()
    {
        score = 0;
        scoreText.text = "Score: " + score;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void AddScore(int value)
    {
        score += value;
        scoreText.text = "Score: " + score;
    }
}
