---
title: Tinte
type: docs
weight: 180
url: /de/androidjava/examples/elements/ink/
keywords:
- Codebeispiel
- Tinte
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Arbeiten Sie mit Tinte in Aspose.Slides für Android: Zeichnen, importieren und bearbeiten Sie Striche, passen Sie Farbe und Breite an und exportieren Sie mithilfe von Java-Beispielen nach PPT, PPTX und ODP."
---
Dieser Artikel enthält Beispiele für den Zugriff auf vorhandene Ink-Formen und deren Entfernen mit **Aspose.Slides für Android via Java**.

> ❗ **Hinweis:** Ink-Formen stellen Benutzereingaben von spezialisierten Geräten dar. Aspose.Slides kann keine neuen Ink-Striche programmgesteuert erstellen, aber Sie können vorhandene Ink-Daten lesen und ändern.

## **Zugriff auf Ink**

Lesen Sie die Tags der ersten Ink-Form auf einer Folie.

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

Löschen Sie eine Ink-Form von der Folie, falls eine vorhanden ist.

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