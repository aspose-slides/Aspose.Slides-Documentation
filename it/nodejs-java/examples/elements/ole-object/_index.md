---
title: Oggetto OLE
type: docs
weight: 210
url: /it/nodejs-java/examples/elements/ole-object/
keywords:
- esempio di codice
- oggetto OLE
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Gestisci oggetti OLE in Aspose.Slides per Node.js: inserisci, collega, aggiorna e estrai contenuti incorporati con JavaScript in presentazioni PPT, PPTX e ODP."
---
Questo articolo dimostra come incorporare un file come oggetto OLE e aggiornare i suoi dati utilizzando **Aspose.Slides for Node.js via Java**.

## **Aggiungi un oggetto OLE**

Incorpora un file PDF in una presentazione.

```js
function addOleObject() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let pdfStream = fs.readFileSync("doc.pdf");
        let pdfData = java.newArray("byte", Array.from(pdfStream));
        let dataInfo = new aspose.slides.OleEmbeddedDataInfo(pdfData, "pdf");
        let oleFrame = slide.getShapes().addOleObjectFrame(20, 20, 50, 50, dataInfo);

        presentation.save("ole_object.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Accedi a un oggetto OLE**

Recupera il primo frame dell'oggetto OLE su una diapositiva.

```js
function accessOleObject() {
    let presentation = new aspose.slides.Presentation("ole_object.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let firstOleFrame = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IOleObjectFrame")) {
                firstOleFrame = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Rimuovi un oggetto OLE**

Elimina un oggetto OLE incorporato dalla diapositiva.

```js
function removeOleObject() {
    let presentation = new aspose.slides.Presentation("ole_object.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Supponendo che la prima forma sia il frame dell'oggetto OLE.
        let oleFrame = slide.getShapes().get_Item(0);
        
        slide.getShapes().remove(oleFrame);

        presentation.save("ole_object_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Aggiorna i dati dell'oggetto OLE**

Sostituisci i dati incorporati in un oggetto OLE esistente.

```js
function updateOleObject() {
    let presentation = new aspose.slides.Presentation("ole_object.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Assumendo che la prima forma sia il frame dell'oggetto OLE.
        let oleFrame = slide.getShapes().get_Item(0);

        let dataStream = fs.readFileSync("picture.png");
        let newData = java.newArray("byte", Array.from(dataStream));
        let dataInfo = new aspose.slides.OleEmbeddedDataInfo(newData, "png");
        oleFrame.setEmbeddedData(dataInfo);

        presentation.save("ole_object_updated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```