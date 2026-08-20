---
title: Διαχείριση Σχημάτων Παρουσίασης σε PHP
linktitle: Διαχείριση Σχήματος
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
- Απόκρυψη σχήματος
- Αλλαγή σειράς σχήματος
- Λήψη ID σχήματος interop
- Εναλλακτικό κείμενο σχήματος
- Μορφές διάταξης σχήματος
- Σχήμα ως SVG
- Μετατροπή σχήματος σε SVG
- Στοίχιση σχήματος
- Αναστροφή σχήματος
- PowerPoint
- Παρουσίαση
- PHP
- Aspose.Slides
description: "Μάθετε πώς να ταυτοποιείτε, κλωνοποιείτε, αφαιρείτε, κρύβετε, αλλάζετε τη σειρά, εξάγετε, στοιχίζετε και αναστρέφετε σχήματα παρουσίασης με το Aspose.Slides για PHP μέσω Java."
---
## **Επισκόπηση**

Aspose.Slides for PHP via Java αντιπροσωπεύει τα σχήματα σε μια διαφάνεια ως μια διατεταγμένη [ShapeCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/). Η συλλογή είναι τόσο το μέρος όπου βρίσκετε και τροποποιείτε τα σχήματα όσο και η πηγή της σειράς στοιβάγματός τους: το index `0` είναι το πιο πίσω σχήμα, ενώ το τελευταίο index είναι το πιο μπροστά σχήμα.

Αυτό το άρθρο ακολουθεί αυτό το μοντέλο. Πρώτα εξηγεί πώς να ταυτοποιήσετε ένα σχήμα αξιόπιστα, στη συνέχεια δείχνει πώς να κλωνοποιήσετε, να αφαιρέσετε, να κρύψετε και να αλλάξετε τη σειρά των σχημάτων. Τα τελικά τμήματα καλύπτουν μορφοποίηση επιπέδου διάταξης, εξαγωγή SVG, στοίχιση και ρυθμίσεις αναστροφής. Κάθε παράδειγμα είναι ανεξάρτητο, ώστε να μπορείτε να χρησιμοποιήσετε μόνο τις λειτουργίες που απαιτεί η ροή εργασίας σας.

## **Αναγνώριση και Εύρεση Σχημάτων**

Οι δείκτες συλλογής είναι βολικοί κατά την επεξεργασία ενός γνωστού αρχείου, αλλά δεν είναι σταθεροί ταυτοποιητές. Η προσθήκη, η αφαίρεση ή η αλλαγή σειράς ενός σχήματος μπορεί να αλλάξει τον δείκτη του. Επιλέξτε έναν ταυτοποιητή ανάλογα με το πώς δημιουργείται και συντηρείται η παρουσίαση:

- [Name](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/getname/) είναι χρήσιμο για πρότυπα που ελέγχονται από προγραμματιστές και είναι εύκολο να το εντοπίσετε στον Πίνακα Επιλογής του PowerPoint. Τα ονόματα μπορούν να επεξεργαστούν και δεν εγγυώνται μοναδικότητα, επομένως καθορίστε μια συμβατική ονοματοδοσία αν ο κώδικας εξαρτάται από αυτά.
- [AlternativeText](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/getalternativetext/) είναι χρήσιμο όταν μια περιγραφή προσβασιμότητας ή μια ετικέτα του δημιουργού ήδη ταυτοποιεί το σχήμα. Είναι ορατό στους χρήστες, μπορεί να μεταφραστεί ή να ξαναγραφτεί για προσβασιμότητα, και δεν εγγυάται μοναδικότητα. Μην επαναχρησιμοποιείτε σιωπηλά το περιεχόμενο προσβασιμότητας ως κλειδί βάσης δεδομένων.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/getofficeinteropshapeid/) είναι ένας μόνο-ανάγνωση ταυτοποιητής που είναι μοναδικός μέσα σε μία διαφάνεια και αντιστοιχεί στο αναγνωριστικό σχήματος που χρησιμοποιεί το PowerPoint interop. Χρησιμοποιήστε το όταν ενσωματώνετε με το PowerPoint ή όταν χρειάζεστε μια ασαφή αναφορά κατά τη διάρκεια της διάρκειας ενός σχήματος. Ένα κλωνοποιημένο ή επανδημιουργημένο σχήμα είναι διαφορετικό σχήμα και λαμβάνει το δικό του ID.

