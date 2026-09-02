---
title: "C++ का उपयोग करके प्रस्तुतियों में चार्ट वर्कबुक प्रबंधित करें"
linktitle: "चार्ट वर्कबुक"
type: docs
weight: 70
url: /hi/cpp/chart-workbook/
keywords:
- "चार्ट वर्कबुक"
- "चार्ट डेटा"
- "वर्कबुक सेल"
- "डेटा लेबल"
- "वर्कशीट"
- "डेटा स्रोत"
- "बाहरी वर्कबुक"
- "बाहरी डेटा"
- "चार्ट कैश"
- "वर्कबुक पुनर्प्राप्ति"
- "PowerPoint"
- "प्रस्तुति"
- "C++"
- "Aspose.Slides"
description: "अस्पोज़.Slides for C++ को खोजें: PowerPoint और OpenDocument फ़ॉर्मैट्स में चार्ट वर्कबुक को आसानी से प्रबंधित करें ताकि आपका प्रस्तुति डेटा सुगम हो सके।"
---
## **अवलोकन**

यह लेख Aspose.Slides में चार्ट वर्कबुक के साथ काम करने का तरीका समझाता है। यह वर्कबुक स्ट्रीम के माध्यम से चार्ट डेटा को पढ़ने और लिखने, वर्कबुक सेल्स को चार्ट डेटा लेबल के रूप में उपयोग करने, वर्कशीट संग्रहों तक पहुँचने, और चार्ट मानों के लिए डेटा सोर्स प्रकार निर्दिष्ट करने को दर्शाता है।

यह बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में उपयोग करने को भी कवर करता है। उदाहरण दिखाते हैं कि कैसे बाहरी वर्कबुक बनाया और सौंपा जाए, चार्ट से जुड़ी बाहरी वर्कबुक का पथ प्राप्त किया जाए, और जब वर्कबुक उपलब्ध हो तो चार्ट डेटा को संपादित किया जाए।

## **वर्कबुक से चार्ट डेटा पढ़ना और लिखना**

Aspose.Slides [ReadWorkbookStream](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) और [WriteWorkbookStream](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) मेथड्स प्रदान करता है जो आपको चार्ट डेटा वर्कबुक (Aspose.Cells के साथ संपादित चार्ट डेटा वाले) को पढ़ने और लिखने की अनुमति देते हैं। **ध्यान दें** कि चार्ट डेटा को उसी तरह व्यवस्थित होना चाहिए या स्रोत के समान संरचना होनी चाहिए।

``` cpp
auto pres = System::MakeObject<Presentation>(u"chart.pptx");

auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto data = chart->get_ChartData();

System::SharedPtr<System::IO::MemoryStream> stream = data->ReadWorkbookStream();
data->get_Series()->Clear();
data->get_Categories()->Clear();

stream->set_Position(0);
data->WriteWorkbookStream(stream);
```

यह C++ कोड चार्ट डेटा वर्कबुक सेट करने के संचालन को दर्शाता है:

``` cpp
auto pres = System::MakeObject<Presentation>(u"Test.pptx");

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(Charts::ChartType::Pie, 50.0f, 50.0f, 500.0f, 400.0f);
chart->get_ChartData()->get_ChartDataWorkbook()->Clear(0);

intrusive_ptr<Aspose::Cells::IWorkbook> workbook;
try
{
    workbook = Aspose::Cells::Factory::CreateIWorkbook(new String("a1.xlsx"));
}
catch (Aspose::Cells::Systems::Exception& ex)
{
    System::Console::Write(System::String::FromWCS(ex.GetMessageExp()->value()));
}

intrusive_ptr<MemoryStream> cellsOutputStream = new Aspose::Cells::Systems::IO::MemoryStream();
workbook->Save(cellsOutputStream, Aspose::Cells::SaveFormat_Xxlsx);

cellsOutputStream->SetPosition(0);
System::SharedPtr<System::IO::MemoryStream> msout = ToSlidesMemoryStream(cellsOutputStream);

chart->get_ChartData()->WriteWorkbookStream(msout);

chart->get_ChartData()->SetRange(u"Sheet1!$A$1:$B$9");
auto series = chart->get_ChartData()->get_Series()->idx_get(0);
series->get_ParentSeriesGroup()->set_IsColorVaried(true);
pres->Save(u"response2.pptx", Export::SaveFormat::Pptx);
```

