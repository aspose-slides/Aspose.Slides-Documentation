---
title: Matematikai szöveg
type: docs
weight: 160
url: /hu/java/examples/elements/math-text/
keywords:
- kód példa
- matematikai szöveg
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for Java MatematikaiSzöveg példákat: hozzon létre és formázzon egyenleteket, törtöket, mátrixokat és szimbólumokat Java-val PPT, PPTX és ODP prezentációkban."
---
Ez a cikk bemutatja, hogyan lehet matematikai szövegformákat használni és egyenleteket formázni a **Aspose.Slides for Java** segítségével.

## **Matematikai szöveg hozzáadása**

Hozzon létre egy matematikai alakzatot, amely egy törtet és a Pithágorasz-formulát tartalmaz.

```java
static void addMathText() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Adjunk egy Math alakzatot a diára.
        IAutoShape mathShape = slide.getShapes().addMathShape(0, 0, 720, 150);

        // A matematikai bekezdés elérése.
        IParagraph paragraph = mathShape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        IMathParagraph mathParagraph = ((MathPortion) textPortion).getMathParagraph();

        // Egyszerű tört hozzáadása: x / y.
        IMathElement fraction = new MathematicalText("x").divide("y");
        mathParagraph.add(new MathBlock(fraction));

        // Egyenlet hozzáadása: c² = a² + b².
        IMathBlock mathBlock = new MathematicalText("c")
                .setSuperscript("2")
                .join("=")
                .join(new MathematicalText("a").setSuperscript("2"))
                .join("+")
                .join(new MathematicalText("b").setSuperscript("2"));
        mathParagraph.add(mathBlock);
    } finally {
        presentation.dispose();
    }
}
```

## **Matematikai szöveg elérése**

Keressen egy olyan alakzatot, amely a diáron egy matematikai bekezdést tartalmaz.

```java
static void accessMathText() {
    Presentation presentation = new Presentation("sample.pptx");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Keresse meg az első alakzatot, amely egy matematikai bekezdést tartalmaz.
        IAutoShape mathShape = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                ITextFrame textFrame = autoShape.getTextFrame();
                if (textFrame != null) {
                    boolean hasMath = false;
                    for (IParagraph paragraph : textFrame.getParagraphs()) {
                        for (IPortion portion : paragraph.getPortions()) {
                            if (portion instanceof MathPortion) {
                                hasMath = true;
                                break;
                            }
                        }
                        if (hasMath) break;
                    }
                    if (hasMath) {
                        mathShape = autoShape;
                        break;
                    }
                }
            }
        }

        if (mathShape != null) {
            IParagraph paragraph = mathShape.getTextFrame().getParagraphs().get_Item(0);
            IPortion textPortion = paragraph.getPortions().get_Item(0);
            IMathParagraph mathParagraph = ((MathPortion) textPortion).getMathParagraph();

            // Példa: tört létrehozása (itt nem kerül hozzáadásra).
            IMathElement fraction = new MathematicalText("x").divide("y");

            // Használja a mathParagraph-et vagy a törtet a szükség szerint...
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Matematikai szöveg eltávolítása**

Törölje a matematikai alakzatot a diáról.

```java
static void removeMathText() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape mathShape = slide.getShapes().addMathShape(50, 50, 100, 50);

        IParagraph paragraph = mathShape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        IMathParagraph mathParagraph = ((MathPortion) textPortion).getMathParagraph();
        IMathElement fraction = new MathematicalText("x").divide("y");
        mathParagraph.add(new MathBlock(fraction));

        // Távolítsa el a matematikai alakzatot.
        slide.getShapes().remove(mathShape);
    } finally {
        presentation.dispose();
    }
}
```

## **Matematikai szöveg formázása**

Állítsa be a betűtípus tulajdonságait egy matematikai részhez.

```java
static void formatMathText() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape mathShape = slide.getShapes().addMathShape(50, 50, 100, 50);
        IParagraph paragraph = mathShape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        IMathParagraph mathParagraph = ((MathPortion) textPortion).getMathParagraph();
        IMathElement fraction = new MathematicalText("x").divide("y");
        mathParagraph.add(new MathBlock(fraction));

        textPortion.getPortionFormat().setFontHeight(20);
    } finally {
        presentation.dispose();
    }
}
```