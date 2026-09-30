---
title: Διαχείριση Γραμμών και Στηλών σε Πίνακες PowerPoint με PHP
linktitle: Γραμμές και Στήλες
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
description: "Διαχειριστείτε τις γραμμές και στήλες των πινάκων σε PowerPoint με Aspose.Slides για PHP μέσω Java και επιταχύνετε την επεξεργασία παρουσιάσεων και την ενημέρωση δεδομένων."
---
## **Εισαγωγή**

Το Aspose.Slides for PHP μέσω Java σάς επιτρέπει να διαχειρίζεστε τη δομή και τη μορφοποίηση πινάκων σε παρουσιάσεις PowerPoint μέσω της κλάσης [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/). Μπορείτε να ορίσετε μια γραμμή κεφαλίδας, να κλωνοποιήσετε ή να αφαιρέσετε γραμμές και στήλες, και να εφαρμόσετε μορφοποίηση κειμένου σε ολόκληρη τη γραμμή ή στήλη.

Αυτό το άρθρο εξηγεί αυτές τις λειτουργίες με παραδείγματα PHP. Επίσης δείχνει πώς να ανακτήσετε το προεπιλεγμένο στυλ ενός πίνακα ώστε να το επαναχρησιμοποιήσετε. Οι δείκτες γραμμών και στηλών του πίνακα είναι μηδενικής βάσης.

## **Έλεγχος Ύψους Γραμμής**

