---
title: "Διαχείριση γραμμών και στηλών σε πίνακες PowerPoint χρησιμοποιώντας PHP"
linktitle: "Γραμμές και Στήλες"
type: docs
weight: 20
url: /el/php-java/manage-rows-and-columns/
keywords:
- γραμμή πίνακα
- στήλη πίνακα
- πρώτη γραμμή
- κεφαλίδα πίνακα
- κλωνοποίηση γραμμής
- κλωνοποίηση στήλης
- αντιγραφή γραμμής
- αντιγραφή στήλης
- αφαίρεση γραμμής
- αφαίρεση στήλης
- μορφοποίηση κειμένου γραμμής
- μορφοποίηση κειμένου στήλης
- στυλ πίνακα
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Διαχειριστείτε τις γραμμές και τις στήλες πίνακα στο PowerPoint με το Aspose.Slides για PHP μέσω Java και επιταχύνετε την επεξεργασία παρουσιάσεων και την ενημέρωση δεδομένων."
---
## **Εισαγωγή**

Για να μπορείτε να διαχειρίζεστε τις γραμμές και τις στήλες ενός πίνακα σε μια παρουσίαση PowerPoint, το Aspose.Slides παρέχει την κλάση [Table](https://reference.aspose.com/slides/el/php-java/aspose.slides/table/) και πολλούς άλλους τύπους.

## **Ορισμός της πρώτης γραμμής ως κεφαλίδα**

1. Δημιουργήστε ένα αντίτυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) και φορτώστε την παρουσίαση.
2. Αποκτήστε τη αναφορά μιας διαφάνειας μέσω του δείκτη της. 
3. Δημιουργήστε ένα αντικείμενο [Table](https://reference.aspose.com/slides/el/php-java/aspose.slides/Table) και ορίστε το σε null.
4. Περιηγηθείτε σε όλα τα αντικείμενα [Shape](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/) για να βρείτε τον σχετικό πίνακα.
5. Ορίστε την πρώτη γραμμή του πίνακα ως κεφαλίδα. 

Αυτός ο κώδικας PHP δείχνει πώς να ορίσετε την πρώτη γραμμή ενός πίνακα ως κεφαλίδα:

```php
  # Δημιουργεί μια παρουσίαση της κλάσης Presentation
  $pres = new Presentation("table.pptx");
  try {
    # Πρόσβαση στην πρώτη διαφάνεια
    $sld = $pres->getSlides()->get_Item(0);
    # Αρχικοποιεί το null TableEx
    $tbl = null;
    # Διασχίζει τα σχήματα και ορίζει μια αναφορά στον πίνακα
    foreach($sld->getShapes() as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # Ορίζει την πρώτη γραμμή του πίνακα ως κεφαλίδα
        $tbl->setFirstRow(true);
      }
    }
    # Αποθηκεύει την παρουσίαση στον δίσκο
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Κλωνοποίηση γραμμής ή στήλης πίνακα**

1. Δημιουργήστε ένα αντίτυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) και φορτώστε την παρουσίαση,
2. Αποκτήστε τη αναφορά μιας διαφάνειας μέσω του δείκτη της. 
3. Ορίστε έναν πίνακα `columnWidth`.
4. Ορίστε έναν πίνακα `rowHeight`.
5. Προσθέστε ένα αντικείμενο [Table](https://reference.aspose.com/slides/el/php-java/aspose.slides/Table) στη διαφάνεια μέσω της μεθόδου [addTable](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/addtable/).
6. Κλωνοποιήστε τη γραμμή του πίνακα.
7. Κλωνοποιήστε τη στήλη του πίνακα.
8. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτός ο κώδικας PHP δείχνει πώς να κλωνοποιήσετε τη γραμμή ή τη στήλη ενός πίνακα PowerPoint:

```php
  # Δημιουργεί μια παρουσίαση της κλάσης Presentation
  $pres = new Presentation("Test.pptx");
  try {
    # Πρόσβαση στην πρώτη διαφάνεια
    $sld = $pres->getSlides()->get_Item(0);
    # Ορίζει στήλες με πλάτη και γραμμές με ύψη
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # Προσθέτει ένα σχήμα πίνακα στη διαφάνεια
    $table = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Προσθέτει κείμενο στο κελί 1 της γραμμής 1
    $table->get_Item(0, 0)->getTextFrame()->setText("Row 1 Cell 1");
    # Προσθέτει κείμενο στο κελί 2 της γραμμής 1
    $table->get_Item(1, 0)->getTextFrame()->setText("Row 1 Cell 2");
    # Κλωνοποιεί τη γραμμή 1 στο τέλος του πίνακα
    $table->getRows()->addClone($table->getRows()->get_Item(0), false);
    # Προσθέτει κείμενο στο κελί 1 της γραμμής 2
    $table->get_Item(0, 1)->getTextFrame()->setText("Row 2 Cell 1");
    # Προσθέτει κείμενο στο κελί 2 της γραμμής 2
    $table->get_Item(1, 1)->getTextFrame()->setText("Row 2 Cell 2");
    # Κλωνοποιεί τη γραμμή 2 ως 4η γραμμή του πίνακα
    $table->getRows()->insertClone(3, $table->getRows()->get_Item(1), false);
    # Κλωνοποιεί την πρώτη στήλη στο τέλος
    $table->getColumns()->addClone($table->getColumns()->get_Item(0), false);
    # Κλωνοποιεί τη 2η στήλη στη θέση της 4ης στήλης
    $table->getColumns()->insertClone(3, $table->getColumns()->get_Item(1), false);
    # Αποθηκεύει την παρουσίαση στον δίσκο
    $pres->save("table_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Αφαίρεση γραμμής ή στήλης από πίνακα**

1. Δημιουργήστε ένα αντίτυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) και φορτώστε την παρουσίαση,
2. Αποκτήστε τη αναφορά μιας διαφάνειας μέσω του δείκτη της. 
3. Ορίστε έναν πίνακα `columnWidth`.
4. Ορίστε έναν πίνακα `rowHeight`.
5. Προσθέστε ένα αντικείμενο [Table](https://reference.aspose.com/slides/el/php-java/aspose.slides/Table) στη διαφάνεια μέσω της μεθόδου [addTable](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/addtable/).
6. Αφαιρέστε τη γραμμή του πίνακα.
7. Αφαιρέστε τη στήλη του πίνακα.
8. Αποθηκεύστε την τροποποιημένη παρουσίαση. 

Αυτός ο κώδικας PHP δείχνει πώς να αφαιρέσετε μια γραμμή ή στήλη από πίνακα:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $colWidth = array(100, 50, 30 );
    $rowHeight = array(30, 50, 30 );
    $table = $slide->getShapes()->addTable(100, 100, $colWidth, $rowHeight);
    $table->getRows()->removeAt(1, false);
    $table->getColumns()->removeAt(1, false);
    $pres->save("TestTable_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ορισμός μορφοποίησης κειμένου σε επίπεδο γραμμής πίνακα**

1. Δημιουργήστε ένα αντίτυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) και φορτώστε την παρουσίαση,
2. Αποκτήστε τη αναφορά μιας διαφάνειας μέσω του δείκτη της. 
3. Προσπελάστε το σχετικό αντικείμενο [Table](https://reference.aspose.com/slides/el/php-java/aspose.slides/Table) από τη διαφάνεια.
4. Ορίστε το [setFontHeight(float value)](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseportionformat/#setFontHeight) των κελιών της πρώτης γραμμής.
5. Ορίστε το [setAlignment(int value)](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/setalignment/) και το [setMarginRight(float value)](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/setmarginright/) των κελιών της πρώτης γραμμής.
6. Ορίστε το [setTextVerticalType(byte value)](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframeformat/settextverticaltype/) των κελιών της δεύτερης γραμμής.
7. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτός ο κώδικας PHP επιδεικνύει τη λειτουργία.

```php
  # Δημιουργεί ένα αντίτυπο της κλάσης Presentation
  $pres = new Presentation();
  try {
    # Ας υποθέσουμε ότι το πρώτο σχήμα στην πρώτη διαφάνεια είναι ένας πίνακας
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Ορίζει το ύψος γραμματοσειράς των κελιών της πρώτης γραμμής
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->getRows()->get_Item(0)->setTextFormat($portionFormat);
    # Ορίζει την ευθυγράμμιση κειμένου και το δεξί περιθώριο των κελιών της πρώτης γραμμής
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->getRows()->get_Item(0)->setTextFormat($paragraphFormat);
    # Ορίζει τον κατακόρυφο τύπο κειμένου των κελιών της δεύτερης γραμμής
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->getRows()->get_Item(1)->setTextFormat($textFrameFormat);
    # Αποθηκεύει την παρουσίαση στον δίσκο
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ορισμός μορφοποίησης κειμένου σε επίπεδο στήλης πίνακα**

1. Δημιουργήστε ένα αντίτυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) και φορτώστε την παρουσίαση,
2. Αποκτήστε τη αναφορά μιας διαφάνειας μέσω του δείκτη της. 
3. Προσπελάστε το σχετικό αντικείμενο [Table](https://reference.aspose.com/slides/el/php-java/aspose.slides/Table) από τη διαφάνεια.
4. Ορίστε το [setFontHeight(float value)](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseportionformat/#setFontHeight) των κελιών της πρώτης στήλης.
5. Ορίστε το [setAlignment(int value)](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/setalignment/) και το [setMarginRight(float value)](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/setmarginright/) των κελιών της πρώτης στήλης.
6. Ορίστε το [setTextVerticalType(byte value)](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframeformat/settextverticaltype/) των κελιών της δεύτερης στήλης.
7. Αποθηκεύστε την τροποποιημένη παρουσίαση. 

Αυτός ο κώδικας PHP επιδεικνύει τη λειτουργία:

```php
  # Δημιουργεί ένα αντίτυπο της κλάσης Presentation
  $pres = new Presentation();
  try {
    # Ας υποθέσουμε ότι το πρώτο σχήμα στην πρώτη διαφάνεια είναι ένας πίνακας
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Ορίζει το ύψος γραμματοσειράς των κελιών της πρώτης στήλης
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->getColumns()->get_Item(0)->setTextFormat($portionFormat);
    # Ορίζει την ευθυγράμμιση κειμένου και το δεξί περιθώριο των κελιών της πρώτης στήλης σε μία κλήση
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->getColumns()->get_Item(0)->setTextFormat($paragraphFormat);
    # Ορίζει τον κατακόρυφο τύπο κειμένου των κελιών της δεύτερης στήλης
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->getColumns()->get_Item(1)->setTextFormat($textFrameFormat);
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Λήψη ιδιοτήτων στυλ πίνακα**

Το Aspose.Slides σας επιτρέπει να ανακτάτε τις ιδιότητες στυλ για έναν πίνακα ώστε να μπορείτε να χρησιμοποιήσετε αυτές τις λεπτομέρειες για άλλο πίνακα ή σε άλλο σημείο. Αυτός ο κώδικας PHP δείχνει πώς να λάβετε τις ιδιότητες στυλ από ένα προεπιλεγμένο στυλ πίνακα:

```php
  $pres = new Presentation();
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->addTable(10, 10, array(100, 150 ), array(5, 5, 5 ));
    $table->setStylePreset(TableStylePreset->DarkStyle1);// αλλάζει το προεπιλεγμένο στυλ θέματος

    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Συχνές ερωτήσεις**

**Μπορώ να εφαρμόσω θέματα/στυλ PowerPoint σε έναν πίνακα που έχει ήδη δημιουργηθεί;**

Ναι. Ο πίνακας κληρονομεί το θέμα της διαφάνειας/διάταξης/κύριου, και μπορείτε ακόμη να παρακάμψετε τα γέμιστρα, τα περιγράμματα και τα χρώματα κειμένου πάνω από αυτό το θέμα.

**Μπορώ να ταξινομήσω τις γραμμές του πίνακα όπως στο Excel;**

Όχι, οι πίνακες Aspose.Slides δεν διαθέτουν ενσωματωμένη ταξινόμηση ή φίλτρα. Ταξινομήστε τα δεδομένα στη μνήμη πρώτα, κατόπιν επαναπληρώστε τις γραμμές του πίνακα με αυτή τη σειρά.

**Μπορώ να έχω εναλλασσόμενες (striped) στήλες διατηρώντας προσαρμοσμένα χρώματα σε συγκεκριμένα κελιά;**

Ναι. Ενεργοποιήστε τις εναλλασσόμενες στήλες, στη συνέχεια παρακάμψτε συγκεκριμένα κελιά με τοπική μορφοποίηση· η μορφοποίηση σε επίπεδο κελιού έχει προτεραιότητα πάνω από το στυλ του πίνακα.