---
title: Διαχείριση βιβλιοθηκών γραφημάτων σε παρουσιάσεις με C++
linktitle: Βιβλιοθήκη Γραφήματος
type: docs
weight: 70
url: /el/cpp/chart-workbook/
keywords:
- βιβλιοθήκη γραφήματος
- δεδομένα γραφήματος
- κελί βιβλιοθήκης
- ετικέτα δεδομένων
- φύλλο εργασίας
- πηγή δεδομένων
- εξωτερική βιβλιοθήκη
- εξωτερικά δεδομένα
- cache γραφήματος
- ανάκτηση βιβλιοθήκης
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Ανακαλύψτε το Aspose.Slides για C++: διαχειριστείτε εύκολα βιβλιοθήκες γραφημάτων σε μορφές PowerPoint και OpenDocument για να βελτιστοποιήσετε τα δεδομένα της παρουσίασής σας."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργάζεστε με βιβλιοθήκες γραφημάτων στο Aspose.Slides. Δείχνει πώς να διαβάζετε και να γράφετε δεδομένα γραφημάτων μέσω ροών βιβλιοθηκών, να χρησιμοποιείτε κελιά βιβλιοθήκης ως ετικέτες δεδομένων γραφήματος, να έχετε πρόσβαση σε συλλογές φύλλων εργασίας και να καθορίζετε τον τύπο πηγής δεδομένων για τις τιμές του γραφήματος.

Επίσης καλύπτει τη χρήση εξωτερικών βιβλιοθηκών ως πηγών δεδομένων γραφήματος. Τα παραδείγματα δείχνουν πώς να δημιουργήσετε και να αντιστοιχίσετε μια εξωτερική βιβλιοθήκη, να ανακτήσετε τη διαδρομή μιας εξωτερικής βιβλιοθήκης που είναι συνδεδεμένη με ένα γράφημα και να επεξεργαστείτε τα δεδομένα του γραφήματος όταν η βιβλιοθήκη είναι διαθέσιμη.

Για κελιά βιβλιοθήκης που αντιπροσωπεύουν ελλιπή δεδομένα, ανατρέξτε στην [Control the Display of Empty Cells](/slides/el/cpp/chart-series/) για τη διαφορά μεταξύ κενού κελιού και μηδενός, καθώς και για σύγκριση γραμμικού διαγράμματος των διαθέσιμων τρόπων εμφάνισης.

## **Ανάγνωση και Εγγραφή Δεδομένων Γραφήματος από Βιβλιοθήκη**

Το Aspose.Slides παρέχει τις μεθόδους [ReadWorkbookStream](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) και [WriteWorkbookStream](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) που επιτρέπουν την ανάγνωση και εγγραφή βιβλιοθηκών δεδομένων γραφήματος (που περιέχουν δεδομένα γραφήματος επεξεργασμένα με το Aspose.Cells). **Σημείωση** ότι τα δεδομένα του γραφήματος πρέπει να είναι οργανωμένα με τον ίδιο τρόπο ή να έχουν δομή παρόμοια με την πηγή.

``` cpp
#include <DOM/Chart/Chart.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/io/memory_stream.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>(u"chart.pptx");

auto chart = System::ExplicitCast<Chart>(pres->get_Slide(0)->get_Shape(0));
auto data = chart->get_ChartData();

auto = data->ReadWorkbookStream();
data->get_Series()->Clear();
data->get_Categories()->Clear();

stream->set_Position(0);
data->WriteWorkbookStream(stream);
```

### **Επικύρωση Διάταξης Γραφήματος μετά την Τροποποίηση της Βιβλιοθήκης**

Όταν αντικαταστήσετε μια ενσωματωμένη βιβλιοθήκη με μια τροποποιημένη, το γράφημα διατηρεί τις αρχικές συλλογές σειρών και κατηγοριών. Αυτή η ασυμφωνία μπορεί να προκαλέσει αποτυχία του [IChart::ValidateChartLayout](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichart/validatechartlayout/) με σφάλμα εκτός εύρους δείκτη. Καθαρίστε τις υπάρχουσες σειρές και κατηγορίες πριν γράψετε την ενημερωμένη βιβλιοθήκη πίσω στο γράφημα.

```cpp
// Μετά την τροποποίηση της ροής βιβλιοθήκης (π.χ., χρησιμοποιώντας Aspose.Cells)
auto updatedWorkbook = chartData->ReadWorkbookStream();

// Καθαρίστε τις υπάρχουσες αναφορές δεδομένων.
chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();

updatedWorkbook->set_Position(0);
chartData->WriteWorkbookStream(updatedWorkbook);

chart->ValidateChartLayout();
```

