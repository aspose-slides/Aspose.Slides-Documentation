---
title: Διαχείριση ετικετών δεδομένων διαγράμματος σε παρουσιάσεις χρησιμοποιώντας C++
linktitle: Ετικέτα δεδομένων
type: docs
url: /el/cpp/chart-data-label/
keywords:
- διάγραμμα
- ετικέτα δεδομένων
- ακρίβεια δεδομένων
- ποσοστό
- απόσταση ετικέτας
- θέση ετικέτας
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε και να μορφοποιείτε ετικέτες δεδομένων διαγράμματος σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides για C++ ώστε οι διαφάνειες να είναι πιο ελκυστικές."
---
## **Εισαγωγή**

Οι ετικέτες δεδομένων εμφανίζουν πληροφορίες σχετικά με τις σειρές του διαγράμματος και μεμονωμένα σημεία δεδομένων, βοηθώντας τους αναγνώστες να αναγνωρίζουν τις τιμές και να κατανοούν το διάγραμμα. Αυτό το άρθρο εξηγεί πώς να μορφοποιήσετε τιμές, να εμφανίσετε ποσοστά, να διαβάσετε το κείμενο της ετικέτας, να ελέγξετε τις ετικέτες πέραν του μέγιστου αξόνων, να προσαρμόσετε το διάκενο ετικετών του άξονα κατηγορίας και να τοποθετήσετε ετικέτες σε πίτα.

## **Ορισμός ακρίβειας δεδομένων στις ετικέτες δεδομένων διαγράμματος**

Χρησιμοποιήστε [set_NumberFormatOfValues](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichartseries/set_numberformatofvalues/) για να μορφοποιήσετε τις τιμές σειράς. Αυτό το παράδειγμα δημιουργεί ένα διάγραμμα γραμμής με προεπιλεγμένα δεδομένα, εμφανίζει τον πίνακα δεδομένων του και ενεργοποιεί τις ετικέτες τιμών για την πρώτη σειρά. Η μορφή `#,##0.00` εμφανίζει διαχωριστικό χιλιάδων και δύο δεκαδικά ψηφία χωρίς να αλλάζει τις υποκείμενες τιμές.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 50, 50, 450, 300);
chart->set_HasDataTable(true);

auto series = chart->get_ChartData()->get_Series()->idx_get(0);
series->set_NumberFormatOfValues(u"#,##0.00");
series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

presentation->Save(u"PrecisionOfDatalabels_out.pptx", SaveFormat::Pptx);
```

## **Εμφάνιση ποσοστού ως ετικέτες**

Για ένα στοίβαγμα στήλης, υπολογίστε κάθε τιμή ως ποσοστό του συνολικού της κατηγορίας και αντιθέστε το κείμενο στο πλαίσιο κειμένου που επιστρέφεται από το [get_TextFrameForOverriding](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ioverridabletext/get_textframeforoverriding/). Αυτό το παράδειγμα χρησιμοποιεί τα προεπιλεγμένα δεδομένα διαγράμματος και εμφανίζει ποσοστά με δύο δεκαδικά ψηφία σε γραμματοσειρά 8 σημείων. Οι κατηγορίες με σύνολο μηδέν παραλείπονται για να αποφευχθεί διαίρεση με μηδέν. Επαναϋπολογίστε το προσαρμοσμένο κείμενο ετικέτας εάν τα δεδομένα του διαγράμματος αλλάξουν.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/Chart/IDataLabel.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/Portion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <system/convert.h>
#include <vector>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn, 20, 20, 400, 400);

auto categoryTotals = std::vector<double>(chart->get_ChartData()->get_Categories()->get_Count(), 0.0);
for (auto k = 0; k < chart->get_ChartData()->get_Categories()->get_Count(); k++)
{
    for (auto i = 0; i < chart->get_ChartData()->get_Series()->get_Count(); i++)
    {
        auto series = chart->get_ChartData()->get_Series()->idx_get(i);
        auto pointValue = Convert::ToDouble(series->get_DataPoint(k)->get_Value()->get_Data());
        categoryTotals[k] += pointValue;
    }
}

for (auto x = 0; x < chart->get_ChartData()->get_Series()->get_Count(); x++)
{
    auto series = chart->get_ChartData()->get_Series()->idx_get(x);
    series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLegendKey(false);

    for (auto j = 0; j < series->get_DataPoints()->get_Count(); j++)
    {
        auto label = series->get_DataPoint(j)->get_Label();
        if (categoryTotals[j] == 0)
        {
            continue;
        }

        auto pointValue = Convert::ToDouble(series->get_DataPoint(j)->get_Value()->get_Data());
        auto dataPointPercent = (pointValue / categoryTotals[j]) * 100;

        auto portion = MakeObject<Portion>();
        portion->set_Text(String::Format(u"{0:F2} %", dataPointPercent));
        portion->get_PortionFormat()->set_FontHeight(8.0f);

        label->get_TextFrameForOverriding()->set_Text(u"");

        auto paragraph = label->get_TextFrameForOverriding()->get_Paragraphs()->idx_get(0);
        paragraph->get_Portions()->Add(portion);

        label->get_DataLabelFormat()->set_ShowValue(true);
        label->get_DataLabelFormat()->set_ShowSeriesName(false);
        label->get_DataLabelFormat()->set_ShowPercentage(false);
        label->get_DataLabelFormat()->set_ShowLegendKey(false);
        label->get_DataLabelFormat()->set_ShowCategoryName(false);
        label->get_DataLabelFormat()->set_ShowBubbleSize(false);
    }
}

presentation->Save(u"DisplayPercentageAsLabels_out.pptx", SaveFormat::Pptx);
```

