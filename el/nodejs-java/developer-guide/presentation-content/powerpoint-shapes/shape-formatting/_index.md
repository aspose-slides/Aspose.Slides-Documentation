---
title: Διαμόρφωση Σχημάτων PowerPoint σε JavaScript
linktitle: Διαμόρφωση Σχήματος
type: docs
weight: 20
url: /el/nodejs-java/shape-formatting/
keywords:
- μορφοποίηση σχήματος
- μορφοποίηση γραμμής
- εφέ σκίτσου
- γραμμή σχήματος σκίτσου
- μορφοποίηση στυλ σύνδεσης
- γέμισμα διαβάθμισης
- γέμισμα μοτίβου
- γέμισμα εικόνας
- γέμισμα υφής
- γέμισμα στερεού χρώματος
- διαφάνεια σχήματος
- ασπρόμαυρη απόδοση σχήματος
- απόδοση σχήματος σε γκρι κλίμακα
- περιστροφή σχήματος
- εφέ 3d λοβού
- εφέ 3d περιστροφής
- επαναφορά μορφοποίησης
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Διαμορφώστε τα σχήματα του PowerPoint σε JavaScript χρησιμοποιώντας το Aspose.Slides—ορίστε στυλ γεμίσματος, γραμμής και εφέ για αρχεία PPT, PPTX και ODP με ακρίβεια και πλήρη έλεγχο."
---
## **Εισαγωγή**

Στο PowerPoint, μπορείτε να προσθέσετε σχήματα στις διαφάνειες. Καθώς τα σχήματα αποτελούνται από γραμμές, μπορείτε να τα μορφοποιήσετε τροποποιώντας ή εφαρμόζοντας εφέ στα περιγράμματά τους. Επιπλέον, μπορείτε να μορφοποιήσετε τα σχήματα καθορίζοντας ρυθμίσεις που ελέγχουν πώς γεμίζουν τα εσωτερικά τους.

![μορφοποίηση σχήματος PowerPoint](format-shape-powerpoint.png)

Το Aspose.Slides για Node.js μέσω Java παρέχει κλάσεις και μεθόδους που σας επιτρέπουν να μορφοποιήσετε σχήματα χρησιμοποιώντας τις ίδιες επιλογές που διατίθενται στο PowerPoint.

## **Μορφοποίηση Γραμμών**

Χρησιμοποιώντας το Aspose.Slides, μπορείτε να ορίσετε προσαρμοσμένο στυ λ γραμμής για ένα σχήμα. Τα παρακάτω βήματα περιγράφουν τη διαδικασία:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το [line style](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linestyle/) του σχήματος.
1. Ορίστε το πάχος της γραμμής.
1. Ορίστε το [dash style](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linedashstyle/) της γραμμής.
1. Ορίστε το χρώμα της γραμμής για το σχήμα.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο παρακάτω κώδικας δείχνει πώς να μορφοποιήσετε ένα ορθογώνιο `AutoShape`:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Δημιουργεί την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
let presentation = new aspose.slides.Presentation();
try {
    // Λάβετε την πρώτη διαφάνεια.
    let slide = presentation.getSlides().get_Item(0);

    // Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 75);

    // Αφαιρέστε το γέμισμα από το σχήμα Rectangle.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // Εφαρμόστε μορφοποίηση στις γραμμές του Rectangle.
    shape.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.ThickThin));
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));

    // Ορίστε το χρώμα για τη γραμμή του Rectangle.
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

## **Εφαρμογή Εφέ Σχεδίων στις Γραμμές Σχήματος**

Ένα εφέ σκίτσου κάνει τη γραμμή ενός σχήματος να φαίνεται σχεδιασμένη με το χέρι. Χρησιμοποιήστε το [Shape.getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) για να αποκτήσετε πρόσβαση στις ρυθμίσεις της γραμμής, το [LineFormat.getSketchFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/) για να αποκτήσετε πρόσβαση στις ρυθμίσεις του σκίτσου, και το [SketchFormat.setSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sketchformat/) για να επιλέξετε μια τιμή από την απαρίθμηση [LineSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/).

