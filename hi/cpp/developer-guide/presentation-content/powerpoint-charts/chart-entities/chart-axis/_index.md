---
title: C++ का उपयोग करके प्रस्तुतियों में चार्ट अक्षों को अनुकूलित करें
linktitle: चार्ट अक्ष
type: docs
url: /hi/cpp/chart-axis/
keywords:
- चार्ट अक्ष
- लंबवत अक्ष
- क्षैतिज अक्ष
- अक्ष को अनुकूलित करें
- अक्ष को हेरफेर करें
- अक्ष को प्रबंधित करें
- अक्ष गुण
- अधिकतम मान
- न्यूनतम मान
- अक्ष रेखा
- तिथि स्वरूप
- अक्ष शीर्षक
- अक्ष स्थिति
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ का उपयोग करके PowerPoint प्रस्तुतियों में रिपोर्ट और विज़ुअलाइज़ेशन के लिये चार्ट अक्षों को कैसे अनुकूलित करें, यह जानें।"
---
## **अवलोकन**

यह लेख Aspose.Slides for C++ के साथ चार्ट अक्षों को अनुकूलित करने के तरीके को समझाता है। यह गणना किए गए अक्ष मान, चार्ट पंक्तियों और स्तंभों को बदलना, अक्ष की दृश्यता, श्रेणी लेबल और टिक‑मार्क अंतराल, तिथि श्रेणियाँ और स्वरूपण, शीर्षक घूर्णन, अक्ष स्थिति, प्रदर्शन इकाइयाँ, और लघुगणकीय स्केलिंग को कवर करता है।

## **चार्ट में लंबवत अक्ष पर अधिकतम मान प्राप्त करें**

एक [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) बनाएं और डिफ़ॉल्ट डेटा के साथ एक एरिया चार्ट जोड़ें। गणना किए गए अक्ष मान पढ़ने से पहले [ValidateChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/validatechartlayout/) को कॉल करें ताकि चार्ट लेआउट अद्यतन रहे।

[get_ActualMaxValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmaxvalue/) और [get_ActualMinValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminvalue/) को अक्ष सीमाओं के लिए पढ़ें, और [get_ActualMajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmajorunit/) तथा [get_ActualMinorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminorunit/) को टिक अंतराल के लिए। [get_ActualMajorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmajorunitscale/) और [get_ActualMinorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminorunitscale/) समय‑इकाई स्केल प्रदान करते हैं, जो तिथि अक्षों के लिए प्रासंगिक हैं। उदाहरण इन मानों को स्थानीय चर में संग्रहीत करता है और चार्ट सहेजता है।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Area, 100, 100, 500, 350);
chart->ValidateChartLayout();

auto maxValue = chart->get_Axes()->get_VerticalAxis()->get_ActualMaxValue();
auto minValue = chart->get_Axes()->get_VerticalAxis()->get_ActualMinValue();

auto majorUnit = chart->get_Axes()->get_VerticalAxis()->get_ActualMajorUnit();
auto minorUnit = chart->get_Axes()->get_VerticalAxis()->get_ActualMinorUnit();

auto majorUnitScale = chart->get_Axes()->get_VerticalAxis()->get_ActualMajorUnitScale();
auto minorUnitScale = chart->get_Axes()->get_VerticalAxis()->get_ActualMinorUnitScale();

presentation->Save(u"AxisValues_out.pptx", SaveFormat::Pptx);
```

## **अक्षों के बीच डेटा स्वैप करें**

[SwitchRowColumn](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/switchrowcolumn/) का उपयोग करके चार्ट डेटा में श्रृंखला और श्रेणियों की भूमिकाएँ बदलें। प्रत्येक पूर्व श्रेणी एक श्रृंखला बनती है, और प्रत्येक पूर्व श्रृंखला एक श्रेणी बनती है। यह डेटा समूह को बदलता है; यह क्षैतिज और लंबवत अक्षों को नहीं बदलता। उदाहरण [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/setrange/) का उपयोग करके डिफ़ॉल्ट डेटा को `Sheet1!A1:D5` से bind करता है, जिसमें हेडर पंक्ति और श्रेणी स्तंभ शामिल हैं, फिर पंक्तियों और स्तंभों को स्वैप करता है। यह चार श्रृंखला और तीन श्रेणियों के साथ एक चार्ट सहेजता है।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartData.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100, 100, 400, 300);

chart->get_ChartData()->SetRange(u"Sheet1!A1:D5");
chart->get_ChartData()->SwitchRowColumn();

presentation->Save(u"SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
```

