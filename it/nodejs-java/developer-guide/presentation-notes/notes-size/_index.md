---
title: Modifica dimensione e orientamento della pagina delle note in JavaScript
linktitle: Dimensione pagina delle note
type: docs
weight: 10
url: /it/nodejs-java/notes-size/
keywords:
- dimensione pagina delle note
- orientamento note
- note orizzontali
- note verticali
- dimensione documento di sintesi
- PowerPoint
- presentazione
- PPT
- PPTX
- Node.js
- JavaScript
- Aspose.Slides
description: "Leggi e modifica le dimensioni della pagina delle note in Aspose.Slides per Node.js tramite Java, cambia orientamento, verifica le dimensioni salvate ed esporta note o documenti di sintesi in PDF e immagini."
---
## **Panoramica**

Utilizzare [Presentation.getNotesSize](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/getnotessize/) per accedere alle impostazioni della pagina delle note della presentazione. Restituisce un oggetto [NotesSize](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/notessize/) il cui metodo [setSize](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/notessize/setsize/) imposta le dimensioni della pagina. Sebbene l'oggetto delle impostazioni non possa essere sostituito, è possibile assegnare nuove dimensioni tramite questo metodo.

Larghezza e altezza sono specificate in **punti**, con 72 punti per pollice. Ad esempio, 900 × 600 punti corrispondono a 12,5 × 8⅓ pollici. Queste impostazioni si applicano alla presentazione, non alle note di una singola diapositiva.

| Impostazione | Scopo |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/getnotessize/) | Controlla le dimensioni della pagina delle note e le dimensioni della pagina utilizzate per l'esportazione del documento di sintesi. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/getslidesize/) | Controlla le dimensioni delle diapositive della presentazione normale tramite [SlideSize](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slidesize/). |

Modificare una delle impostazioni non cambia automaticamente l'altra. Cambiare l'orientamento della pagina delle note non ruota neanche le diapositive regolari. Vedere [Slide Size](/slides/it/nodejs-java/slide-size/) per ridimensionare le diapositive regolari.

Gli esempi seguenti utilizzano un file `sample.pptx` esistente. Per gli esempi di esportazione, usare una presentazione con almeno una diapositiva contenente note del relatore. Ogni esempio può essere eseguito in modo indipendente.

## **Leggere le dimensioni e l'orientamento della pagina delle note**

Leggere la larghezza e l'altezza e confrontarle per determinare l'orientamento: una pagina più larga è orizzontale, una più alta è verticale, e dimensioni uguali descrivono una pagina quadrata. Questo esempio stampa le dimensioni effettive in punti, senza supposizioni su una dimensione di carta standard.

```javascript
const slides = require("aspose.slides.via.java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = presentation.getNotesSize().getSize();
    let orientation = "Square";

    if (size.getWidth() > size.getHeight()) {
        orientation = "Landscape";
    } else if (size.getWidth() < size.getHeight()) {
        orientation = "Portrait";
    }

    console.log("Notes page: " + size.getWidth() + " x " + size.getHeight() + " points");
    console.log("Orientation: " + orientation);
} finally {
    presentation.dispose();
}
```

## **Passare a orizzontale senza modificare le dimensioni della carta**

Per modificare solo l'orientamento, scambiare la larghezza e l'altezza esistenti. Ciò preserva le lunghezze di entrambi i lati, comprese quelle di una dimensione di carta personalizzata. La condizione seguente impedisce a una pagina già orizzontale di tornare verticale e mantiene invariata una pagina quadrata.

