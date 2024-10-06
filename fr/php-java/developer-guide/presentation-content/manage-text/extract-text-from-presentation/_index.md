---
title: Extraire du texte d'une présentation
type: docs
weight: 90
url: /php-java/extract-text-from-presentation/
---

{{% alert color="primary" %}} 

Il n'est pas rare que les développeurs aient besoin d'extraire le texte d'une présentation. Pour ce faire, vous devez extraire le texte de toutes les formes sur toutes les diapositives d'une présentation. Cet article explique comment extraire le texte des présentations Microsoft PowerPoint PPTX en utilisant Aspose.Slides. 

{{% /alert %}} 
## **Extraire du texte d'une diapositive**
Aspose.Slides pour PHP via Java fournit la classe [SlideUtil](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil). Cette classe propose un certain nombre de méthodes statiques surchargées pour extraire l'intégralité du texte d'une présentation ou d'une diapositive. Pour extraire le texte d'une diapositive dans une présentation PPTX, utilisez la méthode statique surchargée [getAllTextBoxes](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#getAllTextBoxes-com.aspose.slides.IBaseSlide-) proposée par la classe [SlideUtil](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil). Cette méthode accepte l'objet Slide comme paramètre. Lors de son exécution, la méthode Slide scanne tout le texte de la diapositive passée en paramètre et retourne un tableau d'objets [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame). Cela signifie que toute mise en forme de texte associée au texte est disponible. Le code suivant extrait tout le texte de la première diapositive de la présentation :

```php
  # Instancier la classe Presentation qui représente un fichier PPTX
  $pres = new Presentation("demo.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    foreach($pres->getSlides() as $slide) {
      # Obtenir un tableau d'objets ITextFrame de toutes les diapositives dans le PPTX
      $textFramesPPTX = SlideUtil->getAllTextBoxes($slide);
      # Boucler à travers le tableau de TextFrames
      for($i = 0; $i < java_values($Array->getLength($textFramesPPTX)) ; $i++) {
        # Boucler à travers les paragraphes dans le ITextFrame actuel
        foreach($textFramesPPTX[$i]->getParagraphs() as $para) {
          # Boucler à travers les portions dans le IParagraph actuel
          foreach($para->getPortions() as $port) {
            # Afficher le texte dans la portion actuelle
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

## **Extraire du texte d'une présentation**
Pour scanner le texte de l'ensemble de la présentation, utilisez la méthode statique [getAllTextFrames](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) proposée par la classe SlideUtil. Elle prend deux paramètres :

1. Tout d'abord, un objet [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/TextExtractionArrangingMode#Unarranged) qui représente la présentation dont le texte est extrait.
1. Deuxièmement, une valeur booléenne déterminant si la diapositive maître doit être incluse lorsque le texte est analysé à partir de la présentation. La méthode retourne un tableau d'objets [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame), complet avec des informations de mise en forme du texte. Le code ci-dessous analyse le texte et les informations de mise en forme d'une présentation, y compris les diapositives maîtresses.

```php
  # Instancier la classe Presentation qui représente un fichier PPTX
  $pres = new Presentation("demo.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # Obtenir un tableau d'objets ITextFrame de toutes les diapositives dans le PPTX
    $textFramesPPTX = SlideUtil->getAllTextFrames($pres, true);
    # Boucler à travers le tableau de TextFrames
    for($i = 0; $i < java_values($Array->getLength($textFramesPPTX)) ; $i++) {
      # Boucler à travers les paragraphes dans le ITextFrame actuel
      foreach($textFramesPPTX[$i]->getParagraphs() as $para) {
        # Boucler à travers les portions dans le IParagraph actuel
        foreach($para->getPortions() as $port) {
          # Afficher le texte dans la portion actuelle
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
La nouvelle méthode statique getPresentationText a été ajoutée à la classe Presentation. Il existe trois surcharges pour cette méthode :

```php

``` 

L'argument enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/php-java/aspose.slides/TextExtractionArrangingMode) indique le mode d'organisation de la sortie du résultat de texte et peut être défini sur les valeurs suivantes :
- [Unarranged](https://reference.aspose.com/slides/php-java/aspose.slides/TextExtractionArrangingMode#Unarranged) - Le texte brut sans respect de la position sur la diapositive
- [Arranged](https://reference.aspose.com/slides/php-java/aspose.slides/TextExtractionArrangingMode#Arranged) - Le texte est positionné dans le même ordre que sur la diapositive

Le mode **Unarranged** peut être utilisé lorsque la vitesse est cruciale, il est plus rapide que le mode Arranged.

[IPresentationText](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationText) représente le texte brut extrait de la présentation. Il contient une méthode [getSlidesText](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationText#getSlidesText--) qui retourne un tableau d'objets [ISlideText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText). Chaque objet représente le texte sur la diapositive correspondante. L'objet [ISlideText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText) a les méthodes suivantes :

- [ISlideText.getText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText#getText--) - Le texte sur les formes de la diapositive
- [ISlideText.getMasterText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText#getMasterText--) - Le texte sur les formes de la page maître pour cette diapositive
- [ISlideText.getLayoutText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText#getLayoutText--) - Le texte sur les formes de la page de mise en page pour cette diapositive
- [ISlideText.getNotesText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText#getNotesText--) - Le texte sur les formes de la page de notes pour cette diapositive

Il existe également une classe [SlideText](https://reference.aspose.com/slides/php-java/aspose.slides/SlideText) qui implémente l'interface [ISlideText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText).

La nouvelle API peut être utilisée comme ceci :

```php
  $text1 = PresentationFactory->getInstance()->getPresentationText("presentation.pptx", TextExtractionArrangingMode->Unarranged);
  echo($text1->getSlidesText()[0]->getText());
  echo($text1->getSlidesText()[0]->getLayoutText());
  echo($text1->getSlidesText()[0]->getMasterText());
  echo($text1->getSlidesText()[0]->getNotesText());

```