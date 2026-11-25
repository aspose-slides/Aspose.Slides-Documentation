---
title: Προσαρμογή 3D Διαγραμμάτων σε Παρουσιάσεις Χρησιμοποιώντας C++
linktitle: 3D Διάγραμμα
type: docs
url: /el/cpp/3d-chart/
keywords:
- 3D Διάγραμμα
- περιστροφή
- βάθος
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Δημιουργήστε 3D διαγράμματα σε παρουσιάσεις PowerPoint με το Aspose.Slides για C++. Ρυθμίστε την περιστροφή, τις αναλογίες ύψους, το βάθος του διαγράμματος και το διάστημα μεταξύ των σειρών με παραδείγματα C++."
---
## **Επισκόπηση**

Aspose.Slides for C++ σας επιτρέπει να προσαρμόσετε την προβολή ενός 3D διαγράμματος μέσω [IChart::get_Rotation3D](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_rotation3d/). Αυτό το άρθρο δείχνει πώς να ρυθμίσετε την περιστροφή, τις αναλογίες ύψους, το βάθος, τους άξονες ορθής γωνίας και το διάστημα μεταξύ των σειρών, και στη συνέχεια να αποθηκεύσετε την παρουσίαση σε μορφή PPTX.

## **Ορισμός της Περιστροφής και του Βάθους ενός 3D Διαγράμματος**

Το παρακάτω παράδειγμα δημιουργεί μια [Παρουσίαση](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) και χρησιμοποιεί [IShapeCollection::AddChart](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addchart/) για να προσθέσει ένα στοιβαγμένο 3D διακριτικό στήλης στη πρώτη διαφάνειά του. Αντικαθιστά τις προεπιλεγμένες σειρές και κατηγορίες με δύο σειρές που περιέχουν τρεις τιμές η καθεμία. Ο δείκτης φύλλου εργασίας `0` προσδιορίζει το πρώτο φύλλο δεδομένων του διαγράμματος· η γραμμή `0` περιέχει τα ονόματα των σειρών και η στήλη `0` περιέχει τις ετικέτες κατηγορίας.

Οι μέθοδοι [set_RotationX](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rotationx/) και [set_RotationY](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rotationy/) ορίζουν την περιστροφή του διαγράμματος στα 40 και 270 μοίρες, αντίστοιχα. Η μέθοδος [set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) θέτει το βάθος στο 150 % του πλάτους του, ενώ η [set_RightAngleAxes](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rightangleaxes/) ενεργοποιεί άξονες ορθής γωνίας αντί για προοπτική. Η προκύπτουσα παρουσίαση περιέχει το γεμισμένο διάγραμμα με αυτές τις ρυθμίσεις 3D προβολής.

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

## **Εφαρμογή Εικόνας ως Γέμιση στην Επιφάνεια ενός 3D Διαγράμματος**

Μπορείτε να γεμίσετε ανεξάρτητα τον [πλευρικό τοίχο](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_sidewall/), τον [οπίσθιο τοίχο](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_backwall/) και το [πάτωμα](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_floor/) ενός 3D διαγράμματος. Ορίστε τον [τύπο γέμισης](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) της επιφάνειας σε `Picture` και εκχωρήστε μια εικόνα. Για να τοποθετήσετε ένα αντίγραφο της εικόνας σε όλη την επιφάνεια, ορίστε τόσο τη [λειτουργία γέμισης εικόνας](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/) όσο και τον [τύπο εικόνας](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartwall/set_picturetype/) του τοίχου σε `Stretch`.

Αποθηκεύστε το αρχείο [arrow.png](arrow.png) στον τρέχοντα φάκελο. Το παράδειγμα περιστρέφει το διάγραμμα και αυξάνει τη μέγιστη τιμή του κάθετου άξονα ώστε το πάτωμα να φαίνεται ανάμεσα στις στήλες. Στη συνέχεια κλωνοποιεί τη διαφάνεια δύο φορές και εφαρμόζει το βέλος σε διαφορετική επιφάνεια σε κάθε διαφάνεια. Και τα τρία διαγράμματα διατηρούν τα ίδια δεδομένα, γωνία θέασης και φόντο.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartWall.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/Chart/IRotation3D.h>
#include <DOM/Chart/PictureType.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/shared_ptr.h>
#include <initializer_list>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 20, 30, 680, 480);
chart->get_Rotation3D()->set_RightAngleAxes(true);
chart->get_Rotation3D()->set_RotationX(40);
chart->get_Rotation3D()->set_RotationY(30);

