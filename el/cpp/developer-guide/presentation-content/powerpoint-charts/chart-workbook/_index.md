---
title: Διαχείριση βιβλίων εργασίας διαγραμμάτων σε παρουσιάσεις με χρήση C++
linktitle: Βιβλίο Εργασίας Διαγράμματος
type: docs
weight: 70
url: /el/cpp/chart-workbook/
keywords:
- βιβλίο εργασίας διαγράμματος
- δεδομένα διαγράμματος
- κελί βιβλίου εργασίας
- ετικέτα δεδομένων
- φύλλο εργασίας
- πηγή δεδομένων
- εξωτερικό βιβλίο εργασίας
- εξωτερικά δεδομένα
- προσωρινή μνήμη διαγράμματος
- ανάκτηση βιβλίου εργασίας
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Ανακαλύψτε το Aspose.Slides για C++: διαχειριστείτε εύκολα τα βιβλία εργασίας διαγραμμάτων σε μορφές PowerPoint και OpenDocument για να βελτιώσετε τα δεδομένα της παρουσίασής σας."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργάζεστε με βιβλία εργασίας διαγραμμάτων στο Aspose.Slides. Δείχνει πώς να διαβάζετε και να γράφετε δεδομένα διαγράμματος μέσω ροών βιβλίου εργασίας, να χρησιμοποιείτε κελιά βιβλίου εργασίας ως ετικέτες δεδομένων διαγράμματος, να έχετε πρόσβαση σε συλλογές φύλλων εργασίας και να καθορίζετε τον τύπο πηγής δεδομένων για τις τιμές του διαγράμματος.

Καλύπτει επίσης τη χρήση εξωτερικών βιβλίων εργασίας ως πηγών δεδομένων διαγράμματος. Τα παραδείγματα δείχνουν πώς να δημιουργήσετε και να εκχωρήσετε ένα εξωτερικό βιβλίο εργασίας, να ανακτήσετε τη διαδρομή ενός εξωτερικού βιβλίου εργασίας που συνδέεται με ένα διάγραμμα και να επεξεργαστείτε τα δεδομένα του διαγράμματος όταν το βιβλίο εργασίας είναι διαθέσιμο.

Για κελιά βιβλίου εργασίας που αντιπροσωπεύουν ελλιπή δεδομένα, δείτε [Έλεγχος της Εμφάνισης Κενών Κελιών](/slides/el/cpp/chart-series/) για τη διαφορά μεταξύ κενού κελιού και μηδενός, και μια σύγκριση σε διαγράμματα γραμμής των διαθέσιμων τρόπων εμφάνισης.

## **Συμπερίληψη δεδομένων από κρυμμένες γραμμές και στήλες**

Χρησιμοποιήστε [IChart::set_PlotVisibleCellsOnly](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_plotvisiblecellsonly/) για να ελέγξετε εάν ένα διάγραμμα σχεδιάζει δεδομένα από κρυμμένες γραμμές και στήλες φύλλου εργασίας. Ορίστε το σε `true` για να σχεδιάζονται μόνο τα ορατά κελιά ή σε `false` για να συμπεριληφθούν και τα ορατά και τα κρυμμένα κελιά. Αυτή η ρύθμιση ελέγχει τη δημιουργία διαγράμματος· δεν κρύβει ή εμφανίζει ξανά γραμμές ή στήλες φύλλου εργασίας.

Η [sample presentation](hidden-source-data.pptx) περιέχει ένα γράφημα στήλης ως το πρώτο σχήμα στην πρώτη διαφάνειά της. Το ενσωματωμένο φύλλο εργασίας, `Sheet1`, περιέχει την ακόλουθη περιοχή προέλευσης, `A1:C4`. Η γραμμή 3 και η στήλη C είναι κρυμμένες, αλλά τα κελιά τους εξακολουθούν να περιέχουν τιμές.

| Γραμμή φύλλου | A: Μήνας | B: Λιανικό | C: Χονδρική (κρυφή στήλη) |
| --- | --- | --- | --- |
| 2 | Ιανουάριος | 10 | 30 |
| 3 (κρυφή γραμμή) | Φεβρουάριος | 40 | 60 |
| 4 | Μάρτιος | 20 | 50 |

