---
title: SmartArt
type: docs
weight: 140
url: /sv/nodejs-java/examples/elements/smart-art/
keywords:
- kodexempel
- SmartArt
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Arbeta med SmartArt i Aspose.Slides för Node.js: skapa, redigera, konvertera och formatera diagram med JavaScript för PowerPoint- och OpenDocument-presentationer."
---
Denna artikel visar hur du lägger till SmartArt-grafik, får åtkomst till dem, tar bort dem och ändrar layouter med **Aspose.Slides for Node.js via Java**.

## **Lägg till SmartArt**

Infoga en SmartArt-grafik med hjälp av en av de inbyggda layouterna.

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

## **Åtkomst till SmartArt**

Hämta det första SmartArt-objektet på en bild.

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

## **Ta bort SmartArt**

Ta bort en SmartArt-form från bilden.

```js
function removeSmartArt() {
    let presentation = new aspose.slides.Presentation("smartart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Antar att den första formen är SmartArt.
        let smartArt = slide.getShapes().get_Item(0);

        slide.getShapes().remove(smartArt);

        presentation.save("smartart_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Ändra SmartArt-layout**

Uppdatera layouttypen för en befintlig SmartArt-grafik.

```js
function changeSmartArtLayout() {
    let presentation = new aspose.slides.Presentation("smartart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Antar att den första formen är SmartArt.
        let smartArt = slide.getShapes().get_Item(0);

        smartArt.setLayout(aspose.slides.SmartArtLayoutType.VerticalPictureList);

        presentation.save("smartart_layout_changed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```