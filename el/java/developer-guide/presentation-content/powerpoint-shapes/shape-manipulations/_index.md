---
title: Διαχείριση Σχημάτων Παρουσίασης σε Java
linktitle: Διαχείριση Σχημάτων
type: docs
weight: 40
url: /el/java/shape-manipulations/
keywords:
- Σχήμα PowerPoint
- σχήμα παρουσίασης
- σχήμα σε διαφάνεια
- εύρεση σχήματος
- κλωνοποίηση σχήματος
- αφαίρεση σχήματος
- απόκρυψη σχήματος
- αλλαγή σειράς σχήματος
- λήψη Interop Shape ID
- εναλλακτικό κείμενο σχήματος
- μορφές διάταξης σχήματος
- σχήμα ως SVG
- σχήμα σε SVG
- ευθυγράμμιση σχήματος
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Μάθετε να δημιουργείτε, επεξεργάζεστε και βελτιστοποιείτε σχήματα στο Aspose.Slides για Java και να παρέχετε παρουσιάσεις PowerPoint υψηλής απόδοσης."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργάζεστε με σχήματα σε παρουσιάσεις χρησιμοποιώντας το Aspose.Slides. Δείχνει πώς να βρείτε ένα σχήμα σε μια διαφάνεια, να το κλωνοποιήσετε, να το αφαιρέσετε, να το αποκρύψετε, να αλλάξετε τη σειρά του, να λάβετε το Interop shape ID και να ορίσετε εναλλακτικό κείμενο για την ταυτοποίηση και περαιτέρω επεξεργασία.

Καλύπτει επίσης πώς να προσπελάσετε μορφές διάταξης για σχήματα, να αποδώσετε ένα σχήμα ως SVG, να ευθυγραμμίσετε σχήματα σε μια διαφάνεια και να χρησιμοποιήσετε τις ιδιότητες αναστροφής για οριζόντια και κάθετη κατοπτρισμό. Επιπλέον, το άρθρο περιλαμβάνει μια σύντομη Συχνές Ερωτήσεις (FAQ) σχετικά με τον συνδυασμό σχημάτων, τη σειρά στοιβάξης και το κλείδωμα σχημάτων.

## **Εύρεση Σχήματος σε Διαφάνεια**
Αυτό το θέμα θα περιγράψει μια απλή τεχνική για να διευκολύνει τους προγραμματιστές να βρουν ένα συγκεκριμένο σχήμα σε μια διαφάνεια χωρίς να χρησιμοποιούν το εσωτερικό του Id. Είναι σημαντικό να γνωρίζετε ότι τα αρχεία Παρουσίασης PowerPoint δεν διαθέτουν τρόπο να αναγνωρίζουν τα σχήματα σε μια διαφάνεια εκτός από ένα εσωτερικό μοναδικό Id. Φαίνεται δύσκολο για τους προγραμματιστές να βρουν ένα σχήμα χρησιμοποιώντας το εσωτερικό μοναδικό Id. Όλα τα σχήματα που προστίθενται στις διαφάνειες έχουν κάποιο Alt Text. Προτείνουμε στους προγραμματιστές να χρησιμοποιούν εναλλακτικό κείμενο για την εύρεση ενός συγκεκριμένου σχήματος. Μπορείτε να χρησιμοποιήσετε το MS PowerPoint για να ορίσετε το εναλλακτικό κείμενο για αντικείμενα που σχεδιάζετε να αλλάξετε στο μέλλον.

