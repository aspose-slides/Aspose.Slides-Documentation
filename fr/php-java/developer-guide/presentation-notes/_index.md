---
title: Notes de Présentation
type: docs
weight: 110
url: /fr/php-java/presentation-notes/
keywords: "Notes de conférencier PowerPoint"
description: "Notes de présentation, notes de conférencier"
---

{{% alert color="primary" %}} 

Aspose.Slides prend en charge la suppression des diapositives de notes d'une présentation. Dans ce sujet, nous allons introduire cette nouvelle fonctionnalité de suppression des notes tout en ajoutant des diapositives de style de notes à n'importe quelle présentation. 

{{% /alert %}} 

Aspose.Slides pour PHP via Java fournit la fonctionnalité de suppression des notes de n'importe quelle diapositive ainsi que l'ajout de style aux notes existantes. Les développeurs peuvent supprimer des notes de la manière suivante :

* Supprimer les notes d'une diapositive spécifique d'une présentation.
* Supprimer les notes de toutes les diapositives d'une présentation.


## **Supprimer les Notes d'une Diapositive**
Les notes d'une diapositive spécifique peuvent être supprimées comme indiqué dans l'exemple ci-dessous :

```php
  # Instancier un objet Presentation qui représente un fichier de présentation
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # Suppression des notes de la première diapositive
    $mgr = $pres->getSlides()->get_Item(0)->getNotesSlideManager();
    $mgr->removeNotesSlide();
    # Sauvegarder la présentation sur le disque
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Supprimer les Notes d'une Présentation**
Les notes de toutes les diapositives d'une présentation peuvent être supprimées comme indiqué dans l'exemple ci-dessous :

```php
  # Instancier un objet Presentation qui représente un fichier de présentation
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # Suppression des notes de toutes les diapositives
    $mgr = null;
    for($i = 0; $i < java_values($pres->getSlides()->size()) ; $i++) {
      $mgr = $pres->getSlides()->get_Item($i)->getNotesSlideManager();
      $mgr->removeNotesSlide();
    }
    # Sauvegarder la présentation sur le disque
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ajouter NotesStyle**
[getNotesStyle](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterNotesSlide#getNotesStyle--) méthode a été ajoutée à l'interface [IMasterNotesSlide](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterNotesSlide) et à la classe [MasterNotesSlide](https://reference.aspose.com/slides/php-java/aspose.slides/MasterNotesSlide) respectivement. Cette propriété spécifie le style d'un texte de notes. L'implémentation est démontrée dans l'exemple ci-dessous.

```php
  # Instancier un objet Presentation qui représente un fichier de présentation
  $pres = new Presentation("demo.pptx");
  try {
    $notesMaster = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
      # Obtenir le style de texte de MasterNotesSlide
      $notesStyle = $notesMaster->getNotesStyle();
      # Définir un symbole de puce pour les paragraphes de premier niveau
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