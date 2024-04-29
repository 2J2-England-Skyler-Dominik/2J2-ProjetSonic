using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script de gestion des caméras.
// Par : Skyler-Dominik England
// Dernière modification : 29/04/2024

public class ControlerCam : MonoBehaviour
{
    public GameObject Camera1;          // Permet de gérer la caméra "CamEnfant" liée à Sonic.
    public GameObject Camera2;          // Permet de gérer la caméra "Cam2".


    // S'exécute au départ.
    void Start()
    {
       Camera1.SetActive(true);         // La caméra 1 est activé.
       Camera2.SetActive(false);        // La caméra 2 est désactivé.
    }

    // Fonction pour l'initialisation qui s'exécute en boucle.
    void Update()
    {
        // Si la touche 1 situé dans la rangée de chiffres est enfoncée...
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Camera1.SetActive(true);    // La caméra 1 est activé.
            Camera2.SetActive(false);   // La caméra 2 est désactivé.

        }
        // Si la touche 2 situé dans la rangée de chiffres est enfoncée...
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Camera1.SetActive(false);   // La caméra 1 est désactivé.
            Camera2.SetActive(true);    // La caméra 2 est activé.

        }
    }
}