Μετά τον ορισμό του εναλλακτικού κειμένου για οποιοδήποτε επιθυμητό σχήμα, μπορείτε να ανοίξετε την παρουσίαση χρησιμοποιώντας το Aspose.Slides for Java και να επαναλάβετε μέσω όλων των σχημάτων που προστέθηκαν σε μια διαφάνεια. Κατά κάθε επανάληψη, μπορείτε να ελέγξετε το εναλλακτικό κείμενο του σχήματος και το σχήμα με το ταιριαστό εναλλακτικό κείμενο θα είναι το σχήμα που απαιτείτε. Για να δείξουμε αυτήν την τεχνική καλύτερα, δημιουργήσαμε μια μέθοδο, [findShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-) που εκτελεί την εύρεση ενός συγκεκριμένου σχήματος σε μια διαφάνεια και επιστρέφει απλώς αυτό το σχήμα.

```java
// Δημιουργία αντικειμένου κλάσης Presentation που αντιπροσωπεύει το αρχείο παρουσίασης
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
// Υλοποίηση μεθόδου για την εύρεση σχήματος σε διαφάνεια χρησιμοποιώντας το εναλλακτικό του κείμενο
public static IShape findShape(ISlide slide, String alttext)
{
    // Επανάληψη σε όλα τα σχήματα μέσα στη διαφάνεια
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        // Αν το εναλλακτικό κείμενο της διαφάνειας ταιριάζει με το απαιτούμενο, τότε
        // Επιστρέψτε το σχήμα
        if (slide.getShapes().get_Item(i).getAlternativeText().compareTo(alttext) == 0)
            return slide.getShapes().get_Item(i);
    }
    return null;
}
```

