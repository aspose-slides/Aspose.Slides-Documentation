---
title: Διαχείριση Σειρών Δεδομένων Διαγράμματος σε Παρουσιάσεις σε C++
linktitle: Σειρές Δεδομένων
type: docs
url: /el/cpp/chart-series/
keywords:
- σειρά διαγράμματος
- επικάλυψη σειράς
- χρώμα σειράς
- χρώμα κατηγορίας
- όνομα σειράς
- σημείο δεδομένων
- κενό σειράς
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Μάθετε πώς να διαχειρίζεστε τις σειρές διαγράμματος, τα σημεία δεδομένων, τα κελιά του βιβλίου εργασίας, τη μορφοποίηση, την επικάλυψη, το πλάτος κενών και τις αρνητικές τιμές σε παρουσιάσεις με C++."
---
## **Επισκόπηση**

Ένα διάγραμμα μπορεί να αποθηκεύει τις σχεδιασμένες τιμές του σε κελιά βιβλίου εργασίας ή απευθείας ως αριθμητικά κυριολεξικά. Ένα [IChartSeries](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/) αντιπροσωπεύει ένα σύνολο σχετικών τιμών, και κάθε [IChartDataPoint](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/) αντιπροσωπεύει ένα σημείο σε αυτή τη σειρά. Τα αντικείμενα [IChartCategory](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartcategory/) παρέχουν τις ετικέτες ή τις τιμές ομαδοποίησης που μοιράζονται οι σειρές. Σε διαγράμματα που δημιουργούνται με προεπιλεγμένα δεδομένα, τα ονόματα σειρών, οι κατηγορίες και οι τιμές σημείων χρησιμοποιούν αντικείμενα [IChartDataCell](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/) από το βιβλίο εργασίας του διαγράμματος.

Για ένα τυπικό διάγραμμα κατηγορίας, το προεπιλεγμένο βιβλίο εργασίας χρησιμοποιεί τη γραμμή 0 για τα ονόματα σειρών, τη στήλη 0 για τα ονόματα κατηγοριών και τα υπόλοιπα κελιά για τις τιμές σειρών. Οι δείκτες φύλλου εργασίας, γραμμής και στήλης που περνούν στο [IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) είναι μηδενικά‑βασισμένοι. Αυτή η διάταξη είναι χρήσιμη όταν δημιουργείτε ένα διάγραμμα με προεπιλεγμένα δεδομένα, αλλά μην υποθέτετε ότι κάθε υπάρχον διάγραμμα τη χρησιμοποιεί. Για μια φορτωμένη παρουσίαση, ελέγξτε τα κελιά στα οποία αναφέρονται οι σειρές, οι κατηγορίες και τα σημεία δεδομένων πριν αλλάξετε τις τιμές του βιβλίου εργασίας.

Οι ρυθμίσεις του διαγράμματος έχουν τρία διαφορετικά επίπεδα:

- Ρυθμίσεις επιπέδου σειράς, όπως η [IChartSeries::get_Format](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_format/), παρέχουν την προεπιλεγμένη εμφάνιση για όλα τα σημεία μιας σειράς.
- Ρυθμίσεις σημείου δεδομένων, όπως η [IChartDataPoint::get_Format](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_format/), παρακάμπτουν την εμφάνιση της σειράς για ένα σημείο.
- Ρυθμίσεις ομάδας εφαρμόζονται σε συμβατές σειρές που ανήκουν στο ίδιο [IChartSeriesGroup](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/). Πρόσβαση στην ομάδα μέσω της [IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/) όταν χρειάζεται να ορίσετε επιλογές όπως το πλάτος επικάλυψης ή το κενό.

Όταν δεν έχει οριστεί ρητή γέμιση σημείου ή σειράς, το στυλ και το θέμα του διαγράμματος καθορίζουν την αυτόματη εμφάνιση. Όταν υπάρχουν τόσο ρυθμίσεις σειράς όσο και σημείου, η ρύθμιση του σημείου προδιαγράφει για εκείνο το σημείο.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Ορισμός Τιμών Σειράς με Αριθμητικά Κυριολεξικά**

