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
- बाहरी कार्यपुस्तिका
- बाहरी डेटा
- चार्ट कैश
- वर्कबुक पुनःप्राप्ति
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ की खोज करें: PowerPoint और OpenDocument स्वरूपों में चार्ट कार्यपुस्तिकाओं को आसानी से प्रबंधित करें ताकि आपकी प्रस्तुति डेटा को सुव्यवस्थित किया जा सके।"
---
## **अवलोकन**

यह लेख Aspose.Slides में चार्ट वर्कबुक के साथ काम करने का तरीका बताता है। यह दिखाता है कि वर्कबुक स्ट्रीम के माध्यम से चार्ट डेटा को कैसे पढ़ा और लिखा जाता है, वर्कबुक सेल्स को चार्ट डेटा लेबल्स के रूप में कैसे उपयोग किया जाता है, वर्कशीट संग्रह तक कैसे पहुँच प्राप्त की जाती है, और चार्ट मानों के डेटा स्रोत प्रकार को कैसे निर्धारित किया जाता है।

यह बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में उपयोग करने को भी कवर करता है। उदाहरण दर्शाते हैं कि कैसे एक बाहरी वर्कबुक बनाकर उसे असाइन किया जाए, चार्ट से जुड़ी बाहरी वर्कबुक का पाथ कैसे प्राप्त किया जाए, और वर्कबुक उपलब्ध होने पर चार्ट डेटा को कैसे संपादित किया जाए।

गुम डेटा का प्रतिनिधित्व करने वाले वर्कबुक सेल्स के बारे में, देखें [खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें](/slides/hi/cpp/chart-series/) जहाँ खाली सेल और शून्य के बीच अंतर तथा उपलब्ध डिस्प्ले मोड्स की लाइन‑चार्ट तुलना बताई गई है।

## **छिपी पंक्तियों और स्तंभों से डेटा शामिल करें**

[**IChart::set_PlotVisibleCellsOnly**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_plotvisiblecellsonly/) का उपयोग करके यह नियंत्रित किया जाता है कि चार्ट छिपी वर्कशीट पंक्तियों और स्तंभों से डेटा प्लॉट करे या नहीं। इसे `true` सेट करने पर केवल दृश्यमान कोशिकाएँ प्लॉट होती हैं, और `false` सेट करने पर दृश्यमान एवं छिपी दोनों कोशिकाएँ शामिल होती हैं। यह सेटिंग केवल चार्ट प्लॉटिंग को नियंत्रित करती है; यह वर्कशीट पंक्तियों या स्तंभों को छिपाती या दिखाती नहीं है।

[नमूना प्रस्तुति](hidden-source-data.pptx) में पहली स्लाइड पर पहला आकार एक कॉलम चार्ट है। एम्बेडेड वर्कशीट, `Sheet1`, में स्रोत रेंज `A1:C4` है। पंक्ति 3 और स्तंभ C छिपे हुए हैं, लेकिन उनकी कोशिकाओं में अभी भी मान मौजूद हैं।

| वर्कशीट पंक्ति | A: माह | B: रिटेल | C: थोक (छिपा स्तंभ) |
| --- | --- | --- | --- |
| 2 | जनवरी | 10 | 30 |
| 3 (छिपी पंक्ति) | फ़रवरी | 40 | 60 |
| 4 | मार्च | 20 | 50 |

स्रोत कोशिकाओं तक पहुँचने के लिए [**IChartData::get_ChartDataWorkbook**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) का उपयोग करें और उनकी छिपी स्थिति का निरीक्षण करने के लिए [**IChartDataCell::get_IsHidden**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/get_ishidden/) पढ़ें। यह प्रॉपर्टी केवल‑पढ़ने योग्य है। इस फ़ाइल में, B2 दृश्यमान है, B3 छिपी पंक्ति से संबंधित है, और C2 छिपे स्तंभ से संबंधित है; उदाहरण क्रमशः `False`, `True`, और `True` प्रदर्शित करता है।

इस उदाहरण में, प्लॉटिंग सेटिंग बदलने के बाद चार्ट डेटा को रिफ्रेश करें: एम्बेडेड वर्कबुक को [**ReadWorkbookStream**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) से रखें और उसे [**WriteWorkbookStream**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) से पुनः लोड करें। सभी कोशिकाओं को शामिल करते समय, छिपी फ़रवरी श्रेणी को पुनर्स्थापित करने के लिए [**SetRange**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setrange/) का उपयोग करें। केवल फ़्लैग बदलना इस उदाहरण के कैश किए गए चार्ट डेटा और श्रेणी लेबल्स को रिफ्रेश करने के लिये पर्याप्त नहीं है।

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

        // एम्बेडेड कार्यपुस्तिका से चार्ट डेटा को रीफ़्रेश करें।
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