## **एक अक्ष के प्लॉटिंग क्रम को उलटना**

[set_IsPlotOrderReversed](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isplotorderreversed/) का उपयोग करके किसी श्रेणी या मान अक्ष को उलटा जा सकता है। उदाहरण के लिए, एक क्षैतिज बार चार्ट कार्य चरणों को शीर्ष से निचले तक उसी क्रम में दिखा सकता है जैसे कार्यपत्र में: Planning, Development, Testing। अक्ष को उलटना प्लॉटिंग दिशा बदलता है; यह कार्यपत्र डेटा को क्रमबद्ध या पुनर्व्यवस्थित नहीं करता। तुलना के लिए, [SwitchRowColumn](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/switchrowcolumn/) श्रृंखला और श्रेणियों की भूमिकाएँ बदलता है।

निम्न उदाहरण तीन चरणों और एक श्रृंखला के साथ एक क्षैतिज बार चार्ट बनाता है। यह तीन स्लाइडों के साथ प्रस्तुति सहेजता है: सामान्य क्रम, उलटी श्रेणियाँ, और उलटे मान। प्रत्येक कॉपी समान डेटासेट का उपयोग करती है, और प्रत्येक कॉपी में केवल एक अक्ष उलटा जाता है।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/CrossesType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredBar, 50, 40, 620, 320);
chart->set_HasLegend(false);

chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::ClusteredBar);
auto stages = std::array<System::String, 3>{u"Planning", u"Development", u"Testing"};
auto values = std::array<int, 3>{10, 30, 20};
for (auto i = 0; i < stages.size(); i++)
{
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(stages[i]));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);
    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(values[i]));
    series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
}

// स्लाइड 2: पहली श्रेणी को शीर्ष पर दिखाएँ.
auto categorySlide = presentation->get_Slides()->AddClone(slide);
auto categoryChart = System::ExplicitCast<IChart>(categorySlide->get_Shape(0));
categoryChart->get_Axes()->get_VerticalAxis()->set_IsPlotOrderReversed(true);
// क्षैतिज मान अक्ष को नीचे रखें.
categoryChart->get_Axes()->get_VerticalAxis()->set_CrossType(CrossesType::Maximum);

// स्लाइड 3: केवल क्षैतिज संख्यात्मक स्केल को उलटें.
auto valueSlide = presentation->get_Slides()->AddClone(slide);
auto valueChart = System::ExplicitCast<IChart>(valueSlide->get_Shape(0));
valueChart->get_Axes()->get_HorizontalAxis()->set_IsPlotOrderReversed(true);

presentation->Save(u"ReversedAxes.pptx", SaveFormat::Pptx);
```

अक्ष को उलटना परस्पर अक्ष को प्लॉट के विपरीत पक्ष पर भी ले जा सकता है। [set_CrossType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crosstype/) निर्धारित करता है कि अन्य अक्ष किस स्थान पर पार करता है। स्लाइड 2 में, उलटे श्रेणी अक्ष पर `Maximum` सेट करने से क्षैतिज मान अक्ष नीचे रहता है। विशिष्ट पार बिंदु के लिए, [set_CrossAt](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crossat/) का प्रयोग करें। दिशा बदलते समय पार सेटिंग्स की जाँच करें, विशेषकर यदि चार्ट में पहले से कस्टम पार बिंदु है। सामान्य प्लॉटिंग दिशा को पुनर्स्थापित करने के लिए `set_IsPlotOrderReversed` को `false` के साथ कॉल करें; पार सेटिंग्स अलग रहती हैं।

| सामान्य क्रम (स्लाइड 1) | उलटी श्रेणियाँ (स्लाइड 2) | उलटे मान (स्लाइड 3) |
| --- | --- | --- |
| ![सामान्य श्रेणी और मान अक्ष क्रम के साथ क्षैतिज बार चार्ट](axis-order-normal.png) | ![श्रेणियों को शीर्ष से निचले तक प्रदर्शित करने वाला क्षैतिज बार चार्ट](axis-order-categories-reversed.png) | ![उलटे मान अक्ष और दाएँ शून्य के साथ क्षैतिज बार चार्ट](axis-order-values-reversed.png) |
| श्रेणियाँ नीचे से ऊपर तक चलती हैं; मान बाएँ से दाएँ बढ़ते हैं। | Planning, Development, और Testing शीर्ष से नीचे तक चलते हैं। मान और कार्यपत्र पंक्ति क्रम अपरिवर्तित रहता है। | श्रेणियाँ उनका सामान्य क्रम बनाए रखती हैं; मान दाएँ से बाएँ बढ़ते हैं। श्रेणी अक्ष दाएँ शून्य पर पार करता है। |

## **लाइन चार्ट के लिए लंबवत अक्ष को अक्षम करें**

[set_IsVisible](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isvisible/) को `false` के साथ लंबवत अक्ष पर उपयोग करके उसे छिपाएँ। उदाहरण डिफ़ॉल्ट डेटा के साथ एक लाइन चार्ट बनाता है और उसे लंबवत अक्ष छिपा कर सहेजता है।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 100, 100, 400, 300);
chart->get_Axes()->get_VerticalAxis()->set_IsVisible(false);

presentation->Save(u"HiddenVerticalAxis.pptx", SaveFormat::Pptx);
```

