---
title: Optimiser la gestion des images dans les présentations avec PHP
linktitle: Gérer les images
type: docs
weight: 10
url: /fr/php-java/image/
keywords:
- ajouter image
- ajouter photo
- ajouter bitmap
- remplacer image
- remplacer photo
- depuis le web
- arrière-plan
- ajouter PNG
- ajouter JPG
- ajouter SVG
- ajouter EMF
- ajouter WMF
- ajouter TIFF
- PowerPoint
- OpenDocument
- présentation
- EMF
- SVG
- PHP
- Aspose.Slides
description: "Simplifiez la gestion des images dans PowerPoint et OpenDocument avec Aspose.Slides pour PHP via Java, en optimisant les performances et en automatisant votre flux de travail."
---

## **Images dans les diapositives de présentation**

Les images rendent les présentations plus attrayantes et intéressantes. Dans Microsoft PowerPoint, vous pouvez insérer des images depuis un fichier, Internet ou d’autres emplacements sur les diapositives. De même, Aspose.Slides vous permet d’ajouter des images aux diapositives de vos présentations via différentes procédures. 

{{% alert  title="Astuce" color="primary" %}} 

Aspose propose des convertisseurs gratuits—[JPEG vers PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) et [PNG vers PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—qui permettent de créer rapidement des présentations à partir d’images. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Si vous souhaitez ajouter une image en tant qu’objet image—surtout si vous prévoyez d’utiliser les options de mise en forme standard pour modifier sa taille, ajouter des effets, etc.—voir [Cadre d’image](https://docs.aspose.com/slides/php-java/picture-frame/).

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

Vous pouvez manipuler les opérations d’entrée/sortie impliquant des images et des présentations PowerPoint pour convertir une image d’un format à un autre. Consultez ces pages : convertir [image en JPG](https://products.aspose.com/slides/php-java/conversion/image-to-jpg/); convertir [JPG en image](https://products.aspose.com/slides/php-java/conversion/jpg-to-image/); convertir [JPG en PNG](https://products.aspose.com/slides/php-java/conversion/jpg-to-png/), convertir [PNG en JPG](https://products.aspose.com/slides/php-java/conversion/png-to-jpg/); convertir [PNG en SVG](https://products.aspose.com/slides/php-java/conversion/png-to-svg/), convertir [SVG en PNG](https://products.aspose.com/slides/php-java/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides prend en charge les opérations avec des images dans ces formats populaires : JPEG, PNG, GIF et autres. 

## **Ajouter des images stockées localement aux diapositives**

Vous pouvez ajouter une ou plusieurs images de votre ordinateur sur une diapositive d’une présentation. Ce code d’exemple vous montre comment ajouter une image à une diapositive :
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


## **Ajouter des images depuis le Web aux diapositives**

Si l’image que vous souhaitez ajouter à une diapositive n’est pas disponible sur votre ordinateur, vous pouvez l’ajouter directement depuis le web. 

Ce code d’exemple vous montre comment ajouter une image depuis le web à une diapositive :
```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $imageUrl = new URL("[REPLACE WITH URL]");
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


## **Ajouter des images aux maîtres de diapositive**

Un maître de diapositive est la diapositive supérieure qui stocke et contrôle les informations (thème, mise en page, etc.) de toutes les diapositives qui en dépendent. Ainsi, lorsque vous ajoutez une image à un maître de diapositive, cette image apparaît sur chaque diapositive sous ce maître. 

Ce code d’exemple Java vous montre comment ajouter une image à un maître de diapositive :
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


## **Ajouter des images en tant qu’arrière‑plan de diapositive**

Vous pouvez choisir d’utiliser une image comme arrière‑plan d’une diapositive spécifique ou de plusieurs diapositives. Dans ce cas, consultez *[Définir des images comme arrière‑plans pour les diapositives](https://docs.aspose.com/slides/php-java/presentation-background/#setting-images-as-background-for-slides)*.

## **Ajouter des SVG aux présentations**
Vous pouvez ajouter ou insérer n’importe quelle image dans une présentation en utilisant la méthode [addPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) appartenant à l’interface [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).

Pour créer un objet image à partir d’une image SVG, vous pouvez procéder ainsi :

1. Créer un objet SvgImage pour l’insérer dans ImageShapeCollection
2. Créer un objet PPImage à partir de ISvgImage
3. Créer un objet PictureFrame en utilisant l’interface IPPImage

Ce code d’exemple vous montre comment implémenter les étapes ci‑dessus pour ajouter une image SVG dans une présentation :
```php
  # Instancier la classe Presentation qui représente le fichier PPTX
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


## **Convertir SVG en un ensemble de formes**
La conversion de SVG en un ensemble de formes d’Aspose.Slides est similaire à la fonctionnalité PowerPoint utilisée pour travailler avec des images SVG :

![PowerPoint Popup Menu](img_01_01.png)

La fonctionnalité est fournie par l’une des surcharges de la méthode [addGroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) de l’interface [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection), qui prend un objet [ISvgImage](https://reference.aspose.com/slides/php-java/aspose.slides/ISvgImage) comme premier argument.

Ce code d’exemple vous montre comment utiliser la méthode décrite pour convertir un fichier SVG en un ensemble de formes :
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

    # Créer l'objet SvgImage
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


## **Ajouter des images en tant qu’EMF aux diapositives**
Aspose.Slides for PHP via Java vous permet de générer des images EMF à partir de feuilles Excel et d’ajouter ces images en tant qu’EMF dans les diapositives avec Aspose.Cells. 

Ce code d’exemple vous montre comment réaliser la tâche décrite :
```php
  $book = new Workbook("chart.xlsx");
  $sheet = $book->getWorksheets()->get(0);
  $options = new ImageOrPrintOptions();
  $options->setHorizontalResolution(200);
  $options->setVerticalResolution(200);
  $options->setImageType(ImageType::EMF);
  # Enregistrer le classeur dans le flux
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


## **Remplacer des images dans la collection d’images**

Aspose.Slides vous permet de remplacer les images stockées dans la collection d’images d’une présentation (y compris celles utilisées par les formes de diapositive). Cette section présente plusieurs approches pour mettre à jour les images de la collection. L’API propose des méthodes simples pour remplacer une image à l’aide de données binaires brutes, d’une instance [IImage](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/) ou d’une autre image déjà présente dans la collection.

Suivez les étapes ci‑dessous :

1. Charger le fichier de présentation contenant des images en utilisant la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Charger une nouvelle image depuis un fichier dans un tableau d’octets.
3. Remplacer l’image cible par la nouvelle image en utilisant le tableau d’octets.
4. Dans la deuxième approche, charger l’image dans un objet [IImage](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/) et remplacer l’image cible par cet objet.
5. Dans la troisième approche, remplacer l’image cible par une image déjà présente dans la collection d’images de la présentation.
6. Enregistrer la présentation modifiée en tant que fichier PPTX.
```php
// Instancier la classe Presentation qui représente un fichier de présentation.
$presentation = new Presentation("sample.pptx");
try {
    // Première méthode.
    $imagePath = (new Java("java.io.File", "image0.jpeg"))->toPath();
    $imageData = (new Java("java.nio.file.Files"))->readAllBytes($imagePath);
    $oldImage = $presentation->getImages()->get_Item(0);
    $oldImage->replaceImage($imageData);

    // Deuxième méthode.
    $newImage = Images::fromFile("image1.png");
    $oldImage = $presentation->getImages()->get_Item(1);
    $oldImage->replaceImage($newImage);
    $newImage->dispose();
    
    // Troisième méthode.
    $oldImage = $presentation->getImages()->get_Item(2);
    $oldImage->replaceImage($presentation->getImages()->get_Item(3));
    
    // Enregistrer la présentation dans un fichier.
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


{{% alert title="Info" color="info" %}}

En utilisant le convertisseur GRATUIT Aspose [Text to GIF](https://products.aspose.app/slides/text-to-gif), vous pouvez facilement animer du texte, créer des GIF à partir de texte, etc. 

{{% /alert %}}

## **FAQ**

**La résolution originale de l’image reste-t-elle intacte après l’insertion ?**

Oui. Les pixels source sont conservés, mais l’apparence finale dépend de la façon dont le [picture](/slides/fr/php-java/picture-frame/) est redimensionné sur la diapositive et de toute compression appliquée lors de l’enregistrement.

**Quelle est la meilleure façon de remplacer le même logo sur des dizaines de diapositives en même temps ?**

Placez le logo sur la diapositive maître ou sur une mise en page et remplacez‑le dans la collection d’images de la présentation — les mises à jour se propageront à tous les éléments qui utilisent cette ressource.

**Une SVG insérée peut-elle être convertie en formes modifiables ?**

Oui. Vous pouvez convertir un SVG en un groupe de formes, après quoi chaque partie devient modifiable avec les propriétés de forme standard.

**Comment définir une image comme arrière‑plan pour plusieurs diapositives en même temps ?**

[Attribuez l’image comme arrière‑plan](/slides/fr/php-java/presentation-background/) sur la diapositive maître ou la mise en page concernée—toutes les diapositives utilisant ce maître/mise en page hériteront de l’arrière‑plan.

**Comment empêcher la présentation de « gonfler » en taille à cause de nombreuses images ?**

Réutilisez une même ressource d’image au lieu de la dupliquer, choisissez des résolutions raisonnables, appliquez une compression lors de l’enregistrement, et conservez les graphiques répétés sur le maître lorsque cela est approprié.