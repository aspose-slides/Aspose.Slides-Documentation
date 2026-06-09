---
title: Λήψη ορίων παραγράφου από παρουσιάσεις σε JavaScript
linktitle: Παράγραφος
type: docs
weight: 60
url: /el/nodejs-java/paragraph/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Μάθετε πώς να ανακτάτε τα όρια παραγράφου και τμήματος κειμένου σε JavaScript με το Aspose.Slides για Node.js ώστε να βελτιστοποιήσετε την τοποθέτηση κειμένου σε παρουσιάσεις PowerPoint."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να λάβετε τα όρια, το μέγεθος και τις συντεταγμένες παραγράφων και τμημάτων κειμένου στο Aspose.Slides. Δείχνει πώς να ανακτήσετε το ορθογώνιο μιας παραγράφου σε ένα `TextFrame` χρησιμοποιώντας τη μέθοδο `getRect()`, πώς να λάβετε τις συντεταγμένες παραγράφων και τμημάτων μέσα σε ένα πλαίσιο κειμένου κελιού πίνακα, και επισημαίνει σημαντικές λεπτομέρειες όπως οι μονάδες μέτρησης, η επίδραση της αναδίπλωσης κειμένου στα όρια, η μετατροπή σε εικονοστοιχεία και οι αποτελεσματικές τιμές μορφοποίησης παραγράφου.

## **Λήψη Συντεταγμένων Παραγράφου και Τμήματος σε TextFrame**
Χρησιμοποιώντας το Aspose.Slides για Node.js μέσω Java, οι προγραμματιστές μπορούν τώρα να λάβουν τις ορθογώνιες συντεταγμένες για την Paragraph μέσα στη συλλογή παραγράφων του TextFrame. Επιτρέπει επίσης να λάβετε [τις συντεταγμένες του τμήματος](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Portion#getCoordinates--) μέσα στη συλλογή τμημάτων μιας παραγράφου. Σε αυτό το θέμα, θα δείξουμε με τη βοήθεια ενός παραδείγματος πώς να λάβετε τις ορθογώνιες συντεταγμένες για την παράγραφο μαζί με τη θέση του τμήματος μέσα σε μια παράγραφο.

```javascript
var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
var textFrame = shape.getTextFrame();
for (let i = 0; i < textFrame.getParagraphs().getCount(); i++) {
    const paragraph = textFrame.getParagraphs().get_Item(i);
    for (let j = 0; j < paragraph.getPortions().getCount(); j++) {
        const portion = paragraph.getPortions().get_Item(j);
        var point = portion.getCoordinates();
    }
}
```

## **Λήψη Ορθογωνίων Συντεταγμένων Παραγράφου**
Χρησιμοποιώντας τη μέθοδο [**getRect()**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Paragraph#getRect--) οι προγραμματιστές μπορούν να λάβουν το ορθογώνιο των ορίων της παραγράφου.

```javascript
var pres = new aspose.slides.Presentation("HelloWorld.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var textFrame = shape.getTextFrame();
    var rect = textFrame.getParagraphs().get_Item(0).getRect();
    console.log("X: " + rect.x + " Y: " + rect.y + " Width: " + rect.width + " Height: " + rect.height);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Λήψη μεγέθους παραγράφου και τμήματος μέσα σε table cell text frame**
Για να λάβετε το μέγεθος και τις συντεταγμένες του [Portion](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Portion) ή του [Paragraph](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Paragraph) σε ένα πλαίσιο κειμένου κελιού πίνακα, μπορείτε να χρησιμοποιήσετε τις μεθόδους [Portion.getRect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Portion#getRect--) και [Paragraph.getRect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Paragraph#getRect--).

Αυτό το παράδειγμα κώδικα επιδεικνύει τη περιγραφόμενη λειτουργία:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var tbl = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var cell = tbl.getRows().get_Item(1).get_Item(1);
    var x = tbl.getX() + tbl.getRows().get_Item(1).get_Item(1).getOffsetX();
    var y = tbl.getY() + tbl.getRows().get_Item(1).get_Item(1).getOffsetY();
    
    for (let i = 0; i < cell.getTextFrame().getParagraphs().getCount(); i++) {
        const para = cell.getTextFrame().getParagraphs().get_Item(i);
        if (para.getText() === "") {
            continue;
        }
        var rect = para.getRect();
        var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, java.newFloat(rect.getX() + x), java.newFloat(rect.getY() + y), java.newFloat(rect.getWidth()), java.newFloat(rect.getHeight()));
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        for (let j = 0; j < para.getPortions().getCount(); j++) {
            const portion = para.getPortions().get_Item(j);
            if (portion.getText().includes("0")) {
                rect = portion.getRect();
                shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, java.newFloat(rect.getX() + x), java.newFloat(rect.getY() + y), java.newFloat(rect.getWidth()), java.newFloat(rect.getHeight()));
                shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            }
        }
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Συχνές ερωτήσεις**

**Σε ποιες μονάδες επιστρέφονται οι συντεταγμένες για μια παράγραφο και τμήματα κειμένου;**  
Σε μονάδες σημείων, όπου 1 ίντσα = 72 σημεία. Αυτό ισχύει για όλες τις συντεταγμένες και διαστάσεις στη διαφάνεια.

**Επηρεάζει η αναδίπλωση κειμένου τα όρια μιας παραγράφου;**  
Ναι. Εάν η [wrapping](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframeformat/setwraptext/) είναι ενεργοποιημένη στο [TextFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/), το κείμενο διακόπτεται ώστε να ταιριάζει στο πλάτος της περιοχής, κάτι που αλλάζει τα πραγματικά όρια της παραγράφου.

**Μπορούν οι συντεταγμένες της παραγράφου να αντιστοιχιστούν αξιόπιστα σε εικονοστοιχεία στην εξάγόμενη εικόνα;**  
Ναι. Μετατρέψτε τα σημεία σε εικονοστοιχεία χρησιμοποιώντας: pixels = points × (DPI / 72). Το αποτέλεσμα εξαρτάται από το DPI που επιλέγεται για την απόδοση/εξαγωγή.

**Πώς μπορώ να λάβω τις "αποτελεσματικές" παραμέτρους μορφοποίησης της παραγράφου, λαμβάνοντας υπόψη την κληρονομικότητα του στυλ;**  
Χρησιμοποιήστε τη [effective paragraph formatting data structure](/slides/el/nodejs-java/shape-effective-properties/); επιστρέφει τις τελικές ενοποιημένες τιμές για τα εσοχές, την απόσταση, την αναδίπλωση, το RTL και άλλα.