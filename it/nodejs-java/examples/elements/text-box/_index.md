---
title: Casella di testo
type: docs
weight: 40
url: /it/nodejs-java/examples/elements/text-box/
keywords:
- esempio di codice
- casella di testo
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Lavora con le caselle di testo in Aspose.Slides per Node.js: aggiungi, formatta, allinea, avvolgi, adatta automaticamente e applichi stili al testo usando JavaScript per presentazioni PPT, PPTX e ODP."
---
In Aspose.Slides, una **casella di testo** è rappresentata da un `AutoShape`. Quasi qualsiasi forma può contenere testo, ma una tipica casella di testo non ha riempimento né bordo e visualizza solo il testo.

Questa guida spiega come aggiungere, accedere e rimuovere le caselle di testo programmaticamente.

## **Aggiungere una casella di testo**

Una casella di testo è semplicemente un `AutoShape` senza riempimento né bordo e con del testo formattato. Ecco come crearne una:

```js
function addTextBox() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Crea una forma rettangolare (predefinita con riempimento, bordo e senza testo).
        let textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 75, 150, 100);

        // Rimuovi riempimento e bordo per farla apparire come una tipica casella di testo.
        let boxFillType = java.newByte(aspose.slides.FillType.NoFill);
        textBox.getFillFormat().setFillType(boxFillType);
        textBox.getLineFormat().getFillFormat().setFillType(boxFillType);

        // Imposta la formattazione del testo.
        let paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        let textFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();
        let textFillType = java.newByte(aspose.slides.FillType.Solid);
        let textFillColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
        textFormat.getFillFormat().setFillType(textFillType);
        textFormat.getFillFormat().getSolidFillColor().setColor(textFillColor);

        // Assegna il contenuto testuale effettivo.
        textBox.getTextFrame().setText("Some text...");

        presentation.save("text_box.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Nota:** Qualsiasi `AutoShape` che contiene un `TextFrame` non vuoto può funzionare come una casella di testo.

## **Accedere a una casella di testo**

Recupera la prima casella di testo dalla diapositiva.

```js
function accessTextBox() {
    let presentation = new aspose.slides.Presentation("text_box.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let firstTextBox = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            // Solo gli AutoShape possono contenere testo modificabile.
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                firstTextBox = shape;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Rimuovere le caselle di testo per contenuto**

Questo esempio trova ed elimina tutte le caselle di testo nella prima diapositiva che contengono una parola chiave specifica:

```js
function removeTextBoxes() {
    let presentation = new aspose.slides.Presentation("text_box.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let shapesToRemove = [];
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                let autoShape = shape;
                if (autoShape.getTextFrame().getText().includes("Slide")) {
                    shapesToRemove.push(shape);
                }
            }
        }

        for (let i = 0; i < shapesToRemove.length; i++) {
            slide.getShapes().remove(shapesToRemove[i]);
        }

        presentation.save("text_boxes_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Suggerimento:** Crea sempre una copia della collezione di forme prima di modificarla durante l'iterazione per evitare errori di modifica della collezione.