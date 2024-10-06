---
title: Gérer le Remplaçant
type: docs
weight: 10
url: /php-java/manage-placeholder/
description: Modifier le texte dans un remplaçant dans des diapositives PowerPoint à l'aide de PHP. Définir le texte d'invite dans un remplaçant dans des diapositives PowerPoint à l'aide de PHP.
---

## **Modifier le texte dans le remplaçant**
À l'aide de [Aspose.Slides pour PHP via Java](/slides/php-java/), vous pouvez trouver et modifier des remplaçants sur des diapositives dans des présentations. Aspose.Slides vous permet de modifier le texte dans un remplaçant.

**Conditions préalables** : Vous avez besoin d'une présentation contenant un remplaçant. Vous pouvez créer une telle présentation dans l'application Microsoft PowerPoint standard.

Voici comment utiliser Aspose.Slides pour remplacer le texte dans le remplaçant de cette présentation :

1. Instanciez la classe [`Presentation`](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) et passez la présentation en tant qu'argument.
2. Obtenez une référence à la diapositive par son index.
3. Itérez à travers les formes pour trouver le remplaçant.
4. Convertissez le remplaçant en une [`AutoShape`](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape) et modifiez le texte à l'aide de la [`TextFrame`](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame) associée à l’[`AutoShape`](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape).
5. Enregistrez la présentation modifiée.

Ce code PHP montre comment modifier le texte dans un remplaçant :

```php
  # Instancie une classe Presentation
  $pres = new Presentation("ReplacingText.pptx");
  try {
    # Accède à la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Itère à travers les formes pour trouver le remplaçant
    foreach($sld->getShapes() as $shp) {
      if (!java_is_null($shp->getPlaceholder())) {
        # Modifie le texte dans chaque remplaçant
        $shp->getTextFrame()->setText("Ceci est un remplaçant");
      }
    }
    # Enregistre la présentation sur le disque
    $pres->save("output_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Définir le texte d'invite dans le remplaçant**
Les mises en page standard et pré-construites contiennent des textes d'invite de remplaçant tels que ***Cliquez pour ajouter un titre*** ou ***Cliquez pour ajouter un sous-titre***. À l'aide d'Aspose.Slides, vous pouvez insérer vos textes d'invite préférés dans les mises en page de remplaçant.

Ce code PHP vous montre comment définir le texte d'invite dans un remplaçant :

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # Itère à travers la diapositive
    foreach($slide->getSlide()->getShapes() as $shape) {
      if (java_instanceof($shape->getPlaceholder()) != null && $shape, new JavaClass("com.aspose.slides.AutoShape")) {
        $text = "";
        # PowerPoint affiche "Cliquez pour ajouter un titre"
        if ($shape->getPlaceholder()->getType() == PlaceholderType::CenteredTitle) {
          $text = "Ajouter un titre";
        } else // Ajoute un sous-titre
        if ($shape->getPlaceholder()->getType() == PlaceholderType::Subtitle) {
          $text = "Ajouter un sous-titre";
        }
        $shape->getTextFrame()->setText($text);
        echo("Remplaçant avec texte : " . $text);
      }
    }
    $pres->save("Placeholders_PromptText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Définir la transparence de l'image du remplaçant**

Aspose.Slides vous permet de définir la transparence de l'image d'arrière-plan dans un remplaçant de texte. En ajustant la transparence de l'image dans un tel cadre, vous pouvez faire ressortir le texte ou l'image (en fonction des couleurs du texte et de l'image).

Ce code PHP vous montre comment définir la transparence pour un arrière-plan d'image (à l'intérieur d'une forme) :

```php
  $presentation = new Presentation("example.pptx");
  $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $operationCollection = $shape->getFillFormat()->getPictureFillFormat()->getPicture()->getImageTransform();
  for($i = 0; $i < java_values($operationCollection->size()); $i++) {
    if (java_instanceof($operationCollection->get_Item($i)), new JavaClass("com.aspose.slides.AlphaModulateFixed")) {
      $alphaModulate = $operationCollection->get_Item($i);
      $currentValue = 100 - $alphaModulate->getAmount();
      echo("Valeur de transparence actuelle : " . $currentValue);
      $alphaValue = 40;
      $alphaModulate->setAmount(100 - $alphaValue);
    }
  }
  $presentation->save("example_out.pptx", SaveFormat::Pptx);

```