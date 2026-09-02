---
title: "Διαχείριση Βιβλίων Εργασίας Διαγραμμάτων σε Παρουσιάσεις χρησιμοποιώντας C++"
linktitle: "Βιβλίο Εργασίας Διαγράμματος"
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
- κρυφή μνήμη διαγράμματος
- ανάκτηση βιβλίου εργασίας
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Ανακαλύψτε το Aspose.Slides για C++: διαχειριστείτε με ευκολία τα βιβλία εργασίας διαγραμμάτων σε μορφές PowerPoint και OpenDocument για να απλοποιήσετε τα δεδομένα της παρουσίασής σας."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργάζεστε με βιβλία εργασίας διαγραμμάτων στο Aspose.Slides. Δείχνει πώς να διαβάζετε και να γράφετε δεδομένα διαγράμματος μέσω ροών βιβλίου εργασίας, να χρησιμοποιείτε κελιά βιβλίου εργασίας ως ετικέτες δεδομένων διαγράμματος, να έχετε πρόσβαση σε συλλογές φύλλων εργασίας και να καθορίζετε τον τύπο πηγής δεδομένων για τις τιμές του διαγράμματος.

Καλύπτει επίσης τη χρήση εξωτερικών βιβλίων εργασίας ως πηγών δεδομένων διαγράμματος. Τα παραδείγματα δείχνουν πώς να δημιουργήσετε και να αναθέσετε ένα εξωτερικό βιβλίο εργασίας, να αποκτήσετε τη διαδρομή ενός εξωτερικού βιβλίου εργασίας που είναι συνδεδεμένο σε διάγραμμα και να επεξεργαστείτε τα δεδομένα του διαγράμματος όταν το βιβλίο εργασίας είναι διαθέσιμο.

## **Ανάγνωση και Εγγραφή Δεδομένων Διαγράμματος από ένα Βιβλίο Εργασίας**

Το Aspose.Slides παρέχει τις μεθόδους [ReadWorkbookStream](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) και [WriteWorkbookStream](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) που σας επιτρέπουν να διαβάζετε και να γράφετε βιβλία εργασίας δεδομένων διαγράμματος (που περιέχουν δεδομένα διαγράμματος επεξεργασμένα με το Aspose.Cells). **Σημείωση** ότι τα δεδομένα του διαγράμματος πρέπει να οργανώνονται με τον ίδιο τρόπο ή να έχουν δομή παρόμοια με την πηγή.

``` cpp
auto pres = System::MakeObject<Presentation>(u"chart.pptx");

auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto data = chart->get_ChartData();

System::SharedPtr<System::IO::MemoryStream> stream = data->ReadWorkbookStream();
data->get_Series()->Clear();
data->get_Categories()->Clear();

stream->set_Position(0);
data->WriteWorkbookStream(stream);
```

Αυτός ο κώδικας C++ δείχνει τη λειτουργία ορισμού ενός βιβλίου εργασίας δεδομένων διαγράμματος:

``` cpp
auto pres = System::MakeObject<Presentation>(u"Test.pptx");

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(Charts::ChartType::Pie, 50.0f, 50.0f, 500.0f, 400.0f);
chart->get_ChartData()->get_ChartDataWorkbook()->Clear(0);

intrusive_ptr<Aspose::Cells::IWorkbook> workbook;
try
{
    workbook = Aspose::Cells::Factory::CreateIWorkbook(new String("a1.xlsx"));
}
catch (Aspose::Cells::Systems::Exception& ex)
{
    System::Console::Write(System::String::FromWCS(ex.GetMessageExp()->value()));
}

intrusive_ptr<MemoryStream> cellsOutputStream = new Aspose::Cells::Systems::IO::MemoryStream();
workbook->Save(cellsOutputStream, Aspose::Cells::SaveFormat_Xlsx);

cellsOutputStream->SetPosition(0);
System::SharedPtr<System::IO::MemoryStream> msout = ToSlidesMemoryStream(cellsOutputStream);

chart->get_ChartData()->WriteWorkbookStream(msout);

chart->get_ChartData()->SetRange(u"Sheet1!$A$1:$B$9");
auto series = chart->get_ChartData()->get_Series()->idx_get(0);
series->get_ParentSeriesGroup()->set_IsColorVaried(true);
pres->Save(u"response2.pptx", Export::SaveFormat::Pptx);
```

