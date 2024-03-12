using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script de contrôle des déplacements, des sauts de Sonic et des detections de collisions.
// Par : Skyler-Dominik England
// Dernière modification : 10/03/2024
public class ControlerPersonnage : MonoBehaviour
{
    // |||||||||||||||||||||||||||||||||||||||| Déclaration des Variables |||||||||||||||||||||||||||||||||||||||| \\
    public float vitesseX;      //vitesse horizontale actuelle
    public float vitesseXMax;   //vitesse horizontale Maximale désirée
    public float vitesseY;      //vitesse verticale 
    public float vitesseSaut;   //vitesse de saut désirée

    // ----------------------------------------------------------------------------------------------------------- \\
    /* Détection des touches et modification de la vitesse de déplacement;
       "a" et "d" pour avancer et reculer, "w" pour sauter
    */
    void Update ()
    {
        // Déplacement vers la gauche.
        if (Input.GetKey("a"))
        {
            vitesseX = -vitesseXMax;
            GetComponent<SpriteRenderer>().flipX = true;

        }
        // Déplacement vers la droite.
        else if (Input.GetKey("d"))
        {
            vitesseX = vitesseXMax;
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            vitesseX = GetComponent<Rigidbody2D>().velocity.x;  //mémorise vitesse actuelle en X
        }

        // Sauter l'objet à l'aide la touche "w".
        if (Input.GetKeyDown("w"))
        {
            vitesseY = vitesseSaut;

        }
        else
        {
            vitesseY = GetComponent<Rigidbody2D>().velocity.y;  //vitesse actuelle verticale
        }
        
        //Applique les vitesses en X et Y
        GetComponent<Rigidbody2D>().velocity = new Vector2(vitesseX, vitesseY);


        //**************************Gestion des animaitons de course et de repos********************************
        //Active l'animation de course si la vitesse de déplacement n'est pas 0, sinon le repos sera jouer par Animator

        if(vitesseX > 0.1f || vitesseX < -0.1f) 
        { 
            GetComponent<Animator>().SetBool("marche", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("marche", false);
        }






    }
    void OnCollisionEnter2D(Collision2D collision)
    {
    
      
    }
}

