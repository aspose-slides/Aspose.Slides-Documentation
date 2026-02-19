---
title: Gruppenform
type: docs
weight: 170
url: /de/nodejs-java/examples/elements/group-shape/
keywords:
- Codebeispiel
- Gruppenform
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Verwalten von gruppierten Formen in Aspose.Slides für Node.js: Erstellen, Verschachteln, Ausrichten, Neuordnen und Stylen von Gruppenformen mit Beispielen in PPT-, PPTX- und ODP-Präsentationen."
---
Beispiele für das Erstellen von Gruppen von Formen, den Zugriff darauf, das Aufheben von Gruppierungen und das Entfernen mit **Aspose.Slides für Node.js via Java**.

## **Gruppe hinzufügen**

Erstellen Sie eine Gruppe, die zwei Grundformen enthält.

```js
function addGroupShape() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let group = slide.getShapes().addGroupShape();
        group.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 50, 50);
        group.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 60, 0, 50, 50);

        presentation.save("group_shape.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Zugriff auf ein Gruppen‑Shape**

Rufen Sie das erste Gruppen‑Shape von einer Folie ab.

```js
function accessGroupShape() {
    let presentation = new aspose.slides.Presentation("group_shape.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let firstGroup = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IGroupShape")) {
                firstGroup = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Entfernen einer Gruppe**

Löschen Sie ein Gruppen‑Shape von der Folie.

```js
function removeGroupShape() {
    let presentation = new aspose.slides.Presentation("group_shape.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Angenommen, die erste Form ist ein Gruppen-Shape.
        slide.getShapes().removeAt(0);

        presentation.save("group_shape_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Gruppierung aufheben**

Verschieben Sie Formen aus einem Gruppencontainer heraus.

```js
function ungroupShapes() {
    let presentation = new aspose.slides.Presentation("group_shape.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Angenommen, die erste Form ist ein Gruppen-Shape.
        let group = slide.getShapes().get_Item(0);

        for (let i = 0; i < group.getShapes().size(); i++) {
            let shape = group.getShapes().get_Item(i);
            // Klone jede Form aus der Gruppe auf die Folie.
            slide.getShapes().addClone(shape);
        }

        slide.getShapes().remove(group);

        presentation.save("group_shape_ungrouped.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```