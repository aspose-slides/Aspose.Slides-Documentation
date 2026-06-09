---
title: Διαχείριση Σειρών Δεδομένων Γραφήματος σε Παρουσιάσεις με С++
linktitle: Σειρές Δεδομένων
type: docs
url: /el/cpp/chart-series/
keywords:
- σειρά γραφήματος
- επικάλυψη σειρών
- χρώμα σειράς
- χρώμα κατηγορίας
- όνομα σειράς
- σημείο δεδομένων
- διάστημα σειράς
- PowerPoint
- παρουσίαση
- С++
- Aspose.Slides
description: "Μάθετε πώς να διαχειρίζεστε τις σειρές γραφήματος σε С++ για PowerPoint (PPT/PPTX) με πρακτικά παραδείγματα κώδικα και βέλτιστες πρακτικές για να ενισχύσετε τις παρουσιάσεις δεδομένων σας."
---
## **Επισκόπηση**

Αυτό το άρθρο περιγράφει τον ρόλο του [ChartSeries](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/chartseries/) στο Aspose.Slides, εστιάζοντας στο πώς τα δεδομένα δομούνται και απεικονίζονται μέσα σε παρουσιάσεις. Αυτά τα αντικείμενα παρέχουν τα θεμελιώδη στοιχεία που ορίζουν μεμονωμένα σύνολα σημείων δεδομένων, κατηγορίες και παραμέτρους εμφάνισης σε ένα γράφημα. Εργαζόμενοι με το [ChartSeries](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/chartseries/), οι προγραμματιστές μπορούν να ενσωματώσουν απρόσκοπτα τις υποκείμενες πηγές δεδομένων και να διατηρούν πλήρη έλεγχο πάνω στο πώς προβάλλεται η πληροφορία, με αποτέλεσμα δυναμικές, δεδομενο‑οδηγούμενες παρουσιάσεις που μεταδίδουν σαφώς ιδέες και αναλύσεις.

Μία σειρά είναι μια γραμμή ή στήλη αριθμών που απεικονίζονται σε ένα γράφημα.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Ορισμός της Επικάλυψης της Σειράς Δεδομένων**

Με τη μέθοδο [IChartSeries::get_Overlap()](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.charts.i_chart_series#a5ae56346bd11dc0a2264ff049a3e72bb), μπορείτε να καθορίσετε πόση επικάλυψη πρέπει να έχουν οι γραμμές και οι στήλες σε ένα 2D γράφημα (εύρος: -100 έως 100). Αυτή η ιδιότητα εφαρμόζεται σε όλες τις σειρές της γονικής ομάδας σειρών: πρόκειται για μια προβολή της αντίστοιχης ιδιότητας της ομάδας.

Χρησιμοποιήστε τη μέθοδο `get_ParentSeriesGroup()::set_Overlap()` για να ορίσετε την προτιμώμενη τιμή για το `Overlap`.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation).
1. Προσθέστε ένα ομαδοποιημένο γράφημα στήλης σε μια διαφάνεια.
1. Αποκτήστε πρόσβαση στην πρώτη σειρά γραφήματος.
1. Αποκτήστε πρόσβαση στο `ParentSeriesGroup` της σειράς γραφήματος και ορίστε την προτιμώμενη τιμή επικάλυψης για τη σειρά.
1. Γράψτε την τροποποιημένη παρουσίαση σε αρχείο PPTX.

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// Προσθέτει γράφημα
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series();
if (series->idx_get(0)->get_Overlap() == 0)
{
    // Ορίζει την επικάλυψη της σειράς
    series->idx_get(0)->get_ParentSeriesGroup()->set_Overlap(-30);
}

