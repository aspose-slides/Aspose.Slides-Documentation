---
title: Convertir PPT et PPTX en JPG en PHP
linktitle: PowerPoint en JPG
type: docs
weight: 60
url: /fr/php-java/convert-powerpoint-to-jpg/
keywords:
- convertir PowerPoint
- convertir présentation
- convertir diapositive
- convertir PPT
- convertir PPTX
- PowerPoint en JPG
- présentation en JPG
- diapositive en JPG
- PPT en JPG
- PPTX en JPG
- enregistrer PowerPoint en JPG
- enregistrer présentation en JPG
- enregistrer diapositive en JPG
- enregistrer PPT en JPG
- enregistrer PPTX en JPG
- exporter PPT en JPG
- exporter PPTX en JPG
- PHP
- Aspose.Slides
description: "Convertir les diapositives PowerPoint (PPT, PPTX) en images JPG de haute qualité en PHP avec Aspose.Slides pour PHP en utilisant des exemples de code rapides et fiables."
---

## **À propos de la conversion PowerPoint en JPG**
Avec [**Aspose.Slides API**](https://products.aspose.com/slides/php-java/) vous pouvez convertir une présentation PowerPoint PPT ou PPTX en image JPG. Il est également possible de convertir PPT/PPTX en JPEG, PNG ou SVG. Avec ces fonctionnalités, il est facile de mettre en œuvre votre propre visualiseur de présentations, de créer la vignette de chaque diapositive. Cela peut être utile si vous souhaitez protéger les diapositives de la copie, ou présenter la présentation en mode lecture seule. Aspose.Slides permet de convertir l’ensemble de la présentation ou une diapositive particulière en formats d’image.  

{{% alert color="primary" %}} 
Pour voir comment Aspose.Slides convertit PowerPoint en images JPG, vous pouvez essayer ces convertisseurs en ligne gratuits : PowerPoint [PPTX to JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) et [PPT to JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 
{{% /alert %}} 

[![todo:image_alt_text](ppt-to-jpg.png)

## **Convertir PowerPoint PPT/PPTX en JPG**
Voici les étapes pour convertir PPT/PPTX en JPG :

1. Créez une instance du type [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtenez l’objet diapositive du type [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) à partir de la collection [Presentation::getSlides()](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) .
3. Créez la vignette de chaque diapositive puis convertissez‑la en JPG. La méthode [**Slide::getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) est utilisée pour obtenir une vignette d’une diapositive. La méthode [getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) doit être appelée depuis la diapositive souhaitée du type [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/), les facteurs d’échelle de la vignette résultante étant transmis à la méthode.
4. Après avoir obtenu la vignette de la diapositive, appelez la méthode [**IImage::save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/php-java/aspose.slides/IImage#save(String formatName, int imageFormat)) depuis l’objet vignette. Transférez le nom de fichier résultant et le format d’image dans cet appel.  

{{% alert color="primary" %}}

**Remarque** : la conversion PPT/PPTX en JPG diffère de la conversion vers d’autres types dans l’API Aspose.Slides. Pour d’autres types, vous utilisez généralement la méthode [**Presentation::Save(String fname, int format, SaveOptions options)**](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/), mais ici vous devez utiliser la méthode [**IImage::save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/php-java/aspose.slides/IImage#save(String formatName, int imageFormat)).  

{{% /alert %}} 
```php
  $pres = new Presentation("PowerPoint-Presentation.pptx");
  try {
    foreach($pres->getSlides() as $sld) {
      # Crée une image à pleine échelle
      $slideImage = $sld->getImage(1.0, 1.0);
      # Enregistre l'image sur le disque au format JPEG
      try {
        $slideImage->save(String->format("Slide_%d.jpg", $sld->getSlideNumber()), ImageFormat::Jpeg);
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


## **Convertir PowerPoint PPT/PPTX en JPG avec des dimensions personnalisées**
Pour modifier les dimensions de la vignette et de l’image JPG résultantes, vous pouvez définir les valeurs *ScaleX* et *ScaleY* en les transmettant aux méthodes [**Slide::getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) :
```php
  $pres = new Presentation("PowerPoint-Presentation.pptx");
  try {
    # Définit les dimensions
    $desiredX = 1200;
    $desiredY = 800;
    # Obtient les valeurs mises à l'échelle de X et Y
    $ScaleX = 1.0 / $pres->getSlideSize()->getSize()->getWidth() * $desiredX;
    $ScaleY = 1.0 / $pres->getSlideSize()->getSize()->getHeight() * $desiredY;
    foreach($pres->getSlides() as $sld) {
      # Crée une image à pleine échelle
      $slideImage = $sld->getImage($ScaleX, $ScaleY);
      # Enregistre l'image sur le disque au format JPEG
      try {
        $slideImage->save(String->format("Slide_%d.jpg", $sld->getSlideNumber()), ImageFormat::Jpeg);
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


## **Rendu des commentaires lors de l’enregistrement des diapositives en images**
Aspose.Slides for PHP via Java fournit une fonctionnalité qui vous permet de rendre les commentaires des diapositives d’une présentation lors de la conversion de ces diapositives en images. Ce code PHP illustre le fonctionnement :
```php
  $pres = new Presentation("presentation.pptx");
  try {
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomTruncated);
    $opts = new RenderingOptions();
    $opts->setSlidesLayoutOptions($notesOptions);
    foreach($pres->getSlides() as $sld) {
      $slideImage = $sld->getImage($opts, new Java("java.awt.Dimension", 740, 960));
      try {
        $slideImage->save(String->format("Slide_%d.png", $sld->getSlideNumber()));
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


{{% alert title="Tip" color="primary" %}}

Aspose propose une [application web GRATUITE Collage](https://products.aspose.app/slides/collage). En utilisant ce service en ligne, vous pouvez fusionner des images [JPG to JPG](https://products.aspose.app/slides/collage/jpg) ou PNG to PNG, créer des [grilles de photos](https://products.aspose.app/slides/collage/photo-grid), etc.  

En suivant les mêmes principes décrits dans cet article, vous pouvez convertir des images d’un format à un autre. Pour plus d’informations, consultez ces pages : conversion [image to JPG](https://products.aspose.com/slides/php-java/conversion/image-to-jpg/) ; conversion [JPG to image](https://products.aspose.com/slides/php-java/conversion/jpg-to-image/) ; conversion [JPG to PNG](https://products.aspose.com/slides/php-java/conversion/jpg-to-png/) ; conversion [PNG to JPG](https://products.aspose.com/slides/php-java/conversion/png-to-jpg/) ; conversion [PNG to SVG](https://products.aspose.com/slides/php-java/conversion/png-to-svg/) ; conversion [SVG to PNG](https://products.aspose.com/slides/php-java/conversion/svg-to-png/).  

{{% /alert %}}

## **FAQ**

**Cette méthode prend‑elle en charge la conversion par lot ?**  

Oui, Aspose.Slides permet la conversion par lot de plusieurs diapositives en JPG en une seule opération.  

**La conversion prend‑elle en charge SmartArt, les graphiques et d’autres objets complexes ?**  

Oui, Aspose.Slides rend tout le contenu, y compris SmartArt, graphiques, tableaux, formes, etc. Toutefois, la précision du rendu peut varier légèrement par rapport à PowerPoint, notamment lorsqu’il s’agit de polices personnalisées ou manquantes.  

**Existe‑t‑il des limites au nombre de diapositives pouvant être traitées ?**  

Aspose.Slides n’impose pas de limites strictes au nombre de diapositives que vous pouvez traiter. Cependant, vous pourriez rencontrer des erreurs de mémoire insuffisante avec de très grandes présentations ou des images en haute résolution.  

## **Voir aussi**

Voir d’autres options pour convertir PPT/PPTX en image comme :

- [Conversion PPT/PPTX en SVG](/slides/fr/php-java/render-a-slide-as-an-svg-image/).