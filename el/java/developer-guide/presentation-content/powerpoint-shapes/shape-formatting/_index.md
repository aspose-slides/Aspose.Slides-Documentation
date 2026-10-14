---
title: Διαμόρφωση Σχημάτων PowerPoint σε Java
linktitle: Διαμόρφωση Σχημάτων
type: docs
weight: 20
url: /el/java/shape-formatting/
keywords:
- διαμόρφωση σχήματος
- διαμόρφωση γραμμής
- εφέ σκίτσης
- γραμμή σχήματος σκίτσης
- διαμόρφωση στυλ σύνδεσης
- γέμιση διαβάθμισης
- γέμιση μοτίβου
- γέμιση εικόνας
- γέμιση υφής
- γέμιση μονόχρωμη
- διαφάνεια σχήματος
- αποτύπωση σχήματος ασπρόμαυρη
- αποτύπωση σχήματος γκρι κλίμακας
- περιστροφή σχήματος
- 3Δ εφέ λοξότμησης
- 3Δ εφέ περιστροφής
- επαναφορά μορφοποίησης
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Μάθετε πώς να διαμορφώνετε σχήματα PowerPoint σε Java χρησιμοποιώντας το Aspose.Slides—ορίστε στυλ γεμίσματος, γραμμής και εφέ για αρχεία PPT, PPTX και ODP με ακρίβεια και πλήρη έλεγχο."
---
## **Εισαγωγή**

Στο PowerPoint, μπορείτε να προσθέσετε σχήματα σε διαφάνειες. Καθώς τα σχήματα αποτελούνται από γραμμές, μπορείτε να μορφοποιήσετε τις γραμμές τους τροποποιώντας ή εφαρμόζοντας εφέ στα περιγράμματά τους. Επιπλέον, μπορείτε να μορφοποιήσετε τα σχήματα ορίζοντας ρυθμίσεις που ελέγχουν τον τρόπο γεμίσματος του εσωτερικού τους.

![format-shape-powerpoint](format-shape-powerpoint.png)

Το Aspose.Slides for Java παρέχει διεπαφές και μεθόδους που σας επιτρέπουν να μορφοποιήσετε σχήματα χρησιμοποιώντας τις ίδιες επιλογές που διατίθενται στο PowerPoint.

## **Μορφοποίηση Γραμμών**

Με το Aspose.Slides, μπορείτε να καθορίσετε ένα προσαρμοσμένο στυλ γραμμής για ένα σχήμα. Τα παρακάτω βήματα περιγράφουν τη διαδικασία:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με τον δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [line style](https://reference.aspose.com/slides/java/com.aspose.slides/linestyle/) του σχήματος.
1. Ορίστε το πάχος της γραμμής.
1. Ορίστε το [dash style](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/) της γραμμής.
1. Ορίστε το χρώμα γραμμής για το σχήμα.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο παρακάτω κώδικας δείχνει πώς να μορφοποιήσετε ένα επίπεδο `AutoShape`:

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

    // Ορισμός του χρώματος γεμίσματος για το σχήμα Rectangle.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // Εφαρμογή μορφοποίησης στις γραμμές του Rectangle.
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // Ορισμός του χρώματος για τη γραμμή του Rectangle.
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

## **Εφαρμογή Σχέδιο Εφέ στις Γραμμές Σχήματος**

Ένα εφέ σκαρίφησης κάνει μια γραμμή σχήματος να φαίνεται χειρογράφιστη. Χρησιμοποιήστε [IShape.getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) για να αποκτήσετε πρόσβαση στις ρυθμίσεις γραμμής, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/) για τις ρυθμίσεις σκαρίφησης και [ISketchFormat.setSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/) για να επιλέξετε μια τιμή από την απαριθμημένη τιμή [LineSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/).

