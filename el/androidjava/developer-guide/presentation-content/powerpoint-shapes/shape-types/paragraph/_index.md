---
title: Απόκτηση ορίων παραγράφου από παρουσιάσεις στο Android
linktitle: Παράγραφος
type: docs
weight: 60
url: /el/androidjava/paragraph/
keywords:
- όρια παραγράφου
- όρια τμήματος κειμένου
- συντεταγμένη παραγράφου
- συντεταγμένη τμήματος
- μέγεθος παραγράφου
- μέγεθος τμήματος κειμένου
- πλαίσιο κειμένου
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Μάθετε πώς να ανακτήσετε τα όρια παραγράφου και τμήματος κειμένου στο Aspose.Slides για Android μέσω Java για βελτιστοποίηση της τοποθέτησης κειμένου σε παρουσιάσεις PowerPoint."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να λάβετε τα όρια, το μέγεθος και τις συντεταγμένες των παραγράφων και των τμημάτων κειμένου στο Aspose.Slides. Δείχνει πώς να ανακτήσετε το ορθογώνιο ενός παραγράφου σε ένα `TextFrame` χρησιμοποιώντας τη μέθοδο `getRect()`, πώς να λάβετε τις συντεταγμένες παραγράφου και τμήματος μέσα σε πλαίσιο κειμένου κελιού πίνακα, και αναδεικνύει σημαντικές λεπτομέρειες όπως οι μονάδες μέτρησης, η επίδραση της αναδίπλωσης κειμένου στα όρια, η μετατροπή σε pixel και οι τιμές αποτελεσματικής μορφοποίησης παραγράφου.

## **Λήψη Συντεταγμένων Παραγράφου και Τμήματος σε TextFrame**
Χρησιμοποιώντας το Aspose.Slides για Android μέσω Java, οι προγραμματιστές μπορούν τώρα να λάβουν τις ορθογώνιες συντεταγμένες για το Paragraph μέσα στη συλλογή παραγράφων του TextFrame. Επιτρέπει επίσης να λάβετε [τις συντεταγμένες του τμήματος](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IPortion#getCoordinates--) μέσα στη συλλογή τμημάτων μιας παραγράφου. Σε αυτό το θέμα, θα δείξουμε με τη βοήθεια ενός παραδείγματος πώς να λάβετε τις ορθογώνιες συντεταγμένες για την παράγραφο μαζί με τη θέση του τμήματος μέσα στην παράγραφο.

``` java
AutoShape shape = (AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
TextFrame textFrame = (TextFrame)shape.getTextFrame();
for (IParagraph paragraph : textFrame.getParagraphs()){
  for (IPortion portion : paragraph.getPortions()){
    Point2D.Float point = portion.getCoordinates();
  }
}
```

## **Λήψη Ορθογώνιων Συντεταγμένων μιας Παραγράφου**
Χρησιμοποιώντας τη μέθοδο [**getRect()**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IParagraph#getRect--) οι προγραμματιστές μπορούν να λάβουν το ορθογώνιο των ορίων της παραγράφου.

```java
Presentation pres = new Presentation("HelloWorld.pptx");
try {
    IAutoShape shape = (IAutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITextFrame textFrame = shape.getTextFrame();
    Rectangle2D.Float rect = textFrame.getParagraphs().get_Item(0).getRect();
    System.out.println("X: " + rect.x + " Y: " + rect.y + " Width: " + rect.width + " Height: " + rect.height);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Λήψη του Μεγέθους μιας Παραγράφου και Τμήματος μέσα σε TextFrame Κελιού Πίνακα**
Για να λάβετε το μέγεθος και τις συντεταγμένες του [Portion](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Portion) ή του [Paragraph](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Paragraph) σε πλαίσιο κειμένου κελιού πίνακα, μπορείτε να χρησιμοποιήσετε τις μεθόδους [IPortion.getRect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IPortion#getRect--) και [IParagraph.getRect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IParagraph#getRect--).

Αυτό το δείγμα κώδικα επιδεικνύει τη περιγραφόμενη λειτουργία:

```java
Presentation pres = new Presentation("source.pptx");
try {
    Table tbl = (Table)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ICell cell = tbl.getRows().get_Item(1).get_Item(1);

    double x = tbl.getX() + tbl.getRows().get_Item(1).get_Item(1).getOffsetX();
    double y = tbl.getY() + tbl.getRows().get_Item(1).get_Item(1).getOffsetY();

    for (IParagraph para : cell.getTextFrame().getParagraphs())
    {
        if (para.getText().equals(""))
            continue;

        Rectangle2D.Float rect = para.getRect();
        IAutoShape shape =
                pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle,
                        (float)rect.getX() + (float)x, (float)rect.getY() + (float)y, (float)rect.getWidth(), (float)rect.getHeight());

        shape.getFillFormat().setFillType(FillType.NoFill);
        shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
        shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);

        for (IPortion portion : para.getPortions())
        {
            if (portion.getText().contains("0"))
            {
                rect = portion.getRect();
                shape =
                        pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle,
                                (float)rect.getX() + (float)x, (float)rect.getY() + (float)y, (float)rect.getWidth(), (float)rect.getHeight());

                shape.getFillFormat().setFillType(FillType.NoFill);
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Σε ποιες μονάδες επιστρέφονται οι συντεταγμένες για μια παράγραφο και τμήματα κειμένου;**

Σε μονάδες point, όπου 1 ίντσα = 72 points. Αυτό ισχύει για όλες τις συντεταγμένες και διαστάσεις στη διαφάνεια.

**Επηρεάζει η αναδίπλωση λέξεων τα όρια μιας παραγράφου;**

Ναι. Εάν η [wrapping](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-) είναι ενεργοποιημένη στο [TextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/textframe/), το κείμενο σπάει ώστε να χωρέσει στο πλάτος της περιοχής, κάτι που αλλάζει τα πραγματικά όρια της παραγράφου.

**Μπορούν οι συντεταγμένες της παραγράφου να χαρτογραφηθούν αξιόπιστα σε pixel στην εξαγόμενη εικόνα;**

Ναι. Μετατρέψτε τα points σε pixel χρησιμοποιώντας: pixels = points × (DPI / 72). Το αποτέλεσμα εξαρτάται από το DPI που επιλέγεται για την απόδοση/εξαγωγή.

**Πώς μπορώ να λάβω τις "αποτελεσματικές" παραμέτρους μορφοποίησης παραγράφου, λαμβάνοντας υπόψη την κληρονομικότητα στυλ;**

Χρησιμοποιήστε τη [effective paragraph formatting data structure](/slides/el/androidjava/shape-effective-properties/); επιστρέφει τις τελικές ενοποιημένες τιμές για εσοχές, απόσταση, αναδίπλωση, RTL και άλλα.