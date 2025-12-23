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
description: "Convertissez les diapositives PowerPoint (PPT, PPTX) en images JPG de haute qualité en PHP avec Aspose.Slides pour PHP en utilisant des exemples de code rapides et fiables."
---

## **À propos de la conversion PowerPoint en JPG**
Avec [**Aspose.Slides API**](https://products.aspose.com/slides/php-java/) vous pouvez convertir une présentation PowerPoint PPT ou PPTX en image JPG. Il est également possible de convertir PPT/PPTX en JPEG, PNG ou SVG. Avec ces fonctionnalités, il est facile de mettre en œuvre votre propre visualiseur de présentations, de créer la miniature de chaque diapositive. Cela peut être utile si vous souhaitez protéger les diapositives de la présentation contre la copie, ou présenter la présentation en mode lecture seule. Aspose.Slides permet de convertir l’ensemble de la présentation ou une diapositive spécifique en formats d’image.

{{% alert color="primary" %}} 

Pour voir comment Aspose.Slides convertit PowerPoint en images JPG, vous pouvez essayer ces convertisseurs en ligne gratuits : PowerPoint [PPTX en JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) et [PPT en JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 

{{% /alert %}} 

[![todo:image_alt_text](ppt-to-jpg.png)

## **Convertir PowerPoint PPT/PPTX en JPG**
Voici les étapes pour convertir PPT/PPTX en JPG :

1. Créez une instance du type [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtenez l’objet diapositive de type [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide) à partir de la collection [Presentation.getSlides()](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) .
3. Créez la miniature de chaque diapositive puis convertissez‑la en JPG. La méthode [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-float-float-) est utilisée pour obtenir une miniature d’une diapositive, elle renvoie un objet [Images](https://reference.aspose.com/slides/php-java/aspose.slides/Images) en résultat. La méthode [getImage](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-float-float-) doit être appelée depuis la diapositive souhaitée du type [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide), les échelles de la miniature résultante sont passées à la méthode.
4. Après avoir obtenu la miniature de la diapositive, appelez la méthode [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/php-java/aspose.slides/IImage#save(String formatName, int imageFormat)) depuis l’objet miniature. Transmettez le nom de fichier résultant et le format d’image.

{{% alert color="primary" %}}

**Note** : la conversion PPT/PPTX en JPG diffère de la conversion vers d’autres types dans l’API Aspose.Slides. Pour les autres types, vous utilisez généralement la méthode [**IPresentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-), mais ici vous devez utiliser la méthode [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/php-java/aspose.slides/IImage#save(String formatName, int imageFormat)).

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
Pour modifier les dimensions de la miniature et de l’image JPG résultantes, vous pouvez définir les valeurs *ScaleX* et *ScaleY* en les transmettant aux méthodes [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-float-float-) :
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


## **Rendre les commentaires lors de l’enregistrement des diapositives en images**
Aspose.Slides for PHP via Java offre une fonctionnalité qui vous permet de rendre les commentaires dans les diapositives d’une présentation lors de la conversion de ces diapositives en images. Ce code PHP illustre le fonctionnement :
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

Aspose propose une [application Web COLLAGE GRATUITE](https://products.aspose.app/slides/collage). En utilisant ce service en ligne, vous pouvez fusionner des images [JPG en JPG](https://products.aspose.app/slides/collage/jpg) ou PNG en PNG, créer des [grilles de photos](https://products.aspose.app/slides/collage/photo-grid), etc.

En appliquant les mêmes principes décrits dans cet article, vous pouvez convertir des images d’un format à un autre. Pour plus d’informations, consultez ces pages : convertir [image en JPG](https://products.aspose.com/slides/php-java/conversion/image-to-jpg/); convertir [JPG en image](https://products.aspose.com/slides/php-java/conversion/jpg-to-image/); convertir [JPG en PNG](https://products.aspose.com/slides/php-java/conversion/jpg-to-png/); convertir [PNG en JPG](https://products.aspose.com/slides/php-java/conversion/png-to-jpg/); convertir [PNG en SVG](https://products.aspose.com/slides/php-java/conversion/png-to-svg/); convertir [SVG en PNG](https://products.aspose.com/slides/php-java/conversion/svg-to-png/).

{{% /alert %}}

## **FAQ**

**Cette méthode prend‑elle en charge la conversion par lots ?**  
Oui, Aspose.Slides permet la conversion par lots de plusieurs diapositives en JPG en une seule opération.

**La conversion prend‑elle en charge SmartArt, les graphiques et d’autres objets complexes ?**  
Oui, Aspose.Slides rend tout le contenu, y compris SmartArt, les graphiques, les tableaux, les formes, etc. Toutefois, la précision du rendu peut varier légèrement par rapport à PowerPoint, surtout lorsqu’on utilise des polices personnalisées ou manquantes.

**Existe‑t‑il des limites au nombre de diapositives pouvant être traitées ?**  
Aspose.Slides n’impose aucune limite stricte au nombre de diapositives que vous pouvez traiter. Cependant, vous pouvez rencontrer une erreur de dépassement de mémoire lors du traitement de présentations volumineuses ou d’images haute résolution.

## **Voir aussi**

Découvrez d’autres options pour convertir PPT/PPTX en image, telles que :

- [Conversion PPT/PPTX en SVG](/slides/fr/php-java/render-a-slide-as-an-svg-image/).