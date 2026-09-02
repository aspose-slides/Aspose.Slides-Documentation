---
title: Εφαρμογή τύπων φύλλου εργασίας διαγράμματος σε παρουσιάσεις με C++
linktitle: Τύποι φύλλου εργασίας
type: docs
weight: 70
url: /el/cpp/chart-worksheet-formulas/
keywords:
- υπολογιστικό φύλλο διαγράμματος
- φύλλο εργασίας διαγράμματος
- τύπος διαγράμματος
- τύπος φύλλου εργασίας
- τύπος υπολογιστικού φύλλου
- βιβλίο δεδομένων διαγράμματος
- υπολογισμός τύπων
- λογική σταθερά
- αριθμητική σταθερά
- σταθερά συμβολοσειράς
- σταθερά σφάλματος
- αριθμητικός τελεστής
- τελεστής σύγκρισης
- στυλ A1
- στυλ R1C1
- προκαθορισμένη συνάρτηση
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Εφαρμόστε τύπους σε στυλ Excel σε φύλλα εργασίας διαγράμματος Aspose.Slides για C++, επαναυπολογίστε τις τιμές και χρησιμοποιήστε τα αποτελέσματα σε διαγράμματα PowerPoint."
---
## **Επισκόπηση**

Τα διαγράμματα PowerPoint συνήθως αποθηκεύουν τα δεδομένα προέλευσής τους σε ένα ενσωματωμένο φύλλο εργασίας. Στο Aspose.Slides για C++, μπορείτε να αποκτήσετε πρόσβαση σε αυτό το φύλλο εργασίας μέσω του βιβλίου εργασίας δεδομένων διαγράμματος, να γράψετε τιμές εισόδου, να εκχωρήσετε τύπους στα κελιά, να υπολογίσετε τους υποστηριζόμενους τύπους και να χρησιμοποιήσετε τα υπολογισμένα κελιά ως δεδομένα διαγράμματος.

Το άρθρο αυτό εξηγεί τη συνολική διαδικασία τύπων: δημιουργία διαγράμματος, γεμίσμα του φύλλου εργασίας του, εκχώρηση τύπων στυλ A1 ή R1C1, επανυπολογισμός, ανάγνωση των υπολογισμένων τιμών, σύνδεση των κελιών με μια σειρά διαγράμματος και αποθήκευση της παρουσίασης. Περιγράφει επίσης τη σύνταξη των υποστηριζόμενων τύπων, το ενσωματωμένο υποσύνολο συναρτήσεων, τις αποθηκευμένες τιμές, τους μη υποστηριζόμενους τύπους και τα σφάλματα συγκεκριμένα για λογιστικά αρχεία.

## **Φύλλα Εργασίας Διαγραμμάτων και Τύποι**

Ένα φύλλο εργασίας διαγράμματος περιέχει τις κατηγορίες, τα ονόματα σειρών και τις τιμές που χρησιμοποιεί ένα διάγραμμα. Στο PowerPoint, μπορείτε να δείτε το φύλλο εργασίας ανοίγοντας τον επεξεργαστή δεδομένων διαγράμματος:

![Διάγραμμα PowerPoint με ανοικτό ενσωματωμένο φύλλο εργασίας, εμφανίζει δεδομένα κατηγορίας και σειράς](chart-worksheet-formulas_1.png)

Στο Aspose.Slides, το φύλλο εργασίας εκτίθεται μέσω της διεπαφής [IChartDataWorkbook](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdataworkbook/). Χρησιμοποιήστε [IChartDataCell::set_Formula](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdatacell/set_formula/) για τύπους στυλ A1 και [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) για τύπους στυλ R1C1. Μετά την αλλαγή των κελιών εισόδου ή των τύπων, καλέστε [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) για να επανυπολογίσετε τους υποστηριζόμενους τύπους και να ενημερώσετε τις αντίστοιχες τιμές κελιών.

