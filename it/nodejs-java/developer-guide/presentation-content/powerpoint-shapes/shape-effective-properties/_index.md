---
title: Ottieni Proprietà Effettive della Forma dalle Presentazioni in JavaScript
linktitle: Proprietà Effettive
type: docs
weight: 50
url: /it/nodejs-java/shape-effective-properties/
keywords:
- proprietà della forma
- proprietà della fotocamera
- impianto di illuminazione
- forma smussata
- riquadro di testo
- stile di testo
- altezza del carattere
- formato di riempimento
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Scopri come Aspose.Slides per Node.js tramite Java calcola e applica le proprietà effettive delle forme per una resa precisa di PowerPoint."
---
## **Panoramica**

Questo argomento spiega la differenza tra le proprietà **locali** e **effettive**. I valori locali sono valori impostati direttamente a un livello specifico di formattazione, come ad esempio:

1. Proprietà delle porzioni su una diapositiva.  
1. Stili di testo della forma prototipo in un layout o in una diapositiva master, quando la forma del riquadro di testo della porzione ne possiede uno.  
1. Impostazioni di testo globali in una presentazione.

I valori locali possono essere definiti o omessi a qualsiasi livello. Quando Aspose.Slides ha bisogno della formattazione finale “come renderizzata”, risolve la catena di ereditarietà e restituisce i valori **effettivi**. È possibile ottenerli chiamando il metodo `getEffective` sull'oggetto di formattazione locale.

L'esempio seguente mostra come ottenere i valori effettivi. Si assume che la prima forma nella prima diapositiva sia un [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/) con un riquadro di testo e almeno una porzione.

```javascript

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let localTextFrameFormat = shape.getTextFrame().getTextFrameFormat();
    let effectiveTextFrameFormat = localTextFrameFormat.getEffective();

    let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    let localPortionFormat = paragraph.getPortions().get_Item(0).getPortionFormat();
    let effectivePortionFormat = localPortionFormat.getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
I dati di formattazione effettiva rappresentano la formattazione calcolata corrente dopo l'applicazione dell'ereditarietà. Nell'implementazione attuale, alcuni oggetti di dati effettivi possono essere memorizzati nella cache internamente. Richiamare nuovamente `getEffective` dopo aver modificato la formattazione genitore o ereditata può aggiornare la cache e un oggetto precedentemente ottenuto potrebbe non rappresentare più lo stato precedente. Se è necessario conservare i valori effettivi per un riutilizzo futuro, copiare le proprietà richieste, come altezza del carattere, colore di riempimento, stile del carattere o allineamento, nel proprio oggetto dati.
{{% /alert %}}

## **Ottenere le Proprietà Effettive di una Fotocamera**

Aspose.Slides permette di ottenere le proprietà effettive di una fotocamera. L'oggetto dati della fotocamera effettiva contiene proprietà immutabili della fotocamera ed è esposto tramite i valori effettivi restituiti per [ThreeDFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/threedformat/).

L'esempio di codice seguente mostra come ottenere le proprietà effettive per la fotocamera. Si assume che la prima forma nella prima diapositiva abbia una formattazione 3D.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let camera = threeDEffectiveData.getCamera();
    let cameraType = camera.getCameraType();
    let fieldOfViewAngle = camera.getFieldOfViewAngle();
    let zoom = camera.getZoom();

    console.log("= Effective camera properties =");
    console.log("Type: " + cameraType);
    console.log("Field of view: " + fieldOfViewAngle);
    console.log("Zoom: " + zoom);
} finally {
    presentation.dispose();
}
```

## **Ottenere le Proprietà Effettive di un Sistema di Illuminazione**

Aspose.Slides permette di ottenere le proprietà effettive di un sistema di illuminazione. L'oggetto dati del sistema di illuminazione effettivo contiene proprietà immutabili del sistema di illuminazione ed è esposto tramite i valori effettivi restituiti per [ThreeDFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/threedformat/).

