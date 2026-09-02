---
title: Εφαρμογή τύπων φύλλου εργασίας γραφημάτων σε παρουσιάσεις με C++
linktitle: Τύποι φύλλου εργασίας
type: docs
weight: 70
url: /el/cpp/chart-worksheet-formulas/
keywords:
- φύλλο εργασίας γραφήματος
- φύλλο εργασίας γραφήματος
- τύπος γραφήματος
- τύπος φύλλου εργασίας
- τύπος λογιστικού φύλλου
- βιβλίο δεδομένων γραφήματος
- υπολογισμός τύπου
- προτιμώμενος πολιτισμός
- τύπος ειδικού πολιτισμού
- DBCS
- λογική σταθερά
- αριθμητική σταθερά
- σταθερά συμβολοσειράς
- σταθερά σφάλματος
- αριθμητικός χειριστής
- χειριστής σύγκρισης
- στυλ A1
- στυλ R1C1
- προκαθορισμένη συνάρτηση
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Εφαρμόστε τύπους τύπου Excel στα φύλλα εργασίας γραφημάτων του Aspose.Slides για C++, επαναϋπολογίστε τις τιμές και χρησιμοποιήστε τα αποτελέσματα σε γραφήματα PowerPoint."
---
## **Επισκόπηση**

Οι γραφήματα του PowerPoint συνήθως αποθηκεύουν τα δεδομένα προέλευσής τους σε ένα ενσωματωμένο φύλλο εργασίας. Στο Aspose.Slides για C++, μπορείτε να αποκτήσετε πρόσβαση σε αυτό το φύλλο εργασίας μέσω του βιβλίου εργασίας δεδομένων γραφήματος, να γράψετε τιμές εισόδου, να αναθέσετε τύπους σε κελιά, να υπολογίσετε τους υποστηριζόμενους τύπους και να χρησιμοποιήσετε τα υπολογισμένα κελιά ως δεδομένα γραφήματος.

Αυτό το άρθρο εξηγεί τη πλήρη ροή εργασίας τύπων: δημιουργία γραφήματος, γέμισμα του φύλλου εργασίας, ανάθεση τύπων τύπου A1 ή R1C1, επαναϋπολογισμό τους, ανάγνωση των υπολογισμένων τιμών, σύνδεση αυτών των κελιών σε σειρά γραφήματος και αποθήκευση της παρουσίασης. Περιγράφει επίσης τη σύνταξη των υποστηριζόμενων τύπων, το υποσύνολο ενσωματωμένων συναρτήσεων, τις αποθηκευμένες τιμές, τους μη υποστηριζόμενους τύπους και τα σφάλματα ειδικά για φύλλα εργασίας.

## **Φύλλα Εργασίας Γραφημάτων και Τύποι**

Ένα φύλλο εργασίας γραφήματος περιέχει τις κατηγορίες, τα ονόματα σειρών και τις τιμές που χρησιμοποιεί ένα γράφημα. Στο PowerPoint, μπορείτε να εξετάσετε το φύλλο εργασίας ανοίγοντας τον επεξεργαστή δεδομένων γραφήματος:

![PowerPoint chart with its embedded worksheet open, showing category and series data](chart-worksheet-formulas_1.png)

Στο Aspose.Slides, το φύλλο εργασίας εκτίθεται μέσω της διεπαφής [IChartDataWorkbook](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdataworkbook/) . Χρησιμοποιήστε [IChartDataCell::set_Formula](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdatacell/set_formula/) για τύπους στυλ A1 και [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) για τύπους στυλ R1C1. Μετά την αλλαγή των κελιών εισόδου ή των τύπων, κλήστε [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) για να επαναϋπολογίσετε τους υποστηριζόμενους τύπους και να ενημερώσετε τις αντίστοιχες τιμές κελιών.

Ένα υπολογισμένο κελί εξακολουθεί να εκθέτει το αποτέλεσμα του μέσω του [IChartDataCell::get_Value](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdatacell/get_value/). Αυτό είναι σημαντικό όταν χρειάζεται να ελέγξετε το αποτέλεσμα ενός τύπου σε κώδικα ή να χρησιμοποιήσετε το κελί ως σημείο δεδομένων γραφήματος.

