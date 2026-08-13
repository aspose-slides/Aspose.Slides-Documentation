---
title: C++ में प्रस्तुतियों में चार्ट डेटा श्रृंखला का प्रबंधन
linktitle: डेटा श्रृंखला
type: docs
url: /hi/cpp/chart-series/
keywords:
- चार्ट श्रृंखला
- श्रृंखला ओवरलैप
- श्रृंखला रंग
- श्रेणी रंग
- श्रृंखला नाम
- डेटा पॉइंट
- श्रृंखला गैप
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "C++ के साथ प्रस्तुतियों में चार्ट श्रृंखला, डेटा पॉइंट, वर्कबुक सेल, फॉर्मेटिंग, ओवरलैप, गैप चौड़ाई और नकारात्मक मानों का प्रबंधन कैसे करें।"
---
## **परिचय**

एक चार्ट अपने प्लॉट किए गए डेटा को चार्ट डेटा वर्कबुक में संग्रहीत करता है। एक [IChartSeries](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartseries/) एक संबंधित मानों के सेट का प्रतिनिधित्व करता है, और श्रृंखला में प्रत्येक [IChartDataPoint](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdatapoint/) एक या अधिक वर्कबुक सेल्स को संदर्भित करता है। [IChartCategory](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartcategory/) ऑब्जेक्ट्स लेबल या समूह मान प्रदान करते हैं जो श्रृंखला द्वारा साझा किए जाते हैं। इसलिए श्रृंखला का नाम, श्रेणियां, और पॉइंट मान [IChartDataCell](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdatacell/) ऑब्जेक्ट्स से जुड़े होते हैं, न कि केवल प्रदर्शन टेक्स्ट के रूप में संग्रहीत होते हैं।

एक सामान्य कैटेगरी चार्ट के लिए, डिफ़ॉल्ट वर्कबुक श्रृंखला नामों के लिए पंक्ति 0, श्रेणी नामों के लिए स्तम्भ 0, और शेष सेल्स श्रृंखला मानों के लिए उपयोग करता है। वर्कशीट, पंक्ति, और स्तम्भ सूचकांक जो [IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) को पास किए जाते हैं, शून्य-आधारित होते हैं। यह लेआउट तब उपयोगी होता है जब आप डिफ़ॉल्ट डेटा के साथ एक चार्ट बनाते हैं, लेकिन यह न मानें कि हर मौजूदा चार्ट इसका उपयोग करता है। लोडेड प्रेजेंटेशन के लिए, वर्कबुक मान बदलने से पहले श्रृंखला, श्रेणियों और डेटा पॉइंट्स द्वारा संदर्भित सेल्स की जाँच करें।

चार्ट सेटिंग्स के तीन अलग-अलग दायरे होते हैं:

- सीरीज़-स्तर की सेटिंग्स, जैसे [IChartSeries::get_Format](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartseries/get_format/), एक श्रृंखला में सभी पॉइंट्स के लिए डिफ़ॉल्ट रूप प्रदान करती हैं।
- डेटा-पॉइंट सेटिंग्स, जैसे [IChartDataPoint::get_Format](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdatapoint/get_format/), एक पॉइंट के लिए श्रृंखला की उपस्थिति को ओवरराइड करती हैं।
- ग्रुप सेटिंग्स उन संगत श्रृंखलाओं पर लागू होती हैं जो एक ही [IChartSeriesGroup](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartseriesgroup/) से संबंधित हैं। जब आपको ओवरलैप या गैप चौड़ाई जैसे विकल्प सेट करने की आवश्यकता हो, तो समूह तक पहुँचें [IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/) के माध्यम से।

जब कोई स्पष्ट पॉइंट या सीरीज़ फ़िल सेट नहीं किया जाता, तो चार्ट शैली और थीम स्वचालित रूप को निर्धारित करती हैं। जब दोनों सीरीज़ और पॉइंट फ़ॉर्मेटिंग मौजूद हो, तो उस पॉइंट के लिए पॉइंट फ़ॉर्मेटिंग प्राथमिकता लेती है।

![चार्ट-श्रृंखला-पावरपॉइंट](chart-series-powerpoint.png)

## **चार्ट श्रृंखला ओवरलैप सेट करें**

