---
title: "Διαχείριση κελιών πίνακα σε παρουσιάσεις με PHP"
linktitle: "Διαχείριση κελιών"
type: docs
weight: 30
url: /el/php-java/manage-cells/
keywords:
- "κελί πίνακα"
- "συγχώνευση κελιών"
- "αφαίρεση περιγράμματος"
- "διαχωρισμός κελιού"
- "εικόνα σε κελί"
- "χρώμα φόντου"
- "PowerPoint"
- "παρουσίαση"
- "PHP"
- "Aspose.Slides"
description: "Διαχειριστείτε εύκολα τα κελιά πίνακα στο PowerPoint με το Aspose.Slides για PHP. Κατακτήστε την πρόσβαση, τροποποίηση και στυλιζάρισμα των κελιών γρήγορα για άψογη αυτοματοποίηση διαφανειών."
---
## **Επισκόπηση**

Το Aspose.Slides σας επιτρέπει να έχετε πρόσβαση και να τροποποιείτε τα κελιά πινάκων σε παρουσιάσεις PowerPoint. Αυτό το άρθρο εξηγεί πώς να αναγνωρίζετε συγχωνευμένα κελιά πινάκων, να αφαιρείτε τα σύνορα των κελιών, να εργάζεστε με την αρίθμηση των κελιών μετά τη συγχώνευση ή το διαχωρισμό τους, να αλλάζετε το χρώμα φόντου ενός κελιού και να προσθέτετε μια εικόνα μέσα σε ένα κελί πίνακα. Τα παραδείγματα δείχνουν πώς να δημιουργήσετε ή να ανοίξετε μια παρουσίαση, να λάβετε έναν πίνακα από μια διαφάνεια, να ενημερώσετε τη μορφοποίηση των κελιών μέσω των ιδιοτήτων τους και να αποθηκεύσετε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

## **Αναγνώριση Συγχωνευμένου Κελ��ου Πίνακα**

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation).
2. Λάβετε τον πίνακα από την πρώτη διαφάνεια.
3. Επαναλάβετε τις σειρές και στήλες του πίνακα για να εντοπίσετε συγχωνευμένα κελιά.
4. Εκτυπώστε μήνυμα όταν βρεθούν συγχωνευμένα κελιά.

Αυτός ο κώδικας PHP δείχνει πώς να αναγνωρίσετε συγχωνευμένα κελιά πίνακα σε μια παρουσίαση:

```php
  $pres = new Presentation("SomePresentationWithTable.pptx");
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);// υποθέτοντας ότι η διαφάνεια #0.σχήμα #0 είναι πίνακας

    for($i = 0; $i < java_values($table->getRows()->size()) ; $i++) {
      for($j = 0; $j < java_values($table->getColumns()->size()) ; $j++) {
        $currentCell = $table->getRows()->get_Item($i)->get_Item($j);
        if ($currentCell->isMergedCell()) {
          echo(sprintf("Cell %d;%d is a part of merged cell with RowSpan=%d and ColSpan=%d starting from Cell %d;%d.", $i, $j, $currentCell->getRowSpan(), $currentCell->getColSpan(), $currentCell->getFirstRowIndex(), $currentCell->getFirstColumnIndex()));
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Αφαίρεση Συνόρων Κελιών Πίνακα**

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation).
2. Λάβετε την αναφορά μιας διαφάνειας μέσω του δείκτη της.
3. Ορίστε έναν πίνακα στηλών με πλάτος.
4. Ορίστε έναν πίνακα σειρών με ύψος.
5. Προσθέστε έναν πίνακα στη διαφάνεια μέσω της μεθόδου [addTable](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/#addTable).
6. Επαναλάβετε κάθε κελί για να αφαιρέσετε τα άνω, κάτω, δεξιά και αριστερά σύνορα.
7. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας PHP δείχνει πώς να αφαιρέσετε τα σύνορα από τα κελιά πίνακα:

```php
  # Δημιουργεί ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PPTX
  $pres = new Presentation();
  try {
    # Πρόσβαση στην πρώτη διαφάνεια
    $sld = $pres->getSlides()->get_Item(0);
    # Ορίζει στήλες με πλάτη και σειρές με ύψη
    $dblCols = array(50, 50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # Προσθέτει σχήμα πίνακα στη διαφάνεια
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Ορίζει τη μορφή περιγράμματος για κάθε κελί
    foreach($tbl->getRows() as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::NoFill);
      }
    }
    # Γράφει το PPTX στο δίσκο
    $pres->save("table_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Αρίθμηση σε Συγχωνευμένα Κελιά**

Αν συγχωνεύσουμε 2 ζεύγη κελιών (1, 1) x (2, 1) και (1, 2) x (2, 2), ο προκύπτων πίνακας θα είναι αριθμημένος. Αυτός ο κώδικας PHP επιδεικνύει τη διαδικασία:

```php
  # Δημιουργεί αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PPTX
  $pres = new Presentation();
  try {
    # Πρόσβαση στην πρώτη διαφάνεια
    $sld = $pres->getSlides()->get_Item(0);
    # Ορίζει στήλες με πλάτη και σειρές με ύψος
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Προσθέτει σχήμα πίνακα στη διαφάνεια
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Ορίζει τη μορφή περιγράμματος για κάθε κελί
    foreach($tbl->getRows() as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderTop()->setWidth(5);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderBottom()->setWidth(5);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderLeft()->setWidth(5);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderRight()->setWidth(5);
      }
    }
    # Συγχωνεύει τα κελιά (1, 1) x (2, 1)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # Συγχωνεύει τα κελιά (1, 2) x (2, 2)
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    $pres->save("MergeCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Στη συνέχεια συγχωνεύουμε περαιτέρω τα κελιά συγχωνεύοντας τα (1, 1) και (1, 2). Το αποτέλεσμα είναι ένας πίνακας που περιέχει ένα μεγάλο συγχωνευμένο κελί στο κέντρο του:

```php
  # Δημιουργεί την κλάση Presentation που αντιπροσωπεύει ένα αρχείο PPTX
  $pres = new Presentation();
  try {
    # Πρόσβαση στην πρώτη διαφάνεια
    $sld = $pres->getSlides()->get_Item(0);
    # Ορίζει στήλες με πλάτη και σειρές με ύψος
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Προσθέτει σχήμα πίνακα στη διαφάνεια
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Ορίζει τη μορφή περιγράμματος για κάθε κελί
    foreach($tbl->getRows() as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderTop()->setWidth(5);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderBottom()->setWidth(5);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderLeft()->setWidth(5);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderRight()->setWidth(5);
      }
    }
    # Συγχωνεύει τα κελιά (1, 1) x (2, 1)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # Συγχωνεύει τα κελιά (1, 2) x (2, 2)
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    # Συγχωνεύει τα κελιά (1, 1) x (1, 2)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(1, 2), true);
    # Γράφει το αρχείο PPTX στο δίσκο
    $pres->save("MergeCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Αρίθμηση σε Διαχωρισμένο Κελί**

Στις προηγούμενες παραδείγματα, όταν τα κελιά πίνακα συγχωνεύονταν, η αρίθμηση ή το σύστημα αριθμών σε άλλα κελιά δεν άλλαζε.

Αυτή τη φορά, παίρνουμε έναν κανονικό πίνακα (πίνακα χωρίς συγχωνευμένα κελιά) και προσπαθούμε να χωρίσουμε το κελί (1,1) για να δημιουργήσουμε έναν ειδικό πίνακα. Ίσως θελήσετε να δώσετε προσοχή στην αρίθμηση αυτού του πίνακα, η οποία μπορεί να φαίνεται περίεργη. Ωστόσο, αυτός είναι ο τρόπος με τον οποίο το Microsoft PowerPoint αριθμεί τα κελιά του πίνακα και το Aspose.Slides κάνει το ίδιο.

Αυτός ο κώδικας PHP επιδεικνύει τη διαδικασία που περιγράψαμε:

```php
  # Δημιουργεί την κλάση Presentation που αντιπροσωπεύει ένα αρχείο PPTX
  $pres = new Presentation();
  try {
    # Πρόσβαση στην πρώτη διαφάνεια
    $sld = $pres->getSlides()->get_Item(0);
    # Ορίζει στήλες με πλάτη και σειρές με ύψη
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Προσθέτει σχήμα πίνακα στη διαφάνεια
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Ορίζει τη μορφή περιγράμματος για κάθε κελί
    foreach($tbl->getRows() as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderTop()->setWidth(5);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderBottom()->setWidth(5);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderLeft()->setWidth(5);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderRight()->setWidth(5);
      }
    }
    # Συγχωνεύει τα κελιά (1, 1) x (2, 1)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # Συγχωνεύει τα κελιά (1, 2) x (2, 2)
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    # Διαχωρίζει το κελί (1, 1)
    $tbl->get_Item(1, 1)->splitByWidth($tbl->get_Item(2, 1)->getWidth() / 2);
    # Γράφει το αρχείο PPTX στο δίσκο
    $pres->save("SplitCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Αλλαγή Χρώματος Φόντου Κελιού Πίνακα**

Αυτός ο κώδικας PHP δείχνει πώς να αλλάξετε το χρώμα φόντου ενός κελιού πίνακα:

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    $dblCols = array(150, 150, 150, 150 );
    $dblRows = array(50, 50, 50, 50, 50 );
    # δημιουργεί έναν νέο πίνακα
    $table = $slide->getShapes()->addTable(50, 50, $dblCols, $dblRows);
    # ορίζει το χρώμα φόντου για ένα κελί
    $cell = $table->get_Item(2, 3);
    $cell->getCellFormat()->getFillFormat()->setFillType(FillType::Solid);
    $cell->getCellFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $presentation->save("cell_background_color.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Προσθήκη Εικόνας Μέσα σε Κελί Πίνακα**

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation).
2. Λάβετε την αναφορά μιας διαφάνειας μέσω του δείκτη της.
3. Ορίστε έναν πίνακα στηλών με πλάτος.
4. Ορίστε έναν πίνακα σειρών με ύψος.
5. Προσθέστε έναν πίνακα στη διαφάνεια μέσω της μεθόδου [AddTable](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/#addTable).
6. Δημιουργήστε ένα αντικείμενο `Images` για να περιέχει το αρχείο εικόνας.
7. Προσθέστε την εικόνα `IImage` στο αντικείμενο `IPPImage`.
8. Ορίστε το `FillFormat` για το κελί του πίνακα σε `Picture`.
9. Προσθέστε την εικόνα στο πρώτο κελί του πίνακα.
10. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX

Αυτός ο κώδικας PHP δείχνει πώς να τοποθετήσετε μια εικόνα μέσα σε ένα κελί πίνακα κατά τη δημιουργία πίνακα:

```php
  # Δημιουργεί την κλάση Presentation που αντιπροσωπεύει ένα αρχείο PPTX
  $pres = new Presentation();
  try {
    # Πρόσβαση στην πρώτη διαφάνεια
    $islide = $pres->getSlides()->get_Item(0);
    # Ορίζει στήλες με πλάτη και σειρές με ύψη
    $dblCols = array(150, 150, 150, 150 );
    $dblRows = array(100, 100, 100, 100, 90 );
    # Προσθέτει σχήμα πίνακα στη διαφάνεια
    $tbl = $islide->getShapes()->addTable(50, 50, $dblCols, $dblRows);
    # Δημιουργεί ένα αντικείμενο IPPImage χρησιμοποιώντας το αρχείο εικόνας
    $picture;
    $image = Images->fromFile("image.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Προσθέτει την εικόνα στο πρώτο κελί του πίνακα
    $cellFormat = $tbl->get_Item(0, 0)->getCellFormat();
    $cellFormat::getFillFormat()->setFillType(FillType::Picture);
    $cellFormat::getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    $cellFormat::getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # Αποθηκεύει το αρχείο PPTX στο δίσκο
    $pres->save("Image_In_TableCell_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Συχνές Ερωτήσεις**

**Μπορώ να ορίσω διαφορετικά πάχη και στυλ γραμμής για τις διαφορετικές πλευρές ενός μόνο κελιού;**

Ναι. Τα σύνορα [πάνω](https://reference.aspose.com/slides/el/php-java/aspose.slides/cellformat/getbordertop/)/[κάτω](https://reference.aspose.com/slides/el/php-java/aspose.slides/cellformat/getborderbottom/)/[αριστερά](https://reference.aspose.com/slides/el/php-java/aspose.slides/cellformat/getborderleft/)/[δεξιά](https://reference.aspose.com/slides/el/php-java/aspose.slides/cellformat/getborderright/) έχουν ξεχωριστές ιδιότητες, έτσι το πάχος και το στυλ κάθε πλευράς μπορεί να διαφέρει. Αυτό ακολουθεί λογικά τον έλεγχο των συνόρων ανά πλευρά για ένα κελί που περιγράφεται στο άρθρο.

**Τι συμβαίνει με την εικόνα αν αλλάξω το μέγεθος στήλης/γραμμής μετά τον ορισμό μιας εικόνας ως φόντο του κελιού;**

Η συμπεριφορά εξαρτάται από τη [fill mode](https://reference.aspose.com/slides/el/php-java/aspose.slides/picturefillmode/) (stretch/tile). Με τέντωμα, η εικόνα προσαρμόζεται στο νέο κελί· με επικάλυψη, τα πλακίδια επαναϋπολογίζονται. Το άρθρο αναφέρει τους τρόπους εμφάνισης εικόνας σε ένα κελί.

**Μπορώ να αντιστοιχίσω έναν υπερσύνδεσμο σε όλο το περιεχόμενο ενός κελιού;**

[Hyperlinks](/slides/el/php-java/manage-hyperlinks/) ορίζονται στο επίπεδο του κειμένου (portion) μέσα στο πλαίσιο κειμένου του κελιού ή σε επίπεδο ολόκληρου του πίνακα/σχήματος. Στην πράξη, αντιστοιχίζετε τον σύνδεσμο σε μια ενότητα ή σε όλο το κείμενο του κελιού.

**Μπορώ να ορίσω διαφορετικές γραμματοσειρές μέσα σε ένα μόνο κελί;**

Ναι. Το πλαίσιο κειμένου ενός κελιού υποστηρίζει [portions](https://reference.aspose.com/slides/el/php-java/aspose.slides/portion/) (runs) με ανεξάρτητη μορφοποίηση—οικογένεια γραμματοσειράς, στυλ, μέγεθος και χρώμα.