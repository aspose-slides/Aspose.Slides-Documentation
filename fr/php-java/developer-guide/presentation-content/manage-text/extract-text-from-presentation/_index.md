---
title: Extraction avancée de texte à partir de présentations en PHP
linktitle: Extraire le texte
type: docs
weight: 90
url: /fr/php-java/extract-text-from-presentation/
keywords:
- extraire le texte
- extraire le texte d'une diapositive
- extraire le texte d'une présentation
- extraire le texte de PowerPoint
- extraire le texte d'OpenDocument
- extraire le texte de PPT
- extraire le texte de PPTX
- extraire le texte d'ODP
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
description: "Extrayez rapidement le texte des présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour PHP via Java. Suivez notre guide simple, étape par étape, pour gagner du temps."
---

{{% alert color="primary" %}} 

Il n'est pas rare que les développeurs aient besoin d'extraire le texte d'une présentation. Pour ce faire, vous devez extraire le texte de toutes les formes sur toutes les diapositives d'une présentation. Cet article explique comment extraire le texte des présentations Microsoft PowerPoint PPTX à l'aide d'Aspose.Slides. 

{{% /alert %}} 
## **Extraire le texte des diapositives**
Aspose.Slides for PHP via Java fournit la classe [SlideUtil](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil). Cette classe expose un certain nombre de méthodes statiques surchargées pour extraire le texte complet d'une présentation ou d'une diapositive. Pour extraire le texte d'une diapositive dans une présentation PPTX,
utilisez la méthode statique surchargée [getAllTextBoxes](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#getAllTextBoxes-com.aspose.slides.IBaseSlide-) exposée par la classe [SlideUtil](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil). Cette méthode accepte l'objet Slide comme paramètre.
Lors de l'exécution, la méthode Slide parcourt tout le texte de la diapositive passée en paramètre et renvoie un tableau d'objets [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame). Cela signifie que tout formatage de texte associé au texte est disponible. Le fragment de code suivant extrait tout le texte de la première diapositive de la présentation :
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
        # Parcourir les paragraphes dans le ITextFrame actuel
        foreach($textFramesPPTX[$i]->getParagraphs() as $para) {
          # Parcourir les portions dans le IParagraph actuel
          foreach($para->getPortions() as $port) {
            # Afficher le texte dans la portion actuelle
            echo($port->getText());
            # Afficher la hauteur de police du texte
            echo($port->getPortionFormat()->getFontHeight());
            # Afficher le nom de police du texte
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
Pour parcourir le texte de l'ensemble de la présentation, utilisez la méthode statique [getAllTextFrames](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) exposée par la classe SlideUtil. Elle prend deux paramètres :

1. Tout d'abord, un objet [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/TextExtractionArrangingMode#Unarranged) qui représente la présentation dont le texte doit être extrait.
1. Deuxièmement, une valeur booléenne déterminant si la diapositive maîtresse doit être incluse lors du scan du texte de la présentation.  
   La méthode renvoie un tableau d'objets [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame), complet avec les informations de formatage du texte. Le code ci‑dessous parcourt le texte et les informations de formatage d'une présentation, y compris les diapositives maîtresses.
```php
  # Instancier la classe Presentation qui représente un fichier PPTX
  $pres = new Presentation("demo.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # Obtenir un tableau d'objets ITextFrame à partir de toutes les diapositives du PPTX
    $textFramesPPTX = SlideUtil->getAllTextFrames($pres, true);
    # Parcourir le tableau de TextFrames
    for($i = 0; $i < java_values($Array->getLength($textFramesPPTX)) ; $i++) {
      # Parcourir les paragraphes dans le ITextFrame actuel
      foreach($textFramesPPTX[$i]->getParagraphs() as $para) {
        # Parcourir les portions dans le IParagraph actuel
        foreach($para->getPortions() as $port) {
          # Afficher le texte dans la portion actuelle
          echo($port->getText());
          # Afficher la hauteur de police du texte
          echo($port->getPortionFormat()->getFontHeight());
          # Afficher le nom de police du texte
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


## **Extraction de texte classée et rapide**
La nouvelle méthode statique getPresentationText a été ajoutée à la classe Presentation. Il existe trois surcharges pour cette méthode :
```php

```


## **FAQ**

**À quelle vitesse Aspose.Slides traite-t‑il les grandes présentations lors de l'extraction du texte ?**

Aspose.Slides est optimisé pour des performances élevées et traite efficacement même les [grandes présentations](/slides/fr/php-java/open-presentation/), ce qui le rend adapté aux scénarios de traitement en temps réel ou en masse.

**Aspose.Slides peut‑il extraire le texte des tableaux et des graphiques présents dans les présentations ?**

Oui, Aspose.Slides prend pleinement en charge l'extraction de texte à partir des tableaux, graphiques et autres éléments complexes des diapositives, vous permettant d'accéder et d'analyser facilement tout le contenu textuel.

**Ai‑je besoin d’une licence spéciale Aspose.Slides pour extraire le texte des présentations ?**

Vous pouvez extraire le texte avec la version d'essai gratuite d'Aspose.Slides, bien qu'elle comporte certaines limitations, comme le traitement d'un nombre limité de diapositives. Pour une utilisation illimitée et pour gérer des présentations plus volumineuses, l'achat d'une licence complète est recommandé.