L'esempio di codice seguente mostra come ottenere le proprietà effettive per il sistema di illuminazione. Si assume che la prima forma nella prima diapositiva abbia una formattazione 3D.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let lightRig = threeDEffectiveData.getLightRig();
    let lightType = lightRig.getLightType();
    let direction = lightRig.getDirection();

    console.log("= Effective light rig properties =");
    console.log("Type: " + lightType);
    console.log("Direction: " + direction);
} finally {
    presentation.dispose();
}
```

## **Ottenere le Proprietà Effettive di una Forma Smussata**

Aspose.Slides permette di ottenere le proprietà effettive di un smusso di forma. L'oggetto dati dello smusso di forma effettivo contiene proprietà immutabili del rilievo di una forma ed è esposto tramite i valori effettivi restituiti per [ThreeDFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/threedformat/).

L'esempio di codice seguente mostra come ottenere le proprietà effettive per lo smusso superiore di una forma. Si assume che la prima forma nella prima diapositiva abbia una formattazione 3D.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let bevelTop = threeDEffectiveData.getBevelTop();
    let bevelType = bevelTop.getBevelType();
    let bevelWidth = bevelTop.getWidth();
    let bevelHeight = bevelTop.getHeight();

    console.log("= Effective shape's top face relief properties =");
    console.log("Type: " + bevelType);
    console.log("Width: " + bevelWidth);
    console.log("Height: " + bevelHeight);
} finally {
    presentation.dispose();
}
```

## **Ottenere le Proprietà Effettive di un Riquadro di Testo**

Utilizzando Aspose.Slides, è possibile ottenere le proprietà effettive di un riquadro di testo. L'oggetto dati restituito contiene le proprietà di formattazione del riquadro di testo.

L'esempio di codice seguente mostra come ottenere le proprietà di formattazione effettiva del riquadro di testo. Si assume che la prima forma nella prima diapositiva sia un [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/) con un riquadro di testo.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    let effectiveTextFrameFormat = textFrameFormat.getEffective();
    let anchoringType = effectiveTextFrameFormat.getAnchoringType();
    let autofitType = effectiveTextFrameFormat.getAutofitType();
    let textVerticalType = effectiveTextFrameFormat.getTextVerticalType();
    let marginLeft = effectiveTextFrameFormat.getMarginLeft();
    let marginTop = effectiveTextFrameFormat.getMarginTop();
    let marginRight = effectiveTextFrameFormat.getMarginRight();
    let marginBottom = effectiveTextFrameFormat.getMarginBottom();

    console.log("Anchoring type: " + anchoringType);
    console.log("Autofit type: " + autofitType);
    console.log("Text vertical type: " + textVerticalType);
    console.log("Margins");
    console.log("   Left: " + marginLeft);
    console.log("   Top: " + marginTop);
    console.log("   Right: " + marginRight);
    console.log("   Bottom: " + marginBottom);
} finally {
    presentation.dispose();
}
```

## **Ottenere le Proprietà Effettive di uno Stile di Testo**

Utilizzando Aspose.Slides, è possibile ottenere le proprietà effettive di uno stile di testo. L'oggetto dati restituito contiene le proprietà dello stile di testo.

L'esempio di codice seguente mostra come ottenere le proprietà effettive dello stile di testo. Si assume che la prima forma nella prima diapositiva sia un [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/) con un riquadro di testo.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);
    let effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    let levelCount = 9;

    for (let levelIndex = 0; levelIndex < levelCount; levelIndex++) {
        let effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);
        let depth = effectiveStyleLevel.getDepth();
        let indent = effectiveStyleLevel.getIndent();
        let alignment = effectiveStyleLevel.getAlignment();
        let fontAlignment = effectiveStyleLevel.getFontAlignment();

        console.log("= Effective paragraph formatting for style level #" + levelIndex + " =");

        console.log("Depth: " + depth);
        console.log("Indent: " + indent);
        console.log("Alignment: " + alignment);
        console.log("Font alignment: " + fontAlignment);
    }
} finally {
    presentation.dispose();
}
```

## **Ottenere il Valore Effettivo dell'Altezza del Carattere**

