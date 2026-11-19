---
title: Προσαρμογή 3Δ Διαγραμμάτων σε Παρουσιάσεις με C++
linktitle: 3Δ Διάγραμμα
type: docs
url: /el/cpp/3d-chart/
keywords:
- 3Δ διάγραμμα
- περιστροφή
- βάθος
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Δημιουργήστε 3Δ διαγράμματα σε παρουσιάσεις PowerPoint με το Aspose.Slides για C++. Προσαρμόστε την περιστροφή, τις αναλογίες ύψους, το βάθος του διαγράμματος και την απόσταση μεταξύ σειρών με παραδείγματα C++."
---
## **Επισκόπηση**

Το Aspose.Slides for C++ σάς επιτρέπει να προσαρμόσετε την προβολή ενός 3Δ διαγράμματος μέσω [IChart::get_Rotation3D](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_rotation3d/). Αυτό το άρθρο δείχνει πώς να ρυθμίσετε την περιστροφή, τις αναλογίες ύψους, το βάθος, τους άξονες ορθής γωνίας και την απόσταση μεταξύ σειρών, και στη συνέχεια να αποθηκεύσετε την παρουσίαση σε μορφή PPTX.

## **Ορισμός της Περιστροφής και του Βάθους ενός 3Δ Διαγράμματος**

Το παρακάτω παράδειγμα δημιουργεί ένα [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) και χρησιμοποιεί το [IShapeCollection::AddChart](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addchart/) για να προσθέσει ένα στοίβαγμα 3Δ στήλης στο πρώτο του slide. Αντικαθιστά τις προεπιλεγμένες σειρές και κατηγορίες με δύο σειρές που περιέχουν τρία τιμές η καθεμία. Ο δείκτης φύλλου εργασίας `0` προσδιορίζει το πρώτο φύλλο δεδομένων του διαγράμματος· η γραμμή `0` κρατά τα ονόματα των σειρών, και η στήλη `0` κρατά τις ετικέτες κατηγοριών.

Οι μέθοδοι [set_RotationX](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rotationx/) και [set_RotationY](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rotationy/) ορίζουν την περιστροφή του διαγράμματος στα 40 και 270 μοίρες, αντίστοιχα. Η μέθοδος [set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) θέτει το βάθος του στο 150 % του πλάτους του, ενώ η [set_RightAngleAxes](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rightangleaxes/) ενεργοποιεί άξονες ορθής γωνίας αντί για προοπτική. Η προκύπτουσα παρουσίαση περιέχει το γεμισμένο διάγραμμα με αυτές τις ρυθμίσεις 3Δ προβολής.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IRotation3D.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn3D, 0, 0, 500, 500);

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheetIndex = 0;

double values[2][3] = { { 20, 50, 30 }, { 30, 10, 60 } };

for (auto categoryIndex = 0; categoryIndex < 3; categoryIndex++)
{
    auto categoryName = String::Format(u"Category {0}", categoryIndex + 1);
    auto categoryCell = workbook->GetCell(worksheetIndex, categoryIndex + 1, 0, ObjectExt::Box(categoryName));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);
}

for (auto seriesIndex = 0; seriesIndex < 2; seriesIndex++)
{
    auto seriesName = String::Format(u"Series {0}", seriesIndex + 1);
    auto seriesCell = workbook->GetCell(worksheetIndex, 0, seriesIndex + 1, ObjectExt::Box(seriesName));
    auto series = chart->get_ChartData()->get_Series()->Add(seriesCell, chart->get_Type());

    for (auto categoryIndex = 0; categoryIndex < 3; categoryIndex++)
    {
        auto valueCell = workbook->GetCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, ObjectExt::Box(values[seriesIndex][categoryIndex]));
        series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
    }
}

chart->get_Rotation3D()->set_RightAngleAxes(true);
chart->get_Rotation3D()->set_RotationX(40);
chart->get_Rotation3D()->set_RotationY(270);
chart->get_Rotation3D()->set_DepthPercents(150);

