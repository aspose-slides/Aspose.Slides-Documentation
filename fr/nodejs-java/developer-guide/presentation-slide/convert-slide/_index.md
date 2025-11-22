---
title: Convertir des diapositives PowerPoint en images en JavaScript
linktitle: Diapositive en image
type: docs
weight: 35
url: /fr/nodejs-java/convert-slide/
keywords:
- convertir la diapositive
- convertir la diapositive en image
- exporter la diapositive en tant qu'image
- enregistrer la diapositive en tant qu'image
- diapositive en image
- diapositive en PNG
- diapositive en JPEG
- diapositive en bitmap
- Node.js
- JavaScript
- Aspose.Slides
description: "Apprenez à convertir les diapositives PowerPoint et OpenDocument en différents formats à l'aide d'Aspose.Slides pour Node.js via Java. Exportez facilement les diapositives PPTX et ODP en BMP, PNG, JPEG, TIFF et plus encore avec des résultats de haute qualité."
---

## **Vue d’ensemble**

Aspose.Slides for Node.js via Java vous permet de convertir facilement les diapositives PowerPoint et OpenDocument en divers formats d’image, notamment BMP, PNG, JPG (JPEG), GIF et d’autres.

Pour convertir une diapositive en image, suivez ces étapes :

1. Définissez les paramètres de conversion souhaités et sélectionnez les diapositives à exporter en utilisant :
    - la classe [TiffOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/), ou
    - la classe [RenderingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/renderingoptions/).
2. Générez l’image de la diapositive en appelant la méthode [getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage).

Dans Aspose.Slides for Node.js via Java, un [IImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/) est une classe qui vous permet de travailler avec des images définies par des données de pixels. Vous pouvez utiliser cette classe pour enregistrer des images dans un large éventail de formats (BMP, JPG, PNG, etc.).

## **Convertir des diapositives en bitmap et enregistrer les images au format PNG**

Vous pouvez convertir une diapositive en objet bitmap et l’utiliser directement dans votre application. Vous pouvez également convertir une diapositive en bitmap puis enregistrer l’image au format JPEG ou tout autre format préféré.

Ce code JavaScript montre comment convertir la première diapositive d’une présentation en objet bitmap puis enregistrer l’image au format PNG :
```js
let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Convertir la première diapositive de la présentation en bitmap.
    let image = presentation.getSlides().get_Item(0).getImage();
    try {
        // Enregistrer l'image au format PNG.
        image.save("Slide_0.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```


## **Convertir des diapositives en images avec des tailles personnalisées**

Il se peut que vous ayez besoin d’obtenir une image d’une certaine taille. En utilisant une surcharge de la méthode [getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage), vous pouvez convertir une diapositive en image avec des dimensions spécifiques (largeur et hauteur).

Ce code d’exemple illustre comment procéder :
```js
let imageSize = java.newInstanceSync("java.awt.Dimension", 1820, 1040);

let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Convertir la première diapositive de la présentation en bitmap avec la taille spécifiée.
    let image = presentation.getSlides().get_Item(0).getImage(imageSize);
    try {
        // Enregistrer l'image au format JPEG.
        image.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```


## **Convertir des diapositives avec notes et commentaires en images**

Certaines diapositives peuvent contenir des notes et des commentaires.

Aspose.Slides fournit deux classes — [TiffOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/) et [RenderingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/renderingoptions/) — qui vous permettent de contrôler le rendu des diapositives de présentation en images. Les deux classes incluent la méthode `setSlidesLayoutOptions`, qui vous permet de configurer le rendu des notes et commentaires sur une diapositive lors de sa conversion en image.

Avec la classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notescommentslayoutingoptions/), vous pouvez spécifier la position souhaitée pour les notes et les commentaires dans l’image résultante.

