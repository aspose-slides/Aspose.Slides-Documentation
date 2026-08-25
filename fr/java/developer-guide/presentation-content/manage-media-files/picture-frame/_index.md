---
title: Gérer les cadres d'image dans les présentations en Java
linktitle: Cadre d'image
type: docs
weight: 10
url: /fr/java/picture-frame/
keywords:
- cadre d'image
- ajouter cadre d'image
- créer cadre d'image
- image incorporée
- image liée
- extraire image
- image matricielle
- image SVG
- recadrer image
- supprimer zones recadrées
- compresser image
- StretchOffset
- formatage du cadre d'image
- échelle relative
- effet d'image
- ratio d'aspect
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Créer, formater, lier, recadrer, extraire et compresser des cadres d'image dans les présentations avec Aspose.Slides pour Java."
---
## **Vue d'ensemble**

Un cadre d’image est une forme de diapositive qui affiche une image. Dans Aspose.Slides, la ressource image et la forme qui l’affiche sont des objets distincts : une [Présentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/) possède des ressources image intégrées via son [IImageCollection](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iimagecollection/), tandis qu’un [IPictureFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipictureframe/) contrôle la position, la taille, le format de ligne, la rotation, le recadrage, les effets d’image et d’autres paramètres au niveau du cadre.

Cette séparation est utile lorsqu’une même image est affichée plusieurs fois. Ajoutez l’image à la présentation une fois, conservez l’[IPPImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ippimage/) retourné, et utilisez cette ressource image lors de la création de cadres d’image.

Les cadres d’image peuvent contenir des images matricielles telles que PNG ou JPEG ainsi que des images vectorielles SVG. Ils peuvent également faire référence à des images liées au lieu de stocker les octets de l’image dans la présentation. Ce choix influence la portabilité, la taille du fichier, l’extraction et le comportement d’exportation, il est donc utile de décider comment l’image doit être stockée avant d’appliquer le formatage ou l’optimisation.

## **Ajouter et formater une image incorporée**

Pour une image incorporée, ajoutez les données d’image à la présentation et créez un cadre d’image avec [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-). L’image devient alors partie du paquet de la présentation, de sorte que la présentation reste autonome lorsqu’elle est déplacée vers un autre ordinateur.