Η σχετική μέθοδος [Shape::getUniqueId](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/getuniqueid/) επιστρέφει έναν ταυτοποιητή με εμβέλεια παρουσίασης, αλλά αυτός ο ταυτοποιητής προορίζεται για πρόσθετα και μπορεί να επαναχρωματιστεί. Δεν πρέπει να αντιμετωπίζεται ως μόνιμο εξωτερικό κλειδί. Αν η μακροπρόθεσμη ταυτότητα είναι ουσιώδης, διατηρήστε τον χάρτη στα δεδομένα της εφαρμογής και επικυρώστε ότι το αναμενόμενο σχήμα εξακολουθεί να υπάρχει.

Το παρακάτω παράδειγμα αναζητά με όνομα με ακριβή σύγκριση και αναφέρει το interop ID της διαφάνειας. Όταν το πρότυπο δεν περιέχει το αναμενόμενο σχήμα, ο κώδικας αναφέρει αυτό το αποτέλεσμα αντί να συνεχίσει με το λανθασμένο αντικείμενο.

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

Όταν μια λειτουργία είναι συγκεκριμένη για έναν τύπο σχήματος, ελέγξτε την κλάση χρόνου εκτέλεσης πριν χρησιμοποιήσετε μέλη ειδικά για τον τύπο. Αυτό το παράδειγμα ενημερώνει το κείμενο και το εναλλακτικό κείμενο μόνο εάν το ονομασμένο αντικείμενο είναι ένα [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/).

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

## **Τροποποίηση της Συλλογής Σχημάτων**

Οι μέθοδοι προσθήκης, κλωνοποίησης, αφαίρεσης και αλλαγής σειράς λειτουργούν αμέσως στη συλλογή. Εάν μια λειτουργία αλλάζει τον αριθμό ή τη σειρά των σχημάτων, μην συνεχίζετε να βασίζεστε σε δείκτες που είχαν ληφθεί πριν από αυτή τη λειτουργία.

### **Κλωνοποίηση Σχήματος**

[ShapeCollection::addClone](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/addclone/) δημιουργεί ένα ανεξάρτητο αντίγραφο και το προσθέτει στο στόχο της συλλογής. [ShapeCollection::insertClone](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/insertclone/) επίσης δημιουργεί ένα αντίγραφο αλλά το τοποθετεί σε έναν καθορισμένο δείκτη z‑order. Οι υπερφορτώσεις που δέχονται συντεταγμένες μετακινούν το κλώνο χωρίς αλλαγή μεγέθους· οι υπερφορτώσεις με πλάτος και ύψος μπορούν επίσης να το επαναπροσδιορίσουν.

Το παράδειγμα δημιουργεί μια διαφάνεια προορισμού, κλωνοποιεί ένα ορθογώνιο με ετικέτα προς τα εμπρός, και εισάγει ένα δεύτερο κλώνο στο πίσω μέρος. Οι αλλαγές σε κάθε κλώνο δεν τροποποιούν το σχήμα προέλευσης.

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

Η κλωνοποίηση αντιγράφει το περιεχόμενο και τη μορφοποίηση του σχήματος, συμπεριλαμβανομένου του ονόματος και του εναλλακτικού κειμένου. Αντιστοιχίστε νέους λογικούς ταυτοποιητές στο κλώνο όταν αυτές οι τιμές πρέπει να είναι μοναδικές. Οι πόροι που χρησιμοποιούνται από πολύπλοκα σχήματα διαχειρίζονται από την παρουσίαση, αλλά ένα κλώνο παραμένει ένα νέο στοιχείο της συλλογής με νέα ταυτότητα σχήματος.

### **Αφαίρεση Σχημάτων**

[ShapeCollection::remove](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/remove/) διαγράφει ένα συγκεκριμένο αντικείμενο σχήματος από τη συλλογή του. Όταν αφαιρείτε πολλαπλές αντιστοιχίες κατά τη διάρκεια επαναληπτικής διαμέτρησης με δείκτες, διασχίστε από το τέλος ώστε κάθε εναπομείναν δείκτης να παραμένει έγκυρος.

Αυτό το παράδειγμα αφαιρεί κάθε σχήμα με ένα καθορισμένο όνομα. Διαβάζει το σχήμα στον τρέχοντα δείκτη, όχι ένα σταθερό στοιχείο της συλλογής, και δεν κάνει περιττή μετατροπή τύπου.

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

