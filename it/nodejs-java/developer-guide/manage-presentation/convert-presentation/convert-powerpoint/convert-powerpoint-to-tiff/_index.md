---
title: Converti presentazioni PowerPoint in TIFF con JavaScript
titlelink: PowerPoint in TIFF
type: docs
weight: 90
url: /it/nodejs-java/convert-powerpoint-to-tiff/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Scopri come convertire facilmente le presentazioni PowerPoint (PPT, PPTX) in immagini TIFF di alta qualità utilizzando Aspose.Slides per Node.js, con esempi di codice JavaScript."
---
## **Introduzione**

TIFF (**Tagged Image File Format**) è un formato raster senza perdita molto diffuso, noto per la sua eccezionale qualità e la conservazione dettagliata della grafica. Designer, fotografi e editori desktop spesso scelgono TIFF per mantenere livelli, precisione del colore e impostazioni originali nelle loro immagini.

Utilizzando Aspose.Slides, è possibile convertire facilmente le slide PowerPoint (PPT, PPTX) e le slide OpenDocument (ODP) direttamente in immagini TIFF di alta qualità, garantendo che le presentazioni conservino la massima fedeltà visiva.

## **Convertire una presentazione in TIFF**

Utilizzando il metodo [save](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-) fornito dalla classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/), è possibile convertire rapidamente un’intera presentazione PowerPoint in TIFF. Le immagini TIFF risultanti corrispondono alle dimensioni predefinite della diapositiva.

Questo codice JavaScript dimostra come convertire una presentazione PowerPoint in TIFF:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Istanzia la classe Presentation che rappresenta un file di presentazione (PPT, PPTX, ODP, ecc.).
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    // Salva la presentazione come TIFF.
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **Convertire una presentazione in TIFF in bianco e nero**

Il metodo [setBwConversionMode](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) nella classe [TiffOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/tiffoptions/) consente di specificare l’algoritmo da utilizzare quando si converte una diapositiva o un’immagine a colori in un TIFF in bianco e nero. Nota che questa impostazione si applica solo quando il metodo [setCompressionType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/tiffoptions/#setCompressionType-int-) è impostato su `CCITT4` o `CCITT3`.

{{% alert color="info" title="Nota" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) è un’impostazione a livello di esportazione che seleziona un algoritmo di conversione dei pixel per l’intera immagine TIFF. Per definire come un singolo shape deve apparire quando è attiva la modalità bianco e nero, utilizzare [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/#setBlackWhiteMode). Vedi [Control Black-and-White Rendering for Shapes](/slides/it/nodejs-java/shape-formatting/#control-black-and-white-rendering-for-shapes) per esempi.
{{% /alert %}}

Supponiamo di avere un file “sample.pptx” con la seguente diapositiva:

![Una diapositiva della presentazione](slide_black_and_white.png)

Questo codice JavaScript dimostra come convertire la diapositiva a colori in un TIFF in bianco e nero:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

Il risultato:

![TIFF in bianco e nero](TIFF_black_and_white.png)

## **Convertire una presentazione in TIFF con dimensioni personalizzate**

Se è necessario un’immagine TIFF con dimensioni specifiche, è possibile impostare i valori desiderati utilizzando i metodi disponibili in [TiffOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/tiffoptions/). Ad esempio, il metodo [setImageSize](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/tiffoptions/#setImageSize) consente di definire la dimensione dell’immagine risultante.

Questo codice JavaScript dimostra come convertire una presentazione PowerPoint in immagini TIFF con dimensioni personalizzate:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Istanzia la classe Presentation che rappresenta un file di presentazione (PPT, PPTX, ODP, ecc.).
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    // Imposta il tipo di compressione.
    tiffOptions.setCompressionType(aspose.slides.TiffCompressionTypes.Default);
    /*
    Tipi di compressione:
        Default - Specifica lo schema di compressione predefinito (LZW).
        None - Specifica nessuna compressione.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // La profondità di colore è controllata dal formato pixel (vedi l'esempio sotto); CCITT3 e CCITT4 producono sempre 1 bit per pixel.

    // Imposta i DPI dell'immagine.
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // Imposta le dimensioni dell'immagine.
    tiffOptions.setImageSize(java.newInstanceSync("java.awt.Dimension", 1728, 1078));

    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Salva la presentazione come TIFF con la dimensione specificata.
    presentation.save("tiff-ImageSize.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

## **Convertire una presentazione in TIFF con formato pixel immagine personalizzato**

Utilizzando il metodo [setPixelFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/tiffoptions/#setPixelFormat) della classe [TiffOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/tiffoptions/), è possibile specificare il formato pixel preferito per l’immagine TIFF risultante.

Questo codice JavaScript dimostra come convertire una presentazione PowerPoint in un’immagine TIFF con un formato pixel personalizzato:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Istanzia la classe Presentation che rappresenta un file di presentazione (PPT, PPTX, ODP, ecc.).
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat contiene i seguenti valori (come indicato nella documentazione):
        Format1bppIndexed - 1 bit per pixel, indicizzato.
        Format4bppIndexed - 4 bit per pixel, indicizzato.
        Format8bppIndexed - 8 bit per pixel, indicizzato.
        Format24bppRgb    - 24 bit per pixel, RGB.
        Format32bppArgb   - 32 bit per pixel, ARGB.
    */

    /// Salva la presentazione come TIFF con le dimensioni dell'immagine specificate.
    presentation.save("Tiff-PixelFormat.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Suggerimento" color="info" %}}
Scopri il [converter GRATUITO PowerPoint to Poster di Aspose](https://products.aspose.app/slides/it/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

**Posso convertire una singola diapositiva invece dell’intera presentazione PowerPoint in TIFF?**

Sì. Aspose.Slides consente di convertire singole diapositive da presentazioni PowerPoint e OpenDocument in immagini TIFF separatamente.

**Esiste un limite al numero di diapositive quando si converte una presentazione in TIFF?**

No, Aspose.Slides non impone restrizioni sul numero di diapositive. È possibile convertire presentazioni di qualsiasi dimensione in formato TIFF.

**Le animazioni e gli effetti di transizione di PowerPoint vengono conservati quando si converte le diapositive in TIFF?**

No, TIFF è un formato immagine statico. Pertanto, le animazioni e gli effetti di transizione non vengono conservati; vengono esportate solo istantanee statiche delle diapositive.