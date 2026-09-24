---
title: Προσαρμογή Πινάκων Δεδομένων Διαγράμματος σε Παρουσιάσεις Χρησιμοποιώντας Python
linktitle: Πίνακας Δεδομένων
type: docs
url: /el/python-java/chart-data-table/
keywords:
- δεδομένα διαγράμματος
- πίνακας δεδομένων
- ιδιότητες γραμματοσειράς
- PowerPoint
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Προσαρμόστε τις γραμματοσειρές, τα όρια και τα κλειδιά υπομνήματος του πίνακα δεδομένων διαγράμματος σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides για Python μέσω Java."
---
## **Επισκόπηση**

Το Aspose.Slides για Python μέσω Java σάς επιτρέπει να εμφανίσετε τον πίνακα δεδομένων ενός διαγράμματος και να προσαρμόσετε τη μορφοποίηση του κειμένου, τα όρια και τα κλειδιά υπομνήματος. Αυτό το άρθρο εξηγεί πώς να ενεργοποιήσετε τον πίνακα, να μορφοποιήσετε το κείμενό του, να ελέγξετε κάθε τύπο ορίου και να εμφανίσετε ή να κρύψετε τα κλειδιά υπομνήματος. Τα παραδείγματα αποθηκεύουν τα διαμορφωμένα διαγράμματα σε αρχεία PPTX.

## **Ορισμός Ιδιότητων Γραμματοσειράς**

