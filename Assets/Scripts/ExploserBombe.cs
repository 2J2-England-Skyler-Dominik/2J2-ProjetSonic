using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script pour gérer l'explosion de la bombe.
// Par : Skyler-Dominik England
// Dernière modification : 11/03/2024

public class ExploserBombe : MonoBehaviour {

    // Détectes les collisions de l'objet Bombe.
    void OnCollisionEnter2D(Collision2D infoCollision)
    {
        // Si le terrain est touché l'animation est activé et l'objet est détruit.
        if (infoCollision.gameObject.name =="gazon")
        {
            GetComponent<Animator>().enabled = true; // Active l'animation de l'objet lorsque le terrain est touché.
            Destroy(gameObject, 0.1f);     // Détruit l'Objet après un delais (à la fin de son animation).
        }
    }
}
