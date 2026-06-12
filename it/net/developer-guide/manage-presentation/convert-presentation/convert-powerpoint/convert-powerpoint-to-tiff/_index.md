---
title: Convertire le presentazioni PowerPoint in TIFF in .NET
titlelink: PowerPoint in TIFF
type: docs
weight: 90
url: /it/net/convert-powerpoint-to-tiff/
keywords:
- convertire PowerPoint
- convertire OpenDocument
- convertire presentazione
- convertire diapositiva
- convertire PPT
- convertire PPTX
- PowerPoint in TIFF
- presentazione in TIFF
- diapositiva in TIFF
- PPT in TIFF
- PPTX in TIFF
- salvare PPT come TIFF
- salvare PPTX come TIFF
- esportare PPT in TIFF
- esportare PPTX in TIFF
- .NET
- C#
- Aspose.Slides
description: "Impara come convertire facilmente presentazioni PowerPoint (PPT, PPTX) in immagini TIFF di alta qualità usando Aspose.Slides per .NET. Esempi di codice C#."
---
## **Introduzione**

TIFF (**Tagged Image File Format**) è un formato raster senza perdita ampiamente utilizzato, noto per la sua qualità eccezionale e per la conservazione dettagliata della grafica. Designer, fotografi e desktop publisher scelgono spesso TIFF per mantenere livelli, precisione del colore e impostazioni originali nelle loro immagini.

Utilizzando Aspose.Slides, è possibile convertire facilmente le diapositive PowerPoint (PPT, PPTX) e le diapositive OpenDocument (ODP) direttamente in immagini TIFF di alta qualità, garantendo che le presentazioni conservino la massima fedeltà visiva. 

## **Converti una presentazione in TIFF**

Utilizzando il metodo [Save](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/save/) fornito dalla classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/), è possibile convertire rapidamente un’intera presentazione PowerPoint in TIFF. Le immagini TIFF risultanti corrispondono alle dimensioni predefinite della diapositiva.

Questo codice C# dimostra come convertire una presentazione PowerPoint in TIFF:

```cs
// Istanzia la classe Presentation che rappresenta un file di presentazione (PPT, PPTX, ODP, ecc.).
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    // Salva la presentazione come TIFF.
    presentation.Save("Output.tiff", SaveFormat.Tiff);
}
```

## **Converti una presentazione in TIFF in bianco e nero**

La proprietà [BwConversionMode](https://reference.aspose.com/slides/it/net/aspose.slides.export/tiffoptions/bwconversionmode/) nella classe [TiffOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/tiffoptions/) consente di specificare l'algoritmo usato quando si converte una diapositiva o un’immagine a colori in un TIFF in bianco e nero. Si noti che questa impostazione si applica solo quando la proprietà [CompressionType](https://reference.aspose.com/slides/it/net/aspose.slides.export/tiffoptions/compressiontype/) è impostata su `CCITT4` o `CCITT3`.

Supponiamo di avere un file “sample.pptx” con la seguente diapositiva:

![Una diapositiva della presentazione](slide_black_and_white.png)

Questo codice C# dimostra come convertire la diapositiva a colori in un TIFF in bianco e nero:

```cs
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

## **Converti una presentazione in TIFF con dimensioni personalizzate**

Se necessiti di un’immagine TIFF con dimensioni specifiche, puoi impostare i valori desiderati tramite le proprietà disponibili in [TiffOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/tiffoptions/). Ad esempio, la proprietà [ImageSize](https://reference.aspose.com/slides/it/net/aspose.slides.export/tiffoptions/imagesize/) consente di definire la dimensione dell’immagine risultante.

Questo codice C# dimostra come convertire una presentazione PowerPoint in immagini TIFF con dimensioni personalizzate:

```cs
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

    // Imposta le dimensioni dell'immagine.
    tiffOptions.ImageSize = new Size(1728, 1078);

    tiffOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    // Salva la presentazione come TIFF con la dimensione specificata.
    presentation.Save("custom_size.tiff", SaveFormat.Tiff, tiffOptions);
}
```

## **Converti una presentazione in TIFF con formato pixel dell’immagine personalizzato**

Utilizzando la proprietà [PixelFormat](https://reference.aspose.com/slides/it/net/aspose.slides.export/tiffoptions/pixelformat/) della classe [TiffOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/tiffoptions) è possibile specificare il formato pixel preferito per l’immagine TIFF risultante.

Questo codice C# dimostra come convertire una presentazione PowerPoint in un’immagine TIFF con un formato pixel personalizzato:

```cs
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

{{% alert title="Suggerimento" color="primary" %}}

Scopri il [convertitore GRATUITO di PowerPoint in Poster di Aspose](https://products.aspose.app/slides/it/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

## **FAQ**

**Posso convertire una singola diapositiva invece dell’intera presentazione PowerPoint in TIFF?**

Sì. Aspose.Slides consente di convertire singole diapositive da presentazioni PowerPoint e OpenDocument in immagini TIFF separatamente.

**Esiste un limite al numero di diapositive durante la conversione di una presentazione in TIFF?**

No, Aspose.Slides non impone alcuna restrizione sul numero di diapositive. È possibile convertire presentazioni di qualsiasi dimensione in formato TIFF.

**Le animazioni e gli effetti di transizione di PowerPoint vengono conservati nella conversione delle diapositive in TIFF?**

No, TIFF è un formato di immagine statico. Pertanto, le animazioni e gli effetti di transizione non vengono conservati; vengono esportate solo istantanee statiche delle diapositive.