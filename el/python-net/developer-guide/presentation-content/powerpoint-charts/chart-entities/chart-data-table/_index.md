---
title: Προσαρμογή Πινάκων Δεδομένων Γραφημάτων σε Παρουσιάσεις σε Python
linktitle: Πίνακας Δεδομένων
type: docs
url: /el/python-net/chart-data-table/
keywords:
- δεδομένα γραφήματος
- πίνακας δεδομένων
- ιδιότητες γραμματοσειράς
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Προσαρμόστε τις γραμματοσειρές, τα περιγράμματα και τα σύμβολα υπόμνησης των πινάκων δεδομένων γραφημάτων σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides for Python μέσω .NET."
---
## **Επισκόπηση**

Το Aspose.Slides for Python μέσω .NET σάς επιτρέπει να εμφανίσετε τον πίνακα δεδομένων ενός διαγράμματος και να προσαρμόσετε τη μορφοποίηση κειμένου, τα περιγράμματα και τα σύμβολα υπόμνησης. Αυτό το άρθρο εξηγεί πώς να ενεργοποιήσετε τον πίνακα, να μορφοποιήσετε το κείμενό του, να ελέγξετε κάθε τύπο περιγράμματος και να εμφανίσετε ή να αποκρύψετε τα σύμβολα υπόμνησης. Τα παραδείγματα αποθηκεύουν τα ρυθμισμένα διαγράμματα σε αρχεία PPTX.

## **Ορισμός Ιδιοτήτων Γραμματοσειράς**

Για να εμφανίσετε τον πίνακα δεδομένων ενός διαγράμματος, ορίστε το [has_data_table](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chart/has_data_table/) σε `True`. Χρησιμοποιήστε το [chart_data_table](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chart/chart_data_table/) για να αποκτήσετε πρόσβαση στον πίνακα και να διαμορφώσετε τη μορφοποίηση κειμένου του.

