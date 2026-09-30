---
title: Διαχείριση Πινάκων Παρουσίασης σε PHP
linktitle: Διαχείριση Πίνακα
type: docs
weight: 10
url: /el/php-java/manage-table/
keywords:
- προσθήκη πίνακα
- δημιουργία πίνακα
- πρόσβαση σε πίνακα
- αναλογία διαστάσεων
- στοίχιση κειμένου
- μορφοποίηση κειμένου
- στυλ πίνακα
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Δημιουργία & επεξεργασία πινάκων σε διαφάνειες PowerPoint με το Aspose.Slides για PHP μέσω Java. Ανακαλύψτε απλά παραδείγματα κώδικα για να βελτιώσετε τις ροές εργασίας με πίνακες."
---
## **Εισαγωγή**

Οι πίνακες στο PowerPoint οργανώνουν πληροφορίες σε σειρές και στήλες, κάνοντας ευκολότερη την ανάγνωση και τη σύγκριση τιμών.

Η Aspose.Slides παρέχει την κλάση [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) , την κλάση [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) και άλλους τύπους ώστε να μπορείτε να δημιουργείτε, ενημερώνετε και διαχειρίζεστε πίνακες σε παρουσιάσεις.

## **Δημιουργία Πίνακα από το Μηδέν**

Δημιουργήστε έναν πίνακα καθορίζοντας τη θέση, το πλάτος των στηλών και το ύψος των σειρών. Αφού τον προσθέσετε σε μια διαφάνεια, μπορείτε να μορφοποιήσετε τα περιγράμματα των κελιών, να συγχωνεύσετε κελιά και να εισάγετε κείμενο.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Αποκτήστε μια αναφορά στη διαφάνεια με βάση το δείκτη της.
3. Ορίστε έναν πίνακα με πλάτη στηλών σε σημείο.
4. Ορίστε έναν πίνακα με ύψη σειρών σε σημείο.
5. Προσθέστε ένα αντικείμενο [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) στη διαφάνεια μέσω της μεθόδου [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/) .
6. Επεξεργαστείτε κάθε [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) για να εφαρμόσετε μορφοποίηση στα άνω, κάτω, δεξιά και αριστερά περιγράμματα.
7. Συγχωνεύστε τα δύο πρώτα κελιά της πρώτης σειράς του πίνακα.
8. Προσπελάστε το συγχωνευμένο κελί μέσω της μεθόδου [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/cell/gettextframe/) .
9. Ορίστε το κείμενο στο συγχωνευμένο κελί.
10. Αποθηκεύστε την τροποποιημένη παρουσία.

