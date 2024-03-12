using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script pour gérer l'explosion de la bombe.
// Par : Skyler-Dominik England
// Dernière modification : 11/03/2024

public class ExploserBombe : MonoBehaviour {
    // |||||||||||||||||||||||||||||||||||||||| Déclaration des Variables |||||||||||||||||||||||||||||||||||||||| \\



    // ----------------------------------------------------------------------------------------------------------- \\

    // Fonction pour initialisation.
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Détecte les colisions de l'objert Bombe
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