Ένα υπολογισμένο κελί εξακολουθεί να εκθέτει το αποτέλεσμα του μέσω [IChartDataCell::get_Value](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdatacell/get_value/). Αυτό είναι σημαντικό όταν χρειάζεται να εξετάσετε το αποτέλεσμα ενός τύπου σε κώδικα ή να χρησιμοποιήσετε το κελί ως σημείο δεδομένων διαγράμματος.

## **Δημιουργία Διαγράμματος και Υπολογισμός Τύπων Φύλλου Εργασίας**

Το παρακάτω παράδειγμα παρουσιάζει μια πλήρη ροή εργασίας. Δημιουργεί ένα διάγραμμα στήλης σε στήλες, καθαρίζει τα δείγματα δεδομένων, γράφει τριμηνιαίες τιμές εσόδων και εξόδων, υπολογίζει κέρδος με τύπους, διαβάζει τα αποτελέσματα, χρησιμοποιεί τα υπολογισμένα κελιά ως τιμές διαγράμματος και αποθηκεύει την παρουσίαση.

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

Τα σημεία δεδομένων του διαγράμματος αναφέρονται στο `D2:D4`, έτσι το διάγραμμα χρησιμοποιεί τις υπολογισμένες τιμές κέρδους. Δεν υπάρχει ξεχωριστή κλήση ανανέωσης διαγράμματος σε αυτή τη ροή: επανυπολογίστε πρώτα το βιβλίο εργασίας, έπειτα χρησιμοποιήστε ή αποθηκεύστε τα δεδομένα διαγράμματος που δείχνουν στα υπολογισμένα κελιά.

## **Χρήση Τύπων Στυλ A1**

Η σημειογραφία A1 προσδιορίζει τις στήλες με γράμματα και τις γραμμές με αριθμούς. Εκχωρήστε εκφράσεις στυλ A1 μέσω [IChartDataCell::set_Formula](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdatacell/set_formula/).

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
| Περιοχή | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Οι σχετικές αναφορές μπορούν να αλλάξουν όταν ένας τύπος μετακινείται ή αντιγράφεται από μια εφαρμογή λογιστικού φύλλου. Οι απόλυτες αναφορές διατηρούν και τις δύο συντεταγμένες σταθερές, ενώ οι μικτές διορθώνουν μόνο μια γραμμή ή μια στήλη.

## **Χρήση Τύπων Στυλ R1C1**

Η σημειογραφία R1C1 προσδιορίζει τόσο τις γραμμές όσο και τις στήλες αριθμητικά. Οι σχετικές αναφορές χρησιμοποιούν μετατοπίσεις σε τετράγωνες αγκύλες. Εκχωρήστε αυτή τη σύνταξη μέσω [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/).

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
| Περιοχή | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Για παράδειγμα, στο κελί `D2`, το `RC[-2]` σημαίνει το κελί στην ίδια γραμμή δύο στήλες αριστερά (`B2`).

## **Σταθερές και Τελεστές Τύπων**

Ο ενσωματωμένος αξιολογητής τύπων υποστηρίζει λογικές τιμές, αριθμητικά λογοπρικά, συμβολοσειρές, τιμές σφάλματος λογιστικού φύλλου, αριθμητικούς τελεστές και τελεστές σύγκρισης.

### **Σταθερές και Συμβολισμοί**

| Τύπος | Παραδείγματα | Σημειώσεις |
|---|---|---|
| Λογική | `TRUE`, `FALSE` | Μπορεί να χρησιμοποιηθεί άμεσα σε λογικές εκφράσεις όπως `A2=TRUE`. |
| Αριθμητική | `1`, `0.5`, `.3`, `1E-2` | Υποστηρίζονται η κοινή και η επιστημονική σημειογραφία. |
| Συμβολοσειρά | `"abc"`, `"2/3/2020 12:00"` | Τα κυριολεκτικά κείμενα περικλείονται σε διπλά εισαγωγικά μέσα στον τύπο. |
| Αποτέλεσμα σφάλματος | `#DIV/0!`, `#N/A`, `#REF!` | Ένας έγκυρος τύπος μπορεί να αξιολογηθεί σε τιμή σφάλματος λογιστικού φύλλου αντί για κανονικό αποτέλεσμα. |

