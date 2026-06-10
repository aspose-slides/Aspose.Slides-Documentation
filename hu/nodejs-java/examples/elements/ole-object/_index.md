---
title: OLE objektum
type: docs
weight: 210
url: /hu/nodejs-java/examples/elements/ole-object/
keywords:
- kód példa
- OLE objektum
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Az OLE objektumok kezelése az Aspose.Slides for Node.js-ben: beillesztés, hivatkozás, frissítés és beágyazott tartalom kinyerése JavaScript segítségével PPT, PPTX és ODP prezentációkban."
---
Ez a cikk bemutatja, hogyan lehet egy fájlt OLE objektumként beágyazni, és annak adatait frissíteni az **Aspose.Slides for Node.js via Java** használatával.

## **OLE objektum hozzáadása**

Ágyazz be egy PDF fájlt a prezentációba.

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

## **OLE objektum elérése**

Hozd vissza a dián az első OLE objektum keretét.

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

## **OLE objektum eltávolítása**

Töröld a diáról a beágyazott OLE objektumot.

```js
function removeOleObject() {
    let presentation = new aspose.slides.Presentation("ole_object.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Feltételezve, hogy az első alakzat az OLE objektum keret.
        let oleFrame = slide.getShapes().get_Item(0);
        
        slide.getShapes().remove(oleFrame);

        presentation.save("ole_object_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **OLE objektum adatainak frissítése**

Cseréld ki a meglévő OLE objektumban beágyazott adatokat.

```js
function updateOleObject() {
    let presentation = new aspose.slides.Presentation("ole_object.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Feltételezve, hogy az első alakzat az OLE objektum keret.
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