---
title: C++ का उपयोग करके प्रस्तुतियों में चार्ट कार्यपुस्तिकाओं को प्रबंधित करें
linktitle: चार्ट कार्यपुस्तिका
type: docs
weight: 70
url: /hi/cpp/chart-workbook/
keywords:
- चार्ट कार्यपुस्तिका
- चार्ट डेटा
- वर्कबुक सेल
- डेटा लेबल
- वर्कशीट
- डेटा स्रोत
- बाह्य कार्यपुस्तिका
- बाह्य डेटा
- चार्ट कैश
- वर्कबुक पुनर्प्राप्ति
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ की खोज करें: PowerPoint और OpenDocument स्वरूपों में चार्ट कार्यपुस्तिकाओं को आसानी से प्रबंधित करें जिससे आपकी प्रस्तुति डेटा सुव्यवस्थित हो सके।"
---
## **अवलोकन**

यह लेख Aspose.Slides में चार्ट कार्यपुस्तिकाओं के साथ काम करने के तरीकों को समझाता है। यह बताता है कि कैसे कार्यपुस्तिका स्ट्रीम्स के माध्यम से चार्ट डेटा को पढ़ा और लिखा जा सकता है, कार्यपुस्तिका सेल्स को चार्ट डेटा लेबल के रूप में उपयोग किया जाए, वर्कशीट संग्रहों तक पहुंच प्राप्त की जाए, और चार्ट मूल्यों के लिए डेटा स्रोत प्रकार को निर्दिष्ट किया जाए।

यह भी बताया गया है कि चार्ट डेटा स्रोत के रूप में बाहरी कार्यपुस्तिकाओं के साथ कैसे काम किया जाए। उदाहरण दिखाते हैं कि कैसे एक बाहरी कार्यपुस्तिका बनाई और असाइन की जाए, चार्ट से लिंक की गई बाहरी कार्यपुस्तिका का पथ प्राप्त किया जाए, और कार्यपुस्तिका उपलब्ध होने पर चार्ट डेटा को संपादित किया जाए।

## **कार्यपुस्तिका से चार्ट डेटा पढ़ना और लिखना**

Aspose.Slides [ReadWorkbookStream](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) और [WriteWorkbookStream](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) मेथड्स प्रदान करता है जो आपको चार्ट डेटा कार्यपुस्तिकाओं (Aspose.Cells के साथ संपादित चार्ट डेटा वाली) को पढ़ने और लिखने की अनुमति देते हैं। **Note** कि चार्ट डेटा को समान ढंग से व्यवस्थित किया जाना चाहिए या स्रोत के समान संरचना होनी चाहिए।

``` cpp
#include <DOM/Chart/Chart.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/io/memory_stream.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>(u"chart.pptx");

auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto data = chart->get_ChartData();

System::SharedPtr<System::IO::MemoryStream> stream = data->ReadWorkbookStream();
data->get_Series()->Clear();
data->get_Categories()->Clear();

stream->set_Position(0);
data->WriteWorkbookStream(stream);
```

यह C++ कोड चार्ट डेटा कार्यपुस्तिका सेट करने की प्रक्रिया को दर्शाता है:

``` cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto pres = MakeObject<Presentation>(u"Test.pptx");

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 500.0f, 400.0f);
chart->get_ChartData()->get_ChartDataWorkbook()->Clear(0);

// Excel (या Aspose.Cells) में तैयार की गई वर्कबुक को पढ़ें और इसे चार्ट डेटा वर्कबुक के रूप में सेट करें।
auto workbookData = File::ReadAllBytes(u"a1.xlsx");
auto workbookStream = MakeObject<MemoryStream>(workbookData);

chart->get_ChartData()->WriteWorkbookStream(workbookStream);

chart->get_ChartData()->SetRange(u"Sheet1!$A$1:$B$9");
auto series = chart->get_ChartData()->get_Series()->idx_get(0);
series->get_ParentSeriesGroup()->set_IsColorVaried(true);
pres->Save(u"response2.pptx", SaveFormat::Pptx);
```