## **Δημιουργία Γραφήματος και Υπολογισμός Τύπων Φύλλου Εργασίας**

Το ακόλουθο παράδειγμα δείχνει μια πλήρη ροή εργασίας. Δημιουργεί ένα γράφημα clustered column, διαγράφει τα δείγματα δεδομένων, γράφει τριμηνιαίες τιμές εσόδων και εξόδων, υπολογίζει το κέρδος με τύπους, διαβάζει τα αποτελέσματα, χρησιμοποιεί τα υπολογισμένα κελιά ως τιμές γραφήματος και αποθηκεύει την παρουσίαση.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 350.0f);
auto chartData = chart->get_ChartData();
auto workbook = chartData->get_ChartDataWorkbook();
const int32_t worksheetIndex = 0;

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();
workbook->Clear(worksheetIndex);

auto category1 = workbook->GetCell(worksheetIndex, u"A2", ObjectExt::Box<String>(u"Q1"));
auto category2 = workbook->GetCell(worksheetIndex, u"A3", ObjectExt::Box<String>(u"Q2"));
auto category3 = workbook->GetCell(worksheetIndex, u"A4", ObjectExt::Box<String>(u"Q3"));

workbook->GetCell(worksheetIndex, u"B1", ObjectExt::Box<String>(u"Revenue"));
workbook->GetCell(worksheetIndex, u"C1", ObjectExt::Box<String>(u"Expenses"));
workbook->GetCell(worksheetIndex, u"D1", ObjectExt::Box<String>(u"Profit"));

workbook->GetCell(worksheetIndex, u"B2")->set_Value(ObjectExt::Box<double>(120.0));
workbook->GetCell(worksheetIndex, u"C2")->set_Value(ObjectExt::Box<double>(80.0));
workbook->GetCell(worksheetIndex, u"B3")->set_Value(ObjectExt::Box<double>(150.0));
workbook->GetCell(worksheetIndex, u"C3")->set_Value(ObjectExt::Box<double>(95.0));
workbook->GetCell(worksheetIndex, u"B4")->set_Value(ObjectExt::Box<double>(135.0));
workbook->GetCell(worksheetIndex, u"C4")->set_Value(ObjectExt::Box<double>(110.0));

auto profit1 = workbook->GetCell(worksheetIndex, u"D2");
auto profit2 = workbook->GetCell(worksheetIndex, u"D3");
auto profit3 = workbook->GetCell(worksheetIndex, u"D4");

profit1->set_Formula(u"B2-C2");
profit2->set_Formula(u"B3-C3");
profit3->set_Formula(u"B4-C4");

workbook->CalculateFormulas();

auto q1Profit = profit1->get_Value(); // 40
auto q2Profit = profit2->get_Value(); // 55
auto q3Profit = profit3->get_Value(); // 25

chartData->get_Categories()->Add(category1);
chartData->get_Categories()->Add(category2);
chartData->get_Categories()->Add(category3);

auto profitSeries = chartData->get_Series()->Add(workbook->GetCell(worksheetIndex, u"D1"), chart->get_Type());
profitSeries->get_DataPoints()->AddDataPointForBarSeries(profit1);
profitSeries->get_DataPoints()->AddDataPointForBarSeries(profit2);
profitSeries->get_DataPoints()->AddDataPointForBarSeries(profit3);
profitSeries->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

