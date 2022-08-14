# Laboratoire final : ... #

> Projet final dans le cadre du cours *Développement orienté objets et multitâche : Programmation orientée objet Windows- C#*

## Real Madrid  Football registry ##

L’objectif de ce projet est de créer une application permettant enregistrer les informations (C’est-à-dire les moments fort) concernant des matches de football ![alt](/260px-Football_Pallo_valmiina-cropped.jpg) de différents compétition. 

Lors de ces matches les différents buteur , le stade ainsin que l'arbitre de la rencontre seront enregistré. 

Il y'aura aussi la possibilités de voir les buts de chaque joueurs .

Toutes les données seront engristrer dans des fichiers XML.


## <u>Class</u> ##



#### Class Joueur  ####

##### Class qui permettre d'instancier les joueur.

String Nom;
int numéro;
String Poste;
datetime age; 

L'age est calculer à partir de la date de naissance.

Note Moyenne;

#### Match ####

##### Class qui permettra  d'instancier les match

 String _nomMatch  
  Il s'agira en réaliter du nom de l'équipe adverse, le but de l'aplication etant enregistrer les matches du Real Madrid il n'est pas nésseaire de créér une class equipe. Enregistrer le nom des opposant et largement suffisant .
 String arbitre 
  Il s'agira de l'arbitre de la rencontre.
  List<but> buteur
  Il s'agira de la liste des buteur du match.
  String Stade 
  Il s'agira du stade, ou le match a eu lieu
 int ButEncaisse 
  il s'agira du nombre de buteur encaisser 
  int ButMarque 
  il s'agira du nombre de but marquer, il sera set a partir de numbre élément de la liste de buteur
  List<Joueur> ListJoueur
  Il s'agira de la liste de joueur ayant  participer au match
  
  
#### But ####

##### Class qui permettra  d'instancier un buteur lors dans un match, l'objet créér sera rajouter dans une liste de la classe Match afin de repertorier les différents buteur du match.
  
  Int minute 
  Il s'agit tout simplement de la minute à laquelle le buteur en question à marquer.
  Joueur buteur
  Il s'agit du buteur en question
  
#### MatchBut ####

##### Class qui permettra  d'instancier un match dans lequel un joueur précis a marquer, tout commme la classe but il sera utiliser sous forme de liste a la simple différence que cette classe sera Sérialiser afin de faciliter sa manipulation.
  
 Match match 
  Le match en question 
 Joueur Joueur
  Le joueur en question, utile car lorsque je clique sur un joueur je peu avoir plus de details sur celui ci, J'ai besoin enregistrer le joueur pour pour le retrouver lorsque je vais parcourir le fichier
  int Minute
  La minute du match auquel il a marquer 


## Diagrame UML

![alt](/UML.jpg)


  
  
  








⚠️ Ce document est *la documentation* de votre projet. Il est *obligatoire* de donner les informations pour qu'une personne, qui ne connait pas votre projet, puisse comprendre de quoi il s'agit. Référez-vous aux consignes données dans l'énoncé sur Moodle.
