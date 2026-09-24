---
title: Προσαρμογή Πίνακων Δεδομένων Διαγραμμάτων σε Παρουσιάσεις χρησιμοποιώντας JavaScript
linktitle: Πίνακας Δεδομένων
type: docs
url: /el/nodejs-java/chart-data-table/
keywords:
- δεδομένα διαγράμματος
- πίνακας δεδομένων
- ιδιότητες γραμματοσειράς
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Προσαρμόστε τις γραμματοσειρές, τα περιθώρια και τα κλειδιά υπομνήματος των πινάκων δεδομένων διαγράμματος σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides για Node.js μέσω Java."
---
## **Επισκόπηση**

Aspose.Slides for Node.js via Java σάς επιτρέπει να εμφανίσετε τον πίνακα δεδομένων ενός διαγράμματος και να προσαρμόσετε τη μορφοποίηση του κειμένου, τα περιθώρια και τα κλειδιά υπομνήματος. Αυτό το άρθρο εξηγεί πώς να ενεργοποιήσετε τον πίνακα, να μορφοποιήσετε το κείμενο, να ελέγξετε κάθε τύπο περιθωρίου και να εμφανίσετε ή να αποκρύψετε τα κλειδιά υπομνήματος. Τα παραδείγματα αποθηκεύουν τα ρυθμισμένα διαγράμματα σε αρχεία PPTX.

## **Ορισμός Ιδιοτήτων Γραμματοσειράς**

Για να εμφανίσετε τον πίνακα δεδομένων ενός διαγράμματος, περάστε το `true` στο [setDataTable](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chart/setdatatable/). Χρησιμοποιήστε το [getChartDataTable](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chart/getchartdatatable/) για να αποκτήσετε πρόσβαση στον πίνακα και να διαμορφώσετε τη μορφοποίηση του κειμένου.