Πρόσβαση στα κελιά προέλευσης μέσω [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) και ανάγνωση του [IChartDataCell::get_IsHidden](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/get_ishidden/) για να ελέγξετε την κρυφή τους κατάσταση. Αυτή η ιδιότητα είναι μόνο για ανάγνωση. Σε αυτό το αρχείο, το B2 είναι ορατό, το B3 ανήκει στη κρυφή γραμμή και το C2 ανήκει στη κρυφή στήλη· το παράδειγμα εκτυπώνει `False`, `True` και `True`, αντίστοιχα.

Για αυτό το παράδειγμα, ανανεώστε τα δεδομένα του διαγράμματος μετά την αλλαγή της ρύθμισης σχεδίασης: διατηρήστε το ενσωματωμένο βιβλίο εργασίας με [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) και φορτώστε το ξανά με [WriteWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/). Όταν συμπεριλαμβάνονται όλα τα κελιά, χρησιμοποιήστε επίσης το [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setrange/) για να επαναφέρετε την πλήρη περιοχή, συμπεριλαμβανομένης της κρυφής κατηγορίας Φεβρουάριου. Η απλή αλλαγή της σημαίας δεν αρκεί για την ανανέωση των προσωρινών δεδομένων διαγράμματος και ετικετών κατηγορίας σε αυτό το δείγμα.

```cpp
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <initializer_list>
#include <system/console.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"hidden-source-data.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
    Console::WriteLine(u"B2 hidden: {0}", workbook->GetCell(0, u"B2")->get_IsHidden());
    Console::WriteLine(u"B3 hidden: {0}", workbook->GetCell(0, u"B3")->get_IsHidden());
    Console::WriteLine(u"C2 hidden: {0}", workbook->GetCell(0, u"C2")->get_IsHidden());

    auto workbookStream = chart->get_ChartData()->ReadWorkbookStream();
    for (auto visibleOnly : {true, false})
    {
        chart->set_PlotVisibleCellsOnly(visibleOnly);

        // Ανανέωση των δεδομένων του διαγράμματος από το ενσωματωμένο βιβλίο εργασίας.
        workbookStream->set_Position(0);
        chart->get_ChartData()->WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // Επαναφορά της πλήρους περιοχής προέλευσης, συμπεριλαμβανομένων των κρυφών κατηγοριών.
            chart->get_ChartData()->SetRange(u"Sheet1!$A$1:$C$4");
        }

        auto outputPath = visibleOnly ? u"hidden_cells_True.pptx" : u"hidden_cells_False.pptx";
        presentation->Save(outputPath, Export::SaveFormat::Pptx);
    }
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

Το παράδειγμα αποθηκεύει δύο εκδόσεις της παρουσίασης: μία μόνο με τις ορατές τιμές Λιανικού (10 και 20) και μια άλλη με όλες τις έξι τιμές. Οι εικόνες παρακάτω απεικονίζουν τις δύο λειτουργίες σχεδίασης. Η γραμμή 3 και η στήλη C παραμένουν κρυμμένες και στα δύο ενσωματωμένα βιβλία εργασίας.

| Μόνο ορατά κελιά (`true`) | Όλα τα κελιά (`false`) |
| --- | --- |
| ![Μόνο ορατά κελιά: Τιμές λιανικού 10 και 20 για Ιανουάριο και Μάρτιο.](hidden_cells_True.png) | ![Όλα τα κελιά: Τιμές λιανικού και χονδρικού για Ιανουάριο, Φεβρουάριο και Μάρτιο.](hidden_cells_False.png) |

Ένα κρυφό κελί που περιέχει τιμή διαφέρει από ένα κενό κελί. Το [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_displayblanksas/) ελέγχει πώς εμφανίζονται οι ελλιπείς τιμές· δεν περιλαμβάνει ή εξαιρεί κρυφά δεδομένα προέλευσης. Δείτε [Έλεγχος της Εμφάνισης Κενών Κελιών](/slides/el/cpp/chart-series/#control-the-display-of-empty-cells) για παράδειγμα.

## **Ανάκτηση της περιοχής δεδομένων ενός διαγράμματος**

Πριν ενημερώσετε τα δεδομένα του βιβλίου εργασίας σε μια υπάρχουσα παρουσίαση, εξετάστε τις περιοχές προέλευσης για να εντοπίσετε ποια κελιά φύλλου εργασίας χρησιμοποιεί κάθε διάγραμμα. Η μέθοδος [IChartData::GetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/getrange/) επιστρέφει την τρέχουσα περιοχή δεδομένων ως τύπο σαρωμένου φύλλου εργασίας, π.χ. `Sheet1!$A$1:$D$5`. Εδώ, το `Sheet1` είναι το όνομα του φύλλου, το `!` το διαχωρίζει από την περιοχή κελιών, και το `$A$1:$D$5` προσδιορίζει τα κελιά A1 έως D5, συμπεριλαμβανομένων. Τα σύμβολα δολαρίου υποδεικνύουν απόλυτες αναφορές γραμμής και στήλης.

Η μέθοδος διαβάζει την τρέχουσα περιοχή χωρίς να αλλάξει το διάγραμμα ή το βιβλίο εργασίας του. Εάν το διάγραμμα δεν χρησιμοποιεί βιβλίο εργασίας ως πηγή δεδομένων, ρίχνει [System::InvalidOperationException](https://reference.aspose.com/slides/cpp/system/details_invalidoperationexception/). Για περισσότερες πληροφορίες, δείτε το [ChartData API Reference](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/).

Αυτό το παράδειγμα ανοίγει μια παρουσίαση και ελέγχει τα σχήματα απευθείας σε κάθε διαφάνεια για διαγράμματα. Εκτυπώνει το όνομα κάθε διαγράμματος και την περιοχή προέλευσης. Εάν ένα διάγραμμα δεν χρησιμοποιεί βιβλίο εργασίας, εκτυπώνει μήνυμα και συνεχίζει στο επόμενο διάγραμμα.

```cpp
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