auto verticalAxis = chart->get_Axes()->get_VerticalAxis();
verticalAxis->set_IsAutomaticMaxValue(false);
verticalAxis->set_MaxValue(24);

auto backSlide = presentation->get_Slides()->AddClone(slide);
auto floorSlide = presentation->get_Slides()->AddClone(slide);
auto backChart = ExplicitCast<IChart>(backSlide->get_Shape(0));
auto floorChart = ExplicitCast<IChart>(floorSlide->get_Shape(0));

auto imageBytes = IO::File::ReadAllBytes(u"arrow.png");
auto arrow = presentation->get_Images()->AddImage(imageBytes);

for (const auto& surface : { chart->get_SideWall(), backChart->get_BackWall(), floorChart->get_Floor() })
{
    auto fill = surface->get_Format()->get_Fill();
    fill->set_FillType(FillType::Picture);
    auto pictureFill = fill->get_PictureFillFormat();
    pictureFill->get_Picture()->set_Image(arrow);
    pictureFill->set_PictureFillMode(PictureFillMode::Stretch);
    surface->set_PictureType(PictureType::Stretch);
}

presentation->Save(u"chart-surfaces.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το Microsoft PowerPoint εμφανίζει τις τρεις διαφάνειες ως εξής.

| Πλευρικός τοίχος | Οπίσθιος τοίχος | Πάτωμα |
| --- | --- | --- |
| ![Βέλος που δείχνει μέσα στο διάγραμμα κατά μήκος του πλευρικού τοίχου](side-wall.png) | ![Βέλος που δείχνει δεξιά κατά μήκος του οπίσθιου τοίχου](back-wall.png) | ![Βέλος που δείχνει δεξιά κατά μήκος του πατώματος μεταξύ των στηλών](floor.png) |

## **Ρύθμιση των Αναλογιών Ύψους ενός 3D Διαγράμματος**

Χρησιμοποιήστε την [IRotation3D::set_HeightPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_heightpercents/) για να ορίσετε το ύψος ενός 3D διαγράμματος ως ποσοστό του πλάτους του. Αυτό αλλάζει τις αναλογίες της 3D σκηνής χωρίς να αλλάζει το μέγεθος του αντικειμένου διαγράμματος στη διαφάνεια.

Το παρακάτω παράδειγμα δημιουργεί ένα διάγραμμα [Column3D](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) με τα προεπιλεγμένα δεδομένα: τρεις σειρές και τέσσερις κατηγορίες. Αποθηκεύει τρεις παρουσιάσεις με αναλογίες ύψους 50 %, 100 % και 200 %. Η θέση, το πλάτος και το ύψος του διαγράμματος παραμένουν σταθερά. Τα δεδομένα, η περιστροφή, το βάθος, το διάστημα σειρών και η μορφοποίηση είναι πανομοιότυπα σε όλα τα τρία αρχεία· μόνο το ποσοστό ύψους αλλάζει.

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

Οι παρακάτω εικόνες από το ισοδύναμο .NET παράδειγμα εξήχθησαν με το Microsoft PowerPoint και απεικονίζουν τις ίδιες ρυθμίσεις ύψους. Ένα μικρότερο ποσοστό παράγει μια πιο επίπεδη σκηνή, ενώ ένα μεγαλύτερο ποσοστό δημιουργεί μια πιο ψηλή σκηνή μέσα στο ίδιο αντικείμενο διαγράμματος. Το PowerPoint ενδέχεται επίσης να προσαρμόσει τα διαστήματα των αξόνων και τη θέση των ετικετών ώστε να ταιριάζουν με τη σκηνή.

| Ύψος: 50 % | Ύψος: 100 % | Ύψος: 200 % |
| --- | --- | --- |
| ![3D διάγραμμα στήλης με ύψος στο 50 % του πλάτους του](height_percent_50.png) | ![3D διάγραμμα στήλης με ύψος στο 100 % του πλάτους του](height_percent_100.png) | ![3D διάγραμμα στήλης με ύψος στο 200 % του πλάτους του](height_percent_200.png) |

Αυτές οι μέθοδοι ελέγχουν διαφορετικές πτυχές του διαγράμματος:

| Μέθοδος | Αποτέλεσμα |
| --- | --- |
| [IRotation3D::set_HeightPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_heightpercents/) | Ύψος της 3D σκηνής ως ποσοστό του πλάτους της. |
| [IShape::set_Height](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_height/) | Ύψος του αντικειμένου διαγράμματος στη διαφάνεια, σε μονάδες σημείων. |
| [IRotation3D::set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) | Βάθος της 3D σκηνής ως ποσοστό του πλάτους της. |
| [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) | Απόσταση μεταξύ σειρών κατά τον άξονα βάθους, ως ποσοστό του πλάτους του σημείου. |

Η ρύθμιση του ύψους επηρεάζει τα 3D διαγράμματα στήλης και μπάρας, συμπεριλαμβανομένων των κυλινδρικών, κωνικών και πυραμιδικών παραλλαγών, καθώς και τα 3D διαγράμματα γραμμής, περιοχής, πίτας και επιφάνειας. Η σύγκριση παραπάνω χρησιμοποιεί τον επαληθευμένο τύπο `Column3D`. Η ρύθμιση δεν αλλάζει την εμφάνιση ενός 2D διαγράμματος `ClusteredColumn` ή ενός διαγράμματος `BubbleWith3D`; αυτά τα ονόματα είναι μέλη της απαρίθμησης [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/). Για άλλες ρυθμίσεις εμφάνισης διαγράμματος, δείτε [Chart Formatting](/slides/el/cpp/chart-formatting/).

## **Ρύθμιση του Κενού μεταξύ Σειρών**

Χρησιμοποιήστε την [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) για να ελέγξετε την απόσταση μεταξύ σειρών δεδομένων κατά τον άξονα βάθους ενός 3D διαγράμματος, εκφρασμένη ως ποσοστό του πλάτους του σημείου. Χρησιμοποιήστε τιμές από **0 to 500**, inclusive: `0` αφαιρεί το κενό, ενώ μεγαλύτερες τιμές αυξάνουν το διάστημα. Με σταθερό βάθος διαγράμματος, η αύξηση του κενού κάνει τα σημεία πιο λεπτά κατά τον άξονα βάθους.

Πρόσβαση στη ομάδα μέσω του [IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/). Η ρύθμιση επηρεάζει κάθε σειρά σε αυτήν την ομάδα, όχι μόνο τη σειρά που χρησιμοποιήθηκε για την πρόσβαση. Η [IChartSeries::get_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_gapdepth/) επιστρέφει τη ρύθμιση της γονικής ομάδας.

Αυτή η ρύθμιση επηρεάζει τα 3D διαγράμματα στήλης και μπάρας, συμπεριλαμβανομένων των κυλινδρικών, κωνικών και πυραμιδικών παραλλαγών, καθώς και τα 3D διαγράμματα γραμμής και περιοχής. Η εμφάνιση εξαρτάται από το αν οι σειρές είναι τοποθετημένες σε βάθος, ομαδοποιημένες ή στοιβαγμένες. Για σαφή σύγκριση των κενών μεταξύ ξεχωριστών σειρών, χρησιμοποιήστε το `ChartType::Column3D` από την απαρίθμηση [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/).

Αυτές οι μέθοδοι ελέγχουν διαφορετικές πτυχές του διαγράμματος:

| Μέθοδος | Αποτέλεσμα |
| --- | --- |
| [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) | Απόσταση μεταξύ σειρών κατά τον άξονα βάθους, ως ποσοστό του πλάτους του σημείου. |
| [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) | Απόσταση μεταξύ γειτονικών ομάδων μπάρας ή στήλης, ως ποσοστό του πλάτους της μπάρας ή της στήλης. |
| [IRotation3D::set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) | Συνολικό βάθος διαγράμματος, ως ποσοστό του πλάτους του διαγράμματος. |

Το παρακάτω αυτόνομο παράδειγμα χρησιμοποιεί τα προεπιλεγμένα δεδομένα του διαγράμματος, τα οποία περιέχουν τρεις σειρές και τέσσερις κατηγορίες. Αποθηκεύει δύο παρουσιάσεις με ταυτόχρονα δεδομένα, περιστροφή, πλάτος κενού και βάθος διαγράμματος· μόνο το βάθος κενού αλλάζει.

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

Οι παρακάτω εικόνες από το ισοδύναμο .NET παράδειγμα εξήχθησαν με το Microsoft PowerPoint και απεικονίζουν τις ίδιες ρυθμίσεις κενού βάθους.

| Κενό βάθους: 0 % | Κενό βάθους: 500 % |
| --- | --- |
| ![3D διάγραμμα στήλης χωρίς κενό μεταξύ σειρών κατά τον άξονα βάθους](gap_depth_0.png) | ![3D διάγραμμα στήλης με κενό 500 % μεταξύ σειρών κατά τον άξονα βάθους](gap_depth_500.png) |

## **Αλλαγή του Τύπου Σειράς 3D και του Σχήματος Μπάρας**

Σε ένα ομαδοποιημένο κυλινδρικό διάγραμμα, η πρώτη σειρά ξεκινά με κυλινδρικές μπάρες. Το παράδειγμα διαβάζει τα [IChartSeries::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_type/) και [IChartSeries::get_Bar3DShape](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_bar3dshape/) πριν και μετά από κάθε αλλαγή.

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
| Δημιουργία διαγράμματος | `ClusteredCylinder` | `Cylinder` |
| Κλήση του [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_type/) με `ClusteredCone` | `ClusteredCone` | `Cone` |
| Κλήση του [set_Bar3DShape](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_bar3dshape/) με `Box` | `ClusteredColumn3D` | `Box` |

Ο ορισμός του σχήματος σε `Box` αλλάζει επίσης τον τύπο σειράς σε `ClusteredColumn3D`. Εάν ο κώδικάς σας κάνει διακλαδώσεις βάσει του τύπου σειράς, καλέστε `series->get_Type()` μετά την αλλαγή του σχήματος. Μια τιμή που είχε αποθηκευτεί πριν την αλλαγή θα εξακολουθεί να επιλέγει τη διακλάδωση `ClusteredCone`.

![Σύγκριση PowerPoint που δείχνει την πρώτη σειρά ως κυλίνδρους, κώνοι και ορθογώνιες στήλες από αριστερά προς δεξιά](series-shapes.png)

## **Συχνές Ερωτήσεις**

**Ποιοι τύποι διαγραμμάτων υποστηρίζουν λειτουργία 3D στο Aspose.Slides;**

Το Aspose.Slides υποστηρίζει 3D παραλλαγές των διαγραμμάτων στήλης, συμπεριλαμβανομένων των Column 3D, Clustered Column 3D, Stacked Column 3D και 100 % Stacked Column 3D, καθώς και συναφή 3D είδη που εκτίθενται μέσω της απαρίθμησης [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/). Για μια ακριβή, ενημερωμένη λίστα, ελέγξτε τα μέλη του [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) στην τεκμηρίωση του API της εγκατεστημένης έκδοσής σας.

**Μπορώ να λάβω μια ραστερική εικόνα ενός 3D διαγράμματος για αναφορά ή το web;**

Ναι. Μπορείτε να εξαχθεί ένα διάγραμμα σε εικόνα με τη [Shape::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/) ή να [αποδώσετε ολόκληρη τη διαφάνεια](/slides/el/cpp/convert-powerpoint-to-png/) σε μορφές όπως PNG ή JPEG. Αυτό είναι χρήσιμο όταν χρειάζεστε μια ραστερική προεπισκόπηση ή θέλετε να ενσωματώσετε το διάγραμμα σε έγγραφα, πίνακες εργαλείων ή ιστοσελίδες χωρίς να απαιτείται το PowerPoint.

**Πόσο αποδοτική είναι η δημιουργία και η απόδοση μεγάλων 3D διαγραμμάτων;**

Η απόδοση εξαρτάται από τον όγκο των δεδομένων και την οπτική πολυπλοκότητα. Για βέλτιστα αποτελέσματα, κρατήστε τα 3D εφέ στο ελάχιστο, αποφύγετε βαριές υφές στους τοίχους και τις περιοχές σχεδίασης, περιορίστε τον αριθμό σημείων δεδομένων ανά σειρά όπου είναι δυνατόν, και αποδώστε σε κατάλληλο μέγεθος εξόδου (ανάλυση και διαστάσεις) ώστε να ταιριάζει με την προβλεπόμενη οθόνη ή εκτύπωση.