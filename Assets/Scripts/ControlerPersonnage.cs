using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Script de contrôle des déplacements et des sauts de Sonic, ainsi que les detections de collisions.
// Par : Skyler-Dominik England
// Dernière modification : 02/04/2024
public class ControlerPersonnage : MonoBehaviour
{
    // |||||||||||||||||||||||||||||||||||||||| Déclaration des Variables |||||||||||||||||||||||||||||||||||||||| \\

    public float vitesseX;          // Vitesse horizontale actuelle.
    public float vitesseXMax;       // Vitesse horizontale Maximale désirée.
    public float vitesseY;          // Vitesse verticale .
    public float vitesseSaut;       // Vitesse de saut désirée.
    public bool etatAttaque = false;// L'État d'attaque de Sonic est à false par défaut.
    public GameObject FinNiveau1;
    public GameObject DebutNiveau2;

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
            GetComponent<SpriteRenderer>().flipX = false;       // Le sprite se tourne vers la droite.
        }
        else
        {
            vitesseX = GetComponent<Rigidbody2D>().velocity.x;  // La vitesse actuelle en X est mémorisé.
        }

        // Vérifie la position du point de pivot du personnage. Le layer du personnage à été mit à Ignorecast.
        print(Physics2D.OverlapCircle(transform.position, 0.5f) == true);

        // Fait sauter le personnage à l'aide la touche "w" seulement lorsqu'il se trouve par terre.
        if (Input.GetKeyDown("w") && Physics2D.OverlapCircle(transform.position, 0.5f))
        {
            vitesseY = vitesseSaut;
            GetComponent<Animator>().SetBool("saut", true);     // L'animation de saut part.
        }

        else
        {
            vitesseY = GetComponent<Rigidbody2D>().velocity.y;  // vitesse actuelle verticale
        }

        // -------------------------------------------------------------------------------------------------------- \\


        // |||||||||||||||||||||||||||||||||||||||| Gestion des animations |||||||||||||||||||||||||||||||||||||||| \\

        // Animation de l'état "marche".
        if (vitesseX > 0.1f || vitesseX < -0.1f)                //Active l'animation de marche si la vitesse de déplacement n'est pas 0, sinon le repos sera jouer par Animator.
        { 
            GetComponent<Animator>().SetBool("marche", true);   // L'animation de marche part.
        }
        else
        {
            GetComponent<Animator>().SetBool("marche", false);  // L'animation de marche s'arrête.
        }

        // --------------------------------------------------------------------------------------------------------- \\

        // ||||||||||||||||||||||||||||||||||||||||| Gestion des attaques |||||||||||||||||||||||||||||||||||||||||| \\
        // Si la touche Espace est appuyée et que l'attaque n'a pas été déclenchée...
        if (Input.GetKeyDown(KeyCode.Space) && etatAttaque == false)
        {
            etatAttaque = true;                                 // L'état d'attaque de Sonic change à true, donc il attaque.
            Invoke("AnnuleAttaque", 0.4f);                      // Après un moment, la fonction AnnuleAttaque est appelée.
            GetComponent<Animator>().SetBool("saut", false);    // L'animation de saut arrête.
            GetComponent<Animator>().SetTrigger("attaqueAnim"); // L'animation de l'attaque part.
        }

        // Si Sonic attaque ... et si la vitesse n'a pas déjà été augmentée ... 
        if (etatAttaque == true && vitesseX <= vitesseXMax && vitesseX >= -vitesseXMax)
        {
            vitesseX *= 4;                                      // La vitesse augmente.
        }

        // --------------------------------------------------------------------------------------------------------- \\

        // Applique les vitesses en X et Y
        GetComponent<Rigidbody2D>().velocity = new Vector2(vitesseX, vitesseY);
    }


    // |||||||||||||||||||||||||||||||||||||||| Gestion des collisions |||||||||||||||||||||||||||||||||||||||| \\
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Détection des collisions avec le sol.
        // Arrêter l'animation du saut SEULEMENT si il y a collision avec les PIEDS du personnage.
        if (Physics2D.OverlapCircle(transform.position, 0.5f))
        {
            // Quand il y a une collision avec le sol à la fin du saut, ...
            GetComponent<Animator>().SetBool("saut", false); // L'animation de saut arrête.
        }

        // Détection des collisions avec l'objet "Bombe".
        if (collision.gameObject.name == "Bombe")
        {
            GetComponent<Animator>().SetTrigger("mort"); // Si l'objet "Bombe" entre en collision avec Sonic, l'animation "Mort" de Sonic est activé.

            // Si la position de Sonic est plus grande que l'objet touché (Si il est à droite de l'écran) ...
            if (transform.position.x > collision.transform.position.x)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(10, 30);   // On pousse le personnage vers la droite en X et on augmente la hauteur en Y.
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 30);  // On pousse le personnage vers la gauche en X on et augmente la hauteur en Y.
            }

            Invoke("RecommencerJeu", 2f);
        }

        // Détection des collisions avec l'objet "Roue".
        else if (collision.gameObject.name == "Roue")
        {
            GetComponent<Animator>().SetTrigger("mort"); // Si l'objet "Roue" entre en collision avec Sonic, l'animation "Mort" de Sonic est activé.

            // Si la position de Sonic est plus grande que l'objet touché (Si il est à droite de l'écran) ...
            if (transform.position.x > collision.transform.position.x)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(10, 30);   // On pousse le personnage vers la droite en X et on augmente la hauteur en Y.
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 30);  // On pousse le personnage vers la gauche en X on et augmente la hauteur en Y.
            }

            Invoke("RecommencerJeu", 2f);
        }

        // Détection des collisions avec l'objet "Ennemi".
        else if (collision.gameObject.name == "Ennemi")
        {
            // Si Sonic est en état d'attaque ...
            if (etatAttaque == true)
            {
                Destroy(collision.gameObject);                                // L'objet "Ennemi" est détruit.
            }
            // Sinon, Sonic n'est pas en état d'attaque ...
            else
            {
                GetComponent<Animator>().SetTrigger("mort");                  // L'animation "mort" de Sonic part.
                Invoke("RecommencerJeu", 2f); 
            }
        }
    }
    // -------------------------------------------------------------------------------------------------------- \\

    // |||||||||||||||||||||||||||||||||||||||||||||| Fonctions ||||||||||||||||||||||||||||||||||||||||||||||| \\
    
    // Fonction poor recommencer le Jeu.
    void RecommencerJeu()
    {
        // SceneManager.LoadScene(0); // La scène avec l'index numéro 0 est chargée. 
        SceneManager.LoadScene(1); // La scène avec l'index numéro 1 est chargée. (Utilisé pour le développement.)
    }

    // Fonction pour changer l'etatAttaque à false après l'attaque de Sonic.
    void AnnuleAttaque()
    {
        etatAttaque = false; 
    }

    // Fonction qui permet de recevoir de l'information lors d'une collision avec un Collider2d trigger.
    private void OnTriggerEnter2D(Collider2D collisionTrigger)
    {
        // Si il y a une collision avec l'objet "FinNiveau1"
        if(collisionTrigger.gameObject.name == "FinNiveau1")
        {
            gameObject.transform.position = DebutNiveau2.transform.position; // Le PJ est téléporté au gameObject "DebutNiveau2".
        }
    }
    // -------------------------------------------------------------------------------------------------------- \\
}


