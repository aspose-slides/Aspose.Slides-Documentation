---
title: Διαχείριση πλαισίων κειμένου σε παρουσιάσεις με JavaScript
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

Τα κείμενα στις διαφάνειες συνήθως βρίσκονται σε πλαίσια κειμένου ή σχήματα. Συνεπώς, για να προσθέσετε κείμενο σε μια διαφάνεια, πρέπει να προσθέσετε ένα πλαίσιο κειμένου και στη συνέχεια να τοποθετήσετε κάποιο κείμενο μέσα στο πλαίσιο. Το Aspose.Slides for Node.js via Java παρέχει την κλάση [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/AutoShape) που σας επιτρέπει να προσθέσετε ένα σχήμα που περιέχει κάποιο κείμενο.

{{% alert title="Info" color="info" %}}

Το Aspose.Slides παρέχει επίσης την κλάση [Shape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Shape) που σας επιτρέπει να προσθέσετε σχήματα σε διαφάνειες. Ωστόσο, δεν μπορούν όλα τα σχήματα που προστίθενται μέσω της κλάσης `Shape` να περιέχουν κείμενο. Αλλά τα σχήματα που προστίθενται μέσω της κλάσης [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/AutoShape) μπορούν να περιέχουν κείμενο.

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

Συνεπώς, όταν εργάζεστε με ένα σχήμα στο οποίο θέλετε να προσθέσετε κείμενο, ίσως θελήσετε να ελέγξετε και να επιβεβαιώσετε ότι έχει μετατραπεί μέσω της κλάσης `AutoShape`. Μόνο τότε θα μπορείτε να εργαστείτε με το [TextFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/TextFrame), το οποίο είναι μια ιδιότητα του `AutoShape`. Δείτε την ενότητα [Update Text](https://docs.aspose.com/slides/el/nodejs-java/manage-textbox/#update-text) σε αυτή τη σελίδα.

{{% /alert %}}

## **Δημιουργία πλαισίου κειμένου σε διαφάνεια**

Για να δημιουργήσετε ένα πλαίσιο κειμένου σε μια διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).
2. Αποκτήστε μια αναφορά για την πρώτη διαφάνεια στην πρόσφατα δημιουργημένη παρουσία. 
3. Προσθέστε ένα αντικείμενο [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/AutoShape) με [ShapeType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/GeometryShape#setShapeType-int-) ορισμένο ως `Rectangle` σε καθορισμένη θέση στη διαφάνεια και αποκτήστε την αναφορά για το νεοπροστέθηκε αντικείμενο `AutoShape`.
4. Προσθέστε την ιδιότητα `TextFrame` στο αντικείμενο `AutoShape` που θα περιέχει κείμενο. Στο παρακάτω παράδειγμα, προσθέσαμε αυτό το κείμενο: *Aspose TextBox*
5. Τέλος, γράψτε το αρχείο PPTX μέσω του αντικειμένου `Presentation`. 

Αυτός ο κώδικας JavaScript—μια υλοποίηση των παραπάνω βημάτων—σας δείχνει πώς να προσθέσετε κείμενο σε μια διαφάνεια:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Δημιουργεί αντικείμενο Presentation
var pres = new aspose.slides.Presentation();
try {
    // Αποκτά την πρώτη διαφάνεια της παρουσίασης
    var sld = pres.getSlides().get_Item(0);
    // Προσθέτει AutoShape με τύπο Rectangle
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // Προσθέτει TextFrame στο Rectangle
    ashp.addTextFrame(" ");
    // Προσπελαύνει το πλαίσιο κειμένου
    var txtFrame = ashp.getTextFrame();
    // Δημιουργεί το αντικείμενο Paragraph για το πλαίσιο κειμένου
    var para = txtFrame.getParagraphs().get_Item(0);
    // Δημιουργεί ένα αντικείμενο Portion για την παράγραφο
    var portion = para.getPortions().get_Item(0);
    // Ορίζει κείμενο
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

Το Aspose.Slides παρέχει τη μέθοδο [isTextBox](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/#isTextBox) από την κλάση [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/) , επιτρέποντάς σας να εξετάζετε σχήματα και να αναγνωρίζετε πλαίσια κειμένου.

![Text box and shape](istextbox.png)

Αυτός ο κώδικας JavaScript σας δείχνει πώς να ελέγξετε αν ένα σχήμα δημιουργήθηκε ως πλαίσιο κειμένου:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (var slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        var slide = presentation.getSlides().get_Item(slideIndex);
        for (var shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            var shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                var autoShape = shape;
                console.log(autoShape.isTextBox() ? "shape is a text box" : "shape is not a text box");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Σημειώστε ότι εάν απλώς προσθέσετε ένα autoshape χρησιμοποιώντας τη μέθοδο `addAutoShape` από την κλάση [ShapeCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shapecollection/) , η μέθοδος `isTextBox` του autoshape θα επιστρέψει `false`. Ωστόσο, μετά την προσθήκη κειμένου στο autoshape χρησιμοποιώντας τη μέθοδο `addTextFrame` ή τη μέθοδο `setText`, η ιδιότητα `isTextBox` επιστρέφει `true`.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

## **Εύρεση του σχήματος που κατέχει ένα πλαίσιο κειμένου**

Σε γενικό κώδικα επεξεργασίας κειμένου, μπορεί να λάβετε ένα [TextFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/) χωρίς να γνωρίζετε ήδη ποιο αντικείμενο παρουσία το περιέχει. Χρησιμοποιήστε τη μέθοδο [TextFrame.getParentShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/#getParentShape--) για να επιστρέψετε στο ιδιοκτητικό [Shape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/).

Για ένα πλαίσιο κειμένου που ανήκει σε ένα [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/) ή σε ένα άλλο σχήμα που περιέχει κείμενο, η [TextFrame.getParentShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/#getParentShape--) επιστρέφει τον ιδιοκτήτη και η [TextFrame.getParentCell](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/#getParentCell--) επιστρέφει `null`. Και οι δύο μέθοδοι παρέχουν πλοήγηση μόνο για ανάγνωση, έτσι η κλήση τους δεν αλλάζει την κυριότητα. Πάντα ελέγχετε την επιστρεφόμενη τιμή για `null` πριν προσπελάσετε το σχήμα.

Για ένα πλήρες παράδειγμα που εντοπίζει ιδιοκτήτες σχήματος και κελιού πίνακα, συμπεριλαμβανομένων σχημάτων που σχετίζονται με κόμβους SmartArt, δείτε το [Search and Replace Text](/slides/el/nodejs-java/search-and-replace-text/).

## **Προσθήκη στήλης σε πλαίσιο κειμένου**

Το Aspose.Slides παρέχει τις μεθόδους [setColumnCount](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) και [setColumnSpacing](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/TextFrameFormat#setColumnSpacing-double-) από την κλάση [TextFrameFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/TextFrameFormat) που σας επιτρέπουν να προσθέσετε στήλες σε πλαίσια κειμένου. Μπορείτε να καθορίσετε τον αριθμό των στηλών σε ένα πλαίσιο κειμένου και να ορίσετε το διάστημα σε σημεία μεταξύ των στηλών.

Αυτός ο κώδικας σε JavaScript δείχνει τη περιγραφείσα λειτουργία: 

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    // Αποκτά την πρώτη διαφάνεια της παρουσίασης
    var slide = pres.getSlides().get_Item(0);
    // Προσθέτει AutoShape με τύπο Rectangle
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // Προσθέτει TextFrame στο Rectangle
    aShape.addTextFrame((("All these columns are limited to be within a single text container -- " + "you can add or delete text and the new or remaining text automatically adjusts ") + "itself to flow within the container. You cannot have text flow from one container ") + "to other though -- we told you PowerPoint's column options for text are limited!");
    // Αποκτά τη μορφή κειμένου του TextFrame
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

Το Aspose.Slides for Node.js via Java παρέχει τη μέθοδο [setColumnCount](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) από την κλάση [TextFrameFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/TextFrameFormat) που σας επιτρέπει να προσθέσετε στήλες σε πλαίσια κειμένου. Μέσω αυτής της ιδιότητας, μπορείτε να καθορίσετε τον επιθυμητό αριθμό στηλών σε ένα πλαίσιο κειμένου.

Αυτός ο κώδικας JavaScript σας δείχνει πώς να προσθέσετε μια στήλη μέσα σε ένα πλαίσιο κειμένου:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const assert = require("assert");

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
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnCount(), 2);
        // Το διάστημα μεταξύ των στηλών δεν ορίστηκε ποτέ, γι' αυτό εμφανίζεται ως NaN.
        assert.ok(Number.isNaN(autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing()));
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
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnCount(), 2);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing(), 20);
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
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnCount(), 3);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing(), 15);
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

Το Aspose.Slides σας επιτρέπει να αλλάξετε ή να ενημερώσετε το κείμενο που περιέχεται σε ένα πλαίσιο κειμένου ή όλο το κείμενο που περιέχεται σε μια παρουσία.

Αυτός ο κώδικας JavaScript επιδεικνύει μια λειτουργία όπου όλο το κείμενο σε μια παρουσία ενημερώνεται ή αλλάζει:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation("text.pptx");
try {
    for (let s = 0; s < pres.getSlides().size(); s++) {
        let slide = pres.getSlides().get_Item(s);
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            // Ελέγχει αν το σχήμα υποστηρίζει πλαίσιο κειμένου (IAutoShape).
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                var autoShape = shape;
                // Επανάληψη στις παραγράφους του πλαισίου κειμένου
                for (let j = 0; j < autoShape.getTextFrame().getParagraphs().getCount(); j++) {
                    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(j);
                    // Επανάληψη σε κάθε τμήμα της παραγράφου
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

Μπορείτε να εισάγετε έναν σύνδεσμο μέσα σε ένα πλαίσιο κειμένου. Όταν κάνετε κλικ στο πλαίσιο κειμένου, οι χρήστες οδηγούνται να ανοίξουν τον σύνδεσμο. 

Για να προσθέσετε ένα πλαίσιο κειμένου που περιέχει σύνδεσμο, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης `Presentation`. 
2. Αποκτήστε μια αναφορά για την πρώτη διαφάνεια στη νεοδημιουργημένη παρουσία. 
3. Προσθέστε ένα αντικείμενο `AutoShape` με `ShapeType` ορισμένο ως `Rectangle` σε καθορισμένη θέση στη διαφάνεια και αποκτήστε μια αναφορά του νεοπροστεθειμένου αντικειμένου AutoShape.
4. Προσθέστε ένα `TextFrame` στο αντικείμενο `AutoShape` και ορίστε το κείμενο του πρώτου τμήματός του. Στο παρακάτω παράδειγμα, χρησιμοποιήσαμε αυτό το κείμενο: *Aspose.Slides*
5. Αποκτήστε το `HyperlinkManager` εκείνου του τμήματος μέσω του `PortionFormat` του.
6. Καλέστε τη μέθοδο `setExternalHyperlinkClick` στο `HyperlinkManager` για να προσαρτήσετε τον σύνδεσμο στο τμήμα.
7. Τέλος, γράψτε το αρχείο PPTX μέσω του αντικειμένου `Presentation`. 

Αυτός ο κώδικας JavaScript—μια υλοποίηση των παραπάνω βημάτων—σας δείχνει πώς να προσθέσετε ένα πλαίσιο κειμένου με υπερσύνδεσμο σε μια διαφάνεια:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Δημιουργεί μια παρουσία της κλάσης Presentation που αντιπροσωπεύει ένα PPTX
var pres = new aspose.slides.Presentation();
try {
    // Αποκτά την πρώτη διαφάνεια της παρουσίασης
    var slide = pres.getSlides().get_Item(0);
    // Προσθέτει αντικείμενο AutoShape με τύπο Rectangle
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 150, 50);
    // Μετατρέπει το σ shape σε AutoShape
    var pptxAutoShape = shape;
    // Προσπελαύνει την ιδιότητα ITextFrame που σχετίζεται με το AutoShape
    pptxAutoShape.addTextFrame("");
    var textFrame = pptxAutoShape.getTextFrame();
    // Προσθέτει κάποιο κείμενο στο πλαίσιο
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");
    // Ορίζει το Hyperlink για το κείμενο του τμήματος
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

## **FAQ**

**Ποια είναι η διαφορά μεταξύ πλαίσίου κειμένου και σύμβολο κράτησης κειμένου όταν εργάζεστε με κύριες διαφάνειες;**

Ένα [placeholder](/slides/el/nodejs-java/manage-placeholder/) κληρονομεί το στυλ/θέση από το [master](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/masterslide/) και μπορεί να αντικατασταθεί σε [layouts](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/layoutslide/), ενώ ένα κανονικό πλαίσιο κειμένου είναι ένα ανεξάρτητο αντικείμενο σε μια συγκεκριμένη διαφάνεια και δεν αλλάζει όταν αλλάζετε layouts.

**Πώς μπορώ να εκτελέσω μαζική αντικατάσταση κειμένου σε όλη την παρουσία χωρίς να επηρεάσω το κείμενο εντός γραφημάτων, πινάκων και SmartArt;**

Περιορίστε την επανάληψή σας σε auto‑shapes που έχουν πλαίσια κειμένου και εξαιρέστε ενσωματωμένα αντικείμενα ([charts](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chart/), [tables](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/smartart/)) διασχίζοντας τις συλλογές τους ξεχωριστά ή παραλείποντας αυτούς τους τύπους αντικειμένων.