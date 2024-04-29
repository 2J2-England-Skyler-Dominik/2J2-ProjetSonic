using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script de gestion de la caméra 2.
// Par : Skyler-Dominik England
// Dernière modification : 29/04/2024

public class cameraSuivre : MonoBehaviour
{
    public GameObject cible;    // Variable qui permet d'identifier la cible à suivre. (Sonic)

    // Fonction pour l'initialisation qui s'exécute en boucle.
    void Update()
    {
        // Déclaration de la variable locale: positionActuelle.
        Vector3 positionActuelle = transform.position;      // Récupère la position actuelle en allant chercher la position X, Y et Z de la caméra.
        positionActuelle.x = cible.transform.position.x;    // Permet de modifier la position X de la caméra en lui donnant la valeur de la position X de la cible. (Sonic) 
        transform.position = positionActuelle;              // Attribue la nouvelle valeur de position X à la position actuelle. 
    }
}