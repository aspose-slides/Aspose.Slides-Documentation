---
title: SmartArt
type: docs
weight: 140
url: /it/nodejs-java/examples/elements/smart-art/
keywords:
- esempio di codice
- SmartArt
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Lavorare con SmartArt in Aspose.Slides per Node.js: creare, modificare, convertire e formattare diagrammi con JavaScript per presentazioni PowerPoint e OpenDocument."
---
Questo articolo dimostra come aggiungere grafiche SmartArt, accedervi, rimuoverle e modificare i layout utilizzando **Aspose.Slides for Node.js via Java**.

## **Add SmartArt**

Inserisci una grafica SmartArt utilizzando uno dei layout predefiniti.

```js
function addSmartArt() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let smartArt = slide.getShapes().addSmartArt(50, 50, 400, 300, aspose.slides.SmartArtLayoutType.BasicProcess);

        presentation.save("smartart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Access SmartArt**

Recupera il primo oggetto SmartArt su una diapositiva.

```js
function accessSmartArt() {
    let presentation = new aspose.slides.Presentation("smartart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let firstSmartArt = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
                firstSmartArt = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Remove SmartArt**

Elimina una forma SmartArt dalla diapositiva.

```js
function removeSmartArt() {
    let presentation = new aspose.slides.Presentation("smartart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Supponendo che la prima forma sia SmartArt.
        let smartArt = slide.getShapes().get_Item(0);

        slide.getShapes().remove(smartArt);

        presentation.save("smartart_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Change SmartArt Layout**

Aggiorna il tipo di layout di una grafica SmartArt esistente.

```js
function changeSmartArtLayout() {
    let presentation = new aspose.slides.Presentation("smartart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Supponendo che la prima forma sia SmartArt.
        let smartArt = slide.getShapes().get_Item(0);

        smartArt.setLayout(aspose.slides.SmartArtLayoutType.VerticalPictureList);

        presentation.save("smartart_layout_changed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```