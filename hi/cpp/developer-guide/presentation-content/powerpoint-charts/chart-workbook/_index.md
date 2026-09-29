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
description: "Aspose.Slides for C++ की खोज करें: PowerPoint और OpenDocument फ़ॉर्मैट में चार्ट वर्कबुक को आसानी से प्रबंधित करके अपनी प्रस्तुति डेटा को सरल बनाएं।"
---
## **अवलोकन**

यह लेख Aspose.Slides में चार्ट वर्कबुक के साथ काम करने के तरीकों को समझाता है। यह वर्कबुक स्ट्रीम के माध्यम से चार्ट डेटा को पढ़ने और लिखने, वर्कबुक कोशिकाओं को चार्ट डेटा लेबल के रूप में उपयोग करने, वर्कशीट संग्रह तक पहुंचने, और चार्ट मूल्यों के लिए डेटा स्रोत प्रकार निर्दिष्ट करने को दर्शाता है।

यह बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में उपयोग करने को भी कवर करता है। उदाहरण दिखाते हैं कि कैसे बाहरी वर्कबुक बनाया और सौंपा जाता है, चार्ट से लिंक किए गए बाहरी वर्कबुक का पथ प्राप्त किया जाता है, और वर्कबुक उपलब्ध होने पर चार्ट डेटा संपादित किया जाता है।

गायब डेटा का प्रतिनिधित्व करने वाली वर्कबुक कोशिकाओं के लिए, खाली कोशिका और शून्य के बीच अंतर के लिए [खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें](/slides/hi/cpp/chart-series/) देखें, और उपलब्ध प्रदर्शन मोडों की रेखा ग्राफ तुलना देखें।

## **छिपी हुई पंक्तियों और स्तम्भों से डेटा शामिल करें**

छिपी हुई वर्कशीट पंक्तियों और स्तम्भों से डेटा प्लॉट किया जाए या नहीं, इसे नियंत्रित करने के लिए [IChart::set_PlotVisibleCellsOnly](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichart/set_plotvisiblecellsonly/) का उपयोग करें। `true` सेट करने पर केवल दृश्यमान कोशिकाएँ प्लॉट होंगी, जबकि `false` सेट करने पर दृश्यमान और छिपी दोनों कोशिकाएँ शामिल होंगी। यह सेटिंग चार्ट प्लॉटिंग को नियंत्रित करती है; यह वर्कशीट पंक्तियों या स्तम्भों को छुपाती या दिखाती नहीं है।

[hidden-source-data.pptx](hidden-source-data.pptx) डाउनलोड करें और इसे कार्य निर्देशिका में रखें। इसकी पहली स्लाइड में पहले आकार के रूप में एक कॉलम चार्ट है। एम्बेडेड वर्कशीट, `Sheet1`, में निम्न स्रोत रेंज `A1:C4` है। पंक्ति 3 और स्तम्भ C छिपे हुए हैं, लेकिन उनकी कोशिकाओं में अभी भी मान हैं।

| वर्कशीट पंक्ति | A: माह | B: रिटेल | C: थोक (छिपा स्तम्भ) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (छिपी हुई पंक्ति) | February | 40 | 60 |
| 4 | March | 20 | 50 |

स्रोत कोशिकाओं तक पहुंचने के लिए [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) का उपयोग करें और उनकी छिपी स्थिति जांचने के लिए [IChartDataCell::get_IsHidden](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdatacell/get_ishidden/) पढ़ें। यह गुण केवल- पढने योग्य है। इस फ़ाइल में, B2 दृश्यमान है, B3 छिपी हुई पंक्ति से संबंधित है, और C2 छिपे हुए स्तम्भ से संबंधित है; उदाहरण क्रमशः `False`, `True`, और `True` प्रिंट करता है।

इस उदाहरण के लिए, प्लॉटिंग सेटिंग बदलने के बाद चार्ट डेटा रीफ़्रेश करें: एम्बेडेड वर्कबुक को [ReadWorkbookStream](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) के साथ बरकरार रखें और इसे [WriteWorkbookStream](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) के साथ पुनः लोड करें। सभी कोशिकाएँ शामिल करने पर, छिपी हुई फ़रवरी श्रेणी को भी पुनर्स्थापित करने के लिए [SetRange](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdata/setrange/) का उपयोग करें। केवल फ़्लैग बदलना इस नमूने के कैश्ड चार्ट डेटा और श्रेणी लेबल को रीफ़्रेश करने के लिए पर्याप्त नहीं है।

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

        // एम्बेडेड वर्कबुक से चार्ट डेटा रीफ़्रेश करें।
        workbookStream->set_Position(0);
        chart->get_ChartData()->WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // छिपी श्रेणियों सहित पूर्ण स्रोत रेंज को पुनर्स्थापित करें।
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

