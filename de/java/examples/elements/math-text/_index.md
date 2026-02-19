---
title: Mathe-Text
type: docs
weight: 160
url: /de/java/examples/elements/math-text/
keywords:
- Codebeispiel
- mathematischer Text
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Entdecken Sie Beispiele für MathematicalText mit Aspose.Slides für Java: Erstellen und formatieren Sie Gleichungen, Brüche, Matrizen und Symbole mit Java in PPT-, PPTX- und ODP-Präsentationen."
---
Dieser Artikel demonstriert die Arbeit mit mathematischen Textformen und die Formatierung von Gleichungen mit **Aspose.Slides for Java**.

## **Mathe-Text hinzufügen**

Erstellen Sie eine mathematische Form, die einen Bruch und die pythagoreische Formel enthält.

```java
static void addMathText() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Fügt eine Mathematikform zur Folie hinzu.
        IAutoShape mathShape = slide.getShapes().addMathShape(0, 0, 720, 150);

        // Greift auf den Mathematikabsatz zu.
        IParagraph paragraph = mathShape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        IMathParagraph mathParagraph = ((MathPortion) textPortion).getMathParagraph();

        // Fügt einen einfachen Bruch hinzu: x / y.
        IMathElement fraction = new MathematicalText("x").divide("y");
        mathParagraph.add(new MathBlock(fraction));

        // Fügt Gleichung hinzu: c² = a² + b².
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

## **Zugriff auf Mathe-Text**

Suchen Sie eine Form, die einen mathematischen Absatz auf der Folie enthält.

```java
static void accessMathText() {
    Presentation presentation = new Presentation("sample.pptx");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Finde die erste Form, die einen Mathematikabsatz enthält.
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

            // Beispiel: Erstelle einen Bruch (hier nicht hinzugefügt).
            IMathElement fraction = new MathematicalText("x").divide("y");

            // Verwende mathParagraph oder fraction nach Bedarf...
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Mathe-Text entfernen**

Löschen Sie eine mathematische Form von der Folie.

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

        // Entferne die Mathematikform.
        slide.getShapes().remove(mathShape);
    } finally {
        presentation.dispose();
    }
}
```

## **Mathe-Text formatieren**

Legen Sie die Schriftarteigenschaften für einen mathematischen Teil fest.

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