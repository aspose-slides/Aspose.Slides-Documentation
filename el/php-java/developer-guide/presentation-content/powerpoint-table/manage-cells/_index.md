---
title: Διαχείριση κελιών πίνακα σε παρουσιάσεις με PHP
linktitle: Διαχείριση κελιών
type: docs
weight: 30
url: /el/php-java/manage-cells/
keywords:
- κέλι πίνακα
- συγχώνευση κελιών
- αφαίρεση περιγράμματος
- διαίρεση κελιού
- εικόνα στο κελί
- χρώμα φόντου
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Διαχειριστείτε τα κελιά πίνακα του PowerPoint σε PHP: εντοπίστε συγχωνευμένα κελιά, αφαιρέστε περιγράμματα, διαιρέστε κελιά και ορίστε χρώματα φόντου και εικόνες με το Aspose.Slides για PHP μέσω Java."
---
## **Επισκόπηση**

Το Aspose.Slides σας επιτρέπει να έχετε πρόσβαση και να τροποποιήσετε τα κελιά πίνακα σε παρουσιάσεις PowerPoint. Αυτό το άρθρο εξηγεί πώς να εντοπίζετε συγχωνευμένα κελιά πίνακα, να αφαιρέετε τα περιγράμματα των κελιών, να εργάζεστε με την αρίθμηση κελιών μετά τη συγχώνευση ή τον χωρισμό κελιών, να αλλάζετε το χρώμα φόντου ενός κελιού και να προσθέτετε μια εικόνα μέσα σε ένα κελί πίνακα. Τα παραδείγματα δείχνουν πώς να δημιουργήσετε ή να ανοίξετε μια παρουσίαση, να πάρετε έναν πίνακα από μια διαφάνεια, να ενημερώσετε τη μορφοποίηση του κελιού μέσω των ιδιοτήτων του κελιού και να αποθηκεύσετε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Το Aspose.Slides χρησιμοποιεί δείκτες που ξεκινούν από το μηδέν για την πρόσβαση στα κελιά πίνακα με τη σειρά `(column, row)`.

## **Αναγνώριση Συγχωνευμένου Κελιού Πίνακα**