Ce code JavaScript montre comment convertir une diapositive avec notes et commentaires :
```js
const scaleX = 2;
const scaleY = scaleX;

// Charger un fichier de présentation.
let presentation = new aspose.slides.Presentation("Presentation_with_notes_and_comments.pptx");
try {
    let notesCommentsOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);                  // Définir la position des notes.
    notesCommentsOptions.setCommentsPosition(aspose.slides.CommentsPositions.Right);                      // Définir la position des commentaires.
    notesCommentsOptions.setCommentsAreaWidth(500);                                                       // Définir la largeur de la zone des commentaires.
    notesCommentsOptions.setCommentsAreaColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));  // Définir la couleur de la zone des commentaires.

    // Créer les options de rendu.
    let options = new aspose.slides.RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);
 
    // Convertir la première diapositive de la présentation en image.
    let image = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);
    try {
        // Enregistrer l'image au format GIF.
        image.save("Image_with_notes_and_comments_0.gif", aspose.slides.ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```


{{% alert title="Note" color="warning" %}} 
Dans tout processus de conversion diapositive‑image, la méthode [setNotesPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) ne peut pas appliquer `BottomFull` (pour spécifier la position des notes) parce que le texte d’une note peut être trop volumineux pour tenir dans la taille d’image spécifiée.
{{% /alert %}} 

## **Convertir des diapositives en images en utilisant les options TIFF**

La classe [TiffOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/) offre un contrôle plus fin sur l’image TIFF résultante en vous permettant de spécifier des paramètres tels que la taille, la résolution, la palette de couleurs, etc.

Ce code JavaScript montre un processus de conversion où les options TIFF sont utilisées pour produire une image noir et blanc avec une résolution de 300 DPI et une taille de 2160 × 2800 :
```js
// Charger un fichier de présentation.
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // Obtenir la première diapositive de la présentation.
    let slide = presentation.getSlides().get_Item(0);

    // Configurer les paramètres de l'image TIFF de sortie.
    let tiffOptions = new aspose.slides.TiffOptions();
    tiffOptions.setImageSize(java.newInstanceSync("java.awt.Dimension", 2160, 2880));  // Définir la taille de l'image.
    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format1bppIndexed);      // Définir le format des pixels (noir et blanc).
    tiffOptions.setDpiX(300);                                                          // Définir la résolution horizontale.
    tiffOptions.setDpiY(300);                                                          // Définir la résolution verticale.

    // Convertir la diapositive en image avec les options spécifiées.
    let image = slide.getImage(tiffOptions);
    try {
        // Enregistrer l'image au format TIFF.
        image.save("output.tiff", aspose.slides.ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```


{{% alert title="Note" color="warning" %}} 
Le support du format TIFF n’est pas garanti dans les versions antérieures à JDK 9.
{{% /alert %}} 

## **Convertir toutes les diapositives en images**

Aspose.Slides vous permet de convertir toutes les diapositives d’une présentation en images, transformant ainsi l’ensemble de la présentation en une série d’images.

Ce code d’exemple montre comment convertir toutes les diapositives d’une présentation en images en JavaScript :
```js
const scaleX = 2;
const scaleY = scaleX;

let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Rendre la présentation en images diapositive par diapositive.
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        // Gérer les diapositives masquées (ne pas rendre les diapositives masquées).
        if (presentation.getSlides().get_Item(i).getHidden()) {
            continue;
        }

        // Convertir la diapositive en image.
        let image = presentation.getSlides().get_Item(i).getImage(scaleX, scaleY);
        try {
            // Enregistrer l'image au format JPEG.
            image.save("Slide_" + i + ".jpg", aspose.slides.ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```


## **FAQ**

**Aspose.Slides prend‑il en charge le rendu des diapositives avec animations ?**

Non, la méthode `getImage` enregistre uniquement une image statique de la diapositive, sans animations.

**Les diapositives masquées peuvent-elles être exportées en images ?**

Oui, les diapositives masquées peuvent être traitées comme les diapositives normales. Assurez‑vous simplement qu’elles soient incluses dans la boucle de traitement.

**Les images peuvent‑elles être enregistrées avec des ombres et des effets ?**

Oui, Aspose.Slides prend en charge le rendu des ombres, de la transparence et d’autres effets graphiques lors de l’enregistrement des diapositives en images.