## **Ορισμός Κελιού WorkBook ως Ετικέτας Δεδομένων Διαγράμματος**

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
2. Λάβετε την αναφορά μιας διαφάνειας μέσω του δείκτη της.
3. Προσθέστε ένα διάγραμμα Bubble με κάποια δεδομένα.
4. Προσπελάστε τη σειρά του διαγράμματος.
5. Ορίστε το κελί του βιβλίου εργασίας ως ετικέτα δεδομένων.
6. Αποθηκεύστε την παρουσίαση.

Αυτός ο κώδικας C++ δείχνει πώς να ορίσετε ένα κελί βιβλίου εργασίας ως ετικέτα δεδομένων διαγράμματος:

``` cpp
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

Αυτός ο κώδικας C++ δείχνει μια λειτουργία όπου η μέθοδος [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) χρησιμοποιείται για πρόσβαση σε μια συλλογή φύλλων εργασίας:

```c++
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

## **Ανίχνευση Μη Υποστηριζόμενων Ενσωματωμένων Μορφών Βιβλίου Εργασίας**

Το Aspose.Slides δεν υποστηρίζει τη δυαδική μορφή βιβλίου εργασίας Excel (.xlsb) που μπορεί να ενσωματώνεται σε ορισμένα διαγράμματα. Μπορείτε να χρησιμοποιήσετε τη μέθοδο `get_EmbeddedWorkbookType` στο [IChartData](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdata/) μαζί με την απαρίθμηση [WorkbookType](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/workbooktype/) για να ανιχνεύσετε μη υποστηριζόμενες μορφές και να παραλείψετε αυτά τα διαγράμματα.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
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
        // Το ενσωματωμένο βιβλίο εργασίας είναι σε μορφή .xlsb, η οποία δεν υποστηρίζεται.
        continue;
    }

    // Διαβάστε ή τροποποιήστε εδώ τα δεδομένα βιβλίου εργασίας του διαγράμματος.
}
```

## **Εξωτερικό Βιβλίο Εργασίας**

{{% alert color="primary" %}} 
Στο [Aspose.Slides](https://releases.aspose.com/slides/el/cpp/release-notes/2019/aspose-slides-for-cpp-19-4-release-notes/) 19.4, εφαρμόσαμε υποστήριξη για εξωτερικά βιβλία εργασίας ως πηγή δεδομένων για διαγράμματα.
{{% /alert %}} 

### **Δημιουργία Εξωτερικού Βιβλίου Εργασίας**

Χρησιμοποιώντας τις μεθόδους **`ReadWorkbookStream`** και **`SetExternalWorkbook`**, μπορείτε είτε να δημιουργήσετε ένα εξωτερικό βιβλίο εργασίας από το μηδέν είτε να κάνετε ένα εσωτερικό βιβλίο εργασίας εξωτερικό.

Αυτός ο κώδικας C++ δείχνει τη διαδικασία δημιουργίας εξωτερικού βιβλίου εργασίας:

```c++
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

### **Ορισμός Εξωτερικού Βιβλίου Εργασίας**

Χρησιμοποιώντας τη μέθοδο **`IChartData::SetExternalWorkbook`**, μπορείτε να αντιστοιχίσετε ένα εξωτερικό βιβλίο εργασίας σε ένα διάγραμμα ως πηγή δεδομένων του. Η μέθοδος αυτή μπορεί επίσης να χρησιμοποιηθεί για την ενημέρωση διαδρομής προς το εξωτερικό βιβλίο εργασίας (αν αυτό έχει μετακινηθεί).

Ενώ δεν μπορείτε να επεξεργαστείτε τα δεδομένα σε βιβλία εργασίας αποθηκευμένα σε απομακρυσμένες θέσεις ή πόρους, μπορείτε ακόμη να χρησιμοποιήσετε τέτοια βιβλία εργασίας ως εξωτερική πηγή δεδομένων. Εάν παρέχεται η σχετική διαδρομή για ένα εξωτερικό βιβλίο εργασίας, αυτή μετατρέπεται αυτόματα σε πλήρη διαδρομή.

