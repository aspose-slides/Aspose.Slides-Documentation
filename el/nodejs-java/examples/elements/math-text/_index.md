---
title: Μαθηματικό Κείμενο
type: docs
weight: 160
url: /el/nodejs-java/examples/elements/math-text/
keywords:
- παράδειγμα κώδικα
- μαθηματικό κείμενο
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Εξερευνήστε παραδείγματα MathematicalText του Aspose.Slides για Node.js: δημιουργήστε και μορφοποιήστε εξισώσεις, κλάσματα, πίνακες και σύμβολα σε παρουσιάσεις PPT, PPTX και ODP."
---
Αυτό το άρθρο δείχνει πώς να εργάζεστε με σχήματα κειμένου μαθηματικών και να μορφοποιείτε εξισώσεις χρησιμοποιώντας **Aspose.Slides for Node.js via Java**.

## **Προσθήκη Μαθηματικού Κειμένου**

Δημιουργήστε ένα μαθηματικό σχήμα που περιέχει ένα κλάσμα και τον Πυθαγόρειο τύπο.

```js
function addMathText() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Προσθήκη σχήματος μαθηματικών στη διαφάνεια.
        let mathShape = slide.getShapes().addMathShape(0, 0, 720, 150);

        // Πρόσβαση στην παράγραφο μαθηματικού κειμένου.
        let paragraph = mathShape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);
        let mathParagraph = textPortion.getMathParagraph();

        // Προσθήκη απλού κλάσματος: x / y.
        let fraction = new aspose.slides.MathematicalText("x").divide("y");
        mathParagraph.add(new aspose.slides.MathBlock(fraction));

        // Προσθήκη εξίσωσης: c² = a² + b².
        let mathBlock = new aspose.slides.MathematicalText("c")
                .setSuperscript("2")
                .join("=")
                .join(new aspose.slides.MathematicalText("a").setSuperscript("2"))
                .join("+")
                .join(new aspose.slides.MathematicalText("b").setSuperscript("2"));
        mathParagraph.add(mathBlock);

        presentation.save("math_text.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Πρόσβαση σε Μαθηματικό Κείμενο**

Εντοπίστε ένα σχήμα που περιέχει μια μαθηματική παράγραφο στη διαφάνεια.

```js
function accessMathText() {
    let presentation = new aspose.slides.Presentation("math_text.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Βρείτε το πρώτο σχήμα που περιέχει παράγραφο μαθηματικού κειμένου.
        let mathShape = null;
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            let shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                let autoShape = shape;
                let textFrame = autoShape.getTextFrame();
                if (textFrame != null) {
                    let hasMath = false;
                    for (let paragraphIndex = 0; paragraphIndex < textFrame.getParagraphs().getCount(); paragraphIndex++) {
                        let paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
                        for (let portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
                            let portion = paragraph.getPortions().get_Item(portionIndex);
                            if (java.instanceOf(portion, "com.aspose.slides.MathPortion")) {
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
            let paragraph = mathShape.getTextFrame().getParagraphs().get_Item(0);
            let textPortion = paragraph.getPortions().get_Item(0);
            let mathParagraph = textPortion.getMathParagraph();

            // ...
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Αφαίρεση Μαθηματικού Κειμένου**

Διαγράψτε ένα μαθηματικό σχήμα από τη διαφάνεια.

```js
function removeMathText() {
    let presentation = new aspose.slides.Presentation("math_text.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Υποθέτουμε ότι το πρώτο σχήμα είναι το σχήμα μαθηματικών.
        let mathShape = slide.getShapes().get_Item(0);

        // Αφαιρέστε το σχήμα μαθηματικών.
        slide.getShapes().remove(mathShape);

        presentation.save("math_text_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Μορφοποίηση Μαθηματικού Κειμένου**

Ορίστε τις ιδιότητες γραμματοσειράς για ένα μαθηματικό τμήμα.

```js
function formatMathText() {
    let presentation = new aspose.slides.Presentation("math_text.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Υποθέτουμε ότι το πρώτο σχήμα είναι το σχήμα μαθηματικών.
        let mathShape = slide.getShapes().get_Item(0);

        let paragraph = mathShape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        textPortion.getPortionFormat().setFontHeight(20);

        presentation.save("math_text_formatted.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```