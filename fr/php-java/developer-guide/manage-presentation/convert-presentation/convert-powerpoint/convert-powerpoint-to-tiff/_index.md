---
title: Convertir des présentations PowerPoint en TIFF avec PHP
titlelink: PowerPoint en TIFF
type: docs
weight: 90
url: /fr/php-java/convert-powerpoint-to-tiff/
keywords:
  - convertir PowerPoint
  - convertir OpenDocument
  - convertir présentation
  - convertir diapositive
  - convertir PPT
  - convertir PPTX
  - PowerPoint en TIFF
  - présentation en TIFF
  - diapositive en TIFF
  - PPT en TIFF
  - PPTX en TIFF
  - enregistrer PPT en TIFF
  - enregistrer PPTX en TIFF
  - exporter PPT en TIFF
  - exporter PPTX en TIFF
  - PHP
  - Aspose.Slides
description: "Apprenez à convertir facilement les présentations PowerPoint (PPT, PPTX) en images TIFF de haute qualité en utilisant Aspose.Slides pour PHP via Java, avec des exemples de code."
---

## **Aperçu**

TIFF (**Tagged Image File Format**) est un format d'image raster sans perte largement utilisé, connu pour sa qualité exceptionnelle et la préservation détaillée des graphiques. Les designers, photographes et éditeurs de bureau choisissent souvent le TIFF pour conserver les calques, la précision des couleurs et les paramètres d'origine de leurs images.

Avec Aspose.Slides, vous pouvez convertir facilement vos diapositives PowerPoint (PPT, PPTX) et les diapositives OpenDocument (ODP) directement en images TIFF de haute qualité, garantissant que vos présentations conservent une fidélité visuelle maximale. 

## **Convertir une présentation en TIFF**

En utilisant la méthode [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) fournie par la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), vous pouvez rapidement convertir une présentation PowerPoint entière en TIFF. Les images TIFF résultantes correspondent à la taille de diapositive par défaut.

Ce code montre comment convertir une présentation PowerPoint en TIFF :
```php
// Instancier la classe Presentation qui représente un fichier de présentation (PPT, PPTX, ODP, etc.).
$presentation = new Presentation("presentation.pptx");
try {
    // Enregistrer la présentation au format TIFF.
    $presentation->save("output.tiff", SaveFormat::Tiff);
} finally {
    $presentation->dispose();
}
```


## **Convertir une présentation en TIFF noir et blanc**

La méthode [setBwConversionMode](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/#setBwConversionMode) dans la classe [TiffOptions](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/) vous permet de spécifier l'algorithme utilisé lors de la conversion d'une diapositive ou d'une image couleur en TIFF noir et blanc. Notez que ce réglage s'applique uniquement lorsque la méthode [setCompressionType](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/#getCompressionType) est définie sur `CCITT4` ou `CCITT3`.

Supposons que nous ayons un fichier "sample.pptx" avec la diapositive suivante :

![Une diapositive de présentation](slide_black_and_white.png)

Ce code montre comment convertir la diapositive couleur en TIFF noir et blanc :
```php
$tiffOptions = new TiffOptions();
$tiffOptions->setCompressionType(TiffCompressionTypes::CCITT4);
$tiffOptions->setBwConversionMode(BlackWhiteConversionMode::Dithering);

$presentation = new Presentation("sample.pptx");
try {
    $presentation->save("output.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```


Le résultat :

![TIFF noir et blanc](TIFF_black_and_white.png)

## **Convertir une présentation en TIFF avec taille personnalisée**

Si vous avez besoin d'une image TIFF avec des dimensions spécifiques, vous pouvez définir les valeurs souhaitées à l'aide des méthodes disponibles dans [TiffOptions](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/). Par exemple, la méthode [setImageSize](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/#getImageSize) vous permet de définir la taille de l'image résultante.

Ce code montre comment convertir une présentation PowerPoint en images TIFF avec une taille personnalisée :
```php
// Instancier la classe Presentation qui représente un fichier de présentation (PPT, PPTX, ODP, etc.).
$presentation = new Presentation("presentation.pptx");
try {
    $tiffOptions = new TiffOptions();

    // Définir le type de compression.
    $tiffOptions->setCompressionType(TiffCompressionTypes::Default);
    /*
    Types de compression :
        Default - Indique le schéma de compression par défaut (LZW).
        None - Indique aucune compression.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // La profondeur dépend du type de compression et ne peut pas être définie manuellement.

    // Définir le DPI de l'image.
    $tiffOptions->setDpiX(200);
    $tiffOptions->setDpiY(200);

    // Définir la taille de l'image.
    $tiffOptions->setImageSize(new Java("java.awt.Dimension", 1728, 1078));

    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull);
    $tiffOptions->setSlidesLayoutOptions($notesOptions);

    // Enregistrer la présentation au format TIFF avec la taille spécifiée.
    $presentation->save("tiff-ImageSize.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```


## **Convertir une présentation en TIFF avec format de pixel d'image personnalisé**

En utilisant la méthode [setPixelFormat](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/#getPixelFormat) de la classe [TiffOptions](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/), vous pouvez spécifier le format de pixel souhaité pour l'image TIFF résultante.

Ce code montre comment convertir une présentation PowerPoint en une image TIFF avec un format de pixel personnalisé :
```php
// Instancier la classe Presentation qui représente un fichier de présentation (PPT, PPTX, ODP, etc.).
$presentation = new Presentation("presentation.pptx");
try {
    $tiffOptions = new TiffOptions();

    $tiffOptions->setPixelFormat(ImagePixelFormat::Format8bppIndexed);
    /*
    ImagePixelFormat contient les valeurs suivantes (tel qu\'indiqué dans la documentation) :
        Format1bppIndexed - 1 bit par pixel, indexé.
        Format4bppIndexed - 4 bits par pixel, indexé.
        Format8bppIndexed - 8 bits par pixel, indexé.
        Format24bppRgb    - 24 bits par pixel, RVB.
        Format32bppArgb   - 32 bits par pixel, ARGB.
    */

    // Enregistrer la présentation au format TIFF avec la taille d'image spécifiée.
    $presentation->save("Tiff-PixelFormat.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```


{{% alert title="Astuce" color="primary" %}}
Découvrez le [convertisseur GRATUIT PowerPoint en affiche](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) d'Aspose.
{{% /alert %}}

## **FAQ**

**Puis-je convertir une diapositive individuelle au lieu de toute la présentation PowerPoint en TIFF ?**

Oui. Aspose.Slides vous permet de convertir des diapositives individuelles provenant de présentations PowerPoint et OpenDocument en images TIFF séparément.

**Y a-t-il une limite au nombre de diapositives lors de la conversion d'une présentation en TIFF ?**

Non, Aspose.Slides n'impose aucune restriction quant au nombre de diapositives. Vous pouvez convertir des présentations de n'importe quelle taille au format TIFF.

**Les animations et les effets de transition PowerPoint sont-ils conservés lors de la conversion des diapositives en TIFF ?**

Non, le TIFF est un format d'image statique. Ainsi, les animations et les effets de transition ne sont pas conservés ; seules des captures d'écran statiques des diapositives sont exportées.