---
title: Tintavonal
type: docs
weight: 180
url: /hu/java/examples/elements/ink/
keywords:
- kódpélda
- tinta
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Munka a tintával az Aspose.Slides for Java-ban: vonalak rajzolása, importálása és szerkesztése, szín és szélesség beállítása, valamint PPT, PPTX és ODP formátumba exportálása Java példákkal."
---
Ez a cikk példákat mutat be a meglévő tintavonalak elérésére és eltávolítására az **Aspose.Slides for Java** használatával.

> ❗ **Megjegyzés:** A tintavonalak a speciális eszközök felhasználói bemenetét képviselik. Az Aspose.Slides nem képes programozott módon új tintavonalakat létrehozni, de meglévő tintákat olvashat és módosíthat.

## **Tintavonalak elérése**

Olvassa be a címkéket az első tintavonal alakzatról egy dián.

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
                // Használja a tagName-et szükség szerint.
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Tintavonalak eltávolítása**

Törölje a tintavonal alakzatot a diáról, ha létezik.

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