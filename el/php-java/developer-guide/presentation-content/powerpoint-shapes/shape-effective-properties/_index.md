---
title: Απόκτηση Αποτελεσματικών Ιδιοτήτων Σχήματος από Παρουσιάσεις σε PHP
linktitle: Αποτελεσματικές Ιδιότητες
type: docs
weight: 50
url: /el/php-java/shape-effective-properties/
keywords:
- ιδιότητες σχήματος
- ιδιότητες κάμερας
- rig φωτισμού
- σχήμα λοξότμησης
- πλαίσιο κειμένου
- στυλ κειμένου
- ύψος γραμματοσειράς
- μορφή γεμίσματος
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Μάθετε πώς να χρησιμοποιείτε το Aspose.Slides για PHP μέσω Java για να διακρίνετε την τοπική, κληρονομημένη και αποτελεσματική μορφοποίηση σχήματος σε παρουσιάσεις PowerPoint."
---
## **Κατανοήστε τις Τοπικές, Κληρονομημένες και Αποτελεσματικές Ιδιότητες**

Η μορφοποίηση στο PowerPoint μπορεί να προέρχεται από διάφορες πηγές. Η τιμή που αποθηκεύεται άμεσα σε ένα αντικείμενο είναι η **τοπική τιμή**. Εάν αυτή η τιμή δεν είναι ορισμένη, το PowerPoint ελέγχει τις γονικές πηγές μορφοποίησης, όπως η προεπιλογή παραγράφου, ένα στυλ κειμένου, ένα σχέδιο ή η κύρια διαφάνεια, ένα θέμα ή οι προεπιλογές σε επίπεδο παρουσίασης. Αυτές οι τιμές είναι **κληρονομημένες τιμές**. Η τιμή που απομένει μετά την επίλυση ολόκληρης της ιεραρχίας είναι η **αποτελεσματική τιμή** — η τιμή που χρησιμοποιείται για την απόδοση του αντικειμένου.

