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
- image intégrée
- image liée
- extraire l'image
- image raster
- image SVG
- rogner l'image
- supprimer les zones rognées
- compresser l'image
- StretchOffset
- formatage du cadre d'image
- échelle relative
- effet d'image
- rapport d'aspect
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Créer, formater, lier, rogner, extraire et compresser les cadres d'image dans les présentations avec Aspose.Slides pour PHP via Java."
---
## **Vue d'ensemble**

Un cadre d'image est une forme de diapositive qui affiche une image. Dans Aspose.Slides, la ressource d'image et la forme qui l'affiche sont des objets séparés : un [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/) possède des ressources d'images intégrées via sa [ImageCollection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/imagecollection/), tandis qu'un [PictureFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/pictureframe/) contrôle la position, la taille, le format de ligne, la rotation, le rognage, les effets d'image et d'autres paramètres au niveau du cadre.

Cette séparation est utile lorsque la même image est affichée plusieurs fois. Ajoutez l'image à la présentation une fois, conservez le [PPImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/ppimage/) retourné, et utilisez cette ressource d'image lors de la création de cadres d'image.

Les cadres d'image peuvent contenir des images raster telles que PNG ou JPEG ainsi que des images vectorielles SVG. Ils peuvent également référencer des images liées au lieu de stocker les octets de l'image dans la présentation. Ce choix affecte la portabilité, la taille du fichier, l'extraction et le comportement d'exportation, il est donc utile de décider comment l'image doit être stockée avant d'appliquer le formatage ou l'optimisation.

## **Ajouter et formater une image intégrée**

Pour une image intégrée, ajoutez les données de l'image à la présentation et créez un cadre d'image avec [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shapecollection/addpictureframe/). L'image devient alors partie du package de la présentation, de sorte que la présentation reste autonome lorsqu'elle est déplacée vers un autre ordinateur.