Χρησιμοποιήστε αριθμητικά κυριολεξικά όταν οι τιμές της σειράς προέρχονται από δεδομένα ή υπολογισμούς της εφαρμογής και δεν χρειάζονται αναφορές σε κελιά του φύλλου εργασίας. Καλέστε το [set_DataSourceTypeForValues](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointcollection/set_datasourcetypeforvalues/) με το [DataSourceType::DoubleLiterals](https://reference.aspose.com/slides/cpp/aspose.slides.charts/datasourcetype/) πριν αντιστοιχίσετε την τιμή που επιστρέφεται από το [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_value/) του κάθε σημείου μέσω του [set_AsLiteralDouble](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idoublechartvalue/set_asliteraldouble/).

Η ρύθμιση της συλλογής ελέγχει τον τύπο πηγής όλων των τιμών σημείων σε αυτή τη σειρά. Η [IBaseChartValue::get_DataSourceType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ibasechartvalue/get_datasourcetype/) του κάθε σημείου αναφέρει τον επιλεγμένο τύπο· αλλάξτε τον μέσω της ρύθμισης της συλλογής. Με `Worksheet`, χρησιμοποιήστε το [get_AsCell](https://reference.aspose.com/slides/cpp/aspose.slides.charts/isinglecellchartvalue/get_ascell/) για πρόσβαση στο αναφερόμενο κελί. Με `DoubleLiterals`, χρησιμοποιήστε το [get_AsLiteralDouble](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idoublechartvalue/get_asliteraldouble/) ή το `set_AsLiteralDouble` για ανάγνωση ή εγγραφή του αριθμού απευθείας.

Το παρακάτω παράδειγμα δημιουργεί ένα διάγραμμα στήλης με προεπιλεγμένες σειρές και κατηγορίες, στη συνέχεια αντιστοιχίζει υπολογισμένες τιμές 10, 20 κ.λπ. στα υπάρχοντα σημεία της πρώτης σειράς. Αποθηκεύει την παρουσίαση, την ανοίγει ξανά και εκτυπώνει τις αποθηκευμένες τιμές.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/DataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20, 20, 500, 300);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

series->get_DataPoints()->set_DataSourceTypeForValues(DataSourceType::DoubleLiterals);
for (auto i = 0; i < series->get_DataPoints()->get_Count(); i++)
{
    series->get_DataPoints()->idx_get(i)->get_Value()->set_AsLiteralDouble((i + 1) * 10);
}

presentation->Save(u"numeric_literals.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopenedPresentation = MakeObject<Presentation>(u"numeric_literals.pptx");
auto reopenedSlide = reopenedPresentation->get_Slide(0);
auto reopenedChart = ExplicitCast<IChart>(reopenedSlide->get_Shape(0));
auto reopenedSeries = reopenedChart->get_ChartData()->get_Series()->idx_get(0);
for (auto i = 0; i < reopenedSeries->get_DataPoints()->get_Count(); i++)
{
    auto point = reopenedSeries->get_DataPoints()->idx_get(i);
    Console::WriteLine(point->get_Value()->get_AsLiteralDouble());
}
reopenedPresentation->Dispose();
```

Ο τύπος πηγής της τιμής του σημείου είναι ξεχωριστός από το [IChartData::get_DataSourceType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_datasourcetype/), το οποίο προσδιορίζει τη διαμόρφωση του εσωτερικού ή εξωτερικού βιβλίου εργασίας του διαγράμματος. Η χρήση αριθμητικών κυριολεξικών δεν αφαιρεί, από μόνη της, το ενσωματωμένο βιβλίο εργασίας. Σε αυτό το παράδειγμα, το βιβλίο εργασίας παραμένει διαθέσιμο για ετικέτες κατηγοριών, ονόματα σειρών και τις άλλες σειρές. Δείτε το [Chart Workbook](/slides/el/cpp/chart-workbook/) για διαχείριση βιβλίου εργασίας.

Για διαγράμματα σκαρτέν (scatter) και φυσαλίδων, καλέστε το [set_DataSourceTypeForXValues](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointcollection/set_datasourcetypeforxvalues/) και το [set_DataSourceTypeForYValues](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointcollection/set_datasourcetypeforyvalues/) για επιλογή πηγών των [get_XValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_xvalue/) και [get_YValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_yvalue/). Τα διαγράμματα φυσαλίδων χρησιμοποιούν επίσης το [set_DataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointcollection/set_datasourcetypeforbubblesizes/) για το [get_BubbleSize](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_bubblesize/). Ορίστε κάθε εφαρμόσιμο πηγή σε `DoubleLiterals` πριν αντιστοιχίσετε αριθμούς μέσω της μεθόδου `set_AsLiteralDouble` της τιμής.

## **Ορισμός Επικάλυψης Σειρών Διαγράμματος**

Το [IChartSeries::get_Overlap](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_overlap/) αναφέρει πόσο επικάλλονται ράβδοι ή στήλες σε 2Δ διάγραμμα, από -100 έως 100 τοις εκατό. Είναι μια μόνο‑ανάγνωση προβολή της ρύθμισης στην ομάδα γονέα της σειράς. Καλέστε το [IChartSeriesGroup::set_Overlap](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_overlap/) για ενημέρωση όλων των συμβατών σειρών στην ομάδα. Αυτή η επιλογή εφαρμόζεται σε τύπους διαγραμμάτων που εμφανίζουν ομαδοποιημένους ράβδους ή στήλες· δεν επηρεάζει ανεξάρτητες ομάδες σειρών σε συνδυαστικό διάγραμμα.

Το παρακάτω παράδειγμα ορίζει την επικάλυψη για την ομάδα που περιέχει την πρώτη σειρά:

```cpp
#include <cstdint>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int8_t overlapPercent = 30;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

// Το νέο διάγραμμα περιέχει δείγμα σειρών, κατηγοριών και τιμών.
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
series->get_ParentSeriesGroup()->set_Overlap(overlapPercent);

presentation->Save(u"series_overlap.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![The series overlap](series_overlap.png)

## **Αλλαγή Χρώματος Γέμισης Σειράς**

Χρησιμοποιήστε το [IChartSeries::get_Format](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_format/) για ορισμό της προεπιλεγμένης γέμισης ολόκληρης μιας σειράς. Εάν ένα σημείο έχει ήδη ρητή γέμιση, η ρύθμιση του [IChartDataPoint::get_Format](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_format/) παρακάμπτει τη γέμιση της σειράς για εκείνο το σημείο.

Το παρακάτω παράδειγμα εφαρμόζει συμπαγή μπλε γέμιση στην πρώτη σειρά:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::FillType;
using Aspose::Slides::Presentation;
using System::Drawing::Color;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
auto seriesColor = Color::get_Blue();
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(seriesColor);

presentation->Save(u"series_color.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![The color of the series](series_color.png)

## **Αλλαγή Ονόματος Σειράς**

Το όνομα μιας σειράς αποθηκεύεται στο βιβλίο δεδομένων του διαγράμματος και συνήθως εμφανίζεται στο υπόμνημα. Στο προεπιλεγμένο βιβλίο εργασίας που δημιουργείται για ένα συγκεντρωτικό διάγραμμα στήλης, το κελί B1 βρίσκεται στη γραμμή 0, στήλη 1 και περιέχει το όνομα της πρώτης σειράς. Οι σταθερές ονομασίας στο παρακάτω παράδειγμα κάνουν αυτή τη δομή ρητή:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::ObjectExt;
using System::String;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int seriesNameRowIndex = 0;
const int firstSeriesColumnIndex = 1;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto seriesNameCell = workbook->GetCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
auto seriesName = ObjectExt::Box<String>(u"Revenue");
seriesNameCell->set_Value(seriesName);

presentation->Save(u"series_name.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Μπορείτε επίσης να ενημερώσετε το κελί που ήδη αναφέρεται από το [IChartSeries::get_Name](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_name/). Αυτή η προσέγγιση αποφεύγει την υπόθεση συγκεκριμένης γραμμής και στήλης σε υπάρχον διάγραμμα:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCellCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IStringChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::ObjectExt;
using System::String;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int firstNameCellIndex = 0;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
auto seriesNameCells = series->get_Name()->get_AsCells();
auto seriesNameCell = seriesNameCells->idx_get(firstNameCellIndex);
auto seriesName = ObjectExt::Box<String>(u"Revenue");
seriesNameCell->set_Value(seriesName);

presentation->Save(u"series_name.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![The series name](series_name.png)

### **Δημιουργία Σειράς με Όνομα από Πολλά Κελιά**

Ένα σύνθετο όνομα σειράς είναι χρήσιμο όταν το όνομα προϊόντος και η περίοδος αναφοράς αποθηκεύονται σε ξεχωριστά κελιά του βιβλίου εργασίας. Για παράδειγμα, μπορείτε να συνδυάσετε το `Product A` στο B1 και το `2026` στο C1 σε ένα ενιαίο όνομα σειράς, διατηρώντας και τις δύο συνδεδεμένες με τα πηγαία κελιά τους.

Χρησιμοποιήστε το [IChartDataWorkbook::GetCellCollection](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/getcellcollection/) για λήψη της περιοχής ονόματος, στη συνέχεια περάστε αυτή τη συλλογή στο [IChartSeriesCollection::Add](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriescollection/add/). Το επιχείρημα `skipHiddenCells` ελέγχει αν τα κρυφά κελιά περιλαμβάνονται: `true` τα εξαιρεί, ενώ `false` τα περιλαμβάνει. Αυτό το παράδειγμα χρησιμοποιεί `false` για να συμπεριλάβει κάθε κελί στην περιοχή ονόματος.

Το παρακάτω παράδειγμα δημιουργεί μια παρουσίαση με μία σειρά και δύο σημεία δεδομένων. Τα κελιά B1:C1 παρέχουν μόνο το όνομα της σειράς· τα A2:A3 παρέχουν τις ετικέτες κατηγοριών, και τα B2:B3 παρέχουν τις αριθμητικές τιμές.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartCellCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using System::ObjectExt;
using System::String;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 620.0f, 180.0f);
auto chartData = chart->get_ChartData();

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();
chart->set_HasLegend(true);

auto workbook = chartData->get_ChartDataWorkbook();
workbook->Clear(0);

// Αυτά τα δύο κελιά παρέχουν το όνομα της σειράς.
auto productName = ObjectExt::Box<String>(u"Product A");
auto reportingPeriod = ObjectExt::Box<String>(u"2026");
workbook->GetCell(0, 0, 1, productName);
workbook->GetCell(0, 0, 2, reportingPeriod);
auto nameCells = workbook->GetCellCollection(u"Sheet1!$B$1:$C$1", false);
auto series = chartData->get_Series()->Add(nameCells, ChartType::ClusteredColumn);

// Ξεχωριστά κελιά παρέχουν τις κατηγορίες και τα αριθμητικά σημεία δεδομένων.
auto northLabel = ObjectExt::Box<String>(u"North");
auto southLabel = ObjectExt::Box<String>(u"South");
auto northCategory = workbook->GetCell(0, 1, 0, northLabel);
auto southCategory = workbook->GetCell(0, 2, 0, southLabel);
chartData->get_Categories()->Add(northCategory);
chartData->get_Categories()->Add(southCategory);
auto northAmount = ObjectExt::Box<int>(120);
auto southAmount = ObjectExt::Box<int>(150);
auto northValue = workbook->GetCell(0, 1, 1, northAmount);
auto southValue = workbook->GetCell(0, 2, 1, southAmount);
series->get_DataPoints()->AddDataPointForBarSeries(northValue);
series->get_DataPoints()->AddDataPointForBarSeries(southValue);

presentation->Save(u"composite_series_name.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το παραγόμενο όνομα σειράς είναι `Product A 2026`, με κενό μεταξύ των δύο τιμών κελιών. Το υπόμνημα το προβάλλει ως μία εγγραφή και για τις δύο στήλες. Η εικόνα παρακάτω δείχνει το αποτέλεσμα:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **Λήψη Αυτοματικού Χρώματος Γέμισης Σειράς**

Η μέθοδος [IChartSeries::GetAutomaticSeriesColor](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/getautomaticseriescolor/) επιστρέφει το χρώμα που υπολογίζεται από τον δείκτη της σειράς και το στυλ του διαγράμματος. Αυτό είναι το χρώμα που χρησιμοποιείται όταν η γέμιση της σειράς δεν έχει οριστεί ρητά. Η κλήση της μεθόδου διαβάζει το υπολογισμένο χρώμα· δεν ορίζει νέα γέμιση.

Το παρακάτω παράδειγμα εκτυπώνει το αυτόματο χρώμα κάθε προεπιλεγμένης σειράς:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Presentation;
using System::Console;
using System::String;

const int firstSlideIndex = 0;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
const int seriesCount = seriesCollection->get_Count();
for (int seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++)
{
    auto series = seriesCollection->idx_get(seriesIndex);
    auto automaticColor = series->GetAutomaticSeriesColor();
    auto colorName = automaticColor.get_Name();
    auto outputLine = String::Format(u"Series {0}: {1}", seriesIndex, colorName);
    Console::WriteLine(outputLine);
}

presentation->Dispose();
```

Αποτέλεσμα παραδείγματος για το προεπιλεγμένο στυλ διαγράμματος:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

Τα ακριβή χρώματα εξαρτώνται από το στυλ και το θέμα του διαγράμματος.

## **Ορισμός Αντιστροφής Χρώματος Γέμισης για Σειρά Διαγράμματος**

Για σειρές ράβδων, στηλών και φυσαλίδων, το [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) μπορεί να εμφανίζει αρνητικές τιμές με διαφορετική γέμιση. Ορίστε τη συνηθισμένη γέμιση της σειράς σε συμπαγή, ενεργοποιήστε την αντιστροφή και καθορίστε το χρώμα αρνητικής τιμής μέσω του [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/). Οι αρνητικοί αριθμοί παραμένουν αμετάβλητοι στο βιβλίο εργασίας· αλλάζει μόνο το χρώμα εμφάνισής τους.

Το παρακάτω παράδειγμα αντικαθιστά τα προεπιλεγμένα δεδομένα του διαγράμματος με μία σειρά. Η γραμμή 0 του φύλλου εργασίας περιέχει το όνομα της σειράς, η στήλη 0 τις ετικέτες κατηγοριών και η στήλη 1 τις τιμές:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::FillType;
using Aspose::Slides::Presentation;
using System::Drawing::Color;
using System::ObjectExt;
using System::String;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int headerRowIndex = 0;
const int categoryColumnIndex = 0;
const int firstSeriesColumnIndex = 1;
const int firstDataRowIndex = 1;
const int categoryCount = 3;

const String categoryNames[] = {u"Category 1", u"Category 2", u"Category 3"};
const int seriesValues[] = {-20, 50, -30};

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);
auto chartData = chart->get_ChartData();
auto workbook = chartData->get_ChartDataWorkbook();

auto seriesCollection = chartData->get_Series();
seriesCollection->Clear();
chartData->get_Categories()->Clear();

auto seriesName = ObjectExt::Box<String>(u"Series 1");
auto seriesNameCell = workbook->GetCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, seriesName);
auto chartType = chart->get_Type();
auto series = seriesCollection->Add(seriesNameCell, chartType);

for (int categoryIndex = 0; categoryIndex < categoryCount; categoryIndex++)
{
    const int dataRowIndex = firstDataRowIndex + categoryIndex;
    auto categoryName = categoryNames[categoryIndex];
    const int seriesValue = seriesValues[categoryIndex];

    auto boxedCategoryName = ObjectExt::Box<String>(categoryName);
    auto categoryCell = workbook->GetCell(worksheetIndex, dataRowIndex, categoryColumnIndex, boxedCategoryName);
    chartData->get_Categories()->Add(categoryCell);

    auto boxedSeriesValue = ObjectExt::Box<int>(seriesValue);
    auto valueCell = workbook->GetCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, boxedSeriesValue);
    series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
}

auto automaticSeriesColor = series->GetAutomaticSeriesColor();
auto invertedSeriesColor = Color::get_Red();
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(automaticSeriesColor);
series->set_InvertIfNegative(true);
series->get_InvertedSolidFillColor()->set_Color(invertedSeriesColor);

presentation->Save(u"inverted_solid_fill_color.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![The inverted solid fill color](inverted_solid_fill_color.png)

Μπορείτε να ενεργοποιήσετε την αντιστροφή για ένα σημείο μέσω του [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/). Στο παρακάτω παράδειγμα η αντιστροφή είναι απενεργοποιημένη για τη σειρά και ενεργοποιημένη μόνο για το επιλεγμένο σημείο. Το σημείο έχει επίσης ανατεθεί αρνητική τιμή ώστε το εφέ να είναι ορατό:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::FillType;
using Aspose::Slides::Presentation;
using System::Drawing::Color;
using System::ObjectExt;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 2;
const int negativeValue = -30;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
auto automaticSeriesColor = series->GetAutomaticSeriesColor();
auto invertedSeriesColor = Color::get_Red();
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(automaticSeriesColor);
series->get_InvertedSolidFillColor()->set_Color(invertedSeriesColor);
series->set_InvertIfNegative(false);

auto dataPoint = series->get_DataPoint(targetDataPointIndex);
auto boxedNegativeValue = ObjectExt::Box<int>(negativeValue);
dataPoint->get_YValue()->get_AsCell()->set_Value(boxedNegativeValue);
dataPoint->set_InvertIfNegative(true);

presentation->Save(u"data_point_invert_color_if_negative.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Καθαρισμός Συγκεκριμένης Τιμής Σημείου Δεδομένων**

Για να αφήσετε ένα σημείο κενό χωρίς να αφαιρέσετε τα άλλα σημεία, ορίστε το αντίστοιχο κελί του βιβλίου εργασίας σε `nullptr`. Για διάγραμμα στήλης, η σχεδιασμένη τιμή είναι διαθέσιμη μέσω του [IChartDataPoint::get_YValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_yvalue/). Το σημείο παραμένει στη ίδια θέση κατηγορίας, αλλά το διάγραμμα το αντιμετωπίζει ως κενή τιμή σύμφωνα με τις ρυθμίσεις κενών τιμών του διαγράμματος.

Το παρακάτω παράδειγμα αφαιρεί μόνο το δεύτερο σημείο της πρώτης σειράς:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 1;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
auto dataPoint = series->get_DataPoint(targetDataPointIndex);
dataPoint->get_YValue()->get_AsCell()->set_Value(nullptr);

presentation->Save(u"clear_data_point_value.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Τα διαγράμματα scatter χρησιμοποιούν ξεχωριστά κελιά X και Y, ενώ τα διαγράμματα φυσαλίδων χρησιμοποιούν επίσης κελί μεγέθους. Καθαρίστε μόνο το κελί που αντιπροσωπεύει την τιμή που θέλετε να αφαιρέσετε. Μη καλείτε το [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) όταν θέλετε να διατηρήσετε τα άλλα σημεία, καθώς αυτή η μέθοδος αφαιρεί όλα τα σημεία από τη συλλογή.

## **Έλεγχος Εμφάνισης Κενών Κυψέλων**

Τα κρυφά κελιά που περιέχουν τιμές αποτελούν ξεχωριστή περίπτωση από τα κενά κελιά. Για να συμπεριλάβετε ή να εξαιρέσετε δεδομένα από κρυφές γραμμές και στήλες φύλλου εργασίας, δείτε το [Include Data from Hidden Rows and Columns](/slides/el/cpp/chart-workbook/#include-data-from-hidden-rows-and-columns).

Ένα κενό κελί βιβλίου εργασίας αντιπροσωπεύει ελλιπή δεδομένα· ένα κελί που περιέχει `0` αντιπροσωπεύει γνωστή αριθμητική τιμή. Καλέστε το [IChartDataCell::set_Value](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/set_value/) με `nullptr` για να κάνετε ένα κελί κενό. Ο αριθμητικός μηδενικός παραμένει μηδέν ανεξάρτητα από τη ρύθμιση κενής κυψέλης.

Χρησιμοποιήστε το [IChart::set_DisplayBlanksAs](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_displayblanksas/) για επιλογή του τρόπου με τον οποίο το διάγραμμα εμφανίζει κενές κυψέλες. Η ρύθμιση αυτή εφαρμόζεται σε ολόκληρο το διάγραμμα. Αλλάζει τον τρόπο που τα κενά σχεδιάζονται, χωρίς να γεμίζει το κενό κελί του βιβλίου εργασίας με μηδέν ή με παρεμβαλλόμενη τιμή.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί ένα διάγραμμα γραμμής με μία σειρά, καθαρίζει την τιμή για την Ημέρα 3 και αποθηκεύει το ίδιο διάγραμμα με κάθε τρόπο. Δεν απαιτείται αρχείο εισόδου. Το [IChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/) χρησιμοποιεί το φύλλο 0, στήλη 0 για ετικέτες κατηγοριών και στήλη 1 για τιμές· η γραμμή 0 περιέχει το όνομα της σειράς. Τα τελικά δεδομένα είναι `10, 20, empty, 30, 40`.

```cpp
#include <array>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/DisplayBlanksAsType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using System::ObjectExt;
using System::String;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::LineWithMarkers, 40.0f, 40.0f, 640.0f, 400.0f);
auto chartData = chart->get_ChartData();
auto workbook = chartData->get_ChartDataWorkbook();

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();

auto seriesName = ObjectExt::Box<String>(u"Measurements");
auto seriesNameCell = workbook->GetCell(0, 0, 1, seriesName);
auto series = chartData->get_Series()->Add(seriesNameCell, chart->get_Type());
auto values = std::array<int, 5>{10, 20, 25, 30, 40};

for (auto i = 0; i < values.size(); i++)
{
    auto categoryName = String::Format(u"Day {0}", i + 1);
    auto boxedCategoryName = ObjectExt::Box<String>(categoryName);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, boxedCategoryName);
    chartData->get_Categories()->Add(categoryCell);
    auto boxedValue = ObjectExt::Box<int>(values[i]);
    auto valueCell = workbook->GetCell(0, i + 1, 1, boxedValue);
    series->get_DataPoints()->AddDataPointForLineSeries(valueCell);
}

// Leave Day 3 genuinely empty, while retaining its category and data point.
workbook->GetCell(0, 3, 1)->set_Value(nullptr);

auto modes = std::array<DisplayBlanksAsType, 3>{DisplayBlanksAsType::Gap, DisplayBlanksAsType::Zero, DisplayBlanksAsType::Span};
for (auto mode : modes)
{
    chart->set_DisplayBlanksAs(mode);
    auto outputPath = String::Format(u"empty_cells_{0}.pptx", mode);
    presentation->Save(outputPath, SaveFormat::Pptx);
}

presentation->Dispose();
```

Κάθε αρχείο εξόδου αποθηκεύει τον τρόπο που είχε οριστεί πριν από την αποθήκευση: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` και `empty_cells_Span.pptx`. Για να αποθηκεύσετε μόνο μία έκδοση, ορίστε τον επιθυμητό τρόπο και αποθηκεύστε την παρουσίαση μία φορά αντί για επαναλήψεις.

Η σύγκριση παρακάτω δείχνει τα ίδια δεδομένα και στα τρία αρχεία. Η Ημέρα 3 είναι κενή στο βιβλίο εργασίας σε κάθε περίπτωση:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Η ορατή επίδραση εξαρτάται από τον τύπο του διαγράμματος. Ένα διάγραμμα γραμμής κάνει εύκολη τη σύγκριση τριών τρόπων. Τα διαγράμματα ράβδων και στηλών δεν έχουν γραμμή για σύνδεση μέσω μιας ελλιπής κατηγορίας, επομένως το `Span` δεν μπορεί να δημιουργήσει το τμήμα σύνδεσης που φαίνεται παραπάνω· μια ελλιπής στήλη και μια στήλη μηδενικού ύψους μπορεί επίσης να μοιάζουν. Όπως και στα διαγράμματα scatter με μόνο σημεία, δεν υπάρχει γραμμή σύνδεσης. Μην περιμένετε τρία διακριτά αποτελέσματα για κάθε τύπο διαγράμματος· ελέγξτε την έξοδο για τον τύπο που χρησιμοποιείτε.

## **Ορισμός Πλάτους Κενών Μεταξύ Σειρών**

Το πλάτος κενών (gap width) είναι το διάστημα μεταξύ παρακείμενων ομάδων ράβδων ή στηλών, εκφρασμένο ως ποσοστό του πλάτους της ράβδου ή στήλης. Όπως και η επικάλυψη, ανήκει στην ομάδα γονέα της σειράς παρά σε μια συγκεκριμένη σειρά. Καλέστε το [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) μία φορά για την ομάδα. Μια μεγαλύτερη τιμή δημιουργεί περισσότερο χώρο μεταξύ των ομάδων· μια μικρότερη τιμή τις καταστηλώνει πιο πυκνά.

Το παρακάτω παράδειγμα αλλάζει το πλάτος κενών και αποθηκεύει μόνο την τελική παρουσίαση:

```cpp
#include <cstdint>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const uint16_t gapWidthPercent = 30;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
series->get_ParentSeriesGroup()->set_GapWidth(gapWidthPercent);

presentation->Save(u"gap_width_30.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![The gap width](gap_width.png)

## **Συχνές Ερωτήσεις**

**Ποιες τύποι διαγραμμάτων υποστηρίζουν σειρές δεδομένων;**

Όλοι οι τύποι διαγραμμάτων που αντιπροσωπεύονται από την απαρίθμηση [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) χρησιμοποιούν δεδομένα διαγράμματος, αλλά οι σειρές τους δεν έχουν όλοι την ίδια δομή τιμών ή ρυθμίσεις. Για παράδειγμα, τα διαγράμματα κατηγορίας χρησιμοποιούν κατηγορίες και τιμές, τα scatter διαγράμματα χρησιμοποιούν τιμές X και Y, και τα διαγράμματα φυσαλίδων προσθέτουν μεγέθη φυσαλίδων. Χρησιμοποιήστε τη μέθοδο δημιουργίας σημείου δεδομένων που ταιριάζει με τον τύπο σειράς. Επιλογές όπως η επικάλυψη και το πλάτος κενών εφαρμόζονται μόνο σε συμβατές ομάδες ράβδων ή στηλών.

**Τι είναι μια ομάδα σειρών διαγράμματος;**

Μία [IChartSeriesGroup](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/) περιέχει συμβατές σειρές που μοιράζονται ρυθμίσεις σχεδίασης επιπέδου ομάδας. Ένα συνδυαστικό διάγραμμα μπορεί να περιέχει περισσότερες από μία ομάδες, οπότε η αλλαγή της ομάδας που προέρχεται από μία σειρά δεν αλλάζει απαραίτητα κάθε σειρά στο διάγραμμα.

**Μήπως ένα νεοδημιουργημένο διάγραμμα περιέχει προεπιλεγμένα δεδομένα;**

Ναι. Από προεπιλογή, η μέθοδος [IShapeCollection::AddChart](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addchart/) δημιουργεί δείγμα σειρών, κατηγοριών και τιμών. Μπορείτε να επεξεργαστείτε αυτά τα κελιά ή να καθαρίσετε τόσο τις συλλογές σειρών όσο και κατηγοριών πριν προσθέσετε ένα εντελώς προσαρμοσμένο σύνολο δεδομένων. Υπάρχει υπερφόρτωση που μπορεί επίσης να δημιουργήσει διάγραμμα χωρίς προεπιλεγμένα δεδομένα.

**Πώς συνδέονται τα αντικείμενα διαγράμματος με κελιά βιβλίου εργασίας;**

Τα ονόματα σειρών, οι ετικέτες κατηγοριών και οι τιμές σημείων δεδομένων αναφέρονται σε κελιά ενός [IChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/). Η αλλαγή ενός αναφερόμενου κελιού ενημερώνει το αντίστοιχο στοιχείο του διαγράμματος. Όταν δημιουργείτε προσαρμοσμένα δεδομένα, κρατήστε τις γραμμές κατηγοριών και τις γραμμές τιμών σειρών ευθυγραμμισμένες ώστε κάθε σημείο να σχεδιάζεται κάτω από την προβλεπόμενη κατηγορία.

**Πώς μπορώ να αφαιρέσω ένα σημείο αντί όλης της σειράς;**

Ορίστε το σχετικό κελί τιμής σε `nullptr` για να διατηρήσετε τη θέση κατηγορίας του σημείου ως κενό σημείο. Καλέστε το [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) μόνο όταν σκοπεύετε να αφαιρέσετε όλα τα σημεία από εκείνη τη σειρά. Εάν αφαιρέσετε επίσης κατηγορίες, ενημερώστε κάθε σειρά ώστε οι τιμές τους να παραμείνουν ευθυγραμμισμένες με τη συλλογή κατηγοριών.

**Πώς εμφανίζονται τα κενά σημεία;**

Το αποτέλεσμα εξαρτάται από τον τύπο του διαγράμματος και το [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_displayblanksas/). Τα υποστηριζόμενα διαγράμματα μπορούν να εμφανίζουν κενά ως κενά, ως μηδενικές τιμές ή συνδέοντας τα γειτονικά σημεία. Επιλέξτε τη ρύθμιση που ταιριάζει στο νόημα των ελλιπών δεδομένων στην παρουσίασή σας. Δείτε το [Control the Display of Empty Cells](#control-the-display-of-empty-cells) για ολοκληρωμένο παράδειγμα και οπτική σύγκριση.

**Πώς μορφοποιούνται οι αρνητικές τιμές;**

Για υποστηριζόμενες σειρές ράβδων, στηλών και φυσαλίδων, καλέστε το [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) και ορίστε το χρώμα μέσω του [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/). Μπορείτε να παρακάμψετε τη συμπεριφορά για ένα επιμέρους σημείο με το [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/). Αυτές οι μέθοδοι επηρεάζουν τη μορφοποίηση, όχι τις αποθηκευμένες αριθμητικές τιμές.

**Ποια μορφοποίηση υπερισχύει όταν τόσο η σειρά όσο και το σημείο είναι μορφοποιημένα;**

Η ρητή μορφοποίηση σημείου δεδομένων υπερισχύει για εκείνο το σημείο. Τα άλλα σημεία συνεχίζουν να χρησιμοποιούν την ρητή μορφοποίηση σειράς ή, όταν η μορφοποίηση σειράς δεν έχει οριστεί, το αυτόματο στυλ και θέμα του διαγράμματος. Ρυθμίσεις ομάδας όπως η επικάλυψη και το πλάτος κενών ελέγχουν τη διάταξη και δεν είναι επιπέδου σημείου.

**Υπάρχει όριο στον αριθμό σειρών που μπορεί να περιέχει ένα διάγραμμα;**

Το Aspose.Slides δεν θέτει ξεχωριστό σταθερό όριο αριθμού σειρών. Στην πράξη, περιορισμοί του αρχείου παρουσίασης, διαθέσιμη μνήμη, χρόνος απόδοσης και η αναγνωσιμότητα του διαγράμματος καθορίζουν ένα πρακτικό όριο.

**Τι πρέπει να αλλάξω όταν οι στήλες είναι πολύ κοντά ή πολύ μακριά μεταξύ τους;**

Καλέστε το [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) στην κατάλληλη ομάδα γονέα της σειράς. Αυξήστε την τιμή για να διευρύνετε το κενό μεταξύ των ομάδων ή μειώστε την για να φέρετε τις ομάδες πιο κοντά.