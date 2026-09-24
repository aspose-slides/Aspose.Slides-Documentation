---
title: Προσαρμογή πινάκων δεδομένων διαγραμμάτων σε παρουσιάσεις με C++
linktitle: Πίνακας Δεδομένων
type: docs
url: /el/cpp/chart-data-table/
keywords:
- δεδομένα διαγράμματος
- πίνακας δεδομένων
- ιδιότητες γραμματοσειράς
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Προσαρμόστε τις γραμματοσειρές, τα περιγράμματα και τα κλειδιά υπομνήματος του πίνακα δεδομένων διαγράμματος σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides για C++."
---
## **Επισκόπηση**

Το Aspose.Slides for C++ σάς επιτρέπει να εμφανίσετε τον πίνακα δεδομένων ενός διαγράμματος και να προσαρμόσετε τη μορφοποίηση κειμένου, τα περιγράμματα και τα κλειδιά υπομνήματος. Αυτό το άρθρο εξηγεί πώς να ενεργοποιήσετε τον πίνακα, να μορφοποιήσετε το κείμενό του, να ελέγξετε κάθε τύπο περιγράμματος και να εμφανίσετε ή να αποκρύψετε τα κλειδιά υπομνήματος. Τα παραδείγματα αποθηκεύουν τα ρυθμισμένα διαγράμματα σε αρχεία PPTX.

## **Ορισμός Ιδιοτήτων Γραμματοσειράς**

Για να εμφανίσετε τον πίνακα δεδομένων ενός διαγράμματος, περάστε `true` στο [IChart::set_HasDataTable](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichart/set_hasdatatable/). Χρησιμοποιήστε το [IChart::get_ChartDataTable](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichart/get_chartdatatable/) για να αποκτήσετε πρόσβαση στον πίνακα και να διαμορφώσετε τη μορφοποίηση του κειμένου.

