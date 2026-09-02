---
title: Διαχείριση Σχημάτων Παρουσίασης σε PHP
linktitle: Διαχείριση Σχημάτων
type: docs
weight: 40
url: /el/php-java/shape-manipulations/
keywords:
- Σχήμα PowerPoint
- Σχήμα παρουσίασης
- Σχήμα στη διαφάνεια
- Εύρεση σχήματος
- Κλωνοποίηση σχήματος
- Αφαίρεση σχήματος
- Κρύψιμο σχήματος
- Αλλαγή σειράς σχήματος
- Λήψη ID σχήματος interop
- Εναλλακτικό κείμενο σχήματος
- Σημείο προσαρμογής σχήματος
- Προκαθορισμένη προσαρμογή σχήματος
- Γεωμετρία σχήματος
- Μορφότυπα διάταξης σχήματος
- Σχήμα ως SVG
- Μετατροπή σχήματος σε SVG
- Στοίχιση σχήματος
- Αναστροφή σχήματος
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Μάθετε πώς να αναγνωρίζετε, προσαρμόζετε, κλωνοποιείτε, αφαιρείτε, κρύβετε, αναδιατάζετε, εξάγετε, στοιχίζετε και αναστρέφετε σχήματα παρουσίασης με το Aspose.Slides για PHP μέσω Java."
---
## **Επισκόπηση**

Το Aspose.Slides for PHP μέσω Java αναπαριστά τα σχήματα σε μια διαφάνεια ως μια διατεταγμένη [ShapeCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/). Η συλλογή είναι τόσο το μέρος όπου βρίσκετε και τροποποιείτε σχήματα όσο και η πηγή της σειράς τους: ο δείκτης `0` είναι το πιο πίσω σχήμα, ενώ ο τελευταίος δείκτης είναι το πιο μπροστά σχήμα.

Αυτό το άρθρο ακολουθεί αυτό το μοντέλο. Πρώτα εξηγεί πώς να αναγνωρίσετε ένα σχήμα αξιόπιστα και να τροποποιήσετε προκαθορισμένα σημεία προσαρμογής σχήματος, στη συνέχεια δείχνει πώς να κλωνοποιήσετε, αφαιρέσετε, κρύψετε και αναδιατάξετε σχήματα. Τα τελικά τμήματα καλύπτουν μορφοποίηση σε επίπεδο διάταξης, εξαγωγή SVG, στοίχιση και ρυθμίσεις αντιστροφής. Κάθε παράδειγμα είναι ανεξάρτητο, ώστε να μπορείτε να χρησιμοποιήσετε μόνο τις λειτουργίες που απαιτούνται στην ροή εργασίας σας.

## **Αναγνώριση και Εύρεση Σχημάτων**

- [Name](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/getname/) είναι χρήσιμο για πρότυπα ελεγχόμενα από προγραμματιστές και είναι εύκολο να το επιθεωρήσετε στο Πάνελ Επιλογής του PowerPoint. Τα ονόματα μπορούν να επεξεργαστούν και δεν εγγυώνται μοναδικότητα, οπότε καθιερώστε μια σύμβαση ονομασίας εάν ο κώδικας εξαρτάται από αυτά.
- [AlternativeText](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/getalternativetext/) είναι χρήσιμο όταν μια περιγραφή προσβασιμότητας ή μια ετικέτα που παρέχεται από τον δημιουργό ήδη αναγνωρίζει το σχήμα. Είναι ορατό στους χρήστες, μπορεί να μεταφραστεί ή να επαναγραφεί για προσβασιμότητα, και δεν εγγυώνται μοναδικότητα. Μην χρησιμοποιείτε σιωπηλά το σημαντικό κείμενο προσβασιμότητας ως κλειδί βάσης δεδομένων.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/getofficeinteropshapeid/) είναι αναγνώστης μόνο για ανάγνωση που είναι μοναδικό εντός μιας διαφάνειας και αντιστοιχεί στο αναγνωριστικό σχήματος που χρησιμοποιείται από το PowerPoint interop. Χρησιμοποιήστε το όταν ενσωματώνετε με το PowerPoint ή όταν χρειάζεστε μια ασαφής αναφορά κατά τη διάρκεια της ζωής ενός σχήματος. Ένα κλωνοποιημένο ή επαναδημιουργημένο σχήμα είναι διαφορετικό σχήμα και λαμβάνει το δικό του ID.

