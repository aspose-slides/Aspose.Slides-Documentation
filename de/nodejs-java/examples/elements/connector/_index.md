---
title: Verbinder
type: docs
weight: 190
url: /de/nodejs-java/examples/elements/connector/
keywords:
- Codebeispiel
- Verbinder
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Erfahren Sie, wie Sie mit Aspose.Slides für Node.js Verbinder zwischen Formen hinzufügen, routen und formatieren, mit JavaScript-Beispielen für PPT-, PPTX- und ODP-Präsentationen."
---
Dieser Artikel demonstriert, wie Sie Formen mit Verbindern verbinden und deren Ziele mithilfe von **Aspose.Slides for Node.js via Java** ändern.

## **Einen Verbinder hinzufügen**

Fügen Sie ein Verbinder‑Shape zwischen zwei Punkten auf der Folie ein.

```js
function addConnector() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 100, 100);

        presentation.save("connector.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Auf einen Verbinder zugreifen**

Rufen Sie das erste zur Folie hinzugefügte Verbinder‑Shape ab.

```js
function accessConnector() {
    let presentation = new aspose.slides.Presentation("connector.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Greifen Sie auf den ersten Verbinder auf der Folie zu.
        let connector = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IConnector")) {
                connector = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Einen Verbinder entfernen**

Löschen Sie einen Verbinder von der Folie.

```js
function removeConnector() {
    let presentation = new aspose.slides.Presentation("connector.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Gehen Sie davon aus, dass das erste Shape ein Verbinder ist und entfernen Sie es.
        slide.getShapes().removeAt(0);

        presentation.save("connector_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Formen erneut verbinden**

Verbinden Sie einen Verbinder mit zwei Formen, indem Sie Start‑ und Endziele zuweisen.

```js
function reconnectShapes() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 50, 50);
        let shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 50, 50);

        let connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 100, 100);

        connector.setStartShapeConnectedTo(shape1);
        connector.setEndShapeConnectedTo(shape2);
    } finally {
        presentation.dispose();
    }
}
```