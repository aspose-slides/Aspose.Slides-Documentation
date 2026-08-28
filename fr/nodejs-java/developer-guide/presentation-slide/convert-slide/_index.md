---
title: Convertir les diapositives de présentation en images en JavaScript
linktitle: Diapositive vers image
type: docs
weight: 35
url: /fr/nodejs-java/convert-slide/
keywords:
  - convertir diapositive
  - exporter diapositive
  - diapositive en image
  - enregistrer diapositive en tant qu'image
  - diapositive en EMF
  - diapositive en PNG
  - diapositive en JPEG
  - diapositive en bitmap
  - diapositive en TIFF
  - PowerPoint
  - OpenDocument
  - présentation
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "Convertir les diapositives des présentations PPT, PPTX et ODP en PNG, JPEG, GIF, TIFF, EMF et autres formats d'image en JavaScript avec Aspose.Slides."
---
## **Introduction**

Aspose.Slides for Node.js via Java peut rendre des diapositives individuelles provenant de présentations PowerPoint et OpenDocument en PNG, JPEG, GIF, TIFF et d’autres formats d’image.

Pour convertir une diapositive en image, suivez ces étapes :

1. Chargez la présentation avec la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/).
2. Sélectionnez la diapositive que vous souhaitez rendre.
3. Si nécessaire, configurez le rendu avec la classe [RenderingOptions](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/renderingoptions/) ou [TiffOptions](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/tiffoptions/).
4. Appelez la méthode [Slide.getImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slide/#getImage). Elle renvoie un objet [IImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/iimage/).
5. Appelez la méthode [IImage.save](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/iimage/#save) et spécifiez le format de sortie avec une valeur [ImageFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/imageformat/).

## **Convertir une diapositive en image PNG**

La conversion la plus simple utilise les paramètres de rendu par défaut. L’objet [IImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/iimage/) résultant peut être traité en mémoire ou enregistré dans un fichier.

L’exemple JavaScript suivant rend la première diapositive et l’enregistre comme image PNG :

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage();
    try {
        image.save("Slide_0.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Convertir des diapositives en images avec des tailles personnalisées**

Utilisez la surcharge de [Slide.getImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slide/#getImage) qui accepte une valeur `java.awt.Dimension` pour rendre une diapositive avec des dimensions exactes en pixels.

L’exemple suivant crée une image JPEG de 1820 × 1040 :

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const imageSize = java.newInstanceSync("java.awt.Dimension", 1820, 1040);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage(imageSize);
    try {
        image.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Convertir des diapositives avec notes et commentaires en images**

Par défaut, les images des diapositives n’incluent pas les notes ni les commentaires. Passez un objet [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/notescommentslayoutingoptions/) à la méthode [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) pour contrôler l’emplacement des notes et des commentaires.

L’exemple suivant place les notes tronquées sous la diapositive et les commentaires à droite :

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const scaleX = 2;
const scaleY = scaleX;

const commentsAreaColor = java.newInstanceSync("java.awt.Color", 250, 235, 215);

const layoutOptions = new aspose.slides.NotesCommentsLayoutingOptions();
layoutOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);
layoutOptions.setCommentsPosition(aspose.slides.CommentsPositions.Right);
layoutOptions.setCommentsAreaWidth(500);
layoutOptions.setCommentsAreaColor(commentsAreaColor);

const renderingOptions = new aspose.slides.RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutOptions);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage(renderingOptions, scaleX, scaleY);
    try {
        image.save("Image_with_notes_and_comments_0.gif", aspose.slides.ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Warning" color="warning" %}}
Pour la conversion diapositive‑vers‑image, ne passez pas [BottomFull](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/notespositions/) à la méthode [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). Les notes peuvent contenir plus de texte que la taille d’image fixe ne peut contenir. Utilisez [BottomTruncated](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/notespositions/) à la place.
{{% /alert %}}

## **Convertir des diapositives en images en utilisant les options TIFF**

La classe [TiffOptions](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/tiffoptions/) vous permet de contrôler la taille, la résolution et d’autres propriétés de l’image TIFF rendue.

L’exemple suivant rend la première diapositive en une image TIFF de 2160 × 2880 à 300 DPI :

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const imageSize = java.newInstanceSync("java.awt.Dimension", 2160, 2880);

const tiffOptions = new aspose.slides.TiffOptions();
tiffOptions.setImageSize(imageSize);
tiffOptions.setDpiX(300);
tiffOptions.setDpiY(300);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage(tiffOptions);
    try {
        image.save("output.tiff", aspose.slides.ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Warning" color="warning" %}}
La prise en charge du TIFF n’est pas garantie dans les versions de Java antérieures à JDK 9.
{{% /alert %}}

## **Convertir toutes les diapositives en images**

Itérez sur la collection de diapositives pour convertir l’ensemble de la présentation en une série d’images. Les diapositives masquées sont incluses à moins que vous ne les excluiez explicitement.

L’exemple suivant rend chaque diapositive en image JPEG avec des facteurs d’échelle horizontaux et verticaux de 2 :

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const scaleX = 2;
const scaleY = scaleX;

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        const slide = presentation.getSlides().get_Item(index);
        const image = slide.getImage(scaleX, scaleY);
        try {
            image.save("Slide_" + index + ".jpg", aspose.slides.ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Créer une sortie Enhanced Metafile**

Enhanced Metafile (EMF) est utile lorsque des graphiques vectoriels doivent être échangés avec Microsoft Office ou d’autres applications Windows qui prennent en charge les métafichiers Windows. Contrairement à une image basée sur des pixels, un EMF peut conserver les opérations de dessin vectoriel qui se redimensionnent sans perte de netteté. Cependant, l’EMF est principalement un format de compatibilité pour les applications disposant d’un support des métafichiers Windows, et non un format d’échange universel. De plus, le contenu complexe d’une diapositive, tel que les images bitmap et certains effets, peut être stocké sous forme d’éléments rasterisés à l’intérieur du conteneur du métafile vectoriel.

### **Exporter une diapositive au format EMF**

La méthode [Slide.writeAsEmf](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slide/#writeAsEmf) écrit une diapositive dans un flux cible au format EMF. L’exemple suivant charge une présentation, sélectionne la première diapositive et l’écrit dans un flux de fichier EMF :

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const emfStream = java.newInstanceSync("java.io.FileOutputStream", "Slide_0.emf");
    try {
        slide.writeAsEmf(emfStream);
    } finally {
        emfStream.close();
    }
} finally {
    presentation.dispose();
}
```

L’appelant possède le flux passé à [Slide.writeAsEmf](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slide/#writeAsEmf) et est responsable de le fermer, comme indiqué ci‑dessus.

### **Convertir une image SVG en EMF et l’ajouter à une présentation**

Utilisez [SvgImage.writeAsEmf](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/svgimage/#writeAsEmf) pour convertir le contenu SVG en EMF. Les octets résultants peuvent être ajoutés à la présentation via [ImageCollection.addImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/imagecollection/#addImage) et placés sur une diapositive avec [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shapecollection/#addPictureFrame).

L’exemple suivant crée un [SvgImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/svgimage/) à partir du balisage SVG, le convertit en EMF en mémoire, insère le métafile sur la première diapositive et enregistre la présentation :

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
const svgImage = new aspose.slides.SvgImage(svgContent);

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const emfStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    try {
        svgImage.writeAsEmf(emfStream);

        const emfData = java.newArray("byte", Array.from(emfStream.toByteArray()));
        const image = presentation.getImages().addImage(emfData);
        slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 100, image);
    } finally {
        emfStream.close();
    }

    presentation.save("Presentation_with_emf.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[SvgImage.writeAsEmf](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/svgimage/#writeAsEmf) ne prend pas la possession du flux de destination. Un `java.io.ByteArrayOutputStream` stocke toutes les données générées en mémoire, il n’est donc pas nécessaire de réinitialiser la position avant d’appeler `toByteArray`. Le tableau d’octets retourné reste valide après la fermeture du flux.

La génération d’EMF est disponible sur les systèmes d’exploitation pris en charge par la configuration sélectionnée d’Aspose.Slides for Node.js via Java et du JDK, mais le rendu peut différer d’une plateforme à l’autre lorsque les polices ou les dépendances graphiques sont indisponibles. Installez les polices utilisées par le contenu source ou configurez des substitutions appropriées, suivez les [exigences de plateforme](/slides/fr/nodejs-java/system-requirements/) pour Aspose.Slides for Node.js via Java, et validez le résultat dans l’application cible consommant les EMF. Les applications Linux et macOS ont souvent un support limité ou incohérent pour l’affichage et l’édition des métafichiers Windows.

## **Rendu des Emoji couleur**

{{% alert title="Note" color="info" %}}
Pour rendre correctement les emojis couleur lors de la conversion des diapositives de présentation en images, les polices d’emoji utilisées dans la présentation doivent être installées et disponibles sur le système effectuant la conversion. Par exemple, si la présentation utilise **Segoe UI Emoji** et que cette police est absente, les emojis peuvent apparaître en monochrome dans les images de sortie.
{{% /alert %}}

## **FAQ**

**Aspose.Slides prend‑t‑il en charge le rendu des diapositives avec animations ?**

Non. La méthode [Slide.getImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slide/#getImage) rend une image statique de la diapositive et n’exporte pas les animations.

**Les diapositives masquées peuvent‑elles être exportées en images ?**

Oui. Les diapositives masquées peuvent être rendues comme des diapositives normales. Incluez‑les dans la boucle de traitement, comme le montre l’exemple ci‑dessus.

**Les ombres et autres effets sont‑ils conservés dans les images des diapositives ?**

Oui. Aspose.Slides rend les ombres, la transparence et d’autres effets graphiques pris en charge dans les images des diapositives.