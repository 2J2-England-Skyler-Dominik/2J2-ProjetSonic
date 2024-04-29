using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Script pour la scène du menu principale.
// Par : Skyler-Dominik England
// Dernière modification : 29/04/2024

public class MenuPrincipal : MonoBehaviour
{
    // Fonction pour l'initialisation qui s'exécute en boucle.
    void Update()
    {
        // Si la touche espace est enfoncée ...
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            SceneManager.LoadScene(1); // La scène avec l'index numéro 1 est chargée.
        }
    }
}
