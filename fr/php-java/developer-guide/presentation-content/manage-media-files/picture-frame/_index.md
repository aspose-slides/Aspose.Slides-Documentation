---
title: Gérer les cadres d’image dans les présentations avec PHP
linktitle: Cadre d’image
type: docs
weight: 10
url: /fr/php-java/picture-frame/
keywords:
- cadre d’image
- ajouter un cadre d’image
- créer un cadre d’image
- ajouter une image
- créer une image
- extraire une image
- image raster
- image vectorielle
- recadrer une image
- zone recadrée
- propriété StretchOff
- mise en forme du cadre d’image
- propriétés du cadre d’image
- échelle relative
- effet d’image
- ratio d’aspect
- transparence de l’image
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Ajoutez des cadres d’image aux présentations PowerPoint et OpenDocument avec Aspose.Slides pour PHP via Java. Rationalisez votre flux de travail et améliorez la conception des diapositives."
---

Un cadre d’image est une forme qui contient une image — c’est comme une photo dans un cadre. 

Vous pouvez ajouter une image à une diapositive via un cadre d’image. Ainsi, vous pouvez formater l’image en formatant le cadre d’image.

{{% alert  title="Tip" color="primary" %}} 
Aspose propose des convertisseurs gratuits —[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) et [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt) — qui permettent de créer rapidement des présentations à partir d’images. 
{{% /alert %}} 

## **Create a Picture Frame**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).  
2. Obtenez la référence d’une diapositive par son indice.  
3. Créez un objet [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) en ajoutant une image à la [ImageCollection](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/) associée à l’objet présentation qui sera utilisé pour remplir la forme.  
4. Spécifiez la largeur et la hauteur de l’image.  
5. Créez un [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) à partir de la largeur et de la hauteur de l’image via la méthode `addPictureFrame` exposée par l’objet shape associé à la diapositive référencée.  
6. Ajoutez le cadre d’image (contenant la photo) à la diapositive.  
7. Enregistrez la présentation modifiée sous forme de fichier PPTX.  

