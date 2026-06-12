---
title: Converti le presentazioni PowerPoint in TIFF con note in PHP
linktitle: PowerPoint in TIFF con note
type: docs
weight: 100
url: /it/php-java/convert-powerpoint-to-tiff-with-notes/
keywords:
- convertire PowerPoint
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
- PowerPoint con note
- presentazione con note
- diapositiva con note
- PPT con note
- PPTX con note
- TIFF con note
- PHP
- Aspose.Slides
description: "Converti le presentazioni PowerPoint in TIFF con note usando Aspose.Slides per PHP via Java. Scopri come esportare le diapositive con le note del relatore in modo efficiente."
---
## **Introduzione**

Aspose.Slides for PHP via Java offre una soluzione semplice per convertire presentazioni PowerPoint e OpenDocument (PPT, PPTX e ODP) con note nel formato TIFF. Questo formato è ampiamente utilizzato per l'archiviazione di immagini ad alta qualità, la stampa e la conservazione dei documenti. Con Aspose.Slides, è possibile non solo esportare intere presentazioni con note del relatore, ma anche generare miniature delle diapositive nella visualizzazione Note Slide. Il processo di conversione è semplice ed efficiente, utilizzando il metodo `save` della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/) per trasformare l'intera presentazione in una serie di immagini TIFF preservando note e layout.

## **Convertire una presentazione in TIFF con note**

Salvare una presentazione PowerPoint o OpenDocument in TIFF con note usando Aspose.Slides for PHP via Java richiede i seguenti passaggi:

1. Istanziare la classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/): Caricare un file PowerPoint o OpenDocument.  
2. Configurare le opzioni di layout di output: Utilizzare la classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/notescommentslayoutingoptions/) per specificare come devono essere visualizzate le note e i commenti.  
3. Salvare la presentazione in TIFF: Passare le opzioni configurate al metodo [save](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#save).

Supponiamo di avere un file "speaker_notes.pptx" con la seguente diapositiva:

![Diapositiva della presentazione con note del relatore](slide_with_notes.png)

Il frammento di codice di seguito dimostra come convertire la presentazione in un'immagine TIFF nella visualizzazione Note Slide utilizzando il metodo [setSlidesLayoutOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions).

```php
// Istanzia la classe Presentation che rappresenta un file di presentazione.
$presentation = new Presentation("speaker_notes.pptx");
try {
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull); // Visualizza le note sotto la diapositiva.

    // Configura le opzioni TIFF con il layout delle note.
    $tiffOptions = new TiffOptions();
    $tiffOptions->setDpiX(300);
    $tiffOptions->setDpiY(300);
    $tiffOptions->setSlidesLayoutOptions($notesOptions);

    // Salva la presentazione in TIFF con le note del relatore.
    $presentation->save("TIFF_with_notes.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

Il risultato:

![Immagine TIFF con note del relatore](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Scopri il Converter gratuito di PowerPoint in Poster di Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/it/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

**Posso controllare la posizione dell'area note nel TIFF risultante?**

Sì. Utilizzare le [impostazioni di layout delle note](https://reference.aspose.com/slides/it/php-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions) per scegliere tra opzioni come `None`, `BottomTruncated` o `BottomFull`, che rispettivamente nascondono le note, le adattano a una singola pagina o consentono loro di continuare su pagine aggiuntive.

**Come posso ridurre le dimensioni di un file TIFF con note senza una perdita visibile di qualità?**

Scegliere una [compressione efficiente](https://reference.aspose.com/slides/it/php-java/aspose.slides/tiffoptions/setcompressiontype/) (ad es. `LZW` o `RLE`), impostare un DPI ragionevole e, se accettabile, utilizzare un [formato pixel](https://reference.aspose.com/slides/it/php-java/aspose.slides/tiffoptions/setpixelformat/) inferiore (come 8 bpp o 1 bpp per monocromo). Ridurre leggermente le [dimensioni dell'immagine](https://reference.aspose.com/slides/it/php-java/aspose.slides/tiffoptions/setimagesize/) può aiutare senza compromettere visibilmente la leggibilità.

**Il carattere nelle note influisce sul risultato se i caratteri originali mancano nel sistema?**

Sì. I caratteri mancanti attivano la [sostituzione](/slides/it/php-java/font-selection-sequence/), che può modificare metriche e aspetto del testo. Per evitarlo, [fornire i caratteri richiesti](/slides/it/php-java/custom-font/) o impostare un [carattere di fallback](/slides/it/php-java/fallback-font/) predefinito in modo che vengano usati i tipi di carattere desiderati.