[IChartSeries::get_Overlap](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartseries/get_overlap/) रिपोर्ट करता है कि 2D चार्ट में बार या कॉलम कितने प्रतिशत (-100 से 100 प्रतिशत) ओवरलैप करते हैं। यह पैरेंट सीरीज़ ग्रुप पर सेटिंग का केवल-रिड-ऑनली प्रोजेक्शन है। उस ग्रुप में सभी संगत श्रृंखलाओं को अपडेट करने के लिए [IChartSeriesGroup::set_Overlap](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartseriesgroup/set_overlap/) को कॉल करें। यह विकल्प उन चार्ट प्रकारों पर लागू होता है जो समूहित बार या कॉलम दिखाते हैं; यह संयोजन चार्ट में असंबंधित श्रृंखला समूहों को प्रभावित नहीं करता है।

निम्न उदाहरण उस समूह के लिए ओवरलैप सेट करता है जिसमें पहली श्रृंखला शामिल है:

```cpp
#include <cstdint>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int8_t overlapPercent = 30;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

// नया चार्ट नमूना श्रृंखलाएँ, श्रेणियाँ और मान शामिल करता है।
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
series->get_ParentSeriesGroup()->set_Overlap(overlapPercent);

presentation->Save(u"series_overlap.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![श्रृंखला ओवरलैप](series_overlap.png)

## **श्रृंखला फ़िल रंग बदलें**

एक पूरी श्रृंखला के लिए डिफ़ॉल्ट फ़िल सेट करने के लिए [IChartSeries::get_Format](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartseries/get_format/) उपयोग करें। यदि किसी पॉइंट का फ़िल पहले से स्पष्ट रूप से सेट है, तो उसका [IChartDataPoint::get_Format](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdatapoint/get_format/) सेटिंग उस पॉइंट के लिए श्रृंखला फ़िल को ओवरराइड करती है।

निम्न उदाहरण पहली श्रृंखला पर ठोस नीला फ़िल लागू करता है:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::FillType;
using Aspose::Slides::Presentation;
using System::Drawing::Color;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
auto seriesColor = Color::get_Blue();
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(seriesColor);

presentation->Save(u"series_color.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![श्रृंखला का रंग](series_color.png)

## **श्रृंखला का नाम बदलें**

एक श्रृंखला का नाम चार्ट डेटा वर्कबुक में संग्रहीत होता है और सामान्यतः लीजेंड में दिखाया जाता है। क्लस्टर्ड कॉलम चार्ट के लिए निर्मित डिफ़ॉल्ट वर्कबुक में, सेल B1 पंक्ति 0, स्तम्भ 1 पर होता है और पहली श्रृंखला का नाम रखता है। निम्न उदाहरण में नामित स्थिरांक उस संरचना को स्पष्ट बनाते हैं:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::ObjectExt;
using System::String;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int seriesNameRowIndex = 0;
const int firstSeriesColumnIndex = 1;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto seriesNameCell = workbook->GetCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
auto seriesName = ObjectExt::Box<String>(u"Revenue");
seriesNameCell->set_Value(seriesName);

presentation->Save(u"series_name.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

आप [IChartSeries::get_Name](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartseries/get_name/) द्वारा पहले से संदर्भित सेल को भी अपडेट कर सकते हैं। यह तरीका मौजूदा चार्ट में किसी विशिष्ट पंक्ति और स्तम्भ मानने से बचाता है:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCellCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IStringChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::ObjectExt;
using System::String;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int firstNameCellIndex = 0;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
auto seriesNameCells = series->get_Name()->get_AsCells();
auto seriesNameCell = seriesNameCells->idx_get(firstNameCellIndex);
auto seriesName = ObjectExt::Box<String>(u"Revenue");
seriesNameCell->set_Value(seriesName);

presentation->Save(u"series_name.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![श्रृंखला का नाम](series_name.png)

## **स्वचालित श्रृंखला फ़िल रंग प्राप्त करें**

[IChartSeries::GetAutomaticSeriesColor](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartseries/getautomaticseriescolor/) श्रृंखला इंडेक्स और चार्ट शैली से गणना किया गया रंग लौटाता है। यह वह रंग है जो तब उपयोग होता है जब श्रृंखला फ़िल स्पष्ट रूप से निर्धारित नहीं है। इस मेथड को कॉल करने से गणना किया गया रंग पढ़ा जाता है; यह नया फ़िल असाइन नहीं करता।

निम्न उदाहरण प्रत्येक डिफ़ॉल्ट श्रृंखला का स्वचालित रंग प्रिंट करता है:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Presentation;
using System::Console;
using System::String;

const int firstSlideIndex = 0;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
const int seriesCount = seriesCollection->get_Count();
for (int seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++)
{
    auto series = seriesCollection->idx_get(seriesIndex);
    auto automaticColor = series->GetAutomaticSeriesColor();
    auto colorName = automaticColor.get_Name();
    auto outputLine = String::Format(u"Series {0}: {1}", seriesIndex, colorName);
    Console::WriteLine(outputLine);
}

presentation->Dispose();
```