Ce code PHP montre comment créer un cadre d’image :
```php
  # Instancie la classe Presentation qui représente un fichier PPTX
  $pres = new Presentation();
  try {
    # Récupère la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Instancie la classe Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Ajoute un cadre d’image avec la même hauteur et largeur que l’image
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
Les cadres d’image vous permettent de créer rapidement des diapositives de présentation à partir d’images. En combinant le cadre d’image avec les options d’enregistrement Aspose.Slides, vous pouvez manipuler les opérations d’entrée/sortie pour convertir des images d’un format à un autre. Vous pouvez consulter ces pages : convertir [image to JPG](https://products.aspose.com/slides/php-java/conversion/image-to-jpg/) ; convertir [JPG to image](https://products.aspose.com/slides/php-java/conversion/jpg-to-image/) ; convertir [JPG to PNG](https://products.aspose.com/slides/php-java/conversion/jpg-to-png/), convertir [PNG to JPG](https://products.aspose.com/slides/php-java/conversion/png-to-jpg/) ; convertir [PNG to SVG](https://products.aspose.com/slides/php-java/conversion/png-to-svg/), convertir [SVG to PNG](https://products.aspose.com/slides/php-java/conversion/svg-to-png/). 
{{% /alert %}}

## **Create a Picture Frame with Relative Scale**

En modifiant l’échelle relative d’une image, vous pouvez créer un cadre d’image plus sophistiqué.  

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).  
2. Obtenez la référence d’une diapositive par son indice.  
3. Ajoutez une image à la collection d’images de la présentation.  
4. Créez un objet [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) en ajoutant une image à la [ImageCollection](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/) associée à l’objet présentation qui sera utilisé pour remplir la forme.  
5. Spécifiez la largeur et la hauteur relatives de l’image dans le cadre d’image.  
6. Enregistrez la présentation modifiée sous forme de fichier PPTX.  

Ce code PHP montre comment créer un cadre d’image avec une échelle relative :
```php
  # Instancie la classe Presentation qui représente le PPTX
  $pres = new Presentation();
  try {
    # Récupère la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Instancie la classe Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Ajoute un cadre d’image avec la même hauteur et largeur que l’image
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Définir l’échelle relative de la hauteur et de la largeur
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


## **Extract Raster Images from Picture Frames**

Vous pouvez extraire des images raster des objets [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) et les enregistrer en PNG, JPG et autres formats. L’exemple de code ci‑dessous montre comment extraire une image du document « sample.pptx » et l’enregistrer au format PNG.  
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


## **Extract SVG Images from Picture Frames**

Lorsqu’une présentation contient des graphiques SVG placés dans des formes [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/), Aspose.Slides for PHP via Java vous permet de récupérer les images vectorielles originales avec une fidélité totale. En parcourant la collection de formes de la diapositive, vous pouvez identifier chaque [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/), vérifier si le [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) sous‑jacent contient du SVG, puis enregistrer cette image sur le disque ou dans un flux au format SVG natif.  

Le code suivant montre comment extraire une image SVG d’un cadre d’image :
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


## **Get Transparency of an Image**

Aspose.Slides vous permet d’obtenir l’effet de transparence appliqué à une image. Ce code PHP montre l’opération :
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


## **Picture Frame Formatting**

Aspose.Slides offre de nombreuses options de mise en forme applicables à un cadre d’image. Avec ces options, vous pouvez modifier un cadre d’image pour qu’il réponde à des exigences spécifiques.  

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).  
2. Obtenez la référence d’une diapositive par son indice.  
3. Créez un objet [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) en ajoutant une image à la [ImageCollection](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/) associée à l’objet présentation qui sera utilisé pour remplir la forme.  
4. Spécifiez la largeur et la hauteur de l’image.  
5. Créez un `PictureFrame` à partir de la largeur et de la hauteur de l’image via la méthode [addPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addpictureframe/) exposée par l’objet [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/) associé à la diapositive référencée.  
6. Ajoutez le cadre d’image (contenant la photo) à la diapositive.  
7. Définissez la couleur de trait du cadre d’image.  
8. Définissez la largeur de trait du cadre d’image.  
9. Faites pivoter le cadre d’image en lui attribuant une valeur positive ou négative.  
   * Une valeur positive fait pivoter l’image dans le sens des aiguilles d’une montre.  
   * Une valeur négative fait pivoter l’image dans le sens inverse.  
10. Ajoutez à nouveau le cadre d’image (contenant la photo) à la diapositive.  
11. Enregistrez la présentation modifiée sous forme de fichier PPTX.  