Για παράδειγμα, ένα τμήμα κειμένου μπορεί να μην ορίζει το δικό του ύψος γραμματοσειράς. Η τοπική τιμή του [getFontHeight](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseportionformat/) είναι τότε `NAN`, που σημαίνει «δεν έχει οριστεί εδώ». Το τμήμα μπορεί να κληρονομήσει ένα ύψος από την παράγραφο του, το προεπιλεγμένο στυλ κειμένου της παρουσίασης ή άλλη σχετική πηγή. Καλέοντας [getEffective](https://reference.aspose.com/slides/el/php-java/aspose.slides/portionformat/geteffective/) στο format του τμήματος επιστρέφει το τελικό επιλυμένο ύψος.

Χρησιμοποιήστε τα δύο είδη δεδομένων μορφοποίησης για διαφορετικούς σκοπούς:

- Αναγνώστε ή αλλάξτε ένα τοπικό αντικείμενο μορφοποίησης, όπως το [PortionFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/portionformat/), όταν χρειάζεται να ελέγξετε πού ορίζεται μια τιμή.
- Αναγνώστε ένα αντικείμενο αποτελεσματικών δεδομένων, όπως τα [data returned by PortionFormat.getEffective](https://reference.aspose.com/slides/el/php-java/aspose.slides/portionformat/geteffective/), όταν χρειάζεστε το τελικό, αποδιδόμενο αποτέλεσμα. Τα αποτελεσματικά δεδομένα είναι μόνο για ανάγνωση.

Πριν εκτελέσετε τα παραδείγματα, [εγκαταστήστε Aspose.Slides for PHP via Java](/slides/el/php-java/installation/).

## **Συγκρίνετε Τοπικές, Κληρονομημένες και Αποτελεσματικές Τιμές**

Το παρακάτω πλήρες παράδειγμα δημιουργεί ένα σχήμα και εφαρμόζει ύψη γραμματοσειράς σε επίπεδο παρουσίασης, παραγράφου και τμήματος. Κάθε βήμα εκτυπώνει τις τιμές που ορίζονται σε αυτά τα επίπεδα και την προκύπτουσα αποτελεσματική τιμή για το ίδιο τμήμα κειμένου. Επίσης δείχνει γιατί τα αποτελεσματικά δεδομένα πρέπει να αναγνώνονται ξανά μετά από αλλαγές μορφοποίησης.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

function formatLocalValue($value)
{
    return $value === null || is_nan($value) ? "<not set>" : (string)$value;
}

function printFontHeights($caption, $presentation, $paragraph, $portion)
{
    $presentationValue = java_values($presentation->getDefaultTextStyle()->getLevel(0)->getDefaultPortionFormat()->getFontHeight());
    $paragraphValue = java_values($paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFontHeight());
    $localValue = java_values($portion->getPortionFormat()->getFontHeight());

    // Διαβάστε τα αποτελεσματικά δεδομένα μετά τις προηγούμενες αλλαγές.
    $effectiveValue = java_values($portion->getPortionFormat()->getEffective()->getFontHeight());

    echo $caption . PHP_EOL;
    echo "  Presentation default: " . formatLocalValue($presentationValue) . PHP_EOL;
    echo "  Paragraph default:    " . formatLocalValue($paragraphValue) . PHP_EOL;
    echo "  Portion local:        " . formatLocalValue($localValue) . PHP_EOL;
    echo "  Portion effective:    " . $effectiveValue . PHP_EOL;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 500, 80, false);
    $textFrame = $shape->addTextFrame("Effective formatting");
    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    // Ορίστε κληρονομημένες τιμές σε δύο διαφορετικά επίπεδα.
    $presentation->getDefaultTextStyle()->getLevel(0)->getDefaultPortionFormat()->setFontHeight(20);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(28);

    printFontHeights("The portion inherits from the paragraph", $presentation, $paragraph, $portion);

    // Μια τοπική τιμή στο τμήμα αντικαθιστά και τις δύο κληρονομημένες τιμές.
    $portion->getPortionFormat()->setFontHeight(36);
    printFontHeights("A local value overrides inherited values", $presentation, $paragraph, $portion);

    // Η αλλαγή μιας κληρονομημένης τιμής δεν αντικαθιστά μια υπάρχουσα τοπική τιμή.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(30);
    printFontHeights("The local value still has priority", $presentation, $paragraph, $portion);

    // Καθαρίστε την τοπική τιμή. Το τμήμα τώρα κληρονομεί ξανά από την παράγραφο.
    $portion->getPortionFormat()->setFontHeight(NAN);
    printFontHeights("The local value is cleared", $presentation, $paragraph, $portion);

    // Καθαρίστε την τιμή της παραγράφου. Η προεπιλογή της παρουσίασης τώρα παρέχει το αποτέλεσμα.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(NAN);
    printFontHeights("The paragraph value is cleared", $presentation, $paragraph, $portion);

    $presentation->save("effective-properties.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Η προτεραιότητα σε αυτό το παράδειγμα είναι η τοπική μορφοποίηση του τμήματος, έπειτα η μορφοποίηση της παραγράφου, και τέλος η προεπιλογή της παρουσίασης. Άλλα αντικείμενα μπορεί να έχουν διαφορετικές αλυσίδες κληρονομικότητας, αλλά η αρχή είναι η ίδια: μια πιο συγκεκριμένη ρητή τιμή κερδίζει, και το [getEffective](https://reference.aspose.com/slides/el/php-java/aspose.slides/portionformat/geteffective/) επιστρέφει το τελικό αποτέλεσμα.

## **Αποκτήστε τις Αποτελεσματικές Ιδιότητες Κειμένου**

Η μορφοποίηση κειμένου είναι διασπασμένη σε πολλαπλά αντικείμενα:

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframeformat/geteffective/) επιλύει ιδιότητες πλαισίου κειμένου όπως περιθώρια, αγκίστρωση, αυτόματη προσαρμογή και κάθετη κατεύθυνση κειμένου.
- [TextStyle.getEffective](https://reference.aspose.com/slides/el/php-java/aspose.slides/textstyle/geteffective/) επιλύει μορφοποίηση παραγράφου για κάθε επίπεδο στυλ κειμένου.
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/geteffective/) επιλύει ιδιότητες παραγράφου όπως στοίχιση, εσοχές και κουκίδες.
- [PortionFormat.getEffective](https://reference.aspose.com/slides/el/php-java/aspose.slides/portionformat/geteffective/) επιλύει ιδιότητες χαρακτήρα όπως ύψος γραμματοσειράς, είδος γραμματοσειράς, χρώμα, έντονη και πλάγια γραφή.

Για το επόμενο παράδειγμα, `text-formatting.pptx` πρέπει να περιέχει τουλάχιστον μια διαφάνεια και ένα [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) με ένα μη κενό πλαίσιο κειμένου. Το AutoShape μπορεί να εμφανιστεί σε οποιαδήποτε θέση στη συλλογή σχημάτων· ο κώδικας αναζητά ένα κατάλληλο αντικείμενο και το επαληθεύει πριν τη χρήση.

```php
use aspose\slides\Presentation;

function formatEffectiveValue($javaValue)
{
    $value = java_values($javaValue);
    if ($value === null) {
        return "<not set>";
    }
    if (is_bool($value)) {
        return $value ? "true" : "false";
    }
    return (string)$value;
}

function hasNonEmptyText($shape)
{
    $textFrame = $shape->getTextFrame();
    if (java_is_null($textFrame)) {
        return false;
    }
    if (java_values($textFrame->getParagraphs()->getCount()) === 0) {
        return false;
    }
    return java_values($textFrame->getParagraphs()->get_Item(0)->getPortions()->getCount()) > 0;
}

function findAutoShapeWithText($slide)
{
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $candidate = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($candidate, $autoShapeClass) && hasNonEmptyText($candidate)) {
            return $candidate;
        }
    }
    return null;
}

$presentation = new Presentation("text-formatting.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0) {
        throw new RuntimeException("The presentation contains no slides.");
    }

    $shape = findAutoShapeWithText($presentation->getSlides()->get_Item(0));
    if ($shape === null) {
        throw new RuntimeException("The first slide must contain an AutoShape with non-empty text.");
    }

    $textFrame = $shape->getTextFrame();
    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    $textFrameEffective = $textFrame->getTextFrameFormat()->getEffective();
    $paragraphEffective = $paragraph->getParagraphFormat()->getEffective();
    $portionEffective = $portion->getPortionFormat()->getEffective();

    echo "Text frame margins:" . PHP_EOL;
    echo "  Left: " . formatEffectiveValue($textFrameEffective->getMarginLeft()) . PHP_EOL;
    echo "  Top: " . formatEffectiveValue($textFrameEffective->getMarginTop()) . PHP_EOL;
    echo "  Right: " . formatEffectiveValue($textFrameEffective->getMarginRight()) . PHP_EOL;
    echo "  Bottom: " . formatEffectiveValue($textFrameEffective->getMarginBottom()) . PHP_EOL;
    echo "Paragraph alignment: " . formatEffectiveValue($paragraphEffective->getAlignment()) . PHP_EOL;
    echo "Font height: " . formatEffectiveValue($portionEffective->getFontHeight()) . PHP_EOL;
    echo "Bold: " . formatEffectiveValue($portionEffective->getFontBold()) . PHP_EOL;

    $effectiveTextStyle = $textFrame->getTextFrameFormat()->getTextStyle()->getEffective();
    for ($level = 0; $level < 9; $level++) {
        $levelEffective = $effectiveTextStyle->getLevel($level);
        echo "Level " . $level . " indent: " . formatEffectiveValue($levelEffective->getIndent()) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Αποκτήστε τις Αποτελεσματικές 3D Ιδιότητες**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/el/php-java/aspose.slides/threedformat/geteffective/) επιστρέφει ένα αντικείμενο αποτελεσματικών δεδομένων που ομαδοποιεί όλες τις επιλυμένες 3D ρυθμίσεις. Οι μέθοδοι [getCamera](https://reference.aspose.com/slides/el/php-java/aspose.slides/threedformat/geteffective/), [getLightRig](https://reference.aspose.com/slides/el/php-java/aspose.slides/threedformat/geteffective/), [getBevelTop](https://reference.aspose.com/slides/el/php-java/aspose.slides/threedformat/geteffective/) και [getBevelBottom](https://reference.aspose.com/slides/el/php-java/aspose.slides/threedformat/geteffective/) εκθέτουν τα αντίστοιχα αποτελεσματικά δεδομένα. Η ανάγνωση αυτών των σχετικών ρυθμίσεων μαζί διευκολύνει την κατανόηση της τελικής 3D εμφάνισης ενός σχήματος.

Για αυτό το παράδειγμα, `shape-3d.pptx` πρέπει να περιέχει τουλάχιστον ένα σχήμα στην πρώτη του διαφάνεια. Εφαρμόστε 3D κάμερα, φωτισμό ή ρυθμίσεις γωνίας σε αυτό το σχήμα εάν θέλετε το αποτέλεσμα να περιέχει τιμές διαφορετικές από τις προεπιλογές.

```php
use aspose\slides\Presentation;

function formatEffectiveValue($javaValue)
{
    $value = java_values($javaValue);
    return $value === null ? "<not set>" : (string)$value;
}

$presentation = new Presentation("shape-3d.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0 || java_values($presentation->getSlides()->get_Item(0)->getShapes()->size()) === 0) {
        throw new RuntimeException("The first slide must contain a shape.");
    }

    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $threeDEffective = $shape->getThreeDFormat()->getEffective();

    echo "Camera:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getCamera()->getCameraType()) . PHP_EOL;
    echo "  Field of view: " . formatEffectiveValue($threeDEffective->getCamera()->getFieldOfViewAngle()) . PHP_EOL;
    echo "  Zoom: " . formatEffectiveValue($threeDEffective->getCamera()->getZoom()) . PHP_EOL;

    echo "Light rig:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getLightRig()->getLightType()) . PHP_EOL;
    echo "  Direction: " . formatEffectiveValue($threeDEffective->getLightRig()->getDirection()) . PHP_EOL;

    echo "Top bevel:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getBevelTop()->getBevelType()) . PHP_EOL;
    echo "  Width: " . formatEffectiveValue($threeDEffective->getBevelTop()->getWidth()) . PHP_EOL;
    echo "  Height: " . formatEffectiveValue($threeDEffective->getBevelTop()->getHeight()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Αποκτήστε την Αποτελεσματική Μορφοποίηση Πίνακα**

Η μορφοποίηση πίνακα μπορεί να προέρχεται από το στυλ πίνακα και από μορφοποιήσεις που εφαρμόζονται σε ολόκληρο τον πίνακα, στήλη, σειρά ή μεμονωμένο κελί. Σε συγκρούσεις μεταξύ ρητά ορισμένων γεμισμάτων, η προτεραιότητα είναι κελί, σειρά, στήλη και στη συνέχεια ολόκληρος ο πίνακας. Η αποτελεσματική μορφοποίηση ενός κελιού είναι η τελική μορφοποίηση που χρησιμοποιείται για τη σχεδίαση του κελιού.

Για αυτό το παράδειγμα, `table-formatting.pptx` πρέπει να περιέχει τουλάχιστον έναν πίνακα στην πρώτη του διαφάνεια. Ο πίνακας πρέπει να έχει τουλάχιστον μία γραμμή και μία στήλη. Ο κώδικας αναζητά ένα [Table](https://reference.aspose.com/slides/el/php-java/aspose.slides/table/) αντί να υποθέτει ότι το `getShapes()->get_Item(0)` είναι πίνακας.

```php
use aspose\slides\Presentation;

function findTable($slide)
{
    $tableClass = new JavaClass("com.aspose.slides.Table");
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, $tableClass)) {
            return $shape;
        }
    }
    return null;
}

$presentation = new Presentation("table-formatting.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0) {
        throw new RuntimeException("The presentation contains no slides.");
    }

    $table = findTable($presentation->getSlides()->get_Item(0));
    if ($table === null) {
        throw new RuntimeException("The first slide must contain a table.");
    }
    if (java_values($table->getRows()->size()) === 0 || java_values($table->getColumns()->size()) === 0) {
        throw new RuntimeException("The table must contain at least one cell.");
    }

    $tableEffective = $table->getTableFormat()->getEffective();
    $rowEffective = $table->getRows()->get_Item(0)->getRowFormat()->getEffective();
    $columnEffective = $table->getColumns()->get_Item(0)->getColumnFormat()->getEffective();
    $cellEffective = $table->get_Item(0, 0)->getCellFormat()->getEffective();

    echo "Table fill: " . java_values($tableEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Row fill: " . java_values($rowEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Column fill: " . java_values($columnEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Final cell fill: " . java_values($cellEffective->getFillFormat()->getFillType()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Εάν χρειάζεστε το χρώμα αντί μόνο του τύπου γεμίσματος, ελέγξτε πρώτα την αποτελεσματική τιμή του [getFillType](https://reference.aspose.com/slides/el/php-java/aspose.slides/fillformat/geteffective/) και, στη συνέχεια, διαβάστε τη μέθοδο που εφαρμόζεται σε αυτόν τον τύπο—για παράδειγμα, το [getSolidFillColor](https://reference.aspose.com/slides/el/php-java/aspose.slides/fillformat/geteffective/) για γεμιστό στερεό χρώμα.

## **Ξαναδιαβάστε τα Αποτελεσματικά Δεδομένα Μετά τις Αλλαγές**

Τα αποτελεσματικά δεδομένα περιγράφουν την ιεραρχία μορφοποίησης τη στιγμή που επιλύεται. Καλέστε ξανά το `getEffective` αφού αλλάξετε οτιδήποτε μπορεί να συμμετέχει σε αυτήν την ιεραρχία, συμπεριλαμβανομένων:

- της τοπικής μορφοποίησης του αντικειμένου·
- των προεπιλογών παραγράφου ή πλαισίου κειμένου·
- ενός στυλ πίνακα, πίνακα, στήλης, σειράς ή μορφοποίησης κελιού·
- μορφοποίησης διάταξης ή κύριας διαφάνειας·
- δεδομένων θέματος ή προεπιλογών σε επίπεδο παρουσίασης·
- της διάταξης ή κύριας που έχει ανατεθεί σε μια διαφάνεια.

Μην διατηρείτε ένα αντικείμενο αποτελεσματικών δεδομένων ως μόνιμο στιγμιότυπο. Το Aspose.Slides μπορεί να αποθηκεύσει προσωρινά κάποια αποτελεσματικά δεδομένα εσωτερικά, και μια μετέπειτα κλήση `getEffective` μπορεί να ενημερώσει αυτά τα δεδομένα. Εάν χρειάζεται να συγκρίνετε τιμές πριν και μετά από αλλαγή, αντιγράψτε τις μοναδικές τιμές που χρειάζεστε—όπως ύψος γραμματοσειράς, χρώμα, στοίχιση ή πλάτος γωνίας—σε δικές σας μεταβλητές πριν κάνετε την αλλαγή.

Για να αλλάξετε μια τιμή, ενημερώστε το αντίστοιχο τοπικό αντικείμενο μορφοποίησης και, στη συνέχεια, καλέστε το `getEffective` για να επαληθεύσετε το αποτέλεσμα. Τα αντικείμενα αποτελεσματικών δεδομένων είναι εγγενώς μόνο για ανάγνωση.

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να καταλάβω ποιο επίπεδο παρείχε μία αποτελεσματική τιμή;**

Τα αποτελεσματικά δεδομένα περιέχουν τη τελική τιμή, όχι την πηγή της. Εξετάστε τα εφαρμόσιμα τοπικά αντικείμενα από το πιο συγκεκριμένο επίπεδο προς τα έξω. Για κείμενο, αυτό μπορεί να περιλαμβάνει το τμήμα, την παράγραφο, το πλαίσιο κειμένου, τη διάταξη, το κύριο, το θέμα και τις προεπιλογές παρουσίασης. Απροσδιόριστες τιμές όπως `NAN` ή `null` δείχνουν ότι η αναζήτηση συνεχίζει σε άλλο επίπεδο.

**Τι συμβαίνει όταν κανένα επίπεδο δεν ορίζει μια ιδιότητα;**

Το Aspose.Slides επιλύει την κατάλληλη προεπιλογή του PowerPoint ή της βιβλιοθήκης. Η επιλυμένη τιμή εμφανίζεται στα αποτελεσματικά δεδομένα παρόλο που κανένα τοπικό αντικείμενο δεν την ορίζει ρητά.

**Γιατί μερικές φορές μια αποτελεσματική τιμή ισούται με την τοπική τιμή;**

Η τοπική τιμή κέρδισε στον υπολογισμό κληρονομικότητας. Αυτό είναι αναμενόμενο όταν η ιδιότητα έχει οριστεί ρητά στο αντικείμενο και κανένας πιο συγκεκριμένος κανόνας δεν την παραβιάζει.

**Πότε πρέπει να χρησιμοποιώ τοπικά δεδομένα αντί για αποτελεσματικά δεδομένα;**

Χρησιμοποιήστε τοπικά δεδομένα για να επιθεωρήσετε ή να επεξεργαστείτε ένα συγκεκριμένο επίπεδο μορφοποίησης. Χρησιμοποιήστε αποτελεσματικά δεδομένα όταν χρειάζεστε την τελική εμφάνιση μετά την κληρονομικότητα, τους κανόνες θέματος και τα εφαρμοσμένα στυλ. Το [πλήρες παράδειγμα σύγκρισης](#compare-local-inherited-and-effective-values) δείχνει και τα δύο στην ίδια ροή εργασίας.