Ο καθαρισμός των συλλογών διασφαλίζει ότι η δομή των δεδομένων του γραφήματος είναι συνεπής με τη νέα βιβλιοθήκη, επιτρέποντας στο `ValidateChartLayout` να ολοκληρωθεί χωρίς σφάλματα.

## **Ορισμός Κελιού Βιβλιοθήκης ως Ετικέτας Δεδομένων Γραφήματος**

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
1. Λάβετε αναφορά σε μια διαφάνεια μέσω του δείκτη της.
1. Προσθέστε ένα γράφημα Bubble με κάποια δεδομένα.
1. Πρόσβαση στις σειρές του γραφήματος.
1. Ορίστε το κελί της βιβλιοθήκης ως ετικέτα δεδομένων.
1. Αποθηκεύστε την παρουσίαση.

Αυτός ο κώδικας C++ δείχνει πώς να ορίσετε ένα κελί βιβλιοθήκης ως ετικέτα δεδομένων γραφήματος:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDataLabel.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

System::String lbl0 = u"Label 0 cell value";
System::String lbl1 = u"Label 1 cell value";
System::String lbl2 = u"Label 2 cell value";

// Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης 
auto pres = System::MakeObject<Presentation>(u"chart2.pptx");

auto slide = pres->get_Slides()->idx_get(0);

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Bubble, 50.0f, 50.0f, 600.0f, 400.0f, true);

auto series = chart->get_ChartData()->get_Series();

series->idx_get(0)->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLabelValueFromCell(true);

auto wb = chart->get_ChartData()->get_ChartDataWorkbook();

series->idx_get(0)->get_Labels()->idx_get(0)->set_ValueFromCell(wb->GetCell(0, u"A10", System::ObjectExt::Box<System::String>(lbl0)));
series->idx_get(0)->get_Labels()->idx_get(1)->set_ValueFromCell(wb->GetCell(0, u"A11", System::ObjectExt::Box<System::String>(lbl1)));
series->idx_get(0)->get_Labels()->idx_get(2)->set_ValueFromCell(wb->GetCell(0, u"A12", System::ObjectExt::Box<System::String>(lbl2)));

pres->Save(u"resultchart.pptx", SaveFormat::Pptx);
```

## **Διαχείριση Φύλλων Εργασίας**

Αυτός ο κώδικας C++ παρουσιάζει μια λειτουργία όπου η μέθοδος [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) χρησιμοποιείται για πρόσβαση σε συλλογή φύλλων εργασίας:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataWorksheet.h>
#include <DOM/Chart/IChartDataWorksheetCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 500.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheets = workbook->get_Worksheets();

for (auto ws : System::IterateOver(worksheets))
    System::Console::WriteLine(ws->get_Name());
```

## **Καθορισμός Τύπου Πηγής Δεδομένων**

Αυτός ο κώδικας C++ δείχνει πώς να καθορίσετε έναν τύπο για μια πηγή δεδομένων:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/DataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IStringChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto chartData = chart->get_ChartData();
auto val = chart->get_ChartData()->get_Series()->idx_get(0)->get_Name();

val->set_DataSourceType(DataSourceType::StringLiterals);
val->set_Data(System::ObjectExt::Box<System::String>(u"LiteralString"));
val = chartData->get_Series()->idx_get(1)->get_Name();
val->set_Data(chartData->get_ChartDataWorkbook()->GetCell(0, u"B1", System::ObjectExt::Box<System::String>(u"NewCell")));

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Ανίχνευση Μη Υποστηριζόμενων Ενσωματωμένων Μορφών Βιβλιοθήκης**

Το Aspose.Slides δεν υποστηρίζει τη δυαδική μορφή βιβλιοθήκης Excel (.xlsb) που μπορεί να ενσωματωθεί σε ορισμένα γραφήματα. Μπορείτε να χρησιμοποιήσετε τη μέθοδο `get_EmbeddedWorkbookType` στο [IChartData](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdata/) μαζί με την απαρίθμηση [WorkbookType](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/workbooktype/) για να ανιχνεύσετε μη υποστηριζόμενες μορφές και να παραλείψετε αυτά τα γραφήματα.

