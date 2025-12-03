using UnityEngine;
using TMPro;
using System.Collections.Generic;


public class Calmie : MonoBehaviour
{
    public PlayerMovement player;
    public TextMeshProUGUI calmieText;
    private float timer = 0f;
    private float interval = 15f; // Calmie speaks every 15 seconds
    private string currentEmotion = "neutral";

    private Dictionary<string, string[]> messages = new Dictionary<string, string[]>()
    {
        {"encourage", new string[] {
            "You’re doing great 💙",
            "Don’t give up, you’ve got this!",
            "Breathe… focus… you’re amazing!"
        }},
        {"praise", new string[] {
            "Wow! You collected so many coins 🌟",
            "Fantastic job!",
            "That was awesome!"
        }},
        {"calm", new string[] {
            "Take it easy 😊",
            "Remember, no rush!",
            "You’re safe here 💫"
        }}
    };

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            AnalyzePlayerState();
            Speak();
            timer = 0f;
        }
    }

    void AnalyzePlayerState()
    {
        if (player.mistakes > 3)
            currentEmotion = "calm";
        else if (player.playerScore > 50)
            currentEmotion = "praise";
        else
            currentEmotion = "encourage";
    }

    void Speak()
    {
        string[] options = messages[currentEmotion];
        calmieText.text = options[Random.Range(0, options.Length)];
        Invoke("ClearText", 4f);
    }

    void ClearText()
    {
        calmieText.text = " ";
    }
}
