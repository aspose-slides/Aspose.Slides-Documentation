---
title: Extraction avancée de texte à partir de présentations en PHP
linktitle: Extraire le texte
type: docs
weight: 90
url: /fr/php-java/extract-text-from-presentation/
keywords:
- extraire du texte
- extraire du texte d'une diapositive
- extraire du texte d'une présentation
- extraire du texte de PowerPoint
- extraire du texte d'OpenDocument
- extraire du texte de PPT
- extraire du texte de PPTX
- extraire du texte d'ODP
- récupérer le texte
- récupérer le texte d'une diapositive
- récupérer le texte d'une présentation
- récupérer le texte de PowerPoint
- récupérer le texte d'OpenDocument
- récupérer le texte de PPT
- récupérer le texte de PPTX
- récupérer le texte d'ODP
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Extrayez rapidement du texte des présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour PHP via Java. Suivez notre guide simple, étape par étape, pour gagner du temps."
---

{{% alert color="primary" %}} 
Il n'est pas rare que les développeurs aient besoin d'extraire le texte d'une présentation. Pour ce faire, vous devez extraire le texte de toutes les formes de toutes les diapositives d'une présentation. Cet article explique comment extraire le texte des présentations Microsoft PowerPoint PPTX à l'aide d'Aspose.Slides. 
{{% /alert %}} 
## **Extraire le texte des diapositives**
Aspose.Slides for PHP via Java fournit la classe [SlideUtil](https://reference.aspose.com/slides/php-java/aspose.slides/slideutil/). Cette classe expose un certain nombre de méthodes statiques surchargées pour extraire le texte complet d'une présentation ou d'une diapositive. Pour extraire le texte d'une diapositive dans une présentation PPTX, utilisez la méthode statique surchargée [getAllTextBoxes](https://reference.aspose.com/slides/php-java/aspose.slides/slideutil/getalltextboxes/) exposée par la classe [SlideUtil](https://reference.aspose.com/slides/php-java/aspose.slides/slideutil/). Cette méthode accepte l'objet Slide comme paramètre.  
Lors de l'exécution, la méthode Slide parcourt l'intégralité du texte de la diapositive transmise en paramètre et renvoie un tableau d'objets [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) . Cela signifie que tout formatage de texte associé est disponible. Le fragment de code suivant extrait tout le texte de la première diapositive de la présentation:
```php
  # Instancier la classe Presentation qui représente un fichier PPTX
  $pres = new Presentation("demo.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    foreach($pres->getSlides() as $slide) {
      # Obtenir un tableau d'objets ITextFrame à partir de toutes les diapositives du PPTX
      $textFramesPPTX = SlideUtil->getAllTextBoxes($slide);
      # Parcourir le tableau de TextFrames
      for($i = 0; $i < java_values($Array->getLength($textFramesPPTX)) ; $i++) {
        # Parcourir les paragraphes du ITextFrame actuel
        foreach($textFramesPPTX[$i]->getParagraphs() as $para) {
          # Parcourir les portions du IParagraph actuel
          foreach($para->getPortions() as $port) {
            # Afficher le texte de la portion actuelle
            echo($port->getText());
            # Afficher la hauteur de la police du texte
            echo($port->getPortionFormat()->getFontHeight());
            # Afficher le nom de la police du texte
            if (!java_is_null($port->getPortionFormat()->getLatinFont())) {
              echo($port->getPortionFormat()->getLatinFont()->getFontName());
            }
          }
        }
      }
    }
  } finally {
    $pres->dispose();
  }
```


## **Extraire le texte des présentations**
Pour parcourir le texte de l'ensemble de la présentation, utilisez la méthode statique [getAllTextFrames](https://reference.aspose.com/slides/php-java/aspose.slides/slideutil/getalltextframes/) exposée par la classe SlideUtil. Elle prend deux paramètres :

1. Premièrement, un objet [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) qui représente la présentation dont le texte est extrait.  
1. Deuxièmement, une valeur booléenne indiquant si la diapositive principale doit être incluse lors du parcours du texte de la présentation.  
La méthode renvoie un tableau d'objets [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) complets avec les informations de formatage du texte. Le code ci‑dessous parcourt le texte et les informations de formatage d'une présentation, y compris les diapositives principales.
```php
  # Instancier la classe Presentation qui représente un fichier PPTX
  $pres = new Presentation("demo.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # Obtenir un tableau d'objets ITextFrame à partir de toutes les diapositives du PPTX
    $textFramesPPTX = SlideUtil->getAllTextFrames($pres, true);
    # Parcourir le tableau de TextFrames
    for($i = 0; $i < java_values($Array->getLength($textFramesPPTX)) ; $i++) {
      # Parcourir les paragraphes du ITextFrame actuel
      foreach($textFramesPPTX[$i]->getParagraphs() as $para) {
        # Parcourir les portions du IParagraph actuel
        foreach($para->getPortions() as $port) {
          # Afficher le texte de la portion actuelle
          echo($port->getText());
          # Afficher la hauteur de la police du texte
          echo($port->getPortionFormat()->getFontHeight());
          # Afficher le nom de la police du texte
          if (!java_is_null($port->getPortionFormat()->getLatinFont())) {
            echo($port->getPortionFormat()->getLatinFont()->getFontName());
          }
        }
      }
    }
  } finally {
    $pres->dispose();
  }
```


## **Extraction de texte catégorisée et rapide**
La nouvelle méthode statique getPresentationText a été ajoutée à la classe Presentation. Il existe trois surcharges pour cette méthode:
```php

``` 

The [TextExtractionArrangingMode](https://reference.aspose.com/slides/php-java/aspose.slides/textextractionarrangingmode/) enum argument indicates the mode to organize the output of text result and can be set to the following values:
- [Unarranged](https://reference.aspose.com/slides/php-java/aspose.slides/textextractionarrangingmode/#Unarranged) - The raw text with no respect to position on the slide
- [Arranged](https://reference.aspose.com/slides/php-java/aspose.slides/textextractionarrangingmode/#Arranged) - The text is positioned in the same order as on the slide

**Unarranged** mode can be used when speed is critical, it's faster than Arranged mode.

[PresentationText](https://reference.aspose.com/slides/php-java/aspose.slides/presentationtext/) represents the raw text extracted from the presentation. It contains a [getSlidesText](https://reference.aspose.com/slides/php-java/aspose.slides/presentationtext/getslidestext/) method which returns an array of `SlideText` objects. Every object represent the text on the corresponding slide. `SlideText` object have the following methods:

- `SlideText.getText` - The text on the slide's shapes
- `SlideText.getMasterText` - The text on the master page's shapes for this slide
- `SlideText.getLayoutText` - The text on the layout page's shapes for this slide
- `SlideText.getNotesText` - The text on the notes page's shapes for this slide

The new API can be used like this:

```php
  $text1 = PresentationFactory->getInstance()->getPresentationText("presentation.pptx", TextExtractionArrangingMode->Unarranged);
  echo($text1->getSlidesText()[0]->getText());
  echo($text1->getSlidesText()[0]->getLayoutText());
  echo($text1->getSlidesText()[0]->getMasterText());
  echo($text1->getSlidesText()[0]->getNotesText());

```


## **FAQ**

**À quelle vitesse Aspose.Slides traite-t-il les grandes présentations lors de l'extraction de texte ?**

Aspose.Slides est optimisé pour des performances élevées et traite efficacement même les [grandes présentations](/slides/fr/php-java/open-presentation/), ce qui le rend adapté aux scénarios de traitement en temps réel ou en lot.

**Aspose.Slides peut-il extraire le texte des tableaux et graphiques au sein des présentations ?**

Oui, Aspose.Slides prend entièrement en charge l'extraction du texte des tableaux, graphiques et autres éléments complexes des diapositives, vous permettant d'accéder et d'analyser facilement tout le contenu textuel.

**Ai-je besoin d'une licence spéciale Aspose.Slides pour extraire le texte des présentations ?**

Vous pouvez extraire le texte avec la version d'essai gratuite d'Aspose.Slides, bien qu'elle comporte certaines limitations, comme le traitement d'un nombre limité de diapositives. Pour une utilisation sans restriction et pour gérer de plus grandes présentations, l'achat d'une licence complète est recommandé.