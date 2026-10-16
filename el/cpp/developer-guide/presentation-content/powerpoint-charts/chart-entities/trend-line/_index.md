---
title: Προσθήκη Γραμμών Τάσης σε Διαγράμματα Παρουσίασης σε C++
linktitle: Γραμμή Τάσης
type: docs
url: /el/cpp/trend-line/
keywords:
- διάγραμμα
- γραμμή τάσης
- εκθετική γραμμή τάσης
- γραμμική γραμμή τάσης
- λογαριθμική γραμμή τάσης
- γραμμή τάσης κινητού μέσου
- πολυωνυμική γραμμή τάσης
- γραμμή τάσης δύναμης
- προσαρμοσμένη γραμμή τάσης
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Προσθέστε και προσαρμόστε γρήγορα γραμμές τάσης σε διαγράμματα PowerPoint με το Aspose.Slides για C++ — ένας πρακτικός οδηγός για να εμπλέξετε το κοινό σας."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσθέσετε γραμμές τάσης σε διαγράμματα παρουσίασης χρησιμοποιώντας το Aspose.Slides. Δείχνει πώς να δημιουργήσετε ένα διάγραμμα, να προσθέσετε γραμμές τάσης σε σειρές διαγράμματος και να εργαστείτε με διάφορους τύπους γραμμών τάσης, συμπεριλαμβανομένων των εκθετικών, γραμμικών, λογαριθμικών, κινητού μέσου, πολυωνυμικών και δύναμης.

Επίσης περιγράφει πώς να προσθέσετε μια προσαρμοσμένη γραμμή σε ένα διάγραμμα εισάγοντας ένα σχήμα γραμμής, και περιλαμβάνει έναν σύντομο FAQ σχετικά με τις τιμές προβολής γραμμών τάσης προς τα εμπρός και προς τα πίσω και αν οι γραμμές τάσης διατηρούνται κατά την εξαγωγή σε PDF ή SVG και κατά την απόδοση των διαγραμμάτων ως εικόνες.

## **Προσθήκη Γραμμής Τάσης**

Χρησιμοποιήστε [ITrendlineCollection::Add](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendlinecollection/add/) για να προσθέσετε μια γραμμή τάσης σε μια σειρά διαγράμματος, επιλέγοντας τον τύπο της με [TrendlineType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/trendlinetype/). Το παράδειγμα δημιουργεί ένα συσσωτιστικό διάγραμμα στήλης με προεπιλεγμένα δεδομένα και προσθέτει δύο γραμμές τάσης σε κάθε μία από τις τρεις σειρές του.

Η εκθετική γραμμή τάσης κρύβει την εξίσωση και την τιμή R‑τετράγωνου μέσω [ITrendline::set_DisplayEquation](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_displayequation/) και [ITrendline::set_DisplayRSquaredValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_displayrsquaredvalue/), ενώ η γραμμική γραμμή τάσης είναι κόκκινη. Η λογαριθμική γραμμή τάσης χρησιμοποιεί [IOverridableText::AddTextFrameForOverriding](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ioverridabletext/addtextframeforoverriding/) για μια προσαρμοσμένη ετικέτα. Ο μέσος όρος κίνησης χρησιμοποιεί [ITrendline::set_Period](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_period/) για να υπολογίσει τον μέσο όρο τριών σημείων δεδομένων και [ITrendline::set_TrendlineName](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_trendlinename/) για προσαρμοσμένο όνομα.

Η πολυωνυμική γραμμή τάσης χρησιμοποιεί [ITrendline::set_Order](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_order/) για να ορίσει τον βαθμό της σε τρία και επεκτείνει μία κατηγορία προς τα εμπρός μέσω [ITrendline::set_Forward](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_forward/). Η γραμμή τάσης δύναμης επεκτείνεται μία κατηγορία προς τα πίσω μέσω [ITrendline::set_Backward](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_backward/).