## **Ορισμός συμβόλου ποσοστού στις ετικέτες δεδομένων διαγράμματος**

Όταν οι τιμές αποθηκεύονται ως κλάσματα, χρησιμοποιήστε [set_NumberFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/idatalabelformat/set_numberformat/) για να εμφανίσετε ποσοστά. Π pass `false` στο [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/idatalabelformat/set_isnumberformatlinkedtosource/) για να εφαρμόσετε τη μορφή ετικέτας ανεξάρτητα από τα κελιά πηγής.

Αυτό το παράδειγμα δημιουργεί ένα διάγραμμα στοίβαξης 100% με κόκκινη και μπλε σειρά σε τέσσερις κατηγορίες. Κάθε ζεύγος τιμών προσθέτει στο 1. Η μορφή ετικέτας `0.0%` εμφανίζει το 0.30 ως 30.0%, ενώ ο κατακόρυφος άξονας χρησιμοποιεί δύο δεκαδικά ψηφία. Και οι δύο σειρές χρησιμοποιούν λευκό κείμενο ετικέτας 10 σημείων.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/FillType.h>
#include <DOM/IFillFormat.h>
#include <DOM/IColorFormat.h>
#include <drawing/color.h>
#include <system/object_ext.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::PercentsStackedColumn, 20, 20, 500, 400);

chart->get_Axes()->get_VerticalAxis()->set_IsNumberFormatLinkedToSource(false);
chart->get_Axes()->get_VerticalAxis()->set_NumberFormat(u"0.00%");

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheetIndex = 0;
for (auto i = 0; i < 4; i++)
{
    auto categoryCell = workbook->GetCell(worksheetIndex, i + 1, 0, ObjectExt::Box(String::Format(u"Category {0}", i + 1)));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);
}

String seriesNames[] = { u"Reds", u"Blues" };
Color seriesColors[] = { Color::get_Red(), Color::get_Blue() };
double values[2][4] = { { 0.30, 0.50, 0.80, 0.65 }, { 0.70, 0.50, 0.20, 0.35 } };

for (auto i = 0; i < 2; i++)
{
    auto seriesCell = workbook->GetCell(worksheetIndex, 0, i + 1, ObjectExt::Box(seriesNames[i]));
    auto series = chart->get_ChartData()->get_Series()->Add(seriesCell, chart->get_Type());
    for (auto j = 0; j < 4; j++)
    {
        auto valueCell = workbook->GetCell(worksheetIndex, j + 1, i + 1, ObjectExt::Box(values[i][j]));
        series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
    }

    series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
    series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(seriesColors[i]);

    auto labelFormat = series->get_Labels()->get_DefaultDataLabelFormat();
    labelFormat->set_ShowValue(true);
    labelFormat->set_IsNumberFormatLinkedToSource(false);
    labelFormat->set_NumberFormat(u"0.0%");
    labelFormat->get_TextFormat()->get_PortionFormat()->set_FontHeight(10);
    labelFormat->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
    labelFormat->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_White());
}

