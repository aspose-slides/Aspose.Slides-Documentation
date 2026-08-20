---
title: Gérer les cadres d'image dans les présentations avec JavaScript
linktitle: Cadre d'image
type: docs
weight: 10
url: /fr/nodejs-java/picture-frame/
keywords:
- cadre d'image
- ajouter un cadre d'image
- créer un cadre d'image
- image incorporée
- image liée
- extraire l'image
- image raster
- image SVG
- rogner l'image
- supprimer les zones recadrées
- compresser l'image
- StretchOffset
- formatage du cadre d'image
- échelle relative
- effet d'image
- ratio d'aspect
- PowerPoint
- OpenDocument
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Créer, formater, lier, rogner, extraire et compresser des cadres d'image dans les présentations avec Aspose.Slides pour Node.js via JavaScript."
---
## **Vue d'ensemble**

Un cadre d'image est une forme de diapositive qui affiche une image. Dans Aspose.Slides, la ressource d'image et la forme qui l'affiche sont des objets distincts : une [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/) possède les ressources d'image incorporées via sa [ImageCollection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/imagecollection/), tandis qu'un [PictureFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/pictureframe/) contrôle la position, la taille, le format de ligne, la rotation, le recadrage, les effets d'image et d'autres paramètres au niveau du cadre.

Cette séparation est utile lorsque la même image est affichée plusieurs fois. Ajoutez l'image à la présentation une seule fois, conservez le [PPImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ppimage/) retourné et utilisez cette ressource d'image lors de la création de cadres d'image.

Les cadres d'image peuvent contenir des images matricielles comme PNG ou JPEG ainsi que des images vectorielles SVG. Ils peuvent également référencer des images liées au lieu de stocker les octets de l'image dans la présentation. Ce choix influence la portabilité, la taille du fichier, l'extraction et le comportement d'exportation, il est donc utile de décider comment l'image doit être stockée avant d'appliquer le formatage ou l'optimisation.

## **Ajouter et formater une image incorporée**

