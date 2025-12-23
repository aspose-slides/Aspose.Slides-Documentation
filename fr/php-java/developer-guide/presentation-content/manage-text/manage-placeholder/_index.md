---
title: Gérer les espaces réservés de présentation en PHP
linktitle: Gérer les espaces réservés
type: docs
weight: 10
url: /fr/php-java/manage-placeholder/
keywords:
- espace réservé
- espace réservé texte
- espace réservé image
- espace réservé graphique
- texte d'invite
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Gérez facilement les espaces réservés dans Aspose.Slides pour PHP via Java : remplacez le texte, personnalisez les invites et définissez la transparence des images dans PowerPoint et OpenDocument."
---

## **Modifier le texte dans un espace réservé**
En utilisant [Aspose.Slides for PHP via Java](/slides/fr/php-java/), vous pouvez trouver et modifier les espaces réservés sur les diapositives dans les présentations. Aspose.Slides vous permet d'apporter des modifications au texte d'un espace réservé.

**Pré-requis** : Vous avez besoin d'une présentation contenant un espace réservé. Vous pouvez créer une telle présentation dans l'application Microsoft PowerPoint standard.

Voici comment utiliser Aspose.Slides pour remplacer le texte dans l'espace réservé de cette présentation :

1. Instanciez la classe [`Presentation`](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) et passez la présentation comme argument.  
2. Obtenez une référence de diapositive via son index.  
3. Parcourez les formes pour trouver l'espace réservé.  
4. Convertissez la forme d'espace réservé en [`AutoShape`](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape) et modifiez le texte à l'aide du [`TextFrame`](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame) associé à l'[`AutoShape`](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape).  
5. Enregistrez la présentation modifiée.

Ce code PHP montre comment modifier le texte dans un espace réservé :
```php
  # Instancie une classe Presentation
  $pres = new Presentation("ReplacingText.pptx");
  try {
    # Accède à la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Parcourt les formes pour trouver l'espace réservé
    foreach($sld->getShapes() as $shp) {
      if (!java_is_null($shp->getPlaceholder())) {
        # Modifie le texte de chaque espace réservé
        $shp->getTextFrame()->setText("This is Placeholder");
      }
    }
    # Enregistre la présentation sur le disque
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Définir le texte d'invite dans un espace réservé**
Les mises en page standard et pré‑construites contiennent des textes d'invite d'espace réservé tels que ***Cliquez pour ajouter un titre*** ou ***Cliquez pour ajouter un sous-titre***. En utilisant Aspose.Slides, vous pouvez insérer vos textes d'invite préférés dans les mises en page d'espace réservé.

Ce code PHP vous montre comment définir le texte d'invite dans un espace réservé :
```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # Parcourt la diapositive
    foreach($slide->getSlide()->getShapes() as $shape) {
      if (java_instanceof($shape->getPlaceholder()) != null && $shape, new JavaClass("com.aspose.slides.AutoShape")) {
        $text = "";
        # PowerPoint affiche "Cliquez pour ajouter un titre"
        if ($shape->getPlaceholder()->getType() == PlaceholderType::CenteredTitle) {
          $text = "Add Title";
        } else // Ajoute le sous-titre
        if ($shape->getPlaceholder()->getType() == PlaceholderType::Subtitle) {
          $text = "Add Subtitle";
        }
        $shape->getTextFrame()->setText($text);
        echo("Placeholder with text: " . $text);
      }
    }
    $pres->save("Placeholders_PromptText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Définir la transparence de l'image d'espace réservé**
Aspose.Slides vous permet de définir la transparence de l'image d'arrière-plan dans un espace réservé de texte. En ajustant la transparence de l'image dans un tel cadre, vous pouvez faire ressortir le texte ou l'image (selon les couleurs du texte et de l'image).

Ce code PHP montre comment définir la transparence d'un arrière‑plan d'image (à l'intérieur d'une forme) :
```php
  $presentation = new Presentation("example.pptx");
  $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $operationCollection = $shape->getFillFormat()->getPictureFillFormat()->getPicture()->getImageTransform();
  for($i = 0; $i < java_values($operationCollection->size()) ; $i++) {
    if (java_instanceof($operationCollection->get_Item($i)), new JavaClass("com.aspose.slides.AlphaModulateFixed")) {
      $alphaModulate = $operationCollection->get_Item($i);
      $currentValue = 100 - $alphaModulate->getAmount();
      echo("Current transparency value: " . $currentValue);
      $alphaValue = 40;
      $alphaModulate->setAmount(100 - $alphaValue);
    }
  }
  $presentation->save("example_out.pptx", SaveFormat::Pptx);
```


## **FAQ**

**Qu'est‑ce qu'un espace réservé de base, et en quoi diffère‑t‑il d'une forme locale sur une diapositive ?**  
Un espace réservé de base est la forme originale sur une mise en page ou un masque dont la forme de la diapositive hérite — le type, la position et certains formats en proviennent. Une forme locale est indépendante ; s'il n'existe pas d'espace réservé de base, l'héritage ne s'applique pas.

**Comment mettre à jour tous les titres ou légendes dans une présentation sans parcourir chaque diapositive ?**  
Modifiez l'espace réservé correspondant sur la mise en page ou le masque. Les diapositives basées sur ces mises en page/ce masque hériteront automatiquement du changement.

**Comment contrôler les espaces réservés d'en‑tête/pied de page standard — date et heure, numéro de diapositive et texte du pied de page ?**  
Utilisez les gestionnaires HeaderFooter au niveau approprié (diapositives normales, mises en page, masque, notes/feuilles de distribution) pour activer ou désactiver ces espaces réservés et définir leur contenu.