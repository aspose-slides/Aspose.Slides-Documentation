---
title: SmartArt
type: docs
weight: 140
url: /nl/nodejs-java/examples/elements/smart-art/
keywords:
- codevoorbeeld
- SmartArt
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Werken met SmartArt in Aspose.Slides voor Node.js: maak, bewerk, converteer en style diagrammen met JavaScript voor PowerPoint- en OpenDocument-presentaties."
---
Dit artikel toont hoe u SmartArt‑afbeeldingen kunt toevoegen, openen, verwijderen en lay‑outs kunt wijzigen met **Aspose.Slides for Node.js via Java**.

## **SmartArt toevoegen**

Voeg een SmartArt‑afbeelding in met een van de ingebouwde indelingen.

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

## **SmartArt openen**

Haal het eerste SmartArt‑object op een dia op.

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

## **SmartArt verwijderen**

Verwijder een SmartArt‑vorm van de dia.

```js
function removeSmartArt() {
    let presentation = new aspose.slides.Presentation("smartart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Aannemende dat de eerste vorm SmartArt is.
        let smartArt = slide.getShapes().get_Item(0);

        slide.getShapes().remove(smartArt);

        presentation.save("smartart_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **SmartArt‑indeling wijzigen**

Werk het indelingstype van een bestaande SmartArt‑afbeelding bij.

```js
function changeSmartArtLayout() {
    let presentation = new aspose.slides.Presentation("smartart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Aannemende dat de eerste vorm SmartArt is.
        let smartArt = slide.getShapes().get_Item(0);

        smartArt.setLayout(aspose.slides.SmartArtLayoutType.VerticalPictureList);

        presentation.save("smartart_layout_changed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```