## **लाइन चार्ट के लिए क्षैतिज अक्ष को अक्षम करें**

[set_IsVisible](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isvisible/) को `false` के साथ क्षैतिज अक्ष पर उपयोग करके उसे छिपाएँ। उदाहरण डिफ़ॉल्ट डेटा के साथ एक लाइन चार्ट बनाता है और उसे क्षैतिज अक्ष छिपा कर सहेजता है।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 100, 100, 400, 300);
chart->get_Axes()->get_HorizontalAxis()->set_IsVisible(false);

presentation->Save(u"HiddenHorizontalAxis.pptx", SaveFormat::Pptx);
```

## **श्रेणी अक्ष बदलें**

[set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_categoryaxistype/) का उपयोग करके तिथि या पाठ श्रेणी अक्ष चुना जा सकता है। इस उदाहरण के लिए `ExistingChart.pptx` आवश्यक है, जिसमें पहले स्लाइड की पहली आकृति के रूप में एक चार्ट है और श्रेणी कोशिकाएँ संख्यात्मक Excel तिथि मान रखती हैं। यह क्षैतिज अक्ष को तिथि अक्ष में बदलता है। [set_IsAutomaticMajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isautomaticmajorunit/) को `false` के साथ, [set_MajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majorunit/) को `1` के साथ, और [set_MajorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majorunitscale/) को महीने के साथ सेट करने से प्रमुख टिक एक‑महीना अंतराल पर रखे जाते हैं।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/CategoryAxisType.h>
#include <DOM/Chart/TimeUnitType.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"ExistingChart.pptx");
auto slide = presentation->get_Slide(0);

auto chart = System::ExplicitCast<IChart>(slide->get_Shape(0));
chart->get_Axes()->get_HorizontalAxis()->set_CategoryAxisType(CategoryAxisType::Date);
chart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticMajorUnit(false);
chart->get_Axes()->get_HorizontalAxis()->set_MajorUnit(1);
chart->get_Axes()->get_HorizontalAxis()->set_MajorUnitScale(TimeUnitType::Months);

presentation->Save(u"ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
```

## **श्रेणी अक्ष लेबल अंतराल को नियंत्रित करें**

जब चार्ट में बहुत सारी श्रेणियाँ होती हैं, तो श्रेणियों या डेटा बिंदुओं को हटाए बिना दिखने वाले अक्ष लेबलों की संख्या घटाएँ। [set_IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomaticticklabelspacing/) को `false` करें, फिर इच्छित श्रेणी अंतराल के साथ [set_TickLabelSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_ticklabelspacing/) का प्रयोग करें। सामान्य क्रम में पाठ श्रेणियों के लिए, गिनती पहली श्रेणी से शुरू होती है:

| अंतराल | उदाहरण में प्रदर्शित लेबल |
| --- | --- |
| `1` | श्रेणी 1, श्रेणी 2, श्रेणी 3, … श्रेणी 24 |
| `2` | श्रेणी 1, श्रेणी 3, श्रेणी 5, … श्रेणी 23 |
| `3` | श्रेणी 1, श्रेणी 4, श्रेणी 7, … श्रेणी 22 |

