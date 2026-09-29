---
title: प्रस्तुतियों में C++ का उपयोग करके चार्ट डेटा लेबल प्रबंधित करें
linktitle: डेटा लेबल
type: docs
url: /hi/cpp/chart-data-label/
keywords:
- चार्ट
- डेटा लेबल
- डेटा सटीकता
- प्रतिशत
- लेबल दूरी
- लेबल स्थान
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ का उपयोग करके PowerPoint प्रस्तुतियों में चार्ट डेटा लेबल जोड़ना और स्वरूपित करना सीखें, ताकि अधिक आकर्षक स्लाइड्स बन सकें।"
---
## **परिचय**

डेटा लेबल चार्ट श्रृंखला और व्यक्तिगत डेटा बिंदुओं के बारे में जानकारी प्रदर्शित करते हैं, जिससे पाठकों को मान पहचानने और चार्ट को समझने में मदद मिलती है। यह लेख मूल्य को स्वरूपित करने, प्रतिशत प्रदर्शित करने, लेबल पाठ पढ़ने, अक्ष अधिकतम से परे लेबल नियंत्रित करने, वर्गीकरण अक्ष लेबल स्पेसिंग समायोजित करने, और पाई चार्ट लेबल की स्थिति निर्धारित करने के तरीकों को समझाता है।

## **चार्ट डेटा लेबल में डेटा सटीकता सेट करें**

सिरिज़ मानों को स्वरूपित करने के लिए [set_NumberFormatOfValues](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartseries/set_numberformatofvalues/) का उपयोग करें। यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक लाइन चार्ट बनाता है, उसकी डेटा तालिका प्रदर्शित करता है, और पहले श्रृंखला के लिए मान लेबल सक्षम करता है। स्वरूप `#,##0.00` हज़ार विभाजक और दो दशमलव स्थान दिखाता है बिना मूल मानों को बदले।

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

## **लेबल के रूप में प्रतिशत दिखाएँ**

एक स्टैक्ड कॉलम चार्ट के लिए, प्रत्येक मान को उसकी वर्ग कुल के प्रतिशत के रूप में गणना करें और पाठ को उस टेक्स्ट फ्रेम में असाइन करें जो [get_TextFrameForOverriding](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ioverridabletext/get_textframeforoverriding/) द्वारा वापस किया जाता है। यह उदाहरण डिफ़ॉल्ट चार्ट डेटा का उपयोग करता है और 8‑पॉइंट फ़ॉन्ट में दो दशमलव स्थान के साथ प्रतिशत प्रदर्शित करता है। शून्य कुल वाले वर्गों को शून्य द्वारा भाग देने से बचने के लिए छोड़ दिया जाता है। यदि चार्ट डेटा बदलता है तो कस्टम लेबल पाठ को पुनः गणना करें।

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

## **चार्ट डेटा लेबल में प्रतिशत चिह्न सेट करें**

जब मान अंशों के रूप में संग्रहीत होते हैं, तो प्रतिशत प्रदर्शित करने के लिए [set_NumberFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/idatalabelformat/set_numberformat/) का उपयोग करें। स्रोत कोशिकाओं से स्वतंत्र रूप से लेबल स्वरूप लागू करने के लिए [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/idatalabelformat/set_isnumberformatlinkedtosource/) को `false` पास करें।

यह उदाहरण चार वर्गों में लाल और नीले क्रमशः श्रृंखलाओं के साथ 100 % स्टैक्ड कॉलम चार्ट बनाता है। प्रत्येक मान जोड़ी का योग 1 होता है। लेबल स्वरूप `0.0%` मान `0.30` को `30.0%` के रूप में दिखाता है, जबकि लम्बवत अक्ष दो दशमलव स्थान का उपयोग करता है। दोनों श्रृंखलाएँ सफेद, 10‑पॉइंट लेबल टेक्स्ट का प्रयोग करती हैं।

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

## **डेटा लेबल के वास्तविक पाठ को पढ़ें**

डेटा लेबल की सेटिंग्स द्वारा उत्पन्न पाठ को प्राप्त करने के लिए [GetActualLabelText](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/idatalabel/getactuallabeltext/) का उपयोग करें। यह रिपोर्टों के लिए लेबल निकालते समय, प्रस्तुति सामग्री खोजते समय, या निर्मित चार्ट को मान्य करते समय उपयोगी है। नीचे दिए गए उदाहरण में, डिफ़ॉल्ट [डेटा लेबल स्वरूप](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/idatalabelformat/) प्रत्येक वर्ग नाम, श्रृंखला नाम, और मान को जोड़ता है। एक बिंदु अपना मान प्रतिशत के रूप में स्वरूपित करता है, और दूसरा [get_TextFrameForOverriding](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ioverridabletext/get_textframeforoverriding/) से कस्टम टेक्स्ट का उपयोग करता है।

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

डेटा बिंदु में संग्रहीत संख्या `0.75` रहती है, जबकि उसका लेबल `75%` के साथ वर्ग और श्रृंखला नाम दिखा सकता है। कस्टम टेक्स्ट उत्पन्न लेबल पाठ को बदल देता है। [GetActualLabelText](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/idatalabel/getactuallabeltext/) दोनों स्थितियों में परिणामी लेबल स्ट्रिंग लौटाता है। यदि आप केवल दिखाई देने वाले लेबल निकालना चाहते हैं तो ऊपर दिखाए अनुसार [get_IsVisible](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/idatalabel/get_isvisible/) को अलग से जांचें।

## **अक्ष अधिकतम से परे डेटा लेबल नियंत्रित करें**

