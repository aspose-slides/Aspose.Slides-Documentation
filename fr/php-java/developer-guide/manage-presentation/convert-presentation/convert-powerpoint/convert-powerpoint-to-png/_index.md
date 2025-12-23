---
title: Convertir les diapositives PowerPoint en PNG en PHP
linktitle: PowerPoint en PNG
type: docs
weight: 30
url: /fr/php-java/convert-powerpoint-to-png/
keywords:
- convertir PowerPoint
- convertir la présentation
- convertir la diapositive
- convertir PPT
- convertir PPTX
- PowerPoint vers PNG
- présentation en PNG
- diapositive en PNG
- PPT en PNG
- PPTX en PNG
- enregistrer PPT en PNG
- enregistrer PPTX en PNG
- exporter PPT en PNG
- exporter PPTX en PNG
- PHP
- Aspose.Slides
description: "Convertissez les présentations PowerPoint en images PNG de haute qualité rapidement avec Aspose.Slides pour PHP via Java, garantissant des résultats précis et automatisés."
---

## **À propos de la conversion PowerPoint en PNG**

Le format PNG (Portable Network Graphics) n'est pas aussi populaire que le JPEG (Joint Photographic Experts Group), mais il reste très populaire.  

**Cas d'utilisation :** Lorsque vous avez une image complexe et que la taille n'est pas un problème, le PNG est un meilleur format d'image que le JPEG.  

{{% alert title="Astuce" color="primary" %}} Vous voudrez peut‑être consulter les convertisseurs PowerPoint en PNG gratuits d'Aspose :**PowerPoint to PNG Converters** : [PPTX to PNG](https://products.aspose.app/slides/conversion/pptx-to-png) et [PPT to PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Ils sont une implémentation en direct du processus décrit sur cette page. {{% /alert %}}

## **Convertir PowerPoint en PNG**

Suivez ces étapes :

1. Instanciez la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtenez l'objet diapositive depuis la collection [Presentation.getSlides()](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) sous l'interface [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide).
3. Utilisez la méthode [ISlide.getImage()](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide) pour obtenir la miniature de chaque diapositive.
4. Utilisez la méthode [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/php-java/aspose.slides/IImage#save(String formatName, int imageFormat)) pour enregistrer la miniature de la diapositive au format PNG.

Ce code PHP montre comment convertir une présentation PowerPoint en PNG :
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


## **Convertir PowerPoint en PNG avec dimensions personnalisées**

Si vous souhaitez obtenir des fichiers PNG à une certaine échelle, vous pouvez définir les valeurs de `desiredX` et `desiredY`, qui déterminent les dimensions de la miniature résultante.  

Ce code montre l'opération décrite :
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


## **Convertir PowerPoint en PNG avec taille personnalisée**

Si vous souhaitez obtenir des fichiers PNG à une certaine taille, vous pouvez fournir vos arguments préférés `width` et `height` pour `ImageSize`.  

Ce code montre comment convertir un PowerPoint en PNG tout en spécifiant la taille des images :
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


## **FAQ**

**Comment puis‑je exporter uniquement une forme spécifique (par exemple, un graphique ou une image) plutôt que la diapositive entière ?**  
Aspose.Slides prend en charge [la génération de miniatures pour des formes individuelles](/slides/fr/php-java/create-shape-thumbnails/) ; vous pouvez rendre une forme en image PNG.  

**La conversion parallèle est‑elle prise en charge sur un serveur ?**  
Oui, mais [ne partagez pas](/slides/fr/php-java/multithreading/) une même instance de présentation entre différents threads. Utilisez une instance distincte par thread ou processus.  

**Quelles sont les limitations de la version d'évaluation lors de l'exportation en PNG ?**  
Le mode d'évaluation ajoute un filigrane aux images de sortie et impose [d'autres restrictions](/slides/fr/php-java/licensing/) jusqu'à ce qu'une licence soit appliquée.