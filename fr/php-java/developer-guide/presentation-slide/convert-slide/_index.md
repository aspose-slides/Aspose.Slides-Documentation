---
title: Convertir les diapositives de présentation en images en PHP
linktitle: Diapositive en image
type: docs
weight: 35
url: /fr/php-java/convert-slide/
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
- PHP
- Aspose.Slides
description: "Convertir les diapositives au format PPT, PPTX et ODP en images avec Aspose.Slides for PHP via Java — rendu rapide et de haute qualité avec des exemples de code clairs."
---
## **Introduction**

Aspose.Slides for PHP via Java vous permet de convertir facilement des diapositives de présentations PowerPoint et OpenDocument en divers formats d’image, notamment BMP, PNG, JPG (JPEG), GIF et d’autres.

Pour convertir une diapositive en image, suivez ces étapes :

1. Définissez les paramètres de conversion souhaités et sélectionnez les diapositives à exporter en utilisant :
    - la classe [TiffOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/tiffoptions/), ou
    - la classe [RenderingOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/renderingoptions/).
2. Générez l’image de la diapositive en appelant la méthode [getImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slide/#getImage).

Dans Aspose.Slides for PHP via Java, un [IImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/iimage/) est une classe qui vous permet de travailler avec des images définies par des données de pixels. Vous pouvez utiliser cette classe pour enregistrer des images dans un large éventail de formats (BMP, JPG, PNG, etc.).

## **Convertir des diapositives en bitmaps et enregistrer les images au format PNG**

Vous pouvez convertir une diapositive en un objet bitmap et l’utiliser directement dans votre application. Vous pouvez également convertir une diapositive en bitmap puis enregistrer l’image au format JPEG ou tout autre format préféré.

Ce code montre comment convertir la première diapositive d’une présentation en objet bitmap puis enregistrer l’image au format PNG :

```php
$presentation = new Presentation("Presentation.pptx");
try {
    // Convertir la première diapositive de la présentation en bitmap.
    $image = $presentation->getSlides()->get_Item(0)->getImage();
    try {
        // Enregistrer l'image au format PNG.
        $image->save("Slide_0.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Convertir des diapositives en images avec des tailles personnalisées**

Il se peut que vous ayez besoin d’obtenir une image d’une taille précise. En utilisant une surcharge de la méthode [getImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slide/#getImage), vous pouvez convertir une diapositive en image avec des dimensions spécifiques (largeur et hauteur).

Cet exemple de code montre comment procéder :

```php
$imageSize = new Java("java.awt.Dimension", 1820, 1040);

$presentation = new Presentation("Presentation.pptx");
try {
    // Convertir la première diapositive de la présentation en bitmap avec la taille spécifiée.
    $image = $presentation->getSlides()->get_Item(0)->getImage($imageSize);
    try {
        // Enregistrer l'image au format JPEG.
        $image->save("Slide_0.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Convertir des diapositives avec notes et commentaires en images**

Certaines diapositives peuvent contenir des notes et des commentaires.

Aspose.Slides fournit deux classes[TiffOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/tiffoptions/) et [RenderingOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/renderingoptions/)—qui vous permettent de contrôler le rendu des diapositives de présentation en images. Les deux classes incluent la méthode `setSlidesLayoutOptions`, qui vous permet de configurer le rendu des notes et des commentaires sur une diapositive lors de sa conversion en image.

Avec la classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/notescommentslayoutingoptions/), vous pouvez spécifier la position souhaitée pour les notes et les commentaires dans l’image résultante.

Ce code montre comment convertir une diapositive avec notes et commentaires :

```php
$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    $notesCommentsOptions = new NotesCommentsLayoutingOptions();
    $notesCommentsOptions->setNotesPosition(NotesPositions::BottomTruncated);         // Définir la position des notes.
    $notesCommentsOptions->setCommentsPosition(CommentsPositions::Right);             // Définir la position des commentaires.
    $notesCommentsOptions->setCommentsAreaWidth(500);                                 // Définir la largeur de la zone de commentaires.
    $notesCommentsOptions->setCommentsAreaColor(java("java.awt.Color")->LIGHT_GRAY);  // Définir la couleur de la zone de commentaires.

    // Créer les options de rendu.
    $options = new RenderingOptions();
    $options->setSlidesLayoutOptions($notesCommentsOptions);

    // Convertir la première diapositive de la présentation en image.
    $image = $presentation->getSlides()->get_Item(0)->getImage($options, $scaleX, $scaleY);
    try {
        // Enregistrer l'image au format GIF.
        $image->save("Image_with_notes_and_comments_0.gif", ImageFormat::Gif);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Note" color="warning" %}} 

Dans tout processus de conversion diapositive‑à‑image, la méthode [setNotesPosition](https://reference.aspose.com/slides/fr/php-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) ne peut pas appliquer `BottomFull` (pour spécifier la position des notes) car le texte d’une note peut être trop volumineux pour tenir dans la taille d’image spécifiée.

{{% /alert %}} 

## **Convertir des diapositives en images en utilisant les options TIFF**

La classe [TiffOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/tiffoptions/) offre un contrôle plus fin sur l’image TIFF résultante en vous permettant de spécifier des paramètres tels que la taille, la résolution, la palette de couleurs, etc.

Ce code montre un processus de conversion où les options TIFF sont utilisées pour produire une image noir et blanc avec une résolution de 300 DPI et une taille de 2160 × 2800 :

```php
// Charger un fichier de présentation.
$presentation = new Presentation("sample.pptx");
try {
    // Obtenir la première diapositive de la présentation.
    $slide = $presentation->getSlides()->get_Item(0);

    // Configurer les paramètres de l'image TIFF de sortie.
    $options = new TiffOptions();
    $options->setImageSize(new Java("java.awt.Dimension", 2160, 2880));  // Définir la taille de l'image.
    $options->setPixelFormat(ImagePixelFormat::Format1bppIndexed);       // Définir le format des pixels (noir et blanc).
    $options->setDpiX(300);                                              // Définir la résolution horizontale.
    $options->setDpiY(300);                                              // Définir la résolution verticale.
    
    // Convertir la diapositive en image avec les options spécifiées.
    $image = $slide->getImage($options);
    try {
        // Enregistrer l'image au format TIFF.
        $image->save("output.tiff", ImageFormat::Tiff);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Note" color="warning" %}} 

La prise en charge du format TIFF n’est pas garantie dans les versions antérieures à JDK 9.

{{% /alert %}} 

## **Convertir toutes les diapositives en images**

Aspose.Slides vous permet de convertir toutes les diapositives d’une présentation en images, transformant ainsi l’ensemble de la présentation en une série d’images.

Cet exemple de code montre comment convertir toutes les diapositives d’une présentation en images en PHP :

```php
$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation.pptx");
try {
    // Rendre la présentation en images diapositive par diapositive.
    for($i = 0; $i < java_values($presentation->getSlides()->size()) ; $i++) {
        // Contrôler les diapositives masquées (ne pas rendre les diapositives masquées).
        if (java_values($presentation->getSlides()->get_Item($i)->getHidden())) {
            continue;
        }

        // Convertir la diapositive en image.
        $image = $presentation->getSlides()->get_Item($i)->getImage($scaleX, $scaleY);
        try {
            // Enregistrer l'image au format JPEG.
            $image->save("Slide_" . $i . ".jpg", ImageFormat::Jpeg);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Rendu des émojis en couleur**

{{% alert title="Note" color="warning" %}} 
Pour rendre correctement les émojis en couleur lors de la conversion de diapositives en images, les polices d’émoji utilisées dans la présentation doivent être installées et disponibles sur le système qui effectue la conversion. Par exemple, si la présentation utilise **Segoe UI Emoji** et que cette police est absente, les émojis peuvent apparaître en monochrome dans les images générées.
{{% /alert %}}

## **FAQ**

**Aspose.Slides prend‑il en charge le rendu des diapositives avec animations ?**

Non, la méthode `getImage` enregistre uniquement une image statique de la diapositive, sans animations.

**Les diapositives masquées peuvent‑elles être exportées en images ?**

Oui, les diapositives masquées peuvent être traitées comme des diapositives normales. Il suffit de s’assurer qu’elles sont incluses dans la boucle de traitement.

**Les images peuvent‑elles être enregistrées avec des ombres et des effets ?**

Oui, Aspose.Slides prend en charge le rendu des ombres, de la transparence et d’autres effets graphiques lors de l’enregistrement des diapositives en images.