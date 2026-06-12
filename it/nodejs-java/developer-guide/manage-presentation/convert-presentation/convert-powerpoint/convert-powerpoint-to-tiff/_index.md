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
description: "Scopri come convertire facilmente presentazioni PowerPoint (PPT, PPTX) in immagini TIFF di alta qualità utilizzando Aspose.Slides per Node.js, con esempi di codice JavaScript."
---
## **Introduzione**

TIFF (**Tagged Image File Format**) è un formato di immagine raster senza perdita ampiamente utilizzato, noto per la sua qualità eccezionale e la conservazione dettagliata della grafica. Designer, fotografi e editori desktop spesso scelgono TIFF per mantenere i livelli, l'accuratezza del colore e le impostazioni originali nelle loro immagini.

Utilizzando Aspose.Slides, è possibile convertire facilmente le diapositive PowerPoint (PPT, PPTX) e le diapositive OpenDocument (ODP) direttamente in immagini TIFF di alta qualità, garantendo che le presentazioni mantengano la massima fedeltà visiva.

## **Convertire una Presentazione in TIFF**

Utilizzando il metodo [save](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-) fornito dalla classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/), è possibile convertire rapidamente un'intera presentazione PowerPoint in TIFF. Le immagini TIFF risultanti corrispondono alle dimensioni predefinite della diapositiva.

```js
// Istanzia la classe Presentation che rappresenta un file di presentazione (PPT, PPTX, ODP, ecc.).
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    // Salva la presentazione come TIFF.
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **Convertire una Presentazione in TIFF in Bianco e Nero**

Il metodo [setBwConversionMode](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) nella classe [TiffOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/tiffoptions/) consente di specificare l'algoritmo utilizzato durante la conversione di una diapositiva o immagine a colori in un TIFF in bianco e nero. Si noti che questa impostazione si applica solo quando il metodo [setCompressionType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/tiffoptions/#setCompressionType-int-) è impostato su `CCITT4` o `CCITT3`.

Supponiamo di avere un file "sample.pptx" con la seguente diapositiva:

![Una diapositiva di presentazione](slide_black_and_white.png)

Questo codice JavaScript dimostra come convertire la diapositiva a colori in un TIFF in bianco e nero:

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

Il risultato:

![TIFF in bianco e nero](TIFF_black_and_white.png)

## **Convertire una Presentazione in TIFF con Dimensioni Personalizzate**

Se è necessaria un'immagine TIFF con dimensioni specifiche, è possibile impostare i valori desiderati utilizzando i metodi disponibili nella classe [TiffOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/tiffoptions/). Ad esempio, il metodo [setImageSize](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/tiffoptions/#setImageSize) consente di definire le dimensioni dell'immagine risultante.

Questo codice JavaScript dimostra come convertire una presentazione PowerPoint in immagini TIFF con dimensioni personalizzate:

```js
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

    // La profondità dipende dal tipo di compressione e non può essere impostata manualmente.

    // Imposta il DPI dell'immagine.
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

## **Convertire una Presentazione in TIFF con Formato Pixel dell'Immagine Personalizzato**

Utilizzando il metodo [setPixelFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/tiffoptions/#setPixelFormat) della classe [TiffOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/tiffoptions/), è possibile specificare il formato pixel preferito per l'immagine TIFF risultante.

Questo codice JavaScript dimostra come convertire una presentazione PowerPoint in un'immagine TIFF con un formato pixel personalizzato:

```js
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

{{% alert title="Tip" color="primary" %}}
Scopri il [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/it/conversion/convert-ppt-to-poster-online) di Aspose.
{{% /alert %}}

## **FAQ**

**Posso convertire una diapositiva individuale invece dell'intera presentazione PowerPoint in TIFF?**

Sì. Aspose.Slides consente di convertire singole diapositive da presentazioni PowerPoint e OpenDocument in immagini TIFF separatamente.

**Esiste un limite al numero di diapositive quando si converte una presentazione in TIFF?**

No, Aspose.Slides non impone alcuna restrizione sul numero di diapositive. È possibile convertire presentazioni di qualsiasi dimensione in formato TIFF.

**Le animazioni e gli effetti di transizione di PowerPoint vengono preservati quando si convertono le diapositive in TIFF?**

No, TIFF è un formato di immagine statico. Pertanto, le animazioni e gli effetti di transizione non vengono preservati; vengono esportate solo istantanee statiche delle diapositive.