Ο παρακάτω κώδικας JavaScript δείχνει πώς να εφαρμόσετε το εφέ [LineSketchType.Curved](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/) , να διαβάσετε την ρητά καθορισμένη τιμή, και να αφαιρέσετε το εφέ με το [LineSketchType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/) :

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);

    // Πρόσβαση στη μορφοποίηση γραμμής του σχήματος και στη μορφή σκίτσου.
    let sketchFormat = shape.getLineFormat().getSketchFormat();

    // Εφαρμογή εφέ σκίτσου.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.Curved);

    // Ανάγνωση του εφέ σκίτσου που έχει οριστεί άμεσα στο σχήμα.
    let explicitSketchType = sketchFormat.getSketchType();
    console.log("Explicit sketch type: " + explicitSketchType);

    // Αφαίρεση του εφέ σκίτσου.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.None);
} finally {
    presentation.dispose();
}
```

Η τιμή που επιστρέφει το [SketchFormat.getSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sketchformat/) αντιπροσωπεύει τη ρύθμιση που έχει οριστεί άμεσα στο σχήμα. Εάν η μορφοποίηση της γραμμής μπορεί να κληθεί από θέμα, κύρια διαφάνεια ή διαφάνεια διάταξης, χρησιμοποιήστε το [LineFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/), καλέστε `getSketchFormat` στο επιστρεφόμενο αντικείμενο και στη συνέχεια καλέστε τη μέθοδό του `getSketchType`. Η αποτελεσματική τιμή αντικατοπτρίζει τη μορφοποίηση που εφαρμόζεται πράγματι μετά την επίλυση της κληρονομικότητας:

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

## **Μορφοποίηση Στυλ Σύνδεσης**

Αυτές είναι οι τρεις επιλογές τύπου σύνδεσης:

* Στρογγυλή
* Οξύγωνη
* Κωνική

Από προεπιλογή, όταν το PowerPoint ενώνει δύο γραμμές με γωνία (π.χ. στη γωνία ενός σχήματος), χρησιμοποιεί τη ρύθμιση **Στρογγυλή**. Ωστόσο, εάν σχεδιάζετε σχήμα με οξυγώνιες γωνίες, μπορεί να προτιμήσετε την επιλογή **Οξύγωνη**.

![Το στυλ σύνδεσης στην παρουσίαση](join-style-powerpoint.png)

Ο παρακάτω κώδικας JavaScript δείχνει πώς τρία ορθογώνια (όπως φαίνονται στην εικόνα παραπάνω) δημιουργήθηκαν χρησιμοποιώντας τις ρυθμίσεις τύπου σύνδεσης Oξύγωνη, Κωνική και Στρογγυλή:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Δημιουργεί την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
let presentation = new aspose.slides.Presentation();
try {
    // Λάβετε την πρώτη διαφάνεια.
    let slide = presentation.getSlides().get_Item(0);

    // Προσθέστε τρία αυτόματα σχήματα τύπου Rectangle.
    let shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 75);
    let shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 20, 150, 75);
    let shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 135, 150, 75);

    // Ορίστε το χρώμα γεμίσματος για κάθε σχήμα Rectangle.
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

    // Ορίστε το πλάτος της γραμμής.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // Ορίστε το χρώμα για τη γραμμή κάθε Rectangle.
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

    // Προσθέστε κείμενο σε κάθε Rectangle.
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

Στο PowerPoint, το Γέμισμα Διαβάθμισης είναι μια επιλογή μορφοποίησης που σας επιτρέπει να εφαρμόσετε μια συνεχόμενη μίξη χρωμάτων σε ένα σχήμα. Για παράδειγμα, μπορείτε να εφαρμόσετε δύο ή περισσότερα χρώματα με τέτοιο τρόπο ώστε το ένα να εξασθένει σταδιακά στο άλλο.

Ακολουθεί η διαδικασία για την εφαρμογή γέμισης διαβάθμισης σε σχήμα χρησιμοποιώντας το Aspose.Slides:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
2. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
3. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) στη διαφάνεια.
4. Ορίστε το [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) του σχήματος σε `Gradient`.
5. Προσθέστε τα δύο προτιμώμενα χρώματά σας με καθορισμένες θέσεις χρησιμοποιώντας τις μεθόδους `add` της συλλογής σημείων διαβάθμισης που εκθέτει η κλάση [GradientFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/) .
6. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Δημιουργεί την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
let presentation = new aspose.slides.Presentation();
try {
    // Λάβετε την πρώτη διαφάνεια.
    let slide = presentation.getSlides().get_Item(0);

    // Προσθέστε ένα αυτόματο σχήμα τύπου Ellipse.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);

    // Εφαρμόστε μορφοποίηση διαβάθμισης στην Ellipse.
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

![Το έλλειψο με γέμισμα διαβάθμισης](gradient-fill.png)

Εάν μια διαβάθμιση φαίνεται διαφορετική σε μια εξαγόμενη εικόνα από ό,τι στο PowerPoint, δείτε το [Επιλέξτε Στυλ Απόδοσης Διαβάθμισης](/slides/el/nodejs-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Μπορείτε να επιλέξετε στυλ απόδοσης χωρίς να αλλάξετε τη διαβάθμιση που αποθηκεύεται στην παρουσίαση.

## **Γέμισμα Σχεδίου**

Στο PowerPoint, το Γέμισμα Σχεδίου είναι μια επιλογή μορφοποίησης που σας επιτρέπει να εφαρμόσετε σχεδίαση δύο χρωμάτων — όπως κουκίδες, λωρίδες, διαγώνιες λωρίδες ή τετράγωνα — σε ένα σχήμα. Μπορείτε να επιλέξετε προσαρμοσμένα χρώματα για το προσκήνιο και το φόντο του σχεδίου.

Το Aspose.Slides παρέχει πάνω από 45 προεγκατεστημένα στυλ σχεδίου που μπορείτε να εφαρμόσετε σε σχήματα για να ενισχύσετε την οπτική ελκυστικότητα των παρουσιάσεών σας. Ακόμη και μετά την επιλογή προεγκατεστημένου σχεδίου, μπορείτε να καθορίσετε ακριβώς τα χρώματα που θα χρησιμοποιηθούν.

Ακολουθεί ο οδηγός για την εφαρμογή γέμισης σχεδίου σε σχήμα χρησιμοποιώντας το Aspose.Slides:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
2. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
3. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) στη διαφάνεια.
4. Ορίστε το [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) του σχήματος σε `Pattern`.
5. Επιλέξτε ένα στυλ σχεδίου από τις προεγκατεστημένες επιλογές.
6. Ορίστε το [Background Color](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#getBackColor--) του σχεδίου.
7. Ορίστε το [Foreground Color](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#getForeColor--) του σχεδίου.
8. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Δημιουργεί την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
let presentation = new aspose.slides.Presentation();
try {
    // Λάβετε την πρώτη διαφάνεια.
    let slide = presentation.getSlides().get_Item(0);

    // Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Ορίστε τον τύπο γεμίσματος σε Pattern.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));

    // Ορίστε το στυλ του μοτίβου.
    shape.getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.Trellis));

    // Ορίστε τα χρώματα φόντου και προσκηνίου του μοτίβου.
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

Στο PowerPoint, το Γέμισμα Εικόνας είναι μια επιλογή μορφοποίησης που σας επιτρέπει να εισάγετε μια εικόνα μέσα σε ένα σχήμα — χρησιμοποιώντας ουσιαστικά την εικόνα ως φόντο του σχήματος.

Ακολουθούν τα βήματα για να εφαρμόσετε γέμισμα εικόνας σε σχήμα χρησιμοποιώντας το Aspose.Slides:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
2. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
3. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) στη διαφάνεια.
4. Ορίστε το [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) του σχήματος σε `Picture`.
5. Ορίστε τη λειτουργία γέμισματος εικόνας σε `Tile` (ή άλλη προτιμώμενη λειτουργία).
6. Δημιουργήστε ένα αντικείμενο [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) από την εικόνα που θέλετε να χρησιμοποιήσετε.
7. Μεταβιβάστε την εικόνα στη μέθοδο `ISlidesPicture.setImage`.
8. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ας υποθέσουμε ότι έχουμε το αρχείο «lotus.png» με την παρακάτω εικόνα:

![Η εικόνα lotus](lotus.png)

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Δημιουργεί την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
let presentation = new aspose.slides.Presentation();
try {
    // Λάβετε την πρώτη διαφάνεια.
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

### **Πλακίδωση Εικόνας ως Υφή**

Εάν θέλετε να ορίσετε μια πλακιδωμένη εικόνα ως υφή και να προσαρμόσετε τη συμπεριφορά της πλακίδωσης, μπορείτε να χρησιμοποιήσετε τις παρακάτω μεθόδους της κλάσης [PictureFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/) :

- [setPictureFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): Ορίζει το mode γέμισματος εικόνας — είτε `Tile` είτε `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): Καθορίζει τη στοίχιση των πλακιδίων μέσα στο σχήμα.
- [setTileFlip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): Ελέγχει εάν το πλακίδιο θα αναστραφεί οριζόντια, κάθετα ή και τα δύο.
- [setTileOffsetX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): Ορίζει την οριζόντια απόσταση του πλακιδίου (σε πόντους) από το σημείο προέλευσης του σχήματος.
- [setTileOffsetY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): Ορίζει την κάθετη απόσταση του πλακιδίου (σε πόντους) από το σημείο προέλευσης του σχήματος.
- [setTileScaleX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): Ορίζει το οριζόντιο κλίμακα του πλακιδίου ως ποσοστό.
- [setTileScaleY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): Ορίζει το κάθετο κλίμακα του πλακιδίου ως ποσοστό.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Δημιουργεί την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
let presentation = new aspose.slides.Presentation();
try {
    // Λάβετε την πρώτη διαφάνεια.
    let firstSlide = presentation.getSlides().get_Item(0);

    // Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
    let shape = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 190, 95);

    // Ορίστε τον τύπο γεμίσματος του σχήματος σε Picture.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // Φορτώστε την εικόνα και προσθέστε την στους πόρους της παρουσίασης.
    let sourceImage = aspose.slides.Images.fromFile("lotus.png");
    let presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Αντιστοιχίστε την εικόνα στο σχήμα.
    let pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Διαμορφώστε τη λειτουργία γεμίσματος εικόνας και τις ιδιότητες πλακίδωσης.
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

