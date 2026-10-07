---
title: C++ में प्रस्तुतियों में चार्ट डेटा श्रृंखलाओं का प्रबंधन
linktitle: डेटा श्रृंखला
type: docs
url: /hi/cpp/chart-series/
keywords:
- चार्ट श्रृंखला
- श्रृंखला ओवरलैप
- श्रृंखला रंग
- श्रेणी रंग
- श्रृंखला नाम
- डेटा बिंदु
- श्रृंखला गैप
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "C++ के साथ प्रस्तुतियों में चार्ट श्रृंखलाओं, डेटा बिंदुओं, वर्कबुक कोशिकाओं, फ़ॉर्मेटिंग, ओवरलैप, गैप विथ, और नकारात्मक मानों को कैसे प्रबंधित करें, सीखें।"
---
## **अवलोकन**

एक चार्ट अपने प्लॉट किए गए डेटा को एक चार्ट डेटा वर्कबुक में संग्रहीत करता है। एक [IChartSeries](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/) संबंधित मानों का एक सेट दर्शाता है, और श्रृंखला में प्रत्येक [IChartDataPoint](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/) एक या अधिक वर्कबुक कोशिकाओं को संदर्भित करता है। [IChartCategory](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartcategory/) वस्तुएँ लेबल या समूह मूल्यों को प्रदान करती हैं जो श्रृंखला द्वारा साझा किए जाते हैं। इस कारण श्रृंखला का नाम, श्रेणियाँ, और बिंदु मान [IChartDataCell](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/) वस्तुओं से जुड़े होते हैं, न कि केवल डिस्प्ले पाठ के रूप में संग्रहीत होते हैं।

एक सामान्य श्रेणी चार्ट के लिए, डिफ़ॉल्ट वर्कबुक क्रमांक 0 पंक्ति को श्रृंखला नामों के लिए, क्रमांक 0 स्तंभ को श्रेणी नामों के लिए, और शेष कोशिकाओं को श्रृंखला मानों के लिए उपयोग करती है। वर्कशीट, पंक्ति, और स्तंभ अनुक्रमांक जो [IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) को पास किए जाते हैं शून्य‑आधारित होते हैं। यह लेआउट तब उपयोगी होता है जब आप डिफ़ॉल्ट डेटा के साथ एक चार्ट बनाते हैं, लेकिन यह मान लेना सही नहीं है कि हर मौजूदा चार्ट इसका उपयोग करता है। लोड किए गए प्रेज़ेंटेशन के लिए, वर्कबुक मान बदलने से पहले श्रृंखला, श्रेणियों और डेटा पॉइंट्स द्वारा संदर्भित कोशिकाओं की जाँच करें।

चार्ट सेटिंग्स के तीन अलग-अलग स्तर होते हैं:

- श्रृंखला‑स्तर की सेटिंग्स, जैसे [IChartSeries::get_Format](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_format/), एक श्रृंखला के सभी पॉइंट्स के लिए डिफ़ॉल्ट रूप प्रदान करती हैं।
- डेटा‑पॉइंट सेटिंग्स, जैसे [IChartDataPoint::get_Format](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_format/), एक पॉइंट के लिए श्रृंखला की उपस्थिति को ओवरराइड करती हैं।
- समूह सेटिंग्स उन संगत श्रृंखलाओं पर लागू होती हैं जो एक ही [IChartSeriesGroup](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/) से संबंधित होती हैं। जब आपको ओवरलैप या गैप विथ जैसे विकल्प सेट करने की आवश्यकता हो तो [IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/) के माध्यम से समूह तक पहुँचें।

यदि कोई स्पष्ट पॉइंट या श्रृंखला फ़िल सेट नहीं किया गया है, तो चार्ट स्टाइल और थीम स्वतः दृश्य निर्धारित करती हैं। यदि श्रृंखला और पॉइंट दोनों का फ़ॉर्मेट मौजूद है, तो उस पॉइंट के लिए पॉइंट फ़ॉर्मेट को प्राथमिकता दी जाती है।

![chart-series-powerpoint](chart-series-powerpoint.png)

## **चार्ट श्रृंखला ओवरलैप सेट करें**