Αυτό το παράδειγμα χρησιμοποιεί πολλαπλούς τύπους σταθερών:

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

### **Αριθμητικοί Τελεστές**

| Τελεστής | Σημασία | Παράδειγμα |
|---|---|---|
| `+` | Άθροιση ή μονοπρόσημο + | `2+3` |
| `-` | Αφαίρεση ή αρνησημός | `2-3`, `-3` |
| `*` | Πολλαπλασιασμός | `2*3` |
| `/` | Διαίρεση | `2/3` |
| `%` | Ποσοστό | `30%` |
| `^` | Ανύψωση σε δύναμη | `2^3` |

Χρησιμοποιήστε παρενθέσεις για να κάνετε ρητή τη σειρά εκτίμησης, π.χ. `(A2+B2)*C2`.

### **Τελεστές Σύγκρισης**

Οι συγκριτικές εκφράσεις επιστρέφουν λογικές τιμές.

| Τελεστής | Σημασία | Παράδειγμα |
|---|---|---|
| `=` | Ίσο | `A2=3` |
| `<>` | Διάφορο | `A2<>3` |
| `>` | Μεγαλύτερο | `A2>3` |
| `>=` | Μεγαλύτερο ή ίσο | `A2>=3` |
| `<` | Μικρότερο | `A2<3` |
| `<=` | Μικρότερο ή ίσο | `A2<=3` |

## **Υποστηριζόμενες Προκαθορισμένες Συναρτήσεις**

Το Aspose.Slides περιλαμβάνει έναν ενσωματωμένο αξιολογητή τύπων για φύλλα εργασίας διαγραμμάτων, αλλά δεν είναι πλήρης μηχανή υπολογισμών Excel. Το τεκμηριωμένο σύνολο συναρτήσεων περιορίζεται στις παρακάτω. Μην υποθέτετε ότι ένας αυθαίρετος τύπος Excel μπορεί να επανυπολογιστεί με το [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/).

| Συνάρτηση | Σκοπός ή υποστηριζόμενη μορφή | Παράδειγμα |
|---|---|---|
| `ABS` | Απόλυτη τιμή | `ABS(A2)` |
| `AVERAGE` | Αριθμητικός μέσος | `AVERAGE(B2:B5)` |
| `CEILING` | Στρογγυλοποίηση αριθμού προς τα πάνω στο πολλαπλάσιο | `CEILING(A2,5)` |
| `CHOOSE` | Επιλογή τιμής κατά δείκτη | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Συγκόλληση κειμενικών τιμών | `CONCAT(A2,B2)` |
| `CONCATENATE` | Συγκόλληση κειμενικών τιμών | `CONCATENATE(A2," ",B2)` |
| `DATE` | Δημιουργία τιμής ημερομηνίας με σύστημα 1900 | `DATE(2026,8,19)` |
| `DAYS` | Επιστρέφει τον αριθμό ημερών μεταξύ ημερομηνιών | `DAYS(B2,A2)` |
| `FIND` | Εύρεση μιας τιμής κειμένου μέσα σε άλλη | `FIND("-",A2)` |
| `FINDB` | Αναζήτηση κειμένου ανά byte | `FINDB("a",A2)` |
| `IF` | Υποσχετική τιμή | `IF(A2>0,A2,0)` |
| `INDEX` | Μορφή αναφοράς | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Μορφή διανύσματος | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Μορφή διανύσματος | `MATCH(A2,B2:B5,0)` |
| `MAX` | Μέγιστη τιμή | `MAX(B2:B5)` |
| `SUM` | Άθροιση τιμών | `SUM(B2:B5)` |
| `VLOOKUP` | Κατακόρυφη αναζήτηση | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Οι περιορισμοί που φαίνονται στον πίνακα είναι σημαντικοί: το `INDEX` τεκμηριώνεται στη μορφή αναφοράς, ενώ τα `LOOKUP` και `MATCH` στη μορφή διανύσματος. Το `DATE` χρησιμοποιεί το σύστημα ημερομηνίας 1900. Λειτουργίες και συναρτήσεις που δεν αναφέρονται εδώ θεωρούνται μη υποστηριζόμενες από τον αξιολογητή τύπων του Aspose.Slides, εκτός αν τεκμηριώνονται ξεχωριστά.