## **वर्कबुक सेल को चार्ट डेटा लेबल के रूप में सेट करें**

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।
3. कुछ डेटा के साथ एक बबल चार्ट जोड़ें।
4. चार्ट सीरीज़ तक पहुँचें।
5. वर्कबुक सेल को डेटा लेबल के रूप में सेट करें।
6. प्रेज़ेंटेशन को सेव करें।

यह C++ कोड आपको वर्कबुक सेल को चार्ट डेटा लेबल के रूप में सेट करने को दिखाता है:

``` cpp
System::String lbl0 = u"Label 0 cell value";
System::String lbl1 = u"Label 1 cell value";
System::String lbl2 = u"Label 2 cell value";

// एक Presentation क्लास को इंस्टैंसिएट करता है जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है 
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

यह C++ कोड एक संचालन को दर्शाता है जहाँ [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) मेथड का उपयोग करके वर्कशीट संग्रह तक पहुँच प्राप्त की जाती है:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 500.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheets = workbook->get_Worksheets();

for (auto ws : System::IterateOver(worksheets))
    System::Console::WriteLine(ws->get_Name());
```

## **डेटा स्रोत प्रकार निर्दिष्ट करें**

यह C++ कोड आपको डेटा स्रोत के लिए प्रकार कैसे निर्दिष्ट किया जाए दिखाता है:

```c++
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

## **असमर्थित एम्बेडेड वर्कबुक फ़ॉर्मेट का पता लगाएँ**

Aspose.Slides कुछ चार्ट में एम्बेड किए जा सकने वाले Excel बाइनरी वर्कबुक (.xlsb) फ़ॉर्मेट का समर्थन नहीं करता है। आप [IChartData](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdata/) पर `get_EmbeddedWorkbookType` मेथड को [WorkbookType](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/workbooktype/) enumeration के साथ उपयोग करके असमर्थित फ़ॉर्मेट का पता लगा सकते हैं और उन चार्ट को स्किप कर सकते हैं।

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
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
        // .xlsb फ़ॉर्मेट में एम्बेडेड वर्कबुक है, जो समर्थित नहीं है।
        continue;
    }

    // यहाँ चार्ट वर्कबुक डेटा को पढ़ें या संशोधित करें।
}
```

## **बाहरी वर्कबुक**

