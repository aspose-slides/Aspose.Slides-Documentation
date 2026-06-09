---
title: Διαχείριση Σχημάτων Παρουσίασης σε Android
linktitle: Διαχείριση Σχημάτων
type: docs
weight: 40
url: /el/androidjava/shape-manipulations/
keywords:
- σχήμα PowerPoint
- σχήμα παρουσίασης
- σχήμα σε διαφάνεια
- εύρεση σχήματος
- κλωνοποίηση σχήματος
- αφαίρεση σχήματος
- απόκρυψη σχήματος
- αλλαγή σειράς σχήματος
- λήψη Interop ID σχήματος
- εναλλακτικό κείμενο σχήματος
- μορφές διάταξης σχήματος
- σχήμα ως SVG
- σχήμα σε SVG
- ευθυγράμμιση σχήματος
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Μάθετε να δημιουργείτε, να επεξεργάζεστε και να βελτιστοποιείτε σχήματα στο Aspose.Slides για Android μέσω Java και να παραδίδετε παρουσιάσεις PowerPoint υψηλής απόδοσης."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργάζεστε με σχήματα σε παρουσιάσεις χρησιμοποιώντας το Aspose.Slides. Δείχνει πώς να εντοπίσετε ένα σχήμα σε μια διαφάνεια, να το κλωνοποιήσετε, να το αφαιρέσετε, να το κρύψετε, να αλλάξετε τη σειρά του, να λάβετε το Interop shape ID του και να ορίσετε εναλλακτικό κείμενο για ταυτοποίηση και περαιτέρω επεξεργασία.

Καλύπτει επίσης πώς να προσπελάσετε μορφές διάταξης για σχήματα, να αποδώσετε ένα σχήμα ως SVG, να ευθυγραμμίσετε σχήματα στην διαφάνεια και να χρησιμοποιήσετε ιδιότητες flip για οριζόντια και κατακόρυφη κατοπτρισμό. Επιπλέον, το άρθρο περιλαμβάνει μια σύντομη ενότητα FAQ σχετικά με συνδυασμό σχημάτων, σειρά στοίβασης και κλείδωμα σχημάτων.

## **Εντοπισμός σχήματος σε διαφάνεια**
Αυτό το θέμα περιγράφει μια απλή τεχνική που διευκολύνει τους προγραμματιστές να εντοπίζουν ένα συγκεκριμένο σχήμα σε μία διαφάνεια χωρίς να χρησιμοποιούν το εσωτερικό του Id. Είναι σημαντικό να γνωρίζετε ότι τα αρχεία παρουσίασης PowerPoint δεν έχουν τρόπο να ταυτοποιούν σχήματα σε μια διαφάνεια εκτός από ένα εσωτερικό μοναδικό Id. Φαίνεται δύσκολο για τους προγραμματιστές να βρουν σχήμα χρησιμοποιώντας το εσωτερικό μοναδικό Id. Όλα τα σχήματα που προστίθενται στις διαφάνειες έχουν κάποιο Alt Text. Προτείνουμε στους προγραμματιστές να χρησιμοποιούν εναλλακτικό κείμενο για την εύρεση συγκεκριμένου σχήματος. Μπορείτε να χρησιμοποιήσετε το MS PowerPoint για να ορίσετε το εναλλακτικό κείμενο για αντικείμενα που σκοπεύετε να αλλάξετε στο μέλλον.

Αφού ορίσετε το εναλλακτικό κείμενο οποιουδήποτε επιθυμητού σχήματος, μπορείτε στη συνέχεια να ανοίξετε την παρουσίαση χρησιμοποιώντας το Aspose.Slides for Android via Java και να επαναλάβετε όλα τα σχήματα που προστέθηκαν σε μια διαφάνεια. Σε κάθε επανάληψη, ελέγχετε το εναλλακτικό κείμενο του σχήματος και το σχήμα με το αντίστοιχο εναλλακτικό κείμενο θα είναι το σχήμα που ζητάτε. Για να δείξουμε αυτήν την τεχνική καλύτερα, δημιουργήσαμε τη μέθοδο [findShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-) που επιτελεί το κόλπο του εντοπισμού συγκεκριμένου σχήματος σε μια διαφάνεια και επιστρέφει απλώς εκείνο το σχήμα.