for (auto slide : IterateOver(presentation->get_Slides()))
{
    for (auto shape : IterateOver(slide->get_Shapes()))
    {
        auto chart = AsCast<IChart>(shape);
        if (chart != nullptr)
        {
            try
            {
                auto range = chart->get_ChartData()->GetRange();
                Console::WriteLine(u"{0}: {1}", chart->get_Name(), range);
            }
            catch (const InvalidOperationException&)
            {
                Console::WriteLine(u"{0}: The chart does not use a workbook as its data source.", chart->get_Name());
            }
        }
    }
}
```

## **Ανάγνωση και Εγγραφή Δεδομένων Διαγράμματος από Βιβλίο Εργασίας**

Το Aspose.Slides for C++ παρέχει τις μεθόδους [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) και [WriteWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) που επιτρέπουν την ανάγνωση και εγγραφή βιβλίων εργασίας δεδομένων διαγράμματος (που περιέχουν δεδομένα διαγράμματος επεξεργασμένα με Aspose.Cells). **Note** ότι τα δεδομένα διαγράμματος πρέπει να οργανωθούν με τον ίδιο τρόπο ή να έχουν παρόμοια δομή με την πηγή.

Αυτό το παράδειγμα χρησιμοποιεί μια παρουσίαση με ένα διάγραμμα ως το πρώτο σχήμα στην πρώτη διαφάνειά της. Διαβάζει το ενσωματωμένο βιβλίο εργασίας σε μια ροή, διαγράφει τις υπάρχουσες σειρές και κατηγορίες, και γράφει πάλι το ίδιο βιβλίο εργασίας. Οι αλλαγές παραμένουν στη μνήμη· το παράδειγμα δεν αποθηκεύει την παρουσίαση.

```cpp
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"chart.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto chartData = chart->get_ChartData();
    auto workbookStream = chartData->ReadWorkbookStream();

    chartData->get_Series()->Clear();
    chartData->get_Categories()->Clear();

    workbookStream->set_Position(0);
    chartData->WriteWorkbookStream(workbookStream);
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

### **Επικύρωση Διάταξης Διαγράμματος μετά την Τροποποίηση του Βιβλίου Εργασίας**

