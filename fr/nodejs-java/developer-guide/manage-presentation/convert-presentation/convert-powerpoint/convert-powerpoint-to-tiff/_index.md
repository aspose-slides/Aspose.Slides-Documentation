---
title: Convertir des présentations PowerPoint en TIFF avec JavaScript
titlelink: PowerPoint en TIFF
type: docs
weight: 90
url: /fr/nodejs-java/convert-powerpoint-to-tiff/
keywords:
- convertir PowerPoint
- convertir OpenDocument
- convertir présentation
- convertir diapositive
- PowerPoint en TIFF
- OpenDocument en TIFF
- présentation en TIFF
- diapositive en TIFF
- PPT en TIFF
- PPTX en TIFF
- ODP en TIFF
- Node.js
- JavaScript
- Aspose.Slides
description: "Découvrez comment convertir facilement des présentations PowerPoint (PPT, PPTX) et OpenDocument (ODP) en images TIFF de haute qualité à l’aide d’Aspose.Slides pour Node.js via Java. Guide étape par étape avec des exemples de code inclus."
---

## **Aperçu**

TIFF (**Tagged Image File Format**) est un format d'image raster sans perte largement utilisé, connu pour sa qualité exceptionnelle et la préservation détaillée des graphiques. Les concepteurs, photographes et éditeurs de bureau choisissent souvent le TIFF pour maintenir les calques, la précision des couleurs et les paramètres d'origine de leurs images.

Avec Aspose.Slides, vous pouvez convertir facilement vos diapositives PowerPoint (PPT, PPTX) et les diapositives OpenDocument (ODP) directement en images TIFF de haute qualité, garantissant que vos présentations conservent une fidélité visuelle maximale.

## **Convertir une présentation en TIFF**

En utilisant la méthode [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-) fournie par la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/), vous pouvez rapidement convertir une présentation PowerPoint complète en TIFF. Les images TIFF résultantes correspondent à la taille de diapositive par défaut.

Ce code JavaScript montre comment convertir une présentation PowerPoint en TIFF :
```js
// Instancier la classe Presentation qui représente un fichier de présentation (PPT, PPTX, ODP, etc.).
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    // Enregistrer la présentation au format TIFF.
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```


## **Convertir une présentation en TIFF noir et blanc**

La méthode [setBwConversionMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) de la classe [TiffOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/) vous permet de spécifier l'algorithme utilisé lors de la conversion d'une diapositive ou d'une image couleur en TIFF noir et blanc. Notez que ce paramètre s'applique uniquement lorsque la méthode [setCompressionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/#setCompressionType-int-) est définie sur `CCITT4` ou `CCITT3`.

Supposons que nous ayons un fichier "sample.pptx" avec la diapositive suivante :
![Une diapositive de présentation](slide_black_and_white.png)

Ce code JavaScript montre comment convertir la diapositive couleur en TIFF noir et blanc :
```js
let tiffOptions = new aspose.slides.TiffOptions();
tiffOptions.setCompressionType(aspose.slides.TiffCompressionTypes.CCITT4);
tiffOptions.setBwConversionMode(aspose.slides.BlackWhiteConversionMode.Dithering);

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```


Le résultat :
![TIFF noir et blanc](TIFF_black_and_white.png)

## **Convertir une présentation en TIFF avec taille personnalisée**

Si vous avez besoin d'une image TIFF avec des dimensions spécifiques, vous pouvez définir les valeurs souhaitées en utilisant les méthodes disponibles dans [TiffOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/). Par exemple, la méthode [setImageSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/#setImageSize) vous permet de définir la taille de l'image résultante.

Ce code JavaScript montre comment convertir une présentation PowerPoint en images TIFF avec une taille personnalisée :
```js
// Instancier la classe Presentation qui représente un fichier de présentation (PPT, PPTX, ODP, etc.).
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    // Définir le type de compression.
    tiffOptions.setCompressionType(aspose.slides.TiffCompressionTypes.Default);
    /*
    Types de compression :
        Default - Spécifie le schéma de compression par défaut (LZW).
        None - Spécifie aucune compression.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // La profondeur dépend du type de compression et ne peut pas être définie manuellement.

    // Définir le DPI de l'image.
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // Définir la taille de l'image.
    tiffOptions.setImageSize(java.newInstanceSync("java.awt.Dimension", 1728, 1078));

    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Enregistrer la présentation en TIFF avec la taille spécifiée.
    presentation.save("tiff-ImageSize.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```


## **Convertir une présentation en TIFF avec format de pixel d'image personnalisé**

En utilisant la méthode [setPixelFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/#setPixelFormat) de la classe [TiffOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/), vous pouvez spécifier le format de pixel souhaité pour l'image TIFF résultante.

Ce code JavaScript montre comment convertir une présentation PowerPoint en image TIFF avec un format de pixel personnalisé :
```js
// Instancier la classe Presentation qui représente un fichier de présentation (PPT, PPTX, ODP, etc.).
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat contient les valeurs suivantes (tel qu’indiqué dans la documentation) :
        Format1bppIndexed - 1 bit par pixel, indexé.
        Format4bppIndexed - 4 bits par pixel, indexé.
        Format8bppIndexed - 8 bits par pixel, indexé.
        Format24bppRgb    - 24 bits par pixel, RGB.
        Format32bppArgb   - 32 bits par pixel, ARGB.
    */

    /// Enregistrer la présentation en TIFF avec la taille d’image spécifiée.
    presentation.save("Tiff-PixelFormat.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```


{{% alert title="Conseil" color="primary" %}}
Découvrez le [convertisseur GRATUIT PowerPoint en Affiche](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) d'Aspose.
{{% /alert %}}

## **FAQ**

**Puis-je convertir une diapositive individuelle au lieu de l'ensemble de la présentation PowerPoint en TIFF ?**

Oui. Aspose.Slides vous permet de convertir des diapositives individuelles provenant de présentations PowerPoint et OpenDocument en images TIFF séparément.

**Existe-t-il une limite au nombre de diapositives lors de la conversion d'une présentation en TIFF ?**

Non, Aspose.Slides n'impose aucune restriction sur le nombre de diapositives. Vous pouvez convertir des présentations de toute taille au format TIFF.

**Les animations et effets de transition PowerPoint sont-ils conservés lors de la conversion des diapositives en TIFF ?**

Non, le TIFF est un format d'image statique. Par conséquent, les animations et les effets de transition ne sont pas conservés ; seules des captures d'écran statiques des diapositives sont exportées.