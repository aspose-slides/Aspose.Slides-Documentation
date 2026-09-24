---
title: Προσαρμογή πινάκων δεδομένων διαγραμμάτων σε παρουσιάσεις στο Android
linktitle: Πίνακας δεδομένων
type: docs
url: /el/androidjava/chart-data-table/
keywords:
- δεδομένα διαγράμματος
- πίνακας δεδομένων
- ιδιότητες γραμματοσειράς
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Προσαρμόστε τις γραμματοσειρές, τα περιγράμματα και τα κλειδιά υπομνήματος του πίνακα δεδομένων διαγράμματος σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides για Android μέσω Java."
---
## **Επισκόπηση**

Το Aspose.Slides for Android μέσω Java σάς επιτρέπει να εμφανίσετε τον πίνακα δεδομένων ενός διαγράμματος και να προσαρμόσετε τη μορφοποίηση του κειμένου, τα πλαίσια και τα κλειδιά υπομνήματος. Αυτό το άρθρο εξηγεί πώς να ενεργοποιήσετε τον πίνακα, να μορφοποιήσετε το κείμενό του, να ελέγξετε κάθε τύπο πλαισίου και να εμφανίσετε ή να αποκρύψετε τα κλειδιά υπομνήματος. Τα παραδείγματα αποθηκεύουν τα ρυθμισμένα διαγράμματα σε αρχεία PPTX.

## **Ορισμός ιδιοτήτων γραμματοσειράς**

