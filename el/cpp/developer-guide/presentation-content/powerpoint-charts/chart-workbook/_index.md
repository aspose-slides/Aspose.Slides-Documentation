---
title: Διαχείριση βιβλίων εργασίας γραφημάτων σε παρουσιάσεις με χρήση С++
linktitle: Βιβλίο Εργασίας Γραφήματος
type: docs
weight: 70
url: /el/cpp/chart-workbook/
keywords:
- βιβλίο εργασίας γραφήματος
- δεδομένα γραφήματος
- κελί βιβλίου εργασίας
- ετικέτα δεδομένων
- φύλλο εργασίας
- πηγή δεδομένων
- εξωτερικό βιβλίο εργασίας
- εξωτερικά δεδομένα
- PowerPoint
- παρουσίαση
- С++
- Aspose.Slides
description: "Ανακαλύψτε το Aspose.Slides για С++: διαχειριστείτε εύκολα τα βιβλία εργασίας γραφημάτων σε μορφές PowerPoint και OpenDocument για να βελτιώσετε τα δεδομένα της παρουσίασής σας."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργάζεστε με βιβλία εργασίας γραφημάτων στο Aspose.Slides. Εμφανίζει πώς να διαβάζετε και να γράφετε δεδομένα γραφημάτων μέσω ροών βιβλίου εργασίας, να χρησιμοποιείτε κελιά βιβλίου εργασίας ως ετικέτες δεδομένων γραφήματος, να έχετε πρόσβαση σε συλλογές φύλλων εργασίας και να καθορίζετε τον τύπο πηγής δεδομένων για τις τιμές του γραφήματος.

Καλύπτει επίσης την εργασία με εξωτερικά βιβλία εργασίας ως πηγές δεδομένων γραφήματος. Τα παραδείγματα δείχνουν πώς να δημιουργήσετε και να εκχωρήσετε ένα εξωτερικό βιβλίο εργασίας, να ανακτήσετε τη διαδρομή ενός εξωτερικού βιβλίου εργασίας που είναι συνδεδεμένο με ένα γράφημα και να επεξεργαστείτε τα δεδομένα του γραφήματος όταν το βιβλίο εργασίας είναι διαθέσιμο.

**Σημείωση** ότι τα δεδομένα του γραφήματος πρέπει να οργανωθούν με τον ίδιο τρόπο ή να έχουν δομή παρόμοια με την πηγή.

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

Αυτός ο κώδικας C++ δείχνει τη λειτουργία για ορισμό βιβλίου εργασίας δεδομένων γραφήματος:

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

## **Ορισμός Κελιάς Βιβλίου Εργασίας ως Ετικέτα Δεδομένων Γραφήματος**

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
2. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της.
3. Προσθέστε ένα γράφημα Bubble με κάποια δεδομένα.
4. Πρόσβαση στη σειρά του γραφήματος.
5. Ορίστε το κελί του βιβλίου εργασίας ως ετικέτα δεδομένων.
6. Αποθηκεύστε την παρουσίαση.

Αυτός ο κώδικας C++ δείχνει πώς να ορίσετε ένα κελί βιβλίου εργασίας ως ετικέτα δεδομένων γραφήματος:

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

Αυτός ο κώδικας C++ δείχνει μια λειτουργία όπου η μέθοδος [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) χρησιμοποιείται για πρόσβαση σε συλλογή φύλλων εργασίας:

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

Αυτός ο κώδικας C++ δείχνει πώς να καθορίσετε έναν τύπο για πηγή δεδομένων:

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

