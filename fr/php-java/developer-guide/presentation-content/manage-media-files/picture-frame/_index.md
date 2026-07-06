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
- image raster
- image vectorielle
- recadrer une image
- zone recadrée
- propriété StretchOff
- mise en forme du cadre d'image
- propriétés du cadre d'image
- échelle relative
- effet d'image
- ratio d'aspect
- transparence de l'image
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Ajoutez des cadres d'image aux présentations PowerPoint et OpenDocument avec Aspose.Slides pour PHP via Java. Simplifiez votre flux de travail et améliorez la conception des diapositives."
---
## **Introduction**

Un cadre d'image est une forme qui contient une image — c'est comme une photo dans un cadre.  

Vous pouvez ajouter une image à une diapositive via un cadre d'image. Ainsi, vous pouvez mettre en forme l'image en formatant le cadre d'image.

{{% alert  title="Tip" color="primary" %}} 
Aspose propose des convertisseurs gratuits—[JPEG vers PowerPoint](https://products.aspose.app/slides/fr/import/jpg-to-ppt) et [PNG vers PowerPoint](https://products.aspose.app/slides/fr/import/png-to-ppt)—qui permettent aux utilisateurs de créer rapidement des présentations à partir d'images. 
{{% /alert %}} 

## **Créer un cadre d'image**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/).  
2. Obtenez la référence d'une diapositive par son indice.  
3. Créez un objet [PPImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/ppimage/) en ajoutant une image à la [ImageCollection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/imagecollection/) associée à l'objet présentation qui sera utilisé pour remplir la forme.  
4. Spécifiez la largeur et la hauteur de l'image.  
5. Créez un [PictureFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/pictureframe/) basé sur la largeur et la hauteur de l'image via la méthode `addPictureFrame` exposée par l'objet shape associé à la diapositive référencée.  
6. Ajoutez un cadre d'image (contenant l'image) à la diapositive.  
7. Enregistrez la présentation modifiée en tant que fichier PPTX.  

Ce code PHP vous montre comment créer un cadre d'image :