L'exemple suivant ajoute une image JPEG, crée un cadre aux dimensions natives de l'image et applique un format de ligne ainsi qu'une rotation :

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 100, $image->getWidth(), $image->getHeight(), $image);
    $pictureFrame->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $pictureFrame->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pictureFrame->getLineFormat()->setWidth(3);
    $pictureFrame->setRotation(15);

    $presentation->save("picture-frame.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le cadre d'image contrôle la géométrie affichée ; modifier la taille du cadre ne change pas les dimensions en pixels originales stockées dans la ressource d'image intégrée. Cette distinction devient importante lors du rognage ou de la compression d'une image ultérieurement.

## **Utiliser l'échelle relative**

[PictureFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/pictureframe/) expose le redimensionnement relatif de la largeur et de la hauteur du cadre via [setRelativeScaleWidth](https://reference.aspose.com/slides/fr/php-java/aspose.slides/pictureframe/setrelativescalewidth/) et [setRelativeScaleHeight](https://reference.aspose.com/slides/fr/php-java/aspose.slides/pictureframe/setrelativescaleheight/). Une valeur de `1.0` correspond à 100 % de la taille originale de l'image. L'échelle relative est utile lorsqu'un flux de travail doit conserver une relation avec la taille source de l'image au lieu de calculer manuellement les dimensions finales.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, $image);
    $pictureFrame->setRelativeScaleWidth(1.35);
    $pictureFrame->setRelativeScaleHeight(0.8);

    $presentation->save("relative-scale.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

L'échelle relative modifie les réglages d'échelle du cadre ; elle ne rééchantillonne pas et ne compresse pas l'image intégrée.

## **Images intégrées et liées**

Une image intégrée stocke les données de l'image à l'intérieur de la présentation et constitue donc le choix le plus sûr pour la portabilité et un rendu prévisible. Une image liée stocke un emplacement externe via la méthode [Picture::setLinkPathLong](https://reference.aspose.com/slides/fr/php-java/aspose.slides/picture/setlinkpathlong/) au lieu d'intégrer les données de l'image de la même façon.

Les images liées peuvent réduire la quantité de données d'image stockées dans le PPTX, mais elles introduisent une dépendance externe. Le fichier lié doit rester accessible à l'application qui ouvre ou rend la présentation. Si le chemin change, le fichier est déplacé ou la ressource n'est plus disponible, l'image liée peut ne pas s'afficher comme prévu. Pour les présentations qui doivent être envoyées par courriel, archivées ou rendues dans des environnements isolés, les images intégrées sont généralement plus fiables.

### **Ajouter une image liée**

L'exemple suivant crée un cadre d'image et le pointe vers un fichier image local. Il ne traite que du lien d'image ; le lien vidéo est un flux média distinct et n'est pas mélangé dans cet exemple.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 320, 180, null);
    $linkedImageFile = new Java("java.io.File", "linked-image.jpg");
    $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong($linkedImageFile->getAbsolutePath());

    $presentation->save("linked-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Utilisez les liens lorsque la gestion de fichiers externes est intentionnelle. Ne les utilisez pas simplement comme substitut à la compression : un petit PPTX avec des dépendances d'image cassées est généralement moins utile qu'une présentation plus grande et autonome.

## **Extraire des images depuis les cadres d'image**

Avant d'extraire une image d'une présentation existante, vérifiez qu'une forme est bien un [PictureFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/pictureframe/) et qu'elle contient une image intégrée. Les cadres d'image liés peuvent ne pas contenir les octets d'image qui peuvent être extraits de la même façon.

### **Extraire une image raster**

L'API d'image moderne utilise directement [IImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/iimage/). L'exemple suivant trouve la première image raster intégrée sur une diapositive et l'enregistre au format PNG :

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (!java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            continue;
        }

        $embeddedImage = $shape->getPictureFormat()->getPicture()->getImage();
        if (java_is_null($embeddedImage) || !java_is_null($embeddedImage->getSvgImage())) {
            continue;
        }

        $rasterImage = $embeddedImage->getImage();
        try {
            $rasterImage->save("extracted-image.png", ImageFormat::Png);
        } finally {
            if (!java_is_null($rasterImage)) {
                $rasterImage->dispose();
            }
        }
        break;
    }
} finally {
    $presentation->dispose();
}
```

En enregistrant via [IImage::save](https://reference.aspose.com/slides/fr/php-java/aspose.slides/iimage/#save), l'image extraite est convertie au format de sortie demandé. Si vous avez besoin des octets codés stockés dans la présentation plutôt qu'un fichier raster converti, utilisez les données binaires de la ressource d'image à la place.

### **Extraire une image SVG**

Pour une image SVG, le [PPImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/ppimage/) expose un objet [SvgImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/svgimage/). Cela vous permet de récupérer les données SVG directement au lieu de rasteriser d'abord l'image.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (!java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            continue;
        }

        $embeddedImage = $shape->getPictureFormat()->getPicture()->getImage();
        $svgImage = java_is_null($embeddedImage) ? null : $embeddedImage->getSvgImage();
        if ($svgImage === null || java_is_null($svgImage)) {
            continue;
        }

        $outputStream = new Java("java.io.FileOutputStream", "extracted-image.svg");
        try {
            $outputStream->write($svgImage->getSvgData());
        } finally {
            $outputStream->close();
        }
        break;
    }
} finally {
    $presentation->dispose();
}
```

Conserver le contenu SVG en tant que SVG préserve la source vectorielle à l'intérieur de la présentation. Les exportations raster telles que PNG ou JPEG rendent nécessairement ce contenu vectoriel en pixels. L'exportation de diapositives en PDF ou SVG est également une opération de rendu, de sorte que les graphiques exportés ne doivent pas être considérés comme une copie octet à octet du SVG intégré original ; utilisez les données [SvgImage::getSvgData](https://reference.aspose.com/slides/fr/php-java/aspose.slides/svgimage/getsvgdata/) lorsque la ressource vectorielle elle‑même est requise.

## **Rogner une image**

Le rognage change la partie de l'image visible à l'intérieur du cadre. Les valeurs de rognage sur [PictureFillFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/picturefillformat/) sont des pourcentages des dimensions de l'image source. Le rognage ne supprime pas initialement les pixels cachés de l'image intégrée ; il ne fait que modifier la région visible.

L'exemple suivant trouve un cadre d'image en toute sécurité et applique des valeurs de rognage :

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $pictureFrame->getPictureFormat()->setCropLeft(23.6);
        $pictureFrame->getPictureFormat()->setCropRight(21.5);
        $pictureFrame->getPictureFormat()->setCropTop(3);
        $pictureFrame->getPictureFormat()->setCropBottom(31);
        $presentation->save("cropped-image.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Comme les données d'image cachées sont toujours présentes, le rognage peut être modifié ultérieurement sans perdre les pixels originaux. Si la taille du fichier est plus importante que la réversibilité, les zones rognées peuvent être supprimées physiquement comme décrit dans la section suivante.

## **Supprimer les données d'image rognées**

[PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/fr/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) supprime les données d'image en dehors du rectangle de rognage actuel et renvoie la ressource d'image résultante. Cela peut réduire la taille du fichier, mais il s'agit d'une optimisation destructive : après l'enregistrement de la présentation, les pixels supprimés ne sont plus disponibles pour une opération de dé‑rognage ultérieure.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("cropped-image.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $croppedImage = $pictureFrame->getPictureFormat()->deletePictureCroppedAreas();
        if (!java_is_null($croppedImage)) {
            $presentation->save("cropped-data-removed.pptx", SaveFormat::Pptx);
        }
    }
} finally {
    $presentation->dispose();
}
```

La méthode peut ajouter une nouvelle ressource d'image à la présentation. Si l'image originale est également utilisée par d'autres cadres d'image, ces cadres ont encore besoin de leur ressource existante, de sorte que la suppression des zones rognées ne réduit pas nécessairement le nombre total d'images. Rogner du contenu WMF ou EMF avec cette méthode rasterise le résultat rogné en PNG.

## **Compresser les images raster**

[PictureFillFormat::compressImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) réduit la résolution d'image raster par rapport à la taille à laquelle l'image est affichée. Elle peut également supprimer les zones rognées dans la même opération. La méthode renvoie `true` lorsque l'image a été redimensionnée ou rognée et `false` lorsqu'aucune modification n'était nécessaire.

Utilisez une valeur prédéfinie de [PicturesCompression](https://reference.aspose.com/slides/fr/php-java/aspose.slides/picturescompression/) lorsqu'une résolution cible standard suffit :

```php
use aspose\slides\PicturesCompression;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $compressed = $pictureFrame->getPictureFormat()->compressImage(true, PicturesCompression::Dpi150);
        echo $compressed ? "The image was compressed." : "No compression was necessary.";
        $presentation->save("compressed-image.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Une valeur DPI personnalisée positive peut être passée à la place d'une valeur prédéfinie lorsqu'une cible spécifique est requise.

La compression est destinée aux images raster. Le contenu SVG et métas fichiers n'est pas réduit par ce flux de compression raster. Gardez également à l'esprit que la résolution inférieure et les zones rognées supprimées ne peuvent pas être récupérées à partir de la présentation optimisée. Choisissez une résolution cible en fonction de la plus grande taille à laquelle l'image sera réellement visualisée ou exportée, plutôt que d'appliquer le DPI le plus bas globalement.

## **Gérer les effets de transformation d'image**

Pour un flux de travail complet couvrant la luminosité, le contraste, les transformations de couleur, le flou, les effets d'alpha, les chaînes ordonnées, l'inspection, la suppression et la vérification en aller‑retour, voir [Image Transform Effects](/slides/fr/php-java/image-transform-effects/).

## **Verrouiller la géométrie du cadre d'image**

Les paramètres de [PictureFrameLock](https://reference.aspose.com/slides/fr/php-java/aspose.slides/pictureframelock/) contrôlent quelles opérations de modification sont désactivées pour un cadre d'image. Par exemple, [setAspectRatioLocked](https://reference.aspose.com/slides/fr/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) préserve les proportions de la forme lorsqu'elle est redimensionnée.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 100, $image->getWidth(), $image->getHeight(), $image);
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);

    $presentation->save("locked-picture-frame.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le verrou s'applique à la forme du cadre d'image. Il ne force pas l'image source à être rééchantillonnée ou modifiée définitivement pour correspondre au même rapport d'aspect.

## **Ajuster les valeurs StretchOffset**

Lorsque le mode de remplissage d'image est étiré, les valeurs stretch‑offset sur [PictureFillFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/picturefillformat/) définissent le rectangle de remplissage par rapport à la boîte englobante du cadre d'image. Des pourcentages positifs créent un retrait depuis le bord, tandis que des pourcentages négatifs créent un débordement.

Ceci diffère du rognage. Les valeurs de rognage sélectionnent la partie de l'image source visible ; les offsets d'étirement changent le rectangle dans lequel le remplissage d'image visible est étiré.

```php
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 400, 300, $image);
    $pictureFrame->getPictureFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $pictureFrame->getPictureFormat()->setStretchOffsetLeft(12);
    $pictureFrame->getPictureFormat()->setStretchOffsetRight(12);
    $pictureFrame->getPictureFormat()->setStretchOffsetTop(8);
    $pictureFrame->getPictureFormat()->setStretchOffsetBottom(8);

    $presentation->save("stretch-offsets.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Utilisez les offsets d'étirement pour le placement du remplissage. Utilisez les propriétés de rognage lorsque le but est de masquer les bords de l'image source.

## **Stockage, taille du fichier et considérations d'exportation**

Les principaux compromis sont plus faciles à gérer lorsque le stockage des images et le formatage du cadre d'image sont traités séparément :

- **Images intégrées** rendent la présentation autonome et sont les plus fiables pour le partage et le rendu côté serveur, mais les grandes images raster augmentent la taille du PPTX et l'utilisation de la mémoire.
- **Images liées** peuvent garder le package plus petit, mais la présentation dépend de la disponibilité continue des fichiers externes aux chemins ou emplacements stockés.
- **Rognage** est initialement non destructif. Les pixels cachés restent intégrés jusqu'à ce que les zones rognées soient explicitement supprimées ou retirées lors de la compression.
- **Compression** peut réduire considérablement la taille du fichier pour les images raster surdimensionnées, mais elle sacrifie la résolution source. Elle doit être appliquée après que la taille prévue sur la diapositive soit connue.
- **Images SVG** doivent rester au format SVG lorsque la préservation vectorielle est importante. Extrayez le SVG intégré directement lorsque vous avez besoin de la ressource vectorielle elle‑même. Les exportations de diapositives en raster convertissent toujours la diapositive rendue en pixels.
- **Images répétées** doivent réutiliser une ressource [PPImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/ppimage/) existante lorsqu'il est possible, au lieu de charger à plusieurs reprises le même fichier dans le flux de travail de la présentation.

Pour les présentations volumineuses, l'optimisation des images est généralement la plus efficace lorsqu'elle est effectuée sélectivement : conservez les logos et les diagrammes comme contenu vectoriel, compressez les photographies selon leur taille d'affichage réelle, supprimez les pixels rognés uniquement lorsque l'édition ultérieure n'est pas requise, et évitez les liens externes sauf si la gestion des dépendances fait partie de la conception du déploiement.

## **FAQ**

**Quelle est la différence entre un cadre d'image et une ressource d'image ?**

Un [PPImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/ppimage/) représente une ressource d'image associée à la présentation. Un [PictureFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/pictureframe/) est une forme sur une diapositive qui affiche une image et stocke la géométrie ainsi que le formatage au niveau du cadre, tels que la taille, la rotation, les valeurs de rognage, les effets et les verrouillages.

**Dois‑je intégrer ou lier les images ?**

Intégrez les images lorsque la présentation doit être portable, archivée ou rendue sans accès à des ressources externes. Liez les images uniquement lorsque le maintien des fichiers image en dehors du PPTX est intentionnel et que les emplacements externes peuvent être gérés de façon fiable.

**Le rognage réduit‑il la taille du fichier PPTX ?**

Pas en soi. Les paramètres de rognage standard masquent des parties de l'image source mais conservent les pixels sous‑jacents. Utilisez [PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/fr/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) ou la compression d'image avec suppression des zones rognées lorsque ces pixels peuvent être éliminés définitivement.

**Puis‑je restaurer la qualité de l'image après compression ?**

Non. La compression peut réduire la résolution raster stockée, et la suppression des zones rognées élimine les données d'image. Conservez l'image source originale en dehors de la présentation si une édition à haute résolution peut être requise plus tard.

**Comment les images SVG doivent‑elles être gérées ?**

Conservez le contenu SVG en tant que SVG lorsque la fidélité vectorielle est importante. Le [SvgImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/svgimage/) intégré peut être extrait directement. Rendre une diapositive en format raster tel que PNG ou JPEG rasterise le SVG comme partie de l'image de la diapositive.

**Comment éviter les casts dangereux lors de la lecture de diapositives existantes ?**

Vérifiez le type de forme avant d'utiliser les membres spécifiques aux cadres d'image. Un test `java_instanceof` contre [PictureFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/pictureframe/) évite les casts invalides et permet au code de gérer les diapositives qui ne contiennent pas de cadres d'image.