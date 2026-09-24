---
title: Προσαρμογή Πινάκων Δεδομένων Διαγραμμάτων σε Παρουσιάσεις Χρησιμοποιώντας PHP
linktitle: Πίνακας Δεδομένων
type: docs
url: /el/php-java/chart-data-table/
keywords:
- δεδομένα διαγράμματος
- πίνακας δεδομένων
- ιδιότητες γραμματοσειράς
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Προσαρμόστε τις γραμματοσειρές, τα περιγράμματα και τα κλειδιά υπομνήματος του πίνακα δεδομένων διαγράμματος σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides για PHP μέσω Java."
---
## **Επισκόπηση**

Το Aspose.Slides for PHP μέσω Java σάς επιτρέπει να εμφανίσετε τον πίνακα δεδομένων ενός διαγράμματος και να προσαρμόσετε τη μορφοποίηση του κειμένου, τα περιγράμματα και τα κλειδιά υπομνήματος. Αυτό το άρθρο εξηγεί πώς να ενεργοποιήσετε τον πίνακα, να μορφοποιήσετε το κείμενό του, να ελέγξετε κάθε τύπο περιγράμματος και να εμφανίσετε ή να αποκρύψετε τα κλειδιά υπομνήματος. Τα παραδείγματα αποθηκεύουν τα ρυθμισμένα διαγράμματα σε αρχεία PPTX.

## **Ορισμός Ιδιοτήτων Γραμματοσειράς**