उदाहरण `hidden_cells_True.pptx` को केवल दृश्यमान रिटेल मान (10 और 20) के साथ सहेजता है, और `hidden_cells_False.pptx` को सभी छह मानों के साथ। नीचे की छवियाँ दो प्लॉटिंग मोड दर्शाती हैं। पंक्ति 3 और स्तम्भ C दोनों एम्बेडेड वर्कबुक में छिपे हुए रहते हैं।

| केवल दृश्यमान कोशिकाएँ (`true`) | सभी कोशिकाएँ (`false`) |
| --- | --- |
| ![केवल दृश्यमान कोशिकाएँ: जनवरी और मार्च के लिए रिटेल मान 10 और 20.](hidden_cells_True.png) | ![सभी कोशिकाएँ: जनवरी, फ़रवरी और मार्च के लिए रिटेल और थोक मान.](hidden_cells_False.png) |

एक मान वाला छिपा सेल खाली सेल से अलग होता है। [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichart/get_displayblanksas/) नियंत्रित करता है कि गुम मान कैसे दिखाए जाएँ; यह छिपा स्रोत डेटा को शामिल या बाहर नहीं करता। उदाहरण के लिए देखें [खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें](/slides/hi/cpp/chart-series/#control-the-display-of-empty-cells)।

## **वर्कबुक से चार्ट डेटा पढ़ना और लिखना**

Aspose.Slides for C++ **नोट** करता है कि चार्ट डेटा को उसी प्रकार व्यवस्थित किया जाना चाहिए या स्रोत के समान संरचना होनी चाहिए।

यह उदाहरण `chart.pptx` खोलता है, जिसमें पहली स्लाइड पर पहला आकार चार्ट होना चाहिए। यह एम्बेडेड वर्कबुक को एक स्ट्रीम में पढ़ता है, मौजूदा सीरीज़ और श्रेणियों को साफ़ करता है, और वही वर्कबुक वापस लिखता है। परिवर्तन मेमोरी में रहते हैं; उदाहरण प्रस्तुति को सहेजता नहीं है।

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

जब आप एम्बेडेड वर्कबुक को संशोधित वर्ज़न से बदलते हैं, तो चार्ट अपनी मूल सीरीज़ और श्रेणी संग्रह बरकरार रखता है। यह असंगति [IChart::ValidateChartLayout](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichart/validatechartlayout/) को इंडेक्स-आउट-ऑफ-रेंज त्रुटि के साथ विफल करा सकती है। अपडेटेड वर्कबुक को वापस लिखने से पहले मौजूदा सीरीज़ और श्रेणियों को साफ़ करें। यह उदाहरण `chart.pptx` की आवश्यकता रखता है जिसमें पहली स्लाइड पर पहला आकार एक चार्ट है। टिप्पणी उस स्थान को दर्शाती है जहाँ वर्कबुक संपादन होगा;Runnable उदाहरण मूल वर्कबुक को वापस लिखता है और मेमोरी में लेआउट सत्यापित करता है।

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

    // यहाँ वर्कबुक स्ट्रीम को संशोधित करें, उदाहरण के लिए, Aspose.Cells का उपयोग करके।

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

सीरीज़ और श्रेणी संग्रह को साफ़ करने से वर्कबुक को वापस लिखने से पहले पुरानी डेटा संदर्भ हट जाते हैं। अपडेटेड वर्कबुक के लिए आवश्यक किसी भी सीरीज़ और श्रेणी मैपिंग को पुनः बनाएं, फिर चार्ट का उपयोग करें।

## **वर्कबुक सेल को चार्ट डेटा लेबल के रूप में सेट करें**

आप वर्कबुक कोशिकाओं के टेक्स्ट को चार्ट डेटा लेबल के रूप में उपयोग कर सकते हैं। निम्न चरण दिखाते हैं कि बबल चार्ट में लेबल को उसके डेटा वर्कबुक की कोशिकाओं से कैसे लिंक किया जाए।

1. Presentation क्लास का एक उदाहरण बनाएं।
1. शून्य-आधारित इंडेक्स से पहली स्लाइड तक पहुंचें।
1. डिफॉल्ट डेटा के साथ एक बबल चार्ट जोड़ें।
1. चार्ट सीरीज़ तक पहुंचें।
1. वर्कबुक सेल को डेटा लेबल के रूप में सेट करें।
1. प्रस्तुति को सहेजें।

यह उदाहरण `chart2.pptx` खोलता है, जिसमें कम से कम एक स्लाइड होनी चाहिए, और डिफॉल्ट डेटा के साथ एक बबल चार्ट जोड़ता है। यह वर्कशीट 0 में सेल A10:A12 को पहली सीरीज़ के पहले तीन लेबल के रूप में उपयोग करता है, कोशिकाओं से लेबल सक्षम करता है, और परिणाम `resultchart.pptx` में सहेजता है।

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

## **वर्कशीट्स प्रबंधित करें**

[IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) मेथड चार्ट वर्कबुक में वर्कशीट्स तक पहुंच प्रदान करता है। यह उदाहरण डिफॉल्ट डेटा के साथ एक पाई चार्ट बनाता है और प्रत्येक वर्कशीट का नाम कंसोल पर प्रिंट करता है।

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

यह उदाहरण डिफॉल्ट डेटा के साथ एक 3D कॉलम चार्ट बनाता है और दो सीरीज़ नाम विभिन्न डेटा स्रोतों का उपयोग कर सेट करता है। पहला नाम स्ट्रिंग लिटरल से आता है; दूसरा वर्कशीट 0 में सेल C1 से। [DataSourceType](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/datasourcetype/) एनेमरेशन प्रत्येक नाम के स्रोत को चुनता है। परिणाम `pres.pptx` में सहेजा जाता है।

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

## **असमर्थित एम्बेडेड वर्कबुक फॉर्मैट्स का पता लगाएँ**

Aspose.Slides कुछ चार्ट में एम्बेडेड Excel बाइनरी वर्कबुक (.xlsb) फॉर्मैट का समर्थन नहीं करता। आप [IChartData](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdata/) पर [get_EmbeddedWorkbookType](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdata/get_embeddedworkbooktype/) मेथड को [WorkbookType](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/workbooktype/) एनेमरेशन के साथ उपयोग करके असमर्थित फॉर्मैट्स का पता लगा सकते हैं और उन चार्ट को स्किप कर सकते हैं। यह उदाहरण `sample.pptx` की पहली स्लाइड पर शपे़स का निरीक्षण करता है, गैर-चार्ट शपे़स को स्किप करता है, और एम्बेडेड .xlsb वर्कबुक वाले प्रत्येक चार्ट के लिए डायग्नोस्टिक संदेश प्रिंट करता है।

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

Aspose.Slides चार्ट के लिए डेटा स्रोत के रूप में बाहरी वर्कबुक का उपयोग समर्थन करता है।

### **बाहरी वर्कबुक बनाएं**

एक एम्बेडेड चार्ट वर्कबुक को फ़ाइल में निर्यात करने और चार्ट को उस बाहरी वर्कबुक से लिंक करने के लिए [ReadWorkbookStream](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) और [SetExternalWorkbook](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) का उपयोग करें।

यह उदाहरण डिफॉल्ट डेटा के साथ एक पाई चार्ट बनाता है, उसकी वर्कबुक को `externalWorkbook1.xlsx` में लिखता है, और आउटपुट स्ट्रीम को बंद करने के बाद फ़ाइल को चार्ट डेटा स्रोत के रूप में असाइन करता है। यह लिंक्ड प्रस्तुति को `externalWorkbook.pptx` में सहेजता है।

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

### **बाहरी वर्कबुक सेट करें**

[SetExternalWorkbook](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) मेथड का उपयोग करके आप किसी चार्ट को बाहरी वर्कबुक को उसके डेटा स्रोत के रूप में असाइन कर सकते हैं। यह मेथड बाहरी वर्कबुक के पथ को अपडेट करने के लिए भी उपयोग किया जा सकता है (यदि वह स्थानांतरित हो गया हो)।

जबकि आप दूरस्थ स्थानों या संसाधनों में संग्रहीत वर्कबुक डेटा को संपादित नहीं कर सकते, आप अभी भी ऐसे वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग कर सकते हैं। यदि बाहरी वर्कबुक के लिए सापेक्ष पथ प्रदान किया जाता है, तो यह स्वचालित रूप से पूर्ण पथ में परिवर्तित हो जाता है।

यह उदाहरण कार्य निर्देशिका में `externalWorkbook.xlsx` की आवश्यकता रखता है। उसकी वर्कशीट `Sheet1` में B1 में एक सीरीज़ नाम, A2:A4 में श्रेणी नाम, और B2:B4 में संख्यात्मक मान होने चाहिए। उदाहरण एक पाई चार्ट बनाता है, वर्कबुक को लिंक करता है, और [SetRange](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdata/setrange/) का उपयोग करके A1:B4 को एक सीरीज़ और तीन श्रेणियों से मैप करता है। यह परिणाम `Presentation_with_externalWorkbook.pptx` में सहेजता है।

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

[SetExternalWorkbook](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) का `updateChartData` पैरामीटर नियंत्रित करता है कि वर्कबुक लोड की जाए या नहीं।

* जब `updateChartData` `false` है, तो केवल वर्कबुक पथ अपडेट होता है। चार्ट डेटा लक्ष्य वर्कबुक से लोड या अपडेट नहीं होता, इसलिए वर्कबुक अनुपलब्ध हो सकती है।
* जब `updateChartData` `true` है, तो चार्ट डेटा लक्ष्य वर्कबुक से अपडेट होता है।

निम्न उदाहरण `updateChartData` को `false` पर सेट करके एक प्लेसहोल्डर URL असाइन करता है। यह पाई चार्ट के डिफॉल्ट डेटा को बरकरार रखता है और अनुपलब्ध वर्कबुक को लोड किए बिना प्रस्तुति सहेजता है।

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

### **चार्ट के बाहरी डेटा स्रोत वर्कबुक पथ को प्राप्त करें**

किसी चार्ट से जुड़ी वर्कबुक को पहचानने के लिए, पहले जाँचें कि क्या चार्ट बाहरी डेटा स्रोत का उपयोग करता है। यदि हाँ, तो निम्न चरणों के साथ वर्कबुक पथ प्राप्त किया जा सकता है।

1. Presentation क्लास का एक उदाहरण बनाएं।
1. शून्य-आधारित इंडेक्स से पहली स्लाइड तक पहुंचें।
1. जाँचें कि पहला आकार एक चार्ट है।
1. चार्ट डेटा स्रोत प्रकार पढ़ें।
1. यदि स्रोत एक बाहरी वर्कबुक है, तो उसका पथ पढ़ें।

यह उदाहरण `externalWorkbook.pptx` खोलता है, जो पिछले उदाहरण में बनाया गया था, और पहली स्लाइड पर पहले आकार का निरीक्षण करता है। यदि वह बाहरी वर्कबुक से लिंक्ड चार्ट है, तो उदाहरण कंसोल पर [get_ExternalWorkbookPath](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdata/get_externalworkbookpath/) प्रिंट करता है। फिर यह प्रस्तुति की एक कॉपी `Result.pptx` में सहेजता है।

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

बाहरी वर्कबुक में डेटा को उसी तरह संपादित किया जा सकता है जैसे आप आंतरिक वर्कबुक की सामग्री को बदलते हैं। जब कोई बाहरी वर्कबुक लोड नहीं हो पाती, तो एक अपवाद फेंका जाता है।

यह उदाहरण `presentation.pptx` की आवश्यकता रखता है जिसमें पहली स्लाइड पर पहला आकार चार्ट है और एक सुलभ बाहरी वर्कबुक है। यह पहली सीरीज़ के पहले डेटा पॉइंट के सेल-बैक्ड मान को 100 सेट करता है और परिणाम `presentation_out.pptx` में सहेजता है। सेल मानों को संपादित करने से लिंक्ड बाहरी XLSX फ़ाइल अपडेट हो सकती है, इसलिए यदि मूल वर्कबुक को संरक्षित रखना है तो एक कॉपी का प्रयोग करें।

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

यदि कोई चार्ट ऐसी बाहरी वर्कबुक का उपयोग करता है जो अनुपलब्ध है, तो Aspose.Slides प्रस्तुति में कैश किए गए डेटा से चार्ट वर्कबुक को पुनर्निर्मित कर सकता है। [LoadOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides/loadoptions/) बनाकर, उसे [set_SpreadsheetOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/) से कॉन्फ़िगर करें, और प्रस्तुति खोलने से पहले [ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/) को `true` के साथ कॉल करें।

निम्न C++ उदाहरण `presentation.pptx` खोलता है, जिसकी पहली स्लाइड पर पहला आकार एक चार्ट होना चाहिए जो अनुपलब्ध बाहरी वर्कबुक को संदर्भित करता है, और पुनः प्राप्त डेटा को [IChart::get_ChartData](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichart/get_chartdata/) और [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) के माध्यम से एक्सेस करता है:

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

    // यहाँ पुनर्प्राप्त कार्यपुस्तिका डेटा को पढ़ें या संशोधित करें।
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

यदि बाहरी वर्कबुक अनुपलब्ध है और पुनर्प्राप्ति अक्षम है, तो Aspose.Slides एक [System::InvalidOperationException](https://reference.aspose.com/slides/hi/cpp/system/details_invalidoperationexception/) फेंकता है। पुनर्प्राप्ति तभी सक्षम करें जब कैश्ड चार्ट डेटा का उपयोग एक स्वीकार्य विकल्प हो, क्योंकि कैश में बाहरी वर्कबुक में अंतिम अपडेट के बाद किए गए परिवर्तन नहीं हो सकते।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं निर्धारित कर सकता हूँ कि कोई विशिष्ट चार्ट बाहरी या एम्बेडेड वर्कबुक से जुड़ा है?**

हां। एक चार्ट का [डेटा स्रोत प्रकार](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) और एक [बाहरी वर्कबुक का पथ](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) होता है; यदि स्रोत बाहरी वर्कबुक है, तो आप पूर्ण पथ पढ़कर सुनिश्चित कर सकते हैं कि बाहरी फ़ाइल उपयोग में है।

**क्या बाहरी वर्कबुक के सापेक्ष पथ समर्थित हैं, और वे कैसे संग्रहीत होते हैं?**

हां। यदि आप सापेक्ष पथ निर्दिष्ट करते हैं, तो यह स्वचालित रूप से पूर्ण पथ में परिवर्तित हो जाता है। प्रस्तुति पूर्ण पथ को PPTX फ़ाइल में संग्रहीत करती है, इसलिए वर्कबुक को स्थानांतरित करने पर लिंक को अपडेट करने की आवश्यकता हो सकती है।

**क्या मैं नेटवर्क संसाधनों/शेयर्स पर स्थित वर्कबुक का उपयोग कर सकता हूँ?**

हां, ऐसे वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग किया जा सकता है। हालांकि, Aspose.Slides से सीधे रिमोट वर्कबुक को संपादित करना समर्थित नहीं है—वे केवल स्रोत के रूप में उपयोग किए जा सकते हैं।

**क्या Aspose.Slides प्रस्तुति सहेजते समय बाहरी XLSX को ओवरराइट करता है?**

प्रेजेंटेशन में [बाहरी फ़ाइल का लिंक](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) संग्रहीत होता है। सेल-बैक्ड चार्ट डेटा को संपादित करने से लिंक्ड स्थानीय XLSX फ़ाइल भी अपडेट हो सकती है। यदि मूल वर्कबुक को बदलना नहीं है तो उसकी एक कॉपी उपयोग करें।

**यदि बाहरी फ़ाइल पासवर्ड‑सुरक्षित है तो क्या करें?**

Aspose.Slides लिंकिंग के समय पासवर्ड स्वीकार नहीं करता। आम तौर पर पहले सुरक्षा हटाना या एक डिक्रिप्टेड कॉपी तैयार करना (उदाहरण के लिए, [Aspose.Cells](https://reference.aspose.com/cells/cpp/)) और उस कॉपी को लिंक करना आवश्यक होता है।

**क्या कई चार्ट एक ही बाहरी वर्कबुक को संदर्भित कर सकते हैं?**

हां। प्रत्येक चार्ट अपना लिंक संग्रहीत करता है। यदि सभी एक ही फ़ाइल की ओर इशारा करते हैं, तो उस फ़ाइल को अपडेट करने से अगली बार डेटा लोड होने पर प्रत्येक चार्ट में परिवर्तन परिलक्षित होंगे।