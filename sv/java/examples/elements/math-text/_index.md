---
title: Matematisk text
type: docs
weight: 160
url: /sv/java/examples/elements/math-text/
keywords:
- kodexempel
- matematisk text
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Utforska Aspose.Slides för Java MathematicalText-exempel: skapa och formatera ekvationer, bråk, matriser och symboler med Java i PPT-, PPTX- och ODP-presentationer."
---
Den här artikeln visar hur du arbetar med matematiska textformer och formaterar ekvationer med **Aspose.Slides for Java**.

## **Lägg till matematisk text**

Skapa en matematisk form som innehåller en bråkdel och Pythagoras formel.

```java
static void addMathText() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Lägg till en matematisk form på bilden.
        IAutoShape mathShape = slide.getShapes().addMathShape(0, 0, 720, 150);

        // Åtkomst till det matematiska stycket.
        IParagraph paragraph = mathShape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        IMathParagraph mathParagraph = ((MathPortion) textPortion).getMathParagraph();

        // Lägg till ett enkelt bråk: x / y.
        IMathElement fraction = new MathematicalText("x").divide("y");
        mathParagraph.add(new MathBlock(fraction));

        // Lägg till ekvation: c² = a² + b².
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

## **Åtkomst till matematisk text**

Hitta en form som innehåller ett matematiskt stycke på bilden.

```java
static void accessMathText() {
    Presentation presentation = new Presentation("sample.pptx");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Hitta den första formen som innehåller ett matematiskt stycke.
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

            // Exempel: skapa ett bråk (ej tillagt här).
            IMathElement fraction = new MathematicalText("x").divide("y");

            // Använd mathParagraph eller fraction vid behov...
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Ta bort matematisk text**

Ta bort en matematisk form från bilden.

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

        // Ta bort den matematiska formen.
        slide.getShapes().remove(mathShape);
    } finally {
        presentation.dispose();
    }
}
```

## **Formatera matematisk text**

Ange teckensnittsegenskaper för en matematisk del.

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