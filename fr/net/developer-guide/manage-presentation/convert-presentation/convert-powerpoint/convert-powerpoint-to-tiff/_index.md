---
title: Convertir des présentations PowerPoint en TIFF dans .NET
titlelink: PowerPoint en TIFF
type: docs
weight: 90
url: /fr/net/convert-powerpoint-to-tiff/
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
- .NET
- C#
- Aspose.Slides
description: "Apprenez à convertir facilement les présentations PowerPoint (PPT, PPTX) en images TIFF de haute qualité à l'aide d'Aspose.Slides pour .NET. Exemples de code C#."
---
## **Introduction**

TIFF (**Tagged Image File Format**) est un format d'image matricielle sans perte largement utilisé, connu pour sa qualité exceptionnelle et la préservation détaillée des graphiques. Les concepteurs, photographes et éditeurs de bureau choisissent souvent le TIFF pour conserver les calques, la précision des couleurs et les paramètres d'origine de leurs images.

Avec Aspose.Slides, vous pouvez convertir sans effort vos diapositives PowerPoint (PPT, PPTX) et OpenDocument (ODP) directement en images TIFF de haute qualité, garantissant que vos présentations conservent une fidélité visuelle maximale.

## **Convertir une présentation en TIFF**

En utilisant la méthode [Enregistrer](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/save/) fournie par la classe [Présentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/), vous pouvez rapidement convertir une présentation PowerPoint complète en TIFF. Les images TIFF générées correspondent à la taille de diapositive par défaut.

Ce code C# montre comment convertir une présentation PowerPoint en TIFF :

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanciez la classe Presentation qui représente un fichier de présentation (PPT, PPTX, ODP, etc.).
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    // Enregistrez la présentation au format TIFF.
    presentation.Save("Output.tiff", SaveFormat.Tiff);
}
```

## **Convertir une présentation en TIFF noir et blanc**

La propriété [BwConversionMode](https://reference.aspose.com/slides/fr/net/aspose.slides.export/tiffoptions/bwconversionmode/) de la classe [TiffOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/tiffoptions/) vous permet de spécifier l'algorithme utilisé lors de la conversion d'une diapositive ou d'une image couleur en TIFF noir et blanc. Notez que ce paramètre ne s'applique que lorsque la propriété [CompressionType](https://reference.aspose.com/slides/fr/net/aspose.slides.export/tiffoptions/compressiontype/) est définie sur `CCITT4` ou `CCITT3`.

{{% alert color="info" title="Remarque" %}}

[TiffOptions.BwConversionMode](https://reference.aspose.com/slides/fr/net/aspose.slides.export/tiffoptions/bwconversionmode/) est un paramètre au niveau de l'exportation qui sélectionne un algorithme de conversion de pixels pour l'image TIFF complète. Pour définir l'apparence d'une forme individuelle en mode d'affichage noir et blanc, utilisez [IShape.BlackWhiteMode](https://reference.aspose.com/slides/fr/net/aspose.slides/ishape/blackwhitemode/). Consultez [Contrôler le rendu noir et blanc des formes](/net/shape-formatting/#control-black-and-white-rendering-for-shapes) pour des exemples.

{{% /alert %}}

Supposons que nous ayons un fichier **sample.pptx** contenant la diapositive suivante :

![Une diapositive de présentation](slide_black_and_white.png)

Ce code C# montre comment convertir la diapositive couleur en TIFF noir et blanc :

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

TiffOptions tiffOptions = new TiffOptions
{
    CompressionType = TiffCompressionTypes.CCITT4,
    BwConversionMode = BlackWhiteConversionMode.Dithering
};

using (Presentation presentation = new Presentation("sample.pptx"))
{
    presentation.Save("output.tiff", SaveFormat.Tiff, tiffOptions);
}
```

Le résultat :

![TIFF noir et blanc](TIFF_black_and_white.png)

## **Convertir une présentation en TIFF avec taille personnalisée**

Si vous avez besoin d'une image TIFF avec des dimensions spécifiques, vous pouvez définir les valeurs souhaitées à l'aide des propriétés disponibles dans [TiffOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/tiffoptions/). Par exemple, la propriété [ImageSize](https://reference.aspose.com/slides/fr/net/aspose.slides.export/tiffoptions/imagesize/) vous permet de préciser la taille de l'image générée.

Ce code C# montre comment convertir une présentation PowerPoint en images TIFF avec une taille personnalisée :

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanciez la classe Presentation qui représente un fichier de présentation (PPT, PPTX, ODP, etc.).
using (Presentation presentation = new Presentation("sample.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();

    // Définissez le type de compression.
    tiffOptions.CompressionType = TiffCompressionTypes.Default;
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

    // Définissez le DPI de l'image.
    tiffOptions.DpiX = 200;
    tiffOptions.DpiY = 200;

    // Définissez la taille de l'image.
    tiffOptions.ImageSize = new Size(1728, 1078);

    tiffOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    // Enregistrez la présentation au format TIFF avec la taille spécifiée.
    presentation.Save("custom_size.tiff", SaveFormat.Tiff, tiffOptions);
}
```

## **Convertir une présentation en TIFF avec format de pixel d'image personnalisé**

En utilisant la propriété [PixelFormat](https://reference.aspose.com/slides/fr/net/aspose.slides.export/tiffoptions/pixelformat/) de la classe [TiffOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/tiffoptions), vous pouvez spécifier le format de pixel souhaité pour l'image TIFF résultante.

Ce code C# montre comment convertir une présentation PowerPoint en image TIFF avec un format de pixel personnalisé :

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanciez la classe Presentation qui représente un fichier de présentation (PPT, PPTX, ODP, etc.).
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();
   
    tiffOptions.PixelFormat = ImagePixelFormat.Format8bppIndexed;
    /*
    ImagePixelFormat contient les valeurs suivantes (comme indiqué dans la documentation) :
        Format1bppIndexed - 1 bit par pixel, indexé.
        Format4bppIndexed - 4 bits par pixel, indexé.
        Format8bppIndexed - 8 bits par pixel, indexé.
        Format24bppRgb    - 24 bits par pixel, RVB.
        Format32bppArgb   - 32 bits par pixel, ARGB.
    */

    // Enregistrez la présentation au format TIFF avec la taille d'image spécifiée.
    presentation.Save("Custom_Image_Pixel_Format.tiff", SaveFormat.Tiff, tiffOptions);
}
```

{{% alert title="Astuce" color="info" %}}

Découvrez le [convertisseur GRATUIT PowerPoint vers Affiche d'Aspose](https://products.aspose.app/slides/fr/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

## **FAQ**

**Puis-je convertir une diapositive individuelle plutôt que l'intégralité de la présentation PowerPoint en TIFF ?**

Oui. Aspose.Slides vous permet de convertir des diapositives individuelles des présentations PowerPoint et OpenDocument en images TIFF séparément.

**Existe‑t‑il une limite au nombre de diapositives lors de la conversion d’une présentation en TIFF ?**

Non, Aspose.Slides n’impose aucune restriction sur le nombre de diapositives. Vous pouvez convertir des présentations de toute taille au format TIFF.

**Les animations et les effets de transition PowerPoint sont‑ils conservés lors de la conversion des diapositives en TIFF ?**

Non, le TIFF est un format d'image statique. Ainsi, les animations et les effets de transition ne sont pas conservés ; seules des captures d'écran statiques des diapositives sont exportées.