`3` का अंतराल प्रत्येक तीसरे लेबल को दिखाता है, और प्रदर्शित लेबलों के बीच दो लेबल छिपे रहते हैं। यह संबंधित स्तंभों को नहीं हटाता। स्वतः स्पेसिंग उपलब्ध जगह के आधार पर अंतराल चुनती है; यह आवश्यक रूप से प्रत्येक लेबल को नहीं दिखाती।

टिक‑मार्क के लिए अलग नियंत्रण होते हैं। [set_IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomatictickmarksspacing/) को `false` करें और [set_TickMarksSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_tickmarksspacing/) से उनका अंतराल सेट करें। उदाहरण के लिए, `1` प्रत्येक श्रेणी अंतराल पर एक टिक मार्क रखता है जबकि लेबल केवल प्रत्येक तीसरी श्रेणी पर दिखते हैं। एक दिखाई देने वाली शैली के साथ [set_MajorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_majortickmark/) का प्रयोग करें ताकि आप परिणाम देख सकें। किसी भी स्वतः‑स्पेसिंग गुण को फिर से `true` करने से चार्ट को वही अंतराल फिर से चुनने की अनुमति मिलती है।

निम्न स्वनिर्भर उदाहरण 24 श्रेणियों और एक श्रृंखला बनाता है, फिर `CategoryAxisIntervals.pptx` में तीन स्लाइड सहेजता है: स्वतः स्पेसिंग, स्वतंत्र टिक‑मार्क के साथ मैन्युअल लेबल स्पेसिंग, और पुनर्स्थापित स्वतः स्पेसिंग। दो कॉपी मूल चार्ट डेटा को बनाए रखती हैं। इनपुट प्रस्तुति की आवश्यकता नहीं है। क्षैतिज लेबल टेक्स्ट घनत्व अंतर को आसानी से दिखाता है।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/CategoryAxisType.h>
#include <DOM/Chart/TickMarkType.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IChartTextBlockFormat.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <system/object_ext.h>
#include <DOM/ISlideCollection.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 30, 40, 660, 320);

chart->set_HasLegend(false);
chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::ClusteredColumn);
for (auto i = 0; i < 24; i++)
{
    auto categoryName = System::String::Format(u"Category {0}", i + 1);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(categoryName));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);
    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(10 + i % 6 * 5));
    series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
}

auto axis = chart->get_Axes()->get_HorizontalAxis();
axis->set_CategoryAxisType(CategoryAxisType::Text);
axis->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(0);
axis->get_TextFormat()->get_PortionFormat()->set_FontHeight(12);
axis->set_MajorTickMark(TickMarkType::Outside);
axis->set_IsAutomaticTickLabelSpacing(true);
axis->set_IsAutomaticTickMarksSpacing(true);

// स्लाइड 2: प्रत्येक तीसरा लेबल दिखाएँ, लेकिन हर श्रेणी के लिए टिक‑मार्क रखें।
auto manualSlide = presentation->get_Slides()->AddClone(slide);
auto manualChart = System::ExplicitCast<IChart>(manualSlide->get_Shape(0));
auto manualAxis = manualChart->get_Axes()->get_HorizontalAxis();
manualAxis->set_IsAutomaticTickLabelSpacing(false);
manualAxis->set_TickLabelSpacing(3);
manualAxis->set_IsAutomaticTickMarksSpacing(false);
manualAxis->set_TickMarksSpacing(1);

// स्लाइड 3: चार्ट को फिर से दोनों अंतराल चुनने दें।
auto restoredSlide = presentation->get_Slides()->AddClone(manualSlide);
auto restoredChart = System::ExplicitCast<IChart>(restoredSlide->get_Shape(0));
restoredChart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticTickLabelSpacing(true);
restoredChart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticTickMarksSpacing(true);

