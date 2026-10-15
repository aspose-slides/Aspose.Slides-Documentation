---
title: Προσαρμογή αξόνων διαγραμμάτων σε παρουσιάσεις με C++
linktitle: Άξονας διαγράμματος
type: docs
url: /el/cpp/chart-axis/
keywords:
- άξονας διαγράμματος
- κατακόρυφος άξονας
- οριζόντιος άξονας
- προσαρμογή άξονα
- χειρισμός άξονα
- διαχείριση άξονα
- ιδιότητες άξονα
- μέγιστη τιμή
- ελάχιστη τιμή
- γραμμή άξονα
- μορφή ημερομηνίας
- τίτλος άξονα
- θέση άξονα
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Ανακαλύψτε πώς να χρησιμοποιήσετε το Aspose.Slides για C++ για να προσαρμόσετε τους άξονες διαγραμμάτων σε παρουσιάσεις PowerPoint για αναφορές και οπτικοποιήσεις."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσαρμόσετε τους άξονες γραφημάτων με το Aspose.Slides για C++. Καλύπτει τις υπολογισμένες τιμές άξονα, την εναλλαγή γραμμών και στηλών του διαγράμματος, την ορατότητα άξονα, τα διαστήματα ετικετών κατηγορίας και σημαδιών, τις ημερομηνίες κατηγοριών και τη μορφοποίηση, την περιστροφή τίτλου, τη θέση άξονα, τις μονάδες εμφάνισης και τη λογαριθμική κλιμάκωση.

## **Απόκτηση των μέγιστων τιμών στον κατακόρυφο άξονα σε γραφήματα**

Δημιουργήστε μια [Παρουσίαση](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) και προσθέστε ένα διαγράφημα περιοχής με προεπιλεγμένα δεδομένα. Καλείτε το [ValidateChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/validatechartlayout/) πριν διαβάσετε τις υπολογισμένες τιμές άξονα ώστε η διάταξη του διαγράμματος να είναι ενημερωμένη.

Διαβάστε τα [get_ActualMaxValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmaxvalue/) και [get_ActualMinValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminvalue/) για τα όρια του άξονα, και τα [get_ActualMajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmajorunit/) και [get_ActualMinorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminorunit/) για τα διαστήματα των σημείων. Τα [get_ActualMajorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmajorunitscale/) και [get_ActualMinorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminorunitscale/) παρέχουν κλίμακες μονάδων χρόνου, οι οποίες σχετίζονται με άξονες ημερομηνίας. Το παράδειγμα αποθηκεύει αυτές τις τιμές σε τοπικές μεταβλητές και αποθηκεύει το γράφημα.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Area, 100, 100, 500, 350);
chart->ValidateChartLayout();

auto maxValue = chart->get_Axes()->get_VerticalAxis()->get_ActualMaxValue();
auto minValue = chart->get_Axes()->get_VerticalAxis()->get_ActualMinValue();

auto majorUnit = chart->get_Axes()->get_VerticalAxis()->get_ActualMajorUnit();
auto minorUnit = chart->get_Axes()->get_VerticalAxis()->get_ActualMinorUnit();

auto majorUnitScale = chart->get_Axes()->get_VerticalAxis()->get_ActualMajorUnitScale();
auto minorUnitScale = chart->get_Axes()->get_VerticalAxis()->get_ActualMinorUnitScale();

presentation->Save(u"AxisValues_out.pptx", SaveFormat::Pptx);
```

## **Ανταλλαγή δεδομένων μεταξύ άξονων**

Χρησιμοποιήστε το [SwitchRowColumn](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/switchrowcolumn/) για να ανταλλάξετε τους ρόλους σειρών και κατηγοριών στα δεδομένα γραφήματος. Κάθε προηγούμενη κατηγορία γίνεται σειρά, και κάθε προηγούμενη σειρά γίνεται κατηγορία. Αυτό αλλάζει τον τρόπο ομαδοποίησης των δεδομένων· δεν ανταλλάσσει τους οριζόντιους και κατακόρυφους άξονες. Το παράδειγμα χρησιμοποιεί το [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/setrange/) για να δεσμεύσει τα προεπιλεγμένα δεδομένα στο `Sheet1!A1:D5`, συμπεριλαμβανομένης της γραμμής κεφαλίδας και της στήλης κατηγορίας, πριν την εναλλαγή γραμμών και στηλών. Αποθηκεύει ένα γράφημα με τέσσερις σειρές και τρεις κατηγορίες.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartData.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100, 100, 400, 300);

chart->get_ChartData()->SetRange(u"Sheet1!A1:D5");
chart->get_ChartData()->SwitchRowColumn();

presentation->Save(u"SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
```

