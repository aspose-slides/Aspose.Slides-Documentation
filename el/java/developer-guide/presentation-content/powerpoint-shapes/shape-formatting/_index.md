---
title: Μορφοποίηση Σχημάτων PowerPoint σε Java
linktitle: Μορφοποίηση Σχήματος
type: docs
weight: 20
url: /el/java/shape-formatting/
keywords:
- μορφοποίηση σχήματος
- μορφοποίηση γραμμής
- μορφοποίηση τύπου σύνδεσης
- διαβαθμισμένη συμπλήρωση
- συμπλήρωση μοτίβου
- συμπλήρωση εικόνας
- συμπλήρωση υφής
- συμπλήρωση σταθερού χρώματος
- διαφάνεια σχήματος
- περιστροφή σχήματος
- εφέ 3Δ αποκοπής
- εφέ 3Δ περιστροφής
- επαναφορά μορφοποίησης
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Μάθετε πώς να μορφοποιείτε σχήματα PowerPoint σε Java χρησιμοποιώντας το Aspose.Slides—ορίστε στυλ συμπλήρωσης, γραμμής και εφέ για αρχεία PPT, PPTX και ODP με ακρίβεια και πλήρη έλεγχο."
---
## **Εισαγωγή**

Στο PowerPoint, μπορείτε να προσθέσετε σχήματα στις διαφάνειες. Καθώς τα σχήματα αποτελούνται από γραμμές, μπορείτε να τα μορφοποιήσετε τροποποιώντας ή εφαρμόζοντας εφέ στα περιγράμματά τους. Επιπλέον, μπορείτε να μορφοποιήσετε τα σχήματα καθορίζοντας ρυθμίσεις που ελέγχουν πώς γεμίζουν τα εσωτερικά τους.

![μορφοποίηση σχήματος PowerPoint](format-shape-powerpoint.png)

Το Aspose.Slides για Java παρέχει διεπαφές και μεθόδους που επιτρέπουν τη μορφοποίηση σχημάτων χρησιμοποιώντας τις ίδιες επιλογές που διατίθενται στο PowerPoint.

## **Μορφοποίηση Γραμμών**

Χρησιμοποιώντας το Aspose.Slides, μπορείτε να ορίσετε προσαρμοσμένο στυλ γραμμής για ένα σχήμα. Τα παρακάτω βήματα περιγράφουν τη διαδικασία:

1. Δημιουργήστε μια νέα παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια βάσει του δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [στυλ γραμμής](https://reference.aspose.com/slides/el/java/com.aspose.slides/linestyle/) του σχήματος.
1. Ορίστε το πάχος της γραμμής.
1. Ορίστε το [στυλ παύλας](https://reference.aspose.com/slides/el/java/com.aspose.slides/linedashstyle/) της γραμμής.
1. Ορίστε το χρώμα γραμμής για το σχήμα.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```java
// Δημιουργήστε μια παρουσία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
Presentation presentation = new Presentation();
try {
    // Λάβετε την πρώτη διαφάνεια.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Ορίστε το χρώμα γεμίσματος για το σχήμα Rectangle.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // Εφαρμόστε μορφοποίηση στις γραμμές του Rectangle.
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // Ορίστε το χρώμα για τη γραμμή του Rectangle.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Αποθηκεύστε το αρχείο PPTX στο δίσκο.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Οι μορφοποιημένες γραμμές στην παρουσίαση](formatted-lines.png)

## **Μορφοποίηση Στυλ Σύνδεσης**

Αυτές είναι οι τρεις επιλογές τύπου σύνδεσης:

* Στρογγυλό
* Μίτερ
* Λεοξή

Από προεπιλογή, όταν το PowerPoint συνδέει δύο γραμμές σε γωνία (όπως στη γωνία ενός σχήματος), χρησιμοποιεί τη ρύθμιση **Στρογγυλό**. Ωστόσο, εάν σχεδιάζετε ένα σχήμα με οξυγώνιες γωνίες, ίσως προτιμάτε την επιλογή **Μίτερ**.

![Το στυλ σύνδεσης στην παρουσίαση](join-style-powerpoint.png)

Ο ακόλουθος κώδικας Java δείχνει πώς δημιουργήθηκαν τρία ορθογώνια (όπως φαίνεται στην παραπάνω εικόνα) χρησιμοποιώντας τις ρυθμίσεις τύπου σύνδεσης Μίτερ, Λεοξή και Στρογγυλό:

```java
// Δημιουργήστε μια παρουσία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
Presentation presentation = new Presentation();
try {
    // Λάβετε την πρώτη διαφάνεια.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Προσθέστε τρία αυτόματα σχήματα τύπου Rectangle.
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Ορίστε το χρώμα γεμίσματος για κάθε σχήμα Rectangle.
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // Ορίστε το πάχος της γραμμής.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // Ορίστε το χρώμα για τη γραμμή κάθε Rectangle.
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

    // Προσθέστε κείμενο σε κάθε Rectangle.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // Αποθηκεύστε το αρχείο PPTX στο δίσκο.
    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Διαβαθμισμένη Συμπλήρωση**

Στο PowerPoint, η Διαβαθμισμένη Συμπλήρωση είναι μια επιλογή μορφοποίησης που σας επιτρέπει να εφαρμόσετε μια συνεχόμενη μίξη χρωμάτων σε ένα σχήμα. Για παράδειγμα, μπορείτε να εφαρμόσετε δύο ή περισσότερα χρώματα με τρόπο ώστε το ένα να εξασθενεί σταδιακά στο άλλο.

Ακολουθούν τα βήματα για να εφαρμόσετε διαβαθμισμένη συμπλήρωση σε ένα σχήμα χρησιμοποιώντας το Aspose.Slides:

1. Δημιουργήστε μια νέα παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια βάσει του δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/java/com.aspose.slides/filltype/) του σχήματος σε `Gradient`.
1. Προσθέστε τα δύο προτιμώμενα χρώματά σας με καθορισμένες θέσεις χρησιμοποιώντας τις μεθόδους `add` της συλλογής gradient stop που εκτίθεται από τη διεπαφή [IGradientFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/igradientformat/).
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```java
// Δημιουργήστε μια παρουσία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
Presentation presentation = new Presentation();
try {
    // Λάβετε την πρώτη διαφάνεια.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Προσθέστε ένα αυτόματο σχήμα τύπου Ellipse.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Εφαρμόστε διαβαθμισμένη μορφοποίηση στο Ellipse.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // Ορίστε τη διεύθυνση του διαβάθματος.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // Προσθέστε δύο σημεία διαβάθματος.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // Αποθηκεύστε το αρχείο PPTX στο δίσκο.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Το έλλειψο με διαβαθμισμένη συμπλήρωση](gradient-fill.png)

## **Συμπλήρωση Σχεδίου**

Στο PowerPoint, η Συμπλήρωση Σχεδίου είναι μια επιλογή μορφοποίησης που σας επιτρέπει να εφαρμόσετε ένα σχεδιαστικό μοτίβο με δύο χρώματα — όπως κουκκίδες, λωρίδες, διαγώνιες γραμμές ή σκαρίφημα — σε ένα σχήμα. Μπορείτε να επιλέξετε προσαρμοσμένα χρώματα για το προσκήνιο και το παρασκήνιο του μοτίβου.

Το Aspose.Slides παρέχει πάνω από 45 προεπιλεγμένα στυλ μοτίβου που μπορείτε να εφαρμόσετε σε σχήματα για να ενισχύσετε την οπτική απήχηση των παρουσιάσεών σας. Ακόμη και αφού επιλέξετε ένα προεπιλεγμένο μοτίβο, μπορείτε να καθορίσετε τα ακριβή χρώματα που θα χρησιμοποιήσει.

Ακολουθούν τα βήματα για να εφαρμόσετε συμπλήρωση σχεδίου σε ένα σχήμα χρησιμοποιώντας το Aspose.Slides:

1. Δημιουργήστε μια νέα παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια βάσει του δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/java/com.aspose.slides/filltype/) του σχήματος σε `Pattern`.
1. Επιλέξτε ένα στυλ μοτίβου από τις προεπιλεγμένες επιλογές.
1. Ορίστε το [Background Color](https://reference.aspose.com/slides/el/java/com.aspose.slides/patternformat/#getBackColor--) του μοτίβου.
1. Ορίστε το [Foreground Color](https://reference.aspose.com/slides/el/java/com.aspose.slides/patternformat/#getForeColor--) του μοτίβου.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```java
// Δημιουργήστε μια παρουσία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
Presentation presentation = new Presentation();
try {
    // Λάβετε την πρώτη διαφάνεια.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Ορίστε τον τύπο γεμίσματος σε Pattern.
    shape.getFillFormat().setFillType(FillType.Pattern);

    // Ορίστε το στυλ μοτίβου.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // Ορίστε τα χρώματα φόντου και προσκηνίου του μοτίβου.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // Αποθηκεύστε το αρχείο PPTX στο δίσκο.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Το ορθογώνιο με συμπλήρωση σχεδίου](pattern-fill.png)

## **Συμπλήρωση Εικόνας**

Στο PowerPoint, η Συμπλήρωση Εικόνας είναι μια επιλογή μορφοποίησης που σας επιτρέπει να εισάγετε μια εικόνα μέσα σε ένα σχήμα — χρησιμοποιώντας ουσιαστικά την εικόνα ως φόντο του σχήματος.

Ακολουθούν τα βήματα για να χρησιμοποιήσετε το Aspose.Slides για να εφαρμόσετε συμπλήρωση εικόνας σε ένα σχήμα:

1. Δημιουργήστε μια νέα παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια βάσει του δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/java/com.aspose.slides/filltype/) του σχήματος σε `Picture`.
1. Ορίστε τη λειτουργία συμπλήρωσης εικόνας σε `Tile` (ή άλλη προτιμώμενη λειτουργία).
1. Δημιουργήστε ένα αντικείμενο [IPPImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/ippimage/) από την εικόνα που θέλετε να χρησιμοποιήσετε.
1. Περνάτε την εικόνα στη μέθοδο `ISlidesPicture.setImage`.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

![Η εικόνα λωτού](lotus.png)

```java
// Δημιουργήστε μια παρουσία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
Presentation presentation = new Presentation();
try {
    // Λάβετε την πρώτη διαφάνεια.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Ορίστε τον τύπο γεμίσματος σε Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Ορίστε τη λειτουργία συμπλήρωσης εικόνας.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // Φορτώστε μια εικόνα και προσθέστε την στους πόρους της παρουσίασης.
    IImage image = Images.fromFile("lotus.png");
    IPPImage picture = presentation.getImages().addImage(image);
    image.dispose();

    // Ορίστε την εικόνα.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Αποθηκεύστε το αρχείο PPTX στο δίσκο.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Το σχήμα με συμπλήρωση εικόνας](picture-fill.png)

### **Τοποθέτηση Εικόνας ως Υφή**

Αν θέλετε να ορίσετε μια τόιωση εικόνας ως υφή και να προσαρμόσετε τη συμπεριφορά της τόιωσης, μπορείτε να χρησιμοποιήσετε τις ακόλουθες μεθόδους της διεπαφής [IPictureFillFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipicturefillformat/) και της κλάσης [PictureFillFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Ορίζει τη λειτουργία συμπλήρωσης εικόνας — είτε `Tile` είτε `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Καθορίζει την στοίχιση των τόιων εντός του σχήματος.
- [setTileFlip](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Ελέγχει εάν η τόιωση θα αναστραφεί οριζόντια, κάθετα ή και τα δύο.
- [setTileOffsetX](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Ορίζει την οριζόντια απόσταση της τόιωσης (σε points) από το αρχικό σημείο του σχήματος.
- [setTileOffsetY](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Ορίζει την κατακόρυφη απόσταση της τόιωσης (σε points) από το αρχικό σημείο του σχήματος.
- [setTileScaleX](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Ορίζει την οριζόντια κλίμακα της τόιωσης ως ποσοστό.
- [setTileScaleY](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Ορίζει την κατακόρυφη κλίμακα της τόιωσης ως ποσοστό.

```java
// Δημιουργήστε μια παρουσία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
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

    // Αναθέστε την εικόνα στο σχήμα.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Διαμορφώστε τη λειτουργία συμπλήρωσης εικόνας και τις ιδιότητες τούλι.
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    // Αποθηκεύστε το αρχείο PPTX στο δίσκο.
    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Οι επιλογές τούλι](tile-options.png)

## **Συμπλήρωση Σταθερού Χρώματος**

Στο PowerPoint, η Συμπλήρωση Σταθερού Χρώματος είναι μια επιλογή μορφοποίησης που γεμίζει ένα σχήμα με ένα ενιαίο, ομοιόμορφο χρώμα. Αυτό το απλό χρώμα φόντου εφαρμόζεται χωρίς βαθμίδες, υφές ή μοτίβα.

Για να εφαρμόσετε συμπλήρωση σταθερού χρώματος σε ένα σχήμα χρησιμοποιώντας το Aspose.Slides, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια νέα παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια βάσει του δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/java/com.aspose.slides/filltype/) του σχήματος σε `Solid`.
1. Αναθέστε το προτιμώμενο χρώμα συμπλήρωσης στο σχήμα.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```java
// Δημιουργήστε μια παρουσία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
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

    // Αποθηκεύστε το αρχείο PPTX στο δίσκο.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Το σχήμα με σταθερό χρώμα](solid-color-fill.png)

## **Ορισμός Διαφάνειας**

Στο PowerPoint, όταν εφαρμόζετε συμπλήρωση στερεού χρώματος, διαβαθμισμένη, εικόνας ή υφής σε σχήματα, μπορείτε επίσης να ορίσετε ένα επίπεδο διαφάνειας για να ελέγξετε την αδιαφάνεια της συμπλήρωσης. Μια υψηλότερη τιμή διαφάνειας κάνει το σχήμα πιο διαφανές, επιτρέποντας στο φόντο ή στα υποκείμενα αντικείμενα να είναι μερικώς ορατά.

Το Aspose.Slides σας επιτρέπει να ορίσετε το επίπεδο διαφάνειας προσαρμόζοντας την τιμή alpha στο χρώμα που χρησιμοποιείται για τη συμπλήρωση. Ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια νέα παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια βάσει του δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/java/com.aspose.slides/filltype/) σε `Solid`.
1. Χρησιμοποιήστε την κλάση `Color` για να ορίσετε ένα χρώμα με διαφάνεια (το συστατικό `alpha` ελέγχει τη διαφάνεια).
1. Αποθηκεύστε την παρουσίαση.

```java
// Δημιουργήστε μια παρουσία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
Presentation presentation = new Presentation();
try {
    // Λάβετε την πρώτη διαφάνεια.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Προσθέστε ένα στερεό ορθογώνιο αυτόματο σχήμα.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Προσθέστε ένα διαφανές ορθογώνιο αυτόματο σχήμα πάνω από το στερεό σχήμα.
    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 204));

    // Αποθηκεύστε το αρχείο PPTX στο δίσκο.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Το διαφανές σχήμα](shape-transparency.png)

## **Περιστροφή Σχημάτων**

Το Aspose.Slides σάς επιτρέπει να περιστρέφετε σχήματα σε παρουσιάσεις PowerPoint. Αυτό μπορεί να είναι χρήσιμο όταν θέλετε να τοποθετήσετε οπτικά στοιχεία με συγκεκριμένη στοίχιση ή σχεδιαστικές απαιτήσεις.

Για να περιστρέψετε ένα σχήμα σε μια διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια νέα παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια βάσει του δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε την ιδιότητα περιστροφής του σχήματος στην επιθυμητή γωνία.
1. Αποθηκεύστε την παρουσίαση.

```java
// Δημιουργήστε μια παρουσία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
Presentation presentation = new Presentation();
try {
    // Λάβετε την πρώτη διαφάνεια.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Περιστρέψτε το σχήμα κατά 5 μοίρες.
    shape.setRotation(5);

    // Αποθηκεύστε το αρχείο PPTX στο δίσκο.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Η περιστροφή του σχήματος](shape-rotation.png)

## **Προσθήκη Εφέ 3Δ Αποκοπής**

Το Aspose.Slides σας επιτρέπει να εφαρμόζετε εφέ 3Δ αποκοπής σε σχήματα, διαμορφώνοντας τις ιδιότητες του [ThreeDFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/threedformat/).

Για να προσθέσετε εφέ 3Δ αποκοπής σε ένα σχήμα, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια νέα παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια βάσει του δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape/) στη διαφάνεια.
1. Διαμορφώστε τις ρυθμίσεις αποκοπής του σχήματος μέσω του [ThreeDFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/threedformat/).
1. Αποθηκεύστε την παρουσίαση.

```java
// Δημιουργήστε μια παρουσία της κλάσης Presentation.
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

![Το εφέ 3Δ αποκοπής](3D-bevel-effect.png)

## **Προσθήκη Εφέ 3Δ Περιστροφής**

Το Aspose.Slides σας επιτρέπει να εφαρμόζετε εφέ 3Δ περιστροφής σε σχήματα, διαμορφώνοντας τις ιδιότητες του [ThreeDFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/threedformat/).

Για να εφαρμόσετε 3Δ περιστροφή σε ένα σχήμα:

1. Δημιουργήστε μια νέα παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια βάσει του δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape/) στη διαφάνεια.
1. Χρησιμοποιήστε τις μεθόδους [setCameraType](https://reference.aspose.com/slides/el/java/com.aspose.slides/icamera/#setCameraType-int-) και [setLightType](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilightrig/#setLightType-int-) για να ορίσετε την 3Δ περιστροφή.
1. Αποθηκεύστε την παρουσίαση.

```java
// Δημιουργήστε μια παρουσία της κλάσης Presentation.
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

![Το εφέ 3Δ περιστροφής](3D-rotation-effect.png)

## **Επαναφορά Μορφοποίησης**

Ο ακόλουθος κώδικας Java δείχνει πώς να επαναφέρετε τη μορφοποίηση μιας διαφάνειας και να επαναφέρετε τη θέση, το μέγεθος και τη μορφοποίηση όλων των σχημάτων με κράτηση θέσης στη [LayoutSlide](https://reference.aspose.com/slides/el/java/com.aspose.slides/layoutslide/) στις προεπιλεγμένες τους ρυθμίσεις:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Επαναφέρετε κάθε σχήμα στη διαφάνεια που έχει κράτηση θέσης στη διάταξη.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Επηρεάζει η μορφοποίηση των σχημάτων το τελικό μέγεθος του αρχείου παρουσίασης;**

Μόνο ελάχιστα. Οι ενσωματωμένες εικόνες και τα μέσα καταλαμβάνουν το μεγαλύτερο μέρος του χώρου του αρχείου, ενώ οι παράμετροι σχήματος όπως χρώματα, εφέ και διαβαθμίσεις αποθηκεύονται ως μεταδεδομένα και δεν προσθέτουν σχεδόν κανένα επιπλέον μέγεθος.

**Πώς μπορώ να εντοπίσω σχήματα σε μια διαφάνεια που μοιράζονται την ίδια μορφοποίηση ώστε να μπορώ να τα ομαδοποιήσω;**

Συγκρίνετε τις κύριες ιδιότητες μορφοποίησης κάθε σχήματος — ρυθμίσεις συμπλήρωσης, γραμμής και εφέ. Εάν όλα τα αντίστοιχα τιμές ταιριάζουν, θεωρήστε τα στυλ ως ταυτόσημα και ομαδοποιήστε λογικά αυτά τα σχήματα, κάτι που απλουστεύει τη μετέπειτα διαχείριση στυλ.

**Μπορώ να αποθηκεύσω ένα σύνολο προσαρμοσμένων στυλ σχήματος σε ξεχωριστό αρχείο για επαναχρησιμοποίηση σε άλλες παρουσιάσεις;**

Ναι. Αποθηκεύστε δείγμα σχημάτων με τα επιθυμητά στυλ σε ένα πρότυπο αρχείο παρουσίασης ή σε αρχείο .POTX. Κατά τη δημιουργία μιας νέας παρουσίασης, ανοίξτε το πρότυπο, κλωνοποιήστε τα στυλ σχήματος που χρειάζεστε και εφαρμόστε ξανά τη μορφοποίησή τους όπου απαιτείται.