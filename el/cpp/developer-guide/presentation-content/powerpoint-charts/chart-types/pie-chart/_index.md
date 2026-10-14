---
title: Προσαρμογή διαγραμμάτων πίτας σε παρουσιάσεις χρησιμοποιώντας C++
linktitle: Διάγραμμα Πίτας
type: docs
url: /el/cpp/pie-chart/
keywords:
- διάγραμμα πίτας
- διαχείριση διαγράμματος
- προσαρμογή διαγράμματος
- επιλογές διαγράμματος
- ρυθμίσεις διαγράμματος
- επιλογές σχεδίασης
- χρώμα φέτας
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Δημιουργήστε και προσαρμόστε διαγράμματα πίτας σε C++ με Aspose.Slides. Διαμορφώστε δευτερεύοντα υπόσχημα, εμφανίστε ετικέτες δεδομένων και εφαρμόστε αυτόματα χρώματα φετών σε PowerPoint."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργαστείτε με διαγράμματα πίτας στο Aspose.Slides. Δείχνει πώς να ρυθμίσετε τις επιλογές δευτερεύοντος υπόσχηματος για διαγράμματα Pie of Pie και Bar of Pie, καθώς και πώς να ενεργοποιήσετε την αυτόματη χρωματιστική των φέτες για ένα τυπικό διάγραμμα πίτας.

Τα παραδείγματα εστιάζουν σε εργασίες προσαρμογής διαγραμμάτων, όπως η προσθήκη διαγράμματος σε μια διαφάνεια, η προσαρμογή ρυθμίσεων σειράς και ετικέτας, η αντικατάσταση των προεπιλεγμένων δεδομένων του διαγράμματος με προσαρμοσμένες κατηγορίες και τιμές, και η αποθήκευση της ενημερωμένης παρουσίασης.

## **Επιλογές Δευτερεύοντος Υπόσχηματος για Διαγράμματα Pie of Pie και Bar of Pie**

Το Aspose.Slides for C++ υποστηρίζει επιλογές δευτερεύοντος υπόσχηματος για διαγράμματα Pie of Pie και Bar of Pie. Αυτές οι επιλογές ελέγχουν το μέγεθος του δευτερεύοντος υπόσχηματος και τον τρόπο με τον οποίο τα σημεία δεδομένων διαιρούνται μεταξύ των δύο υποσχημάτων.

Το παρακάτω παράδειγμα δημιουργεί ένα διάγραμμα Pie of Pie σε μια νέα παρουσίαση και εμφανίζει τις τιμές των σημείων δεδομένων ως ετικέτες. Η μέθοδος [set_SecondPieSize](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_secondpiesize/) ορίζει το μέγεθος του δευτερεύοντος υπόσχηματος στο 149 % του κύριου υπόσχηματος. Η [set_PieSplitBy](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_piesplitby/) επιλέγει διαίρεση βάσει ποσοστού, και η [set_PieSplitPosition](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_piesplitposition/) ορίζει το όριο στο 53 %.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/PieSplitType.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::PieOfPie, 50, 50, 500, 400);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

// Display values and configure the secondary plot.
series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
auto seriesGroup = series->get_ParentSeriesGroup();
seriesGroup->set_SecondPieSize(149);
seriesGroup->set_PieSplitBy(PieSplitType::ByPercentage);
seriesGroup->set_PieSplitPosition(53);

presentation->Save(u"pie_of_pie.pptx", SaveFormat::Pptx);
```

### **Επιλογή Κατηγοριών για το Δευτερεύον Υπόσχημα**

Χρησιμοποιήστε προσαρμοσμένη διαίρεση όταν θέλετε να ομαδοποιήσετε συγκεκριμένες κατηγορίες στο δευτερεύον υπόσχημα ανεξάρτητα από τις τιμές ποσοστού τους. Για παράδειγμα, ένα αναλυτικό πωλήσεων μπορεί να παρουσιάσει τις Online και Events μαζί ώστε οι αναγνώστες να μπορούν να συγκρίνουν αυτά τα δύο κανάλια, παρόλο που αντιπροσωπεύουν το 35 % και το 10 % του συνολικού τζίρου.

Καλέστε τη [set_PieSplitBy](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartseriesgroup/set_piesplitby/) με το [PieSplitType::Custom](https://reference.aspose.com/slides/cpp/aspose.slides.charts/piesplittype/) και επιλέξτε τα σημεία μέσω της [get_PieSplitCustomPoints](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartseriesgroup/get_piesplitcustompoints/). Η μέθοδος [Add](https://reference.aspose.com/slides/cpp/aspose.slides.charts/piesplitcustompointcollection/add/) της συλλογής δέχεται έναν μηδενικό δείκτη στη σειρά. Σε αυτό το παράδειγμα, ο δείκτης 1 επιλέγει Online και ο δείκτης 3 επιλέγει Events. Η Partners προστίθεται επίσης προσωρινά, στη συνέχεια αποκλείεται με τη [Remove](https://reference.aspose.com/slides/cpp/aspose.slides.charts/piesplitcustompointcollection/remove/).

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/PieSplitType.h>
#include <vector>
#include <system/object_ext.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IPieSplitCustomPointCollection.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::PieOfPie, 50, 50, 600, 200);

// Αντικαταστήστε τα προεπιλεγμένα δεδομένα με πωλήσεις ανά κανάλι.
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();
auto categoryNames = std::vector<System::String>{ u"Retail", u"Online", u"Partners", u"Events" };
auto values = std::vector<int>{ 40, 35, 15, 10 };
auto seriesNameCell = workbook->GetCell(0, 0, 1, System::ObjectExt::Box(System::String(u"Sales")));
auto series = chart->get_ChartData()->get_Series()->Add(seriesNameCell, chart->get_Type());

for (auto i = 0; i < static_cast<int>(categoryNames.size()); i++)
{
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(categoryNames[i]));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);

    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(values[i]));
    series->get_DataPoints()->AddDataPointForPieSeries(valueCell);
}

series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
auto seriesGroup = series->get_ParentSeriesGroup();
seriesGroup->set_PieSplitBy(PieSplitType::Custom);
seriesGroup->set_IsColorVaried(true);

// Επιλέξτε Online και Events με τους μηδενικούς δείκτες τους στη σειρά.
seriesGroup->get_PieSplitCustomPoints()->Add(1);
seriesGroup->get_PieSplitCustomPoints()->Add(3);

// Αποκλείστε το Partners από την επιλογή χωρίς διαγραφή των πηγαίων δεδομένων.
seriesGroup->get_PieSplitCustomPoints()->Add(2);
seriesGroup->get_PieSplitCustomPoints()->Remove(2);

presentation->Save(u"pie_of_pie_custom.pptx", SaveFormat::Pptx);
```