// Γράφει το αρχείο παρουσίασης στο δίσκο
presentation->Save(u"SetChartSeriesOverlap_out.pptx", SaveFormat::Pptx);
```

## **Αλλαγή Χρώματος Σειράς Δεδομένων**

Aspose.Slides for C++ σας επιτρέπει να αλλάξετε το χρώμα μιας σειράς με τον εξής τρόπο:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation).
1. Προσθέστε ένα γράφημα στη διαφάνεια.
1. Αποκτήστε πρόσβαση στη σειρά του οποίου το χρώμα θέλετε να αλλάξετε.
1. Ορίστε τον προτιμώμενο τύπο γεμίσματος και το χρώμα γεμίσματος.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();

auto chart = shapes->AddChart(ChartType::Pie, 50.0f, 50.0f, 600.0f, 400.0f);
auto point = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints()->idx_get(1);

point->set_Explosion(30);
point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Blue());

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Αλλαγή Χρώματος Κατηγορίας Σειράς Δεδομένων**

Aspose.Slides for C++ σας επιτρέπει να αλλάξετε το χρώμα μιας κατηγορίας σειράς με τον εξής τρόπο:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation).
1. Προσθέστε ένα γράφημα στη διαφάνεια.
1. Αποκτήστε πρόσβαση στην κατηγορία σειράς του οποίου το χρώμα θέλετε να αλλάξετε.
1. Ορίστε τον προτιμώμενο τύπο γεμίσματος και το χρώμα γεμίσματος.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
auto point = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0);

point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Blue());

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Αλλαγή Ονόματος Σειράς Δεδομένων**

Από προεπιλογή, τα ονόματα του υπόμνησης (legend) για ένα γράφημα είναι τα περιεχόμενα των κελιών πάνω από κάθε στήλη ή γραμμή δεδομένων.

Στο παράδειγμά μας (δείγμα εικόνας),

* οι στήλες είναι *Series 1, Series 2,* και *Series 3*·
* οι γραμμές είναι *Category 1, Category 2, Category 3,* και *Category 4*·

Το Aspose.Slides for C++ σάς επιτρέπει να ενημερώσετε ή να αλλάξετε το όνομα μιας σειράς στα δεδομένα του γραφήματος και στο υπόμνημα.

Αυτός ο κώδικας C++ δείχνει πώς να αλλάξετε το όνομα μιας σειράς στα δεδομένα γραφήματος `ChartDataWorkbook`:

```cpp
auto pres = System::MakeObject<Presentation>();

auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);

auto seriesCell = chart->get_ChartData()->get_ChartDataWorkbook()->GetCell(0, 0, 1);
seriesCell->set_Value(ObjectExt::Box<String>(u"New name"));

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

Αυτός ο κώδικας C++ δείχνει πώς να αλλάξετε το όνομα μιας σειράς στο υπόμνημα μέσω του `Series`:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();

auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

auto name = series->get_Name();
name->get_AsCells()->idx_get(0)->set_Value(ObjectExt::Box<String>(u"New name"));
```

## **Ορισμός Χρώματος Γέμισματος Σειράς Δεδομένων**

Aspose.Slides for C++ σας επιτρέπει να ορίσετε το αυτόματο χρώμα γεμίσματος για τις σειρές γραφήματος μέσα σε μια περιοχή σχεδίασης με τον εξής τρόπο:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με το δείκτη της.
1. Προσθέστε ένα γράφημα με προεπιλεγμένα δεδομένα βάσει του προτιμώμενου τύπου σας (στο παρακάτω παράδειγμα χρησιμοποιήσαμε `ChartType::ClusteredColumn`).
1. Αποκτήστε πρόσβαση στη σειρά του γραφήματος και ορίστε το χρώμα γεμίσματος σε Automatic.
1. Αποθηκεύστε την παρουσίαση σε αρχείο PPTX.

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// Δημιουργεί ένα ομαδοποιημένο γράφημα στήλης
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 50.0f, 600.0f, 400.0f);

// Ορίζει τη μορφή γεμίσματος της σειράς σε αυτόματο
for (const auto& series : chart->get_ChartData()->get_Series())
{
    series->GetAutomaticSeriesColor();
}

// Γράφει το αρχείο παρουσίασης στο δίσκο
presentation->Save(u"AutoFillSeries_out.pptx", SaveFormat::Pptx);
```

## **Ορισμός Αντιστροφής Χρωμάτων Γέμισματος Σειράς Δεδομένων**