डिफ़ॉल्ट चार्ट शैली के लिए उदाहरण आउटपुट:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

सटीक रंग चार्ट शैली और थीम पर निर्भर करते हैं।

## **चार्ट श्रृंखला के लिए इनवर्ट फ़िल रंग सेट करें**

बार, कॉलम, और बबल श्रृंखलाओं के लिए, [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) नकारात्मक मानों को अलग फ़िल के साथ दिखा सकता है। नियमित श्रृंखला फ़िल को ठोस सेट करें, इनवर्ज़न सक्षम करें, और नकारात्मक मान का रंग [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/) के माध्यम से असाइन करें। नकारात्मक संख्याएं वर्कबुक में अपरिवर्तित रहती हैं; केवल उनका डिस्प्ले रंग बदलता है।

निम्न उदाहरण डिफ़ॉल्ट चार्ट डेटा को एक श्रृंखला से बदलता है। वर्कशीट की पंक्ति 0 में श्रृंखला का नाम, स्तम्भ 0 में श्रेणी नाम, और स्तम्भ 1 में मान होते हैं:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::FillType;
using Aspose::Slides::Presentation;
using System::Drawing::Color;
using System::ObjectExt;
using System::String;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int headerRowIndex = 0;
const int categoryColumnIndex = 0;
const int firstSeriesColumnIndex = 1;
const int firstDataRowIndex = 1;
const int categoryCount = 3;

const String categoryNames[] = {u"Category 1", u"Category 2", u"Category 3"};
const int seriesValues[] = {-20, 50, -30};

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);
auto chartData = chart->get_ChartData();
auto workbook = chartData->get_ChartDataWorkbook();

auto seriesCollection = chartData->get_Series();
seriesCollection->Clear();
chartData->get_Categories()->Clear();

auto seriesName = ObjectExt::Box<String>(u"Series 1");
auto seriesNameCell = workbook->GetCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, seriesName);
auto chartType = chart->get_Type();
auto series = seriesCollection->Add(seriesNameCell, chartType);

for (int categoryIndex = 0; categoryIndex < categoryCount; categoryIndex++)
{
    const int dataRowIndex = firstDataRowIndex + categoryIndex;
    auto categoryName = categoryNames[categoryIndex];
    const int seriesValue = seriesValues[categoryIndex];

    auto boxedCategoryName = ObjectExt::Box<String>(categoryName);
    auto categoryCell = workbook->GetCell(worksheetIndex, dataRowIndex, categoryColumnIndex, boxedCategoryName);
    chartData->get_Categories()->Add(categoryCell);

    auto boxedSeriesValue = ObjectExt::Box<int>(seriesValue);
    auto valueCell = workbook->GetCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, boxedSeriesValue);
    series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
}

auto automaticSeriesColor = series->GetAutomaticSeriesColor();
auto invertedSeriesColor = Color::get_Red();
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(automaticSeriesColor);
series->set_InvertIfNegative(true);
series->get_InvertedSolidFillColor()->set_Color(invertedSeriesColor);