```c++
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

Η παράμετρος `updateChartData` (μετά τη μέθοδο `SetExternalWorkbook`) χρησιμοποιείται για να καθορίσει εάν ένα βιβλίο εργασίας Excel θα φορτωθεί ή όχι. 

* Όταν η τιμή του `updateChartData` είναι `false`, μόνο η διαδρομή του βιβλίου εργασίας ενημερώνεται — τα δεδομένα του διαγράμματος δεν θα φορτωθούν ή ενημερωθούν από το στόχο βιβλίου εργασίας. Μπορεί να θέλετε να χρησιμοποιήσετε αυτή τη ρύθμιση όταν το στόχο βιβλίο εργασίας δεν υπάρχει ή δεν είναι διαθέσιμο. 
* Όταν η τιμή του `updateChartData` είναι `true`, τα δεδομένα του διαγράμματος ενημερώνονται από το στόχο βιβλίου εργασίας.

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f, true);
System::SharedPtr<IChartData> chartData = chart->get_ChartData();

System::SharedPtr<ChartData> concreteChartData = System::AsCast<ChartData>(chartData);
concreteChartData->SetExternalWorkbook(u"http://path/doesnt/exists", false);

pres->Save(u"SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
```

### **Ανάκτηση Διαδρομής Εξωτερικού Πηγής Βιβλίου Εργασίας για Ένα Διάγραμμα**

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
2. Λάβετε την αναφορά μιας διαφάνειας μέσω του δείκτη της.
3. Δημιουργήστε ένα αντικείμενο για το σχήμα του διαγράμματος.
4. Δημιουργήστε ένα αντικείμενο για τον τύπο πηγής (`ChartDataSourceType`) που αντιπροσωπεύει την πηγή δεδομένων του διαγράμματος.
5. Καθορίστε τη σχετική προϋπόθεση βάσει του ότι ο τύπος πηγής είναι ίδιος με τον τύπο πηγής δεδομένων εξωτερικού βιβλίου εργασίας.

Αυτός ο κώδικας C++ δείχνει τη λειτουργία:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

auto slide = pres->get_Slides()->idx_get(1);
auto chart = System::ExplicitCast<IChart>(slide->get_Shapes()->idx_get(0));
ChartDataSourceType sourceType = chart->get_ChartData()->get_DataSourceType();
if (sourceType == ChartDataSourceType::ExternalWorkbook)
{
    System::String path = chart->get_ChartData()->get_ExternalWorkbookPath();
}

// Saves the presentation
pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

### **Επεξεργασία Δεδομένων Διαγράμματος**

Μπορείτε να επεξεργαστείτε τα δεδομένα σε εξωτερικά βιβλία εργασίας με τον ίδιο τρόπο που κάνετε αλλαγές στο περιεχόμενο εσωτερικών βιβλίων εργασίας. Όταν ένα εξωτερικό βιβλίο εργασίας δεν μπορεί να φορτωθεί, ρίχνεται μια εξαίρεση.

```c++
const String templatePath = u"../templates/presentation.pptx";
    const String outPath = u"../out/presentation-out.pptx";
    

    System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(templatePath);
    System::SharedPtr<Aspose::Slides::Charts::IChart> chart = System::AsCast<Aspose::Slides::Charts::IChart>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
    System::SharedPtr<Aspose::Slides::Charts::ChartData> chartData = System::ExplicitCast<Aspose::Slides::Charts::ChartData>(chart->get_ChartData());
    

    chartData->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0)->get_Value()->get_AsCell()->set_Value(System::ObjectExt::Box<int32_t>(100));
    pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Ανάκτηση Βιβλίου Εργασίας από την Κρυφή Μνήμη Διαγράμματος**

Εάν ένα διάγραμμα χρησιμοποιεί ένα εξωτερικό βιβλίο εργασίας που λείπει ή δεν είναι διαθέσιμο, το Aspose.Slides μπορεί να αναδημιουργήσει το βιβλίο εργασίας του διαγράμματος από τα δεδομένα που είναι αποθηκευμένα στην κρυφή μνήμη της παρουσίασης. Δημιουργήστε ένα [LoadOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides/loadoptions/), διαμορφώστε το με το [set_SpreadsheetOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/), και καλέστε το [ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/el/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/) με `true` πριν ανοίξετε την παρουσίαση.

Το παρακάτω παράδειγμα C++ ανοίγει μια παρουσίαση της οποία το διάγραμμα αναφέρεται σε μη διαθέσιμο εξωτερικό βιβλίο εργασίας και προσπελάζει τα ανακτημένα δεδομένα μέσω των [IChart::get_ChartData](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichart/get_chartdata/) και [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/):

```cpp
auto spreadsheetOptions = MakeObject<SpreadsheetOptions>();
spreadsheetOptions->set_RecoverWorkbookFromChartCache(true);

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_SpreadsheetOptions(spreadsheetOptions);

