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
description: "Aspose.Slides for C++ को खोजें: PowerPoint और OpenDocument फॉर्मैट में चार्ट वर्कबुक को आसानी से प्रबंधित करें और अपनी प्रस्तुति डेटा को सुव्यवस्थित करें।"
---
## **परिचय**

यह लेख दर्शाता है कि Aspose.Slides में चार्ट वर्कबुक के साथ कैसे काम किया जाए। यह दिखाता है कि वर्कबुक स्ट्रीम के माध्यम से चार्ट डेटा को कैसे पढ़ा और लिखा जाता है, चार्ट डेटा लेबल के रूप में वर्कबुक सेल्स का उपयोग कैसे किया जाता है, कार्यपत्रक संग्रहों तक कैसे पहुंचा जाए, और चार्ट मानों के लिए डेटा स्रोत प्रकार कैसे निर्दिष्ट किया जाए।

यह बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में उपयोग करने को भी कवर करता है। उदाहरण दर्शाते हैं कि कैसे एक बाहरी वर्कबुक बनाया और असाइन किया जाए, चार्ट से जुड़े बाहरी वर्कबुक का पथ प्राप्त किया जाए, और जब वर्कबुक उपलब्ध हो तो चार्ट डेटा को संपादित किया जाए।

गुम डेटा का प्रतिनिधित्व करने वाले वर्कबुक सेल्स के लिए, देखें [खाली सेल्स के प्रदर्शन को नियंत्रित करें](/slides/hi/cpp/chart-series/) जिसमें खाली सेल और शून्य के बीच अंतर और उपलब्ध प्रदर्शन मोड के लाइन-चार्ट तुलना को समझाया गया है।

## **छिपी हुई पंक्तियों और कॉलमों से डेटा शामिल करना**

[**IChart::set_PlotVisibleCellsOnly**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_plotvisiblecellsonly/) का उपयोग करके नियंत्रित किया जा सकता है कि चार्ट छिपी हुई कार्यपत्रक पंक्तियों और कॉलमों से डेटा प्लॉट करे या नहीं। इसे `true` सेट करने पर केवल दृश्यमान सेल्स प्लॉट होते हैं, और `false` सेट करने पर दृश्यमान तथा छिपी हुई दोनों सेल्स प्लॉट होते हैं। यह सेटिंग चार्ट प्लॉटिंग को नियंत्रित करती है; यह कार्यपत्रक पंक्तियों या कॉलमों को छिपाती या दिखाती नहीं है।

[उदाहरण प्रस्तुति](hidden-source-data.pptx) में पहले स्लाइड की पहली आकृति के रूप में एक कॉलम चार्ट है। एम्बेडेड कार्यपत्रक, `Sheet1`, में निम्नलिखित स्रोत रेंज है, `A1:C4`। पंक्ति 3 और कॉलम C छिपे हुए हैं, लेकिन उनके सेल्स अभी भी मान रखते हैं।

| कार्यपत्रक पंक्ति | A: महीना | B: रिटेल | C: थोक (छिपा कॉलम) |
| --- | --- | --- | --- |
| 2 | जनवरी | 10 | 30 |
| 3 (छिपी हुई पंक्ति) | februari | 40 | 60 |
| 4 | मार्च | 20 | 50 |

स्रोत सेल्स तक पहुंचने के लिए [**IChartData::get_ChartDataWorkbook**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) का उपयोग करें और उनके छिपे होने की स्थिति को जांचने के लिए [**IChartDataCell::get_IsHidden**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/get_ishidden/) पढ़ें। यह प्रॉपर्टी केवल-रीड है। इस फ़ाइल में, B2 दृश्यमान है, B3 छिपी हुई पंक्ति से संबंधित है, और C2 छिपे हुए कॉलम से संबंधित है; उदाहरण क्रमशः `False`, `True`, और `True` प्रिंट करता है।

इस उदाहरण के लिए, प्लॉटिंग सेटिंग बदलने के बाद चार्ट डेटा को रीफ़्रेश करें: एम्बेडेड वर्कबुक को [**ReadWorkbookStream**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) के साथ रखें और इसे [**WriteWorkbookStream**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) से पुनः लोड करें। सभी सेल्स को शामिल करने पर, पूरी रेंज को पुनर्स्थापित करने के लिए [**SetRange**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setrange/) का उपयोग करें, जिसमें छिपी हुई फरवरी श्रेणी भी शामिल हो। केवल फ़्लैग बदलना इस नमूने के कैश्ड चार्ट डेटा और श्रेणी लेबल को रीफ़्रेश करने के लिए पर्याप्त नहीं है।

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

        // एम्बेडेड वर्कबुक से चार्ट डेटा को रीफ़्रेश करें।
        workbookStream->set_Position(0);
        chart->get_ChartData()->WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // छिपी हुई श्रेणियों सहित पूर्ण स्रोत रेंज को पुनर्स्थापित करें।
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