presentation->Save(u"chart-formulas.pptx", SaveFormat::Pptx);
```

Τα σημεία δεδομένων του γραφήματος αναφέρονται στο `D2:D4`, έτσι το γράφημα χρησιμοποιεί τις υπολογισμένες τιμές κέρδους. Δεν υπάρχει ξεχωριστή κλήση ανανέωσης γραφήματος σε αυτήν τη ροή εργασίας: επαναϋπολογίστε πρώτα το βιβλίο εργασίας, μετά χρησιμοποιήστε ή αποθηκεύστε τα δεδομένα γραφήματος που δείχνουν στα υπολογισμένα κελιά.

## **Χρήση Τύπων Στυλ A1**

Η σημειολογία A1 προσδιορίζει τις στήλες με γράμματα και τις γραμμές με αριθμούς. Αναθέστε εκφράσεις στυλ A1 μέσω του [IChartDataCell::set_Formula](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdatacell/set_formula/).

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

workbook->GetCell(0, u"C3")->set_Value(ObjectExt::Box<int32_t>(10));
workbook->GetCell(0, u"F2")->set_Value(ObjectExt::Box<int32_t>(2));
workbook->GetCell(0, u"G2")->set_Value(ObjectExt::Box<int32_t>(3));
workbook->GetCell(0, u"H2")->set_Value(ObjectExt::Box<int32_t>(4));

auto cell = workbook->GetCell(0, u"A2");
cell->set_Formula(u"C3+SUM(F2:H2)");

workbook->CalculateFormulas();

auto value = cell->get_Value(); // 19
```

Κοινές μορφές αναφοράς A1 είναι:

| Αναφορά | Σχετική | Απόλυτη | Μικτή |
|---|---|---|---|
| Κελί | `A2` | `$A$2` | `A$2`, `$A2` |
| Γραμμή | `2:2` | `$2:$2` | — |
| Στήλη | `A:A` | `$A:$A` | — |
| Εύρος | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Οι σχετικές αναφορές μπορούν να αλλάξουν όταν ένας τύπος μετακινηθεί ή αντιγραφεί από μια εφαρμογή λογιστικού φύλλου. Οι απόλυτες αναφορές κρατούν και τις δύο συντεταγμένες σταθερές, ενώ οι μικτές κρατούν μόνο μία γραμμή ή στήλη σταθερή.

## **Χρήση Τύπων Στυλ R1C1**

Η σημειολογία R1C1 προσδιορίζει τόσο τις γραμμές όσο και τις στήλες αριθμητικά. Οι σχετικές αναφορές χρησιμοποιούν μετατοπίσεις σε αγκύλες. Αναθέστε αυτή τη σύνταξη μέσω του [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/).

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

workbook->GetCell(0, u"B2")->set_Value(ObjectExt::Box<int32_t>(12));
workbook->GetCell(0, u"C2")->set_Value(ObjectExt::Box<int32_t>(5));

auto cell = workbook->GetCell(0, u"D2");
cell->set_R1C1Formula(u"RC[-2]-RC[-1]");

workbook->CalculateFormulas();

auto value = cell->get_Value(); // 7
```

Κοινές μορφές αναφοράς R1C1 είναι:

| Αναφορά | Σχετική | Απόλυτη | Μικτή |
|---|---|---|---|
| Κελί | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Γραμμή | `R[2]` | `R2` | — |
| Στήλη | `C[3]` | `C3` | — |
| Εύρος | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Για παράδειγμα, στο κελί `D2`, το `RC[-2]` σημαίνει το κελί στην ίδια γραμμή δύο στήλες προς τα αριστερά (`B2`).

## **Σταθερές Τύπων και Χειριστές**

Ο ενσωματωμένος αξιολογητής τύπων υποστηρίζει λογικές τιμές, αριθμητικές λυτρωτικές, συμβολοσειρές, τιμές σφάλματος λογιστικού φύλλου, αριθμητικούς και συγκριτικούς χειριστές.

### **Σταθερές και Κυριολεξίες**

| Τύπος | Παραδείγματα | Σημειώσεις |
|---|---|---|
| Λογική | `TRUE`, `FALSE` | Μπορεί να χρησιμοποιηθεί άμεσα σε λογικές εκφράσεις όπως `A2=TRUE`. |
| Αριθμητική | `1`, `0.5`, `.3`, `1E-2` | Υποστηρίζονται η κοινή και η επιστημονική σημειογραφία. |
| Συμβολοσειρά | `"abc"`, `"2/3/2020 12:00"` | Τα κυριολεξία κειμένου περικλείονται σε διπλά εισαγωγικά μέσα στον τύπο. |
| Αποτέλεσμα σφάλματος | `#DIV/0!`, `#N/A`, `#REF!` | Ένας έγκυρος τύπος μπορεί να αξιολογηθεί σε τιμή σφάλματος λογιστικού φύλλου αντί για κανονικό αποτέλεσμα. |

