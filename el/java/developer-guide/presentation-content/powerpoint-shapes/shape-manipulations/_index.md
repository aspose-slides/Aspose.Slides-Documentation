---
title: Διαχείριση Σχημάτων Παρουσίασης σε Java
linktitle: Χειρισμός Σχημάτων
type: docs
weight: 40
url: /el/java/shape-manipulations/
keywords:
- Σχήμα PowerPoint
- Σχήμα παρουσίασης
- Σχήμα σε διαφάνεια
- Εύρεση σχήματος
- Κλωνοποίηση σχήματος
- Αφαίρεση σχήματος
- Απόκρυψη σχήματος
- Αλλαγή σειράς σχήματος
- Λήψη ID σχήματος interop
- Εναλλακτικό κείμενο σχήματος
- Σημείο προσαρμογής σχήματος
- Προρυθμισμένη προσαρμογή σχήματος
- Γεωμετρία σχήματος
- Μορφές διάταξης σχήματος
- Σχήμα ως SVG
- Σχήμα σε SVG
- Στοίχιση σχήματος
- Αναστροφή σχήματος
- PowerPoint
- Παρουσίαση
- Java
- Aspose.Slides
description: "Μάθετε πώς να αναγνωρίζετε, προσαρμόζετε, κλωνοποιείτε, αφαιρείτε, κρύβετε, αναδιατάξετε, εξάγετε, στοιχίζετε και αντιστρέφετε σχήματα παρουσίασης με το Aspose.Slides for Java."
---
## **Επισκόπηση**

Το Aspose.Slides for Java αντιπροσωπεύει τα σχήματα σε μια διαφάνεια ως μια διατεταγμένη [IShapeCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishapecollection/). Η συλλογή είναι τόσο το μέρος όπου βρίσκετε και τροποποιείτε τα σχήματα όσο και η πηγή της σειράς στοίβαξής τους: η θέση `0` είναι το πιο πίσω σχήμα, ενώ η τελευταία θέση είναι το πιο μπροστά σχήμα.

Αυτό το άρθρο ακολουθεί αυτό το μοντέλο. Πρώτα εξηγεί πώς να αναγνωρίζετε ένα σχήμα αξιόπιστα και να τροποποιείτε προρυθμισμένα σημεία προσαρμογής σχήματος, στη συνέχεια δείχνει πώς να κλωνοποιείτε, να αφαιρείτε, να κρύβετε και να αναδιατάσσετε σχήματα. Τα τελικά τμήματα καλύπτουν μορφοποίηση σε επίπεδο διάταξης, εξαγωγή SVG, στοίχιση και ρυθμίσεις αναστροφής. Κάθε παράδειγμα είναι ανεξάρτητο, ώστε να μπορείτε να χρησιμοποιήσετε μόνο τις λειτουργίες που απαιτεί η ροή εργασίας σας.

## **Αναγνώριση και Εύρεση Σχημάτων**

Οι δείκτες της συλλογής είναι βολικοί κατά την επεξεργασία γνωστού αρχείου, αλλά δεν αποτελούν σταθερά αναγνωριστικά. Η προσθήκη, η αφαίρεση ή η αναδιάταξη ενός σχήματος μπορεί να αλλάξει τον δείκτη του. Επιλέξτε ένα αναγνωριστικό ανάλογα με το πώς δημιουργείται και διατηρείται η παρουσίαση:

- [Name](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishape/#getName--) είναι χρήσιμο για πρότυπα ελεγχόμενα από προγραμματιστές και είναι εύκολο να επιθεωρηθεί στο Pane Επιλογής του PowerPoint. Τα ονόματα μπορούν να επεξεργαστούν και δεν εγγυώνται μοναδικότητα, επομένως θέστε έναν κανόνα ονομασίας αν ο κώδικας εξαρτάται από αυτά.
- [AlternativeText](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishape/#getAlternativeText--) είναι χρήσιμο όταν μια περιγραφή προσβασιμότητας ή μια ετικέτα που έχει προσθέσει ο δημιουργός ήδη ταυτοποιεί το σχήμα. Είναι ορατό στους χρήστες, μπορεί να μεταφραστεί ή να επαναγραφεί για προσβασιμότητα, και δεν εγγυάται μοναδικότητα. Μην επαναχρησιμοποιείτε σιωπηρά σημαντικό κείμενο προσβασιμότητας ως κλειδί βάσης δεδομένων.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--) είναι ένα μόνο‑ανάγνωση αναγνωριστικό που είναι μοναδικό μέσα σε μια διαφάνεια και αντιστοιχεί στο ID σχήματος που χρησιμοποιεί το PowerPoint interop. Χρησιμοποιήστε το όταν ενσωματώνετε με το PowerPoint ή όταν χρειάζεστε αδιαπραγμάτευτη αναφορά κατά τη διάρκεια ζωής ενός σχήματος. Ένα κλωνοποιημένο ή ξαναδημιουργημένο σχήμα είναι διαφορετικό σχήμα και λαμβάνει το δικό του ID.

Η σχετική μέθοδος [getUniqueId](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishape/#getUniqueId--) επιστρέφει ένα αναγνωριστικό εμβέλειας παρουσίασης, αλλά αυτό το αναγνωριστικό προορίζεται για πρόσθετα και μπορεί να επαναπροσδιοριστεί. Δεν θα πρέπει να θεωρείται μόνιμο εξωτερικό κλειδί. Αν η μακροπρόθεσμη ταυτότητα είναι κρίσιμη, διατηρήστε το αντιστοίχηση σε δεδομένα εφαρμογής και επικυρώστε ότι το αναμενόμενο σχήμα υπάρχει ακόμη.

Το παρακάτω παράδειγμα αναζητά με βάση το όνομα με ακριβή σύγκριση και αναφέρει το ID interop της διαφάνειας. Όταν το πρότυπο δεν περιέχει το αναμενόμενο σχήμα, ο κώδικας αναφέρει αυτό το αποτέλεσμα αντί να συνεχίσει με το λανθασμένο αντικείμενο.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape targetShape = null;
    for (IShape shape : slide.getShapes()) {
        if ("RevenueChart".equals(shape.getName())) {
            targetShape = shape;
            break;
        }
    }

    if (targetShape == null) {
        System.out.println("The shape 'RevenueChart' was not found on slide 1.");
    } else {
        System.out.println("Found " + targetShape.getName() + "; interop ID: " + targetShape.getOfficeInteropShapeId());
    }
} finally {
    presentation.dispose();
}
```

Όταν μια λειτουργία είναι ειδική για συγκεκριμένο τύπο σχήματος, ελέγξτε τη διεπαφή πριν χρησιμοποιήσετε μέλη τύπου‑συγκεκριμένα. Αυτό το παράδειγμα ενημερώνει το κείμενο και το εναλλακτικό κείμενο μόνο εάν το ονομασμένο αντικείμενο είναι ένα [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape/).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape candidate = null;
    for (IShape shape : slide.getShapes()) {
        if ("StatusLabel".equals(shape.getName())) {
            candidate = shape;
            break;
        }
    }

    if (candidate instanceof IAutoShape) {
        IAutoShape autoShape = (IAutoShape) candidate;
        autoShape.getTextFrame().setText("Approved");
        autoShape.setAlternativeText("Approval status: approved");
        presentation.save("identified-shape.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("'StatusLabel' is missing or is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

## **Αναγνώριση και Τροποποίηση Προρυθμισμένων Προσαρμογών Σχήματος**

Τα σχήματα προρυθμισμένης γεωμετρίας μπορούν να εκθέσουν σημεία προσαρμογής που ελέγχουν χαρακτηριστικά όπως το μέγεθος γωνίας, τις αναλογίες βέλους ή τις γωνίες τόξων. Πρόσβαση σε αυτά γίνεται μέσω της μόνο‑ανάγνωσης συλλογής [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/el/java/com.aspose.slides/igeometryshape/#getAdjustments--) που παρέχεται από το σχήμα· κάθε [IAdjustValue](https://reference.aspose.com/slides/el/java/com.aspose.slides/iadjustvalue/) περιέχει μια τιμή που μπορεί να αλλάξει.

Μην βασίζεστε μόνο σε έναν σταθερό δείκτη συλλογής. Περάστε από όλες τις προσαρμογές και εξετάστε τη μόνο‑ανάγνωσης μέθοδο [getType](https://reference.aspose.com/slides/el/java/com.aspose.slides/iadjustvalue/#getType--) της, της οποίας η τιμή [ShapeAdjustmentType](https://reference.aspose.com/slides/el/java/com.aspose.slides/shapeadjustmenttype/) περιγράφει τι ελέγχει η προσαρμογή. Η μόνο‑ανάγνωσης μέθοδος [getName](https://reference.aspose.com/slides/el/java/com.aspose.slides/iadjustvalue/#getName--) παρέχει πρόσθετες πληροφορίες ταυτοποίησης και είναι ιδιαίτερα χρήσιμη όταν ένα προρυθμισμένο σχήμα περιέχει περισσότερες από μία προσαρμογές με τον ίδιο σημασιολογικό τύπο.

Χρησιμοποιήστε τη μέθοδο τιμής που ταιριάζει με το νόημα της προσαρμογής:

| Τύπος προσαρμογής | Σκοπός | Τιμή προς αλλαγή |
|---|---|---|
| `CornerSize` | Μέγεθος στρογγυλεμένων γωνιών | [setRawValue](https://reference.aspose.com/slides/el/java/com.aspose.slides/iadjustvalue/#setRawValue-long-) |
| `ArrowTailThickness` | Πάχος άκρου βέλους | `setRawValue` |
| `ArrowheadLength` | Μήκος άκρου βέλους | `setRawValue` |
| `ArrowheadWidth` | Πλάτος άκρου βέλους | `setRawValue` |
| `StartAngle` | Αρχική γωνία πίτας ή τόξου | [setAngleValue](https://reference.aspose.com/slides/el/java/com.aspose.slides/iadjustvalue/#setAngleValue-float-) |
| `EndAngle` | Τελική γωνία πίτας ή τόξου | `setAngleValue` |

Το `getType` και το `getName` επιστρέφουν μόνο‑ανάγνωστη πληροφορία. Τα `getRawValue` και `setRawValue` δουλεύουν με ακέραιο στις εγγενείς μονάδες γεωμετρίας του προρυθμισμένου σχήματος, ενώ τα `getAngleValue` και `setAngleValue` δουλεύουν με γωνία σε μοίρες. Ο αριθμός, η σειρά, το νόημα και το έγκυρο εύρος των προσαρμογών εξαρτώνται από το προρυθμισμένο [ShapeType](https://reference.aspose.com/slides/el/java/com.aspose.slides/igeometryshape/#getShapeType--). Μία τιμή που είναι έγκυρη για ένα προρυθμισμένο σχήμα μπορεί να είναι άκυρη ή να έχει διαφορετικό αποτέλεσμα για άλλο.

Όταν το `getType` επιστρέφει `ShapeAdjustmentType.Custom`, το API δεν αναγνωρίζει τυπικό σημασιολογικό νόημα. Εξετάστε το `getName`, τον τύπο προρυθμισμένου σχήματος και την υπάρχουσα τιμή, και αφήστε την προσαρμογή αμετάβλητη εκτός εάν γνωρίζετε το αναμενόμενο νόημα και εύρος. Ακόμη και για αναγνωρισμένους τύπους, ελέγξτε αν ο ίδιος τύπος εμφανίζεται περισσότερες από μία φορές πριν επιλέξετε τιμή. Το άρθρο [Connector](/slides/el/java/connector/) δείχνει αυτή τη κατάσταση με προσαρμογές κάμψης συνδετήρων.

Το παρακάτω πλήρες παράδειγμα δημιουργεί προεπιλεγμένες και τροποποιημένες εκδοχές τριών προρυθμισμένων σχημάτων. Περνάει από κάθε προσαρμογή, αναφέρει το όνομα και τον τύπο της, αλλάζει τιμές σχετικές με το μέγεθος μέσω `setRawValue`, αλλάζει γωνίες μέσω `setAngleValue` και αποθηκεύει το αποτέλεσμα. Η αριστερή στήλη διατηρεί τη προεπιλεγμένη γεωμετρία· η δεξιά στήλη δείχνει το προσαρμοσμένο στρογγυλεμένο ορθογώνιο, το τέσσερις‑κατευθύνσεων βέλος και την πίτα.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Προσθέτει επικεφαλίδες για τις στήλες προεπιλεγμένου και προσαρμοσμένου σχήματος.
    IAutoShape defaultColumnLabel = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 20, 250, 30);
    defaultColumnLabel.getTextFrame().setText("Default preset geometry");
    IAutoShape adjustedColumnLabel = slide.getShapes().addAutoShape(ShapeType.Rectangle, 390, 20, 250, 30);
    adjustedColumnLabel.getTextFrame().setText("Modified adjustment values");

    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
    IGeometryShape modifiedRoundedRectangle = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
    modifiedRoundedRectangle.setName("ModifiedRoundedRectangle");

    slide.getShapes().addAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110);
    IGeometryShape modifiedArrow = slide.getShapes().addAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110);
    modifiedArrow.setName("ModifiedQuadArrow");

    slide.getShapes().addAutoShape(ShapeType.Pie, 95, 330, 130, 130);
    IGeometryShape modifiedPie = slide.getShapes().addAutoShape(ShapeType.Pie, 445, 330, 130, 130);
    modifiedPie.setName("ModifiedPie");

    IGeometryShape[] shapesToAdjust = {
        modifiedRoundedRectangle,
        modifiedArrow,
        modifiedPie
    };

    for (IGeometryShape shape : shapesToAdjust) {
        for (int adjustmentIndex = 0; adjustmentIndex < shape.getAdjustments().size(); adjustmentIndex++) {
            IAdjustValue adjustment = shape.getAdjustments().get_Item(adjustmentIndex);
            System.out.println(shape.getName() + " / " + adjustment.getName() + ": " + adjustment.getType());

            switch (adjustment.getType()) {
                case ShapeAdjustmentType.CornerSize:
                    adjustment.setRawValue(5000);
                    break;
                case ShapeAdjustmentType.ArrowTailThickness:
                    adjustment.setRawValue(25000);
                    break;
                case ShapeAdjustmentType.ArrowheadLength:
                    adjustment.setRawValue(30000);
                    break;
                case ShapeAdjustmentType.ArrowheadWidth:
                    adjustment.setRawValue(40000);
                    break;
                case ShapeAdjustmentType.StartAngle:
                    adjustment.setAngleValue(30);
                    break;
                case ShapeAdjustmentType.EndAngle:
                    adjustment.setAngleValue(300);
                    break;
                case ShapeAdjustmentType.Custom:
                    System.out.println("Custom adjustment '" + adjustment.getName() + "' was not changed.");
                    break;
            }
        }
    }

    presentation.save("preset-shape-adjustments.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ο έλεγχος του σημασιολογικού τύπου πριν την αλλαγή μιας τιμής κάνει τον κώδικα σαφή σχετικά με την πρόθεσή του και αποφεύγει την υπόθεση ότι ένας συγκεκριμένος δείκτης συλλογής έχει το ίδιο νόημα σε διαφορετικά προρυθμισμένα σχήματα.

## **Τροποποίηση Συλλογής Σχημάτων**

Οι μέθοδοι προσθήκης, κλωνοποίησης, αφαίρεσης και αναδιάταξης λειτουργούν αμέσως στη συλλογή. Αν μια λειτουργία αλλάζει τον αριθμό ή τη σειρά των σχημάτων, μην συνεχίσετε να βασίζεστε σε δείκτες που συλλέχθηκαν πριν από αυτή τη λειτουργία.

### **Κλωνοποίηση Σχήματος**

[addClone](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) δημιουργεί ένα ανεξάρτητο αντίγραφο και το προσθέτει στο στόχο συλλογής. [insertClone](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) επίσης δημιουργεί αντίγραφο αλλά το τοποθετεί σε συγκεκριμένο δείκτη z‑order. Οι υπερφορτώσεις που δέχονται συντεταγμένες μετακινούν το αντίγραφο χωρίς αλλαγή μεγέθους· οι υπερφορτώσεις με πλάτος και ύψος μπορούν επίσης να το επανασχεδιάσουν.

Το παράδειγμα δημιουργεί μια διαφάνεια προορισμού, κλωνοποιεί ένα επισημασμένο ορθογώνιο μπροστά, και εισάγει ένα δεύτερο κλώνο στο τέλος. Αλλαγές σε οποιοδήποτε κλώνο δεν τροποποιούν το αρχικό σχήμα.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide sourceSlide = presentation.getSlides().get_Item(0);
    IAutoShape sourceShape = sourceSlide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 180, 60);
    sourceShape.setName("SourceLabel");
    sourceShape.getTextFrame().setText("Source");

    ILayoutSlide blankLayout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank);
    ISlide destinationSlide = presentation.getSlides().addEmptySlide(blankLayout);

    IShape frontCloneShape = destinationSlide.getShapes().addClone(sourceShape, 80, 80);
    frontCloneShape.setName("FrontClone");
    if (frontCloneShape instanceof IAutoShape) {
        IAutoShape frontClone = (IAutoShape) frontCloneShape;
        frontClone.getTextFrame().setText("Front clone");
    } else {
        System.out.println("The front clone is not an AutoShape; its text was not changed.");
    }

    IShape backCloneShape = destinationSlide.getShapes().insertClone(0, sourceShape, 80, 180);
    backCloneShape.setName("BackClone");
    if (backCloneShape instanceof IAutoShape) {
        IAutoShape backClone = (IAutoShape) backCloneShape;
        backClone.getTextFrame().setText("Back clone");
    } else {
        System.out.println("The back clone is not an AutoShape; its text was not changed.");
    }

    presentation.save("cloned-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η κλωνοποίηση αντιγράφει το περιεχόμενο και τη μορφοποίηση του σχήματος, συμπεριλαμβανομένων του ονόματος και του εναλλακτικού κειμένου. Αναθέστε νέες λογικές ταυτοποιήσεις στο κλώνο όταν αυτές οι τιμές πρέπει να είναι μοναδικές. Οι πόροι που χρησιμοποιούνται από σύνθετα σχήματα διαχειρίζονται από την παρουσίαση, αλλά ένα κλώνο παραμένει νέο στοιχείο συλλογής με νέα ταυτότητα σχήματος.

### **Αφαίρεση Σχημάτων**

[remove](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) διαγράφει ένα συγκεκριμένο αντικείμενο σχήματος από τη συλλογή του. Όταν αφαιρείτε πολλαπλές αντιστοιχίες κατά την επανάληψη με δείκτες, προχωρήστε από το τέλος ώστε κάθε εναπομείναν δείκτης να παραμένει έγκυρος.

Αυτό το παράδειγμα αφαιρεί κάθε σχήμα με ορισμένο όνομα. Διαβάζει το σχήμα στον τρέχοντα δείκτη, όχι ένα σταθερό στοιχείο της συλλογής, και δεν κάνει περιττές μετατροπές τύπου.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape keepShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 140, 60);
    keepShape.setName("Keep");

    IAutoShape firstTemporaryShape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 220, 40, 80, 80);
    firstTemporaryShape.setName("Temporary");

    IAutoShape secondTemporaryShape = slide.getShapes().addAutoShape(ShapeType.Triangle, 340, 40, 100, 80);
    secondTemporaryShape.setName("Temporary");

    for (int i = slide.getShapes().size() - 1; i >= 0; i--) {
        IShape shape = slide.getShapes().get_Item(i);
        if ("Temporary".equals(shape.getName())) {
            slide.getShapes().remove(shape);
        }
    }

    presentation.save("removed-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Μετά την αφαίρεση, ο αριθμός των σχημάτων και οι δείκτες των υπολοίπων σχημάτων αλλάζουν. Αναφορές σε ανεπηρέαστα σχήματα παραμένουν πιο αξιόπιστες από αποθηκευμένους δείκτες. Λάβετε επίσης υπόψη συνδέσμους, animation κ.ά. που μπορεί να αναφέρονται στο αφαιρεθέν αντικείμενο· η αφαίρεση ενός ορατού σχήματος μπορεί να αλλάξει περισσότερο από την εμφάνιση της διαφάνειας.

### **Κρύψιμο Σχήματος**

Ορίζοντας το [Hidden](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishape/#setHidden-boolean-) σε `true` διατηρεί το σχήμα στη συλλογή αλλά εμποδίζει την εμφάνισή του στην κανονική παρουσίαση. Ο δείκτης, η μορφοποίηση και το περιεχόμενο παραμένουν διαθέσιμα στον κώδικα, γι’ αυτό το κρύψιμο είναι κατάλληλο για προαιρετικά στοιχεία που μπορεί να επαναφερθούν αργότερα.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape visibleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 160, 60);
    visibleShape.setName("VisibleLabel");

    IAutoShape optionalShape = slide.getShapes().addAutoShape(ShapeType.Moon, 240, 40, 100, 100);
    optionalShape.setName("OptionalDecoration");

    for (IShape shape : slide.getShapes()) {
        if ("OptionalDecoration".equals(shape.getName())) {
            shape.setHidden(true);
        }
    }

    presentation.save("hidden-shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το κρύψιμο δεν είναι διαγραφή ή ασφάλεια. Το αντικείμενο μπορεί ακόμη να ανακαλυφθεί και να εμφανιστεί ξανά από χρήστη ή κώδικα, και παραμένει μέρος του αρχείου παρουσίασης.

### **Αλλαγή Z‑Order**

Τα επικαλυπτόμενα σχήματα χρωματίζονται με τη σειρά της συλλογής. Η μέθοδος [reorder](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) μετακινεί ένα υπάρχον σχήμα σε στόχο δείκτη χωρίς κλωνοποίηση. Ο δείκτης `0` είναι το πίσω μέρος· `size() - 1` είναι το μπροστινό.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape blueRectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 220, 120);
    blueRectangle.setName("BlueRectangle");
    blueRectangle.getFillFormat().setFillType(FillType.Solid);
    blueRectangle.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    IAutoShape orangeEllipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 180, 140, 220, 120);
    orangeEllipse.setName("OrangeEllipse");
    orangeEllipse.getFillFormat().setFillType(FillType.Solid);
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το ορθογώνιο δημιουργείται πρώτα και αρχικά βρίσκεται πίσω από την έλλειψη. Η μετακίνηση στο τελικό δείκτη το τοποθετεί μπροστά. Ολοκληρώστε το z‑order μετά την προσθήκη ή κλωνοποίηση όλων των σχετικών σχημάτων, επειδή αυτές οι λειτουργίες προσθέτουν ή εισάγουν νέα στοιχεία στη συλλογή και μπορούν να αλλάξουν τη στοίβαξη.

## **Έλεγχος Σχημάτων σε Διαφάνειες Διάταξης**

Οι κανονικές διαφάνειες, οι διαφάνειες διάταξης και οι κύριες διαφάνειες έχουν ξεχωριστές συλλογές σχημάτων. Ένα σχήμα σε συλλογή διάταξης δεν είναι το ίδιο αντικείμενο με ένα παρόμοιο σχήμα σε κανονική διαφάνεια. Εξετάστε τα σχήματα διάταξης όταν χρειάζεται να κατανοήσετε ή να αλλάξετε μορφοποίηση που παρέχεται από διάταξη.

Το παρακάτω παράδειγμα διαβάζει το [FillFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishape/#getFillFormat--) και το [LineFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishape/#getLineFormat--) κάθε σχήματος διάταξης χωρίς να υποθέτει ότι κάθε σχήμα είναι `AutoShape`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ILayoutSlide layoutSlide : presentation.getLayoutSlides()) {
        for (IShape shape : layoutSlide.getShapes()) {
            int fillType = shape.getFillFormat().getFillType();
            double lineWidth = shape.getLineFormat().getWidth();
            System.out.println(layoutSlide.getName() + " / " + shape.getName() + ": fill=" + fillType + ", line width=" + lineWidth);
        }
    }
} finally {
    presentation.dispose();
}
```

Η επεξεργασία μιας διάταξης μπορεί να επηρεάσει πολλές διαφάνειες που τη χρησιμοποιούν. Πριν αλλάξετε ένα σχήμα διάταξης, προσδιορίστε εάν μια κανονική διαφάνεια κληρονομεί το αντικείμενο ή περιέχει τοπική υπερκάλυψη, και δοκιμάστε κάθε διαφάνεια που χρησιμοποιεί τη διάταξη.

## **Εξαγωγή Σχήματος σε SVG**

[writeAsSvg](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) γράφει το αποδομένο περιεχόμενο ενός σχήματος σε ροή. Το αποτέλεσμα περιέχει το σχήμα, όχι ολόκληρο το φόντο της διαφάνειας ή τα γειτονικά σχήματα.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() == 0) {
        System.out.println("Slide 1 does not contain a shape to export.");
    } else {
        IShape shape = slide.getShapes().get_Item(0);
        try (FileOutputStream svgStream = new FileOutputStream("shape.svg")) {
            shape.writeAsSvg(svgStream);
        } catch (IOException exception) {
            System.out.println("The SVG file could not be written: " + exception.getMessage());
        }
    }
} finally {
    presentation.dispose();
}
```

Διατηρήστε την παρουσίαση ανοιχτή κατά τη διάρκεια της απόδοσης. Η έξοδος εξαρτάται από τη μορφοποίηση του σχήματος και από πόρους όπως γραμματοσειρές και εικόνες. Αν χρειάζεστε ολόκληρη τη σύνθεση, εξάγετε τη διαφάνεια αντί για μεμονωμένο σχήμα. Ο καλούπας είναι υπεύθυνος για τη ροή και πρέπει να την κλείσει.

## **Στοίχιση Σχημάτων**

Η μέθοδος [SlideUtil.alignShapes](https://reference.aspose.com/slides/el/java/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) προσφέρει υπερφόρτωση που ευθυγραμμίζει είτε όλα τα σχήματα είτε επιλεγμένους δείκτες συλλογής. Το [ShapesAlignmentType](https://reference.aspose.com/slides/el/java/com.aspose.slides/shapesalignmenttype/) καθορίζει την άκρη, τη γραμμή κέντρου ή τη λειτουργία κατανομής. Ορίστε `alignToSlide` σε `true` για χρήση των άκρων της διαφάνειας· ορίστε το σε `false` για στοίχιση των επιλεγμένων σχημάτων μεταξύ τους.

Αυτό το παράδειγμα στοιχίζει τρία σχήματα στην επάνω άκρη της διαφάνειας. Οι επιστρεφόμενες αναφορές σε σχήματα μετατρέπονται αμέσως στους τρέχοντες δείκτες τους πριν τη στοίχιση.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape firstShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 60, 80, 120, 50);
    IAutoShape secondShape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 240, 160, 120, 50);
    IAutoShape thirdShape = slide.getShapes().addAutoShape(ShapeType.Triangle, 420, 240, 120, 50);
    firstShape.setName("FirstAlignedShape");
    secondShape.setName("SecondAlignedShape");
    thirdShape.setName("ThirdAlignedShape");

    int[] shapeIndexes = {slide.getShapes().indexOf(firstShape), slide.getShapes().indexOf(secondShape), slide.getShapes().indexOf(thirdShape)};

    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
    presentation.save("aligned-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η στοίχιση αλλάζει θέσεις, όχι το z‑order. Η σχετική στοίχιση απαιτεί συνήθως τουλάχιστον δύο σχήματα, ενώ η οριζόντια ή κατακόρυφη κατανομή χρειάζεται αρκετά σχήματα για να ορίσει το διάστημα. Επαναϋπολογίστε τους δείκτες αν τροποποιήσετε τη συλλογή πριν καλέσετε τη μέθοδο.

## **Αναστροφή Σχήματος**

Η κλάση [ShapeFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/shapeframe/) αποθηκεύει θέση, μέγεθος, οριζόντια και κατακόρυφη ρύθμιση αναστροφής και περιστροφή. Οι τιμές `getFlipH` και `getFlipV` χρησιμοποιούν το [NullableBool](https://reference.aspose.com/slides/el/java/com.aspose.slides/nullablebool/): `True` ενεργοποιεί την αναστροφή, `False` την απενεργοποιεί, και `NotDefined` διατηρεί την απροσδιόριστη/προεπιλεγμένη κατάσταση.

Η εισαγόμενη παρουσίαση παρακάτω περιέχει ένα σχήμα που δεν έχει αναστραφεί.

![Το σχήμα πριν την αναστροφή](shape_to_be_flipped.png)

Το παράδειγμα διατηρεί όλες τις άλλες τιμές του πλαισίου και αντικαθιστά μόνο τις δύο ρυθμίσεις αναστροφής. Αυτό είναι σημαντικό επειδή η ανάθεση ενός νέου [Frame](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) αντικαθιστά ολόκληρο το πλαίσιο.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IShapeFrame frame = shape.getFrame();

    System.out.println("Horizontal flip before change: " + frame.getFlipH());
    System.out.println("Vertical flip before change: " + frame.getFlipV());

    shape.setFrame(new ShapeFrame(frame.getX(), frame.getY(), frame.getWidth(), frame.getHeight(), NullableBool.True, NullableBool.True, frame.getRotation()));

    presentation.save("flipped-shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποθηκευμένο σχήμα είναι κατοπτρισμένο οριζόντια και κατακόρυφα ενώ διατηρεί τη θέση, το μέγεθος και τη περιστροφή του.

![Το σχήμα μετά την αναστροφή](flipped_shape.png)

## **Συχνές Ερωτήσεις**

**Θα πρέπει να χρησιμοποιώ έναν δείκτη συλλογής ως αναγνωριστικό σχήματος;**

Μόνο για βραχύβια επεξεργασία όταν η συλλογή δεν θα αλλάξει πριν χρησιμοποιηθεί ο δείκτης. Προτιμήστε μια επικυρωμένη σύμβαση `Name` ή `AlternativeText` για δημιουργημένα πρότυπα, ή `OfficeInteropShapeId` για ενέργειες interop σε επίπεδο διαφάνειας.

**Αφαιρεί η απόκρυψη ένα σχήμα το z‑order;**

Όχι. Ένα κρυφό σχήμα παραμένει στη συλλογή στο ίδιο δείκτη. Μπορεί να βρεθεί, να αναδιατεθεί, να επεξεργαστεί ή να γίνει ξανά ορατό.

**Γιατί ένα κλωνοποιημένο σχήμα εμφανίστηκε μπροστά από άλλο σχήμα;**

Το `addClone` προσθέτει το κλώνο στο τέλος της συλλογής, που είναι το μπροστινό μέρος του z‑order. Χρησιμοποιήστε `insertClone` για να επιλέξετε αρχικό δείκτη ή `reorder` μετά την προσθήκη όλων των σχημάτων.

**Μπορώ να χρησιμοποιήσω σταθερό δείκτη για την ταυτοποίηση προρυθμισμένης προσαρμογής σχήματος;**

Μόνο μετά από επικύρωση του ακριβούς προρυθμισμένου σχήματος και της διάταξης της συλλογής. Προτιμήστε την επανάληψη μέσω `IGeometryShape.getAdjustments` και τον έλεγχο του `IAdjustValue.getType`; χρησιμοποιήστε το `IAdjustValue.getName` ως πρόσθετη πληροφορία όταν ο ίδιος σημασιολογικός τύπος εμφανίζεται περισσότερο από μία φορά.