Για να εμφανίσετε τον πίνακα δεδομένων ενός διαγράμματος, περάστε `True` στη μέθοδο [setDataTable](https://reference.aspose.com/slides/el/python-java/aspose.slides/chart/#setDataTable). Χρησιμοποιήστε τη μέθοδο [getChartDataTable](https://reference.aspose.com/slides/el/python-java/aspose.slides/chart/#getChartDataTable) για να αποκτήσετε πρόσβαση στον πίνακα και να διαμορφώσετε τη μορφοποίηση του κειμένου του.

1. Φορτώστε την παρουσίαση χρησιμοποιώντας την κλάση [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/).
1. Προσθέστε ένα ομαδοποιημένο γράφημα στήλης στην πρώτη διαφάνεια.
1. Ενεργοποιήστε τον πίνακα δεδομένων του διαγράμματος.
1. Ενεργοποιήστε έντονο κείμενο με τη μέθοδο [setFontBold](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseportionformat/#setFontBold) και περάστε `20` στη μέθοδο [setFontHeight](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseportionformat/#setFontHeight) για κείμενο 20 σημείων.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα απαιτεί το αρχείο `test.pptx` στο τρέχον φάκελο με τουλάχιστον μία διαφάνεια. Προσθέτει ένα γράφημα με προεπιλεγμένα δεδομένα στη θέση (50, 50), με πλάτος 600 σημείων και ύψος 400 σημείων. Το αποθηκευμένο αρχείο `output.pptx` περιέχει το γράφημα με ενεργοποιημένο τον πίνακα δεδομένων και τις καθορισμένες ρυθμίσεις γραμματοσειράς.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

presentation = Presentation("test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)

    portion_format = chart.getChartDataTable().getTextFormat().getPortionFormat()
    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Προσαρμογή Ορίων Πίνακα Δεδομένων**

Ενεργοποιήστε τον πίνακα με τη μέθοδο [Chart.setDataTable](https://reference.aspose.com/slides/el/python-java/aspose.slides/chart/#setDataTable) και αποκτήστε πρόσβαση σε αυτόν μέσω της [Chart.getChartDataTable](https://reference.aspose.com/slides/el/python-java/aspose.slides/chart/#getChartDataTable). Μπορείτε να ελέγξετε τρεις τύπους ορίων ανεξάρτητα:

- [setBorderHorizontal](https://reference.aspose.com/slides/el/python-java/aspose.slides/datatable/#setBorderHorizontal) ελέγχει τα οριζόντια όρια των κελιών.
- [setBorderVertical](https://reference.aspose.com/slides/el/python-java/aspose.slides/datatable/#setBorderVertical) ελέγχει τα κατακόρυφα όρια των κελιών.
- [setBorderOutline](https://reference.aspose.com/slides/el/python-java/aspose.slides/datatable/#setBorderOutline) ελέγχει το εξωτερικό όριο του πίνακα.

Περάστε `True` σε κάθε μέθοδο για να εμφανίσετε τα αντίστοιχα όρια ή `False` για να τα κρύψετε. Το παρακάτω παράδειγμα δημιουργεί ένα ομαδοποιημένο γράφημα στήλης με προεπιλεγμένα δεδομένα, εμφανίζει τα οριζόντια όρια και το εξωτερικό όριο, και κρύβει τα κατακόρυφα όρια. Δεν απαιτεί αρχείο εισόδου. Η θέση και το μέγεθος του διαγράμματος καθορίζονται σε σημεία.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)

    data_table = chart.getChartDataTable()
    data_table.setBorderHorizontal(True)
    data_table.setBorderVertical(False)
    data_table.setBorderOutline(True)

    presentation.save("data-table-borders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Η σύγκριση παρακάτω χρησιμοποιεί τα ίδια δεδομένα διαγράμματος και ρύθμιση κλειδιού υπομνήματος και στις τέσσερις περιπτώσεις. Ξεκινώντας με όλα τα όρια ενεργοποιημένα, κάθε επόμενη παραλλαγή απενεργοποιεί μόνο μία ρύθμιση ορίου. Η παραλλαγή κάτω αριστερά ταιριάζει με τις ρυθμίσεις ορίων του παραδείγματος.

![Πίνακες δεδομένων διαγράμματος με όλα τα όρια ενεργοποιημένα, χωρίς οριζόντια όρια, χωρίς κατακόρυφα όρια και χωρίς εξωτερικό όριο](data-table-borders.png)

## **Εμφάνιση ή Απόκρυψη Κλειδιών Υπομνήματος**

Τα κλειδιά υπομνήματος είναι μικρά χρωματιστά σημεία δίπλα στα ονόματα των σειρών στον πίνακα δεδομένων. Βοηθούν τους αναγνώστες να αντιστοιχίσουν κάθε γραμμή του πίνακα σε μια σειρά διαγράμματος. Περάστε `True` στη μέθοδο [setShowLegendKey](https://reference.aspose.com/slides/el/python-java/aspose.slides/datatable/#setShowLegendKey) για να εμφανίσετε αυτά τα σημεία ή `False` για να τα κρύψετε.

Το ξεχωριστό υπόμνημα του διαγράμματος ελέγχεται από τη μέθοδο [Chart.setLegend](https://reference.aspose.com/slides/el/python-java/aspose.slides/chart/#setLegend). Αυτές οι ρυθμίσεις είναι ανεξάρτητες: η απόκρυψη του ξεχωριστού υπομνήματος δεν κρύβει τα κλειδιά μέσα στον πίνακα δεδομένων, και η απόκρυψη των κλειδιών του πίνακα δεν κρύβει το ξεχωριστό υπόμνημα.

Το παρακάτω παράδειγμα δημιουργεί ένα γράφημα με προεπιλεγμένα δεδομένα, ενεργοποιεί τον πίνακα δεδομένων του και εμφανίζει τα κλειδιά υπομνήματος μέσα σε αυτό, ενώ κρύβει το ξεχωριστό υπόμνημα. Όλα τα όρια του πίνακα είναι ρητά ενεργοποιημένα. Δεν απαιτείται εισερχόμενη παρουσίαση. Για να κρύψετε μόνο τα κλειδιά του πίνακα, περάστε `False` στη μέθοδο [setShowLegendKey](https://reference.aspose.com/slides/el/python-java/aspose.slides/datatable/#setShowLegendKey).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)
    chart.setLegend(False)

    data_table = chart.getChartDataTable()
    data_table.setBorderHorizontal(True)
    data_table.setBorderVertical(True)
    data_table.setBorderOutline(True)
    data_table.setShowLegendKey(True)

    presentation.save("data-table-legend-keys.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Η σύγκριση παρακάτω δείχνει τον ίδιο πίνακα με ενεργοποιημένα και απενεργοποιημένα κλειδιά υπομνήματος. Όλα τα όρια παραμένουν ενεργοποιημένα, και το ξεχωριστό υπόμνημα του διαγράμματος είναι κρυφό και στις δύο περιπτώσεις.

![Πίνακες δεδομένων διαγράμματος με κλειδιά υπομνήματος εμφανιζόμενα στα αριστερά και κρυμμένα στα δεξιά](data-table-legend-keys.png)

## **Συχνές Ερωτήσεις**

**Μπορώ να εμφανίσω κλειδιά υπομνήματος σε έναν πίνακα δεδομένων διαγράμματος;**

Ναι. Περάστε `True` στη μέθοδο [setShowLegendKey](https://reference.aspose.com/slides/el/python-java/aspose.slides/datatable/#setShowLegendKey) για να εμφανίσετε κλειδιά υπομνήματος ή `False` για να τα κρύψετε.

**Θα διατηρηθεί ο πίνακας δεδομένων κατά την εξαγωγή της παρουσίασης σε PDF, HTML ή εικόνες;**

Ναι. Το Aspose.Slides αποδίδει το γράφημα και τον εμφανιζόμενο πίνακα δεδομένων του ως μέρος της διαφάνειας κατά την εξαγωγή σε [PDF](/slides/el/python-java/convert-powerpoint-to-pdf/), [HTML](/slides/el/python-java/convert-powerpoint-to-html/), ή [εικόνες](/slides/el/python-java/convert-powerpoint-to-png/).

**Μπορώ να εργαστώ με πίνακες δεδομένων σε γραφήματα που φορτώνονται από πρότυπο;**

Ναι. Για ένα γράφημα που φορτώθηκε από υπάρχουσα παρουσίαση ή πρότυπο, χρησιμοποιήστε τις μεθόδους [hasDataTable](https://reference.aspose.com/slides/el/python-java/aspose.slides/chart/#hasDataTable) και [setDataTable](https://reference.aspose.com/slides/el/python-java/aspose.slides/chart/#setDataTable) για να ελέγξετε ή να αλλάξετε αν ο πίνακας δεδομένων του εμφανίζεται.

**Πώς μπορώ να βρω γραφήματα που έχουν ενεργοποιημένο πίνακα δεδομένων;**

Διατρέξτε τα σχήματα σε κάθε διαφάνεια, εντοπίστε τα γραφήματα και καλέστε τη μέθοδο [hasDataTable](https://reference.aspose.com/slides/el/python-java/aspose.slides/chart/#hasDataTable). Μια τιμή `True` υποδηλώνει ότι ο πίνακας δεδομένων είναι ενεργοποιημένος.