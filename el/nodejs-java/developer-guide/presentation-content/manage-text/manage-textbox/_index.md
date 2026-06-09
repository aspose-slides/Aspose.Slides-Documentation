---
title: Διαχείριση πλαισίων κειμένου σε παρουσιάσεις χρησιμοποιώντας JavaScript
linktitle: Διαχείριση πλαισίου κειμένου
type: docs
weight: 20
url: /el/nodejs-java/manage-textbox/
keywords:
- πλαίσιο κειμένου
- πλαίσιο κειμένου
- προσθήκη κειμένου
- ενημέρωση κειμένου
- δημιουργία πλαισίου κειμένου
- έλεγχος πλαισίου κειμένου
- προσθήκη στήλης κειμένου
- προσθήκη υπερσυνδέσμου
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Το Aspose.Slides for Node.js καθιστά εύκολη τη δημιουργία, επεξεργασία και κλωνοποίηση πλαισίων κειμένου σε αρχεία PowerPoint και OpenDocument, ενισχύοντας την αυτοματοποίηση των παρουσιάσεών σας."
---
## **Εισαγωγή**

Τα κείμενα στις διαφάνειες συνήθως βρίσκονται σε πλαίσια κειμένου ή σχήματα. Συνεπώς, για να προσθέσετε κείμενο σε μια διαφάνεια, πρέπει να προσθέσετε ένα πλαίσιο κειμένου και στη συνέχεια να τοποθετήσετε κάποιο κείμενο μέσα στο πλαίσιο. Το Aspose.Slides for Node.js μέσω Java παρέχει την κλάση [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/AutoShape) που επιτρέπει την προσθήκη σχήματος που περιέχει κείμενο.