Για να εμφανίσετε τον πίνακα δεδομένων ενός διαγράμματος, περάστε `true` στη μέθοδο [setDataTable](https://reference.aspose.com/slides/el/php-java/aspose.slides/chart/setdatatable/). Χρησιμοποιήστε [getChartDataTable](https://reference.aspose.com/slides/el/php-java/aspose.slides/chart/getchartdatatable/) για να προσπελάσετε τον πίνακα και να διαμορφώσετε τη μορφοποίηση του κειμένου.

1. Φορτώστε την παρουσίαση χρησιμοποιώντας την κλάση [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
2. Προσθέστε ένα στήλης σε ομάδα διάγραμμα στην πρώτη διαφάνεια.
3. Ενεργοποιήστε τον πίνακα δεδομένων του διαγράμματος.
4. Ενεργοποιήστε το έντονο κείμενο με τη μέθοδο [setFontBold](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseportionformat/#setFontBold) και περάστε `20` στη μέθοδο [setFontHeight](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseportionformat/#setFontHeight) για κείμενο 20 σημείων.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα απαιτεί το αρχείο `test.pptx` στον τρέχοντα κατάλογο με τουλάχιστον μία διαφάνεια. Προσθέτει ένα διάγραμμα με προεπιλεγμένα δεδομένα στη θέση (50, 50), με πλάτος 600 σημείων και ύψος 400 σημείων. Το αποθηκευμένο `output.pptx` περιέχει το διάγραμμα με ενεργοποιημένο τον πίνακα δεδομένων του και τις καθορισμένες ρυθμίσεις γραμματοσειράς.

```php
use aspose\slides\ChartType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("test.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);

    $portionFormat = $chart->getChartDataTable()->getTextFormat()->getPortionFormat();
    $portionFormat->setFontBold(NullableBool::True);
    $portionFormat->setFontHeight(20);

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Προσαρμογή Περιγραμμάτων Πίνακα Δεδομένων**

Ενεργοποιήστε τον πίνακα με τη μέθοδο [Chart::setDataTable](https://reference.aspose.com/slides/el/php-java/aspose.slides/chart/setdatatable/) και προσπελάστε το μέσω της μεθόδου [Chart::getChartDataTable](https://reference.aspose.com/slides/el/php-java/aspose.slides/chart/getchartdatatable/). Μπορείτε να ελέγξετε τρεις τύπους περιγραμμάτων ανεξάρτητα:

- Ο [setBorderHorizontal](https://reference.aspose.com/slides/el/php-java/aspose.slides/datatable/setborderhorizontal/) ελέγχει τα οριζόντια περιγράμματα των κελιών.
- Ο [setBorderVertical](https://reference.aspose.com/slides/el/php-java/aspose.slides/datatable/setbordervertical/) ελέγχει τα κάθετα περιγράμματα των κελιών.
- Ο [setBorderOutline](https://reference.aspose.com/slides/el/php-java/aspose.slides/datatable/setborderoutline/) ελέγχει το εξωτερικό περίγραμμα του πίνακα.

Περάστε `true` σε κάθε μέθοδο για να εμφανίσετε τα περιγράμματά του ή `false` για να τα αποκρύψετε. Το παρακάτω παράδειγμα δημιουργεί ένα στήλης σε ομάδα διάγραμμα με προεπιλεγμένα δεδομένα, εμφανίζει τα οριζόντια περιγράμματα και το εξωτερικό περίγραμμα, και αποκρύπτει τα κάθετα περιγράμματα. Δεν απαιτείται αρχείο εισόδου. Η θέση και το μέγεθος του διαγράμματος ορίζονται σε σημεία.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);

    $dataTable = $chart->getChartDataTable();
    $dataTable->setBorderHorizontal(true);
    $dataTable->setBorderVertical(false);
    $dataTable->setBorderOutline(true);

    $presentation->save("data-table-borders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Η σύγκριση παρακάτω χρησιμοποιεί τα ίδια δεδομένα διαγράμματος και την ίδια ρύθμιση κλειδιού υπομνήματος και στις τέσσερις περιπτώσεις. Ξεκινώντας με όλα τα περιγράμματα ενεργοποιημένα, κάθε υπόλοιπο σενάριο απενεργοποιεί μόνο μία ρύθμιση περιγράμματος. Η παραλλαγή κάτω‑αριστερά ταιριάζει με τις ρυθμίσεις περιγράμματος του παραδείγματος.

![Διαγράμματα δεδομένων με όλα τα περιγράμματα ενεργοποιημένα, χωρίς οριζόντια περιγράμματα, χωρίς κάθετα περιγράμματα και χωρίς εξωτερικό περίγραμμα](data-table-borders.png)

## **Εμφάνιση ή Απόκρυψη Κλειδιών Υπομνήματος**

Τα κλειδιά υπομνήματος είναι μικροί χρωματιστοί δείκτες δίπλα στα ονόματα των σειρών στον πίνακα δεδομένων. Βοηθούν τους αναγνώστες να αντιστοιχίσουν κάθε γραμμή του πίνακα με μία σειρά διαγράμματος. Περάστε `true` στη μέθοδο [setShowLegendKey](https://reference.aspose.com/slides/el/php-java/aspose.slides/datatable/setshowlegendkey/) για να εμφανίσετε αυτούς τους δείκτες ή `false` για να τους αποκρύψετε.

Το ξεχωριστό υπόμνημα του διαγράμματος ελέγχεται από τη μέθοδο [Chart::setLegend](https://reference.aspose.com/slides/el/php-java/aspose.slides/chart/setlegend/). Οι ρυθμίσεις είναι ανεξάρτητες: η απόκρυψη του ξεχωριστού υπομνήματος δεν κρύβει τα κλειδιά μέσα στον πίνακα δεδομένων και η απόκρυψη των κλειδιών του πίνακα δεν κρύβει το ξεχωριστό υπόμνημα.

Το παρακάτω παράδειγμα δημιουργεί ένα διάγραμμα με προεπιλεγμένα δεδομένα, ενεργοποιεί τον πίνακα δεδομένων του και εμφανίζει τα κλειδιά υπομνήματος μέσα σε αυτό, ενώ αποκρύπτει το ξεχωριστό υπόμνημα. Όλα τα περιγράμματα του πίνακα είναι ρητά ενεργοποιημένα. Δεν απαιτείται παρουσίαση εισόδου. Για να αποκρύψετε μόνο τα κλειδιά του πίνακα, περάστε `false` στη μέθοδο [setShowLegendKey](https://reference.aspose.com/slides/el/php-java/aspose.slides/datatable/setshowlegendkey/).

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);
    $chart->setLegend(false);

    $dataTable = $chart->getChartDataTable();
    $dataTable->setBorderHorizontal(true);
    $dataTable->setBorderVertical(true);
    $dataTable->setBorderOutline(true);
    $dataTable->setShowLegendKey(true);

    $presentation->save("data-table-legend-keys.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Η σύγκριση παρακάτω δείχνει τον ίδιο πίνακα με τα κλειδιά υπομνήματος ενεργοποιημένα και απενεργοποιημένα. Όλα τα περιγράμματα παραμένουν ενεργά, και το ξεχωριστό υπόμνημα του διαγράμματος είναι κρυφό και στις δύο περιπτώσεις.

![Διαγράμματα δεδομένων με κλειδιά υπομνήματος εμφανισμένα στα αριστερά και κρυμμένα στα δεξιά](data-table-legend-keys.png)

## **ΣΥΧΝΑ ΕΡΩΤΗΜΑΤΑ**

**Μπορώ να εμφανίσω κλειδιά υπομνήματος στον πίνακα δεδομένων ενός διαγράμματος;**

Ναι. Περάστε `true` στη μέθοδο [setShowLegendKey](https://reference.aspose.com/slides/el/php-java/aspose.slides/datatable/setshowlegendkey/) για να εμφανίσετε τα κλειδιά υπομνήματος ή `false` για να τα αποκρύψετε.

**Θα διατηρηθεί ο πίνακας δεδομένων κατά την εξαγωγή της παρουσίασης σε PDF, HTML ή εικόνες;**

Ναι. Το Aspose.Slides αποδίδει το διάγραμμα και τον εμφανιζόμενο πίνακα δεδομένων του ως μέρος της διαφάνειας κατά την εξαγωγή σε [PDF](/slides/el/php-java/convert-powerpoint-to-pdf/), [HTML](/slides/el/php-java/convert-powerpoint-to-html/) ή [images](/slides/el/php-java/convert-powerpoint-to-png/).

**Μπορώ να δουλέψω με πίνακες δεδομένων σε διαγράμματα που φορτώνονται από πρότυπο;**

Ναι. Για ένα διάγραμμα που έχει φορτωθεί από υπάρχουσα παρουσίαση ή πρότυπο, χρησιμοποιήστε τις μεθόδους [hasDataTable](https://reference.aspose.com/slides/el/php-java/aspose.slides/chart/hasdatatable/) και [setDataTable](https://reference.aspose.com/slides/el/php-java/aspose.slides/chart/setdatatable/) για να ελέγξετε ή να αλλάξετε αν ο πίνακας δεδομένων εμφανίζεται.

**Πώς μπορώ να βρω διαγράμματα που έχουν ενεργοποιημένο πίνακα δεδομένων;**

Διέλθετε τα σχήματα σε κάθε διαφάνεια, εντοπίστε τα διαγράμματα και καλέστε τη μέθοδο [hasDataTable](https://reference.aspose.com/slides/el/php-java/aspose.slides/chart/hasdatatable/) τους. Μια τιμή `true` υποδεικνύει ότι ο πίνακας δεδομένων είναι ενεργοποιημένος.