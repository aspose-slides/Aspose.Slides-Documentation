---
title: Converti le diapositive di presentazione in immagini in PHP
linktitle: Diapositiva in immagine
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
description: "Converti le diapositive da PPT, PPTX e ODP in immagini usando Aspose.Slides per PHP via Java — rendering veloce e di alta qualità con chiari esempi di codice."
---
## **Introduzione**

Aspose.Slides per PHP via Java ti consente di convertire facilmente le diapositive di presentazioni PowerPoint e OpenDocument in vari formati immagine, tra cui BMP, PNG, JPG (JPEG), GIF e altri.

Per convertire una diapositiva in un'immagine, segui questi passaggi:

1. Definisci le impostazioni di conversione desiderate e seleziona le diapositive che vuoi esportare usando:
    - la classe [TiffOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/tiffoptions/),
    - la classe [RenderingOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/renderingoptions/).
2. Genera l'immagine della diapositiva chiamando il metodo [getImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/slide/#getImage).

In Aspose.Slides per PHP via Java, un [IImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/iimage/) è una classe che ti permette di lavorare con immagini definite da dati pixel. Puoi utilizzare questa classe per salvare le immagini in un'ampia gamma di formati (BMP, JPG, PNG, ecc.).

## **Converti le diapositive in bitmap e salva le immagini in PNG**

Puoi convertire una diapositiva in un oggetto bitmap e utilizzarlo direttamente nella tua applicazione. In alternativa, puoi convertire una diapositiva in una bitmap e poi salvare l'immagine in JPEG o in qualsiasi altro formato preferito.

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

## **Converti le diapositive in immagini con dimensioni personalizzate**

Potresti aver bisogno di ottenere un'immagine a una certa dimensione. Utilizzando una sovraccarico del metodo [getImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/slide/#getImage), puoi convertire una diapositiva in un'immagine con dimensioni specifiche (larghezza e altezza). 

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

## **Converti le diapositive con note e commenti in immagini**

Alcune diapositive possono contenere note e commenti.

Aspose.Slides fornisce due classi[TiffOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/tiffoptions/) e [RenderingOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/renderingoptions/)—che ti permettono di controllare il rendering delle diapositive della presentazione in immagini. Entrambe le classi includono il metodo `setSlidesLayoutOptions`, che consente di configurare il rendering di note e commenti su una diapositiva durante la conversione in immagine.

Con la classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/notescommentslayoutingoptions/) puoi specificare la posizione preferita per note e commenti nell'immagine risultante.

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
In qualsiasi processo di conversione da diapositiva a immagine, il metodo [setNotesPosition](https://reference.aspose.com/slides/it/php-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) non può applicare `BottomFull` (per specificare la posizione delle note) perché il testo di una nota può essere troppo grande, impedendo di adattarsi alla dimensione dell'immagine specificata.
{{% /alert %}} 

## **Converti le diapositive in immagini usando le opzioni TIFF**

La classe [TiffOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/tiffoptions/) offre un controllo maggiore sull'immagine TIFF risultante consentendo di specificare parametri come dimensione, risoluzione, palette di colori e altro.

Questo codice dimostra un processo di conversione in cui le opzioni TIFF sono utilizzate per produrre un'immagine in bianco e nero con una risoluzione di 300 DPI e una dimensione di 2160 × 2800:

```php
// Carica un file di presentazione.
$presentation = new Presentation("sample.pptx");
try {
    // Ottieni la prima diapositiva dalla presentazione.
    $slide = $presentation->getSlides()->get_Item(0);

    // Configura le impostazioni dell'immagine TIFF in output.
    $options = new TiffOptions();
    $options->setImageSize(new Java("java.awt.Dimension", 2160, 2880));  // Imposta la dimensione dell'immagine.
    $options->setPixelFormat(ImagePixelFormat::Format1bppIndexed);       // Imposta il formato pixel (bianco e nero).
    $options->setDpiX(300);                                              // Imposta la risoluzione orizzontale.
    $options->setDpiY(300);                                              // Imposta la risoluzione verticale.
    
    // Converte la diapositiva in un'immagine con le opzioni specificate.
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

## **Converti tutte le diapositive in immagini**

Aspose.Slides ti consente di convertire tutte le diapositive di una presentazione in immagini, trasformando effettivamente l'intera presentazione in una serie di immagini.

Questo esempio di codice dimostra come convertire tutte le diapositive di una presentazione in immagini in PHP:

```php
$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation.pptx");
try {
    // Renderizza la presentazione in immagini diapositiva per diapositiva.
    for($i = 0; $i < java_values($presentation->getSlides()->size()) ; $i++) {
        // Controlla le diapositive nascoste (non renderizzare le diapositive nascoste).
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

## **FAQ**

**Aspose.Slides supporta il rendering di diapositive con animazioni?**

No, il metodo `getImage` salva solo un'immagine statica della diapositiva, senza animazioni.

**Le diapositive nascoste possono essere esportate in immagini?**

Sì, le diapositive nascoste possono essere elaborate come quelle normali. Assicurati solo che siano incluse nel ciclo di elaborazione.

**Le immagini possono essere salvate con ombre ed effetti?**

Sì, Aspose.Slides supporta il rendering di ombre, trasparenze e altri effetti grafici quando si salvano le diapositive come immagini.