using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Script pour la sc�ne du menu principale.
// Par : Skyler-Dominik England
// Derni�re modification : 29/04/2024

public class MenuPrincipal : MonoBehaviour
{
    // Fonction pour l'initialisation qui s'ex�cute en boucle.
    void Update()
    {
        // Si la touche espace est enfonc�e ...
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            SceneManager.LoadScene(1); // La sc�ne avec l'index num�ro 1 est charg�e.
        }
    }
}