```cpp
#include <DOM/Chart/ChartDataSourceType.h>
#include <DOM/Chart/WorkbookType.h>
#include <DOM/IChart.h>
#include <DOM/ISlide.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : System::IterateOver(slide->get_Shapes()))
{
    if (!System::ObjectExt::Is<IChart>(shape))
    {
        continue;
    }

    auto chart = System::ExplicitCast<IChart>(shape);
    auto chartData = chart->get_ChartData();

    if (chartData->get_DataSourceType() == ChartDataSourceType::InternalWorkbook &&
        chartData->get_EmbeddedWorkbookType() == WorkbookType::WorkbookBinaryMacro)
    {
        // Η ενσωματωμένη βιβλιοθήκη είναι σε μορφή .xlsb, η οποία δεν υποστηρίζεται.
        continue;
    }

    // Διαβάστε ή τροποποιήστε εδώ τα δεδομένα της βιβλιοθήκης του γραφήματος.
}
```

## **Εξωτερική Βιβλιοθήκη**

Το Aspose.Slides υποστηρίζει τη χρήση εξωτερικών βιβλιοθηκών ως πηγή δεδομένων για γραφήματα.

### **Δημιουργία Εξωτερικής Βιβλιοθήκης**

Με τη χρήση των μεθόδων **`ReadWorkbookStream`** και **`SetExternalWorkbook`**, μπορείτε είτε να δημιουργήσετε μια εξωτερική βιβλιοθήκη από το μηδέν είτε να κάνετε μια εσωτερική βιβλιοθήκη εξωτερική.

Αυτός ο κώδικας C++ παρουσιάζει τη διαδικασία δημιουργίας εξωτερικής βιβλιοθήκης:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/io/memory_stream.h>
#include <system/io/path.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();

const System::String workbookPath = u"externalWorkbook1.xlsx";

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f);
auto chartData = chart->get_ChartData();

{
    System::SharedPtr<System::IO::FileStream> fileStream = System::MakeObject<System::IO::FileStream>(workbookPath, System::IO::FileMode::Create);

    System::ArrayPtr<uint8_t> workbookData = chartData->ReadWorkbookStream()->ToArray();
    fileStream->Write(workbookData, 0, workbookData->get_Length());
}

chartData->SetExternalWorkbook(System::IO::Path::GetFullPath(workbookPath));

pres->Save(u"externalWorkbook.pptx", SaveFormat::Pptx);
```

### **Ορισμός Εξωτερικής Βιβλιοθήκης**

Με τη χρήση της μεθόδου **`IChartData::SetExternalWorkbook`**, μπορείτε να αντιστοιχίσετε μια εξωτερική βιβλιοθήκη σε ένα γράφημα ως πηγή δεδομένων του. Αυτή η μέθοδος μπορεί επίσης να χρησιμοποιηθεί για ενημέρωση της διαδρομής προς την εξωτερική βιβλιοθήκη (εφόσον αυτή μετακινήθηκε).

Παρόλο που δεν μπορείτε να επεξεργαστείτε τα δεδομένα σε βιβλιοθήκες αποθηκευμένες σε απομακρυσμένες τοποθεσίες ή πόρους, μπορείτε ακόμη να τις χρησιμοποιήσετε ως εξωτερική πηγή δεδομένων. Εάν δοθεί σχετική διαδρομή για μια εξωτερική βιβλιοθήκη, αυτή μετατρέπεται αυτόματα σε πλήρη διαδρομή.

Αυτός ο κώδικας C++ δείχνει πώς να ορίσετε μια εξωτερική βιβλιοθήκη:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/path.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f, false);
auto chartData = chart->get_ChartData();

chartData->SetExternalWorkbook(System::IO::Path::GetFullPath(u"externalWorkbook.xlsx"));

chartData->get_Series()->Add(chartData->get_ChartDataWorkbook()->GetCell(0, u"B1"), ChartType::Pie);
auto dataPoints = chartData->get_Series()->idx_get(0)->get_DataPoints();
auto workbook = chartData->get_ChartDataWorkbook();
dataPoints->AddDataPointForPieSeries(workbook->GetCell(0, u"B2"));
dataPoints->AddDataPointForPieSeries(workbook->GetCell(0, u"B3"));
dataPoints->AddDataPointForPieSeries(workbook->GetCell(0, u"B4"));

auto categories = chartData->get_Categories();
categories->Add(workbook->GetCell(0, u"A2"));
categories->Add(workbook->GetCell(0, u"A3"));
categories->Add(workbook->GetCell(0, u"A4"));
pres->Save(u"Presentation_with_externalWorkbook.pptx", SaveFormat::Pptx);
```