1. Φορτώστε την παρουσίαση χρησιμοποιώντας την κλάση [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/).
1. Προσθέστε ένα διασπαρμένο ρά柱ειο στήλης στην πρώτη διαφάνεια.
1. Ενεργοποιήστε τον πίνακα δεδομένων του διαγράμματος.
1. Ενεργοποιήστε το έντονο κείμενο με το [setFontBold](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/baseportionformat/#setfontbold) και περάστε το `20` στο [setFontHeight](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/baseportionformat/#setfontheight) για κείμενο 20 σημείων.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το ακόλουθο παράδειγμα απαιτεί το `input.pptx` στον τρέχοντα φάκελο εργασίας με τουλάχιστον μία διαφάνεια. Προσθέτει ένα διάγραμμα με προεπιλεγμένα δεδομένα στη θέση (50, 50), με πλάτος 600 σημεία και ύψος 400 σημεία. Το αποθηκευμένο `output.pptx` περιέχει το διάγραμμα με ενεργό τον πίνακα δεδομένων και τις καθορισμένες ρυθμίσεις γραμματοσειράς.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    const portionFormat = chart.getChartDataTable().getTextFormat().getPortionFormat();
    portionFormat.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    portionFormat.setFontHeight(20);

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Προσαρμογή Περιθωρίων Πίνακα Δεδομένων**

Ενεργοποιήστε τον πίνακα με το [Chart.setDataTable](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chart/setdatatable/) και αποκτήστε πρόσβαση μέσω του [Chart.getChartDataTable](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chart/getchartdatatable/). Μπορείτε να ελέγξετε τρεις τύπους περιθωρίων ανεξάρτητα:

- Το [setBorderHorizontal](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/datatable/setborderhorizontal/) ελέγχει τα οριζόντια περιθώρια των κελιών.
- Το [setBorderVertical](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/datatable/setbordervertical/) ελέγχει τα κάθετα περιθώρια των κελιών.
- Το [setBorderOutline](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/datatable/setborderoutline/) ελέγχει το εξωτερικό περιθώριο του πίνακα.

Περάστε το `true` σε κάθε μέθοδο για να εμφανίσετε τα περιθώρια ή το `false` για να τα αποκρύψετε. Το παρακάτω παράδειγμα δημιουργεί ένα διασπαρμένο ρά柱ειο στήλης με προεπιλεγμένα δεδομένα, εμφανίζει τα οριζόντια περιθώρια και το εξωτερικό περιθώριο, και αποκρύπτει τα κάθετα περιθώρια. Δεν απαιτείται αρχείο εισόδου. Η θέση και το μέγεθος του διαγράμματος καθορίζονται σε σημεία.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    const dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(false);
    dataTable.setBorderOutline(true);

    presentation.save("data-table-borders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η σύγκριση παρακάτω χρησιμοποιεί τα ίδια δεδομένα διαγράμματος και τις ίδιες ρυθμίσεις κλειδιού υπομνήματος σε όλες τις τέσσερις περιπτώσεις. Ξεκινώντας με όλα τα περιθώρια ενεργά, κάθε επόμενη παραλλαγή απενεργοποιεί μόνο ένα περιθώριο. Η παραλλαγή κάτω αριστερά ταιριάζει με τις ρυθμίσεις περιθωρίων του παραδείγματος.

![Πίνακες δεδομένων διαγράμματος με όλα τα περιθώρια ενεργά, χωρίς οριζόντια περιθώρια, χωρίς κάθετα περιθώρια και χωρίς εξωτερικό περιθώριο](data-table-borders.png)

## **Εμφάνιση ή Απόκρυψη Κλειδιών Υπόμνησης**

Τα κλειδιά υπομνήματος είναι μικρά χρωματιστά σύμβολα δίπλα στα ονόματα των σειρών στον πίνακα δεδομένων. Βοηθούν τον αναγνώστη να αντιστοιχίσει κάθε σειρά του πίνακα σε μια σειρά του διαγράμματος. Περάστε το `true` στο [setShowLegendKey](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/datatable/setshowlegendkey/) για να εμφανίσετε αυτά τα σύμβολα ή το `false` για να τα αποκρύψετε.

Το ξεχωριστό υπόμνημα του διαγράμματος ελέγχεται από το [Chart.setLegend](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chart/setlegend/). Αυτές οι ρυθμίσεις είναι ανεξάρτητες: η απόκρυψη του ξεχωριστού υπομνήματος δεν αποκρύπτει τα κλειδιά μέσα στον πίνακα δεδομένων, και η απόκρυψη των κλειδιών του πίνακα δεν αποκρύπτει το ξεχωριστό υπόμνημα.

Το παρακάτω παράδειγμα δημιουργεί ένα διάγραμμα με προεπιλεγμένα δεδομένα, ενεργοποιεί τον πίνακα δεδομένων και εμφανίζει τα κλειδιά υπομνήματος μέσα σε αυτό ενώ αποκρύπτει το ξεχωριστό υπόμνημα. Όλα τα περιθώρια του πίνακα είναι ρητά ενεργά. Δεν απαιτείται παρουσίαση εισόδου. Για να αποκρύψετε μόνο τα κλειδιά του πίνακα, περάστε το `false` στο [setShowLegendKey](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/datatable/setshowlegendkey/).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.setLegend(false);

    const dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(true);
    dataTable.setBorderOutline(true);
    dataTable.setShowLegendKey(true);

    presentation.save("data-table-legend-keys.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η σύγκριση παρακάτω εμφανίζει τον ίδιο πίνακα με τα κλειδιά υπομνήματος ενεργά και ανενεργά. Όλα τα περιθώρια παραμένουν ενεργά, και το ξεχωριστό υπόμνημα του διαγράμματος είναι κρυφό και στις δύο περιπτώσεις.

![Πίνακες δεδομένων διαγράμματος με κλειδιά υπομνήματος εμφανισμένα στα αριστερά και κρυμμένα στα δεξιά](data-table-legend-keys.png)

## **Συχνές Ερωτήσεις**

**Μπορώ να εμφανίσω κλειδιά υπομνήματος στον πίνακα δεδομένων ενός διαγράμματος;**

Ναι. Περάστε το `true` στο [setShowLegendKey](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/datatable/setshowlegendkey/) για να εμφανίσετε τα κλειδιά υπομνήματος ή το `false` για να τα αποκρύψετε.

**Θα διατηρηθεί ο πίνακας δεδομένων κατά την εξαγωγή της παρουσίασης σε PDF, HTML ή εικόνες;**

Ναι. Το Aspose.Slides αποδίδει το διάγραμμα και τον εμφανιζόμενο πίνακα δεδομένων ως μέρος της διαφάνειας κατά την εξαγωγή σε [PDF](/slides/el/nodejs-java/convert-powerpoint-to-pdf/), [HTML](/slides/el/nodejs-java/convert-powerpoint-to-html/) ή [images](/slides/el/nodejs-java/convert-powerpoint-to-png/).

**Μπορώ να δουλέψω με πίνακες δεδομένων σε διαγράμματα που φορτώνονται από πρότυπο;**

Ναι. Για ένα διάγραμμα που φορτώνεται από υπάρχουσα παρουσίαση ή πρότυπο, χρησιμοποιήστε το [hasDataTable](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chart/hasdatatable/) και το [setDataTable](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chart/setdatatable/) για να ελέγξετε ή να αλλάξετε αν ο πίνακας δεδομένων εμφανίζεται.

**Πώς μπορώ να βρω διαγράμματα που έχουν ενεργοποιημένο πίνακα δεδομένων;**

Περιηγηθείτε στα σχήματα κάθε διαφάνειας, εντοπίστε τα διαγράμματα και καλέστε τη μέθοδο τους [hasDataTable](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chart/hasdatatable/). Μια τιμή `true` υποδεικνύει ότι ο πίνακας δεδομένων είναι ενεργός.