Ο παρακάτω κώδικας Java δείχνει πώς να εφαρμόσετε το εφέ [LineSketchType.Curved](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/), να διαβάσετε την ρητά ορισμένη τιμή και να αφαιρέσετε το εφέ με το [LineSketchType.None](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/):

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // Πρόσβαση στη μορφοποίηση γραμμής του σχήματος και στη μορφοποίηση σκίτσης.
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // Εφαρμογή εφέ σκίτσης.
    sketchFormat.setSketchType(LineSketchType.Curved);

    // Ανάγνωση του εφέ σκίτσης που έχει ανατεθεί απευθείας στο σχήμα.
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // Αφαίρεση του εφέ σκίτσης.
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

Η τιμή που επιστρέφεται από το [ISketchFormat.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/) αντιπροσωπεύει τη ρύθμιση που έχει ανατεθεί απευθείας στο σχήμα. Εάν η μορφοποίηση της γραμμής μπορεί να κληθεί από ένα θέμα, κύρια διαφάνεια ή διάταξη διαφάνειας, χρησιμοποιήστε το [ILineFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/), αποκτήστε πρόσβαση στο [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformateffectivedata/) και διαβάστε το [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformateffectivedata/). Η αποτελεσματική τιμή αντανακλά τη μορφοποίηση που εφαρμόζεται πραγματικά μετά την επίλυση της κληρονομικότητας:

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

## **Μορφοποίηση Στυλ Σύνδεσης**

Αυτές είναι οι τρεις επιλογές τύπου σύνδεσης:

* Στρογγυλό
* Κόψιμο
* Πλαγιοκόψιμο

Από προεπιλογή, όταν το PowerPoint συνδέει δύο γραμμές σε γωνία (όπως σε μια γωνία σχήματος), χρησιμοποιεί τη ρύθμιση **Στρογγυλό**. Ωστόσο, εάν σχεδιάζετε ένα σχήμα με οξύ γωνίες, ίσως προτιμήσετε την επιλογή **Κόψιμο**.

![Το στυλ σύνδεσης στην παρουσίαση](join-style-powerpoint.png)

Ο παρακάτω κώδικας Java δείχνει πώς δημιουργήθηκαν τρία ορθογώνια (όπως φαίνονται στην παραπάνω εικόνα) χρησιμοποιώντας τις ρυθμίσεις τύπου σύνδεσης Μπλέι, Κόψιμο και Στρογγυλό:

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

    // Ορισμός του χρώματος γεμίσματος για κάθε σχήμα Rectangle.
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // Ορισμό του πλάτους της γραμμής.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // Ορισμός του χρώματος για τη γραμμή κάθε Rectangle.
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

    // Προσθήκη κειμένου σε κάθε Rectangle.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // Αποθήκευση του αρχείου PPTX στον δίσκο.
    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Γέμιση Διαβάθμισης**

Στο PowerPoint, η Γέμιση Διαβάθμισης είναι μια επιλογή μορφοποίησης που σας επιτρέπει να εφαρμόσετε ένα συνεχές μίγμα χρωμάτων σε ένα σχήμα. Για παράδειγμα, μπορείτε να εφαρμόσετε δύο ή περισσότερα χρώματα έτσι ώστε το ένα να εξασφυλίζει σταδιακά στο άλλο.

Ακολουθούν τα βήματα για την εφαρμογή γέμισης διαβάθμισης σε σχήμα με χρήση Aspose.Slides:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με τον δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) του σχήματος σε `Gradient`.
1. Προσθέστε τα δύο προτιμώμενα χρώματά σας με καθορισμένες θέσεις χρησιμοποιώντας τις μεθόδους `add` της συλλογής διαβάθμισης που εκτίθεται από τη διεπαφή [IGradientFormat](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/).
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο παρακάτω κώδικας Java δείχνει πώς να εφαρμόσετε το εφέ γέμισης διαβάθμισης σε μια έλλειψη:

```java
import com.aspose.slides.*;

// Δημιουργία του αντικειμένου Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
Presentation presentation = new Presentation();
try {
    // Λήψη της πρώτης διαφάνειας.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Προσθήκη αυτόματου σχήματος τύπου Ellipse.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Εφαρμογή μορφοποίησης διαβάθμισης στο Ellipse.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // Ορισμός της κατεύθυνσης της διαβάθμισης.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // Προσθήκη δύο σημείων διαβάθμισης.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // Αποθήκευση του αρχείου PPTX στον δίσκο.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Η έλλειψη με γέμιση διαβάθμισης](gradient-fill.png)

Εάν μια διαβάθμιση φαίνεται διαφορετική σε μια εξαγόμενη εικόνα από ό,τι στο PowerPoint, δείτε το [Choose a Gradient Rendering Style](/slides/el/java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Μπορείτε να επιλέξετε στυλ απόδοσης χωρίς να αλλάξετε τη γέμιση διαβάθμισης που αποθηκεύεται στην παρουσίαση.

## **Γέμιση Σχεδίου**

Στο PowerPoint, η Γέμιση Σχεδίου είναι μια επιλογή μορφοποίησης που σας επιτρέπει να εφαρμόσετε ένα σχεδιάγραμμα δίχρωμου – όπως κουκκίδες, λωρίδες, διαγώνιες λωρίδες ή σκαλίσματα – σε ένα σχήμα. Μπορείτε να επιλέξετε προσαρμοσμένα χρώματα για το προσκήνιο και το παρασκήνιο του σχεδίου.

Το Aspose.Slides παρέχει πάνω από 45 προεγκατεστημένα στυλ σχεδίου που μπορείτε να εφαρμόσετε στα σχήματα για να ενισχύσετε την οπτική ελκυστικότητα των παρουσιάσεών σας. Ακόμη και αφού επιλέξετε ένα προεγκατεστημένο σχέδιο, μπορείτε να καθορίσετε ακριβώς τα χρώματα που θα χρησιμοποιήσει.

Ακολουθούν τα βήματα για την εφαρμογή γέμισης σχεδίου σε σχήμα με χρήση Aspose.Slides:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με τον δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) του σχήματος σε `Pattern`.
1. Επιλέξτε ένα στυλ σχεδίου από τις προεγκατεστημένες επιλογές.
1. Ορίστε το [Background Color](https://reference.aspose.com/slides/java/com.aspose.slides/patternformat/#getBackColor--) του σχεδίου.
1. Ορίστε το [Foreground Color](https://reference.aspose.com/slides/java/com.aspose.slides/patternformat/#getForeColor--) του σχεδίου.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο παρακάτω κώδικας Java δείχνει πώς να εφαρμόσετε γέμιση σχεδίου σε ένα ορθογώνιο:

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

    // Ορισμός των χρωμάτων παρασκηνίου και προσκηνίου του μοτίβου.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // Αποθήκευση του αρχείου PPTX στον δίσκο.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Το ορθογώνιο με γέμιση σχεδίου](pattern-fill.png)

## **Γέμιση Εικόνας**

Στο PowerPoint, η Γέμιση Εικόνας είναι μια επιλογή μορφοποίησης που σας επιτρέπει να εισάγετε μια εικόνα μέσα σε ένα σχήμα – χρησιμοποιώντας ουσιαστικά την εικόνα ως φόντο του σχήματος.

Ακολουθούν τα βήματα για τη χρήση Aspose.Slides ώστε να εφαρμόσετε γέμιση εικόνας σε σχήμα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με τον δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) του σχήματος σε `Picture`.
1. Ορίστε τη λειτουργία γέμισης εικόνας σε `Tile` (ή άλλη προτιμώμενη λειτουργία).
1. Δημιουργήστε ένα αντικείμενο [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) από την εικόνα που θέλετε να χρησιμοποιήσετε.
1. Περνάτε την εικόνα στη μέθοδο `ISlidesPicture.setImage`.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ας υποθέσουμε ότι έχουμε το αρχείο «lotus.png» με την ακόλουθη εικόνα:

![Η εικόνα lotus](lotus.png)

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

    // Ορισμός της λειτουργίας γεμίσματος εικόνας.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // Φόρτωση εικόνας και προσθήκη της στους πόρους της παρουσίασης.
    IImage image = Images.fromFile("lotus.png");
    IPPImage picture = presentation.getImages().addImage(image);
    image.dispose();

    // Ορισμός της εικόνας.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Αποθήκευση του αρχείου PPTX στον δίσκο.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Το σχήμα με γέμιση εικόνας](picture-fill.png)

### **Πλακίδια Εικόνας ως Υφή**

Εάν θέλετε να ορίσετε μια πλακιδική εικόνα ως υφή και να προσαρμόσετε τη συμπεριφορά του πλακίδωσης, μπορείτε να χρησιμοποιήσετε τις παρακάτω μεθόδους της διεπαφής [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) και της κλάσης [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Ορίζει τη λειτουργία γέμισης εικόνας—είτε `Tile` είτε `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Καθορίζει την ευθυγράμμιση των πλακιδίων μέσα στο σχήμα.
- [setTileFlip](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Ελέγχει αν το πλακίδιο αναστρέφεται οριζόντια, κάθετα ή και τα δύο.
- [setTileOffsetX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Ορίζει τη οριζόντια μετατόπιση του πλακιδίου (σε points) από το σημείο προέλευσης του σχήματος.
- [setTileOffsetY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Ορίζει τη λvertical μετατόπιση του πλακιδίου (σε points) από το σημείο προέλευσης του σχήματος.
- [setTileScaleX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Καθορίζει την οριζόντια κλίμακα του πλακιδίου ως ποσοστό.
- [setTileScaleY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Καθορίζει την κάθετη κλίμακα του πλακιδίου ως ποσοστό.

Ο παρακάτω κώδικας δείχνει πώς να προσθέσετε ένα ορθογώνιο σχήμα με πλακιδική γέμιση εικόνας και να ρυθμίσετε τις επιλογές πλακιδίων:

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

    // Διαμόρφωση της λειτουργίας γεμίσματος εικόνας και των ιδιοτήτων πλακιδώματος.
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    // Αποθήκευση του αρχείου PPTX στον δίσκο.
    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Οι επιλογές πλακιδίων](tile-options.png)

## **Γέμιση Σε Μονόχρωμα**

Στο PowerPoint, η Γέμιση Σε Μονόχρωμα είναι μια επιλογή μορφοποίησης που γεμίζει ένα σχήμα με ένα ενιαίο, ομοιόμορφο χρώμα. Αυτό το απλό χρώμα φόντου εφαρμόζεται χωρίς διαβαθμίσεις, υφές ή σχέδια.

Για να εφαρμόσετε γέμιση σε μονόχρωμα σε σχήμα με χρήση Aspose.Slides, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με τον δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) του σχήματος σε `Solid`.
1. Εκχωρήστε το προτιμώμενο χρώμα γεμίσματος στο σχήμα.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο παρακάτω κώδικας Java δείχνει πώς να εφαρμόσετε γέμιση σε μονόχρωμα σε ένα ορθογώνιο σε διαφάνεια PowerPoint:

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

    // Αποθήκευση του αρχείου PPTX στον δίσκο.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Το σχήμα με μονόχρωμη γέμιση](solid-color-fill.png)

## **Ορισμός Διαφάνειας**

Στο PowerPoint, όταν εφαρμόζετε ένα μονόχρωμο, διαβαθμισμένο, εικόνα ή υφή γέμισμα σε σχήματα, μπορείτε επίσης να ορίσετε ένα επίπεδο διαφάνειας για να ελέγξετε την αδιαφάνεια του γεμίσματος. Μια υψηλότερη τιμή διαφάνειας κάνει το σχήμα πιο διαφανές, επιτρέποντας στο φόντο ή στα υποκείμενα αντικείμενα να είναι μερικώς ορατά.

Το Aspose.Slides σάς επιτρέπει να ορίσετε την τιμή διαφάνειας ρυθμίζοντας την τιμή alpha στο χρώμα που χρησιμοποιείται για το γέμισμα. Ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με τον δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) σε `Solid`.
1. Χρησιμοποιήστε `Color` για να ορίσετε ένα χρώμα με διαφάνεια (το στοιχείο `alpha` ελέγχει τη διαφάνεια).
1. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας Java δείχνει πώς να εφαρμόσετε χρώμα γεμίσματος με διαφάνεια σε ένα ορθογώνιο:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
Presentation presentation = new Presentation();
try {
    // Λήψη της πρώτης διαφάνειας.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Προσθήκη αυτόματου σχήματος ορθογωνίου με συμπαγές γέμισμα.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Προσθήκη διαφανούς αυτόματου σχήματος ορθογωνίου πάνω από το συμπαγές σχήμα.
    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 204));

    // Αποθήκευση του αρχείου PPTX στον δίσκο.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Το διαφανές σχήμα](shape-transparency.png)

## **Περιστροφή Σχημάτων**

Το Aspose.Slides σας επιτρέπει να περιστρέφετε σχήματα σε παρουσιάσεις PowerPoint. Αυτό μπορεί να είναι χρήσιμο όταν τοποθετείτε οπτικά στοιχεία με συγκεκριμένη ευθυγράμμιση ή απαιτήσεις σχεδίασης.

Για να περιστρέψετε ένα σχήμα σε μια διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με τον δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) στη διαφάνεια.
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

    // Αποθήκευση του αρχείου PPTX στον δίσκο.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Η περιστροφή του σχήματος](shape-rotation.png)

