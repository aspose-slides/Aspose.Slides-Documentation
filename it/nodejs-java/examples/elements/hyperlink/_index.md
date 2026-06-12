---
title: Collegamento ipertestuale
type: docs
weight: 130
url: /it/nodejs-java/examples/elements/hyperlink/
keywords:
- esempio di codice
- collegamento ipertestuale
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Aggiungi e gestisci collegamenti ipertestuali in Aspose.Slides per Node.js: collega testo, forme e immagini, imposta destinazioni e azioni per PPT, PPTX e ODP con esempi."
---
Questo articolo dimostra come aggiungere, accedere, rimuovere e aggiornare collegamenti ipertestuali su forme utilizzando **Aspose.Slides for Node.js via Java**.

## **Aggiungi un collegamento ipertestuale**

Crea una forma rettangolare con un collegamento ipertestuale che punta a un sito Web esterno.

```js
function addHyperlink() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        let hyperlink = new aspose.slides.Hyperlink("https://www.aspose.com");
        textPortion.getPortionFormat().setHyperlinkClick(hyperlink);

        presentation.save("hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Accedi a un collegamento ipertestuale**

Leggi il collegamento ipertestuale dalla porzione di testo di una forma.

```js
function accessHyperlink() {
    let presentation = new aspose.slides.Presentation("hyperlink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Assumendo che la prima forma contenga il testo con collegamento ipertestuale.
        let shape = slide.getShapes().get_Item(0);

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        let hyperlink = textPortion.getPortionFormat().getHyperlinkClick();
    } finally {
        presentation.dispose();
    }
}
```

## **Rimuovi un collegamento ipertestuale**

Elimina il collegamento ipertestuale dal testo di una forma.

```js
function removeHyperlink() {
    let presentation = new aspose.slides.Presentation("hyperlink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Assumendo che la prima forma contenga il testo con collegamento ipertestuale.
        let shape = slide.getShapes().get_Item(0);

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        textPortion.getPortionFormat().setHyperlinkClick(null);

        presentation.save("hyperlink_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Aggiorna un collegamento ipertestuale**

Modifica la destinazione di un collegamento ipertestuale esistente. Usa `HyperlinkManager` per modificare il testo che contiene già un collegamento ipertestuale, simulando il modo in cui PowerPoint aggiorna i collegamenti ipertestuali in modo sicuro.

```js
function updateHyperlink() {
    let presentation = new aspose.slides.Presentation("hyperlink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Supponendo che la prima forma contenga il testo con collegamento ipertestuale.
        let shape = slide.getShapes().get_Item(0);

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        // Cambiare un collegamento ipertestuale all'interno del testo esistente dovrebbe essere fatto tramite
        // HyperlinkManager anziché impostare direttamente la proprietà.
        // Questo riproduce come PowerPoint aggiorna in modo sicuro i collegamenti ipertestuali.
        textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com");

        presentation.save("hyperlink_updated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```