## **कार्यपुस्तिका सेल को चार्ट डेटा लेबल के रूप में सेट करें**

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएँ।  
2. इंडेक्स के द्वारा स्लाइड का संदर्भ प्राप्त करें।  
3. कुछ डेटा के साथ एक बबल चार्ट जोड़ें।  
4. चार्ट सीरीज़ तक पहुंचें।  
5. वर्कबुक सेल को डेटा लेबल के रूप में सेट करें।  
6. प्रेजेंटेशन को सेव करें।

यह C++ कोड आपको कार्यपुस्तिका सेल को चार्ट डेटा लेबल के रूप में सेट करना दिखाता है:

``` cpp
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
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

System::String lbl0 = u"Label 0 cell value";
System::String lbl1 = u"Label 1 cell value";
System::String lbl2 = u"Label 2 cell value";

// एक Presentation क्लास का उदाहरण बनाता है जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है 
auto pres = System::MakeObject<Presentation>(u"chart2.pptx");

auto slide = pres->get_Slides()->idx_get(0);

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Bubble, 50.0f, 50.0f, 600.0f, 400.0f, true);

auto series = chart->get_ChartData()->get_Series();

series->idx_get(0)->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLabelValueFromCell(true);

auto wb = chart->get_ChartData()->get_ChartDataWorkbook();

series->idx_get(0)->get_Labels()->idx_get(0)->set_ValueFromCell(wb->GetCell(0, u"A10", System::ObjectExt::Box<System::String>(lbl0)));
series->idx_get(0)->get_Labels()->idx_get(1)->set_ValueFromCell(wb->GetCell(0, u"A11", System::ObjectExt::Box<System::String>(lbl1)));
series->idx_get(0)->get_Labels()->idx_get(2)->set_ValueFromCell(wb->GetCell(0, u"A12", System::ObjectExt::Box<System::String>(lbl2)));

pres->Save(u"resultchart.pptx", SaveFormat::Pptx);
```

## **वर्कशीट्स प्रबंधित करें**

यह C++ कोड दिखाता है कि कैसे [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) मेथड का उपयोग करके वर्कशीट संग्रह तक पहुंचा जाता है:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataWorksheet.h>
#include <DOM/Chart/IChartDataWorksheetCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 500.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheets = workbook->get_Worksheets();

for (auto ws : System::IterateOver(worksheets))
    System::Console::WriteLine(ws->get_Name());
```

## **डेटा स्रोत प्रकार निर्दिष्ट करें**

यह C++ कोड आपको डेटा स्रोत के लिए प्रकार निर्दिष्ट करना दिखाता है:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/DataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IStringChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto chartData = chart->get_ChartData();
auto val = chart->get_ChartData()->get_Series()->idx_get(0)->get_Name();

val->set_DataSourceType(DataSourceType::StringLiterals);
val->set_Data(System::ObjectExt::Box<System::String>(u"LiteralString"));
val = chartData->get_Series()->idx_get(1)->get_Name();
val->set_Data(chartData->get_ChartDataWorkbook()->GetCell(0, u"B1", System::ObjectExt::Box<System::String>(u"NewCell")));

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **असमर्थित एम्बेडेड कार्यपुस्तिका स्वरूपों का पता लगाएँ**

Aspose.Slides कुछ चार्टों में एम्बेड किए जा सकने वाले Excel बाइनरी कार्यपुस्तिका (.xlsb) स्वरूप को समर्थन नहीं देता है। आप `[IChartData]` (https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdata/) पर `get_EmbeddedWorkbookType` मेथड को [WorkbookType](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/workbooktype/) एन्उमरेशन के साथ उपयोग करके असमर्थित स्वरूपों का पता लगा सकते हैं और उन चार्टों को स्किप कर सकते हैं।

```cpp
#include <DOM/Chart/ChartDataSourceType.h>
#include <DOM/Chart/WorkbookType.h>
#include <DOM/IChart.h>
#include <DOM/ISlide.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : System::IterateOver(slide->get_Shapes()))
{
    if (!System::ObjectExt::Is<IChart>(shape))
    {
        continue;
    }

    auto chart = System::ExplicitCast<IChart>(shape);
    auto chartData = chart->get_ChartData();

    if (chartData->get_DataSourceType() == ChartDataSourceType::InternalWorkbook &&
        chartData->get_EmbeddedWorkbookType() == WorkbookType::WorkbookBinaryMacro)
    {
        // .xlsb स्वरूप में एम्बेडेड वर्कबुक है, जो समर्थित नहीं है।
        continue;
    }

    // यहाँ चार्ट वर्कबुक डेटा पढ़ें या संशोधित करें।
}
```

## **बाह्य कार्यपुस्तिका**

{{% alert color="info" %}} 
[Aspose.Slides](https://releases.aspose.com/slides/hi/cpp/release-notes/2019/aspose-slides-for-cpp-19-4-release-notes/) 19.4 में, हमने चार्ट के डेटा स्रोत के रूप में बाह्य कार्यपुस्तिकाओं के समर्थन को लागू किया। 
{{% /alert %}} 

### **बाह्य कार्यपुस्तिका बनाएं**

**`ReadWorkbookStream`** और **`SetExternalWorkbook`** मेथड्स का उपयोग करके आप या तो शून्य से एक बाह्य कार्यपुस्तिका बना सकते हैं या एक आंतरिक कार्यपुस्तिका को बाह्य बना सकते हैं।

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/io/memory_stream.h>
#include <system/io/path.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();

const System::String workbookPath = u"externalWorkbook1.xlsx";

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f);
auto chartData = chart->get_ChartData();

{
    System::SharedPtr<System::IO::FileStream> fileStream = System::MakeObject<System::IO::FileStream>(workbookPath, System::IO::FileMode::Create);

    System::ArrayPtr<uint8_t> workbookData = chartData->ReadWorkbookStream()->ToArray();
    fileStream->Write(workbookData, 0, workbookData->get_Length());
}

chartData->SetExternalWorkbook(System::IO::Path::GetFullPath(workbookPath));

pres->Save(u"externalWorkbook.pptx", SaveFormat::Pptx);
```