Όταν αντικαθιστάτε ένα ενσωματωμένο βιβλίο εργασίας με ένα τροποποιημένο, το διάγραμμα διατηρεί τις αρχικές σειρές και συλλογές κατηγοριών. Αυτή η ασυμφωνία μπορεί να κάνει την [IChart::ValidateChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/validatechartlayout/) να αποτύχει με σφάλμα εκτός εύρους. Διαγράψτε τις υπάρχουσες σειρές και κατηγορίες πριν γράψετε το ενημερωμένο βιβλίο εργασίας πίσω στο διάγραμμα. Το παράδειγμα αυτό χρησιμοποιεί ένα διάγραμμα που είναι το πρώτο σχήμα στην πρώτη διαφάνεια. Το σχόλιο δείχνει πού θα γινόταν η επεξεργασία του βιβλίου εργασίας· το εκτελέσιμο παράδειγμα γράφει το αρχικό βιβλίο εργασίας πίσω και επικυρώνει τη διάταξη στη μνήμη.

```cpp
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"chart.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto chartData = chart->get_ChartData();
    auto workbookStream = chartData->ReadWorkbookStream();

    // Τροποποιήστε τη ροή του βιβλίου εργασίας εδώ, για παράδειγμα, χρησιμοποιώντας το Aspose.Cells.

    chartData->get_Series()->Clear();
    chartData->get_Categories()->Clear();

    workbookStream->set_Position(0);
    chartData->WriteWorkbookStream(workbookStream);
    chart->ValidateChartLayout();
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

Η διαγραφή των συλλογών αφαιρεί παλαιές αναφορές δεδομένων πριν το βιβλίο εργασίας γραφτεί ξανά. Αναδημιουργήστε τυχόν απαιτούμενες αντιστοιχίες σειρών και κατηγοριών για το ενημερωμένο βιβλίο εργασίας πριν χρησιμοποιήσετε το διάγραμμα.

## **Ορισμός Κελιού Βιβλίου Εργασίας ως Ετικέτας Δεδομένων Διαγράμματος**

Μπορείτε να χρησιμοποιήσετε κείμενο από κελιά βιβλίου εργασίας ως ετικέτες δεδομένων διαγράμματος.

Αυτό το παράδειγμα προσθέτει ένα γράφημα φυσαλίδων με προεπιλεγμένα δεδομένα στην πρώτη διαφάνεια μιας υπάρχουσας παρουσίασης. Χρησιμοποιεί τα κελιά A10:A12 στο φύλλο 0 για τις πρώτες τρεις ετικέτες της πρώτης σειράς, ενεργοποιεί τις ετικέτες από κελιά και αποθηκεύει την ενημερωμένη παρουσίαση.

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
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"chart2.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Bubble, 50, 50, 600, 400, true);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLabelValueFromCell(true);
auto firstLabelCell = workbook->GetCell(0, u"A10", ObjectExt::Box<String>(u"Label 0 cell value"));
auto secondLabelCell = workbook->GetCell(0, u"A11", ObjectExt::Box<String>(u"Label 1 cell value"));
auto thirdLabelCell = workbook->GetCell(0, u"A12", ObjectExt::Box<String>(u"Label 2 cell value"));
series->get_Labels()->idx_get(0)->set_ValueFromCell(firstLabelCell);
series->get_Labels()->idx_get(1)->set_ValueFromCell(secondLabelCell);
series->get_Labels()->idx_get(2)->set_ValueFromCell(thirdLabelCell);

presentation->Save(u"resultchart.pptx", Export::SaveFormat::Pptx);
```

## **Διαχείριση Φύλλων Εργασίας**

Η μέθοδος [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) παρέχει πρόσβαση στα φύλλα εργασίας ενός βιβλίου εργασίας διαγράμματος. Αυτό το παράδειγμα δημιουργεί ένα γράφημα πίτας με προεπιλεγμένα δεδομένα και εκτυπώνει κάθε όνομα φύλλου στην κονσόλα.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataWorksheet.h>
#include <DOM/Chart/IChartDataWorksheetCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 500);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

