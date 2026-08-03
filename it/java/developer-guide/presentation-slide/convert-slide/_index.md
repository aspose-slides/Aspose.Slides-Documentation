---
title: Converti le diapositive della presentazione in immagini in Java
linktitle: Diapositiva in immagine
type: docs
weight: 35
url: /it/java/convert-slide/
keywords:
- convertire diapositiva
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
- Java
- Aspose.Slides
description: "Converti le diapositive da PPT, PPTX e ODP in immagini in Java usando Aspose.Slides—rendering veloce e di alta qualità con esempi di codice chiari."
---
## **Introduzione**

Aspose.Slides for Java consente di convertire facilmente le diapositive di presentazioni PowerPoint e OpenDocument in vari formati immagine, tra cui BMP, PNG, JPG (JPEG), GIF e altri.

Per convertire una diapositiva in un’immagine, segui questi passaggi:

1. Definisci le impostazioni di conversione desiderate e seleziona le diapositive da esportare utilizzando:
    - L’interfaccia [ITiffOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/itiffoptions/), oppure
    - L’interfaccia [IRenderingOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/irenderingoptions/).
2. Genera l’immagine della diapositiva chiamando il metodo [getImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-).

In Aspose.Slides for Java, un [IImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/iimage/) è un’interfaccia che permette di lavorare con immagini definite da dati pixel. Puoi usare questa interfaccia per salvare le immagini in un’ampia gamma di formati (BMP, JPG, PNG, ecc.).

## **Convertire diapositive in bitmap e salvare le immagini in PNG**

Puoi convertire una diapositiva in un oggetto bitmap e usarlo direttamente nella tua applicazione. In alternativa, puoi convertire una diapositiva in un bitmap e poi salvare l’immagine in JPEG o in qualsiasi altro formato preferito.

Questo codice dimostra come convertire la prima diapositiva di una presentazione in un oggetto bitmap e poi salvare l’immagine in formato PNG:

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

## **Convertire diapositive in immagini con dimensioni personalizzate**

Potresti aver bisogno di ottenere un’immagine di una certa dimensione. Utilizzando una sovraccarico del metodo [getImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-), puoi convertire una diapositiva in un’immagine con larghezza e altezza specificate.

Questo esempio di codice mostra come farlo:

```java 
Dimension imageSize = new Dimension(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Converti la prima diapositiva della presentazione in una bitmap con la dimensione specificata.
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

## **Convertire diapositive con note e commenti in immagini**

Alcune diapositive possono contenere note e commenti.

Aspose.Slides fornisce due interfacce—[ITiffOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/itiffoptions/) e [IRenderingOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/irenderingoptions/)—che consentono di controllare il rendering delle diapositive di presentazione in immagini. Entrambe le interfacce includono il metodo `setSlidesLayoutOptions`, che permette di configurare il rendering di note e commenti su una diapositiva durante la conversione in immagine.

Con la classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/notescommentslayoutingoptions/) è possibile specificare la posizione preferita per note e commenti nell’immagine risultante.

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
    notesCommentsOptions.setCommentsAreaWidth(500);                         // Imposta la larghezza dell'area commenti.
    notesCommentsOptions.setCommentsAreaColor(Color.LIGHT_GRAY);            // Imposta il colore dell'area commenti.

    // Crea le opzioni di rendering.
    RenderingOptions options = new RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);

    // Converte la prima diapositiva della presentazione in un'immagine.
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

{{% alert title="Nota" color="warning" %}} 

In qualsiasi processo di conversione da diapositiva a immagine, il metodo [setNotesPosition](https://reference.aspose.com/slides/it/java/com.aspose.slides/inotescommentslayoutingoptions/#setNotesPosition-int-) non può applicare `BottomFull` (per specificare la posizione delle note) perché il testo di una nota potrebbe essere troppo grande e non riuscire a stare all’interno delle dimensioni dell’immagine specificate.

{{% /alert %}} 

## **Convertire diapositive in immagini usando le opzioni TIFF**

L’interfaccia [ITiffOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/itiffoptions/) offre un controllo maggiore sull’immagine TIFF risultante, consentendo di specificare parametri come dimensione, risoluzione, palette di colori e altro.

Questo codice dimostra un processo di conversione in cui le opzioni TIFF vengono utilizzate per generare un’immagine in bianco‑nero con risoluzione di 300 DPI e dimensione di 2160 × 2800:

```java 
// Carica un file di presentazione.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Ottieni la prima diapositiva della presentazione.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Configura le impostazioni dell'immagine TIFF di output.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setImageSize(new Dimension(2160, 2880));             // Imposta la dimensione dell'immagine.
    tiffOptions.setPixelFormat(ImagePixelFormat.Format1bppIndexed);  // Imposta il formato pixel (bianco e nero).
    tiffOptions.setDpiX(300);                                        // Imposta la risoluzione orizzontale.
    tiffOptions.setDpiY(300);                                        // Imposta la risoluzione verticale.

    // Converte la diapositiva in un'immagine con le opzioni specificate.
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

{{% alert title="Nota" color="warning" %}} 

Il supporto TIFF non è garantito nelle versioni precedenti a JDK 9.

{{% /alert %}} 

## **Convertire tutte le diapositive in immagini**

Aspose.Slides consente di convertire tutte le diapositive di una presentazione in immagini, trasformando l’intera presentazione in una serie di immagini.

Questo esempio di codice mostra come convertire tutte le diapositive di una presentazione in immagini in Java:

```java 
float scaleX = 2;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Renderizza la presentazione in immagini diapositiva per diapositiva.
    for (int i = 0 ; i < presentation.getSlides().size(); i++)
    {
        // Controlla le diapositive nascoste (non renderizzare le diapositive nascoste).
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

## **Rendering di emoji a colori**

{{% alert title="Nota" color="warning" %}} 
Per rendere correttamente le emoji a colori quando si convertono le diapositive di una presentazione in immagini, i caratteri emoji usati nella presentazione devono essere installati e disponibili sul sistema che esegue la conversione. Ad esempio, se la presentazione utilizza **Segoe UI Emoji** e questo carattere manca, le emoji potrebbero apparire in bianco‑nero nelle immagini di output.
{{% /alert %}}

## **FAQ**

**Aspose.Slides supporta il rendering di diapositive con animazioni?**

No, il metodo `getImage` salva solo un’immagine statica della diapositiva, senza animazioni.

**Le diapositive nascoste possono essere esportate come immagini?**

Sì, le diapositive nascoste possono essere elaborate come quelle normali. Basta assicurarsi che siano incluse nel ciclo di elaborazione.

**È possibile salvare le immagini con ombre e effetti?**

Sì, Aspose.Slides supporta il rendering di ombre, trasparenze e altri effetti grafici quando si salvano le diapositive come immagini.