{{% alert color="primary" %}} 
In [Aspose.Slides](https://releases.aspose.com/slides/hi/cpp/release-notes/2019/aspose-slides-for-cpp-19-4-release-notes/) 19.4, we implemented support for external workbooks as a data source for charts.
{{% /alert %}} 

### **एक बाहरी वर्कबुक बनाएं**

**`ReadWorkbookStream`** और **`SetExternalWorkbook`** मेथड्स का उपयोग करके आप या तो शून्य से एक बाहरी वर्कबुक बना सकते हैं या किसी आंतरिक वर्कबुक को बाहरी बना सकते हैं।

```c++
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

### **बाहरी वर्कबुक सेट करें**

**`IChartData::SetExternalWorkbook`** मेथड का उपयोग करके आप एक बाहरी वर्कबुक को चार्ट के डेटा स्रोत के रूप में असाइन कर सकते हैं। इस मेथड का उपयोग बाहरी वर्कबुक के पथ को अपडेट करने के लिए भी किया जा सकता है (यदि वह स्थानांतरित किया गया हो)।

जबकि आप दूरस्थ स्थानों या संसाधनों में संग्रहीत वर्कबुक के डेटा को सीधे संपादित नहीं कर सकते, आप अभी भी ऐसे वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग कर सकते हैं। यदि बाहरी वर्कबुक के लिए सापेक्ष पथ प्रदान किया जाता है, तो वह स्वतः पूर्ण पथ में परिवर्तित हो जाता है।

यह C++ कोड दिखाता है कि कैसे एक बाहरी वर्कबुक सेट किया जाता है:

```c++
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

`updateChartData` पैरामीटर (`SetExternalWorkbook` मेथड के तहत) यह निर्धारित करने के लिए उपयोग किया जाता है कि Excel वर्कबुक लोड किया जाएगा या नहीं।

* जब `updateChartData` मान `false` पर सेट किया जाता है, तो केवल वर्कबुक पथ अपडेट होता है—चार्ट डेटा लक्ष्य वर्कबुक से लोड या अपडेट नहीं होता। यह सेटिंग तब उपयोगी है जब लक्ष्य वर्कबुक मौजूद नहीं है या उपलब्ध नहीं है।
* जब `updateChartData` मान `true` पर सेट किया जाता है, तो चार्ट डेटा लक्ष्य वर्कबुक से अपडेट होता है।

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f, true);
System::SharedPtr<IChartData> chartData = chart->get_ChartData();

System::SharedPtr<ChartData> concreteChartData = System::AsCast<ChartData>(chartData);
concreteChartData->SetExternalWorkbook(u"http://path/doesnt/exists", false);

pres->Save(u"SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
```

### **चार्ट के बाहरी डेटा स्रोत वर्कबुक पथ प्राप्त करें**

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।
3. चार्ट शेप के लिए एक ऑब्जेक्ट बनाएं।
4. स्रोत (`ChartDataSourceType`) प्रकार का एक ऑब्जेक्ट बनाएं जो चार्ट के डेटा स्रोत को दर्शाता है।
5. स्रोत प्रकार को बाहरी वर्कबुक डेटा स्रोत प्रकार के समान होने के आधार पर संबंधित शर्त निर्दिष्ट करें।

यह C++ कोड संचालन को दर्शाता है:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

auto slide = pres->get_Slides()->idx_get(1);
auto chart = System::ExplicitCast<IChart>(slide->get_Shapes()->idx_get(0));
ChartDataSourceType sourceType = chart->get_ChartData()->get_DataSourceType();
if (sourceType == ChartDataSourceType::ExternalWorkbook)
{
    System::String path = chart->get_ChartData()->get_ExternalWorkbookPath();
}

// Saves the presentation
pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

### **चार्ट डेटा संपादित करें**

आप बाहरी वर्कबुक के डेटा को उसी तरह संपादित कर सकते हैं जैसे आप आंतरिक वर्कबुक की सामग्री में बदलाव करते हैं। जब कोई बाहरी वर्कबुक लोड नहीं हो पाती, तो एक अपवाद फेंका जाता है।

```c++
const String templatePath = u"../templates/presentation.pptx";
	const String outPath = u"../out/presentation-out.pptx";
	

	System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(templatePath);
	System::SharedPtr<Aspose::Slides::Charts::IChart> chart = System::AsCast<Aspose::Slides::Charts::IChart>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
	System::SharedPtr<Aspose::Slides::Charts::ChartData> chartData = System::ExplicitCast<Aspose::Slides::Charts::ChartData>(chart->get_ChartData());
	

	chartData->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0)->get_Value()->get_AsCell()->set_Value(System::ObjectExt::Box<int32_t>(100));
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **चार्ट कैश से वर्कबुक पुनः प्राप्त करें**

यदि कोई चार्ट ऐसी बाहरी वर्कबुक का उपयोग करता है जो गायब या अनुपलब्ध है, तो Aspose.Slides प्रेज़ेंटेशन में कैश किए गए डेटा से चार्ट वर्कबुक को पुनर्सृजित कर सकता है। [LoadOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides/loadoptions/) बनाएं, उसे [set_SpreadsheetOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/) के साथ कॉन्फ़िगर करें, और प्रेज़ेंटेशन खोलने से पहले `true` के साथ [ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/) को कॉल करें।

