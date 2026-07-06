---
title: Λήψη ορίων παραγράφου από παρουσιάσεις στο Android
linktitle: Όρια παραγράφου
type: docs
weight: 43
url: /el/androidjava/paragraph-bounds/
keywords:
- όρια παραγράφου
- συντεταγμένες παραγράφου
- μέγεθος παραγράφου
- πλαίσιο κειμένου
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Μάθετε πώς να ανακτήσετε τα όρια παραγράφου στο Aspose.Slides για Android μέσω Java για να βελτιστοποιήσετε τη θέση του κειμένου σε παρουσιάσεις PowerPoint."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να λάβετε τα όρια, το μέγεθος και τις συντεταγμένες παραγράφων στο Aspose.Slides. Δείχνει πώς να ανακτήσετε ένα ορθογώνιο παραγράφου από ένα [ITextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/) χρησιμοποιώντας το [IParagraph.getRect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IParagraph#getRect--), πώς να λάβετε τις συντεταγμένες παραγράφου μέσα σε ένα πλαίσιο κειμένου κελιού πίνακα, και υπογραμμίζει σημαντικές λεπτομέρειες όπως οι μονάδες μέτρησης, η επίδραση της αναδίπλωσης κειμένου στα όρια, η μετατροπή σε pixel και οι αποτελεσματικές τιμές μορφοποίησης παραγράφου.

## **Λήψη ορθογώνιων συντεταγμένων παραγράφου**

Χρησιμοποιήστε το [IParagraph.getRect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IParagraph#getRect--) για να λάβετε το ορθογώνιο πλαίσιο μιας παραγράφου.

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    android.graphics.RectF rectangle = paragraph.getRect();
} finally {
    presentation.dispose();
}
```

## **Λήψη του μεγέθους μιας παραγράφου μέσα σε πλαίσιο κειμένου κελιού πίνακα**

Για να λάβετε το μέγεθος και τις συντεταγμένες ενός [IParagraph](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraph/) σε πλαίσιο κειμένου κελιού πίνακα, χρησιμοποιήστε το [IParagraph.getRect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IParagraph#getRect--). Το επιστρεφόμενο ορθογώνιο είναι σχετικό με το πλαίσιο κειμένου του κελιού του πίνακα, οπότε προσθέστε τη θέση του πίνακα και τη μετατόπιση του κελιού όταν χρειάζεστε συντεταγμένες επιπέδου διαφάνειας.

Το παρακάτω παράδειγμα λαμβάνει τα όρια της παραγράφου μέσα σε κελί πίνακα και σχεδιάζει ορθογώνια στη διαφάνεια για να οπτικοποιήσει αυτά τα όρια:

```java
Presentation presentation = new Presentation("source.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);
    ICell cell = table.getRows().get_Item(1).get_Item(1);

    double cellX = table.getX() + cell.getOffsetX();
    double cellY = table.getY() + cell.getOffsetY();

    for (IParagraph paragraph : cell.getTextFrame().getParagraphs())
    {
        if (paragraph.getText().isEmpty())
            continue;

        android.graphics.RectF paragraphRectangle = paragraph.getRect();
        float paragraphRectangleX = paragraphRectangle.left + (float) cellX;
        float paragraphRectangleY = paragraphRectangle.top + (float) cellY;

        IAutoShape paragraphBoundsShape = slide.getShapes().addAutoShape(
                ShapeType.Rectangle,
                paragraphRectangleX,
                paragraphRectangleY,
                paragraphRectangle.width(),
                paragraphRectangle.height());

        paragraphBoundsShape.getFillFormat().setFillType(FillType.NoFill);
        paragraphBoundsShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
        paragraphBoundsShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Συχνές ερωτήσεις**

**Σε ποιες μονάδες μετρώνται οι συντεταγμένες της παραγράφου;**

Μετρώνται σε points, όπου 1 ίντσα ισούται με 72 points. Αυτό ισχύει για όλες τις συντεταγμένες και διαστάσεις στη διαφάνεια.

**Επηρεάζει η αναδίπλωση κειμένου τα όρια μιας παραγράφου;**

Ναι. Εάν η μέθοδος [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-) είναι ενεργοποιημένη για το [ITextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/), το κείμενο χωρίζεται ώστε να ταιριάζει στο πλάτος της περιοχής, γεγονός που αλλάζει τα πραγματικά όρια της παραγράφου.

**Μπορούν οι συντεταγμένες της παραγράφου να μετατραπούν αξιόπιστα σε pixel στην εξαγόμενη εικόνα;**

Ναι. Μετατρέψτε τα points σε pixels χρησιμοποιώντας τον τύπο: pixels = points × (DPI / 72). Το αποτέλεσμα εξαρτάται από το DPI που επιλέγεται για την απόδοση ή την εξαγωγή.

**Πώς μπορώ να λάβω τις «αποτελεσματικές» παραμέτρους μορφοποίησης παραγράφου, λαμβάνοντας υπόψη την κληρονομικότητα των στυλ;**

Χρησιμοποιήστε τη [effective paragraph formatting data structure](/slides/el/androidjava/shape-effective-properties/); επιστρέφει τις τελικές ενοποιημένες τιμές για εσοχές, απόσταση, αναδίπλωση, RTL και άλλα.