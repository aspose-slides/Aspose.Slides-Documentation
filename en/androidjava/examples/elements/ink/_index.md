---
title: Ink
type: docs
weight: 180
url: /androidjava/examples/elements/ink/
keywords:
- code example
- ink
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Work with Ink in Aspose.Slides for Android: draw, import, and edit strokes, adjust color and width, and export to PPT, PPTX, and ODP using Java examples."
---

This article provides examples of accessing existing ink shapes and removing them using **Aspose.Slides for Android via Java**.

> ❗ **Note:** Ink shapes represent user input from specialized devices. Aspose.Slides cannot create new ink strokes programmatically, but you can read and modify existing ink.

## **Access Ink**

Read the tags from the first ink shape on a slide.

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
                // Use tagName as needed.
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Remove Ink**

Delete an ink shape from the slide if one exists.

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