जब आप मैन्युअल रूप से किसी अक्ष की सीमा सीमित करते हैं, तो कुछ डेटा बिंदु उसके अधिकतम से अधिक हो सकते हैं। यह तय करने के लिए कि उनके डेटा लेबल दिखाए जाएँ या नहीं, [set_ShowDataLabelsOverMaximum](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichart/set_showdatalabelsovermaximum/) का उपयोग करें। यह सेटिंग केवल लेबल की दृश्यता बदलती है; यह अक्ष की सीमा या मूल डेटा मानों को नहीं बदलती।

नीचे दिया गया उदाहरण 60 और 120 मानों के साथ 2D क्लस्टर्ड कॉलम चार्ट बनाता है। यह लम्बवत अक्ष पर [set_IsAutomaticMaxValue](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/iaxis/set_isautomaticmaxvalue/) को `false` और [set_MaxValue](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/iaxis/set_maxvalue/) को 100 सेट करता है। पहली स्लाइड अधिकतम से परे लेबल को अनुमति देती है; उसकी एक कॉपी इन्हें निष्क्रिय करती है। दोनों स्लाइडें `DataLabelsOverMaximum.pptx` में सहेजी जाती हैं।

मूल्य लेबल को सक्षम करने के लिए [set_ShowValue](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/idatalabelformat/set_showvalue/) का उपयोग करें। चार्ट‑स्तर की यह सेटिंग अकेले मूल्य प्रदर्शन को सक्रिय नहीं करती और न ही व्यक्तिगत लेबल के निष्क्रिय किए गए मूल्य प्रदर्शन को अधिरोहित करती है। यह उदाहरण संपूर्ण श्रृंखला के लिए मान सक्षम करता है और [set_Position](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/idatalabelformat/set_position/) का उपयोग करके लेबल को प्रत्येक स्तंभ के बाहर के अंत में रखता है।

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

निम्न चित्र Microsoft PowerPoint द्वारा रेंडर किए गए सहेजे गए स्लाइडों को दर्शाते हैं। `true` होने पर लेबल **120** ऊपरी सीमा पर दिखाई देता है; `false` होने पर वह छिपा रहता है। लेबल **60** दृश्यमान रहता है, अक्ष अधिकतम **100** पर बना रहता है, और दूसरा डेटा बिंदु दोनों स्थितियों में **120** ही रहता है।

| ShowDataLabelsOverMaximum = true | ShowDataLabelsOverMaximum = false |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
यह उदाहरण मान अक्ष वाले 2D कॉलम चार्ट का उपयोग करता है। पाई और डोनट चार्ट जैसी मान‑अक्ष के बिना वाली चार्टों में इस प्रकार की अक्ष अधिकतम सीमा नहीं होती।
{{% /alert %}}

## **अक्ष से लेबल की दूरी सेट करें**

[set_LabelOffset](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/iaxis/set_labeloffset/) का उपयोग करके वर्ग अक्ष लेबल और अक्ष के बीच की दूरी नियंत्रित करें। मान अक्ष लेबल की अधिकतम फ़ॉन्ट आकार का प्रतिशत होता है। यह उदाहरण क्लस्टर्ड कॉलम चार्ट बनाता है और क्षैतिज अक्ष लेबल ऑफ़सेट को 500 सेट करता है। यह सेटिंग वर्ग अक्ष लेबल को प्रभावित करती है, न कि व्यक्तिगत डेटा बिंदुओं से जुड़े लेबल को।

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

## **लेबल स्थान समायोजित करें**

पाई चार्ट पर डेटा लेबल स्थितियों को समायोजित करके स्पेसिंग बेहतर करें और लीडर लाइनों के लिए जगह बनाएं।

यह उदाहरण पहले डेटा बिंदु का मान प्रदर्शित करता है, उसका लेबल स्लाइस के बाहर रखता है, और [set_X](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ilayoutable/set_x/) तथा [set_Y](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ilayoutable/set_y/) का उपयोग करके उसके ऑफ़सेट को समायोजित करता है। ये ऑफ़सेट क्रमशः चार्ट की चौड़ाई और ऊँचाई के संबंध में होते हैं।

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

![समायोजित डेटा लेबल स्थिति वाला पाई चार्ट](pie-chart-adjusted-label.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं घने चार्टों में डेटा लेबल के ओवरलैप को कैसे रोक सकता हूँ?**

स्वचालित लेबल प्लेसमेंट, लीडर लाइन्स, और फ़ॉन्ट आकार को कम करके संयोजन करें; आवश्यक होने पर कुछ फ़ील्ड (जैसे वर्ग) को छिपाएँ या केवल अत्यधिक मान या प्रमुख बिंदुओं के लिए लेबल दिखाएँ।

**मैं केवल शून्य, नकारात्मक या खाली मानों के लिए लेबल कैसे निष्क्रिय करूँ?**

लेबल सक्षम करने से पहले डेटा बिंदुओं को फ़िल्टर करें और 0, नकारात्मक मान या अनुपलब्ध मानों के लिए प्रदर्शन बंद करें, जिसे एक परिभाषित नियम के अनुसार लागू किया जा सकता है।

**PDF/छवि निर्यात करते समय लेबल शैली को सुसंगत कैसे बनाए रखें?**

फ़ॉन्ट परिवार और आकार को स्पष्ट रूप से सेट करें और यह सुनिश्चित करें कि रेंडरिंग वातावरण में फ़ॉन्ट उपलब्ध है, ताकि फ़ॉलबैक से बचा जा सके।