[IChartSeries::get_Overlap](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_overlap/) 2D चार्ट में बार या कॉलम के ओवरलैप की मात्रा -100 से 100 प्रतिशत तक रिपोर्ट करता है। यह पैरेंट श्रृंखला समूह पर सेटिंग का केवल‑पढ़ने योग्य प्रक्षेपण है। उस समूह में सभी संगत श्रृंखलाओं को अपडेट करने के लिए [IChartSeriesGroup::set_Overlap](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_overlap/) को कॉल करें। यह विकल्प उन चार्ट प्रकारों पर लागू होता है जो समूहित बार या कॉलम दिखाते हैं; यह संयोजन चार्ट में असंबंधित श्रृंखला समूहों को प्रभावित नहीं करता।

निम्न उदाहरण पहली श्रृंखला को सम्मिलित करने वाले समूह के लिए ओवरलैप सेट करता है:

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

// नई चार्ट में नमूना श्रृंखलाएँ, श्रेणियाँ और मान होते हैं।
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
series->get_ParentSeriesGroup()->set_Overlap(overlapPercent);

presentation->Save(u"series_overlap.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![The series overlap](series_overlap.png)

## **श्रृंखला फ़िल रंग बदलें**

डिफ़ॉल्ट फ़िल सेट करने के लिए पूरे श्रृंखला के लिए [IChartSeries::get_Format](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_format/) का उपयोग करें। यदि किसी पॉइंट का फ़िल पहले से स्पष्ट रूप से सेट है, तो उसका [IChartDataPoint::get_Format](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_format/) सेटिंग उस पॉइंट के लिए श्रृंखला फ़िल को ओवरराइड करती है।

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

![The color of the series](series_color.png)

## **श्रृंखला का नाम बदलें**

श्रृंखला का नाम चार्ट डेटा वर्कबुक में संग्रहीत होता है और आमतौर पर लेजेंड में प्रदर्शित होता है। क्लस्टर्ड कॉलम चार्ट के लिए डिफ़ॉल्ट वर्कबुक में, कोशिका B1 पंक्ति 0, स्तंभ 1 पर स्थित है और पहली श्रृंखला का नाम रखती है। निम्न उदाहरण में नामांकित स्थिरांक इस संरचना को स्पष्ट रूप से दर्शाते हैं:

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

आप [IChartSeries::get_Name](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_name/) द्वारा पहले से संदर्भित कोशिका को भी अपडेट कर सकते हैं। यह तरीका मौजूदा चार्ट में किसी विशेष पंक्ति या स्तंभ को मानने से बचता है:

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

![The series name](series_name.png)

### **कई कोशिकाओं से बना नाम वाली श्रृंखला बनाएं**

जब उत्पाद का नाम और रिपोर्टिंग अवधि अलग-अलग वर्कबुक कोशिकाओं में संग्रहीत हों तो युक्तिशील नाम उपयोगी होता है। उदाहरण के लिए, आप `Product A` (कोशिका B1) और `2026` (कोशिका C1) को मिलाकर एक ही श्रृंखला नाम बना सकते हैं, जबकि दोनों भागों को उनके स्रोत कोशिकाओं से जुड़ा रख सकते हैं।

नाम रेंज प्राप्त करने के लिए [IChartDataWorkbook::GetCellCollection](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/getcellcollection/) का उपयोग करें, फिर वह कलेक्शन [IChartSeriesCollection::Add](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriescollection/add/) को पास करें। `skipHiddenCells` तर्क निर्धारित करता है कि छुपी हुई कोशिकाएँ शामिल हों या नहीं: `true` उन्हें बाहर रखता है, जबकि `false` शामिल करता है। यह उदाहरण `false` का उपयोग करता है ताकि नाम रेंज की सभी कोशिकाएँ शामिल हों।

निम्न उदाहरण एक प्रस्तुति बनाता है जिसमें एक श्रृंखला और दो डेटा पॉइंट्स होते हैं। कोशिका B1:C1 केवल श्रृंखला नाम प्रदान करती हैं; A2:A3 श्रेणी लेबल देती हैं, और B2:B3 संख्यात्मक मान देती हैं।

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartCellCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using System::ObjectExt;
using System::String;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 620.0f, 180.0f);
auto chartData = chart->get_ChartData();

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();
chart->set_HasLegend(true);