## **Αντιστροφή της σειράς σχεδίασης ενός άξονα**

Χρησιμοποιήστε το [set_IsPlotOrderReversed](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isplotorderreversed/) για να αντιστρέψετε έναν άξονα κατηγορίας ή τιμών. Για παράδειγμα, ένα οριζόντιο γράφημα ράβδων μπορεί να δείχνει τα στάδια του έργου από πάνω προς τα κάτω με τη ίδια σειρά όπως το φύλλο εργασίας: Προγραμματισμός, Ανάπτυξη, Δοκιμές. Η αντιστροφή ενός άξονα αλλάζει την κατεύθυνση σχεδίασης· δεν ταξινομεί ή ανασυντάσσει τα δεδομένα του βιβλίου εργασίας. Σε σύγκριση, το [SwitchRowColumn](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/switchrowcolumn/) ανταλλάσσει τους ρόλους σειρών και κατηγοριών.

Το παρακάτω παράδειγμα δημιουργεί ένα οριζόντιο γράφημα ράβδων με τρία στάδια και μια σειρά. Αποθηκεύει μια παρουσίαση με τρεις διαφάνειες: κανονική σειρά, αντίστροφες κατηγορίες και αντίστροφες τιμές. Κάθε αντίγραφο χρησιμοποιεί το ίδιο σύνολο δεδομένων, και μόνο ένας άξονας αντιστρέφεται σε κάθε αντίγραφο.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/CrossesType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredBar, 50, 40, 620, 320);
chart->set_HasLegend(false);

chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::ClusteredBar);
auto stages = std::array<System::String, 3>{u"Planning", u"Development", u"Testing"};
auto values = std::array<int, 3>{10, 30, 20};
for (auto i = 0; i < stages.size(); i++)
{
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(stages[i]));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);
    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(values[i]));
    series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
}

// Slide 2: display the first category at the top.
auto categorySlide = presentation->get_Slides()->AddClone(slide);
auto categoryChart = System::ExplicitCast<IChart>(categorySlide->get_Shape(0));
categoryChart->get_Axes()->get_VerticalAxis()->set_IsPlotOrderReversed(true);
// Keep the horizontal value axis at the bottom.
categoryChart->get_Axes()->get_VerticalAxis()->set_CrossType(CrossesType::Maximum);

// Slide 3: reverse only the horizontal numeric scale.
auto valueSlide = presentation->get_Slides()->AddClone(slide);
auto valueChart = System::ExplicitCast<IChart>(valueSlide->get_Shape(0));
valueChart->get_Axes()->get_HorizontalAxis()->set_IsPlotOrderReversed(true);