1. Φορτώστε την παρουσίαση χρησιμοποιώντας την κλάση [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
1. Προσθέστε ένα συσσωματωμένο διάγραμμα στηλών στην πρώτη διαφάνεια.
1. Ενεργοποιήστε τον πίνακα δεδομένων του διαγράμματος.
1. Ενεργοποιήστε έντονο κείμενο με το [IBasePortionFormat::set_FontBold](https://reference.aspose.com/slides/el/cpp/aspose.slides/ibaseportionformat/set_fontbold/) και περάστε `20` στο [IBasePortionFormat::set_FontHeight](https://reference.aspose.com/slides/el/cpp/aspose.slides/ibaseportionformat/set_fontheight/) για κείμενο μεγέθους 20 σημείων.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα απαιτεί το `test.pptx` στον τρέχοντα φάκελο εργασίας με τουλάχιστον μία διαφάνεια. Προσθέτει ένα διάγραμμα με προεπιλεγμένα δεδομένα στη θέση (50, 50), με πλάτος 600 σημείων και ύψος 400 σημείων. Το αποθηκευμένο `output.pptx` περιέχει το διάγραμμα με ενεργό τον πίνακα δεδομένων και τις καθορισμένες ρυθμίσεις γραμματοσειράς.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IDataTable.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"test.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
chart->set_HasDataTable(true);

auto portionFormat = chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat();
portionFormat->set_FontBold(NullableBool::True);
portionFormat->set_FontHeight(20.0f);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Προσαρμογή Περιγραμμάτων Πίνακα Δεδομένων**

Ενεργοποιήστε τον πίνακα με το [IChart::set_HasDataTable](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichart/set_hasdatatable/) και αποκτήστε πρόσβαση σε αυτόν μέσω του [IChart::get_ChartDataTable](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichart/get_chartdatatable/). Μπορείτε να ελέγξετε τρεις τύπους περιγραμμάτων ανεξάρτητα:

- Το [IDataTable::set_HasBorderHorizontal](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/idatatable/set_hasborderhorizontal/) ελέγχει τα οριζόντια περιγράμματα των κελιών.
- Το [IDataTable::set_HasBorderVertical](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/idatatable/set_hasbordervertical/) ελέγχει τα κάθετα περιγράμματα των κελιών.
- Το [IDataTable::set_HasBorderOutline](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/idatatable/set_hasborderoutline/) ελέγχει το εξωτερικό περίγραμμα του πίνακα.

Περάστε `true` σε κάθε setter ώστε να εμφανιστούν τα περιγράμματα ή `false` για να τα κρύψετε. Το παρακάτω παράδειγμα δημιουργεί ένα συσσωματωμένο διάγραμμα στηλών με προεπιλεγμένα δεδομένα, εμφανίζει τα οριζόντια περιγράμματα και το εξωτερικό περίγραμμα, και κρύβει τα κάθετα περιγράμματα. Δεν απαιτεί αρχείο εισόδου. Η θέση και το μέγεθος του διαγράμματος καθορίζονται σε σημεία.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IDataTable.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
chart->set_HasDataTable(true);

auto dataTable = chart->get_ChartDataTable();
dataTable->set_HasBorderHorizontal(true);
dataTable->set_HasBorderVertical(false);
dataTable->set_HasBorderOutline(true);

presentation->Save(u"data-table-borders.pptx", SaveFormat::Pptx);
```

Η παρακάτω σύγκριση χρησιμοποιεί τα ίδια δεδομένα διαγράμματος και τη ρύθμιση κλειδιών υπομνήματος σε όλες τις τέσσερις περιπτώσεις. Ξεκινώντας με όλα τα περιγράμματα ενεργοποιημένα, κάθε υπόλοιπη παραλλαγή απενεργοποιεί μόνο μία ρύθμιση περιγράμματος. Η παραλλαγή κάτω αριστερά ταιριάζει με τις ρυθμίσεις περιγράμματος του παραδείγματος.

![Πίνακες δεδομένων διαγράμματος με όλα τα περιγράμματα ενεργά, χωρίς οριζόντια περιγράμματα, χωρίς κάθετα περιγράμματα και χωρίς εξωτερικό περίγραμμα](data-table-borders.png)

## **Εμφάνιση ή Απόκρυψη Κλειδιών Υπομνήματος**

Τα κλειδιά υπομνήματος είναι μικρά χρωματιστά σημεία δίπλα στα ονόματα των σειρών στον πίνακα δεδομένων. Βοηθούν τους αναγνώστες να αντιστοιχίσουν κάθε σειρά του πίνακα με μια σειρά του διαγράμματος. Περάστε `true` στο [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/idatatable/set_showlegendkey/) για να εμφανίσετε αυτά τα σημεία ή `false` για να τα αποκρύψετε.

Το ξεχωριστό υπόμνημα του διαγράμματος ελέγχεται από το [IChart::set_HasLegend](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichart/set_haslegend/). Αυτές οι ρυθμίσεις είναι ανεξάρτητες: η απόκρυψη του ξεχωριστού υπομνήματος δεν κρύβει τα κλειδιά μέσα στον πίνακα δεδομένων, και η απόκρυψη των κλειδιών του πίνακα δεν κρύβει το ξεχωριστό υπόμνημα.

Το παρακάτω παράδειγμα δημιουργεί ένα διάγραμμα με προεπιλεγμένα δεδομένα, ενεργοποιεί τον πίνακα δεδομένων του και εμφανίζει τα κλειδιά υπομνήματος μέσα σε αυτόν ενώ αποκρύπτει το ξεχωριστό υπόμνημα. Όλα τα περιγράμματα του πίνακα είναι ρητά ενεργοποιημένα. Δεν απαιτείται αρχική παρουσίαση. Για να αποκρύψετε μόνο τα κλειδιά του πίνακα, περάστε `false` στο [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/idatatable/set_showlegendkey/).

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IDataTable.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
chart->set_HasDataTable(true);
chart->set_HasLegend(false);

auto dataTable = chart->get_ChartDataTable();
dataTable->set_HasBorderHorizontal(true);
dataTable->set_HasBorderVertical(true);
dataTable->set_HasBorderOutline(true);
dataTable->set_ShowLegendKey(true);

presentation->Save(u"data-table-legend-keys.pptx", SaveFormat::Pptx);
```

Η παρακάτω σύγκριση δείχνει τον ίδιο πίνακα με ενεργοποιημένα και απενεργοποιημένα κλειδιά υπομνήματος. Όλα τα περιγράμματα παραμένουν ενεργά και το ξεχωριστό υπόμνημα του διαγράμματος είναι κρυφό και στις δύο περιπτώσεις.

![Πίνακες δεδομένων διαγράμματος με κλειδιά υπομνήματος εμφανιζόμενα στα αριστερά και κρυμμένα στα δεξιά](data-table-legend-keys.png)

## **FAQ**

**Μπορώ να εμφανίσω κλειδιά υπομνήματος στον πίνακα δεδομένων ενός διαγράμματος;**

Ναι. Περάστε `true` στο [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/idatatable/set_showlegendkey/) για να εμφανίσετε κλειδιά υπομνήματος ή `false` για να τα αποκρύψετε.

**Θα διατηρηθεί ο πίνακας δεδομένων κατά την εξαγωγή της παρουσίασης σε PDF, HTML ή εικόνες;**

Ναι. Το Aspose.Slides αποδίδει το διάγραμμα και τον εμφανιζόμενο πίνακα δεδομένων ως μέρος της διαφάνειας κατά την εξαγωγή σε [PDF](/slides/el/cpp/convert-powerpoint-to-pdf/), [HTML](/slides/el/cpp/convert-powerpoint-to-html/), ή [εικόνες](/slides/el/cpp/convert-powerpoint-to-png/).

**Μπορώ να δουλέψω με πίνακες δεδομένων σε διαγράμματα που φορτώνονται από πρότυπο;**

Ναι. Για ένα διάγραμμα που φορτώθηκε από υπάρχουσα παρουσίαση ή πρότυπο, χρησιμοποιήστε το [IChart::get_HasDataTable](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichart/get_hasdatatable/) για να ελέγξετε αν ο πίνακας δεδομένων εμφανίζεται και το [IChart::set_HasDataTable](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichart/set_hasdatatable/) για να αλλάξετε την ορατότητά του.

**Πώς μπορώ να βρω διαγράμματα που έχουν ενεργό τον πίνακα δεδομένων;**

Διενεργήστε επανάληψη στις μορφές κάθε διαφάνειας, εντοπίστε τα διαγράμματα και ελέγξτε το αποτέλεσμα του [IChart::get_HasDataTable](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichart/get_hasdatatable/). Μια τιμή `true` υποδεικνύει ότι ο πίνακας δεδομένων είναι ενεργοποιημένος.