### **बाह्य कार्यपुस्तिका सेट करें**

**`IChartData::SetExternalWorkbook`** मेथड का उपयोग करके आप एक बाह्य कार्यपुस्तिका को चार्ट के डेटा स्रोत के रूप में असाइन कर सकते हैं। इस मेथड का उपयोग बाह्य कार्यपुस्तिका के पथ को अपडेट करने के लिए भी किया जा सकता है (यदि वह स्थानांतरित हो गया हो)।

जबकि आप रिमोट स्थान या संसाधन में संग्रहीत कार्यपुस्तिकाओं का डेटा सीधे संपादित नहीं कर सकते, फिर भी आप ऐसी कार्यपुस्तिकाओं को बाह्य डेटा स्रोत के रूप में उपयोग कर सकते हैं। यदि बाह्य कार्यपुस्तिका के लिए सापेक्ष पथ प्रदान किया जाता है, तो वह स्वचालित रूप से पूर्ण पथ में परिवर्तित हो जाता है।

यह C++ कोड आपको बाह्य कार्यपुस्तिका सेट करना दिखाता है:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/path.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f, false);
auto chartData = chart->get_ChartData();

chartData->SetExternalWorkbook(System::IO::Path::GetFullPath(u"externalWorkbook.xlsx"));

chartData->get_Series()->Add(chartData->get_ChartDataWorkbook()->GetCell(0, u"B1"), ChartType::Pie);
auto dataPoints = chartData->get_Series()->idx_get(0)->get_DataPoints();
auto workbook = chartData->get_ChartDataWorkbook();
dataPoints->AddDataPointForPieSeries(workbook->GetCell(0, u"B2"));
dataPoints->AddDataPointForPieSeries(workbook->GetCell(0, u"B3"));
dataPoints->AddDataPointForPieSeries(workbook->GetCell(0, u"B4"));

