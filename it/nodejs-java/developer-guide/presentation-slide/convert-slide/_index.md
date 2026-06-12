---
title: Converti le diapositive di presentazione in immagini in JavaScript
linktitle: Diapositiva in immagine
type: docs
weight: 35
url: /it/nodejs-java/convert-slide/
keywords: 
- converti diapositiva
- esporta diapositiva
- diapositiva in immagine
- salva diapositiva come immagine
- diapositiva in PNG
- diapositiva in JPEG
- diapositiva in bitmap
- diapositiva in TIFF
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Converti le diapositive da PPT, PPTX e ODP in immagini in JavaScript usando Aspose.Slides per Node.js tramite Java — rendering veloce e di alta qualità con chiari esempi di codice."
---
## **Introduzione**

Aspose.Slides for Node.js tramite Java consente di convertire facilmente diapositive di presentazioni PowerPoint e OpenDocument in vari formati immagine, tra cui BMP, PNG, JPG (JPEG), GIF e altri.

Per convertire una diapositiva in un'immagine, segui questi passaggi:

1. Definisci le impostazioni di conversione desiderate e seleziona le diapositive che vuoi esportare utilizzando:
    - La classe [TiffOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/tiffoptions/), oppure
    - La classe [RenderingOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/renderingoptions/).
2. Genera l'immagine della diapositiva chiamando il metodo [getImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slide/#getImage).

In Aspose.Slides for Node.js tramite Java, un [IImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/iimage/) è una classe che consente di lavorare con immagini definite da dati di pixel. Puoi usare questa classe per salvare le immagini in un'ampia gamma di formati (BMP, JPG, PNG, ecc.).

## **Converti diapositive in bitmap e salva le immagini in PNG**

Puoi convertire una diapositiva in un oggetto bitmap e usarlo direttamente nella tua applicazione. In alternativa, puoi convertire una diapositiva in un bitmap e poi salvare l'immagine in JPEG o in qualsiasi altro formato preferito.

Questo codice JavaScript dimostra come convertire la prima diapositiva di una presentazione in un oggetto bitmap e poi salvare l'immagine in formato PNG:

```js
let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Converti la prima diapositiva della presentazione in una bitmap.
    let image = presentation.getSlides().get_Item(0).getImage();
    try {
        // Salva l'immagine nel formato PNG.
        image.save("Slide_0.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Converti diapositive in immagini con dimensioni personalizzate**

Potresti aver bisogno di ottenere un'immagine di una certa dimensione. Utilizzando una sovraccarico del metodo [getImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slide/#getImage), puoi convertire una diapositiva in un'immagine con dimensioni specifiche (larghezza e altezza).

Questo esempio di codice mostra come fare:

```js
let imageSize = java.newInstanceSync("java.awt.Dimension", 1820, 1040);

let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Converti la prima diapositiva della presentazione in una bitmap con la dimensione specificata.
    let image = presentation.getSlides().get_Item(0).getImage(imageSize);
    try {
        // Salva l'immagine nel formato JPEG.
        image.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Converti diapositive con note e commenti in immagini**

Alcune diapositive possono contenere note e commenti.

Aspose.Slides fornisce due classi—[TiffOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/tiffoptions/) e [RenderingOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/renderingoptions/)—che consentono di controllare il rendering delle diapositive di presentazione in immagini. Entrambe le classi includono il metodo `setSlidesLayoutOptions`, che permette di configurare il rendering di note e commenti su una diapositiva durante la conversione in immagine.

Con la classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/notescommentslayoutingoptions/) è possibile specificare la posizione preferita per note e commenti nell'immagine risultante.

Questo codice JavaScript dimostra come convertire una diapositiva con note e commenti:

```js
const scaleX = 2;
const scaleY = scaleX;

// Load a presentation file.
let presentation = new aspose.slides.Presentation("Presentation_with_notes_and_comments.pptx");
try {
    let notesCommentsOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);                  // Imposta la posizione delle note.
    notesCommentsOptions.setCommentsPosition(aspose.slides.CommentsPositions.Right);                      // Imposta la posizione dei commenti.
    notesCommentsOptions.setCommentsAreaWidth(500);                                                       // Imposta la larghezza dell'area dei commenti.
    notesCommentsOptions.setCommentsAreaColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));  // Imposta il colore per l'area dei commenti.

    // Crea le opzioni di rendering.
    let options = new aspose.slides.RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);
 
    // Converti la prima diapositiva della presentazione in un'immagine.
    let image = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);
    try {
        // Salva l'immagine nel formato GIF.
        image.save("Image_with_notes_and_comments_0.gif", aspose.slides.ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Nota" color="warning" %}} 

In qualsiasi processo di conversione da diapositiva a immagine, il metodo [setNotesPosition](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) non può applicare `BottomFull` (per specificare la posizione delle note) perché il testo di una nota potrebbe essere troppo grande, rendendo impossibile adattarlo alla dimensione dell'immagine specificata.

{{% /alert %}} 

## **Converti diapositive in immagini usando le opzioni TIFF**

La classe [TiffOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/tiffoptions/) offre un maggiore controllo sull'immagine TIFF risultante consentendo di specificare parametri come dimensione, risoluzione, palette di colori e altro.

Questo codice JavaScript dimostra un processo di conversione in cui le opzioni TIFF sono usate per generare un'immagine in bianco e nero con una risoluzione di 300 DPI e una dimensione di 2160 × 2800:

```js
// Carica un file di presentazione.
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // Ottieni la prima diapositiva dalla presentazione.
    let slide = presentation.getSlides().get_Item(0);

    // Configura le impostazioni dell'immagine TIFF di output.
    let tiffOptions = new aspose.slides.TiffOptions();
    tiffOptions.setImageSize(java.newInstanceSync("java.awt.Dimension", 2160, 2880));  // Imposta la dimensione dell'immagine.
    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format1bppIndexed);      // Imposta il formato dei pixel (bianco e nero).
    tiffOptions.setDpiX(300);                                                          // Imposta la risoluzione orizzontale.
    tiffOptions.setDpiY(300);                                                          // Imposta la risoluzione verticale.

    // Converti la diapositiva in un'immagine con le opzioni specificate.
    let image = slide.getImage(tiffOptions);
    try {
        // Salva l'immagine nel formato TIFF.
        image.save("output.tiff", aspose.slides.ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Nota" color="warning" %}} 

Il supporto TIFF non è garantito nelle versioni precedenti al JDK 9.

{{% /alert %}} 

## **Converti tutte le diapositive in immagini**

Aspose.Slides consente di convertire tutte le diapositive di una presentazione in immagini, trasformando effettivamente l'intera presentazione in una serie di immagini.

Questo esempio di codice mostra come convertire tutte le diapositive di una presentazione in immagini in JavaScript:

```js
const scaleX = 2;
const scaleY = scaleX;

let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Renderizza la presentazione in immagini diapositiva per diapositiva.
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        // Controlla le diapositive nascoste (non renderizzare le diapositive nascoste).
        if (presentation.getSlides().get_Item(i).getHidden()) {
            continue;
        }

        // Converti la diapositiva in un'immagine.
        let image = presentation.getSlides().get_Item(i).getImage(scaleX, scaleY);
        try {
            // Salva l'immagine nel formato JPEG.
            image.save("Slide_" + i + ".jpg", aspose.slides.ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Aspose.Slides supporta il rendering di diapositive con animazioni?**

No, il metodo `getImage` salva solo un'immagine statica della diapositiva, senza animazioni.

**Le diapositive nascoste possono essere esportate come immagini?**

Sì, le diapositive nascoste possono essere elaborate come quelle regolari. Assicurati solo che siano incluse nel ciclo di elaborazione.

**Le immagini possono essere salvate con ombre ed effetti?**

Sì, Aspose.Slides supporta il rendering di ombre, trasparenza e altri effetti grafici quando si salvano le diapositive come immagini.