presentation->Save(u"CategoryAxisIntervals.pptx", SaveFormat::Pptx);
```

**ऑटोमेटिक स्पेसिंग (स्लाइड 1):** इस दृश्य में प्रत्येक दूसरी श्रेणी लेबल प्रदर्शित होती है और दो पंक्तियों में विभाजित होती है। स्वतः परिणाम चार्ट आकार, फ़ॉन्ट और रेंडरर के अनुसार बदल सकता है।

![सभी 24 स्तंभ दृश्यमान के साथ स्वचालित श्रेणी लेबल स्पेसिंग](category-axis-automatic.png)

**मैन्युअल स्पेसिंग (स्लाइड 2):** प्रत्येक तीसरा लेबल एक पंक्ति में दिखता है, जबकि टिक‑मार्क प्रत्येक श्रेणी अंतराल पर रहता है। सभी 24 स्तंभ, जिसमें लेबल‑रहित भी शामिल हैं, समान मानों के साथ दृश्यमान रहते हैं। स्लाइड 3 ऊपर दिखाए गए स्वतः स्वरूप को पुनर्स्थापित करता है।

![सभी 24 स्तंभ दृश्यमान के साथ तीन का मैन्युअल श्रेणी लेबल अंतराल](category-axis-manual.png)

### **सही अक्ष और अंतराल चुनें**

पाठ श्रेणी अक्ष के लिए इस श्रेणी‑गणना अंतराल का उपयोग करें, जैसे कॉलम, लाइन, एरिया या बार चार्ट का श्रेणी अक्ष। कॉलम चार्ट में यह क्षैतिज अक्ष होता है। क्षैतिज बार चार्ट में श्रेणी अक्ष लम्बवत होता है, इसलिए इसे [get_VerticalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_verticalaxis/) पर लागू करें। टिक‑मार्क स्पेसिंग उस चार्ट में श्रृंखला अक्ष पर भी लागू होती है जिसमें वह मौजूद है।

मान अक्ष के संख्यात्मक स्केल को सेट करने के लिए श्रेणी लेबल स्पेसिंग का प्रयोग न करें। मान अक्ष पर, [set_MajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_majorunit/) मानों के अंतर को निर्दिष्ट करता है: उदाहरण के लिए, `10` का प्रमुख इकाई 0, 10, 20 आदि पर टिक बनाता है जब अक्ष शून्य से शुरू होता है। `3` का श्रेणी लेबल अंतराल केवल श्रेणी स्थितियों को गिनता है, उनके डेटा मानों की परवाह किए बिना। स्कैटर और बबल चार्ट मान अक्षों का प्रयोग करते हैं, न कि पाठ श्रेणी अक्ष का। तिथि अक्ष के लिए, [Change a Category Axis](#change-a-category-axis) में वर्णित समय‑आधारित प्रमुख इकाइयाँ और स्केल का प्रयोग करें।

## **श्रेणी अक्ष मानों के लिए तिथि फ़ॉर्मेट सेट करें**

उदाहरण डिफ़ॉल्ट चार्ट डेटा को चार वार्षिक मानों से बदलता है। तिथियाँ पहले कार्यपत्र (सूचकांक `0`) में OLE Automation क्रमांक के रूप में संग्रहीत होती हैं। तिथि अक्ष चुनने के लिए [set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_categoryaxistype/) का प्रयोग करें, स्रोत‑संलग्न फ़ॉर्मेटिंग को अक्षम करने के लिए [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isnumberformatlinkedtosource/) का उपयोग करें, और श्रेणी लेबल को चार-अंकीय वर्ष दिखाने के लिए `yyyy` को [set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_numberformat/) से असाइन करें, जिससे यह कोशिका फ़ॉर्मेट से स्वतंत्र हो जाता है।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/CategoryAxisType.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <system/object_ext.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 50, 50, 450, 300);

chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::Line);
for (auto i = 0; i < 4; i++)
{
    auto date = System::DateTime(2015 + i, 1, 1);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(date.ToOADate()));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);

    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(i + 1));
    series->get_DataPoints()->AddDataPointForLineSeries(valueCell);
}

chart->get_Axes()->get_HorizontalAxis()->set_CategoryAxisType(CategoryAxisType::Date);
chart->get_Axes()->get_HorizontalAxis()->set_IsNumberFormatLinkedToSource(false);
chart->get_Axes()->get_HorizontalAxis()->set_NumberFormat(u"yyyy");

presentation->Save(u"DateAxisFormat.pptx", SaveFormat::Pptx);
```

## **चार्ट अक्ष शीर्षक के लिए घूर्णन कोण सेट करें**

