---
title: Cambia le dimensioni e l'orientamento della pagina delle note in Java
linktitle: Dimensioni pagina note
type: docs
weight: 10
url: /it/java/notes-size/
keywords:
- dimensioni pagina note
- orientamento note
- note in orizzontale
- note in verticale
- dimensioni scheda
- PowerPoint
- presentazione
- PPT
- PPTX
- Java
- Aspose.Slides
description: "Leggi e modifica le dimensioni della pagina delle note in Aspose.Slides per Java, cambia orientamento, verifica le dimensioni salvate ed esporta note o schede in PDF e immagini."
---
## **Panoramica**

Usa [Presentation.getNotesSize](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#getNotesSize--) per accedere alle impostazioni della pagina delle note della presentazione. Restituisce un oggetto [INotesSize](https://reference.aspose.com/slides/it/java/com.aspose.slides/inotessize/) il cui metodo [setSize](https://reference.aspose.com/slides/it/java/com.aspose.slides/inotessize/#setSize-java.awt.geom.Dimension2D-) imposta le dimensioni della pagina. Sebbene l'oggetto delle impostazioni non possa essere sostituito, è possibile assegnare nuove dimensioni attraverso questo metodo.

Larghezza e altezza sono specificate in **punti**, con 72 punti per pollice. Ad esempio, 900 × 600 punti corrispondono a 12,5 × 8⅓ pollici. queste impostazioni si applicano all'intera presentazione, piuttosto che alle note di una singola diapositiva.

| Impostazione | Scopo |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#getNotesSize--) | Controlla le dimensioni della pagina delle note e le dimensioni della pagina usate per l'esportazione delle schede. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#getSlideSize--) | Controlla le dimensioni regolari delle diapositive della presentazione tramite [ISlideSize](https://reference.aspose.com/slides/it/java/com.aspose.slides/islidesize/). |

Modificare una delle impostazioni non cambia automaticamente l'altra. Cambiare l'orientamento della pagina delle note non ruota nemmeno le diapositive regolari. Vedi [Slide Size](/slides/it/java/slide-size/) per ridimensionare le diapositive regolari.

Gli esempi seguenti utilizzano un file `sample.pptx` esistente. Per gli esempi di esportazione, usa una presentazione con almeno una diapositiva contenente note del relatore. Ogni esempio può essere eseguito in modo indipendente.

## **Leggere le dimensioni e l'orientamento della pagina delle note**

Leggi larghezza e altezza e confrontale per determinare l'orientamento: una pagina più larga è orizzontale, una più alta è verticale, e dimensioni uguali descrivono una pagina quadrata. Questo esempio stampa le dimensioni effettive in punti, senza assumere una dimensione di carta standard.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D size = presentation.getNotesSize().getSize();
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

## **Passare a orizzontale senza modificare le dimensioni della carta**

Per cambiare solo l'orientamento, scambia larghezza e altezza esistenti. Ciò preserva le lunghezze di entrambi i lati, comprese quelle di una dimensione di carta personalizzata. La condizione qui sotto impedisce che una pagina già in orizzontale venga riportata in verticale e lascia invariata una pagina quadrata.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        double width = size.getWidth();
        size.setSize(size.getHeight(), width);
        presentation.getNotesSize().setSize(size);
    }

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Per l'orientamento verticale, usa la stessa assegnazione quando `size.getWidth() > size.getHeight()`. Non sostituire le dimensioni A4 o Letter a meno che tu non voglia anche modificare la dimensione della carta.

## **Impostare e verificare una dimensione personalizzata della pagina delle note**

