---
title: Μορφοποίηση Σχημάτων PowerPoint σε JavaScript
linktitle: Μορφοποίηση Σχήματος
type: docs
weight: 20
url: /el/nodejs-java/shape-formatting/
keywords:
- μορφοποίηση σχήματος
- μορφοποίηση γραμμής
- εφέ σκετσού
- γραμμή σχήματος σκετσού
- μορφοποίηση τύπου σύνδεσης
- γέμισμα διαβάθμισης
- γέμισμα προτύπου
- γέμισμα εικόνας
- γέμισμα υφής
- γέμισμα στερεού χρώματος
- διαφάνεια σχήματος
- αποτύπωση σχήματος σε ασπρόμαυρο
- αποτύπωση σχήματος σε αποχρώσεις του γκρι
- περιστροφή σχήματος
- εφέ 3Δ φάρδους
- εφέ 3Δ περιστροφής
- επαναφορά μορφοποίησης
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Μορφοποίηση σχημάτων PowerPoint σε JavaScript με χρήση του Aspose.Slides—ορίστε στυλ γεμίσματος, γραμμής και εφέ για αρχεία PPT, PPTX και ODP με ακρίβεια και πλήρη έλεγχο."
---
## **Εισαγωγή**

Στο PowerPoint, μπορείτε να προσθέσετε σχήματα στις διαφάνειες. Καθώς τα σχήματα αποτελούνται από γραμμές, μπορείτε να τα μορφοποιήσετε τροποποιώντας ή εφαρμόζοντας εφέ στα περιγράμματά τους. Επιπλέον, μπορείτε να μορφοποιήσετε τα σχήματα καθορίζοντας ρυθμίσεις που ελέγχουν πώς γεμίζουν τα εσωτερικά τους.

![μορφοποίηση-σχήματος-powerpoint](format-shape-powerpoint.png)

Το Aspose.Slides για Node.js μέσω Java παρέχει κλάσεις και μεθόδους που σας επιτρέπουν να μορφοποιήσετε σχήματα χρησιμοποιώντας τις ίδιες επιλογές που διατίθενται στο PowerPoint.

## **Μορφοποίηση Γραμμών**

Με το Aspose.Slides, μπορείτε να ορίσετε προσαρμοσμένο στυλ γραμμής για ένα σχήμα. Τα παρακάτω βήματα περιγράφουν τη διαδικασία:

1. Δημιουργήστε μια εμφάνιση της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το [line style](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/linestyle/) του σχήματος.
1. Ορίστε το πάχος της γραμμής.
1. Ορίστε το [dash style](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/linedashstyle/) της γραμμής.
1. Ορίστε το χρώμα γραμμής για το σχήμα.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
let presentation = new aspose.slides.Presentation();
try {
    // Αποκτήστε την πρώτη διαφάνεια.
    let slide = presentation.getSlides().get_Item(0);

    // Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 75);

    // Αφαιρέστε το γέμισμα από το ορθογώνιο σχήμα.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // Εφαρμόστε μορφοποίηση στις γραμμές του ορθογωνίου.
    shape.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.ThickThin));
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));

    // Ορίστε το χρώμα για τη γραμμή του ορθογωνίου.
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // Αποθηκεύστε το αρχείο PPTX στο δίσκο.
    presentation.save("formatted_lines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Οι μορφοποιημένες γραμμές στην παρουσίαση](formatted-lines.png)

## **Εφαρμογή Σχέδιο Εφέ στις Γραμμές Σχήματος**

Ένα σκετσοειδές εφέ κάνει τη γραμμή του σχήματος να φαίνεται χειρογράφτη. Χρησιμοποιήστε [Shape.getLineFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/) για πρόσβαση στις ρυθμίσεις γραμμής, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/lineformat/) για πρόσβαση στις ρυθμίσεις σκετσου και [SketchFormat.setSketchType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sketchformat/) για επιλογή τιμής από την απαρίθμηση [LineSketchType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/linesketchtype/).

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);

    // Πρόσβαση στη μορφή γραμμής του σχήματος και στη μορφή σκετσού του.
    let sketchFormat = shape.getLineFormat().getSketchFormat();

    // Εφαρμόστε ένα εφέ σκετσού.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.Curved);

    // Διαβάστε το εφέ σκετσού που έχει οριστεί άμεσα στο σχήμα.
    let explicitSketchType = sketchFormat.getSketchType();
    console.log("Explicit sketch type: " + explicitSketchType);

    // Αφαιρέστε το εφέ σκετσού.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.None);
} finally {
    presentation.dispose();
}
```

Η τιμή που επιστρέφει το [SketchFormat.getSketchType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sketchformat/) αντιπροσωπεύει τη ρύθμιση που έχει οριστεί άμεσα στο σχήμα. Εάν η μορφοποίηση γραμμής μπορεί να κληρονομηθεί από θέμα, κύρια διαφάνεια ή διάταξη, χρησιμοποιήστε το [LineFormat.getEffective](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/lineformat/), καλέστε `getSketchFormat` στο επιστρεφόμενο αντικείμενο και στη συνέχεια καλέστε τη μέθοδο `getSketchType`. Η αποτελεσματική τιμή αντανακλά τη μορφοποίηση που εφαρμόζεται πραγματικά μετά την επίλυση της κληρονομίας:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    let lineFormat = shape.getLineFormat();

    let explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    let effectiveLineFormat = lineFormat.getEffective();
    let effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    console.log("Explicit sketch type: " + explicitSketchType);
    console.log("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **Μορφοποίηση Στυλ Συνδέσεων**

Οι τρεις επιλογές τύπου σύνδεσης είναι:

* Στρογγυλό
* Γωνιακό
* Φάρδος

Από προεπιλογή, όταν το PowerPoint συνδέει δύο γραμμές με γωνία (π.χ. στη γωνία ενός σχήματος), χρησιμοποιεί τη ρύθμιση **Στρογγυλό**. Ωστόσο, εάν σχεδιάζετε σχήμα με οξές γωνίες, ίσως προτιμήσετε την επιλογή **Γωνιακό**.

![Το στυλ σύνδεσης στην παρουσίαση](join-style-powerpoint.png)

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
let presentation = new aspose.slides.Presentation();
try {
    // Αποκτήστε την πρώτη διαφάνεια.
    let slide = presentation.getSlides().get_Item(0);

    // Προσθέστε τρία αυτόματα σχήματα τύπου Rectangle.
    let shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 75);
    let shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 20, 150, 75);
    let shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 135, 150, 75);

    // Ορίστε το χρώμα γεμίσματος για κάθε ορθογώνιο σχήμα.
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

    // Ορίστε το πάχος της γραμμής.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // Ορίστε το χρώμα για τη γραμμή κάθε ορθογωνίου.
    shape1.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape2.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape3.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // Ορίστε το στυλ σύνδεσης.
    shape1.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Miter));
    shape2.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Bevel));
    shape3.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Round));

    // Προσθέστε κείμενο σε κάθε ορθογώνιο.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // Αποθηκεύστε το αρχείο PPTX στο δίσκο.
    presentation.save("join_styles.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Γέμισμα Διαβάθμισης**

Στο PowerPoint, το Γέμισμα Διαβάθμισης είναι μια επιλογή μορφοποίησης που σας επιτρέπει να εφαρμόσετε μια συνεχόμενη ανάμειξη χρωμάτων σε ένα σχήμα. Για παράδειγμα, μπορείτε να εφαρμόσετε δύο ή περισσότερα χρώματα με τέτοιο τρόπο ώστε το ένα να εξασθενίζει σταδιακά στο άλλο.

Ακολουθήστε τα βήματα για να εφαρμόσετε γέμισμα διαβάθμισης σε σχήμα χρησιμοποιώντας το Aspose.Slides:

1. Δημιουργήστε μια εμφάνιση της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/filltype/) του σχήματος σε `Gradient`.
1. Προσθέστε τα δύο προτιμώμενα χρώματά σας με καθορισμένες θέσεις χρησιμοποιώντας τις μεθόδους `add` της συλλογής gradient stop που εκτίθενται από την κλάση [GradientFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/gradientformat/).
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
let presentation = new aspose.slides.Presentation();
try {
    // Αποκτήστε την πρώτη διαφάνεια.
    let slide = presentation.getSlides().get_Item(0);

    // Προσθέστε ένα αυτόματο σχήμα τύπου Ellipse.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);

    // Εφαρμόστε μορφοποίηση διαβάθμισης στην έλλειψη.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));

    // Ορίστε την κατεύθυνση της διαβάθμισης.
    shape.getFillFormat().getGradientFormat().setGradientDirection(aspose.slides.GradientDirection.FromCorner2);

    // Προσθέστε δύο σημεία διαβάθμισης.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, aspose.slides.PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0, aspose.slides.PresetColor.Red);

    // Αποθηκεύστε το αρχείο PPTX στο δίσκο.
    presentation.save("gradient_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Η έλλειψη με γέμισμα διαβάθμισης](gradient-fill.png)

## **Γέμισμα Σχεδίου**

Στο PowerPoint, το Γέμισμα Σχεδίου είναι μια επιλογή μορφοποίησης που σας επιτρέπει να εφαρμόσετε ένα δίχρωμο σχέδιο—όπως σημεία, λωρίδες, διασταυρώσεις ή σκαλοπάτια—σε ένα σχήμα. Μπορείτε να επιλέξετε προσαρμοσμένα χρώματα για το προσκήνιο και το παρασκήνιο του σχεδίου.

Το Aspose.Slides προσφέρει πάνω από 45 προ‑ορισμένα στυλ σχεδίων που μπορείτε να εφαρμόσετε σε σχήματα για να ενισχύσετε την οπτική ελκυστικότητα των παρουσιάσεών σας. Ακόμη και αφού επιλέξετε ένα προ‑ορισμένο σχέδιο, μπορείτε να καθορίσετε τα ακριβή χρώματα που θα χρησιμοποιηθούν.

Ακολουθήστε τα βήματα για να εφαρμόσετε γέμισμα σχεδίου σε σχήμα χρησιμοποιώντας το Aspose.Slides:

1. Δημιουργήστε μια εμφάνιση της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/filltype/) του σχήματος σε `Pattern`.
1. Επιλέξτε ένα στυλ σχεδίου από τις προ‑ορισμένες επιλογές.
1. Ορίστε το [Background Color](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/patternformat/#getBackColor--) του σχεδίου.
1. Ορίστε το [Foreground Color](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/patternformat/#getForeColor--) του σχεδίου.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
let presentation = new aspose.slides.Presentation();
try {
    // Αποκτήστε την πρώτη διαφάνεια.
    let slide = presentation.getSlides().get_Item(0);

    // Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Ορίστε τον τύπο γεμίσματος σε Pattern.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));

    // Ορίστε το στυλ του προτύπου.
    shape.getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.Trellis));

    // Ορίστε τα χρώματα φόντου και προσκηνίου του προτύπου.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // Αποθηκεύστε το αρχείο PPTX στο δίσκο.
    presentation.save("pattern_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Το ορθογώνιο με γέμισμα σχεδίου](pattern-fill.png)

## **Γέμισμα Εικόνας**

Στο PowerPoint, το Γέμισμα Εικόνας είναι μια επιλογή μορφοποίησης που σας επιτρέπει να εισάγετε μια εικόνα μέσα σε ένα σχήμα—χρησιμοποιώντας ουσιαστικά την εικόνα ως φόντο του σχήματος.

Ακολουθήστε τα βήματα για να χρησιμοποιήσετε το Aspose.Slides ώστε να εφαρμόσετε γέμισμα εικόνας σε σχήμα:

1. Δημιουργήστε μια εμφάνιση της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/filltype/) του σχήματος σε `Picture`.
1. Ορίστε τη λειτουργία γέμισματος εικόνας σε `Tile` (ή άλλη προτιμώμενη λειτουργία).
1. Δημιουργήστε ένα αντικείμενο [PPImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ppimage/) από την εικόνα που θέλετε να χρησιμοποιήσετε.
1. Μεταβιβάστε την εικόνα στη μέθοδο `ISlidesPicture.setImage`.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

![Η εικόνα λωτού](lotus.png)

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
let presentation = new aspose.slides.Presentation();
try {
    // Αποκτήστε την πρώτη διαφάνεια.
    let slide = presentation.getSlides().get_Item(0);

    // Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Ορίστε τον τύπο γεμίσματος σε Picture.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // Ορίστε τη λειτουργία γεμίσματος εικόνας.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Tile);

    // Φορτώστε μια εικόνα και προσθέστε την στους πόρους της παρουσίασης.
    let image = aspose.slides.Images.fromFile("lotus.png");
    let picture = presentation.getImages().addImage(image);
    image.dispose();

    // Ορίστε την εικόνα.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Αποθηκεύστε το αρχείο PPTX στο δίσκο.
    presentation.save("picture_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Το σχήμα με γέμισμα εικόνας](picture-fill.png)

### **Πλακάκια Εικόνας ως Υφή**

Αν θέλετε να ορίσετε μια εικόνα σε πλακάκια ως υφή και να προσαρμόσετε τη συμπεριφορά πλαμάρας, μπορείτε να χρησιμοποιήσετε τις παρακάτω μεθόδους της κλάσης [PictureFillFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): Ορίζει τη λειτουργία γεμίσματος εικόνας—είτε `Tile` είτε `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): Καθορίζει την ευθυγράμμιση των πλακιδίων μέσα στο σχήμα.
- [setTileFlip](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): Ελέγχει αν το πλακίδιο θα αντιστραφεί οριζόντια, κάθετα ή και τα δύο.
- [setTileOffsetX](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): Ορίζει τη οριζόντια μετατόπιση του πλακιδίου (σε points) από την αρχή του σχήματος.
- [setTileOffsetY](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): Ορίζει τη κάθετη μετατόπιση του πλακιδίου (σε points) από την αρχή του σχήματος.
- [setTileScaleX](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): Καθορίζει την οριζόντια κλίμακα του πλακιδίου ως ποσοστό.
- [setTileScaleY](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): Καθορίζει την κάθετη κλίμακα του πλακιδίου ως ποσοστό.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
let presentation = new aspose.slides.Presentation();
try {
    // Αποκτήστε την πρώτη διαφάνεια.
    let firstSlide = presentation.getSlides().get_Item(0);

    // Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
    let shape = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 190, 95);

    // Ορίστε τον τύπο γεμίσματος του σχήματος σε Picture.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // Φορτώστε την εικόνα και προσθέστε την στους πόρους της παρουσίασης.
    let sourceImage = aspose.slides.Images.fromFile("lotus.png");
    let presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Αναθέστε την εικόνα στο σχήμα.
    let pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Διαμορφώστε τη λειτουργία γεμίσματος εικόνας και τις ιδιότητες πλακιδίων.
    pictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.BottomRight));
    pictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipBoth);

    // Αποθηκεύστε το αρχείο PPTX στο δίσκο.
    presentation.save("tile.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Οι επιλογές πλακιδίων](tile-options.png)

## **Στερεόχρωμο Γέμισμα**

Στο PowerPoint, το Στερεόχρωμο Γέμισμα είναι μια επιλογή μορφοποίησης που γεμίζει ένα σχήμα με ένα ενιαίο, ομοιόμορφο χρώμα. Αυτό το απλό χρώμα φόντου εφαρμόζεται χωρίς διαβαθμίσεις, υφές ή σχέδια.

Για να εφαρμόσετε στερεόχρωμο γέμισμα σε σχήμα χρησιμοποιώντας το Aspose.Slides, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια εμφάνιση της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/filltype/) του σχήματος σε `Solid`.
1. Αναθέστε το προτιμώμενο χρώμα γέμισμα στο σχήμα.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
let presentation = new aspose.slides.Presentation();
try {
    // Αποκτήστε την πρώτη διαφάνεια.
    let slide = presentation.getSlides().get_Item(0);

    // Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Ορίστε τον τύπο γεμίσματος σε Solid.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));

    // Ορίστε το χρώμα γεμίσματος.
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // Αποθηκεύστε το αρχείο PPTX στο δίσκο.
    presentation.save("solid_color_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Το σχήμα με στερεόχρωμο γέμισμα](solid-color-fill.png)

## **Ορισμός Διαφάνειας**

Στο PowerPoint, όταν εφαρμόζετε στερεόχρωμο, διαβαθμισμένο, εικόνα ή υφή γέμισμα σε σχήματα, μπορείτε επίσης να ορίσετε επίπεδο διαφάνειας για να ελέγξετε την αδιαφάνεια του γεμίσματος. Μια υψηλότερη τιμή διαφάνειας κάνει το σχήμα περισσότερο διαφανές, επιτρέποντας στο φόντο ή στα υποκείμενα αντικείμενα να φαίνονται εν μέρει.

Το Aspose.Slides σας επιτρέπει να ορίσετε το επίπεδο διαφάνειας προσαρμόζοντας την τιμή alpha στο χρώμα που χρησιμοποιείται για το γέμισμα. Ακολουθήστε τα βήματα:

1. Δημιουργήστε μια εμφάνιση της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/filltype/) σε `Solid`.
1. Χρησιμοποιήστε το `Color` για να ορίσετε ένα χρώμα με διαφάνεια (το συστατικό `alpha` ελέγχει τη διαφάνεια).
1. Αποθηκεύστε την παρουσίαση.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
let presentation = new aspose.slides.Presentation();
try {
    // Αποκτήστε την πρώτη διαφάνεια.
    let slide = presentation.getSlides().get_Item(0);

    // Προσθέστε ένα στερεό ορθογώνιο αυτόματο σχήμα.
    let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Προσθέστε ένα διαφανές ορθογώνιο αυτόματο σχήμα πάνω από το στερεό σχήμα.
    let transparentShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    transparentShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 255, 0, 204));

    // Αποθηκεύστε το αρχείο PPTX στο δίσκο.
    presentation.save("shape_transparency.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Το διαφανές σχήμα](shape-transparency.png)

## **Περιστροφή Σχημάτων**

Το Aspose.Slides σας επιτρέπει να περιστρέψετε σχήματα σε παρουσιάσεις PowerPoint. Αυτό μπορεί να είναι χρήσιμο όταν τοποθετείτε οπτικά στοιχεία με συγκεκριμένη ευθυγράμμιση ή σχεδιαστικές απαιτήσεις.

Για να περιστρέψετε ένα σχήμα σε μια διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια εμφάνιση της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε την ιδιότητα περιστροφής του σχήματος στην επιθυμητή γωνία.
1. Αποθηκεύστε την παρουσίαση.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
let presentation = new aspose.slides.Presentation();
try {
    // Αποκτήστε την πρώτη διαφάνεια.
    let slide = presentation.getSlides().get_Item(0);

    // Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Περιστρέψτε το σχήμα κατά 5 μοίρες.
    shape.setRotation(5);

    // Αποθηκεύστε το αρχείο PPTX στο δίσκο.
    presentation.save("shape_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Η περιστροφή του σχήματος](shape-rotation.png)

## **Προσθήκη 3Δ Εφέ Φάρδους**

Το Aspose.Slides σας επιτρέπει να εφαρμόσετε εφέ 3Δ φάρδους σε σχήματα διαμορφώνοντας τις ιδιότητες του [ThreeDFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/threedformat/).

Για να προσθέσετε εφέ 3Δ φάρδους σε σχήμα, ακολουθήστε τα εξής βήματα:

1. Δημιουργήστε μια εμφάνιση της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/) στη διαφάνεια.
1. Διαμορφώστε το [ThreeDFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/threedformat/) του σχήματος για να ορίσετε τις ρυθμίσεις φάρδους.
1. Αποθηκεύστε την παρουσίαση.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Προσθέστε ένα σχήμα στη διαφάνεια.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    shape.getLineFormat().setWidth(2.0);

    // Ορίστε τις ιδιότητες ThreeDFormat του σχήματος.
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);

    // Αποθηκεύστε την παρουσίαση ως αρχείο PPTX.
    presentation.save("3D_bevel_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Το 3Δ εφέ φάρδους](3D-bevel-effect.png)

## **Προσθήκη 3Δ Εφέ Περιστροφής**

Το Aspose.Slides σας επιτρέπει να εφαρμόσετε εφέ 3Δ περιστροφής σε σχήματα διαμορφώνοντας τις ιδιότητες του [ThreeDFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/threedformat/).

Για να εφαρμόσετε 3Δ περιστροφή σε σχήμα:

1. Δημιουργήστε μια εμφάνιση της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/) στη διαφάνεια.
1. Χρησιμοποιήστε τα [setCameraType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/camera/#setCameraType) και [setLightType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/lightrig/#setLightType) για να ορίσετε την 3Δ περιστροφή.
1. Αποθηκεύστε την παρουσίαση.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);

    // Αποθηκεύστε την παρουσίαση ως αρχείο PPTP.
    presentation.save("3D_rotation_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Το 3Δ εφέ περιστροφής](3D-rotation-effect.png)

## **Έλεγχος Ασπρόμαυρης Απόδοσης για Σχήματα**

Η μέθοδος [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) καθορίζει πώς αποδίδεται ένα μεμονωμένο σχήμα όταν μια παρουσίαση προβολίζεται ή επεξεργάζεται σε ασπρόμαυρη λειτουργία. Δεν ενεργοποιεί αυτόματα την ασπρόμαυρη προβολή και δεν αλλάζει το γέμισμα, τη γραμμή ή άλλη μορφοποίηση του σχήματος σε κανονική λειτουργία χρώματος.

Χρησιμοποιήστε μια τιμή από την απαρίθμηση [BlackWhiteMode](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/blackwhitemode/) για να επιλέξετε την επιθυμητή συμπεριφορά. Για παράδειγμα, το `Automatic` αφήνει την εφαρμογή απόφασης να επιλέξει τη μετατροπή, τα `Gray` και `LightGray` χρησιμοποιούν γκρι απόχρωση, το `BlackWhite` χρησιμοποιεί μόνο μαύρο και λευκό, τα `Black` και `White` επιβάλλουν ένα ενιαίο χρώμα, το `Color` διατηρεί το κανονικό χρώμα, και το `Hidden` αποκρύπτει το σχήμα σε ασπρόμαυρη λειτουργία. Το `NotDefined` σημαίνει ότι δεν έχει οριστεί λειτουργία σε επίπεδο σχήματος.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));

    // Διατηρήστε το πορτοκαλί γέμισμα σε κατάσταση χρώματος, αλλά αποδώστε το σχήμα με γκρι χρωματισμό στη λειτουργία ασπρόμαυρου.
    shape.setBlackWhiteMode(java.newByte(aspose.slides.BlackWhiteMode.Gray));

    presentation.save("shape_black_white_mode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Επαναφορά Μορφοποίησης**

Ο παρακάτω κώδικας JavaScript δείχνει πώς να επαναφέρετε τη μορφοποίηση μιας διαφάνειας και να επαναφέρετε τη θέση, το μέγεθος και τη μορφοποίηση όλων των σχημάτων με placeholders στο [LayoutSlide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/layoutslide/) στις προεπιλογές τους:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        // Επαναφορά κάθε σχήματος στη διαφάνεια που έχει θέση κράτησης στη διάταξη.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Επηρεάζει η μορφοποίηση σχήματος το τελικό μέγεθος του αρχείου παρουσίασης;**

Μόνο ελαφρώς. Οι ενσωματωμένες εικόνες και τα μέσα καταλαμβάνουν το μεγαλύτερο μέρος του χώρου του αρχείου, ενώ οι παράμετροι σχήματος όπως χρώματα, εφέ και διαβαθμίσεις αποθηκεύονται ως μεταδεδομένα και δεν προσθέτουν ουσιαστικά επιπλέον μέγεθος.

**Πώς μπορώ να εντοπίσω σχήματα σε μια διαφάνεια που έχουν ταυτόσημη μορφοποίηση ώστε να τα ομαδοποιήσω;**

Συγκρίνετε τις κύριες ιδιότητες μορφοποίησης κάθε σχήματος—γέμισμα, γραμμή και ρυθμίσεις εφέ. Εάν όλες οι αντίστοιχες τιμές ταιριάζουν, θεωρήστε ότι τα στυλ είναι τα ίδια και ομαδοποιήστε λογικά αυτά τα σχήματα, κάτι που απλοποιεί τη μελλοντική διαχείριση στυλ.

**Μπορώ να αποθηκεύσω ένα σύνολο προσαρμοσμένων στυλ σχήματος σε ξεχωριστό αρχείο για επαναχρησιμοποίηση σε άλλες παρουσιάσεις;**

Ναι. Αποθηκεύστε δείγματα σχημάτων με τα επιθυμητά στυλ σε ένα πρότυπο αρχείο διαφάνειας ή σε αρχείο .POTX. Όταν δημιουργείτε νέα παρουσίαση, ανοίξτε το πρότυπο, κλωνοποιήστε τα στυλσχημάτων που χρειάζεστε και εφαρμόστε ξανά τη μορφοποίησή τους όπου απαιτείται.