Online (35) και Events (10) εμφανίζονται ως ξεχωριστές φέτες στο δευτερεύον υπόσχημα. Στο κύριο υπόσχημα, αντιπροσωπεύονται από μία συνδυαστική φέτα με τιμή 45, μαζί με Retail (40) και Partners (15). Η αφαίρεση της Partners από την προσαρμοσμένη επιλογή τη διατηρεί στο κύριο υπόσχημα· δεν αφαιρεί την κατηγορία ή την τιμή της από τα πηγαία δεδομένα του διαγράμματος.

Η παρακάτω εικόνα εμφανίζει την αποθηκευμένη παρουσίαση στο PowerPoint:

![Διάγραμμα Pie of Pie με Online και Events στο δευτερεύον υπόσχημα και τη συνδυαστική τους τιμή 45 στο κύριο υπόσχημα](pie_of_pie_custom.png)

## **Ορισμός Αυτόματων Χρωμάτων Φετών σε Διάγραμμα Πίτας**

Το Aspose.Slides for C++ μπορεί να εκχωρήσει αυτόματα διαφορετικά χρώματα στις φέτες του διαγράμματος πίτας. Το παρακάτω παράδειγμα δημιουργεί ένα διάγραμμα πίτας με κεντραρισμένο τίτλο και αντικαθιστά τα προεπιλεγμένα δεδομένα με τρεις τριμηνιαίες κατηγορίες και τις τιμές τους. Η μέθοδος [set_ShowValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_showvalue/) εμφανίζει τις τιμές 20, 50 και 30 ως ετικέτες, ενώ η [set_IsColorVaried](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_iscolorvaried/) ενεργοποιεί διαφορετικό χρώμα για κάθε φέτα.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <Export/SaveFormat.h>
#include <vector>
#include <system/object_ext.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartTitle.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/NullableBool.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 100, 100, 400, 400);

// Προσθέστε έναν κεντραρισμένο τίτλο διαγράμματος.
chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sample Title");
chart->get_ChartTitle()->get_TextFrameForOverriding()->get_TextFrameFormat()->set_CenterText(NullableBool::True);
chart->get_ChartTitle()->set_Height(20);
chart->set_HasTitle(true);

// Αντικαταστήστε τα προεπιλεγμένα δεδομένα χρησιμοποιώντας το πρώτο φύλλο εργασίας.
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheetIndex = 0;
chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();
auto categoryNames = std::vector<System::String>{ u"First Qtr", u"2nd Qtr", u"3rd Qtr" };
auto values = std::vector<int>{ 20, 50, 30 };
auto seriesNameCell = workbook->GetCell(worksheetIndex, 0, 1, System::ObjectExt::Box(System::String(u"Series 1")));
auto series = chart->get_ChartData()->get_Series()->Add(seriesNameCell, chart->get_Type());

for (auto i = 0; i < static_cast<int>(categoryNames.size()); i++)
{
    auto categoryCell = workbook->GetCell(worksheetIndex, i + 1, 0, System::ObjectExt::Box(categoryNames[i]));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);

    auto valueCell = workbook->GetCell(worksheetIndex, i + 1, 1, System::ObjectExt::Box(values[i]));
    series->get_DataPoints()->AddDataPointForPieSeries(valueCell);
}

// Εμφανίστε τις τιμές και αντιστοιχίστε διαφορετικά χρώματα στις φέτες.
series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
series->get_ParentSeriesGroup()->set_IsColorVaried(true);

presentation->Save(u"pie.pptx", SaveFormat::Pptx);
```

## **Συχνές Ερωτήσεις**

** Υποστηρίζονται οι παραλλαγές Pie of Pie και Bar of Pie ; **

Ναι, η βιβλιοθήκη [supports](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) ένα δευτερεύον υπόσχημα για διαγράμματα πίτας, συμπεριλαμβανομένων των τύπων Pie of Pie και Bar of Pie.

** Μπορώ να εξάγω μόνο το διάγραμμα ως εικόνα (π.χ., PNG); **

Ναι, μπορείτε να [export the chart itself as an image](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/) (όπως PNG) χωρίς να εξάγετε ολόκληρη την παρουσίαση.