```java
// Δημιουργήστε μια κλάση Presentation που αντιπροσωπεύει το αρχείο παρουσίασης
Presentation pres = new Presentation("FindingShapeInSlide.pptx");
try {

    ISlide slide = pres.getSlides().get_Item(0);
    // Εναλλακτικό κείμενο του σχήματος που πρέπει να βρεθεί
    IShape shape = findShape(slide, "Shape1");
    if (shape != null)
    {
        System.out.println("Shape Name: " + shape.getName());
    }
} finally {
    if (pres != null) pres.dispose();
}
```
```java
// Υλοποίηση μεθόδου για εύρεση σχήματος σε διαφάνεια χρησιμοποιώντας το εναλλακτικό κείμενο
public static IShape findShape(ISlide slide, String alttext)
{
    // Επανάληψη σε όλα τα σχήματα μέσα στη διαφάνεια
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        // Εάν το εναλλακτικό κείμενο της διαφάνειας ταιριάζει με το απαιτούμενο τότε
        // Επιστροφή του σχήματος
        if (slide.getShapes().get_Item(i).getAlternativeText().compareTo(alttext) == 0)
            return slide.getShapes().get_Item(i);
    }
    return null;
}
```

## **Κλωνοποίηση σχήματος**
Για να κλωνοποιήσετε ένα σχήμα σε μια διαφάνεια χρησιμοποιώντας το Aspose.Slides for Android via Java:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
1. Αποκτήστε την αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
1. Πρόσβαση στη συλλογή σχημάτων της πηγαίας διαφάνειας.
1. Προσθήκη νέας διαφάνειας στην παρουσίαση.
1. Κλονοποίηση σχημάτων από τη συλλογή σχημάτων της πηγαίας διαφάνειας στη νέα διαφάνεια.
1. Αποθήκευση της τροποποιημένης παρουσίασης ως αρχείο PPTX.

Το παρακάτω παράδειγμα προσθέτει ένα ομαδικό σχήμα σε μια διαφάνεια.