presentation->Save(u"ReversedAxes.pptx", SaveFormat::Pptx);
```

Η αντιστροφή ενός άξονα μπορεί επίσης να μετακινήσει τον κάθετο άξονα στην αντίθετη πλευρά του διαγράμματος. Το [set_CrossType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crosstype/) ελέγχει πού ο άλλος άξονας διασχίζει τον άξονα που διαμορφώνεται. Στη διαφάνεια 2, ορίζοντάς το σε `Maximum` στον αντίστροφο άξονα κατηγορίας διατηρεί τον οριζόντιο άξονα τιμών στο κάτω μέρος. Για συγκεκριμένο σημείο διασταύρωσης, χρησιμοποιήστε το [set_CrossAt](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crossat/). Ελέγξτε τις ρυθμίσεις διασταύρωσης όταν αλλάζετε κατεύθυνση, ιδιαίτερα εάν το γράφημα έχει ήδη προσαρμοσμένο σημείο διασταύρωσης. Καλέστε `set_IsPlotOrderReversed` με `false` για επαναφορά της κανονικής κατεύθυνσης σχεδίασης· οι ρυθμίσεις διασταύρωσης είναι ξεχωριστές.

| Κανονική σειρά (διαφάνεια 1) | Αντεστραμμένες κατηγορίες (διαφάνεια 2) | Αντεστραμμένες τιμές (διαφάνεια 3) |
| --- | --- | --- |
| ![Γραμμικό γράφημα ράβδων με κανονική σειρά κατηγορίας και άξονα τιμών](axis-order-normal.png) | ![Γραμμικό γράφημα ράβδων με κατηγορίες εμφανιζόμενες από πάνω προς τα κάτω](axis-order-categories-reversed.png) | ![Γραμμικό γράφημα ράβδων με αντεστραμμένο άξονα τιμών και μηδέν στα δεξιά](axis-order-values-reversed.png) |
| Οι κατηγορίες τρέχουν από κάτω προς πάνω· οι τιμές αυξάνονται από αριστερά προς δεξιά. | Προγραμματισμός, Ανάπτυξη και Δοκιμές τρέχουν από πάνω προς τα κάτω. Οι τιμές και η σειρά γραμμών του βιβλίου εργασίας παραμένουν αμετάβλητες. | Οι κατηγορίες διατηρούν τη φυσική τους σειρά· οι τιμές αυξάνονται από δεξιά προς αριστερά. Ο άξονας κατηγορίας διασχίζει στο μηδέν στα δεξιά. |

## **Απενεργοποίηση του κατακόρυφου άξονα για διαγράμματα γραμμής**

Χρησιμοποιήστε το [set_IsVisible](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isvisible/) με `false` στον κατακόρυφο άξονα για να τον κρύψετε. Το παράδειγμα δημιουργεί ένα γράφημα γραμμής με προεπιλεγμένα δεδομένα και το αποθηκεύει με κρυμμένο τον κατακόρυφο άξονα.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 100, 100, 400, 300);
chart->get_Axes()->get_VerticalAxis()->set_IsVisible(false);

presentation->Save(u"HiddenVerticalAxis.pptx", SaveFormat::Pptx);
```

## **Απενεργοποίηση του οριζόντιου άξονα για διαγράμματα γραμμής**

Χρησιμοποιήστε το [set_IsVisible](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isvisible/) με `false` στον οριζόντιο άξονα για να τον κρύψετε. Το παράδειγμα δημιουργεί ένα γράφημα γραμμής με προεπιλεγμένα δεδομένα και το αποθηκεύει με κρυμμένο τον οριζόντιο άξονα.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 100, 100, 400, 300);
chart->get_Axes()->get_HorizontalAxis()->set_IsVisible(false);

presentation->Save(u"HiddenHorizontalAxis.pptx", SaveFormat::Pptx);
```

## **Αλλαγή άξονα κατηγορίας**

Χρησιμοποιήστε το [set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_categoryaxistype/) για να επιλέξετε άξονα ημερομηνίας ή κειμένου. Αυτό το παράδειγμα απαιτεί το `ExistingChart.pptx`, με ένα γράφημα ως πρώτο σχήμα στη πρώτη διαφάνεια και κελιά κατηγορίας που περιέχουν αριθμητικές τιμές ημερομηνίας Excel. Αλλάζει τον οριζόντιο άξονα σε άξονα ημερομηνίας. Καλώντας το [set_IsAutomaticMajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isautomaticmajorunit/) με `false`, το [set_MajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majorunit/) με `1` και το [set_MajorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majorunitscale/) με μήνες τοποθετεί τα κύρια σημεία σε διαστήματα ενός μήνα.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/CategoryAxisType.h>
#include <DOM/Chart/TimeUnitType.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"ExistingChart.pptx");
auto slide = presentation->get_Slide(0);

auto chart = System::ExplicitCast<IChart>(slide->get_Shape(0));
chart->get_Axes()->get_HorizontalAxis()->set_CategoryAxisType(CategoryAxisType::Date);
chart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticMajorUnit(false);
chart->get_Axes()->get_HorizontalAxis()->set_MajorUnit(1);
chart->get_Axes()->get_HorizontalAxis()->set_MajorUnitScale(TimeUnitType::Months);

presentation->Save(u"ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
```