```php
  # Instancie la classe Presentation qui représente un fichier PPTX
  $pres = new Presentation();
  try {
    # Obtient la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Instancie la classe Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Ajoute un cadre d'image avec la hauteur et la largeur équivalentes de l'image
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
Les cadres d'image vous permettent de créer rapidement des diapositives à partir d'images. En combinant le cadre d'image avec les options d'enregistrement Aspose.Slides, vous pouvez manipuler les opérations d'entrée/sortie pour convertir des images d'un format à un autre. Vous pourriez consulter ces pages : convertir [image vers JPG](https://products.aspose.com/slides/fr/php-java/conversion/image-to-jpg/); convertir [JPG vers image](https://products.aspose.com/slides/fr/php-java/conversion/jpg-to-image/); convertir [JPG vers PNG](https://products.aspose.com/slides/fr/php-java/conversion/jpg-to-png/), convertir [PNG vers JPG](https://products.aspose.com/slides/fr/php-java/conversion/png-to-jpg/); convertir [PNG vers SVG](https://products.aspose.com/slides/fr/php-java/conversion/png-to-svg/), convertir [SVG vers PNG](https://products.aspose.com/slides/fr/php-java/conversion/svg-to-png/). 
{{% /alert %}}

## **Créer un cadre d'image avec échelle relative**

En modifiant l'échelle relative d'une image, vous pouvez créer un cadre d'image plus sophistiqué.  

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/).  
2. Obtenez la référence d'une diapositive par son indice.  
3. Ajoutez une image à la collection d'images de la présentation.  
4. Créez un objet [PPImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/ppimage/) en ajoutant une image à la [ImageCollection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/imagecollection/) associée à l'objet présentation qui sera utilisé pour remplir la forme.  
5. Spécifiez la largeur et la hauteur relatives de l'image dans le cadre d'image.  
6. Enregistrez la présentation modifiée en tant que fichier PPTX.  

Ce code PHP vous montre comment créer un cadre d'image avec échelle relative :

```php
  # Instancie la classe Presentation qui représente le PPTX
  $pres = new Presentation();
  try {
    # Obtient la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Instancie la classe Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Ajoute un cadre d'image avec la hauteur et la largeur équivalentes de l'image
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Définit la largeur et la hauteur de l'échelle relative
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

## **Extraire des images raster à partir de cadres d'image**

Vous pouvez extraire des images raster des objets [PictureFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/pictureframe/) et les enregistrer au format PNG, JPG ou d'autres formats. L'exemple de code ci‑dessous montre comment extraire une image du document « sample.pptx » et l'enregistrer au format PNG.

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

## **Extraire des images SVG à partir de cadres d'image**

Lorsqu'une présentation contient des graphiques SVG placés à l'intérieur de formes [PictureFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/pictureframe/), Aspose.Slides for PHP via Java vous permet de récupérer les images vectorielles d'origine avec une fidélité totale. En parcourant la collection de formes de la diapositive, vous pouvez identifier chaque [PictureFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/pictureframe/), vérifier si l'[PPImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/ppimage/) sous‑jacente contient du contenu SVG, puis enregistrer cette image sur disque ou dans un flux au format SVG natif.

L'exemple de code suivant montre comment extraire une image SVG d'un cadre d'image :

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

## **Obtenir la transparence d'une image**

Aspose.Slides vous permet d'obtenir l'effet de transparence appliqué à une image. Ce code PHP illustre l'opération :

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

## **Obtenir la luminosité et le contraste d'une image**

Aspose.Slides vous permet d'obtenir les effets de luminosité et de contraste appliqués à une image. La classe [Luminance](https://reference.aspose.com/slides/fr/php-java/aspose.slides/luminance/) représente cet effet de transformation d'image.

Ce code PHP montre comment récupérer les paramètres de luminosité et de contraste d'un cadre d'image :

```php
  $presentation = new Presentation("sample.pptx");

  try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $pictureFrame = $shape;

    $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
    $imageTransformCount = java_values($imageTransform->size());
    for ($index = 0; $index < $imageTransformCount; $index++) {
      $effect = $imageTransform->get_Item($index);
      if (java_instanceof($effect, new JavaClass("com.aspose.slides.Luminance"))) {
        $luminance = $effect->getEffective();
        $brightness = java_values($luminance->getBrightness());
        $contrast = java_values($luminance->getContrast());

        echo("Brightness: " . $brightness . PHP_EOL);
        echo("Contrast: " . $contrast . PHP_EOL);
      }
    }
  } finally {
    $presentation->dispose();
  }
```

## **Mise en forme du cadre d'image**

Aspose.Slides propose de nombreuses options de mise en forme applicables à un cadre d'image. En utilisant ces options, vous pouvez modifier un cadre d'image pour qu'il réponde à des exigences spécifiques.  

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/).  
2. Obtenez la référence d'une diapositive par son indice.  
3. Créez un objet [PPImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/ppimage/) en ajoutant une image à la [ImageCollection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/imagecollection/) associée à l'objet présentation qui sera utilisé pour remplir la forme.  
4. Spécifiez la largeur et la hauteur de l'image.  
5. Créez un `PictureFrame` basé sur la largeur et la hauteur de l'image via la méthode [addPictureFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shapecollection/addpictureframe/) exposée par l'objet [ShapeCollection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shapecollection/) associé à la diapositive référencée.  
6. Ajoutez le cadre d'image (contenant l'image) à la diapositive.  
7. Définissez la couleur de trait du cadre d'image.  
8. Définissez la largeur du trait du cadre d'image.  
9. Faites pivoter le cadre d'image en lui attribuant une valeur positive ou négative.  
   * Une valeur positive fait pivoter l'image dans le sens des aiguilles d'une montre.  
   * Une valeur négative fait pivoter l'image dans le sens inverse des aiguilles d'une montre.  
10. Ajoutez le cadre d'image (contenant l'image) à la diapositive.  
11. Enregistrez la présentation modifiée en tant que fichier PPTX.  

