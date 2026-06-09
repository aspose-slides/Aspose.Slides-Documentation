---
title: "Διαμόρφωση Σχημάτων PowerPoint σε Android"
linktitle: "Μορφοποίηση Σχημάτων"
type: docs
weight: 20
url: /el/androidjava/shape-formatting/
keywords:
- "μορφοποίηση σχήματος"
- "μορφοποίηση γραμμής"
- "μορφοποίηση στυλ σύνδεσης"
- "διαβάθμιση γέμωσης"
- "διάστικτη γέμωση"
- "γέμωση με εικόνα"
- "γέμωση υφής"
- "συμπαγής μονόχρωμη γέμωση"
- "διαφάνεια σχήματος"
- "περιστροφή σχήματος"
- "εφέ 3Δ λοξότμησης"
- "εφέ 3Δ περιστροφής"
- "επαναφορά μορφοποίησης"
- "PowerPoint"
- "παρουσίαση"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Μάθετε πώς να μορφοποιείτε σχήματα PowerPoint σε Android χρησιμοποιώντας το Aspose.Slides—ορίστε στυλ γέμωσης, γραμμής και εφέ για αρχεία PPT, PPTX και ODP με ακρίβεια και πλήρη έλεγχο."
---
## **Εισαγωγή**

Στο PowerPoint, μπορείτε να προσθέσετε σχήματα στις διαφάνειες. Καθώς τα σχήματα αποτελούνται από γραμμές, μπορείτε να μορφοποιήσετε τις γραμμές τους τροποποιώντας ή εφαρμόζοντας εφέ στα περιγράμματά τους. Επιπλέον, μπορείτε να μορφοποιήσετε τα σχήματα καθορίζοντας ρυθμίσεις που ελέγχουν πώς γεμίζουν τα εσωτερικά τους.

![μορφοποίηση-σχήματος-powerpoint](format-shape-powerpoint.png)

Η Aspose.Slides for Android via Java παρέχει διεπαφές και μεθόδους που σας επιτρέπουν να μορφοποιείτε σχήματα χρησιμοποιώντας τις ίδιες επιλογές που είναι διαθέσιμες στο PowerPoint.

## **Διαμόρφωση Γραμμών**

Με τη χρήση Aspose.Slides, μπορείτε να ορίσετε προσαρμοσμένο στυλ γραμμής για ένα σχήμα. Τα παρακάτω βήματα περιγράφουν τη διαδικασία:

1. Δημιουργήστε μια παρουσία της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/).
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [στυλ γραμμής](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/linestyle/) του σχήματος.
1. Ορίστε το πλάτος της γραμμής.
1. Ορίστε το [στυλ παύλας](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/linedashstyle/) της γραμμής.
1. Ορίστε το χρώμα της γραμμής για το σχήμα.
1. Αποθηκεύστε την τροποποιημένη παρουσία ως αρχείο PPTX.

Ο παρακάτω κώδικας δείχνει πώς να μορφοποιήσετε ένα ορθογώνιο `AutoShape`:

```java
// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
Presentation presentation = new Presentation();
try {
    // Λάβετε την πρώτη διαφάνεια.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Ορίστε το χρώμα γεμίσματος για το σχήμα ορθογωνίου.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // Εφαρμόστε μορφοποίηση στις γραμμές του ορθογωνίου.
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // Ορίστε το χρώμα για τη γραμμή του ορθογωνίου.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Αποθηκεύστε το αρχείο PPTX στον δίσκο.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Οι μορφοποιημένες γραμμές στην παρουσίαση](formatted-lines.png)

## **Διαμόρφωση Στυλ Σύνδεσης**

Αυτές είναι οι τρεις επιλογές τύπου σύνδεσης:

* Στρογγυλό
* Κόψιμο
* Λοξότμηση

Από προεπιλογή, όταν το PowerPoint συνδέει δύο γραμμές με γωνία (όπως στη γωνία ενός σχήματος), χρησιμοποιεί τη ρύθμιση **Στρογγυλό**. Ωστόσο, εάν σχεδιάζετε σχήμα με αιχμηρές γωνίες, ίσως προτιμήσετε την επιλογή **Κόψιμο**.

![Το στυλ σύνδεσης στην παρουσίαση](join-style-powerpoint.png)

Ο παρακάτω κώδικας Java δείχνει πώς δημιουργήθηκαν τρία ορθογώνια (όπως φαίνεται στην παραπάνω εικόνα) χρησιμοποιώντας τις ρυθμίσεις τύπου σύνδεσης Κόψιμο, Λοξότμηση και Στρογγυλό:

```java
// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
Presentation presentation = new Presentation();
try {
    // Λάβετε την πρώτη διαφάνεια.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Προσθέστε τρία αυτόματα σχήματα τύπου Rectangle.
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Ορίστε το χρώμα γεμίσματος για κάθε σχήμα ορθογωνίου.
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // Ορίστε το πλάτος της γραμμής.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // Ορίστε το χρώμα για τη γραμμή κάθε ορθογωνίου.
    shape1.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape3.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Ορίστε το στυλ σύνδεσης.
    shape1.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    shape2.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    shape3.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    // Προσθέστε κείμενο σε κάθε ορθογώνιο.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // Αποθηκεύστε το αρχείο PPTX στον δίσκο.
    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Διαβάθμιση Γεμίσματος (Gradient Fill)**

Στο PowerPoint, η διαβάθμιση γέμωσης είναι μια επιλογή μορφοποίησης που επιτρέπει την εφαρμογή μιας συνεχούς μετάβασης χρωμάτων σε ένα σχήμα. Για παράδειγμα, μπορείτε να εφαρμόσετε δύο ή περισσότερα χρώματα έτσι ώστε το ένα να εξασθενεί σταδιακά στο άλλο.

Ακολουθεί η διαδικασία για την εφαρμογή διαβάθμισης γέμωσης σε σχήμα με χρήση Aspose.Slides:

1. Δημιουργήστε μια παρουσία της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/).
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/filltype/) του σχήματος σε `Gradient`.
1. Προσθέστε τα δύο προτιμώμενα χρώματά σας με καθορισμένες θέσεις χρησιμοποιώντας τις μεθόδους `add` της συλλογής διαβάθμισης που εκτίθεται από τη διεπαφή [IGradientFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/igradientformat/).
1. Αποθηκεύστε την τροποποιημένη παρουσία ως αρχείο PPTX.

Ο παρακάτω κώδικας Java δείχνει πώς να εφαρμόσετε εφέ διαβάθμισης γέμωσης σε έλλειψη:

```java
// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
Presentation presentation = new Presentation();
try {
    // Λάβετε την πρώτη διαφάνεια.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Προσθέστε ένα αυτόματο σχήμα τύπου Ellipse.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Εφαρμόστε διαβάθμιση μορφοποίησης στην έλλειψη.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // Ορίστε την κατεύθυνση της διαβάθμισης.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // Προσθέστε δύο στάσεις διαβάθμισης.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // Αποθηκεύστε το αρχείο PPTX στον δίσκο.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Η έλλειψη με διαβάθμιση γέμωσης](gradient-fill.png)

## **Διάστικτη Γέμωση (Pattern Fill)**

Στο PowerPoint, η διάστικτη γέμωση είναι μια επιλογή μορφοποίησης που σας επιτρέπει να εφαρμόσετε ένα σχέδιο δύο χρωμάτων — όπως κουκίδες, λωρίδες, διαγώνιες λωρίδες ή τετράγωνα — σε ένα σχήμα. Μπορείτε να επιλέξετε προσαρμοσμένα χρώματα για το προσκήνιο και το παρασκήνιο του μοτίβου.

Η Aspose.Slides παρέχει πάνω από 45 προκαθορισμένα στυλ μοτίβων που μπορείτε να εφαρμόσετε σε σχήματα για να ενισχύσετε την οπτική ελκυστικότητα των παρουσιάσεών σας. Ακόμη και μετά την επιλογή ενός προκαθορισμένου μοτίβου, μπορείτε να καθορίσετε ακριβώς τα χρώματα που θα χρησιμοποιήσει.

Ακολουθήστε τα παρακάτω βήματα για να εφαρμόσετε διάστικτη γέμωση σε σχήμα με χρήση Aspose.Slides:

1. Δημιουργήστε μια παρουσία της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/).
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/filltype/) του σχήματος σε `Pattern`.
1. Επιλέξτε ένα στυλ μοτίβου από τις προκαθορισμένες επιλογές.
1. Ορίστε το [Background Color](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/patternformat/#getBackColor--) του μοτίβου.
1. Ορίστε το [Foreground Color](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/patternformat/#getForeColor--) του μοτίβου.
1. Αποθηκεύστε την τροποποιημένη παρουσία ως αρχείο PPTX.

Ο παρακάτω κώδικας Java δείχνει πώς να εφαρμόσετε διάστικτη γέμωση σε ένα ορθογώνιο:

```java
// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
Presentation presentation = new Presentation();
try {
    // Λάβετε την πρώτη διαφάνεια.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Ορίστε τον τύπο γεμίσματος σε Pattern.
    shape.getFillFormat().setFillType(FillType.Pattern);

    // Ορίστε το στυλ του μοτίβου.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // Ορίστε τα χρώματα φόντου και προσκηνίου του μοτίβου.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // Αποθηκεύστε το αρχείο PPTX στον δίσκο.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Το ορθογώνιο με διάστικτη γέμωση](pattern-fill.png)

## **Γέμωση με Εικόνα (Picture Fill)**

Στο PowerPoint, η γέμωση με εικόνα είναι μια επιλογή μορφοποίησης που σας επιτρέπει να ενσωματώσετε μια εικόνα μέσα σε σχήμα — χρησιμοποιώντας ουσιαστικά την εικόνα ως φόντο του σχήματος.

Ακολουθήστε τα βήματα για να χρησιμοποιήσετε την Aspose.Slides ώστε να εφαρμόσετε γέμωση με εικόνα σε σχήμα:

1. Δημιουργήστε μια παρουσία της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/).
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/filltype/) του σχήματος σε `Picture`.
1. Ορίστε τη λειτουργία γέμωσης εικόνας σε `Tile` (ή άλλη προτιμώμενη λειτουργία).
1. Δημιουργήστε ένα αντικείμενο [IPPImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ippimage/) από την εικόνα που θέλετε να χρησιμοποιήσετε.
1. Πηγαίνετε την εικόνα στη μέθοδο `ISlidesPicture.setImage`.
1. Αποθηκεύστε την τροποποιημένη παρουσία ως αρχείο PPTX.

Ας υποθέσουμε ότι έχουμε ένα αρχείο «lotus.png» με την παρακάτω εικόνα:

![Η εικόνα λωτού](lotus.png)

Ο παρακάτω κώδικας Java δείχνει πώς να γεμίσετε ένα σχήμα με την εικόνα:

```java
// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
Presentation presentation = new Presentation();
try {
    // Λάβετε την πρώτη διαφάνεια.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Ορίστε τον τύπο γεμίσματος σε Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Ορίστε τη λειτουργία γέμωσης εικόνας.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // Φορτώστε μια εικόνα και προσθέστε την στους πόρους της παρουσίασης.
    IImage image = Images.fromFile("lotus.png");
    IPPImage picture = presentation.getImages().addImage(image);
    image.dispose();

    // Ορίστε την εικόνα.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Αποθηκεύστε το αρχείο PPTX στον δίσκο.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Το σχήμα με γέμωση εικόνας](picture-fill.png)

### **Εφαρμογή Εικόνας σε Πλακόστρωση (Tile Picture As Texture)**

Εάν θέλετε να ορίσετε μια πλακόστρωση εικόνας ως υφή και να προσαρμόσετε τη συμπεριφορά της πλακόστρωσης, μπορείτε να χρησιμοποιήσετε τις παρακάτω μεθόδους της διεπαφής [IPictureFillFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipicturefillformat/) και της κλάσης [PictureFillFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Ορίζει τη λειτουργία γέμωσης εικόνας — `Tile` ή `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Καθορίζει την στοίχιση των πλακιδίων μέσα στο σχήμα.
- [setTileFlip](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Ελέγχει αν το πλακίδιο θα αναστραφεί οριζόντια, κάθετα ή και τα δύο.
- [setTileOffsetX](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Ορίζει την οριζόντια μετατόπιση του πλακιδίου (σε σημεία) από το σημείο προέλευσης του σχήματος.
- [setTileOffsetY](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Ορίζει την κάθετη μετατόπιση του πλακιδίου (σε σημεία) από το σημείο προέλευσης του σχήματος.
- [setTileScaleX](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Ορίζει την οριζόντια κλίμακα του πλακιδίου ως ποσοστό.
- [setTileScaleY](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Ορίζει την κάθετη κλίμακα του πλακιδίου ως ποσοστό.

Ο παρακάτω κώδικας δείχνει πώς να προσθέσετε ένα ορθογώνιο σχήμα με πλακόστρωση εικόνας και να διαμορφώσετε τις επιλογές πλακόστρωσης:

```java
// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
Presentation presentation = new Presentation();
try {
    // Λάβετε την πρώτη διαφάνεια.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Ορίστε τον τύπο γεμίσματος του σχήματος σε Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Φορτώστε την εικόνα και προσθέστε την στους πόρους της παρουσίασης.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Ανέθεστε την εικόνα στο σχήμα.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Ρυθμίστε τη λειτουργία γέμισης εικόνας και τις ιδιότητες πλακόστρωσης.
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    // Αποθηκεύστε το αρχείο PPTX στον δίσκο.
    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Οι επιλογές πλακόστρωσης](tile-options.png)

## **Συμπαγής Γέμιση με Μονόχρωμο (Solid Color Fill)**

Στο PowerPoint, η συμπαγής γέμιση με μονόχρωμο είναι μια επιλογή μορφοποίησης που γεμίζει ένα σχήμα με ένα ενιαίο, ομοιόμορφο χρώμα. Αυτό το απλό χρώμα φόντου εφαρμόζεται χωρίς διαβαθμίσεις, υφές ή μοτίβα.

Για να εφαρμόσετε συμπαγή μονόχρωμη γέμωση σε σχήμα με χρήση Aspose.Slides, ακολουθήστε τα βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/).
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/filltype/) του σχήματος σε `Solid`.
1. Αναθέστε το προτιμώμενο χρώμα γέμωσης στο σχήμα.
1. Αποθηκεύστε την τροποποιημένη παρουσία ως αρχείο PPTX.

Ο παρακάτω κώδικας Java δείχνει πώς να εφαρμόσετε συμπαγή μονόχρωμη γέμωση σε ένα ορθογώνιο σε διαφάνεια PowerPoint:

```java
// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
Presentation presentation = new Presentation();
try {
    // Λάβετε την πρώτη διαφάνεια.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Ορίστε τον τύπο γεμίσματος σε Solid.
    shape.getFillFormat().setFillType(FillType.Solid);

    // Ορίστε το χρώμα γεμίσματος.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // Αποθηκεύστε το αρχείο PPTX στον δίσκο.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Το σχήμα με συμπαγή μονόχρωμη γέμωση](solid-color-fill.png)

## **Ορισμός Διαφάνειας (Set Transparency)**

Στο PowerPoint, όταν εφαρμόζετε συμπαγές χρώμα, διαβάθμιση, εικόνα ή υφή σε σχήματα, μπορείτε επίσης να ορίσετε επίπεδο διαφάνειας για να ελέγξετε την αδιαφάνεια του γέμωσης. Μία μεγαλύτερη τιμή διαφάνειας κάνει το σχήμα πιο διαυγές, επιτρέποντας στο φόντο ή στα υποκείμενα αντικείμενα να φαίνονται εν μέρει.

Η Aspose.Slides σας επιτρέπει να ορίσετε το επίπεδο διαφάνειας προσαρμόζοντας την τιμή alpha στο χρώμα που χρησιμοποιείται για το γέμισμα. Δείτε πώς:

1. Δημιουργήστε μια παρουσία της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/).
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/filltype/) σε `Solid`.
1. Χρησιμοποιήστε την κλάση `Color` για να ορίσετε χρώμα με διαφάνεια (το στοιχείο `alpha` ελέγχει τη διαφάνεια).
1. Αποθηκεύστε την παρουσία.

Ο παρακάτω κώδικας Java δείχνει πώς να εφαρμόσετε διαφανές χρώμα γέμωσης σε ένα ορθογώνιο:

```java
// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
Presentation presentation = new Presentation();
try {
    // Λάβετε την πρώτη διαφάνεια.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Προσθέστε ένα συμπαγές αυτόματο σχήμα τύπου Rectangle.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Προσθέστε ένα διαφανές αυτόματο σχήμα τύπου Rectangle πάνω από το συμπαγές σχήμα.
    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 204));

    // Αποθηκεύστε το αρχείο PPTX στον δίσκο.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Το διαφανές σχήμα](shape-transparency.png)

## **Περιστροφή Σχημάτων (Rotate Shapes)**

Η Aspose.Slides σας επιτρέπει να περιστρέφετε σχήματα σε παρουσιάσεις PowerPoint. Αυτό μπορεί να είναι χρήσιμο όταν τοποθετείτε οπτικά στοιχεία με συγκεκριμένη στοίχιση ή σχεδιαστικές απαιτήσεις.

Για να περιστρέψετε ένα σχήμα σε μια διαφάνεια, ακολουθήστε τα βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/).
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε την ιδιότητα περιστροφής του σχήματος στην επιθυμητή γωνία.
1. Αποθηκεύστε την παρουσία.

Ο παρακάτω κώδικας Java δείχνει πώς να περιστρέψετε ένα σχήμα κατά 5 μοίρες:

```java
// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
Presentation presentation = new Presentation();
try {
    // Λάβετε την πρώτη διαφάνεια.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Περιστρέψτε το σχήμα κατά 5 μοίρες.
    shape.setRotation(5);

    // Αποθηκεύστε το αρχείο PPTX στον δίσκο.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Η περιστροφή του σχήματος](shape-rotation.png)

## **Προσθήκη Εφέ 3Δ Λοξότμησης (Add 3D Bevel Effects)**

Η Aspose.Slides σας επιτρέπει να εφαρμόσετε 3Δ εφέ λοξότμησης σε σχήματα ρυθμίζοντας τις ιδιότητες του [ThreeDFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/threedformat/).

Για να προσθέσετε 3Δ εφέ λοξότμησης σε ένα σχήμα, ακολουθήστε τα βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/).
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/) στη διαφάνεια.
1. Ρυθμίστε το [ThreeDFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/threedformat/) του σχήματος για να ορίσετε τις παραμέτρους λοξότμησης.
1. Αποθηκεύστε την παρουσία.

Ο παρακάτω κώδικας Java δείχνει πώς να εφαρμόσετε 3Δ εφέ λοξότμησης σε σχήμα:

```java
// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Προσθέστε ένα σχήμα στη διαφάνεια.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE);
    shape.getLineFormat().setWidth(2.0);

    // Ορίστε τις ιδιότητες ThreeDFormat του σχήματος.
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    // Αποθηκεύστε την παρουσίαση ως αρχείο PPTX.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Το εφέ 3Δ λοξότμησης](3D-bevel-effect.png)

## **Προσθήκη Εφέ 3Δ Περιστροφής (Add 3D Rotation Effects)**

Η Aspose.Slides σας επιτρέπει να εφαρμόσετε 3Δ εφέ περιστροφής σε σχήματα ρυθμίζοντας τις ιδιότητες του [ThreeDFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/threedformat/).

Για να εφαρμόσετε 3Δ περιστροφή σε ένα σχήμα:

1. Δημιουργήστε μια παρουσία της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/).
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/) στη διαφάνεια.
1. Χρησιμοποιήστε τις μεθόδους [setCameraType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/icamera/#setCameraType-int-) και [setLightType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ilightrig/#setLightType-int-) για να ορίσετε την 3Δ περιστροφή.
1. Αποθηκεύστε την παρουσία.

Ο παρακάτω κώδικας Java δείχνει πώς να εφαρμόσετε 3Δ εφέ περιστροφής σε σχήμα:

```java
// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    // Αποθηκεύστε την παρουσίαση ως αρχείο PPTX.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Το εφέ 3Δ περιστροφής](3D-rotation-effect.png)

## **Επαναφορά Μορφοποίησης (Reset Formatting)**

Ο παρακάτω κώδικας Java δείχνει πώς να επαναφέρετε τη μορφοποίηση μιας διαφάνειας και να επαναφέρετε τη θέση, το μέγεθος και τη μορφοποίηση όλων των σχημάτων με placeholders στο [LayoutSlide](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/layoutslide/) στις προεπιλεγμένες ρυθμίσεις τους:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Επαναφέρετε κάθε σχήμα στη διαφάνεια που έχει σύμβολο κράτησης στη διάταξη.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Συχνές Ερωτήσεις (FAQ)**

**Επηρεάζει η μορφοποίηση των σχημάτων το τελικό μέγεθος του αρχείου παρουσίασης;**

Μόνο ελαφρώς. Οι ενσωματωμένες εικόνες και τα μέσα καταλαμβάνουν το μεγαλύτερο μέρος του χώρου του αρχείου, ενώ οι παράμετροι των σχημάτων όπως χρώματα, εφέ και διαβαθμίσεις αποθηκεύονται ως μεταδεδομένα και δεν προσθέτουν ουσιαστικά επιπλέον μέγεθος.

**Πώς μπορώ να εντοπίσω σχήματα σε μια διαφάνεια που έχουν ταυτόσημη μορφοποίηση ώστε να τα ομαδοποιήσω;**

Συγκρίνετε τις βασικές ιδιότητες μορφοποίησης κάθε σχήματος — ρυθμίσεις γέμωσης, γραμμής και εφέ. Εάν όλα τα αντίστοιχα τιμές ταιριάζουν, θεωρήστε ότι τα στυλ είναι ταυτόσημα και ομάδστε λογικά αυτά τα σχήματα, γεγονός που απλουστεύει τη μετέπειτα διαχείριση στυλ.

**Μπορώ να αποθηκεύσω ένα σύνολο προσαρμοσμένων στυλ σχήματος σε ξεχωριστό αρχείο για χρήση σε άλλες παρουσιάσεις;**

Ναι. Αποθηκεύστε δείγματα σχημάτων με τα επιθυμητά στυλ σε ένα πρότυπο παρουσίασης ή σε αρχείο .POTX. Όταν δημιουργείτε νέα παρουσίαση, ανοίξτε το πρότυπο, κλωνοποιήστε τα στυλ σχήματος που χρειάζεστε και εφαρμόστε ξανά τη μορφοποίηση όπου απαιτείται.