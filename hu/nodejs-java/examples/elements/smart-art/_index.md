---
title: SmartArt
type: docs
weight: 140
url: /hu/nodejs-java/examples/elements/smart-art/
keywords:
- kódpélda
- SmartArt
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Dolgozzon a SmartArt-gal az Aspose.Slides for Node.js-ben: hozzon létre, szerkesszen, konvertáljon és formázza a diagramokat JavaScript-kel PowerPoint és OpenDocument prezentációkhoz."
---
Ez a cikk bemutatja, hogyan lehet SmartArt grafikákat hozzáadni, elérni, eltávolítani, és elrendezéseket módosítani az **Aspose.Slides for Node.js via Java** használatával.

## **SmartArt hozzáadása**

Illessz be egy SmartArt grafikát egy beépített elrendezés valamelyikével.

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

## **SmartArt elérése**

Szerezd meg az első SmartArt objektumot egy dián.

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

## **SmartArt eltávolítása**

Törölj egy SmartArt alakzatot a diárról.

```js
function removeSmartArt() {
    let presentation = new aspose.slides.Presentation("smartart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Feltételezve, hogy az első alakzat SmartArt.
        let smartArt = slide.getShapes().get_Item(0);

        slide.getShapes().remove(smartArt);

        presentation.save("smartart_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **SmartArt elrendezés módosítása**

Frissítsd a meglévő SmartArt grafika elrendezéstípusát.

```js
function changeSmartArtLayout() {
    let presentation = new aspose.slides.Presentation("smartart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Feltételezve, hogy az első alakzat SmartArt.
        let smartArt = slide.getShapes().get_Item(0);

        smartArt.setLayout(aspose.slides.SmartArtLayoutType.VerticalPictureList);

        presentation.save("smartart_layout_changed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```