presentation->Save(u"inverted_solid_fill_color.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![इनवर्टेड ठोस फ़िल रंग](inverted_solid_fill_color.png)

आप [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/) के माध्यम से एक पॉइंट के लिए इनवर्ज़न सक्षम कर सकते हैं। निम्न उदाहरण में, श्रृंखला के लिए इनवर्ज़न अक्षम किया गया है और केवल चयनित पॉइंट के लिए सक्षम किया गया है। पॉइंट को नकारात्मक मान भी असाइन किया गया है ताकि प्रभाव दिखाई दे:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::FillType;
using Aspose::Slides::Presentation;
using System::Drawing::Color;
using System::ObjectExt;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 2;
const int negativeValue = -30;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
auto automaticSeriesColor = series->GetAutomaticSeriesColor();
auto invertedSeriesColor = Color::get_Red();
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(automaticSeriesColor);
series->get_InvertedSolidFillColor()->set_Color(invertedSeriesColor);
series->set_InvertIfNegative(false);

auto dataPoint = series->get_DataPoint(targetDataPointIndex);
auto boxedNegativeValue = ObjectExt::Box<int>(negativeValue);
dataPoint->get_YValue()->get_AsCell()->set_Value(boxedNegativeValue);
dataPoint->set_InvertIfNegative(true);

presentation->Save(u"data_point_invert_color_if_negative.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **विशिष्ट डेटा पॉइंट मान साफ़ करें**

एक पॉइंट को अन्य पॉइंट्स को हटाए बिना खाली बनाने के लिए, उसकी बैकिंग वर्कबुक सेल को `nullptr` सेट करें। कॉलम चार्ट के लिए, प्लॉट किया गया मान [IChartDataPoint::get_YValue](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdatapoint/get_yvalue/) के माध्यम से उपलब्ध है। डेटा पॉइंट वही श्रेणी स्थिति पर रहता है, लेकिन चार्ट उसकी मान को चार्ट की ब्लैंक-वैल्यू सेटिंग्स के अनुसार खाली मानता है।

निम्न उदाहरण पहली श्रृंखला के केवल दूसरे पॉइंट को साफ़ करता है:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 1;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
auto dataPoint = series->get_DataPoint(targetDataPointIndex);
dataPoint->get_YValue()->get_AsCell()->set_Value(nullptr);

presentation->Save(u"clear_data_point_value.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

स्कैटर चार्ट अलग-अलग X और Y सेल्स का उपयोग करते हैं, और बबल चार्ट एक साइज सेल भी उपयोग करता है। केवल उस सेल को साफ़ करें जो उस मान को दर्शाती है जिसे आप हटाना चाहते हैं। जब आप अन्य पॉइंट्स को रखना चाहते हैं, तो [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) को कॉल न करें, क्योंकि यह मेथड संग्रह से सभी डेटा पॉइंट्स हटा देता है।

## **श्रृंखला गैप चौड़ाई सेट करें**

गैप चौड़ाई बार या कॉलम क्लस्टर्स के बीच की दूरी है, जिसे बार या कॉलम की चौड़ाई के प्रतिशत में व्यक्त किया जाता है। ओवरलैप की तरह, यह एक श्रृंखला की बजाय पैरेंट श्रृंखला समूह से संबंधित है। समूह के लिए एक बार [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) को कॉल करें। बड़ी मूल्य क्लस्टर्स के बीच अधिक जगह बनाती है; छोटी मूल्य उन्हें अधिक घना बनाती है।

निम्न उदाहरण गैप चौड़ाई बदलता है और केवल अंतिम प्रेज़ेंटेशन को सहेजता है:

```cpp
#include <cstdint>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const uint16_t gapWidthPercent = 30;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
series->get_ParentSeriesGroup()->set_GapWidth(gapWidthPercent);

presentation->Save(u"gap_width_30.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![गैप चौड़ाई](gap_width.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**कौन से चार्ट प्रकार डेटा श्रृंखलाओं का समर्थन करते हैं?**

सभी चार्ट प्रकार जो [ChartType](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/charttype/) enumeration द्वारा दर्शाए गए हैं, चार्ट डेटा का उपयोग करते हैं, लेकिन उनकी श्रृंखलाओं की मान संरचना या सेटिंग्स समान नहीं होती। उदाहरण के लिए, कैटेगरी चार्ट श्रेणियां और मान उपयोग करते हैं, स्कैटर चार्ट X और Y मान उपयोग करते हैं, और बबल चार्ट बबल साइज जोड़ते हैं। श्रृंखला प्रकार से मेल खाने वाले डेटा-पॉइंट निर्माण मेथड का उपयोग करें। ओवरलैप और गैप चौड़ाई जैसे विकल्प केवल संगत बार या कॉलम समूहों पर लागू होते हैं।

**एक चार्ट श्रृंखला समूह क्या है?**

एक [IChartSeriesGroup](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartseriesgroup/) में संगत श्रृंखलाएँ होती हैं जो समूह-स्तर की प्लॉटिंग सेटिंग्स साझा करती हैं। एक कॉम्बिनेशन चार्ट में एक से अधिक समूह हो सकते हैं, इसलिए एक श्रृंखला के माध्यम से पहुँचने वाले समूह को बदलने से जरूरी नहीं कि चार्ट की सभी श्रृंखलाएँ बदलें।

**क्या नई बनाई गई चार्ट में डिफ़ॉल्ट डेटा होता है?**

हां। डिफ़ॉल्ट रूप से, [IShapeCollection::AddChart](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishapecollection/addchart/) नमूना श्रृंखलाएँ, श्रेणियाँ और मान बनाता है। आप उन सेल्स को संपादित कर सकते हैं या पूरी तरह कस्टम डेटा सेट जोड़ने से पहले श्रृंखला और श्रेणी संग्रह दोनों को साफ़ कर सकते हैं। एक ओवरलोड भी डिफ़ॉल्ट डेटा के बिना चार्ट बना सकता है।

**चार्ट ऑब्जेक्ट्स वर्कबुक सेल्स से कैसे जुड़े होते हैं?**

श्रृंखला नाम, श्रेणी लेबल, और डेटा-पॉइंट मान एक [IChartDataWorkbook](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdataworkbook/) में सेल्स को संदर्भित करते हैं। किसी संदर्भित सेल को बदलने से संबंधित चार्ट तत्व अपडेट होता है। जब आप कस्टम डेटा बनाते हैं, तो श्रेणी पंक्तियों और श्रृंखला-मान पंक्तियों को इस तरह रखें कि प्रत्येक पॉइंट इच्छित श्रेणी के नीचे प्लॉट हो।

**पूरी श्रृंखला के बजाय एक पॉइंट को कैसे साफ़ करें?**

संबंधित मान सेल को `nullptr` सेट करें ताकि पॉइंट की श्रेणी स्थिति को खाली पॉइंट के रूप में बनाए रखा जा सके। केवल उस श्रृंखला के सभी पॉइंट्स को हटाने के लिए ही [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) को कॉल करें। यदि आप श्रेणियों को भी हटाते हैं, तो सभी श्रृंखलाओं को अपडेट करें ताकि उनके मान श्रेणी संग्रह के साथ संरेखित रहें।

**खाली पॉइंट्स कैसे दिखाए जाते हैं?**

परिणाम चार्ट प्रकार और [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichart/get_displayblanksas/) पर निर्भर करता है। समर्थित चार्ट ब्लैंक्स को गैप, शून्य मान, या पड़ोसी पॉइंट्स को जोड़कर दिखा सकते हैं। वह सेटिंग चुनें जो आपके प्रेज़ेंटेशन में गुम डेटा के अर्थ से मेल खाती हो।

**नकारात्मक मान कैसे फॉर्मेट किए जाते हैं?**

समर्थित बार, कॉलम, और बबल श्रृंखलाओं के लिए, [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) को कॉल करें और रंग को [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/) के माध्यम से सेट करें। आप [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/) के साथ व्यक्तिगत पॉइंट के व्यवहार को ओवरराइड कर सकते हैं। ये मेथड फ़ॉर्मेटिंग को प्रभावित करते हैं, न कि संग्रहीत संख्यात्मक मानों को।

**जब दोनों श्रृंखला और पॉइंट फॉर्मेटेड हों तो कौन सा फॉर्मेट जीतता है?**

स्पष्ट डेटा-पॉइंट फ़ॉर्मेटिंग उस पॉइंट के लिए प्राथमिकता लेती है। अन्य पॉइंट्स स्पष्ट श्रृंखला फ़ॉर्मेट या जब श्रृंखला फ़ॉर्मेट परिभाषित नहीं है, तो स्वचालित चार्ट शैली और थीम का उपयोग जारी रखते हैं। ग्रुप सेटिंग्स जैसे ओवरलैप और गैप चौड़ाई लेआउट को नियंत्रित करती हैं और पॉइंट-स्तर की फ़ॉर्मेटिंग ओवरराइड नहीं होतीं।

**क्या किसी चार्ट में शामिल होने वाली श्रृंखलाओं की संख्या पर कोई सीमा है?**

Aspose.Slides किसी अलग स्थिर श्रृंखला-गणना सीमा नहीं लगाता। व्यवहार में, प्रेज़ेंटेशन फ़ाइल सीमाएं, उपलब्ध मेमोरी, रेंडरिंग समय, और चार्ट पठनीयता उपयोगी सीमा निर्धारित करते हैं।

**जब कॉलम बहुत करीब या बहुत दूर हों तो क्या बदलना चाहिए?**

[IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) को उपयुक्त पैरेंट श्रृंखला समूह पर कॉल करें। क्लस्टर्स के बीच स्थान को बढ़ाने के लिए मान बढ़ाएँ, या उन्हें करीब लाने के लिए घटाएँ।