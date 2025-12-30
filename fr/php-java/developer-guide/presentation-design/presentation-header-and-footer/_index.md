---
title: Gérer les en‑têtes et pieds de page de la présentation en PHP
linktitle: En‑tête et pied de page
type: docs
weight: 140
url: /fr/php-java/presentation-header-and-footer/
keywords:
- en‑tête
- texte d'en‑tête
- pied de page
- texte du pied de page
- définir l'en‑tête
- définir le pied de page
- support
- notes
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Utilisez Aspose.Slides for PHP via Java pour ajouter et personnaliser les en‑têtes et pieds de page dans les présentations PowerPoint et OpenDocument afin d’obtenir un rendu professionnel."
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/fr/php-java/) fournit la prise en charge du travail avec les en‑têtes et pieds de page des diapositives dont le texte est réellement géré au niveau du maître de diapositive.

{{% /alert %}} 

[Aspose.Slides for PHP via Java](/slides/fr/php-java/) offre la fonctionnalité de gestion des en‑têtes et pieds de page à l'intérieur des diapositives de présentation. Ceux‑ci sont en fait gérés au niveau du maître de présentation.

## **Gérer les en‑têtes et pieds de page dans une présentation**
Les notes d’une diapositive spécifique peuvent être supprimées comme le montre l’exemple ci‑dessous :

```php
  # Charger la présentation
  $pres = new Presentation("headerTest.pptx");
  try {
    # Définir le pied de page
    $pres->getHeaderFooterManager()->setAllFootersText("My Footer text");
    $pres->getHeaderFooterManager()->setAllFootersVisibility(true);
    # Accéder et mettre à jour l'en-tête
    $masterNotesSlide = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (null != $masterNotesSlide) {
      updateHeaderFooterText($masterNotesSlide);
    }
    # Enregistrer la présentation
    $pres->save("HeaderFooterJava.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

```php

```


## **Gérer les en‑têtes et pieds de page sur les diapositives de support et de notes**
Aspose.Slides for PHP via Java prend en charge les en‑têtes et pieds de page dans les diapositives de support et de notes. Veuillez suivre les étapes ci‑dessous :

- Chargez une [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) contenant une vidéo.
- Modifiez les paramètres d’en‑tête et de pied de page pour le maître des notes et toutes les diapositives de notes.
- Rendez visibles le maître des diapositives de notes et tous les espaces réservés de pied de page enfants.
- Rendez visibles le maître des diapositives de notes et tous les espaces réservés de date et d’heure enfants.
- Modifiez les paramètres d’en‑tête et de pied de page uniquement pour la première diapositive de notes.
- Rendez visible l’espace réservé d’en‑tête de la diapositive de notes.
- Définissez le texte de l’espace réservé d’en‑tête de la diapositive de notes.
- Définissez le texte de l’espace réservé de date‑heure de la diapositive de notes.
- Enregistrez le fichier de présentation modifié.

Extrait de code fourni dans l’exemple ci‑dessous.

```php
  $pres = new Presentation("presentation.pptx");
  try {
    # Modifier les paramètres d’en‑tête et de pied de page pour le maître des notes et toutes les diapositives de notes
    $masterNotesSlide = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($masterNotesSlide)) {
      $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();
      $headerFooterManager->setHeaderAndChildHeadersVisibility(true);// rendre la diapositive maître des notes et tous les espaces réservés de pied de page enfants visibles

      $headerFooterManager->setFooterAndChildFootersVisibility(true);// rendre la diapositive maître des notes et tous les espaces réservés d’en‑tête enfants visibles

      $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);// rendre la diapositive maître des notes et tous les espaces réservés de numéro de diapositive enfants visibles

      $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);// rendre la diapositive maître des notes et tous les espaces réservés de date et heure enfants visibles

      $headerFooterManager->setHeaderAndChildHeadersText("Header text");// définir le texte de la diapositive maître des notes et de tous les espaces réservés d’en‑tête enfants

      $headerFooterManager->setFooterAndChildFootersText("Footer text");// définir le texte de la diapositive maître des notes et de tous les espaces réservés de pied de page enfants

      $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");// définir le texte de la diapositive maître des notes et de tous les espaces réservés de date et heure enfants

    }
    # Modifier les paramètres d’en‑tête et de pied de page uniquement pour la première diapositive de notes
    $notesSlide = $pres->getSlides()->get_Item(0)->getNotesSlideManager()->getNotesSlide();
    if (!java_is_null($notesSlide)) {
      $headerFooterManager = $notesSlide->getHeaderFooterManager();
      if (!$headerFooterManager->isHeaderVisible()) {
        $headerFooterManager->setHeaderVisibility(true);
      }// rendre l’espace réservé d’en‑tête de cette diapositive de notes visible

      if (!$headerFooterManager->isFooterVisible()) {
        $headerFooterManager->setFooterVisibility(true);
      }// rendre l’espace réservé de pied de page de cette diapositive de notes visible

      if (!$headerFooterManager->isSlideNumberVisible()) {
        $headerFooterManager->setSlideNumberVisibility(true);
      }// rendre l’espace réservé de numéro de diapositive de cette diapositive de notes visible

      if (!$headerFooterManager->isDateTimeVisible()) {
        $headerFooterManager->setDateTimeVisibility(true);
      }// rendre l’espace réservé de date‑heure de cette diapositive de notes visible

      $headerFooterManager->setHeaderText("New header text");// définir le texte de l’espace réservé d’en‑tête de la diapositive de notes

      $headerFooterManager->setFooterText("New footer text");// définir le texte de l’espace réservé de pied de page de la diapositive de notes

      $headerFooterManager->setDateTimeText("New date and time text");// définir le texte de l’espace réservé de date‑heure de la diapositive de notes

    }
    $pres->save("testresult.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Puis‑je ajouter un « en‑tête » aux diapositives normales ?**

Dans PowerPoint, l’« en‑tête » n’existe que pour les notes et les supports ; sur les diapositives normales, les éléments pris en charge sont le pied de page, la date/heure et le numéro de diapositive. Dans Aspose.Slides, cela correspond aux mêmes limitations : en‑tête uniquement pour les Notes/Handout, et sur les diapositives — Footer/DateTime/SlideNumber.

**Que se passe‑t‑il si la mise en page ne contient pas de zone de pied de page — puis‑je « activer » sa visibilité ?**

Oui. Vérifiez la visibilité via le gestionnaire d’en‑tête/pied de page et activez‑la si nécessaire. Ces indicateurs et méthodes de l’API sont conçus pour les cas où l’espace réservé est absent ou masqué.

**Comment faire en sorte que le numéro de diapositive commence à une valeur autre que 1 ?**

Définissez le [premier numéro de diapositive](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/setfirstslidenumber/) de la présentation ; après cela, tous les numéros sont recalculés. Par exemple, vous pouvez commencer à 0 ou 10, et masquer le numéro sur la diapositive de titre.

**Que devient les en‑têtes/pieds de page lors de l’exportation vers PDF/images/HTML ?**

Ils sont rendus comme des éléments de texte ordinaires de la présentation. Autrement dit, si les éléments sont visibles sur les diapositives/pages de notes, ils apparaîtront également dans le format de sortie avec le reste du contenu.