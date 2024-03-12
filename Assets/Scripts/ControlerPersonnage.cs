using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script de contrôle des déplacements, des sauts de Sonic et des detections de collisions.
// Par : Skyler-Dominik England
// Dernière modification : 12/03/2024
public class ControlerPersonnage : MonoBehaviour
{
    // |||||||||||||||||||||||||||||||||||||||| Déclaration des Variables |||||||||||||||||||||||||||||||||||||||| \\

    public float vitesseX;      // Vitesse horizontale actuelle.
    public float vitesseXMax;   // Vitesse horizontale Maximale désirée.
    public float vitesseY;      // Vitesse verticale .
    public float vitesseSaut;   // Vitesse de saut désirée.

    // ----------------------------------------------------------------------------------------------------------- \\


    // ||||||||||||||||||| Détection des touches et modification de la vitesse de déplacement |||||||||||||||||||| \\
    
    // Fonction pour initialisation.
    void Update ()
    {
        // Déplacement vers la gauche.
        if (Input.GetKey("a"))
        {
            vitesseX = -vitesseXMax;
            GetComponent<SpriteRenderer>().flipX = true; // Le sprite se tourne vers la gauche.

        }
        // Déplacement vers la droite.
        else if (Input.GetKey("d"))
        {
            vitesseX = vitesseXMax;
            GetComponent<SpriteRenderer>().flipX = false; // Le sprite se tourne vers la droite.
        }
        else
        {
            vitesseX = GetComponent<Rigidbody2D>().velocity.x;  // La vitesse actuelle en X est mémorisé.
        }

        // Sauter l'objet à l'aide la touche "w".
        if (Input.GetKeyDown("w"))
        {
            vitesseY = vitesseSaut;
            GetComponent<Animator>().SetBool("saut", true); // L'animation de part.

        }
        else
        {
            vitesseY = GetComponent<Rigidbody2D>().velocity.y;  // vitesse actuelle verticale
        }
        
        // Applique les vitesses en X et Y
        GetComponent<Rigidbody2D>().velocity = new Vector2(vitesseX, vitesseY);

        // -------------------------------------------------------------------------------------------------------- \\


        // |||||||||||||||||||||||||||||||||||||||| Gestion des animations |||||||||||||||||||||||||||||||||||||||| \\

        // Animation de l'état "marche".
        if (vitesseX > 0.1f || vitesseX < -0.1f) //Active l'animation de marche si la vitesse de déplacement n'est pas 0, sinon le repos sera jouer par Animator.
        { 
            GetComponent<Animator>().SetBool("marche", true); // L'animation de marche part.
        }
        else
        {
            GetComponent<Animator>().SetBool("marche", false); // L'animation de marche s'arrête.
        }

        // --------------------------------------------------------------------------------------------------------- \\
    }

    // |||||||||||||||||||||||||||||||||||||||| Gestion des collisions |||||||||||||||||||||||||||||||||||||||| \\
    void OnCollisionEnter2D(Collision2D collision)
    {   
        // Quand il y a une collision avec le sol à la fin du saut, ...
        GetComponent<Animator>().SetBool("saut", false); // L'animation de saut arrête.
    }
    // -------------------------------------------------------------------------------------------------------- \\
}