auto categories = chartData->get_Categories();
categories->Add(workbook->GetCell(0, u"A2"));
categories->Add(workbook->GetCell(0, u"A3"));
categories->Add(workbook->GetCell(0, u"A4"));
pres->Save(u"Presentation_with_externalWorkbook.pptx", SaveFormat::Pptx);
```

`updateChartData` पैरामीटर (`SetExternalWorkbook` मेथड के अंतर्गत) यह निर्धारित करने के लिए उपयोग किया जाता है कि Excel कार्यपुस्तिका लोड की जाएगी या नहीं।

* जब `updateChartData` का मान `false` पर सेट किया जाता है, तो केवल कार्यपुस्तिका पथ अपडेट होता है—चार्ट डेटा लक्ष्य कार्यपुस्तिका से लोड या अपडेट नहीं होगा। इस सेटिंग का उपयोग तब किया जा सकता है जब लक्ष्य कार्यपुस्तिका मौजूद नहीं है या उपलब्ध नहीं है।  
* जब `updateChartData` का मान `true` पर सेट किया जाता है, तो चार्ट डेटा लक्ष्य कार्यपुस्तिका से अपडेट हो जाता है।

```c++
#include <DOM/Chart/ChartData.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f, true);
System::SharedPtr<IChartData> chartData = chart->get_ChartData();

System::SharedPtr<ChartData> concreteChartData = System::AsCast<ChartData>(chartData);
concreteChartData->SetExternalWorkbook(u"http://path/doesnt/exists", false);