auto workbook = chartData->get_ChartDataWorkbook();
workbook->Clear(0);

// ये दो कोशिकाएँ श्रृंखला का नाम प्रदान करती हैं.
auto productName = ObjectExt::Box<String>(u"Product A");
auto reportingPeriod = ObjectExt::Box<String>(u"2026");
workbook->GetCell(0, 0, 1, productName);
workbook->GetCell(0, 0, 2, reportingPeriod);
auto nameCells = workbook->GetCellCollection(u"Sheet1!$B$1:$C$1", false);
auto series = chartData->get_Series()->Add(nameCells, ChartType::ClusteredColumn);

// अलग-अलग कोशिकाएँ श्रेणियाँ और संख्यात्मक डेटा पॉइंट्स प्रदान करती हैं.
auto northLabel = ObjectExt::Box<String>(u"North");
auto southLabel = ObjectExt::Box<String>(u"South");
auto northCategory = workbook->GetCell(0, 1, 0, northLabel);
auto southCategory = workbook->GetCell(0, 2, 0, southLabel);
chartData->get_Categories()->Add(northCategory);
chartData->get_Categories()->Add(southCategory);
auto northAmount = ObjectExt::Box<int>(120);
auto southAmount = ObjectExt::Box<int>(150);
auto northValue = workbook->GetCell(0, 1, 1, northAmount);
auto southValue = workbook->GetCell(0, 2, 1, southAmount);
series->get_DataPoints()->AddDataPointForBarSeries(northValue);
series->get_DataPoints()->AddDataPointForBarSeries(southValue);

