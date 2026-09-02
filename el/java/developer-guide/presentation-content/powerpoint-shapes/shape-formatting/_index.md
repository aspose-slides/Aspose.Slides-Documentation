---
title: Μορφοποίηση Σχημάτων PowerPoint σε Java
linktitle: Μορφοποίηση Σχήματος
type: docs
weight: 20
url: /el/java/shape-formatting/
keywords:
- μορφοποίηση σχήματος
- μορφοποίηση γραμμής
- εφέ σκίτσο
- γραμμή σχήματος σκίτσου
- μορφοποίηση στυλ σύζευξης
- γεμισμα διαβάθμισης
- γεμισμα μοτίβου
- γεμισμα εικόνας
- γεμισμα υφής
- γεμισμα στέρεου χρώματος
- διαφάνεια σχήματος
- περιστροφή σχήματος
- 3Δ εφέ λοξότητας
- 3Δ εφέ περιστροφής
- επαναφορά μορφοποίησης
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Μάθετε πώς να μορφοποιείτε σχήματα PowerPoint σε Java χρησιμοποιώντας το Aspose.Slides—ορίστε στιλ γεμίσματος, γραμμής και εφέ για αρχεία PPT, PPTX και ODP με ακρίβεια και πλήρη έλεγχο."
---
## **Εισαγωγή**

Στο PowerPoint, μπορείτε να προσθέσετε σχήματα σε διαφάνειες. Δεδομένου ότι τα σχήματα αποτελούνται από γραμμές, μπορείτε να μορφοποιήσετε τις γραμμές τους τροποποιώντας ή εφαρμόζοντας εφέ στα περιγράμματά τους. Επιπλέον, μπορείτε να μορφοποιήσετε τα σχήματα ορίζοντας ρυθμίσεις που ελέγχουν πώς γεμίζουν τα εσωτερικά τους.

![μορφοποίηση-σχήματος-powerpoint](format-shape-powerpoint.png)

Το Aspose.Slides for Java παρέχει διεπαφές και μεθόδους που σας επιτρέπουν να μορφοποιήσετε σχήματα χρησιμοποιώντας τις ίδιες επιλογές που διατίθενται στο PowerPoint.

## **Μορφοποίηση Γραμμών**

