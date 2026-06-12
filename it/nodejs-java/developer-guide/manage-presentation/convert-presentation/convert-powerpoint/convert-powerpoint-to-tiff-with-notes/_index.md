---
title: Converti presentazioni PowerPoint in TIFF con note in JavaScript
linktitle: PowerPoint in TIFF con note
type: docs
weight: 100
url: /it/nodejs-java/convert-powerpoint-to-tiff-with-notes/
keywords:
- converti PowerPoint
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
- PowerPoint con note
- presentazione con note
- diapositiva con note
- PPT con note
- PPTX con note
- TIFF con note
- Node.js
- JavaScript
- Aspose.Slides
description: "Converti le presentazioni PowerPoint in TIFF con note in JavaScript utilizzando Aspose.Slides per Node.js. Scopri come esportare le diapositive con note del relatore in modo efficiente."
---
## **Introduzione**

Aspose.Slides for Node.js via Java offre una soluzione semplice per convertire presentazioni PowerPoint e OpenDocument (PPT, PPTX e ODP) con note nel formato TIFF. Questo formato è ampiamente usato per l'archiviazione di immagini ad alta qualità, la stampa e l'archiviazione di documenti. Con Aspose.Slides, è possibile non solo esportare intere presentazioni con note del relatore, ma anche generare miniature delle diapositive nella visualizzazione Note Slide. Il processo di conversione è semplice ed efficiente, utilizzando il metodo `save` della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) per trasformare l'intera presentazione in una serie di immagini TIFF preservando note e layout.

## **Convertire una presentazione in TIFF con note**

Salvare una presentazione PowerPoint o OpenDocument in TIFF con note usando Aspose.Slides per Node.js via Java comporta i seguenti passaggi:

1. Istanziare la classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/): Caricare un file PowerPoint o OpenDocument.  
2. Configurare le opzioni di layout di output: Utilizzare la classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/notescommentslayoutingoptions/) per specificare come visualizzare note e commenti.  
3. Salvare la presentazione in TIFF: Passare le opzioni configurate al metodo [save](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#save).

Supponiamo di avere un file "speaker_notes.pptx" con la seguente diapositiva:

![La diapositiva della presentazione con note del relatore](slide_with_notes.png)

Il frammento di codice qui sotto dimostra come convertire la presentazione in un'immagine TIFF nella visualizzazione Note Slide utilizzando il metodo [setSlidesLayoutOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions).

```js
// Istanzia la classe Presentation che rappresenta un file di presentazione.
let presentation = new aspose.slides.Presentation("speaker_notes.pptx");
try {
    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull); // Mostra le note sotto la diapositiva.

    // Configura le opzioni TIFF con il layout delle note.
    let tiffOptions = new aspose.slides.TiffOptions();
    tiffOptions.setDpiX(300);
    tiffOptions.setDpiY(300);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Salva la presentazione in TIFF con le note del relatore.
    presentation.save("TIFF_with_notes.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

Il risultato:

![L'immagine TIFF con note del relatore](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Scopri il [Convertitore gratuito di PowerPoint in Poster di Aspose](https://products.aspose.app/slides/it/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **Domande frequenti**

**Posso controllare la posizione dell'area delle note nel TIFF risultante?**

Sì. Utilizzare le [impostazioni di layout delle note](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions) per scegliere tra opzioni come `None`, `BottomTruncated` o `BottomFull`, che rispettivamente nascondono le note, le adattano a una singola pagina o consentono loro di estendersi su pagine aggiuntive.

**Come posso ridurre le dimensioni di un file TIFF con note senza perdita visibile di qualità?**

Scegliere una [compressione efficiente](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/tiffoptions/setcompressiontype/) (ad esempio `LZW` o `RLE`), impostare una DPI ragionevole e, se accettabile, utilizzare un [formato pixel](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/tiffoptions/setpixelformat/) più basso (come 8 bpp o 1 bpp per il bianco e nero). Ridurre leggermente le [dimensioni dell'immagine](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/tiffoptions/setimagesize/) può anche aiutare senza compromettere visibilmente la leggibilità.

**Il carattere nelle note influisce sul risultato se i caratteri originali sono mancanti nel sistema?**

Sì. I caratteri mancanti attivano la [sostituzione](/slides/it/nodejs-java/font-selection-sequence/), che può modificare metriche e aspetto del testo. Per evitarlo, [fornire i caratteri richiesti](/slides/it/nodejs-java/custom-font/) o impostare un [carattere di fallback](/slides/it/nodejs-java/fallback-font/) predefinito in modo che vengano utilizzati i tipi di carattere previsti.