![Οι επιλογές πλακίδωσης](tile-options.png)

## **Γέμισμα Στερεού Χρώματος**

Στο PowerPoint, το Γέμισμα Στερεού Χρώματος είναι μια επιλογή μορφοποίησης που γεμίζει ένα σχήμα με ένα ενιαίο, ομοιόμορφο χρώμα. Αυτό το απλό χρώμα φόντου εφαρμόζεται χωρίς διαβαθμίσεις, υφές ή σχέδια.

Για να εφαρμόσετε γέμισμα στερεού χρώματος σε σχήμα χρησιμοποιώντας το Aspose.Slides, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
2. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
3. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) στη διαφάνεια.
4. Ορίστε το [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) του σχήματος σε `Solid`.
5. Αναθέστε το προτιμώμενο χρώμα γεμίσματος στο σχήμα.
6. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Δημιουργεί την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
let presentation = new aspose.slides.Presentation();
try {
    // Λάβετε την πρώτη διαφάνεια.
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

![Το σχήμα με γέμισμα στερεού χρώματος](solid-color-fill.png)

## **Ορισμός Διαφάνειας**

Στο PowerPoint, όταν εφαρμόζετε γέμισμα στερεού χρώματος, διαβάθμισης, εικόνας ή υφής σε σχήματα, μπορείτε επίσης να ορίσετε ένα επίπεδο διαφάνειας για να ελέγξετε τη διαφάνεια του γεμίσματος. Ένα μεγαλύτερο ποσοστό διαφάνειας κάνει το σχήμα πιο διαυγές, επιτρέποντας στο φόντο ή στα υποκείμενα αντικείμενα να είναι εν μέρει ορατά.

Το Aspose.Slides σας επιτρέπει να ορίσετε το επίπεδο διαφάνειας ρυθμίζοντας την τιμή alpha στο χρώμα που χρησιμοποιείται για το γέμισμα. Δείτε πώς:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
2. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
3. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) στη διαφάνεια.
4. Ορίστε το [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) σε `Solid`.
5. Χρησιμοποιήστε την κλάση `Color` για να ορίσετε ένα χρώμα με διαφάνεια (το συστατικό `alpha` ελέγχει τη διαφάνεια).
6. Αποθηκεύστε την παρουσίαση.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Δημιουργεί την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
let presentation = new aspose.slides.Presentation();
try {
    // Λάβετε την πρώτη διαφάνεια.
    let slide = presentation.getSlides().get_Item(0);

    // Προσθέστε ένα στερεό ορθογώνιο αυτόματο σχήμα.
    let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Προσθέστε ένα διαφανές ορθογώνιο αυτόματο σχήμα επάνω στο στερεό σχήμα.
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

Το Aspose.Slides σας επιτρέπει να περιστρέψετε σχήματα σε παρουσιάσεις PowerPoint. Αυτό μπορεί να είναι χρήσιμο όταν στοιχίζετε οπτικά στοιχεία με συγκεκριμένη στοίχιση ή σχεδιαστικές απαιτήσεις.

Για να περιστρέψετε ένα σχήμα σε μια διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
2. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
3. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) στη διαφάνεια.
4. Ορίστε την ιδιότητα περιστροφής του σχήματος στην επιθυμητή γωνία.
5. Αποθηκεύστε την παρουσίαση.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Δημιουργεί την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
let presentation = new aspose.slides.Presentation();
try {
    // Λάβετε την πρώτη διαφάνεια.
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

## **Προσθήκη 3Δ Εφέ Λοβού**

Το Aspose.Slides επιτρέπει την εφαρμογή 3Δ εφέ λοβού σε σχήματα διαμορφώνοντας τις ιδιότητες του [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/) .

Για να προσθέσετε 3Δ εφέ λοβού σε ένα σχήμα, ακολουθήστε τα βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
2. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
3. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) στη διαφάνεια.
4. Διαμορφώστε το [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/) του σχήματος για να ορίσετε τις ρυθμίσεις λοβού.
5. Αποθηκεύστε την παρουσίαση.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Δημιουργεί ένα στιγμιότυπο της κλάσης Presentation.
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

