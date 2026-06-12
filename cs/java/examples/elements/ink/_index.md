---
title: Ink
type: docs
weight: 180
url: /cs/java/examples/elements/ink/
keywords:
- příklad kódu
- ink
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Pracujte s Ink v Aspose.Slides pro Java: kreslete, importujte a upravujte tahy, upravujte barvu a šířku a exportujte do PPT, PPTX a ODP pomocí příkladů v Javě."
---
Tento článek poskytuje příklady, jak získat přístup k existujícím ink tvarům a jak je odstranit pomocí **Aspose.Slides for Java**.

> ❗ **Poznámka:** Ink tvary představují vstup uživatele ze specializovaných zařízení. Aspose.Slides nemůže programově vytvářet nové ink tahy, ale můžete číst a upravovat existující ink.

## **Přístup k ink**

Přečtěte značky z prvního ink tvaru na snímku.

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

## **Odstranění ink**

Odstraňte ink tvar ze snímku, pokud existuje.

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