Το παράδειγμα ανοίγει μια υπάρχουσα παρουσίαση και αποκτά πρόσβαση στο πρώτο σχήμα στην πρώτη διαφάνεια ως πίνακα. Υποθέτει ότι η διαφάνεια και το σχήμα υπάρχουν και ότι το σχήμα είναι πίνακας. Στη συνέχεια, επαναλαμβάνει όλες τις σειρές και στήλες και χρησιμοποιεί [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) για να εντοπίσει κελιά σε συγχωνευμένες περιοχές. Για κάθε αντιστοιχία, εκτυπώνει τις συντεταγμένες του κελιού με τη σειρά `row;column`, [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/), [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/), και τις αρχικές συντεταγμένες της περιοχής, [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) και [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/).

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation_with_table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);

    $rowCount = java_values($table->getRows()->size());
    for ($rowIndex = 0; $rowIndex < $rowCount; $rowIndex++)
    {
        $columnCount = java_values($table->getColumns()->size());
        for ($columnIndex = 0; $columnIndex < $columnCount; $columnIndex++)
        {
            $cell = $table->get_Item($columnIndex, $rowIndex);
            if (java_values($cell->isMergedCell()))
            {
                printf("Cell %d;%d belongs to a merged region with RowSpan=%d and ColSpan=%d starting at %d;%d.\n", $rowIndex, $columnIndex, java_values($cell->getRowSpan()), java_values($cell->getColSpan()), java_values($cell->getFirstRowIndex()), java_values($cell->getFirstColumnIndex()));
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Αφαίρεση Περιγραμμάτων Κελιού Πίνακα**

Δημιουργήστε ένα [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) και προσθέστε έναν πίνακα στην πρώτη του διαφάνεια με το [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/). Τα πλάτη των στηλών, τα ύψη των σειρών και η θέση του πίνακα ορίζονται σε σημεία. Το παράδειγμα ορίζει όλα τα τέσσερα περιγράμματα των κελιών σε [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/), καθιστώντας τα αόρατα.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 50, 50, 50, 50 ];
    $rowHeights = [ 50, 30, 30, 30, 30 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
        for ($columnIndex = 0; $columnIndex < java_values($table->getColumns()->size()); $columnIndex++) {
            $cell = $table->get_Item($columnIndex, $rowIndex);
            $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::NoFill);
            $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::NoFill);
            $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::NoFill);
            $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::NoFill);
        }
    }

    $presentation->save("table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Συγχώνευση Κελιών Πίνακα**

Χρησιμοποιήστε το [mergeCells](https://reference.aspose.com/slides/php-java/aspose.slides/table/mergecells/) για να συνδυάσετε ένα ορθογώνιο εύρος κελιών πίνακα σε ένα κελί. Καθορίστε τα κελιά στην επάνω αριστερή και κάτω δεξιά γωνία του εύρους. Το τελευταίο όρισμα ελέγχει αν η συγχώνευση μπορεί να περιλαμβάνει κελιά εκτός του καθορισμένου εύρους· `false` διατηρεί τη συγχώνευση εντός του εύρους.

Το παράδειγμα δημιουργεί έναν πίνακα 4x4 με στήλες και σειρές 70 σημείων, στη συνέχεια συγχωνεύει τα τέσσερα κεντρικά κελιά από `(1, 1)` έως `(2, 2)`. Το προκύπτον κελί καλύπτει δύο στήλες και δύο σειρές, ενώ το υποκείμενο πλέγμα του πίνακα παραμένει με τέσσερις στήλες και τέσσερις σειρές. Για να προσπελάσετε το περιεχόμενο ή τη μορφοποίηση του συγχωνευμένου κελιού, χρησιμοποιήστε τη θέση του στην επάνω αριστερή γωνία: `$table->get_Item(1, 1)` σε αυτό το παράδειγμα. Οι άλλες θέσεις στο συγχωνευμένο εύρος παραμένουν μέρος του πλέγματος του πίνακα, επομένως οι δείκτες των κελιών εκτός του εύρους δεν αλλάζουν.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 70, 70, 70, 70 ];
    $rowHeights = [ 70, 70, 70, 70 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->mergeCells($table->get_Item(1, 1), $table->get_Item(2, 2), false);

    $presentation->save("merged_cells.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Διαίρεση Κελιών Πίνακα**

Η συγχώνευση κελιών στο προηγούμενο παράδειγμα διατηρεί το πλέγμα του πίνακα. Η διαίρεση ενός κελιού μπορεί να εισαγάγει μια νέα στήλη στο πλέγμα και να αλλάξει τους δείκτες στήλης των κελιών στα δεξιά του. Το Aspose.Slides ακολουθεί το μοντέλο πλέγματος πίνακα του PowerPoint.

Αυτό το παράδειγμα δημιουργεί έναν πίνακα 4x4 με στήλες και σειρές 70 σημείων και καλεί το [splitByWidth](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbywidth/) στο κελί `(1, 1)`. Η μισή από το πλάτος 70 σημείων του κελιού περνιέται για τη δημιουργία δύο κελιών ίσου πλάτους.

Μετά από αυτή τη διαίρεση, τα δύο μισά προσεγγίζονται ως `$table->get_Item(1, 1)` και `$table->get_Item(2, 1)`. Το πλέγμα του πίνακα τώρα έχει πέντε στήλες: τα κελιά που βρίσκονταν αρχικά στις στήλες 2 και 3 μετακινούνται στις στήλες 3 και 4, αντίστοιχα. Οι δείκτες των σειρών παραμένουν αμετάβλητοι. Χρησιμοποιήστε αυτούς τους ενημερωμένους δείκτες στήλης όταν προσπελάζετε κελιά μετά τη διαίρεση.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 70, 70, 70, 70 ];
    $rowHeights = [ 70, 70, 70, 70 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->get_Item(1, 1)->splitByWidth(java_values($table->get_Item(1, 1)->getWidth()) / 2);

    $presentation->save("split_cells.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Διαίρεση Συγχωνευμένων Κελιών ανά Σειρά ή Στήλη**

Για να προετοιμάσετε τα συγχωνευμένα κελιά πρότυπο για την καταχώρηση δεδομένων, χρησιμοποιήστε το [splitByRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyrowspan/) για διαίρεση κατά μήκος ενός υπάρχοντος ορίου σειράς, ή το [splitByColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbycolspan/) για διαίρεση κατά μήκος ενός ορίου στήλης.

Το όρισμα `index` μετράει σειρές στο άνω μέρος ή στήλες στο αριστερό μέρος της διαίρεσης· είναι σχετικό με τη συγχωνευμένη περιοχή:

- Διάσπαση σειράς: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/).
- Διάσπαση στήλης: `0 < index <` [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/).

Το παράδειγμα αναμένει ότι μια παρουσίαση θα έχει έναν πίνακα ως το πρώτο σχήμα στην πρώτη διαφάνεια, με τα `(1, 2)` και `(1, 3)` συγχωνευμένα κάθετα. Ξεκινώντας από την κάτω θέση, χρησιμοποιεί τα [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) και [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) για να εντοπίσει την αρχή και ελέγχει και τις δύο εκτάσεις. `splitByRowSpan(1)` στη συνέχεια χωρίζει τις σειρές 2 και 3 για τα ονόματα προϊόντων. Για μια οριζόντια συγχώνευση δύο στηλών, χρησιμοποιήστε το `splitByColSpan(1)` αντί αυτού.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("table_template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);

    $selectedCell = $table->get_Item(1, 3);
    $firstColumnIndex = java_values($selectedCell->getFirstColumnIndex());
    $firstRowIndex = java_values($selectedCell->getFirstRowIndex());
    $mergedCell = $table->get_Item($firstColumnIndex, $firstRowIndex);

    if (java_values($mergedCell->isMergedCell()) && java_values($mergedCell->getRowSpan()) == 2 && java_values($mergedCell->getColSpan()) == 1)
    {
        $mergedCell->splitByRowSpan(1);

        // Ανακτήστε τα προκύπτοντα κελιά από τον πίνακα μετά τη διαίρεση.
        $upperCell = $table->get_Item($firstColumnIndex, $firstRowIndex);
        $lowerCell = $table->get_Item($firstColumnIndex, $firstRowIndex + 1);
        echo "Upper cell merged: " . (java_values($upperCell->isMergedCell()) ? "true" : "false") . PHP_EOL;
        echo "Lower cell merged: " . (java_values($lowerCell->isMergedCell()) ? "true" : "false") . PHP_EOL;

        $upperCell->getTextFrame()->setText("Product A");
        $lowerCell->getTextFrame()->setText("Product B");

        $presentation->save("split_template.pptx", SaveFormat::Pptx);
    }
    else
    {
        echo "Select a merged region spanning exactly two rows and one column." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Το πλέγμα του πίνακα και οι γειτονικοί δείκτες κελιών παραμένουν αμετάβλητοι. Ανακτήστε τα προκύπτοντα κελιά με τις συντεταγμένες τους· εδώ, και τα δύο έχουν εκτάσεις 1 και το [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) εμφανίζει `false`. Μεγαλύτερες περιοχές μπορούν να παραμείνουν εν μέρει συγχωνευμένες μετά από μια διαίρεση.

Το αρχικό κείμενο και η μορφοποίησή του παραμένουν στο άνω (ή αριστερό) κελί· το νέο κελί είναι κενό αλλά κληρονομεί τη μορφοποίηση του κελιού όπως γέμισμα, περιγράμματα και περιθώρια. Συμπληρώστε τα κελιά μετά τη διαίρεση και ορίστε ρητά οποιαδήποτε απαιτούμενη μορφοποίηση κειμένου.

Η αποθηκευμένη παρουσίαση περιέχει ξεχωριστά κελιά "Product A" και "Product B" με τη μορφοποίηση του κελιού του προτύπου διατηρημένη. Δείτε την [Cell API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) για λεπτομέρειες.

## **Αλλαγή Χρώματος Φόντου Κελιού Πίνακα**

Αυτό το παράδειγμα δημιουργεί έναν πίνακα με στήλες 150 σημείων και σειρές 50 σημείων. Χρησιμοποιεί το [setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) για να επιλέξει γεμισμό στερεό και ορίζει το χρώμα που επιστρέφει το [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/getsolidfillcolor/) σε κόκκινο για το κελί `(2, 3)`, στην τρίτη στήλη και τέταρτη σειρά.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 150, 150, 150, 150 ];
    $rowHeights = [ 50, 50, 50, 50, 50 ];
    $table = $slide->getShapes()->addTable(50, 50, $columnWidths, $rowHeights);

    $cell = $table->get_Item(2, 3);
    $cell->getCellFormat()->getFillFormat()->setFillType(FillType::Solid);
    $cell->getCellFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $presentation->save("cell_background_color.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Προσθήκη Εικόνας Μέσα σε Κελί Πίνακα**

Τοποθετήστε την είσοδο εικόνας στον κατάλογο εργασίας πριν εκτελέσετε αυτό το παράδειγμα. Φορτώνει την εικόνα με το [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) και την προσθέτει στη συλλογή εικόνων της παρουσίασης με το [addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/addimage/). Στη συνέχεια, αντιστοιχίζει την εικόνα στο γέμισμα εικόνας του κελιού `(0, 0)`, του πρώτου κελιού στον πίνακα.

Το [PictureFillMode::Stretch](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) τεντώνει την εικόνα ώστε να γεμίσει το κελί, κάτι που μπορεί να αλλάξει την αναλογία διαστάσεών της. Τα πλάτη των στηλών και τα ύψη των σειρών είναι σε σημεία. Η φορτωμένη εικόνα απορρίπτεται σε ένα μπλοκ `finally` μετά την προσθήκη της στην παρουσίαση.

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 150, 150, 150, 150 ];
    $rowHeights = [ 100, 100, 100, 100, 90 ];
    $table = $slide->getShapes()->addTable(50, 50, $columnWidths, $rowHeights);

    $image = Images::fromFile("aspose_logo.jpg");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $table->get_Item(0, 0)->getCellFormat()->getFillFormat()->setFillType(FillType::Picture);
    $table->get_Item(0, 0)->getCellFormat()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $table->get_Item(0, 0)->getCellFormat()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    $presentation->save("table_cell_with_image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Συχνές Ερωτήσεις**

**Μπορώ να ορίσω διαφορετικά πάχη γραμμής και στιλ για τις διάφορες πλευρές ενός μόνο κελιού;**

Ναι. Τα περιγράμματα [top](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderright/) έχουν ξεχωριστές ιδιότητες, ώστε το πάχος και το στυλ κάθε πλευράς να μπορεί να διαφέρει.

**Τι συμβαίνει με την εικόνα αν αλλάξω το μέγεθος της στήλης/γραμμής μετά τον ορισμό μιας εικόνας ως φόντο του κελιού;**

Η συμπεριφορά εξαρτάται από τη [fill mode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) (stretch/tile). Με τέντωμα, η εικόνα προσαρμόζεται στο νέο κελί· με επικάλυψη, τα πλακίδια επανυπολογίζονται.

**Μπορώ να αναθέσω έναν υπερσύνδεσμο σε όλο το περιεχόμενο ενός κελιού;**

[Hyperlinks](/slides/el/php-java/manage-hyperlinks/) ορίζονται σε επίπεδο κειμένου (τμήματος) μέσα στο πλαίσιο κειμένου του κελιού ή σε επίπεδο ολόκληρου του πίνακα/σχήματος. Στην πράξη, αντιστοιχίζετε τον σύνδεσμο σε ένα τμήμα ή σε όλο το κείμενο στο κελί.

**Μπορώ να ορίσω διαφορετικές γραμματοσειρές μέσα σε ένα μόνο κελί;**

Ναι. Το πλαίσιο κειμένου ενός κελιού υποστηρίζει [portions](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) (runs) με ανεξάρτητη μορφοποίηση—οικογένεια γραμματοσειράς, στυλ, μέγεθος και χρώμα.