for (auto i = 0; i < workbook->get_Worksheets()->get_Count(); i++)
{
    Console::WriteLine(workbook->get_Worksheets()->idx_get(i)->get_Name());
}
```

## **Καθορισμός του Τύπου Πηγής Δεδομένων**

Αυτό το παράδειγμα δημιουργεί ένα 3Δ γράφημα στήλης με προεπιλεγμένα δεδομένα και ορίζει δύο ονόματα σειρών χρησιμοποιώντας διαφορετικές πηγές δεδομένων. Το πρώτο όνομα χρησιμοποιεί έναν κυριολεκτικό συμβολοσειρά· το δεύτερο χρησιμοποιεί το κελί C1 στο φύλλο 0. Η απαρίθμηση [DataSourceType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/datasourcetype/) επιλέγει την πηγή για κάθε όνομα. Το παράδειγμα αποθηκεύει την παρουσίαση με τα ενημερωμένα ονόματα σειρών.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/DataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IStringChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 50, 50, 600, 400, true);
auto literalName = chart->get_ChartData()->get_Series()->idx_get(0)->get_Name();

literalName->set_DataSourceType(DataSourceType::StringLiterals);
literalName->set_Data(ObjectExt::Box<String>(u"LiteralString"));

auto cellName = chart->get_ChartData()->get_Series()->idx_get(1)->get_Name();
auto nameCell = chart->get_ChartData()->get_ChartDataWorkbook()->GetCell(0, u"C1", ObjectExt::Box<String>(u"NewCell"));
cellName->set_DataSourceType(DataSourceType::Worksheet);
cellName->set_Data(nameCell);

presentation->Save(u"pres.pptx", Export::SaveFormat::Pptx);
```

## **Ανίχνευση Μη Υποστηριζόμενων Ενσωματωμένων Μορφών Βιβλίου Εργασίας**

Το Aspose.Slides δεν υποστηρίζει τη δυαδική μορφή βιβλίου εργασίας Excel (.xlsb) που μπορεί να ενσωματωθεί σε ορισμένα διαγράμματα. Μπορείτε να χρησιμοποιήσετε τη μέθοδο [get_EmbeddedWorkbookType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_embeddedworkbooktype/) στο [IChartData](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/) μαζί με την απαρίθμηση [WorkbookType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/workbooktype/) για να εντοπίσετε μη υποστηριζόμενες μορφές και να παραλείψετε αυτά τα διαγράμματα. Το παράδειγμα ελέγχει τα σχήματα στην πρώτη διαφάνεια μιας υπάρχουσας παρουσίασης, παραλείπει τα μη-διάγραμμα σχήματα και εκτυπώνει ένα διαγνωστικό μήνυμα για κάθε διάγραμμα με ενσωματωμένο βιβλίο εργασίας .xlsb.

```cpp
#include <DOM/Chart/ChartDataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/WorkbookType.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto shape : IterateOver(slide->get_Shapes()))
{
    auto chart = AsCast<IChart>(shape);
    if (chart == nullptr)
    {
        continue;
    }

    auto chartData = chart->get_ChartData();
    auto isInternalWorkbook = chartData->get_DataSourceType() == ChartDataSourceType::InternalWorkbook;
    auto isBinaryMacro = chartData->get_EmbeddedWorkbookType() == WorkbookType::WorkbookBinaryMacro;

    if (isInternalWorkbook && isBinaryMacro)
    {
        Console::WriteLine(u"Skipping a chart with an unsupported .xlsb workbook.");
        continue;
    }

    // Διαβάστε ή τροποποιήστε τα υποστηριζόμενα δεδομένα βιβλίου εργασίας διαγράμματος εδώ.
}
```

## **Εξωτερικό Βιβλίο Εργασίας**

Το Aspose.Slides υποστηρίζει τη χρήση εξωτερικών βιβλίων εργασίας ως πηγή δεδομένων για διαγράμματα.

### **Δημιουργία Εξωτερικού Βιβλίου Εργασίας**

Χρησιμοποιήστε το [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) και το [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) για να εξάγετε ένα ενσωματωμένο βιβλίο εργασίας διαγράμματος σε αρχείο και να συνδέσετε το διάγραμμα με αυτό το εξωτερικό βιβλίο εργασίας.

Αυτό το παράδειγμα δημιουργεί ένα γράφημα πίτας με προεπιλεγμένα δεδομένα και εξάγει το βιβλίο εργασίας του. Κλείνει τη ροή εξόδου πριν εκχωρήσει το εξωτερικό βιβλίο εργασίας ως πηγή δεδομένων διαγράμματος, στη συνέχεια αποθηκεύει την συνδεδεμένη παρουσίαση.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <system/io/memory_stream.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 600);
auto workbookPath = IO::Path::GetFullPath(u"externalWorkbook1.xlsx");
auto workbookStream = chart->get_ChartData()->ReadWorkbookStream();
auto fileStream = IO::File::Create(workbookPath);
workbookStream->CopyTo(fileStream);
fileStream->Close();

