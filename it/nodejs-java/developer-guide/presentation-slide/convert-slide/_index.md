---
title: Convertire diapositive di presentazione in immagini in JavaScript
linktitle: Diapositiva in immagine
type: docs
weight: 35
url: /it/nodejs-java/convert-slide/
keywords:
- convertire diapositiva
- esportare diapositiva
- diapositiva in immagine
- salvare diapositiva come immagine
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
description: "Converti diapositive da PPT, PPTX e ODP in immagini in JavaScript utilizzando Aspose.Slides per Node.js tramite Java — rendering veloce e di alta qualità con esempi di codice chiari."
---
## **Introduzione**

Aspose.Slides per Node.js tramite Java consente di convertire facilmente diapositive di presentazioni PowerPoint e OpenDocument in diversi formati immagine, tra cui BMP, PNG, JPG (JPEG), GIF e altri.

Per convertire una diapositiva in un'immagine, segui questi passaggi:

1. Definisci le impostazioni di conversione desiderate e seleziona le diapositive che vuoi esportare usando:
    - La classe [TiffOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/tiffoptions/), oppure
    - La classe [RenderingOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/renderingoptions/).
2. Genera l'immagine della diapositiva chiamando il metodo [getImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slide/#getImage).

In Aspose.Slides per Node.js tramite Java, un [IImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/iimage/) è una classe che consente di lavorare con immagini definite da dati pixel. Puoi utilizzare questa classe per salvare immagini in un'ampia gamma di formati (BMP, JPG, PNG, ecc.).

## **Converti Diapositive in Bitmap e Salva le Immagini in PNG**

Puoi convertire una diapositiva in un oggetto bitmap e usarlo direttamente nella tua applicazione. In alternativa, puoi convertire una diapositiva in un bitmap e quindi salvare l'immagine in JPEG o in qualsiasi altro formato preferito.

Questo codice JavaScript dimostra come convertire la prima diapositiva di una presentazione in un oggetto bitmap e quindi salvare l'immagine in formato PNG:

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

## **Converti Diapositive in Immagini con Dimensioni Personalizzate**

Potresti aver bisogno di ottenere un'immagine di una certa dimensione. Utilizzando un overload del metodo [getImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slide/#getImage), è possibile convertire una diapositiva in un'immagine con dimensioni specifiche (larghezza e altezza). 

Questo esempio di codice dimostra come farlo:

```js
let imageSize = java.newInstanceSync("java.awt.Dimension", 1820, 1040);

let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Converti la prima diapositiva della presentazione in una bitmap con le dimensioni specificate.
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

## **Converti Diapositive con Note e Commenti in Immagini**

Alcune diapositive possono contenere note e commenti.

Aspose.Slides fornisce due classi—[TiffOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/tiffoptions/) e [RenderingOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/renderingoptions/)—che consentono di controllare il rendering delle diapositive di presentazione in immagini. Entrambe le classi includono il metodo `setSlidesLayoutOptions`, che permette di configurare il rendering di note e commenti su una diapositiva durante la conversione in immagine.

Con la classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/notescommentslayoutingoptions/) puoi specificare la posizione desiderata per note e commenti nell'immagine risultante.

Questo codice JavaScript dimostra come convertire una diapositiva con note e commenti:

```js
const scaleX = 2;
const scaleY = scaleX;

// Carica un file di presentazione.
let presentation = new aspose.slides.Presentation("Presentation_with_notes_and_comments.pptx");
try {
    let notesCommentsOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);                  // Imposta la posizione delle note.
    notesCommentsOptions.setCommentsPosition(aspose.slides.CommentsPositions.Right);                      // Imposta la posizione dei commenti.
    notesCommentsOptions.setCommentsAreaWidth(500);                                                       // Imposta la larghezza dell'area dei commenti.
    notesCommentsOptions.setCommentsAreaColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));  // Imposta il colore dell'area dei commenti.

    // Crea le opzioni di rendering.
    let options = new aspose.slides.RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);
 
    // Converte la prima diapositiva della presentazione in un'immagine.
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

{{% alert title="Note" color="warning" %}} 

In qualsiasi processo di conversione diapositiva-immagine, il metodo [setNotesPosition](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) non può applicare `BottomFull` (per specificare la posizione delle note) perché il testo di una nota potrebbe essere troppo grande, impedendone il posizionamento all'interno delle dimensioni specificate dell'immagine.

{{% /alert %}} 

## **Converti Diapositive in Immagini Usando le Opzioni TIFF**

La classe [TiffOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/tiffoptions/) offre un maggiore controllo sull'immagine TIFF risultante consentendo di specificare parametri come dimensione, risoluzione, palette di colori e altro.

Questo codice JavaScript dimostra un processo di conversione in cui le opzioni TIFF sono utilizzate per produrre un'immagine in bianco e nero con una risoluzione di 300 DPI e una dimensione di 2160 × 2800:

```js
// Carica un file di presentazione.
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // Ottieni la prima diapositiva dalla presentazione.
    let slide = presentation.getSlides().get_Item(0);

    // Configura le impostazioni dell'immagine TIFF di output.
    let tiffOptions = new aspose.slides.TiffOptions();
    tiffOptions.setImageSize(java.newInstanceSync("java.awt.Dimension", 2160, 2880));  // Imposta le dimensioni dell'immagine.
    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format1bppIndexed);      // Imposta il formato pixel (bianco e nero).
    tiffOptions.setDpiX(300);                                                          // Imposta la risoluzione orizzontale.
    tiffOptions.setDpiY(300);                                                          // Imposta la risoluzione verticale.

    // Converte la diapositiva in un'immagine con le opzioni specificate.
    let image = slide.getImage(tiffOptions);
    try {
        // Salva l'immagine in formato TIFF.
        image.save("output.tiff", aspose.slides.ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 

Il supporto TIFF non è garantito nelle versioni precedenti a JDK 9.

{{% /alert %}} 

## **Converti Tutte le Diapositive in Immagini**

Aspose.Slides consente di convertire tutte le diapositive di una presentazione in immagini, trasformando efficacemente l'intera presentazione in una serie di immagini.

Questo esempio di codice dimostra come convertire tutte le diapositive di una presentazione in immagini in JavaScript:

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

        // Converte la diapositiva in un'immagine.
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

## **Rendering di Emoji a Colori**

{{% alert title="Note" color="warning" %}} 
Per rendere correttamente le emoji a colori durante la conversione delle diapositive della presentazione in immagini, i font emoji utilizzati nella presentazione devono essere installati e disponibili sul sistema che esegue la conversione. Ad esempio, se la presentazione utilizza **Segoe UI Emoji** e questo font è assente, le emoji potrebbero apparire in monocromo nelle immagini di output.
{{% /alert %}}

## **FAQ**

**Aspose.Slides supporta il rendering di diapositive con animazioni?**

No, il metodo `getImage` salva solo un'immagine statica della diapositiva, senza animazioni.

**Le diapositive nascoste possono essere esportate come immagini?**

Sì, le diapositive nascoste possono essere elaborate come quelle normali. Basta assicurarsi che siano incluse nel ciclo di elaborazione.

**Le immagini possono essere salvate con ombre ed effetti?**

Sì, Aspose.Slides supporta il rendering di ombre, trasparenza e altri effetti grafici quando si salvano le diapositive come immagini.