## **Προσθήκη 3Δ Εφέ Λοξότμησης**

Το Aspose.Slides επιτρέπει την εφαρμογή 3Δ εφέ λοξότμησης σε σχήματα ρυθμίζοντας τις ιδιότητες του [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/).

Για να προσθέσετε 3Δ εφέ λοξότμησης σε ένα σχήμα, ακολουθήστε τα βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με τον δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) στη διαφάνεια.
1. Ρυθμίστε το [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/) του σχήματος για να ορίσετε τις ρυθμίσεις λοξότμησης.
1. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας Java δείχνει πώς να εφαρμόσετε 3Δ εφέ λοξότμησης σε ένα σχήμα:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Δημιουργία ενός αντικειμένου της κλάσης Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Προσθήκη ενός σχήματος στη διαφάνεια.
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

![Το εφέ 3Δ λοξότμησης](3D-bevel-effect.png)

## **Προσθήκη 3Δ Εφέ Περιστροφής**

Το Aspose.Slides επιτρέπει την εφαρμογή 3Δ εφέ περιστροφής σε σχήματα ρυθμίζοντας τις ιδιότητες του [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/).

Για να εφαρμόσετε 3Δ περιστροφή σε ένα σχήμα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με τον δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) στη διαφάνεια.
1. Χρησιμοποιήστε τις μεθόδους [setCameraType](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setCameraType-int-) και [setLightType](https://reference.aspose.com/slides/java/com.aspose.slides/ilightrig/#setLightType-int-) για να ορίσετε την 3Δ περιστροφή.
1. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας Java δείχνει πώς να εφαρμόσετε 3Δ εφέ περιστροφής σε ένα σχήμα:

```java
import com.aspose.slides.*;

// Δημιουργία ενός αντικειμένου της κλάσης Presentation.
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

Η μέθοδος [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) ορίζει πώς ένα ατομικό σχήμα θα αποδοθεί όταν μια παρουσίαση προβάλλεται ή επεξεργάζεται σε ασπρόμαυρη λειτουργία. Δεν ενεργοποιεί την ασπρόμαυρη απεικόνιση από μόνη της και δεν αλλάζει το γέμισμα, τη γραμμή ή άλλες μορφοποιήσεις του σχήματος σε κανονική χρωματική λειτουργία.

Χρησιμοποιήστε μια τιμή από την κλάση [BlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/blackwhitemode/) για να επιλέξετε τη συμπεριφορά που επιθυμείτε. Για παράδειγμα, το `Automatic` αφήνει την εφαρμογή απόδοσης να επιλέξει τη μετατροπή, τα `Gray` και `LightGray` χρησιμοποιούν γκρι χρωματισμό, το `BlackWhite` χρησιμοποιεί μόνο μαύρο και λευκό, τα `Black` και `White` εξαναγκάζουν ένα ενιαίο χρώμα, το `Color` διατηρεί το κανονικό χρώμα, και το `Hidden` αποκρύπτει το σχήμα σε ασπρόμαυρη λειτουργία. Το `NotDefined` σημαίνει ότι δεν έχει οριστεί λειτουργία σε επίπεδο σχήματος.

Ο παρακάτω κώδικας Java δημιουργεί ένα χρωματιστό σχήμα και το εμφανίζει γκρι σε ασπρόμαυρη λειτουργία εμφάνισης:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    // Διατηρήστε το πορτοκαλί γέμισμα σε χρωματική λειτουργία, αλλά αποδώστε το σχήμα με γκρι χρωματισμό σε ασπρόμαυρη λειτουργία.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Σε κανονική χρωματική λειτουργία, το ορθογώνιο διατηρεί το πορτοκαλί γέμισμα του. Σε ροή εργασίας ασπρόμαυρης προβολής, χρησιμοποιεί γκρι χρωματισμό επειδή η λειτουργία του έχει οριστεί σε `Gray`. Αυτό σας επιτρέπει να διατηρείτε μια πλήρη‑χρωμη διαφάνεια ενώ ορίζετε διαφορετική εμφάνιση για εκτύπωση, προεπισκόπηση ή άλλες ροές εργασίας που σέβονται τις ρυθμίσεις ασπρόμαυρης προβολής της παρουσίασης.

## **Επαναφορά Μορφοποίησης**

Ο παρακάτω κώδικας Java δείχνει πώς να επαναφέρετε τη μορφοποίηση μιας διαφάνειας και να επαναφέρετε τη θέση, το μέγεθος και τη μορφοποίηση όλων των σχημάτων με σύμβολα στη [LayoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/layoutslide/) στις προεπιλεγμένες ρυθμίσεις τους:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Επαναφορά κάθε σχήματος στη διαφάνεια που έχει σύμβολο κράτησης θέσης στη διάταξη.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Η μορφοποίηση των σχημάτων επηρεάζει το τελικό μέγεθος του αρχείου παρουσίασης;**

Μόνο ελάχιστα. Οι ενσωματωμένες εικόνες και τα μέσα καταλαμβάνουν το μεγαλύτερο μέρος του χώρου του αρχείου, ενώ οι παράμετροι σχήματος όπως χρώματα, εφέ και διαβαθμίσεις αποθηκεύονται ως μεταδεδομένα και δεν προσθέτουν σχεδόν κανένα πρόσθετο μέγεθος.

**Πώς μπορώ να εντοπίσω σχήματα σε μια διαφάνεια που έχουν την ίδια μορφοποίηση ώστε να τα ομαδοποιήσω;**

Συγκρίνετε τις κύριες ιδιότητες μορφοποίησης κάθε σχήματος—γέμιση, γραμμή και ρυθμίσεις εφέ. Εάν όλες οι αντίστοιχες τιμές ταιριάζουν, θεωρήστε ότι τα στυλ είναι πανομοιότυπα και ομαδοποιήστε λογικά αυτά τα σχήματα, κάτι που απλοποιεί τη μετέπειτα διαχείριση στυλ.

**Μπορώ να αποθηκεύσω ένα σύνολο προσαρμοσμένων στυλ σχημάτων σε ξεχωριστό αρχείο για επαναχρησιμοποίηση σε άλλες παρουσιάσεις;**

Ναι. Αποθηκεύστε δείγματα σχημάτων με τα επιθυμητά στυλ σε μια προτυπική παρουσίαση ή σε αρχείο προτύπου .POTX. Όταν δημιουργείτε μια νέα παρουσίαση, ανοίξτε το πρότυπο, κλωνοποιήστε τα σχήματα που χρειάζεστε και εφαρμόστε ξανά τη μορφοποίησή τους όπου απαιτείται.