उदाहरण दो संस्करण में प्रस्तुति को सहेजता है: एक में केवल दृश्यमान रिटेल मान (10 और 20) हैं, और दूसरा में सभी छह मान हैं। नीचे की छवियों में दो प्लॉटिंग मोड दिखाए गए हैं। पंक्ति 3 और कॉलम C दोनों एम्बेडेड वर्कबुक में छिपे हुए रहते हैं।

| केवल दृश्यमान सेल्स (`true`) | सभी सेल्स (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

एक मान वाला छिपा हुआ सेल खाली सेल से अलग होता है। [**IChart::get_DisplayBlanksAs**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_displayblanksas/) नियंत्रित करता है कि गुम मान कैसे प्रदर्शित किए जाएँ; यह छिपे हुए स्रोत डेटा को शामिल या बाहर नहीं करता। उदाहरण के लिए देखें [खाली सेल्स के प्रदर्शन को नियंत्रित करें](/slides/hi/cpp/chart-series/#control-the-display-of-empty-cells)।

## **चार्ट के डेटा रेंज को प्राप्त करना**

मौजूदा प्रस्तुति में वर्कबुक डेटा को अपडेट करने से पहले, स्रोत रेंजेस की जाँच करें ताकि यह पहचान सकें कि प्रत्येक चार्ट कौन से कार्यपत्रक सेल्स का उपयोग करता है। [**IChartData::GetRange**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/getrange/) मेथड वर्तमान डेटा रेंज को कार्यपत्रक-योग्य फ़ॉर्मूला के रूप में लौटाता है, जैसे `Sheet1!$A$1:$D$5`। यहाँ, `Sheet1` कार्यपत्रक का नाम है, `!` इसे सेल रेंज से अलग करता है, और `$A$1:$D$5` सेल्स A1 से D5 तक को दर्शाता है, शामिल। डॉलर चिह्न ऐब्सोल्यूट रो और कॉलम रेफरेंस दर्शाते हैं।

यह मेथड चार्ट या उसके वर्कबुक को बदले बिना वर्तमान रेंज को पढ़ता है। यदि चार्ट डेटा स्रोत के रूप में वर्कबुक का उपयोग नहीं करता है, तो यह [**System::InvalidOperationException**](https://reference.aspose.com/slides/cpp/system/details_invalidoperationexception/) फेंकेगा। अधिक जानकारी के लिए देखें [**ChartData API Reference**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/)।

यह उदाहरण एक प्रस्तुति खोलता है और प्रत्येक स्लाइड पर सीधे आकृतियों की जाँच करता है कि वे चार्ट हैं या नहीं। यह प्रत्येक चार्ट का नाम और स्रोत रेंज प्रिंट करता है। यदि कोई चार्ट वर्कबुक का उपयोग नहीं करता, तो यह एक संदेश प्रिंट करता है और अगले चार्ट की ओर बढ़ता है।

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

## **वर्कबुक से चार्ट डेटा पढ़ना और लिखना**

Aspose.Slides for C++ [**ReadWorkbookStream**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) और [**WriteWorkbookStream**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) मेथड प्रदान करता है, जिससे आप चार्ट डेटा वर्कबुक (जिसमें Aspose.Cells के साथ संपादित चार्ट डेटा होता है) को पढ़ और लिख सकते हैं। **Note** कि चार्ट डेटा को उसी तरह संगठित होना चाहिए जैसा स्रोत में है या समान संरचना होनी चाहिए।

यह उदाहरण पहले स्लाइड की पहली आकृति के रूप में एक चार्ट वाली प्रस्तुति का उपयोग करता है। यह एम्बेडेड वर्कबुक को एक स्ट्रीम में पढ़ता है, मौजूदा सीरीज और श्रेणियों को साफ़ करता है, और वही वर्कबुक वापस लिखता है। परिवर्तन मेमोरी में रहते हैं; उदाहरण प्रस्तुति को सहेजता नहीं है।

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

### **वर्कबुक संशोधन के बाद चार्ट लेआउट वैधता जांचना**

जब आप एक संशोधित वर्कबुक को एम्बेडेड वर्कबुक के स्थान पर रखते हैं, तो चार्ट अपनी मूल सीरीज और श्रेणी संग्रहों को बनाए रखता है। यह असंगति [**IChart::ValidateChartLayout**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/validatechartlayout/) को इंडेक्स-आउट-ऑफ-रेंज त्रुटि के साथ फ़ेल कर सकती है। अपडेटेड वर्कबुक को चार्ट में लिखने से पहले मौजूदा सीरीज और श्रेणियों को साफ़ करें। यह उदाहरण पहले स्लाइड की पहली आकृति के रूप में एक चार्ट का उपयोग करता है। टिप्पणी उन भागों को दर्शाती है जहाँ वर्कबुक संपादन होगा; निष्पादनीय उदाहरण मूल वर्कबुक को वापस लिखता है और मेमोरी में लेआउट वैधता जांचता है।

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

संग्रहों को साफ़ करने से वर्कबुक लिखे जाने से पहले पुराने डेटा रेफ़रेंसेज़ हट जाते हैं। अपडेटेड वर्कबुक के लिए आवश्यक किसी भी सीरीज और श्रेणी मैपिंग को पुनः बनाएँ, फिर चार्ट का उपयोग करें।

## **वर्कबुक सेल को चार्ट डेटा लेबल के रूप में सेट करना**

आप वर्कबुक सेल्स से पाठ का उपयोग चार्ट डेटा लेबल के रूप में कर सकते हैं।

यह उदाहरण मौजूद प्रस्तुति की पहली स्लाइड में एक बबल चार्ट डिफ़ॉल्ट डेटा के साथ जोड़ता है। यह कार्यपत्रक 0 में सेल्स A10:A12 को पहले तीन लेबल्स के रूप में उपयोग करता है, सेल्स से लेबल सक्षम करता है, और अपडेटेड प्रस्तुति को सहेजता है।

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

## **वर्कशीट्स का प्रबंधन**

[**IChartDataWorkbook::get_Worksheets**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) मेथड चार्ट वर्कबुक में कार्यपत्रकों तक पहुंच प्रदान करता है। यह उदाहरण एक पाई चार्ट डिफ़ॉल्ट डेटा के साथ बनाता है और प्रत्येक कार्यपत्रक नाम को कंसोल पर प्रिंट करता है।

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

## **डेटा स्रोत प्रकार निर्दिष्ट करना**

यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक 3D कॉलम चार्ट बनाता है और दो सीरीज नाम अलग-अलग डेटा स्रोतों का उपयोग करके सेट करता है। पहला नाम स्ट्रिंग लिटरल का उपयोग करता है; दूसरा कार्यपत्रक 0 में सेल C1 का उपयोग करता है। [**DataSourceType**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/datasourcetype/) एनीमरेशन प्रत्येक नाम के लिए स्रोत का चयन करता है। उदाहरण अपडेटेड सीरीज नामों के साथ प्रस्तुति को सहेजता है।

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

## **असमर्थित एम्बेडेड वर्कबुक फ़ॉर्मेट का पता लगाना**

Aspose.Slides उन Excel बाइनरी वर्कबुक (.xlsb) फ़ॉर्मेट का समर्थन नहीं करता जिसे कुछ चार्ट में एम्बेड किया जा सकता है। आप [**get_EmbeddedWorkbookType**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_embeddedworkbooktype/) मेथड को [**IChartData**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/) के साथ और [**WorkbookType**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/workbooktype/) एनीमरेशन का उपयोग करके असमर्थित फ़ॉर्मेट का पता लगा सकते हैं और उन चार्ट्स को स्किप कर सकते हैं। यह उदाहरण मौजूद प्रस्तुति की पहली स्लाइड पर आकृतियों की जाँच करता है, गैर-चार्ट आकृतियों को छोड़ता है, और प्रत्येक चार्ट जिसके साथ एम्बेडेड .xlsb वर्कबुक है, उसके लिए एक डायग्नोस्टिक संदेश प्रिंट करता है।

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

Aspose.Slides चार्ट्स के लिए डेटा स्रोत के रूप में बाहरी वर्कबुक का उपयोग समर्थन करता है।

### **बाहरी वर्कबुक बनाना**

[**ReadWorkbookStream**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) और [**SetExternalWorkbook**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) का उपयोग करके एम्बेडेड चार्ट वर्कबुक को एक फ़ाइल में निर्यात करें और चार्ट को उस बाहरी वर्कबुक से लिंक करें।

यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक पाई चार्ट बनाता है और उसकी वर्कबुक निर्यात करता है। यह आउटपुट स्ट्रीम को बंद करता है, फिर बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में असाइन करता है, और लिंक्ड प्रस्तुति को सहेजता है।

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

### **बाहरी वर्कबुक सेट करना**

[**SetExternalWorkbook**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) मेथड का उपयोग करके आप किसी चार्ट के डेटा स्रोत के रूप में बाहरी वर्कबुक असाइन कर सकते हैं। यह मेथड बाहरी वर्कबुक के पथ को अपडेट करने के लिए भी उपयोग किया जा सकता है (यदि वह स्थानांतरित कर दी गई हो)।

आप रिमोट स्थानों या संसाधनों में संग्रहीत वर्कबुक के डेटा को संपादित नहीं कर सकते, परंतु ऐसे वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग किया जा सकता है। यदि बाहरी वर्कबुक के लिए सापेक्ष पथ दिया जाता है, तो वह स्वतः ही पूर्ण पथ में परिवर्तित हो जाता है।

यह उदाहरण एक बाहरी वर्कबुक का उपयोग करता है जिसमें कार्यपत्रक `Sheet1` में B1 में एक सीरीज नाम, A2:A4 में श्रेणी नाम, और B2:B4 में संख्यात्मक मान हैं। उदाहरण एक पाई चार्ट बनाता है, वर्कबुक लिंक करता है, और [**SetRange**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setrange/) का उपयोग करके A1:B4 को एक सीरीज और तीन श्रेणियों के रूप में मैप करता है। यह लिंक्ड चार्ट के साथ प्रस्तुति को सहेजता है।

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

[**SetExternalWorkbook**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) का `updateChartData` पैरामीटर नियंत्रित करता है कि वर्कबुक लोड किया जाए या नहीं।

* जब `updateChartData` `false` हो, तो केवल वर्कबुक पथ अपडेट होता है। चार्ट डेटा लक्ष्य वर्कबुक से लोड या अपडेट नहीं होता, इसलिए वर्कबुक अनुपलब्ध हो भी सकती है।
* जब `updateChartData` `true` हो, तो चार्ट डेटा लक्ष्य वर्कबुक से अपडेट होता है।

निम्न उदाहरण `updateChartData` को `false` सेट करके एक प्लेसहोल्डर URL असाइन करता है। यह पाई चार्ट के डिफ़ॉल्ट डेटा को बरकरार रखता है और अनुपलब्ध वर्कबुक को लोड किए बिना प्रस्तुति को सहेजता है।

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

### **चार्ट के बाहरी डेटा स्रोत वर्कबुक पथ को प्राप्त करना**

किसी चार्ट से जुड़े वर्कबुक की पहचान करने के लिए, जाँचें कि क्या चार्ट बाहरी डेटा स्रोत का उपयोग करता है और उसके वर्कबुक पथ को प्राप्त करें।

यह उदाहरण एक प्रस्तुति में पहली स्लाइड की पहली आकृति की जाँच करता है, जहाँ वह एक बाहरी वर्कबुक से लिंक्ड चार्ट है। यदि ऐसा है, तो यह कंसोल पर [**get_ExternalWorkbookPath**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_externalworkbookpath/) प्रिंट करता है। फिर यह प्रस्तुति की एक कॉपी सहेजता है।

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

### **चार्ट डेटा को संपादित करना**

आप बाहरी वर्कबुक के डेटा को उसी तरह संपादित कर सकते हैं जैसे आप आंतरिक वर्कबुक के कंटेंट को बदलते हैं। जब कोई बाहरी वर्कबुक लोड नहीं हो पाती, तो एक अपवाद फेंका जाता है।

यह उदाहरण पहली स्लाइड की पहली आकृति के रूप में एक चार्ट उपयोग करता है और उसे एक सुलभ बाहरी वर्कबुक से लिंक करता है। यह पहली सीरीज के पहले डेटा पॉइंट का सेल-आधारित मान 100 सेट करता है और अपडेटेड प्रस्तुति को सहेजता है। सेल मानों को संपादित करने से लिंक्ड बाहरी XLSX फ़ाइल अपडेट हो सकती है, इसलिए यदि मूल वर्कबुक को संरक्षित रखना है तो एक कॉपी का उपयोग करें।

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

### **चार्ट कैश से वर्कबुक को पुनर्प्राप्त करना**

यदि कोई चार्ट एक बाहरी वर्कबुक का उपयोग करता है जो अनुपलब्ध या गायब है, तो Aspose.Slides प्रस्तुति में कैश किए गए डेटा से चार्ट वर्कबुक को पुनर्निर्मित कर सकता है। [**LoadOptions**](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/) बनाएं, इसे [**set_SpreadsheetOptions**](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/) से कॉन्फ़िगर करें, और प्रस्तुति खोलने से पहले [**ISpreadsheetOptions::set_RecoverWorkbookFromChartCache**](https://reference.aspose.com/slides/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/) को `true` सेट करें।

निम्न C++ उदाहरण एक चार्ट के लिए वर्कबुक डेटा पुनर्प्राप्त करता है जो पहली स्लाइड की पहली आकृति है और एक अनुपलब्ध बाहरी वर्कबुक का संदर्भ देता है। यह पुनर्प्राप्त डेटा को [**IChart::get_ChartData**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_chartdata/) और [**IChartData::get_ChartDataWorkbook**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) के माध्यम से एक्सेस करता है:

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

यदि बाहरी वर्कबुक उपलब्ध नहीं है और रिकवरी अक्षम है, तो Aspose.Slides एक [**System::InvalidOperationException**](https://reference.aspose.com/slides/cpp/system/details_invalidoperationexception/) फेंकता है। रिकवरी तभी सक्षम करें जब कैश्ड चार्ट डेटा का उपयोग एक स्वीकार्य फॉलबैक हो, क्योंकि कैश में बाहरी वर्कबुक में किए गए परिवर्तन शामिल नहीं हो सकते।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं निर्धारित कर सकता हूँ कि कोई विशेष चार्ट बाहरी या एम्बेडेड वर्कबुक से लिंक्ड है?**

हां। एक चार्ट के पास एक [**डेटा स्रोत प्रकार**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) और एक [**बाहरी वर्कबुक का पथ**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) होता है; यदि स्रोत एक बाहरी वर्कबुक है, तो आप पूर्ण पथ पढ़कर सुनिश्चित कर सकते हैं कि बाहरी फ़ाइल उपयोग हो रही है।

**क्या बाहरी वर्कबुक के सापेक्ष पथ समर्थित हैं, और वे कैसे संग्रहीत होते हैं?**

हां। यदि आप सापेक्ष पथ निर्दिष्ट करते हैं, तो वह स्वतः ही पूर्ण पथ में परिवर्तित हो जाता है। प्रस्तुति PPTX फ़ाइल में पूर्ण पथ संग्रहीत करती है, इसलिए वर्कबुक को स्थानांतरित करने पर लिंक को अपडेट करने की आवश्यकता पड़ सकती है।

**क्या मैं नेटवर्क संसाधनों/शेयरों पर स्थित वर्कबुक का उपयोग कर सकता हूँ?**

हां, ऐसी वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग किया जा सकता है। हालांकि, Aspose.Slides द्वारा रिमोट वर्कबुक को सीधे संपादित करना समर्थित नहीं है—वे केवल स्रोत के रूप में उपयोग की जा सकती हैं।

**क्या Aspose.Slides प्रस्तुति सहेजते समय बाहरी XLSX को ओवरराइट करता है?**

प्रस्तुति एक [**बाहरी फ़ाइल के लिंक**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) को संग्रहीत करती है। सेल-आधारित चार्ट डेटा को संपादित करने से लिंक्ड स्थानीय XLSX फ़ाइल भी अपडेट हो सकती है। यदि मूल वर्कबुक को अपरिवर्तित रखना है, तो उसके एक कॉपी का उपयोग करें।

**यदि बाहरी फ़ाइल पासवर्ड-संरक्षित है तो क्या किया जाए?**

Aspose.Slides लिंक करते समय पासवर्ड स्वीकार नहीं करता। एक सामान्य तरीका यह है कि पहले सुरक्षा हटाई जाए या एक डिक्रिप्टेड कॉपी तैयार की जाए (उदाहरण के लिए, [Aspose.Cells](https://reference.aspose.com/cells/cpp/) का उपयोग करके) और उस कॉपी को लिंक किया जाए।

**क्या कई चार्ट एक ही बाहरी वर्कबुक को संदर्भित कर सकते हैं?**

हां। प्रत्येक चार्ट अपना लिंक संग्रहीत करता है। यदि सभी एक ही फ़ाइल की ओर इशारा करते हैं, तो उस फ़ाइल में किए गए अपडेट अगली बार डेटा लोड होने पर सभी चार्ट में परिलक्षित होंगे।