![Το 3Δ εφέ λοβού](3D-bevel-effect.png)

## **Προσθήκη 3Δ Εφέ Περιστροφής**

Το Aspose.Slides επιτρέπει την εφαρμογή 3Δ εφέ περιστροφής σε σχήματα διαμορφώνοντας τις ιδιότητες του [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/) .

Για την εφαρμογή 3Δ περιστροφής σε σχήμα:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
2. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
3. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) στη διαφάνεια.
4. Χρησιμοποιήστε το [setCameraType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#setCameraType) και το [setLightType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lightrig/#setLightType) για να ορίσετε την 3Δ περιστροφή.
5. Αποθηκεύστε την παρουσίαση.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Δημιουργεί ένα στιγμιότυπο της κλάσης Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);

    // Αποθηκεύστε την παρουσίαση ως αρχείο PPTX.
    presentation.save("3D_rotation_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Το 3Δ εφέ περιστροφής](3D-rotation-effect.png)

## **Έλεγχος Ασπρόμαυρης Απόδοσης για Σχήματα**

Η μέθοδος [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) καθορίζει πώς αποδίδεται ένα μεμονωμένο σχήμα όταν η παρουσίαση εμφανίζεται ή επεξεργάζεται σε ασπρόμαυρη λειτουργία. Δεν ενεργοποιεί την ασπρόμαυρη εμφάνιση από μόνο του και δεν αλλάζει το γέμισμα, τη γραμμή ή άλλες μορφοποιήσεις του σχήματος σε κανονική χρωματική λειτουργία.

Χρησιμοποιήστε μια τιμή από την απαρίθμηση [BlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blackwhitemode/) για να επιλέξετε τη συμπεριφορά. Για παράδειγμα, `Automatic` αφήνει την εφαρμογή απόδοσης να επιλέξει τη μετατροπή, `Gray` και `LightGray` χρησιμοποιούν γκριχρώματα, `BlackWhite` χρησιμοποιεί μόνο μαύρο και λευκό, `Black` και `White` επιβάλλουν ένα ενιαίο χρώμα, `Color` διατηρεί το κανονικό χρώμα, και `Hidden` παραλείπει το σχήμα στην ασπρόμαυρη λειτουργία. `NotDefined` σημαίνει ότι δεν έχει οριστεί λειτουργία σε επίπεδο σχήματος.

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

    // Διατηρήστε το πορτοκαλί γέμισμα σε χρωματική λειτουργία, αλλά απεικονίστε το σχήμα με γκρι χρωματισμό σε ασπρόμαυρη λειτουργία.
    shape.setBlackWhiteMode(java.newByte(aspose.slides.BlackWhiteMode.Gray));

    presentation.save("shape_black_white_mode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Επαναφορά Μορφοποίησης**

Ο παρακάτω κώδικας JavaScript δείχνει πώς να επαναφέρετε τη μορφοποίηση μιας διαφάνειας και να επαναφέρετε τη θέση, το μέγεθος και τη μορφοποίηση όλων των σχημάτων με placeholders στη [LayoutSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslide/) στις προεπιλεγμένες ρυθμίσεις τους:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        // Επαναφορά κάθε σχήματος στη διαφάνεια που έχει placeholder στη διάταξη.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Επηρεάζει η μορφοποίηση των σχημάτων το τελικό μέγεθος του αρχείου παρουσίασης;**

Μόνο ελάχιστα. Οι ενσωματωμένες εικόνες και τα μέσα καταλαμβάνουν το μεγαλύτερο μέρος του χώρου του αρχείου, ενώ οι παράμετροι των σχημάτων όπως χρώματα, εφέ και διαβαθμίσεις αποθηκεύονται ως μεταδεδομένα και δεν προσθέτουν σχεδόν κανένα επιπλέον μέγεθος.

**Πώς μπορώ να εντοπίσω σχήματα σε μια διαφάνεια που μοιράζονται την ίδια μορφοποίηση ώστε να τα ομαδοποιήσω;**

Συγκρίνετε τις βασικές ιδιότητες μορφοποίησης κάθε σχήματος — ρυθμίσεις γεμίσματος, γραμμής και εφέ. Εάν όλες οι αντίστοιχες τιμές ταιριάζουν, θεωρήστε ότι τα στυλ είναι τα ίδια και ομαδοποιήστε λογικά αυτά τα σχήματα, κάτι που απλοποιεί τη διαχείριση στυλ αργότερα.

**Μπορώ να αποθηκεύσω ένα σύνολο προσαρμοσμένων στυλ σχημάτων σε ξεχωριστό αρχείο για επαναχρησιμοποίηση σε άλλες παρουσιάσεις;**

Ναι. Αποθηκεύστε δείγμα σχήματος με τα επιθυμητά στυλ σε μια πρότυπη παρουσίαση ή σε αρχείο .POTX. Όταν δημιουργείτε νέα παρουσίαση, ανοίξτε το πρότυπο, κλωνοποιήστε τα στυλιζεμένα σχήματα που χρειάζεστε και εφαρμόστε ξανά τη μορφοποίησή τους όπου απαιτείται.