Για να εμφανίσετε τον πίνακα δεδομένων ενός διαγράμματος, περάστε `true` στη μέθοδο [setDataTable](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/chart/#setDataTable-boolean-). Χρησιμοποιήστε [getChartDataTable](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/chart/#getChartDataTable--) για να έχετε πρόσβαση στον πίνακα και να διαμορφώσετε τη μορφοποίηση του κειμένου.

1. Φορτώστε την παρουσίαση χρησιμοποιώντας την κλάση [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/).
1. Προσθέστε ένα συγκροτημένο γράφημα στήλης στην πρώτη διαφάνεια.
1. Ενεργοποιήστε τον πίνακα δεδομένων του διαγράμματος.
1. Ενεργοποιήστε το έντονο κείμενο με τη μέθοδο [setFontBold](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/baseportionformat/#setFontBold-byte-) και περάστε `20` στη μέθοδο [setFontHeight](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) για κείμενο 20 σημείων.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα απαιτεί το αρχείο `test.pptx` στον τρέχοντα φάκελο με τουλάχιστον μία διαφάνεια. Προσθέτει ένα γράφημα με προεπιλεγμένα δεδομένα στη θέση (50, 50), με πλάτος 600 σημείων και ύψος 400 σημείων. Το αποθηκευμένο `output.pptx` περιέχει το γράφημα με ενεργοποιημένο τον πίνακα δεδομένων και τις καθορισμένες ρυθμίσεις γραμματοσειράς.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    IChartPortionFormat portionFormat = chart.getChartDataTable().getTextFormat().getPortionFormat();
    portionFormat.setFontBold(NullableBool.True);
    portionFormat.setFontHeight(20);

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Προσαρμογή περιγραμμάτων πίνακα δεδομένων**

Ενεργοποιήστε τον πίνακα με τη μέθοδο [IChart.setDataTable](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichart/#setDataTable-boolean-) και αποκτήστε πρόσβαση σε αυτόν μέσω της [IChart.getChartDataTable](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichart/#getChartDataTable--). Μπορείτε να ελέγξετε τρεις τύπους πλαισίων ανεξάρτητα:

- [setBorderHorizontal](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/idatatable/#setBorderHorizontal-boolean-) ελέγχει τα οριζόντια περιγράμματα των κελιών.
- [setBorderVertical](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/idatatable/#setBorderVertical-boolean-) ελέγχει τα κάθετα περιγράμματα των κελιών.
- [setBorderOutline](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/idatatable/#setBorderOutline-boolean-) ελέγχει το εξωτερικό περίγραμμα του πίνακα.

Περάστε `true` σε κάθε μέθοδο για να εμφανίσετε τα περιγράμματά της ή `false` για να τα αποκρύψετε. Το παρακάτω παράδειγμα δημιουργεί ένα συγκροτημένο γράφημα στήλης με προεπιλεγμένα δεδομένα, εμφανίζει τα οριζόντια περιγράμματα και το εξωτερικό περίγραμμα, και αποκρύπτει τα κάθετα περιγράμματα. Δεν απαιτεί αρχείο εισόδου. Η θέση και το μέγεθος του διαγράμματος καθορίζονται σε σημεία.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    IDataTable dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(false);
    dataTable.setBorderOutline(true);

    presentation.save("data-table-borders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η παρακάτω σύγκριση χρησιμοποιεί τα ίδια δεδομένα διαγράμματος και την ίδια ρύθμιση κλειδιού υπομνήματος σε όλες τις τέσσερις περιπτώσεις. Ξεκινώντας με όλα τα περιγράμματα ενεργοποιημένα, κάθε επόμενη παραλλαγή απενεργοποιεί μόνο μία ρύθμιση περιγράμματος. Η παραλλαγή κάτω‑αριστερά ταιριάζει με τις ρυθμίσεις περιγράμματος του παραδείγματος.

![Πίνακες δεδομένων διαγράμματος με όλα τα περιγράμματα ενεργοποιημένα, χωρίς οριζόντια περιγράμματα, χωρίς κάθετα περιγράμματα και χωρίς εξωτερικό περίγραμμα](data-table-borders.png)

## **Εμφάνιση ή απόκρυψη κλειδιών υπομνήματος**

Τα κλειδιά υπομνήματος είναι μικροί χρωματιστοί δείκτες δίπλα στα ονόματα σειρών στον πίνακα δεδομένων. Βοηθούν τους αναγνώστες να αντιστοιχίσουν κάθε γραμμή του πίνακα σε μια σειρά διαγράμματος. Περάστε `true` στη μέθοδο [setShowLegendKey](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/idatatable/#setShowLegendKey-boolean-) για να εμφανίσετε αυτούς τους δείκτες ή `false` για να τους αποκρύψετε.

Το ξεχωριστό υπόμνημα του διαγράμματος ελέγχεται από τη μέθοδο [IChart.setLegend](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichart/#setLegend-boolean-). Οι ρυθμίσεις αυτές είναι ανεξάρτητες: η απόκρυψη του ξεχωριστού υπομνήματος δεν κρύβει τα κλειδιά μέσα στον πίνακα δεδομένων, και η απόκρυψη των κλειδιών του πίνακα δεν κρύβει το ξεχωριστό υπόμνημα.

Το παρακάτω παράδειγμα δημιουργεί ένα γράφημα με προεπιλεγμένα δεδομένα, ενεργοποιεί τον πίνακα δεδομένων του και εμφανίζει τα κλειδιά υπομνήματος μέσα σε αυτό, ενώ αποκρύπτει το ξεχωριστό υπόμνημα. Όλα τα περιγράμματα του πίνακα είναι ρητά ενεργοποιημένα. Δεν απαιτείται παρουσίαση εισόδου. Για να αποκρύψετε μόνο τα κλειδιά του πίνακα, περάστε `false` στη μέθοδο [setShowLegendKey](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/idatatable/#setShowLegendKey-boolean-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.setLegend(false);

    IDataTable dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(true);
    dataTable.setBorderOutline(true);
    dataTable.setShowLegendKey(true);

    presentation.save("data-table-legend-keys.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η παρακάτω σύγκριση εμφανίζει τον ίδιο πίνακα με ενεργοποιημένα και απενεργοποιημένα τα κλειδιά υπομνήματος. Όλα τα περιγράμματα παραμένουν ενεργά, και το ξεχωριστό υπόμνημα του διαγράμματος είναι κρυφό και στις δύο περιπτώσεις.

![Πίνακες δεδομένων διαγράμματος με κλειδιά υπομνήματος εμφανισμένα αριστερά και κρυμμένα δεξιά](data-table-legend-keys.png)

## **Συχνές ερωτήσεις**

**Μπορώ να εμφανίσω κλειδιά υπομνήματος στον πίνακα δεδομένων ενός διαγράμματος;**

Ναι. Περάστε `true` στη μέθοδο [setShowLegendKey](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/datatable/#setShowLegendKey-boolean-) για να εμφανίσετε τα κλειδιά υπομνήματος ή `false` για να τα αποκρύψετε.

**Θα διατηρηθεί ο πίνακας δεδομένων κατά την εξαγωγή της παρουσίασης σε PDF, HTML ή εικόνες;**

Ναι. Το Aspose.Slides αποδίδει το γράφημα και τον εμφανιζόμενο πίνακα δεδομένων του ως μέρος της διαφάνειας κατά την εξαγωγή σε [PDF](/slides/el/androidjava/convert-powerpoint-to-pdf/), [HTML](/slides/el/androidjava/convert-powerpoint-to-html/), ή [images](/slides/el/androidjava/convert-powerpoint-to-png/).

**Μπορώ να εργαστώ με πίνακες δεδομένων σε γραφήματα που φορτώνονται από ένα πρότυπο;**

Ναι. Για ένα γράφημα που φορτώνεται από υπάρχουσα παρουσίαση ή πρότυπο, χρησιμοποιήστε τις μεθόδους [hasDataTable](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/chart/#hasDataTable--) και [setDataTable](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/chart/#setDataTable-boolean-) για να ελέγξετε ή να αλλάξετε αν ο πίνακας δεδομένων του εμφανίζεται.

**Πώς μπορώ να βρω γραφήματα που έχουν ενεργοποιημένο πίνακα δεδομένων;**

Διατρέξτε τα σχήματα σε κάθε διαφάνεια, εντοπίστε τα γραφήματα και καλέστε τη μέθοδο [hasDataTable](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/chart/#hasDataTable--). Μια τιμή `true` υποδεικνύει ότι ο πίνακας δεδομένων είναι ενεργοποιημένος.