---
title: Διαμόρφωση Σχημάτων PowerPoint σε Android
linktitle: Μορφοποίηση Σχήματος
type: docs
weight: 20
url: /el/androidjava/shape-formatting/
keywords:
- διαμόρφωση σχήματος
- διαμόρφωση γραμμής
- εφέ σχεδίου
- γραμμή σχήματος με σχέδιο
- διαμόρφωση στυλ σύνδεσης
- γέμισμα διαβάθμισης
- γέμισμα μοτίβου
- γέμισμα εικόνας
- γέμισμα υφής
- γέμισμα στερεού χρώματος
- διαφάνεια σχήματος
- αποτέλεσμα σχήματος σε ασπρόμαυρο
- αποτέλεσμα σχήματος σε γκρι κλίμακα
- περιστροφή σχήματος
- εφέ 3Δ κότσι
- εφέ 3Δ περιστροφής
- επαναφορά μορφοποίησης
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Μάθετε πώς να διαμορφώνετε σχήματα PowerPoint σε Android χρησιμοποιώντας το Aspose.Slides—ορίστε στυλ γέμισης, γραμμής και εφέ για αρχεία PPT, PPTX και ODP με ακρίβεια και πλήρη έλεγχο."
---
## **Εισαγωγή**

Στο PowerPoint, μπορείτε να προσθέσετε σχήματα στις διαφάνειες. Επειδή τα σχήματα αποτελούνται από γραμμές, μπορείτε να τα μορφοποιήσετε τροποποιώντας ή εφαρμόζοντας εφέ στα περίγραμμα τους. Επιπλέον, μπορείτε να μορφοποιήσετε τα σχήματα ορίζοντας ρυθμίσεις που ελέγχουν πώς γεμίζει το εσωτερικό τους.

![format-shape-powerpoint](format-shape-powerpoint.png)

Το Aspose.Slides for Android via Java παρέχει διασυνέδεια και μεθόδους που σας επιτρέπουν να μορφοποιήσετε σχήματα χρησιμοποιώντας τις ίδιες επιλογές που διατίθενται στο PowerPoint.

## **Μορφοποίηση Γραμμών**

Με το Aspose.Slides, μπορείτε να ορίσετε ένα προσαρμοσμένο στυλ γραμμής για ένα σχήμα. Τα παρακάτω βήματα περιγράφουν τη διαδικασία:

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [line style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linestyle/) του σχήματος.
1. Ορίστε το πλάτος της γραμμής.
1. Ορίστε το [dash style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linedashstyle/) της γραμμής.
1. Ορίστε το χρώμα της γραμμής για το σχήμα.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο παρακάτω κώδικας δείχνει πώς να μορφοποιήσετε ένα ορθογώνιο `AutoShape`:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
Presentation presentation = new Presentation();
try {
    // Λήψη της πρώτης διαφάνειας.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Προσθήκη αυτόματου σχήματος τύπου Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Αφαίρεση του γεμίσματος από το ορθογώνιο σχήμα ώστε να φαίνονται μόνο οι γραμμές του.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // Εφαρμογή μορφοποίησης στις γραμμές του ορθογωνίου.
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // Ορισμός χρώματος για τη γραμμή του ορθογωνίου.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Αποθήκευση του αρχείου PPTX στο δίσκο.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Οι μορφοποιημένες γραμμές στην παρουσίαση](formatted-lines.png)

## **Εφαρμογή Εφέ Σχέδιο σε Γραμμές Σχήματος**

Ένα εφέ σχέδιο κάνει τη γραμμή ενός σχήματος να φαίνεται σχεδιασμένο με το χέρι. Χρησιμοποιήστε [IShape.getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) για να προσπελάσετε τις ρυθμίσεις γραμμής, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/) για να προσπελάσετε τις ρυθμίσεις σχεδίου, και [ISketchFormat.setSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/) για να επιλέξετε μια τιμή από την απαρίθμηση [LineSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/).