Ce code PHP montre le processus de mise en forme d’un cadre d’image :
```php
  # Instancie la classe Presentation qui représente le PPTX
  $pres = new Presentation();
  try {
    # Récupère la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Instancie la classe Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Ajoute un cadre d’image avec la même hauteur et largeur que l’image
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Applique un certain formatage à PictureFrameEx
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
Aspose a récemment développé un [free Collage Maker](https://products.aspose.app/slides/collage). Si vous devez [fusionner des JPG/JPEG](https://products.aspose.app/slides/collage/jpg) ou PNG, ou [créer des grilles à partir de photos](https://products.aspose.app/slides/collage/photo-grid), vous pouvez utiliser ce service. 
{{% /alert %}}

## **Add an Image as a Link**

Pour éviter des tailles de présentation trop importantes, vous pouvez ajouter des images (ou vidéos) via des liens plutôt qu’en les incorporant directement. Ce code PHP montre comment ajouter une image et une vidéo dans un espace réservé :
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


## **Crop Images**

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
    # Ajoute un PictureFrame à une diapositive
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


## **Delete Cropped Areas of a Picture**

Si vous souhaitez supprimer les zones recadrées d’une image contenue dans un cadre, utilisez la méthode [deletePictureCroppedAreas()](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas). Cette méthode renvoie l’image recadrée ou l’image d’origine si le recadrage n’est pas nécessaire.  

Ce code PHP montre l’opération :
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
La méthode [deletePictureCroppedAreas()](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) ajoute l’image recadrée à la collection d’images de la présentation. Si l’image n’est utilisée que dans le [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) traité, cette configuration peut réduire la taille de la présentation. Sinon, le nombre d’images dans la présentation résultante augmentera.  

Cette méthode convertit les métafichiers WMF/EMF en image PNG raster lors de l’opération de recadrage. 
{{% /alert %}}

## **Lock Aspect Ratio**

Si vous voulez qu’une forme contenant une image conserve son rapport d’aspect même après modification des dimensions de l’image, utilisez la méthode [setAspectRatioLocked](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) pour définir le paramètre *Lock Aspect Ratio*.  

Ce code PHP montre comment verrouiller le ratio d’aspect d’une forme :
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
    # définir la forme afin qu'elle préserve le ratio d'aspect lors du redimensionnement
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert title="NOTE" color="warning" %}} 
Ce paramètre *Lock Aspect Ratio* ne préserve que le ratio d’aspect de la forme, pas celui de l’image qu’elle contient. 
{{% /alert %}}

## **Use the StretchOff Property**

En utilisant les méthodes [setStretchOffsetLeft](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/setstretchoffsetleft/), [setStretchOffsetTop](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/setstretchoffsettop/), [setStretchOffsetRight](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/setstretchoffsetright/) et [setStretchOffsetBottom](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/setstretchoffsetbottom/) de la classe [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/), vous pouvez spécifier un rectangle de remplissage.  

Lorsque l’étirement est spécifié pour une image, un rectangle source est mis à l’échelle pour s’adapter au rectangle de remplissage indiqué. Chaque bord du rectangle de remplissage est défini par un décalage en pourcentage par rapport au bord correspondant de la boîte englobante de la forme. Un pourcentage positif indique un retrait, un pourcentage négatif indique un débordement.  

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).  
2. Obtenez la référence d’une diapositive par son indice.  
3. Ajoutez un rectangle `AutoShape`.  
4. Créez une image.  
5. Définissez le type de remplissage de la forme.  
6. Définissez le mode de remplissage d’image de la forme.  
7. Ajoutez l’image de remplissage à la forme.  
8. Spécifiez les décalages d’image par rapport au bord correspondant de la boîte englobante de la forme.  
9. Enregistrez la présentation modifiée sous forme de fichier PPTX.  

Ce code PHP montre un processus où la propriété StretchOff est utilisée :
```php
  # Instancie la classe Presentation qui représente un fichier PPTX
  $pres = new Presentation();
  try {
    # Récupère la première diapositive
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
    # Spécifie les décals d'image par rapport au bord correspondant de la boîte englobante de la forme
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

**How can I find out which image formats are supported for PictureFrame?**  

Aspose.Slides prend en charge à la fois les images raster (PNG, JPEG, BMP, GIF, etc.) et les images vectorielles (par exemple SVG) via l’objet image assigné à un [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/). La liste des formats pris en charge se recoupe généralement avec les capacités du moteur de conversion de diapositives et d’images.  

**How will adding dozens of large images affect PPTX size and performance?**  

L’incorporation d’images volumineuses augmente la taille du fichier et la consommation de mémoire ; le lien d’images permet de réduire la taille de la présentation mais nécessite que les fichiers externes restent accessibles. Aspose.Slides offre la possibilité d’ajouter des images par lien pour diminuer la taille du fichier.  

**How can I lock an image object from accidental moving/resizing?**  

Utilisez les [shape locks](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/getpictureframelock/) pour un [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) (par exemple, désactiver le déplacement ou le redimensionnement). Le mécanisme de verrouillage est pris en charge pour divers types de formes, y compris les [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/).  

**Is SVG vector fidelity preserved when exporting a presentation to PDF/images?**  

Aspose.Slides permet d’extraire un SVG d’un [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) sous forme de vecteur original. Lors de l’[exportation vers PDF](/slides/fr/php-java/convert-powerpoint-to-pdf/) ou les [formats raster](/slides/fr/php-java/convert-powerpoint-to-png/), le résultat peut être rasterisé selon les paramètres d’exportation ; le fait que le SVG original soit stocké en tant que vecteur est confirmé par le comportement d’extraction.