[set_HasTitle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_hastitle/) के साथ लंबवत‑अक्ष शीर्षक को सक्रिय करें, शीर्षक पाठ प्रदान करें, और [set_RotationAngle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/icharttextblockformat/set_rotationangle/) का प्रयोग करके शीर्षक को घुमाएँ। कोण डिग्री में मापा जाता है; यह उदाहरण मूल्य‑अक्ष शीर्षक को 90 डिग्री घुमा कर एक कॉलम चार्ट सहेजता है।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IChartTextBlockFormat.h>
#include <DOM/Chart/IChartTitle.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
chart->get_Axes()->get_VerticalAxis()->set_HasTitle(true);
chart->get_Axes()->get_VerticalAxis()->get_Title()->AddTextFrameForOverriding(u"Value");
chart->get_Axes()->get_VerticalAxis()->get_Title()->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(90);

presentation->Save(u"RotatedAxisTitle.pptx", SaveFormat::Pptx);
```

## **श्रेणी या मान अक्ष पर अक्ष की स्थिति सेट करें**

[set_AxisBetweenCategories](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_axisbetweencategories/) का उपयोग करके तय करें कि मान अक्ष श्रेणी अक्ष के बीच श्रेणियों पर या श्रेणी टिक‑मार्क पर पार करे। यह गुण केवल श्रेणी अक्षों पर लागू होता है। उदाहरण इसे कॉलम चार्ट के क्षैतिज श्रेणी अक्ष पर `true` सेट करता है और परिणाम सहेजता है।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
chart->get_Axes()->get_HorizontalAxis()->set_AxisBetweenCategories(true);

presentation->Save(u"AxisBetweenCategories.pptx", SaveFormat::Pptx);
```

## **चार्ट मान अक्ष पर प्रदर्शन इकाई सेट करें**

[set_DisplayUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_displayunit/) का प्रयोग करके मान अक्ष पर लेबल स्केल किया जा सकता है जबकि मूल डेटा नहीं बदलता। जब [DisplayUnitType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/displayunittype/) `Millions` पर सेट हो, तो 60,000,000 का मान 60 के रूप में दिखाया जाता है। उदाहरण एक कॉलम चार्ट बनाता है और उसके लंबवत अक्ष पर मिलियन प्रदर्शन इकाई लागू करता है।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/DisplayUnitType.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
chart->get_Axes()->get_VerticalAxis()->set_DisplayUnit(DisplayUnitType::Millions);

presentation->Save(u"Result.pptx", SaveFormat::Pptx);
```

## **लघुगणकीय मान अक्ष को कॉन्फ़िगर करें**

लघुगणकीय मान अक्ष तब उपयोगी होता है जब सकारात्मक मान कई क्रम magnitude में फैले हों। उदाहरण के लिए, एक सेवा पाँच अवधियों में 10, 100, 1 000, 10 000, और 100 000 अनुरोध प्राप्त कर सकती है। रैखिक स्केल पर छोटे मान शून्य के निकट एक साथ दिखते हैं। लघुगणकीय स्केल उनके सापेक्ष वृद्धि को तुलना करना आसान बनाता है: समान दूरी समान अनुपात दर्शाती है, न कि समान अंतर।

मान अक्ष पर [set_IsLogarithmic](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_islogarithmic/) को `true` करें और बेस चुनने के लिए [set_LogBase](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_logbase/) का प्रयोग करें। यह मौजूदा मानों के प्रदर्शित होने के तरीके को बदलता है; यह डेटा नहीं बदलता और न ही लघुगणकीय ट्रेंड लाइन जोड़ता है। ट्रेंड लाइन डेटा में फिट की गई रिलेशनशिप को दर्शाता है और एक अलग विशेषता है।

### **मान अक्ष और आधार चुनें**

लाइन या कॉलम चार्ट के लिए, मान अक्ष [get_VerticalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_verticalaxis/) है। क्षैतिज बार चार्ट के लिए यह [get_HorizontalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_horizontalaxis/) है। स्कैटर और बबल चार्ट में दो मान अक्ष होते हैं, इसलिए X मानों के लिए क्षैतिज अक्ष, Y मानों के लिए लंबवत अक्ष, या दोनों चुनें। श्रेणी अक्ष पर लघुगणकीय स्केलिंग लागू न करें।

डिफ़ॉल्ट लघुगणकीय आधार `10` है। PPTX चार्ट के लिए, `2` से `1000` तक का आधार (समावेशी) उपयोग किया जा सकता है; अंशात्मक आधार जैसे `2.5` भी समर्थित हैं। बेस `10` पर क्रमागत शक्ति जैसे 10, 100, 1 000, 10 000 समान अंतराल पर होते हैं।

### **रैखिक और लघुगणकीय स्केलिंग की तुलना**

निम्न स्वनिर्भर उदाहरण पहले स्लाइड पर पाँच अनुरोध गिनतियों के साथ एक लाइन चार्ट बनाता है, फिर उस स्लाइड को क्लोन करके दूसरी स्लाइड पर बेस‑10 लघुगणकीय मान अक्ष सक्षम करता है। दोनों स्लाइड समान डेटा रखती हैं।

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
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 30, 40, 660, 200);

chart->set_HasLegend(false);

chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::Line);
auto values = std::array<double, 5>{10, 100, 1000, 10000, 100000};

for (auto i = 0; i < values.size(); i++)
{
    auto categoryName = System::String::Format(u"Period {0}", i + 1);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(categoryName));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);

    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(values[i]));
    series->get_DataPoints()->AddDataPointForLineSeries(valueCell);
}

// पहली स्लाइड को रैखिक रखें और केवल कॉपी के मान-अक्ष स्केल को बदलें।
auto logarithmicSlide = presentation->get_Slides()->AddClone(slide);
auto logarithmicChart = System::ExplicitCast<IChart>(logarithmicSlide->get_Shape(0));
auto valueAxis = logarithmicChart->get_Axes()->get_VerticalAxis();
valueAxis->set_IsLogarithmic(true);
valueAxis->set_LogBase(10);

presentation->Save(u"LogarithmicAxis.pptx", SaveFormat::Pptx);
```

