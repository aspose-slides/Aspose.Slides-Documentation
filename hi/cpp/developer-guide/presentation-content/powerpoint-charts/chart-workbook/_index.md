---
title: C++ का उपयोग करके प्रस्तुतियों में चार्ट वर्कबुक प्रबंधित करें
linktitle: चार्ट वर्कबुक
type: docs
weight: 70
url: /hi/cpp/chart-workbook/
keywords:
- चार्ट वर्कबुक
- चार्ट डेटा
- वर्कबुक सेल
- डेटा लेबल
- वर्कशीट
- डेटा स्रोत
- बाहरी वर्कबुक
- बाहरी डेटा
- चार्ट कैश
- वर्कबुक पुनर्प्राप्ति
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ की खोज करें: PowerPoint और OpenDocument स्वरूपों में चार्ट वर्कबुक को सहजता से प्रबंधित करें, ताकि आपकी प्रस्तुति डेटा को सुव्यवस्थित किया जा सके।"
---
## **अवलोकन**

यह लेख Aspose.Slides में चार्ट वर्कबुक के साथ काम करने के तरीके को समझाता है। यह दिखाता है कि वर्कबुक स्ट्रीम के माध्यम से चार्ट डेटा को कैसे पढ़ें और लिखें, वर्कबुक कोशिकाओं को चार्ट डेटा लेबल के रूप में उपयोग करें, वर्कशीट संग्रह तक पहुंचें, और चार्ट मानों के लिए डेटा स्रोत प्रकार निर्दिष्ट करें।

यह बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में उपयोग करने को भी शामिल करता है। उदाहरण दिखाते हैं कि बाहरी वर्कबुक कैसे बनाएं और असाइन करें, चार्ट से जुड़ी बाहरी वर्कबुक का पथ कैसे प्राप्त करें, और जब वर्कबुक उपलब्ध हो तो चार्ट डेटा को कैसे संपादित करें।

गुम डेटा का प्रतिनिधित्व करने वाली वर्कबुक कोशिकाओं के लिए, एक खाली कोशिका और शून्य के बीच अंतर तथा उपलब्ध प्रदर्शन मोड की लाइन-चार्ट तुलना के लिए देखें [खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें](/slides/hi/cpp/chart-series/)।

## **छिपी हुई पंक्तियों और कॉलम से डेटा शामिल करें**

Use [IChart::set_PlotVisibleCellsOnly](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_plotvisiblecellsonly/) का उपयोग करके नियंत्रित करें कि क्या चार्ट छिपी हुई वर्कशीट पंक्तियों और कॉलम के डेटा को प्लॉट करता है। इसे `true` सेट करने से केवल दृश्यमान कोशिकाएँ प्लॉट होती हैं, या `false` सेट करने से दृश्यमान और छिपी हुई दोनों कोशिकाएँ शामिल होती हैं। यह सेटिंग चार्ट प्लॉटिंग को नियंत्रित करती है; यह वर्कशीट पंक्तियों या कॉलम को छुपाती या दिखाती नहीं है।

[नमूना प्रस्तुति](hidden-source-data.pptx) में पहली स्लाइड की पहली आकृति के रूप में एक कॉलम चार्ट है। एंबेडेड वर्कशीट, `Sheet1`, में निम्न स्रोत रेंज `A1:C4` है। पंक्ति 3 और कॉलम C छिपे हुए हैं, लेकिन उनकी कोशिकाओं में अभी भी मान हैं।

| वर्कशीट पंक्ति | A: माह | B: खुदरा | C: थोक (छिपा कॉलम) |
| --- | --- | --- | --- |
| 2 | जनवरी | 10 | 30 |
| 3 (छिपी पंक्ति) | फ़रवरी | 40 | 60 |
| 4 | मार्च | 20 | 50 |

Access source cells through [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) और [IChartDataCell::get_IsHidden](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/get_ishidden/) पढ़ें ताकि उनकी छिपी स्थिति का निरीक्षण कर सकें। यह प्रॉपर्टी केवल पढ़ने योग्य है। इस फ़ाइल में, B2 दृश्यमान है, B3 छिपी पंक्ति से संबंधित है, और C2 छिपे कॉलम से संबंधित है; उदाहरण क्रमशः `False`, `True`, और `True` प्रिंट करता है।

