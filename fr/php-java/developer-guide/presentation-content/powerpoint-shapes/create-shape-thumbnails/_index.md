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
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Générez des miniatures de forme de haute qualité à partir des diapositives PowerPoint avec Aspose.Slides pour PHP via Java – créez et exportez facilement des miniatures de présentation."
---

## **Vue d'ensemble**
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java peut être utilisé pour créer des fichiers de présentation dans lesquels chaque page correspond à une diapositive. Les diapositives peuvent être visualisées en ouvrant les fichiers de présentation avec Microsoft PowerPoint. Cependant, les développeurs ont parfois besoin de voir les images des formes séparément dans un visualiseur d'images. Dans ces cas, Aspose.Slides for PHP via Java les aide à générer des images miniatures des formes de diapositives.

{{% /alert %}} 

Dans cet article, nous montrerons comment générer des miniatures de diapositives dans différentes situations :

- Génération d’une vignette de forme à l’intérieur d’une diapositive.
- Génération d’une vignette de forme pour une forme de diapositive avec des dimensions définies par l’utilisateur.
- Génération d’une vignette de forme dans les limites de l’apparence d’une forme.

## **Générer une vignette de forme à partir d’une diapositive**
Pour générer une vignette de forme à partir de n’importe quelle diapositive en utilisant Aspose.Slides for PHP via Java, procédez comme suit :

1. Créez une instance de la [Présentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) classe.
1. Obtenez la référence de n’importe quelle diapositive en utilisant son ID ou son index.
1. [Obtenez l’image miniature de la forme](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) de la diapositive référencée à l’échelle par défaut.
1. Enregistrez l’image miniature dans le format d’image de votre choix.

Ce code d’exemple vous montre comment générer une vignette de forme à partir d’une diapositive :
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


## **Générer une vignette avec facteur d’échelle défini par l’utilisateur**
Pour générer la vignette de forme d’une diapositive en utilisant Aspose.Slides for PHP via Java, procédez comme suit :

1. Créez une instance de la [Présentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) classe.
1. Obtenez la référence de n’importe quelle diapositive en utilisant son ID ou son index.
1. [Obtenez l’image miniature de la forme](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) de la diapositive référencée avec des dimensions définies par l’utilisateur.
1. Enregistrez l’image miniature dans le format d’image de votre choix.

Ce code d’exemple vous montre comment générer une vignette de forme basée sur un facteur d’échelle défini :
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


## **Créer une vignette d’apparence de forme basée sur les limites**
Cette méthode de création de vignettes de formes permet aux développeurs de générer une vignette dans les limites de l’apparence de la forme. Elle prend en compte tous les effets de forme. La vignette de forme générée est limitée par les limites de la diapositive. Pour générer une vignette d’une forme de diapositive dans les limites de son apparence, procédez comme suit :

1. Créez une instance de la [Présentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) classe.
1. Obtenez la référence de n’importe quelle diapositive en utilisant son ID ou son index.
1. Obtenez l’image miniature de la diapositive référencée avec les limites de la forme comme apparence.
1. Enregistrez l’image miniature dans le format d’image de votre choix.

Ce code d’exemple est basé sur les étapes ci‑above :
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


## **FAQ**

**Quels formats d’image peuvent être utilisés lors de l’enregistrement de vignettes de forme ?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/php-java/aspose.slides/imageformat/), et autres. Les formes peuvent également être [exportées en SVG vectoriel](https://reference.aspose.com/slides/php-java/aspose.slides/shape/writeassvg/) en enregistrant le contenu de la forme au format SVG.

**Quelle est la différence entre les limites « Shape » et « Appearance » lors du rendu d’une vignette ?**

`Shape` utilise la géométrie de la forme ; `Appearance` prend en compte les [effets visuels](/slides/fr/php-java/shape-effect/) (ombres, lueurs, etc.).

**Que se passe‑t‑il si une forme est marquée comme masquée ? Sera‑t‑elle toujours rendue en vignette ?**

Une forme masquée reste partie du modèle et peut être rendue ; le drapeau masqué affecte l’affichage du diaporama mais n’empêche pas la génération de l’image de la forme.

**Les formes groupées, graphiques, SmartArt et autres objets complexes sont‑ils pris en charge ?**

Oui. Tout objet représenté comme [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) (y compris [GroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/) et [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/)) peut être enregistré comme vignette ou comme SVG.

**Les polices installées sur le système influencent‑elles la qualité des vignettes pour les formes texte ?**

Oui. Vous devez [fournir les polices requises](/slides/fr/php-java/custom-font/) (ou [configurer les substitutions de polices](/slides/fr/php-java/font-substitution/)) pour éviter les substitutions inattendues et le re‑flux du texte.