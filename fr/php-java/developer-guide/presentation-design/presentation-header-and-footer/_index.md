---
title: En-tête et Pied de page de Présentation
type: docs
weight: 140
url: /php-java/presentation-header-and-footer/
keywords: "En-tête et pied de page PowerPoint"
description: "En-tête et pied de page PowerPoint"
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/php-java/) offre la prise en charge pour travailler avec le texte des en-têtes et pieds de page qui sont en fait maintenus au niveau du modèle de diapositive.

{{% /alert %}} 

[Aspose.Slides pour PHP via Java](/slides/php-java/) fournit la fonction pour gérer les en-têtes et pieds de page dans les diapositives de présentation. Ceux-ci sont en fait gérés au niveau du modèle de présentation.

## **Gérer l'en-tête et le pied de page dans la présentation**
Les notes de certaines diapositives spécifiques peuvent être supprimées comme indiqué dans l'exemple ci-dessous :

```php
  # Charger la présentation
  $pres = new Presentation("headerTest.pptx");
  try {
    # Configuration du pied de page
    $pres->getHeaderFooterManager()->setAllFootersText("Mon texte de pied de page");
    $pres->getHeaderFooterManager()->setAllFootersVisibility(true);
    # Accéder et mettre à jour l'en-tête
    $masterNotesSlide = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (null != $masterNotesSlide) {
      updateHeaderFooterText($masterNotesSlide);
    }
    # Sauvegarder la présentation
    $pres->save("HeaderFooterJava.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
```php

```

## **Gérer l'en-tête et le pied de page dans les diapositives de remise et de notes**
Aspose.Slides pour PHP via Java prend en charge l'en-tête et le pied de page dans les diapositives de remise et de notes. Veuillez suivre les étapes ci-dessous :

- Charger une [Présentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) contenant une vidéo.
- Modifier les paramètres de l'en-tête et du pied de page pour le modèle de notes et toutes les diapositives de notes.
- Rendre le modèle de notes et tous les espaces réservés pour le pied de page visibles.
- Rendre le modèle de notes et tous les espaces réservés pour la date et l'heure visibles.
- Modifier les paramètres de l'en-tête et du pied de page pour la première diapositive de notes uniquement.
- Rendre l'espace réservé de l'en-tête de la diapositive de notes visible.
- Mettre du texte dans l'espace réservé de l'en-tête de la diapositive de notes.
- Mettre du texte dans l'espace réservé de la date et de l'heure de la diapositive de notes.
- Écrire le fichier de présentation modifié.

Exemple de code fourni ci-dessous.

```php
  $pres = new Presentation("presentation.pptx");
  try {
    # Modifier les paramètres de l'en-tête et du pied de page pour le modèle de notes et toutes les diapositives de notes
    $masterNotesSlide = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($masterNotesSlide)) {
      $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();
      $headerFooterManager->setHeaderAndChildHeadersVisibility(true);// rendre le modèle de notes et tous les espaces réservés pour le pied de page visibles

      $headerFooterManager->setFooterAndChildFootersVisibility(true);// rendre le modèle de notes et tous les espaces réservés pour l'en-tête visibles

      $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);// rendre le modèle de notes et tous les espaces réservés pour le numéro de diapositive visibles

      $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);// rendre le modèle de notes et tous les espaces réservés pour la date et l'heure visibles

      $headerFooterManager->setHeaderAndChildHeadersText("Texte de l'en-tête");// définir le texte pour le modèle de notes et tous les espaces réservés de l'en-tête

      $headerFooterManager->setFooterAndChildFootersText("Texte du pied de page");// définir le texte pour le modèle de notes et tous les espaces réservés de pied de page

      $headerFooterManager->setDateTimeAndChildDateTimesText("Texte de date et heure");// définir le texte pour le modèle de notes et tous les espaces réservés de date et d'heure

    }
    # Modifier les paramètres de l'en-tête et du pied de page uniquement pour la première diapositive de notes
    $notesSlide = $pres->getSlides()->get_Item(0)->getNotesSlideManager()->getNotesSlide();
    if (!java_is_null($notesSlide)) {
      $headerFooterManager = $notesSlide->getHeaderFooterManager();
      if (!$headerFooterManager->isHeaderVisible()) {
        $headerFooterManager->setHeaderVisibility(true);
      }// rendre cet espace réservé d'en-tête de diapositive de notes visible

      if (!$headerFooterManager->isFooterVisible()) {
        $headerFooterManager->setFooterVisibility(true);
      }// rendre cet espace réservé de pied de page de diapositive de notes visible

      if (!$headerFooterManager->isSlideNumberVisible()) {
        $headerFooterManager->setSlideNumberVisibility(true);
      }// rendre cet espace réservé de numéro de diapositive de notes visible

      if (!$headerFooterManager->isDateTimeVisible()) {
        $headerFooterManager->setDateTimeVisibility(true);
      }// rendre cet espace réservé de date et heure de diapositive de notes visible

      $headerFooterManager->setHeaderText("Nouveau texte d'en-tête");// définir le texte pour l'espace réservé d'en-tête de diapositive de notes

      $headerFooterManager->setFooterText("Nouveau texte de pied de page");// définir le texte pour l'espace réservé de pied de page de diapositive de notes

      $headerFooterManager->setDateTimeText("Nouveau texte de date et heure");// définir le texte pour l'espace réservé de date et heure de diapositive de notes

    }
    $pres->save("testresult.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```