presentation->Save(u"SetDataLabelsPercentageSign_out.pptx", SaveFormat::Pptx);
```

## **Ανάγνωση του πραγματικού κειμένου των ετικετών δεδομένων**

Χρησιμοποιήστε [GetActualLabelText](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/idatalabel/getactuallabeltext/) για να ανακτήσετε το κείμενο που παράγεται από τις ρυθμίσεις μιας ετικέτας δεδομένων. Αυτό είναι χρήσιμο όταν εξάγετε ετικέτες για αναφορές, αναζητάτε περιεχόμενο παρουσίασης ή επικυρώνετε δημιουργημένα διαγράμματα. Στο παρακάτω παράδειγμα, η προεπιλεγμένη [data label format](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/idatalabelformat/) συνδυάζει το όνομα κάθε κατηγορίας, το όνομα σειράς και την τιμή. Ένα σημείο μορφοποιεί την τιμή του ως ποσοστό, ενώ ένα άλλο χρησιμοποιεί προσαρμοσμένο κείμενο από το [get_TextFrameForOverriding](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ioverridabletext/get_textframeforoverriding/).

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/Chart/IDataLabel.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/ITextFrame.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20, 20, 500, 300);

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto firstCategoryCell = workbook->GetCell(0, 1, 0, ObjectExt::Box<String>(u"Q1"));
chart->get_ChartData()->get_Categories()->Add(firstCategoryCell);
auto secondCategoryCell = workbook->GetCell(0, 2, 0, ObjectExt::Box<String>(u"Q2"));
chart->get_ChartData()->get_Categories()->Add(secondCategoryCell);

auto northSeriesCell = workbook->GetCell(0, 0, 1, ObjectExt::Box<String>(u"North"));
auto north = chart->get_ChartData()->get_Series()->Add(northSeriesCell, chart->get_Type());
auto northFirstValueCell = workbook->GetCell(0, 1, 1, ObjectExt::Box(0.25));
north->get_DataPoints()->AddDataPointForBarSeries(northFirstValueCell);
auto northSecondValueCell = workbook->GetCell(0, 2, 1, ObjectExt::Box(0.75));
north->get_DataPoints()->AddDataPointForBarSeries(northSecondValueCell);

auto southSeriesCell = workbook->GetCell(0, 0, 2, ObjectExt::Box<String>(u"South"));
auto south = chart->get_ChartData()->get_Series()->Add(southSeriesCell, chart->get_Type());
auto southFirstValueCell = workbook->GetCell(0, 1, 2, ObjectExt::Box(0.40));
south->get_DataPoints()->AddDataPointForBarSeries(southFirstValueCell);
auto southSecondValueCell = workbook->GetCell(0, 2, 2, ObjectExt::Box(0.60));
south->get_DataPoints()->AddDataPointForBarSeries(southSecondValueCell);

for (auto i = 0; i < chart->get_ChartData()->get_Series()->get_Count(); i++)
{
    auto series = chart->get_ChartData()->get_Series()->idx_get(i);
    auto format = series->get_Labels()->get_DefaultDataLabelFormat();
    format->set_ShowCategoryName(true);
    format->set_ShowSeriesName(true);
    format->set_ShowValue(true);
}

north->get_Label(1)->get_DataLabelFormat()->set_IsNumberFormatLinkedToSource(false);
north->get_Label(1)->get_DataLabelFormat()->set_NumberFormat(u"0%");
south->get_Label(0)->get_TextFrameForOverriding()->set_Text(u"Reviewed");

for (auto i = 0; i < chart->get_ChartData()->get_Series()->get_Count(); i++)
{
    auto series = chart->get_ChartData()->get_Series()->idx_get(i);
    for (auto j = 0; j < series->get_DataPoints()->get_Count(); j++)
    {
        auto point = series->get_DataPoint(j);
        auto label = point->get_Label();
        if (!label->get_IsVisible())
        {
            continue;
        }

        Console::WriteLine(String::Format(u"Value: {0}; label: {1}", point->get_Value()->get_Data(), label->GetActualLabelText()));
    }
}
```

Ο αριθμός που αποθηκεύεται σε ένα σημείο δεδομένων παραμένει `0.75`, ακόμη και όταν η ετικέτα του εμφανίζει `75%` μαζί με τα ονόματα κατηγορίας και σειράς. Το προσαρμοσμένο κείμενο αντικαθιστά το παραγόμενο κείμενο ετικέτας. Το [GetActualLabelText](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/idatalabel/getactuallabeltext/) επιστρέφει το τελικό κείμενο ετικέτας και στις δύο περιπτώσεις. Ελέγξτε το [get_IsVisible](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/idatalabel/get_isvisible/) ξεχωριστά, όπως φαίνεται παραπάνω, όταν θέλετε να εξαγάγετε μόνο τις ορατές ετικέτες.

