---
title: Bläck
type: docs
weight: 180
url: /sv/java/examples/elements/ink/
keywords:
- kodexempel
- bläck
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Arbeta med bläck i Aspose.Slides för Java: rita, importera och redigera streck, justera färg och bredd samt exportera till PPT, PPTX och ODP med Java-exempel."
---
Den här artikeln ger exempel på hur man får åtkomst till befintliga bläckformer och tar bort dem med **Aspose.Slides for Java**.

> ❗ **Obs:** Bläckformer representerar användarinmatning från specialiserade enheter. Aspose.Slides kan inte skapa nya bläckstreck programatiskt, men du kan läsa och ändra befintligt bläck.

## **Åtkomst till bläck**
Läs taggarna från den första bläckformen på en bild.

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
                // Använd tagName vid behov.
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Ta bort bläck**
Ta bort en bläckform från bilden om den finns.

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