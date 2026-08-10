---
title: Gestire gli oggetti di inchiostro della presentazione in JavaScript
linktitle: Gestire Inchiostro
type: docs
weight: 95
url: /it/nodejs-java/manage-ink/
keywords:
- inchiostro
- oggetto di inchiostro
- traccia di inchiostro
- gestire inchiostro
- disegnare inchiostro
- disegno
- esportazione inchiostro
- rendering inchiostro
- nascondere inchiostro
- InkOptions
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Gestisci gli oggetti di inchiostro di PowerPoint, modifica le tracce e le proprietà dei pennelli, e controlla l'aspetto dell'inchiostro durante l'esportazione in PDF, HTML, SVG, TIFF e immagine con Aspose.Slides per Node.js via Java."
---
## **Introduzione**

PowerPoint fornisce una funzione di inchiostro che consente di disegnare tratti liberi. L'inchiostro può essere usato per evidenziare altri oggetti, mostrare connessioni e processi e attirare l'attenzione su elementi specifici in una diapositiva.

Aspose.Slides fornisce i tipi necessari per lavorare con gli oggetti di inchiostro. Ad esempio, la classe [Ink](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ink/) rappresenta un oggetto di inchiostro su una diapositiva.

## **Differenze tra oggetti normali e oggetti di inchiostro**

