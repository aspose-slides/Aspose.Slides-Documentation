---
title: Converti Diapositive di Presentazione in Immagini in PHP
linktitle: Diapositiva a Immagine
type: docs
weight: 35
url: /it/php-java/convert-slide/
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
- PHP
- Aspose.Slides
description: "Converti diapositive da PPT, PPTX e ODP in immagini usando Aspose.Slides per PHP via Java — rendering rapido e di alta qualità con chiari esempi di codice."
---
## **Introduzione**

Aspose.Slides per PHP via Java consente di convertire facilmente le diapositive di presentazioni PowerPoint e OpenDocument in vari formati immagine, inclusi BMP, PNG, JPG (JPEG), GIF e altri.

Per convertire una diapositiva in un'immagine, segui questi passaggi:

1. Definisci le impostazioni di conversione desiderate e seleziona le diapositive che vuoi esportare utilizzando:
    - la classe [TiffOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/tiffoptions/) o
    - la classe [RenderingOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/renderingoptions/).
2. Genera l'immagine della diapositiva chiamando il metodo [getImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/slide/#getImage).

In Aspose.Slides per PHP via Java, un [IImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/iimage/) è una classe che consente di lavorare con immagini definite da dati pixel. Puoi utilizzare questa classe per salvare le immagini in un'ampia gamma di formati (BMP, JPG, PNG, ecc.).

## **Converti Diapositive in Bitmap e Salva le Immagini in PNG**

Puoi convertire una diapositiva in un oggetto bitmap e usarlo direttamente nella tua applicazione. In alternativa, puoi convertire una diapositiva in una bitmap e poi salvare l'immagine in JPEG o in qualsiasi altro formato preferito.

Questo codice dimostra come convertire la prima diapositiva di una presentazione in un oggetto bitmap e poi salvare l'immagine in formato PNG:

```php
$presentation = new Presentation("Presentation.pptx");
try {
    // Converti la prima diapositiva della presentazione in una bitmap.
    $image = $presentation->getSlides()->get_Item(0)->getImage();
    try {
        // Salva l'immagine nel formato PNG.
        $image->save("Slide_0.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Converti Diapositive in Immagini con Dimensioni Personalizzate**

Potresti aver bisogno di ottenere un'immagine di una certa dimensione. Utilizzando una sovraccarico del metodo [getImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/slide/#getImage), è possibile convertire una diapositiva in un'immagine con dimensioni specifiche (larghezza e altezza).

Questo esempio di codice dimostra come farlo:

```php
$imageSize = new Java("java.awt.Dimension", 1820, 1040);