Αυτό το παράδειγμα χρησιμοποιεί πολλούς τύπους σταθερών:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

workbook->GetCell(0, u"A2")->set_Value(ObjectExt::Box<bool>(false));
workbook->GetCell(0, u"B2")->set_Formula(u"A2=TRUE");
workbook->GetCell(0, u"C2")->set_Formula(u"1+0.5");
workbook->GetCell(0, u"D2")->set_Formula(u".3*1E-2");
workbook->GetCell(0, u"E2")->set_Formula(u"\"abc\"");
workbook->GetCell(0, u"F2")->set_Formula(u"2/0");

workbook->CalculateFormulas();

auto logicalValue = workbook->GetCell(0, u"B2")->get_Value(); // Ψευδές
auto numericValue = workbook->GetCell(0, u"C2")->get_Value(); // 1.5
auto scientificValue = workbook->GetCell(0, u"D2")->get_Value(); // 0.003
auto stringValue = workbook->GetCell(0, u"E2")->get_Value(); // abc
auto errorValue = workbook->GetCell(0, u"F2")->get_Value(); // #DIV/0!
```

### **Αριθμητικοί Χειριστές**

| Χειριστής | Σημασία | Παράδειγμα |
|---|---|---|
| `+` | Πρόσθεση ή μονόπλεον | `2+3` |
| `-` | Αφαίρεση ή αρνητικό | `2-3`, `-3` |
| `*` | Πολλαπλασιασμός | `2*3` |
| `/` | Διαίρεση | `2/3` |
| `%` | Ποσοστό | `30%` |
| `^` | Εκθέτης | `2^3` |

Χρησιμοποιήστε παρενθέσεις για να κάνετε ρητό τη σειρά εκτίμησης, π.χ. `(A2+B2)*C2`.

### **Χειριστές Σύγκρισης**

Οι εκφράσεις σύγκρισης επιστρέφουν λογικές τιμές.

| Χειριστής | Σημασία | Παράδειγμα |
|---|---|---|
| `=` | Ισημερία | `A2=3` |
| `<>` | Ανισότητα | `A2<>3` |
| `>` | Μεγαλύτερο από | `A2>3` |
| `>=` | Μεγαλύτερο ή ίσο | `A2>=3` |
| `<` | Μικρότερο από | `A2<3` |
| `<=` | Μικρότερο ή ίσο | `A2<=3` |

## **Υποστηριζόμενες Προκαθορισμένες Συναρτήσεις**

Το Aspose.Slides περιλαμβάνει έναν ενσωματωμένο αξιολογητή τύπων για φύλλα εργασίας γραφημάτων, αλλά δεν αποτελεί πλήρη μηχανή υπολογισμού του Excel. Ο τεκμηριωμένος κατάλογος συναρτήσεων περιορίζεται στις παρακάτω. Μην υποθέτετε ότι οποιαδήποτε τυχαία συνάρτηση του Excel μπορεί να επαναυπολογιστεί με το [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/).

| Συνάρτηση | Σκοπός ή υποστηριζόμενη μορφή | Παράδειγμα |
|---|---|---|
| `ABS` | Απόλυτη τιμή | `ABS(A2)` |
| `AVERAGE` | Αριθμητικός μέσος | `AVERAGE(B2:B5)` |
| `CEILING` | Στρογγυλοποίηση προς τα πάνω σε πολλαπλάσιο | `CEILING(A2,5)` |
| `CHOOSE` | Επιλογή τιμής με βάση δείκτη | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Συγκόλληση κειμένων | `CONCAT(A2,B2)` |
| `CONCATENATE` | Συγκόλληση κειμένων | `CONCATENATE(A2," ",B2)` |
| `DATE` | Δημιουργία τιμής ημερομηνίας με σύστημα 1900 | `DATE(2026,8,19)` |
| `DAYS` | Επιστροφή του αριθμού ημερών μεταξύ ημερομηνιών | `DAYS(B2,A2)` |
| `FIND` | Εύρεση κειμένου μέσα σε άλλο κείμενο | `FIND("-",A2)` |
| `FINDB` | Αναζήτηση κειμένου κατά byte | `FINDB("a",A2)` |
| `IF` | Συνθήκη | `IF(A2>0,A2,0)` |
| `INDEX` | Μορφή αναφοράς | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Μορφή διανύσματος | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Μορφή διανύσματος | `MATCH(A2,B2:B5,0)` |
| `MAX` | Μέγιστη τιμή | `MAX(B2:B5)` |
| `SUM` | Άθροισμα τιμών | `SUM(B2:B5)` |
| `VLOOKUP` | Κατακόρυφος αναζήτηση | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Οι περιορισμοί που φαίνονται στον πίνακα είναι ουσιώδεις: το `INDEX` τεκμηριώνεται σε μορφή αναφοράς, ενώ τα `LOOKUP` και `MATCH` σε μορφή διανύσματος. Το `DATE` χρησιμοποιεί το σύστημα 1900. Λειτουργίες και συναρτήσεις που δεν αναφέρονται εδώ θεωρούνται μη υποστηριζόμενες από τον αξιολογητή τύπων του Aspose.Slides, εκτός εάν τεκμηριώνονται ξεχωριστά.

## **Υπολογισμός Τύπων με Προτιμώμενο Πολιτισμό**

Ορισμένες λειτουργίες του βιβλίου εργασίας γραφήματος ερμηνεύουν το κείμενο σύμφωνα με πολιτισμικούς κανόνες. Αυτό είναι ιδιαίτερα σημαντικό για λειτουργίες που προορίζονται για γλώσσες που χρησιμοποιούν σύνολα διπλού-byte χαρακτήρων (DBCS). Για σωστό υπολογισμό αυτών των τύπων, δημιουργήστε ένα [LoadOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides/loadoptions/), ρυθμίστε το [ISpreadsheetOptions::set_PreferredCulture](https://reference.aspose.com/slides/el/cpp/aspose.slides/ispreadsheetoptions/set_preferredculture/) μέσω του [LoadOptions::set_SpreadsheetOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/), και, στη συνέχεια, φορτώστε την παρουσίαση.

Το παρακάτω παράδειγμα επιλέγει την ιαπωνική κουλτούρα, ανοίγει μια παρουσίαση με τις ρυθμισμένες επιλογές φόρτωσης και καλεί το [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) για κάθε βιβλίο εργασίας γραφήματος:

```cpp
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/SpreadsheetOptions.h>
#include <system/globalization/culture_info.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;
using namespace System::Globalization;