Ce code PHP montre le processus de mise en forme du cadre d'image :

```php
  # Instancie la classe Presentation qui représente le PPTX
  $pres = new Presentation();
  try {
    # Obtient la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Instancie la classe Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Ajoute un cadre d'image avec la hauteur et la largeur équivalentes de l'image
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Applique un formatage à PictureFrameEx
    $pf->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $pf->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pf->getLineFormat()->setWidth(20);
    $pf->setRotation(45);
    # Enregistre le fichier PPTX sur le disque
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Tip" color="primary" %}}
Aspose a récemment développé un [Créateur de collage gratuit](https://products.aspose.app/slides/fr/collage). Si vous avez besoin de [fusionner des JPG/JPEG](https://products.aspose.app/slides/fr/collage/jpg) ou des images PNG, ou de [créer des grilles à partir de photos](https://products.aspose.app/slides/fr/collage/photo-grid), vous pouvez utiliser ce service. 
{{% /alert %}}

## **Ajouter une image sous forme de lien**

Pour éviter des tailles de présentation importantes, vous pouvez ajouter des images (ou des vidéos) via des liens au lieu d'intégrer les fichiers directement dans les présentations. Ce code PHP montre comment ajouter une image et une vidéo dans un espace réservé :

```php
  $presentation = new Presentation("input.pptx");
  try {
    $shapesToRemove = new Java("java.util.ArrayList");
    $shapesCount = $presentation->getSlides()->get_Item(0)->getShapes()->size();
    for($i = 0; $i < java_values($shapesCount) ; $i++) {
      $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item($i);
      if (java_is_null($autoShape->getPlaceholder())) {
        continue;
      }
      switch ($autoShape->getPlaceholder()->getType()) {
        case PlaceholderType::Picture :
          $pictureFrame = $presentation->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, $autoShape->getX(), $autoShape->getY(), $autoShape->getWidth(), $autoShape->getHeight(), null);
          $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
          $shapesToRemove->add($autoShape);
          break;
        case PlaceholderType::Media :
          $videoFrame = $presentation->getSlides()->get_Item(0)->getShapes()->addVideoFrame($autoShape->getX(), $autoShape->getY(), $autoShape->getWidth(), $autoShape->getHeight(), "");
          $videoFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
          $videoFrame->setLinkPathLong("https://youtu.be/t_1LYZ102RA");
          $shapesToRemove->add($autoShape);
          break;
      }
    }
    foreach($shapesToRemove as $shape) {
      $presentation->getSlides()->get_Item(0)->getShapes()->remove($shape);
    }
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Recadrer des images**

Ce code PHP montre comment recadrer une image existante sur une diapositive :