## **Έλεγχος διαστημάτων ετικετών άξονα κατηγορίας**

Όταν ένα γράφημα έχει πολλές κατηγορίες, μειώστε τον αριθμό των ορατών ετικετών άξονα χωρίς να αφαιρέσετε κατηγορίες ή σημεία δεδομένων. Χρησιμοποιήστε το [set_IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomaticticklabelspacing/) με `false`, στη συνέχεια το [set_TickLabelSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_ticklabelspacing/) με το επιθυμητό διάστημα κατηγορίας. Για κειμενικές κατηγορίες στη φυσική τους σειρά, η μέτρηση ξεκινά από την πρώτη κατηγορία:

| Διάστημα | Ετικέτες που εμφανίζονται στο παράδειγμα |
| --- | --- |
| `1` | Κατηγορία 1, Κατηγορία 2, Κατηγορία 3, … Κατηγορία 24 |
| `2` | Κατηγορία 1, Κατηγορία 3, Κατηγορία 5, … Κατηγορία 23 |
| `3` | Κατηγορία 1, Κατηγορία 4, Κατηγορία 7, … Κατηγορία 22 |

Διάστημα `3` εμφανίζει κάθε τρίτη ετικέτα, αφήνοντας δύο ετικέτες κρυμμένες μεταξύ των εμφανιζόμενων. Δεν αφαιρεί τις αντίστοιχες στήλες. Η αυτόματη διάστιξη επιλέγει διάστημα βάση του διαθέσιμου χώρου· δεν εμφανίζει υποχρεωτικά κάθε ετικέτα.

Τα σημεία διαίρεσης έχουν ξεχωριστό έλεγχο. Χρησιμοποιήστε το [set_IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomatictickmarksspacing/) με `false` και το [set_TickMarksSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_tickmarksspacing/) για να ορίσετε το διάστημα τους. Για παράδειγμα, το `1` διατηρεί σημείο διαίρεσης σε κάθε διάστημα κατηγορίας ενώ οι ετικέτες εμφανίζονται μόνο κάθε τρίτη κατηγορία. Χρησιμοποιήστε το [set_MajorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_majortickmark/) με ένα ορατό στυλ ώστε να δείτε το αποτέλεσμα. Επαναφέροντας τις ιδιότητες αυτόματης διάστιξης σε `true` αφήνετε το γράφημα να επιλέξει ξανά το διάστημα.

Το παρακάτω αυτόνομα παράδειγμα δημιουργεί 24 κατηγορίες και μια σειρά, έπειτα αποθηκεύει τρεις διαφάνειες στο `CategoryAxisIntervals.pptx`: αυτόματη διάστιξη, χειροκίνητη διάστιξη ετικετών με ανεξάρτητα σημεία διαίρεσης, και επαναφορά της αυτόματης διάστιξης. Τα δύο αντίγραφα διατηρούν τα αρχικά δεδομένα του γραφήματος. Δεν απαιτείται εισαγωγική παρουσίαση. Το οριζόντιο κείμενο ετικέτας δείχνει τη διαφορά στην πυκνότητα.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/CategoryAxisType.h>
#include <DOM/Chart/TickMarkType.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IChartTextBlockFormat.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <system/object_ext.h>
#include <DOM/ISlideCollection.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 30, 40, 660, 320);

chart->set_HasLegend(false);
chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::ClusteredColumn);
for (auto i = 0; i < 24; i++)
{
    auto categoryName = System::String::Format(u"Category {0}", i + 1);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(categoryName));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);
    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(10 + i % 6 * 5));
    series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
}

