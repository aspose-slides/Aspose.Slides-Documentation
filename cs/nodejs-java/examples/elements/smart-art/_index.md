---
title: SmartArt
type: docs
weight: 140
url: /cs/nodejs-java/examples/elements/smart-art/
keywords:
- ukázka kódu
- SmartArt
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Práce se SmartArt v Aspose.Slides pro Node.js: vytváření, úprava, převod a stylování diagramů pomocí JavaScriptu pro prezentace PowerPoint a OpenDocument."
---
Tento článek ukazuje, jak přidat grafiku SmartArt, jak k ní přistupovat, jak ji odstranit a jak změnit rozvržení pomocí **Aspose.Slides for Node.js via Java**.

## **Přidat SmartArt**

Vložte grafiku SmartArt pomocí jednoho ze zabudovaných rozvržení.

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

## **Přístup k SmartArt**

Získejte první objekt SmartArt na snímku.

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

## **Odstranit SmartArt**

Odstraňte tvar SmartArt ze snímku.

```js
function removeSmartArt() {
    let presentation = new aspose.slides.Presentation("smartart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Předpokládá se, že první tvar je SmartArt.
        let smartArt = slide.getShapes().get_Item(0);

        slide.getShapes().remove(smartArt);

        presentation.save("smartart_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Změnit rozvržení SmartArt**

Aktualizujte typ rozvržení existující grafiky SmartArt.

```js
function changeSmartArtLayout() {
    let presentation = new aspose.slides.Presentation("smartart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Předpokládá se, že první tvar je SmartArt.
        let smartArt = slide.getShapes().get_Item(0);

        smartArt.setLayout(aspose.slides.SmartArtLayoutType.VerticalPictureList);

        presentation.save("smartart_layout_changed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```