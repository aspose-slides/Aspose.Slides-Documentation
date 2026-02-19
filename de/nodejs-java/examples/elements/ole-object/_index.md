---
title: OLE-Objekt
type: docs
weight: 210
url: /de/nodejs-java/examples/elements/ole-object/
keywords:
- Codebeispiel
- OLE-Objekt
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "OLE-Objekte in Aspose.Slides für Node.js verarbeiten: Einfügen, Verlinken, Aktualisieren und Extrahieren eingebetteter Inhalte mit JavaScript in PPT-, PPTX- und ODP-Präsentationen."
---
Dieser Artikel zeigt, wie man eine Datei als OLE-Objekt einbettet und ihre Daten mit **Aspose.Slides for Node.js via Java** aktualisiert.

## **OLE-Objekt hinzufügen**

Betten Sie eine PDF-Datei in eine Präsentation ein.

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

## **OLE-Objekt zugreifen**

Rufen Sie das erste OLE-Objekt‑Frame auf einer Folie ab.

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

## **OLE-Objekt entfernen**

Löschen Sie ein eingebettetes OLE-Objekt von der Folie.

```js
function removeOleObject() {
    let presentation = new aspose.slides.Presentation("ole_object.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Angenommen, das erste Shape ist das OLE-Objekt-Frame.
        let oleFrame = slide.getShapes().get_Item(0);
        
        slide.getShapes().remove(oleFrame);

        presentation.save("ole_object_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **OLE-Objektdaten aktualisieren**

Ersetzen Sie die in einem vorhandenen OLE-Objekt eingebetteten Daten.

```js
function updateOleObject() {
    let presentation = new aspose.slides.Presentation("ole_object.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Angenommen, das erste Shape ist das OLE-Objekt-Frame.
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