## **Έλεγχος ετικετών δεδομένων πέραν του μέγιστου αξόνων**

Όταν περιορίζετε το εύρος ενός άξονα χειροκίνητα, ορισμένα σημεία δεδομένων μπορεί να ξεπεράσουν το μέγιστο. Χρησιμοποιήστε [set_ShowDataLabelsOverMaximum](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichart/set_showdatalabelsovermaximum/) για να ελέγξετε αν οι ετικέτες δεδομένων τους εμφανίζονται. Αυτή η ρύθμιση αλλάζει τη διαφάνεια της ετικέτας· δεν αλλάζει το εύρος του άξονα ή τις υποκείμενες τιμές δεδομένων.

Το παρακάτω παράδειγμα δημιουργεί ένα 2D διαχωρισμένο διάγραμμα στήλης με τιμές 60 και 120. Ορίζει το [set_IsAutomaticMaxValue](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/iaxis/set_isautomaticmaxvalue/) σε `false` και το [set_MaxValue](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/iaxis/set_maxvalue/) σε 100 στον κατακόρυφο άξονα. Η πρώτη διαφάνεια επιτρέπει ετικέτες πέραν του μέγιστου· ένα αντίγραφο της διαφάνειας τις απενεργοποιεί. Και οι δύο διαφάνειες αποθηκεύονται στο `DataLabelsOverMaximum.pptx`.

Ενεργοποιήστε τις ετικέτες τιμών με το [set_ShowValue](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/idatalabelformat/set_showvalue/). Η ρύθμιση σε επίπεδο διαγράμματος δεν ενεργοποιεί αυτόματα την εμφάνιση της τιμής ούτε παρακάμπτει την απενεργοποιημένη εμφάνιση τιμής μιας μεμονωμένης ετικέτας. Αυτό το παράδειγμα ενεργοποιεί τις τιμές για ολόκληρη τη σειρά και χρησιμοποιεί το [set_Position](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/idatalabelformat/set_position/) για να τοποθετήσει τις ετικέτες στο εξωτερικό άκρο κάθε στήλης.

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
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/Chart/LegendDataLabelPosition.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
chart->set_HasLegend(false);

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

auto firstCategory = workbook->GetCell(0, 1, 0, ObjectExt::Box<String>(u"Within range"));
auto secondCategory = workbook->GetCell(0, 2, 0, ObjectExt::Box<String>(u"Above maximum"));

chart->get_ChartData()->get_Categories()->Add(firstCategory);
chart->get_ChartData()->get_Categories()->Add(secondCategory);

auto seriesName = workbook->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Values"));
auto series = chart->get_ChartData()->get_Series()->Add(seriesName, chart->get_Type());

auto firstValue = workbook->GetCell(0, 1, 1, ObjectExt::Box(60));
auto secondValue = workbook->GetCell(0, 2, 1, ObjectExt::Box(120));

series->get_DataPoints()->AddDataPointForBarSeries(firstValue);
series->get_DataPoints()->AddDataPointForBarSeries(secondValue);

series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
series->get_Labels()->get_DefaultDataLabelFormat()->set_Position(LegendDataLabelPosition::OutsideEnd);

chart->get_Axes()->get_VerticalAxis()->set_IsAutomaticMaxValue(false);
chart->get_Axes()->get_VerticalAxis()->set_MaxValue(100);
chart->set_ShowDataLabelsOverMaximum(true);

auto secondSlide = presentation->get_Slides()->AddClone(slide);
auto secondChart = ExplicitCast<IChart>(secondSlide->get_Shape(0));
secondChart->set_ShowDataLabelsOverMaximum(false);