Η παράμετρος `updateChartData` (στη μέθοδο `SetExternalWorkbook`) χρησιμοποιείται για να καθορίσει εάν μια βιβλιοθήκη Excel θα φορτωθεί ή όχι.

* Όταν η τιμή του `updateChartData` ορίζεται σε `false`, ενημερώνεται μόνο η διαδρομή της βιβλιοθήκης — τα δεδομένα του γραφήματος δεν θα φορτωθούν ή ενημερωθούν από τη βιβλιοθήκη-στόχο. Μπορείτε να χρησιμοποιήσετε αυτή τη ρύθμιση όταν η βιβλιοθήκη-στόχος δεν υπάρχει ή δεν είναι διαθέσιμη.
* Όταν η τιμή του `updateChartData` ορίζεται σε `true`, τα δεδομένα του γραφήματος ενημερώνονται από τη βιβλιοθήκη-στόχο.

```c++
#include <DOM/Chart/ChartData.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f, true);
System::SharedPtr<IChartData> chartData = chart->get_ChartData();

System::SharedPtr<ChartData> concreteChartData = System::AsCast<ChartData>(chartData);
concreteChartData->SetExternalWorkbook(u"http://path/doesnt/exists", false);

pres->Save(u"SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
```

### **Λήψη Διαδρομής Εξωτερικής Βιβλιοθήκης Πηγής Δεδομένων ενός Γραφήματος**

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
1. Λάβετε αναφορά σε μια διαφάνεια μέσω του δείκτη της.
1. Δημιουργήστε ένα αντικείμενο για το σχήμα του γραφήματος.
1. Δημιουργήστε ένα αντικείμενο για τον τύπο πηγής (`ChartDataSourceType`) που αντιπροσωπεύει την πηγή δεδομένων του γραφήματος.
1. Καθορίστε την κατάλληλη συνθήκη βάσει του ότι ο τύπος πηγής είναι ίδιος με τον τύπο εξωτερικής βιβλιοθήκης πηγής δεδομένων.

```c++
#include <DOM/Chart/ChartDataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");

auto slide = pres->get_Slides()->idx_get(1);
auto chart = System::ExplicitCast<IChart>(slide->get_Shapes()->idx_get(0));
ChartDataSourceType sourceType = chart->get_ChartData()->get_DataSourceType();
if (sourceType == ChartDataSourceType::ExternalWorkbook)
{
    System::String path = chart->get_ChartData()->get_ExternalWorkbookPath();
}

// Αποθηκεύει την παρουσίαση
pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

### **Επεξεργασία Δεδομένων Γραφήματος**

Μπορείτε να επεξεργαστείτε τα δεδομένα σε εξωτερικές βιβλιοθήκες με τον ίδιο τρόπο που κάνετε αλλαγές στο περιεχόμενο εσωτερικών βιβλιοθηκών. Όταν μια εξωτερική βιβλιοθήκη δεν μπορεί να φορτωθεί, προκαλείται εξαίρεση.

Αυτός ο κώδικας C++ είναι μια υλοποίηση της περιγραφόμενης διαδικασίας:

```c++
#include <DOM/Chart/Chart.h>
#include <DOM/Chart/ChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

const String templatePath = u"../templates/presentation.pptx";
	const String outPath = u"../out/presentation-out.pptx";
	

	System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(templatePath);
	System::SharedPtr<Aspose::Slides::Charts::IChart> chart = System::AsCast<Aspose::Slides::Charts::IChart>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
	System::SharedPtr<Aspose::Slides::Charts::ChartData> chartData = System::ExplicitCast<Aspose::Slides::Charts::ChartData>(chart->get_ChartData());
	

	chartData->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0)->get_Value()->get_AsCell()->set_Value(System::ObjectExt::Box<int32_t>(100));
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Ανάκτηση Βιβλιοθήκης από την Cache του Γραφήματος**

Εάν ένα γράφημα χρησιμοποιεί μια εξωτερική βιβλιοθήκη που λείπει ή δεν είναι διαθέσιμη, το Aspose.Slides μπορεί να ξαναδημιουργήσει τη βιβλιοθήκη του γραφήματος από τα δεδομένα που έχουν αποθηκευτεί στην cache της παρουσίασης. Δημιουργήστε [LoadOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides/loadoptions/), ρυθμίστε το με [set_SpreadsheetOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/), και καλέστε [ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/el/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/) με `true` πριν ανοίξετε την παρουσίαση.