L’exemple suivant ajoute une image JPEG, crée un cadre aux dimensions natives de l’image et applique un format de ligne ainsi qu’une rotation :

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pictureFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pictureFrame.getLineFormat().setWidth(3);
    pictureFrame.setRotation(15);

    presentation.save("picture-frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le cadre d’image contrôle la géométrie affichée ; modifier la taille du cadre ne change pas les dimensions en pixels d’origine stockées dans la ressource image incorporée. Cette distinction devient importante lors d’un recadrage ou d’une compression ultérieurs de l’image.

## **Utiliser l’échelle relative**

[IPictureFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipictureframe/) expose le redimensionnement relatif en largeur et en hauteur du cadre via [setRelativeScaleWidth](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) et [setRelativeScaleHeight](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-). Une valeur de `1.0` correspond à 100 % de la taille d’image d’origine. L’échelle relative est utile lorsqu’un flux de travail doit préserver une relation avec la taille source de l’image au lieu de calculer manuellement les dimensions finales.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image);
    pictureFrame.setRelativeScaleWidth(1.35f);
    pictureFrame.setRelativeScaleHeight(0.8f);

    presentation.save("relative-scale.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

L’échelle relative modifie les paramètres d’échelle du cadre ; elle ne rééchantillonne ni ne compresse pas l’image incorporée.

## **Images incorporées et liées**

Une image incorporée stocke les données d’image à l’intérieur de la présentation et constitue donc le choix le plus sûr pour la portabilité et un rendu prévisible. Une image liée stocke un emplacement externe via la méthode [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/fr/java/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) au lieu d’incorporer les données d’image de la même façon.

Les images liées peuvent réduire la quantité de données d’image stockées dans le PPTX, mais elles introduisent une dépendance externe. Le fichier lié doit rester accessible à l’application qui ouvre ou rend la présentation. Si le chemin change, le fichier est déplacé ou la ressource devient indisponible, l’image liée peut ne pas s’afficher comme prévu. Pour les présentations qui doivent être envoyées par e‑mail, archivées ou rendues dans des environnements isolés, les images incorporées sont généralement plus fiables.

### **Ajouter une image liée**

L’exemple suivant crée un cadre d’image et le pointe vers un fichier image local. Il ne traite que la liaison d’image ; la liaison vidéo est un flux média séparé et n’est pas mélangée à cet exemple.

```java
import com.aspose.slides.*;
import java.io.File;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, null);
    File linkedImageFile = new File("linked-image.jpg");
    String linkPath = linkedImageFile.getAbsolutePath();
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong(linkPath);

    presentation.save("linked-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Utilisez les liens lorsque la gestion de fichiers externes est intentionnelle. Ne les utilisez pas simplement comme substitut à la compression : un petit PPTX avec des dépendances d’image cassées est généralement moins utile qu’une présentation plus volumineuse mais autonome.

## **Extraire des images des cadres d’image**

Avant d’extraire une image d’une présentation existante, vérifiez qu’une forme est réellement un [IPictureFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipictureframe/) et qu’elle contient une image incorporée. Les cadres d’image liés peuvent ne pas contenir les octets d’image pouvant être extraits de la même manière.

### **Extraire une image matricielle**

L’API image moderne utilise directement [IImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iimage/) et ne nécessite plus l’ancien wrapper Java. L’exemple suivant trouve la première image matricielle incorporée sur une diapositive et l’enregistre au format PNG :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IPictureFrame)) {
            continue;
        }

        IPictureFrame pictureFrame = (IPictureFrame) shape;
        IPPImage embeddedImage = pictureFrame.getPictureFormat().getPicture().getImage();
        if (embeddedImage == null || embeddedImage.getSvgImage() != null) {
            continue;
        }

        IImage rasterImage = embeddedImage.getImage();
        try {
            rasterImage.save("extracted-image.png", ImageFormat.Png);
        } finally {
            rasterImage.dispose();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

Enregistrez via [IImage.save](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iimage/#save-java.lang.String-int-) pour convertir l’image extraite vers le format de sortie demandé. Si vous avez besoin des octets encodés stockés dans la présentation plutôt que d’un fichier matriciel converti, utilisez les données binaires de la ressource image.

### **Extraire une image SVG**

Pour une image SVG, l’[IPPImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ippimage/) expose un objet [ISvgImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isvgimage/). Cela vous permet de récupérer directement les données SVG au lieu de rasteriser d’abord l’image.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IPictureFrame)) {
            continue;
        }

        IPictureFrame pictureFrame = (IPictureFrame) shape;
        IPPImage embeddedImage = pictureFrame.getPictureFormat().getPicture().getImage();
        ISvgImage svgImage = embeddedImage != null ? embeddedImage.getSvgImage() : null;
        if (svgImage == null) {
            continue;
        }

        byte[] svgData = svgImage.getSvgData();
        FileOutputStream outputStream = new FileOutputStream("extracted-image.svg");
        try {
            outputStream.write(svgData);
        } finally {
            outputStream.close();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

Conserver le contenu SVG en tant que SVG préserve la source vectorielle à l’intérieur de la présentation. Les exportations matricielles telles que PNG ou JPEG rendent nécessairement ce contenu vectoriel en pixels. L’exportation de diapositives en PDF ou SVG est également une opération de rendu, de sorte que les graphiques exportés ne doivent pas être traités comme une copie bit à bit du SVG incorporé d’origine ; utilisez les données de [ISvgImage.getSvgData](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isvgimage/#getSvgData--) lorsque la ressource vectorielle originale elle‑même est requise.

## **Recadrer une image**

Le recadrage détermine quelle partie d’une image est visible à l’intérieur du cadre. Les valeurs de recadrage sur [IPictureFillFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipicturefillformat/) sont exprimées en pourcentage des dimensions de l’image source. Le recadrage ne supprime pas initialement les pixels masqués de l’image incorporée ; il ne change que la région visible.

L’exemple suivant trouve en toute sécurité un cadre d’image et applique des valeurs de recadrage :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        pictureFrame.getPictureFormat().setCropLeft(23.6f);
        pictureFrame.getPictureFormat().setCropRight(21.5f);
        pictureFrame.getPictureFormat().setCropTop(3f);
        pictureFrame.getPictureFormat().setCropBottom(31f);
        presentation.save("cropped-image.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Comme les données d’image masquées sont toujours présentes, le recadrage peut être modifié ultérieurement sans perdre les pixels d’origine. Si la taille du fichier est plus importante que la réversibilité, les régions recadrées peuvent être supprimées physiquement comme décrit dans la section suivante.

## **Supprimer les données d’image recadrées**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) supprime les données d’image situées en dehors du rectangle de recadrage actuel et renvoie la ressource image résultante. Cela peut réduire la taille du fichier, mais il s’agit d’une optimisation destructive : après l’enregistrement de la présentation, les pixels supprimés ne sont plus disponibles pour une opération de décadrage ultérieure.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("cropped-image.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IPPImage croppedImage = pictureFrame.getPictureFormat().deletePictureCroppedAreas();
        if (croppedImage != null) {
            presentation.save("cropped-data-removed.pptx", SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

La méthode peut ajouter une nouvelle ressource image à la présentation. Si l’image d’origine est également utilisée par d’autres cadres d’image, ces cadres conservent toujours leur ressource existante, de sorte que la suppression des zones recadrées ne réduit pas nécessairement le nombre total d’images. Recadrer du contenu WMF ou EMF avec cette méthode rasterise le résultat recadré en PNG.

## **Compresser les images matricielles**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) réduit la résolution d’une image matricielle par rapport à la taille à laquelle l’image est affichée. Elle peut également supprimer les régions recadrées dans la même opération. La méthode renvoie `true` lorsque l’image a été redimensionnée ou recadrée et `false` lorsqu’aucune modification n’était nécessaire.

Utilisez une valeur prédéfinie de [PicturesCompression](https://reference.aspose.com/slides/fr/java/com.aspose.slides/picturescompression/) lorsqu’une résolution cible standard suffit :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        boolean compressed = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);
        System.out.println(compressed ? "The image was compressed." : "No compression was necessary.");
        presentation.save("compressed-image.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Une valeur DPI positive personnalisée peut être passée à la place d’une valeur prédéfinie lorsqu’une cible spécifique est requise.

La compression est destinée aux images matricielles. Le contenu SVG et les métafichiers ne sont pas réduits par ce workflow de compression matricielle. Rappelez‑vous également que la résolution inférieure et les régions recadrées supprimées ne peuvent pas être récupérées à partir de la présentation optimisée. Choisissez une résolution cible basée sur la taille maximale à laquelle l’image sera réellement visualisée ou exportée, plutôt que d’appliquer la résolution DPI la plus basse globalement.

## **Gérer les effets de transformation d’image**

Pour un workflow complet couvrant la luminosité, le contraste, les transformations de couleur, le flou, les effets d’alpha, les chaînes ordonnées, l’inspection, la suppression et la vérification en aller‑retour, consultez [Image Transform Effects](/slides/fr/java/image-transform-effects/).

## **Verrouiller la géométrie du cadre d’image**

Les paramètres de [IPictureFrameLock](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipictureframelock/) contrôlent quelles opérations d’édition sont désactivées pour un cadre d’image. Par exemple, [setAspectRatioLocked](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) préserve les proportions de la forme pendant le redimensionnement.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);

    presentation.save("locked-picture-frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le verrou s’applique à la forme du cadre d’image. Il ne force pas l’image source à être rééchantillonnée ou modifiée de façon permanente pour correspondre au même ratio d’aspect.

## **Ajuster les valeurs StretchOffset**

Lorsque le mode de remplissage de l’image est « stretch », les valeurs stretch‑offset sur [IPictureFillFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipicturefillformat/) définissent le rectangle de remplissage relatif à la boîte englobante du cadre d’image. Des pourcentages positifs créent un retrait depuis un bord, tandis que des pourcentages négatifs créent un dépassement.

Ceci est différent du recadrage. Les valeurs de recadrage sélectionnent quelle partie de l’image source est visible ; les offsets d’étirement modifient le rectangle dans lequel le remplissage d’image visible est étiré.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image);
    pictureFrame.getPictureFormat().setPictureFillMode(PictureFillMode.Stretch);
    pictureFrame.getPictureFormat().setStretchOffsetLeft(12f);
    pictureFrame.getPictureFormat().setStretchOffsetRight(12f);
    pictureFrame.getPictureFormat().setStretchOffsetTop(8f);
    pictureFrame.getPictureFormat().setStretchOffsetBottom(8f);

    presentation.save("stretch-offsets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Utilisez les offsets d’étirement pour le placement du remplissage. Utilisez les propriétés de recadrage lorsque le but est de masquer les bords de l’image source.

## **Considérations de stockage, taille du fichier et exportation**

Les principaux compromis sont plus faciles à gérer lorsque le stockage des images et le formatage des cadres d’image sont traités séparément :

- **Images incorporées** rendent la présentation autonome et sont les plus fiables pour le partage et le rendu côté serveur, mais les grandes images matricielles augmentent la taille du PPTX et l’utilisation de la mémoire.
- **Images liées** peuvent alléger le paquet, mais la présentation dépend de la disponibilité continue des fichiers externes aux chemins ou emplacements stockés.
- **Recadrage** est initialement non destructif. Les pixels masqués restent incorporés jusqu’à ce que les zones recadrées soient explicitement supprimées ou retirées lors de la compression.
- **Compression** peut réduire substantiellement la taille du fichier pour les images matricielles surdimensionnées, mais elle sacrifie la résolution source. Elle doit être appliquée après que la taille finale sur la diapositive soit connue.
- **Images SVG** doivent rester au format SVG lorsque la préservation vectorielle est importante. Extrayez le SVG incorporé directement lorsque vous avez besoin de la ressource vectorielle elle‑même. Les exportations de diapositives en raster convertissent toujours la diapositive rendue en pixels.
- **Images répétées** doivent réutiliser une ressource [IPPImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ippimage/) existante quand cela est possible au lieu de charger à nouveau le même fichier dans le workflow de la présentation.

Pour les présentations volumineuses, l’optimisation des images est généralement la plus efficace lorsqu’elle est effectuée de manière sélective : conservez les logos et diagrammes en contenu vectoriel, compressez les photographies en fonction de leur taille d’affichage réelle, supprimez les pixels recadrés uniquement lorsque l’édition ultérieure n’est pas requise, et évitez les liens externes sauf si la gestion des dépendances fait partie du design de déploiement.

## **FAQ**

**Quelle est la différence entre un cadre d’image et une ressource image ?**

Un [IPPImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ippimage/) représente une ressource image associée à la présentation. Un [IPictureFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipictureframe/) est une forme sur une diapositive qui affiche une image et stocke la géométrie et le formatage au niveau du cadre tels que la taille, la rotation, les valeurs de recadrage, les effets et les verrous.

**Dois‑je incorporer ou lier les images ?**

Incorporez les images lorsque la présentation doit être portable, archivée ou rendue sans accès à des ressources externes. Liez les images uniquement lorsque garder les fichiers d’image hors du PPTX est intentionnel et que les emplacements externes peuvent être maintenus de façon fiable.

**Le recadrage réduit‑il la taille du fichier PPTX ?**

Pas en soi. Les réglages de recadrage normaux masquent des parties de l’image source mais conservent les pixels sous‑jacents. Utilisez [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) ou la compression d’image avec suppression des zones recadrées lorsque ces pixels peuvent être éliminés définitivement.

**Puis‑je restaurer la qualité de l’image après compression ?**

Non. La compression peut réduire la résolution matricielle stockée, et la suppression des zones recadrées élimine les données d’image. Conservez l’image source originale à l’extérieur de la présentation si un futur traitement en haute résolution est susceptible d’être nécessaire.

**Comment les images SVG doivent‑elles être gérées ?**

Conservez le contenu SVG en tant que SVG lorsque la fidélité vectorielle compte. L’[ISvgImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isvgimage/) incorporé peut être extrait directement. Rendre une diapositive dans un format matriciel tel que PNG ou JPEG rasterise le SVG comme partie de l’image de la diapositive.

**Comment éviter les casts dangereux lors de la lecture de diapositives existantes ?**

Vérifiez le type de forme avant d’utiliser les membres spécifiques aux cadres d’image. Un test `instanceof` contre [IPictureFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipictureframe/) évite les casts invalides et permet au code de gérer les diapositives qui ne contiennent pas de cadres d’image.