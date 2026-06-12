---
title: Converti le diapositive della presentazione in immagini in Java
linktitle: Diapositiva in immagine
type: docs
weight: 35
url: /it/java/convert-slide/
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
  - Java
  - Aspose.Slides
description: "Converti le diapositive da PPT, PPTX e ODP in immagini in Java utilizzando Aspose.Slides—rendering veloce e di alta qualità con esempi di codice chiari."
---
## **Introduzione**

Aspose.Slides for Java consente di convertire facilmente le diapositive di presentazioni PowerPoint e OpenDocument in vari formati immagine, tra cui BMP, PNG, JPG (JPEG), GIF e altri.

Per convertire una diapositiva in un'immagine, segui questi passaggi:

1. Definisci le impostazioni di conversione desiderate e seleziona le diapositive che vuoi esportare utilizzando:
    - L'interfaccia [ITiffOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/itiffoptions/),
    - L'interfaccia [IRenderingOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/irenderingoptions/).
2. Genera l'immagine della diapositiva chiamando il metodo [getImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-).

In Aspose.Slides for Java, un'interfaccia [IImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/iimage/) consente di lavorare con immagini definite da dati pixel. Puoi utilizzare questa interfaccia per salvare le immagini in un'ampia gamma di formati (BMP, JPG, PNG, ecc.).

## **Converti Diapositive in Bitmap e Salva le Immagini in PNG**

Puoi convertire una diapositiva in un oggetto bitmap e utilizzarlo direttamente nella tua applicazione. In alternativa, puoi convertire una diapositiva in un bitmap e quindi salvare l'immagine in JPEG o in qualsiasi altro formato preferito.

Questo codice dimostra come convertire la prima diapositiva di una presentazione in un oggetto bitmap e poi salvare l'immagine in formato PNG:

```java 
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Converti la prima diapositiva della presentazione in una bitmap.
    IImage image = presentation.getSlides().get_Item(0).getImage();
	try {
        // Salva l'immagine nel formato PNG.
        image.save("Slide_0.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Converti Diapositive in Immagini con Dimensioni Personalizzate**

Potresti aver bisogno di ottenere un'immagine di una certa dimensione. Utilizzando una sovraccarico del metodo [getImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-), puoi convertire una diapositiva in un'immagine con dimensioni specifiche (larghezza e altezza).

Questo esempio di codice mostra come fare:

```java 
Dimension imageSize = new Dimension(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Converti la prima diapositiva della presentazione in una bitmap con le dimensioni specificate.
    IImage image = presentation.getSlides().get_Item(0).getImage(imageSize);

    try {
        // Salva l'immagine nel formato JPEG.
        image.save("Slide_0.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Converti Diapositive con Note e Commenti in Immagini**

Alcune diapositive possono contenere note e commenti.

Aspose.Slides fornisce due interfacce—[ITiffOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/itiffoptions/) e [IRenderingOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/irenderingoptions/)—che consentono di controllare il rendering delle diapositive di presentazione in immagini. Entrambe le interfacce includono il metodo `setSlidesLayoutOptions`, che permette di configurare il rendering di note e commenti su una diapositiva durante la conversione in immagine.

Con la classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/notescommentslayoutingoptions/) puoi specificare la posizione desiderata per note e commenti nell'immagine risultante.

Questo codice dimostra come convertire una diapositiva con note e commenti:

```java 
float scaleX = 2;
float scaleY = scaleX;

// Carica un file di presentazione.
Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    NotesCommentsLayoutingOptions notesCommentsOptions = new NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(NotesPositions.BottomTruncated);  // Imposta la posizione delle note.
    notesCommentsOptions.setCommentsPosition(CommentsPositions.Right);      // Imposta la posizione dei commenti.
    notesCommentsOptions.setCommentsAreaWidth(500);                         // Imposta la larghezza dell'area dei commenti.
    notesCommentsOptions.setCommentsAreaColor(Color.LIGHT_GRAY);            // Imposta il colore dell'area dei commenti.

    // Crea le opzioni di rendering.
    RenderingOptions options = new RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);

    // Converti la prima diapositiva della presentazione in un'immagine.
    IImage image = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);

    try {
        // Salva l'immagine nel formato GIF.
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
In qualsiasi processo di conversione da diapositiva a immagine, il metodo [setNotesPosition](https://reference.aspose.com/slides/it/java/com.aspose.slides/inotescommentslayoutingoptions/#setNotesPosition-int-) non può applicare `BottomFull` (per specificare la posizione delle note) perché il testo di una nota può essere troppo grande, impedendo che si adatti alle dimensioni specificate dell'immagine.
{{% /alert %}} 

## **Converti Diapositive in Immagini Utilizzando le Opzioni TIFF**

L'interfaccia [ITiffOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/itiffoptions/) offre un maggiore controllo sull'immagine TIFF risultante, consentendo di specificare parametri come dimensione, risoluzione, tavolozza dei colori e altro.

Questo codice dimostra un processo di conversione in cui le opzioni TIFF vengono utilizzate per produrre un'immagine in bianco e nero con risoluzione di 300 DPI e dimensione di 2160 × 2800:

```java 
// Carica un file di presentazione.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Ottieni la prima diapositiva dalla presentazione.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Configura le impostazioni dell'immagine TIFF di output.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setImageSize(new Dimension(2160, 2880));             // Imposta le dimensioni dell'immagine.
    tiffOptions.setPixelFormat(ImagePixelFormat.Format1bppIndexed);  // Imposta il formato pixel (bianco e nero).
    tiffOptions.setDpiX(300);                                        // Imposta la risoluzione orizzontale.
    tiffOptions.setDpiY(300);                                        // Imposta la risoluzione verticale.

    // Converti la diapositiva in un'immagine con le opzioni specificate.
    IImage image = slide.getImage(tiffOptions);

    try {
        // Salva l'immagine nel formato TIFF.
        image.save("output.tiff", ImageFormat.Tiff);
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

Aspose.Slides consente di convertire tutte le diapositive di una presentazione in immagini, trasformando l'intera presentazione in una serie di immagini.

Questo esempio di codice dimostra come convertire tutte le diapositive di una presentazione in immagini in Java:

```java 
float scaleX = 2;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Esegui il rendering della presentazione in immagini diapositiva per diapositiva.
    for (int i = 0 ; i < presentation.getSlides().size(); i++)
    {
        // Gestisci le diapositive nascoste (non eseguire il rendering delle diapositive nascoste).
        if (presentation.getSlides().get_Item(i).getHidden())
            continue;

        // Converti la diapositiva in un'immagine.
        IImage image = presentation.getSlides().get_Item(i).getImage(scaleX, scaleY);

        try {
            // Salva l'immagine nel formato JPEG.
            image.save("Slide_" + i + ".jpg", ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
} 
```

## **FAQ**

**Aspose.Slides supporta il rendering delle diapositive con animazioni?**

No, il metodo `getImage` salva solo un'immagine statica della diapositiva, senza animazioni.

**Le diapositive nascoste possono essere esportate come immagini?**

Sì, le diapositive nascoste possono essere elaborate come quelle normali. Basta assicurarsi che siano incluse nel ciclo di elaborazione.

**Le immagini possono essere salvate con ombre ed effetti?**

Sì, Aspose.Slides supporta il rendering di ombre, trasparenza e altri effetti grafici quando si salvano le diapositive come immagini.