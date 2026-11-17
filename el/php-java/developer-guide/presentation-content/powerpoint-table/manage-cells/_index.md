---
title: Διαχείριση Κελιών Πίνακα σε Παρουσιάσεις Χρησιμοποιώντας PHP
linktitle: Διαχείριση Κελιών
type: docs
weight: 30
url: /el/php-java/manage-cells/
keywords:
- κελί πίνακα
- συγχώνευση κελιών
- αφαίρεση περιγράμματος
- διαίρεση κελιού
- εικόνα σε κελί
- χρώμα φόντου
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Διαχείριση κελιών πίνακα PowerPoint σε PHP: εντοπισμός συγχωνευμένων κελιών, αφαίρεση περιγραμμάτων, διαίρεση κελιών και ορισμός χρωμάτων φόντου και εικόνων με Aspose.Slides για PHP μέσω Java."
---
## **Επισκόπηση**

Το Aspose.Slides σας επιτρέπει να προσπελάσετε και να τροποποιήσετε τα κελιά πινάκων σε παρουσιάσεις PowerPoint. Αυτό το άρθρο εξηγεί πώς να εντοπίζετε συγχωνευμένα κελιά πινάκων, να αφαιρείτε τα περιγράμματα κελιών, να εργάζεστε με την αρίθμηση κελιών μετά τη συγχώνευση ή το διαχωρισμό, να αλλάζετε το χρώμα φόντου ενός κελιού και να προσθέτετε μια εικόνα μέσα σε κελί πινάκα. Τα παραδείγματα δείχνουν πώς να δημιουργήσετε ή να ανοίξετε μια παρουσίαση, να λάβετε έναν πίνακα από μια διαφάνεια, να ενημερώσετε τη μορφοποίηση του κελιού μέσω των ιδιοτήτων του κελιού και να αποθηκεύσετε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Το Aspose.Slides χρησιμοποιεί δείκτες μηδενικής βάσης για την πρόσβαση στα κελιά πινάκων με τη σειρά `(στηλη, σειρά)`.

## **Εντοπισμός Συγχωνευμένου Κελιού Πίνακα**

Το παράδειγμα ανοίγει μια υπάρχουσα παρουσίαση και προσπελαύνει το πρώτο σχήμα στην πρώτη διαφάνεια ως πίνακα. Υποθέτει ότι η διαφάνεια και το σχήμα υπάρχουν και ότι το σχήμα είναι πίνακας. Στη συνέχεια διατρέχει όλες τις σειρές και στήλες και χρησιμοποιεί [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) για να εντοπίσει κελιά σε συγχωνευμένες περιοχές. Για κάθε αντιστοιχία, εκτυπώνει τις συντεταγμένες του κελιού με τη σειρά `σειρά;στήλη`, [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/), [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/), και τις αρχικές συντεταγμένες της περιοχής, [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) και [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/).

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

## **Αφαίρεση Περιγραμμάτων Κελιών Πίνακα**

Δημιουργήστε ένα [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) και προσθέστε έναν πίνακα στην πρώτη του διαφάνεια με την [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/). Τα πλάτη των στηλών, τα ύψη των σειρών και η θέση του πίνακα ορίζονται σε πόντους. Το παράδειγμα ορίζει όλα τα τέσσερα περιγράμματα κελιών σε [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/), καθιστώντας τα αόρατα.

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

## **Προσθήκη Διαγώνιων Περιγραμμάτων Κελιού**

Χρησιμοποιήστε [getBorderDiagonalDown](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderdiagonaldown/) για να σχεδιάσετε μια γραμμή από την επάνω‑αριστερή γωνία προς την κάτω‑δεξιά, και [getBorderDiagonalUp](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderdiagonalup/) για να σχεδιάσετε μια γραμμή από την κάτω‑αριστερή γωνία προς την πάνω‑δεξιά. Μια διαγώνιος μπορεί να υποδηλώνει μια κεφαλίδα γωνίας· και οι δύο διαγώνιοι μπορούν να σχηματίσουν X για να σηματοδοτήσουν ότι το κελί δεν είναι εφαρμόσιμο.

Κάθε διαγώνιος έχει το δικό του [LineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/). Στο [getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/getfillformat/), χρησιμοποιήστε το [setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) για να επιλέξετε [FillType::Solid](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) και διαλέξτε χρώμα μέσω του [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/getsolidfillcolor/). Ορίστε το πλάτος της γραμμής σε πόντους με το [setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/setwidth/).