Aspose.Slides σας επιτρέπει να ορίσετε την αντιστροφή του χρώματος γεμίσματος για τις σειρές γραφήματος μέσα σε μια περιοχή σχεδίασης με τον εξής τρόπο:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με το δείκτη της.
1. Προσθέστε ένα γράφημα με προεπιλεγμένα δεδομένα βάσει του προτιμώμενου τύπου σας (στο παρακάτω παράδειγμα χρησιμοποιήσαμε `ChartType::ClusteredColumn`).
1. Αποκτήστε πρόσβαση στη σειρά του γραφήματος και ορίστε το χρώμα γεμίσματος σε invert.
1. Αποθηκεύστε την παρουσίαση σε αρχείο PPTX.

```cpp
Color inverColor = Color::get_Red();
    
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

auto workBook = chart->get_ChartData()->get_ChartDataWorkbook();
auto chartData = chart->get_ChartData();

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();

// Adds new series and categories
chartData->get_Series()->Add(workBook->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
chartData->get_Categories()->Add(workBook->GetCell(0, 1, 0, ObjectExt::Box<String>(u"Category 1")));
chartData->get_Categories()->Add(workBook->GetCell(0, 2, 0, ObjectExt::Box<String>(u"Category 2")));
chartData->get_Categories()->Add(workBook->GetCell(0, 3, 0, ObjectExt::Box<String>(u"Category 3")));

// Takes the first chart series and populates its series data.
auto series = chartData->get_Series()->idx_get(0);
series->get_DataPoints()->AddDataPointForBarSeries(workBook->GetCell(0, 1, 1, ObjectExt::Box<int32_t>(-20)));
series->get_DataPoints()->AddDataPointForBarSeries(workBook->GetCell(0, 2, 1, ObjectExt::Box<int32_t>(50)));
series->get_DataPoints()->AddDataPointForBarSeries(workBook->GetCell(0, 3, 1, ObjectExt::Box<int32_t>(-30)));
Color seriesColor = series->GetAutomaticSeriesColor();
series->set_InvertIfNegative(true);
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(seriesColor);
series->get_InvertedSolidFillColor()->set_Color(inverColor);
pres->Save(u"SetInvertFillColorChart_out.pptx", SaveFormat::Pptx);
```

## **Ορισμός Αντιστροφής Χρώματος Γέμισματος για Σειρά Γραφήματος**

Το Aspose.Slides σάς επιτρέπει να ορίσετε αντιστροφές μέσω των μεθόδων `IChartDataPoint::set_InvertIfNegative()` και `ChartDataPoint.set_InvertIfNegative()`. Όταν μια αντιστροφή ορίζεται με αυτές τις μεθόδους, το σημείο δεδομένων αντιστρέφει τα χρώματά του όταν λαμβάνει μια αρνητική τιμή.

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series();
chart->get_ChartData()->get_Series()->Clear();

auto workBook = chart->get_ChartData()->get_ChartDataWorkbook();
series->Add(workBook->GetCell(0, u"B1"), chart->get_Type());
auto dataPoints = series->idx_get(0)->get_DataPoints();
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B2", ObjectExt::Box<int32_t>(-5)));
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B3", ObjectExt::Box<int32_t>(3)));
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B4", ObjectExt::Box<int32_t>(-2)));
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B5", ObjectExt::Box<int32_t>(1)));

series->idx_get(0)->set_InvertIfNegative(false);

series->idx_get(0)->get_DataPoints()->idx_get(2)->set_InvertIfNegative(true);

pres->Save(u"out.pptx", SaveFormat::Pptx);
```

## **Καθαρισμός Συγκεκριμένων Τιμών Σημείων Δεδομένων**

Aspose.Slides for C++ σας επιτρέπει να καθαρίσετε τα δεδομένα `DataPoints` για μια συγκεκριμένη σειρά γραφήματος με τον εξής τρόπο:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation).
2. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της.
3. Αποκτήστε την αναφορά ενός γραφήματος μέσω του δείκτη του.
4. Διατρέξτε όλα τα `DataPoints` του γραφήματος και ορίστε τα `XValue` και `YValue` σε null.
5. Καθαρίστε όλα τα `DataPoints` για τη συγκεκριμένη σειρά γραφήματος.
6. Γράψτε την τροποποιημένη παρουσίαση σε αρχείο PPTX.

```cpp
auto pres = System::MakeObject<Presentation>(u"TestChart.pptx");
auto sl = pres->get_Slides()->idx_get(0);