auto axis = chart->get_Axes()->get_HorizontalAxis();
axis->set_CategoryAxisType(CategoryAxisType::Text);
axis->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(0);
axis->get_TextFormat()->get_PortionFormat()->set_FontHeight(12);
axis->set_MajorTickMark(TickMarkType::Outside);
axis->set_IsAutomaticTickLabelSpacing(true);
axis->set_IsAutomaticTickMarksSpacing(true);

// Slide 2: show every third label, but keep a tick mark for every category.
auto manualSlide = presentation->get_Slides()->AddClone(slide);
auto manualChart = System::ExplicitCast<IChart>(manualSlide->get_Shape(0));
auto manualAxis = manualChart->get_Axes()->get_HorizontalAxis();
manualAxis->set_IsAutomaticTickLabelSpacing(false);
manualAxis->set_TickLabelSpacing(3);
manualAxis->set_IsAutomaticTickMarksSpacing(false);
manualAxis->set_TickMarksSpacing(1);

// Slide 3: let the chart choose both intervals again.
auto restoredSlide = presentation->get_Slides()->AddClone(manualSlide);
auto restoredChart = System::ExplicitCast<IChart>(restoredSlide->get_Shape(0));
restoredChart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticTickLabelSpacing(true);
restoredChart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticTickMarksSpacing(true);

presentation->Save(u"CategoryAxisIntervals.pptx", SaveFormat::Pptx);
```

**Αυτόματη διάστιξη (διαφάνεια 1):** Σε αυτήν την απόδοση, εμφανίζεται κάθε δεύτερη ετικέτα κατηγορίας και η γραμμή τυλίγεται σε δύο γραμμές. Το αυτόματο αποτέλεσμα μπορεί να διαφέρει ανάλογα με το μέγεθος του γραφήματος, τις γραμματοσειρές και τον render.

![Αυτόματη διάστιξη ετικετών κατηγορίας με όλες τις 24 στήλες ορατές](category-axis-automatic.png)

**Χειροκίνητη διάστιξη (διαφάνεια 2):** Εμφανίζεται κάθε τρίτη ετικέτα σε μία γραμμή, ενώ τα σημεία διαίρεσης παραμένουν σε κάθε διάστημα κατηγορίας. Όλες οι 24 στήλες, συμπεριλαμβανομένων εκείνων χωρίς ετικέτες, παραμένουν ορατές με τις ίδιες τιμές. Η διαφάνεια 3 επαναφέρει την αυτόματη εμφάνιση που φαίνεται παραπάνω.

![Χειροκίνητο διάστημα ετικετών κατηγορίας τριών με όλες τις 24 στήλες ορατές](category-axis-manual.png)

### **Επιλογή του σωστού άξονα και διαστήματος**

Χρησιμοποιήστε αυτό το διάστημα καταμέτρησης κατηγοριών για άξονα κατηγορίας κειμένου, όπως ο άξονας κατηγορίας σε γράφημα στήλης, γραμμής, περιοχής ή ράβδων. Σε γράφημα στήλης, είναι ο οριζόντιος άξονας. Σε γράφημα οριζόντιων ράβδων, ο άξονας κατηγορίας είναι κατακόρυφος, οπότε εφαρμόστε αυτές τις ρυθμίσεις στο [get_VerticalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_verticalaxis/). Η διάστιξη σημείων διαίρεσης ισχύει επίσης για άξονα σειράς σε γραφήματα που έχουν έναν.

Μην χρησιμοποιείτε τη διάστιξη ετικετών κατηγορίας για να ορίσετε την αριθμητική κλίμακα ενός άξονα τιμών. Σε άξονα τιμών, το [set_MajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_majorunit/) ορίζει διαφορά τιμών: π.χ., μονάδα `10` δημιουργεί σημεία στα 0, 10, 20 κ.λπ. όταν ο άξονας αρχίζει από το μηδέν. Διάστημα ετικέτας κατηγορίας `3` μετρά τις θέσεις κατηγορίας ανεξάρτητα από τις τιμές δεδομένων. Τα γραφήματα scatter και bubble χρησιμοποιούν άξονες τιμών αντί για άξονα κειμενικής κατηγορίας. Για άξονα ημερομηνίας, χρησιμοποιήστε μονάδες χρόνου όπως περιγράφεται στην ενότητα [Αλλαγή άξονα κατηγορίας](#αλλαγή-άξονα-κατηγορίας).

## **Ορισμός μορφής ημερομηνίας για τιμές άξονα κατηγορίας**

Το παράδειγμα αντικαθιστά τα προεπιλεγμένα δεδομένα γραφήματος με τέσσερις ετήσιες τιμές. Οι ημερομηνίες αποθηκεύονται ως σειριακοί αριθμοί OLE Automation στο πρώτο φύλλο (δείκτης `0`). Χρησιμοποιήστε το [set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_categoryaxistype/) για να επιλέξετε άξονα ημερομηνίας, απενεργοποιήστε τη μορφοποίηση συνδεδεμένη με την πηγή με το [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isnumberformatlinkedtosource/), και ορίστε `yyyy` με το [set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_numberformat/) ώστε οι ετικέτες κατηγορίας να εμφανίζουν τέσσερα ψηφία έτους ανεξάρτητα από τη μορφοποίηση κελιού.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/CategoryAxisType.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <system/object_ext.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 50, 50, 450, 300);

chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::Line);
for (auto i = 0; i < 4; i++)
{
    auto date = System::DateTime(2015 + i, 1, 1);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(date.ToOADate()));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);

    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(i + 1));
    series->get_DataPoints()->AddDataPointForLineSeries(valueCell);
}

chart->get_Axes()->get_HorizontalAxis()->set_CategoryAxisType(CategoryAxisType::Date);
chart->get_Axes()->get_HorizontalAxis()->set_IsNumberFormatLinkedToSource(false);
chart->get_Axes()->get_HorizontalAxis()->set_NumberFormat(u"yyyy");

presentation->Save(u"DateAxisFormat.pptx", SaveFormat::Pptx);
```

