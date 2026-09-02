---
title: Διαμόρφωση Σχημάτων PowerPoint σε Java
linktitle: Διαμόρφωση Σχήματος
type: docs
weight: 20
url: /el/java/shape-formatting/
keywords:
- διαμόρφωση σχήματος
- διαμόρφωση γραμμής
- εφέ σχεδίου
- γραμμή σχήματος σκίτσο
- διαμόρφωση στυλ σύνδεσης
- διαβαθμισμένη συμπλήρωση
- συμπλήρωση με μοτίβο
- συμπλήρωση με εικόνα
- συμπλήρωση με υφή
- συμπλήρωση στερεού χρώματος
- διαφάνεια σχήματος
- απεικόνιση σχήματος σε ασπρόμαυρο
- απεικόνιση σχήματος σε γκρι απόχρωση
- περιστροφή σχήματος
- εφέ λοξότμησης 3Δ
- εφέ περιστροφής 3Δ
- επαναφορά μορφοποίησης
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Μάθετε πώς να διαμορφώνετε σχήματα PowerPoint σε Java χρησιμοποιώντας το Aspose.Slides—ορίστε στυλ πλήρωσης, γραμμής και εφέ για αρχεία PPT, PPTX και ODP με ακρίβεια και πλήρη έλεγχο."
---
## **Εισαγωγή**

Στο PowerPoint, μπορείτε να προσθέσετε σχήματα στις διαφάνειες. Επειδή τα σχήματα αποτελούνται από γραμμές, μπορείτε να μορφοποιήσετε τις γραμμές τους τροποποιώντας ή εφαρμόζοντας εφέ στα περίγραμμα τους. Επιπλέον, μπορείτε να μορφοποιήσετε τα σχήματα ορίζοντας ρυθμίσεις που ελέγχουν το πώς γεμίζει το εσωτερικό τους.

![format-shape-powerpoint](format-shape-powerpoint.png)

Το Aspose.Slides for Java παρέχει διεπαφές και μεθόδους που σας επιτρέπουν να μορφοποιήσετε σχήματα χρησιμοποιώντας τις ίδιες επιλογές που διατίθενται στο PowerPoint.

## **Μορφοποίηση Γραμμών**

