---
title: Μορφοποίηση Σχημάτων PowerPoint σε JavaScript
linktitle: Μορφοποίηση Σχημάτων
type: docs
weight: 20
url: /el/nodejs-java/shape-formatting/
keywords:
- μορφοποίηση σχήματος
- μορφοποίηση γραμμής
- μορφοποίηση στυλ σύνδεσης
- γεμίσμα διαβάθμισης
- γεμίσμα σχεδίου
- γεμίσμα εικόνας
- γεμίσμα υφής
- γεμίσμα στερεού χρώματος
- διαφάνεια σχήματος
- περιστροφή σχήματος
- εφέ 3Δ λάβδου
- εφέ 3Δ περιστροφής
- επαναφορά μορφοποίησης
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Μορφοποιήστε σχήματα PowerPoint σε JavaScript χρησιμοποιώντας Aspose.Slides—ορίστε στυλ γεμίσματος, γραμμής και εφέ για αρχεία PPT, PPTX και ODP με ακρίβεια και πλήρη έλεγχο."
---
## **Εισαγωγή**

Στο PowerPoint, μπορείτε να προσθέσετε σχήματα στις διαφάνειες. Δεδομένου ότι τα σχήματα αποτελούνται από γραμμές, μπορείτε να τα μορφοποιήσετε τροποποιώντας ή εφαρμόζοντας εφέ στα περίγραμμα τους. Επιπλέον, μπορείτε να μορφοποιήσετε τα σχήματα καθορίζοντας ρυθμίσεις που ελέγχουν πώς γεμίζει το εσωτερικό τους.

![μορφοποίηση σχήματος PowerPoint](format-shape-powerpoint.png)

Το Aspose.Slides για Node.js μέσω Java παρέχει κλάσεις και μεθόδους που σας επιτρέπουν να μορφοποιήσετε σχήματα χρησιμοποιώντας τις ίδιες επιλογές που διατίθενται στο PowerPoint.

## **Μορφοποίηση Γραμμών**

Χρησιμοποιώντας το Aspose.Slides, μπορείτε να καθορίσετε προσαρμοσμένο στυλ γραμμής για ένα σχήμα. Τα παρακάτω βήματα περιγράφουν τη διαδικασία:

1. Δημιουργήστε ένα στιγμιότυπο της [Παρουσίαση](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) κλάσης.
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το [στυλ γραμμής](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/linestyle/) του σχήματος.
1. Ορίστε το πλάτος της γραμμής.
1. Ορίστε το [στυλ παύλας](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/linedashstyle/) της γραμμής.
1. Ορίστε το χρώμα γραμμής για το σχήμα.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο ακόλουθος κώδικας δείχνει πώς να μορφοποιήσετε ένα ορθογώνιο `AutoShape`:

