---
title: Inkt
type: docs
weight: 180
url: /nl/androidjava/examples/elements/ink/
keywords:
- codevoorbeeld
- inkt
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Werk met Inkt in Aspose.Slides voor Android: teken, importeer en bewerk streken, pas kleur en breedte aan, en exporteer naar PPT, PPTX en ODP met Java-voorbeelden."
---
Dit artikel geeft voorbeelden van het benaderen van bestaande inktvormen en het verwijderen ervan met **Aspose.Slides for Android via Java**.

> ❗ **Opmerking:** Inktvormen vertegenwoordigen gebruikersinvoer van gespecialiseerde apparaten. Aspose.Slides kan geen nieuwe inktstreken programmatically aanmaken, maar je kunt bestaande inkt lezen en aanpassen.

## **Access Ink**
## **Toegang tot inkt**

Lees de tags van de eerste inktvorm op een dia.

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
                // Gebruik tagName indien nodig.
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Remove Ink**
## **Inkt verwijderen**

Verwijder een inktvorm van de dia als deze bestaat.

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