Ο παρακάτω κώδικας Java δείχνει πώς να εφαρμόσετε το εφέ [LineSketchType.Curved](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/), να διαβάσετε την ρητά ορισμένη τιμή και να αφαιρέσετε το εφέ με το [LineSketchType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // Πρόσβαση στη μορφοποίηση γραμμής του σχήματος και στη μορφή σχεδίου του.
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

Η τιμή που επιστρέφεται από το [ISketchFormat.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/) αντιπροσωπεύει τη ρύθμιση που έχει ανατεθεί άμεσα στο σχήμα. Εάν η μορφοποίηση της γραμμής μπορεί να κληρονομηθεί από θέμα, κύρια διαφάνεια ή διάταξη διαφάνειας, χρησιμοποιήστε το [ILineFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/), προσπελάστε το [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformateffectivedata/), και διαβάστε το [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformateffectivedata/). Η αποτελεσματική τιμή αντικατοπτρίζει τη μορφοποίηση που εφαρμόζεται πραγματικά μετά την επίλυση της κληρονομιάς:

```java
import com.aspose.slides.*;

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

## **Μορφοποίηση Στυλ Σύνδεσης**

Ακολουθούν οι τρεις επιλογές τύπου σύνδεσης:

* Round
* Miter
* Bevel

Από προεπιλογή, όταν το PowerPoint ενώνει δύο γραμμές σε γωνία (όπως σε γωνία σχήματος), χρησιμοποιεί τη ρύθμιση **Round**. Ωστόσο, εάν σχεδιάζετε ένα σχήμα με έντονες γωνίες, μπορεί να προτιμήσετε την επιλογή **Miter**.

![Το στυλ σύνδεσης στην παρουσίαση](join-style-powerpoint.png)

Ο παρακάτω κώδικας Java δείχνει πώς τρία ορθογώνια (όπως φαίνονται στην παραπάνω εικόνα) δημιουργήθηκαν χρησιμοποιώντας τις ρυθμίσεις σύνδεσης Miter, Bevel και Round:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
Presentation presentation = new Presentation();
try {
    // Λήψη της πρώτης διαφάνειας.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Προσθήκη τριών αυτόματων σχημάτων τύπου Rectangle.
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Ορισμός του χρώματος γεμίσματος για κάθε ορθογώνιο σχήμα.
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // Ορισμός του πλάτους της γραμμής.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // Ορισμός του χρώματος για τη γραμμή κάθε ορθογωνίου.
    shape1.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape3.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Ορισμός του στυλ σύνδεσης.
    shape1.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    shape2.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    shape3.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    // Προσθήκη κειμένου σε κάθε ορθογώνιο.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // Αποθήκευση του αρχείου PPTX στο δίσκο.
    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Γέμισμα Διαβάθμισης**

Στο PowerPoint, το Γέμισμα Διαβάθμισης είναι μια επιλογή μορφοποίησης που επιτρέπει την εφαρμογή ενός συνεχούς μίξης χρωμάτων σε ένα σχήμα. Για παράδειγμα, μπορείτε να εφαρμόσετε δύο ή περισσότερα χρώματα με τρόπο που το ένα εξασθενίζει σταδιακά στο άλλο.

Ακολουθεί πώς να εφαρμόσετε γέμισμα διαβάθμισης σε ένα σχήμα χρησιμοποιώντας το Aspose.Slides:

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) του σχήματος σε `Gradient`.
1. Προσθέστε τα δύο προτιμώμενα χρώματά σας με καθορισμένες θέσεις χρησιμοποιώντας τις μεθόδους `add` της συλλογής διαβάθμισης που εκτίθενται από τη διεπαφή [IGradientFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/).
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο παρακάτω κώδικας Java δείχνει πώς να εφαρμόσετε εφέ γέμισμα διαβάθμισης σε μία έλλειψη:

```java
import com.aspose.slides.*;

// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
Presentation presentation = new Presentation();
try {
    // Λήψη της πρώτης διαφάνειας.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Προσθήκη αυτόματου σχήματος τύπου Ellipse.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Εφαρμογή μορφοποίησης διαβάθμισης στην έλλειψη.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // Ορισμός της κατεύθυνσης της διαβάθμισης.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // Προσθήκη δύο σημείων διαβάθμισης.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // Αποθήκευση του αρχείου PPTX στο δίσκο.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Η έλλειψη με γέμισμα διαβάθμισης](gradient-fill.png)

Εάν μια διαβάθμιση φαίνεται διαφορετική σε εξαγόμενο εικόνα από ό,τι στο PowerPoint, δείτε το [Choose a Gradient Rendering Style](/slides/el/androidjava/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Μπορείτε να επιλέξετε στυλ απόδοσης χωρίς να αλλάξετε το γέμισμα διαβάθμισης που αποθηκεύεται στην παρουσίαση.

## **Γέμισμα Σχεδίου**

Στο PowerPoint, το Γέμισμα Σχεδίου είναι μια επιλογή μορφοποίησης που σας επιτρέπει να εφαρμόσετε ένα σχέδιο με δύο χρώματα — όπως κουκκίδες, ρίγες, διαγώνιες γραμμές ή τετράγωνα — σε ένα σχήμα. Μπορείτε να επιλέξετε προσαρμοσμένα χρώματα για το προσκήνιο και το παρασκήνιο του σχεδίου.

Το Aspose.Slides παρέχει πάνω από 45 προεπιλεγμένα στυλ σχεδίου που μπορείτε να εφαρμόσετε σε σχήματα για να ενισχύσετε την οπτική ελκυστικότητα των παρουσιάσεών σας. Ακόμη και αφού επιλέξετε ένα προεπιλεγμένο σχέδιο, μπορείτε να καθορίσετε ακριβώς τα χρώματα που θα χρησιμοποιηθούν.

Ακολουθεί πώς να εφαρμόσετε γέμισμα σχεδίου σε ένα σχήμα χρησιμοποιώντας το Aspose.Slides:

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) του σχήματος σε `Pattern`.
1. Επιλέξτε ένα στυλ σχεδίου από τις προεπιλεγμένες επιλογές.
1. Ορίστε το [Background Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/patternformat/#getBackColor--) του σχεδίου.
1. Ορίστε το [Foreground Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/patternformat/#getForeColor--) του σχεδίου.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο παρακάτω κώδικας Java δείχνει πώς να εφαρμόσετε γέμισμα σχεδίου σε ένα ορθογώνιο:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
Presentation presentation = new Presentation();
try {
    // Λήψη της πρώτης διαφάνειας.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Προσθήκη αυτόματου σχήματος τύπου Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Ορισμός του τύπου γεμίσματος σε Pattern.
    shape.getFillFormat().setFillType(FillType.Pattern);

    // Ορισμός του στυλ μοτίβου.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // Ορισμός των χρωμάτων φόντου και προσκηνίου του μοτίβου.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // Αποθήκευση του αρχείου PPTX στο δίσκο.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Το ορθογώνιο με γέμισμα σχεδίου](pattern-fill.png)

## **Γέμισμα Εικόνας**

Στο PowerPoint, το Γέμισμα Εικόνας είναι μια επιλογή μορφοποίησης που σας επιτρέπει να ενσωματώσετε μια εικόνα μέσα σε ένα σχήμα — χρησιμοποιώντας ουσιαστικά την εικόνα ως φόντο του σχήματος.

Ακολουθεί πώς να χρησιμοποιήσετε το Aspose.Slides για να εφαρμόσετε γέμισμα εικόνας σε ένα σχήμα:

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) του σχήματος σε `Picture`.
1. Ορίστε τη λειτουργία γέμισμα εικόνας σε `Tile` (ή άλλη προτιμώμενη λειτουργία).
1. Δημιουργήστε ένα αντικείμενο [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) από την εικόνα που θέλετε να χρησιμοποιήσετε.
1. Π passes the image to the `ISlidesPicture.setImage` method.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ας υποθέσουμε ότι έχουμε ένα αρχείο "lotus.png" με την παρακάτω εικόνα:

![Η εικόνα λωτού](lotus.png)

Ο παρακάτω κώδικας Java δείχνει πώς να γεμίσετε ένα σχήμα με την εικόνα:

```java
import com.aspose.slides.*;

// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
Presentation presentation = new Presentation();
try {
    // Λήψη της πρώτης διαφάνειας.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Προσθήκη αυτόματου σχήματος τύπου Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Ορισμός του τύπου γεμίσματος σε Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Ορισμός της λειτουργίας γέμισης εικόνας.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // Φόρτωση εικόνας και προσθήκη της στους πόρους της παρουσίασης.
    IImage image = Images.fromFile("lotus.png");
    IPPImage picture = presentation.getImages().addImage(image);
    image.dispose();

    // Ορισμός της εικόνας.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Αποθήκευση του αρχείου PPTX στο δίσκο.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Το σχήμα με γέμισμα εικόνας](picture-fill.png)

### **Τοποθέτηση Εικόνας ως Υφή**

Εάν θέλετε να ορίσετε μια επαναλαμβανόμενη εικόνα ως υφή και να προσαρμόσετε τη συμπεριφορά της επικάλυψης, μπορείτε να χρησιμοποιήσετε τις ακόλουθες μεθόδους της διεπαφής [IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) και της κλάσης [PictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Ορίζει τη λειτουργία γέμισμα εικόνας — είτε `Tile` είτε `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Καθορίζει την ευθυγράμμιση των πλακιδίων μέσα στο σχήμα.
- [setTileFlip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Ελέγχει εάν το πλακίδιο θα αναστραφεί οριζόντια, κάθετα ή και τα δύο.
- [setTileOffsetX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Ορίζει την οριζόντια μετατόπιση του πλακιδίου (σε σημεία) από το αρχικό σημείο του σχήματος.
- [setTileOffsetY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Ορίζει την κάθετη μετατόπιση του πλακιδίου (σε σημεία) από το αρχικό σημείο του σχήματος.
- [setTileScaleX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Ορίζει την οριζόντια κλίμακα του πλακιδίου ως ποσοστό.
- [setTileScaleY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Ορίζει την κάθετη κλίμακα του πλακιδίου ως ποσοστό.

Ο παρακάτω κώδικας δείχνει πώς να προσθέσετε ένα ορθογώνιο σχήμα με επαναλαμβανόμενο γέμισμα εικόνας και να διαμορφώσετε τις επιλογές πλακιδίων:

```java
import com.aspose.slides.*;

// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
Presentation presentation = new Presentation();
try {
    // Λήψη της πρώτης διαφάνειας.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Προσθήκη αυτόματου σχήματος Rectangle.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Ορισμός του τύπου γεμίσματος του σχήματος σε Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Φόρτωση της εικόνας και προσθήκη της στους πόρους της παρουσίασης.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Ανάθεση της εικόνας στο σχήμα.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Διαμόρφωση της λειτουργίας γέμισης εικόνας και των ιδιοτήτων επικάλυψης.
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    // Αποθήκευση του αρχείου PPTX στο δίσκο.
    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Οι επιλογές πλακιδίων](tile-options.png)

## **Γέμισμα Στερεού Χρώματος**

Στο PowerPoint, το Γέμισμα Στερεού Χρώματος είναι μια επιλογή μορφοποίησης που γεμίζει ένα σχήμα με ένα ενιαίο, ομοιόμορφο χρώμα. Αυτό το απλό χρώμα φόντου εφαρμόζεται χωρίς διαβαθμίσεις, υφές ή σχέδια.

Για να εφαρμόσετε γέμισμα στερεού χρώματος σε ένα σχήμα χρησιμοποιώντας το Aspose.Slides, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) του σχήματος σε `Solid`.
1. Αντιστοιχίστε το προτιμώμενο χρώμα γέμισμα στο σχήμα.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο παρακάτω κώδικας Java δείχνει πώς να εφαρμόσετε γέμισμα στερεού χρώματος σε ένα ορθογώνιο σε διαφάνεια PowerPoint:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
Presentation presentation = new Presentation();
try {
    // Λήψη της πρώτης διαφάνειας.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Προσθήκη αυτόματου σχήματος τύπου Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Ορισμός του τύπου γεμίσματος σε Solid.
    shape.getFillFormat().setFillType(FillType.Solid);

    // Ορισμός του χρώματος γεμίσματος.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // Αποθήκευση του αρχείου PPTX στο δίσκο.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Το σχήμα με γέμισμα στερεού χρώματος](solid-color-fill.png)

## **Ορισμός Διαφάνειας**

Στο PowerPoint, όταν εφαρμόζετε στερεό χρώμα, διαβάθμιση, εικόνα ή γέμισμα υφής σε σχήματα, μπορείτε επίσης να ορίσετε ένα επίπεδο διαφάνειας για να ελέγξετε την αδιαφάνεια του γέμισματος. Μια υψηλότερη τιμή διαφάνειας κάνει το σχήμα πιο διαφανές, επιτρέποντας στο φόντο ή στα υποκείμενα αντικείμενα να είναι εν μέρει ορατά.

Το Aspose.Slides σας επιτρέπει να ορίσετε το επίπεδο διαφάνειας ρυθμίζοντας την τιμή alpha στο χρώμα που χρησιμοποιείται για το γέμισμα. Δείτε πώς:

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) σε `Solid`.
1. Χρησιμοποιήστε το `Color` για να ορίσετε ένα χρώμα με διαφάνεια (το συστατικό `alpha` ελέγχει τη διαφάνεια).
1. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας Java δείχνει πώς να εφαρμόσετε διαφανές χρώμα γέμισμα σε ένα ορθογώνιο:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
Presentation presentation = new Presentation();
try {
    // Λήψη της πρώτης διαφάνειας.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Προσθήκη στερεού ορθογωνίου αυτόματου σχήματος.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Προσθήκη διαφανούς ορθογωνίου αυτόματου σχήματος πάνω από το στερεό σχήμα.
    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 204));

    // Αποθήκευση του αρχείου PPTX στο δίσκο.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Το ημιδιαφανές σχήμα](shape-transparency.png)

## **Περιστροφή Σχημάτων**

Το Aspose.Slides σας επιτρέπει να περιστρέψετε σχήματα σε παρουσιάσεις PowerPoint. Αυτό μπορεί να είναι χρήσιμο όταν τοποθετείτε οπτικά στοιχεία με συγκεκριμένη ευθυγράμμιση ή σχεδιαστικές ανάγκες.

Για να περιστρέψετε ένα σχήμα σε μια διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε την ιδιότητα περιστροφής του σχήματος στην επιθυμητή γωνία.
1. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας Java δείχνει πώς να περιστρέψετε ένα σχήμα κατά 5 μοίρες:

```java
import com.aspose.slides.*;

// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
Presentation presentation = new Presentation();
try {
    // Λήψη της πρώτης διαφάνειας.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Προσθήκη αυτόματου σχήματος τύπου Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Περιστροφή του σχήματος κατά 5 μοίρες.
    shape.setRotation(5);

    // Αποθήκευση του αρχείου PPTX στο δίσκο.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Η περιστροφή του σχήματος](shape-rotation.png)

## **Προσθήκη Εφέ 3Δ Κότσι**

Το Aspose.Slides σας επιτρέπει να εφαρμόσετε εφέ 3Δ κότσι σε σχήματα ρυθμίζοντας τις ιδιότητες του [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/threedformat/).

Για να προσθέσετε εφέ 3Δ κότσι σε ένα σχήμα, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) στη διαφάνεια.
1. Ρυθμίστε το [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/threedformat/) του σχήματος για να ορίσετε τις ρυθμίσεις του κότσι.
1. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας Java δείχνει πώς να εφαρμόσετε εφέ 3Δ κότσι σε ένα σχήμα:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Δημιουργία μιας στιγμής της κλάσης Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Προσθήκη σχήματος στη διαφάνεια.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE);
    shape.getLineFormat().setWidth(2.0);

    // Ορισμός των ιδιοτήτων ThreeDFormat του σχήματος.
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    // Αποθήκευση της παρουσίασης ως αρχείο PPTX.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Το εφέ 3Δ κότσι](3D-bevel-effect.png)

## **Προσθήκη Εφέ 3Δ Περιστροφής**

Το Aspose.Slides σας επιτρέπει να εφαρμόσετε εφέ 3Δ περιστροφής σε σχήματα ρυθμίζοντας τις ιδιότητες του [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/threedformat/).

Για να εφαρμόσετε 3Δ περιστροφή σε ένα σχήμα:

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) στη διαφάνεια.
1. Χρησιμοποιήστε τις μεθόδους [setCameraType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setCameraType-int-) και [setLightType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilightrig/#setLightType-int-) για να ορίσετε την 3Δ περιστροφή.
1. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας Java δείχνει πώς να εφαρμόσετε εφέ 3Δ περιστροφής σε ένα σχήμα:

```java
import com.aspose.slides.*;

// Δημιουργία μιας στιγμής της κλάσης Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    // Αποθήκευση της παρουσίασης ως αρχείο PPTX.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Το εφέ 3Δ περιστροφής](3D-rotation-effect.png)

## **Έλεγχος Ασπρόμαυρης Απόδοσης για Σχήματα**

Η μέθοδος [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) καθορίζει πώς ένα μεμονωμένο σχήμα αποδίδεται όταν μια παρουσίαση προβάλλεται ή επεξεργάζεται σε ασπρόμαυρη λειτουργία. Δεν ενεργοποιεί την ασπρόμαυρη προβολή από μόνη της και δεν αλλάζει το γέμισμα, τη γραμμή ή άλλη μορφοποίηση του σχήματος σε κανονική έγχρωμη λειτουργία.

Χρησιμοποιήστε μια τιμή από την κλάση [BlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/blackwhitemode/) για να επιλέξετε τη ζητούμενη συμπεριφορά. Για παράδειγμα, το `Automatic` αφήνει την εφαρμογή απόδοσης να επιλέξει τη μετατροπή, τα `Gray` και `LightGray` χρησιμοποιούν γκριχρώματα, το `BlackWhite` χρησιμοποιεί μόνο μαύρο και λευκό, τα `Black` και `White` εξαναγκάζουν ένα μόνο χρώμα, το `Color` διατηρεί την κανονική χρωματική απόδοση, και το `Hidden` παραλείπει το σχήμα στην ασπρόμαυρη λειτουργία. Το `NotDefined` σημαίνει ότι δεν έχει οριστεί λειτουργία σε επίπεδο σχήματος.

Ο παρακάτω κώδικας Java δημιουργεί ένα χρωματιστό σχήμα και το εμφανίζει γκρι σε ασπρόμαυρη λειτουργία προβολής:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    // Διατηρήστε το πορτοκαλί γέμισμα σε έγχρωμη λειτουργία, αλλά αποδώστε το σχήμα με γκρι χρωματισμό σε ασπρόμαυρη λειτουργία.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Σε κανονική έγχρωμη λειτουργία, το ορθογώνιο διατηρεί το πορτοκαλί γέμισμα του. Σε ροή εργασίας με ασπρόμαυρη προβολή, χρησιμοποιεί γκρι χρώμα επειδή η λειτουργία του έχει οριστεί σε `Gray`. Αυτό σας επιτρέπει να διατηρήσετε μια πλήρως έγχρωμη διαφάνεια ενώ ορίζετε διαφορετική εμφάνιση για εκτύπωση, προεπισκόπηση ή άλλες ροές εργασίας που σέβονται τις ρυθμίσεις ασπρόμαυρης εμφάνισης της παρουσίασης.

## **Επαναφορά Μορφοποίησης**

Ο παρακάτω κώδικας Java δείχνει πώς να επαναφέρετε τη μορφοποίηση μιας διαφάνειας και να επαναφέρετε τη θέση, το μέγεθος και τη μορφοποίηση όλων των σχημάτων με δεσμευτικά πλαίσια στη [LayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/layoutslide/) στις προεπιλεγμένες ρυθμίσεις τους:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Επαναφορά κάθε σχήματος στη διαφάνεια που έχει θέση κράτησης στη διάταξη.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Επηρεάζει η μορφοποίηση των σχημάτων το τελικό μέγεθος του αρχείου παρουσίασης;**

Μόνο ελαφρώς. Οι ενσωματωμένες εικόνες και τα μέσα καταλαμβάνουν το μεγαλύτερο μέρος του χώρου του αρχείου, ενώ οι παράμετροι σχήματος όπως χρώματα, εφέ και διαβαθμίσεις αποθηκεύονται ως μεταδεδομένα και δεν προσθέτουν σχεδόν καθόλου επιπλέον μέγεθος.

**Πώς μπορώ να εντοπίσω σχήματα σε μια διαφάνεια που έχουν ταυτόσημη μορφοποίηση ώστε να τα ομαδοποιήσω;**

Συγκρίνετε τα βασικά χαρακτηριστικά μορφοποίησης κάθε σχήματος — γέμισμα, γραμμή και ρυθμίσεις εφέ. Εάν όλες οι αντίστοιχες τιμές ταιριάζουν, θεωρήστε τα στυλ ως ταυτόσημα και ομαδοποιήστε λογικά αυτά τα σχήματα, γεγονός που απλοποιεί τη μετέπειτα διαχείριση στυλ.

**Μπορώ να αποθηκεύσω ένα σύνολο προσαρμοσμένων στυλ σχήματος σε ξεχωριστό αρχείο για χρήση σε άλλες παρουσιάσεις;**

Ναι. Αποθηκεύστε δείγμα σχήματος με τα επιθυμητά στυλ σε μια πρότυπη παρουσίαση ή σε αρχείο προτύπου .POTX. Όταν δημιουργείτε μια νέα παρουσίαση, ανοίξτε το πρότυπο, κλωνοποιήστε τα σχήματα που χρειάζεστε και εφαρμόστε εκ νέου τη μορφοποίησή τους όπου απαιτείται.