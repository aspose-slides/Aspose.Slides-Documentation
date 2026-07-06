---
title: Λήψη Ορίων Παραγράφου από Παρουσιάσεις σε JavaScript
linktitle: Όρια Παραγράφου
type: docs
weight: 43
url: /el/nodejs-java/paragraph-bounds/
keywords:
- όρια παραγράφου
- συντεταγμένη παραγράφου
- μέγεθος παραγράφου
- πλαίσιο κειμένου
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Μάθετε πώς να ανακτήσετε τα όρια παραγράφου στο Aspose.Slides για Node.js μέσω Java για βελτιστοποίηση της τοποθέτησης κειμένου σε παρουσιάσεις PowerPoint."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να λάβετε τα όρια, το μέγεθος και τις συντεταγμένες παραγράφων στο Aspose.Slides. Δείχνει πώς να ανακτήσετε ένα ορθογώνιο παραγράφου από ένα [TextFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/) χρησιμοποιώντας το [Paragraph.getRect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraph/getrect/), πώς να λάβετε τις συντεταγμένες παραγράφου μέσα σε ένα πλαίσιο κειμένου κελιού πίνακα, και υποδεικνύει σημαντικές λεπτομέρειες όπως οι μονάδες μέτρησης, η επίδραση της αναδίπλωσης κειμένου στα όρια, η μετατροπή σε pixel, και οι αποτελεσματικές τιμές μορφοποίησης παραγράφου.

## **Λήψη Ορθογωνίων Συντεταγμένων μιας Παραγράφου**

Χρησιμοποιήστε το [Paragraph.getRect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraph/getrect/) για να λάβετε το ορθογώνιο περιγράμματος μιας παραγράφου.

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    const rectangle = paragraph.getRect();
} finally {
    presentation.dispose();
}
```

## **Λήψη του Μεγέθους μιας Παραγράφου μέσα σε Πλαίσιο Κειμένου Κελιού Πίνακα**

Για να λάβετε το μέγεθος και τις συντεταγμένες ενός [Paragraph](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraph/) σε ένα πλαίσιο κειμένου κελιού πίνακα, χρησιμοποιήστε το [Paragraph.getRect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraph/getrect/). Το επιστρεφόμενο ορθογώνιο είναι σχετικό με το πλαίσιο κειμένου του κελιού πίνακα, έτσι προσθέστε τη θέση του πίνακα και τη μετατόπιση του κελιού όταν χρειάζεστε συντεταγμένες επιπέδου διαφάνειας.

Το παρακάτω παράδειγμα λαμβάνει τα όρια της παραγράφου μέσα σε ένα κελί πίνακα και σχεδιάζει ορθογώνια στη διαφάνεια για να οπτικοποιήσει αυτά τα όρια:

```javascript
const presentation = new aspose.slides.Presentation("source.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);
    const cell = table.getRows().get_Item(1).get_Item(1);

    const cellX = table.getX() + cell.getOffsetX();
    const cellY = table.getY() + cell.getOffsetY();
    const paragraphs = cell.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        if (paragraph.getText() === "") {
            continue;
        }

        const paragraphRectangle = paragraph.getRect();
        const paragraphRectangleX = paragraphRectangle.x + cellX;
        const paragraphRectangleY = paragraphRectangle.y + cellY;
        const paragraphRectangleWidth = paragraphRectangle.width;
        const paragraphRectangleHeight = paragraphRectangle.height;

        const paragraphBoundsShape = slide.getShapes().addAutoShape(
            aspose.slides.ShapeType.Rectangle,
            java.newFloat(paragraphRectangleX),
            java.newFloat(paragraphRectangleY),
            java.newFloat(paragraphRectangleWidth),
            java.newFloat(paragraphRectangleHeight));

        paragraphBoundsShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        paragraphBoundsShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
        paragraphBoundsShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Σε ποιες μονάδες μετρώνται οι συντεταγμένες της παραγράφου;**

Μετρώνται σε points, όπου 1 ίντσα ισούται με 72 points. Αυτό ισχύει για όλες τις συντεταγμένες και διαστάσεις στη διαφάνεια.

**Επηρεάζει η αναδίπλωση κειμένου τα όρια μιας παραγράφου;**

Ναι. Εάν η [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframeformat/setwraptext/) είναι ενεργοποιημένη για το [TextFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/), το κείμενο διασπάται ώστε να ταιριάζει στο πλάτος της περιοχής, κάτι που αλλάζει τα πραγματικά όρια της παραγράφου.

**Μπορούν οι συντεταγμένες της παραγράφου να χαρτογραφηθούν αξιόπιστα σε pixel στην εξαγόμενη εικόνα;**

Ναι. Μετατρέψτε τα points σε pixel χρησιμοποιώντας τον τύπο: pixels = points × (DPI / 72). Το αποτέλεσμα εξαρτάται από το DPI που επιλέγεται για την απόδοση ή την εξαγωγή.

**Πώς μπορώ να λάβω τις «αποτελεσματικές» παραμέτρους μορφοποίησης παραγράφου, λαμβάνοντας υπόψη την κληρονομικότητα του στυλ;**

Χρησιμοποιήστε τη [δεδομένα αποτελεσματικής μορφοποίησης παραγράφου](/slides/el/nodejs-java/shape-effective-properties/); επιστρέφει τις τελικές ενωμένες τιμές για εσοχές, απόσταση, αναδίπλωση, RTL και άλλα.