Η σχετική μέθοδος [Shape::getUniqueId](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/getuniqueid/) επιστρέφει έναν αναγνωριστικό εμβέλειας παρουσίας, αλλά αυτός ο αναγνωριστής προορίζεται για add‑ins και μπορεί να επανατοποθετηθεί. Δεν πρέπει να θεωρείται μόνιμο εξωτερικό κλειδί. Εάν η μακροπρόθεσμη ταυτότητα είναι απαραίτητη, διατηρήστε την αντιστοίχηση στα δεδομένα της εφαρμογής και επικυρώστε ότι το αναμενόμενο σχήμα υπάρχει ακόμη.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $targetShape = null;

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "RevenueChart") {
            $targetShape = $shape;
            break;
        }
    }

    if ($targetShape === null) {
        echo "The shape 'RevenueChart' was not found on slide 1." . PHP_EOL;
    } else {
        $shapeName = java_values($targetShape->getName());
        $interopId = java_values($targetShape->getOfficeInteropShapeId());
        echo "Found " . $shapeName . "; interop ID: " . $interopId . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Όταν μια ενέργεια είναι συγκεκριμένη για τύπο σχήματος, ελέγξτε την κλάση χρόνου εκτέλεσης πριν χρησιμοποιήσετε μέλη ειδικά για τον τύπο. Αυτό το παράδειγμα ενημερώνει το κείμενο και το εναλλακτικό κείμενο μόνο εάν το ονομασμένο αντικείμενο είναι ένα [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/).

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $candidate = null;

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "StatusLabel") {
            $candidate = $shape;
            break;
        }
    }

    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    if ($candidate !== null && java_instanceof($candidate, $autoShapeClass)) {
        $candidate->getTextFrame()->setText("Approved");
        $candidate->setAlternativeText("Approval status: approved");
        $presentation->save("identified-shape.pptx", SaveFormat::Pptx);
    } else {
        echo "'StatusLabel' is missing or is not an AutoShape." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Αναγνώριση και Τροποποίηση Προκαθορισμένων Προσαρμογών Σχήματος**

Τα σχήματα προεπιλεγμένης γεωμετρίας μπορούν να εκθέτουν σημεία προσαρμογής που ελέγχουν χαρακτηριστικά όπως το μέγεθος γωνιών, τις αναλογίες βελών ή τις γωνίες τόξων. Πρόσβαση σε αυτά γίνεται μέσω της συλλογής μόνο για ανάγνωση [GeometryShape::getAdjustments](https://reference.aspose.com/slides/el/php-java/aspose.slides/geometryshape/#getAdjustments). Η συλλογή παρέχεται από το σχήμα, αλλά κάθε [AdjustValue](https://reference.aspose.com/slides/el/php-java/aspose.slides/adjustvalue/) περιέχει μια τιμή που μπορεί να αλλάξει.

Μην βασίζεστε μόνο σε έναν σταθερό δείκτη συλλογής. Επανάληψη των προσαρμογών και επιθεώρηση της μόνο για ανάγνωση μεθόδου [AdjustValue::getType](https://reference.aspose.com/slides/el/php-java/aspose.slides/adjustvalue/#getType), της οποίας η τιμή [ShapeAdjustmentType](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapeadjustmenttype/) περιγράφει τι ελέγχει η προσαρμογή. Η μόνο για ανάγνωση μέθοδος [AdjustValue::getName](https://reference.aspose.com/slides/el/php-java/aspose.slides/adjustvalue/getname/) παρέχει επιπλέον πληροφορίες αναγνώρισης και είναι ιδιαίτερα χρήσιμη όταν ένα προκαθορισμένο περιέχει περισσότερες από μία προσαρμογές με τον ίδιο σημασιολογικό τύπο.

Χρησιμοποιήστε τη μέθοδο τιμής που ταιριάζει με το νόημα της προσαρμογής:

| Τύπος προσαρμογής | Σκοπός | Τιμή για αλλαγή |
|---|---|---|
| `CornerSize` | Μέγεθος στρογγυλεμένων γωνιών | [setRawValue](https://reference.aspose.com/slides/el/php-java/aspose.slides/adjustvalue/setrawvalue/) |
| `ArrowTailThickness` | Πάχος ουράς βέλους | `setRawValue` |
| `ArrowheadLength` | Μήκος κεφαλής βέλους | `setRawValue` |
| `ArrowheadWidth` | Πλάτος κεφαλής βέλους | `setRawValue` |
| `StartAngle` | Αρχική γωνία πίτας ή τόξου | [setAngleValue](https://reference.aspose.com/slides/el/php-java/aspose.slides/adjustvalue/setanglevalue/) |
| `EndAngle` | Τελική γωνία πίτας ή τόξου | `setAngleValue` |

`getType` και `getName` επιστρέφουν μόνο για ανάγνωση πληροφορίες. `getRawValue` και `setRawValue` λειτουργούν με ακέραιο στις εγγενείς μονάδες γεωμετρίας του προκαθορισμένου, ενώ `getAngleValue` και `setAngleValue` λειτουργούν με γωνία σε μοίρες. Ο αριθμός, η σειρά, το νόημα και το έγκυρο εύρος των προσαρμογών εξαρτώνται από το προκαθορισμένο [GeometryShape::getShapeType](https://reference.aspose.com/slides/el/php-java/aspose.slides/geometryshape/#getShapeType). Μια τιμή που είναι έγκυρη για ένα προκαθορισμένο μπορεί να είναι άκυρη ή να έχει διαφορετικό αποτέλεσμα για άλλο.

Όταν `getType` επιστρέφει `ShapeAdjustmentType::Custom`, η API δεν αναγνωρίζει τυπικό σημασιολογικό νόημα. Ελέγξτε `getName`, τον τύπο του προκαθορισμένου και την υπάρχουσα τιμή, και αφήστε την προσαρμογή ανεπηρέαστη εκτός εάν το αναμενόμενο νόημα και εύρος είναι γνωστά. Ακόμη και για αναγνωρισμένους τύπους, ελέγξτε αν ο ίδιος τύπος εμφανίζεται περισσότερες από μία φορές πριν επιλέξετε τιμή. Το άρθρο [Connector](/slides/el/php-java/connector/) δείχνει αυτή την κατάσταση με προσαρμογές κάμπυλης σύνδεσμου.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Προσθέστε επικεφαλίδες για τις στήλες του προεπιλεγμένου και του προσαρμοσμένου σχήματος.
    $defaultColumnLabel = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 20, 250, 30);
    $defaultColumnLabel->getTextFrame()->setText("Default preset geometry");
    $adjustedColumnLabel = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 390, 20, 250, 30);
    $adjustedColumnLabel->getTextFrame()->setText("Modified adjustment values");

    $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 80, 70, 160, 70);
    $modifiedRoundedRectangle = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 430, 70, 160, 70);
    $modifiedRoundedRectangle->setName("ModifiedRoundedRectangle");

    $slide->getShapes()->addAutoShape(ShapeType::QuadArrow, 80, 180, 160, 110);
    $modifiedArrow = $slide->getShapes()->addAutoShape(ShapeType::QuadArrow, 430, 180, 160, 110);
    $modifiedArrow->setName("ModifiedQuadArrow");

    $slide->getShapes()->addAutoShape(ShapeType::Pie, 95, 330, 130, 130);
    $modifiedPie = $slide->getShapes()->addAutoShape(ShapeType::Pie, 445, 330, 130, 130);
    $modifiedPie->setName("ModifiedPie");

    $shapesToAdjust = [
        $modifiedRoundedRectangle,
        $modifiedArrow,
        $modifiedPie
    ];

    foreach ($shapesToAdjust as $shape) {
        $adjustmentCount = java_values($shape->getAdjustments()->size());
        for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
            $adjustment = $shape->getAdjustments()->get_Item($adjustmentIndex);
            $shapeName = java_values($shape->getName());
            $adjustmentName = java_values($adjustment->getName());
            $adjustmentType = java_values($adjustment->getType());
            echo $shapeName . " / " . $adjustmentName . ": " . $adjustmentType . PHP_EOL;

            switch ($adjustmentType) {
                case ShapeAdjustmentType::CornerSize:
                    $adjustment->setRawValue(5000);
                    break;
                case ShapeAdjustmentType::ArrowTailThickness:
                    $adjustment->setRawValue(25000);
                    break;
                case ShapeAdjustmentType::ArrowheadLength:
                    $adjustment->setRawValue(30000);
                    break;
                case ShapeAdjustmentType::ArrowheadWidth:
                    $adjustment->setRawValue(40000);
                    break;
                case ShapeAdjustmentType::StartAngle:
                    $adjustment->setAngleValue(30);
                    break;
                case ShapeAdjustmentType::EndAngle:
                    $adjustment->setAngleValue(300);
                    break;
                case ShapeAdjustmentType::Custom:
                    echo "Custom adjustment '" . $adjustmentName . "' was not changed." . PHP_EOL;
                    break;
            }
        }
    }

    $presentation->save("preset-shape-adjustments.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Ο έλεγχος του σημασιολογικού τύπου πριν την αλλαγή μιας τιμής κάνει τον κώδικα σαφή ως προς την πρόθεσή του και αποτρέπει την υπόθεση ότι ένας συγκεκριμένος δείκτης συλλογής έχει το ίδιο νόημα σε διαφορετικά προκαθορισμένα σχήματα.

## **Τροποποίηση της Συλλογής Σχημάτων**

Οι μέθοδοι προσθήκης, κλωνοποίησης, αφαίρεσης και αναδιάταξης λειτουργούν αμέσως στη συλλογή. Εάν μια ενέργεια αλλάζει τον αριθμό ή τη σειρά των σχημάτων, μην συνεχίσετε να βασίζεστε σε δείκτες που συλλέχθηκαν πριν από αυτήν την ενέργεια.

### **Κλωνοποίηση Σχήματος**

[ShapeCollection::addClone](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/addclone/) δημιουργεί ανεξάρτητο αντίγραφο και το προσθέτει στο στόχο της συλλογής. [ShapeCollection::insertClone](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/insertclone/) επίσης δημιουργεί αντίγραφο αλλά το τοποθετεί σε συγκεκριμένο δείκτη z‑order. Οι υπερφορτώσεις που δέχονται συντεταγμένες μετακινούν το αντίγραφο χωρίς αλλαγή μεγέθους· οι υπερφορτώσεις με πλάτος και ύψος μπορούν επίσης να το αναπροσαρμόσουν.

Το παράδειγμα δημιουργεί μια διαφάνεια προορισμού, κλωνοποιεί ένα ορθογώνιο με ετικέτα στο εμπρός και εισάγει δεύτερο κλώνο στο πίσω. Αλλαγές σε οποιονδήποτε κλώνο δεν επηρεάζουν το σχήμα προέλευσης.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation();
try {
    $sourceSlide = $presentation->getSlides()->get_Item(0);
    $sourceShape = $sourceSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 180, 60);
    $sourceShape->setName("SourceLabel");
    $sourceShape->getTextFrame()->setText("Source");

    $blankLayout = $presentation->getMasters()->get_Item(0)->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $destinationSlide = $presentation->getSlides()->addEmptySlide($blankLayout);

    $frontCloneShape = $destinationSlide->getShapes()->addClone($sourceShape, 80, 80);
    $frontCloneShape->setName("FrontClone");
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    if (java_instanceof($frontCloneShape, $autoShapeClass)) {
        $frontCloneShape->getTextFrame()->setText("Front clone");
    } else {
        echo "The front clone is not an AutoShape; its text was not changed." . PHP_EOL;
    }

    $backCloneShape = $destinationSlide->getShapes()->insertClone(0, $sourceShape, 80, 180);
    $backCloneShape->setName("BackClone");
    if (java_instanceof($backCloneShape, $autoShapeClass)) {
        $backCloneShape->getTextFrame()->setText("Back clone");
    } else {
        echo "The back clone is not an AutoShape; its text was not changed." . PHP_EOL;
    }

    $presentation->save("cloned-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Η κλωνοποίηση αντιγράφει το περιεχόμενο και τη μορφοποίηση του σχήματος, συμπεριλαμβανομένου του ονόματος και του εναλλακτικού κειμένου. Αναθέστε νέα λογικά αναγνωριστικά στο κλώνο όταν αυτές οι τιμές πρέπει να είναι μοναδικές. Οι πόροι που χρησιμοποιούν πολύπλοκα σχήματα διαχειρίζονται από την παρουσίαση, αλλά ένα κλώνο παραμένει νέο στοιχείο συλλογής με νέα ταυτότητα σχήματος.

### **Αφαίρεση Σχημάτων**

[ShapeCollection::remove](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/remove/) διαγράφει ένα συγκεκριμένο αντικείμενο σχήματος από τη συλλογή του. Κατά την αφαίρεση πολλαπλών αντιστοιχιών κατά την επανάληψη με δείκτες, διασχίστε από το τέλος ώστε κάθε εναπομείναν δείκτης να παραμένει έγκυρος.

Αυτό το παράδειγμα αφαιρεί κάθε σχήμα με καθορισμένο όνομα. Διαβάζει το σχήμα στον τρέχον δείκτη, όχι ένα σταθερό στοιχείο της συλλογής, και δεν κάνει περιττές μετατροπές τύπου.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $keepShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 140, 60);
    $keepShape->setName("Keep");

    $firstTemporaryShape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 220, 40, 80, 80);
    $firstTemporaryShape->setName("Temporary");

    $secondTemporaryShape = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 340, 40, 100, 80);
    $secondTemporaryShape->setName("Temporary");

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = $shapeCount - 1; $shapeIndex >= 0; $shapeIndex--) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "Temporary") {
            $slide->getShapes()->remove($shape);
        }
    }

    $presentation->save("removed-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Μετά την αφαίρεση, ο αριθμός σχημάτων και οι δείκτες των επόμενων σχημάτων αλλάζουν. Οι αναφορές σε αμετάβλητα σχήματα παραμένουν πιο αξιόπιστες από αποθηκευμένους δείκτες. Επίσης λάβετε υπόψη συνδέσμους, κινήσεις και άλλα χαρακτηριστικά παρουσίασης που μπορεί να αναφέρονται στο αφαιρεθέν αντικείμενο· η αφαίρεση ορατού σχήματος μπορεί να αλλάξει περισσότερα από την εμφάνιση της διαφάνειας.

### **Κρύψιμο Σχήματος**

Ο ορισμός του [Shape::setHidden](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/sethidden/) σε `true` διατηρεί το σχήμα στη συλλογή αλλά εμποδίζει την εμφάνισή του στην κανονική παρουσίαση. Ο δείκτης, η μορφοποίηση και το περιεχόμενο παραμένουν διαθέσιμα στον κώδικα, επομένως το κρύψιμο είναι κατάλληλο για προαιρετικά στοιχεία που μπορούν να εξαχθούν αργότερα.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $visibleShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 160, 60);
    $visibleShape->setName("VisibleLabel");

    $optionalShape = $slide->getShapes()->addAutoShape(ShapeType::Moon, 240, 40, 100, 100);
    $optionalShape->setName("OptionalDecoration");

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "OptionalDecoration") {
            $shape->setHidden(true);
        }
    }

    $presentation->save("hidden-shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το κρύψιμο δεν είναι διαγραφή ή ασφάλεια. Το αντικείμενο μπορεί να εντοπιστεί και να εμφανιστεί ξανά από χρήστη ή κώδικα, και παραμένει μέρος του αρχείου παρουσίασης.

### **Αλλαγή του Z‑Order**

Τα επικαλυπτόμενα σχήματα σχεδιάζονται με σειρά της συλλογής. Η μέθοδος [ShapeCollection::reorder](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/reorder/) μετακινεί ένα υπάρχον σχήμα σε στόχο δείκτη χωρίς κλωνοποίηση. Ο δείκτης `0` είναι το πίσω, `size() - 1` είναι το μπροστά.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $blueRectangle = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 220, 120);
    $blueRectangle->setName("BlueRectangle");
    $blueRectangle->getFillFormat()->setFillType(FillType::Solid);
    $blueRectangle->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 255));

    $orangeEllipse = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 180, 140, 220, 120);
    $orangeEllipse->setName("OrangeEllipse");
    $orangeEllipse->getFillFormat()->setFillType(FillType::Solid);
    $orangeEllipse->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 255, 165, 0));

    $frontIndex = java_values($slide->getShapes()->size()) - 1;
    $slide->getShapes()->reorder($frontIndex, $blueRectangle);
    $presentation->save("reordered-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το ορθογώνιο δημιουργείται πρώτο και αρχικά βρίσκεται πίσω από το έλλειψο. Η μετακίνησή του στον τελικό δείκτη το φέρνει μπροστά. Ολοκληρώστε το z‑order μετά την προσθήκη ή κλωνοποίηση όλων των σχετικών σχημάτων, επειδή αυτές οι λειτουργίες προσθέτουν ή εισάγουν νέα στοιχεία στη συλλογή και μπορούν να αλλάξουν τη στοίβα.

## **Επιθεώρηση Σχημάτων σε Διαφάνειες Διάταξης**

Οι κανονικές διαφάνειες, οι διαφάνειες διάταξης και οι κύριες διαφάνειες έχουν ξεχωριστές συλλογές σχημάτων. Ένα σχήμα σε συλλογή διάταξης δεν είναι το ίδιο αντικείμενο με ένα παρόμοιο σχήμα σε κανονική διαφάνεια. Ελέγξτε τα σχήματα διάταξης όταν χρειάζεται να κατανοήσετε ή να αλλάξετε μορφοποίηση που παρέχεται από μια διάταξη.

Το παρακάτω παράδειγμα διαβάζει το [FillFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/getfillformat/) και το [LineFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/getlineformat/) κάθε σχήματος διάταξης χωρίς να υποθέτει ότι κάθε σχήμα είναι `AutoShape`.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlides = $presentation->getLayoutSlides();
    $layoutSlideCount = java_values($layoutSlides->size());
    for ($layoutIndex = 0; $layoutIndex < $layoutSlideCount; $layoutIndex++) {
        $layoutSlide = $layoutSlides->get_Item($layoutIndex);
        $layoutShapes = $layoutSlide->getShapes();
        $layoutShapeCount = java_values($layoutShapes->size());
        for ($shapeIndex = 0; $shapeIndex < $layoutShapeCount; $shapeIndex++) {
            $shape = $layoutShapes->get_Item($shapeIndex);
            $fillType = java_values($shape->getFillFormat()->getFillType());
            $lineWidth = java_values($shape->getLineFormat()->getWidth());
            $layoutName = java_values($layoutSlide->getName());
            $shapeName = java_values($shape->getName());
            echo $layoutName . " / " . $shapeName . ": fill=" . $fillType . ", line width=" . $lineWidth . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

Η επεξεργασία μιας διάταξης μπορεί να επηρεάσει πολλές διαφάνειες που τη χρησιμοποιούν. Πριν αλλάξετε σχήμα διάταξης, προσδιορίστε εάν μια κανονική διαφάνεια κληρονομεί το αντικείμενο ή περιέχει τοπική παράκαμψη, και δοκιμάστε κάθε διαφάνεια που χρησιμοποιεί αυτή τη διάταξη.

## **Εξαγωγή Σχήματος σε SVG**

Η μέθοδος [Shape::writeAsSvg](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/writeassvg/) γράφει το αποδομένο περιεχόμενο ενός σχήματος σε ροή. Το αποτέλεσμα περιέχει το σχήμα, όχι το υπόβαθρο όλης της διαφάνειας ή τα γειτονικά σχήματα.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    if ($shapeCount === 0) {
        echo "Slide 1 does not contain a shape to export." . PHP_EOL;
    } else {
        $shape = $slide->getShapes()->get_Item(0);
        $svgStream = null;
        try {
            $svgStream = new Java("java.io.FileOutputStream", "shape.svg");
            $shape->writeAsSvg($svgStream);
        } catch (JavaException $exception) {
            echo "The SVG file could not be written: " . $exception->getMessage() . PHP_EOL;
        } finally {
            if ($svgStream !== null && !java_is_null($svgStream)) {
                $svgStream->close();
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Διατηρήστε την παρουσίαση ανοιχτή κατά τη δημιουργία. Η έξοδος εξαρτάται από τη μορφοποίηση του σχήματος και από πόρους όπως γραμματοσειρές και εικόνες. Εάν χρειάζεστε ολόκληρη τη σύνθεση, εξάγετε τη διαφάνεια αντί για μεμονωμένο σχήμα. Ο καλούντ είναι υπεύθυνος για τη ροή και πρέπει να την κλείσει.

## **Στοίχιση Σχημάτων**

Οι υπερφορτώσεις [SlideUtil::alignShapes](https://reference.aspose.com/slides/el/php-java/aspose.slides/slideutil/alignshapes/) ευθυγραμμίζουν είτε όλα τα σχήματα είτε επιλεγμένους δείκτες συλλογής. Το [ShapesAlignmentType](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapesalignmenttype/) ορίζει την άκρη, τη γραμμή κέντρου ή τη λειτουργία κατανομής. Ορίστε `alignToSlide` σε `true` για χρήση των άκρων της διαφάνειας· ορίστε το σε `false` για στοίχιση των επιλεγμένων σχημάτων μεταξύ τους.

Το παράδειγμα στοιχίζει τρία σχήματα στην επάνω άκρη της διαφάνειας. Οι επιστρεφόμενες αναφορές σχήματος μετατρέπονται αμέσως στους τρέχοντες δείκτες τους πριν τη στοίχιση.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\ShapesAlignmentType;
use aspose\slides\SlideUtil;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $firstShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 60, 80, 120, 50);
    $secondShape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 240, 160, 120, 50);
    $thirdShape = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 420, 240, 120, 50);
    $firstShape->setName("FirstAlignedShape");
    $secondShape->setName("SecondAlignedShape");
    $thirdShape->setName("ThirdAlignedShape");

    $shapeIndexes = [
        java_values($slide->getShapes()->indexOf($firstShape)),
        java_values($slide->getShapes()->indexOf($secondShape)),
        java_values($slide->getShapes()->indexOf($thirdShape))
    ];

    SlideUtil::alignShapes(ShapesAlignmentType::AlignTop, true, $slide, $shapeIndexes);
    $presentation->save("aligned-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Η στοίχιση αλλάζει θέσεις, όχι το z‑order. Η σχετική στοίχιση συνήθως απαιτεί τουλάχιστον δύο σχήματα, ενώ η οριζόντια ή κάθετη κατανομή απαιτεί αρκετά σχήματα για ορισμό διαστήματος. Υπολογίστε ξανά τους δείκτες εάν τροποποιήσετε τη συλλογή πριν καλέσετε τη μέθοδο.

## **Αναστροφή Σχήματος**

Η κλάση [ShapeFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapeframe/) αποθηκεύει θέση, μέγεθος, οριζόντιες και κάθετες ρυθμίσεις αναστροφής και περιστροφή. Οι τιμές `getFlipH` και `getFlipV` χρησιμοποιούν [NullableBool](https://reference.aspose.com/slides/el/php-java/aspose.slides/nullablebool/): `True` ενεργοποιεί την αναστροφή, `False` την απενεργοποιεί, και `NotDefined` διατηρεί την ακαθόριστη/προεπιλεγμένη κατάσταση.

Η εισαγωγική παρουσίαση παρακάτω περιέχει ένα μη αναστραμμένο σχήμα.

![The shape before flipping](shape_to_be_flipped.png)

Το παράδειγμα διατηρεί κάθε άλλη τιμή πλαισίου και αντικαθιστά μόνο τις δύο ρυθμίσεις αναστροφής. Αυτό είναι σημαντικό επειδή η ανάθεση ενός νέου [Frame](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/setframe/) αντικαθιστά ολόκληρο το πλαίσιο.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeFrame;

$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $frame = $shape->getFrame();

    $horizontalFlip = java_values($frame->getFlipH());
    $verticalFlip = java_values($frame->getFlipV());
    echo "Horizontal flip before change: " . $horizontalFlip . PHP_EOL;
    echo "Vertical flip before change: " . $verticalFlip . PHP_EOL;

    $shape->setFrame(new ShapeFrame($frame->getX(), $frame->getY(), $frame->getWidth(), $frame->getHeight(), NullableBool::True, NullableBool::True, $frame->getRotation()));

    $presentation->save("flipped-shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποθηκευμένο σχήμα είναι κατοπτρισμένο οριζόντια και κάθετα, διατηρώντας τη θέση, το μέγεθος και την περιστροφή.

![The shape after flipping](flipped_shape.png)

## **Συχνές Ερωτήσεις**

**Πρέπει να χρησιμοποιήσω έναν δείκτη συλλογής ως αναγνωριστικό σχήματος;**

Μόνο για σύντομη επεξεργασία όταν η συλλογή δεν θα αλλάξει πριν χρησιμοποιηθεί ο δείκτης. Προτιμήστε μια επικυρωμένη σύμβαση `Name` ή `AlternativeText` για πρότυπα που δημιουργούνται, ή `OfficeInteropShapeId` για εργασίες interop εντός διαφάνειας.

**Το κρύψιμο σχήματος το αφαιρεί από το z‑order;**

Όχι. Ένα κρυφό σχήμα παραμένει στη συλλογή στον ίδιο δείκτη. Μπορεί να βρεθεί, να αναδιαταχθεί, να επεξεργαστεί ή να γίνει ορατό ξανά.

**Γιατί ένα κλωνοποιημένο σχήμα εμφανίστηκε μπροστά από άλλο σχήμα;**

Το `addClone` προσθέτει το κλώνο στο τέλος της συλλογής, το οποίο είναι το μπροστινό τμήμα του z‑order. Χρησιμοποιήστε `insertClone` για επιλογή αρχικού δείκτη ή `reorder` μετά την προσθήκη όλων των σχημάτων.

**Μπορώ να χρησιμοποιήσω σταθερό δείκτη για αναγνώριση προσαρμογής προκαθορισμένου σχήματος;**

Μόνο μετά την επικύρωση του ακριβούς προκαθορισμένου και της διάταξης της συλλογής. Προτιμήστε επανάληψη μέσω `GeometryShape::getAdjustments` και έλεγχο του `AdjustValue::getType`; χρησιμοποιήστε `AdjustValue::getName` ως πρόσθετη πληροφορία όταν εμφανίζεται ο ίδιος σημασιολογικός τύπος περισσότερες από μία φορές.