Μετά την αφαίρεση, ο αριθμός των σχημάτων και οι δείκτες των μεταγενέστερων σχημάτων αλλάζουν. Οι αναφορές σε ανεπηρέαστα σχήματα παραμένουν πιο αξιόπιστες από αποθηκευμένους δείκτες. Επίσης, σκεφτείτε τους συνδέσμους, τις κινήσεις και άλλα χαρακτηριστικά παρουσίασης που ενδέχεται να αναφέρονται στο αφαιρεθέν αντικείμενο· η αφαίρεση ενός ορατού σχήματος μπορεί να αλλάξει περισσότερο από την εμφάνιση της διαφάνειας.

### **Απόκρυψη Σχήματος**

Ο ορισμός του [Shape::setHidden](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/sethidden/) σε `true` διατηρεί το σχήμα στη συλλογή αλλά εμποδίζει την εμφάνισή του στην κανονική παρουσίαση. Ο δείκτης, η μορφοποίηση και το περιεχόμενο παραμένουν διαθέσιμα στον κώδικα, έτσι η απόκρυψη είναι κατάλληλη για προαιρετικά στοιχεία που μπορούν να αποκατασταθούν αργότερα.

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

Η απόκρυψη δεν είναι διαγραφή ή ασφάλεια. Το αντικείμενο μπορεί ακόμη να εντοπιστεί και να γίνει ορατό ξανά από χρήστη ή κώδικα, και παραμένει μέρος του αρχείου παρουσίασης.

### **Αλλαγή της Σειράς Z**

Τα επικάλυψη σχήματα ζωγραφίζονται με τη σειρά της συλλογής. [ShapeCollection::reorder](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/reorder/) μετακινεί ένα υπάρχον σχήμα σε έναν στόχο δείκτη χωρίς κλωνοποίηση. Ο δείκτης `0` είναι το πίσω μέρος· `size() - 1` είναι το μπροστινό.

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

Το ορθογώνιο δημιουργείται πρώτα και αρχικά βρίσκεται πίσω από το έλλειψη. Η μετακίνηση του στον τελικό δείκτη το φέρνει μπροστά. Ολοκληρώστε την σειρά Z μετά την προσθήκη ή κλωνοποίηση όλων των σχετικών σχημάτων, επειδή αυτές οι λειτουργίες προσθέτουν ή εισάγουν νέα στοιχεία στη συλλογή και μπορούν να αλλάξουν τη στοίβα που προοριζόταν.

## **Έλεγχος Σχημάτων σε Διαφάνειες Διάταξης**

Οι κανονικές διαφάνειες, οι διαφάνειες διάταξης και οι κύριες διαφάνειες έχουν ξεχωριστές συλλογές σχημάτων. Ένα σχήμα σε μια συλλογή διάταξης δεν είναι το ίδιο αντικείμενο με ένα παρόμοιο σχήμα σε κανονική διαφάνεια. Ελέγξτε τα σχήματα διάταξης όταν χρειάζεται να κατανοήσετε ή να αλλάξετε τη μορφοποίηση που παρέχεται από μια διάταξη.

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

Η επεξεργασία μιας διάταξης μπορεί να επηρεάσει πολλαπλές διαφάνειες που τη χρησιμοποιούν. Πριν αλλάξετε ένα σχήμα διάταξης, καθορίστε αν μια κανονική διαφάνεια κληρονομεί το αντικείμενο ή περιέχει τοπική παράκαμψη, και δοκιμάστε κάθε διαφάνεια που χρησιμοποιεί τη διάταξη.

## **Εξαγωγή Σχήματος σε SVG**

[Shape::writeAsSvg](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/writeassvg/) γράφει το αποδιδόμενο περιεχόμενο ενός σχήματος σε μια ροή. Το αποτέλεσμα περιέχει το σ_shape, όχι ολόκληρο το φόντο της διαφάνειας ή γειτονικά σχήματα.

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

Διατηρήστε την παρουσίαση ανοιχτή κατά τη διάρκεια της απόδοσης. Η έξοδος εξαρτάται από τη μορφοποίηση του σχήματος και από πόρους όπως γραμματοσειρές και εικόνες. Εάν χρειάζεστε ολόκληρη τη σύνθεση, εξαγάγετε τη διαφάνεια αντί για το μεμονωμένο σχήμα. Ο καλών χρήστης κατέχει τη ροή και πρέπει να την κλείσει.

