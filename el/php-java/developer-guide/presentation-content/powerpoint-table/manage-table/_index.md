---
title: Διαχείριση Πινάκων Παρουσίασης σε PHP
linktitle: Διαχείριση Πίνακα
type: docs
weight: 10
url: /el/php-java/manage-table/
keywords:
- προσθήκη πίνακα
- δημιουργία πίνακα
- πρόσβαση πίνακα
- λόγος αναλογίας
- στοίχιση κειμένου
- μορφοποίηση κειμένου
- στυλ πίνακα
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Δημιουργήστε & επεξεργαστείτε πίνακες σε διαφάνειες PowerPoint με Aspose.Slides για PHP μέσω Java. Ανακαλύψτε απλά παραδείγματα κώδικα για να βελτιώσετε τη ροή εργασίας των πινάκων σας."
---
## **Εισαγωγή**

Ένας πίνακας στο PowerPoint είναι ένας αποδοτικός τρόπος παρουσίασης και απεικόνισης πληροφοριών. Οι πληροφορίες σε ένα πλέγμα κελιών (διατεταγμένα σε σειρές και στήλες) είναι απλές και εύκολες στην κατανόηση.

Η Aspose.Slides παρέχει την κλάση [Table](https://reference.aspose.com/slides/el/php-java/aspose.slides/Table) , την κλάση [Cell](https://reference.aspose.com/slides/el/php-java/aspose.slides/cell/) , και άλλους τύπους που σας επιτρέπουν να δημιουργείτε, ενημερώνετε και διαχειρίζεστε πίνακες σε όλα τα είδη παρουσιάσεων.

## **Δημιουργία Πίνακα από την Αρχή**

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation).
2. Αποκτήστε αναφορά σε μια διαφάνεια μέσω του δείκτη της. 
3. Ορίστε έναν πίνακα του `columnWidth`.
4. Ορίστε έναν πίνακα του `rowHeight`.
5. Προσθέστε ένα αντικείμενο [Table](https://reference.aspose.com/slides/el/php-java/aspose.slides/table/) στη διαφάνεια μέσω της μεθόδου [addTable](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/addtable/).
6. Επαναλάβετε για κάθε [Cell](https://reference.aspose.com/slides/el/php-java/aspose.slides/cell/) ώστε να εφαρμόσετε μορφοποίηση στα άνω, κάτω, δεξιά και αριστερά όρια.
7. Συνενώστε τα πρώτα δύο κελιά της πρώτης σειράς του πίνακα. 
8. Προσεγγίστε το [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/) ενός [Cell](https://reference.aspose.com/slides/el/php-java/aspose.slides/cell/).
9. Προσθέστε κάποιο κείμενο στο [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/).
10. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```php
  # Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει ένα αρχείο PPTX
  $pres = new Presentation();
  try {
    # Προσπελάζει την πρώτη διαφάνεια
    $sld = $pres->getSlides()->get_Item(0);
    # Ορίζει στήλες με πλάτη και σειρές με ύψη
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # Προσθέτει ένα σχήμα πίνακα στη διαφάνεια
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Ορίζει τη μορφοποίηση του περιγράμματος για κάθε κελί
    for($row = 0; $row < java_values($tbl->getRows()->size()) ; $row++) {
      for($cell = 0; $cell < java_values($tbl->getRows()->get_Item($row)->size()) ; $cell++) {
        $cellFormat = $tbl->getRows()->get_Item($row)->get_Item($cell)->getCellFormat();
        $cellFormat::getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderTop()->setWidth(5);
        $cellFormat::getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderBottom()->setWidth(5);
        $cellFormat::getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderLeft()->setWidth(5);
        $cellFormat::getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderRight()->setWidth(5);
      }
    }
    # Συγχωνεύει τα κελιά 1 & 2 της σειράς 1
    $tbl->mergeCells($tbl->getRows()->get_Item(0)->get_Item(0), $tbl->getRows()->get_Item(1)->get_Item(1), false);
    # Προσθέτει κάποιο κείμενο στο συγχωνευμένο κελί
    $tbl->getRows()->get_Item(0)->get_Item(0)->getTextFrame()->setText("Merged Cells");
    # Αποθηκεύει την παρουσίαση στο δίσκο
    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Αρίθμηση σε Κανονικό Πίνακα**

Σε έναν κανονικό πίνακα, η αρίθμηση των κελιών είναι απλή και αρχίζει από το μηδέν. Το πρώτο κελί σε έναν πίνακα έχει δείκτη 0,0 (στήλη 0, σειρά 0). 

Για παράδειγμα, τα κελιά σε έναν πίνακα με 4 στήλες και 4 σειρές αριθμούνται ως εξής:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Αυτός ο κώδικας PHP δείχνει πώς να ορίσετε την αρίθμηση των κελιών σε έναν πίνακα:

```php
  # Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει ένα αρχείο PPTX
  $pres = new Presentation();
  try {
    # Προσπελάζει την πρώτη διαφάνεια
    $sld = $pres->getSlides()->get_Item(0);
    # Ορίζει στήλες με πλάτη και σειρές με ύψη
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Προσθέτει ένα σχήμα πίνακα στη διαφάνεια
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Ορίζει τη μορφοποίηση του περιγράμματος για κάθε κελί
    $rows = $tbl->getRows();
    foreach($rows as $row) {
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
    # Αποθηκεύει την παρουσίαση στο δίσκο
    $pres->save("StandardTables_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Πρόσβαση σε Υπάρχον Πίνακα**

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation).

2. Αποκτήστε μια αναφορά στη διαφάνεια που περιέχει τον πίνακα μέσω του δείκτη της. 

3. Δημιουργήστε ένα αντικείμενο [Table](https://reference.aspose.com/slides/el/php-java/aspose.slides/Table) και ορίστε το σε null.

4. Επαναλάβετε σε όλα τα αντικείμενα [Shape](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/) μέχρι να βρεθεί ο πίνακας.

   Εάν υποψιάζεστε ότι η διαφάνεια που επεξεργάζεστε περιέχει έναν μόνο πίνακα, μπορείτε απλά να ελέγξετε όλα τα σχήματα που περιέχει. Όταν ένα σχήμα αναγνωρίζεται ως πίνακας, μπορείτε να το μετατρέψετε σε αντικείμενο [Table]. Ωστόσο, εάν η διαφάνεια περιέχει πολλούς πίνακες, είναι προτιμότερο να αναζητήσετε τον απαιτούμενο πίνακα μέσω του [setAlternativeText(String value)](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/setalternativetext/).

5. Χρησιμοποιήστε το αντικείμενο [Table](https://reference.aspose.com/slides/el/php-java/aspose.slides/Table) για να εργαστείτε με τον πίνακα. Στο παρακάτω παράδειγμα, προσθέσαμε μια νέα σειρά στον πίνακα.

6. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```php
  # Δημιουργεί την κλάση Presentation που αντιπροσωπεύει ένα αρχείο PPTX
  $pres = new Presentation("UpdateExistingTable.pptx");
  try {
    # Προσπελάζει την πρώτη διαφάνεια
    $sld = $pres->getSlides()->get_Item(0);
    # Αρχικοποιεί το TableEx σε null
    $tbl = null;
    # Επαναλαμβάνει τα σχήματα και ορίζει μια αναφορά στον πίνακα που βρέθηκε
    $shapes = $sld->getShapes();
    foreach($shapes as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # Ορίζει το κείμενο για την πρώτη στήλη της δεύτερης σειράς
        $tbl->get_Item(0, 1)->getTextFrame()->setText("New");
      }
    }
    # Αποθηκεύει την τροποποιημένη παρουσίαση στο δίσκο
    $pres->save("table1_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Εντοπισμός του Κελιού που Κατέχει ένα Πλαίσιο Κειμένου**

Όταν ο γενικός κώδικας επεξεργασίας κειμένου λαμβάνει ένα [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/) από έναν πίνακα, χρησιμοποιήστε τη μέθοδο [TextFrame::getParentCell](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/#getParentCell) για να ανακτήσετε το ιδιοκατοίκι [Cell](https://reference.aspose.com/slides/el/php-java/aspose.slides/cell/). Για ένα πλαίσιο κειμένου κελιού πίνακα, το [TextFrame::getParentCell](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/#getParentCell) επιστρέφει τον κάτοχο και το [TextFrame::getParentShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/#getParentShape) επιστρέφει `null`, ακόμη και αν ο πίνακας αυτός είναι σχήμα.

Οι συντεταγμένες του κελιού είναι διαθέσιμες μέσω των μόνο‑ανάγνωση μεθόδων [Cell::getFirstColumnIndex](https://reference.aspose.com/slides/el/php-java/aspose.slides/cell/#getFirstColumnIndex) και [Cell::getFirstRowIndex](https://reference.aspose.com/slides/el/php-java/aspose.slides/cell/#getFirstRowIndex). Το [TextFrame::getParentCell](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/#getParentCell) παρέχει επίσης πλοήγηση μόνο‑ανάγνωση: επιστρέφει τον κάτοχο αλλά δεν αλλάζει την ιδιοκτησία. Πάντα ελέγχετε το επιστρεφόμενο κελί με `java_is_null` πριν το χρησιμοποιήσετε.

Για ένα πλήρες παράδειγμα που εντοπίζει ιδιοκτήτες κελιών πίνακα και σχημάτων, συμπεριλαμβανομένων σχημάτων που σχετίζονται με κόμβους SmartArt, δείτε το [Search and Replace Text](/slides/el/php-java/search-and-replace-text/).

## **Στοίχιση Κειμένου σε Πίνακα**

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation).
2. Αποκτήστε αναφορά σε μια διαφάνεια μέσω του δείκτη της. 
3. Προσθέστε ένα αντικείμενο [Table](https://reference.aspose.com/slides/el/php-java/aspose.slides/Table) στη διαφάνεια.
4. Προσεγγίστε ένα αντικείμενο [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/) από τον πίνακα.
5. Προσεγγίστε το [Paragraph](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraph/).
6. Στοίχιση του κειμένου κατακόρυφα.
7. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```php
  # Δημιουργεί ένα αντικείμενο της κλάσης Presentation
  $pres = new Presentation();
  try {
    # Λαμβάνει την πρώτη διαφάνεια
    $slide = $pres->getSlides()->get_Item(0);
    # Ορίζει στήλες με πλάτη και σειρές με ύψη
    $dblCols = array(120, 120, 120, 120 );
    $dblRows = array(100, 100, 100, 100 );
    # Προσθέτει το σχήμα πίνακα στη διαφάνεια
    $tbl = $slide->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    $tbl->get_Item(1, 0)->getTextFrame()->setText("10");
    $tbl->get_Item(2, 0)->getTextFrame()->setText("20");
    $tbl->get_Item(3, 0)->getTextFrame()->setText("30");
    # Προσπελάζει το πλαίσιο κειμένου
    $txtFrame = $tbl->get_Item(0, 0)->getTextFrame();
    # Δημιουργεί το αντικείμενο Paragraph για το πλαίσιο κειμένου
    $paragraph = $txtFrame->getParagraphs()->get_Item(0);
    # Δημιουργεί το αντικείμενο Portion για την παράγραφο
    $portion = $paragraph->getPortions()->get_Item(0);
    $portion->setText("Text here");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Στοίχει το κείμενο κατακόρυφα
    $cell = $tbl->get_Item(0, 0);
    $cell->setTextAnchorType(TextAnchorType::Center);
    $cell->setTextVerticalType(TextVerticalType::Vertical270);
    # Αποθηκεύει την παρουσίαση στο δίσκο
    $pres->save("Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ορισμός Μορφοποίησης Κειμένου σε Επίπεδο Πίνακα**

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation).
2. Αποκτήστε αναφορά σε μια διαφάνεια μέσω του δείκτη της. 
3. Προσεγγίστε ένα αντικείμενο [Table](https://reference.aspose.com/slides/el/php-java/aspose.slides/Table) από τη Διαφάνεια.
4. Ορίστε το [setFontHeight(float value)](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseportionformat/#setFontHeight) για το κείμενο.
5. Ορίστε το [setAlignment(int value)](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/setalignment/) και το [setMarginRight(float value)](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/setmarginright/).
6. Ορίστε το [setTextVerticalType(byte value)](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframeformat/settextverticaltype/).
7. Αποθηκεύστε την τροποποιημένη παρουσίαση. 

```php
  # Δημιουργεί ένα αντικείμενο της κλάσης Presentation
  $pres = new Presentation("simpletable.pptx");
  try {
    # Υποθέτουμε ότι το πρώτο σχήμα στην πρώτη διαφάνεια είναι πίνακας
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Ορίζει το ύψος γραμματοσειράς των κελιών του πίνακα
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->setTextFormat($portionFormat);
    # Ορίζει την στοίχιση κειμένου και το δεξιό περιθώριο των κελιών του πίνακα με μία κλήση
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->setTextFormat($paragraphFormat);
    # Ορίζει τον κατακόρυφο τύπο κειμένου των κελιών του πίνακα
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->setTextFormat($textFrameFormat);
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ανάκτηση Ιδιοτήτων Στυλ Πίνακα**

Η Aspose.Slides σας επιτρέπει να ανακτήσετε τις ιδιότητες στυλ ενός πίνακα ώστε να μπορείτε να χρησιμοποιήσετε αυτές τις λεπτομέρειες για άλλο πίνακα ή αλλού. Αυτός ο κώδικας PHP δείχνει πώς να λάβετε τις ιδιότητες στυλ από ένα προρυθμισμένο στυλ πίνακα:

```php
  $pres = new Presentation();
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->addTable(10, 10, array(100, 150 ), array(5, 5, 5 ));
    $table->setStylePreset(TableStylePreset->DarkStyle1);// αλλάζει το προεπιλεγμένο στυλ προεπιλογής θέματος

    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Κλείδωμα Λόγου Αναλογίας Πίνακα**

Ο λόγος αναλογίας ενός γεωμετρικού σχήματος είναι το ποσοστό των διαστάσεων του σε διαφορετικές διαστάσεις. Η Aspose.Slides παρέχει τη μέθοδο [setAspectRatioLocked](https://reference.aspose.com/slides/el/php-java/aspose.slides/graphicalobjectlock/setaspectratiolocked/) για να μπορείτε να κλειδώσετε τη ρύθμιση λόγου αναλογίας για πίνακες και άλλα σχήματα.

```php
  $pres = new Presentation("pres.pptx");
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    echo("Lock aspect ratio set: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $table->getGraphicalObjectLock()->setAspectRatioLocked(!$table->getGraphicalObjectLock()->getAspectRatioLocked());// αντιστρέφει

    echo("Lock aspect ratio set: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Συχνές Ερωτήσεις**

**Μπορώ να ενεργοποιήσω κατεύθυνση ανάγνωσης δεξιά‑προς‑αριστερά (RTL) για ολόκληρο τον πίνακα και το κείμενο στα κελιά του;**

Ναι. Ο πίνακας εκθέτει τη μέθοδο [setRightToLeft](https://reference.aspose.com/slides/el/php-java/aspose.slides/table/setrighttoleft/), και οι παράγραφοι έχουν τη μέθοδο [ParagraphFormat::setRightToLeft](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/setrighttoleft/). Η χρήση και των δύο εξασφαλίζει τη σωστή σειρά RTL και την αποτύπωση μέσα στα κελιά.

**Πώς μπορώ να αποτρέψω τους χρήστες από το να μετακινούν ή να αλλάζουν το μέγεθος ενός πίνακα στο τελικό αρχείο;**

Χρησιμοποιήστε κλειδώματα σχήματος για να απενεργοποιήσετε τη μετακίνηση, την αλλαγή μεγέθους, την επιλογή κ.λπ. Αυτά τα κλειδώματα ισχύουν και για πίνακες.

**Υποστηρίζεται η εισαγωγή εικόνας μέσα σε ένα κελί ως φόντο;**

Ναι. Μπορείτε να ορίσετε μια [picture fill](https://reference.aspose.com/slides/el/php-java/aspose.slides/picturefillformat/) για ένα κελί· η εικόνα θα καλύψει την περιοχή του κελιού ανάλογα με την επιλεγμένη λειτουργία (τεντωμένο ή πλακίδιο).