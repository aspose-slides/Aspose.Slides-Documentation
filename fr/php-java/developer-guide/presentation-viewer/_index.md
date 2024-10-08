---
title: Visionneuse de Présentation
type: docs
weight: 50
url: /fr/php-java/presentation-viewer/
keywords: "Visionneuse PPT PowerPoint"
description: "Visionneuse PPT PowerPoint "
---

{{% alert color="primary" %}} 

Aspose.Slides pour PHP via Java est utilisé pour créer des fichiers de présentation, complets avec des diapositives. Ces diapositives peuvent être visualisées en ouvrant des présentations à l'aide de Microsoft PowerPoint. Mais parfois, les développeurs peuvent également avoir besoin de visualiser des diapositives sous forme d'images dans leur visionneuse d'images préférée ou de créer leur propre visionneuse de présentation. Dans de tels cas, Aspose.Slides pour PHP via Java vous permet d'exporter une diapositive individuelle vers une image. Cet article décrit comment procéder.

{{% /alert %}} 

## **Exemple en Direct**
Vous pouvez essayer l'application gratuite [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) pour voir ce que vous pouvez implémenter avec l'API Aspose.Slides :

[](https://products.aspose.app/slides/viewer/)

[![todo:image_alt_text](slides-viewer.png)](https://products.aspose.app/slides/viewer/)

## **Générer une Image SVG à partir d'une Diapositive**
Pour générer une image SVG à partir de n'importe quelle diapositive souhaitée avec Aspose.Slides pour PHP via Java, veuillez suivre les étapes ci-dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Obtenez la référence de la diapositive souhaitée en utilisant son ID ou son index.
- Obtenez l'image SVG dans un flux mémoire.
- Enregistrez le flux mémoire dans un fichier.

```php
  # Instancier une classe Presentation qui représente le fichier de présentation
  $pres = new Presentation("CreateSlidesSVGImage.pptx");
  try {
    # Accéder à la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Créer un objet flux mémoire
    $svgStream = new Java("java.io.FileOutputStream", "Aspose_out.svg");
    # Générer l'image SVG de la diapositive et l'enregistrer dans le flux mémoire
    $sld->writeAsSvg($svgStream);
    $svgStream->close();
  } catch (JavaException $e) {
  } finally {
    $pres->dispose();
  }
```

## **Générer SVG avec des IDS de Forme Personnalisés**
Aspose.Slides pour PHP via Java peut être utilisé pour générer [SVG](https://docs.fileformat.com/page-description-language/svg/) à partir d'une diapositive avec un ID de forme personnalisé. Pour cela, utilisez la propriété ID de [ISvgShape](https://reference.aspose.com/slides/php-java/aspose.slides/ISvgShape), qui représente l'ID personnalisé des formes dans le SVG généré. CustomSvgShapeFormattingController peut être utilisé pour définir l'ID de forme.

```php

  class CustomSvgShapeFormattingController {
    private $m_shapeIndex;

    function __construct() {
      $this->m_shapeIndex = 0;
    }

    function __construct($shapeStartIndex) {
      $this->m_shapeIndex = $shapeStartIndex;
    }

    function formatShape($svgShape, $shape) {
      $svgShape->setId(sprintf("shape-%d", $m_shapeIndex++));
    }
  }

  $pres = new Presentation("pptxFileName.pptx");
  try {
    $stream = new Java("java.io.FileOutputStream", "Aspose_out.svg");
    try {
      $svgOptions = new SVGOptions();
      $shapeFormattingController = java_closure(new CustomSvgShapeFormattingController(), null, java("com.aspose.slides.ISvgShapeFormattingController"));
      $svgOptions->setShapeFormattingController($shapeFormattingController);
      $pres->getSlides()->get_Item(0)->writeAsSvg($stream, $svgOptions);
    } finally {
      if (!java_is_null($stream)) {
        $stream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    $pres->dispose();
  }
```

## **Créer une Image Thumbnail de Diapositives**
Aspose.Slides pour PHP via Java vous aide à générer des images miniature des diapositives. Pour générer la miniature de n'importe quelle diapositive souhaitée à l'aide d'Aspose.Slides pour PHP via Java :

1. Créez une instance de la [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) classe.
1. Obtenez la référence de n'importe quelle diapositive souhaitée en utilisant son ID ou son index.
1. Obtenez l'image miniature de la diapositive référencée à une échelle spécifiée.
1. Enregistrez l'image miniature dans n'importe quel format d'image désiré.

```php
  # Instancier une classe Presentation qui représente le fichier de présentation
  $pres = new Presentation("ThumbnailFromSlide.pptx");
  try {
    # Accéder à la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Créer une image en pleine échelle
    $slideImage = $sld->getImage(1.0, 1.0);
    # Enregistrer l'image sur le disque au format JPEG
    try {
      $slideImage->save("Thumbnail_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    $pres->dispose();
  }
```

## **Créer un Thumbnail avec des Dimensions Définies par l'Utilisateur**

1. Créez une instance de la [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) classe.
1. Obtenez la référence de n'importe quelle diapositive souhaitée en utilisant son ID ou son index.
1. Obtenez l'image miniature de la diapositive référencée à une échelle spécifiée.
1. Enregistrez l'image miniature dans n'importe quel format d'image désiré.

```php
  # Instancier une classe Presentation qui représente le fichier de présentation
  $pres = new Presentation("ThumbnailWithUserDefinedDimensions.pptx");
  try {
    # Accéder à la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Dimension définie par l'utilisateur
    $desiredX = 1200;
    $desiredY = 800;
    # Obtenir la valeur mise à l'échelle de X et Y
    $ScaleX = 1.0 / $pres->getSlideSize()->getSize()->getWidth() * $desiredX;
    $ScaleY = 1.0 / $pres->getSlideSize()->getSize()->getHeight() * $desiredY;
    # Créer une image en pleine échelle
    $slideImage = $sld->getImage($ScaleX, $ScaleY);
    # Enregistrer l'image sur le disque au format JPEG
    try {
      $slideImage->save("Thumbnail_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    $pres->dispose();
  }
```

## **Créer un Thumbnail à partir d'une Diapositive dans la Vue des Diapositives de Notes**
Pour générer la miniature de n'importe quelle diapositive souhaitée dans la vue des diapositives de notes à l'aide d'Aspose.Slides pour PHP via Java :

1. Créez une instance de la [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) classe.
1. Obtenez la référence de n'importe quelle diapositive souhaitée en utilisant son ID ou son index.
1. Obtenez l'image miniature de la diapositive référencée à une échelle spécifiée dans la vue des diapositives de notes.
1. Enregistrez l'image miniature dans n'importe quel format d'image désiré.

Le snippet de code ci-dessous produit une miniature de la première diapositive d'une présentation dans la vue des diapositives de notes.

```php
  # Instancier une classe Presentation qui représente le fichier de présentation
  $pres = new Presentation("ThumbnailWithUserDefinedDimensions.pptx");
  try {
    # Accéder à la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Dimension définie par l'utilisateur
    $desiredX = 1200;
    $desiredY = 800;
    # Obtenir la valeur mise à l'échelle de X et Y
    $ScaleX = 1.0 / $pres->getSlideSize()->getSize()->getWidth() * $desiredX;
    $ScaleY = 1.0 / $pres->getSlideSize()->getSize()->getHeight() * $desiredY;
    $opts = new RenderingOptions();
    $opts->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomTruncated);
    # Créer une image en pleine échelle
    $slideImage = $sld->getImage($opts, $ScaleX, $ScaleY);
    # Enregistrer l'image sur le disque au format JPEG
    try {
      $slideImage->save("Thumbnail_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    $pres->dispose();
  }
```