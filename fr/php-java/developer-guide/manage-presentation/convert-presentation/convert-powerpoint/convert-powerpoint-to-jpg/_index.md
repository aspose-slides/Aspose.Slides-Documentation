---
title: Convertir PowerPoint en JPG
type: docs
weight: 60
url: /php-java/convert-powerpoint-to-jpg/
keywords: "Convertir PowerPoint en JPG, PPTX en JPEG, PPT en JPEG"
description: "Convertir PowerPoint en JPG : PPT en JPG, PPTX en JPG"
---


## **À propos de la conversion PowerPoint en JPG**
Avec [**Aspose.Slides API**](https://products.aspose.com/slides/php-java/), vous pouvez convertir une présentation PowerPoint PPT ou PPTX en image JPG. Il est également possible de convertir PPT/PPTX en JPEG, PNG ou SVG. Avec ces fonctionnalités, il est facile d'implémenter votre propre visualiseur de présentations, de créer la vignette pour chaque diapositive. Cela peut être utile si vous souhaitez protéger les diapositives de présentation contre le plagiat, démontrer une présentation en mode lecture seule. Aspose.Slides permet de convertir l'ensemble de la présentation ou une certaine diapositive en formats d'image. 

{{% alert color="primary" %}} 

Pour voir comment Aspose.Slides convertit PowerPoint en images JPG, vous voudrez peut-être essayer ces convertisseurs en ligne gratuits : PowerPoint [PPTX en JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) et [PPT en JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 

{{% /alert %}} 

[![todo:image_alt_text](ppt-to-jpg.png)

## **Convertir PowerPoint PPT/PPTX en JPG**
Voici les étapes pour convertir PPT/PPTX en JPG :

1. Créez une instance de type [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtenez l'objet diapositive de type [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide) à partir de la collection [Presentation.getSlides()](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--).
3. Créez la vignette de chaque diapositive, puis convertissez-la en JPG. La méthode [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-float-float-) est utilisée pour obtenir une vignette d'une diapositive, elle renvoie un objet [Images](https://reference.aspose.com/slides/php-java/aspose.slides/Images) en résultat. La méthode [getImage](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-float-float-) doit être appelée à partir de la diapositive nécessaire de type [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide), les échelles de la vignette résultante sont passées dans la méthode.
4. Après avoir obtenu la vignette de la diapositive, appelez la méthode [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/php-java/aspose.slides/IImage#save(String formatName, int imageFormat)) à partir de l'objet vignette. Passez le nom de fichier résultant et le format d'image dans celle-ci. 

{{% alert color="primary" %}}

**Remarque** : La conversion PPT/PPTX en JPG diffère de la conversion en d'autres types dans l'API Aspose.Slides. Pour d'autres types, vous utilisez généralement la méthode [**IPresentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-), mais ici vous devez utiliser la méthode [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/php-java/aspose.slides/IImage#save(String formatName, int imageFormat)).

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
Pour changer la dimension de la vignette résultante et de l'image JPG, vous pouvez définir les valeurs *ScaleX* et *ScaleY* en les passant dans les méthodes [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-float-float-) :

```php
  $pres = new Presentation("PowerPoint-Presentation.pptx");
  try {
    # Définit les dimensions
    $desiredX = 1200;
    $desiredY = 800;
    # Obtient les valeurs scalées de X et Y
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

## **Rendre les commentaires lors de l'enregistrement de la présentation en image**
Aspose.Slides pour PHP via Java fournit une fonctionnalité qui vous permet de rendre les commentaires dans les diapositives d'une présentation lorsque vous les convertissez en images. Ce code PHP démontre l'opération :

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

{{% alert title="Astuce" color="primary" %}}

Aspose propose une [application web Collage GRATUITE](https://products.aspose.app/slides/collage). En utilisant ce service en ligne, vous pouvez fusionner des images [JPG en JPG](https://products.aspose.app/slides/collage/jpg) ou PNG en PNG, créer des [grilles de photos](https://products.aspose.app/slides/collage/photo-grid), et ainsi de suite. 

En utilisant les mêmes principes décrits dans cet article, vous pouvez convertir des images d'un format à un autre. Pour plus d'informations, consultez ces pages : convertir [image en JPG](https://products.aspose.com/slides/php-java/conversion/image-to-jpg/) ; convertir [JPG en image](https://products.aspose.com/slides/php-java/conversion/jpg-to-image/) ; convertir [JPG en PNG](https://products.aspose.com/slides/php-java/conversion/jpg-to-png/), convertir [PNG en JPG](https://products.aspose.com/slides/php-java/conversion/png-to-jpg/) ; convertir [PNG en SVG](https://products.aspose.com/slides/php-java/conversion/png-to-svg/), convertir [SVG en PNG](https://products.aspose.com/slides/php-java/conversion/svg-to-png/).

{{% /alert %}}

## **Voir aussi**

Voir d'autres options pour convertir PPT/PPTX en image comme :

- [Conversion PPT/PPTX en SVG](/slides/php-java/render-a-slide-as-an-svg-image/).