Assegna entrambe le dimensioni insieme, quindi utilizza [Presentation.save](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#save-java.lang.String-int-) per scrivere la presentazione. Questo esempio imposta una pagina orizzontale di 900 × 600 punti, la salva come PPTX e riapre il file salvato per verificare i valori persistiti. Il confronto consente una tolleranza di 0,01 punti per i valori in virgola mobile; non è una garanzia di precisione per ogni formato di file.

```java
import com.aspose.slides.*;
import java.awt.Dimension;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D expectedSize = new Dimension(900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom-notes.pptx");
    try {
        Dimension2D actualSize = reopened.getNotesSize().getSize();
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

Il risultato previsto è `900.0 x 600.0 points` e `Size preserved: true`. Verificare una presentazione appena aperta conferma il file salvato, piuttosto che solo le impostazioni in memoria.

## **Esportare Note e Schede**

Le dimensioni della pagina definiscono l'area disponibile per le note o i layout delle schede. Non abilitano tali layout da sole: è necessario configurare anche le opzioni di esportazione. L'esportazione delle diapositive regolari continua a usare le dimensioni della diapositiva.

### **Esportare Note in PDF e PNG**

Assegna [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/notescommentslayoutingoptions/) a [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/pdfoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) per includere le note nel PDF. Questo esempio rende anche la prima diapositiva con note in PNG usando [Slide.getImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) e [RenderingOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/renderingoptions/).

La modalità [BottomTruncated](https://reference.aspose.com/slides/it/java/com.aspose.slides/notespositions/) mantiene le note su una singola pagina; le note che non entrano possono essere troncate. Il PDF utilizza pagine di 900 × 600 punti. Alla scala immagine di 1 × 1 usata di seguito, il PNG è di 900 × 600 pixel. I punti descrivono la geometria della pagina; i pixel descrivono l'output raster, le cui dimensioni dipendono anche dalla scala di rendering.

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension size = new Dimension(900, 600);
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

Per l'esportazione PDF con note lunghe, [BottomFull](https://reference.aspose.com/slides/it/java/com.aspose.slides/notespositions/) consente pagine aggiuntive secondo necessità. Non usare quella modalità con la chiamata immagine a diapositiva singola sopra, che non la supporta. Dopo il ridimensionamento, ispeziona l'output per note troncate e il posizionamento degli oggetti master delle note esistenti; modificare solo le dimensioni della pagina non garantisce che tutto il contenuto si adatti. Vedi [Convert PowerPoint to PDF with Notes](/slides/it/java/convert-powerpoint-to-pdf-with-notes/) per ulteriori informazioni sull'esportazione delle note.

### **Esportare Schede in PDF**

Usa [HandoutLayoutingOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/handoutlayoutingoptions/) per più miniature di diapositive su una pagina. L'esempio seguente imposta una pagina di 900 × 600 punti e utilizza [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/it/java/com.aspose.slides/handouttype/) per disporre fino a quattro diapositive per pagina. Il preset orizzontale controlla l'ordinamento delle diapositive; l'orientamento della pagina deriva dalla sua larghezza e altezza.

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension size = new Dimension(900, 600);
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

Cambiare la dimensione della pagina varia l'area disponibile per la griglia delle schede senza modificare le dimensioni delle diapositive di origine. Per le immagini delle schede, usa [Presentation.getImages](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-) con il layout delle schede, anziché il metodo immagine di una singola diapositiva. In Aspose.Slides, il rendering delle schede a livello di presentazione utilizza le dimensioni della pagina delle note, mentre la chiamata immagine di una singola diapositiva non produce la pagina della scheda. Vedi [Handout Mode](/slides/it/java/convert-powerpoint-in-handout-mode/) per le opzioni di layout.

## **Dimensioni della pagina in visualizzatori, esportazione e stampa**

Mantieni distinte le dimensioni della presentazione memorizzata, le dimensioni della pagina esportata e le dimensioni della carta stampata:

- **Visualizzatori di presentazioni:** un visualizzatore può visualizzare o stampare le note usando le proprie regole di layout. Se un'altra applicazione salva il file, riaprilo e verifica nuovamente le dimensioni; la conversione di formato di quell'applicazione potrebbe normalizzarle.
- **Formati di esportazione:** gli esempi PDF di note e schede sopra usano le dimensioni della pagina configurate. Le immagini raster usano dimensioni intere di pixel e una scala di rendering, quindi i valori frazionari dei punti possono essere arrotondati nell'output immagine. L'esportazione delle diapositive regolari non applica le dimensioni della pagina delle note.
- **Driver di stampa:** la selezione della carta, la rotazione automatica e le impostazioni di adattamento alla pagina possono modificare l'output fisico senza cambiare le dimensioni memorizzate nella presentazione o nel PDF. Per una dimensione di carta specifica, abbina le impostazioni della stampante e controlla l'anteprima di stampa.

## **FAQ**

**Posso impostare la dimensione delle note per una sola diapositiva?**

La dimensione della pagina delle note è un'impostazione a livello di presentazione. Le singole diapositive possono contenere contenuti di note diversi, ma questa proprietà non fornisce una dimensione di pagina separata per ciascuna diapositiva.

**Perché il cambiamento dell'orientamento delle note non ha modificato le mie diapositive?**

Le pagine delle note e le diapositive regolari hanno dimensioni indipendenti. Usa le impostazioni di dimensione delle diapositive regolari quando vuoi ridimensionare le diapositive stesse.

**Perché il risultato salvato o stampato ha una dimensione diversa?**

Riapri prima la presentazione salvata e confronta le sue dimensioni delle note. Se queste sono cambiate, verifica se il salvataggio o la conversione del file in un'altra applicazione ha modificato le impostazioni della pagina. Se non è così, controlla il layout di esportazione, la scala dell'immagine, le impostazioni del visualizzatore e la selezione della carta nella stampante.