```js
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
let presentation = new aspose.slides.Presentation();
try {
    // Αποκτήστε την πρώτη διαφάνεια.
    let slide = presentation.getSlides().get_Item(0);

    // Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 75);

    // Ορίστε το χρώμα γεμίσματος για το σχήμα rectangle.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // Εφαρμόστε μορφοποίηση στις γραμμές του rectangle.
    shape.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.ThickThin));
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));

    // Ορίστε το χρώμα για τη γραμμή του rectangle.
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

## **Μορφοποίηση Στυλ Συνένωσης**

Αυτές είναι οι τρεις επιλογές τύπου συνένωσης:

* Στρογγυλό
* Μάτι
* Κωνικό

Από προεπιλογή, όταν το PowerPoint ενώνει δύο γραμμές υπό γωνία (όπως σε γωνία σχήματος), χρησιμοποιεί τη ρύθμιση **Στρογγυλό**. Ωστόσο, εάν δημιουργείτε σχήμα με ακμές, μπορεί να προτιμάτε την επιλογή **Μάτι**.

![Το στυλ συνένωσης στην παρουσίαση](join-style-powerpoint.png)

Ο ακόλουθος κώδικας JavaScript δείχνει πώς δημιουργήθηκαν τρία ορθογώνια (όπως φαίνεται στην εικόνα παραπάνω) χρησιμοποιώντας τις ρυθμίσεις τύπου συνένωσης Μάτι, Κωνικό και Στρογγυλό:

```js
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
let presentation = new aspose.slides.Presentation();
try {
    // Αποκτήστε την πρώτη διαφάνεια.
    let slide = presentation.getSlides().get_Item(0);

    // Προσθέστε τρία αυτόματα σχήματα τύπου Rectangle.
    let shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 75);
    let shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 20, 150, 75);
    let shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 135, 150, 75);

    // Ορίστε το χρώμα γεμίσματος για κάθε σχήμα rectangle.
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

    // Ορίστε το χρώμα για τη γραμμή κάθε rectangle.
    shape1.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape2.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape3.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // Ορίστε το στυλ συνένωσης.
    shape1.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Miter));
    shape2.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Bevel));
    shape3.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Round));

    // Προσθέστε κείμενο σε κάθε rectangle.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // Αποθηκεύστε το αρχείο PPTX στο δίσκο.
    presentation.save("join_styles.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Γραμμική Σχέση**

Στο PowerPoint, η Γραμμική Σχέση είναι μια επιλογή μορφοποίησης που σας επιτρέπει να εφαρμόσετε ένα συνεχές μίξη χρωμάτων σε ένα σχήμα. Για παράδειγμα, μπορείτε να εφαρμόσετε δύο ή περισσότερα χρώματα με τέτοιο τρόπο ώστε το ένα να εξασθενεί σταδιακά προς το άλλο.

Ακολουθήστε τα βήματα για να εφαρμόσετε γραμμική σχέση σε σχήμα χρησιμοποιώντας το Aspose.Slides:

1. Δημιουργήστε ένα στιγμιότυπο της [Παρουσίαση](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) κλάσης.
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/filltype/) του σχήματος σε `Gradient`.
1. Προσθέστε τα δύο επιθυμητά χρώματα με καθορισμένες θέσεις χρησιμοποιώντας τις μεθόδους `add` της συλλογής gradient stop που εκτίθεται από την κλάση [GradientFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/gradientformat/).
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο ακόλουθος κώδικας JavaScript δείχνει πώς να εφαρμόσετε το εφέ γραμμικής σχέσης σε μια έλλειψη:

```js
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
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

    // Προσθέστε δύο στάσεις διαβάθμισης.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, aspose.slides.PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0, aspose.slides.PresetColor.Red);

    // Αποθηκεύστε το αρχείο PPTX στον δίσκο.
    presentation.save("gradient_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Η έλλειψη με γραμμική σχέση](gradient-fill.png)

## **Σχέδιο Σχέσης**

Στο PowerPoint, το Σχέδιο Σχέσης είναι μια επιλογή μορφοποίησης που σας επιτρέπει να εφαρμόσετε ένα σχέδιο δύο χρωμάτων—όπως κουκίδες, λωρίδες, διαγώνιες γραμμές ή σκαλιστά—σε ένα σχήμα. Μπορείτε να επιλέξετε προσαρμοσμένα χρώματα για το προσκήνιο και το παρασκήνιο του σχεδίου.

Το Aspose.Slides προσφέρει πάνω από 45 προεπιλεγμένα στυλ σχεδίου που μπορείτε να εφαρμόσετε σε σχήματα για να βελτιώσετε την οπτική ελκυστικότητα των παρουσιάσεών σας. Ακόμη και μετά την επιλογή ενός προεπιλεγμένου σχεδίου, μπορείτε να καθορίσετε τις ακριβείς χρωματικές τιμές που θα χρησιμοποιηθούν.

Ακολουθήστε τα βήματα για να εφαρμόσετε σχέδιο σε σχήμα χρησιμοποιώντας το Aspose.Slides:

1. Δημιουργήστε ένα στιγμιότυπο της [Παρουσίαση](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) κλάσης.
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/filltype/) του σχήματος σε `Pattern`.
1. Επιλέξτε ένα στυλ σχεδίου από τις προεπιλεγμένες επιλογές.
1. Ορίστε το [Background Color](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/patternformat/#getBackColor--) του σχεδίου.
1. Ορίστε το [Foreground Color](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/patternformat/#getForeColor--) του σχεδίου.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο ακόλουθος κώδικας JavaScript δείχνει πώς να εφαρμόσετε σχέδιο σε ένα ορθογώνιο:

```js
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
let presentation = new aspose.slides.Presentation();
try {
    // Αποκτήστε την πρώτη διαφάνεια.
    let slide = presentation.getSlides().get_Item(0);

    // Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Ορίστε τον τύπο γεμίσματος σε Pattern.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));

    // Ορίστε το στυλ προτύπου.
    shape.getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.Trellis));

    // Ορίστε τα χρώματα φόντου και προσκηνίου του προτύπου.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // Αποθηκεύστε το αρχείο PPTX στον δίσκο.
    presentation.save("pattern_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Το ορθογώνιο με σχέδιο](pattern-fill.png)

## **Σχέση Εικόνας**

Στο PowerPoint, η Σχέση Εικόνας είναι μια επιλογή μορφοποίησης που σας επιτρέπει να εισάγετε μια εικόνα μέσα σε ένα σχήμα—χρησιμοποιώντας την εικόνα ως φόντο του σχήματος.

Ακολουθήστε τα βήματα για να χρησιμοποιήσετε το Aspose.Slides ώστε να εφαρμόσετε σχέση εικόνας σε σχήμα:

1. Δημιουργήστε ένα στιγμιότυπο της [Παρουσίαση](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) κλάσης.
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/filltype/) του σχήματος σε `Picture`.
1. Ορίστε τη λειτουργία σχέσης εικόνας σε `Tile` (ή άλλη προτιμώμενη λειτουργία).
1. Δημιουργήστε ένα αντικείμενο [PPImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ppimage/) από την εικόνα που θέλετε να χρησιμοποιήσετε.
1. Περάστε την εικόνα στη μέθοδο `ISlidesPicture.setImage`.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ας υποθέσουμε ότι έχουμε το αρχείο "lotus.png" με την παρακάτω εικόνα:

