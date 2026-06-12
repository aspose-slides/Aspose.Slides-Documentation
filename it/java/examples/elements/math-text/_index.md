---
title: Testo matematico
type: docs
weight: 160
url: /it/java/examples/elements/math-text/
keywords:
- esempio di codice
- testo matematico
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Esplora gli esempi di MathematicalText di Aspose.Slides per Java: crea e formatta equazioni, frazioni, matrici e simboli con Java in presentazioni PPT, PPTX e ODP."
---
Questo articolo dimostra come lavorare con forme di testo matematico e formattare le equazioni usando **Aspose.Slides for Java**.

## **Aggiungi testo matematico**

Crea una forma matematica contenente una frazione e la formula pitagorica.

```java
static void addMathText() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Aggiungi una forma Math alla diapositiva.
        IAutoShape mathShape = slide.getShapes().addMathShape(0, 0, 720, 150);

        // Accedi al paragrafo matematico.
        IParagraph paragraph = mathShape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        IMathParagraph mathParagraph = ((MathPortion) textPortion).getMathParagraph();

        // Aggiungi una frazione semplice: x / y.
        IMathElement fraction = new MathematicalText("x").divide("y");
        mathParagraph.add(new MathBlock(fraction));

        // Aggiungi l'equazione: c² = a² + b².
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

## **Accedi al testo matematico**

Individua una forma che contiene un paragrafo matematico nella diapositiva.

```java
static void accessMathText() {
    Presentation presentation = new Presentation("sample.pptx");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Trova la prima forma che contiene un paragrafo matematico.
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

            // Esempio: crea una frazione (non aggiunta qui).
            IMathElement fraction = new MathematicalText("x").divide("y");

            // Usa mathParagraph o fraction come necessario...
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Rimuovi testo matematico**

Elimina una forma matematica dalla diapositiva.

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

        // Rimuovi la forma matematica.
        slide.getShapes().remove(mathShape);
    } finally {
        presentation.dispose();
    }
}
```

## **Formatta testo matematico**

Imposta le proprietà del carattere per una porzione matematica.

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