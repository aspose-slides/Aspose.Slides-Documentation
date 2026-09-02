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
- diapositive en EMF
- diapositive en PNG
- diapositive en JPEG
- diapositive en bitmap
- diapositive en TIFF
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Convertir les diapositives des présentations PPT, PPTX et ODP en PNG, JPEG, GIF, TIFF, EMF et autres formats d’image en PHP avec Aspose.Slides."
---
## **Introduction**

Aspose.Slides for PHP via Java peut rendre des diapositives individuelles de présentations PowerPoint et OpenDocument au format PNG, JPEG, GIF, TIFF et d’autres formats d’image.

1. Chargez la présentation avec la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/).
2. Sélectionnez la diapositive que vous souhaitez rendre.
3. Si nécessaire, configurez le rendu avec la classe [RenderingOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/renderingoptions/) ou la classe [TiffOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/tiffoptions/).
4. Appelez la méthode [Slide::getImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slide/#getImage). Elle renvoie un objet [IImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/iimage/).
5. Appelez la méthode [IImage::save](https://reference.aspose.com/slides/fr/php-java/aspose.slides/iimage/#save) et spécifiez le format de sortie avec une valeur [ImageFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/imageformat/).

## **Convertir une diapositive en image PNG**

La conversion la plus simple utilise les paramètres de rendu par défaut. L’objet [IImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/iimage/) résultant peut être traité en mémoire ou enregistré dans un fichier.

L’exemple PHP suivant rend la première diapositive et l’enregistre au format PNG :

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage();
    try {
        $image->save("Slide_0.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Convertir des diapositives en images avec des tailles personnalisées**

Utilisez la surcharge de [Slide::getImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slide/#getImage) qui accepte une valeur [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) pour rendre une diapositive avec des dimensions exactes en pixels.

L’exemple suivant crée une image JPEG de 1820 × 1040 :

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$imageSize = new Java("java.awt.Dimension", 1820, 1040);

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($imageSize);
    try {
        $image->save("Slide_0.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Convertir des diapositives avec notes et commentaires en images**

Par défaut, les images des diapositives n’incluent pas les notes ni les commentaires. Transmettez un objet [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/notescommentslayoutingoptions/) à la méthode [RenderingOptions::setSlidesLayoutOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) pour contrôler l’emplacement des notes et des commentaires.

L’exemple suivant place les notes tronquées sous la diapositive et les commentaires à droite :

```php
use aspose\slides\CommentsPositions;
use aspose\slides\ImageFormat;
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;

$scaleX = 2;
$scaleY = $scaleX;

$commentsAreaColor = new Java("java.awt.Color", 250, 235, 215);

$layoutOptions = new NotesCommentsLayoutingOptions();
$layoutOptions->setNotesPosition(NotesPositions::BottomTruncated);
$layoutOptions->setCommentsPosition(CommentsPositions::Right);
$layoutOptions->setCommentsAreaWidth(500);
$layoutOptions->setCommentsAreaColor($commentsAreaColor);

$renderingOptions = new RenderingOptions();
$renderingOptions->setSlidesLayoutOptions($layoutOptions);

$presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($renderingOptions, $scaleX, $scaleY);
    try {
        $image->save("Image_with_notes_and_comments_0.gif", ImageFormat::Gif);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Warning" color="warning" %}}
Pour la conversion de diapositive en image, ne transmettez pas [BottomFull](https://reference.aspose.com/slides/fr/php-java/aspose.slides/notespositions/) à la méthode [NotesCommentsLayoutingOptions::setNotesPosition](https://reference.aspose.com/slides/fr/php-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). Les notes peuvent contenir plus de texte que la taille fixe de l’image ne peut contenir. Utilisez [BottomTruncated](https://reference.aspose.com/slides/fr/php-java/aspose.slides/notespositions/) à la place.
{{% /alert %}}

## **Convertir des diapositives en images en utilisant les options TIFF**

La classe [TiffOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/tiffoptions/) vous permet de contrôler la taille, la résolution et d’autres propriétés de l’image TIFF rendue.

L’exemple suivant rend la première diapositive en tant qu’image TIFF de 2160 × 2880 à 300 DPI :

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;
use aspose\slides\TiffOptions;

$imageSize = new Java("java.awt.Dimension", 2160, 2880);

$tiffOptions = new TiffOptions();
$tiffOptions->setImageSize($imageSize);
$tiffOptions->setDpiX(300);
$tiffOptions->setDpiY(300);

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($tiffOptions);
    try {
        $image->save("output.tiff", ImageFormat::Tiff);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Warning" color="warning" %}}
Le support du format TIFF n’est pas garanti dans les versions de Java antérieures à JDK 9.
{{% /alert %}}

## **Convertir toutes les diapositives en images**

Parcourez la collection de diapositives pour convertir l’ensemble de la présentation en une série d’images. Les diapositives masquées sont incluses, sauf si vous les excluez explicitement.

L’exemple suivant rend chaque diapositive en image JPEG avec des facteurs d’échelle horizontaux et verticaux égaux à 2 :

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage($scaleX, $scaleY);
        try {
            $image->save("Slide_" . $index . ".jpg", ImageFormat::Jpeg);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Créer une sortie Enhanced Metafile**

Enhanced Metafile (EMF) est utile lorsque des graphiques vectoriels doivent être échangés avec Microsoft Office ou d’autres applications Windows qui prennent en charge les métafichiers Windows. Contrairement à une image basée sur des pixels, un EMF peut conserver les opérations de dessin vectoriel qui s’adaptent sans perte de netteté. Cependant, EMF est principalement un format de compatibilité pour les applications disposant d’un support de métafichier Windows, et non un format d’échange universel. De plus, le contenu complexe d’une diapositive, tel que les images bitmap et certains effets, peut être stocké sous forme d’éléments rasterisés à l’intérieur du conteneur de métafichier vectoriel.

### **Exporter une diapositive en EMF**

La méthode [Slide::writeAsEmf](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slide/#writeAsEmf) écrit une diapositive dans un flux cible au format EMF. L’exemple suivant charge une présentation, sélectionne la première diapositive et l’écrit dans un flux de fichier EMF :

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $emfStream = new Java("java.io.FileOutputStream", "Slide_0.emf");
    try {
        $slide->writeAsEmf($emfStream);
    } finally {
        $emfStream->close();
    }
} finally {
    $presentation->dispose();
}
```

L’appelant possède le flux passé à [Slide::writeAsEmf](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slide/#writeAsEmf) et est responsable de le fermer, comme indiqué ci‑dessus.

### **Convertir une image SVG en EMF et l’ajouter à une présentation**

Utilisez [SvgImage::writeAsEmf](https://reference.aspose.com/slides/fr/php-java/aspose.slides/svgimage/#writeAsEmf) pour convertir le contenu SVG en EMF. Les octets résultants peuvent être ajoutés à la présentation via [ImageCollection::addImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/imagecollection/#addImage) et placés sur une diapositive avec [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shapecollection/#addPictureFrame).

L’exemple suivant crée un [SvgImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/svgimage/) à partir de balises SVG, le convertit en EMF en mémoire, insère le métafichier sur la première diapositive et enregistre la présentation :

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SvgImage;

$svgContent = '<svg xmlns="http://www.w3.org/2000/svg" width="200" height="100"><rect width="200" height="100" fill="#4472C4"/></svg>';
$svgImage = new SvgImage($svgContent);

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $emfStream = new Java("java.io.ByteArrayOutputStream");
    try {
        $svgImage->writeAsEmf($emfStream);

        $emfData = $emfStream->toByteArray();
        $image = $presentation->getImages()->addImage($emfData);
        $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 100, $image);
    } finally {
        $emfStream->close();
    }

    $presentation->save("Presentation_with_emf.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[SvgImage::writeAsEmf](https://reference.aspose.com/slides/fr/php-java/aspose.slides/svgimage/#writeAsEmf) ne prend pas la possession du flux de destination. Un [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) stocke toutes les données générées en mémoire, de sorte qu’aucune réinitialisation de position n’est requise avant d’appeler `toByteArray`. Le tableau d’octets retourné reste valide après la fermeture du flux.

La génération d’EMF est disponible sur les systèmes d’exploitation pris en charge par l’Aspose.Slides for PHP via Java sélectionné et la configuration du JDK, mais le rendu peut différer d’une plateforme à l’autre lorsque les polices ou les dépendances graphiques sont indisponibles. Installez les polices utilisées par le contenu source ou configurez des substitutions appropriées, suivez les [platform requirements](/slides/fr/php-java/system-requirements/) pour Aspose.Slides for PHP via Java et validez le résultat dans l’application consommatrice d’EMF cible. Les applications Linux et macOS ont souvent un support limité ou incohérent pour l’affichage et l’édition des métafichiers Windows.

## **Rendu des emojis en couleur**

{{% alert title="Note" color="info" %}}
Pour rendre correctement les emojis en couleur lors de la conversion de diapositives de présentation en images, les polices emoji utilisées dans la présentation doivent être installées et disponibles sur le système effectuant la conversion. Par exemple, si la présentation utilise **Segoe UI Emoji** et que cette police est absente, les emojis peuvent apparaître en monochrome dans les images de sortie.
{{% /alert %}}

## **FAQ**

**Aspose.Slides prend‑il en charge le rendu des diapositives avec animations ?**

**Non.** La méthode [Slide::getImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slide/#getImage) rend une image statique de la diapositive et n’exporte pas les animations.

**Les diapositives masquées peuvent‑elles être exportées en images ?**

**Oui.** Les diapositives masquées peuvent être rendues comme des diapositives normales. Incluez‑les dans la boucle de traitement, comme le montre l’exemple ci‑dessus.

**Les ombres et autres effets sont‑ils conservés dans les images de diapositive ?**

**Oui.** Aspose.Slides rend les ombres, la transparence et les autres effets graphiques pris en charge dans les images de diapositives.