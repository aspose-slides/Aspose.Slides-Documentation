---
title: Μαθηματικό Κείμενο
type: docs
weight: 160
url: /el/androidjava/examples/elements/math-text/
keywords:
- παράδειγμα κώδικα
- μαθηματικό κείμενο
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Εξερευνήστε παραδείγματα MathematicalText του Aspose.Slides για Android: δημιουργήστε και μορφοποιήστε εξισώσεις, κλάσματα, μήτρες και σύμβολα με Java σε παρουσιάσεις PPT, PPTX και ODP."
---
Αυτό το άρθρο δείχνει πώς να εργάζεστε με σχήματα μαθηματικού κειμένου και να μορφοποιείτε εξισώσεις χρησιμοποιώντας **Aspose.Slides for Android via Java**.

## **Προσθήκη Μαθηματικού Κειμένου**

Δημιουργήστε ένα μαθηματικό σχήμα που περιέχει ένα κλάσμα και τον Πυθαγόρειο τύπο.

```java
static void addMathText() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Προσθήκη σχήματος μαθηματικού κειμένου στη διαφάνεια.
        IAutoShape mathShape = slide.getShapes().addMathShape(0, 0, 720, 150);

        // Πρόσβαση στην μαθηματική παράγραφο.
        IParagraph paragraph = mathShape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        IMathParagraph mathParagraph = ((MathPortion) textPortion).getMathParagraph();

        // Προσθήκη απλού κλάσματος: x / y.
        IMathElement fraction = new MathematicalText("x").divide("y");
        mathParagraph.add(new MathBlock(fraction));

        // Προσθήκη εξίσωσης: c² = a² + b².
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

## **Πρόσβαση Μαθηματικού Κειμένου**

Εντοπίστε ένα σχήμα που περιέχει μια μαθηματική παράγραφο στη διαφάνεια.

```java
static void accessMathText() {
    Presentation presentation = new Presentation("sample.pptx");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Βρείτε το πρώτο σχήμα που περιέχει μια μαθηματική παράγραφο.
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

            // Παράδειγμα: δημιουργία κλάσματος (δεν προστέθηκε εδώ).
            IMathElement fraction = new MathematicalText("x").divide("y");

            // Use mathParagraph or fraction as needed...
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Αφαίρεση Μαθηματικού Κειμένου**

Διαγράψτε ένα μαθηματικό σχήμα από τη διαφάνεια.

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

        // Αφαίρεση του μαθηματικού σχήματος.
        slide.getShapes().remove(mathShape);
    } finally {
        presentation.dispose();
    }
}
```

## **Μορφοποίηση Μαθηματικού Κειμένου**

Ορίστε ιδιότητες γραμματοσειράς για ένα μαθηματικό τμήμα.

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