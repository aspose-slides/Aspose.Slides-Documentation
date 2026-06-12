---
title: Matematický text
type: docs
weight: 160
url: /cs/java/examples/elements/math-text/
keywords:
- příklad kódu
- matematický text
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Prozkoumejte příklady MathematicalText v Aspose.Slides pro Java: vytvářejte a formátujte rovnice, zlomky, matice a symboly v Javě v prezentacích PPT, PPTX a ODP."
---
Tento článek ukazuje práci s matematickými textovými tvary a formátování rovnic pomocí **Aspose.Slides for Java**.

## **Přidat matematický text**

Vytvořte matematický tvar obsahující zlomek a Pythagorovu formuli.

```java
static void addMathText() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Přidejte matematický tvar na snímek.
        IAutoShape mathShape = slide.getShapes().addMathShape(0, 0, 720, 150);

        // Získejte přístup k matematickému odstavci.
        IParagraph paragraph = mathShape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        IMathParagraph mathParagraph = ((MathPortion) textPortion).getMathParagraph();

        // Přidejte jednoduchý zlomek: x / y.
        IMathElement fraction = new MathematicalText("x").divide("y");
        mathParagraph.add(new MathBlock(fraction));

        // Přidejte rovnici: c² = a² + b².
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

## **Přístup k matematickému textu**

Najděte tvar, který obsahuje matematický odstavec na snímku.

```java
static void accessMathText() {
    Presentation presentation = new Presentation("sample.pptx");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Najděte první tvar, který obsahuje matematický odstavec.
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

            // Příklad: vytvořit zlomek (nepřidáno zde).
            IMathElement fraction = new MathematicalText("x").divide("y");

            // Use mathParagraph or fraction as needed...
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Odstranit matematický text**

Odstraňte matematický tvar ze snímku.

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

        // Odstraňte matematický tvar.
        slide.getShapes().remove(mathShape);
    } finally {
        presentation.dispose();
    }
}
```

## **Formátovat matematický text**

Nastavte vlastnosti písma pro matematickou část.

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