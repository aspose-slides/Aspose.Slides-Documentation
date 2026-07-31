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
- बाह्य वर्कबुक
- बाह्य डेटा
- पावरपॉइंट
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ खोजें: पावरपॉइंट और ओपनडॉक्यूमेंट फ़ॉर्मेट में चार्ट वर्कबुक को आसानी से प्रबंधित करें और अपनी प्रस्तुति डेटा को सुव्यवस्थित करें।"
---
## **सारांश**

यह लेख Aspose.Slides में चार्ट वर्कबुक के साथ काम करने की व्याख्या करता है। यह दर्शाता है कि वर्कबुक स्ट्रीम के माध्यम से चार्ट डेटा को कैसे पढ़ा और लिखा जाए, वर्कबुक सेल को चार्ट डेटा लेबल के रूप में उपयोग किया जाए, वर्कशीट संग्रह तक कैसे पहुंचा जाए, और चार्ट मानों के लिए डेटा स्रोत प्रकार को कैसे निर्दिष्ट किया जाए।

यह बाह्य वर्कबुक को चार्ट डेटा स्रोत के रूप में उपयोग करने को भी कवर करता है। उदाहरण दिखाते हैं कि कैसे एक बाह्य वर्कबुक बनाया और असाइन किया जाए, चार्ट से जुड़े बाह्य वर्कबुक का पथ कैसे प्राप्त किया जाए, और वर्कबुक उपलब्ध होने पर चार्ट डेटा को कैसे संपादित किया जाए।

## **Read and Write Chart Data from a Workbook**

Aspose.Slides [ReadWorkbookStream](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) और [WriteWorkbookStream](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) मेथड प्रदान करता है जो आपको चार्ट डेटा वर्कबुक (Aspose.Cells के साथ संपादित चार्ट डेटा वाले) को पढ़ने और लिखने की अनुमति देता है। **नोट** यह कि चार्ट डेटा को समान तरीके से व्यवस्थित होना चाहिए या स्रोत के समान संरचना होनी चाहिए।

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
workbook->Save(cellsOutputStream, Aspose::Cells::SaveFormat_Xlsx);

cellsOutputStream->SetPosition(0);
System::SharedPtr<System::IO::MemoryStream> msout = ToSlidesMemoryStream(cellsOutputStream);

chart->get_ChartData()->WriteWorkbookStream(msout);

chart->get_ChartData()->SetRange(u"Sheet1!$A$1:$B$9");
auto series = chart->get_ChartData()->get_Series()->idx_get(0);
series->get_ParentSeriesGroup()->set_IsColorVaried(true);
pres->Save(u"response2.pptx", Export::SaveFormat::Pptx);
```

## **Set a WorkBook Cell as a Chart Data Label**

1. [Presentation] क्लास का एक इंस्टैंस बनाएं।  
2. इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।  
3. कुछ डेटा के साथ एक बबल चार्ट जोड़ें।  
4. चार्ट सीरीज़ तक पहुंचें।  
5. वर्कबुक सेल को डेटा लेबल के रूप में सेट करें।  
6. प्रेजेंटेशन को सेव करें।  

यह C++ कोड दर्शाता है कि वर्कबुक सेल को चार्ट डेटा लेबल के रूप में कैसे सेट किया जाए:

``` cpp
System::String lbl0 = u"Label 0 cell value";
System::String lbl1 = u"Label 1 cell value";
System::String lbl2 = u"Label 2 cell value";

// एक Presentation क्लास को इंस्टैंसिएट करता है जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करती है 
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

## **Manage Worksheets**

यह C++ कोड एक ऑपरेशन दर्शाता है जहाँ [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) मेथड का उपयोग करके वर्कशीट संग्रह तक पहुंचा जाता है:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 500.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheets = workbook->get_Worksheets();

for (auto ws : System::IterateOver(worksheets))
    System::Console::WriteLine(ws->get_Name());