Το παρακάτω παράδειγμα C++ ανοίγει μια παρουσίαση του οποίου το γράφημα αναφέρεται σε μια μη διαθέσιμη εξωτερική βιβλιοθήκη και προσπελαύνει τα ανακηρυθέντα δεδομένα μέσω των [IChart::get_ChartData](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichart/get_chartdata/) και [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/):

```cpp
auto spreadsheetOptions = MakeObject<SpreadsheetOptions>();
spreadsheetOptions->set_RecoverWorkbookFromChartCache(true);

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_SpreadsheetOptions(spreadsheetOptions);

auto presentation = MakeObject<Presentation>(u"presentation.pptx", loadOptions);

auto shape = presentation->get_Slide(0)->get_Shape(0);
auto chart = System::ExplicitCast<IChart>(shape);

auto recoveredWorkbook = chart->get_ChartData()->get_ChartDataWorkbook();

// Read or modify the recovered workbook data here.

presentation->Dispose();
```

Εάν η εξωτερική βιβλιοθήκη δεν είναι διαθέσιμη και η ανάκτηση είναι απενεργοποιημένη, το Aspose.Slides ρίχνει μια εξαίρεση `System::InvalidOperationException`. Ενεργοποιήστε την ανάκτηση μόνο όταν η χρήση των δεδομένων γραφήματος από την cache αποτελεί αποδεκτό εναλλακτικό σενάριο, επειδή η cache ίσως να μην περιέχει τις αλλαγές που έγιναν στην εξωτερική βιβλιοθήκη μετά την τελευταία ενημέρωση της παρουσίασης.

## **Συχνές Ερωτήσεις**

**Μπορώ να καθορίσω εάν ένα συγκεκριμένο γράφημα συνδέεται με εξωτερική ή ενσωματωμένη βιβλιοθήκη;**

Ναι. Ένα γράφημα διαθέτει έναν [data source type](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) και μια [path to an external workbook](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/); εάν η πηγή είναι εξωτερική βιβλιοθήκη, μπορείτε να διαβάσετε τη πλήρη διαδρομή για να βεβαιωθείτε ότι χρησιμοποιείται εξωτερικό αρχείο.

**Υποστηρίζονται οι σχετικές διαδρομές σε εξωτερικές βιβλιοθήκες και πώς αποθηκεύονται;**

Ναι. Εάν καθορίσετε μια σχετική διαδρομή, αυτή μετατρέπεται αυτόματα σε απόλυτη διαδρομή. Αυτό είναι βολικό για τη φορητότητα του έργου· ωστόσο, λάβετε υπόψη ότι η παρουσίαση θα αποθηκεύει την απόλυτη διαδρομή στο αρχείο PPTX.

**Μπορώ να χρησιμοποιήσω βιβλιοθήκες που βρίσκονται σε δικτυακούς πόρους/διαμοιραζόμενους φάκελους;**

Ναι, αυτές οι βιβλιοθήκες μπορούν να χρησιμοποιηθούν ως εξωτερική πηγή δεδομένων. Ωστόσο, η επεξεργασία απομακρυσμένων βιβλιοθηκών απευθείας από το Aspose.Slides δεν υποστηρίζεται — μπορούν να χρησιμοποιηθούν μόνο ως πηγή.

**Το Aspose.Slides αντικαθιστά το εξωτερικό αρχείο XLSX κατά την αποθήκευση της παρουσίασης;**

Όχι. Η παρουσίαση αποθηκεύει έναν [link to the external file](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) και τον χρησιμοποιεί για την ανάγνωση των δεδομένων. Το εξωτερικό αρχείο δεν τροποποιείται όταν η παρουσίαση αποθηκεύεται.

**Τι πρέπει να κάνω εάν το εξωτερικό αρχείο είναι προστατευμένο με κωδικό;**

Το Aspose.Slides δεν δέχεται κωδικό κατά τη σύνδεση. Μία συνήθης προσέγγιση είναι να αφαιρέσετε την προστασία προκαταβολικά ή να προετοιμάσετε ένα αποκρυπτογραφημένο αντίγραφο (π.χ., χρησιμοποιώντας [Aspose.Cells](/cells/cpp/)) και να συνδέσετε σε αυτό το αντίγραφο.

**Μπορούν πολλά γραφήματα να παραπέμπουν στην ίδια εξωτερική βιβλιοθήκη;**

Ναι. Κάθε γράφημα αποθηκεύει το δικό του σύνδεσμο. Εάν όλα δείχνουν στο ίδιο αρχείο, η ενημέρωση του αρχείου θα αντικατοπτριστεί σε κάθε γράφημα την επόμενη φορά που θα φορτωθούν τα δεδομένα.