Utilizzando Aspose.Slides, è possibile ottenere l'altezza del carattere effettiva. Il codice seguente dimostra come l'altezza del carattere effettiva di una porzione cambia dopo che i valori locali dell'altezza del carattere sono impostati a diversi livelli della struttura della presentazione.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shapeType = aspose.slides.ShapeType.Rectangle;
    let autoShape = slide.getShapes().addAutoShape(shapeType, 100, 100, 400, 75, false);
    autoShape.addTextFrame("");

    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    let firstPortion = new aspose.slides.Portion("Sample text with first portion");
    let secondPortion = new aspose.slides.Portion(" and second portion.");

    paragraph.getPortions().add(firstPortion);
    paragraph.getPortions().add(secondPortion);

    let firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    let secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    let firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    let secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height just after creation:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting the presentation default font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting paragraph default font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    firstPortion.getPortionFormat().setFontHeight(55);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting portion #0 font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    secondPortion.getPortionFormat().setFontHeight(18);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting portion #1 font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    let saveFormat = aspose.slides.SaveFormat.Pptx;
    presentation.save("SetLocalFontHeightValues.pptx", saveFormat);
} finally {
    presentation.dispose();
}
```

## **Ottenere il Formato di Riempimento Effettivo per una Tabella**

Utilizzando Aspose.Slides, è possibile ottenere la formattazione di riempimento effettiva per le diverse parti di una tabella. L'oggetto dati restituito contiene le proprietà di formattazione di riempimento. La formattazione delle celle ha priorità superiore a quella delle righe, la formattazione delle righe ha priorità superiore a quella delle colonne e la formattazione delle colonne ha priorità superiore a quella dell'intera tabella.

Di conseguenza, le proprietà di formattazione effettiva delle celle sono utilizzate per disegnare la cella della tabella. L'esempio di codice seguente mostra come ottenere la formattazione di riempimento effettiva per le diverse parti della tabella. Si assume che la prima forma nella prima diapositiva sia una [Table](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/table/).

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let table = slide.getShapes().get_Item(0);

    let tableFormatEffective = table.getTableFormat().getEffective();
    let rowFormatEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    let columnFormatEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    let cellFormatEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    let tableFillFormatEffective = tableFormatEffective.getFillFormat();
    let rowFillFormatEffective = rowFormatEffective.getFillFormat();
    let columnFillFormatEffective = columnFormatEffective.getFillFormat();
    let cellFillFormatEffective = cellFormatEffective.getFillFormat();
} finally {
    presentation.dispose();
}
```

## **FAQ**

**`getEffective` restituisce uno snapshot?**

Non sempre. I dati effettivi rappresentano la formattazione calcolata dopo l'applicazione dell'ereditarietà, ma alcuni oggetti di dati effettivi possono essere memorizzati nella cache internamente. Una chiamata successiva a `getEffective` può ricalcolare la formattazione e aggiornare la cache, quindi un oggetto ottenuto in precedenza non dovrebbe essere considerato uno snapshot durevole.

**Quando dovrei leggere nuovamente le proprietà effettive?**

Richiamare `getEffective` di nuovo dopo aver modificato la formattazione locale, gli stili genitore, la formattazione del layout, la formattazione master o le impostazioni predefinite a livello di presentazione. La chiamata successiva rivaluta la gerarchia di formattazione e restituisce il risultato effettivo corrente.

**La modifica o la rimozione di un layout/master influisce sulle proprietà effettive già recuperate?**

Sì, ma la modifica si riflette nella successiva chiamata a `getEffective`. Se una fonte di formattazione genitore viene modificata o rimossa, i dati effettivi ottenuti in precedenza possono diventare obsoleti. Una volta richiamato nuovamente `getEffective`, Aspose.Slides rivaluta l'albero di formattazione e i caratteri, i colori, le dimensioni o altri valori risultanti possono cambiare.

**Posso modificare i valori tramite gli oggetti di dati effettivi?**

No. Gli oggetti di dati effettivi espongono valori calcolati. Apportare le modifiche negli oggetti di formattazione locale, quindi ottenere nuovamente i valori effettivi.

**Cosa succede se una proprietà non è impostata a livello di forma, né nel layout/master, né nelle impostazioni globali?**

Il valore effettivo è determinato dal meccanismo predefinito, che include le impostazioni predefinite di PowerPoint e di Aspose.Slides. Quel valore risolto diventa parte dei dati effettivi correnti.

**Da un valore di carattere effettivo, posso capire quale livello ha fornito la dimensione o il tipo di carattere?**

Non direttamente. I dati effettivi restituiscono il valore finale. Per trovare la sorgente, controllare i valori locali nella porzione, nel paragrafo, nel riquadro di testo e negli stili di testo a livello di layout, master e presentazione per vedere dove appare la prima definizione esplicita.

**Perché a volte i valori effettivi sembrano identici a quelli locali?**

Perché il valore locale è risultato finale (non è stata necessaria alcuna eredità di livello superiore). In tali casi, il valore effettivo corrisponde a quello locale.

**Quando dovrei usare le proprietà effettive e quando lavorare solo con quelle locali?**

Utilizzare i dati effettivi quando è necessario il risultato “come renderizzato” dopo che tutte le eredità sono state applicate, ad esempio per allineare colori, rientri o dimensioni. Se è necessario conservare tali valori indipendentemente da eventuali modifiche di formattazione successive, copiarli in un proprio oggetto. Se è necessario modificare la formattazione a un livello specifico, cambiare le proprietà locali e, se necessario, leggere nuovamente i dati effettivi per verificare il risultato.