pres->Save(u"SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
```

### **चार्ट के बाह्य डेटा स्रोत कार्यपुस्तिका पथ प्राप्त करें**

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएँ।  
2. इंडेक्स के द्वारा स्लाइड का संदर्भ प्राप्त करें।  
3. चार्ट शेप के लिए एक ऑब्जेक्ट बनाएं।  
4. स्रोत (`ChartDataSourceType`) प्रकार के लिए एक ऑब्जेक्ट बनाएं जो चार्ट के डेटा स्रोत का प्रतिनिधित्व करता है।  
5. स्रोत प्रकार को बाह्य कार्यपुस्तिका डेटा स्रोत प्रकार के समान होने के आधार पर संबंधित शर्त निर्धारित करें।

यह C++ कोड इस प्रक्रिया को दर्शाता है:

```c++
#include <DOM/Chart/ChartDataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");

auto slide = pres->get_Slides()->idx_get(1);
auto chart = System::ExplicitCast<IChart>(slide->get_Shapes()->idx_get(0));
ChartDataSourceType sourceType = chart->get_ChartData()->get_DataSourceType();
if (sourceType == ChartDataSourceType::ExternalWorkbook)
{
    System::String path = chart->get_ChartData()->get_ExternalWorkbookPath();
}

// प्रस्तुति को सहेजता है
pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

### **चार्ट डेटा संपादित करें**

आप बाह्य कार्यपुस्तिकाओं के डेटा को उसी तरह संपादित कर सकते हैं जैसे आप आंतरिक कार्यपुस्तिकाओं की सामग्री में परिवर्तन करते हैं। जब कोई बाह्य कार्यपुस्तिका लोड नहीं की जा सकती, तो एक अपवाद उत्पन्न किया जाता है।

```c++
#include <DOM/Chart/Chart.h>
#include <DOM/Chart/ChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

const String templatePath = u"../templates/presentation.pptx";
	const String outPath = u"../out/presentation-out.pptx";
	

	System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(templatePath);
	System::SharedPtr<Aspose::Slides::Charts::IChart> chart = System::AsCast<Aspose::Slides::Charts::IChart>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
	System::SharedPtr<Aspose::Slides::Charts::ChartData> chartData = System::ExplicitCast<Aspose::Slides::Charts::ChartData>(chart->get_ChartData());
	

	chartData->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0)->get_Value()->get_AsCell()->set_Value(System::ObjectExt::Box<int32_t>(100));
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **चार्ट कैश से कार्यपुस्तिका पुनर्प्राप्त करें**

यदि कोई चार्ट एक ऐसी बाह्य कार्यपुस्तिका का उपयोग करता है जो अनुपलब्ध या गायब है, तो Aspose.Slides प्रस्तुति में कैश किए गए डेटा से चार्ट कार्यपुस्तिका को पुनर्निर्मित कर सकता है। [LoadOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides/loadoptions/) बनाएं, उसे [set_SpreadsheetOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/) से कॉन्फ़िगर करें, और प्रस्तुति खोलने से पहले `true` के साथ [ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/) को कॉल करें।

निम्नलिखित C++ उदाहरण एक ऐसी प्रस्तुति खोलता है जिसमें चार्ट एक अनुपलब्ध बाह्य कार्यपुस्तिका का संदर्भ देता है और पुनः प्राप्त डेटा को [IChart::get_ChartData](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichart/get_chartdata/) और [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) के माध्यम से एक्सेस करता है:

```cpp
auto spreadsheetOptions = MakeObject<SpreadsheetOptions>();
spreadsheetOptions->set_RecoverWorkbookFromChartCache(true);

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_SpreadsheetOptions(spreadsheetOptions);

auto presentation = MakeObject<Presentation>(u"presentation.pptx", loadOptions);

auto shape = presentation->get_Slide(0)->get_Shape(0);
auto chart = System::ExplicitCast<IChart>(shape);

auto recoveredWorkbook = chart->get_ChartData()->get_ChartDataWorkbook();

// Read or modify the recovered workbook data here.

presentation->Dispose();
```

यदि बाह्य कार्यपुस्तिका उपलब्ध नहीं है और पुनर्प्राप्ति अक्षम है, तो Aspose.Slides `System::InvalidOperationException` फेंकता है। पुनर्प्राप्ति तभी सक्षम करें जब कैश किया गया चार्ट डेटा एक स्वीकार्य विकल्प हो, क्योंकि कैश में वह परिवर्तन नहीं हो सकते जो बाह्य कार्यपुस्तिका में प्रस्तुति के अंतिम अपडेट के बाद किए गए हों।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं यह निर्धारित कर सकता हूँ कि कोई विशिष्ट चार्ट बाह्य या एम्बेडेड कार्यपुस्तिका से जुड़ा है?**

हाँ। एक चार्ट के पास [डेटा स्रोत प्रकार](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) और एक [बाह्य कार्यपुस्तिका पथ](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) होता है; यदि स्रोत बाह्य कार्यपुस्तिका है, तो आप पूर्ण पथ पढ़कर सुनिश्चित कर सकते हैं कि बाह्य फ़ाइल उपयोग में है।

**क्या बाह्य कार्यपुस्तिकाओं के सापेक्ष पथ समर्थित हैं, और वे कैसे संग्रहीत होते हैं?**

हाँ। यदि आप सापेक्ष पथ निर्दिष्ट करते हैं, तो वह स्वचालित रूप से पूर्ण पथ में परिवर्तित हो जाता है। यह परियोजना की पोर्टेबिलिटी के लिए सुविधाजनक है; हालांकि, ध्यान रखें कि प्रस्तुति PPTX फ़ाइल में पूर्ण पथ संग्रहीत करती है।

**क्या मैं नेटवर्क संसाधनों/शेयरों पर स्थित कार्यपुस्तिकाओं का उपयोग कर सकता हूँ?**

हाँ, ऐसी कार्यपुस्तिकाओं को बाह्य डेटा स्रोत के रूप में उपयोग किया जा सकता है। लेकिन Aspose.Slides से रिमोट कार्यपुस्तिकाओं को सीधे संपादित करने का समर्थन नहीं है—वे केवल स्रोत के रूप में उपयोग की जा सकती हैं।

**क्या Aspose.Slides प्रस्तुति सहेजते समय बाह्य XLSX को ओवरराइट करता है?**

नहीं। प्रस्तुति एक [बाह्य फ़ाइल लिंक](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) संग्रहीत करती है और डेटा पढ़ने के लिए इसका उपयोग करती है। प्रस्तुति सहेजने पर बाह्य फ़ाइल स्वयं संशोधित नहीं होती।

**यदि बाह्य फ़ाइल पासवर्ड से संरक्षित है तो मुझे क्या करना चाहिए?**

Aspose.Slides लिंक करते समय पासवर्ड स्वीकार नहीं करता। आमतौर पर पहले सुरक्षा हटाई जाती है या एक डिक्रिप्टेड कॉपी (उदाहरण के लिए, [Aspose.Cells](/cells/cpp/)) तैयार करके उस कॉपी का लिंक किया जाता है।

**क्या कई चार्ट एक ही बाह्य कार्यपुस्तिका का संदर्भ ले सकते हैं?**

हाँ। प्रत्येक चार्ट अपना लिंक संग्रहीत करता है। यदि सभी एक ही फ़ाइल की ओर इशारा करते हैं, तो उस फ़ाइल में किया गया अपडेट अगली बार डेटा लोड होने पर सभी चार्ट में परिलक्षित होगा।