निम्न C++ उदाहरण एक प्रेज़ेंटेशन खोलता है जिसका चार्ट अनुपलब्ध बाहरी वर्कबुक को संदर्भित करता है और पुनः प्राप्त डेटा को [IChart::get_ChartData](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichart/get_chartdata/) और [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) के माध्यम से एक्सेस करता है:

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

यदि बाहरी वर्कबुक अनुपलब्ध है और पुनर्सृजन निष्क्रिय है, तो Aspose.Slides `System::InvalidOperationException` फेंकता है। पुनर्सृजन को केवल तभी सक्षम करें जब कैश्ड चार्ट डेटा का उपयोग एक स्वीकार्य फ़ॉलबैक हो, क्योंकि कैश में बाहरी वर्कबुक में प्रेज़ेंटेशन के अंतिम अपडेट के बाद किए गए परिवर्तन नहीं हो सकते।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं यह निर्धारित कर सकता हूँ कि कोई विशेष चार्ट बाहरी या एम्बेडेड वर्कबुक से जुड़ा है?**

हाँ। एक चार्ट के पास एक [डेटा स्रोत प्रकार](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) और एक [बाहरी वर्कबुक का पथ](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) होता है; यदि स्रोत बाहरी वर्कबुक है, तो आप पूर्ण पथ पढ़ सकते हैं यह सुनिश्चित करने के लिए कि एक बाहरी फ़ाइल उपयोग में है।

**क्या बाहरी वर्कबुक के सापेक्ष पथ समर्थित हैं, और वे कैसे संग्रहीत होते हैं?**

हाँ। यदि आप सापेक्ष पथ निर्दिष्ट करते हैं, तो वह स्वतः पूर्ण पथ में परिवर्तित हो जाता है। यह प्रोजेक्ट पोर्टेबिलिटी के लिए सुविधाजनक है; हालांकि, ध्यान रखें कि प्रेज़ेंटेशन PPTX फ़ाइल में पूर्ण पथ संग्रहीत करेगा।

**क्या मैं नेटवर्क संसाधनों/शेयरों पर स्थित वर्कबुक का उपयोग कर सकता हूँ?**

हाँ, ऐसे वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग किया जा सकता है। हालाँकि, Aspose.Slides से सीधे रिमोट वर्कबुक को संपादित करना समर्थित नहीं है—वे केवल स्रोत के रूप में उपयोग किए जा सकते हैं।

**क्या Aspose.Slides प्रेज़ेंटेशन सहेजते समय बाहरी XLSX को ओवरराइट करता है?**

नहीं। प्रेज़ेंटेशन एक [बाहरी फ़ाइल का लिंक](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) संग्रहीत करता है और डेटा पढ़ने के लिए इसका उपयोग करता है। प्रेज़ेंटेशन सहेजते समय बाहरी फ़ाइल स्वयं संशोधित नहीं होती।

**यदि बाहरी फ़ाइल पासवर्ड-संरक्षित है तो मुझे क्या करना चाहिए?**

Aspose.Slides लिंकिंग के समय पासवर्ड नहीं लेता। आमतौर पर पहले संरक्षण हटाया जाता है या एक डिक्रिप्टेड कॉपी (उदाहरण के लिए, [Aspose.Cells](/cells/cpp/)) तैयार की जाती है और उस कॉपी को लिंक किया जाता है।

**क्या कई चार्ट एक ही बाहरी वर्कबुक को संदर्भित कर सकते हैं?**

हाँ। हर चार्ट अपना लिंक संग्रहीत करता है। यदि सभी एक ही फ़ाइल की ओर संकेत करते हैं, तो उस फ़ाइल में किए गए अपडेट अगले बार डेटा लोड होने पर प्रत्येक चार्ट में प्रतिबिंबित होंगे।