---
title: Converti le presentazioni PowerPoint in TIFF in PHP
titlelink: PowerPoint a TIFF
type: docs
weight: 90
url: /it/php-java/convert-powerpoint-to-tiff/
keywords:
- converti PowerPoint
- converti OpenDocument
- converti presentazione
- converti diapositiva
- converti PPT
- converti PPTX
- PowerPoint a TIFF
- presentazione a TIFF
- diapositiva a TIFF
- PPT a TIFF
- PPTX a TIFF
- salva PPT come TIFF
- salva PPTX come TIFF
- esporta PPT in TIFF
- esporta PPTX in TIFF
- PHP
- Aspose.Slides
description: "Scopri come convertire facilmente le presentazioni PowerPoint (PPT, PPTX) in immagini TIFF di alta qualità utilizzando Aspose.Slides per PHP tramite Java, con esempi di codice."
---
## **Introduzione**

TIFF (**Tagged Image File Format**) è un formato raster senza perdita ampiamente usato, noto per la sua eccezionale qualità e la conservazione dettagliata della grafica. Designer, fotografi e pubblicatori desktop scelgono spesso TIFF per mantenere i livelli, la precisione dei colori e le impostazioni originali nelle loro immagini.

Utilizzando Aspose.Slides, è possibile convertire facilmente le diapositive PowerPoint (PPT, PPTX) e le diapositive OpenDocument (ODP) direttamente in immagini TIFF di alta qualità, garantendo che le presentazioni mantengano la massima fedeltà visiva. 

## **Convertire una presentazione in TIFF**

Utilizzando il metodo [save](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#save) fornito dalla classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/), è possibile convertire rapidamente un'intera presentazione PowerPoint in TIFF. Le immagini TIFF risultanti corrispondono alle dimensioni predefinite della diapositiva.

Questo codice dimostra come convertire una presentazione PowerPoint in TIFF:

```php
// Istanzia la classe Presentation che rappresenta un file di presentazione (PPT, PPTX, ODP, ecc.).
$presentation = new Presentation("presentation.pptx");
try {
    // Salva la presentazione come TIFF.
    $presentation->save("output.tiff", SaveFormat::Tiff);
} finally {
    $presentation->dispose();
}
```

## **Convertire una presentazione in TIFF in bianco e nero**

Il metodo [setBwConversionMode](https://reference.aspose.com/slides/it/php-java/aspose.slides/tiffoptions/#setBwConversionMode) nella classe [TiffOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/tiffoptions/) consente di specificare l'algoritmo utilizzato quando si converte una diapositiva o un'immagine a colori in un TIFF in bianco e nero. Si noti che questa impostazione si applica solo quando il metodo [setCompressionType](https://reference.aspose.com/slides/it/php-java/aspose.slides/tiffoptions/#getCompressionType) è impostato su `CCITT4` o `CCITT3`.

Supponiamo di avere un file "sample.pptx" con la seguente diapositiva:

![Una diapositiva della presentazione](slide_black_and_white.png)

Questo codice dimostra come convertire la diapositiva a colori in un TIFF in bianco e nero:

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

Il risultato:

![TIFF in bianco e nero](TIFF_black_and_white.png)

## **Convertire una presentazione in TIFF con dimensioni personalizzate**

Se è necessaria un'immagine TIFF con dimensioni specifiche, è possibile impostare i valori desiderati utilizzando i metodi disponibili in [TiffOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/tiffoptions/). Ad esempio, il metodo [setImageSize](https://reference.aspose.com/slides/it/php-java/aspose.slides/tiffoptions/#getImageSize) consente di definire la dimensione dell'immagine risultante.

Questo codice dimostra come convertire una presentazione PowerPoint in immagini TIFF con dimensioni personalizzate:

```php
// Istanzia la classe Presentation che rappresenta un file di presentazione (PPT, PPTX, ODP, ecc.).
$presentation = new Presentation("presentation.pptx");
try {
    $tiffOptions = new TiffOptions();

    // Imposta il tipo di compressione.
    $tiffOptions->setCompressionType(TiffCompressionTypes::Default);
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
    $tiffOptions->setDpiX(200);
    $tiffOptions->setDpiY(200);

    // Imposta le dimensioni dell'immagine.
    $tiffOptions->setImageSize(new Java("java.awt.Dimension", 1728, 1078));

    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull);
    $tiffOptions->setSlidesLayoutOptions($notesOptions);

    // Salva la presentazione come TIFF con le dimensioni specificate.
    $presentation->save("tiff-ImageSize.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

## **Convertire una presentazione in TIFF con formato pixel immagine personalizzato**

Utilizzando il metodo [setPixelFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/tiffoptions/#getPixelFormat) della classe [TiffOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/tiffoptions/), è possibile specificare il formato pixel preferito per l'immagine TIFF risultante.

Questo codice dimostra come convertire una presentazione PowerPoint in un'immagine TIFF con un formato pixel personalizzato:

```php
// Istanzia la classe Presentation che rappresenta un file di presentazione (PPT, PPTX, ODP, ecc.).
$presentation = new Presentation("presentation.pptx");
try {
    $tiffOptions = new TiffOptions();

    $tiffOptions->setPixelFormat(ImagePixelFormat::Format8bppIndexed);
    /*
    ImagePixelFormat contiene i seguenti valori (come indicato nella documentazione):
        Format1bppIndexed - 1 bit per pixel, indicizzato.
        Format4bppIndexed - 4 bit per pixel, indicizzato.
        Format8bppIndexed - 8 bit per pixel, indicizzato.
        Format24bppRgb    - 24 bit per pixel, RGB.
        Format32bppArgb   - 32 bit per pixel, ARGB.
    */

    // Salva la presentazione come TIFF con le dimensioni dell'immagine specificate.
    $presentation->save("Tiff-PixelFormat.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Tip" color="primary" %}}
Dai un'occhiata al convertitore GRATUITO di Aspose da PowerPoint a Poster [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/it/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

**Posso convertire una singola diapositiva anziché l'intera presentazione PowerPoint in TIFF?**

Sì. Aspose.Slides consente di convertire singole diapositive da presentazioni PowerPoint e OpenDocument in immagini TIFF separatamente.

**Esiste un limite al numero di diapositive durante la conversione di una presentazione in TIFF?**

No, Aspose.Slides non impone alcuna restrizione sul numero di diapositive. È possibile convertire presentazioni di qualsiasi dimensione in formato TIFF.

**Le animazioni e gli effetti di transizione di PowerPoint vengono conservati durante la conversione delle diapositive in TIFF?**

No, TIFF è un formato immagine statico. Pertanto, le animazioni e gli effetti di transizione non vengono conservati; vengono esportate solo istantanee statiche delle diapositive.