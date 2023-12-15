using UnityEngine;
using TMPro;
using UnityEditor;

public class Wizard : MonoBehaviour
{
    [SerializeField] TMP_Text textOutput;

    int min = 1;        // Minimum number in the guessing range
    int max = 11;       // Maximum number in the guessing range, set to 11 because Random.Range is exclusive at the upper limit
    int guess;          // Current guess of the AI
    int attempts = 3;   // Number of attempts the AI has to guess correctly

    // Start is called before the first frame update
    void Start()
    {
        guess = Random.Range(min, max);

        textOutput.text = $"My guess is\n{guess}";
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
    }

    void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            min = guess + 1;
            NextGuess();
        } 
        else if (Input.GetKeyDown(KeyCode.L))
        {
            max = guess;
            NextGuess();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            WinGame();
        }
    }

    private void WinGame()
    {
        textOutput.text = $"I guessed it!\n\nYour number was {guess}";
    }

    void NextGuess()
    {
        attempts--;

        if (attempts <= 0)
        {
            LoseGame();
            return;
        }

        guess = Random.Range(min, max);
        textOutput.text = $"My guess is\n{guess}";
    }

    private void LoseGame()
    {
        textOutput.text = "I ran out of attempts.\n\nYou win!";
    }
}
