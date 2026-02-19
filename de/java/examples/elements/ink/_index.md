---
title: Ink
type: docs
weight: 180
url: /de/java/examples/elements/ink/
keywords:
- Codebeispiel
- Ink
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Arbeiten Sie mit Ink in Aspose.Slides für Java: Zeichnen, Importieren und Bearbeiten von Strichen, Anpassen von Farbe und Breite und Exportieren nach PPT, PPTX und ODP mit Java-Beispielen."
---
Dieser Artikel enthält Beispiele für den Zugriff auf vorhandene Ink-Formen und deren Entfernen mithilfe von **Aspose.Slides for Java**.

> ❗ **Hinweis:** Ink-Formen stellen Benutzereingaben von spezialisierten Geräten dar. Aspose.Slides kann neue Ink-Striche nicht programmgesteuert erstellen, aber Sie können bestehende Ink-Daten lesen und ändern.

## **Ink abrufen**

Lese die Tags der ersten Ink-Form auf einer Folie.

```java
static void accessInk() {
    Presentation presentation = new Presentation("ink.pptx");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IShape shape = slide.getShapes().get_Item(0);
        if (shape instanceof IInk) {
            IInk inkShape = (IInk) shape;
            ITagCollection tags = inkShape.getCustomData().getTags();
            if (tags.size() > 0) {
                String tagName = tags.getNameByIndex(0);
                // Verwenden Sie tagName nach Bedarf.
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Ink entfernen**

Lösche eine Ink-Form von der Folie, falls sie existiert.

```java
static void removeInk() {
    Presentation presentation = new Presentation("ink.pptx");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IInk ink = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IInk) {
                ink = (IInk) shape;
                break;
            }
        }
        if (ink != null) {
            slide.getShapes().remove(ink);
        }
    } finally {
        presentation.dispose();
    }
}
```