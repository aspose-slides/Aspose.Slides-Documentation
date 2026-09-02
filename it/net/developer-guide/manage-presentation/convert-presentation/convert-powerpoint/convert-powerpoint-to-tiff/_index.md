---
title: Converti le presentazioni PowerPoint in TIFF con .NET
titlelink: PowerPoint in TIFF
type: docs
weight: 90
url: /it/net/convert-powerpoint-to-tiff/
keywords:
- converti PowerPoint
- converti OpenDocument
- converti presentazione
- converti diapositiva
- converti PPT
- converti PPTX
- PowerPoint in TIFF
- presentazione in TIFF
- diapositiva in TIFF
- PPT in TIFF
- PPTX in TIFF
- salva PPT come TIFF
- salva PPTX come TIFF
- esporta PPT in TIFF
- esporta PPTX in TIFF
- .NET
- C#
- Aspose.Slides
description: "Scopri come convertire facilmente le presentazioni PowerPoint (PPT, PPTX) in immagini TIFF di alta qualità utilizzando Aspose.Slides per .NET. Esempi di codice C#."
---
## **Introduzione**

TIFF (**Tagged Image File Format**) è un formato di immagine raster senza perdita ampiamente usato, noto per la sua eccezionale qualità e la conservazione dettagliata della grafica. Designer, fotografi e editori desktop spesso scelgono TIFF per mantenere i livelli, la precisione del colore e le impostazioni originali delle loro immagini.

Utilizzando Aspose.Slides, è possibile convertire facilmente le diapositive PowerPoint (PPT, PPTX) e le diapositive OpenDocument (ODP) direttamente in immagini TIFF di alta qualità, garantendo che le presentazioni mantengano la massima fedeltà visiva. 

## **Convertire una presentazione in TIFF**

Utilizzando il metodo [Save](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/save/) fornito dalla classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) è possibile convertire rapidamente un’intera presentazione PowerPoint in TIFF. Le immagini TIFF risultanti corrispondono alle dimensioni predefinite delle diapositive.

Questo codice C# mostra come convertire una presentazione PowerPoint in TIFF:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Istanzia la classe Presentation che rappresenta un file di presentazione (PPT, PPTX, ODP, ecc.).
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    // Salva la presentazione come TIFF.
    presentation.Save("Output.tiff", SaveFormat.Tiff);
}
```

## **Convertire una presentazione in TIFF in bianco e nero**

La proprietà [BwConversionMode](https://reference.aspose.com/slides/it/net/aspose.slides.export/tiffoptions/bwconversionmode/) nella classe [TiffOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/tiffoptions/) consente di specificare l’algoritmo usato quando si converte una diapositiva o un’immagine a colori in un TIFF in bianco e nero. Si noti che questa impostazione si applica solo quando la proprietà [CompressionType](https://reference.aspose.com/slides/it/net/aspose.slides.export/tiffoptions/compressiontype/) è impostata su `CCITT4` o `CCITT3`.

{{% alert color="info" title="Nota" %}}
[TiffOptions.BwConversionMode](https://reference.aspose.com/slides/it/net/aspose.slides.export/tiffoptions/bwconversionmode/) è un’impostazione a livello di esportazione che seleziona un algoritmo di conversione dei pixel per l’intera immagine TIFF. Per definire come dovrebbe apparire una singola forma quando è attiva la modalità di visualizzazione in bianco e nero, utilizzare [IShape.BlackWhiteMode](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/blackwhitemode/). Vedere [Control Black-and-White Rendering for Shapes](/slides/it/net/shape-formatting/#control-black-and-white-rendering-for-shapes) per esempi.
{{% /alert %}}

Supponiamo di avere un file "sample.pptx" con la seguente diapositiva:

![Una diapositiva della presentazione](slide_black_and_white.png)

Questo codice C# mostra come convertire la diapositiva a colori in un TIFF in bianco e nero:

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

Il risultato:

![TIFF in bianco e nero](TIFF_black_and_white.png)

## **Convertire una presentazione in TIFF con dimensioni personalizzate**

Se è necessario un’immagine TIFF con dimensioni specifiche, è possibile impostare i valori desiderati utilizzando le proprietà disponibili in [TiffOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/tiffoptions/). Ad esempio, la proprietà [ImageSize](https://reference.aspose.com/slides/it/net/aspose.slides.export/tiffoptions/imagesize/) consente di definire la dimensione dell’immagine risultante.

Questo codice C# mostra come convertire una presentazione PowerPoint in immagini TIFF con dimensioni personalizzate:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Istanzia la classe Presentation che rappresenta un file di presentazione (PPT, PPTX, ODP, ecc.).
using (Presentation presentation = new Presentation("sample.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();

    // Imposta il tipo di compressione.
    tiffOptions.CompressionType = TiffCompressionTypes.Default;
    /* 
    Tipi di compressione:
        Default - Specifica lo schema di compressione predefinito (LZW).
        None - Specifica nessuna compressione.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // La profondità dipende dal tipo di compressione e non può essere impostata manualmente.

    // Imposta i DPI dell'immagine.
    tiffOptions.DpiX = 200;
    tiffOptions.DpiY = 200;

    // Imposta la dimensione dell'immagine.
    tiffOptions.ImageSize = new Size(1728, 1078);

    tiffOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    // Salva la presentazione come TIFF con la dimensione specificata.
    presentation.Save("custom_size.tiff", SaveFormat.Tiff, tiffOptions);
}
```