## **Επανάληψη Υπολογισμού και Αποθηκευμένες Τιμές**

Τα αρχεία λογιστικών φύλλων συνήθως αποθηκεύουν τόσο τον τύπο όσο και την τελευταία υπολογισμένη τιμή του. Το Aspose.Slides μπορεί έτσι να διαβάσει μια αποθηκευμένη τιμή από το [IChartDataCell::get_Value](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdatacell/get_value/) όταν φορτώνεται μια παρουσίαση και τα σχετικά δεδομένα διαγράμματος δεν έχουν αλλάξει.

Μετά την αλλαγή κελιών εισόδου ή τύπων, μην βασίζεστε σε παλιό αποθηκευμένο αποτέλεσμα. Καλέστε το [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) πριν διαβάσετε τις υπολογισμένες τιμές ή αποθηκεύσετε δεδομένα διαγράμματος που εξαρτώνται από αυτές.

Για τύπους εκτός του υποσυνόλου, το Aspose.Slides ενδέχεται να μην μπορεί να αναλύσει τον τύπο ή να καθορίσει τις εξαρτήσεις του. Εάν το βιβλίο εργασίας έχει τροποποιηθεί, η προηγούμενη αποθηκευμένη τιμή δεν είναι πλέον αξιόπιστη. Σε αυτή την περίπτωση, η ανάγνωση της τιμής κελιού με μη υποστηριζόμενα δεδομένα μπορεί να προκαλέσει την εξαίρεση [CellUnsupportedDataException](https://reference.aspose.com/slides/el/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Αν το διάγραμμά σας εξαρτάται από συναρτήσεις Excel που το Aspose.Slides δεν αξιολογεί, υπολογίστε αυτούς τους τύπους με μια μηχανή λογιστικού φύλλου που τους υποστηρίζει και γράψτε τις προκύπτουσες τιμές πίσω στο βιβλίο εργασίας διαγράμματος. Μην αντικαθιστάτε μη υποστηριζόμενους τύπους με εκτιμημένες τιμές.

## **Διαχείριση Σφαλμάτων Τύπων**

Υπάρχουν δύο διαφορετικά είδη προβλημάτων που πρέπει να διαχωριστούν.

Ένας τύπος μπορεί να είναι έγκυρος αλλά να παράγει αποτέλεσμα σφάλματος λογιστικού φύλλου όπως `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` ή `#VALUE!`. Σε αυτήν την περίπτωση, το διάγραμμα σφάλματος είναι αποτέλεσμα κελιού και μπορεί να επιστραφεί μέσω του [IChartDataCell::get_Value](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdatacell/get_value/).

Ένας τύπος μπορεί επίσης να αποτύχει κατά την ανάλυση, την αναφορά, τη διαάρτηση ή στο επίπεδο υποστηριζόμενων δεδομένων. Το Aspose.Slides παρέχει εξαιρέσεις συγκεκριμένες για λογιστικά φύλλα για αυτές τις περιπτώσεις: [CellInvalidFormulaException](https://reference.aspose.com/slides/el/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/el/cpp/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/el/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/), και [CellUnsupportedDataException](https://reference.aspose.com/slides/el/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Όταν οι τύποι προέρχονται από πρότυπα ή από είσοδο χρήστη, χειριστείτε αυτές τις εξαιρέσεις γύρω από τον επανυπολογισμό και την πρόσβαση στην τιμή:

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
    // Διαχειριστείτε έναν μη έγκυρο τύπο.
}
catch (CellInvalidReferenceException&)
{
    // Διαχειριστείτε μια μη έγκυρη αναφορά κελιού.
}
catch (CellCircularReferenceException&)
{
    // Διαχειριστείτε μια κυκλική αναφορά.
}
catch (CellUnsupportedDataException&)
{
    // Διαχειριστείτε μη υποστηριζόμενα δεδομένα λογιστικού φύλλου.
}
```

## **Πρακτικοί Περιορισμοί**

Η υποστήριξη τύπων σε φύλλα εργασίας διαγραμμάτων προορίζεται για ένα ορισμένο υποσύνολο υπολογισμών λογιστικού φύλλου, όχι για πλήρη συμβατότητα με το Excel. Λάβετε υπόψη αυτούς τους περιορισμούς κατά το σχεδιασμό μιας ροής αναφοράς:

- Χρησιμοποιήστε μόνο τις τεκμηριωμένες σταθερές, τελεστές, αναφορές και συναρτήσεις όταν χρειάζεστε το Aspose.Slides να επανυπολογίσει τύπους.
- Επανυπολογίστε μετά την αλλαγή των κελιών από τα οποία εξαρτώνται τα αποτελέσματα των τύπων.
- Θεωρείτε τις αποθηκευμένες τιμές από φορτωμένες παρουσιάσεις ως στιγμιότυπα, όχι ως αντικατάσταση του επανυπολογισμού μετά τις επεξεργασίες.
- Δοκιμάστε τους τύπους από υπάρχοντα πρότυπα πριν βασιστείτε στις υπολογισμένες τιμές, ειδικά όταν χρησιμοποιούν συναρτήσεις εκτός της λίστας.
- Για τύπους που απαιτούν πλήρη μηχανή υπολογισμού λογιστικού φύλλου, υπολογίστε τους εξωτερικά και έπειτα ενημερώστε το βιβλίο εργασίας διαγράμματος με τις προκύπτουσες τιμές.

## **FAQ**

**Ποια είναι η διαφορά μεταξύ `set_Formula` και `set_R1C1Formula`;**

[IChartDataCell::set_Formula](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdatacell/set_formula/) αποθηκεύει μια έκφραση στυλ A1 όπως `B2-C2`. [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) αποθηκεύει μια έκφραση στυλ R1C1 όπως `RC[-2]-RC[-1]`. Χρησιμοποιήστε τη σημειογραφία που ταιριάζει καλύτερα με τον τρόπο δημιουργίας ή αντιγραφής των τύπων.

**Πρέπει να διαβάσω το ίδιο το κελί ή την τιμή του μετά τον υπολογισμό;**

[IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) επιστρέφει ένα `IChartDataCell`. Για να αποκτήσετε το υπολογισμένο αποτέλεσμα, διαβάστε την τιμή του [IChartDataCell::get_Value](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdatacell/get_value/) μετά τον επανυπολογισμό.

**Πότε πρέπει να καλέσω το `CalculateFormulas`;**

Καλέστε το [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) μετά την αλλαγή τιμών εισόδου ή τύπων και πριν εξαρτηθείτε από τα υπολογισμένα αποτελέσματα. Αυτό ενημερώνει τις τιμές των τύπων που υποστηρίζονται από τον ενσωματωμένο αξιολογητή.

**Υποστηρίζει το Aspose.Slides κάθε συνάρτηση του Excel;**

Όχι. Ο ενσωματωμένος αξιολογητής υποστηρίζει μόνο ένα τεκμηριωμένο υποσύνολο συναρτήσεων. Δεν πρέπει να υποθέτετε ότι μια τυχαία συνάρτηση Excel θα επανυπολογιστεί σωστά. Αν απαιτείται πλήρης συμβατότητα τύπων Excel, εκτελέστε τον υπολογισμό με μια κατάλληλη μηχανή λογιστικού φύλλου και γράψτε τις τελικές τιμές στο βιβλίο εργασίας διαγράμματος.

**Τι συμβαίνει αν μια φορτωμένη παρουσίαση περιέχει έναν μη υποστηριζόμενο τύπο;**

Αν τα δεδομένα διαγράμματος δεν έχουν αλλάξει, το βιβλίο εργασίας μπορεί ακόμη να περιέχει μια προηγουμένως υπολογισμένη αποθηκευμένη τιμή. Αφού τροποποιηθούν τα σχετιζόμενα δεδομένα, αυτή η αποθηκευμένη τιμή μπορεί να μην είναι πλέον έγκυρη. Η πρόσβαση σε κελί με τύπο που δεν μπορεί να διαχειριστεί μπορεί να προκαλέσει την εξαίρεση [CellUnsupportedDataException](https://reference.aspose.com/slides/el/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/).

**Είναι οι τιμές σφάλματος τύπου ίδιες με τις εξαιρέσεις C++;**

Όχι. Μια τιμή όπως `#DIV/0!` είναι μια τιμή λογιστικού φύλλου που παράγεται από έναν έγκυρο υπολογισμό. Εξαιρέσεις όπως [CellInvalidFormulaException](https://reference.aspose.com/slides/el/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/) ή [CellCircularReferenceException](https://reference.aspose.com/slides/el/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/) υποδεικνύουν ότι ο τύπος δεν μπορεί να επεξεργαστεί κανονικά.

**Ενημερώνεται αυτόματα ένα διάγραμμα όταν αλλάζει ένα κελί τύπου;**

Μια σειρά διαγράμματος μπορεί να αναφέρεται σε κελιά βιβλίου εργασίας. Επανυπολογίστε πρώτα το βιβλίο εργασίας, έπειτα αποθηκεύστε ή αποδώστε την παρουσίαση. Αν τα σημεία δεδομένων του διαγράμματος αναφέρονται στα υπολογισμένα κελιά, το διάγραμμα χρησιμοποιεί αυτές τις ενημερωμένες τιμές· δεν απαιτείται ξεχωριστή μέθοδος ανανέωσης για αυτήν τη ροή.

**Μπορούν τα διαγράμματα να χρησιμοποιούν εξωτερικό βιβλίο εργασίας Excel;**

Ναι, τα δεδομένα διαγράμματος μπορούν να ρυθμιστούν να χρησιμοποιούν εξωτερικό βιβλίο εργασίας μέσω του API δεδομένων διαγράμματος. Ωστόσο, η ροή υπολογισμού τύπων που περιγράφεται σε αυτό το άρθρο αφορά το βιβλίο εργασίας δεδομένων διαγράμματος και το υποσύνολο τύπων που αξιολογεί το Aspose.Slides. Μην υποθέτετε ότι το [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) παρέχει πλήρη επανυπολογισμό αυθαίρετων τύπων σε εξωτερικό αρχείο XLSX.

**Μπορώ να χρησιμοποιήσω τύπους που αναφέρονται σε άλλο φύλλο ή βιβλίο εργασίας;**

Οι αναφορές τύπου Excel μπορεί να υπάρχουν σε βιβλία εργασίας διαγράμματος, αλλά η αξιολόγηση τύπων περιορίζεται από τον υποστηριζόμενο αναλυτή και το σύνολο συναρτήσεων. Αν απαιτείται διασυνδεσμός φύλλων ή εξωτερική αναφορά, επαληθεύστε τον ακριβή τύπο με τη συγκεκριμένη έκδοση Aspose.Slides. Για ροές που απαιτούν ευρεία συμβατότητα αναφορών Excel, υπολογίστε το βιβλίο εργασίας εξωτερικά και γράψτε τις επιλυμένες τιμές πίσω στα δεδομένα διαγράμματος.

**Πρέπει οι συμβολοσειρές τύπων να αρχίζουν με `=`;**

Τα παραδείγματα API του Aspose.Slides αναθέτουν εκφράσεις όπως `B2-C2` ή `SUM(B2:B5)` χωρίς το αρχικό `=`. Η χρήση αυτής της μορφής διατηρεί τους δημιουργημένους τύπους συνεπείς με τα τεκμηριωμένα παραδείγματα API.