chart->get_ChartData()->SetExternalWorkbook(workbookPath);

presentation->Save(u"externalWorkbook.pptx", Export::SaveFormat::Pptx);
```

### **Ορισμός Εξωτερικού Βιβλίου Εργασίας**

Με τη μέθοδο [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) μπορείτε να εκχωρήσετε ένα εξωτερικό βιβλίο εργασίας σε ένα διάγραμμα ως πηγή δεδομένων. Η μέθοδος μπορεί επίσης να χρησιμοποιηθεί για την ενημέρωση της διαδρομής προς το εξωτερικό βιβλίο εργασίας (εάν το τελευταίο μετακινήθηκε).

Ενώ δεν μπορείτε να επεξεργαστείτε τα δεδομένα σε βιβλία εργασίας που αποθηκεύονται σε απομακρυσμένες τοποθεσίες ή πόρους, μπορείτε ακόμη να τα χρησιμοποιήσετε ως εξωτερική πηγή δεδομένων. Εάν παρέχεται η σχετική διαδρομή για ένα εξωτερικό βιβλίο εργασίας, αυτή μετατρέπεται αυτόματα σε πλήρη διαδρομή.

Αυτό το παράδειγμα χρησιμοποιεί ένα εξωτερικό βιβλίο εργασίας του οποίου το φύλλο με όνομα `Sheet1` περιέχει ένα όνομα σειράς στο B1, ονόματα κατηγοριών στο A2:A4 και αριθμητικές τιμές στο B2:B4. Το παράδειγμα δημιουργεί ένα γράφημα πίτας, συνδέει το βιβλίο εργασίας και χρησιμοποιεί το [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setrange/) για να αντιστοιχίσει το A1:B4 σε μία σειρά και τρεις κατηγορίες. Αποθηκεύει την παρουσίαση με το συνδεδεμένο διάγραμμα.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 600, true);
auto chartData = chart->get_ChartData();
auto workbookPath = IO::Path::GetFullPath(u"externalWorkbook.xlsx");

chartData->SetExternalWorkbook(workbookPath);
chartData->SetRange(u"Sheet1!$A$1:$B$4");

presentation->Save(u"Presentation_with_externalWorkbook.pptx", Export::SaveFormat::Pptx);
```

Η παράμετρος `updateChartData` της [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) ελέγχει εάν το βιβλίο εργασίας φορτώνεται.

* Όταν `updateChartData` είναι `false`, ενημερώνεται μόνο η διαδρομή του βιβλίου εργασίας. Τα δεδομένα διαγράμματος δεν φορτώνονται ή ενημερώνονται από το στοχευόμενο βιβλίο εργασίας, επομένως το βιβλίο εργασίας μπορεί να μην είναι διαθέσιμο.
* Όταν `updateChartData` είναι `true`, τα δεδομένα διαγράμματος ενημερώνονται από το στοχευόμενο βιβλίο εργασίας.

Το παρακάτω παράδειγμα εκχωρεί μια εικονική διεύθυνση URL με `updateChartData` ορισμένο σε `false`. Διατηρεί τα προεπιλεγμένα δεδομένα του διαγράμματος πίτας και αποθηκεύει την παρουσίαση χωρίς να φορτώσει το μη διαθέσιμο βιβλίο εργασίας.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 600, true);

chart->get_ChartData()->SetExternalWorkbook(u"https://example.com/unavailable-workbook.xlsx", false);
presentation->Save(u"SetExternalWorkbookWithUpdateChartData.pptx", Export::SaveFormat::Pptx);
```

### **Ανάκτηση Διαδρομής Εξωτερικού Βιβλίου Εργασίας Πηγής Δεδομένων ενός Διαγράμματος**

Για να εντοπίσετε το βιβλίο εργασίας που συνδέεται με ένα διάγραμμα, ελέγξτε εάν το διάγραμμα χρησιμοποιεί εξωτερική πηγή δεδομένων και ανακτήστε τη διαδρομή του βιβλίου εργασίας.

Αυτό το παράδειγμα ελέγχει το πρώτο σχήμα στην πρώτη διαφάνεια μιας παρουσίασης με συνδεδεμένο εξωτερικό βιβλίο εργασίας. Εάν πρόκειται για διάγραμμα συνδεδεμένο σε εξωτερικό βιβλίο εργασίας, το παράδειγμα εκτυπώνει το [get_ExternalWorkbookPath](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_externalworkbookpath/) στην κονσόλα. Στη συνέχεια αποθηκεύει ένα αντίγραφο της παρουσίασης.

```cpp
#include <DOM/Chart/ChartDataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"externalWorkbook.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto chartData = chart->get_ChartData();
    if (chartData->get_DataSourceType() == ChartDataSourceType::ExternalWorkbook)
    {
        Console::WriteLine(chartData->get_ExternalWorkbookPath());
    }
    else
    {
        Console::WriteLine(u"The chart does not use an external workbook.");
    }
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}