```

## **Specify the Data Source Type**

यह C++ कोड दिखाता है कि डेटा स्रोत के लिए प्रकार कैसे निर्दिष्ट किया जाए:

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

## **Detect Unsupported Embedded Workbook Formats**

Aspose.Slides कुछ चार्ट्स में एम्बेड की जा सकने वाली Excel बाइनरी वर्कबुक (.xlsb) फ़ॉर्मेट को सपोर्ट नहीं करता है। आप [IChartData](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdata/) पर `get_EmbeddedWorkbookType` मेथड को [WorkbookType](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/workbooktype/) एन्‍यूमरेशन के साथ उपयोग करके असमर्थित फ़ॉर्मेट का पता लगा सकते हैं और उन चार्ट्स को छोड़ सकते हैं।

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
            // एम्बेडेड वर्कबुक .xlsb फ़ॉर्मेट में है, जो समर्थित नहीं है।
            continue;
    }

    // यहाँ चार्ट वर्कबुक डेटा को पढ़ें या संशोधित करें।
}
```

## **External Workbook**

{{% alert color="primary" %}} 
[Aspose.Slides](https://releases.aspose.com/slides/hi/cpp/release-notes/2019/aspose-slides-for-cpp-19-4-release-notes/) संस्करण 19.4 में, हमने चार्ट्स के लिए डेटा स्रोत के रूप में बाह्य वर्कबुक के समर्थन को लागू किया। 
{{% /alert %}} 

### **Create an External Workbook**

**`ReadWorkbookStream`** और **`SetExternalWorkbook`** मेथड का उपयोग करके, आप या तो शून्य से एक बाह्य वर्कबुक बना सकते हैं या एक आंतरिक वर्कबुक को बाह्य बना सकते हैं।

यह C++ कोड बाह्य वर्कबुक निर्माण प्रक्रिया को दर्शाता है:

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

### **Set an External Workbook**

**`IChartData::SetExternalWorkbook`** मेथड का उपयोग करके, आप किसी चार्ट को उसके डेटा स्रोत के रूप में बाह्य वर्कबुक असाइन कर सकते हैं। इस मेथड का उपयोग बाह्य वर्कबुक के पथ को अपडेट करने के लिए भी किया जा सकता है (यदि वह स्थानांतरित किया गया हो)।

जबकि आप दूरस्थ स्थानों या संसाधनों में संग्रहीत वर्कबुक डेटा को संपादित नहीं कर सकते, आप फिर भी ऐसे वर्कबुक को बाह्य डेटा स्रोत के रूप में उपयोग कर सकते हैं। यदि बाह्य वर्कबुक के लिए एक रिलेटिव पाथ प्रदान किया जाता है, तो वह स्वचालित रूप से पूर्ण पाथ में बदल जाता है।

यह C++ कोड दिखाता है कि बाह्य वर्कबुक कैसे सेट किया जाए:

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

`updateChartData` पैरामीटर (`SetExternalWorkbook` मेथड के अंतर्गत) यह निर्दिष्ट करने के लिए उपयोग किया जाता है कि Excel वर्कबुक लोड किया जाएगा या नहीं।

* जब `updateChartData` मान `false` पर सेट किया जाता है, तो केवल वर्कबुक पाथ अपडेट होता है—चार्ट डेटा लक्ष्य वर्कबुक से लोड या अपडेट नहीं होगा। आप इस सेटिंग का उपयोग तब कर सकते हैं जब लक्ष्य वर्कबुक मौजूद न हो या उपलब्ध न हो।  
* जब `updateChartData` मान `true` पर सेट किया जाता है, तो चार्ट डेटा लक्ष्य वर्कबुक से अपडेट हो जाता है। 

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f, true);
System::SharedPtr<IChartData> chartData = chart->get_ChartData();

System::SharedPtr<ChartData> concreteChartData = System::AsCast<ChartData>(chartData);
concreteChartData->SetExternalWorkbook(u"http://path/doesnt/exists", false);