```php
  $pres = new Presentation();
  # Crée un nouvel objet image
  try {
    $picture;
    $image = Images->fromFile($imagePath);
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Ajoute un cadre d'image à une diapositive
    $picFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 100, 100, 420, 250, $picture);
    # Recadre l'image (valeurs en pourcentage)
    $picFrame->getPictureFormat()->setCropLeft(23.6);
    $picFrame->getPictureFormat()->setCropRight(21.5);
    $picFrame->getPictureFormat()->setCropTop(3);
    $picFrame->getPictureFormat()->setCropBottom(31);
    # Enregistre le résultat
    $pres->save($outPptxFile, SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Supprimer les zones recadrées d'un cadre**

Si vous souhaitez supprimer les zones recadrées d'une image contenue dans un cadre, vous pouvez utiliser la méthode [deletePictureCroppedAreas()](https://reference.aspose.com/slides/fr/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas). Cette méthode renvoie l'image recadrée ou l'image d'origine si le recadrage est inutile.  

Ce code PHP démontre l'opération :

```php
  $presentation = new Presentation("PictureFrameCrop.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # Obtient le PictureFrame de la première diapositive
    $picFrame = $slide->getShapes()->get_Item(0);
    # Supprime les zones recadrées de l'image du PictureFrame et renvoie l'image recadrée
    $croppedImage = $picFrame->getPictureFormat()->deletePictureCroppedAreas();
    # Enregistre le résultat
    $presentation->save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

{{% alert title="NOTE" color="warning" %}} 
La méthode [deletePictureCroppedAreas()](https://reference.aspose.com/slides/fr/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) ajoute l'image recadrée à la collection d'images de la présentation. Si l'image n'est utilisée que dans le [PictureFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/pictureframe/) traité, cette configuration peut réduire la taille de la présentation. Dans le cas contraire, le nombre d'images dans la présentation résultante augmentera.  

Cette méthode convertit les métafichiers WMF/EMF en image PNG raster lors de l'opération de recadrage. 
{{% /alert %}}

## **Compresser les images**

Vous pouvez compresser une image dans une présentation en utilisant la méthode [PictureFillFormat::compressImage()](https://reference.aspose.com/slides/fr/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_). Cette méthode compresse une image en réduisant sa taille en fonction de la taille de la forme et de la résolution spécifiée, avec la possibilité de supprimer les zones recadrées.  

Elle ajuste la taille et la résolution de l'image de la même manière que la fonction **Picture Format -> Compress Pictures -> Resolution** de PowerPoint.  

Les exemples PHP suivants montrent comment compresser une image dans une présentation en spécifiant une résolution cible et éventuellement en supprimant les zones recadrées :

```php
$presentation = new Presentation("demo.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->get_Item(0);

    # Compresse l'image avec une résolution cible de 150 DPI (résolution Web) et supprime les zones recadrées.
    $result = $pictureFrame->getPictureFormat()->compressImage(true, PicturesCompression::Dpi150);

    # Vérifie le résultat de la compression.
    if ($result) {
        echo "Image successfully compressed.";
    } else {
        echo "Image compression failed or no changes were necessary.";
    }

    $presentation->save("CompressedImage.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Ou en utilisant directement une valeur DPI personnalisée :

```php
$presentation = new Presentation("demo.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->get_Item(0);

    # Compresse l'image à 150 DPI (résolution web), en supprimant les zones recadrées.
    $pictureFrame->getPictureFormat()->compressImage(true, 150.0);

    $presentation->save("CompressedImage.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
La méthode convertit l'image à une résolution inférieure en fonction de la taille de la forme et du DPI fourni. Les régions recadrées peuvent également être supprimées afin d'optimiser la taille du fichier.  
Si l'image est un métafile (WMF/EMF) ou un SVG, la compression ne sera pas appliquée. De plus, la qualité JPEG est conservée ou légèrement réduite selon la résolution, de la même façon que PowerPoint gère les JPEG haute résolution. 
{{% /alert %}}

## **Verrouiller le ratio d’aspect**

Si vous souhaitez qu'une forme contenant une image conserve son ratio d’aspect même après modification des dimensions de l'image, utilisez la méthode [setAspectRatioLocked](https://reference.aspose.com/slides/fr/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) pour activer le paramètre *Lock Aspect Ratio*.  

Ce code PHP montre comment verrouiller le ratio d’aspect d'une forme :

```php
  $pres = new Presentation("pres.pptx");
  try {
    $layout = $pres->getLayoutSlides()->getByType(SlideLayoutType::Custom);
    $emptySlide = $pres->getSlides()->addEmptySlide($layout);
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $pictureFrame = $emptySlide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $presImage->getWidth(), $presImage->getHeight(), $picture);
    # définit la forme pour qu'elle conserve le ratio d'aspect lors du redimensionnement
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="NOTE" color="warning" %}} 
Ce paramètre *Lock Aspect Ratio* ne préserve que le ratio d’aspect de la forme et non l'image qu'elle contient. 
{{% /alert %}}

## **Utiliser la propriété StretchOff**

En utilisant les méthodes [setStretchOffsetLeft](https://reference.aspose.com/slides/fr/php-java/aspose.slides/picturefillformat/setstretchoffsetleft/), [setStretchOffsetTop](https://reference.aspose.com/slides/fr/php-java/aspose.slides/picturefillformat/setstretchoffsettop/), [setStretchOffsetRight](https://reference.aspose.com/slides/fr/php-java/aspose.slides/picturefillformat/setstretchoffsetright/) et [setStretchOffsetBottom](https://reference.aspose.com/slides/fr/php-java/aspose.slides/picturefillformat/setstretchoffsetbottom/) de la classe [PictureFillFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/picturefillformat/), vous pouvez spécifier un rectangle de remplissage.  

Lorsque l’étirement est indiqué pour une image, un rectangle source est mis à l'échelle pour s'adapter au rectangle de remplissage spécifié. Chaque bord du rectangle de remplissage est défini par un décalage en pourcentage par rapport au bord correspondant de la boîte englobante de la forme. Un pourcentage positif indique un retrait tandis qu'un pourcentage négatif indique un dépassement.  

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/).  
2. Obtenez la référence d'une diapositive par son indice.  
3. Ajoutez un rectangle `AutoShape`.  
4. Créez une image.  
5. Définissez le type de remplissage de la forme.  
6. Définissez le mode de remplissage image de la forme.  
7. Ajoutez une image définie pour remplir la forme.  
8. Spécifiez les décalages de l'image par rapport aux bords correspondants de la boîte englobante de la forme.  
9. Enregistrez la présentation modifiée en tant que fichier PPTX.  

Ce code PHP montre un processus utilisant la propriété StretchOff :

```php
  # Instancie la classe Presentation qui représente un fichier PPTX
  $pres = new Presentation();
  try {
    # Obtient la première diapositive
    $slide = $pres->getSlides()->get_Item(0);
    # Instancie la classe ImageEx
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Ajoute un AutoShape de type Rectangle
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # Définit le type de remplissage de la forme
    $aShape->getFillFormat()->setFillType(FillType::Picture);
    # Définit le mode de remplissage image de la forme
    $aShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    # Définit l'image pour remplir la forme
    $aShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # Spécifie les décalages de l'image par rapport au bord correspondant de la boîte englobante de la forme
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetLeft(25);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetRight(25);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetTop(-20);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetBottom(-10);
    # Enregistre le fichier PPTX sur le disque
    $pres->save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Comment savoir quels formats d'image sont pris en charge pour PictureFrame ?**

Aspose.Slides prend en charge les images raster (PNG, JPEG, BMP, GIF, etc.) ainsi que les images vectorielles (par exemple SVG) via l'objet image assigné à un [PictureFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/pictureframe/). La liste des formats pris en charge chevauche généralement les capacités du moteur de conversion de diapositives et d'images.

**Comment l'ajout de dizaines d'images volumineuses affecte-t-il la taille et les performances du fichier PPTX ?**

L'intégration d'images volumineuses augmente la taille du fichier et la consommation de mémoire ; le lien d'images aide à réduire la taille de la présentation mais nécessite que les fichiers externes restent accessibles. Aspose.Slides offre la possibilité d'ajouter des images par lien afin de diminuer la taille du fichier.

**Comment verrouiller un objet image contre tout déplacement/redimensionnement accidentel ?**

Utilisez les [verrous de forme](https://reference.aspose.com/slides/fr/php-java/aspose.slides/pictureframe/getpictureframelock/) pour un [PictureFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/pictureframe/) (par exemple, désactiver le déplacement ou le redimensionnement). Le mécanisme de verrouillage est pris en charge pour divers types de formes, y compris les [PictureFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/pictureframe/).

**La fidélité vectorielle SVG est‑elle préservée lors de l'exportation d'une présentation vers PDF ou images ?**

Aspose.Slides permet d'extraire un SVG d'un [PictureFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/pictureframe/) sous forme de vecteur d'origine. Lors de l'[exportation vers PDF](/slides/fr/php-java/convert-powerpoint-to-pdf/) ou des [formats raster](/slides/fr/php-java/convert-powerpoint-to-png/), le résultat peut être rasterisé selon les paramètres d'exportation ; le fait que le SVG d'origine soit stocké comme vecteur est confirmé par le comportement d'extraction.