presentation->Save(u"Result.pptx", Export::SaveFormat::Pptx);
```

### **Επεξεργασία Δεδομένων Διαγράμματος**

Μπορείτε να επεξεργαστείτε τα δεδομένα σε εξωτερικά βιβλία εργασίας με τον ίδιο τρόπο που κάνετε αλλαγές στα περιεχόμενα εσωτερικών βιβλίων εργασίας. Όταν ένα εξωτερικό βιβλίο εργασίας δεν μπορεί να φορτωθεί, ρίχνεται μια εξαίρεση.

Αυτό το παράδειγμα χρησιμοποιεί ένα διάγραμμα που είναι το πρώτο σχήμα στην πρώτη διαφάνεια και είναι συνδεδεμένο σε προσβάσιμο εξωτερικό βιβλίο εργασίας. Ορίζει την τιμή του πρώτου σημείου δεδομένων στην πρώτη σειρά σε 100 και αποθηκεύει την ενημερωμένη παρουσίαση. Η επεξεργασία τιμών κελιών μπορεί να ενημερώσει το συνδεδεμένο εξωτερικό αρχείο XLSX, οπότε χρησιμοποιήστε αντίγραφο εάν χρειάζεται να διατηρήσετε το αρχικό βιβλίο εργασίας.

```cpp
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
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

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto series = chart->get_ChartData()->get_Series();
    if (series->get_Count() > 0 && series->idx_get(0)->get_DataPoints()->get_Count() > 0)
    {
        auto valueCell = series->idx_get(0)->get_DataPoints()->idx_get(0)->get_Value()->get_AsCell();
        if (valueCell != nullptr)
        {
            valueCell->set_Value(ObjectExt::Box<int32_t>(100));
            presentation->Save(u"presentation_out.pptx", Export::SaveFormat::Pptx);
        }
        else
        {
            Console::WriteLine(u"The first data point is not linked to a workbook cell.");
        }
    }
    else
    {
        Console::WriteLine(u"The chart has no data points to edit.");
    }
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

### **Ανάκτηση Βιβλίου Εργασίας από την Κρυφή Μνήμη Διαγράμματος**

Εάν ένα διάγραμμα χρησιμοποιεί εξωτερικό βιβλίο εργασίας που λείπει ή δεν είναι διαθέσιμο, το Aspose.Slides μπορεί να ανακατασκευάσει το βιβλίο εργασίας διαγράμματος από τα δεδομένα που είναι αποθηκευμένα στην παρουσίαση. Δημιουργήστε [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/), ρυθμίστε το με [set_SpreadsheetOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/), και καλέστε το [ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/) με `true` πριν ανοίξετε την παρουσίαση.

Το παρακάτω παράδειγμα C++ ανακτά δεδομένα βιβλίου εργασίας για ένα διάγραμμα που είναι το πρώτο σχήμα στην πρώτη διαφάνεια και αναφέρεται σε μη διαθέσιμο εξωτερικό βιβλίο εργασίας. Πρόσβαση στα ανακτημένα δεδομένα γίνεται μέσω του [IChart::get_ChartData](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_chartdata/) και του [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/):