Το παράδειγμα δημιουργεί τρία κελιά σε μια σειρά: μια κόκκινη διαγώνιο προς τα κάτω, μια μπλε διαγώνιο προς τα πάνω και και τις δύο διαγώνιους. Αφήνει τα επάνω, κάτω, αριστερά και δεξιά περιγράμματα κελιών αμετάβλητα.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 210, 210, 210 ];
    $rowHeights = [ 160 ];
    $table = $slide->getShapes()->addTable(45, 130, $columnWidths, $rowHeights);

    $downwardBorder = $table->get_Item(0, 0)->getCellFormat()->getBorderDiagonalDown();
    $downwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $downwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $downwardBorder->setWidth(3);

    $upwardBorder = $table->get_Item(1, 0)->getCellFormat()->getBorderDiagonalUp();
    $upwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $upwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $upwardBorder->setWidth(5);

    $crossDownwardBorder = $table->get_Item(2, 0)->getCellFormat()->getBorderDiagonalDown();
    $crossDownwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $crossDownwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $crossDownwardBorder->setWidth(3);

    $crossUpwardBorder = $table->get_Item(2, 0)->getCellFormat()->getBorderDiagonalUp();
    $crossUpwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $crossUpwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $crossUpwardBorder->setWidth(5);

    $presentation->save("diagonal_cell_borders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Μια διαγώνιος αλλάζει μόνο τη μορφοποίηση του κελιού. Κάθε κελί διατηρεί ένα μοναδικό πλαίσιο κειμένου, προσπελάσιμο μέσω του [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/cell/gettextframe/). Οι περιοχές από τη μία και την άλλη πλευρά μιας διαγωνίου δεν μπορούν να επεξεργαστούν ανεξάρτητα.

Ο αποθηκευμένος πίνακας, αποτυπωμένος στο Microsoft PowerPoint:

![Τρία κελιά πίνακα που δείχνουν μια κόκκινη διαγώνιο από πάνω‑αριστερά προς κάτω‑δεξιά, μια μπλε διαγώνιο από κάτω‑αριστερά προς πάνω‑δεξιά, και και τις δύο διαγώνιους σχηματίζουν X.](diagonal-cell-borders.png)

*Αριστερά προς δεξιά: διαγώνιος προς τα κάτω (κόκκινο, 3 pt), διαγώνιος προς τα πάνω (μπλε, 5 pt), και και οι δύο διαγώνιοι.*

## **Συγχώνευση Κελιών Πίνακα**

Χρησιμοποιήστε το [mergeCells](https://reference.aspose.com/slides/php-java/aspose.slides/table/mergecells/) για να συνδυάσετε μια ορθογώνια περιοχή κελιών σε ένα κελί. Καθορίστε τα κελιά στις επάνω‑αριστερές και κάτω‑δεξιές γωνίες της περιοχής. Το τελευταίο όρισμα ελέγχει αν η συγχώνευση μπορεί να περιλάβει κελιά εκτός της καθορισμένης περιοχής· `false` διατηρεί τη συγχώνευση εντός της περιοχής.

Το παράδειγμα δημιουργεί έναν πίνακα 4 × 4 με στήλες και σειρές 70 πόντων, στη συνέχεια συγχωνεύει τα τέσσερα κεντρικά κελιά από το `(1, 1)` έως το `(2, 2)`. Το προκύπτον κελί εκτείνεται σε δύο στήλες και δύο σειρές, ενώ το υποκείμενο πλέγμα του πίνακα παραμένει τέσσερις στήλες και τέσσερις σειρές. Για να προσπελάσετε το περιεχόμενο ή τη μορφοποίηση του συγχωνευμένου κελιού, χρησιμοποιήστε τη θέση του επάνω‑αριστερού: `$table->get_Item(1, 1)` σε αυτό το παράδειγμα. Οι υπόλοιπες θέσεις στην περιοχή διατήρούνται μέρος του πλέγματος του πίνακα, έτσι οι δείκτες των κελιών εκτός της περιοχής δεν αλλάζουν.

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

Η συγχώνευση κελιών στο προηγούμενο παράδειγμα διατηρεί το πλέγμα του πίνακα. Η διαίρεση ενός κελιού μπορεί να εισαγάγει μια νέα στήλη πλέγματος και να αλλάξει τους δείκτες στήλης των κελιών στα δεξιά του. Το Aspose.Slides ακολουθεί το μοντέλο πλέγματος πινάκων του PowerPoint.

Αυτό το παράδειγμα δημιουργεί έναν πίνακα 4 × 4 με στήλες και σειρές 70 πόντων και καλεί το [splitByWidth](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbywidth/) στο κελί `(1, 1)`. Η μισή του πλάτος 70 πόντων δίνεται για τη δημιουργία δύο κελίων ίσου πλάτους.

Μετά αυτό το διαχωρισμό, τα δύο μισά προσπελάζονται ως `$table->get_Item(1, 1)` και `$table->get_Item(2, 1)`. Το πλέγμα του πίνακα έχει πλέον πέντε στήλες: τα κελιά που ήταν αρχικά στις στήλες 2 και 3 μετακινούνται στις στήλες 3 και 4, αντίστοιχα. Οι δείκτες σειρών παραμένουν αμετάβλητοι. Χρησιμοποιήστε αυτούς τους ενημερωμένους δείκτες στήλης όταν προσπελάζετε κελιά μετά το διαχωρισμό.

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

<!-- visual-explanation:manage-cells:start -->
[![Ένα μη συγχωνευμένο κελί 70 πόντων χωρίζεται σε δύο κελιά 35 πόντων, προσθέτοντας μια πέμπτη στήλη πλέγματος και μετατοπίζοντας τους δείκτες δεξιά του.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*Το διαχωρισμό πλάτους επηρεάζει το κελί (1, 1), χρησιμοποιώντας δείκτες μηδενικής βάσης (στήλη, σειρά). Οι άλλες σειρές διατηρούν ένα κελί που εκτείνεται και στις δύο νέες θέσεις στήλης.*
<!-- visual-explanation:manage-cells:end -->

### **Διαίρεση Συγχωνευμένων Κελιών κατά Σειρά ή Στήλη**

Για να προετοιμάσετε συγχωνευμένα κελιά προτύπου για πληθυσμό δεδομένων, χρησιμοποιήστε το [splitByRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyrowspan/) για διαίρεση κατά υπάρχον όριο σειράς, ή το [splitByColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbycolspan/) για διαίρεση κατά όριο στήλης.

Το όρισμα `index` μετρά σειρές στο πάνω μέρος ή στήλες στο αριστερό μέρος του διαχωρισμού· είναι σχετικά με τη συγχωνευμένη περιοχή:

- Διαχωρισμός σειράς: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/).
- Διαχωρισμός στήλης: `0 < index <` [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/).

Το παράδειγμα υποθέτει ότι η παρουσίαση έχει έναν πίνακα ως πρώτο σχήμα στην πρώτη διαφάνεια, με τα `(1, 2)` και `(1, 3)` συγχωνευμένα κατακόρυφα. Ξεκινώντας από τη χαμηλότερη θέση, χρησιμοποιεί τα [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) και [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) για να εντοπίσει το σημείο εκκίνησης και ελέγχει και τις δύο διασπάσεις. Το `splitByRowSpan(1)` στη συνέχεια διαχωρίζει τις σειρές 2 και 3 για τα ονόματα προϊόντων. Για μια οριζόντια συγχώνευση δύο στηλών, χρησιμοποιήστε `splitByColSpan(1)`.

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

        // Ανακτήστε τα προκύψαντα κελιά από τον πίνακα μετά το διαχωρισμό.
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

Το πλέγμα του πίνακα και οι γύρω δείκτες κελιών παραμένουν αμετάβλητοι. Ανακτήστε τα προκύπτοντα κελιά με τις συντεταγμένες τους· εδώ, και τα δύο έχουν διασπάσεις 1 και το [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) επιστρέφει `false`. Μεγαλύτερες περιοχές μπορούν να παραμείνουν εν μέρει συγχωνευμένες μετά από ένα διαχωρισμό.

Το αρχικό κείμενο και η μορφοποίησή του παραμένουν στο πάνω (ή αριστερό) κελί· το νέο κελί είναι κενό αλλά κληρονομεί τη μορφοποίηση του κελιού όπως γέμισμα, περιγράμματα και περιθώρια. Συμπληρώστε τα κελιά μετά το διαχωρισμό και ορίστε τυχόν απαιτούμενη μορφοποίηση κειμένου ρητά.

Η αποθηκευμένη παρουσίαση περιέχει ξεχωριστά κελιά «Product A» και «Product B» με τη μορφοποίηση του προτύπου κελιού διατηρημένη. Δείτε την [Cell API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) για λεπτομέρειες.

### **Διαίρεση Κελιού σε Συγκεκριμένο Ύψος**

Το [splitByHeight](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyheight/) παίρνει το ύψος του πάνω μέρους σε πόντους. Το [splitByRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyrowspan/) παίρνει τον αριθμό των υπαρχόντων γραμμών πλέγματος στο πάνω μέρος. Για να κεντράρετε ένα κελί 40 πόντων στη δεξιά στήλη, αφαιρέστε 40 από το πραγματικό ύψος του κελιού και διαιρέστε το υπόλειπο ισόποσα από πάνω και από κάτω.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 160, 160 ];
    $rowHeights = [ 140 ];
    
    $table = $slide->getShapes()->addTable(50, 50, $columnWidths, $rowHeights);
    $table->get_Item(0, 0)->getTextFrame()->setText("Left");

    $rightCell = $table->get_Item(1, 0);
    $height = java_values($rightCell->getHeight());
    $margin = ($height - 40) / 2;

    $rightCell->splitByHeight($margin);
    $table->get_Item(1, 1)->splitByHeight(40);
    $table->get_Item(1, 1)->getTextFrame()->setText("Middle");

    $presentation->save("split_by_height.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Ο πρώτος διαχωρισμός προσθέτει μια γραμμή πλέγματος και αφήνει τα κάτω 90 πόντους στο κελί `(1, 1)`. Ο δεύτερος διαχωρισμός διαιρεί αυτό το κελί σε ένα κέντρο 40 πόντων και ένα κάτω 50 πόντων. Η δεξιά στήλη έχει τώρα τρία κελιά με ύψη 50, 40 και 50 πόντων από πάνω προς τα κάτω. Το αριστερό κελί εκτείνεται και στις τρεις σειρές και διατηρεί το αρχικό ύψος του 140 πόντων.

![Το αριστερό κελί εκτείνεται σε όλο το ύψος του πίνακα δίπλα σε τρία κελιά με το κέντρο «Middle» στο κέντρο.](split-by-height.png)

## **Αλλαγή Χρώματος Φόντου Κελιού Πίνακα**

Αυτό το παράδειγμα δημιουργεί έναν πίνακα με στήλες 150 πόντων και σειρές 50 πόντων. Χρησιμοποιεί το [setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) για να επιλέξει γεμισμό στερεό και θέτει το χρώμα που επιστρέφει το [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/getsolidfillcolor/) σε κόκκινο για το κελί `(2, 3)`, στην τρίτη στήλη και τέταρτη σειρά.

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

Τοποθετήστε την είσοδο εικόνας στον τρέχοντα κατάλογο εργασίας πριν τρέξετε αυτό το παράδειγμα. Φορτώνει την εικόνα με το [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) και την προσθέτει στη συλλογή εικόνων της παρουσίασης με το [addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/addimage/). Στη συνέχεια αναθέτει την εικόνα στο picture fill του κελιού `(0, 0)`, του πρώτου κελιού στον πίνακα.

[PictureFillMode::Stretch](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) τεντώνει την εικόνα ώστε να γεμίζει το κελί, κάτι που μπορεί να αλλάξει την αναλογία της. Τα πλάτη των στηλών και τα ύψη των σειρών είναι σε πόντους. Η φορτωμένη εικόνα διαγράφεται σε ένα μπλοκ `finally` μετά την προσθήκη της στην παρουσίαση.

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

**Μπορώ να ορίσω διαφορετικά πάχη γραμμής και στυλ για διαφορετικές πλευρές ενός μόνο κελιού;**

Ναι. Τα περιγράμματα [top](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getbordertop/), [bottom](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderbottom/), [left](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderleft/), και [right](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderright/) έχουν ξεχωριστές ιδιότητες, ώστε το πάχος και το στυλ της κάθε πλευράς να μπορεί να διαφέρει.

**Τι συμβαίνει με την εικόνα αν αλλάξω το μέγεθος στήλης/σειράς μετά τον καθορισμό μιας εικόνας ως φόντο κελιού;**

Η συμπεριφορά εξαρτάται από τη [fill mode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) (stretch/tile). Με τέντωμα, η εικόνα προσαρμόζεται στο νέο κελί· με εμφάνιση σε πλοκάμια, τα πλοκάμια επαναϋπολογίζονται.

**Μπορώ να αναθέσω υπερσύνδεσμο σε όλο το περιεχόμενο ενός κελιού;**

Τα [Hyperlinks](/slides/el/php-java/manage-hyperlinks/) ορίζονται σε επίπεδο κειμένου (portion) μέσα στο πλαίσιο κειμένου του κελιού ή σε επίπεδο ολόκληρου του πίνακα/σχήματος. Στην πράξη, αναθέτετε το σύνδεσμο σε μια portion ή σε όλο το κείμενο του κελιού.

**Μπορώ να ορίσω διαφορετικές γραμματοσειρές σε ένα μόνο κελί;**

Ναι. Το πλαίσιο κειμένου ενός κελιού υποστηρίζει [portions](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) (τμήματα) με ανεξάρτητη μορφοποίηση—οικογένεια γραμματοσειράς, στυλ, μέγεθος και χρώμα.