auto japaneseCulture = CultureInfo::GetCultureInfo(u"ja-JP");

auto spreadsheetOptions = MakeObject<SpreadsheetOptions>();
spreadsheetOptions->set_PreferredCulture(japaneseCulture);

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_SpreadsheetOptions(spreadsheetOptions);

auto presentation = MakeObject<Presentation>(u"presentation.pptx", loadOptions);

for (int32_t slideIndex = 0; slideIndex < presentation->get_Slides()->get_Count(); slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);

    for (int32_t shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); shapeIndex++)
    {
        auto shape = slide->get_Shape(shapeIndex);
        if (ObjectExt::Is<IChart>(shape))
        {
            auto chart = ExplicitCast<IChart>(shape);
            chart->get_ChartData()->get_ChartDataWorkbook()->CalculateFormulas();
        }
    }
}
```

Η προτιμώμενη κουλτούρα αποτελεί μέρος της διαμόρφωσης φόρτωσης της παρουσίασης, οπότε πρέπει να οριστεί πριν δημιουργήσετε το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/). Χρησιμοποιήστε τον πολιτισμό που αναμένεται από τους τύπους του βιβλίου εργασίας· π.χ., `ja-JP` για τύπους που πρέπει να ακολουθούν τους ιαπωνικούς κανόνες DBCS.

## **Επανάληψη Υπολογισμού και Αποθηκευμένες Τιμές**

Τα αρχεία λογιστικών φύλλων συχνά αποθηκεύουν τόσο τον τύπο όσο και την τελευταία υπολογισμένη τιμή του. Το Aspose.Slides μπορεί επομένως να διαβάσει αποθηκευμένη τιμή από το [IChartDataCell::get_Value](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdatacell/get_value/) όταν μια παρουσίαση φορτώνεται και τα σχετικά δεδομένα γραφήματος δεν έχουν αλλάξει.

Μετά την αλλαγή κελιών εισόδου ή τύπων, μην βασίζεστε σε παλιό αποθηκευμένο αποτέλεσμα. Κλήστε το [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) πριν διαβάσετε τις υπολογισμένες τιμές ή αποθηκεύσετε δεδομένα γραφήματος που εξαρτώνται από αυτές.

Για τύπους εκτός του υποστηριζόμενου υποσυνόλου, το Aspose.Slides ενδέχεται να μην μπορεί να αναλύσει τον τύπο ή να προσδιορίσει τις εξαρτήσεις του. Εάν το βιβλίο εργασίας έχει τροποποιηθεί, η προηγούμενη αποθηκευμένη τιμή δεν μπορεί πλέον να θεωρηθεί αξιόπιστη. Σε αυτήν την περίπτωση, η ανάγνωση τιμής κελιού με μη υποστηριζόμενα δεδομένα μπορεί να προκαλέσει το [CellUnsupportedDataException](https://reference.aspose.com/slides/el/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Εάν το γράφημά σας εξαρτάται από συναρτήσεις Excel που το Aspose.Slides δεν αξιολογεί, υπολογίστε αυτούς τους τύπους με μια μηχανή λογιστικού φύλλου που τους υποστηρίζει και γράψτε τις προκύπτουσες τιμές πίσω στο βιβλίο εργασίας γραφήματος. Μην αντικαθιστάτε τους μη υποστηριζόμενους τύπους με εικτικές τιμές.

## **Διαχείριση Σφαλμάτων Τύπων**

Υπάρχουν δύο διαφορετικά είδη προβλημάτων που πρέπει να διακρίνετε.

Ένας τύπος μπορεί να είναι έγκυρος αλλά να παράγει αποτέλεσμα σφάλματος λογιστικού φύλλου, όπως `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` ή `#VALUE!`. Σε αυτήν την περίπτωση, το διακριτικό σφάλματος είναι αποτέλεσμα κελιού και μπορεί να επιστραφεί μέσω του [IChartDataCell::get_Value](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdatacell/get_value/).

