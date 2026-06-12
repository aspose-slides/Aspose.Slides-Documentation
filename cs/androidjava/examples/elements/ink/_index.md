---
title: Ink
type: docs
weight: 180
url: /cs/androidjava/examples/elements/ink/
keywords:
- ukázka kódu
- ink
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Pracujte s inkem v Aspose.Slides pro Android: kreslete, importujte a upravujte tahy, nastavujte barvu a šířku a exportujte do PPT, PPTX a ODP pomocí ukázek v Javě."
---
Tento článek poskytuje příklady, jak přistupovat k existujícím inkovým tvarům a odstraňovat je pomocí **Aspose.Slides for Android via Java**.

> ❗ **Poznámka:** Inkové tvary představují vstup uživatele ze specializovaných zařízení. Aspose.Slides nemůže programově vytvářet nové inkové tahy, ale můžete číst a upravovat stávající ink.

## **Přístup k inku**

Přečtěte značky z prvního inkového tvaru na snímku.

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
                // Použijte tagName podle potřeby.
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Odstranit ink**

Odstraňte inkový tvar ze snímku, pokud existuje.

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