```javascript
const slides = require("aspose.slides.via.java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        let width = size.getWidth();
        size.setSize(size.getHeight(), width);
        presentation.getNotesSize().setSize(size);
    }

    presentation.save("landscape-notes.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Per l'orientamento verticale, utilizzare la stessa assegnazione quando `size.getWidth() > size.getHeight()`. Non sostituire le dimensioni A4 o Letter a meno che non si desideri anche modificare la dimensione della carta.

## **Impostare e verificare una dimensione personalizzata della pagina delle note**

Assegnare entrambe le dimensioni insieme, quindi utilizzare [Presentation.save](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/save/) per scrivere la presentazione. Questo esempio imposta una pagina orizzontale di 900 × 600 punti, la salva come PPTX e riapre il file salvato per verificare i valori persistiti. Il confronto consente una tolleranza di 0,01 punti per i valori in virgola mobile; non è una garanzia di precisione per ogni formato di file.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let expectedSize = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", slides.SaveFormat.Pptx);

    let reopened = new slides.Presentation("custom-notes.pptx");
    try {
        let actualSize = reopened.getNotesSize().getSize();
        let widthMatches = Math.abs(actualSize.getWidth() - expectedSize.getWidth()) < 0.01;
        let heightMatches = Math.abs(actualSize.getHeight() - expectedSize.getHeight()) < 0.01;
        let preserved = widthMatches && heightMatches;

        console.log("Stored notes page: " + actualSize.getWidth() + " x " + actualSize.getHeight() + " points");
        console.log("Size preserved: " + preserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Il risultato previsto è `900 x 600 points` e `Size preserved: true`. Verificare una presentazione appena aperta consente di confermare il file salvato, anziché solo le impostazioni in memoria.

## **Esportare note e documenti di sintesi**

Le dimensioni della pagina definiscono l'area disponibile per i layout di note o di documenti di sintesi. Esse non abilitano tali layout da sole: è necessario configurare anche le opzioni di esportazione. L'esportazione delle diapositive regolari continua a utilizzare le dimensioni della diapositiva.

### **Esportare note in PDF e PNG**

Assegnare [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/notescommentslayoutingoptions/) a [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) per includere le note nel PDF. Questo esempio rende anche la prima diapositiva con note in PNG utilizzando [Slide.getImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slide/#getImage) e [RenderingOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/renderingoptions/).

La modalità [BottomTruncated](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/notespositions/) mantiene le note su una sola pagina; le note che non entrano possono essere troncate. Il PDF utilizza pagine di 900 × 600 punti. Alla scala dell'immagine di 1 × 1 usata di seguito, il PNG è di 900 × 600 pixel. I punti descrivono la geometria della pagina; i pixel descrivono l'output raster, le cui dimensioni dipendono anche dalla scala di rendering.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(size);

    let layout = new slides.NotesCommentsLayoutingOptions();
    layout.setNotesPosition(slides.NotesPositions.BottomTruncated);

    let pdfOptions = new slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("notes.pdf", slides.SaveFormat.Pdf, pdfOptions);

    let renderingOptions = new slides.RenderingOptions();
    renderingOptions.setSlidesLayoutOptions(layout);

    let image = presentation.getSlides().get_Item(0).getImage(renderingOptions, 1, 1);
    try {
        image.save("first-slide-notes.png", slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

Per l'esportazione PDF con note lunghe, [BottomFull](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/notespositions/) consente pagine aggiuntive secondo necessità. Non utilizzare tale modalità con la chiamata immagine a diapositiva singola sopra, che non la supporta. Dopo il ridimensionamento, ispezionare l'output per note troncate e la posizione degli oggetti note-master esistenti; modificare solo le dimensioni della pagina non garantisce che tutti i contenuti si adattino. Vedere [Convert PowerPoint to PDF with Notes](/slides/it/nodejs-java/convert-powerpoint-to-pdf-with-notes/) per ulteriori informazioni sull'esportazione delle note.

### **Esportare documenti di sintesi in PDF**

Utilizzare [HandoutLayoutingOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/handoutlayoutingoptions/) per più miniature di diapositive su una pagina. L'esempio seguente imposta una pagina di 900 × 600 punti e utilizza [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/handouttype/) per disporre fino a quattro diapositive per pagina. Il preset orizzontale controlla l'ordine delle diapositive; l'orientamento della pagina deriva dalla sua larghezza e altezza.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(size);

    let layout = new slides.HandoutLayoutingOptions();
    layout.setHandout(slides.HandoutType.Handouts4Horizontal);

    let pdfOptions = new slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("handouts.pdf", slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Modificare le dimensioni della pagina cambia l'area disponibile per la griglia del documento di sintesi senza alterare le dimensioni delle diapositive di origine. Per le immagini del documento di sintesi, utilizzare [Presentation.getImages](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/getimages/) con il layout del documento di sintesi, anziché il metodo immagine di una singola diapositiva. In Aspose.Slides, il rendering del documento di sintesi a livello di presentazione utilizza le dimensioni della pagina delle note, mentre la chiamata immagine di una singola diapositiva non produce la pagina del documento di sintesi. Vedere [Handout Mode](/slides/it/nodejs-java/convert-powerpoint-in-handout-mode/) per le opzioni di layout.

## **Dimensioni della pagina in visualizzatori, esportazione e stampa**

Mantenere distinte la dimensione della presentazione memorizzata, la dimensione della pagina esportata e la dimensione della carta stampata:

- **Visualizzatori di presentazioni:** Un visualizzatore può visualizzare o stampare le note usando le proprie regole di layout. Se un'altra applicazione salva il file, riaprilo e controlla nuovamente le dimensioni; la conversione di formato di quell'applicazione può normalizzarle.
- **Formati di esportazione:** Gli esempi PDF di note e documenti di sintesi sopra usano le dimensioni della pagina configurate. Le immagini raster usano dimensioni in pixel interi e una scala di rendering, quindi i valori frazionari in punti possono essere arrotondati nell'output dell'immagine. L'esportazione delle diapositive regolari non applica la dimensione della pagina delle note.
- **Driver della stampante:** La selezione della carta, la rotazione automatica e le impostazioni di adattamento alla pagina possono modificare l'output fisico senza cambiare le dimensioni memorizzate nella presentazione o nel PDF. Per una dimensione di carta specifica, corrispondi alle impostazioni della stampante e controlla l'anteprima di stampa.

## **FAQ**

**Posso impostare la dimensione delle note per una sola diapositiva?**

La dimensione della pagina delle note è un'impostazione a livello di presentazione. Le singole diapositive possono avere contenuti delle note diversi, ma questa proprietà non fornisce una dimensione di pagina separata per ciascuna diapositiva.

**Perché la modifica dell'orientamento delle note non ha cambiato le mie diapositive?**

Le pagine delle note e le diapositive regolari hanno dimensioni indipendenti. Utilizzare le impostazioni delle dimensioni delle diapositive regolari quando si desidera ridimensionare le diapositive stesse.

**Perché il mio risultato salvato o stampato ha una dimensione diversa?**

Innanzitutto riapri la presentazione salvata e confronta le sue dimensioni delle note. Se queste sono cambiate, verifica se il salvataggio o la conversione del file in un'altra applicazione ha modificato le impostazioni della pagina. Se non lo hanno fatto, controlla il layout di esportazione, la scala dell'immagine, le impostazioni del visualizzatore e la selezione della carta della stampante.