For this example, refresh the chart data after changing the plotting setting: retain the embedded workbook with [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) and reload it with [WriteWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/). When including all cells, also use [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setrange/) to restore the complete range, including the hidden February category. Simply changing the flag is insufficient to refresh this sample's cached chart data and category labels.

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

        // एंबेडेड वर्कबुक से चार्ट डेटा को रीफ़्रेश करें।
        workbookStream->set_Position(0);
        chart->get_ChartData()->WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // छिपी श्रेणियों सहित संपूर्ण स्रोत रेंज को पुनर्स्थापित करें।
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

The example saves two versions of the presentation: one with only the visible Retail values (10 and 20), and another with all six values. The images below illustrate the two plotting modes. Row 3 and column C remain hidden in both embedded workbooks.

| केवल दृश्यमान कोशिकाएँ (`true`) | सभी कोशिकाएँ (`false`) |
| --- | --- |
| ![केवल दृश्यमान कोशिकाएँ: जनवरी और मार्च के लिए खुदरा मान 10 और 20।](hidden_cells_True.png) | ![सभी कोशिकाएँ: जनवरी, फ़रवरी और मार्च के लिए खुदरा और थोक मान।](hidden_cells_False.png) |

A hidden cell containing a value is different from an empty cell. [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_displayblanksas/) controls how missing values are displayed; it does not include or exclude hidden source data. See [खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें](/slides/hi/cpp/chart-series/#control-the-display-of-empty-cells) for an example.

## **चार्ट की डेटा रेंज प्राप्त करें**

Before updating workbook data in an existing presentation, inspect the source ranges to identify which worksheet cells each chart uses. The [IChartData::GetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/getrange/) method returns the current data range as a worksheet-qualified formula, such as `Sheet1!$A$1:$D$5`. Here, `Sheet1` is the worksheet name, `!` separates it from the cell range, and `$A$1:$D$5` identifies cells A1 through D5, inclusive. The dollar signs indicate absolute row and column references.

The method reads the current range without changing the chart or its workbook. If the chart does not use a workbook as its data source, it throws [System::InvalidOperationException](https://reference.aspose.com/slides/cpp/system/details_invalidoperationexception/). For more information, see the [ChartData API Reference](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/).

This example opens a presentation and checks the shapes directly on each slide for charts. It prints each chart's name and source range. If a chart does not use a workbook, it prints a message and continues to the next chart.

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

## **वर्कबुक से चार्ट डेटा पढ़ें और लिखें**

Aspose.Slides for C++ provides the [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) and [WriteWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) methods that allow you to read and write chart data workbooks (containing chart data edited with Aspose.Cells). **Note** that the chart data has to be organized in the same manner or must have a structure similar to the source.

This example uses a presentation with a chart as the first shape on its first slide. It reads the embedded workbook into a stream, clears the existing series and categories, and writes the same workbook back. The changes remain in memory; the example does not save the presentation.

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

### **वर्कबुक संशोधन के बाद चार्ट लेआउट सत्यापित करें**

When you replace an embedded workbook with a modified one, the chart retains its original series and category collections. This mismatch can cause [IChart::ValidateChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/validatechartlayout/) to fail with an index-out-of-range error. Clear the existing series and categories before writing the updated workbook back to the chart. This example uses a chart that is the first shape on the first slide. The comment marks where workbook editing would occur; the runnable example writes the original workbook back and validates the layout in memory.

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

    // वर्कबुक स्ट्रीम को यहाँ संशोधित करें, उदाहरण के लिए, Aspose.Cells का उपयोग करके।

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

Clearing the collections removes stale data references before the workbook is written back. Rebuild any required series and category mappings for the updated workbook before using the chart.

## **वर्कबुक कोशिकाओं के लिए कस्टम नंबर फ़ॉर्मेट सेट करें**

Use [IChartDataCell::set_CustomNumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/set_customnumberformat/) to control how numeric values appear in a chart's embedded workbook. For example, a report may need a conversion rate displayed as a percentage with four decimal places and a coefficient displayed with five decimal places. Keep both values numeric so they remain available for calculations and chart plotting.

A number format changes the display, not the stored value. The format `0.0000%` displays `0.125` as `12.5000%`; it does not replace the stored number with `12.5`. Similarly, `0.00000` displays `0.1234567` as `0.12346` without rounding the stored value. If the custom format is an empty string (`""`), the format assigned through [set_PresetNumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/set_presetnumberformat/) is used instead.

The following example creates a column chart and accesses its cells through [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/). On worksheet 0, B2 contains the conversion rate and C2 contains the coefficient. Both cells supply chart values. The example also enables value labels linked to the source formats.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDataLabel.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(720, 270, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 20, 620, 210);
chart->set_HasTitle(false);

chart->get_Axes()->get_VerticalAxis()->set_IsNumberFormatLinkedToSource(false);
chart->get_Axes()->get_VerticalAxis()->set_NumberFormat(u"0.00");
chart->get_Axes()->get_VerticalAxis()->set_IsAutomaticMinValue(false);
chart->get_Axes()->get_VerticalAxis()->set_MinValue(0);

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto categoryCell = workbook->GetCell(0, u"A2", ObjectExt::Box<String>(u"Sample"));
chart->get_ChartData()->get_Categories()->Add(categoryCell);

auto percentageCell = workbook->GetCell(0, u"B2", ObjectExt::Box<double>(0.125));
percentageCell->set_CustomNumberFormat(u"0.0000%");
auto percentageName = workbook->GetCell(0, u"B1", ObjectExt::Box<String>(u"Conversion rate"));
auto percentageSeries = chart->get_ChartData()->get_Series()->Add(percentageName, chart->get_Type());
percentageSeries->get_DataPoints()->AddDataPointForBarSeries(percentageCell);

auto precisionCell = workbook->GetCell(0, u"C2", ObjectExt::Box<double>(0.1234567));
precisionCell->set_CustomNumberFormat(u"0.00000");
auto precisionName = workbook->GetCell(0, u"C1", ObjectExt::Box<String>(u"Coefficient"));
auto precisionSeries = chart->get_ChartData()->get_Series()->Add(precisionName, chart->get_Type());
precisionSeries->get_DataPoints()->AddDataPointForBarSeries(precisionCell);

for (auto series : IterateOver(chart->get_ChartData()->get_Series()))
{
    auto labelFormat = series->get_DataPoint(0)->get_Label()->get_DataLabelFormat();
    labelFormat->set_ShowValue(true);
    labelFormat->set_IsNumberFormatLinkedToSource(true);
}

presentation->Save(u"CustomCellFormats.pptx", Export::SaveFormat::Pptx);
```

Workbook cell formats are separate from formats set directly on chart axes or data labels. In this example, each label displays its source cell's value because [set_ShowValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_showvalue/) is called with `true`, and follows the source number format because [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_isnumberformatlinkedtosource/) is called with `true`. After saving and reopening the presentation, the labels display `12.5000%` and `0.12346`, as shown below. The vertical axis uses its own format of `0.00`, assigned through [set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_numberformat/), with [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isnumberformatlinkedtosource/) called with `false`.

To format a data label independently, set its source-link flag to `false` and assign its format through [set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_numberformat/). This does not change the workbook cell's format. For example, an independent label format of `0.00` displays the first value as `0.13`, while B2 still displays `12.5000%`. See [Chart Data Labels](/slides/hi/cpp/chart-data-label/#set-percentage-sign-with-chart-data-labels) for direct label formatting.

The image below was rendered from the saved presentation after reopening it:

![स्रोत-लिंक्ड लेबल वाले कॉलम चार्ट जिसमें 12.5000% और 0.12346 दिख रहा है तथा स्वतंत्र रूप से फ़ॉर्मेट किए गए संख्यात्मक अक्ष।](custom-cell-formats.png)

## **एक वर्कबुक कोशिका को चार्ट डेटा लेबल के रूप में सेट करें**

You can use text from workbook cells as chart data labels.

This example adds a bubble chart with default data to the first slide of an existing presentation. It uses cells A10:A12 on worksheet 0 for the first three labels in the first series, enables labels from cells, and saves the updated presentation.

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

## **वर्कशीट को प्रबंधित करें**

The [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) method provides access to the worksheets in a chart workbook. This example creates a pie chart with default data and prints each worksheet name to the console.

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

## **डेटा स्रोत प्रकार निर्दिष्ट करें**

Series point values can also be stored directly as numeric literals. See [Set Series Values Using Numeric Literals](/slides/hi/cpp/chart-series/#set-series-values-using-numeric-literals) for a complete example that saves and reads them. The source type of point values is separate from the chart's internal or external workbook configuration; using numeric literals does not, by itself, remove the embedded workbook.

This example creates a 3D column chart with default data and sets two series names using different data sources. The first name uses a string literal; the second uses cell C1 on worksheet 0. The [DataSourceType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/datasourcetype/) enumeration selects the source for each name. The example saves the presentation with the updated series names.

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

## **असमर्थित एंबेडेड वर्कबुक फ़ॉर्मेट का पता लगाएँ**

Aspose.Slides does not support the Excel binary workbook (.xlsb) format that can be embedded in some charts. You can use the [get_EmbeddedWorkbookType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_embeddedworkbooktype/) method on [IChartData](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/) together with the [WorkbookType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/workbooktype/) enumeration to detect unsupported formats and skip those charts. This example inspects the shapes on the first slide of an existing presentation, skips non-chart shapes, and prints a diagnostic message for each chart with an embedded .xlsb workbook.

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

    // समर्थित चार्ट वर्कबुक डेटा को यहाँ पढ़ें या संशोधित करें।
}
```

## **बाहरी वर्कबुक**

Aspose.Slides supports using external workbooks as a data source for charts.

### **एक बाहरी वर्कबुक बनाएं**

Use [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) and [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) to export an embedded chart workbook to a file and link the chart to that external workbook.

This example creates a pie chart with default data and exports its workbook. It closes the output stream before assigning the external workbook as the chart data source, then saves the linked presentation.

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

### **एक बाहरी वर्कबुक सेट करें**

Using the [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) method, you can assign an external workbook to a chart as its data source. This method can also be used to update a path to the external workbook (if the latter has been moved).

While you cannot edit the data in workbooks stored in remote locations or resources, you can still use such workbooks as an external data source. If the relative path for an external workbook is provided, it gets converted to a full path automatically.

This example uses an external workbook whose worksheet named `Sheet1` contains a series name in B1, category names in A2:A4, and numeric values in B2:B4. The example creates a pie chart, links the workbook, and uses [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setrange/) to map A1:B4 to one series and three categories. It saves the presentation with the linked chart.

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

The `updateChartData` parameter of [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) controls whether the workbook is loaded.

* When `updateChartData` is `false`, only the workbook path is updated. The chart data is not loaded or updated from the target workbook, so the workbook can be unavailable.
* When `updateChartData` is `true`, the chart data is updated from the target workbook.

The following example assigns a placeholder URL with `updateChartData` set to `false`. It retains the pie chart's default data and saves the presentation without loading the unavailable workbook.

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

### **एक चार्ट की बाहरी डेटा स्रोत वर्कबुक पथ प्राप्त करें**

To identify the workbook linked to a chart, check whether the chart uses an external data source and retrieve its workbook path.

This example inspects the first shape on the first slide of a presentation with a linked external workbook. If it is a chart linked to an external workbook, the example prints [get_ExternalWorkbookPath](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_externalworkbookpath/) to the console. It then saves a copy of the presentation.

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

### **चार्ट डेटा संपादित करें**

You can edit the data in external workbooks the same way you make changes to the contents of internal workbooks. When an external workbook cannot be loaded, an exception is thrown.

This example uses a chart that is the first shape on the first slide and is linked to an accessible external workbook. It sets the cell-backed value of the first data point in the first series to 100 and saves the updated presentation. Editing cell values can update the linked external XLSX file, so use a copy if you need to preserve the original workbook.

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

### **चार्ट कैश से वर्कबुक पुनर्प्राप्त करें**

If a chart uses an external workbook that is missing or unavailable, Aspose.Slides can reconstruct the chart workbook from the data cached in the presentation. Create [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/), configure it with [set_SpreadsheetOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/), and call [ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/) with `true` before opening the presentation.

The following C++ example recovers workbook data for a chart that is the first shape on the first slide and references an unavailable external workbook. It accesses the recovered data through [IChart::get_ChartData](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_chartdata/) and [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/):

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

    // यहाँ पुनर्प्राप्त वर्कबुक डेटा को पढ़ें या संशोधित करें।
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

If the external workbook is unavailable and recovery is disabled, Aspose.Slides throws a [System::InvalidOperationException](https://reference.aspose.com/slides/cpp/system/details_invalidoperationexception/). Enable recovery only when using the cached chart data is an acceptable fallback, because the cache may not contain changes made to the external workbook after the presentation was last updated.

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं निर्धारित कर सकता हूँ कि कोई विशिष्ट चार्ट बाहरी या एंबेडेड वर्कबुक से जुड़ा है?**

हां। एक चार्ट का [data source type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) और [path to an external workbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) होता है; यदि स्रोत एक बाहरी वर्कबुक है, तो आप पूर्ण पथ पढ़कर सुनिश्चित कर सकते हैं कि कोई बाहरी फ़ाइल उपयोग हो रही है।

**क्या बाहरी वर्कबुक के लिए सापेक्ष पथ समर्थित हैं, और वे कैसे संग्रहीत होते हैं?**

हां। यदि आप सापेक्ष पथ निर्दिष्ट करते हैं, तो वह स्वचालित रूप से पूर्ण पथ में परिवर्तित हो जाता है। प्रस्तुति PPTX फ़ाइल में पूर्ण पथ संग्रहीत करती है, इसलिए वर्कबुक को स्थानांतरित करने पर लिंक को अपडेट करना पड़ सकता है।

**क्या मैं नेटवर्क संसाधनों/शेयरों पर स्थित वर्कबुक का उपयोग कर सकता हूँ?**

हां, ऐसे वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग किया जा सकता है। हालांकि, Aspose.Slides से दूरस्थ वर्कबुक को सीधे संपादित करना समर्थित नहीं है—वे केवल स्रोत के रूप में उपयोग किए जा सकते हैं।

**क्या Aspose.Slides प्रस्तुति सहेजते समय बाहरी XLSX को ओवरराइट करता है?**

प्रस्तुति में [बाहरी फ़ाइल का लिंक](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) संग्रहीत रहता है। सेल-समर्थित चार्ट डेटा को संपादित करने से लिंक्ड स्थानीय XLSX फ़ाइल भी अपडेट हो सकती है। यदि मूल फ़ाइल को अपरिवर्तित रखना आवश्यक है, तो वर्कबुक की एक प्रति उपयोग करें।

**यदि बाहरी फ़ाइल पासवर्ड-संरक्षित है तो मुझे क्या करना चाहिए?**

Aspose.Slides लिंक करते समय पासवर्ड स्वीकार नहीं करता। एक सामान्य तरीका यह है कि पहले सुरक्षा को हटाया जाए या किसी डिक्रिप्टेड प्रति (उदाहरण के लिए, [Aspose.Cells](https://reference.aspose.com/cells/cpp/) का उपयोग करके) तैयार की जाए और उस प्रति से लिंक किया जाए।

**क्या कई चार्ट एक ही बाहरी वर्कबुक को संदर्भित कर सकते हैं?**

हां। प्रत्येक चार्ट अपना लिंक संग्रहीत करता है। यदि वे सभी एक ही फ़ाइल की ओर इशारा करते हैं, तो उस फ़ाइल में परिवर्तन अगली बार डेटा लोड होने पर सभी चार्ट में परिलक्षित होगा।