Ένας τύπος μπορεί επίσης να αποτύχει στο στάδιο ανάλυσης, αναφοράς, εξάρτησης ή σε επίπεδο υποστηριζόμενων δεδομένων. Το Aspose.Slides παρέχει εξαιρέσεις ειδικές για φύλλα εργασίας: [CellInvalidFormulaException](https://reference.aspose.com/slides/el/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/el/cpp/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/el/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/), και [CellUnsupportedDataException](https://reference.aspose.com/slides/el/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Όταν οι τύποι προέρχονται από πρότυπα ή εισαγωγές χρηστών, χειριστείτε αυτές τις εξαιρέσεις γύρω από τον επαναυπολογισμό και την πρόσβαση στην τιμή:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Spreadsheet/CellCircularReferenceException.h>
#include <Spreadsheet/CellInvalidFormulaException.h>
#include <Spreadsheet/CellInvalidReferenceException.h>
#include <Spreadsheet/CellUnsupportedDataException.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Spreadsheet;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto cell = workbook->GetCell(0, u"A2");
cell->set_Formula(u"SUM(B2:B5)");

try
{
    workbook->CalculateFormulas();
    auto value = cell->get_Value();
}
catch (CellInvalidFormulaException&)
{
    // Διαχείριση μη έγκυρου τύπου.
}
catch (CellInvalidReferenceException&)
{
    // Διαχείριση μη έγκυρης αναφοράς κελιού.
}
catch (CellCircularReferenceException&)
{
    // Διαχείριση κυκλικής αναφοράς.
}
catch (CellUnsupportedDataException&)
{
    // Διαχείριση μη υποστηριζόμενων δεδομένων λογιστικού φύλλου.
}
```

## **Πρακτικοί Περιορισμοί**

Η υποστήριξη τύπων στα φύλλα εργασίας γραφημάτων προορίζεται για ένα καθορισμένο υποσύνολο υπολογισμών λογιστικών φύλλων, όχι για πλήρη συμβατότητα με το Excel. Λάβετε υπόψη αυτούς τους περιορισμούς όταν σχεδιάζετε μια ροή εργασίας αναφοράς:

- Χρησιμοποιήστε μόνο τις τεκμηριωμένες σταθερές, χειριστές, αναφορές και συναρτήσεις όταν χρειάζεστε τον επαναυπολογισμό τύπων από το Aspose.Slides.
- Επαναυπολογίστε μετά την αλλαγή κελιών από τα οποία εξαρτώνται τα αποτελέσματα των τύπων.
- Θεωρείτε τις αποθηκευμένες τιμές από φορτωμένες παρουσιάσεις ως στιγμιότυπα, όχι ως υποκατάστατο του επαναυπολογισμού μετά από επεξεργασίες.
- Δοκιμάστε τους τύπους από υπάρχοντα πρότυπα πριν βασιστείτε στις υπολογισμένες τους τιμές, ειδικά όταν χρησιμοποιούν συναρτήσεις εκτός της τεκμηριωμένης λίστας.
- Για τύπους που απαιτούν πλήρη μηχανή υπολογισμού λογιστικού φύλλου, υπολογίστε τους εξωτερικά και, στη συνέχεια, ενημερώστε το βιβλίο εργασίας γραφήματος με τις προκύπτουσες τιμές.

## **FAQ**

**What is the difference between `set_Formula` and `set_R1C1Formula`?**

[IChartDataCell::set_Formula](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdatacell/set_formula/) stores an A1-style expression such as `B2-C2`. [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) stores an R1C1-style expression such as `RC[-2]-RC[-1]`. Use the notation that best matches how you generate or copy formulas.

**Do I need to read the cell itself or its value after calculation?**

[IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) returns an `IChartDataCell`. To obtain the calculated result, read that cell's [IChartDataCell::get_Value](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdatacell/get_value/) value after recalculation.

**When should I call `CalculateFormulas`?**

Call [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) after changing input values or formulas and before you depend on the calculated results. This updates the values of formulas that the built-in evaluator supports.

**Does Aspose.Slides support every Excel function?**

No. The built-in evaluator supports a documented subset of functions. Functions outside that subset should not be assumed to recalculate correctly. If full Excel formula compatibility is required, perform the calculation with an appropriate spreadsheet engine and write the final values to the chart workbook.

**What happens if a loaded presentation contains an unsupported formula?**

If the chart data has not changed, the workbook may still contain a previously calculated cached value. After related data is modified, that cached value may no longer be valid. Accessing a cell whose formula cannot be handled can raise [CellUnsupportedDataException](https://reference.aspose.com/slides/el/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/).

**Are formula error values the same as C++ exceptions?**

No. A result such as `#DIV/0!` is a spreadsheet value produced by a valid calculation. Exceptions such as [CellInvalidFormulaException](https://reference.aspose.com/slides/el/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/) or [CellCircularReferenceException](https://reference.aspose.com/slides/el/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/) indicate that the formula cannot be processed normally.

**Does a chart update automatically when a formula cell changes?**

A chart series can reference workbook cells. Recalculate the workbook first, then save or render the presentation. If the chart data points reference the calculated cells, the chart uses those updated cell values; no separate chart-refresh method is required for this workflow.

**Can charts use an external Excel workbook?**

Yes, chart data can be configured to use an external workbook through the chart data API. However, the formula calculation workflow described in this article concerns the chart data workbook and the formula subset evaluated by Aspose.Slides. Do not assume that [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) provides full recalculation of arbitrary formulas in an external XLSX file.

**Can I use formulas that reference another worksheet or workbook?**

Excel-style references may exist in chart workbooks, but formula evaluation is limited by the supported parser and function set. If a cross-sheet or external reference is essential, validate that exact formula with your target Aspose.Slides version. For workflows that require broad Excel reference compatibility, calculate the workbook externally and write the resolved values back to the chart data.

**Should formula strings start with `=`?**

The Aspose.Slides API examples assign expressions such as `B2-C2` or `SUM(B2:B5)` without a leading `=`. Using that form keeps generated formulas consistent with the documented API examples.