Το Aspose.Slides δεν υποστηρίζει τη δυαδική μορφή βιβλίου εργασίας του Excel (.xlsb) που μπορεί να είναι ενσωματωμένη σε ορισμένα γραφήματα. Μπορείτε να χρησιμοποιήσετε τη μέθοδο `get_EmbeddedWorkbookType` στο [IChartData](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartdata/) μαζί με την απαρίθμηση [WorkbookType](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/workbooktype/) για να ανιχνεύσετε μη υποστηριζόμενες μορφές και να παραλείψετε αυτά τα γραφήματα.

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

    // Διαβάστε ή τροποποιήστε τα δεδομένα του βιβλίου εργασίας του γραφήματος εδώ.
}
```

## **Εξωτερικό Βιβλίο Εργασίας**

{{% alert color="primary" %}} 
Στο [Aspose.Slides](https://releases.aspose.com/slides/el/cpp/release-notes/2019/aspose-slides-for-cpp-19-4-release-notes/) 19.4, υλοποιήσαμε την υποστήριξη εξωτερικών βιβλίων εργασίας ως πηγή δεδομένων για γραφήματα.
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

Χρησιμοποιώντας τη μέθοδο **`IChartData::SetExternalWorkbook`**, μπορείτε να εκχωρήσετε ένα εξωτερικό βιβλίο εργασίας σε ένα γράφημα ως πηγή δεδομένων του. Αυτή η μέθοδος μπορεί επίσης να χρησιμοποιηθεί για να ενημερώσει τη διαδρομή προς το εξωτερικό βιβλίο εργασίας (αν αυτό έχει μετακινηθεί).

Αν και δεν μπορείτε να επεξεργαστείτε τα δεδομένα σε βιβλία εργασίας που βρίσκονται σε απομακρυσμένες τοποθεσίες ή πόρους, μπορείτε ακόμα να τα χρησιμοποιήσετε ως εξωτερική πηγή δεδομένων. Εάν παρέχεται σχετική διαδρομή για ένα εξωτερικό βιβλίο εργασίας, αυτή μετατρέπεται αυτόματα σε πλήρη διαδρομή.

Αυτός ο κώδικας C++ δείχνει πώς να ορίσετε ένα εξωτερικό βιβλίο εργασίας:

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

Η παράμετρος `updateChartData` (στο πλαίσιο της μεθόδου `SetExternalWorkbook`) χρησιμοποιείται για να καθορίσει αν θα φορτωθεί ή όχι ένα βιβλίο εργασίας Excel.

* Όταν η τιμή `updateChartData` είναι `false`, ενημερώνεται μόνο η διαδρομή του βιβλίου εργασίας — τα δεδομένα του γραφήματος δεν θα φορτωθούν ή ενημερωθούν από το βιβλίο εργασίας‑στόχο. Μπορείτε να χρησιμοποιήσετε αυτή τη ρύθμιση όταν το βιβλίο εργασίας‑στόχος δεν υπάρχει ή δεν είναι διαθέσιμο.
* Όταν η τιμή `updateChartData` είναι `true`, τα δεδομένα του γραφήματος ενημερώνονται από το βιβλίο εργασίας‑στόχο.

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f, true);
System::SharedPtr<IChartData> chartData = chart->get_ChartData();

System::SharedPtr<ChartData> concreteChartData = System::AsCast<ChartData>(chartData);
concreteChartData->SetExternalWorkbook(u"http://path/doesnt/exists", false);

pres->Save(u"SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
```

### **Λήψη Διαδρομής Εξωτερικής Πηγής Δεδομένων Βιβλίου Εργασίας ενός Γραφήματος**

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
2. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της.
3. Δημιουργήστε ένα αντικείμενο για το σχήμα του γραφήματος.
4. Δημιουργήστε ένα αντικείμενο για τον τύπο πηγής (`ChartDataSourceType`) που αντιπροσωπεύει την πηγή δεδομένων του γραφήματος.
5. Καθορίστε τη σχετική προϋπόθεση βάσει του ότι ο τύπος πηγής είναι ο ίδιος με τον τύπο εξωτερικού βιβλίου εργασίας.

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

// Αποθηκεύει την παρουσίαση
pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

### **Επεξεργασία Δεδομένων Γραφήματος**

Μπορείτε να επεξεργαστείτε τα δεδομένα σε εξωτερικά βιβλία εργασίας με τον ίδιο τρόπο που κάνετε αλλαγές στο περιεχόμενο εσωτερικών βιβλίων εργασίας. Όταν ένα εξωτερικό βιβλίο εργασίας δεν μπορεί να φορτωθεί, ενεργοποιείται μια εξαίρεση.

