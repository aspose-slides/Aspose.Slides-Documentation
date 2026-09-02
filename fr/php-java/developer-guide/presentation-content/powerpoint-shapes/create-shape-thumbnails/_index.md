---
title: Créer des miniatures de formes de présentation en PHP
linktitle: Miniatures de forme
type: docs
weight: 70
url: /fr/php-java/create-shape-thumbnails/
keywords:
- miniature de forme
- image de forme
- rendu de forme
- rendu de forme
- limites visuelles
- limites de forme
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Générez des miniatures de forme haute qualité à partir des diapositives PowerPoint avec Aspose.Slides pour PHP via Java – créez et exportez facilement des miniatures de présentation."
---
## **Introduction**

Aspose.Slides est utilisé pour créer des fichiers de présentation où chaque page est une diapositive. Ces diapositives peuvent être visualisées en ouvrant les fichiers de présentation avec Microsoft PowerPoint. Mais parfois, les développeurs peuvent avoir besoin de visualiser les images des formes séparément dans un visualiseur d'images. Dans de tels cas, Aspose.Slides vous aide à générer des images miniatures des formes de la diapositive. La façon d'utiliser cette fonctionnalité est décrite dans cet article.
Cet article explique comment générer des miniatures de diapositives de différentes manières :

- Génération d'une miniature de forme à l'intérieur d'une diapositive.
- Génération d'une miniature de forme pour une forme de diapositive avec des dimensions définies par l'utilisateur.
- Génération d'une miniature de forme dans les limites de l'apparence d'une forme.

## **Générer une miniature de forme à partir d'une diapositive**

Pour générer une miniature de forme à partir de n'importe quelle diapositive en utilisant Aspose.Slides pour PHP via Java, procédez ainsi :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation).
1. Obtenez la référence de n'importe quelle diapositive en utilisant son ID ou son index.
1. [Obtenez l'image miniature de la forme](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shape/#getImage) de la diapositive référencée à l'échelle par défaut.
1. Enregistrez l'image miniature dans le format d'image de votre choix.

Ce code d'exemple vous montre comment générer une miniature de forme à partir d'une diapositive :

```php
  # Instancier une classe Presentation qui représente le fichier de présentation
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Créer une image à pleine échelle
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
    # Enregistrer l'image sur le disque au format PNG
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Générer une miniature avec facteur d'échelle défini par l'utilisateur**

Pour générer la miniature de forme d'une diapositive en utilisant Aspose.Slides pour PHP via Java, procédez ainsi :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation).
1. Obtenez la référence de n'importe quelle diapositive en utilisant son ID ou son index.
1. [Obtenez l'image miniature de la forme](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shape/#getImage) de la diapositive référencée avec des dimensions définies par l'utilisateur.
1. Enregistrez l'image miniature dans le format d'image de votre choix.

Ce code d'exemple vous montre comment générer une miniature de forme basée sur un facteur d'échelle défini :

```php
  # Instancier une classe Presentation qui représente le fichier de présentation
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Créer une image à pleine échelle
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Shape, 1, 1);
    # Enregistrer l'image sur le disque au format PNG
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Créer une miniature d'apparence de forme basée sur les limites**

Cette méthode de création de miniatures de formes permet aux développeurs de générer une miniature dans les limites de l'apparence de la forme. Elle prend en compte tous les effets de forme. La miniature de forme générée est limitée par les limites de la diapositive. Pour générer une miniature d'une forme de diapositive dans les limites de son apparition, procédez ainsi :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation).
1. Obtenez la référence de n'importe quelle diapositive en utilisant son ID ou son index.
1. Obtenez l'image miniature de la diapositive référencée avec les limites de forme en tant qu'apparence.
1. Enregistrez l'image miniature dans le format d'image de votre choix.

Ce code d'exemple est basé sur les étapes ci‑above :