{{% alert title="Info" color="info" %}}
Το Aspose.Slides παρέχει επίσης την κλάση [Shape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Shape) που επιτρέπει την προσθήκη σχημάτων στις διαφάνειες. Ωστόσο, όχι όλα τα σχήματα που προστίθενται μέσω της κλάσης `Shape` μπορούν να περιέχουν κείμενο. Αλλά τα σχήματα που προστίθενται μέσω της κλάσης [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/AutoShape) μπορεί να περιέχουν κείμενο.
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
Συνεπώς, όταν εργάζεστε με ένα σχήμα στο οποίο θέλετε να προσθέσετε κείμενο, ίσως να θέλετε να ελέγξετε και να επιβεβαιώσετε ότι μετατράπηκε μέσω της κλάσης `AutoShape`. Μόνο τότε θα μπορείτε να εργαστείτε με το [TextFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/TextFrame), το οποίο είναι ιδιότητα της `AutoShape`. Δείτε την ενότητα [Ενημέρωση κειμένου](https://docs.aspose.com/slides/el/nodejs-java/manage-textbox/#update-text) σε αυτή τη σελίδα.
{{% /alert %}}

## **Δημιουργία πλαισίου κειμένου σε διαφάνεια**

Για να δημιουργήσετε ένα πλαίσιο κειμένου σε μια διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).
2. Αποκτήστε μια αναφορά για τη πρώτη διαφάνεια στην πρόσφατα δημιουργημένη παρουσίαση. 
3. Προσθέστε ένα αντικείμενο [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/AutoShape) με το [ShapeType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/GeometryShape#setShapeType-int-) ορισμένο σε `Rectangle` σε συγκεκριμένη θέση στη διαφάνεια και αποκτήστε την αναφορά για το νεοπροστιθέμενο αντικείμενο `AutoShape`.
4. Προσθέστε την ιδιότητα `TextFrame` στο αντικείμενο `AutoShape` που θα περιέχει κείμενο. Στο παρακάτω παράδειγμα, προσθέσαμε το κείμενο: *Aspose TextBox*
5. Τέλος, εγγράψτε το αρχείο PPTX μέσω του αντικειμένου `Presentation`. 

Αυτός ο κώδικας JavaScript—μια υλοποίηση των παραπάνω βημάτων—δείχνει πώς να προσθέσετε κείμενο σε μια διαφάνεια:

```javascript
// Δημιουργεί παρουσίαση
var pres = new aspose.slides.Presentation();
try {
    // Λαμβάνει την πρώτη διαφάνεια στην παρουσίαση
    var sld = pres.getSlides().get_Item(0);
    // Προσθέτει AutoShape με τύπο Rectangle
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // Προσθέτει TextFrame στο Rectangle
    ashp.addTextFrame(" ");
    // Πρόσβαση στο πλαίσιο κειμένου
    var txtFrame = ashp.getTextFrame();
    // Δημιουργεί το αντικείμενο Paragraph για το πλαίσιο κειμένου
    var para = txtFrame.getParagraphs().get_Item(0);
    // Δημιουργεί ένα αντικείμενο Portion για την παράγραφο
    var portion = para.getPortions().get_Item(0);
    // Ορίζει το κείμενο
    portion.setText("Aspose TextBox");
    // Αποθηκεύει την παρουσίαση στο δίσκο
    pres.save("TextBox_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Έλεγχος για σχήμα πλαισίου κειμένου**

Το Aspose.Slides παρέχει τη μέθοδο [isTextBox](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/#isTextBox) από την κλάση [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/) που επιτρέπει να εξετάσετε σχήματα και να εντοπίσετε πλαίσια κειμένου.

![Πλαίσιο κειμένου και σχήμα](istextbox.png)

Αυτός ο κώδικας JavaScript δείχνει πώς να ελέγξετε αν ένα σχήμα δημιουργήθηκε ως πλαίσιο κειμένου:

```javascript
var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    java.callStaticMethodSync("ForEach", "shape", presentation, (shape, slide, index) -> {
        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            var autoShape = shape;
            console.log(autoShape.isTextBox() ? "shape is a text box" : "shape is not a text box");
        }
    });
} finally {
    presentation.dispose();
}
```

Σημειώστε ότι εάν προσθέσετε απλώς ένα autoshape χρησιμοποιώντας τη μέθοδο `addAutoShape` από την κλάση [ShapeCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shapecollection/), η μέθοδος `isTextBox` του autoshape θα επιστρέψει `false`. Ωστόσο, αφού προσθέσετε κείμενο στο autoshape χρησιμοποιώντας τη μέθοδο `addTextFrame` ή τη μέθοδο `setText`, η ιδιότητα `isTextBox` επιστρέφει `true`.

```javascript
var presentation = new aspose.slides.Presentation();
var slide = presentation.getSlides().get_Item(0);

var shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 40);
// shape1.isTextBox() επιστρέφει false
shape1.addTextFrame("shape 1");
// shape1.isTextBox() επιστρέφει true

var shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 110, 100, 40);
// shape2.isTextBox() επιστρέφει false
shape2.getTextFrame().setText("shape 2");
// shape2.isTextBox() επιστρέφει true

var shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 210, 100, 40);
// shape3.isTextBox() επιστρέφει false
shape3.addTextFrame("");
// shape3.isTextBox() επιστρέφει false

var shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 100, 40);
// shape4.isTextBox() επιστρέφει false
shape4.getTextFrame().setText("");
// shape4.isTextBox() επιστρέφει false
```

## **Προσθήκη στήλης σε πλαίσιο κειμένου**

Το Aspose.Slides παρέχει τις μεθόδους [setColumnCount](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) και [setColumnSpacing](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/TextFrameFormat#setColumnSpacing-double-) από την κλάση [TextFrameFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/TextFrameFormat) που επιτρέπουν την προσθήκη στηλών σε πλαίσια κειμένου. Μπορείτε να ορίσετε τον αριθμό των στηλών σε ένα πλαίσιο κειμένου και να ορίσετε το διάστημα σε σημεία μεταξύ των στηλών.

Αυτός ο κώδικας σε JavaScript δείχνει τη περιγραφείσα λειτουργία: 

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Λαμβάνει την πρώτη διαφάνεια στην παρουσίαση
    var slide = pres.getSlides().get_Item(0);
    // Προσθέτει AutoShape με τύπο Rectangle
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // Προσθέτει TextFrame στο Rectangle
    aShape.addTextFrame((("All these columns are limited to be within a single text container -- " + "you can add or delete text and the new or remaining text automatically adjusts ") + "itself to flow within the container. You cannot have text flow from one container ") + "to other though -- we told you PowerPoint's column options for text are limited!");
    // Λαμβάνει τη μορφή κειμένου του TextFrame
    var format = aShape.getTextFrame().getTextFrameFormat();
    // Ορίζει τον αριθμό των στηλών στο TextFrame
    format.setColumnCount(3);
    // Ορίζει το διάστημα μεταξύ των στηλών
    format.setColumnSpacing(10);
    // Αποθηκεύει την παρουσίαση
    pres.save("ColumnCount.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Προσθήκη στήλης σε πλαίσιο κειμένου**

Το Aspose.Slides for Node.js μέσω Java παρέχει τη μέθοδο [setColumnCount](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) από την κλάση [TextFrameFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/TextFrameFormat) που επιτρέπει την προσθήκη στηλών σε πλαίσια κειμένου. Μέσω αυτής της ιδιότητας, μπορείτε να καθορίσετε τον επιθυμητό αριθμό στηλών σε ένα πλαίσιο κειμένου.

Αυτός ο κώδικας JavaScript δείχνει πώς να προσθέσετε μια στήλη μέσα σε ένα πλαίσιο κειμένου:

```javascript
var outPptxFileName = "ColumnsTest.pptx";
var pres = new aspose.slides.Presentation();
try {
    var shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    var format = shape1.getTextFrame().getTextFrameFormat();
    format.setColumnCount(2);
    shape1.getTextFrame().setText("All these columns are forced to stay within a single text container -- " + "you can add or delete text - and the new or remaining text automatically adjusts " + "itself to stay within the container. You cannot have text spill over from one container " + "to other, though -- because PowerPoint's column options for text are limited!");
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test.getSlides().get_Item(0).getShapes().get_Item(0);
        java.callStaticMethodSync("Assert", "assertTrue", 2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", java.getStaticFieldValue("java.lang.Double", "NaN") == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test != null) {
            test.dispose();
        }
    }
    format.setColumnSpacing(20);
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test1 = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test1.getSlides().get_Item(0).getShapes().get_Item(0);
        java.callStaticMethodSync("Assert", "assertTrue", 2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", 20 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test1 != null) {
            test1.dispose();
        }
    }
    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test2 = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test2.getSlides().get_Item(0).getShapes().get_Item(0);
        java.callStaticMethodSync("Assert", "assertTrue", 3 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", 15 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test2 != null) {
            test2.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ενημέρωση κειμένου**

Το Aspose.Slides σας επιτρέπει να αλλάξετε ή να ενημερώσετε το κείμενο που περιέχεται σε ένα πλαίσιο κειμένου ή όλα τα κείμενα που περιέχονται σε μια παρουσίαση. 

Αυτός ο κώδικας JavaScript δείχνει μια λειτουργία όπου όλα τα κείμενα σε μια παρουσίαση ενημερώνονται ή αλλάζουν:

```javascript
var pres = new aspose.slides.Presentation("text.pptx");
try {
    for (let s = 0; s < pres.getSlides().size(); s++) {
        let slide = pres.getSlides().get_Item(s);
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            // Ελέγχει αν το σχήμα υποστηρίζει πλαίσιο κειμένου (IAutoShape).
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                var autoShape = shape;
                // Διατρέχει τις παραγράφους στο πλαίσιο κειμένου
                for (let j = 0; j < autoShape.getTextFrame().getParagraphs().getCount(); j++) {
                    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(j);
                    // Διατρέχει κάθε τμήμα στην παράγραφο
                    for (let k = 0; k < paragraph.getPortions().getCount(); k++) {
                        let portion = paragraph.getPortions().get_Item(k);
                        portion.setText(portion.getText().replace("years", "months"));// Αλλάζει το κείμενο
                        portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));// Αλλάζει τη μορφοποίηση
                    }
                }
            }
        }
    }
    // Αποθηκεύει την τροποποιημένη παρουσίαση
    pres.save("text-changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Προσθήκη πλαισίου κειμένου με υπερσύνδεσμο** 

Μπορείτε να εισαγάγετε έναν σύνδεσμο μέσα σε ένα πλαίσιο κειμένου. Όταν το πλαίσιο κειμένου κλικάρεται, οι χρήστες οδηγούνται στο άνοιγμα του συνδέσμου. 

Για να προσθέσετε ένα πλαίσιο κειμένου που περιέχει σύνδεσμο, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης `Presentation`. 
2. Αποκτήστε μια αναφορά για τη πρώτη διαφάνεια στην πρόσφατα δημιουργημένη παρουσίαση. 
3. Προσθέστε ένα αντικείμενο `AutoShape` με `ShapeType` ορισμένο σε `Rectangle` σε συγκεκριμένη θέση στη διαφάνεια και αποκτήστε μια αναφορά του νεοπροστιθέμενου αντικειμένου AutoShape.
4. Προσθέστε ένα `TextFrame` στο αντικείμενο `AutoShape` που περιέχει *Aspose TextBox* ως προεπιλεγμένο κείμενο. 
5. Δημιουργήστε μια παρουσία της κλάσης `HyperlinkManager`. 
6. Αναθέστε το αντικείμενο `HyperlinkManager` στην ιδιότητα [HyperlinkClick](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Shape#getHyperlinkClick--) που σχετίζεται με το επιθυμητό τμήμα του `TextFrame`.
7. Τέλος, εγγράψτε το αρχείο PPTX μέσω του αντικειμένου `Presentation`. 

Αυτός ο κώδικας JavaScript—μια υλοποίηση των παραπάνω βημάτων—δείχνει πώς να προσθέσετε ένα πλαίσιο κειμένου με υπερσύνδεσμο σε μια διαφάνεια:

```javascript
// Δημιουργεί μια Presentation που αντιπροσωπεύει ένα PPTX
var pres = new aspose.slides.Presentation();
try {
    // Λαμβάνει την πρώτη διαφάνεια στην παρουσίαση
    var slide = pres.getSlides().get_Item(0);
    // Προσθέτει αντικείμενο AutoShape με τύπο Rectangle
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 150, 50);
    // Μετατρέπει το σχήμα σε AutoShape
    var pptxAutoShape = shape;
    // Πρόσβαση στην ιδιότητα ITextFrame που σχετίζεται με το AutoShape
    pptxAutoShape.addTextFrame("");
    var textFrame = pptxAutoShape.getTextFrame();
    // Προσθέτει κάποιο κείμενο στο πλαίσιο
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");
    // Ορίζει τον υπερσύνδεσμο για το κείμενο του τμήματος
    var hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");
    // Αποθηκεύει την παρουσίαση PPTX
    pres.save("hLink_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Συχνές Ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ πλαισίου κειμένου και θέσης κράτησης κειμένου όταν εργάζεστε με κύριες διαφάνειες;**

Ένα [θέση κράτησης](/slides/el/nodejs-java/manage-placeholder/) κληρονομεί το στυλ/θέση από το [κύριο](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/masterslide/) και μπορεί να παρακαμφθεί στις [διάταξεις](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/layoutslide/), ενώ ένα κανονικό πλαίσιο κειμένου είναι ανεξάρτητο αντικείμενο σε συγκεκριμένη διαφάνεια και δεν αλλάζει όταν αλλάζετε τα layout.

**Πώς μπορώ να εκτελέσω αντικατάσταση μαζικού κειμένου σε ολόκληρη την παρουσίαση χωρίς να επηρεάσω το κείμενο μέσα σε διαγράμματα, πίνακες και SmartArt;**

Περιορίστε την επανάληψή σας στα auto‑shapes που έχουν πλαίσια κειμένου και εξαιρέστε τα ενσωματωμένα αντικείμενα ([διαγράμματα](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chart/), [πίνακες](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/smartart/)) διασχίζοντας τις συλλογές τους ξεχωριστά ή παραλείποντας αυτούς τους τύπους αντικειμένων.