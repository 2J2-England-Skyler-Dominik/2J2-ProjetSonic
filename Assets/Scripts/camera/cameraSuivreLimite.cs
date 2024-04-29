using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script de gestion de la caméra 2 plus complexe.
// Par : Skyler-Dominik England
// Dernière modification : 29/04/2024
// PJ: Personnage joueur. Dans ce cas, le PJ est Sonic.

public class cameraSuivreLimite : MonoBehaviour
{
    public GameObject cible;    // Variable qui permet d'identifier la cible à suivre le PJ.

    public float limiteHaut;    // Variable qui détermine la limite des déplacements vers le haut de la caméra.
    public float limiteBas;     // Variable qui détermine la limite des déplacements vers le bass de la caméra.
    public float limiteGauche;  // Variable qui détermine la limite des déplacements vers le gauche de la caméra.
    public float limiteDroite;  // Variable qui détermine la limite des déplacements vers le Droite de la caméra.


    // Fonction pour l'initialisation qui s'exécute en boucle.
    void Update()
    {   // Déclaration de la variable locale: positionActuelle.
        Vector3 positionActuelle = cible.transform.position; // Permet d'aller chercher position X, Y et Z du PJ et de la mémoriser.

        // La position en X est plus petite que la limite de gauche ...
        if (positionActuelle.x < limiteGauche)
        {
            positionActuelle.x = limiteGauche;   // La position X est égale à la limite de gauche.
        }

        // La position en X est plus grande que la limite de droite ...
        if (positionActuelle.x > limiteDroite)
        {
            positionActuelle.x = limiteDroite;   // La position X est égale à la limite de droite.
        }

        // La position en Y est plus petite que la limite du bas ...
        if (positionActuelle.y < limiteBas)
        {
            positionActuelle.y = limiteBas;      // La position Y est égale à la limite du bas.
        }

        // La position en Y est plus grande que la limite du haut ...
        if (positionActuelle.y > limiteHaut)
        {
            positionActuelle.y = limiteHaut;     // La position Y est égale à la limite du haut.
        }

        positionActuelle.z = -10;                // Assure que la positionActuelle.z reste à -10.

        transform.position = positionActuelle;   // Attribue la nouvelle valeur de position X la position actuelle. 


    }
}