## **Ορισμός γωνίας περιστροφής για τίτλο άξονα γραφήματος**

Ενεργοποιήστε τον τίτλο του κατακόρυφου άξονα με το [set_HasTitle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_hastitle/), δώστε κείμενο τίτλου και χρησιμοποιήστε το [set_RotationAngle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/icharttextblockformat/set_rotationangle/) για να περιστρέψετε τον τίτλο. Η γωνία μετράται σε μοίρες· αυτό το παράδειγμα αποθηκεύει ένα γράφημα στήλης με τον τίτλο του άξονα τιμών περιστραμμένο κατά 90 μοίρες.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IChartTextBlockFormat.h>
#include <DOM/Chart/IChartTitle.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
chart->get_Axes()->get_VerticalAxis()->set_HasTitle(true);
chart->get_Axes()->get_VerticalAxis()->get_Title()->AddTextFrameForOverriding(u"Value");
chart->get_Axes()->get_VerticalAxis()->get_Title()->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(90);

presentation->Save(u"RotatedAxisTitle.pptx", SaveFormat::Pptx);
```

## **Ορισμός θέσης άξονα σε άξονα κατηγορίας ή τιμών**

Χρησιμοποιήστε το [set_AxisBetweenCategories](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_axisbetweencategories/) για να ελέγξετε αν ο άξονας τιμών διασχίζει τον άξονα κατηγορίας μεταξύ των κατηγοριών ή στα σημεία διαίρεσης κατηγορίας. Αυτή η ιδιότητα ισχύει για άξονες κατηγορίας. Το παράδειγμα το ορίζει σε `true` στον οριζόντιο άξονα κατηγορίας ενός γραφήματος στήλης και αποθηκεύει το αποτέλεσμα.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
chart->get_Axes()->get_HorizontalAxis()->set_AxisBetweenCategories(true);

presentation->Save(u"AxisBetweenCategories.pptx", SaveFormat::Pptx);
```

## **Ορισμός μονάδας εμφάνισης σε άξονα τιμών γραφήματος**