1. Φορτώστε την παρουσίαση χρησιμοποιώντας την κλάση [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
1. Προσθέστε ένα συγκεντρωτικό γράφημα στήλης στη πρώτη διαφάνεια.
1. Ενεργοποιήστε τον πίνακα δεδομένων του διαγράμματος.
1. Ενεργοποιήστε το έντονο κείμενο με το [font_bold](https://reference.aspose.com/slides/el/python-net/aspose.slides/baseportionformat/font_bold/) και ορίστε το [font_height](https://reference.aspose.com/slides/el/python-net/aspose.slides/baseportionformat/font_height/) σε `20` για κείμενο 20 σημείων.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα απαιτεί το αρχείο `test.pptx` στον τρέχοντα φάκελο με τουλάχιστον μία διαφάνεια. Προσθέτει ένα γράφημα με προεπιλεγμένα δεδομένα στη θέση (50, 50), με πλάτος 600 σημείων και ύψος 400 σημείων. Το αποθηκευμένο `output.pptx` περιέχει το γράφημα με ενεργοποιημένο τον πίνακα δεδομένων του και τις καθορισμένες ρυθμίσεις γραμματοσειράς εφαρμόσες.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("test.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True

    portion_format = chart.chart_data_table.text_format.portion_format
    portion_format.font_bold = slides.NullableBool.TRUE
    portion_format.font_height = 20

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Προσαρμογή Περιγραμμάτων Πίνακα Δεδομένων**

Ενεργοποιήστε τον πίνακα με το [Chart.has_data_table](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chart/has_data_table/) και αποκτήστε πρόσβαση σε αυτό μέσω του [Chart.chart_data_table](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chart/chart_data_table/). Μπορείτε να ελέγξετε τρεις τύπους περιγραμμάτων ανεξάρτητα:

- Το [has_border_horizontal](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/datatable/has_border_horizontal/) ελέγχει τα οριζόντια περιγράμματα κελιών.
- Το [has_border_vertical](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/datatable/has_border_vertical/) ελέγχει τα κάθετα περιγράμματα κελιών.
- Το [has_border_outline](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/datatable/has_border_outline/) ελέγχει το εξωτερικό περίγραμμα του πίνακα.

Ορίστε κάθε ιδιότητα σε `True` για να εμφανίσετε τα περιγράμματα της ή σε `False` για να τα αποκρύψετε. Το παρακάτω παράδειγμα δημιουργεί ένα συγκεντρωτικό γράφημα στήλης με προεπιλεγμένα δεδομένα, εμφανίζει τα οριζόντια περιγράμματα και το εξωτερικό περίγραμμα, και αποκρύπτει τα κάθετα περιγράμματα. Δεν απαιτεί αρχείο εισόδου. Η θέση και το μέγεθος του γραφήματος καθορίζονται σε σημεία.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True

    data_table = chart.chart_data_table
    data_table.has_border_horizontal = True
    data_table.has_border_vertical = False
    data_table.has_border_outline = True

    presentation.save("data-table-borders.pptx", slides.export.SaveFormat.PPTX)
```

Η παρακάτω σύγκριση χρησιμοποιεί τα ίδια δεδομένα γραφήματος και ρύθμιση κλειδιού υπόμνησης σε όλες τις τέσσερις περιπτώσεις. Ξεκινώντας με όλα τα περιγράμματα ενεργοποιημένα, κάθε επόμενη παραλλαγή απενεργοποιεί μόνο μια ιδιότητα περιγράμματος. Η παραλλαγή κάτω-αριστερά ταιριάζει με τις ρυθμίσεις περιγράμματος του παραδείγματος.

![Πίνακες δεδομένων γραφήματος με ενεργά όλα τα περιγράμματα, χωρίς οριζόντια περιγράμματα, χωρίς κάθετα περιγράμματα και χωρίς εξωτερικό περίγραμμα](data-table-borders.png)

## **Εμφάνιση ή Απόκρυψη Συμβόλων Υπόμνησης**

Τα σύμβολα υπόμνησης είναι μικρές χρωματιστές ενδείξεις δίπλα στα ονόματα των σειρών στον πίνακα δεδομένων. Βοηθούν τους αναγνώστες να αντιστοιχίσουν κάθε γραμμή του πίνακα σε μια σειρά γραφήματος. Ορίστε το [show_legend_key](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/datatable/show_legend_key/) σε `True` για να εμφανίσετε αυτές τις ενδείξεις ή σε `False` για να τις αποκρύψετε.

Η ξεχωριστή υπόμνηση του γραφήματος ελέγχεται από το [Chart.has_legend](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chart/has_legend/). Αυτές οι ρυθμίσεις είναι ανεξάρτητες: η απόκρυψη της ξεχωριστής υπόμνησης δεν κρύβει τα σύμβολα μέσα στον πίνακα δεδομένων, και η απόκρυψη των συμβόλων του πίνακα δεν κρύβει τη ξεχωριστή υπόμνηση.

Το παρακάτω παράδειγμα δημιουργεί ένα γράφημα με προεπιλεγμένα δεδομένα, ενεργοποιεί τον πίνακα δεδομένων του και δείχνει τα σύμβολα υπόμνησης μέσα σε αυτό, ενώ αποκρύπτει τη ξεχωριστή υπόμνηση. Όλα τα περιγράμματα του πίνακα είναι ρητά ενεργοποιημένα. Δεν απαιτείται παρουσίαση εισόδου. Για να αποκρύψετε μόνο τα σύμβολα του πίνακα, αλλάξτε το `data_table.show_legend_key` σε `False`.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True
    chart.has_legend = False

    data_table = chart.chart_data_table
    data_table.has_border_horizontal = True
    data_table.has_border_vertical = True
    data_table.has_border_outline = True
    data_table.show_legend_key = True

    presentation.save("data-table-legend-keys.pptx", slides.export.SaveFormat.PPTX)
```

Η παρακάτω σύγκριση δείχνει τον ίδιο πίνακα με ενεργά και απενεργοποιημένα σύμβολα υπόμνησης. Όλα τα περιγράμματα παραμένουν ενεργά, και η ξεχωριστή υπόμνηση του γραφήματος είναι κρυμμένη και στις δύο περιπτώσεις.

![Πίνακες δεδομένων γραφήματος με τα σύμβολα υπόμνησης εμφανιζόμενα στα αριστερά και κρυμμένα στα δεξιά](data-table-legend-keys.png)

## **ΣΥΧΝΑ ΡΩΤΗΜΑΤΑ**

**Μπορώ να εμφανίσω τα σύμβολα υπόμνησης σε έναν πίνακα δεδομένων γραφήματος;**

Ναι. Ορίστε το [show_legend_key](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/datatable/show_legend_key/) σε `True` για να εμφανίσετε τα σύμβολα υπόμνησης ή σε `False` για να τα αποκρύψετε.

**Θα διατηρηθεί ο πίνακας δεδομένων κατά την εξαγωγή της παρουσίασης σε PDF, HTML ή εικόνες;**

Ναι. Το Aspose.Slides αποδίδει το γράφημα και τον εμφανιζόμενο πίνακα δεδομένων του ως μέρος της διαφάνειας όταν εξάγει σε [PDF](/slides/el/python-net/convert-powerpoint-to-pdf/), [HTML](/slides/el/python-net/convert-powerpoint-to-html/), ή [images](/slides/el/python-net/convert-powerpoint-to-png/).

**Μπορώ να εργαστώ με πίνακες δεδομένων σε γραφήματα που φορτώνονται από ένα πρότυπο;**

Ναι. Για ένα γράφημα που φορτώθηκε από υπάρχουσα παρουσίαση ή πρότυπο, χρησιμοποιήστε το [has_data_table](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chart/has_data_table/) για να ελέγξετε ή να αλλάξετε εάν εμφανίζεται ο πίνακας δεδομένων του.

**Πώς μπορώ να βρω γραφήματα που έχουν ενεργοποιημένο πίνακα δεδομένων;**

Διατρέξτε τα σχήματα σε κάθε διαφάνεια, εντοπίστε τα γραφήματα και ελέγξτε την ιδιότητα [has_data_table](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chart/has_data_table/). Μια τιμή `True` υποδεικνύει ότι ο πίνακας δεδομένων είναι ενεργοποιημένος.