**रैखिक स्केल (स्लाइड 1):** समान लंबवत दूरी अनुरोध गिनतियों के समान अंतर को दर्शाती है। सबसे बड़ा मान चार्ट को हावी करता है, जिससे छोटे मानों को पहचानना कठिन हो जाता है।

![रैखिक मान अक्ष पर पाँच अनुरोध गिनतियों को दिखाता हुआ लाइन चार्ट](value-axis-linear.png)

**लघुगणकीय स्केल (स्लाइड 2):** समान लंबवत दूरी समान अनुपात को दर्शाती है। प्रत्येक अवधि में अनुरोध पिछले की तुलना में दस गुना अधिक होते हैं, इसलिए बिंदु बेस‑10 स्केल पर एक सीधी बढ़ती रेखा बनाते हैं। अक्ष लेबल अभी भी मूल अनुरोध गिनतियों को दिखाते हैं।

![बेस‑10 लघुगणकीय मान अक्ष पर वही पाँच अनुरोध गिनतियां दर्शाता हुआ चार्ट](value-axis-logarithmic.png)

### **शून्य और नकारात्मक मानों को संभालें**

लघुगणकीय स्केल केवल शून्य से बड़े मानों को दिखा सकता है। इसे सक्षम करने से पहले डेटा की जाँच करें। यदि शून्य या नकारात्मक मान सार्थक हैं, तो रैखिक स्केल रखें या उन्हें अलग से दिखाएँ। यदि विश्लेषण के लिए उन मानों को बाहर करना उचित है, तो बहिष्करण की व्याख्या दें। उन्हें छोटे सकारात्मक संख्याओं से चुपचाप बदलें नहीं, क्योंकि इससे डेटा का अर्थ बदल जाता है। लघुगणकीय अक्ष के लिए कोई भी मैन्युअल न्यूनतम या अधिकतम मान भी सकारात्मक होना चाहिए।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं किसी अक्ष के दूसरे अक्ष को पार करने के मान को कैसे सेट करूँ (अक्ष पार करना)?**

[set_CrossType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crosstype/) का प्रयोग करके पार व्यवहार चुनें। संख्यात्मक पार मान निर्दिष्ट करने के लिए [set_CrossAt](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crossat/) का उपयोग करें। ये सेटिंग्स आपको अक्ष पार को उपयुक्त बेसलाइन पर ले जाने की अनुमति देती हैं।

**मैं टिक लेबल को अक्ष के सापेक्ष कैसे स्थित करूँ?**

[TickLabelPositionType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ticklabelpositiontype/) से `Low`, `High`, `NextTo` या `None` मान के साथ [set_TickLabelPosition](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_ticklabelposition/) का उपयोग करें। टिक‑मार्क स्वयं को नियंत्रित करने के लिए, [set_MajorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majortickmark/) या [set_MinorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_minortickmark/) का प्रयोग करें; ये लेबल स्थिति से अलग होते हैं।