```php
  # Instancier une classe Presentation qui représente le fichier de présentation
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Créer une image à pleine échelle
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Appearance, 1, 1);
    # Enregistrer l'image sur le disque au format PNG
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Obtenir les limites visuelles réelles d'une forme**

Les propriétés de cadre de [Shape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shape/) —`Shape::getX()`, `Shape::getY()`, `Shape::getWidth()` et `Shape::getHeight()`—décrivent le rectangle stocké dans le modèle de la présentation. Le contenu réellement rendu peut s'étendre au‑delà de ce cadre ou occuper un rectangle aligné différemment. La rotation, les contours, les pointes de flèche, la mise en page et le débordement du texte, la géométrie SmartArt générée et d'autres effets de rendu peuvent tous modifier la zone occupée.

Utilisez [Shape::getVisualBounds](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shape/#getVisualBounds) pour calculer cette zone occupée sans créer d'image. La méthode renvoie un [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) en coordonnées de diapositive. Le rectangle renvoyé n'est pas découpé à la diapositive, de sorte que ses coordonnées peuvent être négatives lorsque le contenu dépasse l'origine de la diapositive.

L'exemple suivant obtient et compare le cadre et les limites visuelles :

```php
  $presentation = new Presentation("example.pptx");
  try {
      $slide = $presentation->getSlides()->get_Item(0);
      $shape = $slide->getShapes()->get_Item(0);

      $visualBounds = $shape->getVisualBounds();

      $frameX = $shape->getX();
      $frameY = $shape->getY();
      $frameWidth = $shape->getWidth();
      $frameHeight = $shape->getHeight();

      $visualX = $visualBounds->getX();
      $visualY = $visualBounds->getY();
      $visualWidth = $visualBounds->getWidth();
      $visualHeight = $visualBounds->getHeight();

      echo "Frame bounds (x, y, width, height): $frameX, $frameY, $frameWidth, $frameHeight\n";
      echo "Visual bounds (x, y, width, height): $visualX, $visualY, $visualWidth, $visualHeight\n";
  } finally {
      $presentation->dispose();
  }
```

Le même [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) peut être utilisé pour aligner les formes voisines à son bord gauche, droit, supérieur ou inférieur ; réserver suffisamment d'espace dans une disposition générée ; ou détecter du contenu en dehors d'une région autorisée. Les limites visuelles sont particulièrement utiles pour SmartArt, les zones de texte, les flèches, les images, les formes pivotées et les formes groupées, où le cadre stocké peut ne pas représenter le rendu complet.

Utilisez [Shape::getVisualBounds](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shape/#getVisualBounds) lorsque vous avez besoin de coordonnées pour la mise en page ou la validation et que vous n'avez pas besoin d'un bitmap. Utilisez [Shape::getImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shape/#getImage) lorsque vous devez rendre la forme. Avec [ShapeThumbnailBounds](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shapethumbnailbounds/), `ShapeThumbnailBounds::Shape` dimensionne l'image à partir des limites de la forme, y compris les réglages de contour, tandis que `ShapeThumbnailBounds::Appearance` la dimensionne à partir de l'apparence de la forme et restreint le résultat aux limites de la diapositive. En revanche, `Shape::getVisualBounds` ne renvoie que le rectangle calculé et ne le découpe pas à la diapositive.

## **FAQ**

**Quels formats d'image peuvent être utilisés lors de l'enregistrement des miniatures de forme ?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/fr/php-java/aspose.slides/imageformat/), et d'autres. Les formes peuvent également être [exportées en tant que SVG vectoriel](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shape/writeassvg/) en enregistrant le contenu de la forme au format SVG.

**Quelle est la différence entre les limites Shape et Appearance lors du rendu d'une miniature ?**

`Shape` utilise la géométrie de la forme ; `Appearance` prend en compte les [effets visuels](/slides/fr/php-java/shape-effect/) (ombres, lueurs, etc.).

**Que se passe-t-il si une forme est marquée comme cachée ? Sera-t-elle toujours rendue en miniature ?**

Une forme cachée reste partie du modèle et peut être rendue ; le drapeau caché affecte l'affichage du diaporama mais n'empêche pas la génération de l'image de la forme.

**Les formes groupées, les graphiques, SmartArt et autres objets complexes sont-ils pris en charge ?**

Oui. Tout objet représenté comme [Shape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shape/) (y compris [GroupShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chart/) et [SmartArt](https://reference.aspose.com/slides/fr/php-java/aspose.slides/smartart/)) peut être enregistré en tant que miniature ou en tant que SVG.

**Les polices installées sur le système affectent-elles la qualité des miniatures des formes de texte ?**

Oui. Vous devez [fournir les polices requises](/slides/fr/php-java/custom-font/) (ou [configurer les substitutions de polices](/slides/fr/php-java/font-substitution/)) pour éviter les substitutions inattendues et le réarrangement du texte.