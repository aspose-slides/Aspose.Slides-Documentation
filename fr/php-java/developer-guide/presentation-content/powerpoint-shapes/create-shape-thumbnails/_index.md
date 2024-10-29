---
title: Créer des Miniatures de Formes
type: docs
weight: 70
url: /fr/php-java/create-shape-thumbnails/
---

## **Aperçu**
{{% alert color="primary" %}} 

Aspose.Slides pour PHP via Java peut être utilisé pour créer des fichiers de présentation dans lesquels chaque page correspond à une diapositive. Les diapositives peuvent être visualisées en ouvrant les fichiers de présentation avec Microsoft PowerPoint. Cependant, les développeurs ont parfois besoin de visualiser les images des formes séparément dans un visualiseur d'images. Dans de tels cas, Aspose.Slides pour PHP via Java les aide à générer des images miniatures des formes de la diapositive.

{{% /alert %}} 

Dans ce sujet, nous allons montrer comment générer des miniatures de diapositives dans différentes situations :

- Génération d'une miniature de forme à l'intérieur d'une diapositive.
- Génération d'une miniature de forme pour une forme de diapositive avec des dimensions définies par l'utilisateur.
- Génération d'une miniature de forme dans les limites de l'apparence d'une forme.

## **Génération de Miniatures de Formes à partir de Diapositives**
Pour générer une miniature de forme à partir de n'importe quelle diapositive en utilisant Aspose.Slides pour PHP via Java, faites ceci :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Obtenez la référence de n'importe quelle diapositive en utilisant son ID ou son index.
1. [Obtenez l'image miniature de la forme](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getImage--) de la diapositive référencée à l'échelle par défaut.
1. Enregistrez l'image miniature dans le format d'image de votre choix.

Ce code d'exemple vous montre comment générer une miniature de forme à partir d'une diapositive :

```php
  # Instanciez une classe Presentation qui représente le fichier de présentation
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Créez une image à l'échelle complète
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
    # Enregistrez l'image sur le disque au format PNG
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

## **Génération de Miniatures de Formes avec un Facteur d'Échelle Défini par l'Utilisateur**
Pour générer la miniature de forme d'une diapositive en utilisant Aspose.Slides pour PHP via Java, faites ceci :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Obtenez la référence de n'importe quelle diapositive en utilisant son ID ou son index.
1. [Obtenez l'image miniature de la forme](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getImage-int-float-float-) de la diapositive référencée avec des dimensions définies par l'utilisateur.
1. Enregistrez l'image miniature dans le format d'image de votre choix.

Ce code d'exemple vous montre comment générer une miniature de forme en fonction d'un facteur d'échelle défini :

```php
  # Instanciez une classe Presentation qui représente le fichier de présentation
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Créez une image à l'échelle complète
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Shape, 1, 1);
    # Enregistrez l'image sur le disque au format PNG
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

## **Génération de la Miniature de la Forme des Limites**
Cette méthode de création de miniatures de formes permet aux développeurs de générer une miniature dans les limites de l'apparence de la forme. Elle prend en compte tous les effets de forme. La miniature de forme générée est limitée par les limites de la diapositive. Pour générer une miniature d'une forme de diapositive dans la limite de son apparence, faites ceci :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Obtenez la référence de n'importe quelle diapositive en utilisant son ID ou son index.
1. Obtenez l'image miniature de la diapositive référencée avec les limites de forme comme apparence.
1. Enregistrez l'image miniature dans le format d'image de votre choix.

Ce code d'exemple est basé sur les étapes ci-dessus :

```php
  # Instanciez une classe Presentation qui représente le fichier de présentation
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Créez une image à l'échelle complète
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Appearance, 1, 1);
    # Enregistrez l'image sur le disque au format PNG
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