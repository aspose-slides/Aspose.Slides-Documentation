---
title: Tinte
type: docs
weight: 180
url: /de/nodejs-java/examples/elements/ink/
keywords:
- Codebeispiel
- Tinte
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Arbeiten Sie mit Tinte in Aspose.Slides für Node.js: Striche zeichnen, importieren und bearbeiten, Farbe und Breite anpassen und mit Beispielen nach PPT, PPTX und ODP exportieren."
---
Dieser Artikel enthält Beispiele für den Zugriff auf vorhandene Ink‑Formen und deren Entfernung mit **Aspose.Slides for Node.js via Java**.

> ❗ **Hinweis:** Ink‑Formen stellen die Benutzereingabe von speziellen Geräten dar. Aspose.Slides kann keine neuen Ink‑Striche programmgesteuert erstellen, aber Sie können vorhandene Ink‑Daten lesen und ändern.

## **Ink‑Zugriff**

Rufen Sie die erste Ink‑Form auf einer Folie ab.

```js
function accessInk() {
    let presentation = new aspose.slides.Presentation("ink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let inkShape = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IInk")) {
                inkShape = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Ink entfernen**

Löschen Sie eine Ink‑Form von der Folie.

```js
function removeInk() {
    let presentation = new aspose.slides.Presentation("ink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Angenommen, die Ink-Form ist das erste Shape auf der Folie.
        slide.getShapes().removeAt(0);

        presentation.save("ink_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```