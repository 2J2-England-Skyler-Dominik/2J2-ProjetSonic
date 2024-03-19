using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script pour gérer l'explosion de la bombe.
// Par : Skyler-Dominik England
// Dernière modification : 19/03/2024

public class ExploserBombe : MonoBehaviour {

    // Détectes les collisions de l'objet Bombe.
    void OnCollisionEnter2D(Collision2D infoCollision)
    {
        // Si la bombe entre en collision avec le terrain, l'animation est activé et l'objet est détruit.
        if (infoCollision.gameObject.name =="gazon")
        {
            GetComponent<Animator>().enabled = true; // Active l'animation de l'objet lorsque le terrain est touché.
            Destroy(gameObject, 0.1f);     // Détruit l'Objet après un delais (à la fin de son animation).
        }

        // Si la bombe entre en collision avec touche le joueur, l'animation est activé et l'objet est détruit.
        if (infoCollision.gameObject.name == "Sonic")
        {
            GetComponent<Animator>().enabled = true; // Active l'animation de l'objet lorsque la bombe touche Sonic.
            Destroy(gameObject, 0.1f);     // Détruit l'Objet après un delais (à la fin de son animation).
        }
    }
}