pres->Save(u"SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
```

### **Get the External Data Source Workbook Path of a Chart**

1. [Presentation] क्लास का एक इंस्टैंस बनाएं।  
2. इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।  
3. चार्ट शैप के लिए एक ऑब्जेक्ट बनाएं।  
4. स्रोत (`ChartDataSourceType`) प्रकार के लिए एक ऑब्जेक्ट बनाएं जो चार्ट के डेटा स्रोत को दर्शाता है।  
5. यह निर्दिष्ट करें कि स्रोत प्रकार बाह्य वर्कबुक डेटा स्रोत प्रकार के समान है या नहीं।  

यह C++ कोड ऑपरेशन को दर्शाता है:

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

### **Edit Chart Data**

आप बाह्य वर्कबुक में डेटा को उसी तरह संपादित कर सकते हैं जैसे आप आंतरिक वर्कबुक की सामग्री में बदलाव करते हैं। जब कोई बाह्य वर्कबुक लोड नहीं हो पाता, तो एक अपवाद फेंका जाता है।

यह C++ कोड वर्णित प्रक्रिया का कार्यान्वयन है:

```c++
const String templatePath = u"../templates/presentation.pptx";
	const String outPath = u"../out/presentation-out.pptx";
	

	System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(templatePath);
	System::SharedPtr<Aspose::Slides::Charts::IChart> chart = System::AsCast<Aspose::Slides::Charts::IChart>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
	System::SharedPtr<Aspose::Slides::Charts::ChartData> chartData = System::ExplicitCast<Aspose::Slides::Charts::ChartData>(chart->get_ChartData());
	

	chartData->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0)->get_Value()->get_AsCell()->set_Value(System::ObjectExt::Box<int32_t>(100));
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं यह निर्धारित कर सकता हूँ कि कोई विशिष्ट चार्ट बाह्य या एम्बेडेड वर्कबुक से जुड़ा है?**  

हाँ। एक चार्ट के पास एक [data source type](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) और एक [path to an external workbook](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) होता है; यदि स्रोत एक बाह्य वर्कबुक है, तो आप पूर्ण पाथ पढ़कर सुनिश्चित कर सकते हैं कि एक बाह्य फ़ाइल उपयोग में है।

**क्या बाह्य वर्कबुक के लिए रिलेटिव पाथ समर्थित हैं, और वे कैसे संग्रहीत होते हैं?**  

हाँ। यदि आप एक रिलेटिव पाथ निर्दिष्ट करते हैं, तो वह स्वचालित रूप से एब्सॉल्यूट पाथ में बदल जाता है। यह प्रोजेक्ट पोर्टेबिलिटी के लिए सुविधाजनक है; हालांकि, ध्यान रखें कि प्रेजेंटेशन PPTX फ़ाइल में एब्सॉल्यूट पाथ संग्रहीत करेगा।

**क्या मैं नेटवर्क रिसोर्सेज/शेयर पर स्थित वर्कबुक का उपयोग कर सकता हूँ?**  

हाँ, ऐसे वर्कबुक को बाह्य डेटा स्रोत के रूप में उपयोग किया जा सकता है। हालांकि, Aspose.Slides से दूरस्थ वर्कबुक को सीधे संपादित करना समर्थित नहीं है—इन्हें केवल स्रोत के रूप में उपयोग किया जा सकता है।

**क्या Aspose.Slides प्रस्तुति को सहेजते समय बाह्य XLSX को ओवरराइट करता है?**  

नहीं। प्रेजेंटेशन एक [link to the external file](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) संग्रहीत करता है और डेटा पढ़ने के लिए इसका उपयोग करता है। प्रस्तुति सहेजने पर बाह्य फ़ाइल स्वयं नहीं बदली जाती।

**यदि बाह्य फ़ाइल पासवर्ड-सुरक्षित है तो मुझे क्या करना चाहिए?**  

Aspose.Slides लिंक करते समय पासवर्ड स्वीकार नहीं करता। एक सामान्य उपाय यह है कि पहले से सुरक्षा हटा ली जाए या एक डिक्रिप्टेड कॉपी तैयार की जाए (उदाहरण के लिए, [Aspose.Cells](/cells/cpp/) का उपयोग करके) और उस कॉपी को लिंक किया जाए।

**क्या कई चार्ट एक ही बाह्य वर्कबुक को संदर्भित कर सकते हैं?**  

हाँ। प्रत्येक चार्ट अपना लिंक संग्रहीत करता है। यदि सभी एक ही फ़ाइल की ओर संकेत करते हैं, तो उस फ़ाइल को अपडेट करने से अगली बार डेटा लोड होने पर प्रत्येक चार्ट में यह प्रतिबिंबित होगा।