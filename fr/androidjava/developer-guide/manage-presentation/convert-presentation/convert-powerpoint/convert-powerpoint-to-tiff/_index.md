---
title: Convertir les présentations PowerPoint en TIFF sur Android
titlelink: PowerPoint en TIFF
type: docs
weight: 90
url: /fr/androidjava/convert-powerpoint-to-tiff/
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
- Android
- Java
- Aspose.Slides
description: "Apprenez comment convertir facilement les présentations PowerPoint (PPT, PPTX) en images TIFF de haute qualité à l'aide d'Aspose.Slides pour Android, avec des exemples de code Java."
---
## **Introduction**

TIFF (**Tagged Image File Format**) est un format d'image matricielle sans perte largement utilisé, connu pour sa qualité exceptionnelle et la préservation détaillée des graphiques. Les concepteurs, photographes et éditeurs de bureau choisissent souvent le TIFF pour conserver les calques, la précision des couleurs et les paramètres d'origine de leurs images.

En utilisant Aspose.Slides, vous pouvez convertir sans effort vos diapositives PowerPoint (PPT, PPTX) et les diapositives OpenDocument (ODP) directement en images TIFF de haute qualité, garantissant que vos présentations conservent une fidélité visuelle maximale.

## **Convertir une présentation en TIFF**

En utilisant la méthode [save](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) fournie par la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/), vous pouvez rapidement convertir une présentation PowerPoint entière en TIFF. Les images TIFF résultantes correspondent à la taille par défaut des diapositives.

Ce code montre comment convertir une présentation PowerPoint en TIFF :

```java
import com.aspose.slides.*;

// Instanciez la classe Presentation qui représente un fichier de présentation (PPT, PPTX, ODP, etc.).
Presentation presentation = new Presentation("presentation.pptx");
try {
    // Enregistrez la présentation au format TIFF.
    presentation.save("output.tiff", SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **Convertir une présentation en TIFF noir et blanc**

La méthode [setBwConversionMode](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) dans la classe [TiffOptions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/tiffoptions/) vous permet de spécifier l'algorithme utilisé lors de la conversion d'une diapositive ou d'une image couleur en TIFF noir et blanc. Notez que ce paramètre s'applique uniquement lorsque la méthode [setCompressionType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-) est définie sur `CCITT4` ou `CCITT3`.

{{% alert color="info" title="Note" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) est un paramètre de niveau exportation qui sélectionne un algorithme de conversion de pixels pour l'image TIFF complète. Pour définir comment une forme individuelle doit apparaître lorsque le mode d'affichage noir et blanc est actif, utilisez [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-). Consultez [Contrôler le rendu noir et blanc des formes](/slides/fr/androidjava/shape-formatting/#control-black-and-white-rendering-for-shapes) pour des exemples.
{{% /alert %}}

Supposons que nous ayons un fichier "sample.pptx" avec la diapositive suivante :

![Une diapositive de présentation](slide_black_and_white.png)

Ce code montre comment convertir la diapositive couleur en TIFF noir et blanc :

```java
import com.aspose.slides.*;

TiffOptions tiffOptions = new TiffOptions();
tiffOptions.setCompressionType(TiffCompressionTypes.CCITT4);
tiffOptions.setBwConversionMode(BlackWhiteConversionMode.Dithering);

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

Le résultat :

![TIFF noir et blanc](TIFF_black_and_white.png)

## **Convertir une présentation en TIFF avec taille personnalisée**

Si vous avez besoin d'une image TIFF avec des dimensions spécifiques, vous pouvez définir les valeurs souhaitées à l'aide des méthodes disponibles dans [TiffOptions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/tiffoptions/). Par exemple, la méthode [setImageSize](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/tiffoptions/#setImageSize-com.aspose.slides.android.Size-) vous permet de définir la taille de l'image résultante.

Ce code montre comment convertir une présentation PowerPoint en images TIFF avec une taille personnalisée :

```java
import com.aspose.slides.*;
import com.aspose.slides.android.Size;

// Instanciez la classe Presentation qui représente un fichier de présentation (PPT, PPTX, ODP, etc.).
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    // Définissez le type de compression.
    tiffOptions.setCompressionType(TiffCompressionTypes.Default);
    /*
    Types de compression :
        Default - Spécifie le schéma de compression par défaut (LZW).
        None - Aucun type de compression.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // La profondeur dépend du type de compression et ne peut pas être définie manuellement.

    // Définissez le DPI de l'image.
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // Définissez la taille de l'image.
    tiffOptions.setImageSize(new Size(1728, 1078));

    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Enregistrez la présentation au format TIFF avec la taille spécifiée.
    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}   
```

## **Convertir une présentation en TIFF avec un format de pixel d'image personnalisé**

En utilisant la méthode [setPixelFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-) de la classe [TiffOptions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/tiffoptions/), vous pouvez spécifier le format de pixel souhaité pour l'image TIFF résultante.

Ce code montre comment convertir une présentation PowerPoint en image TIFF avec un format de pixel personnalisé :

```java
import com.aspose.slides.*;

// Instanciez la classe Presentation qui représente un fichier de présentation (PPT, PPTX, ODP, etc.).
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    tiffOptions.setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat contient les valeurs suivantes (comme indiqué dans la documentation) :
        Format1bppIndexed - 1 bit par pixel, indexé.
        Format4bppIndexed - 4 bits par pixel, indexé.
        Format8bppIndexed - 8 bits par pixel, indexé.
        Format24bppRgb    - 24 bits par pixel, RGB.
        Format32bppArgb   - 32 bits par pixel, ARGB.
    */
    
    // Enregistrez la présentation au format TIFF avec le format de pixel spécifié.
    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Astuce" color="info" %}}
Découvrez le [convertisseur GRATUIT PowerPoint en Poster](https://products.aspose.app/slides/fr/conversion/convert-ppt-to-poster-online) d'Aspose.
{{% /alert %}}

## **FAQ**

**Puis-je convertir une diapositive individuelle au lieu de toute la présentation PowerPoint en TIFF ?**

Oui. Aspose.Slides vous permet de convertir des diapositives individuelles provenant de présentations PowerPoint et OpenDocument en images TIFF séparément.

**Y a-t-il une limite au nombre de diapositives lors de la conversion d'une présentation en TIFF ?**

Non, Aspose.Slides n'impose aucune restriction quant au nombre de diapositives. Vous pouvez convertir des présentations de n'importe quelle taille au format TIFF.

**Les animations et les effets de transition PowerPoint sont-ils conservés lors de la conversion des diapositives en TIFF ?**

Non, le TIFF est un format d'image statique. Ainsi, les animations et les effets de transition ne sont pas conservés ; seules des captures d'écran statiques des diapositives sont exportées.