Αυτός ο κώδικας C++ είναι μια υλοποίηση της περιγραφόμενης διαδικασίας:

```c++
const String templatePath = u"../templates/presentation.pptx";
	const String outPath = u"../out/presentation-out.pptx";
	

	System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(templatePath);
	System::SharedPtr<Aspose::Slides::Charts::IChart> chart = System::AsCast<Aspose::Slides::Charts::IChart>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
	System::SharedPtr<Aspose::Slides::Charts::ChartData> chartData = System::ExplicitCast<Aspose::Slides::Charts::ChartData>(chart->get_ChartData());
	

	chartData->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0)->get_Value()->get_AsCell()->set_Value(System::ObjectExt::Box<int32_t>(100));
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Συχνές Ερωτήσεις**

**Μπορώ να καθορίσω αν ένα συγκεκριμένο γράφημα είναι συνδεδεμένο με εξωτερικό ή ενσωματωμένο βιβλίο εργασίας;**

Ναι. Ένα γράφημα διαθέτει έναν [τύπο πηγής δεδομένων](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) και μια [διαδρομή προς ένα εξωτερικό βιβλίο εργασίας](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/); εάν η πηγή είναι εξωτερικό βιβλίο εργασίας, μπορείτε να διαβάσετε τη πλήρη διαδρομή για να βεβαιωθείτε ότι χρησιμοποιείται εξωτερικό αρχείο.

**Υποστηρίζονται σχετικές διαδρομές σε εξωτερικά βιβλία εργασίας και πώς αποθηκεύονται;**

Ναι. Εάν καθορίσετε μια σχετική διαδρομή, αυτή μετατρέπεται αυτόματα σε απόλυτη διαδρομή. Αυτό είναι βολικό για τη φορητότητα του έργου· ωστόσο, να γνωρίζετε ότι η παρουσίαση αποθηκεύει την απόλυτη διαδρομή στο αρχείο PPTX.

**Μπορώ να χρησιμοποιήσω βιβλία εργασίας που βρίσκονται σε δικτυακούς πόρους/κοινόχρηστους φακέλους;**

Ναι, τέτοια βιβλία εργασίας μπορούν να χρησιμοποιηθούν ως εξωτερική πηγή δεδομένων. Ωστόσο, η άμεση επεξεργασία απομακρυσμένων βιβλίων εργασίας από το Aspose.Slides δεν υποστηρίζεται — μπορούν να χρησιμοποιηθούν μόνο ως πηγή.

**Αντικαθιστά το Aspose.Slides το εξωτερικό XLSX κατά την αποθήκευση της παρουσίασης;**

Όχι. Η παρουσίαση αποθηκεύει έναν [σύνδεσμο προς το εξωτερικό αρχείο](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) και τον χρησιμοποιεί για την ανάγνωση των δεδομένων. Το εξωτερικό αρχείο δεν τροποποιείται όταν η παρουσίαση αποθηκεύεται.

**Τι πρέπει να κάνω αν το εξωτερικό αρχείο είναι προστατευμένο με κωδικό πρόσβασης;**

Το Aspose.Slides δεν δέχεται κωδικό πρόσβασης όταν δημιουργείται ο σύνδεσμος. Μία κοινή προσέγγιση είναι η αφαίρεση της προστασίας εκ των προτέρων ή η προετοιμασία μιας αποκρυπτογραφημένης αντιγράφου (π.χ., χρησιμοποιώντας [Aspose.Cells](/cells/cpp/)) και η σύνδεση σε αυτό το αντίγραφο.

**Μπορούν πολλά γραφήματα να αναφέρονται στο ίδιο εξωτερικό βιβλίο εργασίας;**

Ναι. Κάθε γράφημα αποθηκεύει το δικό του σύνδεσμο. Εάν όλα δείχνουν στο ίδιο αρχείο, η ενημέρωση του αρχείου θα αντικατοπτρίζεται σε κάθε γράφημα την επόμενη φορά που θα φορτωθούν τα δεδομένα.