```java
// Δημιουργία αντικειμένου κλάσης Presentation
Presentation pres = new Presentation("Source Frame.pptx");
try {
    IShapeCollection sourceShapes = pres.getSlides().get_Item(0).getShapes();
    ILayoutSlide blankLayout = pres.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank);
    ISlide destSlide = pres.getSlides().addEmptySlide(blankLayout);
    IShapeCollection destShapes = destSlide.getShapes();
    destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());
    destShapes.addClone(sourceShapes.get_Item(2));
    destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);

    // Αποθήκευση του αρχείου PPTX στο δίσκο
    pres.save("CloneShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Αφαίρεση σχήματος**
Το Aspose.Slides for Android via Java επιτρέπει στους προγραμματιστές να αφαιρούν οποιοδήποτε σχήμα. Για να αφαιρέσετε το σχήμα από μια διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
1. Πρόσβαση στην πρώτη διαφάνεια.
1. Εντοπίστε το σχήμα με συγκεκριμένο AlternativeText.
1. Αφαιρέστε το σχήμα.
1. Αποθηκεύστε το αρχείο στο δίσκο.

```java
// Δημιουργία αντικειμένου Presentation
Presentation pres = new Presentation();
try {
    // Λήψη της πρώτης διαφάνειας
    ISlide sld = pres.getSlides().get_Item(0);

    // Προσθήκη αυτόματου σχήματος τύπου ορθογωνίου
    sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);

    String altText = "User Defined";
    int iCount = sld.getShapes().size();
    for (int i = 0; i < iCount; i++)
    {
        AutoShape ashp = (AutoShape)sld.getShapes().get_Item(0);
        if (alttext.equals(ashp.getAlternativeText()))
        {
            sld.getShapes().remove(ashp);
        }
    }

    // Αποθήκευση της παρουσίασης στο δίσκο
    pres.save("RemoveShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Απόκρυψη σχήματος**
Το Aspose.Slides for Android via Java επιτρέπει στους προγραμματιστές να κρύβουν οποιοδήποτε σχήμα. Για να κρύψετε το σχήμα από μια διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
1. Πρόσβαση στην πρώτη διαφάνεια.
1. Εντοπίστε το σχήμα με συγκεκριμένο AlternativeText.
1. Κρύψτε το σχήμα.
1. Αποθηκεύστε το αρχείο στο δίσκο.

```java
// Δημιουργία κλάσης Presentation που αντιπροσωπεύει το PPTX
Presentation pres = new Presentation();
try {
    // Λήψη της πρώτης διαφάνειας
    ISlide sld = pres.getSlides().get_Item(0);

    // Προσθήκη αυτόματου σχήματος τύπου ορθογωνίου
    sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);

    String alttext = "User Defined";
    int iCount = sld.getShapes().size();
    for (int i = 0; i < iCount; i++)
    {
        AutoShape ashp = (AutoShape)sld.getShapes().get_Item(i);
        if (alttext.equals(ashp.getAlternativeText()))
        {
            ashp.setHidden(true);
        }
    }

    // Αποθήκευση της παρουσίασης στο δίσκο
    pres.save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Αλλαγή σειράς σχήματος**
Το Aspose.Slides for Android via Java επιτρέπει στους προγραμματιστές να αλλάζουν τη σειρά των σχημάτων. Η αλλαγή σειράς καθορίζει ποιο σχήμα είναι στο προσκήνιο ή ποιο βρίσκεται στο φόντο. Για να αλλάξετε τη σειρά σχήματος σε μια διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
1. Πρόσβαση στην πρώτη διαφάνεια.
1. Προσθήκη ενός σχήματος.
1. Προσθήκη κειμένου στο πλαίσιο κειμένου του σχήματος.
1. Προσθήκη άλλου σχήματος με τις ίδιες συντεταγμένες.
1. Αλλαγή σειράς των σχημάτων.
1. Αποθηκεύστε το αρχείο στο δίσκο.

```java
Presentation pres = new Presentation("ChangeShapeOrder.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape shp3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 365, 400, 150);
    shp3.getFillFormat().setFillType(FillType.NoFill);
    shp3.addTextFrame(" ");

    IParagraph para = shp3.getTextFrame().getParagraphs().get_Item(0);
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("Watermark Text Watermark Text Watermark Text");

    shp3 = slide.getShapes().addAutoShape(ShapeType.Triangle, 200, 365, 400, 150);

    slide.getShapes().reorder(2, shp3);

    pres.save("Reshape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Λήψη του Interop Shape ID**
Το Aspose.Slides for Android via Java επιτρέπει στους προγραμματιστές να λαμβάνουν ένα μοναδικό αναγνωριστικό σχήματος σε επίπεδο διαφάνειας, σε αντίθεση με τη μέθοδο [getUniqueId](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IShape#getUniqueId--) η οποία παρέχει μοναδικό αναγνωριστικό σε επίπεδο παρουσίασης. Η μέθοδος [getOfficeInteropShapeId](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IShape#getOfficeInteropShapeId--) προστέθηκε στις διεπαφές [IShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IShape) και στην κλάση [Shape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Shape). Η τιμή που επιστρέφει η μέθοδος [getOfficeInteropShapeId](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IShape#getOfficeInteropShapeId--) αντιστοιχεί στην τιμή του Id του αντικειμένου Microsoft.Office.Interop.PowerPoint.Shape. Παρακάτω δίνεται ένα δείγμα κώδικα.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Λήψη μοναδικού αναγνωριστικού σχήματος σε επίπεδο διαφάνειας
    long officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();

} finally {
    if (pres != null) pres.dispose();
}
```

## **Ορισμός εναλλακτικού κειμένου για σχήμα**
Το Aspose.Slides for Android via Java επιτρέπει στους προγραμματιστές να ορίζουν AlternateText για οποιοδήποτε σχήμα.
Τα σχήματα σε μια παρουσίαση μπορούν να διακριθούν με τη μέθοδο [AlternativeText](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) ή το [Shape Name](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IShape#setName-java.lang.String-).
Οι μέθοδοι [setAlternativeText](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) και [getAlternativeText](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IShape#getAlternativeText--) μπορούν να διαβαστούν ή να οριστούν χρησιμοποιώντας το Aspose.Slides καθώς και το Microsoft PowerPoint.
Χρησιμοποιώντας αυτή τη μέθοδο, μπορείτε να ετικετοποιήσετε ένα σχήμα και να εκτελέσετε διάφορες λειτουργίες όπως Αφαίρεση σχήματος, Απόκρυψη σχήματος ή Επαναδιάταξη σχημάτων στην διαφάνεια.
Για να ορίσετε το AlternateText ενός σχήματος, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
1. Πρόσβαση στην πρώτη διαφάνεια.
1. Προσθέστε οποιοδήποτε σχήμα στη διαφάνεια.
1. Εκτελέστε κάποια εργασία με το νεοσυνεταγμένο σχήμα.
1. Περιηγηθείτε στα σχήματα για να βρείτε το σχήμα.
1. Ορίστε το AlternativeText.
1. Αποθηκεύστε το αρχείο στο δίσκο.

```java
// Δημιουργία κλάσης Presentation που αντιπροσωπεύει το PPTX
Presentation pres = new Presentation();
try {
    // Λήψη της πρώτης διαφάνειας
    ISlide sld = pres.getSlides().get_Item(0);

    // Πρόσθεση αυτόματου σχήματος τύπου ορθογωνίου
    IShape shp1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    IShape shp2 = sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);
    shp2.getFillFormat().setFillType(FillType.Solid);
    shp2.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        AutoShape shape = (AutoShape) sld.getShapes().get_Item(i);
        if (shape != null)
        {
            shape.setAlternativeText("User Defined");
        }
    }

    // Αποθήκευση της παρουσίασης στο δίσκο
    pres.save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Πρόσβαση σε μορφές διάταξης για σχήμα**
Το Aspose.Slides for Android via Java παρέχει ένα απλό API για πρόσβαση σε μορφές διάταξης ενός σχήματος. Αυτό το άρθρο δείχνει πώς μπορείτε να προσπελάσετε τις μορφές διάταξης.

Παρακάτω δίνεται δείγμα κώδικα.

```java
Presentation pres = new Presentation("pres.pptx");
try {
    for (ILayoutSlide layoutSlide : pres.getLayoutSlides())
    {
        for (IShape shape : layoutSlide.getShapes())
        {
            IFillFormat fillFormats = shape.getFillFormat();
            ILineFormat lineFormats = shape.getLineFormat();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Απόδοση σχήματος ως SVG**
Τώρα το Aspose.Slides for Android via Java υποστηρίζει την απόδοση ενός σχήματος ως SVG. Η μέθοδος [writeAsSvg](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IShape#writeAsSvg-java.io.OutputStream-) (και η υπερφόρμα της) προστέθηκε στην κλάση [Shape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Shape) και στη διεπαφή [IShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IShape). Αυτή η μέθοδος επιτρέπει την αποθήκευση του περιεχομένου του σχήματος ως αρχείο SVG. Το παρακάτω απόσπασμα κώδικα δείχνει πώς να εξάγετε το σχήμα μιας διαφάνειας σε αρχείο SVG.

```java
Presentation pres = new Presentation("TestExportShapeToSvg.pptx");
try {
    FileOutputStream stream = new FileOutputStream("SingleShape.svg");
    try {
        pres.getSlides().get_Item(0).getShapes().get_Item(0).writeAsSvg(stream);
    } finally {
        if (stream != null) stream.close();
    }
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ευθυγράμμιση σχήματος**
Το Aspose.Slides επιτρέπει την ευθυγράμμιση σχημάτων είτε σε σχέση με τα περιθώρια της διαφάνειας είτε μεταξύ τους. Για αυτό το σκοπό, έχει προστεθεί η υπερφορτωμένη μέθοδος [SlidesUtil.alignShape()](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/SlideUtil#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-). Η απαρίθμηση [ShapesAlignmentType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ShapesAlignmentType) ορίζει τις δυνατότητες ευθυγράμμισης.

**Παράδειγμα 1**

Ο παρακάτω κώδικας ευθυγραμμίζει τα σχήματα με δείκτες 1,2 και 4 κατά το επάνω όριο της διαφάνειας.

```java
Presentation pres = new Presentation("example.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IShape shape1 = slide.getShapes().get_Item(1);
    IShape shape2 = slide.getShapes().get_Item(2);
    IShape shape3 = slide.getShapes().get_Item(4);
    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, true, pres.getSlides().get_Item(0), new int[]
    {
        slide.getShapes().indexOf(shape1),
        slide.getShapes().indexOf(shape2),
        slide.getShapes().indexOf(shape3)
    });
} finally {
    if (pres != null) pres.dispose();
}
}
```

**Παράδειγμα 2**

Το παρακάτω παράδειγμα δείχνει πώς να ευθυγραμμίσετε ολόκληρη τη συλλογή σχημάτων σε σχέση με το σχήμα που βρίσκεται στο πολύ κάτω άκρο της συλλογής.

```java
Presentation pres = new Presentation("example.pptx");
try {
    SlideUtil.alignShapes(ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ιδιότητες Flip**

Στο Aspose.Slides, η κλάση [ShapeFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/shapeframe/) παρέχει έλεγχο για οριζόντιο και κατακόρυφο κατοπτρισμό σχημάτων μέσω των ιδιοτήτων `flipH` και `flipV`. Και οι δύο ιδιότητες είναι τύπου `byte`, επιτρέποντας τις τιμές `1` για κατοπτρισμό, `0` για χωρίς κατοπτρισμό ή `-1` για χρήση προεπιλεγμένης συμπεριφοράς. Αυτές οι τιμές είναι προσβάσιμες από το [Frame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/#getFrame--) ενός σχήματος.

Για να τροποποιήσετε τις ρυθμίσεις flip, δημιουργείται ένα νέο στιγμιότυπο [ShapeFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/shapeframe/) με την τρέχουσα θέση και μέγεθος του σχήματος, τις επιθυμητές τιμές για `flipH` και `flipV`, καθώς και τη γωνία περιστροφής. Αναθέτοντας αυτό το στιγμιότυπο στο [Frame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/#getFrame--) του σχήματος και αποθηκεύοντας την παρουσίαση, εφαρμόζονται οι μετασχηματισμοί κατοπτρισμού και αποθηκεύονται στο αρχείο εξόδου.

Ας υποθέσουμε ότι έχουμε ένα αρχείο sample.pptx στο οποίο η πρώτη διαφάνεια περιέχει ένα μόνο σχήμα με προεπιλεγμένες ρυθμίσεις flip, όπως φαίνεται παρακάτω.

![The shape to be flipped](shape_to_be_flipped.png)

Ο ακόλουθος κώδικας παίρνει τις τρέχουσες ιδιότητες flip του σχήματος και τις αντιστρέφει οριζόντια και κατακόρυφα.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    // Ανάκτηση της ιδιότητας οριζόντιου κατοπτρισμού του σχήματος.
    byte horizontalFlip = shape.getFrame().getFlipH();
    System.out.println("Horizontal flip: " + horizontalFlip);

    // Ανάκτηση της ιδιότητας κάθετου κατοπτρισμού του σχήματος.
    byte verticalFlip = shape.getFrame().getFlipV();
    System.out.println("Vertical flip: " + verticalFlip);

    float x = shape.getFrame().getX();
    float y = shape.getFrame().getY();
    float width = shape.getFrame().getWidth();
    float height = shape.getFrame().getHeight();
    byte flipH = NullableBool.True; // Flip horizontally.
    byte flipV = NullableBool.True; // Flip horizontally.
    float rotation = shape.getFrame().getRotation();

    shape.setFrame(new ShapeFrame(x, y, width, height, flipH, flipV, rotation));

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![The flipped shape](flipped_shape.png)

## **FAQ**

**Μπορώ να συνδυάσω σχήματα (ένωση/τομή/αφαίρεση) σε μια διαφάνεια όπως σε έναν επιτραπέζιο επεξεργαστή;**

Δεν υπάρχει ενσωματωμένο API Boolean λειτουργιών. Μπορείτε να το προσεγγίσετε δημιουργώντας το επιθυμητό περίγραμμα μόνοι σας—π.χ. υπολογίζοντας τη γεωμετρία (μέσω του [GeometryPath](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/geometrypath/)) και δημιουργώντας ένα νέο σχήμα με αυτό το περίγραμμα, ενδεχομένως αφαιρώντας τα αρχικά.

**Πώς μπορώ να ελέγξω τη σειρά στοίβασης (z-order) ώστε ένα σχήμα να παραμένει πάντα «στην κορυφή»;**

Αλλάξτε τη σειρά εισαγωγής/μετακίνησης εντός της συλλογής [shapes](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/baseslide/#getShapes--) της διαφάνειας. Για προβλέψιμα αποτελέσματα, ολοκληρώστε το z-order μετά από όλες τις άλλες τροποποιήσεις της διαφάνειας.

**Μπορώ να «κλειδώσω» ένα σχήμα ώστε να αποτρέψω τους χρήστες από το να το επεξεργαστούν στο PowerPoint;**

Ναι. Ορίστε σημαίες προστασίας επιπέδου σχήματος (π.χ. κλείδωμα επιλογής, μετακίνησης, αλλαγής μεγέθους, επεξεργασίας κειμένου). Αν χρειαστεί, εφαρμόστε περιορισμούς στο master ή στο layout. Σημειώστε ότι αυτή είναι προστασία επιπέδου UI, όχι λειτουργία ασφαλείας· για ισχυρότερη προστασία, συνδυάστε με περιορισμούς επιπέδου αρχείου όπως [συμβουλές ανάγνωσης μόνο ή κωδικοί πρόσβασης](/slides/el/androidjava/password-protected-presentation/).