![Η εικόνα λωτού](lotus.png)

Ο ακόλουθος κώδικας JavaScript δείχνει πώς να γεμίσετε ένα σχήμα με την εικόνα:

```js
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
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

    // Αποθηκεύστε το αρχείο PPTX στον δίσκο.
    presentation.save("picture_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Το σχήμα με σχέση εικόνας](picture-fill.png)

### **ΤίλΠ Πίνακας Ως Υφή**

Εάν θέλετε να ορίσετε μια επαναλαμβανόμενη εικόνα ως υφή και να προσαρμόσετε τη συμπεριφορά της επανάληψης, μπορείτε να χρησιμοποιήσετε τις ακόλουθες μεθόδους της κλάσης [PictureFillFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): Ορίζει τη λειτουργία σχέσης εικόνας—είτε `Tile` είτε `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): Καθορίζει τη στοίχιση των πλακιδίων εντός του σχήματος.
- [setTileFlip](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): Ελέγχει εάν το πλακίδιο θα αναστραφεί οριζόντια, κάθετα ή και τα δύο.
- [setTileOffsetX](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): Ορίζει την οριζόντια μετατόπιση του πλακιδίου (σε μονάδες) από την αρχή του σχήματος.
- [setTileOffsetY](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): Ορίζει την κάθετη μετατόπιση του πλακιδίου (σε μονάδες) από την αρχή του σχήματος.
- [setTileScaleX](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): Ορίζει την οριζόντια κλίμακα του πλακιδίου ως ποσοστό.
- [setTileScaleY](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): Ορίζει την κάθετη κλίμακα του πλακιδίου ως ποσοστό.

Ο ακόλουθος κώδικας δείχνει πώς να προσθέσετε ένα ορθογώνιο σχήμα με επαναλαμβανόμενη σχέση εικόνας και να διαμορφώσετε τις επιλογές πλακιδίων:

```js
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
let presentation = new aspose.slides.Presentation();
try {
    // Αποκτήστε την πρώτη διαφάνεια.
    let firstSlide = presentation.getSlides().get_Item(0);

    // Προσθέστε ένα αυτόματο σχήμα rectangle.
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

    // Διαμορφώστε τη λειτουργία γεμίσματος εικόνας και τις ιδιότητες επικάλυψης.
    pictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.BottomRight));
    pictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipBoth);

    // Αποθηκεύστε το αρχείο PPTX στον δίσκο.
    presentation.save("tile.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Οι επιλογές πλακιδίων](tile-options.png)

## **Συμπλήρωση Σταθερού Χρώματος**

Στο PowerPoint, η Συμπλήρωση Σταθερού Χρώματος είναι μια επιλογή μορφοποίησης που γεμίζει ένα σχήμα με ένα ενιαίο, ομοιόμορφο χρώμα. Αυτό το απλό χρώμα φόντου εφαρμόζεται χωρίς γραμμικές σχέσεις, υφές ή σχέδια.

Για να εφαρμόσετε μια συμπλήρωση σταθερού χρώματος σε σχήμα χρησιμοποιώντας το Aspose.Slides, ακολουθήστε τα βήματα:

1. Δημιουργήστε ένα στιγμιότυπο της [Παρουσίαση](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) κλάσης.
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/filltype/) του σχήματος σε `Solid`.
1. Αναθέστε το επιθυμητό χρώμα συμπλήρωσης στο σχήμα.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο ακόλουθος κώδικας JavaScript δείχνει πώς να εφαρμόσετε συμπλήρωση σταθερού χρώματος σε ένα ορθογώνιο σε διαφάνεια PowerPoint:

```js
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
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

    // Αποθηκεύστε το αρχείο PPTX στον δίσκο.
    presentation.save("solid_color_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Το σχήμα με συμπλήρωση σταθερού χρώματος](solid-color-fill.png)

## **Ορισμός Διαφάνειας**

Στο PowerPoint, όταν εφαρμόζετε συμπλήρωση σταθερού χρώματος, γραμμικής σχέσης, εικόνας ή υφής σε σχήματα, μπορείτε επίσης να ορίσετε επίπεδο διαφάνειας για να ελέγξετε τη διαφάνειση της συμπλήρωσης. Μια υψηλότερη τιμή διαφάνειας κάνει το σχήμα πιο διαφανές, επιτρέποντας στο φόντο ή στα υποκείμενα αντικείμενα να φαίνονται εν μέρει.

Το Aspose.Slides σας επιτρέπει να ορίσετε το επίπεδο διαφάνειας προσαρμόζοντας την τιμή alpha στο χρώμα που χρησιμοποιείται για τη συμπλήρωση. Δείτε πώς:

1. Δημιουργήστε ένα στιγμιότυπο της [Παρουσίαση](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) κλάσης.
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/filltype/) σε `Solid`.
1. Χρησιμοποιήστε την κλάση `Color` για να ορίσετε ένα χρώμα με διαφάνεια (το στοιχείο `alpha` ελέγχει τη διαφάνεια).
1. Αποθηκεύστε την παρουσίαση.

Ο ακόλουθος κώδικας JavaScript δείχνει πώς να εφαρμόσετε χρώμα συμπλήρωσης με διαφάνεια σε ένα ορθογώνιο:

