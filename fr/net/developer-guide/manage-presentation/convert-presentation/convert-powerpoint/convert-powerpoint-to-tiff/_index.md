---
title: Convertir PowerPoint en TIFF
type: docs
weight: 90
url: /net/convert-powerpoint-to-tiff/
keywords: "Convertir la présentation PowerPoint, PowerPoint en TIFF, PPT en TIFF, PPTX en TIFF, C#, Csharp, .NET, Aspose.Slides"
description: "Convertir une présentation PowerPoint en TIFF en C# ou .NET."

---

TIFF (**Tagged Image File Format**) est un format d'image bitmap sans perte et de haute qualité. Les professionnels utilisent TIFF pour leurs besoins en design, photographie et publication assistée par ordinateur. Par exemple, si vous souhaitez préserver les calques et les paramètres de votre design ou image, vous voudrez peut-être enregistrer votre travail sous forme de fichier image TIFF.

Aspose.Slides vous permet de convertir les diapositives de PowerPoint directement en TIFF.

{{% alert title="Astuce" color="primary" %}}

Vous voudrez peut-être consulter le [convertisseur GRATUIT PowerPoint en Poster](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) d'Aspose.

{{% /alert %}}

## **Convertir PowerPoint en TIFF**

En utilisant la méthode [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) exposée par la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), vous pouvez rapidement convertir une présentation PowerPoint entière en TIFF. Les images TIFF résultantes correspondent à la taille par défaut des diapositives.

Ce code C# montre comment convertir PowerPoint en TIFF :

```c#
// Instancie un objet Presentation représentant un fichier de présentation
using (Presentation presentation = new Presentation("DemoFile.pptx"))
{
    // Enregistre la présentation en tant que TIFF
    presentation.Save("Tiffoutput_out.tiff", SaveFormat.Tiff);
}
```

## **Convertir PowerPoint en TIFF Noir et Blanc**

Dans Aspose.Slides 23.10, Aspose.Slides a ajouté une nouvelle propriété ([BwConversionMode](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/bwconversionmode/)) à la classe [TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/) pour vous permettre de spécifier l'algorithme à suivre lors de la conversion d'une diapositive ou d'une image colorée en TIFF noir et blanc. Notez que ce paramètre n'est appliqué que lorsque la propriété [CompressionType](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/compressiontype/) est définie sur `CCITT4` ou `CCITT3`.

Ce code C# montre comment convertir une diapositive ou une image colorée en TIFF noir et blanc :

```c#
var tiffOptions = new TiffOptions
{
    CompressionType = TiffCompressionTypes.CCITT4,
    BwConversionMode = BlackWhiteConversionMode.Dithering
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.tiff", SaveFormat.Tiff, tiffOptions);
```

## **Convertir PowerPoint en TIFF avec Taille Personnalisée**

Si vous avez besoin d'une image TIFF avec des dimensions définies, vous pouvez définir vos figures préférées grâce aux propriétés fournies sous [TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/). En utilisant la propriété [ImageSize](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/imagesize/), par exemple, vous pouvez définir une taille pour l'image résultante.

Ce code C# montre comment convertir PowerPoint en images TIFF avec taille personnalisée :

```c#
// Instancie un objet Presentation représentant un fichier de présentation
using (Presentation pres = new Presentation("Convert_Tiff_Custom.pptx"))
{
    // Instancie la classe TiffOptions
    TiffOptions opts = new TiffOptions();

    // Définit le type de compression
    opts.CompressionType = TiffCompressionTypes.Default;

    INotesCommentsLayoutingOptions notesOptions = opts.NotesCommentsLayouting;
    notesOptions.NotesPosition = NotesPositions.BottomFull;
    // Types de compression

    // Défaut - Spécifie le schéma de compression par défaut (LZW).
    // Aucune - Spécifie aucune compression.
    // CCITT3
    // CCITT4
    // LZW
    // RLE

    // La profondeur dépend du type de compression et ne peut pas être définie manuellement.
    // L'unité de résolution est toujours égale à "2" (points par pouce)

    // Définit le DPI de l'image
    opts.DpiX = 200;
    opts.DpiY = 100;

    // Définit la taille de l'image
    opts.ImageSize = new Size(1728, 1078);

    // Enregistre la présentation en TIFF avec la taille spécifiée
    pres.Save("TiffWithCustomSize_out.tiff", SaveFormat.Tiff, opts);
}
```


## **Convertir PowerPoint en TIFF avec Format de Pixel Image Personnalisé**

En utilisant la propriété [PixelFormat](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/pixelformat/) sous la classe [TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions), vous pouvez spécifier votre format de pixel préféré pour l'image TIFF résultante.

Ce code C# montre comment convertir PowerPoint en image TIFF avec un format de pixel personnalisé :

```c#
// Instancie un objet Presentation représentant un fichier de présentation
using (Presentation presentation = new Presentation("DemoFile.pptx"))
{
    TiffOptions options = new TiffOptions();
   
    options.PixelFormat = ImagePixelFormat.Format8bppIndexed;
    /*
    ImagePixelFormat contient les valeurs suivantes (comme indiqué dans la documentation) :
    Format1bppIndexed; // 1 bit par pixel, indexé.
    Format4bppIndexed; // 4 bits par pixel, indexé.
    Format8bppIndexed; // 8 bits par pixel, indexé.
    Format24bppRgb; // 24 bits par pixel, RVB.
    Format32bppArgb; // 32 bits par pixel, ARGB.
    */

    // Enregistre la présentation en TIFF avec la taille d'image spécifiée
    presentation.Save("Tiff_With_Custom_Image_Pixel_Format_out.tiff", SaveFormat.Tiff, options);
}
```