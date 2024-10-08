---
title: Convertir PowerPoint en PNG
type: docs
weight: 30
url: /fr/php-java/convert-powerpoint-to-png/
keywords: PowerPoint en PNG, PPT en PNG, PPTX en PNG, java, Aspose.Slides pour PHP via Java
description: Convertir une présentation PowerPoint en PNG
---

## **À propos de la conversion de PowerPoint en PNG**

Le format PNG (Portable Network Graphics) n'est pas aussi populaire que le JPEG (Joint Photographic Experts Group), mais il reste très prisé.

**Cas d'utilisation :** Lorsque vous avez une image complexe et que la taille n'est pas un problème, le PNG est un meilleur format d'image que le JPEG.

{{% alert title="Astuce" color="primary" %}} Vous voudrez peut-être consulter les **Convertisseurs PowerPoint en PNG** gratuits d'Aspose : [PPTX en PNG](https://products.aspose.app/slides/conversion/pptx-to-png) et [PPT en PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Ce sont une implementation en direct du processus décrit sur cette page. {{% /alert %}}

## **Convertir PowerPoint en PNG**

Suivez ces étapes :

1. Instanciez la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtenez l'objet diapositive de la collection [Presentation.getSlides()](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) sous l'interface [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide).
3. Utilisez la méthode [ISlide.getImage()](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide) pour obtenir la miniature pour chaque diapositive.
4. Utilisez la méthode  [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/php-java/aspose.slides/IImage#save(String formatName, int imageFormat)) pour enregistrer la miniature de la diapositive au format PNG.

Ce code PHP vous montre comment convertir une présentation PowerPoint en PNG :

```php
  $pres = new Presentation("pres.pptx");
  try {
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $slideImage = $slide->getImage();
      try {
        $slideImage->save("image_java_" . $index . ".png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Convertir PowerPoint en PNG avec des dimensions personnalisées**

Si vous souhaitez obtenir des fichiers PNG autour d'une certaine échelle, vous pouvez définir les valeurs pour `desiredX` et `desiredY`, qui déterminent les dimensions de la miniature résultante.

Ce code démontre l'opération décrite :

```php
  $pres = new Presentation("pres.pptx");
  try {
    $scaleX = 2.0;
    $scaleY = 2.0;
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $slideImage = $slide->getImage($scaleX, $scaleY);
      try {
        $slideImage->save("image_java_" . $index . ".png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Convertir PowerPoint en PNG avec une taille personnalisée**

Si vous souhaitez obtenir des fichiers PNG autour d'une certaine taille, vous pouvez passer vos arguments préférés `width` et `height` pour `ImageSize`.

Ce code vous montre comment convertir un PowerPoint en PNG tout en spécifiant la taille des images :

```php
  $pres = new Presentation("pres.pptx");
  try {
    $size = new Java("java.awt.Dimension", 960, 720);
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $slideImage = $slide->getImage($size);
      try {
        $slideImage->save("image_java_" . $index . ".png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```