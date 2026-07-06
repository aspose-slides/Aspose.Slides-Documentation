---
title: Λήψη ορίων παραγράφου από παρουσιάσεις σε PHP
linktitle: Όρια παραγράφου
type: docs
weight: 43
url: /el/php-java/paragraph-bounds/
keywords:
- όρια παραγράφου
- συντεταγμένη παραγράφου
- μέγεθος παραγράφου
- πλαίσιο κειμένου
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Μάθετε πώς να ανακτήσετε τα όρια παραγράφου στο Aspose.Slides για PHP μέσω Java για να βελτιστοποιήσετε τη θέση του κειμένου σε παρουσιάσεις PowerPoint."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να λαμβάνετε τα όρια, το μέγεθος και τις συντεταγμένες των παραγράφων στο Aspose.Slides. Δείχνει πώς να ανακτήσετε ένα ορθογώνιο παραγράφου από ένα [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/) χρησιμοποιώντας τη μέθοδο [Paragraph::getRect](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraph/getrect/), πώς να λάβετε τις συντεταγμένες της παραγράφου μέσα σε ένα TextFrame κελιού πίνακα, και επισημαίνει σημαντικές λεπτομέρειες όπως οι μονάδες μέτρησης, η επίδραση της αναδίπλωσης κειμένου στα όρια, η μετατροπή σε pixel και οι τιμές αποτελεσματικής μορφοποίησης παραγράφου.

## **Λήψη ορθογώνιων συντεταγμένων παραγράφου**

Χρησιμοποιήστε τη μέθοδο [Paragraph::getRect](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraph/getrect/) για να λάβετε το ορθογώνιο που περιβάλλει μια παράγραφο.

```php
$presentation = new Presentation("Shapes.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $rectangle = $paragraph->getRect();
} finally {
    $presentation->dispose();
}
```

## **Λήψη του μεγέθους μιας παραγράφου μέσα σε TextFrame κελιού πίνακα**

Για να λάβετε το μέγεθος και τις συντεταγμένες ενός [Paragraph](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraph/) σε ένα TextFrame κελιού πίνακα, χρησιμοποιήστε τη μέθοδο [Paragraph::getRect](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraph/getrect/). Το επιστρεφόμενο ορθογώνιο είναι σχετικό με το TextFrame του κελιού πίνακα, επομένως προσθέστε τη θέση του πίνακα και την απόκλιση του κελιού όταν χρειάζεστε συντεταγμένες επιπέδου διαφάνειας.

Το παρακάτω παράδειγμα λαμβάνει τα όρια της παραγράφου μέσα σε κελί πίνακα και σχεδιάζει ορθογώνια στη διαφάνεια για να οπτικοποιήσει αυτά τα όρια:

```php
$presentation = new Presentation("source.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);
    $cell = $table->getRows()->get_Item(1)->get_Item(1);

    $cellX = java_values($table->getX()) + java_values($cell->getOffsetX());
    $cellY = java_values($table->getY()) + java_values($cell->getOffsetY());

    foreach ($cell->getTextFrame()->getParagraphs() as $paragraph) {
        if ($paragraph->getText() == "") {
            continue;
        }

        $paragraphRectangle = $paragraph->getRect();
        $paragraphRectangleX = java_values($paragraphRectangle->getX()) + $cellX;
        $paragraphRectangleY = java_values($paragraphRectangle->getY()) + $cellY;
        $paragraphRectangleWidth = java_values($paragraphRectangle->getWidth());
        $paragraphRectangleHeight = java_values($paragraphRectangle->getHeight());

        $paragraphBoundsShape = $slide->getShapes()->addAutoShape(
            ShapeType::Rectangle,
            $paragraphRectangleX,
            $paragraphRectangleY,
            $paragraphRectangleWidth,
            $paragraphRectangleHeight
        );

        $paragraphBoundsShape->getFillFormat()->setFillType(FillType::NoFill);
        $paragraphBoundsShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
        $paragraphBoundsShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Συχνές ερωτήσεις**

**Σε ποιες μονάδες μετρώνται οι συντεταγμένες της παραγράφου;**

Μετρώνται σε σημεία (points), όπου 1 ίντσα ισούται με 72 σημεία. Αυτό ισχύει για όλες τις συντεταγμένες και διαστάσεις στη διαφάνεια.

**Επηρεάζει η αναδίπλωση κειμένου τα όρια μιας παραγράφου;**

Ναι. Εάν η μέθοδος [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframeformat/setwraptext/) είναι ενεργοποιημένη για το [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/), το κείμενο σπάει ώστε να ταιριάζει με το πλάτος της περιοχής, κάτι που αλλάζει τα πραγματικά όρια της παραγράφου.

**Μπορούν οι συντεταγμένες της παραγράφου να αντιστοιχιστούν αξιόπιστα σε pixel στην εξαγόμενη εικόνα;**

Ναι. Μετατρέψτε τα σημεία σε pixel χρησιμοποιώντας τον τύπο: pixels = points × (DPI / 72). Το αποτέλεσμα εξαρτάται από το DPI που έχει επιλεγεί για την απόδοση ή την εξαγωγή.

**Πώς λαμβάνω τις «αποτελεσματικές» παραμέτρους μορφοποίησης παραγράφου, λαμβάνοντας υπόψη την κληρονομικότητα στυλ;**

Χρησιμοποιήστε τη [data structure αποτελεσματικής μορφοποίησης παραγράφου](/slides/el/php-java/shape-effective-properties/). Επιστρέφει τις τελικές ενοποιημένες τιμές για εσοχές, απόσταση, αναδίπλωση, RTL και άλλα.