Gli oggetti su una diapositiva PowerPoint sono tipicamente rappresentati da oggetti shape. Nella sua forma più semplice, una shape è un contenitore che definisce l'area dell'oggetto stesso (il suo frame) insieme a proprietà come la dimensione del contenitore, la forma e lo sfondo. Per ulteriori informazioni, vedere [Shape Layout Format](https://docs.aspose.com/slides/it/nodejs-java/shape-manipulations/#access-layout-formats-for-shape).

Tuttavia, quando PowerPoint gestisce un oggetto di inchiostro, ignora tutte le proprietà del frame dell'oggetto (contenitore) tranne la sua dimensione. La dimensione dell'area del contenitore è determinata dai metodi standard [Shape.getWidth](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/#getWidth--) e [Shape.getHeight](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/#getHeight--) :

![ink_powerpoint1](ink_powerpoint1.png)

## **Tracce di inchiostro**

Una traccia di inchiostro è un elemento base usato per registrare la traiettoria di una penna mentre l'utente scrive inchiostro digitale. Una traccia memorizza una sequenza di punti collegati.

La forma più semplice di codifica specifica le coordinate X e Y di ogni punto di campionamento. Quando tutti i punti collegati vengono renderizzati, producono un'immagine come questa:

![ink_powerpoint2](ink_powerpoint2.png)

## **Proprietà del pennello per il disegno**

Un pennello è usato per disegnare linee che collegano i punti di una traccia di inchiostro. Il pennello ha il proprio colore e dimensione, rappresentati dai metodi [InkBrush.getColor](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/inkbrush/#getColor--) e [InkBrush.getSize](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/inkbrush/#getSize--) .

### **Impostare il colore del pennello di inchiostro**

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const ink = slide.getShapes().get_Item(0);
    const brush = ink.getTraces()[0].getBrush();
    const red = java.getStaticFieldValue("java.awt.Color", "RED");
    brush.setColor(red);
} finally {
    presentation.dispose();
}
```

### **Impostare la dimensione del pennello di inchiostro**

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const ink = slide.getShapes().get_Item(0);
    const brush = ink.getTraces()[0].getBrush();
    const brushSize = java.newInstanceSync("java.awt.Dimension", 5, 10);
    brush.setSize(brushSize);
} finally {
    presentation.dispose();
}
```

In generale, la larghezza e l'altezza di un pennello non coincidono, quindi PowerPoint non mostra la dimensione del pennello (la sezione dati corrispondente è grigia). Quando la larghezza e l'altezza del pennello coincidono, PowerPoint mostra la sua dimensione in questo modo:

![ink_powerpoint3](ink_powerpoint3.png)

Per chiarezza, aumentiamo l'altezza dell'oggetto di inchiostro e rivediamo le dimensioni importanti:

![ink_powerpoint4](ink_powerpoint4.png)

Il contenitore (frame) non tiene conto della dimensione dei pennelli: assume sempre che lo spessore della linea sia zero (vedi l'immagine precedente).

Pertanto, per determinare l'area visibile dell'intero oggetto di inchiostro, è necessario considerare la dimensione del pennello delle sue tracce. Qui, l'oggetto target (la traccia di testo scritto a mano) è stato scalato alla dimensione del contenitore (frame). Quando la dimensione del contenitore cambia, la dimensione del pennello rimane costante, e viceversa.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint utilizza un comportamento simile per gli oggetti di testo:

![ink_powerpoint6](ink_powerpoint6.png)

## **Controllare l'aspetto dell'inchiostro durante l'esportazione e il rendering**

Aspose.Slides fornisce la classe [InkOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/inkoptions/) per controllare come gli oggetti di inchiostro appaiono nell'output esportato o renderizzato. È possibile utilizzare le sue proprietà per nascondere completamente l'inchiostro o modificare il modo in cui le operazioni di maschera del pennello di inchiostro sono interpretate.

Ink options sono disponibili attraverso le opzioni di esportazione o rendering per diversi tipi di output:

| Output | Proprietà opzioni Ink |
| --- | --- |
| PDF | [`PdfOptions.getInkOptions`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pdfoptions/#getInkOptions--) |
| HTML | [`HtmlOptions.getInkOptions`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/htmloptions/#getInkOptions--) |
| SVG | [`SVGOptions.getInkOptions`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/svgoptions/#getInkOptions--) |
| TIFF | [`TiffOptions.getInkOptions`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/tiffoptions/#getInkOptions--) |
| Slide image | [`RenderingOptions.getInkOptions`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/renderingoptions/#getInkOptions--) |

I seguenti metodi di [InkOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/inkoptions/) espongono le stesse due impostazioni:

- [InkOptions.getHideInk](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/inkoptions/#getHideInk--) determina se gli oggetti di inchiostro sono inclusi nell'output. Il valore predefinito è `false`.
- [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity--) determina se un'operazione di maschera è interpretata come opacità durante il rendering di un pennello di inchiostro. Il valore predefinito è `true`; chiamare [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity-boolean-) con `false` per utilizzare invece l'operazione ROP.

### **Nascondere gli oggetti di inchiostro nell'output PDF**

Per impostazione predefinita, gli oggetti di inchiostro rimangono visibili durante l'esportazione. Per creare un output pulito senza annotazioni scritte a mano o altri contenuti di inchiostro, chiamare [InkOptions.setHideInk](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/inkoptions/#setHideInk-boolean-) con `true`.

Il seguente esempio JavaScript esporta una presentazione in PDF nascondendo tutti gli oggetti di inchiostro:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const pdfOptions = new aspose.slides.PdfOptions();
    pdfOptions.getInkOptions().setHideInk(true);

    presentation.save("presentation_without_ink.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Nascondere gli oggetti di inchiostro durante il rendering di una diapositiva come immagine**

Per nascondere gli oggetti di inchiostro durante il rendering delle diapositive come immagini bitmap, configurare [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/renderingoptions/#getInkOptions--) e passare le opzioni di rendering a [Slide.getImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slide/#getImage-aspose.slides.IRenderingOptions-).

Il seguente esempio JavaScript renderizza la prima diapositiva come immagine PNG senza oggetti di inchiostro:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const renderingOptions = new aspose.slides.RenderingOptions();
    renderingOptions.getInkOptions().setHideInk(true);

    const slide = presentation.getSlides().get_Item(0);
    const image = slide.getImage(renderingOptions);
    try {
        image.save("slide_without_ink.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

### **Controllare il rendering della maschera di inchiostro**

L'impostazione [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity--) controlla come le operazioni di maschera sono interpretate durante il rendering dei pennelli di inchiostro. Il valore predefinito è `true`, che utilizza l'opacità. Per utilizzare invece l'operazione ROP, chiamare [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity-boolean-) con `false`.

Il seguente esempio JavaScript esporta una diapositiva in SVG e utilizza il rendering basato su ROP per le operazioni di maschera di inchiostro:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const svgOptions = new aspose.slides.SVGOptions();
    svgOptions.getInkOptions().setInterpretMaskOpAsOpacity(false);

    const outputStream = java.newInstanceSync("java.io.FileOutputStream", "slide.svg");
    try {
        const slide = presentation.getSlides().get_Item(0);
        slide.writeAsSvg(outputStream, svgOptions);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

La stessa impostazione può essere applicata tramite [TiffOptions.getInkOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/tiffoptions/#getInkOptions--) quando si esporta una presentazione o si renderizza una diapositiva in TIFF.

### **Scegliere se nascondere o conservare l'inchiostro**

Quando è necessaria una versione pulita di una presentazione annotata per la distribuzione senza segni di revisione, chiamare [InkOptions.setHideInk](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/inkoptions/#setHideInk-boolean-) con `true` durante l'esportazione.

Mantenere [InkOptions.getHideInk](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/inkoptions/#getHideInk--) al suo valore predefinito `false` quando le annotazioni di inchiostro fanno parte del contenuto previsto, ad esempio commenti di revisione, note scritte a mano, evidenziazioni o disegni che devono rimanere visibili nel risultato esportato. Questo consente alle applicazioni di generare output di revisione e finali separati dalla stessa presentazione senza modificare gli oggetti di inchiostro sorgente.

## **FAQ**

**Posso modificare il colore o la dimensione di un tratto di inchiostro esistente?**

Sì. Ottieni la traccia da [Ink.getTraces](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ink/#getTraces--) e poi modifica il suo [InkTrace.getBrush](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/inktrace/#getBrush--). Chiama [InkBrush.setColor](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/inkbrush/#setColor-java.awt.Color-) o [InkBrush.setSize](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/inkbrush/#setSize-java.awt.geom.Dimension2D-) per cambiare il pennello.

**Nascondere l'inchiostro modifica la presentazione di origine?**

No. Chiamare [InkOptions.setHideInk](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/inkoptions/#setHideInk-boolean-) influisce solo sul risultato renderizzato o esportato; non rimuove né modifica gli oggetti di inchiostro nella presentazione di origine.

**Quali formati di esportazione supportano le opzioni di inchiostro?**

È possibile configurare le opzioni di inchiostro per PDF, HTML, SVG, TIFF e immagini bitmap delle diapositive tramite le corrispondenti opzioni di esportazione o rendering illustrate sopra.

**Approfondimenti**

* Per leggere informazioni generali sulle forme, vedere la sezione [PowerPoint Shapes](https://docs.aspose.com/slides/it/nodejs-java/powerpoint-shapes/).
* Per ulteriori informazioni sui valori efficaci, vedere [Shape Effective Properties](https://docs.aspose.com/slides/it/nodejs-java/shape-effective-properties/#get-effective-font-height-value).
* Per dettagli sull'esportazione PDF, vedere [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/it/nodejs-java/convert-powerpoint-to-pdf/).
* Per dettagli sull'esportazione HTML, vedere [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/it/nodejs-java/convert-powerpoint-to-html/).
* Per dettagli sull'esportazione SVG, vedere [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/it/nodejs-java/render-a-slide-as-an-svg-image/).
* Per dettagli sull'esportazione TIFF, vedere [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/it/nodejs-java/convert-powerpoint-to-tiff/).
* Per dettagli sul rendering diapositiva‑immagine, vedere [Convert Presentation Slides to Images](https://docs.aspose.com/slides/it/nodejs-java/convert-slide/).