using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script de gestion de la cam�ra 2.
// Par : Skyler-Dominik England
// Derni�re modification : 29/04/2024

public class cameraSuivre : MonoBehaviour
{
    public GameObject cible;    // Variable qui permet d'identifier la cible � suivre. (Sonic)

    // Fonction pour l'initialisation qui s'ex�cute en boucle.
    void Update()
    {
        // D�claration de la variable locale: positionActuelle.
        Vector3 positionActuelle = transform.position;      // R�cup�re la position actuelle en allant chercher la position X, Y et Z de la cam�ra.
        positionActuelle.x = cible.transform.position.x;    // Permet de modifier la position X de la cam�ra en lui donnant la valeur de la position X de la cible. (Sonic) 
        transform.position = positionActuelle;              // Attribue la nouvelle valeur de position X � la position actuelle. 
    }
}