Χρησιμοποιώντας το Aspose.Slides, μπορείτε να ορίσετε προσαρμοσμένο στυλ γραμμής για ένα σχήμα. Τα παρακάτω βήματα περιγράφουν τη διαδικασία:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/).
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [line style](https://reference.aspose.com/slides/el/java/com.aspose.slides/linestyle/) του σχήματος.
1. Ορίστε το πάχος της γραμμής.
1. Ορίστε το [dash style](https://reference.aspose.com/slides/el/java/com.aspose.slides/linedashstyle/) της γραμμής.
1. Ορίστε το χρώμα της γραμμής για το σχήμα.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο παρακάτω κώδικας δείχνει πώς να μορφοποιήσετε ένα ορθογώνιο `AutoShape`:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
Presentation presentation = new Presentation();
try {
    // Πάρτε την πρώτη διαφάνεια.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Ορίστε το χρώμα γεμίσματος για το σχήμα του ορθογωνίου.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // Εφαρμόστε μορφοποίηση στις γραμμές του ορθογωνίου.
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // Ορίστε το χρώμα για τη γραμμή του ορθογωνίου.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Αποθηκεύστε το αρχείο PPTX στο δίσκο.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Οι μορφοποιημένες γραμμές στην παρουσίαση](formatted-lines.png)

## **Εφαρμογή Σχεδίου Εφέ στις Γραμμές Σχήματος**

Ένα εφέ σχεδίου κάνει τη γραμμή ενός σχήματος να φαίνεται χειρογράφηση. Χρησιμοποιήστε [IShape.getLineFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishape/) για πρόσβαση στις ρυθμίσεις γραμμής, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilineformat/) για πρόσβαση στις ρυθμίσεις σχεδίου και [ISketchFormat.setSketchType](https://reference.aspose.com/slides/el/java/com.aspose.slides/isketchformat/) για επιλογή τιμής από την απαρίθμηση [LineSketchType](https://reference.aspose.com/slides/el/java/com.aspose.slides/linesketchtype/).

Ο παρακάτω κώδικας Java δείχνει πώς να εφαρμόσετε το εφέ [LineSketchType.Curved](https://reference.aspose.com/slides/el/java/com.aspose.slides/linesketchtype/), να διαβάσετε την ρητά εκχωρημένη τιμή και να καταργήσετε το εφέ με [LineSketchType.None](https://reference.aspose.com/slides/el/java/com.aspose.slides/linesketchtype/):

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // Πρόσβαση στη μορφοποίηση γραμμής του σχήματος και στη μορφοποίηση σχεδίου του.
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // Εφαρμογή εφέ σχεδίου.
    sketchFormat.setSketchType(LineSketchType.Curved);

    // Ανάγνωση του εφέ σχεδίου που έχει εκχωρηθεί άμεσα στο σχήμα.
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // Αφαίρεση του εφέ σχεδίου.
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

Η τιμή που επιστρέφεται από το [ISketchFormat.getSketchType](https://reference.aspose.com/slides/el/java/com.aspose.slides/isketchformat/) αντιπροσωπεύει τη ρύθμιση που έχει εκχωρηθεί άμεσα στο σχήμα. Εάν η μορφοποίηση της γραμμής μπορεί να κληρονομηθεί από ένα θέμα, την κύρια διαφάνεια ή τη διαφάνεια διάταξης, χρησιμοποιήστε το [ILineFormat.getEffective](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilineformat/), προσπελάστε το [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilineformateffectivedata/) και διαβάστε το [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/el/java/com.aspose.slides/isketchformateffectivedata/). Η αποτελεσματική τιμή αντικατοπτρίζει τη μορφοποίηση που εφαρμόζεται πραγματικά μετά την επίλυση της κληρονομικότητας:

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

## **Μορφοποίηση Στυλ Συνδέσμων**

Οι τρεις επιλογές τύπου σύνδεσμου είναι:

* Round
* Miter
* Bevel

Από προεπιλογή, όταν το PowerPoint ενώνει δύο γραμμές σε γωνία (όπως στη γωνία ενός σχήματος), χρησιμοποιεί τη ρύθμιση **Round**. Ωστόσο, εάν σχεδιάζετε σχήμα με έντονες γωνίες, μπορείτε να προτιμήσετε την επιλογή **Miter**.

![The join style in the presentation](join-style-powerpoint.png)

Ο παρακάτω κώδικας Java δείχνει πώς τρία ορθογώνια (όπως φαίνεται στην παραπάνω εικόνα) δημιουργήθηκαν χρησιμοποιώντας τις ρυθμίσεις τύπου σύνδεσμου Miter, Bevel και Round:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
Presentation presentation = new Presentation();
try {
    // Πάρτε την πρώτη διαφάνεια.
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

    // Αποθηκεύστε το αρχείο PPTX στο δίσκο.
    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Γραμμική Συμπλήρωση (Gradient Fill)**

Στο PowerPoint, η Γραμμική Συμπλήρωση είναι μια επιλογή μορφοποίησης που σας επιτρέπει να εφαρμόσετε ένα συνεχές μίγμα χρωμάτων σε ένα σχήμα. Για παράδειγμα, μπορείτε να εφαρμόσετε δύο ή περισσότερα χρώματα έτσι ώστε το ένα να εξασθενεί σταδιακά σε άλλο.

Ακολουθήστε τα παρακάτω βήματα για να εφαρμόσετε γραμμική συμπλήρωση σε σχήμα με το Aspose.Slides:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/).
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/java/com.aspose.slides/filltype/) του σχήματος σε `Gradient`.
1. Προσθέστε τα δύο προτιμώμενα χρώματα με καθορισμένες θέσεις χρησιμοποιώντας τις μεθόδους `add` της συλλογής σημείων διαβάθμισης που εκτίθεται από τη διεπαφή [IGradientFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/igradientformat/).
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο παρακάτω κώδικας Java δείχνει πώς να εφαρμόσετε εφέ γραμμικής συμπλήρωσης σε μια έλλειψη:

```java
import com.aspose.slides.*;

// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
Presentation presentation = new Presentation();
try {
    // Πάρτε την πρώτη διαφάνεια.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Προσθέστε ένα αυτόματο σχήμα τύπου Ellipse.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Εφαρμόστε διαβαθμισμένη μορφοποίηση στην έλλειψη.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // Ορίστε την κατεύθυνση της διαβάθμισης.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // Προσθέστε δύο σημεία διαβάθμισης.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // Αποθηκεύστε το αρχείο PPTX στο δίσκο.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![The ellipse with gradient fill](gradient-fill.png)

## **Συμπλήρωση με Μοτίβο (Pattern Fill)**

Στο PowerPoint, η Συμπλήρωση με Μοτίβο είναι μια επιλογή μορφοποίησης που σας επιτρέπει να εφαρμόσετε ένα σχέδιο διχρωμαίας—όπως κουκκίδες, λωρίδες, διαγώνιες γραμμές ή σκακιές—σε ένα σχήμα. Μπορείτε να επιλέξετε προσαρμοσμένα χρώματα για το προσκήνιο και το φόντο του μοτίβου.

Το Aspose.Slides παρέχει πάνω από 45 προεπιλεγμένα στυλ μοτίβου που μπορείτε να εφαρμόσετε σε σχήματα για να ενισχύσετε την οπτική εμφάνιση των παρουσιάσεών σας. Ακόμη και μετά την επιλογή προεπιλεγμένου μοτίβου, μπορείτε να καθορίσετε τα ακριβή χρώματα που θα χρησιμοποιήσει.

Ακολουθήστε τα παρακάτω βήματα για να εφαρμόσετε συμπλήρωση με μοτίβο σε σχήμα με το Aspose.Slides:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/).
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/java/com.aspose.slides/filltype/) του σχήματος σε `Pattern`.
1. Επιλέξτε ένα στυλ μοτίβου από τις προεπιλεγμένες επιλογές.
1. Ορίστε το [Background Color](https://reference.aspose.com/slides/el/java/com.aspose.slides/patternformat/#getBackColor--) του μοτίβου.
1. Ορίστε το [Foreground Color](https://reference.aspose.com/slides/el/java/com.aspose.slides/patternformat/#getForeColor--) του μοτίβου.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο παρακάτω κώδικας Java δείχνει πώς να εφαρμόσετε συμπλήρωση με μοτίβο σε ένα ορθογώνιο:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
Presentation presentation = new Presentation();
try {
    // Πάρτε την πρώτη διαφάνεια.
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

    // Αποθηκεύστε το αρχείο PPTX στο δίσκο.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![The rectangle with pattern fill](pattern-fill.png)

## **Συμπλήρωση με Εικόνα (Picture Fill)**

Στο PowerPoint, η Συμπλήρωση με Εικόνα είναι μια επιλογή μορφοποίησης που σας επιτρέπει να εισάγετε μια εικόνα μέσα σε ένα σχήμα—χρησιμοποιώντας ουσιαστικά την εικόνα ως φόντο του σχήματος.

Ακολουθήστε τα παρακάτω βήματα για να χρησιμοποιήσετε το Aspose.Slides ώστε να εφαρμόσετε συμπλήρωση με εικόνα σε σχήμα:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/).
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/java/com.aspose.slides/filltype/) του σχήματος σε `Picture`.
1. Ορίστε τη λειτουργία συμπλήρωσης εικόνας σε `Tile` (ή άλλη προτιμώμενη λειτουργία).
1. Δημιουργήστε ένα αντικείμενο [IPPImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/ippimage/) από την εικόνα που θέλετε να χρησιμοποιήσετε.
1. Περάστε την εικόνα στη μέθοδο `ISlidesPicture.setImage`.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ας υποθέσουμε ότι έχουμε ένα αρχείο "lotus.png" με την παρακάτω εικόνα:

![The lotus picture](lotus.png)

Ο παρακάτω κώδικας Java δείχνει πώς να γεμίσετε ένα σχήμα με την εικόνα:

```java
import com.aspose.slides.*;

// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
Presentation presentation = new Presentation();
try {
    // Πάρτε την πρώτη διαφάνεια.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Ορίστε τον τύπο γεμίσματος σε Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Ορίστε τη λειτουργία γεμίσματος εικόνας.
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

Το αποτέλεσμα:

![The shape with picture fill](picture-fill.png)

### **Τίτλεμα Εικόνας ως Υφή**

Εάν θέλετε να ορίσετε μια τισάριστη εικόνα ως υφή και να προσαρμόσετε τη συμπεριφορά των παραθύρων, μπορείτε να χρησιμοποιήσετε τις ακόλουθες μεθόδους της διεπαφής [IPictureFillFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipicturefillformat/) και της κλάσης [PictureFillFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Ορίζει τη λειτουργία συμπλήρωσης εικόνας—`Tile` ή `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Καθορίζει την ευθυγράμμιση των πλακιδίων μέσα στο σχήμα.
- [setTileFlip](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Ελέγχει εάν το πλακίδιο θα αναστραφεί οριζοντίως, κάθετα ή και τα δύο.
- [setTileOffsetX](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Ορίζει την οριζόντια μετατόπιση του πλακιδίου (σε points) από την αρχή του σχήματος.
- [setTileOffsetY](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Ορίζει την κάθετη μετατόπιση του πλακιδίου (σε points) από την αρχή του σχήματος.
- [setTileScaleX](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Καθορίζει την οριζόντια κλίμακα του πλακιδίου ως ποσοστό.
- [setTileScaleY](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Καθορίζει την κάθετη κλίμακα του πλακιδίου ως ποσοστό.

Ο παρακάτω κώδικας δείχνει πώς να προσθέσετε ένα ορθογώνιο σχήμα με τισαρισμένη συμπλήρωση εικόνας και να ρυθμίσετε τις επιλογές πλακιδίων:

```java
import com.aspose.slides.*;

// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
Presentation presentation = new Presentation();
try {
    // Πάρτε την πρώτη διαφάνεια.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Ορίστε τον τύπο γεμίσματος του σχήματος σε Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Φορτώστε την εικόνα και προσθέστε την στους πόρους της παρουσίασης.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Αντιστοιχίστε την εικόνα στο σχήμα.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Διαμορφώστε τη λειτουργία γεμίσματος εικόνας και τις ιδιότητες τούλισης.
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

Το αποτέλεσμα:

![The tile options](tile-options.png)

## **Συμπλήρωση με Σταθερό Χρώμα (Solid Color Fill)**

Στο PowerPoint, η Συμπλήρωση με Σταθερό Χρώμα είναι μια επιλογή μορφοποίησης που γεμίζει ένα σχήμα με ένα ενιαίο, ομοιόμορφο χρώμα. Αυτό το απλό χρώμα φόντου εφαρμόζεται χωρίς διαβαθμίσεις, υφές ή μοτίβα.

Για να εφαρμόσετε συμπλήρωση με σταθερό χρώμα σε σχήμα με το Aspose.Slides, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/).
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/java/com.aspose.slides/filltype/) του σχήματος σε `Solid`.
1. Αναθέστε το προτιμώμενο χρώμα πλήρωσης στο σχήμα.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο παρακάτω κώδικας Java δείχνει πώς να εφαρμόσετε συμπλήρωση με σταθερό χρώμα σε ένα ορθογώνιο σε διαφάνεια PowerPoint:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
Presentation presentation = new Presentation();
try {
    // Πάρτε την πρώτη διαφάνεια.
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

Το αποτέλεσμα:

![The shape with solid color fill](solid-color-fill.png)

## **Ορισμός Διαφάνειας**

Στο PowerPoint, όταν εφαρμόζετε συμπλήρωση με σταθερό χρώμα, διαβάθμιση, εικόνα ή υφή σε σχήματα, μπορείτε επίσης να ορίσετε επίπεδο διαφάνειας για να ελέγξετε την αδιαφάνεια της συμπλήρωσης. Μια υψηλότερη τιμή διαφάνειας κάνει το σχήμα πιο διαυγές, επιτρέποντας στο φόντο ή στα υποκείμενα αντικείμενα να είναι μερικώς ορατά.

Το Aspose.Slides σας επιτρέπει να ορίσετε το επίπεδο διαφάνειας προσαρμόζοντας την τιμή alpha στο χρώμα που χρησιμοποιείται για τη συμπλήρωση. Δείτε πώς:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/).
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/java/com.aspose.slides/filltype/) σε `Solid`.
1. Χρησιμοποιήστε το `Color` για να ορίσετε ένα χρώμα με διαφάνεια (το συστατικό `alpha` ελέγχει τη διαφάνεια).
1. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας Java δείχνει πώς να εφαρμόσετε χρώμα συμπλήρωσης με διαφάνεια σε ένα ορθογώνιο:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
Presentation presentation = new Presentation();
try {
    // Πάρτε την πρώτη διαφάνεια.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Προσθέστε ένα στερεό ορθογώνιο αυτόματο σχήμα.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Προσθέστε ένα διαφανές ορθογώνιο αυτόματο σχήμα πάνω στο στερεό σχήμα.
    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 204));

    // Αποθηκεύστε το αρχείο PPTX στο δίσκο.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![The transparent shape](shape-transparency.png)

## **Περιστροφή Σχημάτων**

Το Aspose.Slides σας επιτρέπει να περιστρέφετε σχήματα σε παρουσιάσεις PowerPoint. Αυτό μπορεί να είναι χρήσιμο όταν τοποθετείτε οπτικά στοιχεία με συγκεκριμένες ανάγκες στοίχισης ή σχεδίασης.

Για να περιστρέψετε ένα σχήμα σε μια διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/).
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε την ιδιότητα περιστροφής του σχήματος στην επιθυμητή γωνία.
1. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας Java δείχνει πώς να περιστρέψετε ένα σχήμα κατά 5 μοίρες:

```java
import com.aspose.slides.*;

// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
Presentation presentation = new Presentation();
try {
    // Πάρτε την πρώτη διαφάνεια.
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

Το αποτέλεσμα:

![The shape rotation](shape-rotation.png)

## **Προσθήκη Εφέ 3Δ Λείανσης (3D Bevel Effects)**

Το Aspose.Slides σας επιτρέπει να εφαρμόζετε εφέ 3Δ λείανσης σε σχήματα ρυθμίζοντας τις ιδιότητες του [ThreeDFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/threedformat/).

Για να προσθέσετε εφέ 3Δ λείανσης σε σχήμα, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/).
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape/) στη διαφάνεια.
1. Ρυθμίστε το [ThreeDFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/threedformat/) του σχήματος για να ορίσετε τις ρυθμίσεις λείανσης.
1. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας Java δείχνει πώς να εφαρμόσετε εφέ 3Δ λείανσης σε σχήμα:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

![The 3D bevel effect](3D-bevel-effect.png)

## **Προσθήκη Εφέ 3Δ Περιστροφής (3D Rotation Effects)**

Το Aspose.Slides σας επιτρέπει να εφαρμόζετε εφέ 3Δ περιστροφής σε σχήματα ρυθμίζοντας τις ιδιότητες του [ThreeDFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/threedformat/).

Για να εφαρμόσετε 3Δ περιστροφή σε σχήμα:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/).
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape/) στη διαφάνεια.
1. Χρησιμοποιήστε τις μεθόδους [setCameraType](https://reference.aspose.com/slides/el/java/com.aspose.slides/icamera/#setCameraType-int-) και [setLightType](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilightrig/#setLightType-int-) για να ορίσετε την 3Δ περιστροφή.
1. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας Java δείχνει πώς να εφαρμόσετε εφέ 3Δ περιστροφής σε σχήμα:

```java
import com.aspose.slides.*;

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

![The 3D rotation effect](3D-rotation-effect.png)

## **Έλεγχος Μαυρό-Άσπρου Απόδοσης για Σχήματα**

Η μέθοδος [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) καθορίζει πώς θα αποδίδεται ένα μεμονωμένο σχήμα όταν μια παρουσίαση προβάλλεται ή επεξεργάζεται σε μαυρό‑άσπρο τρόπο. Δεν ενεργοποιεί την εμφάνιση σε μαυρό‑άσπρο από μόνη της και δεν αλλάζει τη συμπλήρωση, τη γραμμή ή άλλες μορφοποιήσεις του σχήματος σε κανονική χρωματική λειτουργία.

Χρησιμοποιήστε μια τιμή από την κλάση [BlackWhiteMode](https://reference.aspose.com/slides/el/java/com.aspose.slides/blackwhitemode/) για να επιλέξετε την επιθυμητή συμπεριφορά. Για παράδειγμα, το `Automatic` επιτρέπει στην εφαρμογή απόδοσης να επιλέξει τη μετατροπή, τα `Gray` και `LightGray` χρησιμοποιούν γκριχρωματική απόδοση, το `BlackWhite` χρησιμοποιεί μόνο μαύρο και άσπρο, τα `Black` και `White` επιβάλλουν ένα μόνο χρώμα, το `Color` διατηρεί το κανονικό χρώμα και το `Hidden` παραλείπει το σχήμα σε μαυρό‑άσπρο τρόπο. Το `NotDefined` σημαίνει ότι δεν έχει οριστεί λειτουργία σε επίπεδο σχήματος.

Ο παρακάτω κώδικας Java δημιουργεί ένα χρωματισμένο σχήμα και το εμφανίζει γκρι σε λειτουργία μαυρό‑άσπρου:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    // Διατηρήστε το πορτοκαλί γέμισμα σε έγχρωμη λειτουργία, αλλά αποδώστε το σχήμα με γκρι απόχρωση σε μαυρο-άσπρο τρόπο.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Σε κανονική χρωματική λειτουργία, το ορθογώνιο διατηρεί το πορτοκαλί γέμισμά του. Σε ροή εργασίας μαυρό‑άσπρου, χρησιμοποιεί γκριχρωματική απόδοση επειδή η λειτουργία του έχει οριστεί σε `Gray`. Αυτό σας επιτρέπει να διατηρείτε μια πλήρως έγχρωμη διαφάνεια, ορίζοντας παράλληλα διαφορετική εμφάνιση για εκτύπωση, προεπισκόπηση ή άλλες ροές εργασίας που σέβονται τις ρυθμίσεις μαυρό‑άσπρου.

## **Επαναφορά Μορφοποίησης**

Ο παρακάτω κώδικας Java δείχνει πώς να επαναφέρετε τη μορφοποίηση μιας διαφάνειας και να επαναφέρετε τη θέση, το μέγεθος και τη μορφοποίηση όλων των σχημάτων με σύμβολα στην [LayoutSlide](https://reference.aspose.com/slides/el/java/com.aspose.slides/layoutslide/) στις προεπιλογές τους:

```java
import com.aspose.slides.*;

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

**Επηρεάζει η μορφοποίηση του σχήματος το τελικό μέγεθος του αρχείου παρουσίασης;**

Μόνο ελάχιστα. Οι ενσωματωμένες εικόνες και τα μέσα καταλαμβάνουν το μεγαλύτερο μέρος του χώρου του αρχείου, ενώ οι παράμετροι σχήματος όπως χρώματα, εφέ και διαβαθμίσεις αποθηκεύονται ως μεταδεδομένα και δεν προσθέτουν ουσιαστικά επιπλέον μέγεθος.

**Πώς μπορώ να εντοπίσω σχήματα σε μια διαφάνεια που έχουν την ίδια μορφοποίηση ώστε να τα ομαδοποιήσω;**

Συγκρίνετε τις κύριες ιδιότητες μορφοποίησης κάθε σχήματος—συμπλήρωση, γραμμή και ρυθμίσεις εφέ. Εάν όλες οι αντίστοιχες τιμές ταιριάζουν, θεωρήστε τα στυλ ως ίσα και ομαδοποιήστε λογικά τα σχήματα, γεγονός που απλοποιεί τη μετέπειτα διαχείριση στυλ.

**Μπορώ να αποθηκεύσω ένα σύνολο προσαρμοσμένων στυλ σχήματος σε ξεχωριστό αρχείο για επαναχρησιμοποίηση σε άλλες παρουσιάσεις;**

Ναι. Αποθηκεύστε δείγματα σχημάτων με τα επιθυμητά στυλ σε ένα πρότυπο σετ διαφανειών ή σε αρχείο .POTX. Όταν δημιουργείτε νέα παρουσίαση, ανοίξτε το πρότυπο, κλωνοποιήστε τα σχήματα που χρειάζεστε και εφαρμόστε ξανά τη μορφοποίησή τους όπου απαιτείται.