उदाहरण दो संस्करणों की प्रस्तुति को सहेजता है: एक जिसमें केवल दृश्यमान रिटेल मान (10 और 20) हैं, और दूसरा जिसमें सभी छह मान हैं। नीचे दी गई छवियों में दो प्लॉट मोड दिखाए गए हैं। पंक्ति 3 और स्तंभ C दोनों एम्बेडेड वर्कबुक में छिपे हुए रहते हैं।

| केवल दृश्यमान कोशिकाएँ (`true`) | सभी कोशिकाएँ (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

एक मान वाले छिपे हुए सेल का व्यवहार खाली सेल से अलग होता है। [**IChart::get_DisplayBlanksAs**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_displayblanksas/) नियंत्रित करता है कि लापता मान कैसे दिखाए जाएँ; यह छिपे स्रोत डेटा को शामिल या अपवर्जित नहीं करता। उदाहरण के लिये देखें [खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें](/slides/hi/cpp/chart-series/#control-the-display-of-empty-cells)।

## **चार्ट के डेटा रेंज को प्राप्त करें**

किसी मौजूदा प्रस्तुति में वर्कबुक डेटा को अपडेट करने से पहले, स्रोत रेंजेस की जाँच करें ताकि यह पहचाना जा सके कि प्रत्येक चार्ट कौन सी वर्कशीट कोशिकाओं का उपयोग करता है। [**IChartData::GetRange**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/getrange/) मेथड वर्तमान डेटा रेंज को वर्कशीट‑योग्य फ़ॉर्मूला के रूप में लौटाता है, जैसे `Sheet1!$A$1:$D$5`। यहाँ `Sheet1` वर्कशीट का नाम है, `!` इसे कोशिका रेंज से अलग करता है, और `$A$1:$D$5` कोशिकाएँ A1‑D5 को समाहित करता है। डॉलर साइन स्थायी पंक्ति एवं स्तंभ रेफ़रेंस को दर्शाते हैं।

यह मेथड चार्ट या उसकी वर्कबुक को बदले बिना वर्तमान रेंज पढ़ता है। यदि चार्ट डेटा स्रोत के रूप में वर्कबुक का उपयोग नहीं करता, तो यह [**System::InvalidOperationException**](https://reference.aspose.com/slides/cpp/system/details_invalidoperationexception/) थ्रो करता है। अधिक जानकारी के लिये देखें [**ChartData API Reference**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/)।

यह उदाहरण प्रस्तुति को खोलता है और प्रत्येक स्लाइड पर सीधे आकारों की जाँच करता है ताकि चार्ट मिले। यह प्रत्येक चार्ट का नाम और स्रोत रेंज प्रिंट करता है। यदि कोई चार्ट वर्कबुक का उपयोग नहीं करता, तो यह एक संदेश प्रिंट करके अगले चार्ट पर जारी रहता है।

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

Aspose.Slides for C++ [**ReadWorkbookStream**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) और [**WriteWorkbookStream**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) मेथड प्रदान करता है जिससे आप चार्ट डेटा वर्कबुक (जिसमें Aspose.Cells के साथ संपादित डेटा होता है) को पढ़ और लिख सकते हैं। **ध्यान दें** कि चार्ट डेटा को उसी तरीके से व्यवस्थित किया जाना चाहिए या स्रोत के समान संरचना रखनी चाहिए।

यह उदाहरण पहली स्लाइड पर प्रथम आकार के रूप में मौजूद एक चार्ट वाली प्रस्तुति का उपयोग करता है। यह एम्बेडेड वर्कबुक को स्ट्रीम में पढ़ता है, मौजूदा सीरीज़ व श्रेणियों को साफ़ करता है, और वही वर्कबुक वापस लिखता है। परिवर्तन मेमोरी में रहते हैं; इस उदाहरण में प्रस्तुति को सहेजा नहीं जाता।

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

### **वर्कबुक संशोधन के बाद चार्ट लेआउट को सत्यापित करें**

जब आप संशोधित वर्कबुक को एम्बेडेड वर्कबुक के स्थान पर रखते हैं, तो चार्ट अपनी मूल सीरीज़ व श्रेणी संग्रह को बरकरार रखता है। यह असंगति [**IChart::ValidateChartLayout**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/validatechartlayout/) को इंडेक्स‑आउट‑ऑफ‑रेंज त्रुटि के साथ फेल कर सकती है। अपडेटेड वर्कबुक को वापस लिखने से पहले मौजूदा सीरीज़ व श्रेणियों को साफ़ करें। यह उदाहरण पहली स्लाइड पर पहला आकार वाला चार्ट उपयोग करता है। टिप्पणी उन स्थानों को दर्शाती है जहाँ वर्कबुक संपादन किया जा सकता है; चलने योग्य उदाहरण मूल वर्कबुक को वापस लिखता है और मेमोरी में लेआउट को वैध करता है।

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

    // वर्कबुक स्ट्रीम को यहाँ संशोधित करें, उदाहरण के लिए, Aspose.Cells का उपयोग करके.

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

कलेक्शन को साफ़ करने से वर्कबुक लिखे जाने से पहले पुराने डेटा रेफ़रेंसेज़ हट जाती हैं। अपडेटेड वर्कबुक के लिये आवश्यक सीरीज़ और श्रेणी मैपिंग को पुनः बनाएँ तथा चार्ट का उपयोग करें।

## **वर्कबुक कोशिकाओं के लिये कस्टम नंबर फ़ॉर्मेट सेट करें**

[**IChartDataCell::set_CustomNumberFormat**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/set_customnumberformat/) का उपयोग करके आप यह नियंत्रित कर सकते हैं कि संख्यात्मक मान एम्बेडेड वर्कबुक में चार्ट में कैसे दिखें। उदाहरण के लिये, एक रिपोर्ट में परिवर्तन दर को चार दशमलव अंकों के साथ प्रतिशत के रूप में तथा गुणांक को पाँच दशमलव अंकों के साथ दिखाना पड़ सकता है। दोनों मानों को संख्यात्मक रखें ताकि वे गणनाओं और चार्ट प्लॉटिंग के लिये उपलब्ध रहें।

नंबर फ़ॉर्मेट केवल दर्शाता है, संग्रहीत मान नहीं बदलता। फ़ॉर्मेट `0.0000%` संख्या `0.125` को `12.5000%` दिखाता है; यह संग्रहीत संख्या को `12.5` नहीं बनाता। इसी प्रकार, `0.00000` संख्या `0.1234567` को `0.12346` दिखाता है बिना संग्रहीत मान को गोल किए। यदि कस्टम फ़ॉर्मेट खाली स्ट्रिंग (`""`) है, तो [**set_PresetNumberFormat**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/set_presetnumberformat/) द्वारा असाइन किया गया फ़ॉर्मेट उपयोग किया जाता है।

निम्न उदाहरण एक कॉलम चार्ट बनाता है और उसकी कोशिकाओं तक पहुँचता है [**IChartData::get_ChartDataWorkbook**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) द्वारा। वर्कशीट 0 में, B2 में परिवर्तन दर और C2 में गुणांक है। दोनों कोशिकाएँ चार्ट मूल्यों को प्रदान करती हैं। उदाहरण लेबल्स को स्रोत फ़ॉर्मेट से लिंक करने के लिये भी सक्षम करता है।

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

वर्कबुक सेल फ़ॉर्मेट्स चार्ट अक्ष या डेटा लेबल्स पर सीधे सेट किए गये फ़ॉर्मेट्स से अलग होते हैं। इस उदाहरण में, प्रत्येक लेबल अपने स्रोत सेल का मान दिखाता है क्योंकि [**set_ShowValue**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_showvalue/) को `true` किया गया है, तथा स्रोत नंबर फ़ॉर्मेट को लिंक करने के लिये [**set_IsNumberFormatLinkedToSource**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_isnumberformatlinkedtosource/) को `true` किया गया है। प्रस्तुति को सहेजने और पुनः खोलने के बाद, लेबल्स क्रमशः `12.5000%` और `0.12346` दिखाते हैं, जैसा कि नीचे दिखाया गया है। वर्टिकल ऐक्सिस अपना स्वयं का फ़ॉर्मेट `0.00` उपयोग करता है, जो [**set_NumberFormat**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_numberformat/) के द्वारा सेट किया गया है, और इसके लिए [**set_IsNumberFormatLinkedToSource**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isnumberformatlinkedtosource/) को `false` किया गया है।

किसी डेटा लेबल को स्वतंत्र रूप से फ़ॉर्मेट करने के लिये, उसके स्रोत‑लिंक फ़्लैग को `false` सेट करें और फ़ॉर्मेट को [**set_NumberFormat**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_numberformat/) के द्वारा असाइन करें। यह वर्कबुक सेल के फ़ॉर्मेट को नहीं बदलता। उदाहरण के लिये, स्वतंत्र लेबल फ़ॉर्मेट `0.00` पहला मान `0.13` दिखाएगा, जबकि B2 अभी भी `12.5000%` दिखाएगा। अधिक जानकारी के लिये देखें [**Chart Data Labels**](/slides/hi/cpp/chart-data-label/#set-percentage-sign-with-chart-data-labels)।

नीचे की छवि सहेजी गई प्रस्तुति को पुनः खोलने के बाद रेंडर की गई है:

![Column chart with source-linked labels showing 12.5000% and 0.12346 and an independently formatted numeric axis.](custom-cell-formats.png)

## **वर्कबुक सेल को चार्ट डेटा लेबल के रूप में सेट करें**

आप वर्कबुक कोशिकाओं के पाठ को चार्ट डेटा लेबल के रूप में उपयोग कर सकते हैं।

यह उदाहरण मौजूदा प्रस्तुति की पहली स्लाइड पर एक बबल चार्ट जोड़ता है जिसमें डिफ़ॉल्ट डेटा होता है। यह प्रथम श्रृंखला के पहले तीन लेबल्स हेतु वर्कशीट 0 की कोशिकाएँ A10:A12 उपयोग करता है, लेबल्स को कोशिकाओं से सक्षम करता है, और अपडेटेड प्रस्तुति को सहेजता है।

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

## **वर्कशीट्स का प्रबंधन करें**

[**IChartDataWorkbook::get_Worksheets**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) मेथड चार्ट वर्कबुक में मौजूद वर्कशीट्स तक पहुँच प्रदान करता है। यह उदाहरण एक पाई चार्ट बनाता है जिसमें डिफ़ॉल्ट डेटा है और प्रत्येक वर्कशीट नाम को कंसोल पर प्रिंट करता है।

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

यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक 3D कॉलम चार्ट बनाता है और दो सीरीज़ नामों को विभिन्न डेटा स्रोतों के साथ सेट करता है। पहला नाम स्ट्रिंग लिटरल से सेट किया गया है; दूसरा नाम वर्कशीट 0 के सेल C1 से लिया गया है। [**DataSourceType**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/datasourcetype/) एनेमरेशन प्रत्येक नाम के स्रोत को चुनता है। उदाहरण अपडेटेड सीरीज़ नामों के साथ प्रस्तुति को सहेजता है।

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

## **एंबेडेड वर्कबुक के असहाय फ़ॉर्मेट्स का पता लगाएँ**

Aspose.Slides उन Excel बाइनरी वर्कबुक (.xlsb) फ़ॉर्मेट को सपोर्ट नहीं करता जो कुछ चार्ट्स में एंबेडेड हो सकते हैं। आप [**get_EmbeddedWorkbookType**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_embeddedworkbooktype/) मेथड को [**IChartData**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/) के साथ और [**WorkbookType**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/workbooktype/) एनेमरेशन के साथ उपयोग करके असहाय फ़ॉर्मेट्स का पता लगा सकते हैं और उन चार्ट्स को स्किप कर सकते हैं। यह उदाहरण मौजूदा प्रस्तुति की पहली स्लाइड पर आकारों की जाँच करता है, गैर‑चार्ट आकारों को छोड़ता है, और .xlsb एंबेडेड वर्कबुक वाले प्रत्येक चार्ट के लिये निदान संदेश प्रिंट करता है।

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

Aspose.Slides चार्ट्स के लिये डेटा स्रोत के रूप में बाहरी वर्कबुक का उपयोग समर्थन करता है।

### **एक बाहरी वर्कबुक बनाएँ**

[**ReadWorkbookStream**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) और [**SetExternalWorkbook**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) का उपयोग करके एंबेडेड चार्ट वर्कबुक को फ़ाइल में निर्यात करें और चार्ट को उस बाहरी वर्कबुक से लिंक करें।

यह उदाहरण एक पाई चार्ट बनाता है जिसमें डिफ़ॉल्ट डेटा है और उसकी वर्कबुक को निर्यात करता है। बाहरी वर्कबुक को डेटा स्रोत के रूप में असाइन करने से पहले आउटपुट स्ट्रीम को बंद करता है, फिर लिंक्ड प्रस्तुति को सहेजता है।

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

[**SetExternalWorkbook**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) मेथड के द्वारा आप किसी चार्ट को बाहरी वर्कबुक को डेटा स्रोत के रूप में असाइन कर सकते हैं। यह मेथड बाहरी वर्कबुक के पाथ को अपडेट करने के लिये भी उपयोग किया जा सकता है (यदि वर्कबुक को स्थानांतरित किया गया हो)।

रिमोट लोकेशन या रिसोर्स में संग्रहीत वर्कबुक के डेटा को आप सीधे संपादित नहीं कर सकते, परन्तु उन्हें बाहरी डेटा स्रोत के रूप में उपयोग किया जा सकता है। यदि बाहरी वर्कबुक के लिये रिलेटिव पाथ प्रदान किया गया है, तो वह स्वतः पूर्ण पाथ में परिवर्तित हो जाता है।

यह उदाहरण एक बाहरी वर्कबुक का उपयोग करता है जिसकी वर्कशीट `Sheet1` में B1 में सीरीज़ नाम, A2:A4 में श्रेणी नाम, और B2:B4 में संख्यात्मक मान हैं। उदाहरण पाई चार्ट बनाता है, वर्कबुक को लिंक करता है, और [**SetRange**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setrange/) का प्रयोग करके A1:B4 को एक सीरीज़ व तीन श्रेणियों से मैप करता है। लिंक्ड चार्ट के साथ प्रस्तुति को सहेजता है।

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

[**SetExternalWorkbook**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) का `updateChartData` पैरामीटर यह नियंत्रित करता है कि वर्कबुक लोड की जाए या नहीं।

* जब `updateChartData` `false` हो, तो केवल वर्कबुक पाथ अपडेट होता है। चार्ट डेटा लक्ष्य वर्कबुक से लोड या अपडेट नहीं होता, इसलिए वर्कबुक उपलब्ध नहीं भी हो सकती।
* जब `updateChartData` `true` हो, तो चार्ट डेटा लक्ष्य वर्कबुक से अपडेट हो जाता है।

निम्न उदाहरण एक प्लेसहोल्डर URL को `updateChartData` `false` के साथ असाइन करता है। यह पाई चार्ट के डिफ़ॉल्ट डेटा को बरकरार रखता है और अनुपलब्ध वर्कबुक को लोड किए बिना प्रस्तुति को सहेजता है।

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

### **एक चार्ट के बाहरी डेटा स्रोत वर्कबुक पाथ को प्राप्त करें**

किसी चार्ट से जुड़े वर्कबुक को पहचानने के लिये, जाँचें कि क्या चार्ट बाहरी डेटा स्रोत का उपयोग कर रहा है और उसका वर्कबुक पाथ प्राप्त करें।

यह उदाहरण एक प्रस्तुति में पहली स्लाइड के पहले आकार को जांचता है जिसमें बाहरी वर्कबुक लिंकटेड है। यदि वह आकार एक चार्ट है और बाहरी वर्कबुक से जुड़ा है, तो यह कंसोल पर [**get_ExternalWorkbookPath**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_externalworkbookpath/) को प्रिंट करता है। फिर यह प्रस्तुति की एक कॉपी सहेजता है।

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

आप बाहरी वर्कबुक में डेटा को उसी तरह संपादित कर सकते हैं जैसे आप आंतरिक वर्कबुक में करते हैं। जब कोई बाहरी वर्कबुक लोड नहीं हो पाती, तो अपवाद फेंका जाता है।

यह उदाहरण पहली स्लाइड पर पहला आकार वाला एक चार्ट उपयोग करता है जो सुलभ बाहरी वर्कबुक से जुड़ा है। यह पहली सीरीज़ के पहले डेटा पॉइंट के सेल‑बैक्ड मान को 100 सेट करता है और अपडेटेड प्रस्तुति को सहेजता है। सेल मानों को संपादित करने से लिंक्ड बाहरी XLSX फ़ाइल अपडेट हो सकती है, इसलिए मूल वर्कबुक को संरक्षित रखने के लिये एक कॉपी का उपयोग करें।

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

### **चार्ट कैश से वर्कबुक पुनर्स्थापित करें**

यदि कोई चार्ट बाहरी वर्कबुक का उपयोग करता है जो गायब या अनुपलब्ध है, तो Aspose.Slides प्रस्तुति में कैश किए गए डेटा से चार्ट वर्कबुक को पुनर्निर्मित कर सकता है। [**LoadOptions**](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/) बनाएं, उसे [**set_SpreadsheetOptions**](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/) से कॉन्फ़िगर करें, और प्रस्तुति खोलने से पहले [**ISpreadsheetOptions::set_RecoverWorkbookFromChartCache**](https://reference.aspose.com/slides/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/) को `true` सेट करें।

निम्न C++ उदाहरण पहली स्लाइड पर पहला आकार वाला चार्ट जिसके पास अनुपलब्ध बाहरी वर्कबुक है, के लिये वर्कबुक डेटा को पुनर्स्थापित करता है। यह पुनःप्राप्त डेटा को [**IChart::get_ChartData**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_chartdata/) और [**IChartData::get_ChartDataWorkbook**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) के माध्यम से एक्सेस करता है:

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

    // पुनः प्राप्त वर्कबुक डेटा को यहाँ पढ़ें या संशोधित करें।
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

यदि बाहरी वर्कबुक अनुपलब्ध है और रिकवरी अक्षम है, तो Aspose.Slides [**System::InvalidOperationException**](https://reference.aspose.com/slides/cpp/system/details_invalidoperationexception/) थ्रो करता है। केवल तभी रिकवरी सक्षम करें जब कैश्ड चार्ट डेटा को उपयोग करना स्वीकार्य फ़ॉलबैक हो, क्योंकि कैश में बाहरी वर्कबुक में प्रस्तुतिकरण के अंतिम अपडेट के बाद किए गए परिवर्तन शामिल नहीं हो सकते।

## **FAQ**

**क्या मैं निर्धारित कर सकता हूँ कि कोई विशेष चार्ट बाहरी या एंबेडेड वर्कबुक से जुड़ा है?**

हाँ। एक चार्ट का [**data source type**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) और एक [**path to an external workbook**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) होता है; यदि स्रोत बाहरी वर्कबुक है, तो आप पूर्ण पाथ पढ़कर सुनिश्चित कर सकते हैं कि बाहरी फ़ाइल उपयोग में है।

**क्या बाहरी वर्कबुक के लिये रिलेटिव पाथ सपोर्टेड हैं, और वे कैसे संग्रहीत होते हैं?**

हाँ। यदि आप रिलेटिव पाथ निर्दिष्ट करते हैं, तो वह स्वतः पूर्ण पाथ में परिवर्तित हो जाता है। प्रस्तुति इस पूर्ण पाथ को PPTX फ़ाइल में संग्रहीत करती है, इसलिए वर्कबुक को स्थानांतरित करने पर लिंक को अपडेट करना पड़ सकता है।

**क्या मैं नेटवर्क रिसोर्स/शेयर पर स्थित वर्कबुक का उपयोग कर सकता हूँ?**

हाँ, ऐसी वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग किया जा सकता है। हालांकि, Aspose.Slides से रिमोट वर्कबुक को सीधे संपादित करना समर्थित नहीं है—वे केवल स्रोत के रूप में उपयोग की जा सकती हैं।

**क्या Aspose.Slides प्रस्तुति सहेजते समय बाहरी XLSX को ओवरराइट करता है?**

प्रस्तुति में [**link to the external file**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) संग्रहीत होता है। सेल‑बैक्ड चार्ट डेटा को संपादित करने से लिंक्ड स्थानीय XLSX फ़ाइल भी अपडेट हो सकती है। यदि मूल फ़ाइल को अपरिवर्तित रखना है, तो वर्कबुक की एक कॉपी उपयोग करें।

**यदि बाहरी फ़ाइल पासवर्ड‑सुरक्षित है तो क्या करना चाहिए?**

Aspose.Slides लिंक करते समय पासवर्ड स्वीकार नहीं करता। सामान्य उपाय है कि पहले सुरक्षा हटाएँ या एक डिक्रीप्टेड कॉपी (जैसे [Aspose.Cells](https://reference.aspose.com/cells/cpp/)) तैयार करें और उस कॉपी को लिंक करें।

**क्या कई चार्ट एक ही बाहरी वर्कबुक को संदर्भित कर सकते हैं?**

हाँ। प्रत्येक चार्ट अपना लिंक संग्रहीत करता है। यदि सभी एक ही फ़ाइल की ओर इशारा करते हैं, तो उस फ़ाइल को अपडेट करने से अगली बार डेटा लोड होने पर सभी चार्ट पर परिवर्तन प्रतिबिंबित होंगे।