## **Στοίχιση Σχημάτων**

Οι υπερφορτώσεις του [SlideUtil::alignShapes](https://reference.aspose.com/slides/el/php-java/aspose.slides/slideutil/alignshapes/) ευθυγραμμίζουν είτε όλα τα σχήματα είτε επιλεγμένους δείκτες συλλογής. Το [ShapesAlignmentType](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapesalignmenttype/) καθορίζει την άκρη, τη κεντρική γραμμή ή το τρόπο κατανομής. Ορίστε `alignToSlide` σε `true` για χρήση των άκρων της διαφάνειας· ορίστε το σε `false` για στοίχιση των επιλεγμένων σχημάτων μεταξύ τους.

Αυτό το παράδειγμα στοιχίζει τρία σχήματα στο επάνω άκρο της διαφάνειας. Οι αναφορές σχήματος που επιστρέφονται μετατρέπονται αμέσως στους τρέχοντες δείκτες τους πριν τη στοίχιση.

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

Η στοίχιση αλλάζει θέσεις, όχι τη σειρά Z. Η σχετική στοίχιση συνήθως απαιτεί τουλάχιστον δύο σχήματα, ενώ η οριζόντια ή κάθετη κατανομή χρειάζεται αρκετά σχήματα για ορισμό αποστάσεων. Επαναϋπολογίστε τους δείκτες εάν τροποποιήσετε τη συλλογή πριν καλέσετε τη μέθοδο.

## **Αναστροφή Σχήματος**

Η κλάση [ShapeFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapeframe/) αποθηκεύει τη θέση, το μέγεθος, τις ρυθμίσεις οριζόντιας και κάθετης αναστροφής και την περιστροφή. Οι τιμές `getFlipH` και `getFlipV` χρησιμοποιούν το [NullableBool](https://reference.aspose.com/slides/el/php-java/aspose.slides/nullablebool/): `True` ενεργοποιεί την αναστροφή, `False` την απενεργοποιεί, και `NotDefined` διατηρεί την ακαθόριστη/προεπιλεγμένη κατάσταση.

Η παρακάτω παρουσίαση περιέχει ένα σχήμα χωρίς αναστροφή.

![Το σχήμα πριν την αναστροφή](shape_to_be_flipped.png)

Το παράδειγμα διατηρεί κάθε άλλη τιμή του Frame και αντικαθιστά μόνο τις δύο ρυθμίσεις αναστροφής. Αυτό είναι σημαντικό επειδή η ανάθεση ενός νέου [Frame](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/setframe/) αντικαθιστά ολόκληρο το Frame.

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

Το αποθηκευμένο σχήμα είναι κατοπτρισμένο οριζόντια και κάθετα διατηρώντας τη θέση, το μέγεθος και την περιστροφή.

![Το σχήμα μετά την αναστροφή](flipped_shape.png)

## **Συχνές Ερωτήσεις**

**Θα πρέπει να χρησιμοποιώ έναν δείκτη συλλογής ως αναγνωριστικό σχήματος;**

Μόνο για βραχύβια επεξεργασία όταν η συλλογή δεν θα αλλάξει πριν χρησιμοποιηθεί ο δείκτης. Προτιμήστε μια επικυρωμένη σύμβαση `Name` ή `AlternativeText` για πρότυπα που δημιουργούνται, ή `OfficeInteropShapeId` για εργασίες interop περιορισμένες στη διαφάνεια.

**Αφαιρεί η απόκρυψη ενός σχήματος τη θέση του στη σειρά Z;**

Όχι. Ένα κρυμμένο σχήμα παραμένει στη συλλογή στον ίδιο δείκτη. Μπορεί να βρεθεί, να αλλάξει σειρά, να επεξεργαστεί ή να γίνει ορατό ξανά.

**Γιατί ένα κλωνοποιημένο σχήμα εμφανίστηκε μπροστά από ένα άλλο σχήμα;**

Η μέθοδος `addClone` προσθέτει το κλώνο στο τέλος της συλλογής, που είναι η εμπρός θέση της σειράς Z. Χρησιμοποιήστε `insertClone` για να επιλέξετε τον αρχικό δείκτη ή `reorder` μετά την προσθήκη όλων των σχημάτων.