## **Convertire una presentazione in TIFF con formato pixel dell’immagine personalizzato**

Utilizzando la proprietà [PixelFormat](https://reference.aspose.com/slides/it/net/aspose.slides.export/tiffoptions/pixelformat/) della classe [TiffOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/tiffoptions) è possibile specificare il formato pixel preferito per l’immagine TIFF risultante.

Questo codice C# mostra come convertire una presentazione PowerPoint in un’immagine TIFF con un formato pixel personalizzato:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Istanzia la classe Presentation che rappresenta un file di presentazione (PPT, PPTX, ODP, ecc.).
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();
   
    tiffOptions.PixelFormat = ImagePixelFormat.Format8bppIndexed;
    /*
    ImagePixelFormat contiene i seguenti valori (come indicato nella documentazione):
        Format1bppIndexed - 1 bit per pixel, indicizzato.
        Format4bppIndexed - 4 bit per pixel, indicizzato.
        Format8bppIndexed - 8 bit per pixel, indicizzato.
        Format24bppRgb    - 24 bit per pixel, RGB.
        Format32bppArgb   - 32 bit per pixel, ARGB.
    */

    // Salva la presentazione come TIFF con la dimensione dell'immagine specificata.
    presentation.Save("Custom_Image_Pixel_Format.tiff", SaveFormat.Tiff, tiffOptions);
}
```

{{% alert title="Suggerimento" color="info" %}}
Scopri il convertitore GRATUITO di Aspose da PowerPoint a Poster: [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/it/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **Domande frequenti**

**Posso convertire una singola diapositiva invece dell'intera presentazione PowerPoint in TIFF?**

Sì. Aspose.Slides consente di convertire singole diapositive da presentazioni PowerPoint e OpenDocument in immagini TIFF separatamente.

**Esiste qualche limite al numero di diapositive durante la conversione di una presentazione in TIFF?**

No, Aspose.Slides non impone alcuna restrizione sul numero di diapositive. È possibile convertire presentazioni di qualsiasi dimensione in formato TIFF.

**Le animazioni e gli effetti di transizione di PowerPoint sono conservati durante la conversione delle diapositive in TIFF?**

No, il TIFF è un formato immagine statico. Pertanto, le animazioni e gli effetti di transizione non sono conservati; vengono esportate solo istantanee statiche delle diapositive.