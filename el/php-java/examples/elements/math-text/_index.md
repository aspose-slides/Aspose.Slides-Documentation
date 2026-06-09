---
title: Κείμενο Μαθηματικών
type: docs
weight: 160
url: /el/php-java/examples/elements/math-text/
keywords:
- μαθηματικό κείμενο
- προσθήκη μαθηματικού κειμένου
- πρόσβαση σε μαθηματικό κείμενο
- αφαίρεση μαθηματικού κειμένου
- μορφοποίηση μαθηματικού κειμένου
- παραδείγματα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Εργαστείτε με μαθηματικό κείμενο σε PHP χρησιμοποιώντας Aspose.Slides: δημιουργήστε και επεξεργαστείτε εξισώσεις, κλάσματα, ριζικά, δείκτες, μορφοποίηση και αποδώστε τα αποτελέσματα για PPT και PPTX."
---
Δείχνει τη χρήση σχήματος μαθηματικού κειμένου και τη μορφοποίηση εξισώσεων χρησιμοποιώντας **Aspose.Slides for PHP via Java**.

## **Προσθήκη Μαθηματικού Κειμένου**

Δημιουργήστε ένα μαθηματικό σχήμα που περιλαμβάνει ένα κλάσμα και τον Πυθαγόρειο τύπο.

```php
function addMathText() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Προσθήκη σχήματος μαθηματικού κειμένου στη διαφάνεια.
        $mathShape = $slide->getShapes()->addMathShape(0, 0, 720, 150);

        // Πρόσβαση στην μαθηματική παράγραφο.
        $paragraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $mathParagraph = $portion->getMathParagraph();

        // Προσθήκη απλού κλάσματος: x / y.
        $fraction = (new MathematicalText("x"))->divide("y");
        $mathParagraph->add(new MathBlock($fraction));

        // Προσθήκη εξίσωσης: c² = a² + b².
        $mathBlock = (new MathematicalText("c"))
            - >setSuperscript("2")
            - >join("=")
            - >join((new MathematicalText("a"))->setSuperscript("2"))
            - >join("+")
            - >join((new MathematicalText("b"))->setSuperscript("2"));
        $mathParagraph->add($mathBlock);

        $presentation->save("math_text.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Πρόσβαση σε Μαθηματικό Κείμενο**

Βρείτε ένα σχήμα που περιέχει μια μαθηματική παράγραφο στη διαφάνεια.

```php
function accessMathText() {
    $presentation = new Presentation("math_text.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Βρείτε το πρώτο σχήμα που περιέχει μια μαθηματική παράγραφο.
        $mathShape = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $textFrame = $shape->getTextFrame();
                if ($textFrame !== null) {
                    $paragraphCount = java_values($textFrame->getParagraphs()->getCount());
                    for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
                        $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
                        $portionCount = java_values($paragraph->getPortions()->getCount());
                        for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
                            $portion = $paragraph->getPortions()->get_Item($portionIndex);
                            if (java_instanceof($portion, new JavaClass("com.aspose.slides.MathPortion"))) {
                                $mathShape = $shape;
                                break 3;
                            }
                        }
                    }
                }
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Αφαίρεση Μαθηματικού Κειμένου**

Διαγράψτε ένα μαθηματικό σχήμα από τη διαφάνεια.

```php
function removeMathText() {
    $presentation = new Presentation("math_text.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Υποθέτουμε ότι το πρώτο σχήμα στη διαφάνεια είναι σχήμα μαθηματικού κειμένου.
        $mathShape = $slide->getShapes()->get_Item(0);

        // Αφαίρεση του σχήματος μαθηματικού κειμένου από τη διαφάνεια.
        $slide->getShapes()->remove($mathShape);

        $presentation->save("math_text_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Διαμόρφωση Μαθηματικού Κειμένου**

Ορίστε τις ιδιότητες της γραμματοσειράς για ένα μαθηματικό τμήμα.

```php
function formatMathText() {
    $presentation = new Presentation("math_text.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Υποθέτοντας ότι το πρώτο σχήμα στη διαφάνεια είναι σχήμα μαθηματικού κειμένου.
        $mathShape = $slide->getShapes()->get_Item(0);

        $paragraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $portion->getPortionFormat()->setFontHeight(20);

        $presentation->save("math_text_formatted.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```