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

TIFF (**Tagged Image File Format**) è un formato di immagine raster senza perdita ampiamente utilizzato, noto per la sua qualità eccezionale e la dettagliata conservazione della grafica. Designer, fotografi e editori desktop scelgono spesso TIFF per mantenere i livelli, la precisione del colore e le impostazioni originali nelle loro immagini.

Con Aspose.Slides, è possibile convertire facilmente le tue diapositive PowerPoint (PPT, PPTX) e le diapositive OpenDocument (ODP) direttamente in immagini TIFF di alta qualità, garantendo che le tue presentazioni mantengano la massima fedeltà visiva.

## **Convertire una presentazione in TIFF**

Utilizzando il metodo [save](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-) fornito dalla classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/), è possibile convertire rapidamente un'intera presentazione PowerPoint in TIFF. Le immagini TIFF risultanti corrispondono alle dimensioni predefinite delle diapositive.

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

Il metodo [setBwConversionMode](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) nella classe [TiffOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/tiffoptions/) consente di specificare l'algoritmo utilizzato quando si converte una diapositiva o immagine a colori in un TIFF in bianco e nero. Si noti che questa impostazione si applica solo quando il metodo [setCompressionType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/tiffoptions/#setCompressionType-int-) è impostato su `CCITT4` o `CCITT3`.

{{% alert color="info" title="Note" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) è un'impostazione a livello di esportazione che seleziona un algoritmo di conversione dei pixel per l'intera immagine TIFF. Per definire come dovrebbe apparire una singola forma quando la modalità di visualizzazione in bianco e nero è attiva, utilizzare [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/#setBlackWhiteMode). Vedere [Control Black-and-White Rendering for Shapes](/nodejs-java/shape-formatting/#control-black-and-white-rendering-for-shapes) per esempi.
{{% /alert %}}

Supponiamo di avere un file "sample.pptx" con la seguente diapositiva:

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

Se hai bisogno di un'immagine TIFF con dimensioni specifiche, puoi impostare i valori desiderati utilizzando i metodi disponibili in [TiffOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/tiffoptions/). Ad esempio, il metodo [setImageSize](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/tiffoptions/#setImageSize) consente di definire le dimensioni dell'immagine risultante.

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

    // Salva la presentazione come TIFF con le dimensioni specificate.
    presentation.save("tiff-ImageSize.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

## **Convertire una presentazione in TIFF con formato pixel dell'immagine personalizzato**

Utilizzando il metodo [setPixelFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/tiffoptions/#setPixelFormat) della classe [TiffOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/tiffoptions/), è possibile specificare il formato pixel preferito per l'immagine TIFF risultante.

Questo codice JavaScript dimostra come convertire una presentazione PowerPoint in un'immagine TIFF con un formato pixel personalizzato:

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

    /// Salva la presentazione come TIFF con le dimensioni immagine specificate.
    presentation.save("Tiff-PixelFormat.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Tip" color="info" %}}
Scopri il [convertitore gratuito PowerPoint in Poster](https://products.aspose.app/slides/it/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

**Posso convertire una singola diapositiva invece dell'intera presentazione PowerPoint in TIFF?**

Sì. Aspose.Slides consente di convertire singole diapositive da presentazioni PowerPoint e OpenDocument in immagini TIFF separatamente.

**Esiste un limite al numero di diapositive quando si converte una presentazione in TIFF?**

No, Aspose.Slides non impone alcuna restrizione sul numero di diapositive. È possibile convertire presentazioni di qualsiasi dimensione in formato TIFF.

**Le animazioni e gli effetti di transizione di PowerPoint vengono conservati quando si converte le diapositive in TIFF?**

No, TIFF è un formato di immagine statico. Pertanto, le animazioni e gli effetti di transizione non vengono conservati; vengono esportate solo istantanee statiche delle diapositive.