## **Κλωνοποίηση Σχήματος**
Για να κλωνοποιήσετε ένα σχήμα σε μια διαφάνεια χρησιμοποιώντας το Aspose.Slides for Java:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
1. Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το δείκτη της.
1. Προσπελάστε τη συλλογή σχημάτων της πηγής διαφάνειας.
1. Προσθέστε νέα διαφάνεια στην παρουσίαση.
1. Κλωνοποιήστε σχήματα από τη συλλογή σχημάτων της πηγής διαφάνειας στη νέα διαφάνεια.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

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

    // Αποθήκευση του αρχείου PPTX στον δίσκο
    pres.save("CloneShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Αφαίρεση Σχήματος**
Το Aspose.Slides for Java επιτρέπει στους προγραμματιστές να αφαιρέσουν οποιοδήποτε σχήμα. Για να αφαιρέσετε το σχήμα από οποιαδήποτε διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
1. Προσπελάστε την πρώτη διαφάνεια.
1. Βρείτε το σχήμα με συγκεκριμένο AlternativeText.
1. Αφαιρέστε το σχήμα.
1. Αποθηκεύστε το αρχείο στο δίσκο.

```java
// Δημιουργία αντικειμένου Presentation
Presentation pres = new Presentation();
try {
    // Λήψη της πρώτης διαφάνειας
    ISlide sld = pres.getSlides().get_Item(0);

    // Προσθήκη αυτόματου σχήματος τύπου Rectangle
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

    // Αποθήκευση παρουσίασης στον δίσκο
    pres.save("RemoveShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Απόκρυψη Σχήματος**
Το Aspose.Slides for Java επιτρέπει στους προγραμματιστές να αποκρύψουν οποιοδήποτε σχήμα. Για να αποκρύψετε το σχήμα από οποιαδήποτε διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
1. Προσπελάστε την πρώτη διαφάνεια.
1. Βρείτε το σχήμα με συγκεκριμένο AlternativeText.
1. Αποκρύψτε το σχήμα.
1. Αποθηκεύστε το αρχείο στο δίσκο.

```java
// Δημιουργία αντικειμένου κλάσης Presentation που αντιπροσωπεύει το PPTX
Presentation pres = new Presentation();
try {
    // Λήψη της πρώτης διαφάνειας
    ISlide sld = pres.getSlides().get_Item(0);

    // Προσθήκη αυτόματου σχήματος τύπου Rectangle
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

    // Αποθήκευση παρουσίασης στον δίσκο
    pres.save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Αλλαγή Σειράς Σχήματος**
Το Aspose.Slides for Java επιτρέπει στους προγραμματιστές να αλλάξουν τη σειρά των σχημάτων. Η αλλαγή σειράς καθορίζει ποιο σχήμα βρίσκεται μπροστά ή πίσω. Για να αλλάξετε τη σειρά ενός σχήματος σε οποιαδήποτε διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
1. Προσπελάστε την πρώτη διαφάνεια.
1. Προσθέστε ένα σχήμα.
1. Προσθέστε κάποιο κείμενο στο πλαίσιο κειμένου του σχήματος.
1. Προσθέστε ένα άλλο σχήμα με τις ίδιες συντεταγμένες.
1. Αλλάξτε τη σειρά των σχημάτων.
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

## **Λήψη Interop Shape ID**
Το Aspose.Slides for Java επιτρέπει στους προγραμματιστές να λάβουν έναν μοναδικό ταυτοποιητή σχήματος στο πλαίσιο της διαφάνειας, σε αντίθεση με τη μέθοδο [getUniqueId](https://reference.aspose.com/slides/el/java/com.aspose.slides/IShape#getUniqueId--) που παρέχει μοναδικό ταυτοποιητή στο πλαίσιο της παρουσίασης. Η μέθοδος [getOfficeInteropShapeId](https://reference.aspose.com/slides/el/java/com.aspose.slides/IShape#getOfficeInteropShapeId--) προστέθηκε στις διεπαφές [IShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/IShape) και στην κλάση [Shape](https://reference.aspose.com/slides/el/java/com.aspose.slides/Shape). Η τιμή που επιστρέφεται από τη μέθοδο [getOfficeInteropShapeId](https://reference.aspose.com/slides/el/java/com.aspose.slides/IShape#getOfficeInteropShapeId--) αντιστοιχεί στην τιμή του Id του αντικειμένου Microsoft.Office.Interop.PowerPoint.Shape. Παρακάτω δίνεται ένα δείγμα κώδικα.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Λήψη μοναδικού ταυτοποιητή σχήματος στο επίπεδο της διαφάνειας
    long officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();

} finally {
    if (pres != null) pres.dispose();
}
```

## **Ορισμός Εναλλακτικού Κειμένου για Σχήμα**
Το Aspose.Slides for Java επιτρέπει στους προγραμματιστές να ορίσουν AlternateText για οποιοδήποτε σχήμα. Τα σχήματα σε μια παρουσίαση μπορούν να διακριθούν με τη μέθοδο [AlternativeText](https://reference.aspose.com/slides/el/java/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) ή [Shape Name](https://reference.aspose.com/slides/el/java/com.aspose.slides/IShape#setName-java.lang.String-). Οι μέθοδοι [setAlternativeText](https://reference.aspose.com/slides/el/java/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) και [getAlternativeText](https://reference.aspose.com/slides/el/java/com.aspose.slides/IShape#getAlternativeText--) μπορούν να διαβαστούν ή να οριστούν χρησιμοποιώντας το Aspose.Slides καθώς και το Microsoft PowerPoint. Χρησιμοποιώντας αυτή τη μέθοδο, μπορείτε να επισημάνετε ένα σχήμα και να εκτελέσετε διάφορες λειτουργίες όπως Αφαίρεση σχήματος, Απόκρυψη σχήματος ή Αλλαγή σειράς σχημάτων σε μια διαφάνεια. Για να ορίσετε το AlternateText ενός σχήματος, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
1. Προσπελάστε την πρώτη διαφάνεια.
1. Προσθέστε οποιοδήποτε σχήμα στη διαφάνεια.
1. Εκτελέστε κάποια εργασία με το νεοπροστέθηκε σχήμα.
1. Περιηγηθείτε στα σχήματα για να βρείτε το σχήμα.
1. Ορίστε το AlternativeText.
1. Αποθηκεύστε το αρχείο στο δίσκο.

```java
// Δημιουργία αντικειμένου κλάσης Presentation που αντιπροσωπεύει το PPTX
Presentation pres = new Presentation();
try {
    // Λήψη της πρώτης διαφάνειας
    ISlide sld = pres.getSlides().get_Item(0);

    // Προσθήκη αυτόματου σχήματος τύπου Rectangle
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

    // Αποθήκευση παρουσίασης στον δίσκο
    pres.save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Πρόσβαση σε Μορφές Διάταξης για Σχήμα**
Το Aspose.Slides for Java παρέχει ένα απλό API για πρόσβαση σε μορφές διάταξης ενός σχήματος. Το άρθρο αυτό δείχνει πώς μπορείτε να προσπελάσετε τις μορφές διάταξης.

Παρακάτω δίνεται κώδικας δείγματος.

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

## **Απόδοση Σχήματος ως SVG**
Τώρα το Aspose.Slides for Java υποστηρίζει την απόδοση ενός σχήματος ως svg. Η μέθοδος [writeAsSvg](https://reference.aspose.com/slides/el/java/com.aspose.slides/IShape#writeAsSvg-java.io.OutputStream-) (και οι υπερφορτώσεις της) προστέθηκαν στην κλάση [Shape](https://reference.aspose.com/slides/el/java/com.aspose.slides/Shape) και στη διεπαφή [IShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/IShape). Αυτή η μέθοδος επιτρέπει την αποθήκευση του περιεχομένου του σχήματος ως αρχείο SVG. Το παρακάτω απόσπασμα κώδικα δείχνει πώς να εξάγετε το σχήμα μιας διαφάνειας σε αρχείο SVG.

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

## **Στοίχιση Σχήματος**
Το Aspose.Slides επιτρέπει την ευθυγράμμιση σχημάτων είτε σε σχέση με τα περιθώρια της διαφάνειας είτε μεταξύ τους. Για το σκοπό αυτό προστέθηκε η υπερφορτωμένη μέθοδος [SlidesUtil.alignShape()](https://reference.aspose.com/slides/el/java/com.aspose.slides/SlideUtil#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-). Η απαρίθμηση [ShapesAlignmentType](https://reference.aspose.com/slides/el/java/com.aspose.slides/ShapesAlignmentType) ορίζει τις δυνατές επιλογές στοίχισης.

**Παράδειγμα 1**

Ο παρακάτω πηγαίος κώδικας ευθυγραμμίζει σχήματα με δείκτες 1,2 και 4 κατά το πάνω όριο της διαφάνειας.

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

Το παρακάτω παράδειγμα δείχνει πώς να ευθυγραμμίσετε ολόκληρη τη συλλογή σχημάτων σε σχέση με το πιο κάτω σχήμα της συλλογής.

```java
Presentation pres = new Presentation("example.pptx");
try {
    SlideUtil.alignShapes(ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ιδιότητες Αναστροφής**

Στο Aspose.Slides, η κλάση [ShapeFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/shapeframe/) παρέχει έλεγχο της οριζόντιας και κάθετης κατοπτρισμού των σχημάτων μέσω των ιδιοτήτων `flipH` και `flipV`. Και οι δύο ιδιότητες είναι τύπου `byte`, επιτρέποντας τις τιμές `1` για αναστροφή, `0` για καμία αναστροφή ή `-1` για προεπιλογή συμπεριφοράς. Αυτές οι τιμές είναι προσβάσιμες από το [Frame](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishape/#getFrame--) ενός σχήματος.

Για να τροποποιήσετε τις ρυθμίσεις αναστροφής, δημιουργείται μια νέα παρουσία του [ShapeFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/shapeframe/) με τη τρέχουσα θέση και μέγεθος του σχήματος, τις επιθυμητές τιμές για `flipH` και `flipV` και τη γωνία περιστροφής. Η ανάθεση αυτής της παρουσίας στο [Frame](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishape/#getFrame--) του σχήματος και η αποθήκευση της παρουσίασης εφαρμόζει τις μετασχηματιστικές κατοπτρισμούς και τα αποθηκεύει στο αρχείο εξόδου.

Ας υποθέσουμε ότι διαθέτουμε το αρχείο sample.pptx, στο οποίο η πρώτη διαφάνεια περιέχει ένα μόνο σχήμα με τις προεπιλεγμένες ρυθμίσεις αναστροφής, όπως φαίνεται παρακάτω.

![Το σχήμα που θα αναστραφεί](shape_to_be_flipped.png)

Ο παρακάτω κώδικας παραδείγματος ανακτά τις τρέχουσες ιδιότητες αναστροφής του σχήματος και το αναστρέφει οριζόντια και κάθετα.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    // Ανάκτηση της οριζόντιας ιδιότητας αντιστροφής του σχήματος.
    byte horizontalFlip = shape.getFrame().getFlipH();
    System.out.println("Horizontal flip: " + horizontalFlip);

    // Ανάκτηση της κάθετης ιδιότητας αντιστροφής του σχήματος.
    byte verticalFlip = shape.getFrame().getFlipV();
    System.out.println("Vertical flip: " + verticalFlip);

    float x = shape.getFrame().getX();
    float y = shape.getFrame().getY();
    float width = shape.getFrame().getWidth();
    float height = shape.getFrame().getHeight();
    byte flipH = NullableBool.True; // Αντιστροφή οριζόντια.
    byte flipV = NullableBool.True; // Αντιστροφή οριζόντια.
    float rotation = shape.getFrame().getRotation();

    shape.setFrame(new ShapeFrame(x, y, width, height, flipH, flipV, rotation));

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Το αναστραμμένο σχήμα](flipped_shape.png)

## **Συχνές Ερωτήσεις**

**Μπορώ να συνδυάσω σχήματα (ένωση/τομή/αφαίρεση) σε μια διαφάνεια όπως σε έναν επεξεργαστή επιφάνειας εργασίας;**

Δεν υπάρχει ενσωματωμένο API λογικών Boolean λειτουργιών. Μπορείτε να το προσεγγίσετε δημιουργώντας το επιθυμητό περίγραμμα εσείς—π.χ., υπολογίζοντας τη γεωμετρία (μέσω [GeometryPath](https://reference.aspose.com/slides/el/java/com.aspose.slides/geometrypath/)) και δημιουργώντας ένα νέο σχήμα με αυτό το περίγραμμα, ενδεχομένως αφαιρώντας τα αρχικά.

**Πώς μπορώ να ελέγξω τη σειρά στοιβάξης (z-order) ώστε ένα σχήμα να παραμένει πάντα «στην κορυφή»;**

Αλλάξτε τη σειρά εισαγωγής/μετακίνησης μέσα στη συλλογή [shapes](https://reference.aspose.com/slides/el/java/com.aspose.slides/baseslide/#getShapes--) της διαφάνειας. Για προβλέψιμα αποτελέσματα, τελειώστε τη σειρά z-order μετά από όλες τις άλλες τροποποιήσεις της διαφάνειας.

**Μπορώ να «κλειδώσω» ένα σχήμα ώστε να αποτρέψω τους χρήστες από την επεξεργασία του στο PowerPoint;**

Ναι. Ορίστε τα [shape-level protection flags](/slides/el/java/applying-protection-to-presentation/) (π.χ., κλείδωμα επιλογής, κίνησης, αλλαγής μεγέθους, επεξεργασίας κειμένου). Αν χρειάζεται, εφαρμόστε περιορισμούς στο master ή στο layout. Σημειώστε ότι αυτό είναι προστασία σε επίπεδο UI, όχι μια λειτουργία ασφαλείας· για ισχυρότερη προστασία, συνδυάστε με περιορισμούς σε επίπεδο αρχείου όπως συστάσεις μόνο για ανάγνωση ή κωδικούς πρόσβασης [/slides/el/java/password-protected-presentation/].