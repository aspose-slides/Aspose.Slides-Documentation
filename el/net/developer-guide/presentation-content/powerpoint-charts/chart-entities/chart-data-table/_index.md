---
title: Προσαρμογή πινάκων δεδομένων διαγραμμάτων σε παρουσιάσεις σε .NET
linktitle: Πίνακας Δεδομένων
type: docs
url: /el/net/chart-data-table/
keywords:
- δεδομένα διαγράμματος
- πίνακας δεδομένων
- ιδιότητες γραμματοσειράς
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Προσαρμόστε τις γραμματοσειρές, τα περιθώρια και τα κλειδιά υποδοχής του πίνακα δεδομένων διαγράμματος σε παρουσιάσεις PowerPoint χρησιμοποιώντας Aspose.Slides για .NET και C#."
---
## **Επισκόπηση**

Aspose.Slides for .NET σας επιτρέπει να εμφανίσετε τον πίνακα δεδομένων ενός διαγράμματος και να προσαρμόσετε τη μορφοποίηση του κειμένου, τα περιθώρια και τα κλειδιά υποδοχής. Αυτό το άρθρο εξηγεί πώς να ενεργοποιήσετε τον πίνακα, να μορφοποιήσετε το κείμενο, να ελέγξετε κάθε τύπο περιθωρίου και να εμφανίσετε ή να αποκρύψετε τα κλειδιά υποδοχής. Τα παραδείγματα αποθηκεύουν τα διαμορφωμένα διαγράμματα σε αρχεία PPTX.

## **Ορίστε Ιδιότητες Γραμματοσειράς**

