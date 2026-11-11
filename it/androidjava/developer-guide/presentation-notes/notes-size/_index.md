---
title: Modifica dimensione e orientamento della pagina delle note su Android
linktitle: Dimensione pagina delle note
type: docs
weight: 10
url: /it/androidjava/notes-size/
keywords:
- dimensione pagina note
- orientamento note
- note in orizzontale
- note in verticale
- dimensione handout
- PowerPoint
- presentazione
- PPT
- PPTX
- Android
- Java
- Aspose.Slides
description: "Leggi e modifica le dimensioni della pagina delle note in Aspose.Slides per Android via Java, cambia l'orientamento, verifica le dimensioni salvate e esporta note o handout in PDF e immagini."
---
## **Panoramica**

Utilizza [Presentation.getNotesSize](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#getNotesSize--) per accedere alle impostazioni della pagina delle note della presentazione. Restituisce un oggetto [INotesSize](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/inotessize/) il cui metodo [setSize](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/inotessize/#setSize-com.aspose.slides.android.SizeF-) imposta le dimensioni della pagina. Sebbene l'oggetto delle impostazioni non possa essere sostituito, è possibile assegnare nuove dimensioni tramite questo metodo.

Larghezza e altezza sono specificate in **punti**, con 72 punti per pollice. Per esempio, 900 × 600 punti corrispondono a 12,5 × 8⅓ pollici. queste impostazioni si applicano all'intera presentazione, non a una singola diapositiva delle note.

| Impostazione | Scopo |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#getNotesSize--) | Controlla le dimensioni della pagina delle note e le dimensioni della pagina usate per l'esportazione di handout. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#getSlideSize--) | Controlla le dimensioni delle diapositive regolari tramite [ISlideSize](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islidesize/). |

Modificare una delle due impostazioni non cambia automaticamente l'altra. Cambiare l'orientamento della pagina delle note non ruota nemmeno le diapositive regolari. Consulta [Slide Size](/slides/it/androidjava/slide-size/) per ridimensionare le diapositive regolari.

Gli esempi seguenti utilizzano un file `sample.pptx` esistente. Per gli esempi di esportazione, utilizza una presentazione con almeno una diapositiva contenente note del relatore. Ogni esempio può essere eseguito in modo indipendente.

## **Leggi le dimensioni e l'orientamento della pagina delle note**

Leggi larghezza e altezza e confrontale per determinare l'orientamento: una pagina più larga è orizzontale, una più alta è verticale, e dimensioni uguali descrivono una pagina quadrata. Questo esempio stampa le dimensioni effettive in punti, senza assumere una dimensione di carta standard.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = presentation.getNotesSize().getSize();
    String orientation = "Square";

    if (size.getWidth() > size.getHeight()) {
        orientation = "Landscape";
    } else if (size.getWidth() < size.getHeight()) {
        orientation = "Portrait";
    }

    System.out.println("Notes page: " + size.getWidth() + " x " + size.getHeight() + " points");
    System.out.println("Orientation: " + orientation);
} finally {
    presentation.dispose();
}
```

## **Passa a orizzontale senza cambiare la dimensione della carta**

Per cambiare solo l'orientamento, scambia larghezza e altezza esistenti. Questo preserva le lunghezze di entrambi i lati, inclusi quelli di una dimensione di carta personalizzata. La condizione sotto impedisce che una pagina già orizzontale venga nuovamente trasformata in verticale e lascia invariata una pagina quadrata.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        SizeF landscapeSize = new SizeF(size.getHeight(), size.getWidth());
        presentation.getNotesSize().setSize(landscapeSize);
    }

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Per l'orientamento verticale, utilizza la stessa assegnazione quando `size.getWidth() > size.getHeight()`. Non sostituire le dimensioni A4 o Letter a meno che tu non voglia anche cambiare la dimensione della carta.

## **Imposta e verifica una dimensione personalizzata della pagina delle note**

Assegna entrambe le dimensioni insieme, quindi usa [Presentation.save](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) per scrivere la presentazione. Questo esempio imposta una pagina orizzontale di 900 × 600 punti, la salva come PPTX e riapre il file salvato per controllare i valori persistiti. Il confronto consente una tolleranza di 0,01 punti per i valori a virgola mobile; non è una garanzia di precisione per ogni formato di file.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF expectedSize = new SizeF(900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom-notes.pptx");
    try {
        SizeF actualSize = reopened.getNotesSize().getSize();
        boolean widthMatches = Math.abs(actualSize.getWidth() - expectedSize.getWidth()) < 0.01;
        boolean heightMatches = Math.abs(actualSize.getHeight() - expectedSize.getHeight()) < 0.01;
        boolean preserved = widthMatches && heightMatches;

        System.out.println("Stored notes page: " + actualSize.getWidth() + " x " + actualSize.getHeight() + " points");
        System.out.println("Size preserved: " + preserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Il risultato atteso è `900.0 x 600.0 points` e `Size preserved: true`. Verificare una presentazione appena aperta conferma il file salvato, anziché solo le impostazioni in memoria.

## **Esporta note e handout**

Le dimensioni della pagina definiscono l'area disponibile per layout di note o handout. Non abilitano tali layout da sole: è necessario configurare anche le opzioni di esportazione. L'esportazione delle diapositive regolari continua a usare le dimensioni delle diapositive.

### **Esporta note in PDF e PNG**

Assegna [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/notescommentslayoutingoptions/) a [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/pdfoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) per includere le note nel PDF. Questo esempio rende anche la prima diapositiva con note in PNG usando [Slide.getImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) e [RenderingOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/renderingoptions/).

La modalità [BottomTruncated](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/notespositions/) mantiene le note su una sola pagina; le note che non entrano possono essere troncate. Il PDF utilizza pagine di 900 × 600 punti. Alla scala immagine di 1 × 1 usata di seguito, il PNG è di 900 × 600 pixel. I punti descrivono la geometria della pagina; i pixel descrivono l'output raster, le cui dimensioni dipendono anche dalla scala di rendering.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = new SizeF(900, 600);
    presentation.getNotesSize().setSize(size);

    NotesCommentsLayoutingOptions layout = new NotesCommentsLayoutingOptions();
    layout.setNotesPosition(NotesPositions.BottomTruncated);

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("notes.pdf", SaveFormat.Pdf, pdfOptions);

    RenderingOptions renderingOptions = new RenderingOptions();
    renderingOptions.setSlidesLayoutOptions(layout);

    IImage image = presentation.getSlides().get_Item(0).getImage(renderingOptions, 1, 1);
    try {
        image.save("first-slide-notes.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

Per l'esportazione in PDF con note lunghe, [BottomFull](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/notespositions/) consente pagine aggiuntive se necessario. Non usare quella modalità con la chiamata immagine a diapositiva singola sopra, che non la supporta. Dopo il ridimensionamento, ispeziona l'output per note ritagliate e la posizione degli oggetti note-master esistenti; modificare solo le dimensioni della pagina non garantisce che tutto il contenuto si adatti. Vedi [Convert PowerPoint to PDF with Notes](/slides/it/androidjava/convert-powerpoint-to-pdf-with-notes/) per ulteriori informazioni sull'esportazione delle note.

### **Esporta handout in PDF**

Usa [HandoutLayoutingOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/handoutlayoutingoptions/) per più miniature di diapositive su una pagina. L'esempio seguente imposta una pagina di 900 × 600 punti e utilizza [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/handouttype/) per disporre fino a quattro diapositive per pagina. Il preset orizzontale controlla l'ordine delle diapositive; l'orientamento della pagina deriva dalla sua larghezza e altezza.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = new SizeF(900, 600);
    presentation.getNotesSize().setSize(size);

    HandoutLayoutingOptions layout = new HandoutLayoutingOptions();
    layout.setHandout(HandoutType.Handouts4Horizontal);

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("handouts.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Cambiare le dimensioni della pagina modifica l'area disponibile per la griglia dell'handout senza alterare le dimensioni delle diapositive di origine. Per le immagini dell'handout, usa [Presentation.getImages](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-) con il layout handout, anziché il metodo immagine di una singola diapositiva. In Aspose.Slides, il rendering dell'handout a livello di presentazione utilizza le dimensioni della pagina delle note, mentre la chiamata immagine di una singola diapositiva non produce la pagina handout. Vedi [Handout Mode](/slides/it/androidjava/convert-powerpoint-in-handout-mode/) per le opzioni di layout.

## **Dimensione della pagina in visualizzatori, esportazione e stampa**

Mantieni distinte la dimensione della presentazione memorizzata, la dimensione della pagina esportata e la dimensione della carta stampata:

- **Visualizzatori di presentazioni:** Un visualizzatore può visualizzare o stampare le note usando le proprie regole di layout. Se un'altra applicazione salva il file, riaprilo e controlla nuovamente le dimensioni; la conversione del formato di quell'applicazione potrebbe normalizzarle.
- **Formati di esportazione:** Gli esempi di PDF per note e handout sopra usano le dimensioni della pagina configurate. Le immagini raster usano dimensioni di pixel interi e una scala di rendering, quindi i valori frazionari dei punti possono essere arrotondati nell'output immagine. L'esportazione delle diapositive regolari non applica le dimensioni della pagina delle note.
- **Driver di stampa:** La selezione della carta, la rotazione automatica e le impostazioni di adatta alla pagina possono modificare l'output fisico senza cambiare le dimensioni memorizzate nella presentazione o nel PDF. Per una dimensione di carta specifica, abbina le impostazioni della stampante e ispeziona l'anteprima di stampa.

## **FAQ**

**Posso impostare le dimensioni delle note per una sola diapositiva?**

Le dimensioni della pagina delle note sono un'impostazione a livello di presentazione. Le singole diapositive possono contenere contenuti di note diversi, ma questa proprietà non fornisce una dimensione della pagina separata per ogni diapositiva.

**Perché la modifica dell'orientamento delle note non ha cambiato le mie diapositive?**

Le pagine delle note e le diapositive regolari hanno dimensioni indipendenti. Usa le impostazioni della dimensione delle diapositive regolari quando vuoi ridimensionare le diapositive stesse.

**Perché il risultato salvato o stampato ha una dimensione diversa?**

Riapri prima la presentazione salvata e confronta le sue dimensioni delle note. Se sono cambiate, verifica se il salvataggio o la conversione del file in un'altra applicazione ha modificato le impostazioni della pagina. Se non è così, controlla il layout di esportazione, la scala dell'immagine, le impostazioni del visualizzatore e la selezione della carta della stampante.