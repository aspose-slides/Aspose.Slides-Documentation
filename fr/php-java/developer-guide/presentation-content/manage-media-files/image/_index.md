---
title: Image
type: docs
weight: 10
url: /fr/php-java/image/
description: Travailler avec des images dans les diapositives dans les présentations PowerPoint en utilisant PHP. Ajouter des images depuis le disque ou depuis le web dans les diapositives PowerPoint en utilisant PHP. Ajouter des images aux modèles de diapositives ou en tant qu'arrière-plan de diapositive en utilisant PHP. Ajouter du SVG à la présentation PowerPoint en utilisant PHP. Convertir le SVG en formes dans PowerPoint en utilisant PHP. Ajouter des images en tant qu'EMF dans les diapositives en utilisant PHP.
---

## **Images dans les diapositives dans les présentations**

Les images rendent les présentations plus engageantes et intéressantes. Dans Microsoft PowerPoint, vous pouvez insérer des images à partir d'un fichier, d'internet ou d'autres emplacements dans les diapositives. De même, Aspose.Slides vous permet d'ajouter des images aux diapositives de vos présentations par différents procédés.

{{% alert title="Conseil" color="primary" %}}

Aspose propose des convertisseurs gratuits—[JPEG vers PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) et [PNG vers PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—qui permettent aux personnes de créer rapidement des présentations à partir d'images.

{{% /alert %}}

{{% alert title="Info" color="info" %}}

Si vous voulez ajouter une image en tant qu'objet de cadre—surtout si vous prévoyez d'utiliser les options de mise en forme standard pour changer sa taille, ajouter des effets, etc.—voir [Cadre d'image](https://docs.aspose.com/slides/php-java/picture-frame/).

{{% /alert %}}

{{% alert title="Remarque" color="warning" %}}

Vous pouvez manipuler les opérations d'entrée/sortie impliquant des images et des présentations PowerPoint pour convertir une image d'un format à un autre. Voir ces pages : convertir [image en JPG](https://products.aspose.com/slides/php-java/conversion/image-to-jpg/) ; convertir [JPG en image](https://products.aspose.com/slides/php-java/conversion/jpg-to-image/) ; convertir [JPG en PNG](https://products.aspose.com/slides/php-java/conversion/jpg-to-png/) ; convertir [PNG en JPG](https://products.aspose.com/slides/php-java/conversion/png-to-jpg/) ; convertir [PNG en SVG](https://products.aspose.com/slides/php-java/conversion/png-to-svg/) ; convertir [SVG en PNG](https://products.aspose.com/slides/php-java/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides prend en charge les opérations avec des images dans ces formats populaires : JPEG, PNG, GIF, et d'autres.

## **Ajouter des images stockées localement aux diapositives**

Vous pouvez ajouter une ou plusieurs images sur votre ordinateur à une diapositive dans une présentation. Ce code d'exemple vous montre comment ajouter une image à une diapositive :

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ajouter des images depuis le web aux diapositives**

Si l'image que vous souhaitez ajouter à une diapositive n'est pas disponible sur votre ordinateur, vous pouvez ajouter l'image directement depuis le web.

Ce code d'exemple vous montre comment ajouter une image depuis le web à une diapositive :

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $imageUrl = new URL("[REMPLACER PAR URL]");
    $connection = $imageUrl->openConnection();
    $inputStream = $connection->getInputStream();
    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new java_class("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    try {
      $buffer = $Array->newInstance($Byte, 1024);
      $read;
      while ($read = $inputStream->read($buffer, 0, $Array->getLength($buffer)) != -1) {
        $outputStream->write($buffer, 0, $read);
      } 
      $outputStream->flush();
      $image = $pres->getImages()->addImage($outputStream->toByteArray());
      $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $image);
    } finally {
      if (!java_is_null($inputStream)) {
        $inputStream->close();
      }
      $outputStream->close();
    }
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ajouter des images aux modèles de diapositives**

Un modèle de diapositive est la diapositive supérieure qui stocke et contrôle des informations (thème, mise en page, etc.) sur toutes les diapositives en dessous. Ainsi, lorsque vous ajoutez une image à un modèle de diapositive, cette image apparaît sur chaque diapositive sous ce modèle de diapositive.

Ce code d'exemple Java vous montre comment ajouter une image à un modèle de diapositive :

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $masterSlide = $slide->getLayoutSlide()->getMasterSlide();
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $masterSlide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ajouter des images comme arrière-plan de diapositive**

Vous pouvez décider d'utiliser une image comme arrière-plan pour une diapositive spécifique ou plusieurs diapositives. Dans ce cas, vous devez voir *[Définir des images comme arrière-plans pour les diapositives](https://docs.aspose.com/slides/php-java/presentation-background/#setting-images-as-background-for-slides)*.

## **Ajouter du SVG aux présentations**
Vous pouvez ajouter ou insérer n'importe quelle image dans une présentation en utilisant la méthode [addPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) qui appartient à l'interface [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).

Pour créer un objet image basé sur une image SVG, vous pouvez le faire de cette manière :

1. Créer un objet SvgImage pour l'insérer dans ImageShapeCollection
2. Créer un objet PPImage à partir de ISvgImage
3. Créer un objet PictureFrame en utilisant l'interface IPPImage

Ce code d'exemple vous montre comment mettre en œuvre les étapes ci-dessus pour ajouter une image SVG dans une présentation:
```php
  # Instancier la classe Presentation qui représente un fichier PPTX
  $pres = new Presentation();
  try {
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "image.svg"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $svgContent = new String($bytes);

    $svgImage = new SvgImage($svgContent);
    $ppImage = $pres->getImages()->addImage($svgImage);
    $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, $ppImage->getWidth(), $ppImage->getHeight(), $ppImage);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Convertir le SVG en un ensemble de formes**
La conversion du SVG en un ensemble de formes dans Aspose.Slides est similaire à la fonctionnalité de PowerPoint utilisée pour travailler avec des images SVG :

![Menu contextuel PowerPoint](img_01_01.png)

La fonctionnalité est fournie par l'un des surcharges de la méthode [addGroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) de l'interface [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection) qui prend un objet [ISvgImage](https://reference.aspose.com/slides/php-java/aspose.slides/ISvgImage) comme premier argument.

Ce code d'exemple vous montre comment utiliser la méthode décrite pour convertir un fichier SVG en un ensemble de formes :

```php
  # Créer une nouvelle présentation
  $presentation = new Presentation();
  try {
    # Lire le contenu du fichier SVG
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "image.svg"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $svgContent = $bytes;

    # Créer un objet SvgImage
    $svgImage = new SvgImage($svgContent);
    # Obtenir la taille de la diapositive
    $slideSize = $presentation->getSlideSize()->getSize();
    # Convertir l'image SVG en groupe de formes en l'adaptant à la taille de la diapositive
    $presentation->getSlides()->get_Item(0)->getShapes()->addGroupShape($svgImage, 0.0, 0.0, $slideSize->getWidth(), $slideSize->getHeight());
    # Enregistrer la présentation au format PPTX
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Ajouter des images en tant qu'EMF dans les diapositives**
Aspose.Slides pour PHP via Java vous permet de générer des images EMF à partir de feuilles Excel et d'ajouter les images en tant qu'EMF dans les diapositives avec Aspose.Cells.

Ce code d'exemple vous montre comment réaliser la tâche décrite :

```php
  $book = new Workbook("chart.xlsx");
  $sheet = $book->getWorksheets()->get(0);
  $options = new ImageOrPrintOptions();
  $options->setHorizontalResolution(200);
  $options->setVerticalResolution(200);
  $options->setImageType(ImageType::EMF);
  # Enregistrer le classeur dans un flux
  $sr = new SheetRender($sheet, $options);
  $pres = new Presentation();
  try {
    $pres->getSlides()->removeAt(0);
    $EmfSheetName = "";
    for($j = 0; $j < java_values($sr->getPageCount()) ; $j++) {
      $EmfSheetName = "test" . $sheet->getName() . " Page" . $j + 1 . ".out.emf";
      $sr->toImage($j, $EmfSheetName);
      $picture;
      $image = Images->fromFile($EmfSheetName);
      try {
        $picture = $pres->getImages()->addImage($image);
      } finally {
        if (!java_is_null($image)) {
          $image->dispose();
        }
      }
      $slide = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->getByType(SlideLayoutType::Blank));
      $m = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, $pres->getSlideSize()->getSize()->getWidth(), $pres->getSlideSize()->getSize()->getHeight(), $picture);
    }
    $pres->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Info" color="info" %}}

En utilisant le convertisseur gratuit Aspose [Texte vers GIF](https://products.aspose.app/slides/text-to-gif), vous pouvez facilement animer des textes, créer des GIF à partir de textes, etc.

{{% /alert %}}