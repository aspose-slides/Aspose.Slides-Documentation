---
title: Convertir les diapositives de présentation en images sur Android
linktitle: Diapositive en image
type: docs
weight: 35
url: /fr/androidjava/convert-slide/
keywords:
- convertir diapositive
- exporter diapositive
- diapositive en image
- enregistrer diapositive comme image
- diapositive en PNG
- diapositive en JPEG
- diapositive en bitmap
- diapositive en TIFF
- PowerPoint
- OpenDocument
- présentation
- Android
- Java
- Aspose.Slides
description: "Convertissez les diapositives PPT, PPTX et ODP en images avec Aspose.Slides pour Android—rendu rapide et de haute qualité avec des exemples de code Java clairs."
---

## **Vue d'ensemble**

Aspose.Slides for Android via Java permet de convertir facilement les diapositives PowerPoint et OpenDocument en divers formats d'image, notamment BMP, PNG, JPG (JPEG), GIF et d'autres.

Pour convertir une diapositive en image, suivez les étapes suivantes :

1. Définissez les paramètres de conversion souhaités et sélectionnez les diapositives que vous souhaitez exporter en utilisant :
    - L'interface [ITiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itiffoptions/), ou
    - L'interface [IRenderingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irenderingoptions/)
2. Générez l'image de la diapositive en appelant la méthode [getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage--) .

In Aspose.Slides for Android via Java, un [IImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/) est une interface qui vous permet de travailler avec des images définies par des données de pixels. Vous pouvez utiliser cette interface pour enregistrer les images dans un large éventail de formats (BMP, JPG, PNG, etc.).

## **Convertir les diapositives en bitmaps et enregistrer les images en PNG**

Vous pouvez convertir une diapositive en objet bitmap et l'utiliser directement dans votre application. Alternativement, vous pouvez convertir une diapositive en bitmap puis enregistrer l'image au format JPEG ou tout autre format de votre choix.

Ce code montre comment convertir la première diapositive d'une présentation en objet bitmap, puis enregistrer l'image au format PNG :
```java 
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Convertir la première diapositive de la présentation en bitmap.
    IImage image = presentation.getSlides().get_Item(0).getImage();
	try {
        // Enregistrer l'image au format PNG.
        image.save("Slide_0.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```


## **Convertir les diapositives en images avec des tailles personnalisées**

Il se peut que vous ayez besoin d'obtenir une image d'une taille précise. En utilisant une surcharge de la méthode [getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-), vous pouvez convertir une diapositive en image avec des dimensions spécifiques (largeur et hauteur).

Ce code d'exemple montre comment faire :
```java 
Size imageSize = new Size(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Convertir la première diapositive de la présentation en bitmap avec la taille spécifiée.
    IImage image = presentation.getSlides().get_Item(0).getImage(imageSize);

    try {
        // Enregistrer l'image au format JPEG.
        image.save("Slide_0.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```


## **Convertir les diapositives avec notes et commentaires en images**

Certaines diapositives peuvent contenir des notes et des commentaires.

Aspose.Slides fournit deux interfaces — [ITiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itiffoptions/) et [IRenderingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irenderingoptions/) — qui vous permettent de contrôler le rendu des diapositives de la présentation en images. Les deux interfaces incluent la méthode `setSlidesLayoutOptions`, qui vous permet de configurer le rendu des notes et des commentaires sur une diapositive lors de sa conversion en image.

Avec la classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/notescommentslayoutingoptions/), vous pouvez spécifier la position souhaitée pour les notes et les commentaires dans l'image résultante.

Ce code montre comment convertir une diapositive avec notes et commentaires :
```java 
float scaleX = 2;
float scaleY = scaleX;

// Charger un fichier de présentation.
Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    NotesCommentsLayoutingOptions notesCommentsOptions = new NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(NotesPositions.BottomTruncated);  // Définir la position des notes.
    notesCommentsOptions.setCommentsPosition(CommentsPositions.Right);      // Définir la position des commentaires.
    notesCommentsOptions.setCommentsAreaWidth(500);                         // Définir la largeur de la zone des commentaires.
    notesCommentsOptions.setCommentsAreaColor(Color.LTGRAY);   // Définir la couleur de la zone des commentaires.

    // Créer les options de rendu.
    RenderingOptions options = new RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);

    // Convertir la première diapositive de la présentation en image.
    IImage image = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);

    try {
        // Enregistrer l'image au format GIF.
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```


{{% alert title="Note" color="warning" %}} 

Dans tout processus de conversion de diapositive en image, la méthode [setNotesPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inotescommentslayoutingoptions/#setNotesPosition-int-) ne peut pas appliquer `BottomFull` (pour spécifier la position des notes) car le texte d'une note peut être trop volumineux, ce qui empêche son adaptation à la taille d'image spécifiée.

{{% /alert %}} 

## **Convertir les diapositives en images en utilisant les options TIFF**

L'interface [ITiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itiffoptions/) offre un contrôle plus poussé sur l'image TIFF résultante en vous permettant de spécifier des paramètres tels que la taille, la résolution, la palette de couleurs, etc.

Ce code montre un processus de conversion où les options TIFF sont utilisées pour produire une image en noir et blanc avec une résolution de 300 DPI et une taille de 2160 × 2800 :
```java 
// Charger un fichier de présentation.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Obtenir la première diapositive de la présentation.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Configurer les paramètres de l'image TIFF de sortie.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setImageSize(new Size(2160, 2880));                  // Définir la taille de l'image.
    tiffOptions.setPixelFormat(ImagePixelFormat.Format1bppIndexed);  // Définir le format de pixel (noir et blanc).
    tiffOptions.setDpiX(300);                                        // Définir la résolution horizontale.
    tiffOptions.setDpiY(300);                                        // Définir la résolution verticale.

    // Convertir la diapositive en image avec les options spécifiées.
    IImage image = slide.getImage(tiffOptions);

    try {
        // Enregistrer l'image au format TIFF.
        image.save("output.tiff", ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```


## **Convertir toutes les diapositives en images**

Aspose.Slides vous permet de convertir toutes les diapositives d'une présentation en images, transformant ainsi la présentation entière en une série d'images.

Ce code d'exemple montre comment convertir toutes les diapositives d'une présentation en images en Java :
```java 
float scaleX = 2;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Rendre la présentation en images diapositive par diapositive.
    for (int i = 0 ; i < presentation.getSlides().size(); i++)
    {
        // Contrôler les diapositives masquées (ne pas rendre les diapositives masquées).
        if (presentation.getSlides().get_Item(i).getHidden())
            continue;

        // Convertir la diapositive en image.
        IImage image = presentation.getSlides().get_Item(i).getImage(scaleX, scaleY);

        try {
            // Enregistrer l'image au format JPEG.
            image.save("Slide_" + i + ".jpg", ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```


## **FAQ**

**Aspose.Slides prend-il en charge le rendu des diapositives avec animations ?**  
Non, la méthode `getImage` enregistre uniquement une image statique de la diapositive, sans animations.

**Les diapositives masquées peuvent-elles être exportées en images ?**  
Oui, les diapositives masquées peuvent être traitées comme les diapositives ordinaires. Assurez-vous simplement qu'elles sont incluses dans la boucle de traitement.

**Les images peuvent-elles être enregistrées avec des ombres et des effets ?**  
Oui, Aspose.Slides prend en charge le rendu des ombres, de la transparence et d'autres effets graphiques lors de l'enregistrement des diapositives en images.