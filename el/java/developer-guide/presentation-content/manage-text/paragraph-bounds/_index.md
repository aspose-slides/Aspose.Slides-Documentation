---
title: Λήψη ορίων παραγράφων από παρουσιάσεις σε Java
linktitle: Όρια παραγράφων
type: docs
weight: 43
url: /el/java/paragraph-bounds/
keywords:
- όρια παραγράφων
- συντεταγμένη παραγράφου
- μέγεθος παραγράφου
- πλαίσιο κειμένου
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Μάθετε πώς να ανακτήσετε τα όρια παραγράφων στο Aspose.Slides για Java ώστε να βελτιστοποιήσετε την τοποθέτηση του κειμένου σε παρουσιάσεις PowerPoint."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να αποκτήσετε τα όρια, το μέγεθος και τις συντεταγμένες των παραγράφων στο Aspose.Slides. Δείχνει πώς να ανακτήσετε ένα ορθογώνιο παραγράφου από ένα [ITextFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/) χρησιμοποιώντας [IParagraph.getRect](https://reference.aspose.com/slides/el/java/com.aspose.slides/IParagraph#getRect--), πώς να λάβετε τις συντεταγμένες της παραγράφου μέσα σε ένα πλαίσιο κειμένου κελιού πίνακα, και επισημαίνει σημαντικές λεπτομέρειες όπως οι μονάδες μέτρησης, η επίδραση της αναδίπλωσης κειμένου στα όρια, η μετατροπή σε pixel και οι αποτελεσματικές τιμές μορφοποίησης παραγράφου.

## **Λήψη Ορθογώνιων Συντεταγμένων μιας Παραγράφου**

Χρησιμοποιήστε το [IParagraph.getRect](https://reference.aspose.com/slides/el/java/com.aspose.slides/IParagraph#getRect--) για να λάβετε το περιγράμματα ορθογώνιο μιας παραγράφου.

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    java.awt.geom.Rectangle2D.Float rectangle = paragraph.getRect();
} finally {
    presentation.dispose();
}
```

## **Λήψη του Μεγέθους μιας Παραγράφου μέσα σε Πλαίσιο Κειμένου Κελιού Πίνακα**

Για να λάβετε το μέγεθος και τις συντεταγμένες ενός [IParagraph](https://reference.aspose.com/slides/el/java/com.aspose.slides/iparagraph/) σε ένα πλαίσιο κειμένου κελιού πίνακα, χρησιμοποιήστε το [IParagraph.getRect](https://reference.aspose.com/slides/el/java/com.aspose.slides/IParagraph#getRect--). Το επιστρεφόμενο ορθογώνιο είναι σχετικό με το πλαίσιο κειμένου του κελιού πίνακα, επομένως προσθέστε τη θέση του πίνακα και τη μετατόπιση του κελιού όταν χρειάζεστε συντεταγμένες επιπέδου διαφάνειας.

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

        java.awt.geom.Rectangle2D.Float paragraphRectangle = paragraph.getRect();
        float paragraphRectangleX = paragraphRectangle.x + (float) cellX;
        float paragraphRectangleY = paragraphRectangle.y + (float) cellY;

        IAutoShape paragraphBoundsShape = slide.getShapes().addAutoShape(
                ShapeType.Rectangle,
                paragraphRectangleX,
                paragraphRectangleY,
                paragraphRectangle.width,
                paragraphRectangle.height);

        paragraphBoundsShape.getFillFormat().setFillType(FillType.NoFill);
        paragraphBoundsShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
        paragraphBoundsShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Σε ποιες μονάδες μετρώνται οι συντεταγμένες της παραγράφου;**

Μετρώνται σε σημεία (points), όπου 1 ίντσα ισούται με 72 σημεία. Αυτό ισχύει για όλες τις συντεταγμένες και διαστάσεις στη διαφάνεια.

**Επηρεάζει η αναδίπλωση κειμένου τα όρια μιας παραγράφου;**

Ναι. Εάν είναι ενεργοποιημένο το [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) για το [ITextFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/), το κείμενο σπάει ώστε να χωράει στο πλάτος της περιοχής, γεγονός που αλλάζει τα πραγματικά όρια της παραγράφου.

**Μπορούν οι συντεταγμένες της παραγράφου να αντιστοιχιστούν αξιόπιστα σε pixel στην εξαγόμενη εικόνα;**

Ναι. Μετατρέψτε τα σημεία σε pixel χρησιμοποιώντας τον τύπο: pixels = points × (DPI / 72). Το αποτέλεσμα εξαρτάται από το DPI που επιλέγεται για την απόδοση ή εξαγωγή.

**Πώς μπορώ να λάβω τις "αποτελεσματικές" παραμέτρους μορφοποίησης παραγράφου, λαμβάνοντας υπόψη την κληρονομιά στυλ;**

Χρησιμοποιήστε τη [effective paragraph formatting data structure](/slides/el/java/shape-effective-properties/); επιστρέφει τις τελικές ενοποιημένες τιμές για εσοχές, απόσταση, αναδίπλωση, RTL και περισσότερα.