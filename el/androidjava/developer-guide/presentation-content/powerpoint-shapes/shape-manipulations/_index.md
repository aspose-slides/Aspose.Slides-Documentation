---
title: Διαχείριση Σχημάτων Παρουσίασης στο Android
linktitle: Διαχείριση Σχημάτων
type: docs
weight: 40
url: /el/androidjava/shape-manipulations/
keywords:
- Σχήμα PowerPoint
- σχήμα παρουσίασης
- σχήμα στη διαφάνεια
- εύρεση σχήματος
- κλωνοποίηση σχήματος
- αφαίρεση σχήματος
- απόκρυψη σχήματος
- αλλαγή σειράς σχήματος
- λήψη ID σχήματος interop
- εναλλακτικό κείμενο σχήματος
- σημείο προσαρμογής σχήματος
- προκαθορισμένη προσαρμογή σχήματος
- γεωμετρία σχήματος
- μορφές διάταξης σχήματος
- σχήμα ως SVG
- σχήμα σε SVG
- στοίχιση σχήματος
- αναστροφή σχήματος
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Μάθετε πώς να εντοπίζετε, προσαρμόζετε, κλωνοποιείτε, αφαιρείτε, κρύβετε, επαναδιατάσσετε, εξάγετε, στοιχίζετε και αναστρέφετε σχήματα παρουσίασης με το Aspose.Slides για Android μέσω Java."
---
## **Επισκόπηση**

Aspose.Slides for Android μέσω Java αναπαριστά τα σχήματα σε μια διαφάνεια ως μια διατεταγμένη [IShapeCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishapecollection/). Η συλλογή είναι τόσο το σημείο όπου βρίσκετε και τροποποιείτε σχήματα όσο και η πηγή της σειράς στρώσης: το ευρετήριο `0` είναι το πιο πίσω σχήμα, ενώ το τελευταίο ευρετήριο είναι το πιο μπροστά σχήμα.

Αυτό το άρθρο ακολουθεί αυτό το μοντέλο. Πρώτα εξηγεί πώς να εντοπίσετε ένα σχήμα αξιόπιστα και να τροποποιήσετε προκαθορισμένα σημεία προσαρμογής σχήματος, στη συνέχεια δείχνει πώς να κλωνοποιήσετε, αφαιρέσετε, κρύψετε και επαναδιατάξετε σχήματα. Οι τελευταίες ενότητες καλύπτουν μορφοποίηση σε επίπεδο διάταξης, εξαγωγή SVG, στοίχιση και ρυθμίσεις αναστροφής. Κάθε παράδειγμα είναι ανεξάρτητο, ώστε να μπορείτε να χρησιμοποιήσετε μόνο τις λειτουργίες που απαιτούνται από τη ροή εργασίας σας.

## **Εντοπισμός και Ανεύρεση Σχημάτων**

Τα ευρετήρια της συλλογής είναι βολικά κατά την επεξεργασία γνωστού αρχείου, αλλά δεν είναι σταθεροί ταυτοποιητές. Η προσθήκη, η διαγραφή ή η επαναδιάταξη ενός σχήματος μπορεί να αλλάξει το ευρετήριό του. Επιλέξτε έναν ταυτοποιητή σύμφωνα με το πώς δημιουργείται και συντηρείται η παρουσίαση:

- [Name](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/#getName--) είναι χρήσιμο για πρότυπα ελεγχόμενα από προγραμματιστές και είναι εύκολο να το ελέγξετε στον Πίνακα Επιλογής του PowerPoint. Τα ονόματα μπορούν να επεξεργαστούν και δεν είναι εγγυημένα μοναδικά, επομένως καθιερώστε μια συμβατική ονομασία εάν ο κώδικας εξαρτάται από αυτά.
- [AlternativeText](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/#getAlternativeText--) είναι χρήσιμο όταν μια περιγραφική εναλλακτική πρόσβαση ή μια ετικέτα που έχει προσθέσει ο δημιουργός ήδη ταυτοποιεί το σχήμα. Είναι ορατό στους χρήστες, μπορεί να μεταφραστεί ή να επαναγραφεί για προσβασιμότητα, και δεν εγγυάται μοναδικότητα. Μην επαναχρησιμοποιείτε σιωπηρά το σημαντικό κείμενο προσβασιμότητας ως κλειδί βάσης δεδομένων.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--) είναι ένας μόνο-ανάγνωση ταυτοποιητής που είναι μοναδικός εντός μιας διαφάνειας και αντιστοιχεί στο ID σχήματος που χρησιμοποιείται από το PowerPoint interop. Χρησιμοποιήστε το όταν ενσωματώνετε με το PowerPoint ή όταν χρειάζεστε μια σαφή αναφορά κατά τη διάρκεια ζωής ενός σχήματος. Ένα κλωνοποιημένο ή ξαναδημιουργημένο σχήμα είναι διαφορετικό σχήμα και λαμβάνει το δικό του ID.

Η σχετική μέθοδος [getUniqueId](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/#getUniqueId--) επιστρέφει έναν ταυτοποιητή με εμβέλεια παρουσίασης, αλλά αυτός ο ταυτοποιητής προορίζεται για πρόσθετα και μπορεί να επαναχρωματιστεί. Δεν πρέπει να θεωρείται μόνιμο εξωτερικό κλειδί. Εάν η μακροπρόθεσμη ταυτότητα είναι ουσιώδης, διατηρήστε την αντιστοίχηση σε δεδομένα εφαρμογής και επικυρώστε ότι το αναμενόμενο σχήμα εξακολουθεί να υπάρχει.

Για ένα πρακτικό παράδειγμα ανάγνωσης και ενημέρωσης τόσο του τίτλου εναλλακτικού κειμένου όσο και της περιγραφής, δείτε [Manage Alternative Text Titles and Descriptions](/slides/el/androidjava/presentation-accessibility/). Χρησιμοποιήστε το εναλλακτικό κείμενο για να εξηγήσετε το νόημα του οπτικού περιεχομένου στους αναγνώστες, και κρατήστε το ξεχωριστά από τα ονόματα σχημάτων που χρησιμοποιεί ο κώδικας για την εύρεση σχημάτων.

Το παρακάτω παράδειγμα αναζητεί με βάση το όνομα με ακριβή σύγκριση και αναφέρει το interop ID της διαφάνειας. Όταν το πρότυπο δεν περιέχει το αναμενόμενο σχήμα, ο κώδικας αναφέρει εκείνο το αποτέλεσμα αντί να συνεχίσει με το λανθασμένο αντικείμενο.

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

Όταν μια λειτουργία είναι συγκεκριμένη για έναν τύπο σχήματος, ελέγξτε τη διεπαφή πριν χρησιμοποιήσετε μέλη τύπου-συγκεκριμένα. Το παράδειγμα αυτό ενημερώνει το κείμενο και το εναλλακτικό κείμενο μόνο εάν το ονομασμένο αντικείμενο είναι ένα [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/).

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

## **Εντοπισμός και Τροποποίηση Προκαθορισμένων Προσαρμογών Σχήματος**

Τα σχήματα προεπιλεγμένης γεωμετρίας μπορούν να εκθέσουν σημεία προσαρμογής που ελέγχουν χαρακτηριστικά όπως το μέγεθος γωνίας, οι αναλογίες βέλους ή οι γωνίες τόξου. Πρόσβαση σε αυτά μέσω της μόνο-ανάγνωσης συλλογής [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/igeometryshape/#getAdjustments--) . Η συλλογή αυτή παρέχεται από το σχήμα, αλλά κάθε [IAdjustValue](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iadjustvalue/) περιέχει μια τιμή που μπορεί να αλλάξει.

Μην βασίζεστε μόνο σε ένα σταθερό ευρετήριο συλλογής. Επαναλάβετε μέσω των προσαρμογών και ελέγξτε τη μόνο-ανάγνωσης μέθοδο [getType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iadjustvalue/#getType--) , του οποίου η τιμή [ShapeAdjustmentType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/shapeadjustmenttype/) περιγράφει τι ελέγχει η προσαρμογή. Η μόνο-ανάγνωσης μέθοδος [getName](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iadjustvalue/#getName--) παρέχει πρόσθετες πληροφορίες ταυτοποίησης και είναι ιδιαίτερα χρήσιμη όταν ένα προκαθορισμένο περιέχει περισσότερες από μία προσαρμογές με τον ίδιο σημασιολογικό τύπο.

Χρησιμοποιήστε τη μέθοδο τιμής που ταιριάζει με το νόημα της προσαρμογής:

| Τύπος προσαρμογής | Σκοπός | Τιμή για αλλαγή |
|---|---|---|
| `CornerSize` | Μέγεθος στρογγυλεμένων γωνιών | [setRawValue](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iadjustvalue/#setRawValue-long-) |
| `ArrowTailThickness` | Πάχος ουράς βέλους | `setRawValue` |
| `ArrowheadLength` | Μήκος άκρου βέλους | `setRawValue` |
| `ArrowheadWidth` | Πλάτος άκρου βέλους | `setRawValue` |
| `StartAngle` | Αρχική γωνία πίτας ή τόξου | [setAngleValue](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iadjustvalue/#setAngleValue-float-) |
| `EndAngle` | Τελική γωνία πίτας ή τόξου | `setAngleValue` |

Οι μέθοδοι `getType` και `getName` επιστρέφουν πληροφορίες μόνο-ανάγνωσης. Τα `getRawValue` και `setRawValue` λειτουργούν με ακέραιο στη φυσική μονάδα γεωμετρίας του προκαθορισμένου σχήματος, ενώ τα `getAngleValue` και `setAngleValue` λειτουργούν με γωνία σε μοίρες. Ο αριθμός, η σειρά, το νόημα και το έγκυρο εύρος των προσαρμογών εξαρτώνται από τον προκαθορισμένο [ShapeType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/igeometryshape/#getShapeType--). Μια τιμή που είναι έγκυρη για ένα προκαθορισμένο μπορεί να είναι μη έγκυρη ή να έχει διαφορετικό αποτέλεσμα για άλλο.

Όταν το `getType` επιστρέφει `ShapeAdjustmentType.Custom`, το API δεν αναγνωρίζει τυπικό σημασιολογικό νόημα. Ελέγξτε το `getName`, τον τύπο του προκαθορισμένου και την υπάρχουσα τιμή, και αφήστε την προσαρμογή αμετάβλητη εκτός εάν το αναμενόμενο νόημα και το εύρος είναι γνωστά. Ακόμη και για αναγνωρισμένους τύπους, ελέγξτε αν ο ίδιος τύπος εμφανίζεται περισσότερες από μία φορές πριν επιλέξετε τιμή. Το άρθρο [Connector](/slides/el/androidjava/connector/) δείχνει αυτή την κατάσταση με προσαρμογές κάμπυλης συνδέσμου.

Το παρακάτω πλήρες παράδειγμα δημιουργεί προεπιλεγμένες και τροποποιημένες εκδόσεις τριών προκαθορισμένων σχημάτων. Επαναλαμβάνει σε κάθε προσαρμογή, αναφέρει το όνομα και τον τύπο της, αλλάζει τιμές σχετικές με το μέγεθος μέσω `setRawValue`, αλλάζει γωνίες μέσω `setAngleValue`, και αποθηκεύει το αποτέλεσμα. Η αριστερή στήλη διατηρεί τη προεπιλεγμένη γεωμετρία· η δεξιά στήλη δείχνει το προσαρμοσμένο στρογγυλεμένο ορθογώνιο, το τετραπλό βέλος και την πίτα.

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

Ο έλεγχος του σημασιολογικού τύπου πριν την αλλαγή μιας τιμής κάνει τον κώδικα σαφή ως προς την πρόθεσή του και αποφεύγει την υπόθεση ότι ένα συγκεκριμένο ευρετήριο συλλογής έχει το ίδιο νόημα σε διαφορετικά προκαθορισμένα σχήματα.

## **Τροποποίηση της Συλλογής Σχημάτων**

Οι μέθοδοι προσθήκης, κλωνοποίησης, αφαίρεσης και επαναδιάταξης λειτουργούν αμέσως στη συλλογή. Εάν μια λειτουργία αλλάζει τον αριθμό ή τη σειρά των σχημάτων, μην συνεχίσετε να στηρίζεστε σε ευρετήρια που εμφανίστηκαν πριν από αυτή τη λειτουργία.

### **Κλωνοποίηση Σχήματος**

[addClone](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) δημιουργεί ένα ανεξάρτητο αντίγραφο και το προσθέτει στο στόχο συλλογής. [insertClone](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) επίσης δημιουργεί ένα αντίγραφο αλλά το τοποθετεί σε συγκεκριμένο ευρετήριο z‑order. Τα overloads που δέχονται συντεταγμένες μετακινούν το κλώνο χωρίς αλλαγή μεγέθους· τα overloads με πλάτος και ύψος μπορούν επίσης να το αλλάξουν.

Το παράδειγμα δημιουργεί μια διαφάνεια προορισμού, κλωνοποιεί ένα επισημασμένο ορθογώνιο στο μπροστά και εισάγει ένα δεύτερο κλώνο στο πίσω μέρος. Οι αλλαγές σε κάθε κλώνο δεν τροποποιούν το αρχικό σχήμα.

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

Η κλωνοποίηση αντιγράφει το περιεχόμενο και τη μορφοποίηση του σχήματος, συμπεριλαμβανομένου του ονόματος και του εναλλακτικού κειμένου. Εκχωρήστε νέα λογικά αναγνωριστικά στο κλώνο όταν αυτές οι τιμές πρέπει να είναι μοναδικές. Οι πόροι που χρησιμοποιούν πολύπλοκα σχήματα διαχειρίζονται από την παρουσίαση, αλλά ένα κλώνο παραμένει νέο στοιχείο της συλλογής με νέα ταυτότητα σχήματος.

### **Αφαίρεση Σχημάτων**

[remove](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) διαγράφει ένα συγκεκριμένο αντικείμενο σχήματος από τη συλλογή του. Όταν αφαιρείτε πολλαπλές αντιστοιχίες κατά τη διάρκεια επαναληπτικού δείκτη, διασχίστε από το τέλος ώστε κάθε υπόλοιπο ευρετήριο να παραμένει έγκυρο.

Αυτό το παράδειγμα αφαιρεί κάθε σχήμα με καθορισμένο όνομα. Διαβάζει το σχήμα στο τρέχον ευρετήριο, όχι ένα σταθερό στοιχείο της συλλογής, και δεν κάνει άσκοπη μετατροπή τύπου.

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

Μετά την αφαίρεση, ο αριθμός σχημάτων και τα ευρετήρια των υπόλοιπων σχημάτων αλλάζουν. Οι αναφορές σε αμετάβλητα σχήματα παραμένουν πιο αξιόπιστες από αποθηκευμένα ευρετήρια. Επίσης σκεφτείτε συνδέσμους, animation και άλλα χαρακτηριστικά παρουσίασης που μπορεί να αναφέρονται στο αφαιρεθέν αντικείμενο· η αφαίρεση ενός ορατού σχήματος μπορεί να αλλάξει περισσότερα από την εμφάνιση της διαφάνειας.

### **Απόκρυψη Σχήματος**

Ορίζοντας το [Hidden](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/#setHidden-boolean-) σε `true` διατηρεί το σχήμα στη συλλογή αλλά εμποδίζει την εμφάνισή του στην κανονική παρουσίαση. Το ευρετήριο, η μορφοποίηση και το περιεχόμενο παραμένουν διαθέσιμα στον κώδικα, έτσι η απόκρυψη είναι κατάλληλη για προαιρετικά στοιχεία που μπορεί να επαναφερθούν αργότερα.

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

Η απόκρυψη δεν είναι διαγραφή ή ασφάλεια. Το αντικείμενο μπορεί ακόμη να εντοπιστεί και να αποκρυφτεί ξανά από χρήστη ή κώδικα, και παραμένει μέρος του αρχείου παρουσίασης.

### **Αλλαγή του Z‑Order**

Τα επικαλυπτόμενα σχήματα ζωγραφίζονται με τη σειρά της συλλογής. Η μέθοδος [reorder](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) μετακινεί ένα υπάρχον σχήμα σε ένα στόχο ευρετήριο χωρίς κλωνοποίηση. Το ευρετήριο `0` είναι το πίσω, `size() - 1` είναι το μπροστά.

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
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το ορθογώνιο δημιουργείται πρώτα και αρχικά βρίσκεται πίσω από την έλλειψη. Η μετακίνηση του στο τελικό ευρετήριο το τοποθετεί μπροστά. Ολοκληρώστε το z‑order μετά την προσθήκη ή κλωνοποίηση όλων των σχετικών σχημάτων, επειδή αυτές οι λειτουργίες προσθέτουν ή εισάγουν νέα στοιχεία στην συλλογή και μπορούν να αλλάξουν τη στοίβα.

## **Έλεγχος Σχημάτων σε Διαφάνειες Διάταξης**

Οι κανονικές διαφάνειες, οι διαφάνειες διάταξης και οι κύριες διαφάνειες έχουν ξεχωριστές συλλογές σχημάτων. Ένα σχήμα σε συλλογή διάταξης δεν είναι το ίδιο αντικείμενο με ένα παρόμοιο σχήμα σε κανονική διαφάνεια. Ελέγξτε τα σχήματα διάταξης όταν χρειάζεται να κατανοήσετε ή να αλλάξετε τη μορφοποίηση που παρέχεται από μια διάταξη.

Το παρακάτω παράδειγμα διαβάζει το [FillFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/#getFillFormat--) και το [LineFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/#getLineFormat--) κάθε σχήματος διάταξης χωρίς να υποθέτει ότι κάθε σχήμα είναι `AutoShape`.

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

Η επεξεργασία μιας διάταξης μπορεί να επηρεάσει πολλές διαφάνειες που τη χρησιμοποιούν. Πριν αλλάξετε ένα σχήμα διάταξης, προσδιορίστε εάν μια κανονική διαφάνεια κληρονομεί το αντικείμενο ή περιέχει τοπική αντικατάσταση, και δοκιμάστε κάθε διαφάνεια που χρησιμοποιεί αυτή τη διάταξη.

## **Εξαγωγή Σχήματος σε SVG**

[writeAsSvg](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) γράφει το αποδιδόμενο περιεχόμενο ενός σχήματος σε ροή. Το αποτέλεσμα περιλαμβάνει το σχήμα, όχι το πλήρες φόντο της διαφάνειας ή τα γειτονικά σχήματα.

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

Διατηρήστε την παρουσίαση ανοιχτή κατά το rendering. Η έξοδος εξαρτάται από τη μορφοποίηση του σχήματος και από πόρους όπως γραμματοσειρές και εικόνες. Εάν χρειάζεστε ολόκληρη τη σύνθεση, εξάγετε τη διαφάνεια αντί για ένα μεμονωμένο σχήμα. Ο καλών είναι υπεύθυνος για τη ροή και πρέπει να την κλείσει.

## **Στοίχιση Σχημάτων**

Η μέθοδος [SlideUtil.alignShapes](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) διαθέτει υπερφορτώσεις για στοίχιση είτε όλων των σχημάτων είτε επιλεγμένων ευρετηρίων συλλογής. Το [ShapesAlignmentType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/shapesalignmenttype/) καθορίζει την άκρη, τη γραμμή κέντρου ή τη λειτουργία κατανομής. Ορίστε `alignToSlide` σε `true` για χρήση των άκρων της διαφάνειας· ορίστε το σε `false` για στοίχιση των επιλεγμένων σχημάτων μεταξύ τους.

Αυτό το παράδειγμα στοιχίζει τρία σχήματα στην άνω άκρη της διαφάνειας. Οι αναφορές σχήματος που επιστρέφονται μετατρέπονται αμέσως στα τρέχοντα ευρετήρια τους πριν από τη στοίχιση.

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

Η στοίχιση αλλάζει θέσεις, όχι το z‑order. Η σχετική στοίχιση συνήθως απαιτεί τουλάχιστον δύο σχήματα, ενώ η οριζόντια ή κάθετη κατανομή απαιτεί αρκετά σχήματα για ορισμό αποστάσεων. Υπολογίστε εκ νέου τα ευρετήρια εάν τροποποιήσετε τη συλλογή πριν καλέσετε τη μέθοδο.

## **Αναστροφή Σχήματος**

Η κλάση [ShapeFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/shapeframe/) αποθηκεύει θέση, μέγεθος, οριζόντια και κάθετη ρύθμιση ανάστροφας και περιστροφή. Οι τιμές `getFlipH` και `getFlipV` χρησιμοποιούν [NullableBool](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/nullablebool/) : `True` ενεργοποιεί την ανάστροφη, `False` την απενεργοποιεί, και `NotDefined` διατηρεί την ακαθόριστη/προεπιλεγμένη κατάσταση.

Η παρακάτω παρουσίαση εισόδου περιέχει ένα σχήμα χωρίς ανάστροφο.

![The shape before flipping](shape_to_be_flipped.png)

Το παράδειγμα διατηρεί κάθε άλλη τιμή πλαισίου και αντικαθιστά μόνο τις δύο ρυθμίσεις ανάστροφας. Αυτό είναι σημαντικό επειδή η ανάθεση ενός νέου [Frame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) αντικαθιστά ολόκληρο το πλαίσιο.

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

Το αποθηκευμένο σχήμα είναι καθρεφτισμένο οριζόντια και κάθετα, διατηρώντας τη θέση, το μέγεθος και την περιστροφή του.

![The shape after flipping](flipped_shape.png)

## **Συχνές Ερωτήσεις**

**Πρέπει να χρησιμοποιήσω ένα ευρετήριο συλλογής ως ταυτοποιητή σχήματος;**

Μόνο για βραχυπρόθεσμη επεξεργασία όταν η συλλογή δεν θα αλλάξει πριν χρησιμοποιηθεί το ευρετήριο. Προτιμήστε έναν επικυρωμένο συμβιβασμό `Name` ή `AlternativeText` για πρότυπα που δημιουργούνται, ή `OfficeInteropShapeId` για διαπραγμάτευση interop εντός διαφάνειας.

**Αφαιρεί η απόκρυψη ενός σχήματος το ζ‑order;**

Όχι. Ένα κρυφό σχήμα παραμένει στη συλλογή στο ίδιο ευρετήριο. Μπορεί να βρεθεί, να επαναδιαταχθεί, να επεξεργαστεί ή να γίνει ξανά ορατό.

**Γιατί ένα κλωνοποιημένο σχήμα εμφανίστηκε μπροστά από άλλο σχήμα;**

`addClone` προσθέτει το κλώνο στο τέλος της συλλογής, που αποτελεί το μπροστινό τμήμα του ζ‑order. Χρησιμοποιήστε `insertClone` για επιλογή αρχικού ευρετηρίου ή `reorder` μετά την προσθήκη όλων των σχημάτων.

**Μπορώ να χρησιμοποιήσω ένα σταθερό ευρετήριο για την ταυτοποίηση μιας προεπιλεγμένης προσαρμογής σχήματος;**

Μόνο αφού επικυρώσετε το ακριβές προεπιλεγμένο σχήμα και τη διάταξη της συλλογής. Προτιμήστε την επανάληψη μέσω του `IGeometryShape.getAdjustments` και τον έλεγχο του `IAdjustValue.getType`; χρησιμοποιήστε το `IAdjustValue.getName` ως πρόσθετη πληροφορία όταν ο ίδιος σημασιολογικός τύπος εμφανίζεται περισσότερες από μία φορές.