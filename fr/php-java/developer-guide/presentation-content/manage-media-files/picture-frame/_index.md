---
title: Gérer les cadres d'image dans les présentations avec PHP
linktitle: Cadre d'image
type: docs
weight: 10
url: /fr/php-java/picture-frame/
keywords:
- cadre d'image
- ajouter un cadre d'image
- créer un cadre d'image
- ajouter une image
- créer une image
- extraire une image
- image matricielle
- image vectorielle
- rogner une image
- zone rognée
- propriété StretchOff
- mise en forme du cadre d'image
- propriétés du cadre d'image
- mise à l'échelle relative
- effet d'image
- rapport d'aspect
- transparence d'image
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Ajoutez des cadres d'image aux présentations PowerPoint et OpenDocument avec Aspose.Slides pour PHP via Java. Rationalisez votre flux de travail et améliorez la conception des diapositives."
---
## **Introduction**

Un cadre d’image est une forme qui contient une image — c’est comme une photo dans un cadre.  

Vous pouvez ajouter une image à une diapositive via un cadre d’image. Ainsi, vous pouvez formater l’image en formatant le cadre d’image.

{{% alert title="Astuce" color="primary" %}}  
Aspose fournit des convertisseurs gratuits —[JPEG vers PowerPoint](https://products.aspose.app/slides/fr/import/jpg-to-ppt) et [PNG vers PowerPoint](https://products.aspose.app/slides/fr/import/png-to-ppt)—qui permettent de créer rapidement des présentations à partir d’images.  
{{% /alert %}}  

## **Créer un cadre d’image**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/).  
2. Obtenez la référence d’une diapositive via son indice.  
3. Créez un objet [PPImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/ppimage/) en ajoutant une image à la [ImageCollection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/imagecollection/) associée à l’objet présentation qui sera utilisé pour remplir la forme.  
4. Précisez la largeur et la hauteur de l’image.  
5. Créez un [PictureFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/pictureframe/) basé sur la largeur et la hauteur de l’image via la méthode `addPictureFrame` exposée par l’objet forme associé à la diapositive de référence.  
6. Ajoutez le cadre d’image (contenant la photo) à la diapositive.  
7. Enregistrez la présentation modifiée au format PPTX.  

Ce code PHP montre comment créer un cadre d’image :

```php
  # Instancie la classe Presentation qui représente un fichier PPTX
  $pres = new Presentation();
  try {
    # Récupère la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Instancie la classe Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Ajoute un cadre d'image avec la même hauteur et largeur que l'image
    $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Enregistre le fichier PPTX sur le disque
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" %}}  
Les cadres d’image permettent de créer rapidement des diapositives de présentation à partir d’images. En combinant le cadre d’image avec les options d’enregistrement d’Aspose.Slides, vous pouvez manipuler les opérations d’entrée/sortie pour convertir des images d’un format à un autre. Vous pouvez consulter ces pages : convertir [image en JPG](https://products.aspose.com/slides/fr/php-java/conversion/image-to-jpg/); convertir [JPG en image](https://products.aspose.com/slides/fr/php-java/conversion/jpg-to-image/); convertir [JPG en PNG](https://products.aspose.com/slides/fr/php-java/conversion/jpg-to-png/), convertir [PNG en JPG](https://products.aspose.com/slides/fr/php-java/conversion/png-to-jpg/); convertir [PNG en SVG](https://products.aspose.com/slides/fr/php-java/conversion/png-to-svg/), convertir [SVG en PNG](https://products.aspose.com/slides/fr/php-java/conversion/svg-to-png/).  
{{% /alert %}}  

## **Créer un cadre d’image avec mise à l’échelle relative**

En modifiant la mise à l’échelle relative d’une image, vous pouvez créer un cadre d’image plus complexe.  

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/).  
2. Obtenez la référence d’une diapositive via son indice.  
3. Ajoutez une image à la collection d’images de la présentation.  
4. Créez un objet [PPImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/ppimage/) en ajoutant une image à la [ImageCollection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/imagecollection/) associée à l’objet présentation qui sera utilisé pour remplir la forme.  
5. Spécifiez la largeur et la hauteur relatives de l’image dans le cadre d’image.  
6. Enregistrez la présentation modifiée au format PPTX.  

Ce code PHP montre comment créer un cadre d’image avec mise à l’échelle relative :

```php
  # Instancie la classe Presentation qui représente le PPTX
  $pres = new Presentation();
  try {
    # Récupère la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Instancie la classe Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Ajoute un cadre d'image avec la même hauteur et largeur que l'image
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Définit la mise à l'échelle relative en largeur et hauteur
    $pf->setRelativeScaleHeight(0.8);
    $pf->setRelativeScaleWidth(1.35);
    # Enregistre le fichier PPTX sur le disque
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Extraire des images matricielles des cadres d’image**

Vous pouvez extraire des images matricielles des objets [PictureFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/pictureframe/) et les enregistrer en PNG, JPG et autres formats. L’exemple de code ci‑dessous montre comment extraire une image du document « sample.pptx » et l’enregistrer au format PNG.

```php
  $presentation = new Presentation("sample.pptx");
  try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $firstShape = $firstSlide->getShapes()->get_Item(0);
    if (java_instanceof($firstShape, new JavaClass("com.aspose.slides.PictureFrame"))) {
      $pictureFrame = $firstShape;
      try {
        $slideImage = $pictureFrame->getPictureFormat()->getPicture()->getImage()->getImage();
        $slideImage->save("slide_1_shape_1.png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } catch (JavaException $e) {
  } finally {
    $presentation->dispose();
  }
```

## **Extraire des images SVG des cadres d’image**

Lorsqu’une présentation contient des graphiques SVG placés dans des formes [PictureFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/pictureframe/), Aspose.Slides for PHP via Java vous permet de récupérer les images vectorielles d’origine avec une fidélité totale. En parcourant la collection de formes de la diapositive, vous pouvez identifier chaque [PictureFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/pictureframe/), vérifier si le [PPImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/ppimage/) sous‑jacent contient du SVG, puis enregistrer cette image sur disque ou dans un flux au format SVG natif.

L’exemple de code suivant montre comment extraire une image SVG d’un cadre d’image :

```php
$presentation = new Presentation("sample.pptx");

try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
        $svgImage = $shape->getPictureFormat()->getPicture()->getImage()->getSvgImage();

        if ($svgImage !== null) {
            file_put_contents("output.svg", $svgImage->getSvgData());
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Obtenir la transparence d’une image**

Aspose.Slides vous permet d’obtenir l’effet de transparence appliqué à une image. Ce code PHP démontre l’opération :

```php
  $presentation = new Presentation("Test.pptx");
  $pictureFrame = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
  foreach($imageTransform as $effect) {
    if (java_instanceof($effect, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
      $alphaModulateFixed = $effect;
      $transparencyValue = 100 - $alphaModulateFixed->getAmount();
      echo("Picture transparency: " . $transparencyValue);
    }
  }
```

## **Mise en forme d’un cadre d’image**

Aspose.Slides propose de nombreuses options de mise en forme applicables à un cadre d’image. En utilisant ces options, vous pouvez modifier un cadre d’image pour répondre à des exigences spécifiques.  

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/).  
2. Obtenez la référence d’une diapositive via son indice.  
3. Créez un objet [PPImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/ppimage/) en ajoutant une image à la [ImageCollection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/imagecollection/) associée à l’objet présentation qui sera utilisé pour remplir la forme.  
4. Précisez la largeur et la hauteur de l’image.  
5. Créez un `PictureFrame` basé sur la largeur et la hauteur de l’image via la méthode [addPictureFrame](https://reference.aspose.com/sl