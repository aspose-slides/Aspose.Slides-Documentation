---
title: Gérer les notes de présentation en PHP
linktitle: Notes de présentation
type: docs
weight: 110
url: /fr/php-java/presentation-notes/
keywords:
- notes
- diapositive de notes
- ajouter des notes
- supprimer des notes
- style de notes
- notes maîtres
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Personnalisez les notes de présentation avec Aspose.Slides pour PHP via Java. Travaillez sans effort avec les notes PowerPoint et OpenDocument pour augmenter votre productivité."
---

{{% alert color="primary" %}} 

Aspose.Slides prend en charge la suppression des diapositives de notes d’une présentation. Dans cet article, nous présenterons cette nouvelle fonctionnalité de suppression des notes ainsi que l’ajout de diapositives de style de notes à toute présentation. 

{{% /alert %}} 

Aspose.Slides for PHP via Java fournit la fonctionnalité de suppression des notes de n’importe quelle diapositive ainsi que l’ajout de style aux notes existantes. Les développeurs peuvent supprimer les notes de la manière suivante :

* Supprimer les notes d’une diapositive spécifique d’une présentation.  
* Supprimer les notes de toutes les diapositives d’une présentation.  


## **Remove Notes from a Slide**
Les notes d’une diapositive spécifique peuvent être supprimées comme montré dans l’exemple ci‑dessous :
```php
  # Instanciez un objet Presentation qui représente un fichier de présentation
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # Suppression des notes de la première diapositive
    $mgr = $pres->getSlides()->get_Item(0)->getNotesSlideManager();
    $mgr->removeNotesSlide();
    # Enregistrement de la présentation sur le disque
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Remove Notes from a Presentation**
Les notes de toutes les diapositives d’une présentation peuvent être supprimées comme montré dans l’exemple ci‑dessous :
```php
  # Instanciez un objet Presentation qui représente un fichier de présentation
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # Suppression des notes de toutes les diapositives
    $mgr = null;
    for($i = 0; $i < java_values($pres->getSlides()->size()) ; $i++) {
      $mgr = $pres->getSlides()->get_Item($i)->getNotesSlideManager();
      $mgr->removeNotesSlide();
    }
    # Enregistrement de la présentation sur le disque
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Add a Notes Style**
[getNotesStyle](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterNotesSlide#getNotesStyle--) method a été ajouté à l’interface [IMasterNotesSlide](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterNotesSlide) et à la classe [MasterNotesSlide](https://reference.aspose.com/slides/php-java/aspose.slides/MasterNotesSlide) respectivement. Cette propriété spécifie le style du texte des notes. L’implémentation est démontrée dans l’exemple ci‑dessous.
```php
  # Instanciez un objet Presentation qui représente un fichier de présentation
  $pres = new Presentation("demo.pptx");
  try {
    $notesMaster = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
      # Récupérer le style de texte du MasterNotesSlide
      $notesStyle = $notesMaster->getNotesStyle();
      # Définir une puce symbole pour les paragraphes de premier niveau
      $paragraphFormat = $notesStyle->getLevel(0);
      $paragraphFormat::getBullet()->setType(BulletType::Symbol);
    }
    $pres->save("NotesSlideWithNotesStyle.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Which API entity provides access to the notes of a specific slide?**

Les notes sont accessibles via le gestionnaire de notes de la diapositive : la diapositive possède un [NotesSlideManager](https://reference.aspose.com/slides/php-java/aspose.slides/notesslidemanager/) et une [method](https://reference.aspose.com/slides/php-java/aspose.slides/notesslidemanager/getnotesslide/) qui renvoie l’objet notes, ou `null` s’il n’y a aucune note.

**Are there differences in notes support across the PowerPoint versions the library works with?**

La bibliothèque cible une large gamme de formats Microsoft PowerPoint (97 et plus récents) ainsi que ODP ; les notes sont prises en charge dans ces formats sans dépendre d’une copie installée de PowerPoint.