```cpp
#include <system/shared_ptr.h>
#include <drawing/color.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ILineFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/ITrendline.h>
#include <DOM/Chart/ITrendlineCollection.h>
#include <DOM/Chart/TrendlineType.h>
#include <DOM/Chart/IFormat.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20, 20, 500, 400);

auto firstSeries = chart->get_ChartData()->get_Series()->idx_get(0);

auto exponentialTrendline = firstSeries->get_TrendLines()->Add(TrendlineType::Exponential);
exponentialTrendline->set_DisplayEquation(false);
exponentialTrendline->set_DisplayRSquaredValue(false);

auto linearTrendline = firstSeries->get_TrendLines()->Add(TrendlineType::Linear);
linearTrendline->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
linearTrendline->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

auto secondSeries = chart->get_ChartData()->get_Series()->idx_get(1);

auto logarithmicTrendline = secondSeries->get_TrendLines()->Add(TrendlineType::Logarithmic);
logarithmicTrendline->AddTextFrameForOverriding(u"New log trend line");

auto movingAverageTrendline = secondSeries->get_TrendLines()->Add(TrendlineType::MovingAverage);
movingAverageTrendline->set_Period(3);
movingAverageTrendline->set_TrendlineName(u"New TrendLine Name");

auto thirdSeries = chart->get_ChartData()->get_Series()->idx_get(2);

auto polynomialTrendline = thirdSeries->get_TrendLines()->Add(TrendlineType::Polynomial);
polynomialTrendline->set_Forward(1);
polynomialTrendline->set_Order(3);

auto powerTrendline = thirdSeries->get_TrendLines()->Add(TrendlineType::Power);
powerTrendline->set_Backward(1);

presentation->Save(u"ChartTrendLines.pptx", SaveFormat::Pptx);
```

## **Ορισμός Τομής Γραμμής Τάσης**

Χρησιμοποιήστε [ITrendline::set_Intercept](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_intercept/) για να καθορίσετε την τιμή Y μιας γραμμής τάσης στο X = 0. Αυτή η ρύθμιση υποστηρίζεται για γραμμικές, εκθετικές και πολυωνυμικές γραμμές τάσης.

Για παράδειγμα, ένα μοντέλο κόστους παραγωγής μπορεί να χρειάζεται να ξεκινά από γνωστά σταθερά κόστη 100, ακόμη και όταν οι μετρήσεις σε μη μηδενικούς όγκους παραγωγής υποδεικνύουν διαφορετικό βασικό επίπεδο. Για μια γραμμική γραμμή τάσης, η καθορισμένη τομή περιορίζει την εξίσωση `y = ax + b` στο `b = 100`; η κλίση προσαρμόζεται στα δεδομένα υπό αυτήν την περιοριστική συνθήκη. Δεν μετακινεί απλώς μια ήδη προσαρμοσμένη γραμμή. Οι ρυθμίσεις διασυνοριακής τομής ελέγχουν πού συναντώνται οι άξονες του διαγράμματος, όχι τους συντελεστές της προσαρμοσμένης γραμμής τάσης.

Το παρακάτω παράδειγμα δημιουργεί ένα διάγραμμα διασποράς (XY) με όγκους παραγωγής από 1 έως 4 και κόστη 170, 200, 230 και 260. Αποθηκεύει το διάγραμμα με την προεπιλεγμένη αυτόματη τομή, ορίζει την τομή στο 100 και αποθηκεύει ένα δεύτερο αρχείο PPTX. Τα δύο αρχεία διαφέρουν μόνο στη ρύθμιση της τομής. Η γραμμή τάσης εμφανίζει την εξίσωσή της και επεκτείνεται πίσω στο X = 0.

```cpp
#include <system/shared_ptr.h>
#include <system/object_ext.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/ITrendline.h>
#include <DOM/Chart/ITrendlineCollection.h>
#include <DOM/Chart/TrendlineType.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ScatterWithMarkers, 20, 20, 480, 210);
chart->set_HasLegend(false);

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto nameCell = workbook->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Production cost"));
auto series = chart->get_ChartData()->get_Series()->Add(nameCell, ChartType::ScatterWithMarkers);
const double costs[] = { 170, 200, 230, 260 };

for (auto i = 0; i < 4; i++)
{
    auto xCell = workbook->GetCell(0, i + 1, 0, ObjectExt::Box<int32_t>(i + 1));
    auto yCell = workbook->GetCell(0, i + 1, 1, ObjectExt::Box<double>(costs[i]));
    series->get_DataPoints()->AddDataPointForScatterSeries(xCell, yCell);
}

auto trendline = series->get_TrendLines()->Add(TrendlineType::Linear);
trendline->set_DisplayEquation(true);
trendline->set_Backward(1);

presentation->Save(u"AutomaticIntercept.pptx", SaveFormat::Pptx);

trendline->set_Intercept(100);
presentation->Save(u"FixedIntercept.pptx", SaveFormat::Pptx);
```