presentation->Save(u"Rotation3D_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ρύθμιση των Αναλογιών Ύψους ενός 3Δ Διαγράμματος**

Χρησιμοποιήστε το [IRotation3D::set_HeightPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_heightpercents/) για να ορίσετε το ύψος ενός 3Δ διαγράμματος ως ποσοστό του πλάτους του. Αυτό αλλάζει τις αναλογίες της 3Δ σκηνής χωρίς να αλλάζει το μέγεθος του αντικειμένου διαγράμματος στο slide.

Το παρακάτω παράδειγμα δημιουργεί ένα διάγραμμα [Column3D](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) με τα προεπιλεγμένα δεδομένα: τρεις σειρές και τέσσερις κατηγορίες. Αποθηκεύει τρεις παρουσιάσεις με αναλογίες ύψους 50 %, 100 % και 200 %. Η θέση, το πλάτος και το ύψος του διαγράμματος παραμένουν σταθερά. Τα δεδομένα, η περιστροφή, το βάθος, η απόσταση σειρών και η μορφοποίηση είναι τα ίδια και στα τρία αρχεία· μόνο το ποσοστό ύψους αλλάζει.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <DOM/Chart/IRotation3D.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <cstdint>
#include <initializer_list>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 40, 30, 620, 460);
chart->get_Rotation3D()->set_RotationX(20);
chart->get_Rotation3D()->set_RotationY(30);
chart->get_Rotation3D()->set_RightAngleAxes(true);
chart->get_Rotation3D()->set_DepthPercents(100);
chart->get_ChartData()->get_Series()->idx_get(0)->get_ParentSeriesGroup()->set_GapDepth(150);

for (uint16_t heightPercent : { 50, 100, 200 })
{
    chart->get_Rotation3D()->set_HeightPercents(heightPercent);
    auto fileName = String::Format(u"chart_height_{0}.pptx", heightPercent);
    presentation->Save(fileName, SaveFormat::Pptx);
}
presentation->Dispose();
```

Οι παρακάτω εικόνες από το αντίστοιχο παράδειγμα .NET εξήχθησαν με το Microsoft PowerPoint και δείχνουν τις ίδιες ρυθμίσεις ύψους. Ένα μικρότερο ποσοστό παράγει πιο επίπεδη σκηνή, ενώ ένα μεγαλύτερο ποσοστό παράγει πιο ψηλή σκηνή εντός του ίδιου αντικειμένου διαγράμματος. Το PowerPoint μπορεί επίσης να προσαρμόσει τα διαστήματα των γραμμών των αξόνων και τη θέση των ετικετών ώστε να ταιριάζουν στη σκηνή.

| Ύψος: 50% | Ύψος: 100% | Ύψος: 200% |
| --- | --- | --- |
| ![3Δ στήλη με ύψος 50 % του πλάτους της](height_percent_50.png) | ![3Δ στήλη με ύψος 100 % του πλάτους της](height_percent_100.png) | ![3Δ στήλη με ύψος 200 % του πλάτους της](height_percent_200.png) |

Αυτές οι μέθοδοι ελέγχουν διαφορετικές πτυχές του διαγράμματος:

| Μέθοδος | Αποτέλεσμα |
| --- | --- |
| [IRotation3D::set_HeightPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_heightpercents/) | Ύψος της 3Δ σκηνής ως ποσοστό του πλάτους της. |
| [IShape::set_Height](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_height/) | Ύψος του αντικειμένου διαγράμματος στο slide, σε points. |
| [IRotation3D::set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) | Βάθος της 3Δ σκηνής ως ποσοστό του πλάτους της. |
| [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) | Απόσταση μεταξύ σειρών κατά τον άξονα βάθους, ως ποσοστό του πλάτους του δείκτη. |

Η ρύθμιση του ύψους επηρεάζει διαγράμματα 3Δ στήλης και ράβδου, συμπεριλαμβανομένων των κυλινδρικών, κωνικών και πυραμιδικών παραλλαγών, καθώς και διαγράμματα 3Δ γραμμής, περιοχής, πίτας και επιφάνειας. Η σύγκριση παραπάνω χρησιμοποιεί τον επαληθευμένο τύπο `Column3D`. Η ρύθμιση δεν αλλάζει την εμφάνιση ενός 2Δ διαγράμματος `ClusteredColumn` ή ενός διαγράμματος `BubbleWith3D`; αυτά τα ονόματα είναι μέλη της αρίθμησης [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/). Για άλλες ρυθμίσεις εμφάνισης διαγράμματος, δείτε το [Chart Formatting](/slides/el/cpp/chart-formatting/).

## **Ρύθμιση της Απόστασης μεταξύ Σειρών**

Χρησιμοποιήστε το [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) για να ελέγξετε την απόσταση μεταξύ δεδομένων σειρών κατά τον άξονα βάθους ενός 3Δ διαγράμματος, εκφρασμένη ως ποσοστό του πλάτους του δείκτη. Χρησιμοποιήστε τιμές από **0 μέχρι 500**, συμπεριλαμβανομένων: το `0` αφαιρεί το κενό, ενώ μεγαλύτερες τιμές αυξάνουν την απόσταση. Με σταθερό βάθος διαγράμματος, η αύξηση του κενό κάνει τα δείκτες πιο λεπτά κατά τον άξονα βάθους.

Αποκτήστε την ομάδα μέσω του [IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/). Η ρύθμιση εφαρμόζεται σε κάθε σειρά της ομάδας, όχι μόνο στη σειρά που χρησιμοποιήθηκε για την πρόσβαση. Η [IChartSeries::get_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_gapdepth/) επιστρέφει τη ρύθμιση της ομάδας-γονέα.

Αυτή η ρύθμιση επηρεάζει διαγράμματα 3Δ στήλης και ράβδου, συμπεριλαμβανομένων των κυλινδρικών, κωνικών και πυραμιδικών παραλλαγών, καθώς και διαγράμματα 3Δ γραμμής και περιοχής. Η εμφάνιση εξαρτάται από το αν οι σειρές είναι διατεταγμένες σε βάθος, ομαδοποιημένες ή στοίβαγμενες. Για σαφή σύγκριση των κενών μεταξύ ξεχωριστών σειρών, χρησιμοποιήστε το `ChartType::Column3D` από την αρίθμηση [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/).

Αυτές οι μέθοδοι ελέγχουν διαφορετικές πτυχές του διαγράμματος:

| Μέθοδος | Αποτέλεσμα |
| --- | --- |
| [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) | Απόσταση μεταξύ σειρών κατά τον άξονα βάθους, ως ποσοστό του πλάτους του δείκτη. |
| [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) | Απόσταση μεταξύ γειτονικών ομάδων ράβδων ή στηλών, ως ποσοστό του πλάτους της ράβδου ή στήλης. |
| [IRotation3D::set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) | Συνολικό βάθος διαγράμματος, ως ποσοστό του πλάτους του διαγράμματος. |

Το παρακάτω παράδειγμα αυτόνομο χρησιμοποιεί τα προεπιλεγμένα δεδομένα διαγράμματος, που περιέχουν τρεις σειρές και τέσσερις κατηγορίες. Αποθηκεύει δύο παρουσιάσεις με πανομοιότυπα δεδομένα, περιστροφή, πλάτος κενών και βάθος διαγράμματος· μόνο το βάθος κενών αλλάζει.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IRotation3D.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <cstdint>
#include <initializer_list>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 40, 30, 620, 230);

chart->get_Rotation3D()->set_RotationX(20);
chart->get_Rotation3D()->set_RotationY(30);
chart->get_Rotation3D()->set_DepthPercents(100);

auto series = chart->get_ChartData()->get_Series()->idx_get(0);
auto group = series->get_ParentSeriesGroup();
group->set_GapWidth(150);

for (uint16_t gapDepth : { 0, 500 })
{
    group->set_GapDepth(gapDepth);

    auto fileName = String::Format(u"series_gap_depth_{0}.pptx", gapDepth);
    presentation->Save(fileName, SaveFormat::Pptx);
}
presentation->Dispose();
```

Οι παρακάτω εικόνες από το αντίστοιχο παράδειγμα .NET εξήχθησαν με το Microsoft PowerPoint και δείχνουν τις ίδιες ρυθμίσεις βάθους κενών.

| Βάθος κενών: 0% | Βάθος κενών: 500% |
| --- | --- |
| ![3Δ στήλη χωρίς κενό μεταξύ σειρών κατά τον άξονα βάθους](gap_depth_0.png) | ![3Δ στήλη με κενό 500 % μεταξύ σειρών κατά τον άξονα βάθους](gap_depth_500.png) |

## **Αλλαγή του Τύπου Σειράς 3Δ και του Σχήματος Ράβδου**

Σε ένα ομαδοποιημένο κυλινδρικό διάγραμμα, η πρώτη σειρά ξεκινά με κυλινδρικές ράβδους. Το παράδειγμα διαβάζει [IChartSeries::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_type/) και [IChartSeries::get_Bar3DShape](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_bar3dshape/) πριν και μετά από κάθε αλλαγή.

```cpp
#include <DOM/Chart/ChartShapeType.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/enum.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredCylinder, 20, 20, 500, 300);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

auto printSeries = [&series]()
{
    auto type = Enum<ChartType>::GetName(series->get_Type());
    auto shape = Enum<ChartShapeType>::GetName(series->get_Bar3DShape());
    Console::WriteLine(u"{0} | {1}", type, shape);
};

printSeries();

series->set_Type(ChartType::ClusteredCone);
printSeries();

series->set_Bar3DShape(ChartShapeType::Box);
printSeries();

presentation->Save(u"series_shape.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

| Αλλαγή στην πρώτη σειρά | `get_Type` | `get_Bar3DShape` |
| --- | --- | --- |
| Δημιουργία του διαγράμματος | `ClusteredCylinder` | `Cylinder` |
| Κλήση του [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_type/) με `ClusteredCone` | `ClusteredCone` | `Cone` |
| Κλήση του [set_Bar3DShape](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_bar3dshape/) με `Box` | `ClusteredColumn3D` | `Box` |

Ο ορισμός του σχήματος σε `Box` αλλάζει επίσης τον τύπο σειράς σε `ClusteredColumn3D`. Εάν ο κώδικάς σας ελέγχει τον τύπο σειράς, καλέστε `series->get_Type()` μετά την αλλαγή του σχήματος. Μια τιμή που έχει αποθηκευτεί πριν την αλλαγή θα εξακολουθήσει να οδηγεί στην ακμή `ClusteredCone`.

![Σύγκριση PowerPoint που δείχνει την πρώτη σειρά ως κυλίνδρους, κώνοι και ορθογώνιες στήλες από αριστερά προς δεξιά](series-shapes.png)

## **Συχνές Ερωτήσεις**

**Ποιοι τύποι διαγραμμάτων υποστηρίζουν λειτουργία 3Δ στο Aspose.Slides;**

Το Aspose.Slides υποστηρίζει 3Δ παραλλαγές διαγραμμάτων στηλών, συμπεριλαμβανομένων των Column 3D, Clustered Column 3D, Stacked Column 3D και 100 % Stacked Column 3D, καθώς και σχετικούς 3Δ τύπους που εκτίθενται μέσω της αρίθμησης [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/). Για μια ακριβή, ενημερωμένη λίστα, ελέγξτε τα μέλη του [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) στην τεκμηρίωση API της εγκατεστημένης έκδοσής σας.

**Μπορώ να λάβω μια ραστερ εικόνα ενός 3Δ διαγράμματος για αναφορά ή το διαδίκτυο;**

Ναι. Μπορείτε να εξάγετε ένα διάγραμμα σε εικόνα με την [Shape::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/) ή να [αποδώσετε ολόκληρη τη διαφάνεια](/slides/el/cpp/convert-powerpoint-to-png/) σε μορφές όπως PNG ή JPEG. Αυτό είναι χρήσιμο όταν χρειάζεστε μια ραστερ προεπισκόπηση ή θέλετε να ενσωματώσετε το διάγραμμα σε έγγραφα, πίνακες ελέγχου ή ιστοσελίδες χωρίς να απαιτείται το PowerPoint.

**Πόσο αποδοτική είναι η δημιουργία και απόδοση μεγάλων 3Δ διαγραμμάτων;**

Η απόδοση εξαρτάται από τον όγκο των δεδομένων και τη οπτική πολυπλοκότητα. Για βέλτιστα αποτελέσματα, κρατήστε τα 3Δ εφέ στα ελάχιστα, αποφύγετε βαριά υφάσματα σε τοίχους και περιοχές σχεδίασης, περιορίστε τον αριθμό των σημείων δεδομένων ανά σειρά όταν είναι δυνατόν, και αποδώστε σε ένα κατάλληλο μέγεθος εξόδου (ανάλυση και διαστάσεις) ώστε να ταιριάζει με την απαιτούμενη προβολή ή εκτύπωση.