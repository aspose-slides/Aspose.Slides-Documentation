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
- diapositiva in EMF
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
description: "Converti le diapositive da presentazioni PPT, PPTX e ODP in PNG, JPEG, GIF, TIFF, EMF e altri formati immagine in JavaScript con Aspose.Slides."
---
## **Introduzione**

Aspose.Slides per Node.js via Java può rendere singole diapositive dalle presentazioni PowerPoint e OpenDocument come PNG, JPEG, GIF, TIFF e altri formati immagine.

Per convertire una diapositiva in un'immagine, segui questi passaggi:

1. Carica la presentazione con la classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
2. Seleziona la diapositiva che desideri rendere.
3. Se necessario, configura il rendering con la classe [RenderingOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/renderingoptions/) o [TiffOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/tiffoptions/).
4. Chiama il metodo [Slide.getImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slide/#getImage). Restituisce un oggetto [IImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/iimage/).
5. Chiama il metodo [IImage.save](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/iimage/#save) e specifica il formato di output con un valore [ImageFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/imageformat/).

## **Converti una diapositiva in immagine PNG**

La conversione più semplice utilizza le impostazioni di rendering predefinite. L'oggetto [IImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/iimage/) risultante può essere elaborato in memoria o salvato su file.

L'esempio JavaScript seguente rende la prima diapositiva e la salva come immagine PNG:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage();
    try {
        image.save("Slide_0.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Converti diapositive in immagini con dimensioni personalizzate**

Usa la sovraccarico del metodo [Slide.getImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slide/#getImage) che accetta un valore `java.awt.Dimension` per rendere una diapositiva con dimensioni pixel esatte.

L'esempio seguente crea un'immagine JPEG 1820 × 1040:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const imageSize = java.newInstanceSync("java.awt.Dimension", 1820, 1040);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage(imageSize);
    try {
        image.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Converti diapositive con note e commenti in immagini**

Per impostazione predefinita, le immagini delle diapositive non includono note o commenti. Passa un oggetto [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/notescommentslayoutingoptions/) al metodo [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) per controllare dove compaiono note e commenti.

L'esempio seguente posiziona le note troncate sotto la diapositiva e i commenti a destra:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const scaleX = 2;
const scaleY = scaleX;

const commentsAreaColor = java.newInstanceSync("java.awt.Color", 250, 235, 215);

const layoutOptions = new aspose.slides.NotesCommentsLayoutingOptions();
layoutOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);
layoutOptions.setCommentsPosition(aspose.slides.CommentsPositions.Right);
layoutOptions.setCommentsAreaWidth(500);
layoutOptions.setCommentsAreaColor(commentsAreaColor);

const renderingOptions = new aspose.slides.RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutOptions);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage(renderingOptions, scaleX, scaleY);
    try {
        image.save("Image_with_notes_and_comments_0.gif", aspose.slides.ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Attenzione" color="warning" %}}
Per la conversione diapositive‑immagine, non passare [BottomFull](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/notespositions/) al metodo [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). Le note possono contenere più testo di quanto la dimensione fissa dell'immagine possa contenere. Usa invece [BottomTruncated](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/notespositions/).
{{% /alert %}}

## **Converti diapositive in immagini usando le opzioni TIFF**

La classe [TiffOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/tiffoptions/) consente di controllare le dimensioni, la risoluzione e altre proprietà dell'immagine TIFF renderizzata.

L'esempio seguente rende la prima diapositiva come immagine TIFF 2160 × 2880 a 300 DPI:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const imageSize = java.newInstanceSync("java.awt.Dimension", 2160, 2880);

const tiffOptions = new aspose.slides.TiffOptions();
tiffOptions.setImageSize(imageSize);
tiffOptions.setDpiX(300);
tiffOptions.setDpiY(300);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage(tiffOptions);
    try {
        image.save("output.tiff", aspose.slides.ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Attenzione" color="warning" %}}
Il supporto TIFF non è garantito nelle versioni di Java precedenti a JDK 9.
{{% /alert %}}

## **Converti tutte le diapositive in immagini**

Itera la collezione di diapositive per convertire l'intera presentazione in una serie di immagini. Le diapositive nascoste sono incluse a meno che non le salti esplicitamente.

L'esempio seguente rende ogni diapositiva come immagine JPEG con fattori di scala orizzontale e verticale pari a 2:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const scaleX = 2;
const scaleY = scaleX;

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        const slide = presentation.getSlides().get_Item(index);
        const image = slide.getImage(scaleX, scaleY);
        try {
            image.save("Slide_" + index + ".jpg", aspose.slides.ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Crea output Metafile potenziato**

Enhanced Metafile (EMF) è utile quando è necessario scambiare grafica vettoriale con Microsoft Office o altre applicazioni Windows che supportano i metafile Windows. A differenza di un'immagine basata su pixel, un EMF può conservare le operazioni di disegno vettoriale che si scalano senza perdita di nitidezza. Tuttavia, EMF è principalmente un formato di compatibilità per applicazioni con supporto a metafile Windows, non un formato di interscambio universale. Inoltre, contenuti di diapositiva complessi, come immagini bitmap e alcuni effetti, possono essere archiviati come elementi rasterizzati all'interno del contenitore vettoriale.

### **Esporta una diapositiva in EMF**

Il metodo [Slide.writeAsEmf](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slide/#writeAsEmf) scrive una diapositiva su uno stream di destinazione in formato EMF. L'esempio seguente carica una presentazione, seleziona la prima diapositiva e la scrive su uno stream di file EMF:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const emfStream = java.newInstanceSync("java.io.FileOutputStream", "Slide_0.emf");
    try {
        slide.writeAsEmf(emfStream);
    } finally {
        emfStream.close();
    }
} finally {
    presentation.dispose();
}
```

Il chiamante possiede lo stream passato a [Slide.writeAsEmf](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slide/#writeAsEmf) ed è responsabile della sua chiusura, come mostrato sopra.

### **Converti un'immagine SVG in EMF e aggiungila a una presentazione**

Usa [SvgImage.writeAsEmf](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/svgimage/#writeAsEmf) per convertire contenuto SVG in EMF. I byte risultanti possono essere aggiunti alla presentazione tramite [ImageCollection.addImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/imagecollection/#addImage) e posizionati su una diapositiva con [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shapecollection/#addPictureFrame).

L'esempio seguente crea un [SvgImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/svgimage/) dal markup SVG, lo converte in un EMF in memoria, inserisce il metafile sulla prima diapositiva e salva la presentazione:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
const svgImage = new aspose.slides.SvgImage(svgContent);

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const emfStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    try {
        svgImage.writeAsEmf(emfStream);

        const emfData = java.newArray("byte", Array.from(emfStream.toByteArray()));
        const image = presentation.getImages().addImage(emfData);
        slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 100, image);
    } finally {
        emfStream.close();
    }

    presentation.save("Presentation_with_emf.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[SvgImage.writeAsEmf](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/svgimage/#writeAsEmf) non prende possesso dello stream di destinazione. Un `java.io.ByteArrayOutputStream` memorizza tutti i dati generati in memoria, quindi non è necessario ripristinare la posizione prima di chiamare `toByteArray`. L'array di byte restituito rimane valido dopo la chiusura dello stream.

La generazione di EMF è disponibile sui sistemi operativi supportati dalla configurazione di Aspose.Slides per Node.js via Java e JDK selezionata, ma il rendering può differire tra piattaforme quando i font o le dipendenze grafiche non sono disponibili. Installa i font usati dal contenuto sorgente o configura sostituzioni adeguate, segui i [requirements di piattaforma](/slides/it/nodejs-java/system-requirements/) per Aspose.Slides per Node.js via Java e valida il risultato nell'applicazione EMF di destinazione. Le applicazioni Linux e macOS spesso hanno supporto limitato o incoerente per la visualizzazione e modifica dei metafile Windows.

## **Rendering emoji a colori**

{{% alert title="Nota" color="info" %}}
Per rendere correttamente gli emoji a colori durante la conversione delle diapositive in immagini, i font emoji usati nella presentazione devono essere installati e disponibili sul sistema che esegue la conversione. Ad esempio, se la presentazione utilizza **Segoe UI Emoji** e questo font manca, gli emoji potrebbero apparire in monocromatico nelle immagini di output.
{{% /alert %}}

## **FAQ**

**Aspose.Slides supporta il rendering di diapositive con animazioni?**

No. Il metodo [Slide.getImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slide/#getImage) renderizza un'immagine statica della diapositiva e non esporta le animazioni.

**Le diapositive nascoste possono essere esportate come immagini?**

Sì. Le diapositive nascoste possono essere renderizzate come le diapositive regolari. Includile nel ciclo di elaborazione, come mostrato nell'esempio sopra.

**Le ombre e altri effetti sono conservati nelle immagini delle diapositive?**

Sì. Aspose.Slides renderizza ombre, trasparenza e altri effetti grafici supportati nelle immagini delle diapositive.