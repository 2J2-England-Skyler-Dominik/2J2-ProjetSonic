using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script de contr�le de la roue.
// Par : Skyler-Dominik England
// Derni�re modification : 19/03/2024

public class NewBehaviourScript : MonoBehaviour
{
    // D�tectes les collisions de l'objet Roue.
    void OnCollisionEnter2D(Collision2D infoCollision)
    {
        // Si la bombe entre en collision avec touche le joueur, l'animation est activ� et l'objet est d�truit.
        if (infoCollision.gameObject.name == "Sonic")
        {
            GetComponent<Animator>().enabled = true; // Active l'animation de l'objet lorsque la bombe touche Sonic.
            Destroy(gameObject, 0.1f);     // D�truit l'Objet apr�s un delais (� la fin de son animation).
        }
    }
}