```js
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
let presentation = new aspose.slides.Presentation();
try {
    // Αποκτήστε την πρώτη διαφάνεια.
    let slide = presentation.getSlides().get_Item(0);

    // Προσθέστε ένα αυτόματο σχήμα ορθογωνίου με στερεό γέμισμα.
    let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Προσθέστε ένα διαφανές αυτόματο σχήμα ορθογωνίου πάνω στο στερεό σχήμα.
    let transparentShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    transparentShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 255, 0, 204));

    // Αποθηκεύστε το αρχείο PPTX στον δίσκο.
    presentation.save("shape_transparency.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Το διαφανές σχήμα](shape-transparency.png)

## **Περιστροφή Σχημάτων**

Το Aspose.Slides σας επιτρέπει να περιστρέφετε σχήματα σε παρουσιάσεις PowerPoint. Αυτό μπορεί να είναι χρήσιμο όταν τοποθετείτε οπτικά στοιχεία με συγκεκριμένη ευθυγράμμιση ή σχέδια.

Για να περιστρέψετε ένα σχήμα σε μια διαφάνεια, ακολουθήστε τα βήματα:

1. Δημιουργήστε ένα στιγμιότυπο της [Παρουσίαση](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) κλάσης.
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε την ιδιότητα περιστροφής του σχήματος στην επιθυμητή γωνία.
1. Αποθηκεύστε την παρουσίαση.

Ο ακόλουθος κώδικας JavaScript δείχνει πώς να περιστρέψετε ένα σχήμα κατά 5 μοίρες:

```js
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
let presentation = new aspose.slides.Presentation();
try {
    // Αποκτήστε την πρώτη διαφάνεια.
    let slide = presentation.getSlides().get_Item(0);

    // Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Περιστρέψτε το σχήμα κατά 5 μοίρες.
    shape.setRotation(5);

    // Αποθηκεύστε το αρχείο PPTX στον δίσκο.
    presentation.save("shape_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Η περιστροφή του σχήματος](shape-rotation.png)

## **Προσθήκη Εφέ Τρισδιάστατης Λάβδου**

Το Aspose.Slides σας επιτρέπει να εφαρμόζετε εφέ τρισδιάστατης λάβδου σε σχήματα ρυθμίζοντας τις ιδιότητες του [ThreeDFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/threedformat/).

Για να προσθέσετε εφέ τρισδιάστατης λάβδου σε ένα σχήμα, ακολουθήστε τα βήματα:

1. Δημιουργήστε ένα στιγμιότυπο της [Παρουσίαση](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) κλάσης.
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/) στη διαφάνεια.
1. Ρυθμίστε το [ThreeDFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/threedformat/) του σχήματος για να ορίσετε τις ρυθμίσεις λάβδου.
1. Αποθηκεύστε την παρουσίαση.

Ο ακόλουθος κώδικας JavaScript δείχνει πώς να εφαρμόσετε εφέ τρισδιάστατης λάβδου σε σχήμα:

```js
// Δημιουργήστε ένα στιγμιότυπο της κλάσης Presentation.
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

![Το εφέ τρισδιάστατης λάβδου](3D-bevel-effect.png)

## **Προσθήκη Εφέ Τρισδιάστατης Περιστροφής**

Το Aspose.Slides σας επιτρέπει να εφαρμόζετε εφέ τρισδιάστατης περιστροφής σε σχήματα ρυθμίζοντας τις ιδιότητες του [ThreeDFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/threedformat/).

Για να εφαρμόσετε τρισδιάστατη περιστροφή σε σχήμα:

1. Δημιουργήστε ένα στιγμιότυπο της [Παρουσίαση](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) κλάσης.
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/) στη διαφάνεια.
1. Χρησιμοποιήστε τις μεθόδους [setCameraType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/camera/#setCameraType) και [setLightType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/lightrig/#setLightType) για να ορίσετε την τρισδιάστατη περιστροφή.
1. Αποθηκεύστε την παρουσίαση.

Ο ακόλουθος κώδικας JavaScript δείχνει πώς να εφαρμόσετε εφέ τρισδιάστατης περιστροφής σε σχήμα:

```js
// Δημιουργήστε ένα στιγμιότυπο της κλάσης Presentation.
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

![Το εφέ τρισδιάστατης περιστροφής](3D-rotation-effect.png)

## **Επαναφορά Μορφοποίησης**

Ο ακόλουθος κώδικας Java δείχνει πώς να επαναφέρετε τη μορφοποίηση μιας διαφάνειας και να επαναφέρετε τη θέση, το μέγεθος και τη μορφοποίηση όλων των σχημάτων με placeholder στο [LayoutSlide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/layoutslide/) στις προεπιλεγμένες ρυθμίσεις τους:

```js
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        // Επαναφέρετε κάθε σχήμα στη διαφάνεια που έχει placeholder στη διάταξη.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ΣΥΧΝΑ ΕΡΩΤΗΜΑΤΑ**

**Επηρεάζει η μορφοποίηση σχήματος το τελικό μέγεθος του αρχείου παρουσίασης;**

Μόνο ελάχιστα. Οι ενσωματωμένες εικόνες και τα μέσα καταλαμβάνουν το μεγαλύτερο μέρος του χώρου του αρχείου, ενώ οι παράμετροι σχήματος όπως χρώματα, εφέ και γραμμικές σχέσεις αποθηκεύονται ως μεταδεδομένα και δεν προσθέτουν ουσιαστικά επιπλέον μέγεθος.

**Πώς μπορώ να εντοπίσω σχήματα σε μια διαφάνεια που έχουν ταυτόσημη μορφοποίηση ώστε να τα ομαδοποιήσω;**

Συγκρίνετε τις βασικές ιδιότητες μορφοποίησης κάθε σχήματος — ρυθμίσεις γεμίσματος, γραμμής και εφέ. Εάν όλες οι αντίστοιχες τιμές ταιριάζουν, θεωρήστε ότι τα στυλ είναι ταυτόσημα και ομαδοποιήστε λογικά αυτά τα σχήματα, γεγονός που απλοποιεί τη μελλοντική διαχείριση στυλ.

**Μπορώ να αποθηκεύσω ένα σύνολο προσαρμοσμένων στυλ σχήματος σε ξεχωριστό αρχείο για επαναχρησιμοποίηση σε άλλες παρουσιάσεις;**

Ναι. Αποθηκεύστε δείγματα σχημάτων με τα επιθυμητά στυλ σε ένα πρότυπο παρουσίασης ή σε αρχείο .POTX. Όταν δημιουργείτε νέα παρουσίαση, ανοίξτε το πρότυπο, κλωνοποιήστε τα στυλ σχήματος που χρειάζεστε και επανατοποθετήστε τη μορφοποίησή τους όπου απαιτείται.