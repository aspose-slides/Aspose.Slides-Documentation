---
title: Tinták
type: docs
weight: 180
url: /hu/androidjava/examples/elements/ink/
keywords:
- kódrészlet
- tinta
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Munka a tintával az Aspose.Slides for Android-ban: rajzolás, importálás és vonalak szerkesztése, szín és szélesség beállítása, valamint export PPT, PPTX és ODP formátumba Java példákkal."
---
Ez a cikk példákat mutat be a meglévő tintaalakzatok elérésére és eltávolítására a **Aspose.Slides for Android via Java** használatával.

> ❗ **Megjegyzés:** A tintaalakzatok a speciális eszközök által rögzített felhasználói bemenetet képviselik. Az Aspose.Slides programozottan nem tud új tintavonalakat létrehozni, de a meglévő tintát be tudja olvasni és módosítani.

## **Tintához való hozzáférés**

Olvassa ki a címkéket a dián lévő első tintaalakzatról.

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

## **Tinták eltávolítása**

Távolítson el egy tintaalakzatot a diáról, ha létezik.

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