Χρησιμοποιήστε [Row::setMinimalHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/setminimalheight/) για να ορίσετε το ελάχιστο ύψος μιας γραμμής σε σημεία. Είναι ένα κατώτερο όριο, όχι σταθερό ύψος. Η μέθοδος [Row::getHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/getheight/) επιστρέφει το πραγματικό ύψος. Πρόσβαση στη γραμμή μέσω της [Table::getRows](https://reference.aspose.com/slides/php-java/aspose.slides/table/getrows/).

Το παράδειγμα φορτώνει το [row-height-input.pptx](row-height-input.pptx), το οποίο έχει έναν πίνακα ως το πρώτο σχήμα στην πρώτη διαφάνεια. Η πρώτη του σειρά ξεκινά στα 70 σημεία. Τα κελιά χρησιμοποιούν κείμενο Arial 18 σημείων, με αναδίπλωση και περιθώρια 6 σημεία πάνω και κάτω· το μεγαλύτερο κείμενο στη δεύτερη στήλη αναδιπλώνεται σε πολλαπλές γραμμές. Το παράδειγμα αυξάνει το ελάχιστο σε 100 σημεία, έπειτα το μειώνει σε 20 σημεία, εκτυπώνει το πραγματικό ύψος μετά από κάθε αλλαγή, και αποθηκεύει και τα δύο αποτελέσματα.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("row-height-input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $row = $table->getRows()->get_Item(0);

    $row->setMinimalHeight(100);
    printf("Increased: minimum = %.1f, actual = %.1f pt\n", java_values($row->getMinimalHeight()), java_values($row->getHeight()));
    $presentation->save("row-height-increased.pptx", SaveFormat::Pptx);

    $row->setMinimalHeight(20);
    printf("Decreased: minimum = %.1f, actual = %.1f pt\n", java_values($row->getMinimalHeight()), java_values($row->getHeight()));
    $presentation->save("row-height-decreased.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Με την παρεχόμενη παρουσίαση, η αύξηση του ελάχιστου προσθέτει χώρο στη γραμμή. Η μείωση αφαιρεί αυτόν τον επιπλέον χώρο, αλλά το πραγματικό ύψος παραμένει μεγαλύτερο από 20 σημεία επειδή το κείμενο και τα περιθώρια των κελιών χρειάζονται περισσότερο χώρο. Η μόνο μείωση του ελάχιστου δεν μπορεί να οδηγήσει τη γραμμή κάτω από το χώρο που απαιτεί το περιεχόμενό της.

Πολλοί παράγοντες επηρεάζουν το πραγματικό ύψος:
- **Κείμενο και μέγεθος γραμματοσειράς:** το μεγαλύτερο κείμενο, οι ρητοί αλλαγές γραμμής ή μια μεγαλύτερη γραμματοσειρά μπορεί να απαιτούν περισσότερη κάθετη διάστημα.
- **Αναδίπλωση και πλάτος στήλης:** με ενεργοποιημένη την αναδίπλωση, η μείωση του πλάτους της στήλης με τη μέθοδο [Column::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/column/setwidth/) μπορεί να δημιουργήσει περισσότερες γραμμές. Μια πιο ευρεία στήλη μπορεί να μειώσει το απαιτούμενο κάθετο διάστημα.
- **Περιθώρια κελιού:** οι μέθοδοι [Cell::setMarginTop](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmargintop/) και [Cell::setMarginBottom](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginbottom/) προσθέτουν κάθετο διάστημα. Οι [Cell::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginleft/) και [Cell::setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginright/) μειώνουν το διαθέσιμο πλάτος για το κείμενο και μπορούν να προκαλέσουν πρόσθετη αναδίπλωση.

Για αυτόν τον πίνακα χωρίς συγχωνευμένα κελιά, το κελί που χρειάζεται το περισσότερο κάθετο διάστημα καθορίζει το όριο κατώτερου επιπέδου για ολόκληρη τη γραμμή. Για να μειώσετε το ύψος της γραμμής, ίσως χρειαστεί να συντομεύσετε το κείμενο, να μειώσετε το μέγεθος γραμματοσειράς ή τα περιθώρια, ή να διευρύνετε μια στήλη.

Τα παρακάτω εικόνες δείχνουν τον ίδιο πίνακα στην ίδια κλίμακα. Σ τα παραδειγμένα αποτελέσματα, τα πραγματικά ύψη ήταν 70, 100 και 55,2 σημεία: η τελική γραμμή παρέμεινε ψηλότερη από το ελάχιστο των 20 σημείων. Οι ακριβείς μετρήσεις κειμένου μπορεί να διαφέρουν ανάλογα με τις γραμματοσειρές που είναι διαθέσιμες στο περιβάλλον σας. Κατεβάστε τα αποθηκευμένα αποτελέσματα: [αυξημένο ελάχιστο](row-height-increased.pptx) και [μειωμένο ελάχιστο](row-height-decreased.pptx).

| Αρχικό: ελάχιστο 70 pt, πραγματικό 70 pt | Αυξημένο: ελάχιστο 100 pt, πραγματικό 100 pt | Μειωμένο: ελάχιστο 20 pt, πραγματικό 55.2 pt |
| --- | --- | --- |
| ![Αρχικός πίνακας με πρώτη σειρά 70 σημείων.](row-height-before.png) | ![Πίνακας μετά την αύξηση του ελάχιστου της πρώτης σειράς σε 100 σημεία.](row-height-increased.png) | ![Πίνακας μετά τη μείωση του ελάχιστου της πρώτης σειράς σε 20 σημεία· το αναδιπλωμένο κείμενο κρατά τη σειρά ψηλότερη από το ελάχιστο.](row-height-decreased.png) |

## **Ορισμός της Πρώτης Γραμμής ως Κεφαλίδα**

Χρησιμοποιήστε τη μέθοδο [setFirstRow](https://reference.aspose.com/slides/php-java/aspose.slides/table/setfirstrow/) για να σημαδέψετε την πρώτη γραμμή για μορφοποίηση κεφαλίδας. Η εμφάνισή της εξαρτάται από το στυλ πίνακα που εφαρμόζεται στον πίνακα.

1. Φορτώστε την παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Πρόσβαση στην πρώτη διαφάνεια.
3. Πρόσβαση στον πίνακα που αποθηκεύεται ως το πρώτο σχήμα στη διαφάνεια.
4. Ενεργοποίηση της μορφοποίησης κεφαλίδας για την πρώτη του γραμμή.
5. Αποθήκευση της τροποποιημένης παρουσίασης.

Το παράδειγμα απαιτεί το `table.pptx` με έναν πίνακα ως το πρώτο σχήμα στην πρώτη διαφάνεια. Ενεργοποιεί τη μορφοποίηση κεφαλίδας για την πρώτη γραμμή και αποθηκεύει το `First_row_header.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $table->setFirstRow(true);

    $presentation->save("First_row_header.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Κλωνοποίηση Γραμμής ή Στήλης Πίνακα**

Κλωνοποιήστε γραμμές ή στήλες για να επαναχρησιμοποιήσετε το περιεχόμενό τους και τη μορφοποίησή τους. Μπορείτε να προσαρτήσετε ένα αντίγραφο στο τέλος του πίνακα ή να το εισάγετε σε συγκεκριμένη θέση.

1. Φορτώστε την παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Πρόσβαση στην πρώτη διαφάνεια.
3. Ορισμός του πλάτους των στηλών και του ύψους των γραμμών.
4. Προσθήκη πίνακα με τη μέθοδο [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/).
5. Κλωνοποίηση των απαιτούμενων γραμμών.
6. Κλωνοποίηση των απαιτούμενων στηλών.
7. Αποθήκευση της τροποποιημένης παρουσίασης.

Το παράδειγμα απαιτεί το `Test.pptx` με τουλάχιστον μία διαφάνεια. Δημιουργεί έναν πίνακα με τρεις στήλες και πέντε γραμμές, με διαστάσεις καθορισμένες σε σημεία. Προσθέτει αντίγραφα της πρώτης γραμμής και στήλης, έπειτα εισάγει αντίγραφα της δεύτερης γραμμής και στήλης στην θέση 3 (στην τέταρτη θέση). Ο resulting πίνακας έχει επτά γραμμές και πέντε στήλες. Το επιχείρημα `false` απενεργοποιεί την κλωνοποίηση σε γειτονικές συγχωνευμένες γραμμές ή στήλες· αυτός ο πίνακας δεν έχει συγχωνευμένα κελιά.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Test.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [50, 50, 50];
    $rowHeights = [50, 30, 30, 30, 30];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->get_Item(0, 0)->getTextFrame()->setText("Row 1 Cell 1");
    $table->get_Item(1, 0)->getTextFrame()->setText("Row 1 Cell 2");
    $table->getRows()->addClone($table->getRows()->get_Item(0), false);

    $table->get_Item(0, 1)->getTextFrame()->setText("Row 2 Cell 1");
    $table->get_Item(1, 1)->getTextFrame()->setText("Row 2 Cell 2");
    $table->getRows()->insertClone(3, $table->getRows()->get_Item(1), false);

    $table->getColumns()->addClone($table->getColumns()->get_Item(0), false);
    $table->getColumns()->insertClone(3, $table->getColumns()->get_Item(1), false);

    $presentation->save("table_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Αφαίρεση Γραμμής ή Στήλης από Πίνακα**

Αφαιρέστε γραμμές ή στήλες που δεν χρειάζονται πλέον σε έναν πίνακα. Η αφαίρεση ενός στοιχείου μετατοπίζει τους δείκτες των γραμμών ή στηλών που ακολουθούν.

1. Δημιουργία παρουσίασης με την κλάση [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Πρόσβαση στην πρώτη διαφάνεια.
3. Ορισμός του πλάτους των στηλών και του ύψους των γραμμών.
4. Προσθήκη πίνακα με τη μέθοδο [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/).
5. Αφαίρεση της δεύτερης γραμμής και της δεύτερης στήλης.
6. Αποθήκευση της τροποποιημένης παρουσίασης.

Αυτό το παράδειγμα δημιουργεί έναν πίνακα τριών επί τριών και αφαιρεί τη γραμμή και τη στήλη στη θέση 1, αφήνοντας έναν πίνακα δύο επί δύο στο `TestTable_out.pptx`. Οι διαστάσεις είναι σε σημεία. Το επιχείρημα `false` απενεργοποιεί την αφαίρεση γειτονικών συγχωνευμένων γραμμών ή στηλών· αυτός ο πίνακας δεν έχει συγχωνευμένα κελιά.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [100, 50, 30];
    $rowHeights = [30, 50, 30];
    $table = $slide->getShapes()->addTable(100, 100, $columnWidths, $rowHeights);

    $table->getRows()->removeAt(1, false);
    $table->getColumns()->removeAt(1, false);

    $presentation->save("TestTable_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ορισμός Μορφοποίησης Κειμένου σε Επίπεδο Γραμμής Πίνακα**

Εφαρμόστε μορφοποίηση κειμένου σε ολόκληρη τη γραμμή για να διατηρήσετε τα κελιά της συνεπή. Μπορείτε να ορίσετε ιδιότητες γραμματοσειράς, μορφοποίηση παραγράφου και κατεύθυνση κειμένου χωρίς να μορφοποιήσετε κάθε κελί ξεχωριστά.

1. Φορτώστε την παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Πρόσβαση στον πίνακα στην πρώτη διαφάνεια.
3. Χρησιμοποιήστε το [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) για την πρώτη γραμμή.
4. Χρησιμοποιήστε τα [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) και [setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) για την πρώτη γραμμή.
5. Χρησιμοποιήστε το [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) για τη δεύτερη γραμμή.
6. Αποθήκευση της τροποποιημένης παρουσίασης.

Το παράδειγμα απαιτεί το `table.pptx` με έναν πίνακα ως το πρώτο σχήμα στην πρώτη διαφάνεια και τουλάχιστον δύο γραμμές. Εφαρμόζει κείμενο 25 σημείων, δεξιά στοίχιση και περιθώριο παραγράφου 20 σημειών στα δεξιά στην πρώτη γραμμή, και στη συνέχεια ορίζει κάθετο κείμενο στη δεύτερη γραμμή.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PortionFormat;
use aspose\slides\ParagraphFormat;
use aspose\slides\TextFrameFormat;
use aspose\slides\TextAlignment;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);

    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $table->getRows()->get_Item(0)->setTextFormat($portionFormat);

    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $table->getRows()->get_Item(0)->setTextFormat($paragraphFormat);

    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $table->getRows()->get_Item(1)->setTextFormat($textFrameFormat);

    $presentation->save("row_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ορισμός Μορφοποίησης Κειμένου σε Επίπεδο Στήλης Πίνακα**

Εφαρμόστε μορφοποίηση κειμένου σε ολόκληρη τη στήλη για να διατηρήσετε τα κελιά της συνεπή. Μπορείτε να ορίσετε ιδιότητες γραμματοσειράς, μορφοποίηση παραγράφου και κατεύθυνση κειμένου χωρίς να μορφοποιήσετε κάθε κελί ξεχωριστά.

1. Φορτώστε την παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Πρόσβαση στον πίνακα στην πρώτη διαφάνεια.
3. Χρησιμοποιήστε το [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) για την πρώτη στήλη.
4. Χρησιμοποιήστε τα [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) και [setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) για την πρώτη στήλη.
5. Χρησιμοποιήστε το [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) για τη δεύτερη στήλη.
6. Αποθήκευση της τροποποιημένης παρουσίασης.

Το παράδειγμα απαιτεί το `table.pptx` με έναν πίνακα ως το πρώτο σχήμα στην πρώτη διαφάνεια και τουλάχιστον δύο στήλες. Εφαρμόζει κείμενο 25 σημείων, δεξιά στοίχιση και περιθώριο παραγράφου 20 σημείων στα δεξιά στην πρώτη στήλη, και στη συνέχεια ορίζει κάθετο κείμενο στη δεύτερη στήλη.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PortionFormat;
use aspose\slides\ParagraphFormat;
use aspose\slides\TextFrameFormat;
use aspose\slides\TextAlignment;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);

    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $table->getColumns()->get_Item(0)->setTextFormat($portionFormat);

    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $table->getColumns()->get_Item(0)->setTextFormat($paragraphFormat);

    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $table->getColumns()->get_Item(1)->setTextFormat($textFrameFormat);

    $presentation->save("column_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Λήψη Ιδιοτήτων Στυλ Πίνακα**

Χρησιμοποιήστε τη μέθοδο [getStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/getstylepreset/) για να ανακτήσετε το προεπιλεγμένο στυλ που εφαρμόζεται σε έναν πίνακα και να το επαναχρησιμοποιήσετε σε άλλο πίνακα. Αυτό εντοπίζει το προεπιλεγμένο στυλ αντί για τις ατομικές παρακάμψεις μορφοποίησης κελιών.

Το παράδειγμα δημιουργεί έναν πίνακα, εφαρμόζει το [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/php-java/aspose.slides/tablestylepreset/#DarkStyle1), και διαβάζει το προεπιλεγμένο στυλ πίσω. Εκτυπώνει την ακέραια τιμή που αντιστοιχεί στο `DarkStyle1` και αποθηκεύει τον πίνακα στο `table.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TableStylePreset;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [100, 150];
    $rowHeights = [5, 5, 5];
    $table = $slide->getShapes()->addTable(10, 10, $columnWidths, $rowHeights);
    $table->setStylePreset(TableStylePreset::DarkStyle1);

    $stylePreset = $table->getStylePreset();
    echo java_values($stylePreset) . PHP_EOL;

    $presentation->save("table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Συχνές Ερωτήσεις**

**Μπορώ να εφαρμόσω θέματα/στυλ PowerPoint σε έναν πίνακα που έχει ήδη δημιουργηθεί;**

Ναι. Ο πίνακας κληρονομεί το θέμα της διαφάνειας/διάταξης/κύριου, και μπορείτε ακόμη να παρακάμψετε τις γεμές, τα περιγράμματα και τα χρώματα κειμένου πάνω από αυτό το θέμα.

**Μπορώ να ταξινομήσω τις γραμμές του πίνακα όπως στο Excel;**

Όχι, οι πίνακες Aspose.Slides δεν διαθέτουν ενσωματωμένη ταξινόμηση ή φίλτρα. Ταξινομήστε τα δεδομένα σας στη μνήμη πρώτα, και στη συνέχεια επανασυμπληρώστε τις γραμμές του πίνακα με αυτή τη σειρά.

**Μπορώ να έχω ενωμένες (striped) στήλες ενώ διατηρώ προσαρμοσμένα χρώματα σε συγκεκριμένα κελιά;**

Ναι. Ενεργοποιήστε τις ενωμένες στήλες, έπειτα παρακάμψτε συγκεκριμένα κελιά με τοπική μορφοποίηση· η μορφοποίηση επιπέδου κελιού έχει προτεραιότητα πάνω από το στυλ του πίνακα.