Χρησιμοποιήστε το [set_DisplayUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_displayunit/) για να κλιμακώσετε τις ετικέτες σε άξονα τιμών χωρίς να αλλάξετε τα υποκείμενα δεδομένα. Με το [DisplayUnitType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/displayunittype/) ορισμένο σε `Millions`, μια τιμή των 60 000 000 εμφανίζεται ως 60. Το παράδειγμα δημιουργεί ένα γράφημα στήλης και εφαρμόζει τη μονάδα εμφάνισης εκατομμυρίων στον κατακόρυφο άξονά του.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/DisplayUnitType.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
chart->get_Axes()->get_VerticalAxis()->set_DisplayUnit(DisplayUnitType::Millions);

presentation->Save(u"Result.pptx", SaveFormat::Pptx);
```

## **Διαμόρφωση λογαριθμικού άξονα τιμών**

Ένας λογαριθμικός άξονας τιμών είναι χρήσιμος όταν οι θετικές τιμές καλύπτουν πολλαπλά επίπεδα μεγέθους. Για παράδειγμα, μια υπηρεσία μπορεί να λαμβάνει 10, 100, 1 000, 10 000 και 100 000 αιτήματα σε πέντε περιόδους. Σε γραμμική κλίμακα, οι μικρότερες τιμές εμφανίζονται κοντά μεταξύ τους κοντά στο μηδέν. Μια λογαριθμική κλίμακα κάνει την σχετική ανάπτυξή τους πιο εύκολη στη σύγκριση: ίσες αποστάσεις αντιπροσωπεύουν ίσες αναλογίες αντί για ίσες διαφορές.

Καλέστε το [set_IsLogarithmic](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_islogarithmic/) με `true` στον άξονα τιμών και χρησιμοποιήστε το [set_LogBase](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_logbase/) για να επιλέξετε τη βάση. Αυτό αλλάζει τον τρόπο εμφάνισης των υπαρχουσών τιμών· δεν αλλάζει τα δεδομένα ή προσθέτει λογαριθμική γραμμή τάσης. Μία γραμμή τάσης αντιπροσωπεύει μια προσαρμοσμένη σχέση στα δεδομένα και είναι ξεχωριστή λειτουργία.

### **Επιλογή άξονα τιμών και βάσης**

Για γράφημα γραμμής ή στήλης, ο άξονας τιμών είναι το [get_VerticalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_verticalaxis/). Για γράφημα οριζόντιων ράβδων, είναι το [get_HorizontalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_horizontalaxis/). Τα γραφήματα scatter και bubble έχουν δύο άξονες τιμών, οπότε επιλέξτε τον οριζόντιο άξονα για τις τιμές X, τον κατακόρυφο για τις τιμές Y ή και τους δύο. Μην εφαρμόζετε λογαριθμική κλιμάκωση σε άξονα κατηγορίας.

Η προεπιλεγμένη λογαριθμική βάση είναι `10`. Για γραφήματα PPTX, χρησιμοποιήστε βάση από `2` έως `1000`, συμπεριλαμβανομένων· υποστηρίζονται και κλασματικές βάσεις όπως `2.5`. Με βάση `10`, διαδοχικές δυνάμεις όπως 10, 100, 1 000 και 10 000 είναι ίσια διατεταγμένες.

### **Σύγκριση γραμμικής και λογαριθμικής κλιμάκωσης**

Το παρακάτω αυτόνομα παράδειγμα δημιουργεί ένα γράφημα γραμμής με τις πέντε μετρήσεις αιτημάτων στη πρώτη διαφάνεια, έπειτα κλωνοποιεί τη διαφάνεια και ενεργοποιεί λογαριθμικό άξονα τιμών βάσης 10 στη δεύτερη. Και οι δύο διαφάνειες διατηρούν τα ίδια δεδομένα.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 30, 40, 660, 200);

chart->set_HasLegend(false);

chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::Line);
auto values = std::array<double, 5>{10, 100, 1000, 10000, 100000};

for (auto i = 0; i < values.size(); i++)
{
    auto categoryName = System::String::Format(u"Period {0}", i + 1);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(categoryName));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);

    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(values[i]));
    series->get_DataPoints()->AddDataPointForLineSeries(valueCell);
}

// Keep the first slide linear and change only the copy's value-axis scale.
auto logarithmicSlide = presentation->get_Slides()->AddClone(slide);
auto logarithmicChart = System::ExplicitCast<IChart>(logarithmicSlide->get_Shape(0));
auto valueAxis = logarithmicChart->get_Axes()->get_VerticalAxis();
valueAxis->set_IsLogarithmic(true);
valueAxis->set_LogBase(10);

presentation->Save(u"LogarithmicAxis.pptx", SaveFormat::Pptx);
```