auto presentation = MakeObject<Presentation>(u"presentation.pptx", loadOptions);

auto shape = presentation->get_Slide(0)->get_Shape(0);
auto chart = System::ExplicitCast<IChart>(shape);

auto recoveredWorkbook = chart->get_ChartData()->get_ChartDataWorkbook();

// Διαβάστε ή τροποποιήστε εδώ τα δεδομένα του ανακτημένου βιβλίου εργασίας.

presentation->Dispose();
```

Εάν το εξωτερικό βιβλίο εργασίας δεν είναι διαθέσιμο και η ανάκτηση είναι απενεργοποιημένη, το Aspose.Slides ρίχνει ένα `System::InvalidOperationException`. Ενεργοποιήστε την ανάκτηση μόνο όταν η χρήση των δεδομένων του διαγράμματος από την κρυφή μνήμη είναι αποδεκτή εναλλακτική, επειδή η κρυφή μνήμη ίσως να μην περιέχει αλλαγές που έγιναν στο εξωτερικό βιβλίο εργασίας μετά την τελευταία ενημέρωση της παρουσίασης.

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Μπορώ να προσδιορίσω εάν ένα συγκεκριμένο διάγραμμα είναι συνδεδεμένο σε εξωτερικό ή ενσωματωμένο βιβλίο εργασίας;**

Ναι. Ένα διάγραμμα έχει έναν [τύπο πηγής δεδομένων](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) και μια [διαδρομή σε εξωτερικό βιβλίο εργασίας](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/); εάν η πηγή είναι ένα εξωτερικό βιβλίο εργασίας, μπορείτε να διαβάσετε τη πλήρη διαδρομή για να βεβαιωθείτε ότι χρησιμοποιείται εξωτερικό αρχείο.

**Υποστηρίζονται οι σχετικές διαδρομές προς εξωτερικά βιβλία εργασίας και πώς αποθηκεύονται;**

Ναι. Εάν καθορίσετε μια σχετική διαδρομή, αυτή μετατρέπεται αυτόματα σε απόλυτη διαδρομή. Αυτό είναι βολικό για τη φορητότητα του έργου· όμως, σημειώστε ότι η παρουσίαση αποθηκεύει την απόλυτη διαδρομή στο αρχείο PPTX.

**Μπορώ να χρησιμοποιήσω βιβλία εργασίας που βρίσκονται σε δικτυακούς πόρους/κοινόχρηστους φακέλους;**

Ναι, τέτοια βιβλία εργασίας μπορούν να χρησιμοποιηθούν ως εξωτερική πηγή δεδομένων. Ωστόσο, η επεξεργασία απομακρυσμένων βιβλίων εργασίας απευθείας από το Aspose.Slides δεν υποστηρίζεται — μπορούν μόνο να χρησιμοποιηθούν ως πηγή.

**Το Aspose.Slides αντικαθιστά το εξωτερικό XLSX κατά την αποθήκευση της παρουσίασης;**

Όχι. Η παρουσίαση αποθηκεύει ένα [σύνδεσμο προς το εξωτερικό αρχείο](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) και το χρησιμοποιεί για ανάγνωση δεδομένων. Το εξωτερικό αρχείο δεν τροποποιείται όταν η παρουσίαση αποθηκεύεται.

**Τι πρέπει να κάνω εάν το εξωτερικό αρχείο είναι προστατευμένο με κωδικό;**

Το Aspose.Slides δεν δέχεται κωδικό πρόσβασης κατά τη σύνδεση. Μια συνήθης προσέγγιση είναι να αφαιρέσετε την προστασία εκ των προτέρων ή να προετοιμάσετε ένα αποκρυπτογραφημένο αντίγραφο (π.χ., χρησιμοποιώντας το [Aspose.Cells](/cells/cpp/)) και να συνδέσετε σε αυτό το αντίγραφο.

**Μπορούν πολλά διαγράμματα να αναφέρονται στο ίδιο εξωτερικό βιβλίο εργασίας;**

Ναι. Κάθε διάγραμμα αποθηκεύει το δικό του σύνδεσμο. Εάν όλα δείχνουν στο ίδιο αρχείο, η ενημέρωση του αρχείου θα αντικατοπτρίζεται σε κάθε διάγραμμα την επόμενη φορά που τα δεδομένα θα φορτωθούν.