presentation->Save(u"DataLabelsOverMaximum.pptx", SaveFormat::Pptx);
```

Η ακόλουθη εικόνα δείχνει τις αποθηκευμένες διαφάνειες που αποδόθηκαν από το Microsoft PowerPoint. Με `true`, η ετικέτα **120** είναι ορατή στο άνω όριο· με `false`, είναι κρυφή. Η ετικέτα **60** παραμένει ορατή, το μέγιστο του άξονα παραμένει **100** και το δεύτερο σημείο δεδομένων παραμένει **120** και στις δύο περιπτώσεις.

| ShowDataLabelsOverMaximum = true | ShowDataLabelsOverMaximum = false |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Τύπος Διαγράμματος" %}}
Αυτό το παράδειγμα χρησιμοποιεί ένα 2D διάγραμμα στήλης με άξονα τιμών. Τα διαγράμματα χωρίς άξονα τιμών, όπως τα διαγράμματα πίτας και δακτυλίου, δεν διαθέτουν μέγιστο άξονα προς περιορισμό με αυτόν τον τρόπο.
{{% /alert %}}

## **Ορισμός απόστασης ετικέτας από άξονα**

Χρησιμοποιήστε το [set_LabelOffset](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/iaxis/set_labeloffset/) για να ελέγξετε το απόσταση μεταξύ των ετικετών του άξονα κατηγορίας και του άξονα. Η τιμή είναι ποσοστό του μέγιστου μεγέθους γραμματοσειράς των ετικετών άξονα. Αυτό το παράδειγμα δημιουργεί ένα διαχωρισμένο διάγραμμα στήλης και ορίζει το οριζόντιο offset ετικέτας άξονα σε 500. Αυτή η ρύθμιση επηρεάζει τις ετικέτες άξονα κατηγορίας και όχι τις ετικέτες που συνδέονται με μεμονωμένα σημεία δεδομένων.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20, 20, 500, 300);
chart->get_Axes()->get_HorizontalAxis()->set_LabelOffset(500);

presentation->Save(u"SetCategoryAxisLabelDistance_out.pptx", SaveFormat::Pptx);
```

## **Προσαρμογή θέσης ετικέτας**

Σε διάγραμμα πίτας, προσαρμόστε τις θέσεις ετικετών δεδομένων για να βελτιώσετε το διάστημα και να δημιουργήσετε χώρο για γραμμές οδηγού.

Αυτό το παράδειγμα εμφανίζει την τιμή του πρώτου σημείου δεδομένων, τοποθετεί την ετικέτα του έξω από το τμήμα και χρησιμοποιεί τα [set_X](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ilayoutable/set_x/) και [set_Y](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ilayoutable/set_y/) για να προσαρμόσει τις μετατοπίσεις του. Αυτές οι μετατοπίσεις είναι σχετικές με το πλάτος και το ύψος του διαγράμματος, αντίστοιχα.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IDataLabel.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/Chart/LegendDataLabelPosition.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 200, 200);
auto series = chart->get_ChartData()->get_Series();

auto label = series->idx_get(0)->get_Label(0);
label->get_DataLabelFormat()->set_ShowValue(true);
label->get_DataLabelFormat()->set_Position(LegendDataLabelPosition::OutsideEnd);
label->set_X(0.71f);
label->set_Y(0.04f);

presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
```

![Pie chart with an adjusted data label position](pie-chart-adjusted-label.png)

## **FAQ**

**Πώς μπορώ να αποτρέψω την επικάλυψη ετικετών δεδομένων σε πυκνά διαγράμματα;**

Συνδυάστε αυτόματη τοποθέτηση ετικετών, γραμμές οδηγού και μειωμένο μέγεθος γραμματοσειράς· εφόσον χρειαστεί, κρύψτε ορισμένα πεδία (π.χ. την κατηγορία) ή εμφανίστε ετικέτες μόνο για ακραίες τιμές ή κεντρικά σημεία.

**Πώς μπορώ να απενεργοποιήσω ετικέτες μόνο για μηδενικές, αρνητικές ή κενές τιμές;**

Φιλτράρετε τα σημεία δεδομένων πριν ενεργοποιήσετε τις ετικέτες και απενεργοποιήστε την εμφάνιση για τιμές 0, αρνητικές τιμές ή ελλιπείς τιμές σύμφωνα με έναν ορισμένο κανόνα.

**Πώς μπορώ να διασφαλίσω συνεπές στυλ ετικετών κατά την εξαγωγή σε PDF/εικόνες;**

Ορίστε ρητά την οικογένεια γραμματοσειράς και το μέγεθος και βεβαιωθείτε ότι η γραμματοσειρά είναι διαθέσιμη στο περιβάλλον απόδοσης για να αποφύγετε εναλλακτικές γραμματοσειρές.