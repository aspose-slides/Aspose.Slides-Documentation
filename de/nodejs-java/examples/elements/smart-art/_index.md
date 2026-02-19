---
title: SmartArt
type: docs
weight: 140
url: /de/nodejs-java/examples/elements/smart-art/
keywords:
- Codebeispiel
- SmartArt
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Arbeiten Sie mit SmartArt in Aspose.Slides für Node.js: Erstellen, bearbeiten, konvertieren und formatieren Sie Diagramme mit JavaScript für PowerPoint‑ und OpenDocument‑Präsentationen."
---
Dieser Artikel demonstriert, wie SmartArt‑Grafiken hinzugefügt, darauf zugegriffen, entfernt und Layouts geändert werden, wobei **Aspose.Slides for Node.js via Java** verwendet wird.

## **SmartArt hinzufügen**

Fügen Sie eine SmartArt‑Grafik mit einem der integrierten Layouts ein.

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

## **SmartArt abrufen**

Rufen Sie das erste SmartArt‑Objekt auf einer Folie ab.

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

## **SmartArt entfernen**

Löschen Sie eine SmartArt‑Form von der Folie.

```js
function removeSmartArt() {
    let presentation = new aspose.slides.Presentation("smartart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Angenommen, die erste Form ist SmartArt.
        let smartArt = slide.getShapes().get_Item(0);

        slide.getShapes().remove(smartArt);

        presentation.save("smartart_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **SmartArt‑Layout ändern**

Aktualisieren Sie den Layouttyp einer vorhandenen SmartArt‑Grafik.

```js
function changeSmartArtLayout() {
    let presentation = new aspose.slides.Presentation("smartart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Angenommen, die erste Form ist SmartArt.
        let smartArt = slide.getShapes().get_Item(0);

        smartArt.setLayout(aspose.slides.SmartArtLayoutType.VerticalPictureList);

        presentation.save("smartart_layout_changed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```