**Γραμμική κλίμακα (διαφάνεια 1):** Ίσες κατακόρυφες αποστάσεις αντιπροσωπεύουν ίσες διαφορές στις μετρήσεις αιτημάτων. Η μεγαλύτερη τιμή κυριαρχεί στο γράφημα, καθιστώντας τις μικρότερες δύσκολες στην ανάλυση.

![Γράφημα γραμμής στο PowerPoint που δείχνει πέντε μετρήσεις αιτημάτων σε γραμμικό άξονα τιμών](value-axis-linear.png)

**Λογαριθμική κλίμακα (διαφάνεια 2):** Ίσες κατακόρυφες αποστάσεις αντιπροσωπεύουν ίσες αναλογίες. Κάθε περίοδος έχει δέκα φορές περισσότερα αιτήματα από την προηγούμενη, οπότε τα σημεία σχηματίζουν μια ευθεία ανοδική γραμμή στη βάση 10. Οι ετικέτες άξονα εξακολουθούν να δείχνουν τις αρχικές μετρήσεις αιτημάτων.

![Οι ίδιες πέντε μετρήσεις αιτημάτων στο PowerPoint σε λογαριθμικό άξονα τιμών βάσης 10](value-axis-logarithmic.png)

### **Διαχείριση μηδενικών και αρνητικών τιμών**

Μια λογαριθμική κλίμακα μπορεί να εμφανίσει μόνο αυστηρά θετικές τιμές. Ελέγξτε τα δεδομένα πριν την ενεργοποιήσετε. Εάν μηδενικές ή αρνητικές τιμές έχουν νόημα, διατηρήστε γραμμική κλίμακα ή εμφανίστε τις ξεχωριστά. Εάν η εξαίρεση αυτών των τιμών είναι κατάλληλη για την ανάλυση, εξηγήστε την απουσία. Μην τις αντικαθιστάτε κρυφά με μικρές θετικές τιμές, καθώς αυτό αλλάζει το νόημα των δεδομένων. Οποιαδήποτε χειροκίνητη ελάχιστη ή μέγιστη τιμή για λογαριθμικό άξονα πρέπει επίσης να είναι θετική.

## **Συχνές ερωτήσεις**

**Πώς ορίζω την τιμή στην οποία ένας άξονας διασχίζει τον άλλο (διασταύρωση άξονα);**

Χρησιμοποιήστε το [set_CrossType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crosstype/) για να επιλέξετε τη συμπεριφορά διασταύρωσης. Για να ορίσετε αριθμητική τιμή διασταύρωσης, χρησιμοποιήστε το [set_CrossAt](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crossat/). Αυτές οι ρυθμίσεις σας επιτρέπουν να μετακινήσετε τη διασταύρωση του άξονα σε ένα κατάλληλο επίπεδο.

**Πώς μπορώ να τοποθετήσω τις ετικέτες σημεία διαίρεσης σε σχέση με τον άξονα;**

Χρησιμοποιήστε το [set_TickLabelPosition](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_ticklabelposition/) με τιμή από το [TickLabelPositionType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ticklabelpositiontype/): `Low`, `High`, `NextTo` ή `None`. Για έλεγχο των σημείων διαίρεσης, χρησιμοποιήστε το [set_MajorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majortickmark/) ή το [set_MinorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_minortickmark/); αυτά είναι ξεχωριστά από τη θέση των ετικετών.