Χρησιμοποιώντας το Aspose.Slides, μπορείτε να ορίσετε ένα προσαρμοσμένο στυλ γραμμής για ένα σχήμα. Τα παρακάτω βήματα περιγράφουν τη διαδικασία:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [line style](https://reference.aspose.com/slides/el/java/com.aspose.slides/linestyle/) του σχήματος.
1. Ορίστε το πάχος γραμμής.
1. Ορίστε το [dash style](https://reference.aspose.com/slides/el/java/com.aspose.slides/linedashstyle/) της γραμμής.
1. Ορίστε το χρώμα γραμμής για το σχήμα.
1. Αποθηκεύστε την τροποποιημένη παρουσία ως αρχείο PPTX.

Ο παρακάτω κώδικας δείχνει πώς να μορφοποιήσετε ένα ορθογώνιο `AutoShape`:

```java
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
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

    // Αποθηκεύστε το αρχείο PPTX στον δίσκο.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Οι μορφοποιημένες γραμμές στην παρουσία](formatted-lines.png)

## **Εφαρμογή Σχεδίου Εφέ στις Γραμμές Σχήματος**

Ένα εφέ σκίτσο κάνει τη γραμμή ενός σχήματος να φαίνεται σχεδιασμένη με το χέρι. Χρησιμοποιήστε [IShape.getLineFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishape/) για να έχετε πρόσβαση στις ρυθμίσεις γραμμής, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilineformat/) για να αποκτήσετε πρόσβαση στις ρυθμίσεις σκίτσου, και [ISketchFormat.setSketchType](https://reference.aspose.com/slides/el/java/com.aspose.slides/isketchformat/) για να επιλέξετε μια τιμή από την απαρίθμηση [LineSketchType](https://reference.aspose.com/slides/el/java/com.aspose.slides/linesketchtype/).

Ο παρακάτω κώδικας Java δείχνει πώς να εφαρμόσετε ένα εφέ [LineSketchType.Curved](https://reference.aspose.com/slides/el/java/com.aspose.slides/linesketchtype/) , να διαβάσετε την ρητά ορισμένη τιμή και να αφαιρέσετε το εφέ με [LineSketchType.None](https://reference.aspose.com/slides/el/java/com.aspose.slides/linesketchtype/):

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // Πρόσβαση στη μορφή γραμμής του σχήματος και στη μορφή σκίτσου του.
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // Εφαρμόστε ένα εφέ σκίτσου.
    sketchFormat.setSketchType(LineSketchType.Curved);

    // Διαβάστε το εφέ σκίτσου που έχει ανατεθεί απευθείας στο σχήμα.
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // Αφαιρέστε το εφέ σκίτσου.
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

Η τιμή που επιστρέφεται από το [ISketchFormat.getSketchType](https://reference.aspose.com/slides/el/java/com.aspose.slides/isketchformat/) αντιπροσωπεύει τη ρύθμιση που έχει ανατεθεί άμεσα στο σχήμα. Εάν η μορφοποίηση της γραμμής μπορεί να κληρονόμησέται από ένα θέμα, την κύρια διαφάνεια ή τη διάταξη, χρησιμοποιήστε το [ILineFormat.getEffective](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilineformat/), αποκτήστε πρόσβαση στο [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilineformateffectivedata/) και διαβάστε το [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/el/java/com.aspose.slides/isketchformateffectivedata/). Η αποτελεσματική τιμή αντικατοπτρίζει τη μορφοποίηση που εφαρμόζεται πραγματικά μετά την επίλυση της κληρονομικότητας:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    ILineFormat lineFormat = shape.getLineFormat();

    int explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    ILineFormatEffectiveData effectiveLineFormat = lineFormat.getEffective();
    int effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    System.out.println("Explicit sketch type: " + explicitSketchType);
    System.out.println("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **Μορφοποίηση Στυλ Συζεύξεων**

Εδώ είναι οι τρεις επιλογές τύπου σύζευξης:

* Round
* Miter
* Bevel

Από προεπιλογή, όταν το PowerPoint συνδέει δύο γραμμές υπό γωνία (όπως στη γωνία ενός σχήματος), χρησιμοποιεί την ρύθμιση **Round**. Ωστόσο, εάν σχεδιάζετε ένα σχήμα με κοφτές γωνίες, μπορεί να προτιμήσετε την επιλογή **Miter**.

![Το στυλ σύζευξης στην παρουσία](join-style-powerpoint.png)

Ο παρακάτω κώδικας Java δείχνει πώς τρία ορθογώνια (όπως φαίνεται στην παραπάνω εικόνα) δημιουργήθηκαν με τις ρυθμίσεις σύζευξης Miter, Bevel και Round:

```java
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
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

    // Ορίστε το πλάτος γραμμής.
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

    // Ορίστε το στυλ σύζευξης.
    shape1.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    shape2.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    shape3.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    // Προσθέστε κείμενο σε κάθε Rectangle.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // Αποθηκεύστε το αρχείο PPTX στον δίσκο.
    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Γεμισμα Διαβάθμισης**

Στο PowerPoint, το Γεμισμα Διαβάθμισης είναι μια επιλογή μορφοποίησης που σας επιτρέπει να εφαρμόσετε μια συνεχόμενη ανάμειξη χρωμάτων σε ένα σχήμα. Για παράδειγμα, μπορείτε να εφαρμόσετε δύο ή περισσότερα χρώματα με τρόπο που το ένα σταδιακά να μετατρέπεται σε άλλο.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/java/com.aspose.slides/filltype/) του σχήματος σε `Gradient`.
1. Προσθέστε τα δύο προτιμώμενα χρώματά σας με καθορισμένες θέσεις χρησιμοποιώντας τις μεθόδους `add` της συλλογής gradient stop που εκτίθεται από τη διεπαφή [IGradientFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/igradientformat/).
1. Αποθηκεύστε την τροποποιημένη παρουσία ως αρχείο PPTX.

```java
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
Presentation presentation = new Presentation();
try {
    // Λάβετε την πρώτη διαφάνεια.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Προσθέστε ένα αυτόματο σχήμα τύπου Ellipse.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Εφαρμόστε μορφοποίηση διαβάθμισης στην Ellipse.
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

![Η έλλειψη με γεμισμα διαβάθμισης](gradient-fill.png)

## **Γεμισμα Σχεδίου**

Στο PowerPoint, το Γεμισμα Σχεδίου είναι μια επιλογή μορφοποίησης που σας επιτρέπει να εφαρμόσετε ένα σχεδιασμό δύο χρωμάτων — όπως σημεία, λωρίδες, διαγώνιες γραμμές ή σκαρίφημα — σε ένα σχήμα. Μπορείτε να επιλέξετε προσαρμοσμένα χρώματα για το προσκήνιο και το παρασκήνιο του σχεδίου.

Το Aspose.Slides παρέχει πάνω από 45 προεπιλεγμένα στυλ προτύπων που μπορείτε να εφαρμόσετε σε σχήματα για να ενισχύσετε την οπτική ελκυστικότητα των παρουσιάσεών σας. Ακόμη και αφού έχετε επιλέξει ένα προεπιλεγμένο σχέδιο, μπορείτε να καθορίσετε τα ακριβή χρώματα που θα χρησιμοποιήσει.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/java/com.aspose.slides/filltype/) του σχήματος σε `Pattern`.
1. Επιλέξτε ένα στυλ προτύπου από τις προεπιλεγμένες επιλογές.
1. Ορίστε το [Background Color](https://reference.aspose.com/slides/el/java/com.aspose.slides/patternformat/#getBackColor--) του προτύπου.
1. Ορίστε το [Foreground Color](https://reference.aspose.com/slides/el/java/com.aspose.slides/patternformat/#getForeColor--) του προτύπου.
1. Αποθηκεύστε την τροποποιημένη παρουσία ως αρχείο PPTX.

```java
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
Presentation presentation = new Presentation();
try {
    // Λάβετε την πρώτη διαφάνεια.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Ορίστε τον τύπο γεμίσματος σε Pattern.
    shape.getFillFormat().setFillType(FillType.Pattern);

    // Ορίστε το στυλ του προτύπου.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // Ορίστε τα χρώματα φόντου και προσκηνίου του προτύπου.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // Αποθηκεύστε το αρχείο PPTX στον δίσκο.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Το ορθογώνιο με γεμισμα σχεδίου](pattern-fill.png)

## **Γεμισμα Εικόνας**

Στο PowerPoint, το Γεμισμα Εικόνας είναι μια επιλογή μορφοποίησης που σας επιτρέπει να ενσωματώσετε μια εικόνα μέσα σε ένα σχήμα — χρησιμοποιώντας αποτελεσματικά την εικόνα ως φόντο του σχήματος.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/java/com.aspose.slides/filltype/) του σχήματος σε `Picture`.
1. Ορίστε τη λειτουργία γεμίσματος εικόνας σε `Tile` (ή άλλη προτιμώμενη λειτουργία).
1. Δημιουργήστε ένα αντικείμενο [IPPImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/ippimage/) από την εικόνα που θέλετε να χρησιμοποιήσετε.
1. Μεταβιβάστε την εικόνα στη μέθοδο `ISlidesPicture.setImage`.
1. Αποθηκεύστε την τροποποιημένη παρουσία ως αρχείο PPTX.

![Η εικόνα λωτόν](lotus.png)

```java
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
Presentation presentation = new Presentation();
try {
    // Λάβετε την πρώτη διαφάνεια.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Ορίστε τον τύπο γεμίσματος σε Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Ορίστε τη λειτουργία γεμίσματος εικόνας.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // Φορτώστε μια εικόνα και προσθέστε τη στους πόρους της παρουσίασης.
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

![Το σχήμα με γεμισμα εικόνας](picture-fill.png)

### **Πλακίδια Εικόνας ως Υφή**

Εάν θέλετε να ορίσετε μια πλακιδισμένη εικόνα ως υφή και να προσαρμόσετε τη συμπεριφορά του πλακιδίου, μπορείτε να χρησιμοποιήσετε τις παρακάτω μεθόδους της διεπαφής [IPictureFillFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipicturefillformat/) και της κλάσης [PictureFillFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Ορίζει τη λειτουργία γεμίσματος εικόνας — είτε `Tile` είτε `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Καθορίζει την ευθυγράμμιση των πλακιδίων μέσα στο σχήμα.
- [setTileFlip](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Ελέγχει αν το πλακίδιο θα αναστραφεί οριζόντια, κάθετα ή και τα δύο.
- [setTileOffsetX](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Ορίζει την οριζόντια μετατόπιση του πλακιδίου (σε σημεία) από το άκρο του σχήματος.
- [setTileOffsetY](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Ορίζει την κάθετη μετατόπιση του πλακιδίου (σε σημεία) από το άκρο του σχήματος.
- [setTileScaleX](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Ορίζει την οριζόντια κλίμακα του πλακιδίου ως ποσοστό.
- [setTileScaleY](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Ορίζει την κάθετη κλίμακα του πλακιδίου ως ποσοστό.

```java
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
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

    // Διαμορφώστε τη λειτουργία γεμίσματος εικόνας και τις ιδιότητες πλακιδίων.
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

![Οι επιλογές πλακιδίου](tile-options.png)

## **Γεμισμα Στέρεου Χρώματος**

Στο PowerPoint, το Γεμισμα Στέρεου Χρώματος είναι μια επιλογή μορφοποίησης που γεμίζει ένα σχήμα με ένα ενιαίο, ομοιόμορφο χρώμα. Αυτό το απλό χρώμα φόντου εφαρμόζεται χωρίς διαβαθμίσεις, υφές ή μοτίβα.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/java/com.aspose.slides/filltype/) του σχήματος σε `Solid`.
1. Αναθέστε το προτιμώμενο χρώμα γεμίσματος στο σχήμα.
1. Αποθηκεύστε την τροποποιημένη παρουσία ως αρχείο PPTX.

```java
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
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

![Το σχήμα με γεμισμα στέρεου χρώματος](solid-color-fill.png)

## **Ορισμός Διαφάνειας**

Στο PowerPoint, όταν εφαρμόζετε γεμισμα στέρεου χρώματος, διαβάθμισης, εικόνας ή υφής σε σχήματα, μπορείτε επίσης να ορίσετε ένα επίπεδο διαφάνειας για να ελέγξετε την αδιαφάνεια του γεμίσματος. Μια μεγαλύτερη τιμή διαφάνειας κάνει το σχήμα πιο διαυγές, επιτρέποντας στο φόντο ή στα υποκείμενα αντικείμενα να είναι εν μέρει ορατά.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/java/com.aspose.slides/filltype/) σε `Solid`.
1. Χρησιμοποιήστε το `Color` για να ορίσετε ένα χρώμα με διαφάνεια (το στοιχείο `alpha` ελέγχει τη διαφάνεια).
1. Αποθηκεύστε την παρουσία.

```java
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
Presentation presentation = new Presentation();
try {
    // Λάβετε την πρώτη διαφάνεια.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Προσθέστε ένα στερεό αυτόματο σχήμα τύπου Rectangle.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Προσθέστε ένα διαφανές αυτόματο σχήμα τύπου Rectangle πάνω από το στερεό σχήμα.
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

## **Περιστροφή Σχημάτων**

Το Aspose.Slides σας επιτρέπει να περιστρέφετε σχήματα σε παρουσιάσεις PowerPoint. Αυτό μπορεί να είναι χρήσιμο κατά την τοποθέτηση οπτικών στοιχείων με συγκεκριμένες ανάγκες στοίχισης ή σχεδίασης.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε την ιδιότητα περιστροφής του σχήματος στη ζητούμενη γωνία.
1. Αποθηκεύστε την παρουσία.

```java
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
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

## **Προσθήκη 3Δ Εφέ Λοξότητας**

Το Aspose.Slides σας επιτρέπει να εφαρμόζετε 3Δ εφέ λοξότητας σε σχήματα διαμορφώνοντας τις ιδιότητες τους [ThreeDFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/threedformat/).

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape/) στη διαφάνεια.
1. Διαμορφώστε το [ThreeDFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/threedformat/) του σχήματος για να ορίσετε τις ρυθμίσεις λοξότητας.
1. Αποθηκεύστε την παρουσία.

```java
// Δημιουργήστε ένα στιγμιότυπο της κλάσης Presentation.
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

    // Set the shape's ThreeDFormat properties.
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    // Save the presentation as a PPTX file.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Το 3Δ εφέ λοξότητας](3D-bevel-effect.png)

## **Προσθήκη 3Δ Εφέ Περιστροφής**

Το Aspose.Slides σας επιτρέπει να εφαρμόζετε 3Δ εφέ περιστροφής σε σχήματα διαμορφώνοντας τις ιδιότητες τους [ThreeDFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/threedformat/).

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape/) στη διαφάνεια.
1. Χρησιμοποιήστε τις [setCameraType](https://reference.aspose.com/slides/el/java/com.aspose.slides/icamera/#setCameraType-int-) και [setLightType](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilightrig/#setLightType-int-) για να ορίσετε την 3Δ περιστροφή.
1. Αποθηκεύστε την παρουσία.

```java
// Δημιουργήστε ένα στιγμιότυπο της κλάσης Presentation.
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

![Το 3Δ εφέ περιστροφής](3D-rotation-effect.png)

## **Επαναφορά Μορφοποίησης**

Ο παρακάτω κώδικας Java δείχνει πώς να επαναφέρετε τη μορφοποίηση μιας διαφάνειας και να επαναφέρετε τη θέση, το μέγεθος και τη μορφοποίηση όλων των σχημάτων με δεσμευμένα στοιχεία στην [LayoutSlide](https://reference.aspose.com/slides/el/java/com.aspose.slides/layoutslide/) στις προεπιλεγμένες ρυθμίσεις τους:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Επαναφορά κάθε σχήματος στη διαφάνεια που έχει δεσμευτικό στοιχείο στην διάταξη.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Επηρεάζει η μορφοποίηση του σχήματος το τελικό μέγεθος του αρχείου παρουσίασης;**

Μόνο ελάχιστα. Οι ενσωματωμένες εικόνες και τα μέσα καταλαμβάνουν το μεγαλύτερο μέρος του χώρου του αρχείου, ενώ οι παράμετροι των σχημάτων όπως χρώματα, εφέ και διαβαθμίσεις αποθηκεύονται ως μεταδεδομένα και δεν προσθέτουν πρακτικά επιπλέον μέγεθος.

**Πώς μπορώ να εντοπίσω σχήματα σε μια διαφάνεια που μοιράζονται την ίδια μορφοποίηση ώστε να τα ομαδοποιήσω;**

Συγκρίνετε τα βασικά χαρακτηριστικά μορφοποίησης κάθε σχήματος — ρυθμίσεις γεμίσματος, γραμμής και εφέ. Εάν όλες οι αντίστοιχες τιμές ταιριάζουν, αντιμετωπίστε τα στυλ ως τα ίδια και λογικά ομαδοποιήστε αυτά τα σχήματα, γεγονός που απλοποιεί τη διαχείριση στυλ αργότερα.

**Μπορώ να αποθηκεύσω ένα σύνολο προσαρμοσμένων στυλ σχήματος σε ξεχωριστό αρχείο για επαναχρησιμοποίηση σε άλλες παρουσιάσεις;**

Ναι. Αποθηκεύστε δείγματα σχημάτων με τα επιθυμητά στυλ σε ένα αρχείο προτύπου διαφανειών ή σε αρχείο .POTX. Όταν δημιουργείτε μια νέα παρουσία, ανοίξτε το πρότυπο, κλωνοποιήστε τα σχήματα με το στυλ που χρειάζεστε και εφαρμόστε ξανά τη μορφοποίησή τους όπου απαιτείται.