Το παρακάτω παράδειγμα δημιουργεί έναν πίνακα με τρεις στήλες και πέντε σειρές στο (100, 50) σε σημεία. Εφαρμόζει κόκκινα περιγράμματα πλάτους 5 σημείων, συγχωνεύει τα δύο πρώτα κελιά της πρώτης σειράς και αποθηκεύει το αποτέλεσμα ως `table.pptx`.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $red = java("java.awt.Color")->RED;
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 50, 50, 50 ];
    $rowHeights = [ 50, 30, 30, 30, 30 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
        $row = $table->getRows()->get_Item($rowIndex);
        for ($columnIndex = 0; $columnIndex < java_values($row->size()); $columnIndex++) {
            $cell = $row->get_Item($columnIndex);
            $cellFormat = $cell->getCellFormat();
            $cellFormat->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderTop()->setWidth(5);

            $cellFormat->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderBottom()->setWidth(5);

            $cellFormat->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderLeft()->setWidth(5);

            $cellFormat->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderRight()->setWidth(5);
        }
    }

    $table->mergeCells($table->get_Item(0, 0), $table->get_Item(1, 0), false);
    $table->get_Item(0, 0)->getTextFrame()->setText("Merged Cells");

    $presentation->save("table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Αρίθμηση σε Έναν Τυπικό Πίνακα**

Σε έναν τυπικό πίνακα, οι δείκτες των κελιών ξεκινούν από το μηδέν και χρησιμοποιούν τη σειρά (στήλη, σειρά). Το πρώτο κελί έχει δείκτη (0, 0).

Για παράδειγμα, τα κελιά ενός πίνακα 4 × 4 αριθμούνται ως εξής:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Αυτό το παράδειγμα δημιουργεί τον παραπάνω πίνακα 4 × 4, με πλάτη στηλών και ύψη σειρών 70 σημείων και κόκκινα περιγράμματα κελιών πλάτους 5 σημείων. Οι συντεταγμένες απεικονίζουν τους δείκτες των κελιών· το παράδειγμα αφήνει τα κελιά κενά και αποθηκεύει τον πίνακα ως `StandardTables_out.pptx`.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $red = java("java.awt.Color")->RED;
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 70, 70, 70, 70 ];
    $rowHeights = [ 70, 70, 70, 70 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
        $row = $table->getRows()->get_Item($rowIndex);
        for ($columnIndex = 0; $columnIndex < java_values($row->size()); $columnIndex++) {
            $cell = $row->get_Item($columnIndex);
            $cellFormat = $cell->getCellFormat();
            $cellFormat->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderTop()->setWidth(5);

            $cellFormat->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderBottom()->setWidth(5);

            $cellFormat->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderLeft()->setWidth(5);

            $cellFormat->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderRight()->setWidth(5);
        }
    }

    $presentation->save("StandardTables_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Πρόσβαση σε Υπάρχον Πίνακα**

Οι πίνακες αποθηκεύονται στη συλλογή σχημάτων μιας διαφάνειας. Περιηγηθείτε στα σχήματα για να εντοπίσετε έναν πίνακα, στη συνέχεια χρησιμοποιήστε την κλάση [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) για να διαβάσετε ή να ενημερώσετε τα κελιά του.

1. Φορτώστε την παρουσία χρησιμοποιώντας την κλάση [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Αποκτήστε μια αναφορά στη διαφάνεια που περιέχει τον πίνακα με βάση το δείκτη της.
3. Περιηγηθείτε στα αντικείμενα [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) και σταματήστε όταν βρεθεί ένας πίνακας. Εάν η διαφάνεια περιέχει αρκετούς πίνακες, χρησιμοποιήστε το [getAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getalternativetext/) για να εντοπίσετε αυτόν που χρειάζεστε.
4. Ενημερώστε το κείμενο στο κελί-στόχο.
5. Αποθηκεύστε την τροποποιημένη παρουσία.

Το παρακάτω παράδειγμα ανοίγει το `UpdateExistingTable.pptx` και βρίσκει τον πρώτο πίνακα στην πρώτη διαφάνεια. Ορίζει το κελί στη στήλη 0, σειρά 1 σε `New` και αποθηκεύει το αποτέλεσμα ως `table1_out.pptx`. Η είσοδος πρέπει να περιέχει τουλάχιστον μία διαφάνεια και ο πρώτος πίνακας σε αυτήν πρέπει να έχει τουλάχιστον μία στήλη και δύο σειρές.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("UpdateExistingTable.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = null;
    $tableClass = new JavaClass("com.aspose.slides.Table");

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, $tableClass)) {
            $table = $shape;
            break;
        }
    }

    if ($table !== null) {
        $table->get_Item(0, 1)->getTextFrame()->setText("New");
        $presentation->save("table1_out.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Για να αλλάξετε το μέγεθος μιας σειράς σε έναν υπάρχοντα πίνακα και να καταλάβετε γιατί το πραγματικό του ύψος μπορεί να υπερβαίνει το ελάχιστο που ζητήσατε, δείτε [Control Row Height](/slides/el/php-java/manage-rows-and-columns/#control-row-height).

## **Εύρεση του Κελιού που Κατέχει ένα Πλαίσιο Κειμένου**

Όταν ο γενικός κώδικας επεξεργασίας κειμένου λαμβάνει ένα [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) από έναν πίνακα, χρησιμοποιήστε τη μέθοδο [TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell) για να ανακτήσετε το ιδιοκτησιακό [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/). Για ένα πλαίσιο κειμένου κελιού πίνακα, το [TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell) επιστρέφει τον κάτοχο και το [TextFrame::getParentShape](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentShape) επιστρέφει `null`, παρόλο που ο ίδιος ο πίνακας είναι σχήμα.

Οι συντεταγμένες του κελιού είναι διαθέσιμες μέσω των μόνο για ανάγνωση μεθόδων [Cell::getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) και [Cell::getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) . Η [TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell) παρέχει επίσης πλοήγηση μόνο για ανάγνωση: επιστρέφει τον κάτοχο αλλά δεν αλλάζει την ιδιοκτησία. Πάντοτε ελέγχετε το επιστρεφόμενο κελί με `java_is_null` πριν το χρησιμοποιήσετε.

Για ένα πλήρες παράδειγμα που εντοπίζει ιδιοκτήτες κελιού-πίνακα και σχήματος, συμπεριλαμβανομένων σχημάτων που σχετίζονται με κόμβους SmartArt, δείτε [Search and Replace Text](/slides/el/php-java/search-and-replace-text/).

## **Στοίχιση Κειμένου σε Πίνακα**

Μπορείτε να ελέγξετε την κατακόρυφη αγκύρωση και την κατεύθυνση κειμένου των μεμονωμένων κελιών πίνακα. Το παράδειγμα σε αυτήν την ενότητα κεντράρει το κείμενο μέσα στο πρώτο κελί και το περιστρέφει κατά 270 μοίρες.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Αποκτήστε μια αναφορά στη διαφάνεια με βάση το δείκτη της.
3. Προσθέστε ένα αντικείμενο [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) στη διαφάνεια.
4. Προσπελάστε ένα αντικείμενο [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) από τον πίνακα.
5. Προσπελάστε την πρώτη [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) και ορίστε το κείμενο και το χρώμα της.
6. Ορίστε την κατακόρυφη αγκύρωση του κελιού και την κατεύθυνση κειμένου χρησιμοποιώντας τις μεθόδους [setTextAnchorType](https://reference.aspose.com/slides/php-java/aspose.slides/cell/settextanchortype/) και [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/cell/settextverticaltype/) .
7. Αποθηκεύστε την τροποποιημένη παρουσία.

Αυτό το παράδειγμα δημιουργεί έναν πίνακα 4 × 4 με πλάτη στηλών 120 σημείων και ύψη σειρών 100 σημείων. Μορφοποιεί το κείμενο στο κελί (0, 0), προσθέτει τιμές στα υπόλοιπα κελιά της πρώτης σειράς και αποθηκεύει το αποτέλεσμα ως `Vertical_Align_Text_out.pptx`.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAnchorType;
use aspose\slides\TextVerticalType;

$presentation = new Presentation();
try {
    $black = java("java.awt.Color")->BLACK;
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 120, 120, 120, 120 ];
    $rowHeights = [ 100, 100, 100, 100 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->get_Item(1, 0)->getTextFrame()->setText("10");
    $table->get_Item(2, 0)->getTextFrame()->setText("20");
    $table->get_Item(3, 0)->getTextFrame()->setText("30");

    $textFrame = $table->get_Item(0, 0)->getTextFrame();
    $paragraph = $textFrame->getParagraphs()->get_Item(0);

    $portion = $paragraph->getPortions()->get_Item(0);
    $portion->setText("Text here");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($black);

    $cell = $table->get_Item(0, 0);
    $cell->setTextAnchorType(TextAnchorType::Center);
    $cell->setTextVerticalType(TextVerticalType::Vertical270);

    $presentation->save("Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ορισμός Μορφοποίησης Κειμένου σε Επίπεδο Πίνακα**

Χρησιμοποιήστε τη μέθοδο [setTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/table/settextformat/) για να εφαρμόσετε μορφοποίηση κειμένου σε όλα τα κελιά ενός πίνακα. Οι υπερφορτώσεις της δέχονται μορφοποίηση τμήματος, παραγράφου και πλαισίου κειμένου, ώστε να μπορείτε να ορίσετε αυτές τις ιδιότητες χωρίς επανάληψη μέσα από μεμονωμένα κελιά.

1. Φορτώστε την παρουσία χρησιμοποιώντας την κλάση [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Αποκτήστε μια αναφορά στη διαφάνεια με βάση το δείκτη της.
3. Προσπελάστε ένα αντικείμενο [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) από τη διαφάνεια.
4. Ορίστε το μέγεθος γραμματοσειράς χρησιμοποιώντας τη μέθοδο [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) για το κείμενο.
5. Ορίστε την ευθυγράμμιση παραγράφου και το δεξιό περιθώριο με τις μεθόδους [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) και [setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) .
6. Ορίστε την κατακόρυφη κατεύθυνση κειμένου με τη μέθοδο [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) .
7. Αποθηκεύστε την τροποποιημένη παρουσία.

Το παρακάτω παράδειγμα ανοίγει το `table.pptx`, το οποίο πρέπει να περιέχει τουλάχιστον μία διαφάνεια με έναν πίνακα ως το πρώτο του σχήμα. Ορίζει το μέγεθος γραμματοσειράς σε 25 σημεία, στοίχεια τα παραγράφους δεξιά με δεξιό περιθώριο 20 σημείων και κάνει το κείμενο κατακόρυφο. Η μορφοποιημένη παρουσία αποθηκεύεται ως `result.pptx`.

```php
use aspose\slides\ParagraphFormat;
use aspose\slides\PortionFormat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAlignment;
use aspose\slides\TextFrameFormat;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);

    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $table->setTextFormat($portionFormat);

    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $table->setTextFormat($paragraphFormat);

    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $table->setTextFormat($textFrameFormat);

    $presentation->save("result.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Λήψη Ιδιοτήτων Στυλ Πίνακα**

Χρησιμοποιήστε τη μέθοδο [getStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/getstylepreset/) για να διαβάσετε το προρυθμισμένο στυλ ενός πίνακα και τη μέθοδο [setStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/setstylepreset/) για να το ορίσετε. Αυτό το παράδειγμα εφαρμόζει το [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/php-java/aspose.slides/tablestylepreset/) σε έναν πίνακα, εμφανίζει την προρυθμισμένη τιμή και ορίζει το ίδιο προρύθμιση σε δεύτερο πίνακα. Και οι δύο πίνακες αποθηκεύονται στο `table-style.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TableStylePreset;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 100, 150 ];
    $rowHeights = [ 5, 5, 5 ];
    $table = $slide->getShapes()->addTable(10, 10, $columnWidths, $rowHeights);
    $table->setStylePreset(TableStylePreset::DarkStyle1);

    $stylePreset = java_values($table->getStylePreset());
    echo "Table style preset: " . $stylePreset . PHP_EOL;

    $anotherTable = $slide->getShapes()->addTable(10, 100, $columnWidths, $rowHeights);
    $anotherTable->setStylePreset($stylePreset);

    $presentation->save("table-style.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Κλείδωμα Αναλογίας Διαστάσεων Πίνακα**

Η αναλογία διαστάσεων ενός πίνακα είναι το πηλίκο του πλάτους προς το ύψος του. Χρησιμοποιήστε τη μέθοδο [setAspectRatioLocked](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/setaspectratiolocked/) για να κλειδώσετε αυτήν την αναλογία για έναν πίνακα.

Το παρακάτω παράδειγμα ανοίγει το `pres.pptx`, το οποίο πρέπει να περιέχει τουλάχιστον μία διαφάνεια με έναν πίνακα ως το πρώτο του σχήμα. Εκτυπώνει την τρέχουσα κατάσταση κλειδώματος, ενεργοποιεί το κλείδωμα της αναλογίας διαστάσεων, εκτυπώνει την ενημερωμένη κατάσταση (`true`) και αποθηκεύει το αποτέλεσμα ως `pres-out.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    echo "Lock aspect ratio set: " . (java_values($table->getGraphicalObjectLock()->getAspectRatioLocked()) ? "true" : "false") . PHP_EOL;

    $table->getGraphicalObjectLock()->setAspectRatioLocked(true);
    echo "Lock aspect ratio set: " . (java_values($table->getGraphicalObjectLock()->getAspectRatioLocked()) ? "true" : "false") . PHP_EOL;

    $presentation->save("pres-out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Συχνές Ερωτήσεις**

**Μπορώ να ενεργοποιήσω την ανάγνωση από δεξιά προς αριστερά (RTL) για ολόκληρο τον πίνακα και το κείμενο στα κελιά του;**

Ναι. Ο πίνακας διαθέτει τη μέθοδο [setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/table/setrighttoleft/) , και οι παράγραφοι έχουν τη μέθοδο [ParagraphFormat::setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setrighttoleft/) . Η χρήση και των δύο εξασφαλίζει τη σωστή σειρά RTL και την απόδοση μέσα στα κελιά.

**Πώς μπορώ να αποτρέψω τους χρήστες από το να μετακινούν ή να αλλάζουν το μέγεθος ενός πίνακα στο τελικό αρχείο;**

Χρησιμοποιήστε τα «shape locks» ([graphicalobjectlock](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/)) για να απενεργοποιήσετε τη μετακίνηση, την αλλαγή μεγέθους, την επιλογή κ.λπ. Αυτά τα κλειδώματα ισχύουν και για πίνακες.

**Υποστηρίζεται η εισαγωγή εικόνας μέσα σε κελί ως φόντο;**

Ναι. Μπορείτε να ορίσετε μια [picture fill](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) για ένα κελί· η εικόνα θα καλύψει την περιοχή του κελιού σύμφωνα με την επιλεγμένη λειτουργία (τεντωμένη ή επαναλαμβανόμενη).