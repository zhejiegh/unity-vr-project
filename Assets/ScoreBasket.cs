using UnityEngine;
using TMPro; // Important pour le texte

public class ScoreBasket : MonoBehaviour
{
    public TextMeshProUGUI affichageScore;
    private int score = 0;

    private void OnTriggerEnter(Collider other)
    {
        // On vérifie si le nom contient "Balle" (ça marchera pour Balle et Balle(Clone))
        if (other.name.Contains("Balle"))
        {
            score = score + 1;
            affichageScore.text = "SCORE : " + score;
            Debug.Log("Points : " + score);
        }
    }
}