Για να εμφανίσετε τον πίνακα δεδομένων ενός διαγράμματος, ορίστε [HasDataTable](https://reference.aspose.com/slides/el/net/aspose.slides.charts/chart/hasdatatable/) σε `true`. Χρησιμοποιήστε [ChartDataTable](https://reference.aspose.com/slides/el/net/aspose.slides.charts/chart/chartdatatable/) για να προσπελάσετε τον πίνακα και να διαμορφώσετε τη μορφοποίηση του κειμένου.

1. Φορτώστε την παρουσίαση χρησιμοποιώντας την κλάση [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).
1. Προσθέστε ένα ομαδοποιημένο γράφημα στηλών στη πρώτη διαφάνεια.
1. Ενεργοποιήστε τον πίνακα δεδομένων του διαγράμματος.
1. Ενεργοποιήστε το έντονο κείμενο με [FontBold](https://reference.aspose.com/slides/el/net/aspose.slides/baseportionformat/fontbold/) και ορίστε [FontHeight](https://reference.aspose.com/slides/el/net/aspose.slides/baseportionformat/fontheight/) σε `20` για κείμενο μεγέθους 20 σημεία.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα απαιτεί το αρχείο `test.pptx` στον τρέχοντα φάκελο εργασίας με τουλάχιστον μία διαφάνεια. Προσθέτει ένα γράφημα με προεπιλεγμένα δεδομένα στη θέση (50, 50), με πλάτος 600 σημείων και ύψος 400 σημείων. Το αποθηκευμένο `output.pptx` περιέχει το γράφημα με ενεργοποιημένο τον πίνακα δεδομένων και εφαρμοσμένες τις καθορισμένες ρυθμίσεις γραμματοσειράς.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("test.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;

var portionFormat = chart.ChartDataTable.TextFormat.PortionFormat;
portionFormat.FontBold = NullableBool.True;
portionFormat.FontHeight = 20;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Προσαρμογή Περιθωρίων Πίνακα Δεδομένων**

Ενεργοποιήστε τον πίνακα με [IChart.HasDataTable](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichart/hasdatatable/) και προσπελάστε τον μέσω του [IChart.ChartDataTable](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichart/chartdatatable/). Μπορείτε να ελέγξετε τρία είδη περιθωρίων ανεξάρτητα:

- [HasBorderHorizontal](https://reference.aspose.com/slides/el/net/aspose.slides.charts/idatatable/hasborderhorizontal/) ελέγχει τα οριζόντια περιθώρια των κελιών.
- [HasBorderVertical](https://reference.aspose.com/slides/el/net/aspose.slides.charts/idatatable/hasbordervertical/) ελέγχει τα κάθετα περιθώρια των κελιών.
- [HasBorderOutline](https://reference.aspose.com/slides/el/net/aspose.slides.charts/idatatable/hasborderoutline/) ελέγχει το εξωτερικό περιθώριο του πίνακα.

Ορίστε κάθε ιδιότητα σε `true` για να εμφανίζονται τα περιθώρια ή σε `false` για να τα κρύβετε. Το παρακάτω παράδειγμα δημιουργεί ένα ομαδοποιημένο γράφημα στηλών με προεπιλεγμένα δεδομένα, εμφανίζει τα οριζόντια περιθώρια και το εξωτερικό περιθώριο, και κρύβει τα κάθετα περιθώρια. Δεν απαιτείται αρχείο εισόδου. Η θέση και το μέγεθος του διαγράμματος καθορίζονται σε σημεία.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;

var dataTable = chart.ChartDataTable;
dataTable.HasBorderHorizontal = true;
dataTable.HasBorderVertical = false;
dataTable.HasBorderOutline = true;

presentation.Save("data-table-borders.pptx", SaveFormat.Pptx);
```

Η σύγκριση παρακάτω χρησιμοποιεί τα ίδια δεδομένα διαγράμματος και την ίδια ρύθμιση κλειδιού υποδοχής σε όλες τις τέσσερις περιπτώσεις. Ξεκινώντας με όλα τα περιθώρια ενεργοποιημένα, κάθε επόμενη παραλλαγή απενεργοποιεί μόνο μία ιδιότητα περιθωρίου. Η παραλλαγή κάτω αριστερά ταιριάζει με τις ρυθμίσεις περιθωρίου στο παράδειγμα.

![Πίνακες δεδομένων διαγράμματος με όλα τα περιθώρια ενεργοποιημένα, χωρίς οριζόντια περιθώρια, χωρίς κάθετα περιθώρια και χωρίς εξωτερικό περιθώριο](data-table-borders.png)

## **Εμφάνιση ή Απόκρυψη Κλειδιών Υποδοχής**

Τα κλειδιά υποδοχής είναι μικρά χρωματιστά σημεία δίπλα στα ονόματα των σειρών στον πίνακα δεδομένων. Βοηθούν τους αναγνώστες να αντιστοιχίσουν κάθε γραμμή του πίνακα σε μια σειρά διαγράμματος. Ορίστε το [ShowLegendKey](https://reference.aspose.com/slides/el/net/aspose.slides.charts/idatatable/showlegendkey/) σε `true` για να εμφανίζονται αυτά τα σημεία ή σε `false` για να κρύβονται.

Ο ξεχωριστός υπότιτλος του διαγράμματος ελέγχεται από το [IChart.HasLegend](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichart/haslegend/). Οι ρυθμίσεις είναι ανεξάρτητες: η απόκρυψη του ξεχωριστού υπότιτλου δεν κρύβει τα κλειδιά μέσα στον πίνακα δεδομένων, και η απόκρυψη των κλειδιών του πίνακα δεν κρύβει τον ξεχωριστό υπότιτλο.

Το παρακάτω παράδειγμα δημιουργεί ένα γράφημα με προεπιλεγμένα δεδομένα, ενεργοποιεί τον πίνακα δεδομένων του και εμφανίζει κλειδιά υποδοχής μέσα σε αυτόν ενώ κρύβει τον ξεχωριστό υπότιτλο. Όλα τα περιθώρια του πίνακα είναι ρητά ενεργοποιημένα. Δεν απαιτείται παρουσίαση εισόδου. Για να κρύψετε μόνο τα κλειδιά του πίνακα, αλλάξτε το `dataTable.ShowLegendKey` σε `false`.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;
chart.HasLegend = false;

var dataTable = chart.ChartDataTable;
dataTable.HasBorderHorizontal = true;
dataTable.HasBorderVertical = true;
dataTable.HasBorderOutline = true;
dataTable.ShowLegendKey = true;

presentation.Save("data-table-legend-keys.pptx", SaveFormat.Pptx);
```

Η σύγκριση παρακάτω δείχνει τον ίδιο πίνακα με τα κλειδιά υποδοχής ενεργοποιημένα και απενεργοποιημένα. Όλα τα περιθώρια παραμένουν ενεργοποιημένα και ο ξεχωριστός υπότιτλος του διαγράμματος είναι κρυμμένος και στις δύο περιπτώσεις.

![Πίνακες δεδομένων διαγράμματος με κλειδιά υποδοχής εμφανισμένα στα αριστερά και κρυμμένα στα δεξιά](data-table-legend-keys.png)

## **Συχνές ερωτήσεις**

**Μπορώ να εμφανίσω κλειδιά υποδοχής στον πίνακα δεδομένων ενός διαγράμματος;**

Ναι. Ορίστε το [ShowLegendKey](https://reference.aspose.com/slides/el/net/aspose.slides.charts/datatable/showlegendkey/) σε `true` για να εμφανιστούν τα κλειδιά υποδοχής ή σε `false` για να κρυφτούν.

**Θα διατηρηθεί ο πίνακας δεδομένων κατά την εξαγωγή της παρουσίασης σε PDF, HTML ή εικόνες;**

Ναι. Το Aspose.Slides αποδίδει το γράφημα και τον εμφανιζόμενο πίνακα δεδομένων του ως μέρος της διαφάνειας κατά την εξαγωγή σε [PDF](/slides/el/net/convert-powerpoint-to-pdf/), [HTML](/slides/el/net/convert-powerpoint-to-html/) ή [images](/slides/el/net/convert-powerpoint-to-png/).

**Μπορώ να εργαστώ με πίνακες δεδομένων σε διαγράμματα που φορτώνονται από πρότυπο;**

Ναι. Για ένα γράφημα που φορτώνεται από υπάρχουσα παρουσίαση ή πρότυπο, χρησιμοποιήστε το [HasDataTable](https://reference.aspose.com/slides/el/net/aspose.slides.charts/chart/hasdatatable/) για να ελέγξετε ή να αλλάξετε εάν εμφανίζεται ο πίνακας δεδομένων.

**Πώς μπορώ να βρω διαγράμματα που έχουν ενεργοποιημένο πίνακα δεδομένων;**

Διατρέξτε τις μορφές σε κάθε διαφάνεια, εντοπίστε τα διαγράμματα και ελέγξτε την ιδιότητα τους [HasDataTable](https://reference.aspose.com/slides/el/net/aspose.slides.charts/chart/hasdatatable/). Μια τιμή `true` υποδεικνύει ότι ο πίνακας δεδομένων είναι ενεργοποιημένος.