Με αυτόματο υπολογισμό, αυτά τα δεδομένα παράγουν `y = 30x + 140`. Ορίζοντας την τομή στο 100 αντίθετα παράγει περίπου `y = 43.33x + 100`: η προσαρμοσμένη τιμή στο μηδέν ταιριάζει με το γνωστό βασικό επίπεδο, ενώ η γραμμή δεν περνά πλέον από κάθε σημείο δεδομένων.

| Αυτόματη τομή | Σταθερή τομή 100 |
| --- | --- |
| ![Γραμμική γραμμή τάσης με αυτόματα υπολογισμένη τομή 140](intercept-automatic.png) | ![Γραμμική γραμμή τάσης με σταθερή τομή 100](intercept-fixed.png) |

Και οι δύο εικόνες χρησιμοποιούν τα ίδια δεδομένα και κλίμακες άξονα. Οι γραμμές τάσης επεκτείνονται πίσω στο X = 0 για να δείξουν τις τομές τους.

Από προεπιλογή, η ιδιότητα περιέχει `std::numeric_limits<double>::quiet_NaN()`, που αντιπροσωπεύει μια ακαθόριστη τομή αντί για μηδέν. Στη συνέχεια η τομή υπολογίζεται αυτόματα από τα δεδομένα.

## **Προσθήκη Προσαρμοσμένης Γραμμής**

Μια προσαρμοσμένη γραμμή είναι ένα σχήμα που σχεδιάζεται πάνω από το διάγραμμα αντί για μια γραμμή τάσης που υπολογίζεται από τα δεδομένα της σειράς. Αυτό το παράδειγμα χρησιμοποιεί [IShapeCollection::AddAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addautoshape/) για να προσθέσει μια οριζόντια γραμμή στη διαφάνεια πάνω από το διάγραμμα. Η θέση της γραμμής καθορίζεται σε συντεταγμένες διαφάνειας, μετρημένες σε μονάδες σημείου, έτσι ώστε να ξεκινά από την αριστερή άκρη του διαγράμματος και να βρίσκεται στη μέση του ύψους του. Το πλάτος της ταιριάζει με το πλάτος του διαγράμματος. Η μορφή γραμμής που επιστρέφεται από [IShape::get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/) δίνει στη γραμμή ένα συμπαγές κόκκινο χρώμα.

```cpp
#include <system/shared_ptr.h>
#include <drawing/color.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ShapeType.h>
#include <DOM/ILineFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100, 100, 500, 400);

auto line = slide->get_Shapes()->AddAutoShape(ShapeType::Line, chart->get_X(), chart->get_Y() + chart->get_Height() / 2, chart->get_Width(), 0);
line->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
line->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

presentation->Save(u"AddCustomLines.pptx", SaveFormat::Pptx);
```

## **Συχνές Ερωτήσεις**

**Τι σημαίνουν οι όροι 'προς τα εμπρός' και 'προς τα πίσω' για μια γραμμή τάσης;**

Αυτά είναι τα μήκη της γραμμής τάσης που προβάλλονται προς τα εμπρός/πίσω: για διαγράμματα διασποράς (XY) — σε μονάδες άξονα· για μη διαγράμματα διασποράς — σε αριθμό κατηγοριών. Επιτρέπονται μόνο μη αρνητικές τιμές.

**Θα διατηρηθεί η γραμμή τάσης κατά την εξαγωγή της παρουσίασης σε PDF ή SVG, ή κατά την απόδοση μιας διαφάνειας σε εικόνα;**

Ναι. Το Aspose.Slides μετατρέπει παρουσιάσεις σε [PDF](/slides/el/cpp/convert-powerpoint-to-pdf/) ή [SVG](/slides/el/cpp/render-a-slide-as-an-svg-image/) και αποδίδει διαγράμματα σε εικόνες· οι γραμμές τάσης, ως μέρος του διαγράμματος, διατηρούνται κατά αυτές τις λειτουργίες. Μια μέθοδος είναι επίσης διαθέσιμη για την [εξαγωγή εικόνας του διαγράμματος](/slides/el/cpp/shape-thumbnails/).