Pour une image incorporée, ajoutez les données de l'image à la présentation et créez un cadre d'image avec [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shapecollection/#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-). L'image devient partie du package de la présentation, de sorte que la présentation reste autonome lorsqu'elle est déplacée vers un autre ordinateur.

L'exemple suivant ajoute une image PNG, crée un cadre aux dimensions natives de l'image et applique un format de ligne ainsi qu'une rotation :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    pictureFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pictureFrame.getLineFormat().setWidth(3);
    pictureFrame.setRotation(15);

    presentation.save("picture-frame.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le cadre d'image contrôle la géométrie affichée ; modifier la taille du cadre ne change pas les dimensions en pixels originales stockées dans la ressource d'image incorporée. Cette distinction devient importante lorsqu'on recadre ou compresse une image ultérieurement.

## **Utiliser l'échelle relative**

[PictureFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/pictureframe/) expose le redimensionnement relatif de la largeur et de la hauteur du cadre via [setRelativeScaleWidth](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleWidth-float-) et [setRelativeScaleHeight](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleHeight-float-). Une valeur de `1.0` correspond à 100 % de la taille originale de l'image. L'échelle relative est utile lorsqu'un flux de travail doit préserver une relation avec la taille de l'image source au lieu de calculer manuellement les dimensions finales.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 100, image);
    pictureFrame.setRelativeScaleWidth(java.newFloat(1.35));
    pictureFrame.setRelativeScaleHeight(java.newFloat(0.8));

    presentation.save("relative-scale.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

L'échelle relative modifie les paramètres de mise à l'échelle du cadre ; elle ne rééchantillonne pas et ne compresse pas l'image incorporée.

## **Images incorporées et liées**

Une image incorporée stocke les données d'image à l'intérieur de la présentation et constitue donc le choix le plus sûr pour la portabilité et un rendu prévisible. Une image liée stocke un emplacement externe via la méthode [Picture.setLinkPathLong](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/picture/#setLinkPathLong-java.lang.String-) au lieu d'incorporer les données de l'image de la même manière.

Les images liées peuvent réduire la quantité de données d'image stockées dans le PPTX, mais elles introduisent une dépendance externe. Le fichier lié doit rester accessible à l'application qui ouvre ou rend la présentation. Si le chemin change, le fichier est déplacé ou la ressource n'est plus disponible, l'image liée peut ne pas s'afficher comme prévu. Pour les présentations qui doivent être envoyées par courriel, archivées ou rendues dans des environnements isolés, les images incorporées sont généralement plus fiables.

### **Ajouter une image liée**

L'exemple suivant crée un cadre d'image et le pointe vers un fichier image local. Il ne traite que le lien d'image ; le lien vidéo est un flux média séparé et n'est volontairement pas mêlé à cet exemple.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const path = require("path");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 180, null);
    const linkPath = path.resolve("image.png");
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong(linkPath);

    presentation.save("linked-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Utilisez les liens lorsque la gestion de fichiers externes est intentionnelle. Ne les utilisez pas simplement comme un remplacement de la compression : un petit PPTX avec des dépendances d'image cassées est généralement moins utile qu'une présentation plus grande et autonome.

## **Extraire des images à partir de cadres d'image**

Avant d'extraire une image d'une présentation existante, vérifiez qu'une forme est réellement un [PictureFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/pictureframe/) et qu'elle contient une image incorporée. Les cadres d'image liés peuvent ne pas contenir d'octets d'image pouvant être extraits de la même manière.

### **Extraire une image raster**

L'API d'image moderne utilise directement [IImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/iimage/). L'exemple suivant trouve la première image raster incorporée sur une diapositive et l'enregistre au format PNG :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            continue;
        }

        const embeddedImage = shape.getPictureFormat().getPicture().getImage();
        if (embeddedImage == null || embeddedImage.getSvgImage() != null) {
            continue;
        }

        const rasterImage = embeddedImage.getImage();
        try {
            rasterImage.save("extracted-image.png", aspose.slides.ImageFormat.Png);
        } finally {
            rasterImage.dispose();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

Sauvegarder via [IImage.save](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/iimage/#save) convertit l'image extraite vers le format de sortie demandé. Si vous avez besoin des octets encodés stockés dans la présentation plutôt que d'un fichier raster converti, utilisez les données binaires de la ressource image à la place.

### **Extraire une image SVG**

Pour une image SVG, le [PPImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ppimage/) expose un objet [SvgImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/svgimage/). Cela vous permet de récupérer les données SVG directement au lieu de rasteriser d'abord l'image.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            continue;
        }

        const embeddedImage = shape.getPictureFormat().getPicture().getImage();
        const svgImage = embeddedImage != null ? embeddedImage.getSvgImage() : null;
        if (svgImage == null) {
            continue;
        }

        fs.writeFileSync("extracted-image.svg", svgImage.getSvgData());
        break;
    }
} finally {
    presentation.dispose();
}
```

Conserver le contenu SVG en tant que SVG préserve la source vectorielle à l'intérieur de la présentation. Les exportations raster telles que PNG ou JPEG rendent obligatoirement ce contenu vectoriel en pixels. L'exportation de diapositive au format PDF ou SVG est également une opération de rendu, de sorte que les graphiques exportés ne doivent pas être considérés comme une copie octet pour octet de l'SVG incorporé original ; utilisez les données de [SvgImage.getSvgData](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/svgimage/#getSvgData--) lorsque la ressource vectorielle originale est requise.

## **Rogner une image**

Le recadrage change la partie de l'image visible à l'intérieur du cadre. Les valeurs de recadrage sur [PictureFillFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/picturefillformat/) sont des pourcentages des dimensions de l'image source. Le recadrage ne supprime pas initialement les pixels masqués de l'image incorporée ; il ne fait que modifier la région visible.

L'exemple suivant trouve un cadre d'image de façon sécurisée et applique des valeurs de recadrage :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        pictureFrame.getPictureFormat().setCropLeft(java.newFloat(23.6));
        pictureFrame.getPictureFormat().setCropRight(java.newFloat(21.5));
        pictureFrame.getPictureFormat().setCropTop(java.newFloat(3));
        pictureFrame.getPictureFormat().setCropBottom(java.newFloat(31));
        presentation.save("cropped-image.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Comme les données d'image cachées sont toujours présentes, le recadrage peut être modifié ultérieurement sans perdre les pixels originaux. Si la taille du fichier compte plus que la réversibilité, les zones recadrées peuvent être physiquement supprimées comme décrit dans la section suivante.

## **Supprimer les données d'image recadrées**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) supprime les données d'image situées en dehors du rectangle de recadrage actuel et renvoie la ressource d'image résultante. Cela peut réduire la taille du fichier, mais c'est une optimisation destructive : après la sauvegarde de la présentation, les pixels supprimés ne sont plus disponibles pour une opération de décrochage ultérieure.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const croppedImage = pictureFrame.getPictureFormat().deletePictureCroppedAreas();
        if (croppedImage != null) {
            presentation.save("cropped-data-removed.pptx", aspose.slides.SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

La méthode peut ajouter une nouvelle ressource d'image à la présentation. Si l'image originale est également utilisée par d'autres cadres d'image, ces cadres ont toujours besoin de leur ressource existante, de sorte que la suppression des zones recadrées ne réduit pas nécessairement le nombre total d'images. Recadrer du contenu WMF ou EMF avec cette méthode rasterise le résultat recadré en PNG.

## **Compresser les images raster**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) réduit la résolution d'image raster par rapport à la taille à laquelle l'image est affichée. Elle peut également supprimer les zones recadrées dans la même opération. La méthode renvoie `true` lorsque l'image a été redimensionnée ou recadrée et `false` lorsqu'aucun changement n'était nécessaire.

Utilisez une valeur prédéfinie de [PicturesCompression](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/picturescompression/) lorsque une résolution cible standard suffit :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const compressed = pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi150);
        console.log(compressed ? "The image was compressed." : "No compression was necessary.");
        presentation.save("compressed-image.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Une valeur DPI positive personnalisée peut être passée à la place d'une valeur prédéfinie lorsqu'une cible spécifique est requise.

La compression est destinée aux images raster. Le contenu SVG et les métadonnées ne sont pas réduits par ce flux de travail de compression raster. Gardez également à l'esprit que la résolution plus basse et les zones recadrées supprimées ne peuvent pas être récupérées à partir de la présentation optimisée. Choisissez une résolution cible en fonction de la plus grande taille à laquelle l'image sera réellement visualisée ou exportée, plutôt que d'appliquer le DPI le plus bas globalement.

## **Inspecter les effets d'image**

Les effets d'image sont stockés sur l'image utilisée par le cadre. La collection de transformations d'image peut contenir des effets tels que la modulation d'alpha fixe pour la transparence et la luminance pour la luminosité et le contraste. L'exemple ci‑dessous lit en toute sécurité les deux types d'effets depuis le premier cadre d'image d'une diapositive :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        for (let i = 0; i < imageTransform.size(); i++) {
            const effect = imageTransform.get_Item(i);
            if (java.instanceOf(effect, "com.aspose.slides.IAlphaModulateFixed")) {
                const transparency = 100 - effect.getAmount();
                console.log("Transparency: " + transparency);
            }

            if (java.instanceOf(effect, "com.aspose.slides.ILuminance")) {
                const luminance = effect.getEffective();
                console.log("Brightness: " + luminance.getBrightness());
                console.log("Contrast: " + luminance.getContrast());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Ces effets modifient la façon dont l'image est rendue dans le cadre ; ils ne réécrivent pas les octets originaux de l'image incorporée.

## **Verrouiller la géométrie du cadre d'image**

Les paramètres du [PictureFrameLock](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/pictureframelock/) contrôlent quelles opérations d'édition sont désactivées pour un cadre d'image. Par exemple, [setAspectRatioLocked](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) préserve les proportions de la forme lorsqu'elle est redimensionnée.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);

    presentation.save("locked-picture-frame.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le verrou s'applique à la forme du cadre d'image. Il ne force pas l'image source à être rééchantillonnée ou modifiée de façon permanente pour correspondre au même ratio d'aspect.

## **Ajuster les valeurs StretchOffset**

Lorsque le mode de remplissage d'image est « stretch », les valeurs stretch‑offset sur [PictureFillFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/picturefillformat/) définissent le rectangle de remplissage par rapport à la boîte englobante du cadre d'image. Des pourcentages positifs créent un retrait depuis un bord, tandis que des pourcentages négatifs créent un dépassement.

Ceci est différent du recadrage. Les valeurs de recadrage sélectionnent quelle partie de l'image source est visible ; les offsets de stretch modifient le rectangle dans lequel le remplissage d'image visible est étiré.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 400, 300, image);
    pictureFrame.getPictureFormat().setPictureFillMode(java.newByte(aspose.slides.PictureFillMode.Stretch));
    pictureFrame.getPictureFormat().setStretchOffsetLeft(java.newFloat(12));
    pictureFrame.getPictureFormat().setStretchOffsetRight(java.newFloat(12));
    pictureFrame.getPictureFormat().setStretchOffsetTop(java.newFloat(8));
    pictureFrame.getPictureFormat().setStretchOffsetBottom(java.newFloat(8));

    presentation.save("stretch-offsets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Utilisez les offsets de stretch pour le placement du remplissage. Utilisez les propriétés de recadrage lorsque l'objectif est de masquer les bords de l'image source.

## **Considérations de stockage, de taille de fichier et d'exportation**

Les principaux compromis sont plus faciles à gérer lorsque le stockage d'image et le formatage du cadre d'image sont traités séparément :

- **Images incorporées** rendent la présentation autonome et sont les plus fiables pour le partage et le rendu côté serveur, mais les grandes images raster augmentent la taille du PPTX et la consommation de mémoire.
- **Images liées** peuvent garder le package plus petit, mais la présentation dépend de la disponibilité continue des fichiers externes aux chemins ou emplacements stockés.
- **Recadrage** est initialement non destructif. Les pixels masqués restent incorporés jusqu'à ce que les zones recadrées soient explicitement supprimées ou retirées lors de la compression.
- **Compression** peut réduire considérablement la taille du fichier pour les images raster surdimensionnées, mais elle sacrifie la résolution source. Elle doit être appliquée après que la taille finale sur la diapositive soit connue.
- **Images SVG** doivent rester au format SVG quand la préservation du vecteur est importante. Extrayez le SVG incorporé directement lorsque vous avez besoin de la ressource vectorielle elle‑même. Les exportations de diapositive en raster comme PNG ou JPEG convertissent toujours la diapositive rendue en pixels.
- **Images répétées** doivent réutiliser une ressource [PPImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ppimage/) existante chaque fois que possible au lieu de charger à nouveau le même fichier dans le flux de travail de la présentation.

Pour les présentations volumineuses, l'optimisation d'image est généralement la plus efficace lorsqu'elle est effectuée de manière sélective : conservez les logos et diagrammes en contenu vectoriel, compressez les photographies selon leur taille d'affichage réelle, supprimez les pixels recadrés uniquement lorsque les modifications ultérieures ne sont pas nécessaires, et évitez les liens externes sauf si la gestion des dépendances fait partie de la conception du déploiement.

## **FAQ**

**Quelle est la différence entre un cadre d'image et une ressource d'image ?**

Un [PPImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ppimage/) représente une ressource d'image associée à la présentation. Un [PictureFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/pictureframe/) est une forme sur une diapositive qui affiche une image et stocke la géométrie et le formatage au niveau du cadre tels que la taille, la rotation, les valeurs de recadrage, les effets et les verrous.

**Dois‑je incorporer ou lier les images ?**

Incorporez les images lorsque la présentation doit être portable, archivée ou rendue sans accès aux ressources externes. Liez les images uniquement lorsque le fait de garder les fichiers d'image à l'extérieur du PPTX est intentionnel et que les emplacements externes peuvent être maintenus de façon fiable.

**Le recadrage réduit‑il la taille du fichier PPTX ?**

Pas en soi. Les paramètres de recadrage normal masquent des parties de l'image source tout en conservant les pixels sous‑jacents. Utilisez [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) ou la compression d'image avec suppression des zones recadrées lorsque ces pixels peuvent être supprimés de façon permanente.

**Puis‑je restaurer la qualité de l'image après la compression ?**

Non. La compression peut réduire la résolution raster stockée, et la suppression des zones recadrées élimine des données d'image. Conservez l'image source originale en dehors de la présentation si un futur travail en haute résolution peut être nécessaire.

**Comment doit‑on gérer les images SVG ?**

Conservez le contenu SVG en tant que SVG lorsque la fidélité vectorielle est importante. Le [SvgImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/svgimage/) incorporé peut être extrait directement. Rendre une diapositive vers un format raster tel que PNG ou JPEG rasterise le SVG dans le cadre de l'image de la diapositive.

**Comment éviter les castings dangereux lors de la lecture de diapositives existantes ?**

Vérifiez le type de forme avant d'utiliser les membres spécifiques au cadre d'image. Un contrôle `java.instanceOf` contre [PictureFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/pictureframe/) évite les castings invalides et permet au code de gérer les diapositives ne contenant pas de cadres d'image.