presentation->Save(u"composite_series_name.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणामी श्रृंखला नाम `Product A 2026` है, दो कोशिका मानों के बीच एक स्पेस के साथ। लेजेंड इसे दोनों स्तंभों के लिए एक प्रविष्टि के रूप में दर्शाता है। नीचे चित्र परिणाम को दिखाता है:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **स्वचालित श्रृंखला फ़िल रंग प्राप्त करें**

[IChartSeries::GetAutomaticSeriesColor](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/getautomaticseriescolor/) श्रृंखला इंडेक्स और चार्ट स्टाइल से गणना किया हुआ रंग लौटाता है। यह वह रंग है जिसका उपयोग तब किया जाता है जब श्रृंखला फ़िल स्पष्ट रूप से परिभाषित नहीं किया गया हो। यह विधि गणना किया हुआ रंग पढ़ती है; यह नया फ़िल असाइन नहीं करती।

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

डिफ़ॉल्ट चार्ट स्टाइल के लिए उदाहरण आउटपुट:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

सटीक रंग चार्ट स्टाइल और थीम पर निर्भर होते हैं।

## **एक चार्ट श्रृंखला के लिए इनवर्ट फ़िल रंग सेट करें**

बार, कॉलम और बबल श्रृंखलाओं के लिए, [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) नकारात्मक मानों को भिन्न फ़िल से प्रदर्शित कर सकता है। नियमित श्रृंखला फ़िल को ठोस सेट करें, इनवर्ज़न सक्षम करें, और नकारात्मक‑मान रंग को [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/) के माध्यम से असाइन करें। नकारात्मक संख्याएँ वर्कबुक में अपरिवर्तित रहती हैं; केवल उनका प्रदर्शित रंग बदलता है।

निम्न उदाहरण डिफ़ॉल्ट चार्ट डेटा को एक श्रृंखला से बदलता है। पंक्ति 0 में श्रृंखला नाम, स्तंभ 0 में श्रेणी नाम, और स्तंभ 1 में मान होते हैं:

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

![The inverted solid fill color](inverted_solid_fill_color.png)

आप [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/) के माध्यम से केवल एक पॉइंट के लिए इनवर्ज़न सक्षम कर सकते हैं। निम्न उदाहरण में श्रृंखला के लिए इनवर्ज़न निष्क्रिय है और केवल चयनित पॉइंट के लिए सक्रिय किया गया है। वह पॉइंट नकारात्मक मान भी रखता है ताकि प्रभाव दिखाई दे:

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

## **किसी विशिष्ट डेटा पॉइंट मान को साफ़ करें**

किसी पॉइंट को खाली बनाने के लिए, उसके बैकिंग वर्कबुक सेल को `nullptr` सेट करें, बिना अन्य पॉइंट्स को हटाए। कॉलम चार्ट के लिए, प्लॉटेड मान [IChartDataPoint::get_YValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_yvalue/) के माध्यम से उपलब्ध है। डेटा पॉइंट समान श्रेणी स्थिति पर बना रहता है, लेकिन चार्ट उसकी मान को ब्लैंक के अनुसार मानता है।

निम्न उदाहरण पहली श्रृंखला में केवल दूसरे पॉइंट को साफ़ करता है:

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

स्कैटर चार्ट अलग‑अलग X और Y कोशिकाओं का उपयोग करते हैं, और बबल चार्ट में आकार की भी कोशिका होती है। केवल वह सेल साफ़ करें जो आप हटाना चाहते हैं। जब आप अन्य पॉइंट्स को रखना चाहते हैं, तो [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) को कॉल न करें, क्योंकि यह मेथड संपूर्ण श्रृंखला को हटा देता है।

## **खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें**

छिपी हुई कोशिकाएँ जो मान रखती हैं, खाली कोशिकाओं से अलग मानी जाती हैं। छिपी हुई पंक्तियों और स्तंभों से डेटा को शामिल या बाहर करने के लिए देखें [Include Data from Hidden Rows and Columns](/slides/hi/cpp/chart-workbook/#include-data-from-hidden-rows-and-columns)।

एक खाली वर्कबुक सेल लापता डेटा दर्शाता है; `0` वाली कोशिका ज्ञात संख्यात्मक मान दर्शाती है। किसी सेल को खाली बनाने के लिए [IChartDataCell::set_Value](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/set_value/) को `nullptr` के साथ कॉल करें। शून्य मान ब्लैंक‑सेल सेटिंग चाहे जो भी हो, शून्य बना रहता है।

खाली कोशिकाओं के प्रदर्शन को चुनने के लिए [IChart::set_DisplayBlanksAs](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_displayblanksas/) का प्रयोग करें। यह सेटिंग पूरे चार्ट पर लागू होती है और ब्लैंक्स को प्लॉट करने के तरीके को बदलती है, बिना खाली वर्कबुक सेल को शून्य या इंटरपोलेटेड मान से भरने के।

निम्न स्वतंत्र उदाहरण एक लाइन चार्ट बनाता है जिसमें एक श्रृंखला है, दिन 3 का मान साफ़ करता है, और प्रत्येक मोड के साथ वही चार्ट सहेजता है। कोई इनपुट फ़ाइल आवश्यक नहीं है। [IChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/) कार्यपत्रक 0, स्तंभ 0 को श्रेणी लेबल और स्तंभ 1 को मान के लिए उपयोग करता है; पंक्ति 0 में श्रृंखला नाम रहता है। अंतिम डेटा `10, 20, empty, 30, 40` है।

```cpp
#include <array>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/DisplayBlanksAsType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using System::ObjectExt;
using System::String;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::LineWithMarkers, 40.0f, 40.0f, 640.0f, 400.0f);
auto chartData = chart->get_ChartData();
auto workbook = chartData->get_ChartDataWorkbook();

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();

auto seriesName = ObjectExt::Box<String>(u"Measurements");
auto seriesNameCell = workbook->GetCell(0, 0, 1, seriesName);
auto series = chartData->get_Series()->Add(seriesNameCell, chart->get_Type());
auto values = std::array<int, 5>{10, 20, 25, 30, 40};

for (auto i = 0; i < values.size(); i++)
{
    auto categoryName = String::Format(u"Day {0}", i + 1);
    auto boxedCategoryName = ObjectExt::Box<String>(categoryName);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, boxedCategoryName);
    chartData->get_Categories()->Add(categoryCell);
    auto boxedValue = ObjectExt::Box<int>(values[i]);
    auto valueCell = workbook->GetCell(0, i + 1, 1, boxedValue);
    series->get_DataPoints()->AddDataPointForLineSeries(valueCell);
}

// Leave Day 3 genuinely empty, while retaining its category and data point.
workbook->GetCell(0, 3, 1)->set_Value(nullptr);

auto modes = std::array<DisplayBlanksAsType, 3>{DisplayBlanksAsType::Gap, DisplayBlanksAsType::Zero, DisplayBlanksAsType::Span};
for (auto mode : modes)
{
    chart->set_DisplayBlanksAs(mode);
    auto outputPath = String::Format(u"empty_cells_{0}.pptx", mode);
    presentation->Save(outputPath, SaveFormat::Pptx);
}

presentation->Dispose();
```

प्रत्येक आउटपुट फ़ाइल में सहेजने से पहले सेट किया गया मोड शामिल होता है: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, और `empty_cells_Span.pptx`। केवल एक संस्करण सहेजने के लिए इच्छित मोड असाइन करें और प्रस्तुति को एक बार सहेजें।

नीचे तुलना दिखाती है कि सभी तीन फ़ाइलों में समान डेटा कैसे दिखता है। दिन 3 सभी मामलों में वर्कबुक में खाली है:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

दिखाया गया प्रभाव चार्ट प्रकार पर निर्भर करता है। लाइन चार्ट सभी तीन मोड को आसानी से तुलना करने देता है। बार और कॉलम चार्ट में गायब श्रेणी के ऊपर जोड़ने के लिए लाइन नहीं होती, इसलिए `Span` वह कनेक्टिंग सेगमेंट नहीं बना पाता; एक गायब कॉलम और शून्य‑ऊँचाई वाला कॉलम भी समान दिख सकते हैं। इसी प्रकार, मार्कर्स वाले स्कैटर चार्ट में कोई कनेक्टिंग लाइन नहीं होती। सभी चार्ट प्रकारों में तीन अलग‑अलग परिणाम की अपेक्षा न रखें; अपने उपयोग के प्रकार के लिए आउटपुट जाँचें।

## **श्रृंखला गैप विथ सेट करें**

गैप विथ पड़ोसी बार या कॉलम क्लस्टर के बीच की दूरी को दर्शाता है, जो बार या कॉलम की चौड़ाई के प्रतिशत में व्यक्त किया जाता है। ओवरलैप की तरह, यह पैरेंट श्रृंखला समूह से संबंधित है, न कि व्यक्तिगत श्रृंखला से। समूह के लिये एक बार [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) को कॉल करें। बड़ा मान क्लस्टर के बीच अधिक दूरी बनाता है; छोटा मान उन्हें घना करता है।

निम्न उदाहरण गैप विथ बदलता है और केवल अंतिम प्रस्तुति को सहेजता है:

```cpp
#include <cstdint>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <DOM/IChart>
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

![The gap width](gap_width.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**कौन से चार्ट प्रकार डेटा श्रृंखला का समर्थन करते हैं?**

[ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) एनीमेरेशन द्वारा प्रतिनिधित्व किए गए सभी चार्ट प्रकार डेटा उपयोग करते हैं, लेकिन उनकी श्रृंखला की मूल्य संरचना या सेटिंग्स समान नहीं होती। उदाहरण के लिए, श्रेणी चार्ट श्रेणियों और मानों का उपयोग करते हैं, स्कैटर चार्ट X और Y मान, तथा बबल चार्ट बबल आकार जोड़ते हैं। डेटा‑पॉइंट निर्माण विधि का उपयोग करें जो श्रृंखला प्रकार से मेल खाती हो। ओवरलैप और गैप विथ जैसी सेटिंग्स केवल संगत बार या कॉलम समूहों पर लागू होती हैं।

**एक चार्ट श्रृंखला समूह क्या है?**

[IChartSeriesGroup](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/) संगत श्रृंखलाओं को सम्मिलित करता है जो समूह‑स्तर की प्लॉटिंग सेटिंग्स साझा करती हैं। संयोजन चार्ट में एक से अधिक समूह हो सकते हैं, इसलिए एक श्रृंखला के माध्यम से पहुँचा गया समूह बदलना आवश्यक नहीं कि चार्ट की सभी श्रृंखलाओं को बदल दे।

**क्या नई बनाई गई चार्ट में डिफ़ॉल्ट डेटा होता है?**

हां। डिफ़ॉल्ट रूप से, [IShapeCollection::AddChart](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addchart/) नमूना श्रृंखलाएं, श्रेणियां और मान बनाता है। आप उन कोशिकाओं को संपादित कर सकते हैं या पूरी तरह कस्टम डेटा सेट जोड़ने से पहले श्रृंखला और श्रेणी संग्रह दोनों को साफ़ कर सकते हैं। एक ओवरलोड भी डिफ़ॉल्ट डेटा के बिना चार्ट बना सकता है।

**चार्ट ऑब्जेक्ट्स वर्कबुक कोशिकाओं से कैसे जुड़े होते हैं?**

श्रृंखला नाम, श्रेणी लेबल, और डेटा‑पॉइंट मान [IChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/) में कोशिकाओं को संदर्भित करते हैं। संदर्भित कोशिका बदलने पर संबंधित चार्ट तत्व अपडेट होता है। कस्टम डेटा बनाते समय, श्रेणी पंक्तियों और श्रृंखला‑मान पंक्तियों को इस प्रकार व्यवस्थित रखें कि प्रत्येक पॉइंट इच्छित श्रेणी के अंतर्गत प्लॉट हो।

**मैं पूरी श्रृंखला के बजाय केवल एक पॉइंट कैसे साफ़ करूँ?**

संबंधित मान सेल को `nullptr` सेट करें ताकि पॉइंट की श्रेणी स्थिति एक खाली पॉइंट के रूप में बनी रहे। [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) को केवल तभी कॉल करें जब आप उस श्रृंखला के सभी पॉइंट्स को हटाना चाहते हों। यदि आप श्रेणियां भी हटाते हैं, तो सभी श्रृंखलाओं को इस तरह अपडेट करें कि उनके मान श्रेणी संग्रह के साथ संरेखित रहें।

**खाली पॉइंट्स कैसे प्रदर्शित होते हैं?**

परिणाम चार्ट प्रकार और [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_displayblanksas/) पर निर्भर करता है। समर्थित चार्ट ब्लैंक्स को गैप, शून्य मान, या निकटतम पॉइंट्स को जोड़कर प्रदर्शित कर सकते हैं। अपनी प्रस्तुति में लापता डेटा के अर्थ के अनुसार सेटिंग चुनें। पूर्ण उदाहरण और दृश्य तुलना के लिए देखें [खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें](#control-the-display-of-empty-cells)।

**नकारात्मक मानों का फ़ॉर्मेट कैसे किया जाता है?**

समर्थित बार, कॉलम और बबल श्रृंखलाओं के लिए, [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) को कॉल करें और रंग को [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/) से सेट करें। आप व्यक्तिगत पॉइंट के लिए व्यवहार को [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/) से ओवरराइड कर सकते हैं। ये विधियां फ़ॉर्मेटिंग को प्रभावित करती हैं, न कि संग्रहीत संख्यात्मक मानों को।

**जब श्रृंखला और पॉइंट दोनों को फ़ॉर्मेट किया गया हो तो कौन जीतेगा?**

स्पष्ट डेटा‑पॉइंट फ़ॉर्मेटिंग उस पॉइंट के लिए प्राथमिकता रखती है। अन्य पॉइंट्स स्पष्ट श्रृंखला फ़ॉर्मेट या, यदि श्रृंखला फ़ॉर्मेट परिभाषित नहीं है, तो स्वचालित चार्ट स्टाइल और थीम का उपयोग जारी रखते हैं। समूह सेटिंग्स जैसे ओवरलैप और गैप विथ लेआउट को नियंत्रित करती हैं और पॉइंट‑स्तर की फ़ॉर्मेटिंग ओवरराइड नहीं होतीं।

**एक चार्ट अधिकतम कितनी श्रृंखलाएँ रख सकता है?**

Aspose.Slides कोई अलग से स्थायी श्रृंखला‑गणना सीमा नहीं लगाता। व्यवहार में, प्रस्तुति फ़ाइल की सीमाएं, उपलब्ध मेमोरी, रेंडरिंग समय, और चार्ट की पठनीयता उपयोगी सीमा निर्धारित करती हैं।

**जब कॉलम बहुत पास या बहुत दूर हों तो क्या बदलना चाहिए?**

उचित पैरेंट श्रृंखला समूह पर [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) को कॉल करें। मान बढ़ाकर क्लस्टर के बीच की दूरी बढ़ाएँ, या मान घटाकर क्लस्टर को पास लाएँ।