auto chart = System::ExplicitCast<IChart>(sl->get_Shapes()->idx_get(0));
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();

for (const auto& dataPoint : dataPoints)
{
    dataPoint->get_XValue()->get_AsCell()->set_Value(nullptr);
    dataPoint->get_YValue()->get_AsCell()->set_Value(nullptr);
}

dataPoints->Clear();

pres->Save(u"ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat::Pptx);
```

## **Ορισμός Πλάτους Κενού Σειράς Δεδομένων**

Aspose.Slides for C++ σας επιτρέπει να ορίσετε το πλάτος κενού (Gap Width) μιας σειράς μέσω της μεθόδου **`set_GapWidth()`** με τον εξής τρόπο:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation).
1. Αποκτήστε πρόσβαση στην πρώτη διαφάνεια.
1. Προσθέστε ένα γράφημα με προεπιλεγμένα δεδομένα.
1. Αποκτήστε πρόσβαση σε οποιαδήποτε σειρά γραφήματος.
1. Ορίστε την ιδιότητα `GapWidth`.
1. Γράψτε την τροποποιημένη παρουσίαση σε αρχείο PPTX.

```cpp
// Δημιουργεί κενή παρουσίαση 
auto presentation = System::MakeObject<Presentation>();

// Πρόσβαση στην πρώτη διαφάνεια της παρουσίασης
auto slide = presentation->get_Slides()->idx_get(0);

// Προσθέτει γράφημα με προεπιλεγμένα δεδομένα
auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn, 0.0f, 0.0f, 500.0f, 500.0f);

// Ορίζει τον δείκτη του φύλλου δεδομένων του γραφήματος
int32_t worksheetIndex = 0;

// Λαμβάνει το φύλλο εργασίας δεδομένων του γραφήματος
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// Προσθέτει σειρές
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 2, ObjectExt::Box<String>(u"Series 2")), chart->get_Type());

// Προσθέτει κατηγορίες
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 1, 0, ObjectExt::Box<String>(u"Category 1")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 2, 0, ObjectExt::Box<String>(u"Category 2")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 3, 0, ObjectExt::Box<String>(u"Category 3")));

// Παίρνει τη δεύτερη σειρά γραφήματος
auto series = chart->get_ChartData()->get_Series()->idx_get(1);
auto dataPoints = series->get_DataPoints();

// Συμπληρώνει τα δεδομένα της σειράς
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 1, ObjectExt::Box<int32_t>(20)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 1, ObjectExt::Box<int32_t>(50)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 1, ObjectExt::Box<int32_t>(30)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 2, ObjectExt::Box<int32_t>(30)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 2, ObjectExt::Box<int32_t>(10)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 2, ObjectExt::Box<int32_t>(60)));

// Ορίζει την τιμή GapWidth
series->get_ParentSeriesGroup()->set_GapWidth(50);

// Αποθηκεύει την παρουσίαση στο δίσκο
presentation->Save(u"GapWidth_out.pptx", SaveFormat::Pptx);
```

## **Συχνές Ερωτήσεις**

**Υπάρχει όριο στον αριθμό των σειρών που μπορεί να περιέχει ένα μεμονωμένο γράφημα;**

Το Aspose.Slides δεν επιβάλλει συγκεκριμένο όριο στον αριθμό των σειρών που προσθέτετε. Το πρακτικό όριο καθορίζεται από την αναγνωσιμότητα του γραφήματος και από τη μνήμη που είναι διαθέσιμη στην εφαρμογή σας.

**Τι γίνεται αν οι στήλες μέσα σε ένα σύμπλεγμα είναι πολύ κοντά μεταξύ τους ή πολύ μακριά;**

Ρυθμίστε την τιμή του πλάτους κενού (gap width) για εκείνη τη σειρά (ή την γονική ομάδα σειρών). Η αύξηση της τιμής διευρύνει το κενό μεταξύ των στηλών, ενώ η μείωση την φέρνει πιο κοντά.