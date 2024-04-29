using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script de gestion des cam�ras.
// Par : Skyler-Dominik England
// Derni�re modification : 29/04/2024

public class ControlerCam : MonoBehaviour
{
    public GameObject Camera1;          // Permet de g�rer la cam�ra "CamEnfant" li�e � Sonic.
    public GameObject Camera2;          // Permet de g�rer la cam�ra "Cam2".


    // S'ex�cute au d�part.
    void Start()
    {
       Camera1.SetActive(true);         // La cam�ra 1 est activ�.
       Camera2.SetActive(false);        // La cam�ra 2 est d�sactiv�.
    }

    // Fonction pour l'initialisation qui s'ex�cute en boucle.
    void Update()
    {
        // Si la touche 1 situ� dans la rang�e de chiffres est enfonc�e...
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Camera1.SetActive(true);    // La cam�ra 1 est activ�.
            Camera2.SetActive(false);   // La cam�ra 2 est d�sactiv�.

        }
        // Si la touche 2 situ� dans la rang�e de chiffres est enfonc�e...
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Camera1.SetActive(false);   // La cam�ra 1 est d�sactiv�.
            Camera2.SetActive(true);    // La cam�ra 2 est activ�.

        }
    }
}