$presentation = new Presentation("Presentation.pptx");
try {
    // Converti la prima diapositiva della presentazione in una bitmap con le dimensioni specificate.
    $image = $presentation->getSlides()->get_Item(0)->getImage($imageSize);
    try {
        // Salva l'immagine nel formato JPEG.
        $image->save("Slide_0.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Converti Diapositive con Note e Commenti in Immagini**

Alcune diapositive possono contenere note e commenti.

Aspose.Slides fornisce due classi[TiffOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/tiffoptions/) e [RenderingOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/renderingoptions/)—che consentono di controllare il rendering delle diapositive della presentazione in immagini. Entrambe le classi includono il metodo `setSlidesLayoutOptions`, che permette di configurare il rendering di note e commenti su una diapositiva durante la conversione in immagine.

Con la classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/notescommentslayoutingoptions/) puoi specificare la posizione desiderata per note e commenti nell'immagine risultante.

Questo codice dimostra come convertire una diapositiva con note e commenti:

```php
$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    $notesCommentsOptions = new NotesCommentsLayoutingOptions();
    $notesCommentsOptions->setNotesPosition(NotesPositions::BottomTruncated);         // Imposta la posizione delle note.
    $notesCommentsOptions->setCommentsPosition(CommentsPositions::Right);             // Imposta la posizione dei commenti.
    $notesCommentsOptions->setCommentsAreaWidth(500);                                 // Imposta la larghezza dell'area dei commenti.
    $notesCommentsOptions->setCommentsAreaColor(java("java.awt.Color")->LIGHT_GRAY);  // Imposta il colore dell'area dei commenti.

    // Crea le opzioni di rendering.
    $options = new RenderingOptions();
    $options->setSlidesLayoutOptions($notesCommentsOptions);

    // Converti la prima diapositiva della presentazione in un'immagine.
    $image = $presentation->getSlides()->get_Item(0)->getImage($options, $scaleX, $scaleY);
    try {
        // Salva l'immagine nel formato GIF.
        $image->save("Image_with_notes_and_comments_0.gif", ImageFormat::Gif);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Note" color="warning" %}} 
In qualsiasi processo di conversione da diapositiva a immagine, il metodo [setNotesPosition](https://reference.aspose.com/slides/it/php-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) non può applicare `BottomFull` (per specificare la posizione delle note) perché il testo di una nota potrebbe essere troppo grande, impedendone l'adattamento alla dimensione specificata dell'immagine.
{{% /alert %}} 

## **Converti Diapositive in Immagini Utilizzando le Opzioni TIFF**

La classe [TiffOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/tiffoptions/) offre un maggiore controllo sull'immagine TIFF risultante consentendo di specificare parametri come dimensione, risoluzione, tavolozza colori e altro.

Questo codice dimostra un processo di conversione in cui le opzioni TIFF vengono utilizzate per produrre un'immagine in bianco e nero con una risoluzione di 300 DPI e una dimensione di 2160 × 2800:

```php
// Carica un file di presentazione.
$presentation = new Presentation("sample.pptx");
try {
    // Ottieni la prima diapositiva dalla presentazione.
    $slide = $presentation->getSlides()->get_Item(0);

    // Configura le impostazioni dell'immagine TIFF di output.
    $options = new TiffOptions();
    $options->setImageSize(new Java("java.awt.Dimension", 2160, 2880));  // Imposta la dimensione dell'immagine.
    $options->setPixelFormat(ImagePixelFormat::Format1bppIndexed);       // Imposta il formato pixel (bianco e nero).
    $options->setDpiX(300);                                              // Imposta la risoluzione orizzontale.
    $options->setDpiY(300);                                              // Imposta la risoluzione verticale.
    
    // Converti la diapositiva in un'immagine con le opzioni specificate.
    $image = $slide->getImage($options);
    try {
        // Salva l'immagine in formato TIFF.
        $image->save("output.tiff", ImageFormat::Tiff);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Note" color="warning" %}} 
Il supporto TIFF non è garantito nelle versioni precedenti a JDK 9.
{{% /alert %}} 

## **Converti Tutte le Diapositive in Immagini**

Aspose.Slides consente di convertire tutte le diapositive di una presentazione in immagini, trasformando efficacemente l'intera presentazione in una serie di immagini.

Questo esempio di codice dimostra come convertire tutte le diapositive di una presentazione in immagini in PHP:

```php
$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation.pptx");
try {
    // Esegui il rendering della presentazione in immagini diapositiva per diapositiva.
    for($i = 0; $i < java_values($presentation->getSlides()->size()) ; $i++) {
        // Gestisci le diapositive nascoste (non eseguire il rendering delle diapositive nascoste).
        if (java_values($presentation->getSlides()->get_Item($i)->getHidden())) {
            continue;
        }

        // Converti la diapositiva in un'immagine.
        $image = $presentation->getSlides()->get_Item($i)->getImage($scaleX, $scaleY);
        try {
            // Salva l'immagine nel formato JPEG.
            $image->save("Slide_" . $i . ".jpg", ImageFormat::Jpeg);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Rendering di Emoji a Colori**

{{% alert title="Note" color="warning" %}} 
Per rendere correttamente le emoji a colori durante la conversione delle diapositive della presentazione in immagini, i font emoji utilizzati nella presentazione devono essere installati e disponibili sul sistema che esegue la conversione. Ad esempio, se la presentazione utilizza **Segoe UI Emoji** e questo font non è presente, le emoji potrebbero apparire in monocromo nelle immagini di output.
{{% /alert %}}

## **FAQ**

**Aspose.Slides supporta il rendering di diapositive con animazioni?**

No, il metodo `getImage` salva solo un'immagine statica della diapositiva, senza animazioni.

**Le diapositive nascoste possono essere esportate come immagini?**

Sì, le diapositive nascoste possono essere elaborate come quelle normali. Assicurati solo che siano incluse nel ciclo di elaborazione.

**Le immagini possono essere salvate con ombre ed effetti?**

Sì, Aspose.Slides supporta il rendering di ombre, trasparenza e altri effetti grafici quando si salvano le diapositive come immagini.