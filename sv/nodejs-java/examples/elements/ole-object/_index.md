---
title: OLE-objekt
type: docs
weight: 210
url: /sv/nodejs-java/examples/elements/ole-object/
keywords:
- kodexempel
- OLE-objekt
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Hantera OLE-objekt i Aspose.Slides för Node.js: infoga, länka, uppdatera och extrahera inbäddat innehåll med JavaScript i PPT-, PPTX- och ODP-presentationer."
---
Den här artikeln demonstrerar hur man bäddar in en fil som ett OLE-objekt och uppdaterar dess data med **Aspose.Slides for Node.js via Java**.

## **Lägg till ett OLE-objekt**

Bädda in en PDF-fil i en presentation.

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

## **Åtkomst till ett OLE-objekt**

Hämta den första OLE-objekt-ramen på en bild.

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

## **Ta bort ett OLE-objekt**

Ta bort ett inbäddat OLE-objekt från bilden.

```js
function removeOleObject() {
    let presentation = new aspose.slides.Presentation("ole_object.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Antar att den första formen är OLE-objektramen.
        let oleFrame = slide.getShapes().get_Item(0);
        
        slide.getShapes().remove(oleFrame);

        presentation.save("ole_object_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Uppdatera OLE-objektdata**

Ersätt den data som är inbäddad i ett befintligt OLE-objekt.

```js
function updateOleObject() {
    let presentation = new aspose.slides.Presentation("ole_object.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Antar att den första formen är OLE-objektramen.
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