```cpp
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/SpreadsheetOptions.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto spreadsheetOptions = MakeObject<SpreadsheetOptions>();
spreadsheetOptions->set_RecoverWorkbookFromChartCache(true);

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_SpreadsheetOptions(spreadsheetOptions);

auto presentation = MakeObject<Presentation>(u"presentation.pptx", loadOptions);
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto recoveredWorkbook = chart->get_ChartData()->get_ChartDataWorkbook();

    // Διαβάστε ή τροποποιήστε τα ανακτημένα δεδομένα του βιβλίου εργασίας εδώ.
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

Εάν το εξωτερικό βιβλίο εργασίας δεν είναι διαθέσιμο και η ανάκτηση είναι απενεργοποιημένη, το Aspose.Slides ρίχνει μια [System::InvalidOperationException](https://reference.aspose.com/slides/cpp/system/details_invalidoperationexception/). Ενεργοποιήστε την ανάκτηση μόνο όταν η χρήση των προσωρινών δεδομένων διαγράμματος είναι αποδεκτή εναλλακτική λύση, επειδή η κρυφή μνήμη ενδέχεται να μην περιέχει αλλαγές που έγιναν στο εξωτερικό βιβλίο εργασίας μετά την τελευταία ενημέρωση της παρουσίασης.

## **Συχνές Ερωτήσεις**

**Μπορώ να προσδιορίσω εάν ένα συγκεκριμένο διάγραμμα είναι συνδεδεμένο με εξωτερικό ή ενσωματωμένο βιβλίο εργασίας;**

Ναι. Ένα διάγραμμα έχει έναν [data source type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) και μια [path to an external workbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/); εάν η πηγή είναι ένα εξωτερικό βιβλίο εργασίας, μπορείτε να διαβάσετε τη πλήρη διαδρομή για να βεβαιωθείτε ότι χρησιμοποιείται εξωτερικό αρχείο.

**Υποστηρίζονται σχετικές διαδρομές σε εξωτερικά βιβλία εργασίας και πώς αποθηκεύονται;**

Ναι. Εάν ορίσετε μια σχετική διαδρομή, αυτή μετατρέπεται αυτόματα σε απόλυτη διαδρομή. Η παρουσίαση αποθηκεύει την απόλυτη διαδρομή στο αρχείο PPTX, επομένως η μετακίνηση του βιβλίου εργασίας μπορεί να απαιτήσει ενημέρωση του συνδέσμου.

**Μπορώ να χρησιμοποιήσω βιβλία εργασίας που βρίσκονται σε δικτυακούς πόρους/κεφαλαιαίους δίσκους;**

Ναι, τέτοια βιβλία μπορούν να χρησιμοποιηθούν ως εξωτερική πηγή δεδομένων. Ωστόσο, η επεξεργασία απομακρυσμένων βιβλίων εργασίας απευθείας από το Aspose.Slides δεν υποστηρίζεται· μπορούν μόνο να χρησιμοποιηθούν ως πηγή.

**Αντικαθιστά το Aspose.Slides το εξωτερικό XLSX όταν αποθηκεύεται η παρουσίαση;**

Η παρουσίαση αποθηκεύει έναν [link to the external file](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/). Η επεξεργασία δεδομένων διαγράμματος που προέρχονται από κελιά μπορεί επίσης να ενημερώσει το συνδεδεμένο τοπικό αρχείο XLSX. Χρησιμοποιήστε ένα αντίγραφο του βιβλίου εργασίας εάν το πρωτότυπο πρέπει να παραμείνει αμετάβλητο.

**Τι πρέπει να κάνω εάν το εξωτερικό αρχείο είναι προστατευμένο με κωδικό;**

Το Aspose.Slides δεν δέχεται κωδικό πρόσβασης κατά τη σύνδεση. Μια συνήθης προσέγγιση είναι να αφαιρεθεί η προστασία εκ των προτέρων ή να προετοιμαστεί ένα αποκρυπτογραφημένο αντίγραφο (π.χ. χρησιμοποιώντας το [Aspose.Cells](https://reference.aspose.com/cells/cpp/)) και να συνδεθεί με αυτό το αντίγραφο.

**Μπορούν πολλά διαγράμματα να αναφέρονται στο ίδιο εξωτερικό βιβλίο εργασίας;**

Ναι. Κάθε διάγραμμα αποθηκεύει το δικό του σύνδεσμο. Εάν όλα δείχνουν στο ίδιο αρχείο, η ενημέρωση του αρχείου θα αντικατοπτριστεί σε κάθε διάγραμμα την επόμενη φορά που φορτωθούν τα δεδομένα.